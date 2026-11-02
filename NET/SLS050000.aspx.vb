Imports System.Data.SqlClient
Imports System.IO
Public Class SLS050000
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
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SLS050000")
        'active account / menu

        'create variable
        Dim Msg As String = Validate("Access", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        'load page
        If IsPostBack = False Then

            'display record
            bindtotalSales()
            bindReservationSales()
            bindBookedSales()
            bindReservedSalesLineChart()
            bindBookedSalesLineChart()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindtotalSales()

        'get total sales include condition for ytd >> for reserved
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  sum(case when [A].Active = 1 and [A].Posted = 1 then [B].SellingPrice else 0 end) [Gross Reserved Sales] ")
        Query.Append("  ,sum(case when [A].Posted = 1 and [A].Active = 1 and [B].Posted = 1 then [B].Sellingprice else '0' end) [Gross Booked Sales] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.ICR_Buyers [A]  ")
        Query.Append("  left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("where ")
        Query.Append("  YEAR([B].RFDate) = YEAR(GETDATE()) ")
        'get total sales

        'Create InnerHtml
        Dim InnerHtml As New StringBuilder
        'Create InnerHtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'Declaring variable to store decimal values
                    Dim ReservationSales As Decimal = If(Not DR.IsDBNull(0), DR.GetDecimal(0), 0)
                    Dim BookedSales As Decimal = If(Not DR.IsDBNull(1), DR.GetDecimal(1), 0)

                    spReservationSales.Attributes.Add("data-kt-countup-value", Format(ReservationSales, "N2"))
                    spBookedSales.Attributes.Add("data-kt-countup-value", Format(BookedSales, "N2"))
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        upnlDashboard.Update()
        'diplay record

    End Function

    Function bindReservationSales()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,dbo.ProperCase([A].AcctName) [Buyer] ")
        Query.Append("   ,[D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[E].ModelName ")
        Query.Append("   ,[B].Sellingprice [TCP] ")
        Query.Append("   ,isnull([C].AgentCode, '') [AgentCode] ")
        Query.Append("   ,case when [C].SellerName IS NOT NULL then dbo.ProperCase([C].SellerName) when [C].SellerName <> '' then dbo.ProperCase([C].SellerName) else '-' end [Seller] ")
        Query.Append("   ,(case when [B].RFDate is null then '-' else CONVERT (varchar, [B].RFDate, 107) end) [RsvDate] ")
        Query.Append("   ,(case when [B].RFDate is null then '-' else RIGHT(CONVERT(varchar, [B].RFDate, 100), 7) end) [RsvTime] ")
        Query.Append("   ,[F].SellerGrpDesc ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [C] on [C].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [D] on [D].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [E] on [E].ModelCode = [A].ModelCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [F] on [F].SellerGrpCode = [C].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("   [B].RFDate >= DATEADD(MONTH, -3, GETDATE()) ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [C].AgentCode IS NOT NULL ")
        Query.Append("order by ")
        Query.Append("   [B].RFDate desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Buyer"))
        dtable.Columns.Add(New DataColumn("RsvDate"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("TCP"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Group"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim SlrImg As String
                    If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(5) & "/Profile/" & DR.GetString(5) & ".png")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(5) & "/Profile/" & DR.GetString(5) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(5) & ".jpg")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(5) & "/Profile/" & DR.GetString(5) & ".jpg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    Dim ReservationDate As String = DR.GetString(7) & " | " & DR.GetString(8)
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(4), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(1), ReservationDate, DR.GetString(2), DR.GetString(3), TCP, DR.GetString(6), DR.GetString(2), DR.GetString(9)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvRsvSales.DataSource = dtable
        gvRsvSales.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvRsvSales.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvRsvSales.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvRsvSales.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvRsvSales.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindBookedSales()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,dbo.ProperCase([A].AcctName) [Buyer] ")
        Query.Append("   ,[D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[E].ModelName ")
        Query.Append("   ,[B].Sellingprice [TCP] ")
        Query.Append("   ,isnull([C].AgentCode, '') [AgentCode] ")
        Query.Append("   ,case when [C].SellerName IS NOT NULL then dbo.ProperCase([C].SellerName) when [C].SellerName <> '' then dbo.ProperCase([C].SellerName) else '-' end [Seller] ")
        Query.Append("   ,(case when [B].DatePosted is null then '-' else CONVERT (varchar, [B].DatePosted, 107) end) [BkDate] ")
        Query.Append("   ,(case when [B].DatePosted is null then '-' else RIGHT(CONVERT(varchar, [B].DatePosted, 100), 7) end) [BkTime] ")
        Query.Append("   ,[F].SellerGrpDesc ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [C] on [C].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [D] on [D].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [E] on [E].ModelCode = [A].ModelCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [F] on [F].SellerGrpCode = [C].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("   [B].RFDate >= DATEADD(MONTH, -3, GETDATE()) ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [B].Posted = 1 ")
        Query.Append("   and [C].AgentCode IS NOT NULL ")
        Query.Append("order by ")
        Query.Append("   [B].RFDate desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Buyer"))
        dtable.Columns.Add(New DataColumn("BkDate"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("TCP"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Group"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim SlrImg As String
                    If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(5) & "/Profile/" & DR.GetString(5) & ".png")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(5) & "/Profile/" & DR.GetString(5) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(5) & ".jpg")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(5) & "/Profile/" & DR.GetString(5) & ".jpg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    Dim ReservationDate As String = DR.GetString(7) & " | " & DR.GetString(8)
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(4), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(1), ReservationDate, DR.GetString(2), DR.GetString(3), TCP, DR.GetString(6), DR.GetString(2), DR.GetString(9)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvBkSales.DataSource = dtable
        gvBkSales.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvBkSales.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvBkSales.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvBkSales.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvBkSales.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

#Region "Graphs"

    Function bindReservedSalesLineChart()

        'get sales per month
        Dim Query As New StringBuilder
        Query.Append("WITH Month AS ( ")
        Query.Append("  SELECT 1 AS MonthNumber, 'Jan' AS MonthName UNION ALL ")
        Query.Append("  SELECT 2, 'Feb' UNION ALL  ")
        Query.Append("  SELECT 3, 'Mar' UNION ALL ")
        Query.Append("  SELECT 4, 'Apr' UNION ALL  ")
        Query.Append("  SELECT 5, 'May' UNION ALL  ")
        Query.Append("  SELECT 6, 'Jun' UNION ALL ")
        Query.Append("  SELECT 7, 'Jul' UNION ALL  ")
        Query.Append("  SELECT 8, 'Aug' UNION ALL ")
        Query.Append("  SELECT 9, 'Sep' UNION ALL  ")
        Query.Append("  SELECT 10, 'Oct' UNION ALL  ")
        Query.Append("  SELECT 11, 'Nov' UNION ALL ")
        Query.Append("  SELECT 12, 'Dec' )  ")
        Query.Append("select  ")
        Query.Append("  [M].MonthNumber  ")
        Query.Append("  ,[M].MonthName ")
        Query.Append("  ,isnull(sum([ReservedAmount]), 0) [Reservation Sales]  ")
        Query.Append("from  ")
        Query.Append("  Month [M]  ")
        Query.Append("left join ")
        Query.Append("   (select MONTH([B].RFDate) [ReservedMonth], [B].SellingPrice [ReservedAmount] from calmardbLive.dbo.ICR_Buyers [A] left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo where YEAR([B].RFDate) = YEAR(GETDATE()) and [A].Active = 1 and [A].Posted = 1 group by [B].RFDate,[B].AcctNo, [B].Sellingprice) [Reserved] ON [Reserved].[ReservedMonth] = [M].MonthNumber ")
        Query.Append("group by ")
        Query.Append("  [M].MonthNumber  ")
        Query.Append("  ,[M].MonthName ")
        Query.Append("order by ")
        Query.Append("  [M].MonthNumber ")
        'get sales per month

        ltrlLineMonthlyBooked.Text = ""
        ltrlLineMonthlyName.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    If ltrlLineMonthlyName.Text = "" Then
                        ltrlLineMonthlyName.Text = DR.GetString(1)
                    Else
                        ltrlLineMonthlyName.Text = ltrlLineMonthlyName.Text & ", " & DR.GetString(1)
                    End If
                    If ltrlLineMonthlyReserved.Text = "" Then
                        ltrlLineMonthlyReserved.Text = DR.GetDecimal(2)
                    Else
                        ltrlLineMonthlyReserved.Text = ltrlLineMonthlyReserved.Text & ", " & DR.GetDecimal(2)
                    End If
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        upnlDashboard.Update()
        'diplay record

    End Function

    Function bindBookedSalesLineChart()

        'get sales per month
        Dim Query As New StringBuilder
        Query.Append("WITH Month AS ( ")
        Query.Append("  SELECT 1 AS MonthNumber, 'Jan' AS MonthName UNION ALL ")
        Query.Append("  SELECT 2, 'Feb' UNION ALL  ")
        Query.Append("  SELECT 3, 'Mar' UNION ALL ")
        Query.Append("  SELECT 4, 'Apr' UNION ALL  ")
        Query.Append("  SELECT 5, 'May' UNION ALL  ")
        Query.Append("  SELECT 6, 'Jun' UNION ALL ")
        Query.Append("  SELECT 7, 'Jul' UNION ALL  ")
        Query.Append("  SELECT 8, 'Aug' UNION ALL ")
        Query.Append("  SELECT 9, 'Sep' UNION ALL  ")
        Query.Append("  SELECT 10, 'Oct' UNION ALL  ")
        Query.Append("  SELECT 11, 'Nov' UNION ALL ")
        Query.Append("  SELECT 12, 'Dec' )  ")
        Query.Append("select  ")
        Query.Append("  [M].MonthNumber  ")
        Query.Append("  ,[M].MonthName ")
        Query.Append("  ,isnull(sum([BookedAmount]), 0) [Booked Sales]  ")
        Query.Append("from  ")
        Query.Append("  Month [M]  ")
        Query.Append("left join ")
        Query.Append("   (select MONTH([B].RFDate) [BookedMonth], [B].SellingPrice [BookedAmount] from calmardbLive.dbo.ICR_Buyers [A] left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo where YEAR([B].RFDate) = YEAR(GETDATE()) and [A].Active = 1 and [A].Posted = 1 and [B].Posted = 1 group by [B].RFDate,[B].AcctNo, [B].Sellingprice) [Booked] ON [Booked].[BookedMonth] = [M].MonthNumber ")
        Query.Append("group by ")
        Query.Append("  [M].MonthNumber  ")
        Query.Append("  ,[M].MonthName ")
        Query.Append("order by ")
        Query.Append("  [M].MonthNumber ")
        'get sales per month

        ltrlLineMonthlyBooked.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    If ltrlLineMonthlyBooked.Text = "" Then
                        ltrlLineMonthlyBooked.Text = DR.GetDecimal(2)
                    Else
                        ltrlLineMonthlyBooked.Text = ltrlLineMonthlyBooked.Text & ", " & DR.GetDecimal(2)
                    End If
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        upnlDashboard.Update()
        'diplay record

    End Function

#End Region

#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Access" Then

            'get total task
            If Type = "View" Then
                Query.Append("if 'SLS050000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS050000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SLS050000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS050000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SLS050000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS050000' and Save_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Msg = DR.GetString(0)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        Return Msg
        'display data

    End Function

#End Region

End Class