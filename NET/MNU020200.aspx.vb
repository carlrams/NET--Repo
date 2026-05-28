Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic.ApplicationServices

Public Class MNU020200
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim View As String
    Dim File As String
    'cookies

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'user info
        Try
            CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            View = HttpUtility.UrlDecode(Request.QueryString("View"))
            File = EncryptionHelper.DecryptString(View)
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'load page
        If IsPostBack = False Then
            'validate
            If File.Contains("png") Or File.Contains("PNG") Then
                'view file
                Dim embed As String = "<object data='{0}' type='application/pdf' width='100%' height='100%'></object>"
                ltEmbed.Text = String.Format(embed, ResolveUrl(File))
                'view file
            ElseIf File.Contains(".jpg") Or File.Contains(".jpeg") Or File.Contains(".jpe") Or File.Contains(".jfif") Or File.Contains(".JPG") Or File.Contains(".JPEG") Or File.Contains(".JPE") Or File.Contains(".JFIF") Then
                'view file
                Dim embed As String = "<object data='{0}' type='application/pdf' width='100%' height='100%'></object>"
                ltEmbed.Text = String.Format(embed, ResolveUrl(File))
                'view file
            ElseIf File.Contains("pdf") Or File.Contains("PDF") Then
                'view file
                Dim embed As String = "<object data='{0}' type='application/pdf' width='100%' height='100%'></object>"
                ltEmbed.Text = String.Format(embed, ResolveUrl(File))
                'view file
            Else
                'download
                Response.ContentType = ContentType
                Response.AppendHeader("Content-Disposition", ("attachment; filename=" + Path.GetFileName(File)))
                Response.WriteFile(File)
                Response.End()
                Page.ClientScript.RegisterOnSubmitStatement(Me.GetType, "closePage", "window.onunload = CloseWindow();")
                'download
            End If
            'validate
        End If
        'load page
    End Sub

#End Region

End Class