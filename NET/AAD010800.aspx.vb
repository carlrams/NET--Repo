Imports System.Data.SqlClient
Imports System.IO

Public Class VerifiedPDC
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
            bindPDCTotalHistory()
            bindPDCTotalPending()
            bindPDCHistoryList()
            bindPDCPendingList()


            If CIIS_Department = "Business Tech Department" Then
                'If CIIS_Department = "Customer Service" Then
                divFINButton.Visible = True
            Else
                divFINButton.Visible = False
            End If

        End If

    End Sub

#End Region

#Region "Modal Declined"

    'Private Sub gv03RPDCDeclined_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv03PDCDeclined.RowCommand

    '    'get selected data
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("     [A].PDCCode ")
    '    Query.Append("    ,[A].AcctNo ")
    '    Query.Append("    ,[C].Fullname ")
    '    Query.Append("    ,[A].CheckDate ")
    '    Query.Append("    ,[A].CheckNo ")
    '    Query.Append("    ,[A].Amount ")
    '    Query.Append("    ,[A].Bank ")
    '    Query.Append("    ,[A].Remarks ")
    '    Query.Append("    ,[A].CreatedDate ")
    '    Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
    '    Query.Append("    ,[A].Status ")
    '    Query.Append("    ,isnull([B].Fullname,'') [Name] ")
    '    Query.Append("    ,[A].ApprovedDate ")
    '    Query.Append("    ,[A].ApprovedRemarks ")
    '    Query.Append("from ")
    '    Query.Append("	bp_PDC [A] ")
    '    Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
    '    Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("   PDCCode = '" & e.CommandArgument & "' ")
    '    'get selected data

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                lbl03PDCTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
    '                lbl03AcctNo.Text = DR.GetString(1)
    '                lbl03Name.Text = DR.GetString(2)
    '                lbl03CheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
    '                lbl03CheckNo.Text = DR.GetString(4)
    '                lbl03Amount.Text = DR.GetDecimal(5).ToString("N2")
    '                lbl03Bank.Text = DR.GetString(6)
    '                lbl03Remarks.Text = DR.GetString(7)
    '                lbl03DateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
    '                img03Attachment.ImageUrl = IIf(DR.GetString(9) = "", "Assets/media/custom/default.png", DR.GetString(9))
    '                lbl03Status.Text = DR.GetString(10)
    '                lbl03ApprovedBy.Text = DR.GetString(11)
    '                lbl03ApprovedDate.Text = Format(DR.GetDateTime(12), "MM/dd/yyyy")
    '                lbl03ApproverRemarks.Text = DR.GetString(13)

    '            End While
    '            DR.Close()
    '            ConStr.Close()

    '        End Using
    '    End Using
    '    'read record

    '    'display data
    '    mdl03DeclinedPDC.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl03DeclinedPDC').modal('show');</script>", False)
    '    'display data

    'End Sub

#End Region

