Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class SubmittedPDC
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
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
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
            bind03TotalDeclined()
            bind02TotalApproved()
            bind01TotalPending()
            bind03PDCDeclined()
            bind02PDCApproved()
            bind01PDCPending()

            'If CIIS_Department = "Finance" Then
            '    div01CSStatus.Visible = False
            '    divCSButton.Visible = False
            '    div01FINStatus.Visible = True
            '    divFINButton.Visible = True
            'Else
            '    div01CSStatus.Visible = False
            '    divCSButton.Visible = False
            '    div01FINStatus.Visible = False
            '    divFINButton.Visible = False
            'End If

        End If

    End Sub

#End Region

#Region "Modal Declined"

    Protected Sub btnViewPDCDeclined_Click(ByVal sender As Object, e As EventArgs)

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
        Query.Append("    ,isnull([B].Fullname,'') [Name] ")
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

                    lbl03PDCTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
                    lbl03AcctNo.Text = DR.GetString(1)
                    lbl03Name.Text = DR.GetString(2)
                    lbl03CheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lbl03CheckNo.Text = DR.GetString(4)
                    lbl03Amount.Text = DR.GetDecimal(5).ToString("N2")
                    lbl03Bank.Text = DR.GetString(6)
                    lbl03Remarks.Text = DR.GetString(7)
                    lbl03DateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
                    lbl03Status.Text = DR.GetString(9)
                    lbl03ApprovedBy.Text = DR.GetString(10)
                    lbl03ApprovedDate.Text = Format(DR.GetDateTime(11), "MM/dd/yyyy")
                    lbl03ApproverRemarks.Text = DR.GetString(12)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdl03DeclinedPDC.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl03DeclinedPDC').modal('show');</script>", False)
        'display data

    End Sub

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

