Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting

Public Class FINRT0019
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim FormCode As String = "FINRT0019"

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

        ' Only bind dropdown on the first load
        If Not IsPostBack Then
            BindGlchart()
            BindGldiv()
            BindGldept()
            Bindyear()
            BindPeriod()
            BindJtype()
        End If
        'load

    End Sub


#End Region

#Region "Button"

    Protected Sub btnGenerate_Click(ByVal sender As Object, e As EventArgs)

        If ddlgl_acct.Text = "" Then
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0019.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0019.rdlc"))
        'System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/finGLB_detail.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/finGLB_detail.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0020.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0020.rdlc"))
        'copy template report

        'view report

        Dim pclear = cbxclear.Checked
        Dim pacct = ddlgl_acct.SelectedValue
        Dim pyear_from = tbxyear_from.Text
        Dim pyear_to = tbxyear_to.Text
        Dim pyear_srs As String = String.Join(",", lbxyear.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pperiod_from = tbxperiod_from.Text
        Dim pperiod_to = tbxperiod_to.Text
        Dim pperiod_srs As String = String.Join(",", lbxperiod_srs.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim psub_from = ddlsub_from.SelectedValue
        Dim psub_to = ddlsub_to.SelectedValue
        Dim psub_srs As String = String.Join(",", lbxsub_srs.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pdiv_from = ddldiv_from.SelectedValue
        Dim pdiv_to = ddldiv_to.SelectedValue
        Dim pdiv_srs As String = String.Join(",", lbxdiv_srs.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pdept_from = ddldept_from.SelectedValue
        Dim pdept_to = ddldept_to.SelectedValue
        Dim pdept_srs As String = String.Join(",", lbxdept_srs.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pjtype_from = ddljtype_from.SelectedValue
        Dim pjtype_to = ddljtype_to.SelectedValue
        Dim pjtype_srs As String = String.Join(",", lbxjtype_srs.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pjdate_from = tbxjdate_from.Value
        Dim pjdate_to = tbxjdate_to.Value
        Dim pref_from = tbxref_from.Text
        Dim pref_to = tbxref_to.Text
        Dim jdesc = tbxjdesc.Text
        Dim pdebit_from = tbxpdebit_from.Text
        Dim pdebit_to = tbxpdebit_to.Text
        Dim pcredit_from = tbxpcredit_from.Text
        Dim pcredit_to = tbxpcredit_to.Text

        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode &
            "&pclear=" & pclear & "&pacct=" & pacct &
            "&pyear_from=" & pyear_from & "&pyear_to=" & pyear_to & "&pyear_srs=" & Server.UrlEncode(pyear_srs) &
            "&pperiod_from=" & pperiod_from & "&pperiod_to=" & pperiod_to & "&pperiod_srs=" & Server.UrlEncode(pperiod_srs) &
            "&psub_from=" & psub_from & "&psub_to=" & psub_to & "&psub_srs=" & Server.UrlEncode(psub_srs) &
            "&pdiv_from=" & pdiv_from & "&pdiv_to=" & pdiv_to & "&pdiv_srs=" & Server.UrlEncode(pdiv_srs) &
            "&pdept_from=" & pdept_from & "&pdept_to=" & pdept_to & "&pdept_srs=" & Server.UrlEncode(pdept_srs) &
            "&pjtype_from=" & pjtype_from & "&pjtype_to=" & pjtype_to & "&pjtype_srs=" & Server.UrlEncode(pjtype_srs) &
            "&pjdate_from=" & pjdate_from & "&pjdate_to=" & pjdate_to &
            "&pref_from=" & pref_from & "&pref_to=" & pref_to &
            "&jdesc=" & jdesc & "&pdebit_from=" & pdebit_from & "&pdebit_to=" & pdebit_to &
            "&pcredit_from=" & pcredit_from & "&pcredit_to=" & pcredit_to & "');", True)


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
        Query.Append("   ,[A].subsidiary [Order] ")
        Query.Append("from ")
        Query.Append("   fin_chart [A] ")
        Query.Append("order by ")
        Query.Append("   [code] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlgl_acct.DataSource = DT
        ddlgl_acct.DataValueField = "Code"
        ddlgl_acct.DataTextField = "Name"
        ddlgl_acct.DataBind()
        'fill data


    End Function

    Function BindYear()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   year [Code] ")
        Query.Append("   ,year [Description] ")
        Query.Append("from ")
        Query.Append("   fin_ap_year ")
        Query.Append("where ")
        Query.Append("  lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString(), SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        lbxyear.DataSource = DT
        lbxyear.DataValueField = "Code"
        lbxyear.DataTextField = "Description"
        lbxyear.DataBind()
        'fill data


    End Function

    Function BindPeriod()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'' [Description] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   period [Code] ")
        Query.Append("   ,period [Description] ")
        Query.Append("from ")
        Query.Append("   fin_ap_month ")
        Query.Append("where ")
        Query.Append("  lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Code] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString(), SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        lbxperiod_srs.DataSource = DT
        lbxperiod_srs.DataValueField = "Code"
        lbxperiod_srs.DataTextField = "Description"
        lbxperiod_srs.DataBind()
        'fill data


    End Function
    Private Sub ddlGlchart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlgl_acct.SelectedIndexChanged
        BindSubsidiary(ddlgl_acct.SelectedValue)
    End Sub
    Function BindSubsidiary(subsidiary As String)

        'get Assigned To
        Dim Query As New StringBuilder
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
        'get Assigned To
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
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('CUSTOMER') ")
        Query.Append("begin ")
        Query.Append("  select ")
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
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('EMPLOYEE') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_employee  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('EWT') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_ewt  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('LOT') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_lot  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('MISCELLANEOUS') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_misc  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('MODEL HOUSE') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_house  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('PHASE') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_phase  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('RAW LAND') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_rawland  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('SUBDIVISION') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_subdivision  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('VENDOR') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_vendor  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To
        Query.Append("else if (select subsidiary from fin_chart where acct_code = '" & subsidiary & "') in ('WAREHOUSE') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select Subsidiary' [Name] ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      code [Code] ")
        Query.Append("      ,description [Name] ")
        Query.Append("  from ")
        Query.Append("      sub_warehouse  ")
        Query.Append("  where ")
        Query.Append("      lock = 1 ")
        Query.Append("  order by ")
        Query.Append("      [Code] ")
        Query.Append("end ")
        'get Assigned To






        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query




        'fill data
        ddlsub_from.DataSource = DT
        ddlsub_from.DataValueField = "Code"
        ddlsub_from.DataTextField = "Name"
        ddlsub_from.DataBind()
        'fill data

        'fill data
        ddlsub_to.DataSource = DT
        ddlsub_to.DataValueField = "Code"
        ddlsub_to.DataTextField = "Name"
        ddlsub_to.DataBind()
        'fill data

        'fill data
        lbxsub_srs.DataSource = DT
        lbxsub_srs.DataValueField = "Code"
        lbxsub_srs.DataTextField = "Name"
        lbxsub_srs.DataBind()
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
        ddldiv_from.DataSource = DT
        ddldiv_from.DataValueField = "Code"
        ddldiv_from.DataTextField = "Name"
        ddldiv_from.DataBind()
        'fill data

        'fill data
        ddldiv_to.DataSource = DT
        ddldiv_to.DataValueField = "Code"
        ddldiv_to.DataTextField = "Name"
        ddldiv_to.DataBind()
        'fill data

        'fill data
        lbxdiv_srs.DataSource = DT
        lbxdiv_srs.DataValueField = "Code"
        lbxdiv_srs.DataTextField = "Name"
        lbxdiv_srs.DataBind()
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
        ddldept_from.DataSource = DT
        ddldept_from.DataValueField = "Code"
        ddldept_from.DataTextField = "Name"
        ddldept_from.DataBind()
        'fill data

        'fill data
        ddldept_to.DataSource = DT
        ddldept_to.DataValueField = "Code"
        ddldept_to.DataTextField = "Name"
        ddldept_to.DataBind()
        'fill data

        'fill data
        lbxdept_srs.DataSource = DT
        lbxdept_srs.DataValueField = "Code"
        lbxdept_srs.DataTextField = "Name"
        lbxdept_srs.DataBind()
        'fill data
    End Function


    Function BindJtype()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Journal Type' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].j_code [Code] ")
        Query.Append("   ,[A].journal [Name] ")
        Query.Append("   ,[A].j_code [Order] ")
        Query.Append("from ")
        Query.Append("   fin_jrnl_type [A] ")
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
        ddljtype_from.DataSource = DT
        ddljtype_from.DataValueField = "Code"
        ddljtype_from.DataTextField = "Name"
        ddljtype_from.DataBind()
        'fill data

        'fill data
        ddljtype_to.DataSource = DT
        ddljtype_to.DataValueField = "Code"
        ddljtype_to.DataTextField = "Name"
        ddljtype_to.DataBind()
        'fill data

        'fill data
        lbxjtype_srs.DataSource = DT
        lbxjtype_srs.DataValueField = "Code"
        lbxjtype_srs.DataTextField = "Name"
        lbxjtype_srs.DataBind()
        'fill data
    End Function






#End Region

End Class