#Region "Modal Verified"

    Protected Sub btnViewPDCHistorySubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

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

                    lblPDCHistorySubmittedDtlCode.Text = DR.GetString(0)
                    lblPDCHistorySubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
                    lblPDCHistorySubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblPDCHistorySubmittedDtlName.Text = DR.GetString(2)
                    lblPDCHistorySubmittedDtlCheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lblPDCHistorySubmittedDtlCheckNo.Text = DR.GetString(4)
                    lblPDCHistorySubmittedDtlAmount.Text = DR.GetDecimal(5).ToString("N2")
                    lblPDCHistorySubmittedDtlBank.Text = DR.GetString(6)
                    lblPDCHistorySubmittedDtlRemarks.Text = DR.GetString(7)
                    lblPDCHistorySubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
                    lblPDCHistorySubmittedDtlStatus.Text = DR.GetString(9)
                    lblPDCHistorySubmittedDtlApprovedBy.Text = DR.GetString(10)
                    lblPDCHistorySubmittedDtlApprovedDate.Text = Format(DR.GetDateTime(11), "MM/dd/yyyy")
                    lblPDCHistorySubmittedDtlApproverRemarks.Text = DR.GetString(12)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlPDCHistorySubmittedDtl.Update()
        RenderDatatable()
        bindHistoryTimeline()
        CallJS("$('#ContentPlaceHolder1_mdlPDCHistorySubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCHistorySubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCHistorySubmittedDtl').modal('show'); }, 250);")
        'display data

    End Sub

    Protected Sub btnViewPDCHistorySubmitted_Click(ByVal sender As Object, e As EventArgs)

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
        Query.Append("    (case when [A].Status = 'Approved' then 'bullet bullet-margin bullet-vertical h-40px bg-success' when [A].Status = 'Declined' then 'bullet bullet-margin bullet-vertical h-40px bg-danger' end) [Bullet] ")
        Query.Append("	 ,[A].PDCCode ")
        Query.Append("	 ,[A].CheckDate ")
        Query.Append("	 ,[A].CheckNo ")
        Query.Append("	 ,(case when [A].CSVerified is not null then 'Verified' end) [Status] ")
        Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("	 ,(case when [A].Status = 'Approved' then 'badge py-2 px-4 fs-8 badge-success' when [A].Status = 'Declined' then 'badge py-2 px-4 fs-8 badge-light-warning' end) [BadgeStyle] ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    ([A].Status = 'Approved' or [A].Status = 'Declined') ")
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
        dtable.Columns.Add(New DataColumn("BadgeStyle"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("ViewPDCHistorySubmittedDtl"))
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
                    Dim CheckDate As String = DR("CheckDate")
                    Dim CheckNo As String = DR("CheckNo")
                    Dim Status As String = DR("Status")
                    Dim BadgeStyle As String = DR("BadgeStyle")
                    Dim ViewPDCHistorySubmittedDtl As String = "ViewPDCHistorySubmittedDtl('" & DR("PDCCode") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, CheckDate, CheckNo, BadgeStyle, Status, ViewPDCHistorySubmittedDtl}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblPDCHistorySubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvPDCHistorySubmitted.DataSource = dtable
        gvPDCHistorySubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlPDCHistorySubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlPDCHistorySubmitted').modal('show');")
        'display Data

    End Sub

    'Protected Sub btnViewPDCApproved_Click(ByVal sender As Object, e As EventArgs)

    '    'get selected data
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("     [A].PDCCode ")
    '    Query.Append("    ,[A].AcctNo ")
    '    Query.Append("    ,[C].Fullname ")
    '    Query.Append("    ,[A].CheckDate ")
    '    Query.Append("    ,[A].CheckNo ")
    '    Query.Append("    ,[A].Amount ")
    '    Query.Append("    ,[A].Bank ")
    '    Query.Append("    ,[A].Remarks ")
    '    Query.Append("    ,[A].CreatedDate ")
    '    Query.Append("    ,[A].Status ")
    '    Query.Append("    ,isnull([B].Fullname,'') ")
    '    Query.Append("    ,[A].ApprovedDate ")
    '    Query.Append("    ,[A].ApprovedRemarks ")
    '    Query.Append("from ")
    '    Query.Append("	bp_PDC [A] ")
    '    Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
    '    Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("   PDCCode = '" & hfID.Value & "' ")
    '    'get selected data

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                lbl02PDCTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
    '                lbl02AcctNo.Text = DR.GetString(1)
    '                lbl02Name.Text = DR.GetString(2)
    '                lbl02CheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
    '                lbl02CheckNo.Text = DR.GetString(4)
    '                lbl02Amount.Text = DR.GetDecimal(5).ToString("N2")
    '                lbl02Bank.Text = DR.GetString(6)
    '                lbl02Remarks.Text = DR.GetString(7)
    '                lbl02DateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
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
    '    mdl02ApprovedPDC.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl02ApprovedPDC').modal('show');</script>", False)
    '    'display data

    'End Sub



    'Private Sub gv02PDCApproved_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv02PDCApproved.RowCommand

    '    'get selected data
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("     [A].PDCCode ")
    '    Query.Append("    ,[A].AcctNo ")
    '    Query.Append("    ,[C].Fullname ")
    '    Query.Append("    ,[A].CheckDate ")
    '    Query.Append("    ,[A].CheckNo ")
    '    Query.Append("    ,[A].Amount ")
    '    Query.Append("    ,[A].Bank ")
    '    Query.Append("    ,[A].Remarks ")
    '    Query.Append("    ,[A].CreatedDate ")
    '    Query.Append("    ,isnull([A].FilePath,'') [FilePath] ")
    '    Query.Append("    ,[A].Status ")
    '    Query.Append("    ,isnull([B].Fullname,'') ")
    '    Query.Append("    ,[A].ApprovedDate ")
    '    Query.Append("    ,[A].ApprovedRemarks ")
    '    Query.Append("from ")
    '    Query.Append("	bp_PDC [A] ")
    '    Query.Append("	left join employee [B] on [A].ApprovedBy = [B].emp_no ")
    '    Query.Append("	left join bp_user [C] on [A].AcctNo = [C].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("   PDCCode = '" & e.CommandArgument & "' ")
    '    'get selected data

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                lbl02PDCTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
    '                lbl02AcctNo.Text = DR.GetString(1)
    '                lbl02Name.Text = DR.GetString(2)
    '                lbl02CheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
    '                lbl02CheckNo.Text = DR.GetString(4)
    '                lbl02Amount.Text = DR.GetDecimal(5).ToString("N2")
    '                lbl02Bank.Text = DR.GetString(6)
    '                lbl02Remarks.Text = DR.GetString(7)
    '                lbl02DateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
    '                img02Attachment.ImageUrl = IIf(DR.GetString(9) = "", "Assets/media/custom/default.png", DR.GetString(9))
    '                lbl02Status.Text = DR.GetString(10)
    '                lbl02ApprovedBy.Text = DR.GetString(11)
    '                lbl02ApprovedDate.Text = Format(DR.GetDateTime(12), "MM/dd/yyyy")
    '                lbl02ApproverRemarks.Text = DR.GetString(13)

    '            End While
    '            DR.Close()
    '            ConStr.Close()

    '        End Using
    '    End Using
    '    'read record

    '    'display data
    '    mdl02ApprovedPDC.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl02ApprovedPDC').modal('show');</script>", False)
    '    'display data

    'End Sub

