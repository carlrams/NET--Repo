Imports System.Data.SqlClient
Imports System.IO

Public Class DSB040400
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("DSB", "DSB040300")
        'active account / menu

        If IsPostBack = False Then
            bindCCI()
            bindFIN()
            bindMKT()
            bindSCM()
            bindPDD()
            bindTSGCOS()
            bindTSGPAD()
            bindTSGPE()
            bindTSGPMD()
            bindCompleted()
            bindCancelled()
        End If
    End Sub
#End Region

#Region "Function"
    Dim CCITotal As Integer = 0
    Dim CCIGood As Integer = 0
    Dim CCIDue As Integer = 0
    Dim CCIDelay As Integer = 0
    Function bindCCI()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'CCI' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    CCITotal = CCITotal + 1

                    If Status = "Good" Then
                        CCIGood = CCIGood + 1
                    ElseIf Status = "Due" Then
                        CCIDue = CCIDue + 1
                    ElseIf Status = "Delay" Then
                        CCIDelay = CCIDelay + 1
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
        gvCCI.DataSource = dt
        gvCCI.DataBind()
        'bind

        'count
        lblCCITotal.Text = CCITotal
        lblCCIGood.Text = CCIGood
        lblCCIDue.Text = CCIDue
        lblCCIDelay.Text = CCIDelay
        'count

    End Function

    Dim FINTotal As Integer = 0
    Dim FINGood As Integer = 0
    Dim FINDue As Integer = 0
    Dim FINDelay As Integer = 0
    Function bindFIN()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'FIN' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    FINTotal = FINTotal + 1

                    If Status = "Good" Then
                        FINGood = FINGood + 1
                    ElseIf Status = "Due" Then
                        FINDue = FINDue + 1
                    ElseIf Status = "Delay" Then
                        FINDelay = FINDelay + 1
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
        gvFIN.DataSource = dt
        gvFIN.DataBind()
        'bind

        'count
        lblFINTotal.Text = FINTotal
        lblFINGood.Text = FINGood
        lblFINDue.Text = FINDue
        lblFINDelay.Text = FINDelay
        'count

    End Function

    Dim MKTTotal As Integer = 0
    Dim MKTGood As Integer = 0
    Dim MKTDue As Integer = 0
    Dim MKTDelay As Integer = 0
    Function bindMKT()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'MKT' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    MKTTotal = MKTTotal + 1

                    If Status = "Good" Then
                        MKTGood = MKTGood + 1
                    ElseIf Status = "Due" Then
                        MKTDue = MKTDue + 1
                    ElseIf Status = "Delay" Then
                        MKTDelay = MKTDelay + 1
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
        gvMKT.DataSource = dt
        gvMKT.DataBind()
        'bind

        'count
        lblMKTTotal.Text = MKTTotal
        lblMKTGood.Text = MKTGood
        lblMKTDue.Text = MKTDue
        lblMKTDelay.Text = MKTDelay
        'count

    End Function

    Dim SCMTotal As Integer = 0
    Dim SCMGood As Integer = 0
    Dim SCMDue As Integer = 0
    Dim SCMDelay As Integer = 0
    Function bindSCM()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'SCM' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    SCMTotal = SCMTotal + 1

                    If Status = "Good" Then
                        SCMGood = SCMGood + 1
                    ElseIf Status = "Due" Then
                        SCMDue = SCMDue + 1
                    ElseIf Status = "Delay" Then
                        SCMDelay = SCMDelay + 1
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
        gvSCM.DataSource = dt
        gvSCM.DataBind()
        'bind

        'count
        lblSCMTotal.Text = SCMTotal
        lblSCMGood.Text = SCMGood
        lblSCMDue.Text = SCMDue
        lblSCMDelay.Text = SCMDelay
        'count

    End Function

    Dim PDDTotal As Integer = 0
    Dim PDDGood As Integer = 0
    Dim PDDDue As Integer = 0
    Dim PDDDelay As Integer = 0
    Function bindPDD()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'PDD' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    PDDTotal = PDDTotal + 1

                    If Status = "Good" Then
                        PDDGood = PDDGood + 1
                    ElseIf Status = "Due" Then
                        PDDDue = PDDDue + 1
                    ElseIf Status = "Delay" Then
                        PDDDelay = PDDDelay + 1
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
        gvPDD.DataSource = dt
        gvPDD.DataBind()
        'bind

        'count
        lblPDDTotal.Text = PDDTotal
        lblPDDGood.Text = PDDGood
        lblPDDDue.Text = PDDDue
        lblPDDDelay.Text = PDDDelay
        'count

    End Function

    Dim TSGCOSTotal As Integer = 0
    Dim TSGCOSGood As Integer = 0
    Dim TSGCOSDue As Integer = 0
    Dim TSGCOSDelay As Integer = 0
    Function bindTSGCOS()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-COS' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    TSGCOSTotal = TSGCOSTotal + 1

                    If Status = "Good" Then
                        TSGCOSGood = TSGCOSGood + 1
                    ElseIf Status = "Due" Then
                        TSGCOSDue = TSGCOSDue + 1
                    ElseIf Status = "Delay" Then
                        TSGCOSDelay = TSGCOSDelay + 1
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
        gvTSGCOS.DataSource = dt
        gvTSGCOS.DataBind()
        'bind

        'count
        lblTSGCOSTotal.Text = TSGCOSTotal
        lblTSGCOSGood.Text = TSGCOSGood
        lblTSGCOSDue.Text = TSGCOSDue
        lblTSGCOSDelay.Text = TSGCOSDelay
        'count

    End Function

    Dim TSGPADTotal As Integer = 0
    Dim TSGPADGood As Integer = 0
    Dim TSGPADDue As Integer = 0
    Dim TSGPADDelay As Integer = 0
    Function bindTSGPAD()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-PAD' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    TSGPADTotal = TSGPADTotal + 1

                    If Status = "Good" Then
                        TSGPADGood = TSGPADGood + 1
                    ElseIf Status = "Due" Then
                        TSGPADDue = TSGPADDue + 1
                    ElseIf Status = "Delay" Then
                        TSGPADDelay = TSGPADDelay + 1
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
        gvTSGPAD.DataSource = dt
        gvTSGPAD.DataBind()
        'bind

        'count
        lblTSGPADTotal.Text = TSGPADTotal
        lblTSGPADGood.Text = TSGPADGood
        lblTSGPADDue.Text = TSGPADDue
        lblTSGPADDelay.Text = TSGPADDelay
        'count

    End Function

    Dim TSGPETotal As Integer = 0
    Dim TSGPEGood As Integer = 0
    Dim TSGPEDue As Integer = 0
    Dim TSGPEDelay As Integer = 0
    Function bindTSGPE()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-PE' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    TSGPETotal = TSGPETotal + 1

                    If Status = "Good" Then
                        TSGPEGood = TSGPEGood + 1
                    ElseIf Status = "Due" Then
                        TSGPEDue = TSGPEDue + 1
                    ElseIf Status = "Delay" Then
                        TSGPEDelay = TSGPEDelay + 1
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
        gvTSGPE.DataSource = dt
        gvTSGPE.DataBind()
        'bind

        'count
        lblTSGPETotal.Text = TSGPETotal
        lblTSGPEGood.Text = TSGPEGood
        lblTSGPEDue.Text = TSGPEDue
        lblTSGPEDelay.Text = TSGPEDelay
        'count

    End Function

    Dim TSGPMDTotal As Integer = 0
    Dim TSGPMDGood As Integer = 0
    Dim TSGPMDDue As Integer = 0
    Dim TSGPMDDelay As Integer = 0
    Function bindTSGPMD()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-PMD' ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    TSGPMDTotal = TSGPMDTotal + 1

                    If Status = "Good" Then
                        TSGPMDGood = TSGPMDGood + 1
                    ElseIf Status = "Due" Then
                        TSGPMDDue = TSGPMDDue + 1
                    ElseIf Status = "Delay" Then
                        TSGPMDDelay = TSGPMDDelay + 1
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
        gvTSGPMD.DataSource = dt
        gvTSGPMD.DataBind()
        'bind

        'count
        lblTSGPMDTotal.Text = TSGPMDTotal
        lblTSGPMDGood.Text = TSGPMDGood
        lblTSGPMDDue.Text = TSGPMDDue
        lblTSGPMDDelay.Text = TSGPMDDelay
        'count

    End Function

    Dim CompletedTotal As Integer = 0
    Dim CompletedGood As Integer = 0
    Dim CompletedDue As Integer = 0
    Dim CompletedDelay As Integer
    Function bindCompleted()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'bullet bullet-vertical h-58px bg-success' [Bullet] ")
        Query.Append("  ,'FRM0000-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  Status in ('Done') ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    CompletedTotal = CompletedTotal + 1

                    If Status = "Good" Then
                        CompletedGood = CompletedGood + 1
                    ElseIf Status = "Due" Then
                        CompletedDue = CompletedDue + 1
                    ElseIf Status = "Delay" Then
                        CompletedDelay = CompletedDelay + 1
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
        gvCompleted.DataSource = dt
        gvCompleted.DataBind()
        'bind

        'count
        lblCompletedTotal.Text = CompletedTotal
        lblCompletedGood.Text = CompletedGood
        lblCompletedDue.Text = CompletedDue
        lblCompletedDelay.Text = CompletedDelay
        'count

    End Function

    Dim CancelledTotal As Integer = 0
    Dim CancelledGood As Integer = 0
    Dim CancelledDue As Integer = 0
    Dim CancelledDelay As Integer = 0
    Function bindCancelled()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'bullet bullet-vertical h-58px bg-danger' [Bullet] ")
        Query.Append("  ,'FRM000010-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardPR.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardPR ")
        Query.Append("  left join employee on Rpt_DashboardPR.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  Status in ('Cancelled') ")
        Query.Append("  and Project NOT LIKE 'OSM Project%' ")
        Query.Append("  and employee.emp_status != 'Resigned' ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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

                    CancelledTotal = CancelledTotal + 1

                    If Status = "Good" Then
                        CancelledGood = CancelledGood + 1
                    ElseIf Status = "Due" Then
                        CancelledDue = CancelledDue + 1
                    ElseIf Status = "Delay" Then
                        CancelledDelay = CancelledDelay + 1
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
        gvCancelled.DataSource = dt
        gvCancelled.DataBind()
        'bind

        'count
        lblCancelledTotal.Text = CancelledTotal
        lblCancelledGood.Text = CancelledGood
        lblCancelledDue.Text = CancelledDue
        lblCancelledDelay.Text = CancelledDelay
        'count

    End Function
#End Region

End Class