Imports System.Web
Imports System.Web.Services

Public Class FRM000063HND
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
    Dim calmardblive As String = "calmardblive"
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim pFunction = context.Request("pFunction")
            Dim pFormCode = context.Request("pFormCode")
            Dim pType = context.Request("pType")
            Dim json As String
            'general parameter

            If pFormCode = "FRM000063" And pType = "Get - Record" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Record(pID)

            End If

            'general - context
            context.Response.ContentType = "application/json"
            context.Response.Write(json)
            'general - context

        Catch ex As Exception
            'nothing
        End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Function Get_Record(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        'get query

    End Function

End Class