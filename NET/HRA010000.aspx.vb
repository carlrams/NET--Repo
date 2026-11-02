Imports System.Data.SqlClient
Imports System.Web.Services.Description

Public Class HRA010000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "HRA010000"

    Dim AssignToDT As New DataTable

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "HRA010000")
        'active account / menu

        'create variable
        Dim Msg As String = Access(CIIS_EmpCode, FormCode, "View")
        'create variable

        'validate access
        If Msg <> "1" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        'load page
        If IsPostBack = False Then

            'load
            bindRecord()
            'load

        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Protected Sub lbtnRefresh_Click(ByVal sender As Object, e As EventArgs)
        bindRecord()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg = Access(CIIS_EmpCode, FormCode, "Add")
        If Msg = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'clear record
        tbxAdd_Description.Text = ""
        tbxAdd_Abbr.Text = ""
        cbxAdd_DayOff.Checked = False
        cbxAdd_OpenTime.Checked = False
        tbxAdd_FrstStart.Value = ""
        tbxAdd_FrstEnd.Value = ""
        tbxAdd_ScndStart.Value = ""
        tbxAdd_ScndEnd.Value = ""
        'clear record

        'update modal
        mdlAdd.Update()
        'update modal

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlAdd').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnAdd_Ok_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg = Access(CIIS_EmpCode, FormCode, "Add")
        If Msg = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        If tbxAdd_Description.Text = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf tbxAdd_Abbr.Text = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxAdd_DayOff.Checked = False And tbxAdd_FrstStart.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxAdd_DayOff.Checked = False And tbxAdd_FrstEnd.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxAdd_DayOff.Checked = False And tbxAdd_ScndStart.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxAdd_DayOff.Checked = False And tbxAdd_ScndEnd.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        End If

        Dim Query As New StringBuilder
        Query.Append("declare @Code nvarchar(13) ")
        Query.Append("exec New_Code 'Mstr_Shift','MN',@Code output ")
        Query.Append("INSERT INTO [dbo].[hr_shift] ")
        Query.Append("   ([s_code] ")
        Query.Append("   ,[description] ")
        Query.Append("   ,[abbr] ")
        Query.Append("   ,[DayOff]  ")
        Query.Append("   ,[OpenTime] ")
        Query.Append("   ,[frst_start] ")
        Query.Append("   ,[frst_end] ")
        Query.Append("   ,[scnd_start] ")
        Query.Append("   ,[scnd_end] ")
        Query.Append("   ,[created_by] ")
        Query.Append("   ,[created_date] ")
        Query.Append("   ,[updated_by] ")
        Query.Append("   ,[updated_date] ")
        Query.Append("   ,[lock_by] ")
        Query.Append("   ,[lock_date] ")
        Query.Append("   ,[lock]) ")
        Query.Append("values ")
        Query.Append("   (@Code ")
        Query.Append("   ,'" & tbxAdd_Description.Text & "' ")
        Query.Append("   ,'" & tbxAdd_Abbr.Text & "' ")
        Query.Append("   ," & IIf(cbxAdd_DayOff.Checked = True, 1, 0) & " ")
        Query.Append("   ," & IIf(cbxAdd_OpenTime.Checked = True, 1, 0) & " ")
        Query.Append("   ," & IIf(cbxAdd_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxAdd_FrstStart.Value & "'") & " ")
        Query.Append("   ," & IIf(cbxAdd_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxAdd_FrstEnd.Value & "'") & " ")
        Query.Append("   ," & IIf(cbxAdd_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxAdd_ScndStart.Value & "'") & " ")
        Query.Append("   ," & IIf(cbxAdd_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxAdd_ScndEnd.Value & "'") & " ")
        Query.Append("   ,'" & CIIS_EmpCode & "'")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & CIIS_EmpCode & "'")
        Query.Append("   ,getdate() ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0) ")
        'set query 

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.Text
        SqlCmd.CommandText = Query.ToString
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'fill record
        bindRecord()
        'fill record

        'clear record
        tbxAdd_Description.Text = ""
        tbxAdd_Abbr.Text = ""
        cbxAdd_DayOff.Checked = False
        cbxAdd_OpenTime.Checked = False
        tbxAdd_FrstStart.Value = ""
        tbxAdd_FrstEnd.Value = ""
        tbxAdd_ScndStart.Value = ""
        tbxAdd_ScndEnd.Value = ""
        'clear record

        'update modal
        mdlAdd.Update()
        'update modal

        'alert success
        Alert("success", "Record successfully added.", "")
        'alert success

    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Delete")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Delete")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDelete').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnDelete_Ok_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Delete")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Delete")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'create connection
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Del_Record"
        sqlCmd.Parameters.AddWithValue("@pTblName", "hr_shift")
        sqlCmd.Parameters.AddWithValue("@pTblCode", hfID.Value)
        'create connection

        'execute procedure
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'execute procedure

        'fill record
        bindRecord()
        'fill record

        'alert success
        Alert("success", "Record successfully removed.", "$('#ContentPlaceHolder1_mdlDelete').modal('hide');")
        'alert success

    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, e As EventArgs)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].s_code [ID] ")
        Query.Append("   ,[A].description [Title] ")
        Query.Append("   ,[A].abbr [Init] ")
        Query.Append("   ,[A].DayOff ")
        Query.Append("   ,[A].OpenTime ")
        Query.Append("   ,format([A].frst_start,'hh:mm tt') [AMIn] ")
        Query.Append("   ,format([A].frst_end,'hh:mm tt') [AMOut] ")
        Query.Append("   ,format([A].scnd_start,'hh:mm tt') [PMIn] ")
        Query.Append("   ,format([A].scnd_end,'hh:mm tt') [PMOut] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [PreparedBy] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("   hr_shift [A] ")
        Query.Append("   left join employee [B] on [A].updated_by = [B].emp_no ")
        Query.Append("   left join employee [C] on [A].lock_by = [C].emp_no  ")
        Query.Append("where ")
        Query.Append("   [A].s_code = '" & hfID.Value & "' ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    lblView_ID.Text = DR("ID")
                    lblView_Description.Text = DR("Title")
                    lblView_Abbr.Text = DR("Init")
                    cbxView_DayOff.Checked = IIf(DR("DayOff") = 1, True, False)
                    cbxView_OpenTime.Checked = IIf(DR("OpenTime") = 1, True, False)
                    lblView_FrstStart.Text = DR("AMIn")
                    lblView_FrstEnd.Text = DR("AMOut")
                    lblView_ScndStart.Text = DR("PMIn")
                    lblView_ScndEnd.Text = DR("PMOut")
                    lblView_PreparedBy.Text = DR("PreparedBy")
                    lblView_LockedBy.Text = DR("LockedBy")
                    'create varialble

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        mdlView.Update()
        'display

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlView').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnView_Edit_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Save")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Save")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].s_code [ID] ")
        Query.Append("   ,[A].description [Title] ")
        Query.Append("   ,[A].abbr [Init] ")
        Query.Append("   ,[A].DayOff ")
        Query.Append("   ,[A].OpenTime ")
        Query.Append("   ,format([A].frst_start,'hh:mm tt') [AMIn] ")
        Query.Append("   ,format([A].frst_end,'hh:mm tt') [AMOut] ")
        Query.Append("   ,format([A].scnd_start,'hh:mm tt') [PMIn] ")
        Query.Append("   ,format([A].scnd_end,'hh:mm tt') [PMOut] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [PreparedBy] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("   hr_shift [A] ")
        Query.Append("   left join employee [B] on [A].updated_by = [B].emp_no ")
        Query.Append("   left join employee [C] on [A].lock_by = [C].emp_no  ")
        Query.Append("where ")
        Query.Append("   [A].s_code = '" & hfID.Value & "' ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    tbxEdit_Description.Text = DR("Title")
                    tbxEdit_Abbr.Text = DR("Init")
                    cbxEdit_DayOff.Checked = IIf(DR("DayOff") = 1, True, False)
                    cbxEdit_OpenTime.Checked = IIf(DR("OpenTime") = 1, True, False)
                    tbxEdit_FrstStart.Value = DR("AMIn")
                    tbxEdit_FrstEnd.Value = DR("AMOut")
                    tbxEdit_ScndStart.Value = DR("PMIn")
                    tbxEdit_ScndEnd.Value = DR("PMOut")
                    'create varialble

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        mdlEdit.Update()
        'display

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlEdit').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Save")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Save")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].s_code [ID] ")
        Query.Append("   ,[A].description [Title] ")
        Query.Append("   ,[A].abbr [Init] ")
        Query.Append("   ,[A].DayOff ")
        Query.Append("   ,[A].OpenTime ")
        Query.Append("   ,format([A].frst_start,'hh:mm tt') [AMIn] ")
        Query.Append("   ,format([A].frst_end,'hh:mm tt') [AMOut] ")
        Query.Append("   ,format([A].scnd_start,'hh:mm tt') [PMIn] ")
        Query.Append("   ,format([A].scnd_end,'hh:mm tt') [PMOut] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [PreparedBy] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("   hr_shift [A] ")
        Query.Append("   left join employee [B] on [A].updated_by = [B].emp_no ")
        Query.Append("   left join employee [C] on [A].lock_by = [C].emp_no  ")
        Query.Append("where ")
        Query.Append("   [A].s_code = '" & hfID.Value & "' ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    tbxEdit_Description.Text = DR("Title")
                    tbxEdit_Abbr.Text = DR("Init")
                    cbxEdit_DayOff.Checked = IIf(DR("DayOff") = 1, True, False)
                    cbxEdit_OpenTime.Checked = IIf(DR("OpenTime") = 1, True, False)
                    tbxEdit_FrstStart.Value = DR("AMIn")
                    tbxEdit_FrstEnd.Value = DR("AMOut")
                    tbxEdit_ScndStart.Value = DR("PMIn")
                    tbxEdit_ScndEnd.Value = DR("PMOut")
                    'create varialble

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        mdlEdit.Update()
        'display

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlEdit').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnEdit_Ok_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Save")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Save")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        If tbxEdit_Description.Text = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf tbxEdit_Abbr.Text = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxEdit_DayOff.Checked = False And tbxEdit_FrstStart.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxEdit_DayOff.Checked = False And tbxEdit_FrstEnd.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxEdit_DayOff.Checked = False And tbxEdit_ScndStart.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf cbxEdit_DayOff.Checked = False And tbxEdit_ScndEnd.Value = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        End If

        Dim Query As New StringBuilder
        Query.Append("update hr_shift set ")
        Query.Append("   [description] = '" & tbxEdit_Description.Text & "' ")
        Query.Append("   ,[abbr] = '" & tbxEdit_Abbr.Text & "' ")
        Query.Append("   ,[DayOff] = " & IIf(cbxEdit_DayOff.Checked = True, 1, 0) & " ")
        Query.Append("   ,[OpenTime] = " & IIf(cbxEdit_OpenTime.Checked = True, 1, 0) & " ")
        Query.Append("   ,[frst_start] = " & IIf(cbxEdit_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxEdit_FrstStart.Value & "'") & " ")
        Query.Append("   ,[frst_end] = " & IIf(cbxEdit_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxEdit_FrstEnd.Value & "'") & " ")
        Query.Append("   ,[scnd_start] = " & IIf(cbxEdit_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxEdit_ScndStart.Value & "'") & " ")
        Query.Append("   ,[scnd_end] = " & IIf(cbxEdit_DayOff.Checked = True, "null", "'1900-01-01 ' + '" & tbxEdit_ScndEnd.Value & "'") & " ")
        Query.Append("   ,[updated_by] = '" & CIIS_EmpCode & "'")
        Query.Append("   ,[updated_date] = getdate() ")
        Query.Append("where ")
        Query.Append("   s_code = '" & hfID.Value & "' ")
        'set query 

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.Text
        SqlCmd.CommandText = Query.ToString
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'update progress
        For Each Row As GridViewRow In gvTask.Rows
            Dim ID As Label = gvTask.Rows(Row.RowIndex).FindControl("lblID")
            If ID.Text = hfID.Value Then
                'update
                Dim upnlTitle As UpdatePanel = gvTask.Rows(Row.RowIndex).FindControl("upnlTitle")
                Dim lblTitle As Label = gvTask.Rows(Row.RowIndex).FindControl("lblTitle")
                lblTitle.Text = tbxEdit_Description.Text
                upnlTitle.Update()
                'update
            End If
        Next
        'update progress

        'alert success
        Alert("success", "Record successfully saved.", "")
        'alert success

    End Sub

    Protected Sub btnLock_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Lock")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Lock")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'set value
        tbxLock_Password.Value = ""
        'set value

        'update modal
        mdlLock.Update()
        'update modal

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlLock').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnLock_Ok_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Lock")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Lock")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'password
        Dim Msg03 = CheckPassword(tbxLock_Password.Value)
        If Msg03 <> "" Then
            Alert("error", Msg03, "")
            Exit Sub
        End If
        'password

        'create connection
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Lock_Record"
        sqlCmd.Parameters.AddWithValue("@pTblName", "hr_shift")
        sqlCmd.Parameters.AddWithValue("@pTblCode", hfID.Value)
        sqlCmd.Parameters.AddWithValue("@pLockBy", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pLock", 1)
        'create connection

        'execute procedure
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'execute procedure

        'update progress
        For Each Row As GridViewRow In gvTask.Rows
            Dim ID As Label = gvTask.Rows(Row.RowIndex).FindControl("lblID")
            If ID.Text = hfID.Value Then
                'update
                Dim upnlStatus As UpdatePanel = gvTask.Rows(Row.RowIndex).FindControl("upnlStatus")
                Dim lblStatus As Label = gvTask.Rows(Row.RowIndex).FindControl("lblStatus")
                lblStatus.Text = "Locked"
                upnlStatus.Update()
                'update
            End If
        Next
        'update progress

        'alert success
        Alert("success", "Record successfully locked.", "$('#ContentPlaceHolder1_mdlLock').modal('hide');")
        'alert success

    End Sub

    Protected Sub btnUnlock_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Unlock")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Unlock")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'set value
        tbxUnlock_Password.Value = ""
        'set value

        'update modal
        mdlUnlock.Update()
        'update modal

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUnlock').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnUnlock_Ok_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Unlock")
        If Msg01 = "0" Then
            Alert("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate("hr_shift", hfID.Value, "Unlock")
        If Msg02 <> "" Then
            Alert("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'password
        Dim Msg03 = CheckPassword(tbxUnlock_Password.Value)
        If Msg03 <> "" Then
            Alert("error", Msg03, "")
            Exit Sub
        End If
        'password

        'create connection
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Lock_Record"
        sqlCmd.Parameters.AddWithValue("@pTblName", "hr_shift")
        sqlCmd.Parameters.AddWithValue("@pTblCode", hfID.Value)
        sqlCmd.Parameters.AddWithValue("@pLockBy", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pLock", 0)
        'create connection

        'execute procedure
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'execute procedure

        'update progress
        For Each Row As GridViewRow In gvTask.Rows
            Dim ID As Label = gvTask.Rows(Row.RowIndex).FindControl("lblID")
            If ID.Text = hfID.Value Then
                'update
                Dim upnlStatus As UpdatePanel = gvTask.Rows(Row.RowIndex).FindControl("upnlStatus")
                Dim lblStatus As Label = gvTask.Rows(Row.RowIndex).FindControl("lblStatus")
                lblStatus.Text = "-"
                upnlStatus.Update()
                'update
            End If
        Next
        'update progress

        'alert success
        Alert("success", "Record successfully unlocked.", "$('#ContentPlaceHolder1_mdlUnlock').modal('hide');")
        'alert success

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String, AdditionalScript As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & AdditionalScript & "Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function RenderDatatable()
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTask.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTask.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTask.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTask.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindRecord()

        'processing time
        System.Threading.Thread.Sleep(2000)
        'processing time

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   description [Title] ")
        Query.Append("   ,s_code [ID] ")
        Query.Append("   ,(case when lock = 1 then 'badge badge-lg badge-light-success' else '' end) [Badge] ")
        Query.Append("   ,(case when lock = 1 then 'Locked' else '-' end) [Status] ")
        Query.Append("from ")
        Query.Append("   hr_shift ")
        Query.Append("order by ")
        Query.Append("   description ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Badge"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Delete"))
        dtable.Columns.Add(New DataColumn("View"))
        dtable.Columns.Add(New DataColumn("Edit"))
        dtable.Columns.Add(New DataColumn("Lock_Display"))
        dtable.Columns.Add(New DataColumn("Lock"))
        dtable.Columns.Add(New DataColumn("Unlock_Display"))
        dtable.Columns.Add(New DataColumn("Unlock"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Badge As String = DR("Badge")
                    Dim Status As String = DR("Status")
                    Dim Delete As String = "Delete('" & DR("ID") & "')"
                    Dim View As String = "View('" & DR("ID") & "')"
                    Dim Edit As String = "Edit('" & DR("ID") & "')"
                    Dim Lock_Display As String = IIf(DR("Status") = "-", "", "style='display:none'")
                    Dim Lock As String = "Lock('" & DR("ID") & "')"
                    Dim Unlock_Display As String = IIf(DR("Status") = "Locked", "", "style='display:none'")
                    Dim Unlock As String = "Unlock('" & DR("ID") & "')"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Title, ID, Badge, Status, Delete, View, Edit, Lock_Display, Lock, Unlock_Display, Unlock}
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
        gvTask.EmptyDataText = "No data"
        gvTask.DataSource = dtable
        gvTask.DataBind()
        RenderDatatable()
        'bind datatable 

        'display
        upnlContent.Update()
        'display

    End Function

    Function Access(EmpCode, FormCode, Action)

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Restriction"
        sqlCmd.Parameters.AddWithValue("@pUserId", EmpCode)
        sqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
        sqlCmd.Parameters.AddWithValue("@pRes", Action)
        Dim oConf As New SqlClient.SqlParameter("@oConf", SqlDbType.NVarChar, 1000)
        oConf.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oConf)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        Return oConf.Value.ToString
    End Function

    Function Validate(TblName, TblCode, Type)
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Record"
        sqlCmd.Parameters.AddWithValue("@pTblName", "hr_shift")
        sqlCmd.Parameters.AddWithValue("@pTblCode", hfID.Value)
        sqlCmd.Parameters.AddWithValue("@pTblVal", "")
        sqlCmd.Parameters.AddWithValue("@pType", Type)
        Dim oAns As New SqlClient.SqlParameter("@oAns", SqlDbType.NVarChar, 1000)
        oAns.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oAns)
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        Return oAns.Value.ToString
    End Function

    Function CheckPassword(UserPassword)
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Password"
        sqlCmd.Parameters.AddWithValue("@pEmpCode", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pPassword", UserPassword)
        Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
        oMsg.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oMsg)
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        Return oMsg.Value.ToString
    End Function

#End Region

End Class