Imports System.Web.Configuration

Public Class SCM150100
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    'variable
    Dim FRMCode As String = "SCM150000"
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
            hdnID.Value = Me.Page.RouteData.Values("ID").ToString.Replace("No", "-")
            hdnPrevID.Value = IIf(hdnMode.Value = "ADD", "", hdnID.Value)
            'param
        End If
        'load page

    End Sub

#End Region

End Class