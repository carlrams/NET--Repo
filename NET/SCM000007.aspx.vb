Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports CrystalDecisions.Web
Imports Microsoft.Ajax.Utilities
Imports System.Security.Policy
Imports System.ComponentModel
Imports Microsoft.AspNet.SignalR.Hubs
Imports System.Web.WebSockets
Imports CrystalDecisions.[Shared]

Public Class SCM000007
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        'user info

        'active account / menu
        'Master.setActiveMenu("APP", "SCM010100")
        'active account / menu

        'create variable
        Dim Msg As String = Validate("Access", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString()
            ltrlFormNo.Text = "SCM000007"
            'Record

            bindFiles()
            bindOverview()
            bindBilling()
            bindCondition()

            'deadline
            bindDeadline()

        End If

    End Sub
#End Region

#Region "Button"
    Private Sub lbtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSubmit.Click
        bindFiles()
    End Sub

    Private Sub lbtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnView.Click
        Dim FileName As String = hdnFile.Value
        If FileName <> "" Then
            bindViewing(FileName)
        End If
    End Sub
    Protected Sub lbtnDLAttachment(ByVal sender As Object, ByVal e As System.EventArgs)

        'get file
        Dim FolderName As String = CType(sender, LinkButton).CommandName
        Dim FilePath As String = "http://ciisv2.calmarland.com:806/Assets/Upload/Contracts/FRM000009/" & ltrlID.Text & "/" & FolderName & "/" & CType(sender, LinkButton).CommandArgument
        Dim FileName As String = CType(sender, LinkButton).CommandArgument
        'get file

        'view/download
        'CIIS_UserInfo("CIIS_File") = "~/Assets/Upload/Contracts/FRM000009/" & ltrlID.Text & "/" & FolderName & "/" & FileName
        CIIS_UserInfo("CIIS_File") = "/Assets/Upload/Contracts/FRM000009/" & ltrlID.Text & "/" & FolderName & "/" & FileName
        Response.Cookies.Add(CIIS_UserInfo)
        'ScriptManager.RegisterStartupScript(upnlOverview, upnlOverview.GetType, "OpenWindow", "window.open('SCM020200');", True)
        ScriptManager.RegisterStartupScript(upnlOverview, upnlOverview.GetType, "OpenWindow", "window.open('" & FilePath & "', '_blank');", True)
        'view/download

    End Sub

    Protected Sub lbtnDLNoticeAttachment(ByVal sender As Object, ByVal e As System.EventArgs)

        'get file
        Dim FolderName As String = CType(sender, LinkButton).CommandName
        Dim FilePath As String = "http://ciisv2.calmarland.com:806/Assets/Upload/Contracts/FRM000009/Notice/" & ltrlID.Text & "/" & CType(sender, LinkButton).CommandArgument
        Dim FileName As String = CType(sender, LinkButton).CommandArgument
        'get file

        'view/download
        ScriptManager.RegisterStartupScript(upnlOverview, upnlOverview.GetType, "OpenWindow", "window.open('" & FilePath & "', '_blank');", True)
        'view/download

    End Sub

    Private Sub lbtnViewBilling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnViewBilling.Click
        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlBillingPosted').modal('show');</script>", False)
        'modal

        'bind
        bindBillingPosted()
        'bind
    End Sub

    Private Sub lbtnPosted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnPosted.Click
        Dim Code As String = hdnCode.Value
        Dim ConDate As String = hdnDate.Value
        If Code <> "" And ConDate <> "" Then
            bindConAttachment(Code, ConDate)
        End If
    End Sub

    Protected Sub lbtnDLView(ByVal sender As Object, ByVal e As System.EventArgs)
        'get file
        Dim Code As String = CType(sender, LinkButton).CommandName
        'Dim FilePath As String = Server.MapPath("~/Assets/Upload/Contracts/FRM000009/" & ltrlID.Text & "/" & FolderName) & CType(sender, LinkButton).CommandArgument
        Dim FilePath As String = "http://ciisv2.calmarland.com:806/Assets/Upload/Contracts/Billing/" & ltrlID.Text & "/" & Code & "/" & CType(sender, LinkButton).CommandArgument
        Dim FileName As String = CType(sender, LinkButton).CommandArgument
        'get file

        'view/download
        ScriptManager.RegisterStartupScript(upnlBillingUploaded, upnlBillingUploaded.GetType, "OpenWindow", "window.open('" & FilePath & "', '_blank');", True)
        'view/download
    End Sub

    Private Sub lbtnConApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnConApproved.Click
        Dim Code As String = hdnCode.Value
        Dim SeqNo As String = hdnSeqNo.Value

        If Code <> "" And SeqNo <> "" Then
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SCM_Upd_Billing"
            SqlCmd.Parameters.AddWithValue("@pFormID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pDateRequired", "")
            SqlCmd.Parameters.AddWithValue("@pDescription", "Approved")
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", Code)
            SqlCmd.Parameters.AddWithValue("@pNote", "")
            SqlCmd.Parameters.AddWithValue("@pSeqNo", SeqNo)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({title: 'Success!',text: 'Successfully approved Billing', icon: 'success',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: 'btn btn-primary'}});$('#ContentPlaceHolder1_mdlBilling').modal('hide');</script>", False)

            'update
            upnlBillingUploaded.Update()
            'update
        Else
            Exit Sub
        End If
    End Sub
    Private Sub lbtnConDeclined_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnConDeclined.Click
        Dim Code As String = hdnCode.Value
        Dim SeqNo As String = hdnSeqNo.Value
        If Code <> "" And SeqNo <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlNote').modal('show');$('#ContentPlaceHolder1_mdlBilling').modal('hide');</script>", False)
        Else
            Exit Sub
        End If
    End Sub
    Private Sub lbtnDeclined_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnDeclined.Click
        Dim Code As String = hdnCode.Value
        Dim SeqNo As String = hdnSeqNo.Value
        If Code <> "" And SeqNo <> "" Then
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "SCM_Upd_Billing"
            SqlCmd.Parameters.AddWithValue("@pFormID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pDateRequired", "")
            SqlCmd.Parameters.AddWithValue("@pDescription", "Declined")
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", Code)
            SqlCmd.Parameters.AddWithValue("@pNote", tbxNote.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", SeqNo)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'reset
            tbxNote.Text = ""
            'reset

            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({title: 'Success!',text: 'Successfully declined Billing', icon: 'success',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: 'btn btn-primary'}});$('#ContentPlaceHolder1_mdlNote').modal('hide');</script>", False)

            'update
            upnlBillingUploaded.Update()
            'update
        Else
            Exit Sub
        End If
    End Sub
