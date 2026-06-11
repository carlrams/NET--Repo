Imports System.Data.SqlClient
Imports System.IO
Imports PROMPTINGLib

Public Class SLS060000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "iis"
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
        Master.setActiveMenu("APP", "SLS060000")
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
            'record
            tbxSLDateFrom.Text = Format(New DateTime(DateTime.Now.Year, 1, 1), "MM/dd/yyyy")
            tbxSLDateTo.Text = Format(Date.Now, "MM/dd/yyyy")
            'record

            'display record
            bindSalesOverall(0, "")
            bindRsvRank()
            bindBkRank()
            bindMonths()
            bindGSRsvChart()
            bindGSBkChart()
            bindQueSlsChart()
            bindGSRsvBarChart()
            bindGSBkBarChart()
            bindSLTypes()
            bindSLGroups()
            bindSLYear()
            bindSLTypeGroupRank(tbxSLDateFrom.Text, tbxSLDateTo.Text, "", "", "")
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindSalesOverall(Year As Int32, Territory As String)

        'get sellers for approval
        Dim Query As New StringBuilder
        If Year = 0 Then
            Query.Append("DECLARE @Year INT = YEAR(GETDATE()); ")
        Else
            Query.Append("DECLARE @Year INT = '" & Year & "'; ")
        End If
        Query.Append("  WITH Months As ( ")
        Query.Append("      select")
        Query.Append("          1 AS MonthNumber ")
        Query.Append("          ,DATENAME(MONTH, DATEADD(MONTH, 0, CAST(@Year AS VARCHAR(4)) + '-01-01')) [MonthName] ")
        Query.Append("      union all ")
        Query.Append("      select ")
        Query.Append("          MonthNumber + 1 ")
        Query.Append("          ,DATENAME(MONTH, DATEADD(MONTH, MonthNumber, CAST(@Year AS VARCHAR(4)) + '-01-01')) ")
        Query.Append("      from ")
        Query.Append("          Months ")
        Query.Append("      where ")
        Query.Append("          MonthNumber < 12) ")
        Query.Append("  ,MonthlySales As ( ")
        Query.Append("      select")
        Query.Append("          @Year [SelectedYear] ")
        Query.Append("          ,[A].MonthNumber ")
        Query.Append("          ,[A].MonthName ")
        Query.Append("          ,isnull([E].SellerGrpDesc, '-') [SLGroup] ")
        Query.Append("          ,sum([B].SellingPrice) [TotalSales] ")
        Query.Append("      from ")
        Query.Append("          Months [A] ")
        Query.Append("          left join calmardbLive.dbo.ICR_Reservations [B] on MONTH([B].RFDate) = [A].MonthNumber ")
        Query.Append("          left join calmardblive.dbo.ICR_Buyers [C] on [C].AcctNo = [B].AcctNo ")
        Query.Append("          left join calmardblive.dbo.mstr_sellers [D] on [D].SellerCode = [C].SellerCode ")
        Query.Append("          left join calmardblive.dbo.mstr_sellergroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("          left join calmardbLive.dbo.mstr_Projects [F] on [F].ProjCode = [C].ProjCode ")
        Query.Append("      where ")
        Query.Append("          YEAR([B].RFDate) = @Year ")
        Query.Append("          and [C].Active = 1 ")
        Query.Append("          and [C].Posted = 1 ")
        Query.Append("          and [E].SellerGrpDesc IS NOT NULL ")
        If Territory = "Quezon" Then
            Query.Append("          and [F].ProvinceName = '" & Territory & "' ")
        ElseIf Territory = "Laguna" Then
            Query.Append("          and [F].ProvinceName = '" & Territory & "' ")
        ElseIf Territory = "Batangas" Then
            Query.Append("          and [F].ProvinceName = '" & Territory & "' ")
        Else
            Query.Append("          and [F].ProvinceName = [F].ProvinceName ")
        End If
        Query.Append("      group by ")
        Query.Append("          [A].MonthNumber ")
        Query.Append("          ,[A].MonthName ")
        Query.Append("          ,[E].SellerGrpDesc) ")
        Query.Append("  ,RankedSales AS( ")
        Query.Append("      select")
        Query.Append("          [A].MonthNumber ")
        Query.Append("          ,[A].MonthName ")
        Query.Append("          ,[B].SLGroup ")
        Query.Append("          ,[B].TotalSales ")
        Query.Append("          ,RANK() OVER (PARTITION BY [A].MonthNumber ORDER BY [B].TotalSales DESC) [SalesRank] ")
        Query.Append("      from ")
        Query.Append("          Months [A] ")
        Query.Append("          left join MonthlySales [B] on [B].MonthNumber = [A].MonthNumber) ")
        Query.Append("          select ")
        Query.Append("              @Year [SaleYear] ")
        Query.Append("              ,[A].MonthNumber ")
        Query.Append("              ,[A].MonthName ")
        Query.Append("              ,isnull([A].SLGroup, '-') [SLGroup] ")
        Query.Append("              ,[A].TotalSales")
        Query.Append("          from ")
        Query.Append("              RankedSales [A] ")
        Query.Append("          where ")
        Query.Append("              [A].SalesRank = 1 ")
        Query.Append("          order by ")
        Query.Append("              [A].MonthNumber; ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("SLMonth"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("SLGroup"))
        dtable.Columns.Add(New DataColumn("TotalSales"))
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
                    If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetInt32(0) & "/Profile/" & DR.GetInt32(0) & ".png")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetInt32(0) & "/Profile/" & DR.GetInt32(0) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetInt32(0) & "/Profile/" & DR.GetInt32(0) & ".jpg")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetInt32(0) & "/Profile/" & DR.GetInt32(0) & ".jpg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    Dim TCP As String = If(Not DR.IsDBNull(4), String.Format("₱ {0:N2}", DR.GetDecimal(4)), "₱ 0.00")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(2), DR.GetString(3), DR.GetString(3), TCP}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvSalesOverall.DataSource = dtable
        gvSalesOverall.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvSalesOverall.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvSalesOverall.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvSalesOverall.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvSalesOverall.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindRsvRank()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   isnull([D].AgentCode, '-') [AgentCode]  ")
        Query.Append("   ,dbo.ProperCase([F].fullname) [Agent] ")
        Query.Append("   ,SUM([B].Sellingprice) [TotalSales] ")
        Query.Append("   ,ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) [Rank] ")
        Query.Append("   ,[E].SellerGrpDesc [Group] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.ICR_Sellers [C] on [C].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [C].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("   left join agent [F] on [F].agent_code = [D].AgentCode ")
        Query.Append("where ")
        Query.Append("   YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [D].AgentCode IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("   [D].AgentCode ")
        Query.Append("   ,[F].fullname ")
        Query.Append("   ,[E].SellerGrpDesc ")
        Query.Append("order by ")
        Query.Append("   [TotalSales] desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("TotalSales"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Rank"))
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
                    If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(2), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(1), TCP, DR.GetString(0), DR.GetInt64(3), DR.GetString(4)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvRsvRank.DataSource = dtable
        gvRsvRank.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvRsvRank.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvRsvRank.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvRsvRank.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvRsvRank.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindBkRank()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   isnull([D].AgentCode, '-') [AgentCode]  ")
        Query.Append("   ,dbo.ProperCase([F].fullname) [Agent] ")
        Query.Append("   ,SUM([B].Sellingprice) [TotalSales] ")
        Query.Append("   ,ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) [Rank] ")
        Query.Append("   ,[E].SellerGrpDesc [Group] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.ICR_Sellers [C] on [C].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [C].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("   left join agent [F] on [F].agent_code = [D].AgentCode ")
        Query.Append("where ")
        Query.Append("   YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [B].Posted = 1 ")
        Query.Append("   and [D].AgentCode IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("   [D].AgentCode ")
        Query.Append("   ,[F].fullname ")
        Query.Append("   ,[E].SellerGrpDesc ")
        Query.Append("order by ")
        Query.Append("   [TotalSales] desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("TotalSales"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Rank"))
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
                    If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(2), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(1), TCP, DR.GetString(0), DR.GetInt64(3), DR.GetString(4)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvBkRank.DataSource = dtable
        gvBkRank.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvBkRank.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvBkRank.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvBkRank.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvBkRank.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindMonths()
        ' Array of month names
        Dim months As String() = {
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    }

        ' Get the current month number and year
        Dim currentMonth As Integer = DateTime.Now.Month
        Dim currentYear As Integer = DateTime.Now.Year

        ' Clear any existing items in the DropDownList
        ddlMonths.Items.Clear()

        ' Populate DropDownList with months up to the current month
        For i As Integer = 1 To currentMonth
            ddlMonths.Items.Add(New ListItem($"{months(i - 1)} {currentYear}", i.ToString()))
        Next

        ' Set the current month as the default selected item
        ddlMonths.SelectedValue = currentMonth.ToString()
    End Function

    Function bindSLTypeGroupRank(DateFrom As String, DateTo As String, SLGroup As String, SLType As String, Territory As String)

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   isnull([D].AgentCode, '-') [AgentCode] ")
        Query.Append("   ,dbo.ProperCase([F].first_name + ' ' + [F].last_name) [Agent] ")
        Query.Append("   ,SUM([B].Sellingprice) [TotalSales] ")
        Query.Append("   ,ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) [Rank] ")
        Query.Append("   ,[E].SellerGrpDesc [Group] ")
        Query.Append("   ,[G].SellerTypeDesc [SLType] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.ICR_Sellers [C] on [C].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [C].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("   left join agent [F] on [F].agent_code = [D].AgentCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerTypes [G] on [G].SellerTypeCode = [D].SellerType ")
        Query.Append("   left join calmardblive.dbo.mstr_projects [H] on [H].ProjCode = [A].ProjCode ")
        Query.Append("where ")
        Query.Append("   [B].RFDate between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [D].AgentCode IS NOT NULL ")
        If SLGroup = "All" Or SLGroup = "" Then
            Query.Append("  and [E].SellerGrpCode = [E].SellerGrpCode ")
        Else
            Query.Append("   and [E].SellerGrpCode = '" & SLGroup & "' ")
        End If
        If SLType = "All" Or SLType = "" Then
            Query.Append("  and [G].SellerTypeCode = [G].SellerTypeCode ")
        Else
            Query.Append("   and [G].SellerTypeCode = '" & SLType & "' ")
        End If
        If Territory = "Quezon" Then
            Query.Append("   and [H].ProvinceName = '" & Territory & "' ")
        ElseIf Territory = "Laguna" Then
            Query.Append("   and [H].ProvinceName = '" & Territory & "' ")
        ElseIf Territory = "Batangas" Then
            Query.Append("   and [H].ProvinceName = '" & Territory & "' ")
        Else
            Query.Append("   and [H].ProvinceName = [H].ProvinceName ")
        End If
        Query.Append("group by ")
        Query.Append("   [D].AgentCode ")
        Query.Append("   ,[F].first_name ")
        Query.Append("   ,[F].last_name ")
        Query.Append("   ,[E].SellerGrpDesc ")
        Query.Append("   ,[G].SellerTypeDesc ")
        Query.Append("order by ")
        Query.Append("   [TotalSales] desc ")
        'get sellers for approval retyrn onchange

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("SLType"))
        dtable.Columns.Add(New DataColumn("SLGroup"))
        dtable.Columns.Add(New DataColumn("TotalSales"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Rank"))
        dtable.Columns.Add(New DataColumn("Seller"))
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
                    If File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg")) = True Then
                        SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(2), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(5), DR.GetString(4), TCP, DR.GetString(0), DR.GetInt64(3), DR.GetString(1)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvNewSLTypeGroupRank.DataSource = dtable
        gvNewSLTypeGroupRank.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvNewSLTypeGroupRank.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvNewSLTypeGroupRank.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvNewSLTypeGroupRank.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvNewSLTypeGroupRank.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

#Region "Dropdownlist"

    Private Sub ddlTerritory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTerritory.SelectedIndexChanged
        bindSalesOverall(ddlQueYear.SelectedValue, ddlTerritory.SelectedValue)
        bindSLTypeGroupRank(tbxSLDateFrom.Text, tbxSLDateTo.Text, ddlSLNewGroup.SelectedValue, ddlSLNewType.SelectedValue, ddlTerritory.SelectedValue)
    End Sub

    Private Sub ddlQueYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlQueYear.SelectedIndexChanged
        bindSalesOverall(ddlQueYear.SelectedValue, ddlTerritory.SelectedValue)
    End Sub

    Private Sub tbxSLDateFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxSLDateFrom.TextChanged
        bindSLTypeGroupRank(tbxSLDateFrom.Text, tbxSLDateTo.Text, ddlSLNewGroup.SelectedValue, ddlSLNewType.SelectedValue, ddlTerritory.SelectedValue)
    End Sub

    Private Sub tbxSLDateTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxSLDateTo.TextChanged
        bindSLTypeGroupRank(tbxSLDateFrom.Text, tbxSLDateTo.Text, ddlSLNewGroup.SelectedValue, ddlSLNewType.SelectedValue, ddlTerritory.SelectedValue)
    End Sub

    Private Sub ddlSLNewGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSLNewGroup.SelectedIndexChanged
        bindSLTypeGroupRank(tbxSLDateFrom.Text, tbxSLDateTo.Text, ddlSLNewGroup.SelectedValue, ddlSLNewType.SelectedValue, ddlTerritory.SelectedValue)
    End Sub

    Private Sub ddlSLNewType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSLNewType.SelectedIndexChanged
        bindSLTypeGroupRank(tbxSLDateFrom.Text, tbxSLDateTo.Text, ddlSLNewGroup.SelectedValue, ddlSLNewType.SelectedValue, ddlTerritory.SelectedValue)
    End Sub

#End Region

#Region "Charts"

    Function bindGSRsvChart()

        'get sold units per seller
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull([E].SellerGrpDesc, '-') [Group]  ")
        Query.Append("  ,SUM([B].Sellingprice) [TotalSales]  ")
        Query.Append("from  ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("  YEAR([B].RFDate) = YEAR(GETDATE())  ")
        Query.Append("  and [A].Active = 1 ")
        Query.Append("  and [A].Posted = 1 ")
        Query.Append("  and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("  [E].SellerGrpDesc ")
        Query.Append("order by ")
        Query.Append("  [TotalSales] desc ")
        'get sold units per seller 

        ltrlBarGroupSalesDataRsv.Text = ""
        ltrlBarGroupSalesNameRsv.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGroupSalesNameRsv.Text = "" Then
                        ltrlBarGroupSalesNameRsv.Text = DR.GetString(0)
                    Else
                        ltrlBarGroupSalesNameRsv.Text = ltrlBarGroupSalesNameRsv.Text & "," & DR.GetString(0)
                    End If

                    If ltrlBarGroupSalesDataRsv.Text = "" Then
                        ltrlBarGroupSalesDataRsv.Text = DR.GetDecimal(1)
                    Else
                        ltrlBarGroupSalesDataRsv.Text = ltrlBarGroupSalesDataRsv.Text & "," & DR.GetDecimal(1)
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

    Function bindGSBkChart()

        'get sold units per seller
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull([E].SellerGrpDesc, '-') [Group]  ")
        Query.Append("  ,SUM([B].Sellingprice) [TotalSales]  ")
        Query.Append("from  ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("  YEAR([B].RFDate) = YEAR(GETDATE())  ")
        Query.Append("  and [A].Active = 1 ")
        Query.Append("  and [A].Posted = 1 ")
        Query.Append("  and [B].Posted = 1 ")
        Query.Append("  and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("  [E].SellerGrpDesc ")
        Query.Append("order by ")
        Query.Append("  [TotalSales] desc ")
        'get sold units per seller 

        ltrlBarGroupSalesDataBk.Text = ""
        ltrlBarGroupSalesNameBk.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGroupSalesNameBk.Text = "" Then
                        ltrlBarGroupSalesNameBk.Text = DR.GetString(0)
                    Else
                        ltrlBarGroupSalesNameBk.Text = ltrlBarGroupSalesNameBk.Text & "," & DR.GetString(0)
                    End If

                    If ltrlBarGroupSalesDataBk.Text = "" Then
                        ltrlBarGroupSalesDataBk.Text = DR.GetDecimal(1)
                    Else
                        ltrlBarGroupSalesDataBk.Text = ltrlBarGroupSalesDataBk.Text & "," & DR.GetDecimal(1)
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

    Function bindQueSlsChart()

        'get sold units per seller
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull([E].SellerGrpDesc, '-') [Group]  ")
        Query.Append("  ,SUM([B].Sellingprice) [TotalSales]  ")
        Query.Append("from  ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardblive.dbo.mstr_projects [C] on [C].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_sellers [D] on [D].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardblive.dbo.mstr_sellergroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("  YEAR([B].RFDate) = YEAR(GETDATE())  ")
        Query.Append("  and [A].Active = 1 ")
        Query.Append("  and [A].Posted = 1 ")
        Query.Append("  and [C].ProvinceName = 'Quezon' ")
        Query.Append("  and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("  [E].SellerGrpDesc ")
        Query.Append("order by ")
        Query.Append("  [TotalSales] desc ")
        'get sold units per seller 

        ltrlBarGroupSalesDataQue.Text = ""
        ltrlBarGroupSalesNameQue.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGroupSalesNameQue.Text = "" Then
                        ltrlBarGroupSalesNameQue.Text = DR.GetString(0)
                    Else
                        ltrlBarGroupSalesNameQue.Text = ltrlBarGroupSalesNameQue.Text & "," & DR.GetString(0)
                    End If

                    If ltrlBarGroupSalesDataQue.Text = "" Then
                        ltrlBarGroupSalesDataQue.Text = DR.GetDecimal(1)
                    Else
                        ltrlBarGroupSalesDataQue.Text = ltrlBarGroupSalesDataQue.Text & "," & DR.GetDecimal(1)
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

    Function bindGSRsvBarChart()

        'get details - per project
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
        Query.Append("  ,isnull(sum([ReservedAmount]), 0) [ReservationSales] ")
        Query.Append("  ,isnull([Group], '-') [Group] ")
        Query.Append("from  ")
        Query.Append("  Month [M]  ")
        Query.Append("left join ")
        Query.Append("   (select ")
        Query.Append("      MONTH([B].RFDate) [ReservedMonth] ")
        Query.Append("      ,[B].SellingPrice [ReservedAmount] ")
        Query.Append("      ,[E].SellerGrpDesc [Group] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.ICR_Buyers [A]  ")
        Query.Append("      left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo  ")
        Query.Append("      left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [A].SellerCode  ")
        Query.Append("      left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode  ")
        Query.Append("  where ")
        Query.Append("      YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("      and [A].Active = 1   ")
        Query.Append("      and [A].Posted = 1 ")
        Query.Append("      and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("  group by ")
        Query.Append("      [B].RFDate ")
        Query.Append("      ,[B].AcctNo ")
        Query.Append("      ,[B].Sellingprice ")
        Query.Append("      ,[E].SellerGrpDesc) [Reserved] ON [Reserved].[ReservedMonth] = [M].MonthNumber ")
        Query.Append("where ")
        Query.Append("  [M].MonthNumber = MONTH(GETDATE()) ")
        Query.Append("group by ")
        Query.Append("  [M].MonthNumber ")
        Query.Append("  ,[M].MonthName  ")
        Query.Append("  ,[Group] ")
        Query.Append("order by ")
        Query.Append("  [ReservationSales] desc ")
        'get details - per project

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGrpCgy.Text = "" Then
                        ltrlBarGrpCgy.Text = DR.GetString(3)
                    Else
                        ltrlBarGrpCgy.Text = ltrlBarGrpCgy.Text & "," & DR.GetString(3)
                    End If

                    If ltrlBarGrpSlsRsv.Text = "" Then
                        ltrlBarGrpSlsRsv.Text = DR.GetDecimal(2)
                    Else
                        ltrlBarGrpSlsRsv.Text = ltrlBarGrpSlsRsv.Text & "," & DR.GetDecimal(2)
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

    Function bindGSBkBarChart()

        'get details - per project
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
        Query.Append("  ,isnull(sum([ReservedAmount]), 0) [Reservation Sales] ")
        Query.Append("  ,[Group] ")
        Query.Append("from  ")
        Query.Append("  Month [M]  ")
        Query.Append("left join ")
        Query.Append("   (select ")
        Query.Append("      MONTH([B].RFDate) [ReservedMonth] ")
        Query.Append("      ,[B].SellingPrice [ReservedAmount] ")
        Query.Append("      ,[E].SellerGrpDesc [Group] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.ICR_Buyers [A]  ")
        Query.Append("      left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo  ")
        Query.Append("      left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [A].SellerCode  ")
        Query.Append("      left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode  ")
        Query.Append("  where ")
        Query.Append("      YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("      and [A].Active = 1  ")
        Query.Append("      and [A].Posted = 1 ")
        Query.Append("      and [B].Posted = 1 ")
        Query.Append("      and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("  group by ")
        Query.Append("      [B].RFDate ")
        Query.Append("      ,[B].AcctNo ")
        Query.Append("      ,[B].Sellingprice ")
        Query.Append("      ,[E].SellerGrpDesc) [Reserved] ON [Reserved].[ReservedMonth] = [M].MonthNumber ")
        Query.Append("where ")
        'Query.Append("  [M].MonthNumber = 1 ")
        Query.Append("  [M].MonthNumber = MONTH(GETDATE()) ")
        Query.Append("group by ")
        Query.Append("  [M].MonthNumber ")
        Query.Append("  ,[M].MonthName  ")
        Query.Append("  ,[Group] ")
        Query.Append("order by ")
        Query.Append("  [M].MonthNumber ")
        'get details - per project

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGrpSlsBk.Text = "" Then
                        ltrlBarGrpSlsBk.Text = DR.GetDecimal(2)
                    Else
                        ltrlBarGrpSlsBk.Text = ltrlBarGrpSlsBk.Text & "," & DR.GetDecimal(2)
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

    Function bindSLTypes()
        'get data for house model dropdown
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'All' [Code] ")
        Query.Append("  ,'Select all' [Name] ")
        Query.Append("  ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   CAST([B].SellerTypeCode as varchar) [Code] ")
        Query.Append("   ,[B].SellerTypeDesc [Name] ")
        Query.Append("   ,CAST([B].SellerRank as varchar) [Order] ")
        Query.Append("from  ")
        Query.Append("   calmardblive.dbo.mstr_sellertypes [B]  ")
        Query.Append("order by  ")
        Query.Append("   [Order] ")
        'get data for house model dropdown

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        'ddlSLTypeQue.DataSource = DT
        'ddlSLTypeQue.DataValueField = "Code"
        'ddlSLTypeQue.DataTextField = "Name"
        'ddlSLTypeQue.DataBind()
        'fill data

        'fill data
        ddlSLNewType.DataSource = DT
        ddlSLNewType.DataValueField = "Code"
        ddlSLNewType.DataTextField = "Name"
        ddlSLNewType.DataBind()
        'fill data

    End Function

    Function bindSLGroups()
        'get data for house model dropdown
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'All' [Code] ")
        Query.Append("  ,'Select all' [Name] ")
        Query.Append("  ,'All' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   CAST([E].SellerGrpCode as varchar) [Code] ")
        Query.Append("   ,[E].SellerGrpDesc [Name] ")
        Query.Append("   ,[E].SellerGrpDesc [Order] ")
        Query.Append("from  ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardblive.dbo.mstr_projects [C] on [C].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_sellers [D] on [D].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardblive.dbo.mstr_sellergroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("   YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [C].ProvinceName = 'Quezon' ")
        Query.Append("   and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("   [E].SellerGrpDesc ")
        Query.Append("   ,[E].SellerGrpCode ")
        Query.Append("order by  ")
        Query.Append("   [Order] ")
        'get data for house model dropdown

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        'ddlSLGroupQue.DataSource = DT
        'ddlSLGroupQue.DataValueField = "Code"
        'ddlSLGroupQue.DataTextField = "Name"
        'ddlSLGroupQue.DataBind()
        'fill data

        'fill data
        ddlSLNewGroup.DataSource = DT
        ddlSLNewGroup.DataValueField = "Code"
        ddlSLNewGroup.DataTextField = "Name"
        ddlSLNewGroup.DataBind()
        'fill data

    End Function

    Function bindSLYear()
        'get data for house model dropdown
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Select year' [Name] ")
        Query.Append("  ,'' [Order] ")
        Query.Append("union ")
        Query.Append("SELECT DISTINCT ")
        Query.Append("   YEAR([A].RFDATE) [Code] ")
        Query.Append("   ,CAST(YEAR([A].RFDATE) AS VARCHAR) [Name] ")
        Query.Append("   ,YEAR([A].RFDATE) [Order] ")
        Query.Append("from  ")
        Query.Append("   calmardblive.dbo.ICR_Reservations [A] ")
        Query.Append("where ")
        Query.Append("   YEAR([A].RFDATE) BETWEEN 
					1989
					AND 
					(SELECT MAX(YEAR([A].RFDATE)) FROM calmardblive.dbo.ICR_Reservations [A]) ")
        Query.Append("order by  ")
        Query.Append("   [Order] ")
        'get data for house model dropdown

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlQueYear.DataSource = DT
        ddlQueYear.DataValueField = "Code"
        ddlQueYear.DataTextField = "Name"
        ddlQueYear.DataBind()
        'fill data

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
                Query.Append("if 'SLS060000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS060000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SLS060000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS060000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SLS060000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS060000' and Save_ = 1) ")
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