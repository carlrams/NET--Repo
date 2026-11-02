Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail

Public Class SubmittedRemittance
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
    Dim UserID As String = "ciis"
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
            bindRSTotalHistory()
            bindRSTotalPending()
            bindRSHistoryList()
            bindRSPendingList()

        End If
    End Sub

#End Region

#Region "Modal Approved"

    'Protected Sub btnViewRSApproved_Click(ByVal sender As Object, e As EventArgs)

    '    'get selected data
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("     [A].RSCode ")
    '    Query.Append("    ,[A].AcctNo ")
    '    Query.Append("    ,[C].fullname ")
    '    Query.Append("    ,[A].RSDate ")
    '    Query.Append("    ,[A].RSRefNo ")
    '    Query.Append("    ,[A].RSAmount ")
    '    Query.Append("    ,[A].Remarks ")
    '    Query.Append("    ,[A].CreatedDate ")
    '    Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
    '    Query.Append("    ,[A].Status ")
    '    Query.Append("    ,isnull([B].Fullname,'') ")
    '    Query.Append("    ,[A].ApprovedDate ")
    '    Query.Append("    ,[A].ApprovedRemarks ")
    '    Query.Append("from ")
    '    Query.Append("	bp_remittance [A] ")
    '    Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
    '    Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("  [A].RSCode = '" & hfID.Value & "' ")
    '    'get selected data

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                lbl02RemittanceTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - Remittance Slip"
    '                lbl02AcctNo.Text = DR.GetString(1)
    '                lbl02Name.Text = DR.GetString(2)
    '                lbl02RemittanceDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
    '                lbl02ReferenceNo.Text = DR.GetString(4)
    '                lbl02Amount.Text = DR.GetDecimal(5).ToString("N2")
    '                lbl02Remarks.Text = DR.GetString(6)
    '                lbl02DateSubmitted.Text = Format(DR.GetDateTime(7), "MM/dd/yyyy")
    '                img02Attachment.ImageUrl = IIf(DR.GetString(8) = "", "Assets/media/custom/default.png", DR.GetString(8))
    '                lbl02Status.Text = DR.GetString(9)
    '                lbl02ApprovedBy.Text = DR.GetString(10)
    '                lbl02ApprovedDate.Text = Format(DR.GetDateTime(11), "MM/dd/yyyy")
    '                lbl02ApproverRemarks.Text = DR.GetString(12)

    '            End While
    '            DR.Close()
    '            ConStr.Close()

    '        End Using
    '    End Using
    '    'read record

    '    'display data
    '    mdl01ApprovedRemittance.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01ApprovedRemittance').modal('show');</script>", False)
    '    'display data

    'End Sub

    'Private Sub gv02RemittanceApproved_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv02RemittanceApproved.RowCommand

    '    'get selected data
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("     [A].RSCode ")
    '    Query.Append("    ,[A].AcctNo ")
    '    Query.Append("    ,[C].fullname ")
    '    Query.Append("    ,[A].RSDate ")
    '    Query.Append("    ,[A].RSRefNo ")
    '    Query.Append("    ,[A].RSAmount ")
    '    Query.Append("    ,[A].Remarks ")
    '    Query.Append("    ,[A].CreatedDate ")
    '    Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
    '    Query.Append("    ,[A].Status ")
    '    Query.Append("    ,isnull([B].Fullname,'') ")
    '    Query.Append("    ,[A].ApprovedDate ")
    '    Query.Append("    ,[A].ApprovedRemarks ")
    '    Query.Append("from ")
    '    Query.Append("	bp_remittance [A] ")
    '    Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
    '    Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("  [A].RSCode = '" & e.CommandArgument & "' ")
    '    'get selected data

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                lbl02RemittanceTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - Remittance Slip"
    '                lbl02AcctNo.Text = DR.GetString(1)
    '                lbl02Name.Text = DR.GetString(2)
    '                lbl02RemittanceDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
    '                lbl02ReferenceNo.Text = DR.GetString(4)
    '                lbl02Amount.Text = DR.GetDecimal(5).ToString("N2")
    '                lbl02Remarks.Text = DR.GetString(6)
    '                lbl02DateSubmitted.Text = Format(DR.GetDateTime(7), "MM/dd/yyyy")
    '                img02Attachment.ImageUrl = IIf(DR.GetString(8) = "", "Assets/media/custom/default.png", DR.GetString(8))
    '                lbl02Status.Text = DR.GetString(9)
    '                lbl02ApprovedBy.Text = DR.GetString(10)
    '                lbl02ApprovedDate.Text = Format(DR.GetDateTime(11), "MM/dd/yyyy")
    '                lbl02ApproverRemarks.Text = DR.GetString(12)

    '            End While
    '            DR.Close()
    '            ConStr.Close()

    '        End Using
    '    End Using
    '    'read record

    '    'display data
    '    mdl01ApprovedRemittance.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01ApprovedRemittance').modal('show');</script>", False)
    '    'display data

    'End Sub

