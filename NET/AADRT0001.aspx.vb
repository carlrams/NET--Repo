Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Threading.Tasks
Imports System.Windows
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Ajax.Utilities

Public Class AADRT0001
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim FormCode As String = "AADRT0001"

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

        'load page
        If IsPostBack = False Then

            'create new folder
            If Directory.Exists(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/")) = False Then
                Directory.CreateDirectory(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
            End If
            'create new folder

            'remove file within the folder
            Dim RptFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
            Try
                Dim file As FileInfo
                For Each file In RptFile.GetFiles()
                    file.Delete()
                Next
            Catch ex As Exception
                ' Optional: Log error
            End Try
            'remove file within the folder

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/AADRT0001.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/AADRT0001.rdlc"))
            'copy template report

            'content
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
            'content
        End If
        'load page

    End Sub

#End Region


End Class