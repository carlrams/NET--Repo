Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Web.Script.Serialization
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer

Public Class FRM010000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

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
        Master.setActiveMenu("APP", "FRM010000")
        'active account / menu

        'load page
        If IsPostBack = False Then
            bindCounter()
            bindForm()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
        End If
        'load page
    End Sub

#End Region

#Region "Function"

    Function bindCounter()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from oop_form_hdr [A] where [A].approver = '" & CIIS_EmpCode & "' and [A].status Not In ('Accepted','Declined','Cancelled') And [A].f_code in (select [B].f_code from oop_form_dtl_appr [B] where [B].approver = [A].approver and [B].status = '' and cast([B].DateStart as date) = cast(getdate() as date))),0) [New] ")
        Query.Append("	,isnull((select count(1) from oop_form_hdr [A] where [A].approver = '" & CIIS_EmpCode & "' And [A].status Not In ('Accepted','Declined','Cancelled')),0) [Total] ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    spn00Total.InnerText = "You have " & DR("Total") & " assigned form(s)"
                    spn01Total.InnerText = DR("Total") & " total assigned form(s)"
                    blink01New.Style.Add("display", IIf(DR("New") = 0, "none", ""))
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Function bindForm()

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
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Accepted','Declined','Cancelled') ")
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

                    InnerHtml.Append("<tr id='tr01" & DR("ID") & "'>")
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

        'update
        tbody01Form.InnerHtml = InnerHtml.ToString
        upnl01Form.Update()
        'update

    End Function

#End Region

End Class