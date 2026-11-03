Imports System.Data.SqlClient
Imports System.IO

Public Class DSB040000
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
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("DSB", "DSB040000")
        'active account / menu

        'load page
        If IsPostBack = False Then
            bind01CSD()
            bind02Director()
            bind03Others()
            bind04COS()
            bind05SCM()
            bind06PE()
            bind07PMD()
            bind08CCI()
            bind09Cancel()
            bind10Complete()
        End If
        'load page

    End Sub

#End Region

#Region "Function"

    Dim CSD01Total As Integer = 0
    Dim CSD01Good As Integer = 0
    Dim CSD01Due As Integer = 0
    Dim CSD01Delay As Integer = 0

    Function bind01CSD()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'CSD' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    CSD01Total = CSD01Total + 1

                    If Status = "Good" Then
                        CSD01Good = CSD01Good + 1
                    ElseIf Status = "Due" Then
                        CSD01Due = CSD01Due + 1
                    ElseIf Status = "Delay" Then
                        CSD01Delay = CSD01Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv01CSD.DataSource = dt
        gv01CSD.DataBind()
        'bind

        'count
        lbl01CSDTotal.Text = CSD01Total
        lbl01CSDGood.Text = CSD01Good
        lbl01CSDDue.Text = CSD01Due
        lbl01CSDDelay.Text = CSD01Delay
        'count

    End Function

    Dim Director02Total As Integer = 0
    Dim Director02Good As Integer = 0
    Dim Director02Due As Integer = 0
    Dim Director02Delay As Integer = 0

    Function bind02Director()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'Director' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    Director02Total = Director02Total + 1

                    If Status = "Good" Then
                        Director02Good = Director02Good + 1
                    ElseIf Status = "Due" Then
                        Director02Due = Director02Due + 1
                    ElseIf Status = "Delay" Then
                        Director02Delay = Director02Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv02Director.DataSource = dt
        gv02Director.DataBind()
        'bind

        'count
        lbl02DirectorTotal.Text = Director02Total
        lbl02DirectorGood.Text = Director02Good
        lbl02DirectorDue.Text = Director02Due
        lbl02DirectorDelay.Text = Director02Delay
        'count

    End Function

    Dim Other03Total As Integer = 0
    Dim Other03Good As Integer = 0
    Dim Other03Due As Integer = 0
    Dim Other03Delay As Integer = 0

    Function bind03Others()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'Others' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    Other03Total = Other03Total + 1

                    If Status = "Good" Then
                        Other03Good = Other03Good + 1
                    ElseIf Status = "Due" Then
                        Other03Due = Other03Due + 1
                    ElseIf Status = "Delay" Then
                        Other03Delay = Other03Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv03Other.DataSource = dt
        gv03Other.DataBind()
        'bind

        'count
        lbl03OtherTotal.Text = Other03Total
        lbl03OtherGood.Text = Other03Good
        lbl03OtherDue.Text = Other03Due
        lbl03OtherDelay.Text = Other03Delay
        'count

    End Function

    Dim COS04Total As Integer = 0
    Dim COS04Good As Integer = 0
    Dim COS04Due As Integer = 0
    Dim COS04Delay As Integer = 0

    Function bind04COS()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'TSG-COS' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    COS04Total = COS04Total + 1

                    If Status = "Good" Then
                        COS04Good = COS04Good + 1
                    ElseIf Status = "Due" Then
                        COS04Due = COS04Due + 1
                    ElseIf Status = "Delay" Then
                        COS04Delay = COS04Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv04COS.DataSource = dt
        gv04COS.DataBind()
        'bind

        'count
        lbl04COSTotal.Text = COS04Total
        lbl04COSGood.Text = COS04Good
        lbl04COSDue.Text = COS04Due
        lbl04COSDelay.Text = COS04Delay
        'count

    End Function

    Dim SCM05Total As Integer = 0
    Dim SCM05Good As Integer = 0
    Dim SCM05Due As Integer = 0
    Dim SCM05Delay As Integer = 0

    Function bind05SCM()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'SCM' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    SCM05Total = SCM05Total + 1

                    If Status = "Good" Then
                        SCM05Good = SCM05Good + 1
                    ElseIf Status = "Due" Then
                        SCM05Due = SCM05Due + 1
                    ElseIf Status = "Delay" Then
                        SCM05Delay = SCM05Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv05SCM.DataSource = dt
        gv05SCM.DataBind()
        'bind

        'count
        lbl05SCMTotal.Text = SCM05Total
        lbl05SCMGood.Text = SCM05Good
        lbl05SCMDue.Text = SCM05Due
        lbl05SCMDelay.Text = SCM05Delay
        'count

    End Function

    Dim PE06Total As Integer = 0
    Dim PE06Good As Integer = 0
    Dim PE06Due As Integer = 0
    Dim PE06Delay As Integer = 0

    Function bind06PE()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'TSG-PE' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    PE06Total = PE06Total + 1

                    If Status = "Good" Then
                        PE06Good = PE06Good + 1
                    ElseIf Status = "Due" Then
                        PE06Due = PE06Due + 1
                    ElseIf Status = "Delay" Then
                        PE06Delay = PE06Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv06PE.DataSource = dt
        gv06PE.DataBind()
        'bind

        'count
        lbl06PETotal.Text = PE06Total
        lbl06PEGood.Text = PE06Good
        lbl06PEDue.Text = PE06Due
        lbl06PEDelay.Text = PE06Delay
        'count

    End Function

    Dim PMD07Total As Integer = 0
    Dim PMD07Good As Integer = 0
    Dim PMD07Due As Integer = 0
    Dim PMD07Delay As Integer = 0

    Function bind07PMD()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'TSG-PMD' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    PMD07Total = PMD07Total + 1

                    If Status = "Good" Then
                        PMD07Good = PMD07Good + 1
                    ElseIf Status = "Due" Then
                        PMD07Due = PMD07Due + 1
                    ElseIf Status = "Delay" Then
                        PMD07Delay = PMD07Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv07PMD.DataSource = dt
        gv07PMD.DataBind()
        'bind

        'count
        lbl07PMDTotal.Text = PMD07Total
        lbl07PMDGood.Text = PMD07Good
        lbl07PMDDue.Text = PMD07Due
        lbl07PMDDelay.Text = PMD07Delay
        'count

    End Function

    Dim CCI08Total As Integer = 0
    Dim CCI08Good As Integer = 0
    Dim CCI08Due As Integer = 0
    Dim CCI08Delay As Integer = 0

    Function bind08CCI()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group1] = 'CCI' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    CCI08Total = CCI08Total + 1

                    If Status = "Good" Then
                        CCI08Good = CCI08Good + 1
                    ElseIf Status = "Due" Then
                        CCI08Due = CCI08Due + 1
                    ElseIf Status = "Delay" Then
                        CCI08Delay = CCI08Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv08CCI.DataSource = dt
        gv08CCI.DataBind()
        'bind

        'count
        lbl08CCITotal.Text = CCI08Total
        lbl08CCIGood.Text = CCI08Good
        lbl08CCIDue.Text = CCI08Due
        lbl08CCIDelay.Text = CCI08Delay
        'count

    End Function

    Dim Cancel09Total As Integer = 0
    Dim Cancel09Good As Integer = 0
    Dim Cancel09Due As Integer = 0
    Dim Cancel09Delay As Integer = 0

    Function bind09Cancel()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'bullet bullet-vertical h-58px bg-danger' [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  Status in ('Cancelled') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    Cancel09Total = Cancel09Total + 1

                    If Status = "Good" Then
                        Cancel09Good = Cancel09Good + 1
                    ElseIf Status = "Due" Then
                        Cancel09Due = Cancel09Due + 1
                    ElseIf Status = "Delay" Then
                        Cancel09Delay = Cancel09Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv09Cancel.DataSource = dt
        gv09Cancel.DataBind()
        'bind

        'count
        lbl09CancelTotal.Text = Cancel09Total
        lbl09CancelGood.Text = Cancel09Good
        lbl09CancelDue.Text = Cancel09Due
        lbl09CancelDelay.Text = Cancel09Delay
        'count

    End Function

    Dim Complete10Total As Integer = 0
    Dim Complete10Good As Integer = 0
    Dim Complete10Due As Integer = 0
    Dim Complete10Delay As Integer = 0

    Function bind10Complete()

        'get task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'bullet bullet-vertical h-58px bg-success' [Bullet] ")
        Query.Append("  ,'FRM000012-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardSRF.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardSRF ")
        Query.Append("  left join employee on Rpt_DashboardSRF.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  Status in ('Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("Bullet"))
        dt.Columns.Add(New DataColumn("Link"))
        dt.Columns.Add(New DataColumn("FormNo"))
        dt.Columns.Add(New DataColumn("Project"))
        dt.Columns.Add(New DataColumn("Assigned"))
        dt.Columns.Add(New DataColumn("DueDate"))
        dt.Columns.Add(New DataColumn("AssignTo"))
        dt.Columns.Add(New DataColumn("Status"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row

                    Dim Image As String = DR.GetString(6)
                    Dim Status As String = DR.GetString(7)

                    Complete10Total = Complete10Total + 1

                    If Status = "Good" Then
                        Complete10Good = Complete10Good + 1
                    ElseIf Status = "Due" Then
                        Complete10Due = Complete10Due + 1
                    ElseIf Status = "Delay" Then
                        Complete10Delay = Complete10Delay + 1
                    End If

                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), Image}
                        Dim NewRow As DataRow
                        NewRow = dt.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind
        gv10Complete.DataSource = dt
        gv10Complete.DataBind()
        'bind

        'count
        lbl10CompleteTotal.Text = Complete10Total
        lbl10CompleteGood.Text = Complete10Good
        lbl10CompleteDue.Text = Complete10Due
        lbl10CompleteDelay.Text = Complete10Delay
        'count

    End Function

#End Region

End Class