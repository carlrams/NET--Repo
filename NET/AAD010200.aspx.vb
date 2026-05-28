Imports System.Data.SqlClient
Imports System.IO

Public Class DownloadableDocs
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

            lbl01Date.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")
            bind01File()

        End If

    End Sub

#End Region

#Region "Modal Upload"

    Protected Sub lbtn01UploadDocuments_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01UploadDocuments.Click

        'create variable
        Dim Msg As String = Validate("DownloadablesAccess", "Add", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Docs').modal('show');</script>", False)

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Title_ As String, ByVal Message_ As String, ByVal Alert_ As String)

        Dim script As String = "Swal.fire({title: '" & Title_ & "', text: '" & Message_ & "', icon: '" & Alert_ & "', confirmButtonColor: '#279852'});"
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "SweetAlert", script, True)

    End Function

    Protected Sub RefreshGVDocs(ByVal sender As Object, ByVal e As EventArgs)

        bind01File()

    End Sub

    Protected Sub DeleteDocs(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim Msg As String = Validate("DownloadablesAccess", "Delete", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'get file
        Dim FilePath As String = "C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\" & CType(sender, LinkButton).CommandArgument
        File.Delete(FilePath)
        'remove file

        'fill new data
        bind01File()
        'fill new data

        'alert
        Alert("Success!", "File remove successfully.", "success")
        'alert

    End Sub

    Protected Sub DownloadDocs(ByVal sender As Object, ByVal e As EventArgs)

        'download file
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("content-disposition", "attachment; filename=" & CType(sender, LinkButton).CommandArgument)
        Response.WriteFile("C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\" & CType(sender, LinkButton).CommandArgument)
        Response.Flush()
        Response.End()
        'download file

    End Sub

    Function bind01File()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\") Then

            'set folder
            Dim objDir As New DirectoryInfo("C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\")
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
            gv01Docs.DataSource = dataView
            gv01Docs.DataBind()
            'bind datatable

            'display data
            upnlDocs.Update()
            'display data

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gv01Docs.DataSource = dataView
            gv01Docs.DataBind()
            'bind datatable

            'display data
            upnlDocs.Update()
            'display data

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv01Docs.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv01Docs.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv01Docs.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "DownloadablesAccess" Then
            If Type = "Add" Then
                Query.Append("if 'AAD010200' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010200' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if 'AAD010200' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010200' and Delete_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If

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