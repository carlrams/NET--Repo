Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports System.Web.Configuration
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.UI.HtmlControl
Imports AjaxControlToolkit
Imports Azure
Imports Azure.Core
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports Microsoft.Ajax.Utilities
Imports Microsoft.Identity.Client.Cache
Imports Newtonsoft.Json
Imports OfficeOpenXml
Imports OfficeOpenXml.Drawing.Chart

Public Class SCM060100
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    'variable
    Dim FRMCode As String = "SCM060000"
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