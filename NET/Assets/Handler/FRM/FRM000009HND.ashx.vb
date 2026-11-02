Imports System.ComponentModel.Design
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Pipes
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net.PeerToPeer.Collaboration
Imports System.Reflection.Emit
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.Remoting.Contexts
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Principal
Imports System.Web
Imports System.Web.ApplicationServices
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Windows.Forms
Imports System.Windows.Forms.LinkLabel
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft
Imports Microsoft.Ajax.Utilities
Imports Microsoft.AspNet.SignalR.Infrastructure
Imports Microsoft.Identity.Client
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports OfficeOpenXml.ConditionalFormatting.Contracts
Public Class FRM000009HND
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

            If pFormCode = "FRM000009" And pType = "Get Record - Estimate" Then

                Dim pCategory = context.Request("pCategory")
                json = Me.Get_Record_Estimate(pCategory)

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

    Function Get_Record_Estimate(pCategory)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  CECode ")
        Query.Append("  ,Title ")
        Query.Append("from ")
        Query.Append("  Trxn_CEHdr ")
        Query.Append("where ")
        Query.Append("  Post = 1 ")
        Query.Append("  and Rvrs = 0 ")
        Query.Append("  and Category = @pCategory ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Bullet As New StringBuilder
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""fn01GetEstimate('" & DR("CECode") & "', '" & DR("Title") & "'); return false;"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Title") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("CECode") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

End Class