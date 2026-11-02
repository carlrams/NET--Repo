Imports System.Data.SqlClient
Imports System.IO

Public Class FINRT0018
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "FINRT0018"

    Dim AssignToDT As New DataTable

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", FormCode)
        'active account / menu

        'Validate Access
        Dim msg As String = Access(CIIS_EmpCode, FormCode, "View")
        If msg <> "1" Then
            Response.Redirect("MNU000022")
        End If
        'Validate Access

        'load
        If Not IsPostBack Then
            bindBank()
        End If
        'load

    End Sub

#End Region

#Region "Button"
    Protected Sub btnGenerate_Click(ByVal sender As Object, e As EventArgs)

        If tbxDateFrom.Value = "" Or tbxDateTo.Value = "" Then
            Alert("error", "Some fields are missing!")
            Exit Sub
        End If

        'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
        End If
        'create new folder


        'remove file within the folder
        Dim RptFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
        Try
            Dim file As FileInfo
            For Each file In RptFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file within the folder

        'copy template report
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0018.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0018.rdlc"))
        'copy template report

        'view report
        Dim pDateFrom = tbxDateFrom.Value
        Dim pDateTo = tbxDateTo.Value
        Dim pBank = ddlBank.SelectedValue
        Dim pCreditor = ddlCreditor.SelectedValue
        Dim pType = ddlType.SelectedValue
        Dim pAmtF = tbxAmtF.Text
        Dim pAmtT = tbxAmtT.Text
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode & "&pDateFrom=" & pDateFrom & "&pDateTo=" & pDateTo & "&pBank=" & pBank & "&pCreditor=" & pCreditor & "&pType=" & pType & "&pAmtF=" & pAmtF & "&pAmtT=" & pAmtT & "');", True)
        'view report

    End Sub

    Function bindBank()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'(Select Bank)' [Description] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   b_code [Code] ")
        Query.Append("   ,bank [Description] ")
        Query.Append("from ")
        Query.Append("   fin_bank ")
        Query.Append("where ")
        Query.Append(" lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Description] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlBank.DataSource = DT
        ddlBank.DataValueField = "Code"
        ddlBank.DataTextField = "Description"
        ddlBank.DataBind()
        'fill data

    End Function

    Function bindType(Creditor As String)
        'get Assigned To
        Dim Query As New StringBuilder

        If Creditor = "Agent" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,' (Select Agent)' [Description] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   agent_code [Code] ")
            Query.Append("   ,fullname [Description] ")
            Query.Append("from ")
            Query.Append("   agent ")
            Query.Append("where ")
            Query.Append(" lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Description] ")


        ElseIf Creditor = "Customer" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,' (Select Customer)' [Description] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   cust_code [Code] ")
            Query.Append("   ,fullname [Description] ")
            Query.Append("from ")
            Query.Append("   customer ")
            Query.Append("where ")
            Query.Append(" lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Description] ")

        ElseIf Creditor = "Employee" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,' (Select Employee)' [Description] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   emp_no [Code] ")
            Query.Append("   ,fullname [Description] ")
            Query.Append("from ")
            Query.Append("   employee ")
            Query.Append("where ")
            Query.Append(" lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Description] ")

        ElseIf Creditor = "Vendor" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,' (Select Vendor)' [Description] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   v_code [Code] ")
            Query.Append("   ,vendor [Description] ")
            Query.Append("from ")
            Query.Append("   ogm_vendor ")
            Query.Append("where ")
            Query.Append(" lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Description] ")
        End If
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlType.DataSource = DT
        ddlType.DataValueField = "Code"
        ddlType.DataTextField = "Description"
        ddlType.DataBind()
        'fill data

    End Function

    Private Sub ddlCreditor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCreditor.SelectedIndexChanged
        bindType(ddlCreditor.SelectedValue)
    End Sub


#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function


    Function Access(EmpCode, FormCode, Action)

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Restriction"
        sqlCmd.Parameters.AddWithValue("@pUserId", EmpCode)
        sqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
        sqlCmd.Parameters.AddWithValue("@pRes", Action)
        Dim oConf As New SqlClient.SqlParameter("@oConf", SqlDbType.NVarChar, 1000)
        oConf.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oConf)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        Return oConf.Value.ToString
    End Function

#End Region

End Class