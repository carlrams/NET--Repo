Imports System.ComponentModel.DataAnnotations
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Public Class SLS020000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "iis"
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SLS020000")
        'active account / menu

        'create variable
        Dim Msg As String = Validate("Access", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        'load page
        If IsPostBack = False Then

            'display record
            'checkUserAccess()
            bindForApproval()
            bindApproved()
            bindRejected()
            bindCounter()
            bindUserStatsBarChart()
            'display record
        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApprove.Click

        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SL_Approved"
        SqlCmd.Parameters.AddWithValue("@pAgentCode", tbxAgentCode.Value)
        SqlCmd.Parameters.AddWithValue("@pEmail", tbxEmail.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        Dim capitalized As New CultureInfo("en-US")
        Dim textInfo As TextInfo = capitalized.TextInfo
        Dim name As String = tbxFirstName.Value
        Dim seller As String = textInfo.ToTitleCase(name)

        Dim eMailContent As New StringBuilder
        eMailContent.Append("<style>html,body { padding: 0; margin:0; }</style> ")
        eMailContent.Append("<div style='font-family: Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7'>")
        eMailContent.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse:collapse;margin:0 auto; padding:0; max-width:600px'>")
        eMailContent.Append("    <tbody>")
        eMailContent.Append("        <tr>")
        eMailContent.Append("            <td align='center' valign='center' style='text-align:center; padding: 40px'>")
        eMailContent.Append("                <a href='#'>")
        eMailContent.Append("                    <img alt='Logo' src='https://raw.githubusercontent.com/ronivangithub/sl-icon/main/seller-portal-icon-img.png' />")
        eMailContent.Append("                </a>")
        eMailContent.Append("            </td>")
        eMailContent.Append("        </tr>")
        eMailContent.Append("        <tr>")
        eMailContent.Append("            <td align='left' valign='center'>")
        eMailContent.Append("                <div style='text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px'>")
        eMailContent.Append("                <div style='padding-bottom: 30px; font-size: 17px;'>")
        eMailContent.Append("                    <strong>Hello <span style='cursor: pointer;' onmouseover='this.style.color='#009EF7' onmouseout='this.style.color='#000'''>" & name & "," & "</span></strong>")
        eMailContent.Append("                </div>")
        eMailContent.Append("                <div style='padding-bottom: 30px;'>We are delighted to inform that your account has been successfully approved and verified.")
        eMailContent.Append("                </div>")
        eMailContent.Append("                <div style='padding-bottom: 30px;'>As part of our security measures, we verified your account to ensure the safety and authenticity of all our users. This process involved:<br>
                                                <strong>1. Email Verification:</strong> Confirming your email address to ensure you have access to your account.<br>
                                                <strong>2. Identity Confirmation:</strong> Checking the information provided during registration for accuracy.</div> ")
        eMailContent.Append("                <div style='padding-bottom: 30px;'>To access your account, please click the link below: ")
        eMailContent.Append("                <div style='padding-top: 20px; text-align:center;'>
                                                <a href='http://sellersportal.calmarland.com:809/SLL000001' rel='noopener' style='text-decoration:none;display:inline-block;text-align: center;padding:0.75575rem 1.3rem;font-size:0.925rem;line-height:1.5;border-radius:0.35rem;color:#ffffff;background-color:#009EF7;border:0px;margin-right:0.75rem!important;font-weight:600!important;outline:none!important;vertical-align:middle' target='_blank'>Seller's Portal</a>
                                             </div> ")
        eMailContent.Append("                <div style='padding-top: 20px;'>For more information, you can reach us at <a href='#' rel='noopener' target='_blank' style='text-decoration:none;color: #009EF7'>email@yahoo.com</a>. </div> ")
        eMailContent.Append("               </div> ")
        eMailContent.Append("                <div style='padding-bottom: 10px'>Kind regards,")
        eMailContent.Append("                <br>CDLC Team.")
        eMailContent.Append("                    <tr>")
        eMailContent.Append("                        <td align='center' valign='center' style='font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;'>")
        eMailContent.Append("                            <div style='display: flex; justify-content: center; flex-wrap: wrap; padding: 5px;'>")
        eMailContent.Append("                                <div style='display: flex; justify-content: center;'>")
        eMailContent.Append("                                <span style='font-weight: bold; margin: 5px; border-style: none;'>2023 ©</span><img src='https://calmarland.net/Resources/logo-single.png' height='25' width='25'><span style='color: gray; font-weight: bold; margin: 5px;'>   CIIS 2023.08.04</span>")
        eMailContent.Append("                                </div>")
        eMailContent.Append("                            </div>")
        eMailContent.Append("                        </td>")
        eMailContent.Append("                    </tr></br></div>")
        eMailContent.Append("                </div>")
        eMailContent.Append("            </td>")
        eMailContent.Append("        </tr>")
        eMailContent.Append("        </tbody>")
        eMailContent.Append("    </table>")
        eMailContent.Append("</div>")

        'send email
        Dim Email As String = tbxEmail.Value
        If Email <> "" Then
            Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
            Dim mail As MailMessage
            Dim body As String
            smtp.Credentials = New NetworkCredential("ciissystems@calmarland.com", "M5ilp5ssw0rd")
            smtp.Host = "mail.calmarland.com"
            smtp.Port = 587
            mail = New MailMessage()
            mail.From = New MailAddress("ciissystems@calmarland.com")
            mail.To.Add(Email)
            mail.Subject = "Notice of User Account for Seller's Portal"
            mail.IsBodyHtml = True
            mail.Body = eMailContent.ToString
            smtp.Send(mail)
            mail.Dispose()
        End If

        'display record
        bindForApproval()
        bindApproved()
        bindRejected()
        bindCounter()
        ClientScript.RegisterStartupScript(Me.GetType(), "reload", "window.location.reload();", True)
        'diplay record
        Exit Sub

    End Sub

    Protected Sub btnRevert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRevert.Click

        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SL_Revert"
        SqlCmd.Parameters.AddWithValue("@pAgentCode", tbxRvtAgentCode.Value)
        SqlCmd.Parameters.AddWithValue("@pEmail", tbxRvtEmail.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'display record
        bindCounter()
        bindForApproval()
        bindApproved()
        bindRejected()
        ClientScript.RegisterStartupScript(Me.GetType(), "reload", "window.location.reload();", True)
        'diplay record
        Exit Sub

    End Sub

    Protected Sub btnReject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReject.Click

        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SL_Rejected"
        SqlCmd.Parameters.AddWithValue("@pAgentCode", tbxAgentCode.Value)
        SqlCmd.Parameters.AddWithValue("@pEmail", tbxEmail.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'Dim capitalized As New CultureInfo("en-US")
        'Dim textInfo As TextInfo = capitalized.TextInfo
        'Dim name As String = tbxFirstName.Value
        'Dim seller As String = textInfo.ToTitleCase(name)

        'Dim eMailContent As New StringBuilder
        'eMailContent.Append("<style>html,body { padding: 0; margin:0; }</style> ")
        'eMailContent.Append("<div style='font-family: Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7'>")
        'eMailContent.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse:collapse;margin:0 auto; padding:0; max-width:600px'>")
        'eMailContent.Append("    <tbody>")
        'eMailContent.Append("        <tr>")
        'eMailContent.Append("            <td align='center' valign='center' style='text-align:center; padding: 40px'>")
        'eMailContent.Append("                <a href='#'>")
        'eMailContent.Append("                    <img alt='Logo' src='https://raw.githubusercontent.com/ronivangithub/sl-icon/main/seller-portal-icon-img.png' />")
        'eMailContent.Append("                </a>")
        'eMailContent.Append("            </td>")
        'eMailContent.Append("        </tr>")
        'eMailContent.Append("        <tr>")
        'eMailContent.Append("            <td align='left' valign='center'>")
        'eMailContent.Append("                <div style='text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px'>")
        'eMailContent.Append("                <div style='padding-bottom: 30px; font-size: 17px;'>")
        'eMailContent.Append("                    <strong>Hello <span style='cursor: pointer;' onmouseover='this.style.color='#009EF7' onmouseout='this.style.color='#000'''>" & name & "," & "</span></strong>")
        'eMailContent.Append("                </div>")
        'eMailContent.Append("                <div style='padding-bottom: 30px;'>Thank you for the recent attempt to create an account on Seller's Portal. However, we regret to inform you that your account creation request has been rejected. ")
        'eMailContent.Append("                </div>")
        'eMailContent.Append("                <div style='padding-bottom: 30px;'>After a careful review of the information provided, our team determined that the credentials submitted did not meet our validation criteria. As a result, we are unable to approve your account this time.<br></div> ")
        'eMailContent.Append("                <div style='padding-bottom: 30px;'>If you believe this decision was made in error, feel free to contact us at <a href='#' rel='noopener' target='_blank' style='text-decoration:none;color: #009EF7'>email@yahoo.com</a>. Please ensure that any future submissions meet all the necessary requirements. ")
        'eMailContent.Append("                <div style='padding-top: 20px;'>We appreciate your understanding and cooperation.</div> ")
        'eMailContent.Append("                <div style='padding-bottom: 10px'>Kind regards,")
        'eMailContent.Append("                <br>CDLC Team.")
        'eMailContent.Append("                    <tr>")
        'eMailContent.Append("                        <td align='center' valign='center' style='font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;'>")
        'eMailContent.Append("                            <div style='display: flex; justify-content: center; flex-wrap: wrap; padding: 5px;'>")
        'eMailContent.Append("                                <div style='display: flex; justify-content: center;'>")
        'eMailContent.Append("                                <span style='font-weight: bold; margin: 5px; border-style: none;'>2023 ©</span><img src='https://calmarland.net/Resources/logo-single.png' height='25' width='25'><span style='color: gray; font-weight: bold; margin: 5px;'>   CIIS 2023.08.04</span>")
        'eMailContent.Append("                                </div>")
        'eMailContent.Append("                            </div>")
        'eMailContent.Append("                        </td>")
        'eMailContent.Append("                    </tr></br></div>")
        'eMailContent.Append("                </div>")
        'eMailContent.Append("            </td>")
        'eMailContent.Append("        </tr>")
        'eMailContent.Append("        </tbody>")
        'eMailContent.Append("    </table>")
        'eMailContent.Append("</div>")

        ''send email
        'Dim Email As String = tbxEmail.Value
        'If Email <> "" Then
        '    Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
        '    Dim mail As MailMessage
        '    Dim body As String
        '    smtp.Credentials = New NetworkCredential("ciissystems@calmarland.com", "M5ilp5ssw0rd")
        '    smtp.Host = "mail.calmarland.com"
        '    smtp.Port = 587
        '    mail = New MailMessage()
        '    mail.From = New MailAddress("ciissystems@calmarland.com")
        '    mail.To.Add(Email)
        '    mail.Subject = "Seller's Portal Account Creation Attempt - Rejected"
        '    mail.IsBodyHtml = True
        '    mail.Body = eMailContent.ToString
        '    smtp.Send(mail)
        '    mail.Dispose()
        'End If

        'display record
        bindCounter()
        bindForApproval()
        bindApproved()
        bindRejected()
        ClientScript.RegisterStartupScript(Me.GetType(), "reload", "window.location.reload();", True)
        'diplay record
        Exit Sub

    End Sub

#End Region

#Region "General"

    Function bindForApproval()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [SellerCode] ")
        Query.Append("   ,(dbo.ProperCase([A].fullname)) [SellerName] ")
        Query.Append("   ,[A].sl_username [Email] ")
        Query.Append("   ,[A].sl_type [Type] ")
        Query.Append("   ,[A].sl_group [Group] ")
        Query.Append("   ,[A].acct_status [Status] ")
        Query.Append("   ,(case when [A].created_date is null then '-' else CONVERT (varchar, [A].created_date, 107) end) [CreatedDate] ")
        Query.Append("   ,(case when [A].created_date is null then '-' else RIGHT(CONVERT(varchar, [A].created_date, 100), 7) end) [CreatedTime] ")
        Query.Append("from ")
        Query.Append("   slp_user_register [A] ")
        Query.Append("where ")
        Query.Append("   [A].acct_status = 'For Approval' ")
        Query.Append("order by ")
        Query.Append("   [A].created_date desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Email"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Group"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("DateCreated"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'Dim SlrImg As String
                    'If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".PNG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".png"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".JPG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".jpg"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".JPE") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".jpe"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".JPEG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("SellerCode") & "/Profile/" & DR("SellerCode") & ".jpeg"
                    'Else
                    '    SlrImg = "Assets/media/avatars/blank.png"
                    'End If

                    'If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png")) = True Then
                    '    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png"
                    'ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg")) = True Then
                    '    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg"
                    'Else
                    '    SlrImg = "Assets/media/avatars/blank.png"
                    'End If
                    Dim FormattedStatus As String
                    FormattedStatus = "<span class='fw-bolder text-info fs-6'> " & DR.GetString(5) & " </span>"
                    Dim FormattedDate As String
                    FormattedDate = DR.GetString(6) & " | " & DR.GetString(7)

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), FormattedStatus, FormattedDate}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvApproval.DataSource = dtable
        gvApproval.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvApproval.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvApproval.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvApproval.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvApproval.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindApproved()

        'get approved sellers
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [Link] ")
        Query.Append("   ,(dbo.ProperCase([A].fullname)) [Name] ")
        Query.Append("   ,[A].sl_username [Email] ")
        Query.Append("   ,[A].sl_type [Type] ")
        Query.Append("   ,[A].sl_group [Group] ")
        Query.Append("   ,[A].acct_status [Status] ")
        Query.Append("   ,(dbo.ProperCase([B].fullname)) [Approver] ")
        Query.Append("   ,(case when [A].approved_date is null then '-' else CONVERT (varchar, [A].approved_date, 107) end) [DateApproved] ")
        Query.Append("   ,(case when [A].approved_date is null then '-' else RIGHT(CONVERT(varchar, [A].approved_date, 100), 7) end) [ApprovedTime] ")
        Query.Append("from ")
        Query.Append("   slp_user_register [A] ")
        Query.Append("   left join employee [B] on [B].emp_no = [A].approved_by ")
        Query.Append("where ")
        Query.Append("   [A].acct_status = 'Approved' ")
        Query.Append("order by ")
        Query.Append("   [A].approved_date desc ")
        'get approved sellers

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Email"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Group"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Approver"))
        dtable.Columns.Add(New DataColumn("DateApproved"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim AgentCode As String = DR.GetString(0)

                    'Dim SlrImg As String
                    'If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".PNG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".png"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".JPG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpg"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".JPE") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpe"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".JPEG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpeg"
                    'Else
                    '    SlrImg = "Assets/media/avatars/blank.png"
                    'End If
                    'If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png")) = True Then
                    '    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png"
                    'ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg")) = True Then
                    '    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg"
                    'Else
                    '    SlrImg = "Assets/media/avatars/blank.png"
                    'End If
                    Dim FormattedStatus As String
                    If AgentCode = "MN2024050014" Then
                        FormattedStatus = "<span class='fw-bolder text-primary fs-6'> " & "Programmer's Test Acct." & " </span>"
                    Else
                        FormattedStatus = "<span class='fw-bolder text-primary fs-6'> " & DR.GetString(5) & " </span>"
                    End If
                    Dim FormattedDate As String
                    FormattedDate = DR.GetString(7) & " | " & DR.GetString(8)

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), FormattedStatus, DR.GetString(6), FormattedDate}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvApproved.DataSource = dtable
        gvApproved.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvApproved.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvApproved.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvApproved.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvApproved.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindRejected()

        'get approved sellers
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [Link] ")
        Query.Append("   ,(dbo.ProperCase([A].fullname)) [SellerName] ")
        Query.Append("   ,[A].sl_username [Email] ")
        Query.Append("   ,[A].sl_type [Type] ")
        Query.Append("   ,[A].sl_group [Group] ")
        Query.Append("   ,[A].acct_status [Status] ")
        Query.Append("   ,(dbo.ProperCase([B].fullname)) [Approver] ")
        Query.Append("   ,(case when [A].rejected_date is null then '-' else CONVERT (varchar, [A].rejected_date, 107) end) [DateDenied] ")
        Query.Append("   ,(case when [A].rejected_date is null then '-' else RIGHT(CONVERT(varchar, [A].rejected_date, 100), 7) end) [RejectedTime] ")
        Query.Append("from ")
        Query.Append("   slp_user_register [A] ")
        Query.Append("   left join employee [B] on [B].emp_no = [A].rejected_by ")
        Query.Append("where ")
        Query.Append("   [A].acct_status = 'Rejected' ")
        Query.Append("order by ")
        Query.Append("   [A].rejected_date desc ")
        'get approved sellers

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Email"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Group"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Approver"))
        dtable.Columns.Add(New DataColumn("DateDenied"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim SlrImg As String
                    If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".PNG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".png"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".JPG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpg"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".JPE") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpe"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".JPEG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("Link") & "/Profile/" & DR("Link") & ".jpeg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    'If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png")) = True Then
                    '    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png"
                    'ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg")) = True Then
                    '    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg"
                    'Else
                    '    SlrImg = "Assets/media/avatars/blank.png"
                    'End If
                    Dim FormattedStatus As String
                    FormattedStatus = "<span class='fw-bolder text-danger fs-6'> " & DR.GetString(5) & " </span>"
                    Dim FormattedDate As String
                    FormattedDate = DR.GetString(7) & " | " & DR.GetString(8)

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), FormattedStatus, DR.GetString(6), FormattedDate}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvDenied.DataSource = dtable
        gvDenied.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvDenied.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvDenied.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvDenied.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvDenied.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindCounter()

        'get the count of sellers
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull((select count(1) from slp_user_register where acct_status = 'For Approval'), 0) [ForApproval] ")
        Query.Append("  ,isnull((select count(1) from slp_user_register where acct_status = 'Approved'), 0) [Approved] ")
        Query.Append("  ,isnull((select count(1) from slp_user_register where acct_status = 'Rejected'), 0) [Rejected] ")
        'get the count of sellers

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblApprovalCount.Text = DR.GetInt32(0)
                    lblApprovedCount.Text = DR.GetInt32(1)
                    lblRejectedCount.Text = DR.GetInt32(2)

                    Dim ForApproval As Int32 = If(Not DR.IsDBNull(0), DR.GetInt32(0), 0)
                    Dim Approved As Int32 = If(Not DR.IsDBNull(1), DR.GetInt32(1), 0)
                    Dim Rejected As Int32 = If(Not DR.IsDBNull(2), DR.GetInt32(2), 0)

                    spnForApproval.Attributes.Add("data-kt-countup-value", ForApproval)
                    spnApproved.Attributes.Add("data-kt-countup-value", Approved)
                    spnRejected.Attributes.Add("data-kt-countup-value", Rejected)

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        mdlSellerDtl.Update()
        upnlNavBar.Update()
        'display data

    End Function

    Function bindUserStatsBarChart()

        'get sold units per seller
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].sl_type ")
        Query.Append("  ,count([A].sl_type) [Users] ")
        Query.Append("from  ")
        Query.Append("  slp_user_register [A]  ")
        Query.Append("group by ")
        Query.Append("  [A].sl_type ")
        'get sold units per seller 

        ltrlBarUserData.Text = ""
        ltrlBarUserGroupName.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarUserGroupName.Text = "" Then
                        ltrlBarUserGroupName.Text = DR.GetString(0)
                    Else
                        ltrlBarUserGroupName.Text = ltrlBarUserGroupName.Text & "," & DR.GetString(0)
                    End If

                    If ltrlBarUserData.Text = "" Then
                        ltrlBarUserData.Text = DR.GetInt32(1)
                    Else
                        ltrlBarUserData.Text = ltrlBarUserData.Text & "," & DR.GetInt32(1)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        mdlSellerDtl.Update()
        'diplay record

    End Function

    Public Function CheckIfRemoteFileExists(ByVal url As String) As Boolean
        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "HEAD"
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                If response.StatusCode = HttpStatusCode.OK Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.ProtocolError Then
                Dim httpResponse As HttpWebResponse = CType(ex.Response, HttpWebResponse)
                If httpResponse.StatusCode = HttpStatusCode.NotFound Then
                    Return False
                End If
            End If
            Return False
        End Try
    End Function

#End Region

#Region "Validation"

    'Private Sub checkUserAccess()

    '    'retrieve user information from the cookie
    '    Dim Validator As String = CIIS_UserInfo.Values("CIIS_EmpCode")

    '    'validate user credentials
    '    If validateUserAccess(Validator) = False Then
    '        Response.Redirect("DSB000001")
    '    End If

    'End Sub

    'Private Function validateUserAccess(Validator As String) As Boolean

    '    'get agent details
    '    Dim Query As New StringBuilder
    '    Query.Append("if (select [A].emp_no from employee [A] where [A].emp_no = '" & Validator & "') in ('2010000024', 'MN2021080000', 'MN2024030004', 'MN2023100001') ")
    '    Query.Append("begin ")
    '    Query.Append("  select 'Approved' ")
    '    Query.Append("end ")
    '    Query.Append("else ")
    '    Query.Append("begin ")
    '    Query.Append("  select 'Denied' ")
    '    Query.Append("end ")
    '    'get agent details

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()
    '                Dim Access As String = DR.GetString(0)

    '                If Access = "Approved" Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            End While
    '            DR.Close()
    '            ConStr.Close()
    '        End Using
    '    End Using
    '    'read record

    'End Function

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
                Query.Append("if 'SLS020000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS020000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SLS020000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS020000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SLS020000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS020000' and Save_ = 1) ")
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
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
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