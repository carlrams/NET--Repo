Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json

Public Class HNDDSB
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

            If FormCode = "DSB010000" And Type = "Form Counter" Then
                Dim json As String = Me.DSB010000_Form_Counter()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB010000" And Type = "Form Summary" Then
                Dim Status = context.Request("Status")
                Dim json As String = Me.DSB010000_Form_Status(Status)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "DSB010000" And Type = "Form Update" Then
                Dim ID = context.Request("ID")
                Dim json As String = Me.DSB010000_Form_Update(ID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB010000" And Type = "Work Order Counter" Then
                Dim json As String = Me.DSB010000_WorkOrder_Counter()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB010000" And Type = "Work Order Summary" Then
                Dim Status = context.Request("Status")
                Dim json As String = Me.DSB010000_WorkOrder_Status(Status)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "DSB010000" And Type = "Work Order Update" Then
                Dim ID = context.Request("ID")
                Dim json As String = Me.DSB010000_WorkOrder_Update(ID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If

            If FormCode = "DSB030000" And Type = "Department - Name" Then
                Dim DeptCode = context.Request("DeptCode")
                Dim json As String = Me.DSB030000_DeptName(DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Employee - Name" Then
                Dim EmpCode = context.Request("EmpCode")
                Dim json As String = Me.DSB030000_EmpName(EmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Overall" Then
                Dim Status = context.Request("Status")
                Dim json As String = Me.DSB030000_Overall(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Overall - Month" Then
                Dim Status = context.Request("Status")
                Dim Month = context.Request("Month")
                Dim json As String = Me.DSB030000_Overall_Month(Status, Month)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Open - Department" Then
                Dim DeptCode = context.Request("DeptCode")
                Dim json As String = Me.DSB030000_Open_Department(DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Open - Employee" Then
                Dim DeptCode = context.Request("DeptCode")
                Dim json As String = Me.DSB030000_Open_Employee(DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Open - Form" Then
                Dim EmpCode = context.Request("EmpCode")
                Dim json As String = Me.DSB030000_Open_Form(EmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Year - Department" Then
                Dim Year = context.Request("Year")
                Dim json As String = Me.DSB030000_Year_Department(Year)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Year - Employee" Then
                Dim Year = context.Request("Year")
                Dim DeptCode = context.Request("DeptCode")
                Dim json As String = Me.DSB030000_Year_Employee(Year, DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Year - Form" Then
                Dim Year = context.Request("Year")
                Dim EmpCode = context.Request("EmpCode")
                Dim json As String = Me.DSB030000_Year_Form(Year, EmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging - Department" Then
                Dim Aging = context.Request("Aging")
                Dim json As String = Me.DSB030000_Aging(Aging)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging - Employee" Then
                Dim Aging = context.Request("Aging")
                Dim DeptCode = context.Request("DeptCode")
                Dim json As String = Me.DSB030000_Aging_Employee(Aging, DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging - Form" Then
                Dim Aging = context.Request("Aging")
                Dim EmpCode = context.Request("EmpCode")
                Dim json As String = Me.DSB030000_Aging_Form(Aging, EmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Accomplishment - Employee" Then
                Dim DateFrom = context.Request("DateFrom")
                Dim DateTo = context.Request("DateTo")
                Dim DeptCode = context.Request("DeptCode")
                Dim json As String = Me.DSB030000_Accomplishment_Employee(DateFrom, DateTo, DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Accomplishment - Form" Then
                Dim DateFrom = context.Request("DateFrom")
                Dim DateTo = context.Request("DateTo")
                Dim EmpCode = context.Request("EmpCode")
                Dim json As String = Me.DSB030000_Accomplishment_Form(DateFrom, DateTo, EmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB080000" And Type = "Project" Then
                Dim Batch = context.Request("Batch")
                Dim json As String = Me.DSB080000_Project_List(Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Info" Then
                Dim No = context.Request("No")
                Dim json As String = Me.DSB080000_Project_Info(No)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Get Status" Then

                Dim Batch = context.Request("Batch")

                Dim json As String = Me.DSB080000_Get_Status(Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Get Status Per Section" Then

                Dim Batch = context.Request("Batch")

                Dim json As String = Me.DSB080000_Get_Status_Per_Section(Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Get Accomplishment Per Section" Then

                Dim Batch = context.Request("Batch")

                Dim json As String = Me.DSB080000_Accomplishment_Per_Section(Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Get Accomplishment Per Contractor" Then

                Dim Batch = context.Request("Batch")

                Dim json As String = Me.DSB080000_Accomplishment_Per_Contractor(Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Get Overall Batch Status" Then

                Dim Batch = context.Request("Batch")

                Dim json As String = Me.DSB080000_Overall_Batch_Status(Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Construction Status List" Then
                Dim Batch = context.Request("Batch")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB080000_Construction_Status_List(Batch, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Status Per Section List" Then
                Dim Batch = context.Request("Batch")
                Dim TaskName = context.Request("Status")
                Dim Status = context.Request("seriesName")

                Dim json As String = Me.DSB080000_Status_PerSection_List(Batch, TaskName, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Accomplishment Per Section List" Then
                Dim Batch = context.Request("Batch")
                Dim Status = context.Request("Status")
                Dim seriesName = context.Request("seriesName")

                Dim json As String = Me.DSB080000_Accomplishment_PerSection_List(Batch, Status, seriesName)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Accomplishment Per Contractor List" Then
                Dim Batch = context.Request("Batch")
                Dim Status = context.Request("Status")
                Dim seriesName = context.Request("seriesName")

                Dim json As String = Me.DSB080000_Accomplishment_PerContractor_List(Batch, Status, seriesName)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB080000" And Type = "Overall Batch Status List" Then
                Dim Batch = context.Request("Batch")
                Dim Status = context.Request("Status")
                Dim seriesName = context.Request("seriesName")

                Dim json As String = Me.DSB080000_Overall_Batch_Status_List(Batch, Status, seriesName)
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

#Region "DSB010000"

    Function DSB010000_Form_Counter()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Endorsed By','Approved By',Implementer','Clarification') and status not in ('Accepted','Declined','Cancelled')),0) [Total] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Endorsed By') and status not in ('Accepted','Declined','Cancelled')),0) [Endorse] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Approved By') and status not in ('Accepted','Declined','Cancelled')),0) [Approve] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Implementer') and status not in ('Accepted','Declined','Cancelled')),0) [Implement] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Clarification') and status not in ('Accepted','Declined','Cancelled')),0) [Clarify] ")
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
                        .Total = DR("Total"),
                        .Endorse = DR("Endorse"),
                        .Approve = DR("Approve"),
                        .Implement = DR("Implement"),
                        .Clarify = DR("Clarify")
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

    Function DSB010000_Form_Status(Status As String)

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
        Query.Append("         when 'For Clarification' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>'")
        Query.Append("         when 'For Cancellation' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>' end) [Type] ")
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
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Decline' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Accepted','Declined','Cancelled') ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].approver_type = '" & Status & "') [A] ")
        'get query 

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    InnerHtml.Append("<tr id='trFRM_Summary" & DR("ID") & "'>")
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

    Function DSB010000_Form_Update(ID As String)

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
        Query.Append("   ,[Action] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Decline' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
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
        Query.Append("      [A].f_code = '" & ID & "') [A] ")
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

    Function DSB010000_WorkOrder_Counter()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Assigned','Accepted','Completed','Clarify')),0) [Total] ")
        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Assigned')),0) [Assigned] ")
        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Accepted')),0) [Accepted] ")
        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Completed')),0) [Completed] ")
        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Clarify')),0) [Clarify] ")
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
                        .Total = DR("Total"),
                        .Assigned = DR("Accepted"),
                        .Accepted = DR("Accepted"),
                        .Completed = DR("Completed"),
                        .Clarify = DR("Clarify")
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

    Function DSB010000_WorkOrder_Status(Status As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'Assigned' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'Accepted' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'Clarify' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>'")
        Query.Append("         when 'Completed' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>' end) [Type]")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("	 ,(case when [DateRequired] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateRequired] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateRequired] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
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
        Query.Append("	    oop_wo_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].status = '" & Status & "' ")
        Query.Append("      and [A].assigned_to = '" & CIIS_EmpCode & "') [A] ")
        'get query 

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    InnerHtml.Append("<tr id='trWO_Summary" & DR("ID") & "'>")
                    InnerHtml.Append("   <td><a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a></td>")
                    InnerHtml.Append("   <td><div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div></td>")
                    InnerHtml.Append("   <td>" & DR("Type") & "</td>")
                    InnerHtml.Append("   <td>" & DR("DateRequired") & "</td>")
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

    Function DSB010000_WorkOrder_Update(ID As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'Assigned' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'Accepted' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'Clarify' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>'")
        Query.Append("         when 'Completed' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>' end) [Type]")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("	 ,(case when [DateRequired] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateRequired] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateRequired] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("   ,[Action] ")
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
        Query.Append("      ,(case when [A].assigned_to = '" & CIIS_EmpCode & "' and [A].status not in ('Closed') then 'Update' else 'Remove' end) [Action] ")
        Query.Append("   from ")
        Query.Append("	    oop_wo_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].wo_code = '" & ID & "') [A] ")
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
                        .col00 = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .col01 = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                        .col02 = DR("Type"),
                        .col03 = DR("DateRequired"),
                        .col04 = DR("Status"),
                        .col05 = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>",
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

#Region "DSB030000"

    Function DSB030000_DeptName(DeptCode)

        'get count
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.ProperCase(description) [DeptName] ")
        Query.Append("from ")
        Query.Append("   department ")
        Query.Append("where ")
        Query.Append("   dept_code = '" & DeptCode & "' ")
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
                        .DeptName = DR("DeptName")
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

    Function DSB030000_EmpName(EmpCode)

        'get count
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   fullname [EmpName] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("   emp_no = '" & EmpCode & "' ")
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
                        .EmpName = DR("EmpName")
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

    Function DSB030000_Overall(Status)

        'get count
        Dim Query As New StringBuilder
        If Status = "Open" Then
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-success"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("      and year([A].date_start) <= year(getdate()) ")
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("   [Form] is not null ")
            Query.Append("order by ")
            Query.Append("   [Count] DESC ")
        End If
        If Status = "Closed" Then
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-info"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status in ('Accepted') ")
            Query.Append("      and year([A].date_start) = year(getdate()) ")
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("   [Form] is not null ")
            Query.Append("order by ")
            Query.Append("   [Count] DESC ")
        End If
        If Status = "Total" Then
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-success"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("      and year([A].date_start) <= year(getdate()) ")
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-info"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status in ('Accepted') ")
            Query.Append("      and year([A].date_start) = year(getdate()) ")
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("   [Form] is not null ")
            Query.Append("order by ")
            Query.Append("   [Count] DESC ")
        End If
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
                        .Form = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Form") & "</div>",
                        .Category = DR("Category"),
                        .Count = DR("Count")
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

    Function DSB030000_Overall_Month(Status, Month)

        'get count
        Dim Query As New StringBuilder
        If Status = "Open" Then
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-success"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            If Month = Date.Today.Year Then
                Query.Append("  and year([A].date_start) < year(getdate()) ")
            Else
                Query.Append("  and year([A].date_start) = year(getdate()) ")
                Query.Append("  and month([A].date_start) = " & Month & " ")
            End If
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("   [Form] is not null ")
            Query.Append("order by ")
            Query.Append("   [Count] DESC ")
        End If
        If Status = "Closed" Then
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-info"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status in ('Accepted') ")
            If Month = Date.Today.Year Then
                Query.Append("  and year([A].date_start) < year(getdate()) ")
            Else
                Query.Append("  and year([A].date_start) = year(getdate()) ")
                Query.Append("  and month([A].date_start) = " & Month & " ")
            End If
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("   [Form] is not null ")
            Query.Append("order by ")
            Query.Append("   [Count] DESC ")
        End If
        If Status = "Total" Then
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-success"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            If Month = Date.Today.Year Then
                Query.Append("  and year([A].date_start) < year(getdate()) ")
            Else
                Query.Append("  and year([A].date_start) = year(getdate()) ")
                Query.Append("  and month([A].date_start) = " & Month & " ")
            End If
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   * ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      (case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("      ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("      ,'<span class=""badge badge-info"">Open Form</span>' [Category] ")
            Query.Append("      ,count(1) [Count] ")
            Query.Append("   from ")
            Query.Append("      form_hdr [A] ")
            Query.Append("   where ")
            Query.Append("      [A].status in ('Accepted') ")
            If Month = Date.Today.Year Then
                Query.Append("  and year([A].date_start) < year(getdate()) ")
            Else
                Query.Append("  and year([A].date_start) = year(getdate()) ")
                Query.Append("  and month([A].date_start) = " & Month & " ")
            End If
            Query.Append("   group by ")
            Query.Append("      [A].form_type ")
            Query.Append("      ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("   [Form] is not null ")
            Query.Append("order by ")
            Query.Append("   [Count] DESC ")
        End If
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
                        .Form = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Form") & "</div>",
                        .Category = DR("Category"),
                        .Count = DR("Count")
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

    Function DSB030000_Open_Department(DeptCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   DepCode ")
        Query.Append("   ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [DepName] ")
        Query.Append("   ,Total ")
        Query.Append("   ,Age1 ")
        Query.Append("   ,Age2 ")
        Query.Append("   ,Age3 ")
        Query.Append("   ,Age4 ")
        Query.Append("   ,Age5 ")
        Query.Append("   ,Age6 ")
        Query.Append("from ")
        Query.Append("   Rpt_AgingFormDep ")
        Query.Append("where ")
        Query.Append("   DepCode = '" & DeptCode & "' ")
        Query.Append("order by ")
        Query.Append("   SeqNo ")
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
                        .Department = "<a href='#' onclick='fn02OpenEmployee(""" & DR("DepCode") & """);' >" & DR("DepName") & "</a>",
                        .Total = DR("Total"),
                        .Age1 = DR("Age1"),
                        .Age2 = DR("Age2"),
                        .Age3 = DR("Age3"),
                        .Age4 = DR("Age4"),
                        .Age5 = DR("Age5"),
                        .Age6 = DR("Age6")
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

    Function DSB030000_Open_Employee(DeptCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   EmpCode ")
        Query.Append("   ,EmpName ")
        Query.Append("   ,SecName ")
        Query.Append("   ,ltrim(str(Total)) [Total] ")
        Query.Append("   ,ltrim(str(Age1)) [Age1] ")
        Query.Append("   ,ltrim(str(Age2)) [Age2] ")
        Query.Append("   ,ltrim(str(Age3)) [Age3] ")
        Query.Append("   ,ltrim(str(Age4)) [Age4] ")
        Query.Append("   ,ltrim(str(Age5)) [Age5] ")
        Query.Append("   ,ltrim(str(Age6)) [Age6] ")
        Query.Append("from ")
        Query.Append("   Rpt_AgingFormEmp ")
        Query.Append("Where ")
        Query.Append("   DepCode = '" & DeptCode & "' ")
        Query.Append("order by ")
        Query.Append("   EmpName ")
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
                        .Employee = "<a href='#' onclick='fn02OpenForm(""" & DR("EmpCode") & """);' >" & DR("EmpName") & "</a>",
                        .Section = DR("SecName"),
                        .Total = DR("Total"),
                        .Age1 = DR("Age1"),
                        .Age2 = DR("Age2"),
                        .Age3 = DR("Age3"),
                        .Age4 = DR("Age4"),
                        .Age5 = DR("Age5"),
                        .Age6 = DR("Age6")
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

    Function DSB030000_Open_Form(EmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
        Query.Append("   ,[A].FormNo [ID] ")
        Query.Append("   ,dbo.Get_Icon([B].tbl_from) [Icon] ")
        Query.Append("   ,[A].FormSummary [Title] ")
        Query.Append("   ,[A].Total [Total] ")
        Query.Append("   ,[A].Age1 [Age1] ")
        Query.Append("   ,[A].Age2 [Age2] ")
        Query.Append("   ,[A].Age3 [Age3] ")
        Query.Append("   ,[A].Age4 [Age4] ")
        Query.Append("   ,[A].Age5 [Age5] ")
        Query.Append("   ,[A].Age6 [Age6] ")
        Query.Append("from ")
        Query.Append("   Rpt_AgingFormDtl [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
        Query.Append("   left join employee [C] on [A].EmpCode = [C].emp_no ")
        Query.Append("   left join oop_form_type [D] on [B].form_type = [D].t_code ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & EmpCode & "' ")
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
                        .ID = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                        .Total = DR("Total"),
                        .Age1 = DR("Age1"),
                        .Age2 = DR("Age2"),
                        .Age3 = DR("Age3"),
                        .Age4 = DR("Age4"),
                        .Age5 = DR("Age5"),
                        .Age6 = DR("Age6")
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

    Function DSB030000_Year_Department(Year_)

        'get query
        Dim Query As New StringBuilder
        If Year_.ToString.Contains("<") = True Then
            Query.Append("select ")
            Query.Append("   [A].DepCode ")
            Query.Append("   ,(select dbo.ProperCase([B].description) from department [B] where [B].dept_code = [A].DepCode) [DepName] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) < " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode) [Total] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) < " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) >= 0) [Age1] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) < " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -7 and -1) [Age2] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) < " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -15 and -8) [Age3] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) < " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -22 and -16) [Age4] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) < " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -30 and -23) [Age5] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) < " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) < -30) [Age6] ")
            Query.Append("from ")
            Query.Append("   Rpt_AgingFormDep [A] ")
            Query.Append("order by ")
            Query.Append("   DepName ")
        ElseIf Year_.ToString.Contains("<") = False Then
            Query.Append("select ")
            Query.Append("   [A].DepCode ")
            Query.Append("   ,(select dbo.ProperCase([B].description) from department [B] where [B].dept_code = [A].DepCode) [DepName] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode) [Total] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) >= 0) [Age1] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -7 and -1) [Age2] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -15 and -8) [Age3] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -22 and -16) [Age4] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) between -30 and -23) [Age5] ")
            Query.Append("   ,(select count(1) from form_hdr [B] left join employee [C] on [B].approver = [C].emp_no where [B].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = " & Replace(Year_, "<", "") & " and [C].dept_code = [A].DepCode and datediff(day,getdate(),[B].date_end) < -30) [Age6] ")
            Query.Append("from ")
            Query.Append("   Rpt_AgingFormDep [A] ")
            Query.Append("order by ")
            Query.Append("   DepName ")
        End If
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

                    If DR("Total") > 0 Then
                        RecordList.Add(New With {
                            .Department = "<a href='#' onclick='fn03YearEmployee(""" & DR("DepCode") & """);' >" & DR("DepName") & "</a>",
                            .Total = DR("Total"),
                            .Age1 = DR("Age1"),
                            .Age2 = DR("Age2"),
                            .Age3 = DR("Age3"),
                            .Age4 = DR("Age4"),
                            .Age5 = DR("Age5"),
                            .Age6 = DR("Age6")
                        })
                    End If

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

    Function DSB030000_Year_Employee(Year_, DeptCode)

        'get query
        Dim Query As New StringBuilder
        If Year_.ToString.Contains("<") = True Then
            Query.Append("select")
            Query.Append("   [A].EmpCode ")
            Query.Append("   ,[A].EmpName ")
            Query.Append("   ,[A].SecName ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) < " & Replace(Year_, "<", "") & ") [Total] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) < " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) >= 0) [Age1] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) < " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -7 and -1) [Age2] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) < " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -15 and -8) [Age3] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) < " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -22 and -16) [Age4] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) < " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -30 and -23) [Age5] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) < " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) < -30) [Age6] ")
            Query.Append("from ")
            Query.Append("   Rpt_AgingFormEmp [A] ")
            Query.Append("Where ")
            Query.Append("   [A].DepCode = '" & DeptCode & "' ")
            Query.Append("order by ")
            Query.Append("   [A].EmpName ")
        ElseIf Year_.ToString.Contains("<") = False Then
            Query.Append("select")
            Query.Append("   [A].EmpCode ")
            Query.Append("   ,[A].EmpName ")
            Query.Append("   ,[A].SecName ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) = " & Replace(Year_, "<", "") & ") [Total] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) = " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) >= 0) [Age1] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) = " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -7 and -1) [Age2] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) = " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -15 and -8) [Age3] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) = " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -22 and -16) [Age4] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) = " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) between -30 and -23) [Age5] ")
            Query.Append("   ,(select count(1) from form_hdr [B] where [B].approver = [A].EmpCode and [B].status not in ('Accepted', 'Cancelled', 'Declined') and year([B].date_start) = " & Replace(Year_, "<", "") & " and datediff(day,getdate(),[B].date_end) < -30) [Age6] ")
            Query.Append("from ")
            Query.Append("   Rpt_AgingFormEmp [A] ")
            Query.Append("Where ")
            Query.Append("   [A].DepCode = '" & DeptCode & "' ")
            Query.Append("order by ")
            Query.Append("   [A].EmpName ")
        End If
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

                    If DR("Total") > 0 Then
                        RecordList.Add(New With {
                            .Employee = "<a href='#' onclick='fn03YearForm(""" & DR("EmpCode") & """);' >" & DR("EmpName") & "</a>",
                            .Section = DR("SecName"),
                            .Total = DR("Total"),
                            .Age1 = DR("Age1"),
                            .Age2 = DR("Age2"),
                            .Age3 = DR("Age3"),
                            .Age4 = DR("Age4"),
                            .Age5 = DR("Age5"),
                            .Age6 = DR("Age6")
                        })
                    End If

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

    Function DSB030000_Year_Form(Year_, EmpCode)

        'get query
        Dim Query As New StringBuilder
        If Year_.ToString.Contains("<") = True Then
            Query.Append("select ")
            Query.Append("   dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("   ,[A].FormNo [ID] ")
            Query.Append("   ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("   ,[A].FormSummary [Title] ")
            Query.Append("   ,[A].Total [Total] ")
            Query.Append("   ,[A].Age1 [Age1] ")
            Query.Append("   ,[A].Age2 [Age2] ")
            Query.Append("   ,[A].Age3 [Age3] ")
            Query.Append("   ,[A].Age4 [Age4] ")
            Query.Append("   ,[A].Age5 [Age5] ")
            Query.Append("   ,[A].Age6 [Age6] ")
            Query.Append("from ")
            Query.Append("   Rpt_AgingFormDtl [A] ")
            Query.Append("   left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("   left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("   left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("where ")
            Query.Append("   [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("   and year([B].created_date) < " & Replace(Year_, "<", "") & " ")
        ElseIf Year_.ToString.Contains("<") = False Then
            Query.Append("select ")
            Query.Append("   dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("   ,[A].FormNo [ID] ")
            Query.Append("   ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("   ,[A].FormSummary [Title] ")
            Query.Append("   ,[A].Total [Total] ")
            Query.Append("   ,[A].Age1 [Age1] ")
            Query.Append("   ,[A].Age2 [Age2] ")
            Query.Append("   ,[A].Age3 [Age3] ")
            Query.Append("   ,[A].Age4 [Age4] ")
            Query.Append("   ,[A].Age5 [Age5] ")
            Query.Append("   ,[A].Age6 [Age6] ")
            Query.Append("from ")
            Query.Append("   Rpt_AgingFormDtl [A] ")
            Query.Append("   left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("   left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("   left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("where ")
            Query.Append("   [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("   and year([B].created_date) = " & Replace(Year_, "<", "") & " ")
        End If

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
                        .ID = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                        .Total = DR("Total"),
                        .Age1 = DR("Age1"),
                        .Age2 = DR("Age2"),
                        .Age3 = DR("Age3"),
                        .Age4 = DR("Age4"),
                        .Age5 = DR("Age5"),
                        .Age6 = DR("Age6")
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

    Function DSB030000_Aging(Aging)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].DepCode ")
        Query.Append("   ,(select dbo.ProperCase([B].description) from department [B] where [B].dept_code = [A].DepCode) [DepName] ")
        If Aging = "Within" Then
            Query.Append("   ,[A].Age1 [Total] ")
        ElseIf Aging = "1 to 7 days" Then
            Query.Append("   ,[A].Age2 [Total] ")
        ElseIf Aging = "8 to 15 days" Then
            Query.Append("   ,[A].Age3 [Total] ")
        ElseIf Aging = "16 to 22 days" Then
            Query.Append("   ,[A].Age4 [Total] ")
        ElseIf Aging = "23 to 30 days" Then
            Query.Append("   ,[A].Age5 [Total] ")
        ElseIf Aging = "Above 30 days" Then
            Query.Append("   ,[A].Age6 [Total] ")
        End If
        Query.Append("from ")
        Query.Append("   Rpt_AgingFormDep [A] ")
        Query.Append("order by ")
        Query.Append("   DepName ")
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

                    If DR("Total") > 0 Then
                        RecordList.Add(New With {
                            .Department = "<a href='#' onclick='fn04AgingEmployee(""" & DR("DepCode") & """);' >" & DR("DepName") & "</a>",
                            .Total = DR("Total")
                        })
                    End If

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

    Function DSB030000_Aging_Employee(Aging, DeptCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   EmpCode ")
        Query.Append("   ,EmpName ")
        Query.Append("   ,SecName ")
        If Aging = "Within" Then
            Query.Append("   ,Age1 [Total] ")
        ElseIf Aging = "1 to 7 days" Then
            Query.Append("   ,Age2 [Total] ")
        ElseIf Aging = "8 to 15 days" Then
            Query.Append("   ,Age3 [Total] ")
        ElseIf Aging = "16 to 22 days" Then
            Query.Append("   ,Age4 [Total] ")
        ElseIf Aging = "23 to 30 days" Then
            Query.Append("   ,Age5 [Total] ")
        ElseIf Aging = "Above 30 days" Then
            Query.Append("   ,Age6 [Total] ")
        End If
        Query.Append("from ")
        Query.Append("   Rpt_AgingFormEmp ")
        Query.Append("Where ")
        Query.Append("   DepCode = '" & DeptCode & "' ")
        Query.Append("order by ")
        Query.Append("   EmpName ")
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

                    If DR("Total") > 0 Then
                        RecordList.Add(New With {
                            .Employee = "<a href='#' onclick='fn04AgingForm(""" & DR("EmpCode") & """);' >" & DR("EmpName") & "</a>",
                            .Section = DR("SecName"),
                            .Total = DR("Total")
                        })
                    End If

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

    Function DSB030000_Aging_Form(Aging, EmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
        Query.Append("   ,[A].FormNo [ID] ")
        Query.Append("   ,dbo.Get_Icon([B].tbl_from) [Icon] ")
        Query.Append("   ,[A].FormSummary [Title] ")
        If Aging = "Within" Then
            Query.Append("   ,Age1 [Total] ")
        ElseIf Aging = "1 to 7 days" Then
            Query.Append("   ,Age2 [Total] ")
        ElseIf Aging = "8 to 15 days" Then
            Query.Append("   ,Age3 [Total] ")
        ElseIf Aging = "16 to 22 days" Then
            Query.Append("   ,Age4 [Total] ")
        ElseIf Aging = "23 to 30 days" Then
            Query.Append("   ,Age5 [Total] ")
        ElseIf Aging = "Above 30 days" Then
            Query.Append("   ,Age6 [Total] ")
        End If
        Query.Append("from ")
        Query.Append("   Rpt_AgingFormDtl [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
        Query.Append("   left join employee [C] on [A].EmpCode = [C].emp_no ")
        Query.Append("   left join oop_form_type [D] on [B].form_type = [D].t_code ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & EmpCode & "' ")
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

                    If DR("Total") > 0 Then
                        RecordList.Add(New With {
                            .ID = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                            .Title = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                            .Total = DR("Total")
                        })
                    End If

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

    Function DSB030000_Accomplishment_Employee(DateFrom, DateTo, DeptCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [EmpCode] ")
        Query.Append("   ,[EmpName] ")
        Query.Append("   ,[Section] ")
        Query.Append("   ,(select count(1) from view_FormApprover [B] where [B].approver = [A].EmpCode and [B].DateStart between '" & DateFrom & "' and '" & DateTo & "') [IN] ")
        Query.Append("   ,(select count(1) from view_FormApprover [B] where [B].approver = [A].EmpCode and [B].UpdatedDate between '" & DateFrom & "' and '" & DateTo & "') [OUT] ")
        Query.Append("   ,(select count(1) from view_FormApprover [B] where [B].approver = [A].EmpCode and [B].UpdatedDate between '" & DateFrom & "' and '" & DateTo & "' and [B].DateEnd > [B].UpdatedDate) [Within] ")
        Query.Append("   ,(select count(1) from view_FormApprover [B] where [B].approver = [A].EmpCode and [B].UpdatedDate between '" & DateFrom & "' and '" & DateTo & "' and [B].DateEnd = [B].UpdatedDate) [Due] ")
        Query.Append("   ,(select count(1) from view_FormApprover [B] where [B].approver = [A].EmpCode and [B].UpdatedDate between '" & DateFrom & "' and '" & DateTo & "' and [B].DateEnd < [B].UpdatedDate) [Delay] ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      [B].emp_no [EmpCode] ")
        Query.Append("      ,[B].fullname [EmpName] ")
        Query.Append("      ,[C].Description [Section] ")
        Query.Append("   from ")
        Query.Append("      view_FormApprover [A] ")
        Query.Append("      left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("      left join Mstr_Section [C] on [B].Section = [C].SecCode ")
        Query.Append("   where ")
        Query.Append("      [B].dept_code = '" & DeptCode & "' ")
        Query.Append("      and ([A].DateStart between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("         or [A].DateEnd between '" & DateFrom & "' and '" & DateTo & "')) [A] ")
        Query.Append("order by ")
        Query.Append("   [EmpName] ")
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
                        .Employee = "<a href='#' onclick='fn05AccomplishmentForm(""" & DR("EmpCode") & """);' >" & DR("EmpName") & "</a>",
                        .Section = DR("Section"),
                        .IN = DR("IN"),
                        .OUT = DR("OUT"),
                        .Within = DR("Within"),
                        .Due = DR("Due"),
                        .Delay = DR("Delay")
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

    Function DSB030000_Accomplishment_Form(DateFrom, DateTo, EmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([B].f_code,'#','No') [Link] ")
        Query.Append("   ,[A].f_code [ID] ")
        Query.Append("   ,dbo.Get_Icon([B].tbl_from) [Icon] ")
        Query.Append("   ,[B].FormTitle [Title] ")
        Query.Append("   ,format([A].DateStart,'MM/dd/yyyy') [Start] ")
        Query.Append("   ,format([A].DateEnd,'MM/dd/yyyy') [End] ")
        Query.Append("   ,format([A].UpdatedDate,'MM/dd/yyyy') [Approved] ")
        Query.Append("   ,(case	  when [A].DateEnd > [A].UpdatedDate then 'Within' ")
        Query.Append("            when [A].DateEnd = [A].UpdatedDate then 'Due' ")
        Query.Append("            when [A].DateEnd < [A].UpdatedDate then 'Delay' end) [Status] ")
        Query.Append("from ")
        Query.Append("   view_FormApprover [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].f_code = [B].f_code ")
        Query.Append("where ")
        Query.Append("   [A].approver = '" & EmpCode & "' ")
        Query.Append("   and ([A].DateStart between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("      or [A].DateEnd between '" & DateFrom & "' and '" & DateTo & "') ")
        Query.Append("order by ")
        Query.Append("   [ID] ")

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
                        .ID = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>",
                        .Start = DR("Start"),
                        .End = DR("End"),
                        .Approved = DR("Approved"),
                        .Status = DR("Status")
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

#Region "DSB080000"

    Function DSB080000_Project_List(Batch)

        'get query 

        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].HWCode [No] ")
        Query.Append("   ,[A].BatchNo [Batch] ")
        Query.Append("   ,[B].ProjInit [Subd] ")
        Query.Append("   ,[A].Phase ")
        Query.Append("   ,[A].Block ")
        Query.Append("   ,[A].Lot ")
        Query.Append("   ,[D].ModelName [House] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '011'),'-') [Target011] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '011'),'-') [Status011] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '011'),'-') [DateSecured011] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '002'),'-') [Target002] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '002'),'-') [Status002] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '002'),'-') [DateSecured002] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '014'),'-') [Target014] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '014'),'-') [Status014] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '014'),'-') [DateSecured014] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '008'),'-') [Target008] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '008'),'-') [Status008] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '008'),'-') [DateSecured008] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '012'),'-') [Target012] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '012'),'-') [Status012] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '012'),'-') [DateSecured012] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '001'),'-') [Target001] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '001'),'-') [Status001] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '001'),'-') [DateSecured001] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '003'),'-') [Target003] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '003'),'-') [Status003] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '003'),'-') [DateSecured003] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '013'),'-') [Target013] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '013'),'-') [Status013] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '013'),'-') [DateSecured013] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '005'),'-') [Target005] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '005'),'-') [Status005] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '005'),'-') [DateSecured005] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '009'),'-') [Target009] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '009'),'-') [Status009] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '009'),'-') [DateSecured009] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '006'),'-') [Target006] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '006'),'-') [Status006] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '006'),'-') [DateSecured006] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '007'),'-') [Target007] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '007'),'-') [Status007] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '007'),'-') [DateSecured007] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '010'),'-') [Target010] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '010'),'-') [Status010] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '010'),'-') [DateSecured010] ")
        Query.Append("from ")
        Query.Append("   Form_HWHdr [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_BatchNo [C] on [A].BatchNo = [C].BatchNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        If Batch = "All" Then Query.Append("   [A].BatchNo in (select [E].BatchNo from Form_HWHdr [E] ) ")
        If Batch <> "All" Then Query.Append("   [A].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [C].DateReleased ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot ")
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
                    Dim No As String = "<a class='pointer' onclick=""bindInfo('" & DR("Subd") & " " & DR("Phase") & " B" & DR("Block") & " L" & DR("Lot") & " (" & DR("House") & ")','" & DR("No") & "')"">" & DR("No") & "</a>"
                    Dim Phase As String = "<span class='nowrap-auto'>" & DR("Phase") & "</span>"
                    Dim House As String = "<span class='nowrap-auto'>" & DR("House") & "</span>"

                    RecordList.Add(New With {
                        .No = No,
                        .Batch = DR("Batch"),
                        .Subd = DR("Subd"),
                        .Phase = Phase,
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .House = House,
                        .Target011 = DR("Target011"),
                        .Status011 = DR("Status011"),
                        .DateSecured011 = DR("DateSecured011"),
                        .Target002 = DR("Target002"),
                        .Status002 = DR("Status002"),
                        .DateSecured002 = DR("DateSecured002"),
                        .Target014 = DR("Target014"),
                        .Status014 = DR("Status014"),
                        .DateSecured014 = DR("DateSecured014"),
                        .Target008 = DR("Target008"),
                        .Status008 = DR("Status008"),
                        .DateSecured008 = DR("DateSecured008"),
                        .Target012 = DR("Target012"),
                        .Status012 = DR("Status012"),
                        .DateSecured012 = DR("DateSecured012"),
                        .Target001 = DR("Target001"),
                        .Status001 = DR("Status001"),
                        .DateSecured001 = DR("DateSecured001"),
                        .Target003 = DR("Target003"),
                        .Status003 = DR("Status003"),
                        .DateSecured003 = DR("DateSecured003"),
                        .Target013 = DR("Target013"),
                        .Status013 = DR("Status013"),
                        .DateSecured013 = DR("DateSecured013"),
                        .Target005 = DR("Target005"),
                        .Status005 = DR("Status005"),
                        .DateSecured005 = DR("DateSecured005"),
                        .Target009 = DR("Target009"),
                        .Status009 = DR("Status009"),
                        .DateSecured009 = DR("DateSecured009"),
                        .Target006 = DR("Target006"),
                        .Status006 = DR("Status006"),
                        .DateSecured006 = DR("DateSecured006"),
                        .Target007 = DR("Target007"),
                        .Status007 = DR("Status007"),
                        .DateSecured007 = DR("DateSecured007"),
                        .Target010 = DR("Target010"),
                        .Status010 = DR("Status010"),
                        .DateSecured010 = DR("DateSecured010")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function

    Function DSB080000_Project_Info(No)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   FormCode [Code] ")
        Query.Append("   ,TaskName [Task] ")
        Query.Append("   ,isnull((select dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) from Form_HWTask [B] left join employee [C] on [B].AssignTo = [C].emp_no where [B].HWCode = '" & No & "' and [B].TaskCode = [A].TaskCode),'-') [AssignTo] ")
        Query.Append("   ,(select format([B].DateEnd,'MM/dd/yyyy') from Form_HWTask [B] where [B].HWCode = '" & No & "' and [B].TaskCode = [A].TaskCode) [TargetDate] ")
        Query.Append("   ,isnull((select [B].Status from Form_HWTask [B] where [B].HWCode = '" & No & "' and [B].TaskCode = [A].TaskCode),'-') [Status] ")
        Query.Append("   ,(select format([B].ActDateEnd,'MM/dd/yyyy') from Form_HWTask [B] where [B].HWCode = '" & No & "' and [B].TaskCode = [A].TaskCode) [DateSecured] ")
        Query.Append("from ")
        Query.Append("   Mstr_TaskTemplate [A] ")
        Query.Append("where ")
        Query.Append("   Type = 'Construction' ")
        Query.Append("order by ")
        Query.Append("   WeekStart ")
        Query.Append("   ,WeekDuration ")
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
                        .Task = "<a href='#' onclick=""window.open('" & DR("Code") & "-" & No & "');"">" & DR("Task") & "</a>",
                        .AssignTo = DR("AssignTo"),
                        .TargetDate = DR("TargetDate"),
                        .Status = DR("Status"),
                        .DateSecured = DR("DateSecured")
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

    Function DSB080000_Get_Status(Batch As String)

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   SUM(CASE WHEN [A].Status IN ('Assign', 'Not Started') THEN 1 ELSE 0 END) AS NotStarted ")
        Query.Append("   ,SUM(CASE WHEN [A].Status IN ('On-Going','Clarify','On-Hold') THEN 1 ELSE 0 END) AS InProgress ")
        Query.Append("   ,SUM(CASE WHEN [A].Status IN ('Close', 'Complete') THEN 1 ELSE 0 END) AS Complete ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   LEFT JOIN Form_HWHdr [B] ON [A].HWCode = [B].HWCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006'")
        If Batch <> "All" Then
            Query.Append("   AND [B].BatchNo = '" & Batch & "' ")
        End If

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                        .NotStarted = DR("NotStarted"),
                        .InProgress = DR("InProgress"),
                        .Complete = DR("Complete")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB080000_Get_Status_Per_Section(Batch As String)

        Dim Query As New StringBuilder
        If Batch = "All" Then
            Query.Append("SELECT ")
            Query.Append("   [A].TaskCode ")
            Query.Append("   ,[A].TaskName ")
            Query.Append("   ,[A].NotStartedRate [NotStartedRate] ")
            Query.Append("   ,[A].InProgressRate [InProgressRate] ")
            Query.Append("   ,[A].CompletionRate [CompletionRate] ")
            Query.Append("FROM ")
            Query.Append("   (SELECT ")
            Query.Append("      [A].TaskCode ")
            Query.Append("      ,[A].TaskName ")
            Query.Append("      ,[A].WeekStart ")
            Query.Append("      ,[A].WeekDuration ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] where [B].TaskCode = [A].TaskCode) [Total] ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] where [B].TaskCode = [A].TaskCode and [B].Status in ('Assign', 'Not Started')) [NotStartedRate] ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] where [B].TaskCode = [A].TaskCode and [B].Status in ('On-Going','Clarify','On-Hold')) [InProgressRate] ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] where [B].TaskCode = [A].TaskCode and [B].Status in ('Complete', 'Close')) [CompletionRate] ")
            Query.Append("   FROM ")
            Query.Append("      Mstr_TaskTemplate [A] ")
            Query.Append("   WHERE ")
            Query.Append("      [A].Type = 'Construction') [A] ")
            Query.Append("ORDER BY ")
            Query.Append("   [A].WeekStart, ")
            Query.Append("   [A].WeekDuration ")
        Else
            Query.Append("SELECT ")
            Query.Append("   [A].TaskCode ")
            Query.Append("   ,[A].TaskName ")
            Query.Append("   ,[A].NotStartedRate [NotStartedRate] ")
            Query.Append("   ,[A].InProgressRate [InProgressRate] ")
            Query.Append("   ,[A].CompletionRate [CompletionRate] ")
            Query.Append("FROM ")
            Query.Append("   (SELECT ")
            Query.Append("      [A].TaskCode ")
            Query.Append("      ,[A].TaskName ")
            Query.Append("      ,[A].WeekStart ")
            Query.Append("      ,[A].WeekDuration ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [C].BatchNo = '" & Batch & "' and [B].TaskCode = [A].TaskCode) [Total] ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [C].BatchNo = '" & Batch & "' and [B].TaskCode = [A].TaskCode and [B].Status in ('Assign', 'Not Started')) [NotStartedRate] ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [C].BatchNo = '" & Batch & "' and [B].TaskCode = [A].TaskCode and [B].Status in ('On-Going','Clarify','On-Hold')) [InProgressRate] ")
            Query.Append("      ,(select count(1) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [C].BatchNo = '" & Batch & "' and [B].TaskCode = [A].TaskCode and [B].Status in ('Complete', 'Close')) [CompletionRate] ")
            Query.Append("   FROM ")
            Query.Append("      Mstr_TaskTemplate [A] ")
            Query.Append("   WHERE ")
            Query.Append("      [A].Type = 'Construction') [A] ")
            Query.Append("ORDER BY ")
            Query.Append("   [A].WeekStart, ")
            Query.Append("   [A].WeekDuration ")
        End If

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                    .TaskCode = DR("TaskCode"),
                    .TaskName = DR("TaskName"),
                    .NotStartedRate = DR("NotStartedRate"),
                    .InProgressRate = DR("InProgressRate"),
                    .CompletionRate = DR("CompletionRate")})

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB080000_Accomplishment_Per_Section(Batch As String)

        Dim Query As New StringBuilder
        If Batch = "All" Then
            Query.Append("SELECT ")
            Query.Append("   [A].TaskCode ")
            Query.Append("   ,[A].TaskName ")
            Query.Append("   ,[A].CompletedWithinTAT ")
            Query.Append("   ,[A].Total - [A].CompletedWithinTAT [CompletedBeyondTAT] ")
            Query.Append("FROM ")
            Query.Append("   (SELECT ")
            Query.Append("      [A].TaskCode ")
            Query.Append("      ,[A].TaskName ")
            Query.Append("      ,[A].WeekStart ")
            Query.Append("      ,[A].WeekDuration ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [B] where [B].TaskCode = [A].TaskCode and [B].Status in ('Complete', 'Close')) [Total] ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [B] where [B].TaskCode = [A].TaskCode and [B].Status in ('Complete', 'Close') and [B].ActDateEnd <= [B].DateEnd) [CompletedWithinTAT] ")
            Query.Append("   FROM ")
            Query.Append("      Mstr_TaskTemplate [A] ")
            Query.Append("   WHERE ")
            Query.Append("      [A].Type = 'Construction') [A] ")
            Query.Append("ORDER BY ")
            Query.Append("   [A].WeekStart, ")
            Query.Append("   [A].WeekDuration ")
        Else
            Query.Append("SELECT ")
            Query.Append("   [A].TaskCode ")
            Query.Append("   ,[A].TaskName ")
            Query.Append("   ,[A].CompletedWithinTAT ")
            Query.Append("   ,[A].Total - [A].CompletedWithinTAT [CompletedBeyondTAT] ")
            Query.Append("FROM ")
            Query.Append("   (SELECT ")
            Query.Append("      [A].TaskCode ")
            Query.Append("      ,[A].TaskName ")
            Query.Append("      ,[A].WeekStart ")
            Query.Append("      ,[A].WeekDuration ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [C].BatchNo = '" & Batch & "' and [B].TaskCode = [A].TaskCode and [B].Status in ('Complete', 'Close')) [Total] ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [C].BatchNo = '" & Batch & "' and [B].TaskCode = [A].TaskCode and [B].Status in ('Complete', 'Close') and [B].ActDateEnd <= [B].DateEnd) [CompletedWithinTAT] ")
            Query.Append("   FROM ")
            Query.Append("      Mstr_TaskTemplate [A] ")
            Query.Append("   WHERE ")
            Query.Append("      [A].Type = 'Construction') [A] ")
            Query.Append("ORDER BY ")
            Query.Append("   [A].WeekStart, ")
            Query.Append("   [A].WeekDuration ")
        End If

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                        .TaskCode = DR("TaskCode"),
                        .TaskName = DR("TaskName"),
                        .CompletedWithinTAT = DR("CompletedWithinTAT"),
                        .CompletedBeyondTAT = DR("CompletedBeyondTAT")})

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB080000_Accomplishment_Per_Contractor(Batch As String)

        Dim Query As New StringBuilder
        If Batch = "All" Then
            Query.Append("SELECT ")
            Query.Append("   [A].ConCode ")
            Query.Append("   ,[A].ConName ")
            Query.Append("   ,Format(([A].CompletedWithinTAT / (case when [A].[Total] = 0 then 1 else [A].[Total] end)) * 100.00,'N2') [CompletedWithinTAT] ")
            Query.Append("   ,Format(([A].CompletedBeyondTAT / (case when [A].[Total] = 0 then 1 else [A].[Total] end)) * 100.00,'N2') [CompletedBeyondTAT] ")
            Query.Append("FROM ")
            Query.Append("   (select distinct ")
            Query.Append("      [B].v_code [ConCode] ")
            Query.Append("      ,[B].vendor [ConName] ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [C] left join Form_HWHdr [D] on [C].HWCode = [D].HWCode where [D].Contractor = [A].Contractor and [D].ConStatus = 'Awarded' and [C].Status in ('Complete', 'Close')) [Total] ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [C] left join Form_HWHdr [D] on [C].HWCode = [D].HWCode where [D].Contractor = [A].Contractor and [D].ConStatus = 'Awarded' and [C].Status in ('Complete', 'Close') and [C].ActDateEnd <= [C].DateEnd) [CompletedWithinTAT] ")
            Query.Append("   from ")
            Query.Append("      Form_HWHdr [A] ")
            Query.Append("      left join ogm_vendor [B] on [A].Contractor = [B].v_code ")
            Query.Append("   where ")
            Query.Append("      [A].ConStatus = 'Awarded') [A] ")
            Query.Append("ORDER BY ")
            Query.Append("   [A].ConName ")
        Else
            Query.Append("SELECT ")
            Query.Append("   [A].ConCode ")
            Query.Append("   ,[A].ConName ")
            Query.Append("   ,Format(([A].CompletedWithinTAT / (case when [A].[Total] = 0 then 1 else [A].[Total] end)) * 100.00,'N2') [CompletedWithinTAT] ")
            Query.Append("   ,Format(([A].CompletedBeyondTAT / (case when [A].[Total] = 0 then 1 else [A].[Total] end)) * 100.00,'N2') [CompletedBeyondTAT] ")
            Query.Append("FROM ")
            Query.Append("   (select distinct ")
            Query.Append("      [B].v_code [ConCode] ")
            Query.Append("      ,[B].vendor [ConName] ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [C] left join Form_HWHdr [D] on [C].HWCode = [D].HWCode where [C].TaskCode = '006' and [D].BatchNo = [A].BatchNo and [D].Contractor = [A].Contractor and [D].ConStatus = 'Awarded' and [C].Status in ('Complete', 'Close')) [Total] ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [C] left join Form_HWHdr [D] on [C].HWCode = [D].HWCode where [C].TaskCode = '006' and [D].BatchNo = [A].BatchNo and [D].Contractor = [A].Contractor and [D].ConStatus = 'Awarded' and [C].Status in ('Complete', 'Close') and [C].ActDateEnd <= [C].DateEnd) [CompletedWithinTAT] ")
            Query.Append("      ,(select cast(count(1) as decimal(21,2)) from Form_HWTask [C] left join Form_HWHdr [D] on [C].HWCode = [D].HWCode where [C].TaskCode = '006' and [D].BatchNo = [A].BatchNo and [D].Contractor = [A].Contractor and [D].ConStatus = 'Awarded' and [C].Status in ('Complete', 'Close') and [C].ActDateEnd > [C].DateEnd) [CompletedBeyondTAT] ")
            Query.Append("   from ")
            Query.Append("      Form_HWHdr [A] ")
            Query.Append("      left join ogm_vendor [B] on [A].Contractor = [B].v_code ")
            Query.Append("   where ")
            Query.Append("      [A].ConStatus = 'Awarded' ")
            Query.Append("      and [A].BatchNo = '" & Batch & "') [A] ")
            Query.Append("ORDER BY ")
            Query.Append("   [A].ConName ")
        End If

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                        .ConCode = DR("ConCode"),
                        .ConName = DR("ConName"),
                        .CompletedWithinTAT = DR("CompletedWithinTAT"),
                        .CompletedBeyondTAT = DR("CompletedBeyondTAT")})
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB080000_Overall_Batch_Status(Batch As String)
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("   [A].BatchNo ")
        Query.Append("   ,[A].DateReleased ")
        Query.Append("   ,[A].[InProgress] ")
        Query.Append("   ,[A].CompletedWithinTAT ")
        Query.Append("   ,[A].CompletedBeyondTAT ")
        Query.Append("FROM ")
        Query.Append("   (SELECT ")
        Query.Append("      [A].BatchNo ")
        Query.Append("      ,[A].DateReleased ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo) [Total] ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo AND [B].Status NOT IN ('Complete','Close')) [InProgress] ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo AND [B].Status IN ('Complete','Close') AND [B].ActDateEnd <= [B].DateEnd) [CompletedWithinTAT] ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo AND [B].Status IN ('Complete','Close') AND [B].ActDateEnd > [B].DateEnd) [CompletedBeyondTAT] ")
        Query.Append("   FROM ")
        Query.Append("      calmardbLive.dbo.mstr_BatchNo [A] ")
        Query.Append("   WHERE Year <= 2025) [A] ")
        Query.Append("UNION ")
        Query.Append("SELECT ")
        Query.Append("   [A].BatchNo ")
        Query.Append("   ,[A].DateReleased ")
        Query.Append("   ,[A].[InProgress] ")
        Query.Append("   ,[A].CompletedWithinTAT ")
        Query.Append("   ,[A].CompletedBeyondTAT ")
        Query.Append("FROM ")
        Query.Append("   (SELECT ")
        Query.Append("      [A].BatchNo ")
        Query.Append("      ,[A].DateReleased ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo) [Total] ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo AND [B].Status NOT IN ('Complete','Close')) [InProgress] ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo AND [B].Status IN ('Complete','Close') AND [B].ActDateEnd <= [B].DateEnd) [CompletedWithinTAT] ")
        Query.Append("      ,(SELECT COUNT(1) FROM Form_HWTask [B] LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode WHERE [B].TaskCode = '010' AND [C].BatchNo = [A].BatchNo AND [B].Status IN ('Complete','Close') AND [B].ActDateEnd > [B].DateEnd) [CompletedBeyondTAT] ")
        Query.Append("   FROM ")
        Query.Append("      calmardbLive.dbo.mstr_BatchNo [A] ")
        Query.Append("   WHERE Year >= 2025) [A] ")
        Query.Append("WHERE ")
        Query.Append("   [InProgress] > 0 ")
        Query.Append("order by ")
        Query.Append("   DateReleased ")

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                    .BatchNo = DR("BatchNo"),
                    .CompletedWithinTAT = DR("CompletedWithinTAT"),
                    .CompletedBeyondTAT = DR("CompletedBeyondTAT"),
                    .InProgress = DR("InProgress")
                })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB080000_Construction_Status_List(Batch As String, Status As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].HWCode [No] ")
        Query.Append("   ,[B].BatchNo [Batch] ")
        Query.Append("   ,[C].ProjInit [Subd] ")
        Query.Append("   ,[B].Phase ")
        Query.Append("   ,[B].Block ")
        Query.Append("   ,[B].Lot ")
        Query.Append("   ,[D].ModelName [House] ")
        Query.Append("   ,isnull(format([A].DateEnd,'MM/dd/yy'),'-') [Target] ")
        Query.Append("   ,isnull([A].Status,'-') [Status] ")
        Query.Append("   ,isnull(format([A].ActDateEnd,'MM/dd/yy'),'-') [DateSecured] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        If Batch = "All" Then Query.Append("   and [B].BatchNo in (select [E].BatchNo from calmardbLive.dbo.mstr_BatchNo [E]) ")
        If Batch <> "All" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        If Status = "Not Started" Then Query.Append("   and [A].Status in ('Assign', 'Not Started') ")
        If Status = "In Progress" Then Query.Append("   and [A].Status in ('On-Going','Clarify','On-Hold') ")
        If Status = "Complete" Then Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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
                    Dim No As String = "<a class='pointer' onclick=""bindInfo('" & DR("Subd") & " " & DR("Phase") & " B" & DR("Block") & " L" & DR("Lot") & " (" & DR("House") & ")','" & DR("No") & "')"">" & DR("No") & "</a>"
                    Dim Phase As String = "<span class='nowrap-auto'>" & DR("Phase") & "</span>"
                    Dim House As String = "<span class='nowrap-auto'>" & DR("House") & "</span>"

                    RecordList.Add(New With {
                        .No = No,
                        .Batch = DR("Batch"),
                        .Subd = DR("Subd"),
                        .Phase = Phase,
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .House = House,
                        .Target = DR("Target"),
                        .Status = DR("Status"),
                        .DateSecured = DR("DateSecured")
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

    Function DSB080000_Status_PerSection_List(Batch As String, TaskName As String, Status As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].HWCode [No] ")
        Query.Append("   ,[B].BatchNo [Batch] ")
        Query.Append("   ,[C].ProjInit [Subd] ")
        Query.Append("   ,[B].Phase ")
        Query.Append("   ,[B].Block ")
        Query.Append("   ,[B].Lot ")
        Query.Append("   ,[D].ModelName [House] ")
        Query.Append("   ,isnull(format([A].DateEnd,'MM/dd/yy'),'-') [Target] ")
        Query.Append("   ,isnull([A].Status,'-') [Status] ")
        Query.Append("   ,isnull(format([A].ActDateEnd,'MM/dd/yy'),'-') [DateSecured] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskName = '" & TaskName & "' ")
        If Batch = "All" Then Query.Append("   and [B].BatchNo in (select [E].BatchNo from calmardbLive.dbo.mstr_BatchNo [E]) ")
        If Batch <> "All" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        If Status = "Not Started" Then Query.Append("   and [A].Status in ('Assign', 'Not Started') ")
        If Status = "In Progress" Then Query.Append("   and [A].Status in ('On-Going','Clarify','On-Hold') ")
        If Status = "Complete" Then Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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
                    Dim No As String = "<a class='pointer' onclick=""bindInfo('" & DR("Subd") & " " & DR("Phase") & " B" & DR("Block") & " L" & DR("Lot") & " (" & DR("House") & ")','" & DR("No") & "')"">" & DR("No") & "</a>"
                    Dim Phase As String = "<span class='nowrap-auto'>" & DR("Phase") & "</span>"
                    Dim House As String = "<span class='nowrap-auto'>" & DR("House") & "</span>"

                    RecordList.Add(New With {
                        .No = No,
                        .Batch = DR("Batch"),
                        .Subd = DR("Subd"),
                        .Phase = Phase,
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .House = House,
                        .Target = DR("Target"),
                        .Status = DR("Status"),
                        .DateSecured = DR("DateSecured")
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

    Function DSB080000_Accomplishment_PerSection_List(Batch As String, TaskName As String, Status As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].HWCode [No] ")
        Query.Append("   ,[B].BatchNo [Batch] ")
        Query.Append("   ,[C].ProjInit [Subd] ")
        Query.Append("   ,[B].Phase ")
        Query.Append("   ,[B].Block ")
        Query.Append("   ,[B].Lot ")
        Query.Append("   ,[D].ModelName [House] ")
        Query.Append("   ,isnull(format([A].DateEnd,'MM/dd/yy'),'-') [Target] ")
        Query.Append("   ,isnull([A].Status,'-') [Status] ")
        Query.Append("   ,isnull(format([A].ActDateEnd,'MM/dd/yy'),'-') [DateSecured] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskName = '" & TaskName & "' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        If Batch = "All" Then Query.Append("   and [B].BatchNo in (select [E].BatchNo from calmardbLive.dbo.mstr_BatchNo [E]) ")
        If Batch <> "All" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        If Status = "Completed Within TAT" Then Query.Append("   and [A].ActDateEnd <= [A].DateEnd ")
        If Status = "Completed Beyond TAT" Then Query.Append("   and [A].ActDateEnd > [A].DateEnd ")
        Query.Append("order by ")
        Query.Append("   [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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
                    Dim No As String = "<a class='pointer' onclick=""bindInfo('" & DR("Subd") & " " & DR("Phase") & " B" & DR("Block") & " L" & DR("Lot") & " (" & DR("House") & ")','" & DR("No") & "')"">" & DR("No") & "</a>"
                    Dim Phase As String = "<span class='nowrap-auto'>" & DR("Phase") & "</span>"
                    Dim House As String = "<span class='nowrap-auto'>" & DR("House") & "</span>"

                    RecordList.Add(New With {
                        .No = No,
                        .Batch = DR("Batch"),
                        .Subd = DR("Subd"),
                        .Phase = Phase,
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .House = House,
                        .Target = DR("Target"),
                        .Status = DR("Status"),
                        .DateSecured = DR("DateSecured")
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

    Function DSB080000_Accomplishment_PerContractor_List(Batch As String, ContractorName As String, Status As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].HWCode [No] ")
        Query.Append("   ,[B].BatchNo [Batch] ")
        Query.Append("   ,[C].ProjInit [Subd] ")
        Query.Append("   ,[B].Phase ")
        Query.Append("   ,[B].Block ")
        Query.Append("   ,[B].Lot ")
        Query.Append("   ,[D].ModelName [House] ")
        Query.Append("   ,isnull(format([A].DateEnd,'MM/dd/yy'),'-') [Target] ")
        Query.Append("   ,isnull([A].Status,'-') [Status] ")
        Query.Append("   ,isnull(format([A].ActDateEnd,'MM/dd/yy'),'-') [DateSecured] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("   and [E].vendor = '" & ContractorName & "' ")
        If Batch = "All" Then Query.Append("   and [B].BatchNo in (select [E].BatchNo from calmardbLive.dbo.mstr_BatchNo [E]) ")
        If Batch <> "All" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        If Status = "Completed Within TAT" Then Query.Append("   and [A].ActDateEnd <= [A].DateEnd ")
        If Status = "Completed Beyond TAT" Then Query.Append("   and [A].ActDateEnd > [A].DateEnd ")
        Query.Append("order by ")
        Query.Append("   [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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
                    Dim No As String = "<a class='pointer' onclick=""bindInfo('" & DR("Subd") & " " & DR("Phase") & " B" & DR("Block") & " L" & DR("Lot") & " (" & DR("House") & ")','" & DR("No") & "')"">" & DR("No") & "</a>"
                    Dim Phase As String = "<span class='nowrap-auto'>" & DR("Phase") & "</span>"
                    Dim House As String = "<span class='nowrap-auto'>" & DR("House") & "</span>"

                    RecordList.Add(New With {
                        .No = No,
                        .Batch = DR("Batch"),
                        .Subd = DR("Subd"),
                        .Phase = Phase,
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .House = House,
                        .Target = DR("Target"),
                        .Status = DR("Status"),
                        .DateSecured = DR("DateSecured")
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

    Function DSB080000_Overall_Batch_Status_List(Batch As String, BatchNo As String, Status As String)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].HWCode [No] ")
        Query.Append("   ,[B].BatchNo [Batch] ")
        Query.Append("   ,[C].ProjInit [Subd] ")
        Query.Append("   ,[B].Phase ")
        Query.Append("   ,[B].Block ")
        Query.Append("   ,[B].Lot ")
        Query.Append("   ,[D].ModelName [House] ")
        Query.Append("   ,isnull(format([A].DateEnd,'MM/dd/yy'),'-') [Target] ")
        Query.Append("   ,isnull([A].Status,'-') [Status] ")
        Query.Append("   ,isnull(format([A].ActDateEnd,'MM/dd/yy'),'-') [DateSecured] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '010' ")
        Query.Append("   and [B].BatchNo = '" & BatchNo & "' ")
        If Status = "In Progress" Then
            Query.Append("   and [A].Status not in ('Complete','Close') ")
        End If
        If Status = "Completed Within TAT" Then
            Query.Append("   and [A].ActDateEnd <= [A].DateEnd ")
            Query.Append("   and [A].Status in ('Complete','Close') ")
        End If
        If Status = "Completed Beyond TAT" Then
            Query.Append("   and [A].ActDateEnd > [A].DateEnd ")
            Query.Append("   and [A].Status in ('Complete','Close') ")
        End If
        Query.Append("order by ")
        Query.Append("   [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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
                    Dim No As String = "<a class='pointer' onclick=""bindInfo('" & DR("Subd") & " " & DR("Phase") & " B" & DR("Block") & " L" & DR("Lot") & " (" & DR("House") & ")','" & DR("No") & "')"">" & DR("No") & "</a>"
                    Dim Phase As String = "<span class='nowrap-auto'>" & DR("Phase") & "</span>"
                    Dim House As String = "<span class='nowrap-auto'>" & DR("House") & "</span>"

                    RecordList.Add(New With {
                        .No = No,
                        .Batch = DR("Batch"),
                        .Subd = DR("Subd"),
                        .Phase = Phase,
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .House = House,
                        .Target = DR("Target"),
                        .Status = DR("Status"),
                        .DateSecured = DR("DateSecured")
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