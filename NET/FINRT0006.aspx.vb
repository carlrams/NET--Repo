Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting

Public Class FINRT0006
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "FINRT0006"

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
            BindGldiv()
            BindGldept()
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0006.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0006.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0007.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0007.rdlc"))
        'copy template report

        'view report
        Dim pyear = year.Text
        Dim pperiod = period.Text
        Dim pdiv_from = dlldiv.SelectedValue
        Dim pdiv_to = dlldiv2.SelectedValue
        Dim pdiv_srs = lbxdiv3.SelectedValue
        Dim pdept_from = dlldept.SelectedValue
        Dim pdept_to = dlldept2.SelectedValue
        Dim pdept_srs = lbxdept3.SelectedValue
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode &
        "&pyear=" & pyear & "&pperiod=" & pperiod &
        "&pdiv_from=" & pdiv_from & "&pdiv_to=" & pdiv_to & "&pdiv_srs=" & pdiv_srs &
        "&pdept_from=" & pdept_from & "&pdept_to=" & pdept_to & "&pdept_srs=" & pdept_srs & "');", True)
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









    Function BindGldiv()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Division' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].div_code [Code] ")
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
        dlldiv.DataSource = DT
        dlldiv.DataValueField = "Code"
        dlldiv.DataTextField = "Name"
        dlldiv.DataBind()
        'fill data

        'fill data
        dlldiv2.DataSource = DT
        dlldiv2.DataValueField = "Code"
        dlldiv2.DataTextField = "Name"
        dlldiv2.DataBind()
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
        Query.Append("   [A].dept_code [Code] ")
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
        dlldept.DataSource = DT
        dlldept.DataValueField = "Code"
        dlldept.DataTextField = "Name"
        dlldept.DataBind()
        'fill data

        'fill data
        dlldept2.DataSource = DT
        dlldept2.DataValueField = "Code"
        dlldept2.DataTextField = "Name"
        dlldept2.DataBind()
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