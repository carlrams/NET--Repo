Imports System.Data.SqlClient
Imports System.IO

Public Class DocsStorage
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "iis"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "AAD010000")
        'active account / menu

        If IsPostBack = False Then

            lblDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")

            bind01Documentary()
            bind01Client()

        End If

    End Sub

#End Region

#Region "Modal Upload"

    Protected Sub RefreshGVFiles(ByVal sender As Object, ByVal e As EventArgs)

        bind01ClientDocumentary()

    End Sub

    Private Sub gv01Documentary_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv01Documentary.RowCommand

        'create variable
        Dim Msg As String = Validate("DocumentaryAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("	 ,[A].DateCreated ")
        Query.Append("from ")
        Query.Append("	 bp_documentary [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where [A].AcctNo = '" & e.CommandArgument & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01Title.Text = DR.GetString(0) & " - Documentary"
                    lbl01AcctNo.Text = DR.GetString(0)
                    lbl01Name.Text = DR.GetString(1)
                    lbl01DateCreated.Text = Format(DR.GetDateTime(2), "MM/dd/yyyy")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        bind01ClientDocumentary()
        mdl01UploadDocuments.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01UploadDocuments').modal('show');</script>", False)
        'display data

    End Sub

#End Region

#Region "Modal Add"

    Protected Sub lbtn01Create_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Create.Click

        'create variable
        Dim Msg As String = Validate("DocumentaryAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_NewDocumentary"
        SqlCmd.Parameters.AddWithValue("@pAcctNo", ddl01Client.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'alert
        Alert("Success!", "Record saved successfully!", "success")
        'alert

        'clear fields
        ddl01Client.SelectedValue = ""
        'clear fields

        'hide modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Documentary').modal('hide');</script>", False)
        'hide modal

        'display record
        bind01Documentary()
        'display record

        Exit Sub

    End Sub

    Protected Sub lbtnCreateDocumentary_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnCreateDocumentary.Click

        'create variable
        Dim Msg As String = Validate("DocumentaryAccess", "Add", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Documentary').modal('show');</script>", False)

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Title_ As String, ByVal Message_ As String, ByVal Alert_ As String)

        Dim script As String = "Swal.fire({title: '" & Title_ & "', text: '" & Message_ & "', icon: '" & Alert_ & "', confirmButtonColor: '#279852'});"
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "SweetAlert", script, True)

    End Function

    Protected Sub DeleteDocs(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim Msg As String = Validate("DocumentaryAccess", "Delete", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'remove file
        Dim FilePath As String = "C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lbl01AcctNo.Text & "\" & "Documentary" & "\" & CType(sender, LinkButton).CommandArgument
        File.Delete(FilePath)
        'remove file

        'fill new data 
        bind01ClientDocumentary()
        'fill new data

        'success alert
        Dim script As String = "Swal.fire({title: 'Success!', text: 'File remove successfully!', icon: 'success', confirmButtonColor: '#279852'});"
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "SweetAlert", script, True)
        'success alert

    End Sub

    Protected Sub DownloadDocs(ByVal sender As Object, ByVal e As EventArgs)

        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("content-disposition", "attachment; filename=" & CType(sender, LinkButton).CommandArgument)
        Response.WriteFile("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lbl01AcctNo.Text & "\" & "Documentary" & "\" & CType(sender, LinkButton).CommandArgument)
        Response.Flush()
        Response.End()

    End Sub

    Function bind01ClientDocumentary()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lbl01AcctNo.Text & "\" & "Documentary" & "\") Then

            'set folder
            Dim objDir As New DirectoryInfo("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lbl01AcctNo.Text & "\" & "Documentary" & "\")
            Dim listfiles As FileInfo() = objDir.GetFiles()
            Dim DefaultFiles As FileInfo() = (From file In listfiles Order By file.CreationTime Select file).ToArray()
            'set folder

            'read file
            For Each File In DefaultFiles

                'create variable
                Dim Icon As String
                'create variable

                'set icon for specific file
                If File.Name.Contains(".png") Or File.Name.Contains(".PNG") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".jpg") Or File.Name.Contains(".jpeg") Or File.Name.Contains(".jpe") Or File.Name.Contains(".jfif") Or File.Name.Contains(".JPG") Or File.Name.Contains(".JPEG") Or File.Name.Contains(".JPE") Or File.Name.Contains(".JFIF") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".txt") Or File.Name.Contains(".TXT") Then
                    Icon = "<i class='las la-file-alt fs-2qx'></i>"
                ElseIf File.Name.Contains(".xlsx") Or File.Name.Contains(".xls") Or File.Name.Contains(".XLSX") Or File.Name.Contains(".XLS") Then
                    Icon = "<i class='las la-file-excel fs-2qx'></i>"
                ElseIf File.Name.Contains(".docx") Or File.Name.Contains(".doc") Or File.Name.Contains(".DOCX") Or File.Name.Contains(".DOC") Then
                    Icon = "<i class='las la-file-word fs-2qx'></i>"
                ElseIf File.Name.Contains(".pptx") Or File.Name.Contains(".ppt") Or File.Name.Contains(".PPTX") Or File.Name.Contains(".PPT") Then
                    Icon = "<i class='las la-file-powerpoint fs-2qx'></i>"
                ElseIf File.Name.Contains(".pdf") Or File.Name.Contains(".PDF") Then
                    Icon = "<i class='las la-file-pdf fs-2qx'></i>"
                End If
                'set icon for specific file

                'add file
                Dim current_RowValues As Object() = {Icon, File.Name, Format(File.CreationTime, "MM/dd/yyyy hh:mm tt")}
                Dim current_dRow As DataRow
                current_dRow = dtable.Rows.Add(current_RowValues)
                dtable.AcceptChanges()
                'add file

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gv02Files.DataSource = dataView
            gv02Files.DataBind()
            'bind datatable

            'display data
            mdl01UploadDocuments.Update()
            'display data

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gv02Files.DataSource = dataView
            gv02Files.DataBind()
            'bind datatable

            'display data
            mdl01UploadDocuments.Update()
            'display data

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv02Files.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv02Files.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv02Files.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bind01Client()

        'get
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Select a user' [Name]")
        Query.Append("  ,'' [Order]")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].AcctNo [Code] ")
        Query.Append("  ,[A].Fullname [Name] ")
        Query.Append("  ,[A].Fullname [Order] ")
        Query.Append("from ")
        Query.Append("  bp_user [A] ")
        Query.Append("  left join calmardbLive.dbo.ICR_Buyers [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append(" [A].hasDocsStorage = 0 ")
        Query.Append("order by ")
        Query.Append(" [Order] ")
        'get 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Client.DataSource = DT
        ddl01Client.DataValueField = "Code"
        ddl01Client.DataTextField = "Name"
        ddl01Client.DataBind()
        'fill data

    End Function

    Function bind01Documentary()

        'get for submission
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    AcctNo ")
        Query.Append("	 ,DateCreated ")
        Query.Append("from ")
        Query.Append("	 bp_documentary ")
        Query.Append("order by ")
        Query.Append("   DateCreated ")
        'get for submission

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("DateCreated"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'add new row
                    Dim NewRowValues As Object() = {DR.GetString(0), Format(DR.GetDateTime(1), "MM/dd/yyyy")}
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
        gv01Documentary.DataSource = dtable
        gv01Documentary.DataBind()
        'bind datatable 

        'display data
        upnlDocumentary.Update()
        'display data

    End Function

#End Region

#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        'access
        If Group_ = "DocumentaryAccess" Then
            If Type = "Add" Then
                Query.Append("if 'AAD010100' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010100' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'AAD010100' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010100' and Save_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if 'AAD010100' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010100' and Delete_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'access

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
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