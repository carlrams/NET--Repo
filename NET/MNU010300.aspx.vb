Imports System.Data.SqlClient

Public Class MNU010300
    Inherits System.Web.UI.Page

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

#Region "Button"

    Private Sub lbtnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnChange.Click
        If tbxEmail.Text = "" Or tbxUsername.Text = "" Or tbxCurrentPassword.Text = "" Or tbxNewPassword.Text = "" Then
            Alert("error", "Please fill-up the following fields!")
            Exit Sub
        End If

        If tbxEmail.Text = "" Then Exit Sub
        If tbxUsername.Text = "" Then Exit Sub
        If tbxCurrentPassword.Text = "" Then Exit Sub
        If tbxNewPassword.Text = "" Then Exit Sub

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Change"
        sqlCmd.Parameters.AddWithValue("@pEmail", Trim(tbxEmail.Text))
        sqlCmd.Parameters.AddWithValue("@pUserName", Trim(tbxUsername.Text))
        sqlCmd.Parameters.AddWithValue("@pCurrentPassword", Trim(tbxCurrentPassword.Text))
        sqlCmd.Parameters.AddWithValue("@pNewPassword", Trim(tbxNewPassword.Text))
        Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
        oMsg.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oMsg)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        If oMsg.Value.ToString <> "" Then
            Alert("error", oMsg.Value.ToString)
        Else
            tbxEmail.Text = ""
            tbxUsername.Text = ""
            tbxCurrentPassword.Text = ""
            tbxNewPassword.Text = ""
            Alert("success", "Password successfully change.")
        End If
    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

#End Region

End Class