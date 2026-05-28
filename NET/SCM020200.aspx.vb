Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IdentityModel.Protocols.WSTrust
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Security.Policy
Imports System.Threading.Tasks
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.[Shared].Json
Imports CrystalDecisions.Web
Imports Microsoft.Ajax.Utilities

Public Class SCM020200
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    'variable
    Dim FRMCode As String = "SCM020000"
    'variable

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

        'active account / menu
        Master.setActiveMenu("APP", FRMCode)
        'active account / menu

        'load page
        If IsPostBack = False Then
            'param
            hdnMode.Value = Me.Page.RouteData.Values("Mode")
            hdnID.Value = Me.Page.RouteData.Values("ID")
            hdnPrevID.Value = IIf(hdnMode.Value = "ADD", "", hdnID.Value)
            'param
        End If
        'load page

    End Sub

#End Region

End Class