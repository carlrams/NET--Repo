Imports System.Data.SqlClient
Imports System.IO

Public Class ForVerificationPDC
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    Dim CIIS_Department As String
    'cookies

    'connection
    Dim DataSource As String = "iis"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
    'connection

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        CIIS_Department = CIIS_UserInfo("CIIS_Department")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "AAD010000")
        'active account / menu

        If IsPostBack = False Then

            lblDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")
            bindPDCForVerificationListTotal()
            bindPDCForVerificationList()
            bindPDCVerified()
            bindPDCVerifiedListTotal()

            If CIIS_Department = "Business Tech Department" Then
                'If CIIS_Department = "Customer Service" Then
                divCSButton.Visible = True
            Else
                divCSButton.Visible = False
            End If

        End If

    End Sub

#End Region

#Region "Modal Verified Submitted"

    Protected Sub btnViewPDCVerifiedSubmitted_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("PDCAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", Msg, "error")
            Exit Sub
        End If
        'validate access

        'get
        Dim Query As New StringBuilder

        Query.Append("Select ")
        Query.Append("    (case when [A].CSVerified is not null then 'bullet bullet-margin bullet-vertical h-40px bg-success' else 'bullet bullet-margin bullet-vertical h-40px bg-danger' end) [Bullet] ")
        Query.Append("	 ,[A].PDCCode ")
        Query.Append("	 ,[A].CheckDate ")
        Query.Append("	 ,[A].CheckNo ")
        Query.Append("	 ,(case when [A].CSVerified is not null then 'Verified' end) [Status] ")
        Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    [A].Status = 'Pending' ")
        Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("    and [A].CSVerified is not null ")
        Query.Append("order by ")
        Query.Append("   [A].CheckDate ")
        'get

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("CheckDate"))
        dtable.Columns.Add(New DataColumn("CheckNo"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("ViewPDCVerifiedSubmittedDtl"))
        dtable.Columns.Add(New DataColumn("Code"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Title As String = DR("Title")
                    Dim Bullet As String = DR("Bullet")
                    Dim CheckDate As String = DR("CheckDate")
                    Dim CheckNo As String = DR("CheckNo")
                    Dim Status As String = DR("Status")
                    Dim ViewPDCVerifiedSubmittedDtl As String = "ViewPDCVerifiedSubmittedDtl('" & DR("PDCCode") & "')"
                    Dim Code As String = DR("PDCCode")

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, CheckDate, CheckNo, Status, ViewPDCVerifiedSubmittedDtl, Code}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblPDCVerifiedSubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvPDCVerifiedSubmitted.DataSource = dtable
        gvPDCVerifiedSubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlPDCVerifiedSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlPDCVerifiedSubmitted').modal('show');")
        'display Data

    End Sub

#End Region

#Region "Modal Verified Submitted Dtl"

    Protected Sub btnViewPDCVerifiedSubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("     [A].PDCCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[C].Fullname ")
        Query.Append("    ,[A].CheckDate ")
        Query.Append("    ,[A].CheckNo ")
        Query.Append("    ,[A].Amount ")
        Query.Append("    ,[A].Bank ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,[A].CreatedDate ")
        Query.Append("    ,[A].Status ")
        Query.Append("    ,isnull([B].Fullname,'') ")
        Query.Append("    ,[A].ApprovedDate ")
        Query.Append("    ,[A].ApprovedRemarks ")
        Query.Append("from ")
        Query.Append("	bp_PDC [A] ")
        Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
        Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
        Query.Append("where ")
        Query.Append("   PDCCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPDCVerifiedSubmittedDtlCode.Text = DR.GetString(0)
                    lblPDCVerifiedSubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
                    lblPDCVerifiedSubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblPDCVerifiedSubmittedDtlName.Text = DR.GetString(2)
                    lblPDCVerifiedSubmittedDtlCheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lblPDCVerifiedSubmittedDtlCheckNo.Text = DR.GetString(4)
                    lblPDCVerifiedSubmittedDtlAmount.Text = DR.GetDecimal(5).ToString("N2")
                    lblPDCVerifiedSubmittedDtlBank.Text = DR.GetString(6)
                    lblPDCVerifiedSubmittedDtlRemarks.Text = DR.GetString(7)
                    lblPDCVerifiedSubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
                    lblPDCVerifiedSubmittedDtlStatus.Text = DR.GetString(9)
                    lblPDCVerifiedSubmittedDtlApprovedBy.Text = DR.GetString(10)
                    lblPDCVerifiedSubmittedDtlApprovedDate.Text = Format(DR.GetDateTime(11), "MM/dd/yyyy")
                    lblPDCVerifiedSubmittedDtlApproverRemarks.Text = DR.GetString(12)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlPDCVerifiedSubmittedDtl.Update()
        RenderDatatable()
        bindHistoryTimeline()
        CallJS("$('#ContentPlaceHolder1_mdlPDCVerifiedSubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCVerifiedSubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCVerifiedSubmittedDtl').modal('show'); }, 250);")

        'display data

    End Sub

#End Region

#Region "Modal For Verification Submitted"

    Protected Sub btnViewPDCForVerificationSubmitted_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("PDCAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", Msg, "error")
            Exit Sub
        End If
        'validate access

        'get
        Dim Query As New StringBuilder

        Query.Append("Select ")
        Query.Append("	  [A].PDCCode ")
        Query.Append("	 ,[A].CheckDate ")
        Query.Append("	 ,[A].CheckNo ")
        Query.Append("	 ,(case when [A].CSVerified is null then 'For Verification' end) [Status] ")
        Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    [A].Status = 'Pending' ")
        Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("    and [A].CSVerified is null ")
        Query.Append("order by ")
        Query.Append("   [A].CheckDate ")
        'get

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("CheckDate"))
        dtable.Columns.Add(New DataColumn("CheckNo"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("ViewPDCForVerificationSubmittedDtl"))
        dtable.Columns.Add(New DataColumn("Code"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Title As String = DR("Title")
                    Dim CheckDate As String = DR("CheckDate")
                    Dim CheckNo As String = DR("CheckNo")
                    Dim Status As String = DR("Status")
                    Dim ViewPDCForVerificationSubmittedDtl As String = "ViewPDCForVerificationSubmittedDtl('" & DR("PDCCode") & "')"
                    Dim Code As String = DR("PDCCode")

                    'add new row
                    Dim NewRowValues As Object() = {CheckDate, CheckNo, Status, ViewPDCForVerificationSubmittedDtl, Code}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblPDCForVerificationSubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvPDCForVerificationSubmitted.DataSource = dtable
        gvPDCForVerificationSubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlPDCForVerificationSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlPDCForVerificationSubmitted').modal('show');")
        'display Data

    End Sub

#End Region

#Region "Modal For Verification Submitted Dtl"

    Protected Sub btnViewPDCForVerificationSubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("     [A].PDCCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[B].Fullname ")
        Query.Append("    ,[A].CheckDate ")
        Query.Append("    ,[A].CheckNo ")
        Query.Append("    ,[A].Amount ")
        Query.Append("    ,[A].Bank ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,[A].CreatedDate ")
        Query.Append("    ,[B].Email ")
        Query.Append("from ")
        Query.Append("	bp_pdc [A] ")
        Query.Append("	left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].PDCCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPDCForVerificationSubmittedDtlCode.Text = hfID.Value
                    lblPDCForVerificationSubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
                    lblPDCForVerificationSubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblPDCForVerificationSubmittedDtlName.Text = DR.GetString(2)
                    lblPDCForVerificationSubmittedDtlCheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lblPDCForVerificationSubmittedDtlCheckNo.Text = DR.GetString(4)
                    lblPDCForVerificationSubmittedDtlAmount.Text = DR.GetDecimal(5).ToString("N2")
                    lblPDCForVerificationSubmittedDtlBank.Text = DR.GetString(6)
                    lblPDCForVerificationSubmittedDtlRemarks.Text = DR.GetString(7)
                    lblPDCForVerificationSubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
                    lblPDCForVerificationSubmittedDtlEmail.Text = DR.GetString(9)

                    pnlPDCForVerificationSubmittedDtlDetail.Visible = True

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlPDCForVerificationSubmittedDtl.Update()
        RenderDatatable()
        bindHistoryTimeline()
        CallJS("$('#ContentPlaceHolder1_mdlPDCForVerificationSubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCForVerificationSubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCForVerificationSubmittedDtl').modal('show'); }, 250);")
        'display data

    End Sub

    Protected Sub lbtnPDCForVerificationSubmittedDtlSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCForVerificationSubmittedDtlSave.Click

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprUpdatePDC"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", lblPDCForVerificationSubmittedDtlCode.Text)
        SqlCmd.Parameters.AddWithValue("@pCheckDate", tbxPDCForVerificationSubmittedDtlCheckDate.Value)
        SqlCmd.Parameters.AddWithValue("@pCheckNo", tbxPDCForVerificationSubmittedDtlCheckNo.Value)
        SqlCmd.Parameters.AddWithValue("@pAmount", CDec(tbxPDCForVerificationSubmittedDtlAmount.Value))
        SqlCmd.Parameters.AddWithValue("@pBank", tbxPDCForVerificationSubmittedDtlBank.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'success alert
        Alert("Success!", "Record Saved Successfully", "success")
        'success alert

        'clear fields
        lblPDCForVerificationSubmittedDtlCode.Text = ""
        tbxPDCForVerificationSubmittedDtlCheckDate.Value = ""
        tbxPDCForVerificationSubmittedDtlCheckNo.Value = ""
        tbxPDCForVerificationSubmittedDtlAmount.Value = "0.00"
        tbxPDCForVerificationSubmittedDtlBank.Value = ""
        'clear fields


        lbtnPDCForVerificationSubmittedDtlCancelEdit.Visible = False
        pnlPDCForVerificationSubmittedDtlDetail.Visible = True
        pnlPDCForVerificationSubmittedDtlEdit.Visible = False
        lbtnPDCForVerificationSubmittedDtlEdit.Visible = True
        lbtnPDCForVerificationSubmittedDtlSave.Visible = False
        lblPDCForVerificationSubmittedDtlCode.Text = ""
        tbxPDCForVerificationSubmittedDtlCheckDate.Value = ""
        tbxPDCForVerificationSubmittedDtlCheckNo.Value = ""
        tbxPDCForVerificationSubmittedDtlAmount.Value = "0.00"
        tbxPDCForVerificationSubmittedDtlBank.Value = ""

        lbtnPDCForVerificationSubmittedDtlVerified.Enabled = True
        lbtnPDCForVerificationSubmittedDtlVerified.CssClass = "btn btn-primary"

        CallJS("$('#ContentPlaceHolder1_mdl01PDCPending').modal('hide');")

        'display record
        bindPDCForVerificationList()
        bindPDCForVerificationListTotal()
        'display record

        Exit Sub

    End Sub

    Protected Sub lbtnPDCForVerificationSubmittedDtlCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCForVerificationSubmittedDtlCancel.Click

        lbtnPDCForVerificationSubmittedDtlCancelEdit.Visible = False
        pnlPDCForVerificationSubmittedDtlDetail.Visible = True
        pnlPDCForVerificationSubmittedDtlEdit.Visible = False
        lbtnPDCForVerificationSubmittedDtlEdit.Visible = True
        lbtnPDCForVerificationSubmittedDtlSave.Visible = False
        lblPDCForVerificationSubmittedDtlCode.Text = ""
        tbxPDCForVerificationSubmittedDtlCheckDate.Value = ""
        tbxPDCForVerificationSubmittedDtlCheckNo.Value = ""
        tbxPDCForVerificationSubmittedDtlAmount.Value = "0.00"
        tbxPDCForVerificationSubmittedDtlBank.Value = ""

        CallJS("$('#ContentPlaceHolder1_mdlPDCForVerificationSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCForVerificationSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCForVerificationSubmitted').modal('show'); }, 250);")

        lbtnPDCForVerificationSubmittedDtlVerified.Enabled = True
        lbtnPDCForVerificationSubmittedDtlVerified.CssClass = "btn btn-primary"

    End Sub

    Protected Sub lbtnPDCForVerificationSubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCForVerificationSubmittedDtlClose.Click

        lbtnPDCForVerificationSubmittedDtlCancelEdit.Visible = False
        pnlPDCForVerificationSubmittedDtlDetail.Visible = True
        pnlPDCForVerificationSubmittedDtlEdit.Visible = False
        lbtnPDCForVerificationSubmittedDtlEdit.Visible = True
        lbtnPDCForVerificationSubmittedDtlSave.Visible = False
        lblPDCForVerificationSubmittedDtlCode.Text = ""
        tbxPDCForVerificationSubmittedDtlCheckDate.Value = ""
        tbxPDCForVerificationSubmittedDtlCheckNo.Value = ""
        tbxPDCForVerificationSubmittedDtlAmount.Value = "0.00"
        tbxPDCForVerificationSubmittedDtlBank.Value = ""

        CallJS("$('#ContentPlaceHolder1_mdlPDCForVerificationSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCForVerificationSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCForVerificationSubmitted').modal('show'); }, 250);")

        lbtnPDCForVerificationSubmittedDtlVerified.Enabled = True
        lbtnPDCForVerificationSubmittedDtlVerified.CssClass = "btn btn-primary"

    End Sub

    Protected Sub lbtnPDCForVerificationSubmittedDtlEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCForVerificationSubmittedDtlEdit.Click

        lbtnPDCForVerificationSubmittedDtlCancelEdit.Visible = True
        pnlPDCForVerificationSubmittedDtlEdit.Visible = True
        pnlPDCForVerificationSubmittedDtlDetail.Visible = False
        lbtnPDCForVerificationSubmittedDtlEdit.Visible = False
        lbtnPDCForVerificationSubmittedDtlSave.Visible = True

        lbtnPDCForVerificationSubmittedDtlVerified.Enabled = False
        lbtnPDCForVerificationSubmittedDtlVerified.CssClass = "btn btn-light"

        bindHistoryTimeline()

        mdlPDCForVerificationSubmitted.Update()

    End Sub

#End Region

#Region "Modal Verified Submitted Dtl"

    Protected Sub lbtnPDCVerifiedSubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCVerifiedSubmittedDtlClose.Click

        lblPDCVerifiedSubmittedDtlTitle.Text = ""
        lblPDCVerifiedSubmittedDtlAcctNo.Text = ""
        lblPDCVerifiedSubmittedDtlCheckDate.Text = ""
        lblPDCVerifiedSubmittedDtlCheckNo.Text = ""
        lblPDCVerifiedSubmittedDtlAmount.Text = ""
        lblPDCVerifiedSubmittedDtlBank.Text = ""
        lblPDCVerifiedSubmittedDtlDateSubmitted.Text = ""
        lblPDCVerifiedSubmittedDtlRemarks.Text = ""

        CallJS("$('#ContentPlaceHolder1_mdlPDCVerifiedSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCVerifiedSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCVerifiedSubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnPDCForVerificationSubmittedDtlVerified_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCForVerificationSubmittedDtlVerified.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprPDCVerified"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", lblPDCForVerificationSubmittedDtlCode.Text)
        SqlCmd.Parameters.AddWithValue("@pIDs", "")
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'success alert
        Alert("Success!", "Record Saved Successfully!", "success")
        'success alert

        'send email
        'SendEmailNotification()
        'send email

        'clear fields
        lblPDCForVerificationSubmittedDtlTitle.Text = ""
        lblPDCForVerificationSubmittedDtlAcctNo.Text = ""
        lblPDCForVerificationSubmittedDtlCheckDate.Text = ""
        lblPDCForVerificationSubmittedDtlCheckNo.Text = ""
        lblPDCForVerificationSubmittedDtlAmount.Text = ""
        lblPDCForVerificationSubmittedDtlBank.Text = ""
        lblPDCForVerificationSubmittedDtlDateSubmitted.Text = ""
        lblPDCForVerificationSubmittedDtlRemarks.Text = ""
        'clear fields

        'hide modal
        CallJS("$('#ContentPlaceHolder1_mdlPDCForVerificationSubmittedDtl').modal('hide');")
        'hide modal

        'display record
        bindPDCVerified()
        bindPDCVerifiedListTotal()
        bindPDCForVerificationList()
        bindPDCForVerificationListTotal()
        'display record

        Exit Sub

    End Sub

#End Region

#Region "Modal Batch Revert"

    Protected Sub lbtnPDCVerifiedSubmittedBatchRevert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCVerifiedSubmittedBatchRevert.Click

        CallJS("Swal.fire({ title: 'Do you want to revert PDC?', showDenyButton: false, showCancelButton: true, confirmButtonText: 'Save', confirmButtonColor: '#279852', cancelButtonColor: '#cbd4d9' }).then((result) => { if (result.isConfirmed) { var clickButton = document.getElementById('" & btnPDCVerifySubmittedRevert.ClientID & "'); clickButton.click(); } else if (result.dismiss === Swal.DismissReason.cancel) { $('.checkBoxClass').prop('checked', false); } }); ")

    End Sub

    Protected Sub btnPDCVerifySubmittedRevert_Click(ByVal sender As Object, e As EventArgs)

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        ' Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gvPDCVerifiedSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvPDCVerifiedSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gvPDCVerifiedSubmitted.Rows(RowIdx).FindControl("lblPDCVerifiedSubmittedID"), Label)

            ' If checkbox is checked, add the ID to the string
            If RowCheckbox.Checked = True Then
                IDSrs &= lblID.Text & "," ' Collect IDs, separated by commas
            End If

            RowIdx += 1
        Loop

        ' Remove the last comma
        If IDSrs.Length > 0 Then
            IDSrs = IDSrs.TrimEnd(","c)

            ' Call the method to delete the records using the stored procedure
            RevertVerifiedPDC(IDSrs)
        End If

    End Sub


#End Region

#Region "Modal Batch Verify"

    Protected Sub lbtnPDCForVerificationSubmittedBatchVerify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCForVerificationSubmittedBatchVerify.Click

        CallJS(" Swal.fire({ title: 'Do you want to verify PDC?', showDenyButton: false, showCancelButton: true, confirmButtonText: 'Save', confirmButtonColor: '#279852', cancelButtonColor: '#cbd4d9' }).then((result) => { if (result.isConfirmed) { var clickButton = document.getElementById('" & btnPDCForVerificationSubmittedBatchVerify.ClientID & "'); clickButton.click(); } else if (result.dismiss === Swal.DismissReason.cancel) { $('.checkBoxClass').prop('checked', false); } }); ")

    End Sub

    Protected Sub btnPDCForVerificationSubmittedBatchVerify_Click(ByVal sender As Object, e As EventArgs)

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        ' Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gvPDCForVerificationSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvPDCForVerificationSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gvPDCForVerificationSubmitted.Rows(RowIdx).FindControl("lblPDCForVerificationSubmittedID"), Label)

            ' If checkbox is checked, add the ID to the string
            If RowCheckbox.Checked = True Then
                IDSrs &= lblID.Text & "," ' Collect IDs, separated by commas
            End If

            RowIdx += 1
        Loop

        ' Remove the last comma
        If IDSrs.Length > 0 Then
            IDSrs = IDSrs.TrimEnd(","c)

            ' Call the method to delete the records using the stored procedure
            VerifiedPDC(IDSrs)
        End If

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Title_ As String, ByVal Message_ As String, ByVal Alert_ As String)

        Dim script As String = "Swal.fire({title: '" & Title_ & "', text: '" & Message_ & "', icon: '" & Alert_ & "', confirmButtonColor: '#279852'});"
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "SweetAlert", script, True)

    End Function

    Function CallJS(ByVal Script As String)

        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & Script & "</script>", False)

    End Function

    Function RenderDatatable()

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvPDCForVerificationList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCForVerificationList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCForVerificationList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCForVerificationList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gvPDCForVerificationSubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCForVerificationSubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCForVerificationSubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCForVerificationSubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvPDCVerifiedList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCVerifiedList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCVerifiedList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCVerifiedList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        If gvPDCVerifiedSubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCVerifiedSubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCVerifiedSubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCVerifiedSubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindHistoryTimeline()

        'get
        Dim Query As New StringBuilder

        Dim PDCCode As String = IIf(lblPDCForVerificationSubmittedDtlCode.Text = "", lblPDCVerifiedSubmittedDtlCode.Text, lblPDCForVerificationSubmittedDtlCode.Text)

        Query.Append("select ")
        Query.Append("	  ([A].Type + ' ' + [A].Description) [Progress] ")
        Query.Append("	 ,[A].CreatedDate ")
        Query.Append("	 ,[A].CreatedBy ")
        Query.Append("	 ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	 ,[A].Type ")
        Query.Append("from ")
        Query.Append("	 BP_History [A] ")
        Query.Append("	 left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TblCode = '" & PDCCode & "' ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate ")
        'get 

        Dim innerHTML As New StringBuilder

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'icons
                    Dim img As String
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("CreatedBy") & ".png")) = True Then
                        img = "Assets/media/avatars/" & DR("CreatedBy") & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("CreatedBy") & ".jpg")) = True Then
                        img = "Assets/media/avatars/" & DR("CreatedBy") & ".jpg"
                    Else
                        img = "Assets/media/avatars/blank.png"
                    End If

                    Dim svg As String
                    If DR("Type") = "Edit PDC:" Then
                        svg = "<path d='M3,16 L5,16 C5.55228475,16 6,15.5522847 6,15 C6,14.4477153 5.55228475,14 5,14 L3,14 L3,12 L5,12 C5.55228475,12 6,11.5522847 6,11 C6,10.4477153 5.55228475,10 5,10 L3,10 L3,8 L5,8 C5.55228475,8 6,7.55228475 6,7 C6,6.44771525 5.55228475,6 5,6 L3,6 L3,4 C3,3.44771525 3.44771525,3 4,3 L10,3 C10.5522847,3 11,3.44771525 11,4 L11,19 C11,19.5522847 10.5522847,20 10,20 L4,20 C3.44771525,20 3,19.5522847 3,19 L3,16 Z' fill='#279852' opacity='0.3'/> <path d='M16,3 L19,3 C20.1045695,3 21,3.8954305 21,5 L21,15.2485298 C21,15.7329761 20.8241635,16.200956 20.5051534,16.565539 L17.8762883,19.5699562 C17.6944473,19.7777745 17.378566,19.7988332 17.1707477,19.6169922 C17.1540423,19.602375 17.1383289,19.5866616 17.1237117,19.5699562 L14.4948466,16.565539 C14.1758365,16.200956 14,15.7329761 14,15.2485298 L14,5 C14,3.8954305 14.8954305,3 16,3 Z' fill='#279852'/>"
                    End If
                    'icons

                    'history
                    innerHTML.Append(" <!--begin::Timeline item--> ")
                    innerHTML.Append(" <div class='timeline-item pe-3'> ")
                    innerHTML.Append("     <div class='timeline-line w-30px'></div> ")
                    innerHTML.Append("     <div class='timeline-icon symbol symbol-circle symbol-30px'> ")
                    innerHTML.Append("         <div class='symbol-label bg-light'> ")
                    innerHTML.Append("             <span class='svg-icon svg-icon-2 svg-icon-gray-500'> ")
                    innerHTML.Append("                 <svg xmlns='http//www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    innerHTML.Append(" 			        " & svg & " ")
                    innerHTML.Append("		            </svg>  ")
                    innerHTML.Append("            </span> ")
                    innerHTML.Append("         </div> ")
                    innerHTML.Append("     </div> ")
                    innerHTML.Append("     <div class='timeline-content mb-10 mt-n2'> ")
                    innerHTML.Append("         <div class='overflow-auto pe-3'> ")
                    innerHTML.Append("             <div class='fs-5 fw-bold mb-2'>" & DR("Progress") & "</div> ")
                    innerHTML.Append("             <div class='d-flex align-items-center mt-1 fs-6'> ")
                    innerHTML.Append("                 <div class='text-muted me-2 fs-7'>Updated at " & DR("CreatedDate") & " by</div> ")
                    innerHTML.Append("                 <div class='symbol symbol-circle symbol-25px' data-bs-toggle='tooltip' data-bs-boundary='window' data-bs-placement='top' title=" & DR("Name") & "> ")
                    innerHTML.Append("                     <img src=" & img & " alt='img' /> ")
                    innerHTML.Append("                 </div> ")
                    innerHTML.Append("             </div> ")
                    innerHTML.Append("         </div> ")
                    innerHTML.Append("     </div> ")
                    innerHTML.Append(" </div> ")
                    innerHTML.Append(" <!--end::Timeline item--> ")
                    'history

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        divPDCForVerificationSubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        divPDCVerifiedSubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        'display data

    End Function

    Function VerifiedPDC(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprPDCVerified"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", "")
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'alert
        Alert("Success!", "Record save successfully.", "success")
        'alert

        'CallJS("$('#ContentPlaceHolder1_mdl01PDCList').modal('hide');")
        mdlPDCForVerificationSubmitted.Update()

        'display record
        bindPDCForVerificationListTotal()
        bindPDCForVerificationList()
        bindPDCVerifiedListTotal()
        bindPDCVerified()
        'display record

    End Function

    Function RevertVerifiedPDC(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprRevertPDCVerified"
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'alert
        Alert("Success!", "Record revert successfully.", "success")
        'alert

        CallJS("$('#ContentPlaceHolder1_mdl02PDCVerifiedList').modal('hide');")

        'display record
        bindPDCVerified()
        bindPDCForVerificationList()
        bindPDCForVerificationListTotal()
        bindPDCVerifiedListTotal()
        'display record

    End Function

    Function bindPDCVerifiedListTotal()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   CSVerified is not null ")
        Query.Append("   and Status not in ('Approved', 'Declined') ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPDCVerifiedListTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlPDCTotal.Update()
        'display data

    End Function

    Function bindPDCForVerificationListTotal()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and CSVerified is null ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPDCForVerificationListTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlPDCTotal.Update()
        'display data

    End Function

    Function bindPDCVerified()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Pending' ")
        Query.Append("   and [A].CSVerified is not null ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewPDCVerifiedList"))
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim ViewPDCVerifiedList As String = "ViewPDCVerifiedList('" & DR("AcctNo") & "')"
                    Dim AcctNo As String = DR("AcctNo")
                    Dim Name As String = DR("Fullname")

                    'add new row
                    Dim NewRowValues As Object() = {ViewPDCVerifiedList, AcctNo, Name}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvPDCVerifiedList.DataSource = dtable
        gvPDCVerifiedList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlPDCVerifiedList.Update()
        'display data

    End Function

    Function bindPDCForVerificationList()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("	 ,(select count(PDCCode) from bp_pdc left join bp_user on bp_pdc.AcctNo = bp_user.AcctNo where (bp_pdc.Status = 'Pending') and bp_pdc.AcctNo = [A].AcctNo) [TotalSubmitted] ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Pending' ")
        Query.Append("   and [A].CSVerified is null ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("TotalSubmitted"))
        dtable.Columns.Add(New DataColumn("ViewPDCForVerificationSubmitted"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim AcctNo As String = DR("AcctNo")
                    Dim Name As String = DR("Fullname")
                    Dim TotalSubmitted As String = DR("TotalSubmitted")
                    Dim ViewPDCForVerificationSubmitted As String = "ViewPDCForVerificationSubmitted('" & DR("AcctNo") & "')"


                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Name, TotalSubmitted, ViewPDCForVerificationSubmitted}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvPDCForVerificationList.DataSource = dtable
        gvPDCForVerificationList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlPDCForVerificationList.Update()
        'display data

    End Function

#End Region

#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        'access
        If Group_ = "PDCAccess" Then
            If Type = "Save" Then
                Query.Append("if 'AAD010400' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010400' and Save_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'access

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Msg = DR.GetString(0)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        Return Msg
        'display data

    End Function

#End Region

End Class