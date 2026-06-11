Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail

Public Class MNU010400
    Inherits System.Web.UI.Page

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

#Region "Button"

    Private Sub lbtnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSend.Click
        pnlAleart.Visible = False
        lblMessage.Text = ""

        If tbxEmail.Text = "" Or tbxUsername.Text = "" Then
            Alert("Reset", "danger", "Please fill-up the following fields!")
        End If

        If tbxEmail.Text = "" Then Exit Sub
        If tbxUsername.Text = "" Then Exit Sub

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Reset"
        sqlCmd.Parameters.AddWithValue("@pEmail", Trim(tbxEmail.Text))
        sqlCmd.Parameters.AddWithValue("@pUserName", Trim(tbxUsername.Text))
        Dim oName As New SqlClient.SqlParameter("@oName", SqlDbType.NVarChar, 1000)
        oName.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oName)
        Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
        oMsg.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oMsg)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        If oMsg.Value.ToString <> "" Then
            Alert("Reset", "danger", oMsg.Value.ToString)
        Else
            'email
            Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
            Dim mail As MailMessage
            Dim body As String
            smtp.Credentials = New NetworkCredential("ciissystems@calmarland.com", "M5ilp5ssw0rd")
            smtp.Host = "mail.calmarland.com"
            smtp.Port = 587
            mail = New MailMessage()
            mail.From = New MailAddress("ciissystems@calmarland.com")
            mail.To.Add(tbxEmail.Text)
            mail.Subject = "Your new CIIS Password"
            body = "Dear Ms./Mr. " & oName.Value.ToString & vbCrLf.ToString & vbCrLf.ToString
            body = body & "You may now log-in to the CLDC CIIS website using the information below:" & vbCrLf.ToString & vbCrLf.ToString
            body = body & "     Username : " & tbxUsername.Text & vbCrLf.ToString
            body = body & "     Password : " & "ciis" & vbCrLf.ToString & vbCrLf.ToString
            body = body & "Should you encounter any problems accessing your account, please contact any CIIS staff for assistance." & vbCrLf.ToString & vbCrLf.ToString
            body = body & "This is a system-generated e-mail. Please do not reply."
            mail.Body = body
            smtp.Send(mail)
            mail.Dispose()

            'reset
            tbxEmail.Text = ""
            tbxUsername.Text = ""

            'alert
            Alert("Reset", "success", "Password successfully change.")
        End If
    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Group_ As String, ByVal Alert_ As String, ByVal Message_ As String)
        If Group_ = "Reset" Then
            pnlAleart.Attributes.Add("class", "alert alert-" & Alert_ & " bg-" & Alert_ & " d-flex flex-column flex-sm-row p-5 mb-10")
            pnlAleart.Visible = True
            lblMessage.Text = Message_
            upReset.Update()
        End If
    End Function

#End Region

End Class