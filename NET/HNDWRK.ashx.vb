Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices

Public Class HNDWRK
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

#Region "Form"

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")
            'general parameter

            If FormCode = "WRK010000" And Type = "List-Subscribed" Then
                Dim json As String = Me.WRK010000_List_Subscribed()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf FormCode = "WRK010000" And Type = "List-Request" Then
                Dim json As String = Me.WRK010000_List_Request()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If

        Catch ex As Exception

        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#End Region

#Region "FRM010000"

    Function WRK010000_List_Subscribed()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[Type] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("	 ,(case when [DateRequired] < cast(getdate() as date) then 'Delay' ")
        Query.Append("	       when [DateRequired] = cast(getdate() as date) then 'Due' ")
        Query.Append("	       when [DateRequired] > cast(getdate() as date) then 'Within' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      'WRK010100-DTL-' + replace([A].wo_code,'#','No') [Link] ")
        Query.Append("      ,'assets/media/svg/apps/WRK010000.svg' [Icon] ")
        Query.Append("      ,[A].wo_code [ID] ")
        Query.Append("      ,[A].summary [Title] ")
        Query.Append("      ,[A].status [Type] ")
        Query.Append("      ,[A].date_end [DateRequired] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("   from ")
        Query.Append("	    oop_wo_dtl_monitor [C] ")
        Query.Append("	    left join oop_wo_hdr [A] on [C].wo_code = [A].wo_code ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Closed','Cancelled') ")
        Query.Append("      and [C].monitored_by = '" & CIIS_EmpCode & "') [A] ")
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
                    Dim ID As String = "<a href='" & DR("Link") & "'>" & DR("ID") & "</a>"
                    Dim Title As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px'><img alt='' class='w-100' src='" & DR("Icon") & "' /></div>&nbsp" & DR("Title") & "</div>"
                    Dim RequestedBy As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"
                    RecordList.Add(New With {
                        .ID = ID,
                        .Title = Title,
                        .Type = DR("Type"),
                        .DateRequired = DR("DateRequired"),
                        .Status = DR("Status"),
                        .RequestedBy = RequestedBy
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

    Function WRK010000_List_Request()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[Type] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("	 ,(case when [DateRequired] < cast(getdate() as date) then 'Delay' ")
        Query.Append("	       when [DateRequired] = cast(getdate() as date) then 'Due' ")
        Query.Append("	       when [DateRequired] > cast(getdate() as date) then 'Within' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      'WRK010100-DTL-' + replace([A].wo_code,'#','No') [Link] ")
        Query.Append("      ,'assets/media/svg/apps/WRK010000.svg' [Icon] ")
        Query.Append("      ,[A].wo_code [ID] ")
        Query.Append("      ,[A].summary [Title] ")
        Query.Append("      ,[A].status [Type] ")
        Query.Append("      ,[A].status [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("   from ")
        Query.Append("	    oop_wo_dtl_monitor [C] ")
        Query.Append("	    left join oop_wo_hdr [A] on [C].wo_code = [A].wo_code ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].created_by = '" & CIIS_EmpCode & "') [A] ")
        Query.Append("where ")
        Query.Append("   [DateCreated] >= dateadd(month,-6,getdate()) ")
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
                    Dim ID As String = "<a href='" & DR("Link") & "'>" & DR("ID") & "</a>"
                    Dim Title As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px'><img alt='' class='w-100' src='" & DR("Icon") & "' /></div>&nbsp" & DR("Title") & "</div>"
                    Dim RequestedBy As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"
                    RecordList.Add(New With {
                        .ID = ID,
                        .Title = Title,
                        .Type = DR("Type"),
                        .DateRequired = DR("DateRequired"),
                        .Status = DR("Status"),
                        .RequestedBy = RequestedBy
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

#End Region

End Class