#End Region

#Region "Modal Submitted Pending"

    Protected Sub btnViewRSPendingSubmitted_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("RSAccess", "Save", "")
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
        Query.Append("	  [A].RSCode ")
        Query.Append("	 ,[A].RSDate ")
        Query.Append("	 ,[A].RSRefNo ")
        Query.Append("	 ,[A].Status ")
        Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("from ")
        Query.Append("	 bp_remittance [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    [A].Status = 'Pending' ")
        Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("order by ")
        Query.Append("   [A].RSDate ")
        'get

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewRSPendingSubmittedDtl"))
        dtable.Columns.Add(New DataColumn("RSDate"))
        dtable.Columns.Add(New DataColumn("RSRefNo"))
        dtable.Columns.Add(New DataColumn("Status"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim ViewRSPendingSubmittedDtl As String = "ViewRSPendingSubmittedDtl('" & DR("RSCode") & "')"
                    Dim RSDate As String = DR("RSDate")
                    Dim RSRefNo As String = DR("RSRefNo")
                    Dim Status As String = DR("Status")
                    Dim Title As String = DR("Title")

                    'add new row
                    Dim NewRowValues As Object() = {ViewRSPendingSubmittedDtl, RSDate, RSRefNo, Status}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblRSPendingSubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvRSPendingSubmitted.DataSource = dtable
        gvRSPendingSubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlRSPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlRSPendingSubmitted').modal('show');")
        'display data

    End Sub

    'Private Sub gv01RemittancePending_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv01RemittancePending.RowCommand

    '    'create variable
    '    Dim Msg As String = Validate("RemittanceAccess", "Save", "")
    '    'create variable

    '    'validate access
    '    If Msg <> "" Then
    '        Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
    '        Exit Sub
    '    End If
    '    'validate access

    '    'get selected data
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("     [A].RSCode ")
    '    Query.Append("    ,[A].AcctNo ")
    '    Query.Append("    ,[B].Fullname ")
    '    Query.Append("    ,[A].RSDate ")
    '    Query.Append("    ,[A].RSRefNo ")
    '    Query.Append("    ,[A].RSAmount ")
    '    Query.Append("    ,[A].Remarks ")
    '    Query.Append("    ,[A].CreatedDate ")
    '    Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
    '    Query.Append("    ,[B].Email ")
    '    Query.Append("from ")
    '    Query.Append("	bp_remittance [A] ")
    '    Query.Append("	left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("  [A].RSCode = '" & e.CommandArgument & "' ")
    '    'get selected data

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                lbl01RemittanceTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - Remittance Slip"
    '                lbl01RSCode.Text = e.CommandArgument
    '                lbl01AcctNo.Text = DR.GetString(1)
    '                lbl01Name.Text = DR.GetString(2)
    '                lbl01RemittanceDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
    '                lbl01ReferenceNo.Text = DR.GetString(4)
    '                lbl01Amount.Text = DR.GetDecimal(5).ToString("N2")
    '                lbl01Remarks.Text = DR.GetString(6)
    '                lbl01DateSubmitted.Text = Format(DR.GetDateTime(7), "MM/dd/yyyy")
    '                img01Attachment.ImageUrl = IIf(DR.GetString(8) = "", "Assets/media/custom/default.png", DR.GetString(8))
    '                lbl01Email.Text = DR.GetString(9)

    '            End While
    '            DR.Close()
    '            ConStr.Close()

    '        End Using
    '    End Using
    '    'read record

    '    'display data
    '    mdl01UpdateRemittance.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01UpdateRemittance').modal('show');</script>", False)
    '    'display data

    'End Sub

#End Region

#Region "Modal Batch Change Status"

    Protected Sub lbtnRSBatchChangeStatusClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnRSBatchChangeStatusClose.Click

        ddlRSBatchChangeStatusStatus.SelectedValue = ""
        tbxRSBatchChangeStatusRemarks.Text = ""

        mdlRSPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlRSBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlRSBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlRSPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnRSBatchChangeStatusCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnRSBatchChangeStatusCancel.Click

        ddlRSBatchChangeStatusStatus.SelectedValue = ""
        tbxRSBatchChangeStatusRemarks.Text = ""

        mdlRSPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlRSBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlRSBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlRSPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnRSBatchChangeStatusSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnRSBatchChangeStatusSave.Click

        'create variable
        Dim Msg As String = Validate("RSAccess", "Save", "")
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
        Do Until RowIdx = gvRSPendingSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvRSPendingSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gvRSPendingSubmitted.Rows(RowIdx).FindControl("lblID"), Label)

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

