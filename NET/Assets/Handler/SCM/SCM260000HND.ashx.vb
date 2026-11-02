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

Public Class SCM260000HND
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

            If pFormCode = "SCM260000" And pType = "Get - Record" Then

                json = Me.Get_Record()

            ElseIf pFormCode = "SCM260000" And pType = "Get - Record : Redraw" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Record_Redraw(pID)

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

    Function Get_Record()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  WCode [ID] ")
        Query.Append("  ,Description [Description] ")
        Query.Append("  ,isnull(lock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("  Mstr_Work ")
        Query.Append("order by ")
        Query.Append("  Description ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('SCM260100-DTL-" & DR("ID").ToString.Replace("-", "No") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>"
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function Get_Record_Redraw(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  WCode [ID] ")
        Query.Append("  ,Description [Description] ")
        Query.Append("  ,isnull(lock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("  Mstr_Work ")
        Query.Append("where ")
        Query.Append("  WCode = @pID ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('SCM260100-DTL-" & DR("ID").ToString.Replace("-", "No") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>"
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record 

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

End Class