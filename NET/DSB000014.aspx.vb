Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.VisualBasic.Logging
Imports System.Data.SqlClient

Public Class DSB000014
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

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("YEAR").ToString() & "-" & Me.Page.RouteData.Values("NO").ToString()
            'Record

            bindPieChart()
            bindBarChartH()
            bindBarChartV1()
            bindBarChartV2()

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindPieChart()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'Newly Endorsed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'for Costing') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'for Budget') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'for Award') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'Awarded') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'On-Going') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'Completed') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'On-Hold') ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where [A].BatchNo = '" & ltrlID.Text & "' and [A].Status = 'Cancelled') ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPieNewlyEndorsed.Text = DR.GetInt32(1)
                    lblPieForCosting.Text = DR.GetInt32(2)
                    lblPieForBudget.Text = DR.GetInt32(3)
                    lblPieForAward.Text = DR.GetInt32(4)
                    lblPieAwarded.Text = DR.GetInt32(5)
                    lblPieOngoing.Text = DR.GetInt32(6)
                    lblPieCompleted.Text = DR.GetInt32(7)
                    lblPieOnhold.Text = DR.GetInt32(8)
                    lblPieCancelled.Text = DR.GetInt32(9)

                    ltrlPieNewlyEndorsed.Text = DR.GetInt32(1)
                    ltrlPieForCosting.Text = DR.GetInt32(2)
                    ltrlPieForBudget.Text = DR.GetInt32(3)
                    ltrlPieForAward.Text = DR.GetInt32(4)
                    ltrlPieAwarded.Text = DR.GetInt32(5)
                    ltrlPieOnGoing.Text = DR.GetInt32(6)
                    ltrlPieCompleted.Text = DR.GetInt32(7)
                    ltrlPieOnHold.Text = DR.GetInt32(8)
                    ltrlPieCancelled.Text = DR.GetInt32(9)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindBarChartH()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '001') ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '001' and [A].Status in ('Close','Complete')) ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '002') ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '002' and [A].Status in ('Close','Complete')) ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '003') ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '003' and [A].Status in ('Close','Complete')) ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '005') ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '005' and [A].Status in ('Close','Complete')) ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '006') ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '006' and ([A].Status in ('Close','Complete') or [A].POCRate = 100)) ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '010') ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] left join Form_HWHDr [B] on [A].HWCode = [B].HWCode where [B].BatchNo = '" & ltrlID.Text & "' and [A].TaskCode = '010' and [A].Status in ('Close','Complete')) ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    ltrlBarHTarPermits.Text = DR.GetInt32(0)
                    ltrlBarHActPermits.Text = DR.GetInt32(1)
                    ltrlBarHTarPAD.Text = DR.GetInt32(2)
                    ltrlBarHActPAD.Text = DR.GetInt32(3)
                    ltrlBarHTarCost.Text = DR.GetInt32(4)
                    ltrlBarHActCost.Text = DR.GetInt32(5)
                    ltrlBarHTarSCMD.Text = DR.GetInt32(6)
                    ltrlBarHActSCMD.Text = DR.GetInt32(7)
                    ltrlBarHTarCOD.Text = DR.GetInt32(8)
                    ltrlBarHActCOD.Text = DR.GetInt32(9)
                    ltrlBarHTarPMD.Text = DR.GetInt32(10)
                    ltrlBarHActPMD.Text = DR.GetInt32(11)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindBarChartV1()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].House ")
        Query.Append("   ,(select count(1) from Form_HWHdr [B] left join calmardbLive.dbo.mstr_HouseModels [C] on [B].House = [C].ModelCode where [B].BatchNo = '" & ltrlID.Text & "' and (select top 1 * from SplitString([C].ModelName,' ')) = [A].House) ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      (select top 1 * from SplitString([B].ModelName,' ')) [House] ")
        Query.Append("   from ")
        Query.Append("      Form_HWHdr [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [B] on [A].House = [B].ModelCode ")
        Query.Append("   where ")
        Query.Append("      [A].BatchNo = '" & ltrlID.Text & "') [A] ")
        'get approver 

        ltrlBarV1ValueCategory.Text = ""
        ltrlBarV1ValueData.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarV1ValueCategory.Text = "" Then
                        ltrlBarV1ValueCategory.Text = DR.GetString(0)
                        ltrlBarV1ValueData.Text = DR.GetInt32(1)
                    Else
                        ltrlBarV1ValueCategory.Text = ltrlBarV1ValueCategory.Text & "," & DR.GetString(0)
                        ltrlBarV1ValueData.Text = ltrlBarV1ValueData.Text & "," & DR.GetInt32(1)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindBarChartV2()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   isnull([A].[ConName],'') [ConName] ")
        Query.Append("   ,(select count(1) from Form_HWHdr [B] where [B].BatchNo = '2023-001' and [B].Contractor = [A].[ConCode]) ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      [A].Contractor [ConCode] ")
        Query.Append("      ,[B].vendor [ConName] ")
        Query.Append("   from ")
        Query.Append("      Form_HWHdr [A] ")
        Query.Append("      left join ogm_vendor [B] on [A].Contractor = [B].v_code ")
        Query.Append("   where ")
        Query.Append("      [A].BatchNo = '" & ltrlID.Text & "') [A] ")
        'get approver 

        ltrlBarV2ValueCategory.Text = ""
        ltrlBarV2ValueData.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarV2ValueCategory.Text = "" Then
                        ltrlBarV2ValueCategory.Text = DR.GetString(0)
                        ltrlBarV2ValueData.Text = DR.GetInt32(1)
                    Else
                        ltrlBarV2ValueCategory.Text = ltrlBarV2ValueCategory.Text & "," & DR.GetString(0)
                        ltrlBarV2ValueData.Text = ltrlBarV2ValueData.Text & "," & DR.GetInt32(1)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

#End Region

End Class