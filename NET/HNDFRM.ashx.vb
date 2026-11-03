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

Public Class HNDFRM
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
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

            If FormCode = "FRM010000" And Type = "Form - Name" Then
                Dim FormType = context.Request("FormType")
                Dim json As String = Me.FRM010000_FormName(FormType)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM010000" And Type = "Counter" Then
                Dim json As String = Me.FRM010000_Counter()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM010000" And Type = "List-New" Then
                Dim json As String = Me.FRM010000_List_New()
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "FRM010000" And Type = "List-Subscribed" Then
                Dim json As String = Me.FRM010000_List_Subscribed()
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "FRM010000" And Type = "Request - Form" Then
                Dim FormType = context.Request("FormType")
                Dim json As String = Me.FRM010000_List_Request(FormType)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM010000" And Type = "Approved - Form" Then
                Dim FormType = context.Request("FormType")
                Dim json As String = Me.FRM010000_List_Approved(FormType)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM010000" And Type = "Update" Then
                Dim ID = context.Request("ID")
                Dim json As String = Me.FRM010000_Update(ID)
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

    Function FRM010000_FormName(FormType)

        'get count
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.ProperCase(description) [FormName] ")
        Query.Append("from ")
        Query.Append("   oop_form_type ")
        Query.Append("where ")
        Query.Append("   FormCode = '" & FormType & "' ")
        'get count

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

                    RecordList.Add(New With {
                        .FormName = DR("FormName")
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

    Function FRM010000_Counter()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from oop_form_hdr [A] where [A].approver = '" & CIIS_EmpCode & "' and [A].status Not In ('Accepted','Declined','Cancelled') And [A].f_code in (select [B].f_code from oop_form_dtl_appr [B] where [B].approver = [A].approver and [B].status = '' and cast([B].DateStart as date) = cast(getdate() as date))),0) [New] ")
        Query.Append("	,isnull((select count(1) from oop_form_hdr [A] where [A].approver = '" & CIIS_EmpCode & "' And [A].status Not In ('Accepted','Declined','Cancelled')),0) [Total] ")
        'get query 

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordList.Add(New With {
                        .New = DR("New"),
                        .Total = DR("Total")
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

    Function FRM010000_List_New()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'For Endorsement' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'For Approval' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'For Implementation' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'For Clarification' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("   ,Format([DateCreated],'MM/dd/yyyy') [DateCreated] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("   ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("	 ,(case when [DateExpected] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateExpected] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateExpected] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("	    left join Form_CRT [D] on [A].tbl_code = [D].CRTCode ")
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Accepted','Declined','Cancelled') ")
        Query.Append("      and [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [C].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "') [A] ")
        'get query 

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    InnerHtml.Append("<tr id='tr03" & DR("ID") & "'>")
                    InnerHtml.Append("   <td><a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a></td>")
                    InnerHtml.Append("   <td><div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div></td>")
                    InnerHtml.Append("   <td>" & DR("Type") & "</td>")
                    InnerHtml.Append("   <td>" & DR("DateRequired") & "</td>")
                    InnerHtml.Append("   <td>" & DR("DateExpected") & "</td>")
                    InnerHtml.Append("   <td>" & DR("Status") & "</td>")
                    InnerHtml.Append("   <td><div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div></td>")
                    InnerHtml.Append("</tr>")

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return InnerHtml.ToString
        'display 

    End Function

    Function FRM010000_List_Subscribed()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'For Endorsement' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'For Approval' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'For Implementation' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'For Clarification' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("   ,Format([DateCreated],'MM/dd/yyyy') [DateCreated] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("   ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("	 ,(case when [DateExpected] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateExpected] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateExpected] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("   from ")
        Query.Append("      oop_form_dtl_monitor [D] ")
        Query.Append("	    left join oop_form_hdr [A] on [D].f_code = [A].f_code ")
        Query.Append("	    left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Accepted','Declined','Cancelled') ")
        Query.Append("      and [D].monitored_by = '" & CIIS_EmpCode & "') [A] ")
        'get query 

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    InnerHtml.Append("<tr id='tr04" & DR("ID") & "'>")
                    InnerHtml.Append("   <td><a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a></td>")
                    InnerHtml.Append("   <td><div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div></td>")
                    InnerHtml.Append("   <td>" & DR("Type") & "</td>")
                    InnerHtml.Append("   <td>" & DR("DateRequired") & "</td>")
                    InnerHtml.Append("   <td>" & DR("DateExpected") & "</td>")
                    InnerHtml.Append("   <td>" & DR("Status") & "</td>")
                    InnerHtml.Append("   <td><div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div></td>")
                    InnerHtml.Append("</tr>")

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return InnerHtml.ToString
        'display 

    End Function

    Function FRM010000_List_Request(FormType)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,([Title] + ' / ' + [Remarks]) [Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'For Endorsement' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'For Approval' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'For Implementation' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'For Clarification' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("   ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("	 ,(case when [DateExpected] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateExpected] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateExpected] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].approver [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        If FormType = "FRM000037" Then
            Query.Append("      dbo.Get_Link(tbl_from) = '" & FormType & "' ")
        Else
            Query.Append("      [C].FormCode = '" & FormType & "' ")
            Query.Append("      AND dbo.Get_Link(tbl_from) != 'FRM000037' ")
        End If
        Query.Append("      and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status = 'Accepted' ")
        Query.Append("      and cast([A].updated_date as date) between cast(dateadd(month,-6,getdate()) as date) and cast(getdate() as date) ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].approver [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        If FormType = "FRM000037" Then
            Query.Append("      dbo.Get_Link(tbl_from) = '" & FormType & "' ")
        Else
            Query.Append("      [C].FormCode = '" & FormType & "' ")
            Query.Append("      AND dbo.Get_Link(tbl_from) != 'FRM000037' ")
        End If
        Query.Append("      and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
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

                    RecordList.Add(New With {
                        .ID = "tr05" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                        .Type = DR("Type"),
                        .DateRequired = DR("DateRequired"),
                        .DateExpected = DR("DateExpected"),
                        .Status = DR("Status"),
                        .RequestedBy = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"
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

    Function FRM010000_List_Approved(FormType)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'For Endorsement' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'For Approval' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'For Implementation' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'For Clarification' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("   ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("   ,Format([DateApproved],'MM/dd/yyyy') [DateApproved] ")
        Query.Append("	 ,(case when [DateApproved] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateApproved] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateApproved] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,(select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status not in ('') order by [C].seq_no desc) [DateExpected] ")
        Query.Append("      ,(select top 1 [C].updated_date from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status not in ('') order by [C].seq_no desc) [DateApproved] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code in (select [D].f_code from oop_form_dtl_appr [D] left join oop_form_hdr [E] on [D].f_code = [E].f_code left join oop_form_type [F] on [E].form_type = [F].t_code where [D].approver = '" & CIIS_EmpCode & "' and [F].FormCode = '" & FormType & "' and [D].status not in (''))) [A] ")
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

                    RecordList.Add(New With {
                        .ID = "tr06" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                        .Type = DR("Type"),
                        .DateExpected = DR("DateExpected"),
                        .DateApproved = DR("DateApproved"),
                        .Status = DR("Status"),
                        .RequestedBy = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"
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

    Function FRM010000_Update(ID As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select top 1 ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'For Endorsement' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'For Approval' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'For Implementation' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'For Clarification' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("   ,Format([DateCreated],'MM/dd/yyyy') [DateCreated] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("   ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("	 ,(case when [DateExpected] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateExpected] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateExpected] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("   ,[Action] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      1 [SeqNo] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("      ,(case when [A].approver = '" & CIIS_EmpCode & "' and [A].status not in ('Accepted','Declined','Cancelled') then 'Update' else 'Remove' end) [Action] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code = '" & ID & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      2 [SeqNo] ")
        Query.Append("      ,'' [Link] ")
        Query.Append("      ,'' [Icon] ")
        Query.Append("      ,'' [ID] ")
        Query.Append("      ,'' [Title] ")
        Query.Append("      ,'' [Type] ")
        Query.Append("      ,null [DateCreated] ")
        Query.Append("      ,null [DateRequired] ")
        Query.Append("      ,null [DateExpected] ")
        Query.Append("      ,'' [RequestedByCode] ")
        Query.Append("      ,'' [RequestedByName] ")
        Query.Append("      ,'Remove' [Action]) [A] ")
        Query.Append("order by ")
        Query.Append("   [SeqNo] ")
        'get query 

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordList.Add(New With {
                        .col00 = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .col01 = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                        .col02 = DR("Type"),
                        .col03 = DR("DateRequired"),
                        .col04 = DR("DateExpected"),
                        .col05 = DR("Status"),
                        .col06 = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>",
                        .Action = DR("Action")
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