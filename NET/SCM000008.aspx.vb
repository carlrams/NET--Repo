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

Public Class SCM000008
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
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
            CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "003002")
        'active account / menu

        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString()
            ltrlFormNo.Text = "SCM000008"
            'Record

            bindFiles()
            bindOverview()
            bindBilling()
            bindCondition()

        End If

    End Sub
#End Region

#Region "Button"
    Private Sub lbtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSubmit.Click
        bindFiles()
    End Sub

    Private Sub lbtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnDelete.Click
        Dim FileName As String = hdnFile.Value
        If FileName <> "" Then
            bindDeletion(FileName)
        End If
    End Sub

    Private Sub lbtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnView.Click
        Dim FileName As String = hdnFile.Value
        If FileName <> "" Then
            bindViewing(FileName)
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
        Query.Append("  ,(select dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) from Form_HWTask [T] left join employee [B] on [T].AssignTo = [B].emp_no where [T].TaskCode = '006' and [T].TaskName = 'House Construction' and [T].HWCode = [A].HWCode) [Assigned] ")
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

                    'trigger
                    If Percentage = 100 Then
                        lbtnDone.Visible = True
                    Else
                        lbtnDone.Visible = False
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
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join Trxn_ContractBill [B] on [A].HWCode = [B].CRTCode ")
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
                    Dim Upd As New StringBuilder
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {RemarksBefore, RemarksAfter, PostedDate, Type, Rate, Amount}
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

    End Function
#End Region

#Region "File Deletion"
    Function bindDeletion(FileName As String)
        'get file
        Dim FilePath As String = Server.MapPath("~/Assets/Upload/ENG010501/" & ltrlID.Text & "/") & FileName
        File.Delete(FilePath)
        'remove file

        'fill new data
        bindFiles()
        'fill new data

        'alert
        Alert("success", "File successfully removed!", "Success")
        'alert
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
        ScriptManager.RegisterStartupScript(upnlFiles, upnlFiles.GetType, "OpenWindow", "window.open('MNU000005');", True)
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

End Class