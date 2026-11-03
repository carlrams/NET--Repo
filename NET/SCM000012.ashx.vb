Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Web.Services
Imports Microsoft.Ajax.Utilities
Imports Microsoft.SqlServer

Public Class SCM000012
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'user info
        CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        Try
            context.Response.ContentType = "text\plain"
            Dim FormCode = context.Request("FormCode")
            Dim ID = context.Request("ID")
            Dim Temp = context.Request("Temp")

            If Temp = "Batch" Then

                Dim seperatedVal As String() = ID.Split("©"c)
                Dim List As New List(Of String)

                For Each value As String In seperatedVal
                    List.Add(value)
                Next

                For Each value As String In List

                    'create new folder
                    If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Batch/" & value & "/")) = False Then
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Batch/" & value & "/"))
                    End If
                    'create new folder

                    Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Batch/" & value & "/")
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

                            Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Batch/" & value & "/") & FileName
                            File.SaveAs(Path)

                        End If

                    Next

                Next

            ElseIf Temp = "Single" Then

                'create new folder
                If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Single/" & ID & "/")) = False Then
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Single/" & ID & "/"))
                End If
                'create new folder

                Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Single/" & ID & "/")
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

                        Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/Single/" & ID & "/") & FileName
                        File.SaveAs(Path)

                    End If

                Next

            ElseIf Temp = "Contractor" And FormCode = "" Then

                'create new folder
                'If Directory.Exists(HttpContext.Current.Server.MapPath("~\Assets\Upload\" & ID & "\")) = False Then
                '    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~\Assets\Upload\" & ID & "\"))
                'End If
                If Directory.Exists("C:\inetpub\contractor\Assets\Upload\" & ID & "\") = False Then
                    Directory.CreateDirectory("C:\inetpub\contractor\Assets\Upload\" & ID & "\")
                End If
                'create new folder

                'Dim FilesPath As String = HttpContext.Current.Server.MapPath("~\Assets\Upload\" & ID & "\")
                Dim FilesPath As String = "C:\inetpub\contractor\Assets\Upload\" & ID & "\"
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

                        'Dim Path As String = HttpContext.Current.Server.MapPath("~\Assets\Upload\" & ID & "\") & FileName
                        Dim Path As String = "C:\inetpub\contractor\Assets\Upload\" & ID & "\" & FileName
                        File.SaveAs(Path)

                    End If
                Next

            ElseIf Temp = "Project" And FormCode <> "" Then

                'create new folder
                'If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/")) = False Then
                '    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/"))
                'End If
                If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\") = False Then
                    Directory.CreateDirectory("C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\")
                End If
                'create new folder

                'Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/")
                Dim FilesPath As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\"
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

                        'Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/" & FormCode & "/" & ID & "/") & FileName
                        Dim Path As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\" & FormCode & "\" & ID & "\" & FileName
                        File.SaveAs(Path)

                    End If
                Next

            ElseIf Temp = "BatchProject" And FormCode <> "" Then
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

            ElseIf Temp = "Notice" And FormCode <> "" And ID <> "" Then

                'create new folder
                'If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")) = False Then
                '    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/"))
                'End If
                If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\") = False Then
                    Directory.CreateDirectory("C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\")
                End If
                'create new folder

                'Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")
                Dim FilesPath As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\"
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

                        'Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/") & FileName
                        Dim Path As String = "C:\inetpub\ciis.net\Assets\Upload\Contracts\Notice\" & FormCode & "\" & ID & "\" & FileName
                        File.SaveAs(Path)

                    End If
                Next

            Else

                'create new folder
                If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")) = False Then
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/"))
                End If
                'create new folder

                Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")
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

                        Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/") & FileName
                        File.SaveAs(Path)

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

End Class