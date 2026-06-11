Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons

Public Class DSB000009
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

    Dim QUE As String = "Quezon"
    Dim LAG As String = "Laguna"
    Dim BAT As String = "Batangas"

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
        Master.setActiveMenu("DSB", "001002")
        'active account / menu

        'load page
        If IsPostBack = False Then
            bindGridviewSummary()
            bindQUEPieChart()
            bindLAGPieChart()
            bindBATPieChart()
        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindGridviewSummary()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [Branch] ")
        Query.Append("   ,[Total] [TotTotal] ")
        Query.Append("   ,cast(((cast([Total] as decimal(21,2)) / cast([GrandTotal] as decimal(21,2))) * 100.00) as decimal(21,2)) [PerTotal] ")
        Query.Append("   ,[OnGoing] [TotOnGoing] ")
        Query.Append("   ,cast(((cast([OnGoing] as decimal(21,2)) / cast([GrandTotal] as decimal(21,2))) * 100.00) as decimal(21,2)) [PerOnGoing] ")
        Query.Append("   ,[OnTime] [TotOnTime] ")
        Query.Append("   ,cast(((cast([OnTime] as decimal(21,2)) / cast([OnGoing] as decimal(21,2))) * 100.00) as decimal(21,2)) [PerOnTime] ")
        Query.Append("   ,[Delayed] [TotDelayed] ")
        Query.Append("   ,cast(((cast([Delayed] as decimal(21,2)) / cast([OnGoing] as decimal(21,2))) * 100.00) as decimal(21,2)) [PerDelayed] ")
        Query.Append("   ,[YetToStart] [TotYetToStart] ")
        Query.Append("   ,cast(((cast([YetToStart] as decimal(21,2)) / cast([GrandTotal] as decimal(21,2))) * 100.00) as decimal(21,2)) [PerYetToStart] ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      division [Branch] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going')) [GrandTotal] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division) [Total] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99) [OnGoing] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd >= [B].POCDate) [OnTime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd < [B].POCDate) [Delayed] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) = 0) [YetToStart] ")
        Query.Append("   from ")
        Query.Append("      calmardbLive.dbo.mstr_Projects [A]) [A] ")
        Query.Append("order by ")
        Query.Append("   (case when [Branch] = 'Quezon' then 1 when [Branch] = 'Laguna' then 2 else 3 end) ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Branch"))
        dtable.Columns.Add(New DataColumn("TotTotal"))
        dtable.Columns.Add(New DataColumn("ViewWARTotal"))
        dtable.Columns.Add(New DataColumn("PerTotal"))
        dtable.Columns.Add(New DataColumn("TotOngoing"))
        dtable.Columns.Add(New DataColumn("ViewWAROngoing"))
        dtable.Columns.Add(New DataColumn("PerOngoing"))
        dtable.Columns.Add(New DataColumn("TotNotyetstarted"))
        dtable.Columns.Add(New DataColumn("ViewWARNotyetstarted"))
        dtable.Columns.Add(New DataColumn("PerNotyetstarted"))
        'Create datatable and columns

        Dim TotTotal As Integer = 0
        Dim PerTotal As Decimal = 0
        Dim TotOngoing As Decimal = 0
        Dim PerOngoing As Decimal = 0
        Dim TotOntime As Decimal = 0
        Dim PerOntime As Decimal = 0
        Dim TotDelayed As Decimal = 0
        Dim PerDelayed As Decimal = 0
        Dim TotNotyetstarted As Decimal = 0
        Dim PerNotyetstarted As Decimal = 0

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If DR.GetString(0) = "Quezon" Then
                        lblQUETotCnt.Text = DR.GetInt32(1)
                        lblQUETotRate.Text = DR.GetDecimal(2) & "%"
                        lblQUEOngCnt.Text = DR.GetInt32(3)
                        lblQUEOngRate.Text = DR.GetDecimal(4) & "%"
                        lblQUEOntCnt.Text = DR.GetInt32(5)
                        lblQUEOntRate.Text = DR.GetDecimal(6) & "%"
                        lblQUEDelCnt.Text = DR.GetInt32(7)
                        lblQUEDelRate.Text = DR.GetDecimal(8) & "%"
                        lblQUEForCnt.Text = DR.GetInt32(9)
                        lblQUEForRate.Text = DR.GetDecimal(10) & "%"
                    ElseIf DR.GetString(0) = "Laguna" Then
                        lblLAGTotCnt.Text = DR.GetInt32(1)
                        lblLAGTotRate.Text = DR.GetDecimal(2) & "%"
                        lblLAGOngCnt.Text = DR.GetInt32(3)
                        lblLAGOngRate.Text = DR.GetDecimal(4) & "%"
                        lblLAGOntCnt.Text = DR.GetInt32(5)
                        lblLAGOntRate.Text = DR.GetDecimal(6) & "%"
                        lblLAGDelCnt.Text = DR.GetInt32(7)
                        lblLAGDelRate.Text = DR.GetDecimal(8) & "%"
                        lblLAGForCnt.Text = DR.GetInt32(9)
                        lblLAGForRate.Text = DR.GetDecimal(10) & "%"
                    ElseIf DR.GetString(0) = "Batangas" Then
                        lblBATTotCnt.Text = DR.GetInt32(1)
                        lblBATTotRate.Text = DR.GetDecimal(2) & "%"
                        lblBATOngCnt.Text = DR.GetInt32(3)
                        lblBATOngRate.Text = DR.GetDecimal(4) & "%"
                        lblBATOntCnt.Text = DR.GetInt32(5)
                        lblBATOntRate.Text = DR.GetDecimal(6) & "%"
                        lblBATDelCnt.Text = DR.GetInt32(7)
                        lblBATDelRate.Text = DR.GetDecimal(8) & "%"
                        lblBATForCnt.Text = DR.GetInt32(9)
                        lblBATForRate.Text = DR.GetDecimal(10) & "%"
                    End If

                    TotTotal = TotTotal + DR.GetInt32(1)
                    PerTotal = PerTotal + DR.GetDecimal(2)
                    TotOngoing = TotOngoing + DR.GetInt32(3)
                    PerOngoing = PerOngoing + DR.GetDecimal(4)
                    TotOntime = TotOntime + DR.GetInt32(5)
                    PerOntime = PerOntime + DR.GetDecimal(6)
                    TotDelayed = TotDelayed + DR.GetInt32(7)
                    PerDelayed = PerDelayed + DR.GetDecimal(8)
                    TotNotyetstarted = TotNotyetstarted + DR.GetInt32(9)
                    PerNotyetstarted = PerNotyetstarted + DR.GetDecimal(10)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        lblTotal.Text = TotTotal & " Units"
        lblTOTTotCnt.Text = TotTotal
        lblTOTTotRate.Text = "100.00%"
        lblTOTOngCnt.Text = TotOngoing
        lblTOTOngRate.Text = Format((TotOngoing / TotTotal) * 100, "N2") & "%"
        lblTOTOntCnt.Text = TotOntime
        lblTOTOntRate.Text = Format((TotOntime / TotOngoing) * 100, "N2") & "%"
        lblTOTDelCnt.Text = TotDelayed
        lblTOTDelRate.Text = Format((TotDelayed / TotOngoing) * 100, "N2") & "%" & "%"
        lblTOTForCnt.Text = TotNotyetstarted
        lblTOTForRate.Text = Format((TotNotyetstarted / TotTotal) * 100, "N2") & "%" & "%"

    End Function

    Function bindQUEPieChart()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   (select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) <= 99.99) [Total] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd >= [B].POCDate) [OnTime] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd < [B].POCDate) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) = 0) [YetToStart] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("where ")
        Query.Append("   [A].Division = 'Quezon' ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblQUETotal.Text = DR.GetInt32(0) & " Units"
                    lblQUEOntime.Text = DR.GetInt32(1)
                    ltrlPieQUEOntime.Text = DR.GetInt32(1)
                    lblQUEDelayed.Text = DR.GetInt32(2)
                    ltrlPieQUEDelayed.Text = DR.GetInt32(2)
                    lblQUENotYetStarted.Text = DR.GetInt32(3)
                    ltrlPieQUENotYetStarted.Text = DR.GetInt32(3)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindLAGPieChart()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   (select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) <= 99.99) [Total] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd >= [B].POCDate) [OnTime] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd < [B].POCDate) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) = 0) [YetToStart] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("where ")
        Query.Append("   [A].Division = 'Laguna' ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblLAGTotal.Text = DR.GetInt32(0) & " Units"
                    lblLAGOntime.Text = DR.GetInt32(1)
                    ltrlPieLAGOntime.Text = DR.GetInt32(1)
                    lblLAGDelayed.Text = DR.GetInt32(2)
                    ltrlPieLAGDelayed.Text = DR.GetInt32(2)
                    lblLAGNotYetStarted.Text = DR.GetInt32(3)
                    ltrlPieLAGNotYetStarted.Text = DR.GetInt32(3)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindBATPieChart()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   (select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) <= 99.99) [Total] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd >= [B].POCDate) [OnTime] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].POCEnd < [B].POCDate) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].Division = [A].Division and isnull([B].POCRate,0) = 0) [YetToStart] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("where ")
        Query.Append("   [A].Division = 'Batangas' ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblBATTotal.Text = DR.GetInt32(0) & " Units"
                    lblBATOntime.Text = DR.GetInt32(1)
                    ltrlPieBATOntime.Text = DR.GetInt32(1)
                    lblBATDelayed.Text = DR.GetInt32(2)
                    ltrlPieBATDelayed.Text = DR.GetInt32(2)
                    lblBATNotYetStarted.Text = DR.GetInt32(3)
                    ltrlPieBATNotYetStarted.Text = DR.GetInt32(3)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

#End Region

End Class