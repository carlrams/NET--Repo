Imports System.Net
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes
Imports Microsoft.Ajax.Utilities
Imports System.Net.Mail

Public Class AAD002013HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
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

                Dim json As String = Me.Get_Record_03_List()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Add-Record-03" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pPayType = context.Request("pPayType")
                Dim pCheck = context.Request("pCheck")
                Dim pNotesDate = context.Request("pNotesDate")
                Dim pNotes = context.Request("pNotes")

                Dim json As String = Me.Add_Record_03(pAcctNo, pPayType, pCheck, pNotesDate, pNotes)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-Record-03" Then

                Dim pID = context.Request("pID")
                Dim pPayType = context.Request("pPayType")
                Dim pCheck = context.Request("pCheck")
                Dim pNotesDate = context.Request("pNotesDate")
                Dim pNotes = context.Request("pNotes")

                Dim json As String = Me.Update_Record_03(pID, pPayType, pCheck, pNotesDate, pNotes)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Getdata-Account" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Data_Account(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Getdata-Cobuyers-email" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Data_Account_Cobuyers(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "GetdataPushmail" Then
                Dim pID = context.Request("pID")
                Dim json As String = Me.Get_Push_Email(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Getdata-Account-Seller" Then
                Dim pID = context.Request("pID")
                Dim json As String = Me.Get_Data_Account_Seller(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "SendPushmail" Then
                Dim AcctNo = context.Request("AcctNo")
                Dim Project = context.Request("Project")
                Dim AcctName = context.Request("AcctName")
                Dim Address = context.Request("Address")
                Dim EmailCoBuyer = context.Request("EmailCoBuyer")
                Dim SellerEmail = context.Request("SellerEmail")
                Dim SellerGrp = context.Request("SellerGrp")
                Dim Email = context.Request("Email")
                Dim MainEmail = context.Request("MainEmail")

                Dim json As String = Me.PushMail_SendCTS(AcctNo, Project, AcctName, Address, EmailCoBuyer, SellerEmail, SellerGrp, Email, MainEmail)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
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
        Query.Append("	ICR_AccountNotes.TransactionNumber ")
        Query.Append("	,ICR_AccountNotes.AcctNo ")
        Query.Append("	,ICR_AccountNotes.NotesType ")
        Query.Append("	,mstr_AccountNoteTypes.Notesdescription ")
        Query.Append("	,ICR_AccountNotes.Reminder ")
        Query.Append("	,ICR_AccountNotes.NotesDate ")
        Query.Append("	,ICR_AccountNotes.Notes ")
        Query.Append("	,ICR_AccountNotes.AuditUser ")
        Query.Append("	,ICR_AccountNotes.AuditDate ")
        Query.Append("	,ISNULL([A].fullname, (SELECT fullname FROM employee WHERE emp_no = (SELECT EmpCode FROM calmardbLive.dbo.mstr_users WHERE ICR_AccountNotes.AuditUser = mstr_users.LogName)))  [updated_by] ")
        Query.Append("from  ")
        Query.Append("	calmardblive.dbo.ICR_AccountNotes ")
        Query.Append("	LEFT JOIN employee [A] ON ICR_AccountNotes.AuditUser = [A].Emp_no ")
        Query.Append("	left join calmardblive.dbo.mstr_AccountNoteTypes on ICR_AccountNotes.NotesType = mstr_AccountNoteTypes.NotesCode ")
        Query.Append("where ")
        Query.Append("	CAST(ICR_AccountNotes.AcctNo AS VARCHAR(50)) + CAST(ICR_AccountNotes.TransactionNumber AS VARCHAR(50)) = @AcctNo  ")
        Query.Append("order by ")
        Query.Append("	ICR_AccountNotes.NotesDate ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn02View('DTL','" & DR("AcctNo").ToString() & DR("TransactionNumber").ToString() & "');$('#mdl03View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn02Delete('DTL','" & DR("AcctNo").ToString() & DR("TransactionNumber").ToString() & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn02Edit('UPD','" & DR("AcctNo").ToString() & DR("TransactionNumber").ToString() & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID02" & DR("AcctNo") & DR("TransactionNumber"),
                        .Action = Action.ToString,
                        .Reminder = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Reminder") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Type = DR("Notesdescription"),
                        .NoteDate = If(IsDBNull(DR("NotesDate")), "", Convert.ToDateTime(DR("NotesDate")).ToString("MM/dd/yyyy")),
                        .Note = "<span title='" & DR("Notes") & "'>" & DR("Notes") & "</span>"
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
        Query.Append("	ICR_AccountNotes.TransactionNumber ")
        Query.Append("	,ICR_AccountNotes.AcctNo ")
        Query.Append("	,ICR_AccountNotes.NotesType ")
        Query.Append("	,mstr_AccountNoteTypes.Notesdescription ")
        Query.Append("	,ICR_AccountNotes.Reminder ")
        Query.Append("	,ICR_AccountNotes.NotesDate ")
        Query.Append("	,ICR_AccountNotes.Notes ")
        Query.Append("	,ICR_AccountNotes.AuditUser ")
        Query.Append("	,ICR_AccountNotes.AuditDate ")
        Query.Append("	,ISNULL([A].fullname, (SELECT fullname FROM employee WHERE emp_no = (SELECT EmpCode FROM calmardbLive.dbo.mstr_users WHERE ICR_AccountNotes.AuditUser = mstr_users.LogName)))  [updated_by] ")
        Query.Append("from  ")
        Query.Append("	calmardblive.dbo.ICR_AccountNotes ")
        Query.Append("	LEFT JOIN employee [A] ON ICR_AccountNotes.AuditUser = [A].Emp_no ")
        Query.Append("	left join calmardblive.dbo.mstr_AccountNoteTypes on ICR_AccountNotes.NotesType = mstr_AccountNoteTypes.NotesCode ")
        Query.Append("where ")
        Query.Append("	ICR_AccountNotes.AcctNo = @AcctNo ")
        Query.Append("order by ")
        Query.Append("	ICR_AccountNotes.NotesDate ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn02View('DTL','" & DR("AcctNo").ToString() & DR("TransactionNumber").ToString() & "');$('#mdl03View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn02Delete('DTL','" & DR("AcctNo").ToString() & DR("TransactionNumber").ToString() & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn02Edit('UPD','" & DR("AcctNo").ToString() & DR("TransactionNumber").ToString() & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID02" & DR("AcctNo") & DR("TransactionNumber"),
                        .Action = Action.ToString,
                        .Reminder = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Reminder") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Type = DR("Notesdescription"),
                        .NoteDate = If(IsDBNull(DR("NotesDate")), "", Convert.ToDateTime(DR("NotesDate")).ToString("MM/dd/yyyy")),
                        .Note = "<span title='" & DR("Notes") & "'>" & DR("Notes") & "</span>"
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
        Query.Append("SELECT ")
        Query.Append("	ICR_AccountNotes.TransactionNumber,  ")
        Query.Append("	ICR_AccountNotes.AcctNo,  ")
        Query.Append("	ICR_AccountNotes.NotesType, ")
        Query.Append("	mstr_AccountNoteTypes.NotesDescription,  ")
        Query.Append("	ICR_AccountNotes.NotesDate,  ")
        Query.Append("	ICR_AccountNotes.Notes,  ")
        Query.Append("	ICR_AccountNotes.AuditUser,  ")
        Query.Append("	ICR_AccountNotes.AuditDate,  ")
        Query.Append("	ICR_AccountNotes.Reminder, ")
        Query.Append("	ISNULL([A].fullname, (SELECT fullname FROM employee WHERE emp_no =  ")
        Query.Append("	(SELECT EmpCode FROM calmardbLive.dbo.mstr_users WHERE ICR_AccountNotes.AuditUser = mstr_users.LogName)))  [updated_by] ")
        Query.Append("	,'New' [RecordStatus]  ")
        Query.Append("FROM             ")
        Query.Append("	calmardbLive.dbo.ICR_AccountNotes  ")
        Query.Append("	LEFT OUTER JOIN calmardbLive.dbo.mstr_AccountNoteTypes ON ICR_AccountNotes.NotesType = mstr_AccountNoteTypes.NotesCode ")
        Query.Append("	LEFT JOIN employee [A] ON ICR_AccountNotes.AuditUser = [A].Emp_no ")
        Query.Append("WHERE         ")
        Query.Append("	CAST(ICR_AccountNotes.AcctNo AS VARCHAR(50)) + CAST(ICR_AccountNotes.TransactionNumber AS VARCHAR(50)) = @AcctNo ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Title = DR("Notes"),
                        .RecordStatus = DR("RecordStatus"),
                        .Reminder = IIf(DR("Reminder") = 1, True, False),
                        .Type = DR("NotesDescription"),
                        .NotesType = DR("NotesType"),
                        .NotesDate = Convert.ToDateTime(DR("NotesDate")).ToString("MM/dd/yyyy"),
                        .Notes = DR("Notes"),
                        .updated_by = DR("updated_by"),
                        .AuditDate = Convert.ToDateTime(DR("AuditDate")).ToString("MM/dd/yyyy hh:mm tt")
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

    Function Get_Record_03_List()

        'query
        Dim Query As New StringBuilder()
        Query.Append("select ")
        Query.Append("	'' [ID] ")
        Query.Append("	,'Select Type' [Name] ")
        Query.Append("    ,1 [Lock] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("	cast(NotesCode as nvarchar(13)) [ID] ")
        Query.Append("	,NotesDescription [Name] ")
        Query.Append("    ,1 [Lock] ")
        Query.Append("from  ")
        Query.Append("	calmardbLive.dbo.mstr_AccountNoteTypes ")
        Query.Append("order by ")
        Query.Append("	[ID] ")

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

    Function Add_Record_03(pAcctNo, pPayType, pCheck, pNotesDate, pNotes)
        'create variable
        Dim Query As New StringBuilder
        Query.Append("DECLARE @Seqno nvarchar(13); ")
        Query.Append("EXEC calmardblive.dbo.JCF_NewSeqNo 'ICR_AccountNotes', @AcctNo, @Seqno OUTPUT; ")
        Query.Append("INSERT INTO calmardblive.dbo.ICR_AccountNotes ")
        Query.Append("    (AcctNo, TransactionNumber, NotesType, Reminder, NotesDate, Notes, AuditUser, AuditDate) ")
        Query.Append("VALUES ")
        Query.Append("    (@AcctNo, @Seqno, @NotesType, @Reminder, @NotesDate, @Notes, @AuditUser, FORMAT(GETDATE(), 'MM/dd/yy HH:mm:ss.fff')); ")
        Query.Append("SELECT @AcctNo + @Seqno AS oID; ")

        'variable
        Dim RecordList As New List(Of Object)()

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text

                ' Parameters
                Cmd.Parameters.AddWithValue("@AcctNo", pAcctNo)
                Cmd.Parameters.AddWithValue("@NotesType", pPayType)
                Dim isChecked As Boolean = False

                If pCheck IsNot Nothing Then
                    Dim val As String = pCheck.ToString().Trim().ToLower()
                    If val = "on" OrElse val = "true" OrElse val = "1" Then
                        isChecked = True
                    End If
                End If

                Cmd.Parameters.AddWithValue("@Reminder", If(isChecked, 1, 0))
                Cmd.Parameters.AddWithValue("@NotesDate", pNotesDate)
                Cmd.Parameters.AddWithValue("@Notes", pNotes)
                Cmd.Parameters.AddWithValue("@AuditUser", CIIS_EmpCode)

                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    While DR.Read()
                        RecordList.Add(New With {.oID = DR("oID")})
                    End While
                    DR.Close()
                End Using
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
    End Function

    Function Update_Record_03(pID, pPayType, pCheck, pNotesDate, pNotes)
        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE calmardblive.dbo.ICR_AccountNotes SET ")
        Query.Append("    NotesType = @NotesType, ")
        Query.Append("    Reminder = @Reminder, ")
        Query.Append("    NotesDate = @NotesDate, ")
        Query.Append("    Notes = @Notes, ")
        Query.Append("    AuditUser = @AuditUser, ")
        Query.Append("    AuditDate = FORMAT(GETDATE(), 'MM/dd/yy HH:mm:ss.fff') ")
        Query.Append("WHERE CAST(ICR_AccountNotes.AcctNo AS VARCHAR(50)) + CAST(ICR_AccountNotes.TransactionNumber AS VARCHAR(50)) = @AcctNo ")

        'variable
        Dim RecordList As New List(Of Object)()

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text

                ' Parameters
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                Cmd.Parameters.AddWithValue("@NotesType", pPayType)
                Dim isChecked As Boolean = False

                If pCheck IsNot Nothing Then
                    Dim val As String = pCheck.ToString().Trim().ToLower()
                    If val = "on" OrElse val = "true" OrElse val = "1" Then
                        isChecked = True
                    End If
                End If

                Cmd.Parameters.AddWithValue("@Reminder", If(isChecked, 1, 0))
                Cmd.Parameters.AddWithValue("@NotesDate", pNotesDate)
                Cmd.Parameters.AddWithValue("@Notes", pNotes)
                Cmd.Parameters.AddWithValue("@AuditUser", CIIS_EmpCode)

                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    While DR.Read()
                        RecordList.Add(New With {.oID = pID})
                    End While
                    DR.Close()
                End Using
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
    End Function

    Function Get_Data_Account(pID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ICR_Buyers.AcctNo ")
        Query.Append("	,ICR_Buyers.AcctName ")
        Query.Append("	,mstr_Projects.ProjName + ' Phase ' + ICR_Buyers.Phase + ' Block ' + ICR_Buyers.block + ' Lot ' + ICR_Buyers.Lot [Project] ")
        Query.Append("	,ICR_Buyers.MailingAddress + ', ' + ICR_Buyers.MailingTownPlace + ', ' + mstr_Cities.CityName [MailingAddress] ")
        Query.Append("	,ICR_Buyers.Emailaddress ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.ICR_Buyers  ")
        Query.Append("	left join calmardbLive.dbo.mstr_Projects on ICR_Buyers.ProjCode = mstr_Projects.ProjCode ")
        Query.Append("	left join calmardbLive.dbo.mstr_Cities  on ICR_Buyers.MailingCountryCode = mstr_Cities.CountryCode and ICR_Buyers.MailingCityCode = mstr_Cities.CityCode ")
        Query.Append("where  ")
        Query.Append("	ICR_Buyers.AcctNo = '" & pID & "' ")
        'get total task

        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordInfo.Add(New With {
                        .AcctName = If(IsDBNull(DR("AcctName")), Nothing, DR("AcctName")),
                        .Project = If(IsDBNull(DR("Project")), Nothing, DR("Project")),
                        .Address = If(IsDBNull(DR("MailingAddress")), Nothing, DR("MailingAddress")),
                        .Email = If(IsDBNull(DR("Emailaddress")), Nothing, DR("Emailaddress"))
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'Display
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordInfo)
        'Display


    End Function
    Function Get_Data_Account_Cobuyers(pID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	Emailaddress  ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.ICR_CoBuyer ")
        Query.Append("where ")
        Query.Append("	AcctNo = '" & pID & "' ")
        'get total task

        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordInfo.Add(New With {
                        .Email = If(IsDBNull(DR("Emailaddress")), Nothing, DR("Emailaddress"))
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'Display
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordInfo)
        'Display


    End Function
    Function Get_Push_Email(pID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	 PushMailType ")
        Query.Append("	,EmailType ")
        Query.Append("	,Email ")
        Query.Append("	,Territory ")
        Query.Append("from ")
        Query.Append("	cldc_live_acc.dbo.Parm_AAD_Pushmail ")
        Query.Append("where  ")
        Query.Append("	PushMailType = 'CTS Transmittal' ")
        Query.Append("	and Territory =  ")
        Query.Append("	(select mstr_Projects.Territory from  ")
        Query.Append("	calmardbLive.dbo.ICR_Buyers  ")
        Query.Append("	left join calmardbLive.dbo.mstr_Projects on ICR_Buyers.ProjCode = mstr_Projects.ProjCode where ICR_Buyers.AcctNo = '" & pID & "') ")
        'get total task

        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordInfo.Add(New With {
                        .EmailType = If(IsDBNull(DR("EmailType")), Nothing, DR("EmailType")),
                        .Email = If(IsDBNull(DR("Email")), Nothing, DR("Email"))
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'Display
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordInfo)
        'Display


    End Function
    Function Get_Data_Account_Seller(pID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	mstr_LotsInventory.AcctNo ")
        Query.Append("	,mstr_Sellers.EmailAddress ")
        Query.Append("	,mstr_SellerGroups.SellerGrpDesc ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_LotsInventory ")
        Query.Append("	left join calmardbLive.dbo.ICR_Sellers on mstr_LotsInventory.AcctNo = ICR_Sellers.AcctNo ")
        Query.Append("	left join calmardbLive.dbo.mstr_Sellers on ICR_Sellers.SellerCode = mstr_Sellers.SellerCode ")
        Query.Append("    left join calmardbLive.dbo.mstr_SellerGroups on ICR_Sellers.GroupCode = mstr_SellerGroups.SellerGrpCode ")
        Query.Append("where  ")
        Query.Append("	mstr_LotsInventory.AcctNo = '" & pID & "' ")
        'get total task

        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordInfo.Add(New With {
                        .EmailAddress = If(IsDBNull(DR("EmailAddress")), Nothing, DR("EmailAddress")),
                        .SellerGrpDesc = If(IsDBNull(DR("SellerGrpDesc")), Nothing, DR("SellerGrpDesc"))
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'Display
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordInfo)
        'Display


    End Function
    Function PushMail_SendCTS(AcctNo, Project, AcctName, Address, EmailCoBuyer, SellerEmail, SellerGrp, Email, MainEmail) As String
        Dim result As String = "Success"
        Dim sentCount As Integer = 0

        Try
            Dim smtp As New SmtpClient("mail.calmarland.com")
            smtp.Credentials = New NetworkCredential("accountmanagement@calmarland.com", "M5ilP5ssw0rdAAD")
            smtp.Port = 587
            smtp.EnableSsl = False

            ' Deserialize JSON string into list of dictionaries
            Dim serializer As New JavaScriptSerializer()
            Dim emailList As List(Of Dictionary(Of String, Object)) = serializer.Deserialize(Of List(Of Dictionary(Of String, Object)))(Email)
            Dim EmailCoBuyerList As List(Of Dictionary(Of String, Object)) = serializer.Deserialize(Of List(Of Dictionary(Of String, Object)))(EmailCoBuyer)

            ' Prepare MailMessage only once
            Dim mail As New MailMessage()
            mail.From = New MailAddress("accountmanagement@calmarland.com")

            If Not String.IsNullOrWhiteSpace(MainEmail) Then
                Try
                    Dim addr As New MailAddress(MainEmail)
                    mail.To.Add(addr)
                Catch ex As Exception
                    ' Skip if invalid
                End Try
            End If

            For Each Email In emailList
                Dim recipient As String = Email("Email").ToString()
                Dim type As String = Email("EmailType").ToString().Trim().ToUpper()

                If Not String.IsNullOrWhiteSpace(recipient) Then
                    Try
                        Dim addr As New MailAddress(recipient) ' Validate format
                        If type = "CC" Then
                            mail.CC.Add(addr)
                        Else
                            mail.To.Add(addr)
                        End If
                    Catch ex As Exception
                        ' Skip invalid email, continue with others
                        Continue For
                    End Try
                End If
            Next

            For Each EmailCoBuyer In EmailCoBuyerList
                Dim recipient As String = Email("Email").ToString()

                If Not String.IsNullOrWhiteSpace(recipient) Then
                    Try
                        Dim addr As New MailAddress(recipient) ' Validate format
                        mail.CC.Add(addr)

                    Catch ex As Exception
                        ' Skip invalid email, continue with others
                        Continue For
                    End Try
                End If
            Next

            ' Add SellerEmail as recipient (safe add)
            If Not String.IsNullOrWhiteSpace(SellerEmail) Then
                Try
                    Dim addr As New MailAddress(SellerEmail)
                    mail.CC.Add(addr)
                Catch ex As Exception
                    ' Skip if invalid
                End Try
            End If

            If Not String.IsNullOrWhiteSpace(SellerGrp = "BU-CPI") Then
                Try

                    mail.CC.Add("namichanchan27@gmail.com")
                    'mail.CC.Add("padua.aileen@gmail.com")
                    'mail.CC.Add("fransley.evora@gmail.com")
                    'mail.CC.Add("tcsalvacion@gmail.com")
                Catch ex As Exception
                    ' Skip invalid email, but continue
                End Try
            End If

            ' Build email content
            mail.Subject = "CTS Transmittal - " & AcctName
            Dim Content As String = ""

            Content = "<html><body>Dear Sir/Ma'am <b>" & AcctName & "</b>, <br /><br />"
            Content = Content & "Good day! <br /><br />"
            Content = Content & "This is to inform you that the Contract to Sell (CTS) for your purchased property located <br />"
            Content = Content & "at <b>" & Project & "</b> has been picked up by J&T today and <br />"
            Content = Content & "will be delivered at your mailing address, <b>" & Address & "</b>, for your signature. <br /> <br />"
            Content = Content & "To make the signing process easier, we have included a Cover Letter and Sample <br />"
            Content = Content & "Illustration with the Contract to Sell (CTS). Please take your time to read the instructions <br />"
            Content = Content & "carefully. Once you’ve signed the Contract to Sell (CTS) and the attached Annexes, you can refer to <br />"
            Content = Content & "the Cover Letter for the next steps. <br /><br />"
            Content = Content & "By J&T shipping standards, kindly expect that your Contract to Sell (CTS) should arrive <br />"
            Content = Content & "in your area and will be out for delivery within <b>2 to 3 days</b>. <br /><br />"
            Content = Content & "To ensure a smooth transaction, we kindly request that the signed documents be returned to us within <b>fifteen (15) days</b> upon receipt. <br /><br />"
            Content = Content & "Warm Regards,<br /> <br />"
            Content = Content & "Account Administration Department<br />"
            Content = Content & "CALMARLAND DEVELOPMENT CORPORATION<br /> <br />"
            Content = Content & "NOTE: This is a system generated email, please do not reply.</html></body>"
            mail.Body = Content
            mail.IsBodyHtml = True

            ' Send the email once
            smtp.Send(mail)
            mail.Dispose()
            sentCount = 1

        Catch ex As Exception
            result = "Error sending email: " & ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(New With {
        Key .status = result,
        Key .emailsSent = sentCount
    })
    End Function

End Class