#End Region

#Region "Function"
    Function bindOverview()

        'get details
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("  [A].HWCode [Code] ")
        Query.Append("  ,[C].ProjName [Project] ")
        Query.Append("  ,[A].ConCategory [Category] ")
        Query.Append("  ,isnull([B].vendor, '-') [Contractor] ")
        Query.Append("  ,Format([A].DP, 'N2') [DP] ")
        Query.Append("  ,[A].RF [RF] ")
        Query.Append("  ,[A].ConPrice [ContractPrice] ")
        Query.Append("  ,isnull((select dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) from Form_HWTask [T] left join employee [B] on [T].AssignTo = [B].emp_no where [T].TaskCode = '006' and [T].TaskName LIKE '%Construction%' and [T].HWCode = [A].HWCode), '') [Assigned] ")
        Query.Append("  ,isnull((select vat_rate from fin_vat where v_code = [B].vat), 0.00) [vat_rate] ")
        Query.Append("  ,isnull((select ewt_rate from fin_ewt where ewt_code = [B].ewt), 0.00) [ewt_rate] ")
        Query.Append("  ,isnull([A].VAT, '-') [VAT] ")
        Query.Append("  ,isnull([A].EWT, '-') [EWT] ")
        Query.Append("  ,[A].ConNo [ContractNo] ")
        Query.Append("  ,[A].DateStart [StartDate] ")
        Query.Append("  ,(select (case when sum(CBAmount) is not null then sum(CBAmount) else 0.00 end) from Trxn_ContractBill where CRTCode = [A].HWCode and PostedDate is not null and CancelDate is null) [Subtotal] ")
        Query.Append("  ,(select isnull(sum(CBAmount), 0) from Trxn_ContractBill where CRTCode = [A].HWCode and CBType = 'Downpayment' and PostedDate is not null and CancelDate is null) [Downpayment] ")
        Query.Append("  ,[A].Type ")
        Query.Append("  ,[A].DateEnd ")
        Query.Append("  ,isnull([A].POCStatus, '-') [POCStatus] ")
        Query.Append("  ,isnull([A].ConStatus, '-') [ConStatus] ")
        Query.Append("  ,[A].BatchNo ")
        Query.Append("  ,[D].ModelName ")
        Query.Append("  ,[A].Phase ")
        Query.Append("  ,[A].Block ")
        Query.Append("  ,[A].Lot ")
        Query.Append("  ,[A].TCPBal ")
        Query.Append("  ,[A].BillAmt ")
        Query.Append("  ,(select count(1) from SCM_CON_Billing where FormID = [A].HWCode) [ConPosted]")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join ogm_vendor [B] on [A].Contractor = [B].v_code ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("  [A].HWCode = '" & ltrlID.Text & "' ")
        'get details

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblProjectAmt.Text = "₱ " & Format(DR("ContractPrice"), "N2")
                    lblProjectVAT.Text = Format(DR("vat_rate"), "N2") & "%"
                    lblProjectEWT.Text = Format(DR("ewt_rate"), "N2") & "%"
                    lblProjectRF.Text = IIf(DR("RF") = 0, DR("RF"), "₱ " & Format(DR("RF"), "N2"))
                    lblProjectDownpayment.Text = IIf(DR("DP") = 0, DR("DP"), "₱ " & DR("DP"))
                    lblProjectContractor.Text = DR("Contractor")
                    lblProjectAssigned.Text = DR("Assigned")

                    ahrefTag.Attributes("href") = "ENG010501-" & ltrlID.Text
                    divProjectCategory.InnerText = DR("Category")
                    divProject.InnerText = DR("Project")
                    divStartDate.InnerText = Format(DR("StartDate"), "MMM. d yyyy")

                    'computation
                    Dim Balance As String
                    Dim Percentage As String
                    If DR.GetDecimal(6) = DR.GetDecimal(14) Then

                        If DR.GetDecimal(6) = 0.00 Then
                            Balance = "0.00"
                            Percentage = "0.00"
                        Else
                            Balance = Format(DR.GetDecimal(6) - DR.GetDecimal(14), "N2")

                            'progress bar
                            Percentage = Math.Round(DR.GetDecimal(14) / DR.GetDecimal(6) * 100)
                        End If

                    ElseIf DR.GetDecimal(6) < DR.GetDecimal(15) Then

                        If DR.GetDecimal(15) = 0.00 And DR.GetDecimal(5) = 0.00 Then
                            Balance = Format(DR.GetDecimal(15) - DR.GetDecimal(8), "N2")

                            'progress bar
                            Percentage = Math.Round(DR.GetDecimal(15) / DR.GetDecimal(6) * 100)
                        ElseIf DR.GetDecimal(15) = 0.00 And DR.GetDecimal(5) <> 0.00 Then
                            Balance = Format((DR.GetDecimal(15) - DR.GetDecimal(6)) - DR.GetDecimal(6), "N2")

                            'progress bar
                            Percentage = Math.Round((DR.GetDecimal(15) - DR.GetDecimal(15)) / DR.GetDecimal(6) * 100)
                        ElseIf DR.GetDecimal(15) <> 0.00 And DR.GetDecimal(5) = 0.00 Then
                            Balance = Format((DR.GetDecimal(15) - DR.GetDecimal(14)) - DR.GetDecimal(8), "N2")

                            'progress bar
                            Percentage = Math.Round((DR.GetDecimal(15) - DR.GetDecimal(14)) / DR.GetDecimal(6) * 100)
                        ElseIf DR.GetDecimal(15) <> 0.00 And DR.GetDecimal(5) <> 0.00 Then
                            Balance = Format((DR.GetDecimal(15) - (DR.GetDecimal(14) + DR.GetDecimal(5))) - DR.GetDecimal(6), "N2")

                            'progress bar
                            Percentage = Math.Round((DR.GetDecimal(15) - (DR.GetDecimal(14) + DR.GetDecimal(5))) / DR.GetDecimal(6) * 100)
                        End If

                    ElseIf DR.GetDecimal(6) > DR.GetDecimal(14) Then

                        If DR.GetDecimal(14) = 0.00 And DR.GetDecimal(5) = 0.00 Then
                            Balance = Format(DR.GetDecimal(6) - DR.GetDecimal(14), "N2")

                            'progress bar
                            Percentage = Math.Round(DR.GetDecimal(14) / DR.GetDecimal(6) * 100)
                        ElseIf DR.GetDecimal(14) = 0.00 And DR.GetDecimal(5) <> 0.00 Then
                            Balance = Format(DR.GetDecimal(6) - DR.GetDecimal(14), "N2")

                            'progress bar
                            Percentage = Math.Round(DR.GetDecimal(14) / DR.GetDecimal(6) * 100)
                        ElseIf DR.GetDecimal(14) <> 0.00 And DR.GetDecimal(5) = 0.00 Then
                            Balance = Format(DR.GetDecimal(6) - DR.GetDecimal(14), "N2")

                            'progress bar
                            Percentage = Math.Round(DR.GetDecimal(14) / DR.GetDecimal(6) * 100)
                        ElseIf DR.GetDecimal(14) <> 0.00 And DR.GetDecimal(5) <> 0.00 Then
                            Balance = Format(DR.GetDecimal(6) - DR.GetDecimal(14), "N2")

                            'progress bar
                            Percentage = Math.Round(DR.GetDecimal(14) / DR.GetDecimal(6) * 100)
                        End If

                    Else
                        Balance = "0.00"
                        Percentage = "0"
                    End If

                    lblPostedCount.Text = DR("ConPosted")

                    If DR("ConPosted") = 0 Then
                        lbtnViewBilling.Visible = False
                    Else
                        lbtnViewBilling.Visible = True
                    End If

                    lblProjectBalance.Text = "₱ " & Balance
                    lblSubtotal.Text = "₱ " & Format(DR("Subtotal"), "N2")
                    lblVAT.Text = IIf(DR("VAT") = 0.00, DR("VAT"), "₱ " & Format(DR("VAT"), "N2"))
                    lblEWT.Text = IIf(DR("EWT") = 0.00, DR("EWT"), "₱ " & Format(DR("EWT"), "N2"))

                    divPercentage.InnerText = Percentage & "%"
                    divProgressBar.Attributes("aria-valuenow") = Percentage
                    divProgressBar.Style("width") = Percentage & "%"
                    togglePercent.Attributes("title") = "Billing progress: " & Percentage & "%"

                    divTotalBilled.InnerText = "₱ " & Format(DR("Subtotal"), "N2")

                    spnProjectName.InnerText = DR("Category") & ": " & DR("Project")

                    'bind
                    hdnCode.Value = DR("Code")
                    bindAttachment(DR("Code"))
                    bindNoticeAttachment()

                    'condition
                    If gvAttachment.Rows.Count = 0 Then
                        pnlNotice.Visible = True
                        gvAttachment.Visible = False
                    Else
                        pnlNotice.Visible = False
                        gvAttachment.Visible = True
                    End If
                    If gvNoticeAttachment.Rows.Count = 0 Then
                        pnlNoticeAttach.Visible = True
                        gvNoticeAttachment.Visible = False
                    Else
                        pnlNoticeAttach.Visible = False
                        gvNoticeAttachment.Visible = True
                    End If
                    'condition

                    'project 
                    lblID.Text = DR("Code")
                    lblType.Text = DR("Type")
                    lblDateStart.Text = Format(DR("StartDate"), "MMM. d yyyy")
                    lblDateEnd.Text = Format(DR("DateEnd"), "MMM. d yyyy")
                    lbl01AssignedTo.Text = DR("Assigned")
                    lblStatus.Text = DR("POCStatus")
                    lblCategory.Text = DR("Category")
                    lblBatchNo.Text = DR("BatchNo")
                    lblProject.Text = DR("Project")
                    lblProjectDetails.Text = "P" & DR("Phase") & " B" & DR("Block") & " L" & DR("Lot")
                    lblModel.Text = DR("ModelName")
                    lblConStatus.Text = DR("ConStatus")

                    lblBillAmt.Text = IIf(DR("BillAmt") = 0.00, DR("BillAmt"), "₱ " & Format(DR("BillAmt"), "N2"))
                    lblTCPBal.Text = IIf(DR("TCPBal") = 0.00, DR("TCPBal"), "₱ " & Format(DR("TCPBal"), "N2"))
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Function bindBilling()

        'get billing
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [B].PostedDate ")
        Query.Append("  ,[B].CBAmount [BilledAmt] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join Trxn_ContractBill [B] on [A].HWCode = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].HWCode = '" & ltrlID.Text & "' ")
        Query.Append("  and [B].PostedDate is not null ")
        Query.Append("  and [B].CancelDate is null ")
        'get billing

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBilledDate.Text = "" Then
                        ltrlBilledDate.Text = Format(DR.GetDateTime(0), "MMM. dd yyyy")
                        ltrlBilledAmt.Text = DR.GetDecimal(1)
                    Else
                        ltrlBilledDate.Text = ltrlBilledDate.Text & "," & Format(DR.GetDateTime(0), "MMM. dd yyyy")
                        ltrlBilledAmt.Text = ltrlBilledAmt.Text & "," & DR.GetDecimal(1)
                    End If

                End While

                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindHistory()

        'get billing history
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (CASE WHEN CHARINDEX('-', [B].CBRemarks) > 0 THEN LEFT([B].CBRemarks, CHARINDEX('-', [B].CBRemarks) - 1) ELSE [B].CBRemarks END) [Before] ")
        Query.Append("  ,(CASE WHEN CHARINDEX('-', [B].CBRemarks) > 0 THEN SUBSTRING([B].CBRemarks, CHARINDEX('-', [B].CBRemarks) + 1, LEN([B].CBRemarks) - CHARINDEX('-', [B].CBRemarks)) ELSE '' END) [After] ")
        Query.Append("  ,[B].PostedDate ")
        Query.Append("  ,[B].CBType [Type] ")
        Query.Append("  ,[B].CBRate [Rate] ")
        Query.Append("  ,Format([B].CBAmount, 'N2') [Amount] ")
        Query.Append("  ,(case when [C].ReceivedStatus = 0 then '' else 'display: none;' end) [Pending] ")
        Query.Append("  ,(case when [C].ReceivedStatus = 1 then '' else 'display: none;' end) [Received] ")
        Query.Append("  ,(case when [C].ReceivedStatus is null then '' else 'display: none;' end) [Fixed] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join Trxn_ContractBill [B] on [A].HWCode = [B].CRTCode ")
        Query.Append("  left join SCM_CON_Billed [C] on [A].HWCode = [C].FormID ")
        Query.Append("where ")
        Query.Append("  [A].HWCode = '" & ltrlID.Text & "' ")
        Query.Append("  and [B].PostedDate is not null ")
        Query.Append("  and [B].CancelDate is null ")
        'get billing history

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Before"))
        dtable.Columns.Add(New DataColumn("After"))
        dtable.Columns.Add(New DataColumn("PostedDate"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Rate"))
        dtable.Columns.Add(New DataColumn("Amount"))
        dtable.Columns.Add(New DataColumn("Pending"))
        dtable.Columns.Add(New DataColumn("Received"))
        dtable.Columns.Add(New DataColumn("Fixed"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim RemarksBefore As String = DR.GetString(0)
                    Dim RemarksAfter As String = DR.GetString(1)
                    Dim PostedDate As String = Format(DR.GetDateTime(2), "MMM. dd yyyy")
                    Dim Type As String = DR.GetString(3)
                    Dim Rate As String = DR.GetDecimal(4)
                    Dim Amount As String = DR.GetString(5)
                    Dim Pending As String = DR.GetString(6)
                    Dim Received As String = DR.GetString(7)
                    Dim Fixed As String = DR.GetString(8)
                    Dim Upd As New StringBuilder
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {RemarksBefore, RemarksAfter, PostedDate, Type, Rate, Amount, Pending, Received, Fixed}
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
        gvHistory.DataSource = dtable
        gvHistory.DataBind()
        RenderDataTable()
        'bind datatable 

        'display
        upnlOverview.Update()
        'display

    End Function

    Function bindCondition()

        'get count
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  count(1) ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join Trxn_ContractBill [B] on [A].HWCode = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].HWCode = '" & ltrlID.Text & "' ")
        Query.Append("  and [B].PostedDate is not null ")
        Query.Append("  and [B].CancelDate is null ")
        'get count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    If DR.GetInt32(0) <> 0 Then
                        pnlAlert.Visible = False
                        gvHistory.Visible = True
                        bindHistory()
                    Else
                        pnlAlert.Visible = True
                        gvHistory.Visible = False
                    End If
                End While

                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'update
        upnlOverview.Update()
        'update

    End Function

    Function bindFiles()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("FileName"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        If Directory.Exists(Server.MapPath("~/Assets/Upload/ENG010501/" & ltrlID.Text & "/")) Then

            'set folder
            Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/ENG010501/" & ltrlID.Text & "/"))
            Dim listfiles As FileInfo() = objDir.GetFiles()
            Dim DefaultFiles As FileInfo() = (From file In listfiles Order By file.CreationTime Select file).ToArray()
            'set folder

            'read file
            For Each File In DefaultFiles

                'create variable
                Dim Icon As String = "Assets/Upload/ENG010501/" & ltrlID.Text & "/" & File.Name
                'create variable

                Dim FileName As String = File.Name
                Dim Name As String
                If FileName.Length > 13 Then
                    Name = FileName.Substring(0, 13) & " ..."
                Else
                    Name = FileName
                End If

                'add file
                Dim current_RowValues As Object() = {Icon, Name, File.Name, Format(File.CreationTime, "MM/dd/yyyy hh:mm tt")}
                Dim current_dRow As DataRow
                current_dRow = dtable.Rows.Add(current_RowValues)
                dtable.AcceptChanges()
                'add file

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            dlContent.DataSource = dataView
            dlContent.DataBind()
            'RenderDataTable()
            'bind datatable

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            dlContent.DataSource = dataView
            dlContent.DataBind()
            'RenderDataTable()
            'bind datatable

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        'update
        mdlProgress.Update()
        upnlFiles.Update()
        'update

    End Function

    Function bindAttachment(Code As String)

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        'If Directory.Exists(Server.MapPath("~/Assets/Upload/FRM000009/" & ltrlID.Text & "/" & Code)) Then
        If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\FRM000009\" & ltrlID.Text & "\" & Code) Then

            'set folder
            'Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/FRM000009/" & ltrlID.Text & "/" & Code))
            Dim objDir As New DirectoryInfo("C:\inetpub\ciis.net\Assets\Upload\Contracts\FRM000009\" & ltrlID.Text & "\" & Code)
            Dim listfiles As FileInfo() = objDir.GetFiles()
            Dim DefaultFiles As FileInfo() = (From file In listfiles Order By file.CreationTime Select file).ToArray()
            'set folder

            'read file
            For Each File In DefaultFiles

                'create variable
                Dim Icon As String
                'create variable

                'set icon for specific file
                If File.Name.Contains(".png") Or File.Name.Contains(".PNG") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".jpg") Or File.Name.Contains(".jpeg") Or File.Name.Contains(".jpe") Or File.Name.Contains(".jfif") Or File.Name.Contains(".JPG") Or File.Name.Contains(".JPEG") Or File.Name.Contains(".JPE") Or File.Name.Contains(".JFIF") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".txt") Or File.Name.Contains(".TXT") Then
                    Icon = "<i class='las la-file-alt fs-2qx'></i>"
                ElseIf File.Name.Contains(".xlsx") Or File.Name.Contains(".xls") Or File.Name.Contains(".XLSX") Or File.Name.Contains(".XLS") Then
                    Icon = "<i class='las la-file-excel fs-2qx'></i>"
                ElseIf File.Name.Contains(".docx") Or File.Name.Contains(".doc") Or File.Name.Contains(".DOCX") Or File.Name.Contains(".DOC") Then
                    Icon = "<i class='las la-file-word fs-2qx'></i>"
                ElseIf File.Name.Contains(".pptx") Or File.Name.Contains(".ppt") Or File.Name.Contains(".PPTX") Or File.Name.Contains(".PPT") Then
                    Icon = "<i class='las la-file-powerpoint fs-2qx'></i>"
                ElseIf File.Name.Contains(".pdf") Or File.Name.Contains(".PDF") Then
                    Icon = "<i class='las la-file-pdf fs-2qx'></i>"
                End If
                'set icon for specific file

                'add file
                Dim current_RowValues As Object() = {Icon, File.Name, Code, Format(File.CreationTime, "MM/dd/yyyy hh:mm tt")}
                Dim current_dRow As DataRow
                current_dRow = dtable.Rows.Add(current_RowValues)
                dtable.AcceptChanges()
                'add file

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvAttachment.DataSource = dataView
            gvAttachment.DataBind()
            'bind datatable

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvAttachment.DataSource = dataView
            gvAttachment.DataBind()
            'bind datatable

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

    End Function

    Function bindNoticeAttachment()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        'If Directory.Exists(Server.MapPath("~/Assets/Upload/FRM000009/" & ltrlID.Text & "/" & Code)) Then
        If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\FRM000009\" & ltrlID.Text) Then

            'set folder
            'Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/FRM000009/" & ltrlID.Text & "/" & Code))
            Dim objDir As New DirectoryInfo("C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\FRM000009\" & ltrlID.Text)
            Dim listfiles As FileInfo() = objDir.GetFiles()
            Dim DefaultFiles As FileInfo() = (From file In listfiles Order By file.CreationTime Select file).ToArray()
            'set folder

            'read file
            For Each File In DefaultFiles

                'create variable
                Dim Icon As String
                'create variable

                'set icon for specific file
                If File.Name.Contains(".png") Or File.Name.Contains(".PNG") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".jpg") Or File.Name.Contains(".jpeg") Or File.Name.Contains(".jpe") Or File.Name.Contains(".jfif") Or File.Name.Contains(".JPG") Or File.Name.Contains(".JPEG") Or File.Name.Contains(".JPE") Or File.Name.Contains(".JFIF") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".txt") Or File.Name.Contains(".TXT") Then
                    Icon = "<i class='las la-file-alt fs-2qx'></i>"
                ElseIf File.Name.Contains(".xlsx") Or File.Name.Contains(".xls") Or File.Name.Contains(".XLSX") Or File.Name.Contains(".XLS") Then
                    Icon = "<i class='las la-file-excel fs-2qx'></i>"
                ElseIf File.Name.Contains(".docx") Or File.Name.Contains(".doc") Or File.Name.Contains(".DOCX") Or File.Name.Contains(".DOC") Then
                    Icon = "<i class='las la-file-word fs-2qx'></i>"
                ElseIf File.Name.Contains(".pptx") Or File.Name.Contains(".ppt") Or File.Name.Contains(".PPTX") Or File.Name.Contains(".PPT") Then
                    Icon = "<i class='las la-file-powerpoint fs-2qx'></i>"
                ElseIf File.Name.Contains(".pdf") Or File.Name.Contains(".PDF") Then
                    Icon = "<i class='las la-file-pdf fs-2qx'></i>"
                End If
                'set icon for specific file

                'add file
                Dim current_RowValues As Object() = {Icon, File.Name, Format(File.CreationTime, "MM/dd/yyyy hh:mm tt")}
                Dim current_dRow As DataRow
                current_dRow = dtable.Rows.Add(current_RowValues)
                dtable.AcceptChanges()
                'add file

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvNoticeAttachment.DataSource = dataView
            gvNoticeAttachment.DataBind()
            'bind datatable

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvNoticeAttachment.DataSource = dataView
            gvNoticeAttachment.DataBind()
            'bind datatable

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

    End Function

    Function bindBillingPosted()

        'get data
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull(Remarks, '') [Remarks] ")
        Query.Append("  ,isnull(DateRequired, '') [DateRequired] ")
        Query.Append("  ,isnull(Status, '') [Status] ")
        Query.Append("  ,isnull(CreatedBy, '') [Contractor] ")
        Query.Append("  ,isnull(CreatedDate, '') [CreatedDate] ")
        Query.Append("  ,(case when Status = 'Submitted' then '' else 'display: none;' end) [Submitted] ")
        Query.Append("  ,(case when Status = 'Approved' then '' else 'display: none;' end) [Approved] ")
        Query.Append("  ,(case when Status = 'Declined' then '' else 'display: none;' end) [Declined] ")
        Query.Append("  ,SeqNo [SeqNo] ")
        Query.Append("from ")
        Query.Append("  SCM_CON_Billing ")
        Query.Append("where ")
        Query.Append("  FormID = '" & ltrlID.Text & "' ")
        'get data

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("DateRequired"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Contractor"))
        dtable.Columns.Add(New DataColumn("CreatedDate"))
        dtable.Columns.Add(New DataColumn("Submitted"))
        dtable.Columns.Add(New DataColumn("Approved"))
        dtable.Columns.Add(New DataColumn("Declined"))
        dtable.Columns.Add(New DataColumn("SeqNo"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Remarks As String = DR("Remarks")
                    Dim DateRequired As String = Format(DR("DateRequired"), "MMM. dd yyyy")
                    Dim Status As String = DR("Status")
                    Dim Contractor As String = DR("Contractor")
                    Dim CreatedDate As String = DR("CreatedDate")
                    Dim Submitted As String = DR("Submitted")
                    Dim Approved As String = DR("Approved")
                    Dim Declined As String = DR("Declined")
                    Dim SeqNo As Int32 = DR("SeqNo")
                    Dim Upd As New StringBuilder
                    'create varialble

                    'set 
                    lblDateReq.Text = Format(DR("DateRequired"), "MM/dd/yyyy")
                    lblCStatus.Text = Status
                    lblRemarks.Text = Remarks
                    'set 

                    'add new row
                    Dim NewRowValues As Object() = {Remarks, DateRequired, Status, Contractor, CreatedDate, Submitted, Approved, Declined}
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
        gvUploadedBilling.DataSource = dtable
        gvUploadedBilling.DataBind()
        RenderDataTable()
        'bind datatable 

        'display
        mdlBillingPosted.Update()
        upnlBillingUploaded.Update()
        'display

    End Function

    Function bindConAttachment(Code As String, ConDate As Date)


        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        'If Directory.Exists(Server.MapPath("~/Assets/Upload/Billing/" & ltrlID.Text & "/" & Code)) Then
        If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\Billing\" & ltrlID.Text & "\" & Code) Then

            'set folder
            'Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/Billing/" & ltrlID.Text & "/" & Code))
            Dim objDir As New DirectoryInfo("C:\inetpub\ciis.net\Assets\Upload\Contracts\Billing\" & ltrlID.Text & "\" & Code)
            Dim listfiles As FileInfo() = objDir.GetFiles()
            'Dim DefaultFiles As FileInfo() = (From file In listfiles Order By file.CreationTime Select file).ToArray()

            ' Specify the target date (modify this to your needs)
            Dim targetDate As DateTime = New DateTime(ConDate.Year, ConDate.Month, ConDate.Day, ConDate.Hour, ConDate.Minute, ConDate.Second) ' i want to get the date and time of the file

            ' Filter files by the target date
            Dim filteredFiles As IEnumerable(Of FileInfo) = listfiles.Where(Function(file) file.LastWriteTime.Date = targetDate.Date)

            ' Order the filtered files by CreationTime
            Dim DefaultFiles As FileInfo() = filteredFiles.OrderBy(Function(file) file.CreationTime).ToArray()

            'set folder

            'read file
            For Each File In DefaultFiles

                'create variable
                Dim Icon As String
                'create variable

                'set icon for specific file
                If File.Name.Contains(".png") Or File.Name.Contains(".PNG") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".jpg") Or File.Name.Contains(".jpeg") Or File.Name.Contains(".jpe") Or File.Name.Contains(".jfif") Or File.Name.Contains(".JPG") Or File.Name.Contains(".JPEG") Or File.Name.Contains(".JPE") Or File.Name.Contains(".JFIF") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".txt") Or File.Name.Contains(".TXT") Then
                    Icon = "<i class='las la-file-alt fs-2qx'></i>"
                ElseIf File.Name.Contains(".xlsx") Or File.Name.Contains(".xls") Or File.Name.Contains(".XLSX") Or File.Name.Contains(".XLS") Then
                    Icon = "<i class='las la-file-excel fs-2qx'></i>"
                ElseIf File.Name.Contains(".docx") Or File.Name.Contains(".doc") Or File.Name.Contains(".DOCX") Or File.Name.Contains(".DOC") Then
                    Icon = "<i class='las la-file-word fs-2qx'></i>"
                ElseIf File.Name.Contains(".pptx") Or File.Name.Contains(".ppt") Or File.Name.Contains(".PPTX") Or File.Name.Contains(".PPT") Then
                    Icon = "<i class='las la-file-powerpoint fs-2qx'></i>"
                ElseIf File.Name.Contains(".pdf") Or File.Name.Contains(".PDF") Then
                    Icon = "<i class='las la-file-pdf fs-2qx'></i>"
                End If
                'set icon for specific file

                'add file
                Dim current_RowValues As Object() = {Icon, File.Name, Code, Format(File.CreationTime, "MM/dd/yyyy hh:mm tt")}
                Dim current_dRow As DataRow
                current_dRow = dtable.Rows.Add(current_RowValues)
                dtable.AcceptChanges()
                'add file

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvUploadedAttachment.DataSource = dataView
            gvUploadedAttachment.DataBind()
            'bind datatable

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvUploadedAttachment.DataSource = dataView
            gvUploadedAttachment.DataBind()
            'bind datatable

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        'update
        upnlBillingUploaded.Update()
        'update
    End Function

    Function RenderDataTable()

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvHistory.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvHistory.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvHistory.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvHistory.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvUploadedBilling.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvUploadedBilling.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvUploadedBilling.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvUploadedBilling.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function
#End Region

#Region "File Viewing"
    Function bindViewing(FileName As String)

        'get file
        Dim FilePath As String = Server.MapPath("~/Assets/Upload/ENG010501/" & ltrlID.Text & "/") & FileName
        'get file

        'view/download
        CIIS_UserInfo("CIIS_File") = "~/Assets/Upload/ENG010501/" & ltrlID.Text & "/" & FileName
        Response.Cookies.Add(CIIS_UserInfo)
        ScriptManager.RegisterStartupScript(upnlFiles, upnlFiles.GetType, "OpenWindow", "window.open('SCM020200');", True)
        'view/download

        'update
        mdlProgress.Update()
        'update

    End Function
#End Region

#Region "Alert"
    Function Alert(ByVal Alert_ As String, ByVal Message_ As String, ByVal Title_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({title: '" & Title_ & "',text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function
#End Region


#Region "Update Deadline"
    Function bindDeadline()

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SCM_Upd_Deadline"
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

    End Function
#End Region


#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Access" Then

            'get total task
            If Type = "View" Then
                Query.Append("if 'SCM000007' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SCM000007') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

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