#End Region

#Region "Modal Pending"

    Function bindHistoryTimeline()

        'get
        Dim Query As New StringBuilder

        Dim PDCCode As String = IIf(lblPDCPendingSubmittedDtlCode.Text = "", lblPDCHistorySubmittedDtlCode.Text, lblPDCPendingSubmittedDtlCode.Text)

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
                        svg = "<path d='M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z' fill='#279852' fill-rule='nonzero' transform='translate(12.000000, 10.707409) rotate(-135.000000) translate(-12.000000, -10.707409) '/>"
                    ElseIf DR("Type") = "Verified PDC:" Then
                        svg = "<path d='M16.7689447,7.81768175 C17.1457787,7.41393107 17.7785676,7.39211077 18.1823183,7.76894473 C18.5860689,8.1457787 18.6078892,8.77856757 18.2310553,9.18231825 L11.2310553,16.6823183 C10.8654446,17.0740439 10.2560456,17.107974 9.84920863,16.7592566 L6.34920863,13.7592566 C5.92988278,13.3998345 5.88132125,12.7685345 6.2407434,12.3492086 C6.60016555,11.9298828 7.23146553,11.8813212 7.65079137,12.2407434 L10.4229928,14.616916 L16.7689447,7.81768175 Z' fill='#279852' fill-rule='nonzero'/>"
                    ElseIf DR("Type") = "Re-Verify PDC:" Then
                        svg = "<path d='M8.43296491,7.17429118 L9.40782327,7.85689436 C9.49616631,7.91875282 9.56214077,8.00751728 9.5959027,8.10994332 C9.68235021,8.37220548 9.53982427,8.65489052 9.27756211,8.74133803 L5.89079566,9.85769242 C5.84469033,9.87288977 5.79661753,9.8812917 5.74809064,9.88263369 C5.4720538,9.8902674 5.24209339,9.67268366 5.23445968,9.39664682 L5.13610134,5.83998177 C5.13313425,5.73269078 5.16477113,5.62729274 5.22633424,5.53937151 C5.384723,5.31316892 5.69649589,5.25819495 5.92269848,5.4165837 L6.72910242,5.98123382 C8.16546398,4.72182424 10.0239806,4 12,4 C16.418278,4 20,7.581722 20,12 C20,16.418278 16.418278,20 12,20 C7.581722,20 4,16.418278 4,12 L6,12 C6,15.3137085 8.6862915,18 12,18 C15.3137085,18 18,15.3137085 18,12 C18,8.6862915 15.3137085,6 12,6 C10.6885336,6 9.44767246,6.42282109 8.43296491,7.17429118 Z' fill='#279852' fill-rule='nonzero'/>"
                    ElseIf DR("Type") = "Approved PDC:" Then
                        svg = "<path d='M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z M10.875,15.75 C11.1145833,15.75 11.3541667,15.6541667 11.5458333,15.4625 L15.3791667,11.6291667 C15.7625,11.2458333 15.7625,10.6708333 15.3791667,10.2875 C14.9958333,9.90416667 14.4208333,9.90416667 14.0375,10.2875 L10.875,13.45 L9.62916667,12.2041667 C9.29375,11.8208333 8.67083333,11.8208333 8.2875,12.2041667 C7.90416667,12.5875 7.90416667,13.1625 8.2875,13.5458333 L10.2041667,15.4625 C10.3958333,15.6541667 10.6354167,15.75 10.875,15.75 Z' fill='#279852' fill-rule='nonzero' opacity='0.3'/> <path d='M10.875,15.75 C10.6354167,15.75 10.3958333,15.6541667 10.2041667,15.4625 L8.2875,13.5458333 C7.90416667,13.1625 7.90416667,12.5875 8.2875,12.2041667 C8.67083333,11.8208333 9.29375,11.8208333 9.62916667,12.2041667 L10.875,13.45 L14.0375,10.2875 C14.4208333,9.90416667 14.9958333,9.90416667 15.3791667,10.2875 C15.7625,10.6708333 15.7625,11.2458333 15.3791667,11.6291667 L11.5458333,15.4625 C11.3541667,15.6541667 11.1145833,15.75 10.875,15.75 Z' fill='#279852'/>"
                    ElseIf DR("Type") = "Declined PDC:" Then
                        svg = "<path d='M5.85714286,2 L13.7364114,2 C14.0910962,2 14.4343066,2.12568431 14.7051108,2.35473959 L19.4686994,6.3839416 C19.8056532,6.66894833 20,7.08787823 20,7.52920201 L20,20.0833333 C20,21.8738751 19.9795521,22 18.1428571,22 L5.85714286,22 C4.02044787,22 4,21.8738751 4,20.0833333 L4,3.91666667 C4,2.12612489 4.02044787,2 5.85714286,2 Z' fill='#279852' fill-rule='nonzero' opacity='0.3'/> <path d='M10.5857864,13 L9.17157288,11.5857864 C8.78104858,11.1952621 8.78104858,10.5620972 9.17157288,10.1715729 C9.56209717,9.78104858 10.1952621,9.78104858 10.5857864,10.1715729 L12,11.5857864 L13.4142136,10.1715729 C13.8047379,9.78104858 14.4379028,9.78104858 14.8284271,10.1715729 C15.2189514,10.5620972 15.2189514,11.1952621 14.8284271,11.5857864 L13.4142136,13 L14.8284271,14.4142136 C15.2189514,14.8047379 15.2189514,15.4379028 14.8284271,15.8284271 C14.4379028,16.2189514 13.8047379,16.2189514 13.4142136,15.8284271 L12,14.4142136 L10.5857864,15.8284271 C10.1952621,16.2189514 9.56209717,16.2189514 9.17157288,15.8284271 C8.78104858,15.4379028 8.78104858,14.8047379 9.17157288,14.4142136 L10.5857864,13 Z' fill='#279852'/>"
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
        divPDCPendingSubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        divPDCHistorySubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        'display data

    End Function

