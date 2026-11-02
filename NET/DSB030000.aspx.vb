Imports System.Data.SqlClient

Public Class DSB030000
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        'user info

        'active account / menu
        Master.setActiveMenu("DSB", "DSB030000")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'display record
            bind01TotalForm()
            bind02OpenFormPerDepartment()
            bind03OpenFormPerYear()
            bind04OpenFormAging()
            tbx05DateFrom.Value = Format(Date.Now, "MM") & "/01/" & Format(Date.Now, "yyyy")
            tbx05DateTo.Value = Format(DateAdd(DateInterval.Day, -1, CDate(DateAdd(DateInterval.Month, 1, CDate(Format(Date.Now, "MM") & "/01/" & Format(Date.Now, "yyyy"))))), "MM/dd/yyyy")
            bind05InOut(tbx05DateFrom.Value, tbx05DateTo.Value)
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Private Sub btn05Filter_Click(sender As Object, e As EventArgs) Handles btn05Filter.Click
        bind05InOut(tbx05DateFrom.Value, tbx05DateTo.Value)
    End Sub

#End Region

#Region "Function"

    Function bind01TotalForm()

        Dim Query As New StringBuilder

        'get total forms
        Query.Append("select")
        Query.Append("  Form ")
        Query.Append("  ,Format(Total,'N2') [Total] ")
        Query.Append("  ,Prev ")
        Query.Append("  ,Jan ")
        Query.Append("  ,Feb ")
        Query.Append("  ,Mar ")
        Query.Append("  ,Apr ")
        Query.Append("  ,May ")
        Query.Append("  ,Jun ")
        Query.Append("  ,Jul ")
        Query.Append("  ,Aug ")
        Query.Append("  ,Sep ")
        Query.Append("  ,Oct ")
        Query.Append("  ,Nov ")
        Query.Append("  ,Dec ")
        Query.Append("from ")
        Query.Append("  Rpt_TotalForm ")
        Query.Append("order by ")
        Query.Append("  SeqNo ")
        'get total forms

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If DR.GetString(0).ToString = "Total" Then
                        ltrl01TotalForm_Total.Text = DR("Prev") & "," & DR("Jan") & "," & DR("Feb") & "," & DR("Mar") & "," & DR("Apr") & "," & DR("May") & "," & DR("Jun") & "," & DR("Jul") & "," & DR("Aug") & "," & DR("Sep") & "," & DR("Oct") & "," & DR("Nov") & "," & DR("Dec")
                        lbl01TotalForm_Total.Text = DR("Total")

                    ElseIf DR.GetString(0).ToString = "Closed" Then
                        ltrl01TotalForm_Closed.Text = DR("Prev") & "," & DR("Jan") & "," & DR("Feb") & "," & DR("Mar") & "," & DR("Apr") & "," & DR("May") & "," & DR("Jun") & "," & DR("Jul") & "," & DR("Aug") & "," & DR("Sep") & "," & DR("Oct") & "," & DR("Nov") & "," & DR("Dec")
                        lbl01TotalForm_Closed.Text = DR("Total")

                    ElseIf DR.GetString(0).ToString = "Open" Then
                        ltrl01TotalForm_Open.Text = DR("Prev") & "," & DR("Jan") & "," & DR("Feb") & "," & DR("Mar") & "," & DR("Apr") & "," & DR("May") & "," & DR("Jun") & "," & DR("Jul") & "," & DR("Aug") & "," & DR("Sep") & "," & DR("Oct") & "," & DR("Nov") & "," & DR("Dec")
                        lbl01TotalForm_Open.Text = DR("Total")
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind02OpenFormPerDepartment()

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("  (case DepName ")
        Query.Append("     when 'AAD' then 'background-color:#efa43c' ")
        Query.Append("     when 'BTD' then 'background-color:#b5b5c3' ")
        Query.Append("     when 'CONS' then 'background-color:#31d058' ")
        Query.Append("     when 'CS' then 'background-color:#fe463a' ")
        Query.Append("     when 'ENG' then 'background-color:#236bfe' ")
        Query.Append("     when 'EXC' then 'background-color:#67c182' ")
        Query.Append("     when 'FIN' then 'background-color:#f9d65e' ")
        Query.Append("     when 'HRA' then 'background-color:#ed6646' ")
        Query.Append("     when 'IA' then 'background-color:#8462c9' ")
        Query.Append("     when 'ILA' then 'background-color:#43ab9f' ")
        Query.Append("     when 'MKTG' then 'background-color:#feb54d' ")
        Query.Append("     when 'OCE' then 'background-color:#e372b1' ")
        Query.Append("     when 'OOP' then 'background-color:#48bdee' ")
        Query.Append("     when 'PDDRE' then 'background-color:#a3c039' ")
        Query.Append("     when 'PMG' then 'background-color:#b5b5c3' ")
        Query.Append("     when 'SALES' then 'background-color:#a75dba' ")
        Query.Append("     when 'SCM' then 'background-color:#6edbdb' end) [Background] ")
        Query.Append("  ,(case DepName ")
        Query.Append("     when 'AAD' then '#efa43c' ")
        Query.Append("     when 'BTD' then '#b5b5c3' ")
        Query.Append("     when 'CONS' then '#31d058' ")
        Query.Append("     when 'CS' then '#fe463a' ")
        Query.Append("     when 'ENG' then '#236bfe' ")
        Query.Append("     when 'EXC' then '#67c182' ")
        Query.Append("     when 'FIN' then '#f9d65e' ")
        Query.Append("     when 'HRA' then '#ed6646' ")
        Query.Append("     when 'IA' then '#8462c9' ")
        Query.Append("     when 'ILA' then '#43ab9f' ")
        Query.Append("     when 'MKTG' then '#feb54d' ")
        Query.Append("     when 'OCE' then '#e372b1' ")
        Query.Append("     when 'OOP' then '#48bdee' ")
        Query.Append("     when 'PDDRE' then '#a3c039' ")
        Query.Append("     when 'PMG' then '#b5b5c3' ")
        Query.Append("     when 'SALES' then '#a75dba' ")
        Query.Append("     when 'SCM' then '#6edbdb' end) [Color] ")
        Query.Append("  ,DepCode ")
        Query.Append("  ,DepName ")
        'Query.Append("  ,Format(Total,'N0') [Total] ")
        'Query.Append("  ,Format(Rate,'N2') [Rate] ")
        Query.Append("  ,Total ")
        Query.Append("  ,Rate ")
        Query.Append("from ")
        Query.Append("  Rpt_OpenForm [A] ")
        Query.Append("order by ")
        Query.Append("  SeqNo ")
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
        ltrl02OpenFormPerDepartment_Code.Text = ""
        ltrl02OpenFormPerDepartment_Value.Text = ""
        ltrl02OpenFormPerDepartment_Color.Text = ""
        ltrl02OpenFormPerDepartment_DeptName.Text = ""
        'set value

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    ltrl02OpenFormPerDepartment_Code.Text = IIf(ltrl02OpenFormPerDepartment_Code.Text = "", DR("DepCode"), ltrl02OpenFormPerDepartment_Code.Text & "," & DR("DepCode"))
                    ltrl02OpenFormPerDepartment_Value.Text = IIf(ltrl02OpenFormPerDepartment_Value.Text = "", DR("Total"), ltrl02OpenFormPerDepartment_Value.Text & "," & DR("Total"))
                    ltrl02OpenFormPerDepartment_Color.Text = IIf(ltrl02OpenFormPerDepartment_Color.Text = "", DR("Color"), ltrl02OpenFormPerDepartment_Color.Text & "," & DR("Color"))
                    ltrl02OpenFormPerDepartment_DeptName.Text = IIf(ltrl02OpenFormPerDepartment_DeptName.Text = "", DR("DepName"), ltrl02OpenFormPerDepartment_DeptName.Text & "," & DR("DepName"))
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
        gv02OpenFormPerDepartment.DataSource = dtable
        gv02OpenFormPerDepartment.DataBind()
        'now bind datatable to gridview... 

    End Function

    Function bind03OpenFormPerYear()

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("  (case ")
        Query.Append("     when [A].Year < year(getdate()) then 'background-color:#f1416c' ")
        Query.Append("     when [A].Year = year(getdate()) then 'background-color:#279852' end) [Background] ")
        Query.Append("  ,[A].Year ")
        Query.Append("  ,Format([A].Total,'N0') [Total] ")
        Query.Append("  ,Format((select CAST([A].Total AS DECIMAL(21,2)) / sum(CAST([B].Total AS DECIMAL(21,2))) from Rpt_OpenFormperYear [B]) * 100.00,'N2') [Rate] ")
        Query.Append("from ")
        Query.Append("  Rpt_OpenFormperYear [A] ")
        Query.Append("order by ")
        Query.Append("  [A].SeqNo desc ")
        'query

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Background"))
        dtable.Columns.Add(New DataColumn("Year"))
        dtable.Columns.Add(New DataColumn("Total"))
        'Create datatable and columns

        'set value
        Dim Previous = 0
        Dim Current = 0
        ltrl03OpenFormPerYear_Previous.Text = ""
        ltrl03OpenFormPerYear_Current.Text = ""
        'set value

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Previous = Previous + IIf(DR("Year") < Year(Date.Now), DR("Total"), 0)
                    Current = Current + IIf(DR("Year") = Year(Date.Now), DR("Total"), 0)
                    Dim Total As String = "<div id='" & DR("Year") & "' class='d-flex flex-column pointer w-100' onclick='ViewOpenYear(this.id);'><div class='d-flex flex-stack mb-2'><span class='text-dark fs-6 fw-bold' >" & DR("Total") & "</span> <span class='text-muted fs-8 fw-bold'>" & DR("Rate") & "%</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(DR("Rate")) >= 66.66, "bg-sucess", IIf(CDbl(DR("Rate")) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & DR("Rate") & "%' aria-valuenow='" & DR("Rate") & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>"
                    'set value

                    'add new row
                    Dim NewRowValues As Object() = {DR("Background"), DR("Year"), Total}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'set value
        ltrl03OpenFormPerYear_Previous.Text = Previous
        ltrl03OpenFormPerYear_Current.Text = Current
        'set value

        'now bind datatable to gridview... 
        gv02OpenFormPerYear.DataSource = dtable
        gv02OpenFormPerYear.DataBind()
        'now bind datatable to gridview... 

    End Function

    Function bind04OpenFormAging()

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("  'background-color:#279852' [Background] ")
        Query.Append("  ,[A].Aging ")
        Query.Append("  ,[A].Total ")
        Query.Append("  ,Format((select CAST([A].Total AS DECIMAL(21,2)) / sum(CAST([B].Total AS DECIMAL(21,2))) from Rpt_AgingForm [B]) * 100.00,'N2') [Rate] ")
        Query.Append("from ")
        Query.Append("  Rpt_AgingForm [A] ")
        Query.Append("order by ")
        Query.Append("  SeqNo ")
        'query

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Background"))
        dtable.Columns.Add(New DataColumn("Aging"))
        dtable.Columns.Add(New DataColumn("Total"))
        'Create datatable and columns

        'set value
        ltrl04OpenFormAging_Category.Text = ""
        ltrl04OpenFormAging_Data.Text = ""
        'set value

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    If ltrl04OpenFormAging_Category.Text = "" Then
                        ltrl04OpenFormAging_Category.Text = DR("Aging")
                        ltrl04OpenFormAging_Data.Text = DR("Total")
                    Else
                        ltrl04OpenFormAging_Category.Text = ltrl04OpenFormAging_Category.Text & "," & DR("Aging")
                        ltrl04OpenFormAging_Data.Text = ltrl04OpenFormAging_Data.Text & "," & DR("Total")
                    End If

                    Dim Total As String = "<div id='" & DR("Aging") & "' class='d-flex flex-column pointer w-100' onclick='ViewAgingForm(this.id);'><div class='d-flex flex-stack mb-2'><span class='text-dark fs-6 fw-bold'>" & DR("Total") & "</span> <span class='text-muted fs-8 fw-bold'>" & DR("Rate") & "%</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(DR("Rate")) >= 66.66, "bg-sucess", IIf(CDbl(DR("Rate")) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & DR("Rate") & "%' aria-valuenow='" & DR("Rate") & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>"
                    'set value

                    'add new row
                    Dim NewRowValues As Object() = {DR("Background"), DR("Aging"), Total}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'now bind datatable to gridview... 
        gv04OpenFormAging.DataSource = dtable
        gv04OpenFormAging.DataBind()
        'now bind datatable to gridview... 

    End Function

    Function bind05InOut(DateFrom As String, DateTo As String)

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   'background-color:#279852' [Background] ")
        Query.Append("   ,[DepCode] ")
        Query.Append("   ,[DepName] ")
        Query.Append("   ,[IN] ")
        Query.Append("   ,[OUT] ")
        Query.Append("   ,[Good] ")
        Query.Append("   ,[Due] ")
        Query.Append("   ,[Delay] ")
        Query.Append("   ,'width:' + (case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Good] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) + '%' [GoodStyle] ")
        Query.Append("   ,'width:' + (case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Due] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) + '%' [DueStyle] ")
        Query.Append("   ,'width:' + (case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Delay] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) + '%' [DelayStyle] ")
        Query.Append("   ,(case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Good] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) [GoodValue] ")
        Query.Append("   ,(case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Due] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) [DueValue] ")
        Query.Append("   ,(case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Delay] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) [DelayValue] ")
        Query.Append("from ")
        Query.Append("   (Select ")
        Query.Append("      ROW_NUMBER() OVER(ORDER BY [DepName]) [SeqNo] ")
        Query.Append("      ,[DepCode] ")
        Query.Append("      ,[DepName] ")
        Query.Append("      ,(Select count(1) from view_FormApprover [A] where [A].dept_code = [TBL].DepCode And [A].DateStart between '" & DateFrom & "' And '" & DateTo & "') [IN] ")
        Query.Append("      ,(select count(1) from view_FormApprover [A] where [A].dept_code = [TBL].DepCode And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved') [OUT] ")
        Query.Append("      ,(select count(1) from view_FormApprover [A] where [A].dept_code = [TBL].DepCode And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved' and [A].DateEnd > [A].UpdatedDate) [Good] ")
        Query.Append("      ,(select count(1) from view_FormApprover [A] where [A].dept_code = [TBL].DepCode And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved' and [A].DateEnd = [A].UpdatedDate) [Due] ")
        Query.Append("      ,(select count(1) from view_FormApprover [A] where [A].dept_code = [TBL].DepCode And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved' and [A].DateEnd < [A].UpdatedDate) [Delay] ")
        Query.Append("   from ")
        Query.Append("      (select distinct ")
        Query.Append("          [DEP].dept_code [DepCode] ")
        Query.Append("          ,[DEP].abbr [DepName] ")
        Query.Append("      from ")
        Query.Append("          employee [EMP] ")
        Query.Append("          Left Join department [DEP] on [EMP].dept_code = [DEP].dept_code ")
        Query.Append("      where ")
        Query.Append("          [EMP].emp_status in ('Contractual','Probationary','Regular')) [TBL]) [TBL] ")
        Query.Append("order by ")
        Query.Append("   [SeqNo] ")
        'query

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Background"))
        dtable.Columns.Add(New DataColumn("DepCode"))
        dtable.Columns.Add(New DataColumn("DepName"))
        dtable.Columns.Add(New DataColumn("IN"))
        dtable.Columns.Add(New DataColumn("OUT"))
        dtable.Columns.Add(New DataColumn("Good"))
        dtable.Columns.Add(New DataColumn("Due"))
        dtable.Columns.Add(New DataColumn("Delay"))
        dtable.Columns.Add(New DataColumn("GoodStyle"))
        dtable.Columns.Add(New DataColumn("DueStyle"))
        dtable.Columns.Add(New DataColumn("DelayStyle"))
        dtable.Columns.Add(New DataColumn("GoodValue"))
        dtable.Columns.Add(New DataColumn("DueValue"))
        dtable.Columns.Add(New DataColumn("DelayValue"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    If DR("IN") > 0 Or DR("OUT") > 0 Then
                        'add new row
                        Dim NewRowValues As Object() = {DR("Background"), DR("DepCode"), DR("DepName"), DR("IN"), DR("OUT"), DR("Good"), DR("Due"), DR("Delay"), DR("GoodStyle"), DR("DueStyle"), DR("DelayStyle"), DR("GoodValue"), DR("DueValue"), DR("DelayValue")}
                        Dim NewRow As DataRow
                        NewRow = dtable.Rows.Add(NewRowValues)
                        'add new row
                    End If
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'now bind datatable to gridview... 
        gv05InOut.DataSource = dtable
        gv05InOut.DataBind()
        'now bind datatable to gridview... 

        'display
        upnl05InOut.Update()
        'display

    End Function

#End Region

End Class