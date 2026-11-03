Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports System.Web.Services.Description

Public Class DSB020000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

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
        Master.setActiveMenu("DSB", "DSB020000")
        'active account / menu

        If IsPostBack = False Then
            bindForm()
            bindWorkOrder()
            bindTask()
            bindRequest()
            bindRequestWO()
        End If

    End Sub
#End Region

#Region "Button"

    Protected Sub btnView_Click(ByVal sender As Object, e As EventArgs)

    End Sub

#End Region

#Region "Function"

    Function bindForm()

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	tbl_from ")
        Query.Append("	,description ")
        Query.Append("	,isnull((select count(1) from form_hdr [D] where [D].approver  = [H].Approver And [D].tbl_from = [H].tbl_from And [D].status Not In ('Accepted','Declined','Cancelled')),0) [Total] ")
        Query.Append("	,isnull((select count(1) from Form_AssignedApprover [A] where [A].approver = [H].Approver and [A].tbl_from = [H].tbl_from and [A].DateEnd > cast(getdate() as date)),0) [Good] ")
        Query.Append("	,isnull((select count(1) from Form_AssignedApprover [A] where [A].approver = [H].Approver and [A].tbl_from = [H].tbl_from and [A].DateEnd = cast(getdate() as date)),0) [Due] ")
        Query.Append("	,isnull((select count(1) from Form_AssignedApprover [A] where [A].approver = [H].Approver and [A].tbl_from = [H].tbl_from and [A].DateEnd < cast(getdate() as date)),0) [Delay] ")
        Query.Append("from ")
        Query.Append("	(select distinct ")
        Query.Append("		form_hdr.tbl_from  ")
        Query.Append("		,oop_form_type.description  ")
        Query.Append("		,form_hdr.approver  ")
        Query.Append("	from  ")
        Query.Append("		form_hdr  ")
        Query.Append("		left join oop_form_type on form_hdr.form_type =  oop_form_type.t_code ")
        Query.Append("	where  ")
        Query.Append("		form_hdr.approver = '" & CIIS_EmpCode & "' ")
        Query.Append("		and form_hdr.status not in ('Accepted','Declined','Cancelled')) [H] ")
        'get form

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlFormNo.Text = "" Then
                        ltrlFormTblName.Text = DR.GetString(0)
                        ltrlFormNo.Text = DR.GetString(1)
                        ltrlFormTotal.Text = DR.GetInt32(2)
                        ltrlFormGood.Text = DR.GetInt32(3)
                        ltrlFormDue.Text = DR.GetInt32(4)
                        ltrlFormDelay.Text = DR.GetInt32(5)
                    Else
                        ltrlFormTblName.Text = ltrlFormTblName.Text & "," & DR.GetString(0)
                        ltrlFormNo.Text = ltrlFormNo.Text & "," & DR.GetString(1)
                        ltrlFormTotal.Text = ltrlFormTotal.Text + DR.GetInt32(2)
                        ltrlFormGood.Text = ltrlFormGood.Text + DR.GetInt32(3)
                        ltrlFormDue.Text = ltrlFormDue.Text + DR.GetInt32(4)
                        ltrlFormDelay.Text = ltrlFormDelay.Text + DR.GetInt32(5)
                    End If

                End While

                'total
                spn01FormWithinTotal.InnerText = ltrlFormTotal.Text
                spn01FormDueTotal.InnerText = ltrlFormTotal.Text
                spn01FormDelayTotal.InnerText = ltrlFormTotal.Text
                'total

                'total per status
                spn01WithinTotal.InnerText = ltrlFormGood.Text
                spn01DueTotal.InnerText = ltrlFormDue.Text
                spn01DelayTotal.InnerText = ltrlFormDelay.Text
                'total per status

                'percentage
                spn01FormPercentageWithin.InnerText = Math.Truncate(ltrlFormGood.Text / ltrlFormTotal.Text * 100) & "%"
                spn01FormPercentageDue.InnerText = Math.Truncate(ltrlFormDue.Text / ltrlFormTotal.Text * 100) & "%"
                spn01FormPercentageDelay.InnerText = Math.Truncate(ltrlFormDelay.Text / ltrlFormTotal.Text * 100) & "%"
                'percentage

                'condition
                lbl01Total.Text = ltrlFormTotal.Text & " form(s)"
                If ltrlFormTotal.Text = "" Then pnl01Assigned.Visible = False
                'condition

                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindWorkOrder()

        'get work order
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	project ")
        Query.Append("	,description ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].assigned_to = [H].assigned_to and [D].project = [H].project and [D].Status not in ('Closed')),0) [Total] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].assigned_to = [H].assigned_to and [D].project = [H].project and [D].Status not in ('Closed') and [D].date_end > cast(getdate() as date)),0) [Good] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].assigned_to = [H].assigned_to and [D].project = [H].project and [D].Status not in ('Closed') and [D].date_end = cast(getdate() as date)),0) [Due] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].assigned_to = [H].assigned_to and [D].project = [H].project and [D].Status not in ('Closed') and [D].date_end < cast(getdate() as date)),0) [Delay] ")
        Query.Append("from ")
        Query.Append("	(select distinct ")
        Query.Append("		oop_wo_hdr.project  ")
        Query.Append("		,oop_project.description  ")
        Query.Append("		,oop_wo_hdr.assigned_to  ")
        Query.Append("	from  ")
        Query.Append("		oop_wo_hdr  ")
        Query.Append("		left join oop_project on oop_wo_hdr.project = oop_project.p_code ")
        Query.Append("	where  ")
        Query.Append("		oop_wo_hdr.assigned_to = '" & CIIS_EmpCode & "' ")
        Query.Append("		and oop_wo_hdr.status not in ('Closed')) [H] ")
        'get work order

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlWONo.Text = "" Then
                        ltrlWOProject.Text = DR.GetString(0)
                        ltrlWONo.Text = DR.GetString(1)
                        ltrlWOTotal.Text = DR.GetInt32(2)
                        ltrlWOGood.Text = DR.GetInt32(3)
                        ltrlWODue.Text = DR.GetInt32(4)
                        ltrlWODelay.Text = DR.GetInt32(5)
                    Else
                        ltrlWOProject.Text = ltrlWOProject.Text & "," & DR.GetString(0)
                        ltrlWONo.Text = ltrlWONo.Text & "," & DR.GetString(1)
                        ltrlWOTotal.Text = ltrlWOTotal.Text + DR.GetInt32(2)
                        ltrlWOGood.Text = ltrlWOGood.Text + DR.GetInt32(3)
                        ltrlWODue.Text = ltrlWODue.Text + DR.GetInt32(4)
                        ltrlWODelay.Text = ltrlWODelay.Text + DR.GetInt32(5)
                    End If

                End While

                'condition
                If ltrlWOTotal.Text = "" Then
                    pnl02WorkOrder.Visible = False
                Else
                    'total
                    spn02FormWithinTotal.InnerText = ltrlWOTotal.Text
                    spn02FormDueTotal.InnerText = ltrlWOTotal.Text
                    spn02FormDelayTotal.InnerText = ltrlWOTotal.Text
                    'total

                    'total per status
                    spn02WithinTotal.InnerText = ltrlWOGood.Text
                    spn02DueTotal.InnerText = ltrlWODue.Text
                    spn02DelayTotal.InnerText = ltrlWODelay.Text
                    'total per status

                    'percentage
                    spn02FormPercentageWithin.InnerText = Math.Truncate(ltrlWOGood.Text / ltrlWOTotal.Text * 100) & "%"
                    spn02FormPercentageDue.InnerText = Math.Truncate(ltrlWODue.Text / ltrlWOTotal.Text * 100) & "%"
                    spn02FormPercentageDelay.InnerText = Math.Truncate(ltrlWODelay.Text / ltrlWOTotal.Text * 100) & "%"
                    'percentage
                End If
                'condition

                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindTask()

        'get work order
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	TaskCode ")
        Query.Append("	,TaskName ")
        Query.Append("	,isnull((select count(1) from Form_HWTask [D] where [D].AssignTo = [H].AssignTo and [D].Status not in ('Close','Complete')),0) [Total] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask [D] where [D].AssignTo = [H].AssignTo and [D].Status not in ('Close','Complete') and [D].DateEnd > cast(getdate() as date)),0) [Good] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask [D] where [D].AssignTo = [H].AssignTo and [D].Status not in ('Close','Complete') and [D].DateEnd = cast(getdate() as date)),0) [Due] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask [D] where [D].AssignTo = [H].AssignTo and [D].Status not in ('Close','Complete') and [D].DateEnd < cast(getdate() as date)),0) [Delay] ")
        Query.Append("from ")
        Query.Append("	(select distinct ")
        Query.Append("		TaskCode  ")
        Query.Append("		,TaskName ")
        Query.Append("		,AssignTo ")
        Query.Append("	from  ")
        Query.Append("		Form_HWTask  ")
        Query.Append("	where  ")
        Query.Append("		AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("		and Status not in ('Close', 'Complete')) [H] ")
        'get work order

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlTaskNo.Text = "" Then
                        ltrlTask.Text = DR.GetString(0)
                        ltrlTaskNo.Text = DR.GetString(1)
                        ltrlTaskTotal.Text = DR.GetInt32(2)
                        ltrlTaskGood.Text = DR.GetInt32(3)
                        ltrlTaskDue.Text = DR.GetInt32(4)
                        ltrlTaskDelay.Text = DR.GetInt32(5)
                    Else
                        ltrlTask.Text = ltrlTask.Text & "," & DR.GetString(0)
                        ltrlTaskNo.Text = ltrlTaskNo.Text & "," & DR.GetString(1)
                        ltrlTaskTotal.Text = ltrlTaskTotal.Text + DR.GetInt32(2)
                        ltrlTaskGood.Text = ltrlTaskGood.Text + DR.GetInt32(3)
                        ltrlTaskDue.Text = ltrlTaskDue.Text + DR.GetInt32(4)
                        ltrlTaskDelay.Text = ltrlTaskDelay.Text + DR.GetInt32(5)
                    End If

                End While

                'condition
                If ltrlTaskTotal.Text = "" Then
                    pnl03ConstructionTask.Visible = False
                Else
                    'total
                    spn03CTWithinTotal.InnerText = ltrlTaskTotal.Text
                    spn03CTDueTotal.InnerText = ltrlTaskTotal.Text
                    spn03CTDelayTotal.InnerText = ltrlTaskTotal.Text
                    'total

                    'total per status
                    spn03WithinTotal.InnerText = ltrlTaskGood.Text
                    spn03DueTotal.InnerText = ltrlTaskDue.Text
                    spn03DelayTotal.InnerText = ltrlTaskDelay.Text
                    'total per status

                    'percentage
                    spn03CTPercentageWithin.InnerText = Math.Truncate(ltrlTaskGood.Text / ltrlTaskTotal.Text * 100) & "%"
                    spn03CTPercentageDue.InnerText = Math.Truncate(ltrlTaskDue.Text / ltrlTaskTotal.Text * 100) & "%"
                    spn03CTPercentageDelay.InnerText = Math.Truncate(ltrlTaskDelay.Text / ltrlTaskTotal.Text * 100) & "%"
                    'percentage
                End If
                'condition

                'condition
                lbl03Total.Text = ltrlTaskTotal.Text & " form(s)"
                If ltrlTaskTotal.Text = "" Then pnl03ConstructionTask.Visible = False
                'condition

                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindRequest()

        'get work order
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	tbl_from ")
        Query.Append("	,description ")
        Query.Append("	,isnull((select count(1) from form_hdr [D] where [D].created_by  = [H].created_by And [D].tbl_from = [H].tbl_from And [D].status Not In ('Accepted','Declined','Cancelled')),0) [Total] ")
        Query.Append("	,isnull((select count(1) from Form_AssignedApprover [A] where [A].created_by = [H].created_by and [A].tbl_from = [H].tbl_from and [A].DateEnd > cast(getdate() as date)),0) [Good] ")
        Query.Append("	,isnull((select count(1) from Form_AssignedApprover [A] where [A].created_by = [H].created_by and [A].tbl_from = [H].tbl_from and [A].DateEnd = cast(getdate() as date)),0) [Due] ")
        Query.Append("	,isnull((select count(1) from Form_AssignedApprover [A] where [A].created_by = [H].created_by and [A].tbl_from = [H].tbl_from and [A].DateEnd < cast(getdate() as date)),0) [Delay] ")
        Query.Append("from ")
        Query.Append("	(select distinct ")
        Query.Append("		form_hdr.tbl_from  ")
        Query.Append("		,oop_form_type.description  ")
        Query.Append("		,form_hdr.created_by  ")
        Query.Append("	from  ")
        Query.Append("		form_hdr  ")
        Query.Append("		left join oop_form_type on form_hdr.form_type =  oop_form_type.t_code ")
        Query.Append("	where  ")
        Query.Append("		form_hdr.created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("		and form_hdr.status not in ('Accepted','Declined','Cancelled')) [H] ")
        'get work order

        'variable
        Dim Good As Integer
        Dim Due As Integer
        Dim Delay As Integer
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlRequest.Text = "" Then
                        ltrlRequest.Text = DR.GetString(0)
                        ltrlRequestNo.Text = DR.GetString(1)
                        ltrlRequestTotal.Text = DR.GetInt32(2)
                        ltrlRequestGood.Text = DR.GetInt32(3)
                        ltrlRequestDue.Text = DR.GetInt32(4)
                        ltrlRequestDelay.Text = DR.GetInt32(5)

                        Good = DR.GetInt32(3)
                        Due = DR.GetInt32(4)
                        Delay = DR.GetInt32(5)
                    Else
                        ltrlRequest.Text = ltrlRequest.Text & "," & DR.GetString(0)
                        ltrlRequestNo.Text = ltrlRequestNo.Text & "," & DR.GetString(1)
                        ltrlRequestTotal.Text = ltrlRequestTotal.Text + DR.GetInt32(2)
                        ltrlRequestGood.Text = ltrlRequestGood.Text + DR.GetInt32(3)
                        ltrlRequestDue.Text = ltrlRequestDue.Text + DR.GetInt32(4)
                        ltrlRequestDelay.Text = ltrlRequestDelay.Text + DR.GetInt32(5)

                        Good = Good + DR.GetInt32(3)
                        Due = Due + DR.GetInt32(4)
                        Delay = Delay + DR.GetInt32(5)
                    End If

                End While

                'condition
                If ltrlRequestTotal.Text = "" Then
                    pnl04Request.Visible = False
                Else
                    'total
                    spn04ReqWithinTotal.InnerText = ltrlRequestTotal.Text
                    spn04ReqDueTotal.InnerText = ltrlRequestTotal.Text
                    spn04ReqDelayTotal.InnerText = ltrlRequestTotal.Text
                    'total

                    'total per status
                    spn04WithinTotal.InnerText = ltrlRequestGood.Text
                    spn04DueTotal.InnerText = ltrlRequestDue.Text
                    spn04DelayTotal.InnerText = ltrlRequestDelay.Text
                    'total per status

                    If ltrlRequestTotal.Text = Math.Truncate(Good + Due + Delay) Then
                        'percentage
                        spn04ReqPercentageWithin.InnerText = Math.Truncate(ltrlRequestGood.Text / ltrlRequestTotal.Text * 100) & "%"
                        spn04ReqPercentageDue.InnerText = Math.Truncate(ltrlRequestDue.Text / ltrlRequestTotal.Text * 100) & "%"
                        spn04ReqPercentageDelay.InnerText = Math.Truncate(ltrlRequestDelay.Text / ltrlRequestTotal.Text * 100) & "%"
                        'percentage
                    Else
                        Dim sum = Math.Truncate(Good + Due + Delay)
                        Dim diff As Integer = Math.Truncate(ltrlRequestTotal.Text - sum)
                        ltrlRequestTotal.Text = Math.Truncate(ltrlRequestTotal.Text - diff)
                        'percentage
                        spn04ReqPercentageWithin.InnerText = Math.Truncate(ltrlRequestGood.Text / ltrlRequestTotal.Text * 100) & "%"
                        spn04ReqPercentageDue.InnerText = Math.Truncate(ltrlRequestDue.Text / ltrlRequestTotal.Text * 100) & "%"
                        spn04ReqPercentageDelay.InnerText = Math.Truncate(ltrlRequestDelay.Text / ltrlRequestTotal.Text * 100) & "%"
                        'percentage
                    End If

                End If
                'condition

                'condition
                lbl04Total.Text = ltrlRequestTotal.Text & " form(s)"
                If ltrlRequestTotal.Text = "" Then pnl04Request.Visible = False
                'condition

                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindRequestWO()

        'get work order
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	project ")
        Query.Append("	,description ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].reported_by = [H].reported_by and [D].assigned_to not in ('') and [D].project = [H].project and [D].Status not in ('Closed')),0) [Total] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].reported_by = [H].reported_by and [D].assigned_to not in ('') and [D].project = [H].project and [D].Status not in ('Closed') and [D].date_end > cast(getdate() as date)),0) [Good] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].reported_by = [H].reported_by and [D].assigned_to not in ('') and [D].project = [H].project and [D].Status not in ('Closed') and [D].date_end = cast(getdate() as date)),0) [Due] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr [D] where [D].reported_by = [H].reported_by and [D].assigned_to not in ('') and [D].project = [H].project and [D].Status not in ('Closed') and [D].date_end < cast(getdate() as date)),0) [Delay] ")
        Query.Append("from ")
        Query.Append("	(select distinct ")
        Query.Append("		oop_wo_hdr.project  ")
        Query.Append("		,oop_project.description  ")
        Query.Append("		,oop_wo_hdr.reported_by  ")
        Query.Append("	from  ")
        Query.Append("		oop_wo_hdr  ")
        Query.Append("		left join oop_project on oop_wo_hdr.project = oop_project.p_code ")
        Query.Append("	where  ")
        Query.Append("		oop_wo_hdr.reported_by = '" & CIIS_EmpCode & "' ")
        Query.Append("		and oop_wo_hdr.assigned_to not in ('') ")
        Query.Append("		and oop_wo_hdr.status not in ('Closed')) [H] ")
        'get work order

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlRequestWONo.Text = "" Then
                        ltrlRequestWOProject.Text = DR.GetString(0)
                        ltrlRequestWONo.Text = DR.GetString(1)
                        ltrlRequestWOTotal.Text = DR.GetInt32(2)
                        ltrlRequestWOGood.Text = DR.GetInt32(3)
                        ltrlRequestWODue.Text = DR.GetInt32(4)
                        ltrlRequestWODelay.Text = DR.GetInt32(5)
                    Else
                        ltrlRequestWOProject.Text = ltrlRequestWOProject.Text & "," & DR.GetString(0)
                        ltrlRequestWONo.Text = ltrlRequestWONo.Text & "," & DR.GetString(1)
                        ltrlRequestWOTotal.Text = ltrlRequestWOTotal.Text + DR.GetInt32(2)
                        ltrlRequestWOGood.Text = ltrlRequestWOGood.Text + DR.GetInt32(3)
                        ltrlRequestWODue.Text = ltrlRequestWODue.Text + DR.GetInt32(4)
                        ltrlRequestWODelay.Text = ltrlRequestWODelay.Text + DR.GetInt32(2)
                    End If

                End While

                'condition
                If ltrlRequestWOTotal.Text = "" Then
                    pnl05RequestWO.Visible = False
                Else
                    'total
                    spn05ReqWOWithinTotal.InnerText = ltrlRequestWOTotal.Text
                    spn05ReqWODueTotal.InnerText = ltrlRequestWOTotal.Text
                    spn05ReqWODelayTotal.InnerText = ltrlRequestWOTotal.Text
                    'total

                    'total per status
                    spn05WithinTotal.InnerText = ltrlRequestWOGood.Text
                    spn05DueTotal.InnerText = ltrlRequestWODue.Text
                    spn05DelayTotal.InnerText = ltrlRequestWODelay.Text
                    'total per status

                    'percentage
                    spn05ReqPercentageWithin.InnerText = Math.Truncate(ltrlRequestWOGood.Text / ltrlRequestWOTotal.Text * 100) & "%"
                    spn05ReqWOPercentageDue.InnerText = Math.Truncate(ltrlRequestWODue.Text / ltrlRequestWOTotal.Text * 100) & "%"
                    spn05ReqWOPercentageDelay.InnerText = Math.Truncate(ltrlRequestWODelay.Text / ltrlRequestWOTotal.Text * 100) & "%"
                    'percentage
                End If
                'condition

                'condition
                lbl05Total.Text = ltrlRequestWOTotal.Text & " form(s)"
                If ltrlRequestWOTotal.Text = "" Then pnl05RequestWO.Visible = False
                'condition

                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

#End Region

End Class