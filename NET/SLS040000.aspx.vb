Imports System.ComponentModel.DataAnnotations
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.Threading.Tasks
Imports CrystalReportsDataDefModelLib
Public Class SLS040000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "iis"
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
        Master.setActiveMenu("APP", "SLS040000")
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
            'checkUserAccess()
            bindMasterlist("")
            bindInventory("")
            bindTOL("")
            bindTL("")
            bindTechnical("")
            bindReinstatement("")
            bindCounter()
            bindProjectsMstrList()
            bindProjectsInv()
            'display record
        End If
        'load page

    End Sub

#End Region

#Region "General"
    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function bindMasterlist(Project As String)

        'get latest promo details
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 0 ")
        If Project = "[A].ProjInit" Or Project = "" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @Project  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("   ,[P].InventoryStatus ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get latest promo details

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If Project <> "[A].ProjInit" Then
                    Cmd.Parameters.AddWithValue("@Project", Project)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(6)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvAllProject.DataSource = dtable
        gvAllProject.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvAllProject.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvAllProject.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvAllProject.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvAllProject.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindTOL(ProjectTOL As String)

        'get latest promo details
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 2  ")
        If ProjectTOL = "[A].ProjInit" Or ProjectTOL = "" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @ProjectTOL  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append(",TOL AS( ")
        Query.Append("   select ")
        Query.Append("      [P].ProjInit ")
        Query.Append("      ,[P].Project ")
        Query.Append("      ,[P].HouseStatus ")
        Query.Append("      ,[P].LotType ")
        Query.Append("      ,[P].Category ")
        Query.Append("      ,[P].Status ")
        Query.Append("      ,[P].LotCode ")
        Query.Append("  from ")
        Query.Append("      ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0)) ")
        Query.Append(",History As ( ")
        Query.Append("   select ")
        Query.Append("      [T].ProjInit ")
        Query.Append("      ,[T].Project ")
        Query.Append("      ,[T].HouseStatus ")
        Query.Append("      ,[T].LotType ")
        Query.Append("      ,[T].Category ")
        Query.Append("      ,[T].Status ")
        Query.Append("      ,[T].LotCode ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].updated_date desc) [HistoryRow] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else CONVERT (varchar, [A].updated_date, 107) end) [UpdatedDate] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else RIGHT(CONVERT(varchar, [A].updated_date, 100), 7) end) [UpdatedTime] ")
        Query.Append("      ,isnull([A].inventory_status, '-') [InvStatus] ")
        Query.Append("      ,isnull([A].description, '-') [Title] ")
        Query.Append("      ,isnull([A].remarks, '-') [Remarks] ")
        Query.Append("      ,isnull(dbo.ProperCase([B].fullname), '-') [Author] ")
        Query.Append("  from ")
        Query.Append("      TOL [T] ")
        Query.Append("      left join lot_inventory_history [A] on [A].LotCode = [T].LotCode ")
        Query.Append("      left join employee [B] on [B].emp_no = [A].updated_by) ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].Project ")
        Query.Append("      ,[A].HouseStatus ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].Category ")
        Query.Append("      ,[A].Status ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[A].UpdatedDate ")
        Query.Append("      ,[A].UpdatedTime ")
        Query.Append("      ,[A].InvStatus ")
        Query.Append("      ,[A].Title ")
        Query.Append("      ,[A].Remarks ")
        Query.Append("      ,[A].Author ")
        Query.Append("  from ")
        Query.Append("      History [A] ")
        Query.Append("  where ")
        Query.Append("      [A].HistoryRow = 1 ")
        'get latest promo details

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("RemarksDate"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If ProjectTOL <> "[A].ProjInit" Then
                    Cmd.Parameters.AddWithValue("@ProjectTOL", ProjectTOL)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim RemarksDate As String = DR.GetString(7) & " | " & DR.GetString(8)

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(6), DR.GetString(10), DR.GetString(11), RemarksDate}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvTOL.DataSource = dtable
        gvTOL.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTOL.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTOL.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTOL.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTOL.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindReinstatement(ProjectReinstatement As String)

        'get latest promo details
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 3  ")
        If ProjectReinstatement = "[A].ProjInit" Or ProjectReinstatement = "" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @ProjectReinstatement  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append(",TOL AS( ")
        Query.Append("   select ")
        Query.Append("      [P].ProjInit ")
        Query.Append("      ,[P].Project ")
        Query.Append("      ,[P].HouseStatus ")
        Query.Append("      ,[P].LotType ")
        Query.Append("      ,[P].Category ")
        Query.Append("      ,[P].Status ")
        Query.Append("      ,[P].LotCode ")
        Query.Append("  from ")
        Query.Append("      ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0)) ")
        Query.Append(",History As ( ")
        Query.Append("   select ")
        Query.Append("      [T].ProjInit ")
        Query.Append("      ,[T].Project ")
        Query.Append("      ,[T].HouseStatus ")
        Query.Append("      ,[T].LotType ")
        Query.Append("      ,[T].Category ")
        Query.Append("      ,[T].Status ")
        Query.Append("      ,[T].LotCode ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].updated_date desc) [HistoryRow] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else CONVERT (varchar, [A].updated_date, 107) end) [UpdatedDate] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else RIGHT(CONVERT(varchar, [A].updated_date, 100), 7) end) [UpdatedTime] ")
        Query.Append("      ,isnull([A].inventory_status, '-') [InvStatus] ")
        Query.Append("      ,isnull([A].description, '-') [Title] ")
        Query.Append("      ,isnull([A].remarks, '-') [Remarks] ")
        Query.Append("      ,isnull(dbo.ProperCase([B].fullname), '-') [Author] ")
        Query.Append("  from ")
        Query.Append("      TOL [T] ")
        Query.Append("      left join lot_inventory_history [A] on [A].LotCode = [T].LotCode ")
        Query.Append("      left join employee [B] on [B].emp_no = [A].updated_by) ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].Project ")
        Query.Append("      ,[A].HouseStatus ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].Category ")
        Query.Append("      ,[A].Status ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[A].UpdatedDate ")
        Query.Append("      ,[A].UpdatedTime ")
        Query.Append("      ,[A].InvStatus ")
        Query.Append("      ,[A].Title ")
        Query.Append("      ,[A].Remarks ")
        Query.Append("      ,[A].Author ")
        Query.Append("  from ")
        Query.Append("      History [A] ")
        Query.Append("  where ")
        Query.Append("      [A].HistoryRow = 1 ")
        'get latest promo details

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("RemarksDate"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If ProjectReinstatement <> "[A].ProjInit" Then
                    Cmd.Parameters.AddWithValue("@ProjectReinstatement", ProjectReinstatement)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim RemarksDate As String = DR.GetString(7) & " | " & DR.GetString(8)

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(6), DR.GetString(10), DR.GetString(11), RemarksDate}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvReinstatement.DataSource = dtable
        gvReinstatement.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvReinstatement.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvReinstatement.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvReinstatement.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvReinstatement.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindTL(ProjectTL As String)

        'get latest promo details
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 4  ")
        If ProjectTL = "[A].ProjInit" Or ProjectTL = "" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @ProjectTL  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append(",TOL AS( ")
        Query.Append("   select ")
        Query.Append("      [P].ProjInit ")
        Query.Append("      ,[P].Project ")
        Query.Append("      ,[P].HouseStatus ")
        Query.Append("      ,[P].LotType ")
        Query.Append("      ,[P].Category ")
        Query.Append("      ,[P].Status ")
        Query.Append("      ,[P].LotCode ")
        Query.Append("  from ")
        Query.Append("      ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0)) ")
        Query.Append(",History As ( ")
        Query.Append("   select ")
        Query.Append("      [T].ProjInit ")
        Query.Append("      ,[T].Project ")
        Query.Append("      ,[T].HouseStatus ")
        Query.Append("      ,[T].LotType ")
        Query.Append("      ,[T].Category ")
        Query.Append("      ,[T].Status ")
        Query.Append("      ,[T].LotCode ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].updated_date desc) [HistoryRow] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else CONVERT (varchar, [A].updated_date, 107) end) [UpdatedDate] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else RIGHT(CONVERT(varchar, [A].updated_date, 100), 7) end) [UpdatedTime] ")
        Query.Append("      ,isnull([A].inventory_status, '-') [InvStatus] ")
        Query.Append("      ,isnull([A].description, '-') [Title] ")
        Query.Append("      ,isnull([A].remarks, '-') [Remarks] ")
        Query.Append("      ,isnull(dbo.ProperCase([B].fullname), '-') [Author] ")
        Query.Append("  from ")
        Query.Append("      TOL [T] ")
        Query.Append("      left join lot_inventory_history [A] on [A].LotCode = [T].LotCode ")
        Query.Append("      left join employee [B] on [B].emp_no = [A].updated_by) ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].Project ")
        Query.Append("      ,[A].HouseStatus ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].Category ")
        Query.Append("      ,[A].Status ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[A].UpdatedDate ")
        Query.Append("      ,[A].UpdatedTime ")
        Query.Append("      ,[A].InvStatus ")
        Query.Append("      ,[A].Title ")
        Query.Append("      ,[A].Remarks ")
        Query.Append("      ,[A].Author ")
        Query.Append("  from ")
        Query.Append("      History [A] ")
        Query.Append("  where ")
        Query.Append("      [A].HistoryRow = 1 ")
        'get latest promo details

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("RemarksDate"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If ProjectTL <> "[A].ProjInit" Then
                    Cmd.Parameters.AddWithValue("@ProjectTL", ProjectTL)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim RemarksDate As String = DR.GetString(7) & " | " & DR.GetString(8)

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(6), DR.GetString(10), DR.GetString(11), RemarksDate}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvTL.DataSource = dtable
        gvTL.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTL.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTL.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTL.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTL.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindTechnical(ProjectTechnical As String)

        'get latest promo details
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 5  ")
        If ProjectTechnical = "[A].ProjInit" Or ProjectTechnical = "" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @ProjectTechnical  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append(",TOL AS( ")
        Query.Append("   select ")
        Query.Append("      [P].ProjInit ")
        Query.Append("      ,[P].Project ")
        Query.Append("      ,[P].HouseStatus ")
        Query.Append("      ,[P].LotType ")
        Query.Append("      ,[P].Category ")
        Query.Append("      ,[P].Status ")
        Query.Append("      ,[P].LotCode ")
        Query.Append("  from ")
        Query.Append("      ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0)) ")
        Query.Append(",History As ( ")
        Query.Append("   select ")
        Query.Append("      [T].ProjInit ")
        Query.Append("      ,[T].Project ")
        Query.Append("      ,[T].HouseStatus ")
        Query.Append("      ,[T].LotType ")
        Query.Append("      ,[T].Category ")
        Query.Append("      ,[T].Status ")
        Query.Append("      ,[T].LotCode ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].updated_date desc) [HistoryRow] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else CONVERT (varchar, [A].updated_date, 107) end) [UpdatedDate] ")
        Query.Append("      ,(case when [A].updated_date is null then '-' else RIGHT(CONVERT(varchar, [A].updated_date, 100), 7) end) [UpdatedTime] ")
        Query.Append("      ,isnull([A].inventory_status, '-') [InvStatus] ")
        Query.Append("      ,isnull([A].description, '-') [Title] ")
        Query.Append("      ,isnull([A].remarks, '-') [Remarks] ")
        Query.Append("      ,isnull(dbo.ProperCase([B].fullname), '-') [Author] ")
        Query.Append("  from ")
        Query.Append("      TOL [T] ")
        Query.Append("      left join lot_inventory_history [A] on [A].LotCode = [T].LotCode ")
        Query.Append("      left join employee [B] on [B].emp_no = [A].updated_by) ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].Project ")
        Query.Append("      ,[A].HouseStatus ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].Category ")
        Query.Append("      ,[A].Status ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[A].UpdatedDate ")
        Query.Append("      ,[A].UpdatedTime ")
        Query.Append("      ,[A].InvStatus ")
        Query.Append("      ,[A].Title ")
        Query.Append("      ,[A].Remarks ")
        Query.Append("      ,[A].Author ")
        Query.Append("  from ")
        Query.Append("      History [A] ")
        Query.Append("  where ")
        Query.Append("      [A].HistoryRow = 1 ")
        'get latest promo details

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("RemarksDate"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If ProjectTechnical <> "[A].ProjInit" Then
                    Cmd.Parameters.AddWithValue("@ProjectTechnical", ProjectTechnical)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim RemarksDate As String = DR.GetString(7) & " | " & DR.GetString(8)

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(6), DR.GetString(10), DR.GetString(11), RemarksDate}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvTechnical.DataSource = dtable
        gvTechnical.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTechnical.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTechnical.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTechnical.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTechnical.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindInventory(ProjectInv As String)

        'get latest promo details
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 1  ")
        If ProjectInv = "All" Or ProjectInv = "" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @ProjectInv  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get latest promo details

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If ProjectInv <> "All" Then
                    Cmd.Parameters.AddWithValue("@ProjectInv", ProjectInv)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(6)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvProjList.DataSource = dtable
        gvProjList.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvProjList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvProjList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvProjList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvProjList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Private Sub ddlProjMstr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProjMstr.SelectedIndexChanged
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        bindMasterlist(ddlProjMstr.SelectedValue)
    End Sub

    Private Sub ddlProjInv_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProjInv.SelectedIndexChanged
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleInv();", True)
        bindInventory(ddlProjInv.SelectedValue)
    End Sub

    Function bindCounter()

        'get latest promo details
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[C].ModelCode [ModelCode] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   count(case when [P].InventoryStatus = 1 then 1 end) [Inventory] ")
        Query.Append("   ,count(case when [P].InventoryStatus = 0 then 1 end) [Masterlist] ")
        Query.Append("   ,count(case when [P].InventoryStatus = 2 then 1 end) [TOL] ")
        Query.Append("   ,count(case when [P].InventoryStatus = 3 then 1 end) [Reinstatement] ")
        Query.Append("   ,count(case when [P].InventoryStatus = 4 then 1 end) [TL] ")
        Query.Append("   ,count(case when [P].InventoryStatus = 5 then 1 end) [TechnicalHolding] ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        'get latest promo details

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblMasterlistCount.Text = DR.GetInt32(1)
                    lblInventoryCount.Text = DR.GetInt32(0)
                    lblTOLCount.Text = DR.GetInt32(2)
                    lblReinstatementCount.Text = DR.GetInt32(3)
                    lblTLCount.Text = DR.GetInt32(4)
                    lblTechnicalCount.Text = DR.GetInt32(5)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'update
        mdlInventoryDtl.Update()
        'update

    End Function

#End Region

#Region "Dropdown"

    Function bindProjectsMstrList()
        'get data for house model dropdown
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select distinct ")
        Query.Append("      [A].ProjInit  ")
        Query.Append("      ,[C].ModelCode [ModelCode] ")
        Query.Append("      ,[A].ProjName  ")
        Query.Append("      ,(select count(1) from calmardbLive.dbo.lot [B] left join calmardbLive.dbo.mstr_LotsInventory [C] on [C].LotCode = [B].LotCode where [B].HCRate = 100 and [B].Saleable = 1 and [B].PropertyStatus = 'Open' and [C].IsReserve not in (1,3) and [B].ProjInit = [A].ProjInit) [RFO] ")
        Query.Append("      ,(select count(1) from calmardbLive.dbo.lot [B] left join calmardbLive.dbo.mstr_LotsInventory [C] on [C].LotCode = [B].LotCode where [B].HCRate <> 100 and [B].Saleable = 1 and [B].PropertyStatus = 'Open' and [C].IsReserve not in (1,3) and [B].ProjInit = [A].ProjInit) [Non-RFO] ")
        Query.Append("      ,[A].ProjCode  ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status]  ")
        Query.Append("      ,[A].HCRate [Rate]  ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow]  ")
        Query.Append("   from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open'  ")
        Query.Append("      and [B].IsReserve <> 3  ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0))  ")
        Query.Append("select ")
        Query.Append("  '[A].ProjInit' [Code] ")
        Query.Append("  ,'Select all' [Name] ")
        Query.Append("  ,'All' [Order] ")
        Query.Append("union ")
        Query.Append("select distinct ")
        Query.Append("   CAST([P].ProjInit as varchar) [Code] ")
        Query.Append("   ,[P].ProjName [Name] ")
        Query.Append("   ,[P].ProjName [Order] ")
        Query.Append("from  ")
        Query.Append("   ProjList [P]  ")
        Query.Append("where  ")
        Query.Append("   [P].RFO + [P].[Non-RFO] <> 0  ")
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
        ddlProjMstr.DataSource = DT
        ddlProjMstr.DataValueField = "Code"
        ddlProjMstr.DataTextField = "Name"
        ddlProjMstr.DataBind()
        'fill data

    End Function

    Function bindProjectsInv()
        'get data for house model dropdown
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select distinct ")
        Query.Append("      [A].ProjInit  ")
        Query.Append("      ,[C].ModelCode [ModelCode] ")
        Query.Append("      ,[A].ProjName  ")
        Query.Append("      ,(select count(1) from calmardbLive.dbo.lot [B] left join calmardbLive.dbo.mstr_LotsInventory [C] on [C].LotCode = [B].LotCode where [B].HCRate = 100 and [B].Saleable = 1 and [B].PropertyStatus = 'Open' and [C].IsReserve not in (1,3) and [B].ProjInit = [A].ProjInit) [RFO] ")
        Query.Append("      ,(select count(1) from calmardbLive.dbo.lot [B] left join calmardbLive.dbo.mstr_LotsInventory [C] on [C].LotCode = [B].LotCode where [B].HCRate <> 100 and [B].Saleable = 1 and [B].PropertyStatus = 'Open' and [C].IsReserve not in (1,3) and [B].ProjInit = [A].ProjInit) [Non-RFO] ")
        Query.Append("      ,[A].ProjCode  ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status]  ")
        Query.Append("      ,[A].HCRate [Rate]  ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow]  ")
        Query.Append("   from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [A].Saleable = 1  ")
        Query.Append("      and [B].inventory_status = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open'  ")
        Query.Append("      and [B].IsReserve <> 3  ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0))  ")
        Query.Append("select ")
        Query.Append("  'All' [Code] ")
        Query.Append("  ,'Select all' [Name] ")
        Query.Append("  ,'All' [Order] ")
        Query.Append("union ")
        Query.Append("select distinct ")
        Query.Append("   CAST([P].ProjInit as varchar) [Code] ")
        Query.Append("   ,[P].ProjName [Name] ")
        Query.Append("   ,[P].ProjName [Order] ")
        Query.Append("from  ")
        Query.Append("   ProjList [P]  ")
        Query.Append("where  ")
        Query.Append("   [P].RFO + [P].[Non-RFO] <> 0  ")
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
        ddlProjInv.DataSource = DT
        ddlProjInv.DataValueField = "Code"
        ddlProjInv.DataTextField = "Name"
        ddlProjInv.DataBind()
        'fill data

    End Function


#End Region

#Region "Button"

    Protected Sub lbtnAddtoInventory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAddtoInventory.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Add_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindInventory("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        'update panel 
    End Sub

    Protected Sub lbtnTOL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnTOL.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblTOLLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblTOLLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblTOLLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_TOL_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pRemarks", tbxTOLRemarks.Text)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindTOL("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlTOLProj').modal('hide');</script>", False)
        'update panel 
    End Sub

    Protected Sub lbtnReinstatement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnReinstatement.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Reinstatement_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pRemarks", tbxReinstatementRemarks.Text)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindReinstatement("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlReinstatementProj').modal('hide');</script>", False)
        'update panel 
    End Sub

    Protected Sub lbtnTL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnTL.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_TL_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pRemarks", tbxTLRemarks.Text)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindTL("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlTLProj').modal('hide');</script>", False)
        'update panel 
    End Sub

    Protected Sub lbtnTechnical_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnTechnical.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Technical_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pRemarks", tbxTechnicalRemarks.Text)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindTechnical("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlTechnicalProj').modal('hide');</script>", False)
        'update panel 
    End Sub

    Protected Sub lbtnUnhold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnUnhold.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTOL.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTOL.Rows(RowIdx).FindControl("TOLCheckbox")
            Dim lblTOLLotCode As Label = gvTOL.Rows(RowIdx).FindControl("lblTOLLotCode")
            hfLotCode.Value = lblTOLLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblTOLLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Unhold_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pCategory", "TOL")
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindTOL("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        'update panel 
    End Sub

    Protected Sub lbtnUnholdReinstatement_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnUnholdReinstatement.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvReinstatement.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvReinstatement.Rows(RowIdx).FindControl("ReinstatementCheckbox")
            Dim lblReinstatementLotCode As Label = gvReinstatement.Rows(RowIdx).FindControl("lblReinstatementLotCode")
            hfLotCode.Value = lblReinstatementLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblReinstatementLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Unhold_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pCategory", "Reinstatement")
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindReinstatement("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        'update panel 
    End Sub

    Protected Sub lbtnUnholdTL_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnUnholdTL.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTL.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTL.Rows(RowIdx).FindControl("TLCheckbox")
            Dim lblTechnicalLotCode As Label = gvTL.Rows(RowIdx).FindControl("lblTechnicalLotCode")
            hfLotCode.Value = lblTechnicalLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblTechnicalLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Unhold_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pCategory", "TL")
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindTL("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        'update panel 
    End Sub

    Protected Sub lbtnUnholdTechnical_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnUnholdTechnical.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTechnical.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTechnical.Rows(RowIdx).FindControl("TechnicalCheckbox")
            Dim lblTechnicalLotCode As Label = gvTechnical.Rows(RowIdx).FindControl("lblTechnicalLotCode")
            hfLotCode.Value = lblTechnicalLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblTechnicalLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Unhold_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                SqlCmd.Parameters.AddWithValue("@pCategory", "Technical")
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindTechnical("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        'update panel 
    End Sub

    Protected Sub lbtnReturntoMasterlist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnReturntoMasterlist.Click

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvProjList.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvProjList.Rows(RowIdx).FindControl("InvCheckbox")
            Dim lblLotCode As Label = gvProjList.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "SL_Return_Lot"
                SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'display item
        bindInventory("")
        bindMasterlist("")
        bindCounter()
        'display item

        'update panel 
        mdlInventoryDtl.Update()
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "toggleMstr();", True)
        'update panel 
    End Sub

    Protected Sub btnProjTOL_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create var
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create var

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckBox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckBox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 0  ")
        Query.Append("      and [A].Lotcode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(4), DR.GetString(3), DR.GetString(2), DR.GetString(6)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvTOLProj.DataSource = dtable
        gvTOLProj.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTOLProj.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTOLProj.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTOLProj.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTOLProj.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update
        mdlTOLProj.Update()
        'update         

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlTOLProj').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnProjReinstatement_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create var
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create var

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckBox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckBox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 0  ")
        Query.Append("      and [A].Lotcode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(4), DR.GetString(3), DR.GetString(2), DR.GetString(6)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvReinstatementProj.DataSource = dtable
        gvReinstatementProj.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvReinstatementProj.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvReinstatementProj.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvReinstatementProj.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvReinstatementProj.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update
        mdlReinstatementProj.Update()
        'update         

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlReinstatementProj').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnProjTL_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create var
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create var

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckBox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckBox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 0  ")
        Query.Append("      and [A].Lotcode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(4), DR.GetString(3), DR.GetString(2), DR.GetString(6)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvTLProj.DataSource = dtable
        gvTLProj.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTLProj.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTLProj.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTLProj.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTLProj.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update
        mdlTLProj.Update()
        'update         

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlTLProj').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnProjTechnical_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create var
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create var

        'get selected rows
        Do Until RowIdx = gvAllProject.Rows.Count
            Dim RowCheckBox As HtmlInputCheckBox = gvAllProject.Rows(RowIdx).FindControl("MstrCheckbox")
            Dim lblLotCode As Label = gvAllProject.Rows(RowIdx).FindControl("lblLotCode")
            hfLotCode.Value = lblLotCode.Text
            If RowCheckBox.Checked = True Then
                IDSrs = IDSrs & "," & lblLotCode.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 0  ")
        Query.Append("      and [A].Lotcode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ProjImage"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Category"))
        dtable.Columns.Add(New DataColumn("LotType"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("LotCode"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(4), DR.GetString(3), DR.GetString(2), DR.GetString(6)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvTechnicalProj.DataSource = dtable
        gvTechnicalProj.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTechnicalProj.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTechnicalProj.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTechnicalProj.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTechnicalProj.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update
        mdlTechnicalProj.Update()
        'update         

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlTechnicalProj').modal('show');</script>", False)
        'modal

    End Sub

#End Region

#Region "Validation"

    'Private Sub checkUserAccess()

    '    'retrieve user information from the cookie
    '    Dim Validator As String = CIIS_UserInfo.Values("CIIS_EmpCode")

    '    'validate user credentials
    '    If validateUserAccess(Validator) = False Then
    '        Response.Redirect("DSB000001")
    '    End If

    'End Sub

    'Private Function validateUserAccess(Validator As String) As Boolean

    '    'get agent details
    '    Dim Query As New StringBuilder
    '    Query.Append("if (select [A].emp_no from employee [A] where [A].emp_no = '" & Validator & "') in ('2010000024', 'MN2021080000', 'MN2024030004', 'MN2023100001') ")
    '    Query.Append("begin ")
    '    Query.Append("  select 'Approved' ")
    '    Query.Append("end ")
    '    Query.Append("else ")
    '    Query.Append("begin ")
    '    Query.Append("  select 'Denied' ")
    '    Query.Append("end ")
    '    'get agent details

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()
    '                Dim Access As String = DR.GetString(0)

    '                If Access = "Approved" Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            End While
    '            DR.Close()
    '            ConStr.Close()
    '        End Using
    '    End Using
    '    'read record

    'End Function

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
                Query.Append("if 'SLS020000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS020000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SLS020000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS020000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SLS020000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS020000' and Save_ = 1) ")
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