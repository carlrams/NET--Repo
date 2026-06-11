Imports System.Data.SqlClient

Public Class ACC010200
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
        Master.setActiveMenu("APP", "ACC010200")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'display record
            bindInfo()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

#End Region

#Region "Profile"

    Function bindInfo()

        'set value
        tbxEmail.Text = ""
        tbxUsername.Text = ""
        tbxCurrentPassword.Text = ""
        tbxNewPassword.Text = ""
        'set value

        'display
        upnlChange.Update()
        'display

    End Function

    Protected Sub lbtnSave_Click(ByVal sender As Object, e As EventArgs)

        If tbxCurrentPassword.Text = "" Or tbxNewPassword.Text = "" Then
            Alert("error", "Some fields are missing!")
            Exit Sub
        End If

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
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

        'display
        upnlChange.Update()
        'display

    End Sub

#End Region

End Class