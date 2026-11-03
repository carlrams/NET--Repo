Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting

Public Class FINRT0010
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim FormCode As String = "FINRT0010"

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

        ' Only bind dropdown on the first load
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0010.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0010.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0011.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0011.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0012.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0012.rdlc"))
        'copy template report

        'view report
        Dim pyear = Year.Text
        Dim pacct = ddlchart.SelectedValue
        Dim psub_from = ddlsub.SelectedValue
        Dim psub_to = ddlsub2.SelectedValue
        Dim psub_srs As String = String.Join(",", lbxsub3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pdiv_from = dlldiv.SelectedValue
        Dim pdiv_to = dlldiv2.SelectedValue
        Dim pdiv_srs As String = String.Join(",", lbxdiv3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pdept_from = dlldept.SelectedValue
        Dim pdept_to = dlldept2.SelectedValue
        Dim pdept_srs As String = String.Join(",", lbxdept3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode &
        "&pyear=" & pyear &
        "&pacct=" & pacct &
        "&psub_from=" & psub_from & "&psub_to=" & psub_to & "&psub_srs=" & Server.UrlEncode(psub_srs) &
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


    Private Sub ddlchart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlchart.SelectedIndexChanged
        BindGlsub(ddlchart.SelectedValue)
    End Sub
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
        Query.Append("   ,[A].subsidiary [Order] ")
        Query.Append("from ")
        Query.Append("   fin_chart [A] ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
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
    End Function


    Function BindGlsub(subsidiary As String)


        'get Assigned To
        Dim Query As New StringBuilder
        'AGENT
        Query.Append("if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('AGENT') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_agent  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'BANK
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('BANK') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_bank  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'CUSTOMER
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('CUSTOMER') ")
        Query.Append("begin ")
        Query.Append("  select")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_customer  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'EMPLOYEE
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('EMPLOYEE') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_employee  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'EWT
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('EWT') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_ewt  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'LOT
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('LOT') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_lot  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'MISCELLANEOUS
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('MISCELLANEOUS') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_misc  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'MODEL HOUSE
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('MODEL HOUSE') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_house  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'PHASE
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('PHASE') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_phase  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'RAW LAND
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('RAW LAND') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_rawland  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'SUBDIVISION
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('SUBDIVISION') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_subdivision  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'VENDOR
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('VENDOR') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_vendor  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        'WAREHOUSE
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('WAREHOUSE') ")
        Query.Append("begin ")
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Subsidiary' [Name] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("from ")
        Query.Append("   sub_warehouse  ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("select ")
        Query.Append(" '' [Code]")
        Query.Append(" ,'No Subsidiary' [Name]")
        Query.Append("end ")

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data

        ddlsub.DataSource = DT
        ddlsub.DataValueField = "Code"
        ddlsub.DataTextField = "Name"
        ddlsub.DataBind()

        ddlsub2.DataSource = DT
        ddlsub2.DataValueField = "Code"
        ddlsub2.DataTextField = "Name"
        ddlsub2.DataBind()

        lbxsub3.DataSource = DT
        lbxsub3.DataValueField = "Code"
        lbxsub3.DataTextField = "Name"
        lbxsub3.DataBind()

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