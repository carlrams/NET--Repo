Imports System.Data.SqlClient

Public Class MNU010100
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_UserName As String
    Dim CIIS_LogStatus As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

#Region "Form"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'get user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")

        'load page
        If Not (Request.Cookies("CIIS_UserInfo")) Is Nothing Then
            Response.Redirect("DSB010000")
        End If
    End Sub

#End Region

#Region "Button"

    Private Sub btnSignIn_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignIn.ServerClick
        If tbxUsername.Text = "" Or tbxPassword.Text = "" Then
            Alert("error", "Please fill-up the following fields!")
            Exit Sub
        End If

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_SignIn"
        sqlCmd.Parameters.AddWithValue("@pUserName", Trim(tbxUsername.Text))
        sqlCmd.Parameters.AddWithValue("@pPassword", Trim(tbxPassword.Text))
        Dim oEmpCode As New SqlClient.SqlParameter("@oEmpCode", SqlDbType.NVarChar, 1000)
        oEmpCode.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oEmpCode)
        Dim oFirstName As New SqlClient.SqlParameter("@oFirstName", SqlDbType.NVarChar, 1000)
        oFirstName.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oFirstName)
        Dim oLastName As New SqlClient.SqlParameter("@oLastName", SqlDbType.NVarChar, 1000)
        oLastName.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oLastName)
        Dim oDepartment As New SqlClient.SqlParameter("@oDepartment", SqlDbType.NVarChar, 1000)
        oDepartment.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oDepartment)
        Dim oSection As New SqlClient.SqlParameter("@oSection", SqlDbType.NVarChar, 1000)
        oSection.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oSection)
        Dim oJobDesc As New SqlClient.SqlParameter("@oJobDesc", SqlDbType.NVarChar, 1000)
        oJobDesc.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oJobDesc)
        Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
        oMsg.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oMsg)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        If oMsg.Value.ToString <> "" Then
            Alert("error", oMsg.Value.ToString)
        Else
            CIIS_UserInfo = New HttpCookie("CIIS_UserInfo")
            CIIS_UserInfo("CIIS_EmpCode") = oEmpCode.Value.ToString
            CIIS_UserInfo("CIIS_FirstName") = oFirstName.Value.ToString
            CIIS_UserInfo("CIIS_LastName") = oLastName.Value.ToString
            CIIS_UserInfo("CIIS_Department") = oDepartment.Value.ToString
            CIIS_UserInfo("CIIS_Section") = oSection.Value.ToString
            CIIS_UserInfo("CIIS_JobDesc") = oJobDesc.Value.ToString
            If cbxRemember.Checked = True Then CIIS_UserInfo.Expires = Date.Now.AddDays(30)
            If cbxRemember.Checked = False Then CIIS_UserInfo.Expires = DateAdd(DateInterval.Hour, 24, Date.Now)
            Response.Cookies.Add(CIIS_UserInfo)
            Response.Redirect("DSB010000")
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