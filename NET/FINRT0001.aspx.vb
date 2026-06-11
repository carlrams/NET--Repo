Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting

Public Class FINRT0001
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "FINRT0001"

    Dim AssignToDT As New DataTable

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'User info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'User info

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
            BindGlchart()
            BindGldiv()
            BindGldept()
        End If
        'load

    End Sub


#End Region

#Region "Button"

    Protected Sub btnGenerate_Click(ByVal sender As Object, e As EventArgs)

        If year.Text = "" Then
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0001.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0001.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0002.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0002.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0003.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0003.rdlc"))
        'copy template report

        'view report
        Dim pyear = year.Text
        Dim pacct_from = ddlchart.SelectedValue
        Dim pacct_to = ddlchart2.SelectedValue
        Dim pacct_srs As String = String.Join(",", lbxchart3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pdiv_from = ddldiv.SelectedValue
        Dim pdiv_to = ddldiv2.SelectedValue
        Dim pdiv_srs As String = String.Join(",", lbxdiv3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pdept_from = ddldept.SelectedValue
        Dim pdept_to = ddldept2.SelectedValue
        Dim pdept_srs As String = String.Join(",", lbxdept3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode &
        "&pyear=" & pyear &
        "&pacct_from=" & pacct_from & "&pacct_to=" & pacct_to & "&pacct_srs=" & Server.UrlEncode(pacct_srs) &
        "&pdiv_from=" & pdiv_from & "&pdiv_to=" & pdiv_to & "&pdiv_srs=" & Server.UrlEncode(pdiv_srs) &
        "&pdept_from=" & pdept_from & "&pdept_to=" & pdept_to & "&pdept_srs=" & Server.UrlEncode(pdept_srs) & "');", True)
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

    Function BindGlchart()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select GL Account' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].acct_code [Code] ")
        Query.Append("   ,[A].description [Name] ")
        Query.Append("   ,[A].acct_code [Order] ")
        Query.Append("from ")
        Query.Append("   fin_chart [A] ")
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
        ddlchart.DataSource = DT
        ddlchart.DataValueField = "Code"
        ddlchart.DataTextField = "Name"
        ddlchart.DataBind()
        'fill data

        'fill data
        ddlchart2.DataSource = DT
        ddlchart2.DataValueField = "Code"
        ddlchart2.DataTextField = "Name"
        ddlchart2.DataBind()
        'fill data

        'fill data
        lbxchart3.DataSource = DT
        lbxchart3.DataValueField = "Code"
        lbxchart3.DataTextField = "Name"
        lbxchart3.DataBind()
        'fill data
    End Function

    Function BindGldiv()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Division' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].abbr [Code] ")
        Query.Append("   ,[A].description [Name] ")
        Query.Append("   ,[A].description [Order] ")
        Query.Append("from ")
        Query.Append("   division [A] ")
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
        ddldiv.DataSource = DT
        ddldiv.DataValueField = "Code"
        ddldiv.DataTextField = "Name"
        ddldiv.DataBind()
        'fill data

        'fill data
        ddldiv2.DataSource = DT
        ddldiv2.DataValueField = "Code"
        ddldiv2.DataTextField = "Name"
        ddldiv2.DataBind()
        'fill data

        'fill data
        lbxdiv3.DataSource = DT
        lbxdiv3.DataValueField = "Code"
        lbxdiv3.DataTextField = "Name"
        lbxdiv3.DataBind()
        'fill data
    End Function

    Function BindGldept()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Department' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].abbr [Code] ")
        Query.Append("   ,[A].description [Name] ")
        Query.Append("   ,[A].description [Order] ")
        Query.Append("from ")
        Query.Append("   department [A] ")
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
        ddldept.DataSource = DT
        ddldept.DataValueField = "Code"
        ddldept.DataTextField = "Name"
        ddldept.DataBind()
        'fill data

        'fill data
        ddldept2.DataSource = DT
        ddldept2.DataValueField = "Code"
        ddldept2.DataTextField = "Name"
        ddldept2.DataBind()
        'fill data

        'fill data
        lbxdept3.DataSource = DT
        lbxdept3.DataValueField = "Code"
        lbxdept3.DataTextField = "Name"
        lbxdept3.DataBind()
        'fill data
    End Function

#End Region

End Class