#Region "Modal Pending Submitted Detail"

    Protected Sub llbtnRSPendingSubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnRSPendingSubmittedDtlClose.Click

        ddlRSPendingSubmittedDtlStatus.SelectedValue = ""
        tbxRSPendingSubmittedDtlRemarks.Text = ""
        CallJS("$('#ContentPlaceHolder1_mdlRSPendingSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlRSPendingSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlRSPendingSubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnRSPendingSubmittedDtlCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnRSPendingSubmittedDtlCancel.Click

        ddlRSPendingSubmittedDtlStatus.SelectedValue = ""
        tbxRSPendingSubmittedDtlRemarks.Text = ""
        CallJS("$('#ContentPlaceHolder1_mdlRSPendingSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlRSPendingSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlRSPendingSubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub btnViewRSPendingSubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("RSAccess", "Save", "")
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
        Query.Append("     [A].RSCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[B].Fullname ")
        Query.Append("    ,[A].RSDate ")
        Query.Append("    ,[A].RSRefNo ")
        Query.Append("    ,[A].RSAmount ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,[A].CreatedDate ")
        Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
        Query.Append("    ,[B].Email ")
        Query.Append("from ")
        Query.Append("	bp_remittance [A] ")
        Query.Append("	left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("  [A].RSCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblRSPendingSubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - Remittance Slip"
                    lblRSPendingSubmittedDtlCode.Text = hfID.Value
                    lblRSPendingSubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblRSPendingSubmittedDtlName.Text = DR.GetString(2)
                    lblRSPendingSubmittedDtlRemittanceDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lblRSPendingSubmittedDtlReferenceNo.Text = DR.GetString(4)
                    lblRSPendingSubmittedDtlAmount.Text = DR.GetDecimal(5).ToString("N2")
                    lblRSPendingSubmittedDtlRemarks.Text = DR.GetString(6)
                    lblRSPendingSubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(7), "MM/dd/yyyy")
                    imgRSPendingSubmittedDtlAttachment.ImageUrl = IIf(DR.GetString(8) = "", "Assets/media/custom/default.png", DR.GetString(8))
                    lblRSPendingSubmittedDtlEmail.Text = DR.GetString(9)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlRSPendingSubmittedDtl.Update()
        CallJS("$('#ContentPlaceHolder1_mdlRSPendingSubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlRSPendingSubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlRSPendingSubmittedDtl').modal('show'); }, 250);")
        'display data

    End Sub

    Protected Sub lbtnRSPendingSubmittedDtlSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnRSPendingSubmittedDtlSubmit.Click

        'create variable
        Dim Msg As String = Validate("INQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        If ddlRSPendingSubmittedDtlStatus.SelectedValue = "" Or tbxRSPendingSubmittedDtlRemarks.Text = "" Then

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
            SqlCmd.CommandText = "BP_ApprRSChangeStatus"
            SqlCmd.Parameters.AddWithValue("@pRSCode", lblRSPendingSubmittedDtlCode.Text)
            SqlCmd.Parameters.AddWithValue("@pIDs", "")
            SqlCmd.Parameters.AddWithValue("@pStatus", ddlRSPendingSubmittedDtlStatus.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbxRSPendingSubmittedDtlRemarks.Text)
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
            lblRSPendingSubmittedDtlTitle.Text = ""
            lblRSPendingSubmittedDtlCode.Text = ""
            lblRSPendingSubmittedDtlAcctNo.Text = ""
            lblRSPendingSubmittedDtlName.Text = ""
            lblRSPendingSubmittedDtlRemittanceDate.Text = ""
            lblRSPendingSubmittedDtlReferenceNo.Text = ""
            lblRSPendingSubmittedDtlAmount.Text = ""
            lblRSPendingSubmittedDtlDateSubmitted.Text = ""
            tbxRSPendingSubmittedDtlRemarks.Text = ""
            imgRSPendingSubmittedDtlAttachment.ImageUrl = ""
            ddlRSPendingSubmittedDtlStatus.SelectedValue = ""
            tbxRSPendingSubmittedDtlRemarks.Text = ""

            'clear fields

            'hide modal
            CallJS("$('#ContentPlaceHolder1_mdlRSPendingSubmittedDtl').modal('hide');")
            'hide modal

            'display record
            bindRSHistoryList()
            bindRSPendingList()
            bindRSTotalHistory()
            bindRSTotalPending()
            'display record

            Exit Sub

        End If

    End Sub

#End Region

#Region "Modal History Submitted Detail"

    Protected Sub lbtnRSHistorySubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnRSHistorySubmittedDtlClose.Click


        mdlRSHistorySubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlRSHistorySubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlRSHistorySubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlRSHistorySubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub btnViewRSHistorySubmitted_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("RSAccess", "Save", "")
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
        Query.Append("   ,[A].RSCode ")
        Query.Append("	 ,[A].RSDate ")
        Query.Append("	 ,[A].RSRefNo ")
        Query.Append("	 ,[A].Status ")
        Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("	 ,(case when [A].Status = 'Approved' then 'badge py-2 px-4 fs-8 badge-success' when [A].Status = 'Declined' then 'badge py-2 px-4 fs-8 badge-light-warning' end) [BadgeStyle] ")
        Query.Append("from ")
        Query.Append("	 bp_remittance [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    ([A].Status = 'Approved' or [A].Status = 'Declined') ")
        Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("order by ")
        Query.Append("   [A].RSDate ")
        'get

        'Create datatable and columns
        Dim dtable As New DataTable

        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("RSDate"))
        dtable.Columns.Add(New DataColumn("RSRefNo"))
        dtable.Columns.Add(New DataColumn("BadgeStyle"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("ViewRSHistorySubmittedDtl"))
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
                    Dim CreatedDate As String = DR("RSDate")
                    Dim Inquiry As String = DR("RSRefNo")
                    Dim BadgeStyle As String = DR("BadgeStyle")
                    Dim Status As String = DR("Status")
                    Dim ViewRSHistorySubmittedDtl As String = "ViewRSHistorySubmittedDtl('" & DR("RSCode") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, CreatedDate, Inquiry, BadgeStyle, Status, ViewRSHistorySubmittedDtl}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblRSHistorySubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvRSHistorySubmitted.DataSource = dtable
        gvRSHistorySubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlRSHistorySubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlRSHistorySubmitted').modal('show');")
        'display data

    End Sub

    Protected Sub btnViewRSHistorySubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("RSAccess", "Save", "")
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
        Query.Append("     [A].RSCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[C].fullname ")
        Query.Append("    ,[A].RSDate ")
        Query.Append("    ,[A].RSRefNo ")
        Query.Append("    ,[A].RSAmount ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,[A].CreatedDate ")
        Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
        Query.Append("    ,[A].Status ")
        Query.Append("    ,isnull([B].Fullname,'') ")
        Query.Append("    ,[A].ApprovedDate ")
        Query.Append("    ,[A].ApprovedRemarks ")
        Query.Append("from ")
        Query.Append("	bp_remittance [A] ")
        Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
        Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
        Query.Append("where ")
        Query.Append("  [A].RSCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblRSHistorySubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - Remittance Slip"
                    lblRSHistorySubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblRSHistorySubmittedDtlName.Text = DR.GetString(2)
                    lblRSHistorySubmittedDtlRemittanceDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lblRSHistorySubmittedDtlReferenceNo.Text = DR.GetString(4)
                    lblRSHistorySubmittedDtlAmount.Text = DR.GetDecimal(5).ToString("N2")
                    lblRSHistorySubmittedDtlRemarks.Text = DR.GetString(6)
                    lblRSHistorySubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(7), "MM/dd/yyyy")
                    imgRSHistorySubmittedDtlAttachment.ImageUrl = IIf(DR.GetString(8) = "", "Assets/media/custom/default.png", DR.GetString(8))
                    lblRSHistorySubmittedDtlStatus.Text = DR.GetString(9)
                    lblRSHistorySubmittedDtlApprovedBy.Text = DR.GetString(10)
                    lblRSHistorySubmittedDtlApprovedDate.Text = Format(DR.GetDateTime(11), "MM/dd/yyyy")
                    lblRSHistorySubmittedDtlApproverRemarks.Text = DR.GetString(12)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlRSHistorySubmittedDtl.Update()
        CallJS("$('#ContentPlaceHolder1_mdlRSHistorySubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlRSHistorySubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlRSHistorySubmittedDtl').modal('show'); }, 250);")
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
        If gvRSPendingList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvRSPendingList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvRSPendingList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvRSPendingList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gvRSPendingSubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvRSPendingSubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvRSPendingSubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvRSPendingSubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gvRSHistoryList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvRSHistoryList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvRSHistoryList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvRSHistoryList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gvRSHistorySubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvRSHistorySubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvRSHistorySubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvRSHistorySubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

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
        mail.To.Add(lblRSPendingSubmittedDtlEmail.Text)
        mail.To.Add("norween.laborte@calmarland.com")
        mail.Subject = "Remittance Slip " & lblRSPendingSubmittedDtlReferenceNo.Text & " has been" & ddlRSPendingSubmittedDtlStatus.SelectedValue

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
        Content = Content & "             <strong>Hello " & lblRSPendingSubmittedDtlName.Text & ", </strong>"
        Content = Content & "          </div>"
        Content = Content & "          <div style='padding-bottom: 20px'>Your submitted remittance slip with reference no " & lblRSPendingSubmittedDtlReferenceNo.Text & " has been " & ddlRSPendingSubmittedDtlStatus.SelectedValue & ".</div>"
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

    Function BatchChangeStatusSave(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprRSChangeStatus"
        SqlCmd.Parameters.AddWithValue("@pINQCode", "")
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pStatus", ddlRSBatchChangeStatusStatus.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxRSBatchChangeStatusRemarks.Text)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'clear fields
        ddlRSBatchChangeStatusStatus.SelectedValue = ""
        tbxRSBatchChangeStatusRemarks.Text = ""
        'clear fields

        'alert
        Alert("Success!", "Record save successfully.", "success")
        'alert

        CallJS("$('#ContentPlaceHolder1_mdlINQBatchChangeStatus').modal('hide');")

        'display record
        bindRSTotalPending()
        bindRSPendingList()
        bindRSTotalHistory()
        bindRSHistoryList()
        'display record

    End Function

    Function bindRSTotalHistory()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(RSCode) ")
        Query.Append("from ")
        Query.Append("	 bp_remittance ")
        Query.Append("where ")
        Query.Append("   status = 'Approved' ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblHistoryTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlRemittanceTotal.Update()
        'display data

    End Function

    Function bindRSTotalPending()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(RSCode) ")
        Query.Append("from ")
        Query.Append("	 bp_remittance ")
        Query.Append("where ")
        Query.Append("    Status = 'Pending' ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPendingTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlRemittanceTotal.Update()
        'display data

    End Function

    Function bindRSHistoryList()

        'get pending
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("from ")
        Query.Append("	 bp_remittance [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Approved' or [A].Status = 'Declined') ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("ViewRSHistorySubmitted"))
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
                    Dim ViewRSHistorySubmitted As String = "ViewRSHistorySubmitted('" & DR("AcctNo") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Fullname, ViewRSHistorySubmitted}
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
        gvRSHistoryList.DataSource = dtable
        gvRSHistoryList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlRSHistoryList.Update()
        'display data

    End Function

    Function bindRSPendingList()

        'get pending
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("	 ,(select count(RSCode) from bp_remittance left join bp_user on bp_remittance.AcctNo = bp_user.AcctNo where (bp_remittance.Status = 'Pending') and bp_remittance.AcctNo = [A].AcctNo) [TotalSubmitted] ")
        Query.Append("from ")
        Query.Append("	 bp_remittance [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Pending' ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("TotalSubmitted"))
        dtable.Columns.Add(New DataColumn("ViewRSPendingSubmitted"))
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
                    Dim TotalSubmitted As String = DR("TotalSubmitted")
                    Dim ViewRSPendingSubmitted As String = "ViewRSPendingSubmitted('" & DR("AcctNo") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Fullname, TotalSubmitted, ViewRSPendingSubmitted}
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
        gvRSPendingList.DataSource = dtable
        gvRSPendingList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlRSPendingList.Update()
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
        If Group_ = "RSAccess" Then
            If Type = "Save" Then
                Query.Append("if 'AAD010500' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010500' and Save_ = 1) ")
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