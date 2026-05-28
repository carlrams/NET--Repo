Imports System.Data.SqlClient
Imports System.IO

Public Class FINRT0021
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "FINRT0021"

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
            bindYear()
            bindPeriod()
            bindGLA()
            bindDiv()
            bindDept()
            bindJType()
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0021.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0021.rdlc"))
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0022.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0022.rdlc"))
        'copy template report

        'view report
        Dim pClear = IIf(cbxClear.Checked = True, 1, 0)
        Dim pYearF = tbxYearF.Text
        Dim pYearT = tbxYearT.Text
        Dim pYear As String = String.Join(",", ddlYear.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pPeriodF = tbxPeriodF.Text
        Dim pPeriodT = tbxPeriodT.Text
        Dim pPeriod As String = String.Join(",", ddlPeriod.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pGLA = ddlGLA.SelectedValue
        Dim pGLA2 = ddlGLA2.SelectedValue
        Dim pGLA3 As String = String.Join(",", ddlGLA3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pDiv = ddlDiv.SelectedValue
        Dim pDiv2 = ddlDiv2.SelectedValue
        Dim pDiv3 As String = String.Join(",", ddlDiv3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pDept = ddlDept.SelectedValue
        Dim pDept2 = ddlDept2.SelectedValue
        Dim pDept3 As String = String.Join(",", ddlDept3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pJType = ddlJType.SelectedValue
        Dim pJType2 = ddlJType2.SelectedValue
        Dim pJType3 As String = String.Join(",", ddlJType3.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Select(Function(item) item.Value))
        Dim pDateFrom = tbxDateFrom.Value
        Dim pDateTo = tbxDateTo.Value
        Dim pRef = tbxRef.Text
        Dim pRef2 = tbxRef2.Text
        Dim pRemarks = tbxRemarks.Text
        Dim pDebit = tbxDebit.Text
        Dim pDebit2 = tbxDebit2.Text
        Dim pCredit = tbxCredit.Text
        Dim pCredit2 = tbxCredit2.Text
        ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('FINRTView?FormCode=" & FormCode & "&pClear=" & pClear & "&pYearF=" & pYearF & "&pYearT=" & pYearT & "&pYear=" & Server.UrlEncode(pYear) & "&pPeriodF=" & pPeriodF & "&pPeriodT=" & pPeriodT & "&pPeriod=" & Server.UrlEncode(pPeriod) & "&pGLA=" & pGLA & "&pGLA2=" & pGLA2 & "&pGLA3=" & Server.UrlEncode(pGLA3) & "&pDiv=" & pDiv & "&pDiv2=" & pDiv2 & "&pDiv3=" & Server.UrlEncode(pDiv3) & "&pDept=" & pDept & "&pDept2=" & pDept2 & "&pDept3=" & Server.UrlEncode(pDept3) & "&pJType=" & pJType & "&pJType2=" & pJType2 & "&pJType3=" & Server.UrlEncode(pJType3) & "&pDateFrom=" & pDateFrom & "&pDateTo=" & pDateTo & "&pRef=" & pRef & "&pRef2=" & pRef2 & "&pRemarks=" & pRemarks & "&pDebit=" & pDebit & "&pDebit2=" & pDebit2 & "&pCredit=" & pCredit & "&pCredit2=" & pCredit2 & "');", True)
        'view report

    End Sub

    Function bindYear()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'' [Description] ")
        Query.Append("union ")
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
        ddlYear.DataSource = DT
        ddlYear.DataValueField = "Code"
        ddlYear.DataTextField = "Description"
        ddlYear.DataBind()
        'fill data

    End Function

    Function bindPeriod()

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
        ddlPeriod.DataSource = DT
        ddlPeriod.DataValueField = "Code"
        ddlPeriod.DataTextField = "Description"
        ddlPeriod.DataBind()
        'fill data

    End Function

    Function bindGLA()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,' (Select GL Account)' [Description] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   acct_code [Code] ")
        Query.Append("   ,description [Description] ")
        Query.Append("from ")
        Query.Append("   fin_chart ")
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
        ddlGLA.DataSource = DT
        ddlGLA.DataValueField = "Code"
        ddlGLA.DataTextField = "Description"
        ddlGLA.DataBind()
        'fill data

        'fill data
        ddlGLA2.DataSource = DT
        ddlGLA2.DataValueField = "Code"
        ddlGLA2.DataTextField = "Description"
        ddlGLA2.DataBind()
        'fill data

        'fill data
        ddlGLA3.DataSource = DT
        ddlGLA3.DataValueField = "Code"
        ddlGLA3.DataTextField = "Description"
        ddlGLA3.DataBind()
        'fill data

    End Function

    Function bindDiv()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,' (Select Division)' [Description] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   abbr [Code] ")
        Query.Append("   ,description [Description] ")
        Query.Append("from ")
        Query.Append("   division ")
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
        ddlDiv.DataSource = DT
        ddlDiv.DataValueField = "Code"
        ddlDiv.DataTextField = "Description"
        ddlDiv.DataBind()
        'fill data

        'fill data
        ddlDiv2.DataSource = DT
        ddlDiv2.DataValueField = "Code"
        ddlDiv2.DataTextField = "Description"
        ddlDiv2.DataBind()
        'fill data

        'fill data
        ddlDiv3.DataSource = DT
        ddlDiv3.DataValueField = "Code"
        ddlDiv3.DataTextField = "Description"
        ddlDiv3.DataBind()
        'fill data

    End Function

    Function bindDept()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,' (Select Department)' [Description] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   abbr [Code] ")
        Query.Append("   ,description [Description] ")
        Query.Append("from ")
        Query.Append("   department ")
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
        ddlDept.DataSource = DT
        ddlDept.DataValueField = "Code"
        ddlDept.DataTextField = "Description"
        ddlDept.DataBind()
        'fill data

        'fill data
        ddlDept2.DataSource = DT
        ddlDept2.DataValueField = "Code"
        ddlDept2.DataTextField = "Description"
        ddlDept2.DataBind()
        'fill data

        'fill data
        ddlDept3.DataSource = DT
        ddlDept3.DataValueField = "Code"
        ddlDept3.DataTextField = "Description"
        ddlDept3.DataBind()
        'fill data

    End Function

    Function bindJType()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,' (Select Journal Type)' [Description] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   j_code [Code] ")
        Query.Append("   ,journal [Description] ")
        Query.Append("from ")
        Query.Append("   fin_jrnl_type ")
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
        ddlJType.DataSource = DT
        ddlJType.DataValueField = "Code"
        ddlJType.DataTextField = "Description"
        ddlJType.DataBind()
        'fill data

        'fill data
        ddlJType2.DataSource = DT
        ddlJType2.DataValueField = "Code"
        ddlJType2.DataTextField = "Description"
        ddlJType2.DataBind()
        'fill data

        'fill data
        ddlJType3.DataSource = DT
        ddlJType3.DataValueField = "Code"
        ddlJType3.DataTextField = "Description"
        ddlJType3.DataBind()
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