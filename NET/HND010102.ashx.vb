Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Web.Services
Imports Microsoft.Ajax.Utilities
Imports Microsoft.Owin
Imports Microsoft.SqlServer

Public Class HND010102
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

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'user info
        If HttpContext.Current.Request.Cookies("CIIS_UserInfo") IsNot Nothing Then
            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info
        End If
        'user info

        Try
            context.Response.ContentType = "text/plain"

            Dim ID = context.Request("ID")

            'create new folder
            'If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & ID & "/")) = False Then
            '    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & ID & "/"))
            'End If
            If Directory.Exists(HttpContext.Current.Server.MapPath("C:\inetpub\ciis.net\Assets\Upload\" & ID & "\")) = False Then
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("C:\inetpub\ciis.net\Assets\Upload\" & ID & "\"))
            End If
            'create new folder

            'Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & ID & "/")
            Dim FilesPath As String = HttpContext.Current.Server.MapPath("C:\inetpub\ciis.net\Assets\Upload\" & ID & "\")
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
                    FileName = Replace(FileName, "/", "")
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

                    'Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & ID & "/") & FileName
                    Dim Path As String = HttpContext.Current.Server.MapPath("C:\inetpub\ciis.net\Assets\Upload\" & ID & "\") & FileName
                    File.SaveAs(Path)

                End If
            Next

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