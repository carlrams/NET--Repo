Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons

Public Class DSB000008
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
            bindOverall()
            bindCompleted()
            bindOngoing()
            bindForconstruction()
            bindYear()
            bindMonth(Year(Date.Now))
        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindOverall()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (select count(1) from view_ContructionStatus [A] where [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded')) + (select count(1) from view_ContructionStatus [A] where [A].Status = 'On-Going') + (select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()))  [Total] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate())) [CompletedAll] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 1) [CompletedJan] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 2) [CompletedFeb] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 3) [CompletedMar] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 4) [CompletedApr] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 5) [CompletedMay] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 6) [CompletedJun] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 7) [CompletedJul] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 8) [CompletedAug] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 9) [CompletedSep] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 10) [CompletedOct] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 11) [CompletedNov] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'Completed' and year([A].POCDate) = year(getdate()) and month([A].POCDate) = 12) [CompletedDec] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status = 'On-Going') [OnGoing] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded')) [ForConstruction] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status in ('Newly Endorsed')) [NewlyEndorsed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status in ('for Costing')) [ForCosting] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status in ('for Budget')) [ForBudget] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status in ('for Award')) [ForAward] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].Status in ('Awarded')) [Awarded] ")
        'get approver 

        ddlYear.Items.Clear()
        Dim YearData As String
        Dim ValueData As String

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblTotal1.Text = DR.GetInt32(0) & " Units"
                    lblTotal2.Text = DR.GetInt32(0)
                    lblCompletedAll.Text = DR.GetInt32(1)
                    lblCompletedJan.Text = DR.GetInt32(2)
                    lblCompletedFeb.Text = DR.GetInt32(3)
                    lblCompletedMar.Text = DR.GetInt32(4)
                    lblCompletedApr.Text = DR.GetInt32(5)
                    lblCompletedMay.Text = DR.GetInt32(6)
                    lblCompletedJun.Text = DR.GetInt32(7)
                    lblCompletedJul.Text = DR.GetInt32(8)
                    lblCompletedAug.Text = DR.GetInt32(9)
                    lblCompletedSep.Text = DR.GetInt32(10)
                    lblCompletedOct.Text = DR.GetInt32(11)
                    lblCompletedNov.Text = DR.GetInt32(12)
                    lblCompletedDec.Text = DR.GetInt32(13)
                    lblOngoing.Text = DR.GetInt32(14)
                    lblForConstruction.Text = DR.GetInt32(15)
                    lblNewlyEndorsed.Text = DR.GetInt32(16)
                    lblForCosting.Text = DR.GetInt32(17)
                    lblForBudget.Text = DR.GetInt32(18)
                    lblForAward.Text = DR.GetInt32(19)
                    lblAwarded.Text = DR.GetInt32(20)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindCompleted()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].BatchNo ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status = 'Completed' and year([B].POCDate) = year(getdate()) and [B].POCEnd > [B].POCDate) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status = 'Completed' and year([B].POCDate) = year(getdate()) and [B].POCEnd <= [B].POCDate) [Ontime] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("Where ")
        Query.Append("   [A].Status = 'Completed' ")
        Query.Append("   and year([A].POCDate) = year(getdate()) ")
        'get approver 

        ltrlCompletedBarCategory.Text = ""
        ltrlCompletedBarDelayedValueData.Text = ""
        ltrlCompletedBarOntimeValueData.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlCompletedBarCategory.Text = "" Then
                        ltrlCompletedBarCategory.Text = DR.GetString(0)
                        ltrlCompletedBarDelayedValueData.Text = DR.GetInt32(1)
                        ltrlCompletedBarOntimeValueData.Text = DR.GetInt32(2)
                    Else
                        ltrlCompletedBarCategory.Text = ltrlCompletedBarCategory.Text & "," & DR.GetString(0)
                        ltrlCompletedBarDelayedValueData.Text = ltrlCompletedBarDelayedValueData.Text & "," & DR.GetInt32(1)
                        ltrlCompletedBarOntimeValueData.Text = ltrlCompletedBarOntimeValueData.Text & "," & DR.GetInt32(2)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindOngoing()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].BatchNo ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status = 'On-Going' and [B].POCEnd > [B].POCDate) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status = 'On-Going' and [B].POCEnd <= [B].POCDate) [Ontime] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("Where ")
        Query.Append("   [A].Status = 'On-Going' ")
        'get approver 

        ltrlOngoingBarCategory.Text = ""
        ltrlOngoingBarDelayedValueData.Text = ""
        ltrlOngoingBarOntimeValueData.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlOngoingBarCategory.Text = "" Then
                        ltrlOngoingBarCategory.Text = DR.GetString(0)
                        ltrlOngoingBarDelayedValueData.Text = DR.GetInt32(1)
                        ltrlOngoingBarOntimeValueData.Text = DR.GetInt32(2)
                    Else
                        ltrlOngoingBarCategory.Text = ltrlOngoingBarCategory.Text & "," & DR.GetString(0)
                        ltrlOngoingBarDelayedValueData.Text = ltrlOngoingBarDelayedValueData.Text & "," & DR.GetInt32(1)
                        ltrlOngoingBarOntimeValueData.Text = ltrlOngoingBarOntimeValueData.Text & "," & DR.GetInt32(2)
                    End If


                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindForconstruction()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].BatchNo ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status in ('Newly Endorsed')) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status in ('for Costing')) [ForCosting] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status in ('for Budget')) [ForBudget] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status in ('for Award')) [ForAward] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo and [B].Status in ('Awarded')) [Awarded] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("Where ")
        Query.Append("   [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') ")
        'get approver 

        ltrlForconstructionBarCategory.Text = ""
        ltrlForconstructionBarNewlyEndorsed.Text = ""
        ltrlForconstructionBarForCosting.Text = ""
        ltrlForconstructionBarForBudget.Text = ""
        ltrlForconstructionBarForAward.Text = ""
        ltrlForconstructionBarAwarded.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlForconstructionBarCategory.Text = "" Then
                        ltrlForconstructionBarCategory.Text = DR.GetString(0)
                        ltrlForconstructionBarNewlyEndorsed.Text = DR.GetInt32(1)
                        ltrlForconstructionBarForCosting.Text = DR.GetInt32(2)
                        ltrlForconstructionBarForBudget.Text = DR.GetInt32(3)
                        ltrlForconstructionBarForAward.Text = DR.GetInt32(4)
                        ltrlForconstructionBarAwarded.Text = DR.GetInt32(5)
                    Else
                        ltrlForconstructionBarCategory.Text = ltrlForconstructionBarCategory.Text & "," & DR.GetString(0)
                        ltrlForconstructionBarNewlyEndorsed.Text = ltrlForconstructionBarNewlyEndorsed.Text & "," & DR.GetInt32(1)
                        ltrlForconstructionBarForCosting.Text = ltrlForconstructionBarForCosting.Text & "," & DR.GetInt32(2)
                        ltrlForconstructionBarForBudget.Text = ltrlForconstructionBarForBudget.Text & "," & DR.GetInt32(3)
                        ltrlForconstructionBarForAward.Text = ltrlForconstructionBarForAward.Text & "," & DR.GetInt32(4)
                        ltrlForconstructionBarAwarded.Text = ltrlForconstructionBarAwarded.Text & "," & DR.GetInt32(5)
                    End If


                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindYear()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].[Year] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and year([B].POCDate) = [A].[Year]) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and [B].TOStatus in ('Complete','Close') and year([B].TODate) = [A].[Year]) ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      Year([A].POCEnd) [Year] ")
        Query.Append("   from ")
        Query.Append("      view_ContructionStatus [A]) [A] ")
        Query.Append("order by ")
        Query.Append("   [Year] ")
        'get approver 

        ddlYear.Items.Clear()
        ltrlYearLineCategory.Text = ""
        ltrlYearLineCOCValueData.Text = ""
        ltrlYearLinePMDValueData.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    ddlYear.Items.Add(DR.GetInt32(0))

                    If ltrlYearLineCategory.Text = "" Then
                        ltrlYearLineCategory.Text = DR.GetInt32(0)
                        ltrlYearLineCOCValueData.Text = DR.GetInt32(1)
                        ltrlYearLinePMDValueData.Text = DR.GetInt32(2)
                    Else
                        ltrlYearLineCategory.Text = ltrlYearLineCategory.Text & "," & DR.GetInt32(0)
                        ltrlYearLineCOCValueData.Text = ltrlYearLineCOCValueData.Text & "," & DR.GetInt32(1)
                        ltrlYearLinePMDValueData.Text = ltrlYearLinePMDValueData.Text & "," & DR.GetInt32(2)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        ddlYear.SelectedValue = Year(Date.Now)

    End Function

    Function bindMonth(Year_ As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   (select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 1 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 1) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 2 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 2) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 3 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 3) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 4 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 4) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 5 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 5) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 6 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 6) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 7 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 7) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 8 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 8) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 9 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 9) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 10 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 10) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 11 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 11) ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 12 and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year_ & " and month([A].POCEnd) = 12) ")
        'get approver 

        ltrlMonthBarTarValueData.Text = ""
        ltrlMonthBarActValueData.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    ltrlMonthBarTarValueData.Text = DR.GetInt32(1) & "," & DR.GetInt32(3) & "," & DR.GetInt32(5) & "," & DR.GetInt32(7) & "," & DR.GetInt32(9) & "," & DR.GetInt32(11) & "," & DR.GetInt32(13) & "," & DR.GetInt32(15) & "," & DR.GetInt32(17) & "," & DR.GetInt32(19) & "," & DR.GetInt32(21) & "," & DR.GetInt32(23)
                    ltrlMonthBarActValueData.Text = DR.GetInt32(0) & "," & DR.GetInt32(2) & "," & DR.GetInt32(4) & "," & DR.GetInt32(6) & "," & DR.GetInt32(8) & "," & DR.GetInt32(10) & "," & DR.GetInt32(12) & "," & DR.GetInt32(14) & "," & DR.GetInt32(16) & "," & DR.GetInt32(18) & "," & DR.GetInt32(20) & "," & DR.GetInt32(22)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

#End Region

End Class