#Region "Modal Approved"

    Protected Sub btnViewPDCApproved_Click(ByVal sender As Object, e As EventArgs)

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

                    lbl02PDCTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
                    lbl02AcctNo.Text = DR.GetString(1)
                    lbl02Name.Text = DR.GetString(2)
                    lbl02CheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lbl02CheckNo.Text = DR.GetString(4)
                    lbl02Amount.Text = DR.GetDecimal(5).ToString("N2")
                    lbl02Bank.Text = DR.GetString(6)
                    lbl02Remarks.Text = DR.GetString(7)
                    lbl02DateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
                    lbl02Status.Text = DR.GetString(9)
                    lbl02ApprovedBy.Text = DR.GetString(10)
                    lbl02ApprovedDate.Text = Format(DR.GetDateTime(11), "MM/dd/yyyy")
                    lbl02ApproverRemarks.Text = DR.GetString(12)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdl02ApprovedPDC.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl02ApprovedPDC').modal('show');</script>", False)
        'display data

    End Sub



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

    Function bindHistory()

        'get
        Dim Query As New StringBuilder
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
        Query.Append("   [A].TblCode = '" & lbl01PDCCode.Text & "' ")
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
        divTimeline.InnerHtml = innerHTML.ToString()
        'display data

    End Function

    Protected Sub lbtn01SavePDC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01SavePDC.Click

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprUpdatePDC"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", lbl01PDCCode.Text)
        SqlCmd.Parameters.AddWithValue("@pCheckDate", tbx01CheckDate.Value)
        SqlCmd.Parameters.AddWithValue("@pCheckNo", tbx01CheckNo.Value)
        SqlCmd.Parameters.AddWithValue("@pAmount", CDec(tbx01Amount.Value))
        SqlCmd.Parameters.AddWithValue("@pBank", tbx01Bank.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'success alert
        Alert("success", "Record successfully", "")
        'success alert

        'clear fields
        lbl01PDCCode.Text = ""
        tbx01CheckDate.Value = ""
        tbx01CheckNo.Value = ""
        tbx01Amount.Value = "0.00"
        tbx01Bank.Value = ""
        'clear fields

        'hide modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01PDCPending').modal('hide');</script>", False)
        'hide modal


        'display record
        bind01PDCPending()
        bind01TotalPending()
        'display record

        Exit Sub

    End Sub

    Protected Sub lbtn01CancelPDC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01CancelPDC.Click

        lbtn01CancelPDC.Visible = False
        pnl01Dtl.Visible = True
        pnl01Edit.Visible = False
        lbtn01EditPDC.Visible = True
        lbtn01SavePDC.Visible = False
        lbl01PDCCode.Text = ""
        tbx01CheckDate.Value = ""
        tbx01CheckNo.Value = ""
        tbx01Amount.Value = "0.00"
        tbx01Bank.Value = ""

    End Sub

    Protected Sub lbtn01EditPDC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01EditPDC.Click

        lbtn01CancelPDC.Visible = True
        pnl01Edit.Visible = True
        pnl01Dtl.Visible = False
        lbtn01EditPDC.Visible = False
        lbtn01SavePDC.Visible = True

        bindHistory()

        mdl01PDCPending.Update()

    End Sub

    Protected Sub lbtn01CSSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01CSSubmit.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg, "")
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
        SqlCmd.CommandText = "BP_UpdPDCVerified"
        SqlCmd.Parameters.AddWithValue("@pPDCCode", lbl01PDCCode.Text)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01CSRemarks.Text)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'success alert
        Alert("success", "Record successfully", "")
        'success alert

        'send email
        'SendEmailNotification()
        'send email

        'clear fields
        lbl01PDCTitle.Text = ""
        lbl01AcctNo.Text = ""
        lbl01CheckDate.Text = ""
        lbl01CheckNo.Text = ""
        lbl01Amount.Text = ""
        lbl01Bank.Text = ""
        lbl01DateSubmitted.Text = ""
        lbl01Remarks.Text = ""
        tbx01CSRemarks.Text = ""
        'clear fields

        'hide modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01PDCPending').modal('hide');</script>", False)
        'hide modal

        'display record
        bind03PDCDeclined()
        bind03TotalDeclined()
        bind02PDCApproved()
        bind02TotalApproved()
        bind01PDCPending()
        bind01TotalPending()
        'display record

        Exit Sub

    End Sub

    Protected Sub blbtn01FINSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01FINSubmit.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg, "")
            Exit Sub
        End If
        'validate access

        If ddl01FINStatus.SelectedValue = "" Or tbx01FINRemarks.Text = "" Then

            'alert
            Alert("error", "Please provide data in all fields.", "")
            'alert

        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "BP_ApprPDC"
            SqlCmd.Parameters.AddWithValue("@pPDCCode", lbl01PDCCode.Text)
            SqlCmd.Parameters.AddWithValue("@pStatus", ddl01FINStatus.Text)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01FINRemarks.Text)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'alert
            Alert("success", "Record saved successfully.", "")
            'alert

            'send email
            'SendEmailNotification()
            'send email

            'clear fields
            lbl01PDCTitle.Text = ""
            lbl01AcctNo.Text = ""
            lbl01CheckDate.Text = ""
            lbl01CheckNo.Text = ""
            lbl01Amount.Text = ""
            lbl01Bank.Text = ""
            lbl01DateSubmitted.Text = ""
            lbl01Remarks.Text = ""
            ddl01FINStatus.SelectedValue = ""
            tbx01FINRemarks.Text = ""
            'clear fields

            'hide modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01PDCPending').modal('hide');</script>", False)
            'hide modal

            'display record
            bind03PDCDeclined()
            bind03TotalDeclined()
            bind02PDCApproved()
            bind02TotalApproved()
            bind01PDCPending()
            bind01TotalPending()
            'display record

            Exit Sub

        End If

    End Sub


    'Private Sub gv01PDCPending_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv01PDCPending.RowCommand

    '    'create variable
    '    Dim Msg As String = Validate("PDCAccess", "Save", "")
    '    'create variable

    '    'validate access
    '    If Msg <> "" Then
    '        Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
    '        Exit Sub
    '    End If
    '    'validate access

    '    'get
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("	  [A].PDCCode ")
    '    Query.Append("	 ,[A].CheckDate ")
    '    Query.Append("	 ,[A].CheckNo ")
    '    Query.Append("	 ,[A].Status ")
    '    Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
    '    Query.Append("from ")
    '    Query.Append("	 bp_pdc [A] ")
    '    Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("    [A].Status = 'Pending' ")
    '    Query.Append("    and [A].AcctNo = '" & e.CommandArgument & "' ")
    '    Query.Append("order by ")
    '    Query.Append("   [A].CheckDate ")
    '    'get

    '    'Create datatable and columns
    '    Dim dtable As New DataTable
    '    dtable.Columns.Add(New DataColumn("PDCCode"))
    '    dtable.Columns.Add(New DataColumn("CheckDate"))
    '    dtable.Columns.Add(New DataColumn("CheckNo"))
    '    dtable.Columns.Add(New DataColumn("Status"))
    '    'Create datatable and columns

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                'add new row
    '                Dim NewRowValues As Object() = {DR.GetString(0), Format(DR.GetDateTime(1), "MM/dd/yyyy"), DR.GetString(2), DR.GetString(3)}
    '                Dim NewRow As DataRow
    '                NewRow = dtable.Rows.Add(NewRowValues)
    '                'add new row

    '                lbl01PDCListTitle.Text = DR.GetString(4)

    '            End While
    '            DR.Close()
    '            ConStr.Close()

    '        End Using
    '    End Using
    '    'read record

    '    'bind datatable 
    '    gv01PDCList.DataSource = dtable
    '    gv01PDCList.DataBind()
    '    'bind datatable 

    '    'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
    '    If gv01PDCList.Rows.Count > 0 Then
    '        'Adds THEAD and TBODY Section.
    '        gv01PDCList.HeaderRow.TableSection = TableRowSection.TableHeader
    '        'Adds THEAD and TBODY Section.

    '        'Adds TH element in Header Row.  
    '        gv01PDCList.UseAccessibleHeader = True
    '        'Adds TH element in Header Row.  

    '        'Adds TFOOT section. 
    '        gv01PDCList.FooterRow.TableSection = TableRowSection.TableFooter
    '        'Adds TFOOT section. 
    '    End If
    '    'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    '    'display data
    '    mdl01PDCList.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01PDCList').modal('show');</script>", False)
    '    'display data

    'End Sub

    'Private Sub gv01PDCList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv01PDCList.RowCommand

    '    'get selected data
    '    Dim Query As New StringBuilder

    '    Query.Append("select ")
    '    Query.Append("     [A].PDCCode ")
    '    Query.Append("    ,[A].AcctNo ")
    '    Query.Append("    ,[B].Fullname ")
    '    Query.Append("    ,[A].CheckDate ")
    '    Query.Append("    ,[A].CheckNo ")
    '    Query.Append("    ,[A].Amount ")
    '    Query.Append("    ,[A].Bank ")
    '    Query.Append("    ,[A].Remarks ")
    '    Query.Append("    ,[A].CreatedDate ")
    '    Query.Append("    ,[B].Email ")
    '    Query.Append("from ")
    '    Query.Append("	bp_pdc [A] ")
    '    Query.Append("	left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
    '    Query.Append("where ")
    '    Query.Append("   [A].PDCCode = '" & e.CommandArgument & "' ")
    '    'get selected data

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                lbl01PDCCode.Text = e.CommandArgument
    '                lbl01PDCTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
    '                lbl01AcctNo.Text = DR.GetString(1)
    '                lbl01Name.Text = DR.GetString(2)
    '                lbl01CheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
    '                lbl01CheckNo.Text = DR.GetString(4)
    '                lbl01Amount.Text = DR.GetDecimal(5).ToString("N2")
    '                lbl01Bank.Text = DR.GetString(6)
    '                lbl01Remarks.Text = DR.GetString(7)
    '                lbl01DateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
    '                lbl01Email.Text = DR.GetString(9)

    '                pnl01Dtl.Visible = True

    '            End While
    '            DR.Close()
    '            ConStr.Close()

    '        End Using
    '    End Using
    '    'read record

    '    'display data
    '    mdl01PDCPending.Update()
    '    RenderDatatable()
    '    bind01CSVerified()
    '    bindHistory()
    '    'ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('[data-bs-dismiss=modal]').trigger({ type: 'click' });</script>", False)
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01PDCList').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdl01PDCList').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdl01PDCPending').modal('show'); }, 250);</script>", False)
    '    'display data

    'End Sub

    Protected Sub btnViewPDCPending_Click(ByVal sender As Object, e As EventArgs)

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

                    lbl01PDCCode.Text = hfID.Value
                    lbl01PDCTitle.Text = DR.GetString(1) & " - " & DR.GetString(2) & " - PDC"
                    lbl01AcctNo.Text = DR.GetString(1)
                    lbl01Name.Text = DR.GetString(2)
                    lbl01CheckDate.Text = Format(DR.GetDateTime(3), "MM/dd/yyyy")
                    lbl01CheckNo.Text = DR.GetString(4)
                    lbl01Amount.Text = DR.GetDecimal(5).ToString("N2")
                    lbl01Bank.Text = DR.GetString(6)
                    lbl01Remarks.Text = DR.GetString(7)
                    lbl01DateSubmitted.Text = Format(DR.GetDateTime(8), "MM/dd/yyyy")
                    lbl01Email.Text = DR.GetString(9)

                    pnl01Dtl.Visible = True

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdl01PDCPending.Update()
        RenderDatatable()
        bind01CSVerified()
        bindHistory()
        'ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('[data-bs-dismiss=modal]').trigger({ type: 'click' });</script>", False)
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01PDCList').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdl01PDCList').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdl01PDCPending').modal('show'); }, 250);</script>", False)
        'display data

    End Sub

    Protected Sub btnViewPDCList_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("PDCAccess", "Save", "")
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
        Query.Append("	  [A].PDCCode ")
        Query.Append("	 , [A].CheckDate ")
        Query.Append("	 , [A].CheckNo ")
        Query.Append("	 , [A].Status ")
        Query.Append("	 , ([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        Query.Append("from ")
        Query.Append("	 bp_pdc [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("    [A].Status = 'Pending' ")
        Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("order by ")
        Query.Append("   [A].CheckDate ")
        'get

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewPDCPending"))
        dtable.Columns.Add(New DataColumn("CheckDate"))
        dtable.Columns.Add(New DataColumn("CheckNo"))
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

                    Dim ViewPDCPending As String = "ViewPDCPending('" & DR("PDCCode") & "')"
                    Dim CheckDate As String = DR("CheckDate")
                    Dim CheckNo As String = DR("CheckNo")
                    Dim Status As String = DR("Status")
                    Dim Title As String = DR("Title")

                    'add new row
                    Dim NewRowValues As Object() = {ViewPDCPending, CheckDate, CheckNo, Status}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    lbl01PDCListTitle.Text = Title

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gv01PDCList.DataSource = dtable
        gv01PDCList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        mdl01PDCList.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01PDCList').modal('show');</script>", False)
        'display data

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String, AdditionalScript As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & AdditionalScript & "Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
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
        mail.To.Add(lbl01Email.Text)
        mail.Subject = "PDC " & lbl01CheckNo.Text & " has been" & ddl01FINStatus.SelectedValue

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
        Content = Content & "             <strong>Hello " & lbl01Name.Text & ", </strong>"
        Content = Content & "          </div>"
        Content = Content & "          <div style='padding-bottom: 20px'>Your submitted PDC with check no. " & lbl01CheckNo.Text & " has been " & ddl01FINStatus.SelectedValue & ".</div>"
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

    Function RenderDatatable()

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv01PDCPending.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv01PDCPending.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gv01PDCPending.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gv01PDCPending.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        If gv01PDCList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv01PDCList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gv01PDCList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gv01PDCList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bind03TotalDeclined()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   status = 'Declined' ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01DeclinedTotal.Text = DR.GetInt32(0)

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

    Function bind02TotalApproved()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
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

                    lbl01ApprovedTotal.Text = DR.GetInt32(0)

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

    Function bind01TotalPending()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
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
        upnlPDCTotal.Update()
        'display data

    End Function

    Function bind03PDCDeclined()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("	  PDCCode ")
        Query.Append("	 ,CheckDate ")
        Query.Append("	 ,CheckNo ")
        Query.Append("	 ,Bank")
        Query.Append("	 ,Amount")
        Query.Append("	 ,isnull(Remarks,'') [Remarks] ")
        Query.Append("	 ,Status ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("    Status = 'Declined' ")
        Query.Append("order by ")
        Query.Append("   ApprovedDate ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewPDCDeclined"))
        dtable.Columns.Add(New DataColumn("CheckDate"))
        dtable.Columns.Add(New DataColumn("CheckNo"))
        dtable.Columns.Add(New DataColumn("Bank"))
        dtable.Columns.Add(New DataColumn("Amount"))
        dtable.Columns.Add(New DataColumn("Remarks"))
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

                    Dim ViewPDCDeclined As String = "ViewPDCDeclined('" & DR("PDCCode") & "')"
                    Dim CheckDate As String = DR("CheckDate")
                    Dim CheckNo As String = DR("CheckNo")
                    Dim Bank As String = DR("Bank")
                    Dim Amount As String = DR("Amount")
                    Dim Remarks As String = DR("Remarks")
                    Dim Status As String = DR("Status")

                    'add new row
                    Dim NewRowValues As Object() = {ViewPDCDeclined, CheckDate, CheckNo, Bank, Amount, Remarks, Status}
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
        gv03PDCDeclined.DataSource = dtable
        gv03PDCDeclined.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv03PDCDeclined.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv03PDCDeclined.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gv03PDCDeclined.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gv03PDCDeclined.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'display data
        upnlPDCDeclined.Update()
        'display data

    End Function

    Function bind02PDCApproved()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("	  PDCCode ")
        Query.Append("	 ,CheckDate ")
        Query.Append("	 ,CheckNo ")
        Query.Append("	 ,Bank")
        Query.Append("	 ,Amount")
        Query.Append("	 ,isnull(Remarks,'') [Remarks] ")
        Query.Append("	 ,Status ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Approved' ")
        Query.Append("order by ")
        Query.Append("   ApprovedDate ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewPDCApproved"))
        dtable.Columns.Add(New DataColumn("CheckDate"))
        dtable.Columns.Add(New DataColumn("CheckNo"))
        dtable.Columns.Add(New DataColumn("Bank"))
        dtable.Columns.Add(New DataColumn("Amount"))
        dtable.Columns.Add(New DataColumn("Remarks"))
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

                    Dim ViewPDCApproved As String = "ViewPDCApproved('" & DR("PDCCode") & "')"
                    Dim CheckDate As String = DR("CheckDate")
                    Dim CheckNo As String = DR("CheckNo")
                    Dim Bank As String = DR("Bank")
                    Dim Amount As String = DR("Amount")
                    Dim Remarks As String = DR("Remarks")
                    Dim Status As String = DR("Status")

                    'add new row
                    Dim NewRowValues As Object() = {ViewPDCApproved, CheckDate, CheckNo, Bank, Amount, Remarks, Status}
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
        gv02PDCApproved.DataSource = dtable
        gv02PDCApproved.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv02PDCApproved.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv02PDCApproved.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gv02PDCApproved.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gv02PDCApproved.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'display data
        upnlPDCApproved.Update()
        'display data

    End Function

    Function bind01PDCPending()

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
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ViewPDCList"))
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

                    Dim ViewPDCList As String = "ViewPDCList('" & DR("AcctNo") & "')"
                    Dim AcctNo As String = DR("AcctNo")
                    Dim Name As String = DR("Fullname")

                    'add new row
                    Dim NewRowValues As Object() = {ViewPDCList, AcctNo, Name}
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
        gv01PDCPending.DataSource = dtable
        gv01PDCPending.DataBind()
        'bind datatable 

        'display data
        upnlPDCPending.Update()
        'display data

    End Function

    Function bind01CSVerified()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    isnull(UpdatedByCSRemarks,'') [UpdatedByCSRemarks] ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   PDCCode = '" & lbl01PDCCode.Text & "' ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If CIIS_Department = "Finance" And DR.GetString(0).ToString <> "" Then
                        div01CSStatus.Visible = False
                        divCSButton.Visible = False
                        div01FINStatus.Visible = True
                        divFINButton.Visible = True
                    ElseIf CIIS_Department = "Customer Service" Then
                        div01CSStatus.Visible = True
                        divCSButton.Visible = True
                        div01FINStatus.Visible = False
                        divFINButton.Visible = False
                    Else
                        div01CSStatus.Visible = False
                        divCSButton.Visible = False
                        div01FINStatus.Visible = False
                        divFINButton.Visible = False
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

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