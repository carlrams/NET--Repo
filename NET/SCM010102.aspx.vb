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
Imports System.Reflection.Emit
Imports System.Web.Configuration
Imports System.Web.ModelBinding

#Region "Module"
Module GlobalStorageContent1
    Public emailContent As String
End Module
#End Region

Public Class SCM010102
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    'cookies

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

        If IsPostBack = False Then
            'param
            hdnMode.Value = Me.Page.RouteData.Values("Mode")
            hdnID.Value = Me.Page.RouteData.Values("ID")
            hdnPrevID.Value = IIf(hdnMode.Value = "ADD", "", hdnID.Value)
            'param
        End If

    End Sub
#End Region

End Class