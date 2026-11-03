Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports CrystalDecisions.Web
Imports Microsoft.Ajax.Utilities
Imports System.Security.Policy
Imports System.ComponentModel
Imports Microsoft.AspNet.SignalR.Hubs
Imports Microsoft.Extensions.Configuration
Imports System.Web.Services
Imports Newtonsoft.Json.Linq
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Web.Services.Description
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Diagnostics.Contracts

#Region "Module"
Module GlobalStorage
    Public emailContent As String
End Module
#End Region

Public Class SCM010100
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

#End Region

End Class