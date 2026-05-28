Imports System.Net
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes

Public Class AAD002002HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            CIIS_UserInfo = context.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            Dim pFunction = context.Request("pFunction")

            If pFunction = "Redraw-02" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Redraw_02(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-02" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_02(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Info-03" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_03(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-03-List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_03_List(pTblName, pPlaceHolder, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Add-Record-03" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pPayType = context.Request("pPayType")
                Dim pTotalAmount = context.Request("pTotalAmount")
                Dim pInstallmentNo = context.Request("pInstallmentNo")
                Dim pInstallmentAmount = context.Request("pInstallmentAmount")
                Dim pCoinciding = context.Request("pCoinciding")
                Dim pStartDate = context.Request("pStartDate")
                Dim pRemarks = context.Request("pRemarks")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.Add_Record_03(pAcctNo, pPayType, pTotalAmount, pInstallmentNo, pInstallmentAmount, pCoinciding, pStartDate, pRemarks, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-Record-03" Then

                Dim pID = context.Request("pID")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pPayType = context.Request("pPayType")
                Dim pTotalAmount = context.Request("pTotalAmount")
                Dim pInstallmentNo = context.Request("pInstallmentNo")
                Dim pInstallmentAmount = context.Request("pInstallmentAmount")
                Dim pCoinciding = context.Request("pCoinciding")
                Dim pStartDate = context.Request("pStartDate")
                Dim pRemarks = context.Request("pRemarks")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.Update_Record_03(pID, pAcctNo, pPayType, pTotalAmount, pInstallmentNo, pInstallmentAmount, pCoinciding, pStartDate, pRemarks, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Post-Record-03" Then

                Dim pID = context.Request("pID")
                Dim pPostedBy = CIIS_EmpCode

                Dim json As String = Me.Post_Record_03(pID, pPostedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Cancel-Record-03" Then

                Dim pID = context.Request("pID")
                Dim pCancelledRemarks = context.Request("pCancelledRemarks")
                Dim pCancelledBy = CIIS_EmpCode

                Dim json As String = Me.Cancel_Record_03(pID, pCancelledRemarks, pCancelledBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

        Catch ex As Exception

        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Function Redraw_02(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo + '-' + ltrim(str([A].SeqNo)) + '-' + ltrim(str([A].PayType)) [ID] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("   ,isnull([A].Posted,0) [Post] ")
        Query.Append("   ,isnull([A].Cancel,0) [Cancel] ")
        Query.Append("   ,[B].PayDesc ")
        Query.Append("   ,format([A].TotalAmount,'N2') [TotalAmount] ")
        Query.Append("   ,[A].Coinciding ")
        Query.Append("   ,[A].InstallmentNo ")
        Query.Append("   ,format([A].InstallmentAmount,'N2') [InstallmentAmount] ")
        Query.Append("   ,format([A].StartDate,'MM/dd/yyyy') [StartDate] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.trn_OCSummary [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_PaymentType [B] on [A].PayType = [B].PayType ")
        Query.Append("where ")
        Query.Append("  [A].AcctNo + '-' + ltrim(str([A].SeqNo)) + '-' + ltrim(str([A].PayType)) = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn02View('DTL','" & DR("ID") & "');$('#mdl03View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn02Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn02Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn02Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn02Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn02Post('DTL','" & DR("ID") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-cancel' title='Cancel' onclick=""fn02Cancel('DTL','" & DR("ID") & "');return false;""><i class='las la-times-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID02" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Post = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Post") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Cancel = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Cancel") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .PayDesc = "<span title='" & DR("PayDesc") & "'>" & DR("PayDesc") & "</span>",
                        .TotalAmount = DR("TotalAmount"),
                        .Coinciding = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Coinciding") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .InstallmentNo = DR("InstallmentNo"),
                        .InstallmentAmount = DR("InstallmentAmount"),
                        .StartDate = DR("StartDate"),
                        .Blank = ""
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function Get_Record_02(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo + '-' + ltrim(str([A].SeqNo)) + '-' + ltrim(str([A].PayType)) [ID] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("   ,isnull([A].Posted,0) [Post] ")
        Query.Append("   ,isnull([A].Cancel,0) [Cancel] ")
        Query.Append("   ,[B].PayDesc ")
        Query.Append("   ,format([A].TotalAmount,'N2') [TotalAmount] ")
        Query.Append("   ,[A].Coinciding ")
        Query.Append("   ,[A].InstallmentNo ")
        Query.Append("   ,format([A].InstallmentAmount,'N2') [InstallmentAmount] ")
        Query.Append("   ,format([A].StartDate,'MM/dd/yyyy') [StartDate] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.trn_OCSummary [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_PaymentType [B] on [A].PayType = [B].PayType ")
        Query.Append("where ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn02View('DTL','" & DR("ID") & "');$('#mdl03View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn02Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn02Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn02Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn02Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn02Post('DTL','" & DR("ID") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-cancel' title='Cancel' onclick=""fn02Cancel('DTL','" & DR("ID") & "');return false;""><i class='las la-times-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID02" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Post = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Post") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Cancel = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Cancel") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .PayDesc = "<span title='" & DR("PayDesc") & "'>" & DR("PayDesc") & "</span>",
                        .TotalAmount = DR("TotalAmount"),
                        .Coinciding = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Coinciding") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .InstallmentNo = DR("InstallmentNo"),
                        .InstallmentAmount = DR("InstallmentAmount"),
                        .StartDate = DR("StartDate"),
                        .Blank = ""
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function Get_Info_03(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].PayDesc [Title] ")
        Query.Append("   ,(case when isnull([A].Cancel,0) = 1 then 'Cancelled' when isnull([A].Posted,0) = 1 then 'Posted' when isnull([A].Lock,0) = 1 then 'Locked' else 'New' end) [RecordStatus] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("   ,isnull([A].Posted,0) [Post] ")
        Query.Append("   ,isnull([A].Cancel,0) [Cancel] ")
        Query.Append("   ,[A].PayType ")
        Query.Append("   ,[B].PayDesc ")
        Query.Append("   ,format([A].TotalAmount,'N2') [TotalAmount] ")
        Query.Append("   ,[A].Coinciding ")
        Query.Append("   ,[A].InstallmentNo ")
        Query.Append("   ,format([A].InstallmentAmount,'N2') [InstallmentAmount] ")
        Query.Append("   ,format([A].StartDate,'MM/dd/yyyy') [StartDate] ")
        Query.Append("   ,[A].Remarks ")
        Query.Append("   ,[C].fullname [UpdatedByName] ")
        Query.Append("   ,format([A].UpdatedDate,'MM/dd/yyyy') [UpdatedDate] ")
        Query.Append("   ,[D].fullname [LockedByName] ")
        Query.Append("   ,format([A].LockedDate,'MM/dd/yyyy') [LockedDate] ")
        Query.Append("   ,[E].fullname [PostedByName] ")
        Query.Append("   ,format([A].PostedDate,'MM/dd/yyyy') [PostedDate] ")
        Query.Append("   ,[F].fullname [CancelledByName] ")
        Query.Append("   ,format([A].CancelledDate,'MM/dd/yyyy') [CancelledDate] ")
        Query.Append("   ,[A].CancelledRemarks ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.trn_OCSummary [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_PaymentType [B] on [A].PayType = [B].PayType ")
        Query.Append("   left join employee [C] on [A].UpdatedBy = [C].emp_no ")
        Query.Append("   left join employee [D] on [A].LockedBy = [D].emp_no ")
        Query.Append("   left join employee [E] on [A].PostedBy = [E].emp_no ")
        Query.Append("   left join employee [F] on [A].CancelledBy = [F].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].AcctNo + '-' + ltrim(str([A].SeqNo)) + '-' + ltrim(str([A].PayType)) = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Title = DR("Title"),
                        .RecordStatus = DR("RecordStatus"),
                        .Lock = IIf(DR("Lock") = 1, True, False),
                        .Post = IIf(DR("Post") = 1, True, False),
                        .Cancel = IIf(DR("Cancel") = 1, True, False),
                        .PayType = DR("PayType"),
                        .PayDesc = DR("PayDesc"),
                        .TotalAmount = DR("TotalAmount"),
                        .Coinciding = IIf(DR("Coinciding") = 1, True, False),
                        .InstallmentNo = DR("InstallmentNo"),
                        .InstallmentAmount = DR("InstallmentAmount"),
                        .StartDate = DR("StartDate"),
                        .Remarks = DR("Remarks"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate"),
                        .PostedByName = DR("PostedByName"),
                        .PostedDate = DR("PostedDate"),
                        .CancelledByName = DR("CancelledByName"),
                        .CancelledDate = DR("CancelledDate"),
                        .CancelledRemarks = DR("CancelledRemarks")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Get_Record_03_List(pTblName, pPlaceHolder, pID)

        'query
        Dim Query As New StringBuilder
        If pTblName = "mstr_PaymentType" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,1 [Order01] ")
            Query.Append("   ,'' [Order02] ")
            Query.Append("union select ")
            Query.Append("   ltrim(str([A].PayType)) [ID] ")
            Query.Append("   ,[A].PayDesc [Name] ")
            Query.Append("   ,2 [Order01] ")
            Query.Append("   ,[A].PayDesc [Order02] ")
            Query.Append("from ")
            Query.Append("   calmardblive.dbo.mstr_PaymentType [A] ")
            Query.Append("where ")
            Query.Append("   [A].PayType = '" & pID & "' ")
            Query.Append("union select ")
            Query.Append("   ltrim(str([A].PayType)) [ID] ")
            Query.Append("   ,[A].PayDesc [Name] ")
            Query.Append("   ,2 [Order01] ")
            Query.Append("   ,[A].PayDesc [Order02] ")
            Query.Append("from ")
            Query.Append("   calmardblive.dbo.mstr_PaymentType [A] ")
            Query.Append("where ")
            Query.Append("   [A].Active = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order01] ")
            Query.Append("   ,[Order02] ")
        End If
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .Name = DR("Name")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Add_Record_03(pAcctNo, pPayType, pTotalAmount, pInstallmentNo, pInstallmentAmount, pCoinciding, pStartDate, pRemarks, pCreatedBy)

        Dim StartDate As String
        If pCoinciding = True Then StartDate = "null"
        If pCoinciding = False Then StartDate = "'" & Format(CDate(pStartDate), "yyyy-MM-dd") & "'"

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @SeqNo nvarchar(13) ")
        Query.Append("exec New_SeqNo 'trn_OCSummary','" & pAcctNo & "',@SeqNo output ")
        Query.Append("INSERT INTO [calmardbLive].[dbo].[trn_OCSummary] ")
        Query.Append("   ([AcctNo] ")
        Query.Append("   ,[SeqNo] ")
        Query.Append("   ,[PayType] ")
        Query.Append("   ,[TotalAmount] ")
        Query.Append("   ,[Coinciding] ")
        Query.Append("   ,[InstallmentNo] ")
        Query.Append("   ,[InstallmentAmount] ")
        Query.Append("   ,[StartDate] ")
        Query.Append("   ,[Remarks] ")
        Query.Append("   ,[CreatedBy] ")
        Query.Append("   ,[CreatedDate] ")
        Query.Append("   ,[UpdatedBy] ")
        Query.Append("   ,[UpdatedDate] ")
        Query.Append("   ,[LockedBy] ")
        Query.Append("   ,[LockedDate] ")
        Query.Append("   ,[Lock] ")
        Query.Append("   ,[PostedBy] ")
        Query.Append("   ,[PostedDate] ")
        Query.Append("   ,[Posted] ")
        Query.Append("   ,[CancelledRemarks] ")
        Query.Append("   ,[CancelledBy] ")
        Query.Append("   ,[CancelledDate] ")
        Query.Append("   ,[Cancel] ")
        Query.Append("   ,[Priority] ")
        Query.Append("   ,[InstallmentPeriod] ")
        Query.Append("   ,[AddToICR] ")
        Query.Append("   ,[Frequency] ")
        Query.Append("   ,[EndingDate] ")
        Query.Append("   ,[AuditUser] ")
        Query.Append("   ,[AuditDate]) ")
        Query.Append("VALUES ")
        Query.Append("   ('" & pAcctNo & "' ")
        Query.Append("   ,@SeqNo ")
        Query.Append("   ," & pPayType & " ")
        Query.Append("   ," & CDbl(pTotalAmount) & " ")
        Query.Append("   ," & IIf(pCoinciding = True, 1, 0) & " ")
        Query.Append("   ," & CDbl(pInstallmentNo) & " ")
        Query.Append("   ," & CDbl(pInstallmentAmount) & " ")
        Query.Append("   ," & StartDate & " ")
        Query.Append("   ,'" & pRemarks & "' ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0 ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0 ")
        Query.Append("   ,'' ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0 ")
        Query.Append("   ,0 ")
        Query.Append("   ,0 ")
        Query.Append("   ,0 ")
        Query.Append("   ,0 ")
        Query.Append("   ,null ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate()) ")
        Query.Append("select '" & pAcctNo & "' + '-' + ltrim(str(@SeqNo))  + '-' + '" & pPayType & "' [oID] ")

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = DR("oID")})

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Update_Record_03(pID, pAcctNo, pPayType, pTotalAmount, pInstallmentNo, pInstallmentAmount, pCoinciding, pStartDate, pRemarks, pUpdatedBy)

        Dim StartDate As String
        If pCoinciding = True Then StartDate = "null"
        If pCoinciding = False Then StartDate = "'" & Format(CDate(pStartDate), "yyyy-MM-dd") & "'"

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE [calmardbLive].[dbo].[trn_OCSummary] SET ")
        Query.Append("   ,[PayType] = " & pPayType & " ")
        Query.Append("   ,[TotalAmount] = " & CDbl(pTotalAmount) & " ")
        Query.Append("   ,[Coinciding] = " & IIf(pCoinciding = True, 1, 0) & " ")
        Query.Append("   ,[InstallmentNo] = " & CDbl(pInstallmentNo) & " ")
        Query.Append("   ,[InstallmentAmount] = " & CDbl(pInstallmentAmount) & " ")
        Query.Append("   ,[StartDate] = " & StartDate & " ")
        Query.Append("   ,[Remarks] = '" & pRemarks & "' ")
        Query.Append("   ,[UpdatedBy] = '" & pUpdatedBy & "' ")
        Query.Append("   ,[UpdatedDate] = GETDATE() ")
        Query.Append("WHERE ")
        Query.Append("AcctNo + '-' + ltrim(str(SeqNo)) + '-' + ltrim(str(PayType)) = '" & pID & "' ")

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pID})

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Post_Record_03(pTblCode, pPostedBy)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Post_NonICRSummary"
        SqlCmd.Parameters.AddWithValue("@pTblCode", pTblCode)
        SqlCmd.Parameters.AddWithValue("@pPostedBy", pPostedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Function Cancel_Record_03(pTblCode, pCancelledRemarks, pCancelledBy)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Rvrs_NonICRSummary"
        SqlCmd.Parameters.AddWithValue("@pTblCode", pTblCode)
        SqlCmd.Parameters.AddWithValue("@pCancelledRemarks", pCancelledRemarks)
        SqlCmd.Parameters.AddWithValue("@pCancelledBy", pCancelledBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

End Class