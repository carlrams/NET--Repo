Imports System.Data.SqlClient
Imports System.IO

Public Class DSB070200
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_Deparment As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_Deparment = CIIS_UserInfo("CIIS_Department")

        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("DSB", "DSB070200")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'load
            bind01Overall()
            bind02Department()
            bind03Priority()
            bind04ImplementerStatus()
            bind04ImplementerPriority()
            'load

        End If
        'load page
    End Sub

#End Region

#Region "Function"

    Function bind01Overall()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'New') [New] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'On-Going') [Ongoing] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'On-Hold') [Onhold] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'Not Started') [Notstarted] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'Complete') [Complete] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'IT' and [C].Status = 'New') [IT_New] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'IT' and [C].Status = 'On-Going') [IT_Ongoing] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'IT' and [C].Status = 'On-Hold') [IT_Onhold] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'IT' and [C].Status = 'Not Started') [IT_Notstarted] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'IT' and [C].Status = 'Complete') [IT_Complete] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'SD' and [C].Status = 'New') [SD_New] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'SD' and [C].Status = 'On-Going') [SD_Ongoing] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'SD' and [C].Status = 'On-Hold') [SD_Onhold] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'SD' and [C].Status = 'Not Started') [SD_Notstarted] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join Parm_BTSCategory [D] on [C].Category = [D].Description where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [D].Section = 'SD' and [C].Status = 'Complete') [SD_Complete] ")
        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'html
                    lbl01Total.Text = (DR("New") + DR("Ongoing") + DR("Onhold") + DR("Notstarted") + DR("Complete")) & " Total Ticket"
                    lbl01New.Text = DR("New")
                    lbl01Ongoing.Text = DR("Ongoing")
                    lbl01Onhold.Text = DR("Onhold")
                    lbl01Notstarted.Text = DR("Notstarted")
                    lbl01Complete.Text = DR("Complete")
                    'html

                    'graph
                    ltrl01New.Text = DR("IT_New") & "," & DR("SD_New")
                    ltrl01Ongoing.Text = DR("IT_Ongoing") & "," & DR("SD_Ongoing")
                    ltrl01Onhold.Text = DR("IT_Onhold") & "," & DR("SD_Onhold")
                    ltrl01Notstarted.Text = DR("IT_Notstarted") & "," & DR("SD_Notstarted")
                    ltrl01Complete.Text = DR("IT_Complete") & "," & DR("SD_Complete")
                    'graph

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind02Department()

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   (case [DepName] ")
        Query.Append("      when 'AAD' then 'background-color:#efa43c' ")
        Query.Append("      when 'BTD' then 'background-color:#b5b5c3' ")
        Query.Append("      when 'CONS' then 'background-color:#31d058' ")
        Query.Append("      when 'CS' then 'background-color:#fe463a' ")
        Query.Append("      when 'ENG' then 'background-color:#236bfe' ")
        Query.Append("      when 'EXC' then 'background-color:#67c182' ")
        Query.Append("      when 'FIN' then 'background-color:#f9d65e' ")
        Query.Append("      when 'HRA' then 'background-color:#ed6646' ")
        Query.Append("      when 'IA' then 'background-color:#8462c9' ")
        Query.Append("      when 'ILA' then 'background-color:#43ab9f' ")
        Query.Append("      when 'MKTG' then 'background-color:#feb54d' ")
        Query.Append("      when 'OCE' then 'background-color:#e372b1' ")
        Query.Append("      when 'OOP' then 'background-color:#48bdee' ")
        Query.Append("      when 'PDDRE' then 'background-color:#a3c039' ")
        Query.Append("      when 'PMG' then 'background-color:#b5b5c3' ")
        Query.Append("      when 'SALES' then 'background-color:#a75dba' ")
        Query.Append("      when 'SCM' then 'background-color:#6edbdb' end) [Background] ")
        Query.Append("   ,(case [DepName] ")
        Query.Append("      when 'AAD' then '#efa43c' ")
        Query.Append("      when 'BTD' then '#b5b5c3' ")
        Query.Append("      when 'CONS' then '#31d058' ")
        Query.Append("      when 'CS' then '#fe463a' ")
        Query.Append("      when 'ENG' then '#236bfe' ")
        Query.Append("      when 'EXC' then '#67c182' ")
        Query.Append("      when 'FIN' then '#f9d65e' ")
        Query.Append("      when 'HRA' then '#ed6646' ")
        Query.Append("      when 'IA' then '#8462c9' ")
        Query.Append("      when 'ILA' then '#43ab9f' ")
        Query.Append("      when 'MKTG' then '#feb54d' ")
        Query.Append("      when 'OCE' then '#e372b1' ")
        Query.Append("      when 'OOP' then '#48bdee' ")
        Query.Append("      when 'PDDRE' then '#a3c039' ")
        Query.Append("      when 'PMG' then '#b5b5c3' ")
        Query.Append("      when 'SALES' then '#a75dba' ")
        Query.Append("      when 'SCM' then '#6edbdb' end) [Color] ")
        Query.Append("   ,[DepCode] ")
        Query.Append("   ,[DepName] ")
        Query.Append("   ,(select cast(count(1) as decimal(21,2)) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join employee [D] on [B].created_by = [D].emp_no left join department [E] on [D].dept_code = [E].dept_code where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [E].dept_code = [A].DepCode) [Total] ")
        Query.Append("   ,format((select cast(count(1) as decimal(21,2)) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join employee [D] on [B].created_by = [D].emp_no left join department [E] on [D].dept_code = [E].dept_code where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [E].dept_code = [A].DepCode) / (select cast(count(1) as decimal(21,2)) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode left join employee [D] on [B].created_by = [D].emp_no left join department [E] on [D].dept_code = [E].dept_code where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled')) * 100.00,'N2') [Rate] ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      [D].dept_code [DepCode] ")
        Query.Append("      ,[D].abbr [DepName] ")
        Query.Append("   from ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
        Query.Append("      left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("      left join department [D] on [C].dept_code = [D].dept_code ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_BTS' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [DepName] ")
        'query

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Background"))
        dtable.Columns.Add(New DataColumn("Color"))
        dtable.Columns.Add(New DataColumn("DepCode"))
        dtable.Columns.Add(New DataColumn("DepName"))
        dtable.Columns.Add(New DataColumn("Total"))
        'Create datatable and columns

        'set value
        ltrl02Code.Text = ""
        ltrl02Value.Text = ""
        ltrl02Color.Text = ""
        ltrl02Name.Text = ""
        'set value

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    ltrl02Code.Text = IIf(ltrl02Code.Text = "", DR("DepCode"), ltrl02Code.Text & "," & DR("DepCode"))
                    ltrl02Value.Text = IIf(ltrl02Value.Text = "", DR("Total"), ltrl02Value.Text & "," & DR("Total"))
                    ltrl02Color.Text = IIf(ltrl02Color.Text = "", DR("Color"), ltrl02Color.Text & "," & DR("Color"))
                    ltrl02Name.Text = IIf(ltrl02Name.Text = "", DR("DepName"), ltrl02Name.Text & "," & DR("DepName"))
                    Dim Total As String = "<div id='" & DR("DepCode") & "' data-name='" & DR("DepName") & "' class='d-flex flex-column w-100 pointer' onclick='ViewOpenForm(this, this.id);'><div class='d-flex flex-stack mb-2'><span class='text-dark fs-6 fw-bold'>" & DR("Total") & "</span> <span class='text-muted fs-8 fw-bold'>" & DR("Rate") & "%</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(DR("Rate")) >= 66.66, "bg-sucess", IIf(CDbl(DR("Rate")) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & DR("Rate") & "%' aria-valuenow='" & DR("Rate") & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>"
                    'set value

                    'add new row
                    Dim NewRowValues As Object() = {DR("Background"), DR("Color"), DR("DepCode"), DR("DepName"), Total}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'now bind datatable to gridview... 
        gv02Department.DataSource = dtable
        gv02Department.DataBind()
        'now bind datatable to gridview... 

    End Function

    Function bind03Priority()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Priority = 'Critical') [Critical] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Priority = 'High') [High] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Priority = 'Medium') [Medium] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Priority = 'Low') [Low] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Priority = 'Lowest') [Lowest] ")
        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'html
                    lbl03Critical.Text = DR("Critical")
                    lbl03High.Text = DR("High")
                    lbl03Medium.Text = DR("Medium")
                    lbl03Low.Text = DR("Low")
                    lbl03Lowest.Text = DR("Lowest")
                    'html

                    'graph
                    ltrl03Critical.Text = DR("Critical")
                    ltrl03High.Text = DR("High")
                    ltrl03Medium.Text = DR("Medium")
                    ltrl03Low.Text = DR("Low")
                    ltrl03Lowest.Text = DR("Lowest")
                    'graph

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind04ImplementerStatus()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [Code] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,cast([Total02] as int) [Total] ")
        Query.Append("   ,(case when [Total01] > 0 then format([Total02] / [Total01] * 100.00,'N2') else '0.00' end) [Rate] ")
        Query.Append("   ,[Ongoing] ")
        Query.Append("   ,[Onhold] ")
        Query.Append("   ,[Notstarted] ")
        Query.Append("   ,[Complete] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      [A].emp_no [Code] ")
        Query.Append("      ,dbo.ProperCase((select top 1 dbo.ProperCase(Data) from dbo.SplitString([A].first_name,' '))) [Name] ")
        Query.Append("      ,(select cast(count(1) as decimal(21,2)) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status in ('On-Going','On-Hold','Not Started','Complete')) [Total01] ")
        Query.Append("      ,(select cast(count(1) as decimal(21,2)) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status in ('On-Going','On-Hold','Not Started','Complete')) [Total02] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'On-Going') [Ongoing] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'On-Hold') [Onhold] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'Not Started') [Notstarted] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'Complete') [Complete] ")
        Query.Append("      ,[A].DateHired ")
        Query.Append("   from ")
        Query.Append("      employee [A] ")
        Query.Append("   where ")
        Query.Append("      [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("      and [A].dept_code = '2023000009' ")
        Query.Append("      and [A].lock = 1) [A] ")
        Query.Append("order by ")
        Query.Append("   [A].DateHired ")
        Query.Append("   ,[A].Name ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Total"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    ltrl04Name.Text = IIf(ltrl04Name.Text = "", DR("Name"), ltrl04Name.Text & "," & DR("Name"))
                    ltrl04Ongoing.Text = IIf(ltrl04Ongoing.Text = "", DR("Ongoing"), ltrl04Ongoing.Text & "," & DR("Ongoing"))
                    ltrl04Onhold.Text = IIf(ltrl04Onhold.Text = "", DR("Onhold"), ltrl04Onhold.Text & "," & DR("Onhold"))
                    ltrl04Notstarted.Text = IIf(ltrl04Notstarted.Text = "", DR("Notstarted"), ltrl04Notstarted.Text & "," & DR("Notstarted"))
                    ltrl04Complete.Text = IIf(ltrl04Complete.Text = "", DR("Complete"), ltrl04Complete.Text & "," & DR("Complete"))

                    Dim Total As String = "<div id='" & DR("Code") & "' data-name='" & DR("Name") & "' class='d-flex flex-column w-100 pointer' onclick='ViewOpenForm(this, this.id);'><div class='d-flex flex-stack mb-2'><span class='text-dark fs-6 fw-bold'>" & DR("Total") & "</span> <span class='text-muted fs-8 fw-bold'>" & DR("Rate") & "%</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(DR("Rate")) >= 66.66, "bg-sucess", IIf(CDbl(DR("Rate")) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & DR("Rate") & "%' aria-valuenow='" & DR("Rate") & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>"
                    'set value

                    'add new row
                    Dim NewRowValues As Object() = {DR("Name"), Total}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'now bind datatable to gridview... 
        gv04ImplementerStatus.DataSource = dtable
        gv04ImplementerStatus.DataBind()
        'now bind datatable to gridview... 

    End Function

    Function bind04ImplementerPriority()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [Code] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,cast([Total02] as int) [Total] ")
        Query.Append("   ,(case when [Total01] > 0 then format([Total02] / [Total01] * 100.00,'N2') else '0.00' end) [Rate] ")
        Query.Append("   ,[Critical] ")
        Query.Append("   ,[High] ")
        Query.Append("   ,[Medium] ")
        Query.Append("   ,[Low] ")
        Query.Append("   ,[Lowest] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      [A].emp_no [Code] ")
        Query.Append("      ,dbo.ProperCase((select top 1 dbo.ProperCase(Data) from dbo.SplitString([A].first_name,' '))) [Name] ")
        Query.Append("      ,(select cast(count(1) as decimal(21,2)) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status in ('On-Going','On-Hold','Not Started','Complete')) [Total01] ")
        Query.Append("      ,(select cast(count(1) as decimal(21,2)) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status in ('On-Going','On-Hold','Not Started','Complete')) [Total02] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Priority = 'Critical') [Critical] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Priority = 'High') [High] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Priority = 'Medium') [Medium] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Priority = 'Low') [Low] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Priority = 'Lowest') [Lowest] ")
        Query.Append("      ,[A].DateHired ")
        Query.Append("   from ")
        Query.Append("      employee [A] ")
        Query.Append("   where ")
        Query.Append("      [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("      and [A].dept_code = '2023000009' ")
        Query.Append("      and [A].lock = 1) [A] ")
        Query.Append("order by ")
        Query.Append("   [A].DateHired ")
        Query.Append("   ,[A].Name ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Total"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    ltrl05Name.Text = IIf(ltrl05Name.Text = "", DR("Name"), ltrl05Name.Text & "," & DR("Name"))
                    ltrl05Critical.Text = IIf(ltrl05Critical.Text = "", DR("Critical"), ltrl05Critical.Text & "," & DR("Critical"))
                    ltrl05High.Text = IIf(ltrl05High.Text = "", DR("High"), ltrl05High.Text & "," & DR("High"))
                    ltrl05Medium.Text = IIf(ltrl05Medium.Text = "", DR("Medium"), ltrl05Medium.Text & "," & DR("Medium"))
                    ltrl05Low.Text = IIf(ltrl05Low.Text = "", DR("Low"), ltrl05Low.Text & "," & DR("Low"))
                    ltrl05Lowest.Text = IIf(ltrl05Lowest.Text = "", DR("Lowest"), ltrl05Lowest.Text & "," & DR("Lowest"))

                    Dim Total As String = "<div id='" & DR("Code") & "' data-name='" & DR("Name") & "' class='d-flex flex-column w-100 pointer' onclick='ViewOpenForm(this, this.id);'><div class='d-flex flex-stack mb-2'><span class='text-dark fs-6 fw-bold'>" & DR("Total") & "</span> <span class='text-muted fs-8 fw-bold'>" & DR("Rate") & "%</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(DR("Rate")) >= 66.66, "bg-sucess", IIf(CDbl(DR("Rate")) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & DR("Rate") & "%' aria-valuenow='" & DR("Rate") & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>"
                    'set value

                    'add new row
                    Dim NewRowValues As Object() = {DR("Name"), Total}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'now bind datatable to gridview... 
        gv05ImplementerPriority.DataSource = dtable
        gv05ImplementerPriority.DataBind()
        'now bind datatable to gridview... 

    End Function

#End Region

End Class