#Region "Modal Batch Change Status"

    Protected Sub lbtnINQBatchChangeStatusClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCBatchChangeStatusClose.Click

        ddlPDCBatchChangeStatusStatus.SelectedValue = ""
        tbxPDCBatchChangeStatusRemarks.Text = ""

        mdlPDCPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlPDCBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnPDCBatchChangeStatusCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCBatchChangeStatusCancel.Click

        ddlPDCBatchChangeStatusStatus.SelectedValue = ""
        tbxPDCBatchChangeStatusRemarks.Text = ""

        mdlPDCPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlPDCBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCPendingSubmitted').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnPDCBatchChangeStatusSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCBatchChangeStatusSave.Click

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        ' Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gvPDCPendingSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvPDCPendingSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gvPDCPendingSubmitted.Rows(RowIdx).FindControl("lblID"), Label)

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
            BatchChangeStatusSave(IDSrs)
        End If

    End Sub

#End Region

#Region "Re-Verify"
    Protected Sub lbtn01ReVerifyPDC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01ReVerifyPDC.Click

        CallJS("Swal.fire({ title: 'Do you want to re-verify PDC?', showDenyButton: false, showCancelButton: true, confirmButtonText: 'Save', confirmButtonColor: '#279852', cancelButtonColor: '#cbd4d9' }).then((result) => { if (result.isConfirmed) { var clickButton = document.getElementById('" & btnPDCPendingSubmittedReVerify.ClientID & "'); clickButton.click(); } else if (result.dismiss === Swal.DismissReason.cancel) { $('.checkBoxClass').prop('checked', false); } }); ")

    End Sub

    Protected Sub btnPDCPendingSubmittedReVerify_Click(ByVal sender As Object, e As EventArgs)

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        ' Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gvPDCPendingSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvPDCPendingSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gvPDCPendingSubmitted.Rows(RowIdx).FindControl("lblID"), Label)

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
            ReVerifyPDC(IDSrs)
        End If

    End Sub

    Function ReVerifyPDC(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprPDCReVerify"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", "")
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
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

        ''send email
        'SendEmailNotification()
        ''send email

        'hide modal
        CallJS("$('#ContentPlaceHolder1_mdlPDCPendingSubmitted').modal('hide');")
        'hide modal

        'display record
        bindPDCPendingList()
        bindPDCTotalPending()
        'display record

    End Function

