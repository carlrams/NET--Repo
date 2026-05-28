Imports System.Data.SqlClient
Imports System.IO

Public Class SCMRT0011
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "SCMRT0011"

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
            bindWarehouse()
        End If
        'load

    End Sub

#End Region

#Region "Button"

    Protected Sub btnGenerate_Click(ByVal sender As Object, e As EventArgs)

        If tbxDateFrom.Value = "" Or tbxDateTo.Value = "" Or ddlWarehouse.SelectedValue = "" Then
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/SCMRT0011.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0011.rdlc"))
        'copy template report

        'view report
        Dim pType = ddlType.SelectedValue
        Dim pCharge = ddlCharge.SelectedValue
        Dim pWarehouse = ddlWarehouse.SelectedValue
        Dim pDateFrom = tbxDateFrom.Value
        Dim pDateTo = tbxDateTo.Value
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('SCMRTView?FormCode=" & FormCode & "&pType=" & pType & "&pCharge=" & pCharge & "&pWarehouse=" & pWarehouse & "&pDateFrom=" & pDateFrom & "&pDateTo=" & pDateTo & "');", True)
        'view report

    End Sub

    Function bindCharge(Type As String)
        'get Assigned To
        Dim Query As New StringBuilder

        If Type = "OSM Project" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_misc ")
            Query.Append("where ")
            Query.Append("   account = '07030004' ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Land Development" Or Type = "Subdivision Maintenance" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_subdivision ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Model House" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_house ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Water Connection" Or Type = "Electricity Connection" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_lot ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Office Supplies" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_misc ")
            Query.Append("where ")
            Query.Append("   account = '62010400' ")
            Query.Append("   and code in ('MN2012070011','MN2012070014','MN2012070094') ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Advances (Employee)" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_employee ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Advances (Contractor)" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_vendor ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Service Vehicle" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_misc ")
            Query.Append("where ")
            Query.Append("   account = '62040000' ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "Branch Marketing" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Charge To' [Description] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   code [Code] ")
            Query.Append("   ,description [Description] ")
            Query.Append("   ,description [Order] ")
            Query.Append("from ")
            Query.Append("   sub_misc ")
            Query.Append("where ")
            Query.Append("   account = '62020002' ")
            Query.Append("order by ")
            Query.Append("   [Order] ")
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
        ddlCharge.DataSource = DT
        ddlCharge.DataValueField = "Code"
        ddlCharge.DataTextField = "Description"
        ddlCharge.DataBind()
        'fill data

        upnlParameter.Update()

    End Function

    Private Sub ddlType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlType.SelectedIndexChanged
        bindCharge(ddlType.SelectedValue)
    End Sub

    Function bindWarehouse()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Warehouse' [Description] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   w_code [Code] ")
        Query.Append("   ,warehouse [Description] ")
        Query.Append("   ,warehouse [Order] ")
        Query.Append("from ")
        Query.Append("   ogm_warehouse ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlWarehouse.DataSource = DT
        ddlWarehouse.DataValueField = "Code"
        ddlWarehouse.DataTextField = "Description"
        ddlWarehouse.DataBind()
        'fill data

    End Function

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