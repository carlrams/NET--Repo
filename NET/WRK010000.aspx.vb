Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class WRK010000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

    Protected Property FormDataSet As DataSet

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
        Query.Append("	isnull((select count(1) from oop_wo_dtl_monitor [A] left join oop_wo_hdr [B] on [A].wo_code = [B].wo_code where [A].monitored_by = '" & CIIS_EmpCode & "' and [B].status Not In ('Closed','Cancelled')),0) [Subscribed] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [A] where [A].assigned_to = '" & CIIS_EmpCode & "' And [A].status Not In ('Closed','Cancelled')),0) [Total] ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    spnTotal.InnerText = "You have " & DR("Total") & " assigned work order"
                    spn01Total.InnerText = DR("Total") & " total assigned work order(s)"
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
        Query.Append("	    oop_wo_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Closed','Cancelled') ")
        Query.Append("      and [A].assigned_to = '" & CIIS_EmpCode & "') [A] ")
        'get query 

        'variable
        Dim FormDataTable As DataTable = New DataTable()
        FormDataTable.Columns.Add(New DataColumn("ID"))
        FormDataTable.Columns.Add(New DataColumn("Title"))
        FormDataTable.Columns.Add(New DataColumn("Type"))
        FormDataTable.Columns.Add(New DataColumn("DateRequired"))
        FormDataTable.Columns.Add(New DataColumn("Status"))
        FormDataTable.Columns.Add(New DataColumn("RequestedBy"))
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim ID As String = "<a href='" & DR("Link") & "'>" & DR("ID") & "</a>"
                    Dim Title As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>"
                    Dim RequestedBy As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"
                    FormDataTable.Rows.Add(ID, Title, DR("Type"), DR("DateRequired"), DR("Status"), RequestedBy)

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        FormDataSet = New DataSet()
        FormDataSet.Tables.Add(FormDataTable)

    End Function

#End Region

End Class