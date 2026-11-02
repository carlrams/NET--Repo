Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities

Public Class SLS010000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "iis"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SLS010000")
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
            bindAgentMasterlist()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindAgentMasterlist()

        'get agent list
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].agent_code [AgentCode] ")
        Query.Append("   ,(dbo.ProperCase([A].fullname)) [Fullname] ")
        Query.Append("   ,isnull([A].tin, '-') [TIN] ")
        Query.Append("   ,isnull([A].email, '-') [Email] ")
        Query.Append("   ,isnull([A].remarks, '-') ")
        Query.Append("from ")
        Query.Append("   agent [A] ")
        Query.Append("where ")
        Query.Append("   [A].last_name <> 'Direct' ")
        'get agent list

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("TIN"))
        dtable.Columns.Add(New DataColumn("Email"))
        dtable.Columns.Add(New DataColumn("Remarks"))
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
                    'If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".PNG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPE") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe"
                    'ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPEG") Then
                    '    SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg"
                    'Else
                    '    SlrImg = "Assets/media/avatars/blank.png"
                    'End If
                    'SlrImg = "Assets/media/avatars/blank.png"

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvAgents.DataSource = dtable
        gvAgents.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvAgents.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvAgents.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvAgents.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvAgents.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

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

#Region "Button"

    Protected Sub lbtnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnSubmit.Click

        'validate record
        If inpFirstName.Value = "" Then
            Alert("error", "Firstname field cannot be empty!")
            'ElseIf inpLastName.Value = "" Then
            '    Alert("error", "Lastname field cannot be empty!")
            'ElseIf tbxPersonalEmail.Text = "" Then
            '    Alert("error", "Personal email field cannot be empty!")
            'ElseIf inpAddress.Value = "" Then
            '    Alert("error", "Address field cannot be empty!")
            'ElseIf inpTIN.Value = "" Then
            '    Alert("error", "TIN field cannot be empty!")
        Else

            'hide button
            lbtn01DeleteOk.Visible = False
            lbtn01SaveOk.Visible = False
            'hide button

            'display modal
            lbl01ConfirmMessageDialogBox.Text = "Save record?"
            lbtn01SaveOk.Visible = True
            mdlDialogBox.Update()
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDialogBox').modal('show');$('#ContentPlaceHolder1_mdlAddAgent').modal('hide');</script>", False)
            'display modal

        End If

    End Sub

    Protected Sub lbtn01SaveOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01SaveOk.Click

        'hide modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDialogBox').modal('hide');</script>", False)
        'hide modal

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SL_NewAgent"
        SqlCmd.Parameters.AddWithValue("@pAgentCode", "MN0000000000")
        SqlCmd.Parameters.AddWithValue("@pFirstName", inpFirstName.Value)
        SqlCmd.Parameters.AddWithValue("@pMiddleName", inpMiddleName.Value)
        SqlCmd.Parameters.AddWithValue("@pLastName", inpLastName.Value)
        SqlCmd.Parameters.AddWithValue("@pPersonalEmail", tbxPersonalEmail.Text)
        SqlCmd.Parameters.AddWithValue("@pStreetAddress", "")
        SqlCmd.Parameters.AddWithValue("@pProvince", "")
        SqlCmd.Parameters.AddWithValue("@pTown", "")
        SqlCmd.Parameters.AddWithValue("@pTIN", inpTIN.Value)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        Dim oMessage As New SqlClient.SqlParameter("@oMessage", SqlDbType.NVarChar, 1000)
        oMessage.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oMessage)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        Dim scriptFail As String = "Swal.fire({ title: 'Invalid!', text: 'Email already exist', icon: 'error', confirmButtonText: 'OK' });"
        Dim scriptSuccess As String = "Swal.fire({ title: 'Success!', text: 'Seller successfully created.', icon: 'success', confirmButtonText: 'OK' });"
        If oMessage.Value.ToString <> "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SweetAlert", scriptFail, True)
            bindAgentMasterlist()
        Else
            'success alert
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SweetAlert", scriptSuccess, True)
            'success alert

            'display record
            'checkUserAccess()
            bindAgentMasterlist()
            'display record
        End If

    End Sub

    Protected Sub lbtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnSave.Click

        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SL_EditAgent"
        SqlCmd.Parameters.AddWithValue("@pAgentCode", tbxAgentCodeDtl1.Value)
        SqlCmd.Parameters.AddWithValue("@pFirstName", tbxAgentFName1.Text)
        SqlCmd.Parameters.AddWithValue("@pMiddleName", tbxAgentMName1.Text)
        SqlCmd.Parameters.AddWithValue("@pLastName", tbxAgentLName1.Text)
        SqlCmd.Parameters.AddWithValue("@pPersonalEmail", tbxAgentEmail1.Text)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        Dim oMessage As New SqlClient.SqlParameter("@oMessage", SqlDbType.NVarChar, 1000)
        oMessage.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oMessage)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        Dim scriptFail As String = "Swal.fire({ title: 'Invalid!', text: 'Email already exist', icon: 'error', confirmButtonText: 'OK' });"
        Dim scriptSuccess As String = "Swal.fire({ title: 'Success!', text: 'Agent successfully updated.', icon: 'success', confirmButtonText: 'OK' });"
        If oMessage.Value.ToString <> "" Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SweetAlert", scriptFail, True)
            bindAgentMasterlist()
        Else
            'success alert
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SweetAlert", scriptSuccess, True)
            'success alert

            'display record
            bindAgentMasterlist()
            'display record

        End If

    End Sub

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
                Query.Append("if 'SLS010000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS010000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SLS010000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS010000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SLS010000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS010000' and Save_ = 1) ")
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

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

End Class