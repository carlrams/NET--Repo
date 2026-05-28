Public Class FIN090100
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    'variable
    Dim FRMCode As String = "FIN090000"
    'variable

#Region "Form"

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
            hdnDate.Value = Me.Page.RouteData.Values("Date").ToString().Insert(2, "/").Insert(5, "/")
            hdnAcctNo.Value = Me.Page.RouteData.Values("AcctNo")
            hdnPrevID.Value = IIf(hdnMode.Value = "ADD", "", hdnID.Value)
            'param
        End If
        'load page

    End Sub

#End Region

End Class