Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting
Public Class FINRT0013
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim FormCode As String = "FINRT0013"

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

        'Only bind dropdown on the first load
        If Not IsPostBack Then
            BindSubd()
        End If
        'load

    End Sub


#End Region

#Region "Button"

    Protected Sub btnGenerate_Click(ByVal sender As Object, e As EventArgs)

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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0013.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0013.rdlc"))

        'copy template report

        'view report
        Dim pSubd = ddlsubd.SelectedValue
        Dim pPhase = ddlphase.SelectedValue
        Dim pBlock = ddlblock.SelectedValue
        Dim pLot = ddllot.SelectedValue
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode &
        "&pSubd=" & pSubd & "&pPhase=" & pPhase & "&pBlock=" & pBlock & "&pLot=" & pLot & "');", True)
        'view report

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



    Function BindSubd()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subdivision' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].code [Code] ")
        Query.Append("   ,[A].description [Name] ")
        Query.Append("   ,[A].code [Order] ")
        Query.Append("from ")
        Query.Append("   subdivision [A] ")
        Query.Append("where ")
        Query.Append(" lock = 1 ")
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
        ddlsubd.DataSource = DT
        ddlsubd.DataValueField = "Code"
        ddlsubd.DataTextField = "Name"
        ddlsubd.DataBind()
        'fill data

    End Function

    Private Sub ddlAdd_Subd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlsubd.SelectedIndexChanged
        BindPhase(ddlsubd.SelectedValue)
    End Sub

    Function BindPhase(SubdCode)

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Phase' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].code [Code] ")
        Query.Append("   ,[A].description [Name] ")
        Query.Append("   ,[A].code [Order] ")
        Query.Append("from ")
        Query.Append("   phase [A] ")
        Query.Append("where ")
        Query.Append("   [A].scode = '" & SubdCode & "' ")
        Query.Append(" and [A].lock = 1 ")
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
        ddlphase.DataSource = DT
        ddlphase.DataValueField = "Code"
        ddlphase.DataTextField = "Name"
        ddlphase.DataBind()
        'fill data

    End Function

    Private Sub ddlAdd_Phase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlphase.SelectedIndexChanged
        BindBlock(ddlphase.SelectedValue)
    End Sub

    Function BindBlock(PhaseCode)

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Block' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].B_code [Code] ")
        Query.Append("   ,[A].block [Name] ")
        Query.Append("   ,[A].B_code [Order] ")
        Query.Append("from ")
        Query.Append("   eng_block [A] ")
        Query.Append("where ")
        Query.Append("   [A].s_code = '" & PhaseCode & "' ")
        Query.Append(" and [A].lock = 1 ")
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
        ddlblock.DataSource = DT
        ddlblock.DataValueField = "Code"
        ddlblock.DataTextField = "Name"
        ddlblock.DataBind()
        'fill data

    End Function

    Private Sub ddlAdd_Block_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlblock.SelectedIndexChanged
        Bindlot(ddlblock.SelectedValue)
    End Sub

    Function Bindlot(BlockCode)

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Lot' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].l_code [Code] ")
        Query.Append("   ,[A].lot [Name] ")
        Query.Append("   ,[A].l_code [Order] ")
        Query.Append("from ")
        Query.Append("   eng_lot [A] ")
        Query.Append("where ")
        Query.Append("   [A].b_code = '" & BlockCode & "' ")
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
        ddllot.DataSource = DT
        ddllot.DataValueField = "Code"
        ddllot.DataTextField = "Name"
        ddllot.DataBind()
        'fill data

    End Function










#End Region

End Class