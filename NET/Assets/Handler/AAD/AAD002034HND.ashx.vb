Imports System.ComponentModel.DataAnnotations
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.InteropServices.ComTypes
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Windows.Interop

Public Class AAD002034HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            CIIS_UserInfo = context.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            Dim pFunction = context.Request("pFunction")

            If pFunction = "Get-Info-03" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_03(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-Record-03" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTODate = context.Request("pTODate")

                Dim json As String = Me.Update_Record_03(pAcctNo, pTODate)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Send-Record-03" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTODate = context.Request("pTODate")
                Dim pTime = context.Request("pTime")

                Dim json As String = Me.Send_Record_03(pAcctNo, pTODate, pTime)
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
        Query.Append("   mstr_LotsInventory.AcctNo [AcctNo] ")
        Query.Append("   ,ISNULL(mstr_Sellers.SellerName, '') [SellerName] ")
        Query.Append("   ,ISNULL(FORMAT(mstr_LotsInventory.TurnOverDate, 'MM/dd/yyyy'), '') [TurnOverDate] ")
        Query.Append("   ,ISNULL(mstr_Sellers.EmailAddress, '') [EmailAddress] ")
        Query.Append("   ,ISNULL(mstr_Sellers.Cellphone, '') [Cellphone] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_LotsInventory ")
        Query.Append("   left join calmardbLive.dbo.ICR_Sellers on mstr_LotsInventory.AcctNo = ICR_Sellers.AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers on ICR_Sellers.SellerCode = mstr_Sellers.SellerCode ")
        Query.Append("where ")
        Query.Append("   mstr_LotsInventory.AcctNo = '" & pID & "' ")
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
                        .AcctNo = DR("AcctNo"),
                        .SellerName = DR("SellerName"),
                        .TODate = DR("TurnOverDate"),
                        .Email = DR("EmailAddress"),
                        .MobileNo = DR("Cellphone")
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
        Query.Append("   mstr_LotsInventory.AcctNo [AcctNo] ")
        Query.Append("   ,ISNULL(mstr_Sellers.SellerName, '') [SellerName] ")
        Query.Append("   ,ISNULL(FORMAT(mstr_LotsInventory.TurnOverDate, 'MM/dd/yyyy'), '') [TurnOverDate] ")
        Query.Append("   ,ISNULL(mstr_Sellers.EmailAddress, '') [EmailAddress] ")
        Query.Append("   ,ISNULL(mstr_Sellers.Cellphone, '') [Cellphone] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_LotsInventory ")
        Query.Append("   left join calmardbLive.dbo.ICR_Sellers on mstr_LotsInventory.AcctNo = ICR_Sellers.AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers on ICR_Sellers.SellerCode = mstr_Sellers.SellerCode ")
        Query.Append("where ")
        Query.Append("   mstr_LotsInventory.AcctNo = '" & pID & "' ")
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
                        .AcctNo = DR("AcctNo"),
                        .SellerName = DR("SellerName"),
                        .TODate = DR("TurnOverDate"),
                        .Email = DR("EmailAddress"),
                        .MobileNo = DR("Cellphone")
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

    Function Update_Record_03(pAcctNo, pTODate)

        Dim TODate As Date = pTODate

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE calmardbLive.dbo.mstr_LotsInventory SET ")
        If pTODate <> "" Then
            Query.Append("   TurnOverDate = '" & TODate & "' ")
        Else
            Query.Append("   TurnOverDate = NULL ")
        End If
        Query.Append("WHERE ")
        Query.Append("  AcctNo = '" & pAcctNo & "' ")

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

                    RecordList.Add(New With {.oReturn = "Success"})

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

    Function Send_Record_03(pAcctNo, pTODate, pTime)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   mstr_LotsInventory.AcctNo [AcctNo] ")
        Query.Append("   ,mstr_LotsInventory.AcctName [AcctName] ")
        Query.Append("   ,ISNULL(mstr_Sellers.SellerName, '') [SellerName] ")
        Query.Append("   ,ISNULL(FORMAT(mstr_LotsInventory.TurnOverDate, 'MM/dd/yyyy'), '') [TurnOverDate] ")
        Query.Append("   ,ISNULL(mstr_Sellers.EmailAddress, '') [EmailAddress] ")
        Query.Append("   ,ISNULL(mstr_Sellers.Cellphone, '') [Cellphone] ")
        Query.Append("   ,(select ProjName from calmardbLive.dbo.mstr_Projects where mstr_Projects.ProjCode = mstr_LotsInventory.ProjCode) [ProjectName] ")
        Query.Append("   ,mstr_LotsInventory.PhaseNo [Phase] ")
        Query.Append("   ,mstr_LotsInventory.Block [Block] ")
        Query.Append("   ,mstr_LotsInventory.Lot [Lot] ")
        Query.Append("   ,(select ISNULL(employee.email, '') from employee where emp_no = '" & CIIS_EmpCode & "') [EmpEmail] ") 'change address
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_LotsInventory ")
        Query.Append("   left join calmardbLive.dbo.ICR_Sellers on mstr_LotsInventory.AcctNo = ICR_Sellers.AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers on ICR_Sellers.SellerCode = mstr_Sellers.SellerCode ")
        Query.Append("where ")
        Query.Append("   mstr_LotsInventory.AcctNo = '" & pAcctNo & "' ")
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

                    Dim Content As New StringBuilder
                    Content.Append(" Hi <b>" & DR("SellerName") & ", </b><br /><br /> ")
                    Content.Append(" I'm excited to inform you that <b>" & DR("AcctName") & "</b> <br /> ")
                    Content.Append(" unit at <b>" & DR("ProjectName") & "</b> Phase <b>" & DR("Phase") & "</b> Block <b>" & DR("Block") & "</b> Lot <b>" & DR("Lot") & "</b> is scheduled for turnover on  <b>" & pTODate & "</b>.<br /> ")
                    Content.Append(" You’re warmly invited to visit the unit at <b>" & IIf(pTime <> "", pTime, "-") & "</b> to witness your client’s turnover. <br /><br /> ")
                    Content.Append(" Looking forward to seeing you there! <br /><br /> ")
                    Content.Append(" Best Regards,<br /><br /> ")
                    Content.Append(" Calmar Land - Customer Service Team<br /><br /> ")
                    Content.Append(" NOTE: This is a system generated email, do not reply.</html></body>")

                    If DR("EmailAddress") <> "" Then
                        Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
                        Dim mail As MailMessage
                        Dim body As String
                        smtp.Credentials = New NetworkCredential("accountmanagement@calmarland.com", "M5ilP5ssw0rdAAD")
                        smtp.Host = "mail.calmarland.com"
                        smtp.Port = 587
                        mail = New MailMessage()
                        mail.From = New MailAddress("accountmanagement@calmarland.com")
                        mail.To.Add(DR("EmailAddress"))
                        mail.CC.Add(DR("EmpEmail"))
                        mail.Subject = "Turnover Schedule - " & pTODate
                        mail.IsBodyHtml = True
                        mail.Body = Content.ToString
                        smtp.Send(mail)
                        mail.Dispose()
                    End If

                    If DR("Cellphone") <> "" Then

                        Dim TextMessage As New StringBuilder
                        TextMessage.Append(" Hi <b>" & DR("SellerName") & ", </b><br /><br /> ")
                        TextMessage.Append(" I'm excited to inform you that <b>" & DR("AcctName") & "</b> <br /> ")
                        TextMessage.Append(" unit at <b>" & DR("ProjectName") & "</b> Phase <b>" & DR("Phase") & "</b> Block <b>" & DR("Block") & "</b> Lot <b>" & DR("Lot") & "</b> is scheduled for turnover on  <b>" & pTODate & "</b>.<br /> ")
                        TextMessage.Append(" You’re warmly invited to visit the unit at <b>" & IIf(pTime <> "", pTime, "-") & "</b> to witness your client’s turnover. <br /><br /> ")
                        TextMessage.Append(" Looking forward to seeing you there! <br /><br /> ")
                        TextMessage.Append(" Best Regards,<br /><br /> ")
                        TextMessage.Append(" Calmar Land - Customer Service Team<br /><br /> ")
                        TextMessage.Append(" NOTE: This is a system generated email, do not reply.</html></body>")

                        'create connection
                        Dim SqlConn As New SqlClient.SqlConnection
                        Dim SqlCmd As New SqlCommand
                        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                        SqlCmd.CommandTimeout = 1500
                        SqlCmd.Connection = SqlConn
                        SqlCmd.CommandType = CommandType.StoredProcedure
                        SqlCmd.CommandText = "New_SMS"
                        SqlCmd.Parameters.AddWithValue("@pTblFrom", "Seller")
                        SqlCmd.Parameters.AddWithValue("@pTblCode", DR("AcctNo"))
                        SqlCmd.Parameters.AddWithValue("@pName", DR("SellerName"))
                        SqlCmd.Parameters.AddWithValue("@pMobileNo", DR("Cellphone"))
                        SqlCmd.Parameters.AddWithValue("@pSMS", TextMessage.ToString)
                        SqlCmd.Parameters.AddWithValue("@pSendBy", "system")
                        'create connection

                        'execute procedure
                        SqlConn.Open()
                        SqlCmd.ExecuteNonQuery()
                        SqlConn.Close()
                        'execute procedure

                    End If

                    RecordList.Add(New With {.oReturn = "Success"})

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

End Class