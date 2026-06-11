Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting

Public Class FINRT0016
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "FINRT0016"

    Dim AssignToDT As New DataTable

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' User info
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

    End Sub


#End Region

#Region "Button"

    Protected Sub btnGenerate_Click(ByVal sender As Object, e As EventArgs)


        If ddlReport.SelectedValue = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf tbxDate.Value = "" Then
            Alert("error", "Some fields are missing!", "")
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0016.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0016.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0017.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0017.rdlc"))
        'copy template report

        'view report
        Dim ptype = ddlReport.SelectedValue
        Dim pDate = tbxDate.Value
        Dim pcrdtr_type = ddlcrdtr_type.SelectedValue
        Dim pcrdtr_code = ddlcrdtr_code.SelectedValue
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode & "&ptype=" & ptype & "&pDate=" & pDate & "&pcrdtr_type=" & pcrdtr_type & "&pcrdtr_code=" & pcrdtr_code & "');", True)
        'view report

    End Sub

    Protected Sub ddlcrdtr_type_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case ddlcrdtr_type.SelectedValue
            Case "Agent"
                BindAgent()
            Case "Customer"
                BindCustomer()
            Case "Employee"
                BindEmployee()
            Case "Vendor"
                BindVendor()
            Case Else
                ddlcrdtr_code.Items.Clear()
                ddlcrdtr_code.Items.Add(New ListItem("Please select a type first", ""))
        End Select
    End Sub


#End Region

#Region "Function"

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

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String, AdditionalScript As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & AdditionalScript & "Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function BindAgent()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Agent' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].agent_code [Code] ")
        Query.Append("   ,[A].fullname [Name] ")
        Query.Append("   ,[A].agent_code [Order] ")
        Query.Append("from ")
        Query.Append("   agent [A] ")
        Query.Append("where ")
        Query.Append(" lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Name] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query




        'fill data
        ddlcrdtr_code.DataSource = DT
        ddlcrdtr_code.DataValueField = "Code"
        ddlcrdtr_code.DataTextField = "Name"
        ddlcrdtr_code.DataBind()
        'fill data

    End Function

    Function BindCustomer()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Customer' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].cust_code [Code] ")
        Query.Append("   ,[A].fullname [Name] ")
        Query.Append("   ,[A].cust_code [Order] ")
        Query.Append("from ")
        Query.Append("   customer [A] ")
        Query.Append("where ")
        Query.Append(" lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Name] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query




        'fill data
        ddlcrdtr_code.DataSource = DT
        ddlcrdtr_code.DataValueField = "Code"
        ddlcrdtr_code.DataTextField = "Name"
        ddlcrdtr_code.DataBind()
        'fill data

    End Function

    Function BindEmployee()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Agent' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].emp_no [Code] ")
        Query.Append("   ,[A].fullname [Name] ")
        Query.Append("   ,[A].emp_no [Order] ")
        Query.Append("from ")
        Query.Append("   employee [A] ")
        Query.Append("where ")
        Query.Append(" lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Name] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query




        'fill data
        ddlcrdtr_code.DataSource = DT
        ddlcrdtr_code.DataValueField = "Code"
        ddlcrdtr_code.DataTextField = "Name"
        ddlcrdtr_code.DataBind()
        'fill data

    End Function

    Function BindVendor()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select vendor' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].v_code [Code] ")
        Query.Append("   ,[A].vendor [Name] ")
        Query.Append("   ,[A].v_code [Order] ")
        Query.Append("from ")
        Query.Append("   ogm_vendor [A] ")
        Query.Append("where ")
        Query.Append(" lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Name] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query




        'fill data
        ddlcrdtr_code.DataSource = DT
        ddlcrdtr_code.DataValueField = "Code"
        ddlcrdtr_code.DataTextField = "Name"
        ddlcrdtr_code.DataBind()
        'fill data

    End Function


#End Region

End Class