#End Region

    Function BatchChangeStatusSave(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprPDCChangeStatus"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", "")
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pStatus", ddlPDCBatchChangeStatusStatus.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxPDCBatchChangeStatusRemarks.Text)
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
        ddlPDCBatchChangeStatusStatus.SelectedValue = ""
        tbxPDCBatchChangeStatusRemarks.Text = ""
        'clear fields

        CallJS("$('#mdlPDCBatchChangeStatus').modal('hide');")

        'display record
        bindPDCHistoryList()
        bindPDCTotalHistory()
        bindPDCPendingList()
        bindPDCTotalPending()
        'display record

    End Function

    Protected Sub lbtnPDCPendingSubmittedDtlCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCPendingSubmittedDtlCancel.Click

        pnlPDCPendingSubmittedDtlDetail.Visible = True
        pnlPDCPendingSubmittedDtlEdit.Visible = False
        lbtnPDCPendingSubmittedDtlReVerify.Visible = True
        lblPDCPendingSubmittedDtlCode.Text = ""
        tbxPDCPendingSubmittedDtlCheckDate.Value = ""
        tbxPDCPendingSubmittedDtlCheckNo.Value = ""
        tbxPDCPendingSubmittedDtlAmount.Value = "0.00"
        tbxPDCPendingSubmittedDtlBank.Value = ""

        CallJS("$('#ContentPlaceHolder1_mdlPDCPendingSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCPendingSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCPendingSubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnPDCPendingSubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCPendingSubmittedDtlClose.Click

        pnlPDCPendingSubmittedDtlDetail.Visible = True
        pnlPDCPendingSubmittedDtlEdit.Visible = False
        lbtnPDCPendingSubmittedDtlReVerify.Visible = True
        lblPDCPendingSubmittedDtlCode.Text = ""
        tbxPDCPendingSubmittedDtlCheckDate.Value = ""
        tbxPDCPendingSubmittedDtlCheckNo.Value = ""
        tbxPDCPendingSubmittedDtlAmount.Value = "0.00"
        tbxPDCPendingSubmittedDtlBank.Value = ""

        CallJS("$('#ContentPlaceHolder1_mdlPDCPendingSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCPendingSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCPendingSubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnPDCHistorySubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCHistorySubmittedDtlClose.Click


        mdlPDCHistorySubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlPDCHistorySubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCHistorySubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCHistorySubmitted').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnPDCPendingSubmittedDtlReVerify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCPendingSubmittedDtlReVerify.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        CallJS("Swal.fire({ title: 'Do you want to re-verify this record?', showDenyButton: false, showCancelButton: true, confirmButtonText: 'Save', confirmButtonColor: '#279852', cancelButtonColor: '#cbd4d9'}).then((result) => { if (result.isConfirmed) { var clickButton = document.getElementById('" & btnPDCPendingSubmittedDtlReVerify.ClientID & "'); clickButton.click(); } });")

        Exit Sub

    End Sub

    Protected Sub btnPDCPendingSubmittedDtlReVerify_Click(ByVal sender As Object, e As EventArgs)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprPDCReVerify"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", lblPDCPendingSubmittedDtlCode.Text)
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
        lblPDCPendingSubmittedDtlTitle.Text = ""
        lblPDCPendingSubmittedDtlAcctNo.Text = ""
        lblPDCPendingSubmittedDtlCheckDate.Text = ""
        lblPDCPendingSubmittedDtlCheckNo.Text = ""
        lblPDCPendingSubmittedDtlAmount.Text = ""
        lblPDCPendingSubmittedDtlBank.Text = ""
        lblPDCPendingSubmittedDtlDateSubmitted.Text = ""
        lblPDCPendingSubmittedDtlRemarks.Text = ""
        'clear fields

        'hide modal
        CallJS("$('#ContentPlaceHolder1_mdl01PDCPending').modal('hide');")

        'display record
        bindPDCHistoryList()
        bindPDCPendingList()
        bindPDCTotalHistory()
        bindPDCTotalPending()
        'display record

    End Sub


    'Protected Sub lbtn01VerifiedPDC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01VerifiedPDC.Click

    '    Dim IDSrs As String = String.Empty
    '    Dim RowIdx As Integer = 0

    '    ' Loop through the GridView rows and check the checkbox
    '    Do Until RowIdx = gv01PDCList.Rows.Count
    '        Dim RowCheckbox As HtmlInputCheckBox = CType(gv01PDCList.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
    '        Dim lblID As Label = CType(gv01PDCList.Rows(RowIdx).FindControl("lblID"), Label)

    '        ' If checkbox is checked, add the ID to the string
    '        If RowCheckbox.Checked = True Then
    '            IDSrs &= lblID.Text & "," ' Collect IDs, separated by commas
    '        End If

    '        RowIdx += 1
    '    Loop

    '    ' Remove the last comma
    '    If IDSrs.Length > 0 Then
    '        IDSrs = IDSrs.TrimEnd(","c)

    '        ' Call the method to delete the records using the stored procedure
    '        VerifiedPDC(IDSrs)
    '    End If

    'End Sub

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

        CallJS("$('#ContentPlaceHolder1_mdl01PDCList').modal('hide');")

        'display record
        bindPDCTotalPending()
        bindPDCPendingList()
        bindPDCTotalHistory()
        bindPDCHistoryList()
        'display record

    End Function

    Protected Sub btnViewPDCPendingSubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

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

                    lblPDCPendingSubmittedDtlCode.Text = hfID.Value
                    lblPDCPendingSubmittedDtlTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
                    lblPDCPendingSubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblPDCPendingSubmittedDtlName.Text = DR.GetString(2)
                    lblPDCPendingSubmittedDtlCheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lblPDCPendingSubmittedDtlCheckNo.Text = DR.GetString(4)
                    lblPDCPendingSubmittedDtlAmount.Text = DR.GetDecimal(5).ToString("N2")
                    lblPDCPendingSubmittedDtlBank.Text = DR.GetString(6)
                    lblPDCPendingSubmittedDtlRemarks.Text = DR.GetString(7)
                    lblPDCPendingSubmittedDtlDateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
                    lblPDCPendingSubmittedDtlEmail.Text = DR.GetString(9)

                    pnlPDCPendingSubmittedDtlDetail.Visible = True

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlPDCPendingSubmittedDtl.Update()
        RenderDatatable()
        bindHistoryTimeline()
        CallJS("$('#ContentPlaceHolder1_mdlPDCPendingSubmitted').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlPDCPendingSubmitted').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlPDCPendingSubmittedDtl').modal('show'); }, 250);")
        'display data

    End Sub

    Protected Sub btnViewPDCPendingSubmitted_Click(ByVal sender As Object, e As EventArgs)

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
        Query.Append("	 ,[A].Status ")
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
        dtable.Columns.Add(New DataColumn("CheckDate"))
        dtable.Columns.Add(New DataColumn("CheckNo"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("ViewPDCPendingSubmittedDtl"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim CheckDate As String = DR("CheckDate")
                    Dim CheckNo As String = DR("CheckNo")
                    Dim Status As String = DR("Status")
                    Dim Title As String = DR("Title")
                    Dim Code As String = DR("PDCCode")
                    Dim ViewPDCPendingSubmittedDtl As String = "ViewPDCPendingSubmittedDtl('" & DR("PDCCode") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {CheckDate, CheckNo, Status, Code, ViewPDCPendingSubmittedDtl}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lblPDCPendingSubmittedTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvPDCPendingSubmitted.DataSource = dtable
        gvPDCPendingSubmitted.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdlPDCPendingSubmitted.Update()
        CallJS("$('#ContentPlaceHolder1_mdlPDCPendingSubmitted').modal('show');")
        'display Data

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
        If gvPDCPendingList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCPendingList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCPendingList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCPendingList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvPDCHistoryList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCHistoryList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCHistoryList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCHistoryList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        If gvPDCPendingSubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCPendingSubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCPendingSubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCPendingSubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gvPDCHistorySubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPDCHistorySubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPDCHistorySubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPDCHistorySubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindPDCTotalHistory()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	 count([A].PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Approved' or [A].Status = 'Declined') ")
        Query.Append("   and [A].CSVerified is not null ")
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
        upnlPDCTotal.Update()
        'display data

    End Function

    Function bindPDCTotalPending()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	 count([A].AcctNo) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Pending') ")
        Query.Append("   and [A].CSVerified is not null ")
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
        upnlPDCTotal.Update()
        'display data

    End Function

    Function bindPDCHistoryList()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Approved' or [A].Status = 'Declined') ")
        Query.Append("   and [A].CSVerified is not null ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("ViewPDCHistorySubmitted"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim ViewPDCHistorySubmitted As String = "ViewPDCHistorySubmitted('" & DR("AcctNo") & "')"
                    Dim AcctNo As String = DR("AcctNo")
                    Dim Name As String = DR("Fullname")

                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Name, ViewPDCHistorySubmitted}
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
        gvPDCHistoryList.DataSource = dtable
        gvPDCHistoryList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlPDCHistoryList.Update()
        'display data

    End Function

    Function bindPDCPendingList()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("	 ,(select count(PDCCode) from bp_pdc left join bp_user on bp_pdc.AcctNo = bp_user.AcctNo where bp_pdc.Status = 'Pending' and bp_pdc.AcctNo = [A].AcctNo) [TotalSubmitted] ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Pending' ")
        Query.Append("   and [A].CSVerified is not null ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("TotalSubmitted"))
        dtable.Columns.Add(New DataColumn("ViewPDCPendingSubmitted"))
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
                    Dim ViewPDCPendingSubmitted As String = "ViewPDCPendingSubmitted('" & DR("AcctNo") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Name, TotalSubmitted, ViewPDCPendingSubmitted}
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
        gvPDCPendingList.DataSource = dtable
        gvPDCPendingList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlPDCPendingList.Update()
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