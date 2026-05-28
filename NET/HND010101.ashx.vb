Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities
Imports Microsoft.AspNet.SignalR

Public Class HND010101
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

#Region "Page"
    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            context.Response.ContentType = "text\plain"
            Dim FormCode = context.Request("FormCode")
            Dim ID = context.Request("ID")
            Dim Type = context.Request("Type")

            If Type = "Project" Then

                'create new folder
                If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/")) = False Then
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/"))
                End If
                'If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\") = False Then
                '    Directory.CreateDirectory("C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\")
                'End If
                'create new folder

                Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/")
                'Dim FilesPath As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\"
                Dim Files As String()
                For Each s As String In context.Request.Files
                    Dim File As HttpPostedFile = context.Request.Files(s)
                    Dim FileSizeInBytes As Integer = File.ContentLength
                    Dim FileName As String = File.FileName
                    Dim FileExtension As String = File.ContentType
                    If Not String.IsNullOrEmpty(FileName) Then
                        FileExtension = System.IO.Path.GetExtension(FileName)
                        Files = System.IO.Directory.GetFiles(FilesPath)

                        FileName = Replace(FileName, "@", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "^", "")
                        FileName = Replace(FileName, "`", "")
                        FileName = Replace(FileName, "|", "")
                        FileName = Replace(FileName, "~", "")
                        FileName = Replace(FileName, "\", "")
                        FileName = Replace(FileName, "\", "")
                        FileName = Replace(FileName, "!", "")
                        FileName = Replace(FileName, "#", "")
                        FileName = Replace(FileName, "$", "")
                        FileName = Replace(FileName, "%", "")
                        FileName = Replace(FileName, "&", "")
                        FileName = Replace(FileName, "*", "")
                        FileName = Replace(FileName, "(", "")
                        FileName = Replace(FileName, ")", "")
                        FileName = Replace(FileName, "+", "")
                        FileName = Replace(FileName, "=", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "]", "")
                        FileName = Replace(FileName, "{", "")
                        FileName = Replace(FileName, "}", "")
                        FileName = Replace(FileName, "'", "")
                        FileName = Replace(FileName, "<", "")
                        FileName = Replace(FileName, ">", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, "?", "")
                        FileName = Replace(FileName, ":", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, "ñ", "n")
                        FileName = Replace(FileName, "Ñ", "N")

                        Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/") & FileName
                        'Dim Path As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\" & FileName
                        File.SaveAs(Path)

                        'create connection
                        Dim SqlConn01 As New SqlClient.SqlConnection
                        Dim SqlCmd01 As New SqlCommand
                        SqlConn01.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                        SqlCmd01.CommandTimeout = 1500
                        SqlCmd01.Connection = SqlConn01
                        SqlCmd01.CommandType = CommandType.StoredProcedure
                        SqlCmd01.CommandText = "New_File"
                        SqlCmd01.Parameters.AddWithValue("@pFormCode", FormCode)
                        SqlCmd01.Parameters.AddWithValue("@pID", ID)
                        SqlCmd01.Parameters.AddWithValue("@pType", "Uploaded a file:")
                        SqlCmd01.Parameters.AddWithValue("@pDescription", FileName)
                        SqlCmd01.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                        'create connection

                        'execute procedure
                        SqlConn01.Open()
                        SqlCmd01.ExecuteNonQuery()
                        SqlConn01.Close()
                        'execute procedure

                    End If
                Next

            ElseIf Type = "Batch" Then
                Dim Codes() As String = ID.Split("®"c)

                For Each Code As String In Codes
                    'create new folder
                    'If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Batch/" & FormCode & "/" & Code & "/")) = False Then
                    '    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Batch/" & FormCode & "/" & Code & "/"))
                    'End If
                    If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\Batch\" & FormCode & "\" & Code & "\") = False Then
                        Directory.CreateDirectory("C:\inetpub\ciis.net\Assets\Upload\Contracts\Batch\" & FormCode & "\" & Code & "\")
                    End If
                    'create new folder

                    'Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Batch/" & FormCode & "/" & Code & "/")
                    Dim FilesPath As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\Batch\" & FormCode & "\" & Code & "\"
                    Dim Files As String()
                    For Each s As String In context.Request.Files
                        Dim File As HttpPostedFile = context.Request.Files(s)
                        Dim FileSizeInBytes As Integer = File.ContentLength
                        Dim FileName As String = File.FileName
                        Dim FileExtension As String = File.ContentType
                        If Not String.IsNullOrEmpty(FileName) Then
                            FileExtension = System.IO.Path.GetExtension(FileName)
                            Files = System.IO.Directory.GetFiles(FilesPath)

                            FileName = Replace(FileName, "@", "")
                            FileName = Replace(FileName, "[", "")
                            FileName = Replace(FileName, "^", "")
                            FileName = Replace(FileName, "`", "")
                            FileName = Replace(FileName, "|", "")
                            FileName = Replace(FileName, "~", "")
                            FileName = Replace(FileName, "\", "")
                            FileName = Replace(FileName, "\", "")
                            FileName = Replace(FileName, "!", "")
                            FileName = Replace(FileName, "#", "")
                            FileName = Replace(FileName, "$", "")
                            FileName = Replace(FileName, "%", "")
                            FileName = Replace(FileName, "&", "")
                            FileName = Replace(FileName, "*", "")
                            FileName = Replace(FileName, "(", "")
                            FileName = Replace(FileName, ")", "")
                            FileName = Replace(FileName, "+", "")
                            FileName = Replace(FileName, "=", "")
                            FileName = Replace(FileName, "[", "")
                            FileName = Replace(FileName, "]", "")
                            FileName = Replace(FileName, "{", "")
                            FileName = Replace(FileName, "}", "")
                            FileName = Replace(FileName, "'", "")
                            FileName = Replace(FileName, "<", "")
                            FileName = Replace(FileName, ">", "")
                            FileName = Replace(FileName, ",", "")
                            FileName = Replace(FileName, ",", "")
                            FileName = Replace(FileName, "?", "")
                            FileName = Replace(FileName, ":", "")
                            FileName = Replace(FileName, ";", "")
                            FileName = Replace(FileName, ";", "")
                            FileName = Replace(FileName, "ñ", "n")
                            FileName = Replace(FileName, "Ñ", "N")

                            'Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Batch/" & FormCode & "/" & Code & "/") & FileName
                            Dim Path As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\Batch\" & FormCode & "\" & Code & "\" & FileName
                            File.SaveAs(Path)

                        End If
                    Next
                Next

            ElseIf Type = "Notice" Then

                'create new folder
                If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Notice/" & FormCode & "/" & ID & "/")) = False Then
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Notice/" & FormCode & "/" & ID & "/"))
                End If
                'If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\") = False Then
                '    Directory.CreateDirectory("C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\")
                'End If
                'create new folder

                Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Notice/" & FormCode & "/" & ID & "/")
                'Dim FilesPath As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\"
                Dim Files As String()
                For Each s As String In context.Request.Files
                    Dim File As HttpPostedFile = context.Request.Files(s)
                    Dim FileSizeInBytes As Integer = File.ContentLength
                    Dim FileName As String = File.FileName
                    Dim FileExtension As String = File.ContentType
                    If Not String.IsNullOrEmpty(FileName) Then
                        FileExtension = System.IO.Path.GetExtension(FileName)
                        Files = System.IO.Directory.GetFiles(FilesPath)

                        FileName = Replace(FileName, "@", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "^", "")
                        FileName = Replace(FileName, "`", "")
                        FileName = Replace(FileName, "|", "")
                        FileName = Replace(FileName, "~", "")
                        FileName = Replace(FileName, "\", "")
                        FileName = Replace(FileName, "\", "")
                        FileName = Replace(FileName, "!", "")
                        FileName = Replace(FileName, "#", "")
                        FileName = Replace(FileName, "$", "")
                        FileName = Replace(FileName, "%", "")
                        FileName = Replace(FileName, "&", "")
                        FileName = Replace(FileName, "*", "")
                        FileName = Replace(FileName, "(", "")
                        FileName = Replace(FileName, ")", "")
                        FileName = Replace(FileName, "+", "")
                        FileName = Replace(FileName, "=", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "]", "")
                        FileName = Replace(FileName, "{", "")
                        FileName = Replace(FileName, "}", "")
                        FileName = Replace(FileName, "'", "")
                        FileName = Replace(FileName, "<", "")
                        FileName = Replace(FileName, ">", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, "?", "")
                        FileName = Replace(FileName, ":", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, "ñ", "n")
                        FileName = Replace(FileName, "Ñ", "N")

                        Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Notice/" & FormCode & "/" & ID & "/") & FileName
                        'Dim Path As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\" & FileName
                        File.SaveAs(Path)

                        'create connection
                        Dim SqlConn01 As New SqlClient.SqlConnection
                        Dim SqlCmd01 As New SqlCommand
                        SqlConn01.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                        SqlCmd01.CommandTimeout = 1500
                        SqlCmd01.Connection = SqlConn01
                        SqlCmd01.CommandType = CommandType.StoredProcedure
                        SqlCmd01.CommandText = "New_File"
                        SqlCmd01.Parameters.AddWithValue("@pFormCode", FormCode)
                        SqlCmd01.Parameters.AddWithValue("@pID", ID)
                        SqlCmd01.Parameters.AddWithValue("@pType", "Uploaded a notice to proceed file:")
                        SqlCmd01.Parameters.AddWithValue("@pDescription", FileName)
                        SqlCmd01.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                        'create connection

                        'execute procedure
                        SqlConn01.Open()
                        SqlCmd01.ExecuteNonQuery()
                        SqlConn01.Close()
                        'execute procedure

                    End If
                Next
            End If

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#End Region

End Class