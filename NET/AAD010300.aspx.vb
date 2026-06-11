Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail


Public Class RequestAndInquiry
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
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
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "AAD010000")
        'active account / menu

        If IsPostBack = False Then

            lblDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")
            bindInquiryHistoryList()
            bindInquiryPendingList()
            bindTotalHistory()
            bindTotalPending()

        End If
    End Sub

#End Region

#Region "Modal Pending Submitted"

    Protected Sub btnViewINQPendingSubmitted_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg, "")
            Exit Sub
        End If
        'validate access

        'get
        Dim Query As New StringBuilder

        Query.Append("Select ")
        Query.Append("    [A].INQCode ")
        Query.Append("	 ,[A].CreatedDate ")
        Query.Append("	 ,[A].Inquiry ")
        Query.Append("	 ,[A].Status ")
        Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    ([A].Status = 'Pending' or [A].Status = 'In Process') ")
        Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate ")
        'get

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewINQPendingSubmittedDtl"))
        dtable.Columns.Add(New DataColumn("CreatedDate"))
        dtable.Columns.Add(New DataColumn("Inquiry"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("INQCode"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim ViewINQPendingSubmittedDtl As String = "ViewINQPendingSubmittedDtl('" & DR("INQCode") & "')"
                    Dim CreatedDate As String = DR("CreatedDate")
                    Dim Inquiry As String = DR("Inquiry")
                    Dim Status As String = DR("Status")
                    Dim Title As String = DR("Title")
                    Dim Code As String = DR("INQCode")

                    'add new row
                    Dim NewRowValues As Object() = {ViewINQPendingSubmittedDtl, CreatedDate, Inquiry, Status, Code}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblINQPendingSubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvINQPendingSubmitted.DataSource = dtable
        gvINQPendingSubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlINQPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('show');")
        'display data

    End Sub

#End Region

#Region "Modal Pending Submitted Detail"

    Protected Sub lbtnINQPendingSubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQPendingSubmittedDtlClose.Click

        ddlINQPendingSubmittedDtlStatus.SelectedValue = ""
        tbxINQPendingSubmittedDtlRemarks.Text = ""

        CallJS("$('#ContentPlaceHolder1_mdlINQPendingSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQPendingSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnINQPendingSubmittedDtlCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQPendingSubmittedDtlCancel.Click

        ddlINQPendingSubmittedDtlStatus.SelectedValue = ""
        tbxINQPendingSubmittedDtlRemarks.Text = ""

        CallJS("$('#ContentPlaceHolder1_mdlINQPendingSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQPendingSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub btnViewINQPendingSubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("     [A].INQCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[B].Fullname ")
        Query.Append("    ,[A].Inquiry ")
        Query.Append("    ,[A].CreatedDate ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
        Query.Append("    ,[A].Status ")
        Query.Append("    ,[B].Email ")
        Query.Append("from ")
        Query.Append("	bp_inquiry [A] ")
        Query.Append("	left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].INQCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblINQPendingSubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - Request and Inquiry"
                    lblINQPendingSubmittedDtlCode.Text = hfID.Value
                    lblINQPendingSubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblINQPendingSubmittedDtlName.Text = DR.GetString(2)
                    lblINQPendingSubmittedDtlType.Text = DR.GetString(3)
                    lblINQPendingSubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(4), "MM/dd/yyyy")
                    lblINQPendingSubmittedDtlRemarks.Text = DR.GetString(5)
                    imgINQPendingSubmittedDtlAttachment.ImageUrl = IIf(DR.GetString(6) = "", "Assets/media/custom/default.png", DR.GetString(6))
                    lblINQPendingSubmittedDtlStatus.Text = DR.GetString(7)
                    lblINQPendingSubmittedDtlEmail.Text = DR.GetString(8)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlINQPendingSubmittedDtl.Update()
        bindHistoryTimeline()
        CallJS("$('#ContentPlaceHolder1_mdlINQPendingSubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQPendingSubmittedDtl').modal('show'); }, 250);")
        'display data

    End Sub

    Protected Sub lbtnINQPendingSubmittedDtlSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQPendingSubmittedDtlSubmit.Click

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        If ddlINQPendingSubmittedDtlStatus.SelectedValue = "" Or tbxINQPendingSubmittedDtlRemarks.Text = "" Then

            'alert
            Alert("Some field are empty!", "Please provide data in all fields.", "error")
            'alert

        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "BP_ApprInquiryChangeStatus"
            SqlCmd.Parameters.AddWithValue("@pINQCode", lblINQPendingSubmittedDtlCode.Text)
            SqlCmd.Parameters.AddWithValue("@pIDs", "")
            SqlCmd.Parameters.AddWithValue("@pStatus", ddlINQPendingSubmittedDtlStatus.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbxINQPendingSubmittedDtlRemarks.Text)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'alert
            Alert("Success!", "Record saved successfully.", "success")
            'alert

            'send email
            SendEmailNotification()
            'send email

            'clear fields
            lblINQPendingSubmittedDtlTitle.Text = ""
            lblINQPendingSubmittedDtlCode.Text = ""
            lblINQPendingSubmittedDtlAcctNo.Text = ""
            lblINQPendingSubmittedDtlType.Text = ""
            lblINQPendingSubmittedDtlRemarks.Text = ""
            lblINQPendingSubmittedDtlDateSubmitted.Text = ""
            imgINQPendingSubmittedDtlAttachment.ImageUrl = ""
            ddlINQPendingSubmittedDtlStatus.SelectedValue = ""
            tbxINQPendingSubmittedDtlRemarks.Text = ""
            'clear fields

            'hide modal
            CallJS("$('#ContentPlaceHolder1_mdlINQPendingSubmittedDtl').modal('hide');")
            'hide modal

            'display record
            bindInquiryHistoryList()
            bindInquiryPendingList()
            bindTotalHistory()
            bindTotalPending()
            'display record

            Exit Sub

        End If

    End Sub

#End Region

#Region "Modal Batch TL Creation"

    Private Sub ddlINQBatchTLCreationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlINQBatchTLCreationType.SelectedIndexChanged

        bindINQTLCategory(ddlINQBatchTLCreationType.SelectedValue)

    End Sub

    Function bindINQTLCategory(Type)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select category' [Text] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("    Category [Value] ")
        Query.Append("    ,Category [Text] ")
        Query.Append("from ")
        Query.Append("   Mstr_InqTrx_Category ")
        Query.Append("where ")
        Query.Append("   Type = '" & Type & "' ")
        Query.Append("order by ")
        Query.Append("   [Value] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlINQBatchTLCreationCategory.DataSource = DT
        ddlINQBatchTLCreationCategory.DataValueField = "Value"
        ddlINQBatchTLCreationCategory.DataTextField = "Text"
        ddlINQBatchTLCreationCategory.DataBind()
        'fill data

    End Function

    Protected Sub lbtnINQBatchTLClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQBatchTLClose.Click

        ddlINQBatchTLCreationLogType.SelectedValue = ""
        ddlINQBatchTLCreationOriginOfRequest.SelectedValue = ""
        ddlINQBatchTLCreationType.SelectedValue = ""
        ddlINQBatchTLCreationCategory.SelectedValue = ""
        tbxINQBatchTLCreationRemarks.Text = ""

        mdlINQBatchTLCreation.Update()
        CallJS("$('#ContentPlaceHolder1_mdlINQBatchTLCreation').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQBatchTLCreation').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnINQBatchTLCreationCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQBatchTLCreationCancel.Click

        ddlINQBatchTLCreationLogType.SelectedValue = ""
        ddlINQBatchTLCreationOriginOfRequest.SelectedValue = ""
        ddlINQBatchTLCreationType.SelectedValue = ""
        ddlINQBatchTLCreationCategory.SelectedValue = ""
        tbxINQBatchTLCreationRemarks.Text = ""

        mdlINQBatchTLCreation.Update()
        CallJS("$('#ContentPlaceHolder1_mdlINQBatchTLCreation').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQBatchTLCreation').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnINQBatchTLCreationSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQBatchTLCreationSave.Click

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        'Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gvINQPendingSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvINQPendingSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblINQPendingSubmittedID As Label = CType(gvINQPendingSubmitted.Rows(RowIdx).FindControl("lblINQPendingSubmittedID"), Label)

            If RowCheckbox.Checked = True Then
                IDSrs &= lblINQPendingSubmittedID.Text & ","
            End If

            RowIdx += 1
        Loop

        'Remove the last comma
        If IDSrs.Length > 0 Then
            IDSrs = IDSrs.TrimEnd(","c)
            batchTLCreationSave(IDSrs)
        End If

        Exit Sub

    End Sub

#End Region

#Region "Modal Batch Change Status"

    Protected Sub lbtnINQBatchChangeStatusClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQBatchChangeStatusClose.Click

        ddlINQBatchChangeStatusStatus.SelectedValue = ""
        tbxINQBatchChangeStatusRemarks.Text = ""

        mdlINQPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlINQBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnINQBatchChangeStatusCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQBatchChangeStatusCancel.Click

        ddlINQBatchChangeStatusStatus.SelectedValue = ""
        tbxINQBatchChangeStatusRemarks.Text = ""

        mdlINQPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlINQBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnINQBatchChangeStatusSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQBatchChangeStatusSave.Click

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        ' Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gvINQPendingSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvINQPendingSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gvINQPendingSubmitted.Rows(RowIdx).FindControl("lblID"), Label)

            ' If checkbox is checked, add the ID to the string
            If RowCheckbox.Checked = True Then
                IDSrs &= lblID.Text & "," ' Collect IDs, separated by commas
            End If

            RowIdx += 1
        Loop

        '' Remove the last comma
        If IDSrs.Length > 0 Then
            IDSrs = IDSrs.TrimEnd(","c)

            ' Call the method to delete the records using the stored procedure
            BatchChangeStatusSave(IDSrs)
        End If

        Exit Sub

    End Sub

#End Region

#Region "Modal History"

    Protected Sub lbtnINQHistorySubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQHistorySubmittedDtlClose.Click


        mdlINQHistorySubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlINQHistorySubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQHistorySubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQHistorySubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub btnViewINQHistorySubmitted_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg, "")
            Exit Sub
        End If
        'validate access

        'get
        Dim Query As New StringBuilder

        Query.Append("Select ")
        Query.Append("    (case when [A].Status = 'Approved' then 'bullet bullet-margin bullet-vertical h-40px bg-success' when [A].Status = 'Declined' then 'bullet bullet-margin bullet-vertical h-40px bg-danger' end) [Bullet] ")
        Query.Append("   ,[A].INQCode ")
        Query.Append("	 ,[A].CreatedDate ")
        Query.Append("	 ,[A].Inquiry ")
        Query.Append("	 ,[A].Status ")
        Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("	 ,(case when [A].Status = 'Approved' then 'badge py-2 px-4 fs-8 badge-success' when [A].Status = 'Declined' then 'badge py-2 px-4 fs-8 badge-light-warning' end) [BadgeStyle] ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    ([A].Status = 'Approved' or [A].Status = 'Declined') ")
        Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate ")
        'get

        'Create datatable and columns
        Dim dtable As New DataTable

        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("CreatedDate"))
        dtable.Columns.Add(New DataColumn("Inquiry"))
        dtable.Columns.Add(New DataColumn("BadgeStyle"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("ViewINQHistorySubmittedDtl"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = DR("Bullet")
                    Dim Title As String = DR("Title")
                    Dim CreatedDate As String = DR("CreatedDate")
                    Dim Inquiry As String = DR("Inquiry")
                    Dim BadgeStyle As String = DR("BadgeStyle")
                    Dim Status As String = DR("Status")
                    Dim ViewINQHistorySubmittedDtl As String = "ViewINQHistorySubmittedDtl('" & DR("INQCode") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, CreatedDate, Inquiry, BadgeStyle, Status, ViewINQHistorySubmittedDtl}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblINQHistorySubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvINQHistorySubmitted.DataSource = dtable
        gvINQHistorySubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlINQHistorySubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlINQHistorySubmitted').modal('show');")
        'display data

    End Sub

    Protected Sub btnViewINQHistorySubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg, "")
            Exit Sub
        End If
        'validate access

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("     [A].INQCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[C].Fullname ")
        Query.Append("    ,[A].Inquiry ")
        Query.Append("    ,[A].CreatedDate ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
        Query.Append("    ,[A].Status ")
        Query.Append("    ,[B].Fullname ")
        Query.Append("    ,[A].ApprovedDate ")
        Query.Append("    ,[A].ApprovedRemarks ")
        Query.Append("from ")
        Query.Append("	bp_inquiry [A] ")
        Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
        Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].INQCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblINQHistorySubmittedDtlCode.Text = hfID.Value
                    lblINQHistorySubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - Request and Inquiry"
                    lblINQHistorySubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblINQHistorySubmittedDtlName.Text = DR.GetString(2)
                    lblINQHistorySubmittedDtlInquiryType.Text = DR.GetString(3)
                    lblINQHistorySubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(4), "MM/dd/yyyy")
                    lblINQHistorySubmittedDtlRemarks.Text = DR.GetString(5)
                    imgINQHistorySubmittedDtlAttachment.ImageUrl = IIf(DR.GetString(6) = "", "Assets/media/custom/default.png", DR.GetString(6))
                    lblINQHistorySubmittedDtlStatus.Text = DR.GetString(7)
                    lblINQHistorySubmittedDtlApprovedBy.Text = DR.GetString(8)
                    lblINQHistorySubmittedDtlApprovedDate.Text = Format(DR.GetDateTime(9), "MM/dd/yyyy")
                    lblINQHistorySubmittedDtlApproverRemarks.Text = DR.GetString(10)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlINQHistorySubmittedDtl.Update()
        bindHistoryTimeline()
        CallJS("$('#ContentPlaceHolder1_mdlINQHistorySubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlINQHistorySubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlINQHistorySubmittedDtl').modal('show'); }, 250);")

        'display data

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

        If gvINQPendingList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvINQPendingList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvINQPendingList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvINQPendingList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gvINQHistoryList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvINQHistoryList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvINQHistoryList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvINQHistoryList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If


        If gvINQPendingSubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvINQPendingSubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvINQPendingSubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvINQPendingSubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gvINQHistorySubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvINQHistorySubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvINQHistorySubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvINQHistorySubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindHistoryTimeline()

        'get
        Dim Query As New StringBuilder

        Dim INQCode As String = IIf(lblINQPendingSubmittedDtlCode.Text = "", lblINQHistorySubmittedDtlCode.Text, lblINQPendingSubmittedDtlCode.Text)

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
        Query.Append("   [A].TblCode = '" & INQCode & "' ")
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
                    If DR("Type") = "Change Status Inquiry:" Then
                        svg = "<path d='M3.5,3 L5,3 L5,19.5 C5,20.3284271 4.32842712,21 3.5,21 L3.5,21 C2.67157288,21 2,20.3284271 2,19.5 L2,4.5 C2,3.67157288 2.67157288,3 3.5,3 Z' fill='#279852'/> <path d='M6.99987583,2.99995344 L19.754647,2.99999303 C20.3069317,2.99999474 20.7546456,3.44771138 20.7546439,3.99999613 C20.7546431,4.24703684 20.6631995,4.48533385 20.497938,4.66895776 L17.5,8 L20.4979317,11.3310353 C20.8673908,11.7415453 20.8341123,12.3738351 20.4236023,12.7432941 C20.2399776,12.9085564 20.0016794,13 19.7546376,13 L6.99987583,13 L6.99987583,2.99995344 Z' fill='#279852' opacity='0.3'/>"
                    ElseIf DR("Type") = "Transaction Log Created:" Then
                        svg = "<path d='M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z M10.875,15.75 C11.1145833,15.75 11.3541667,15.6541667 11.5458333,15.4625 L15.3791667,11.6291667 C15.7625,11.2458333 15.7625,10.6708333 15.3791667,10.2875 C14.9958333,9.90416667 14.4208333,9.90416667 14.0375,10.2875 L10.875,13.45 L9.62916667,12.2041667 C9.29375,11.8208333 8.67083333,11.8208333 8.2875,12.2041667 C7.90416667,12.5875 7.90416667,13.1625 8.2875,13.5458333 L10.2041667,15.4625 C10.3958333,15.6541667 10.6354167,15.75 10.875,15.75 Z' fill='#279852' fill-rule='nonzero' opacity='0.3'/> <path d='M10.875,15.75 C10.6354167,15.75 10.3958333,15.6541667 10.2041667,15.4625 L8.2875,13.5458333 C7.90416667,13.1625 7.90416667,12.5875 8.2875,12.2041667 C8.67083333,11.8208333 9.29375,11.8208333 9.62916667,12.2041667 L10.875,13.45 L14.0375,10.2875 C14.4208333,9.90416667 14.9958333,9.90416667 15.3791667,10.2875 C15.7625,10.6708333 15.7625,11.2458333 15.3791667,11.6291667 L11.5458333,15.4625 C11.3541667,15.6541667 11.1145833,15.75 10.875,15.75 Z' fill='#279852'/>"
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
        divINQPendingSubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        divINQHistorySubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        'display data

    End Function

    Function SendEmailNotification()

        Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
        Dim mail As MailMessage
        Dim body As String
        smtp.Credentials = New NetworkCredential("ciissystems@calmarland.com", "M5ilp5ssw0rd")
        smtp.Host = "mail.calmarland.com"
        smtp.Port = 587
        mail = New MailMessage()
        mail.From = New MailAddress("ciissystems@calmarland.com")
        mail.To.Add(lblINQPendingSubmittedDtlEmail.Text)
        mail.Subject = "Request/Inquiry " & lblINQPendingSubmittedDtlSubject.Text & " has been" & ddlINQPendingSubmittedDtlStatus.SelectedValue

        Dim Content As String = ""

        Content = Content & "<style>html,body { padding: 0; margin:0; }</style>"
        Content = Content & "<div style='background-color:#edf2f7; padding:20px;'>"
        Content = Content & "<table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse:collapse;margin:0 auto; padding:0; max-width:600px'>"
        Content = Content & "   <tbody>"
        Content = Content & "      <tr>"
        Content = Content & "         <td align='center' valign='center' style='text-align:center; padding: 40px'>"
        Content = Content & "             <a href='http://buyersportal.calmarland.com:807/Account/Login' rel='noopener' target='_blank'>"
        Content = Content & "                <img alt='Logo' src='http://buyersportal.calmarland.com:807/Assets/media/logos/cldc_logo_full.png' style='width:350px;height:60px'/>"
        Content = Content & "             </a>"
        Content = Content & "         </td>"
        Content = Content & "     </tr>"
        Content = Content & "     <tr>"
        Content = Content & "       <td align='left' valign='center'>"
        Content = Content & "          <div style='text-align:Left(); margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px'>"
        Content = Content & "          <!--begin:Email content-->"
        Content = Content & "          <div style='padding-bottom: 30px; font-size: 17px;'>"
        Content = Content & "             <strong>Hello " & lblINQPendingSubmittedDtlName.Text & ", </strong>"
        Content = Content & "          </div>"
        Content = Content & "          <div style='padding-bottom: 20px'>Your submitted request/inquiry with subject " & lblINQPendingSubmittedDtlSubject.Text & " has been " & ddlINQPendingSubmittedDtlStatus.SelectedValue & ".</div>"
        Content = Content & "          <!--end:Email content-->"
        Content = Content & "          <div style='padding-bottom: 10px'>Kind regards,"
        Content = Content & "          <br><br>Calmarland Development Corporation."
        Content = Content & "          <tr>"
        Content = Content & "             <td align='center' valign='center' style='font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;'>"
        Content = Content & "                <p>Copyright ©"
        Content = Content & "                <a href='http://buyersportal.calmarland.com:807/Account/Login' rel='noopener' target='_blank'>Calmar Land</a>.</p>"
        Content = Content & "             </td>"
        Content = Content & "          </tr>"
        Content = Content & "          <br>"
        Content = Content & "          </div>"
        Content = Content & "         </div>"
        Content = Content & "       </td>"
        Content = Content & "     </tr>"
        Content = Content & "   </tbody>"
        Content = Content & " </table>"
        Content = Content & "</div>"

        mail.Body = Content
        mail.IsBodyHtml = True
        smtp.Send(mail)
        mail.Dispose()

    End Function

    Function batchTLCreationSave(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprInquiryTLCreation"
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pStatus", ddlINQBatchTLCreationLogType.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pOriginOfRequest", ddlINQBatchTLCreationOriginOfRequest.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pType", ddlINQBatchTLCreationType.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pCategory", ddlINQBatchTLCreationCategory.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxINQBatchTLCreationRemarks.Text)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'clear fields
        ddlINQBatchTLCreationLogType.SelectedValue = ""
        ddlINQBatchTLCreationOriginOfRequest.SelectedValue = ""
        ddlINQBatchTLCreationType.SelectedValue = ""
        ddlINQBatchTLCreationCategory.SelectedValue = ""
        tbxINQBatchTLCreationRemarks.Text = ""
        'clear fields

        'alert
        Alert("Success!", "Record save successfully.", "success")
        'alert

        'hide modal
        CallJS("$('#ContentPlaceHolder1_mdlINQTLCreation').modal('hide');")
        'hide modal

        'display record
        bindTotalPending()
        bindInquiryPendingList()
        bindTotalHistory()
        bindInquiryHistoryList()
        'display record

    End Function

    Function BatchChangeStatusSave(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprInquiryChangeStatus"
        SqlCmd.Parameters.AddWithValue("@pINQCode", "")
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pStatus", ddlINQBatchChangeStatusStatus.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxINQBatchChangeStatusRemarks.Text)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'clear fields
        ddlINQBatchChangeStatusStatus.SelectedValue = ""
        tbxINQBatchChangeStatusRemarks.Text = ""
        'clear fields

        'alert
        Alert("Success!", "Record save successfully.", "success")
        'alert

        CallJS("$('#ContentPlaceHolder1_mdlINQBatchChangeStatus').modal('hide');")

        'display record
        bindTotalPending()
        bindInquiryPendingList()
        bindTotalHistory()
        bindInquiryHistoryList()
        'display record

    End Function

    Function bindTotalHistory()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	 count([A].INQCode) ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Approved' or Status = 'Declined') ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01HistoryTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlINQTotal.Update()
        'display data

    End Function

    Function bindTotalPending()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	 count([A].AcctNo) ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Pending') ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01PendingTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlINQTotal.Update()
        'display data

    End Function

    Function bindInquiryHistoryList()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Approved' or Status = 'Declined') ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("ViewINQHistorySubmitted"))
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
                    Dim Fullname As String = DR("Fullname")
                    Dim ViewINQHistorySubmitted As String = "ViewINQHistorySubmitted('" & DR("AcctNo") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Fullname, ViewINQHistorySubmitted}
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
        gvINQHistoryList.DataSource = dtable
        gvINQHistoryList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlINQHistoryList.Update()
        'display data

    End Function

    Function bindInquiryPendingList()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("	 ,(select count(INQCode) from bp_inquiry left join bp_user on bp_inquiry.AcctNo = bp_user.AcctNo where (bp_inquiry.Status = 'Pending' or bp_inquiry.Status = 'In Process') and bp_inquiry.AcctNo = [A].AcctNo) [TotalSubmitted] ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Pending' or Status = 'In Process') ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewINQPendingSubmitted"))
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("TotalSubmitted"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim ViewINQPendingSubmitted As String = "ViewINQPendingSubmitted('" & DR("AcctNo") & "')"
                    Dim AcctNo As String = DR("AcctNo")
                    Dim Fullname As String = DR("Fullname")
                    Dim TotalSubmitted As String = DR("TotalSubmitted")

                    'add new row
                    Dim NewRowValues As Object() = {ViewINQPendingSubmitted, AcctNo, Fullname, TotalSubmitted}
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
        gvINQPendingList.EmptyDataText = "No data"
        gvINQPendingList.DataSource = dtable
        gvINQPendingList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlINQPendingList.Update()
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
        If Group_ = "INQAccess" Then
            If Type = "Save" Then
                Query.Append("if 'AAD010300' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010300' and Save_ = 1) ")
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