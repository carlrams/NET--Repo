Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.PeerToPeer.Collaboration
Imports System.Web.WebSockets
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.AspNet.SignalR.Infrastructure
Imports OfficeOpenXml.SystemDrawing.Text

Public Class SCM050000
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
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
            CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SCM050000")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'bind
            bind01Warehouse()
            bind01ChargeTo()
            bind01PRDtl("")
            'bind

        ElseIf IsPostBack = True Then

            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
            If gv01PRDtl.Rows.Count > 0 Then
                gv01PRDtl.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
            If gv01Review.Rows.Count > 0 Then
                gv01Review.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Protected Sub lbtn01Fill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn01Fill.Click
        If tbx01PRNo.Value = "" Then
            Alert("error", "Some field(s) are missing!")
        Else
            bind01PRDtl(tbx01PRNo.Value)
        End If
    End Sub

    Private Sub lbtn01Preview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn01Preview.Click

        'validate
        If tbx01PRNo.Value = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf ddl01Warehouse.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf ddl01ChargeTo.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf tbx01Project.Text = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        End If
        'validate

        'set value
        lbl01PRNo.Text = tbx01PRNo.Value
        lbl01Warehouse.Text = ddl01Warehouse.SelectedItem.Text
        lbl01ChargeTo.Text = ddl01ChargeTo.SelectedItem.Text
        'set value

        'hidden
        hf01PRNo.Value = tbx01PRNo.Value
        hf01Warehouse.Value = ddl01Warehouse.SelectedValue
        hf01ChargeTo.Value = ddl01ChargeTo.SelectedValue
        'hidden

        'Create datatable for final materials
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("PRSeqNo"))
        dtable.Columns.Add(New DataColumn("PRItem"))
        dtable.Columns.Add(New DataColumn("PRQty"))
        dtable.Columns.Add(New DataColumn("PRUnit"))
        dtable.Columns.Add(New DataColumn("ItemCode"))
        dtable.Columns.Add(New DataColumn("ItemName"))
        dtable.Columns.Add(New DataColumn("Balance"))
        dtable.Columns.Add(New DataColumn("Qty"))
        dtable.Columns.Add(New DataColumn("UMCode"))
        dtable.Columns.Add(New DataColumn("UMName"))
        dtable.Columns.Add(New DataColumn("ContractorCode"))
        dtable.Columns.Add(New DataColumn("ContractorName"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        'Create datatable for final materials

        'validate detail field
        Dim Cnt = 0
        Dim RowIdx = 0
        Do Until RowIdx = gv01PRDtl.Rows.Count
            Dim lblPRSeqNo As Label = gv01PRDtl.Rows(RowIdx).FindControl("lblPRSeqNo")
            Dim lblPRItem As Label = gv01PRDtl.Rows(RowIdx).FindControl("lblPRItem")
            Dim lblPRQty As Label = gv01PRDtl.Rows(RowIdx).FindControl("lblPRQty")
            Dim lblPRUnit As Label = gv01PRDtl.Rows(RowIdx).FindControl("lblPRUnit")
            Dim ddlItem As DropDownList = gv01PRDtl.Rows(RowIdx).FindControl("ddl01Item")
            Dim lblBalance As Label = gv01PRDtl.Rows(RowIdx).FindControl("lblBalance")
            Dim tbxQtyIssued As HtmlInputText = gv01PRDtl.Rows(RowIdx).FindControl("tbx01QtyIssued")
            Dim lblUMCode As Label = gv01PRDtl.Rows(RowIdx).FindControl("lblUMCode")
            Dim lblUMName As Label = gv01PRDtl.Rows(RowIdx).FindControl("lblUMName")
            Dim ddlContractor As DropDownList = gv01PRDtl.Rows(RowIdx).FindControl("ddl01Contractor")
            Dim tbxRemarks As HtmlInputText = gv01PRDtl.Rows(RowIdx).FindControl("tbx01Remarks")
            Dim PRSeqNo As String = lblPRSeqNo.Text
            Dim PRItem As String = lblPRItem.Text
            Dim PRQty As String = lblPRQty.Text
            Dim PRUnit As String = lblPRUnit.Text
            Dim ItemCode As String = ddlItem.SelectedValue
            Dim ItemName As String = ddlItem.SelectedItem.Text
            Dim Balance As String = lblBalance.Text
            Dim Qty As String = tbxQtyIssued.Value
            Dim UMCode As String = lblUMCode.Text
            Dim UMName As String = lblUMName.Text
            Dim ContractorCode As String = ddlContractor.SelectedValue
            Dim ContractorName As String = ddlContractor.SelectedItem.Text
            Dim Remarks As String = IIf(tbxRemarks.Value = "", tbx01Project.Text, tbxRemarks.Value)

            If (ItemCode <> "" Or CDbl(Qty) > 0 Or UMCode <> "" Or ContractorCode <> "") And (ItemCode = "" Or CDbl(Qty) <= 0 Or UMCode = "" Or ContractorCode = "") Then
                Alert("error", "Please complete the For Issuance input fields!")
                Exit Sub
            ElseIf CDbl(Qty) > CDbl(PRQty) Then
                Alert("error", "Item issue exceed maximum PR request balance!")
                Exit Sub
            ElseIf CDbl(Qty) > CDbl(Balance) Then
                Alert("error", "Insufficient warehouse item balance!")
                Exit Sub
            ElseIf ItemCode <> "" And CDbl(Qty) > 0 And UMCode <> "" And ContractorCode <> "" Then
                Cnt = Cnt + 1
                Dim rValues As Object() = {PRSeqNo, PRItem, PRQty, PRUnit, ItemCode, ItemName, Balance, Qty, UMCode, UMName, ContractorCode, ContractorName, Remarks}
                Dim dRow As DataRow
                dRow = dtable.Rows.Add(rValues)
                dtable.AcceptChanges()
            End If

            RowIdx = RowIdx + 1
        Loop
        'validate detail field

        'validate
        If Cnt = 0 Then
            Alert("error", "Requires atleast one material for issuance!")
            Exit Sub
        End If
        'validate

        'bind
        gv01Review.DataSource = dtable
        gv01Review.DataBind()
        'bind

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv01Review.Rows.Count > 0 Then
            gv01Review.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update display
        mdl01Review.Update()
        'update display

        'show modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Review').modal('show');</script>", False)
        'show modal

    End Sub

    Protected Sub btn01SaveOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_SIDtl_SCM"
        SqlCmd.Parameters.AddWithValue("@pPRNo", hf01PRNo.Value)
        SqlCmd.Parameters.AddWithValue("@pWhseCode", hf01Warehouse.Value)
        SqlCmd.Parameters.AddWithValue("@pChargeto", hf01ChargeTo.Value)
        SqlCmd.Parameters.AddWithValue("@pItemSRS", GetMaterials())
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        Dim SINo As New SqlClient.SqlParameter("@oSINo", SqlDbType.NVarChar, 1000)
        SINo.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(SINo)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'set
        hfSINo.Value = SINo.Value
        'set

        'display record
        tbx01PRNo.Value = ""
        ddl01Warehouse.SelectedValue = ""
        ddl01ChargeTo.SelectedValue = ""
        tbx01Project.Text = ""
        bind01PRDtl("")
        mdl01Review.Update()
        'display record

        'success alert
        'Alert("success", "Record successfully saved. " & SINo.Value)
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none",
        "<script>
            Swal.fire({
                text: 'Record successfully saved. " & SINo.Value & "',
                icon: 'success',
                buttonsStyling: false,
                confirmButtonText: 'Preview Report',
                customClass: {
                    confirmButton: 'btn btn-primary'
                }
            }).then((result) => {
              // Modal
              $('#ContentPlaceHolder1_mdl01Review').modal('hide');
              if (result.isConfirmed) {
                    // Report
                    btn01Report1();
              };
            });
        </script>", False)
        'success alert

        Exit Sub

    End Sub

#End Region

#Region "Function"
    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none",
        "<script>
        setTimeout(function() {
            $('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');
            Swal.fire({
                text: '" & Message_ & "',
                icon: '" & Alert_ & "',
                buttonsStyling: false,
                confirmButtonText: 'Ok, got it!',
                customClass: {
                    confirmButton: '" & class_ & "'
                }
            }).then((result) => {
              if (result.isConfirmed) {
                    " & IIf(Alert_ = "success", "$('#ContentPlaceHolder1_mdl01Review').modal('hide');", "console.log('Error');") & "
              }
            });
        }, 200);
    </script>", False)
    End Function

    Function bind01Warehouse()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a warehouse' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   w_code [Code] ")
        Query.Append("   ,warehouse [Name] ")
        Query.Append("   ,warehouse [Order] ")
        Query.Append("from ")
        Query.Append("   ogm_warehouse ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Warehouse.DataSource = DT
        ddl01Warehouse.DataValueField = "Code"
        ddl01Warehouse.DataTextField = "Name"
        ddl01Warehouse.DataBind()
        'fill data

        'update display
        upnlContent.Update()
        'update display

    End Function

    Function bind01ChargeTo()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Select a charge to' [Name] ")
        Query.Append("  ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  ms_code [Code] ")
        Query.Append("  ,description [Name] ")
        Query.Append("  ,description [Order] ")
        Query.Append("from ")
        Query.Append("  fin_misc_sub ")
        Query.Append("where ")
        Query.Append("  a_code = '07030004' ")
        Query.Append("order by ")
        Query.Append("  [Order] ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01ChargeTo.DataSource = DT
        ddl01ChargeTo.DataValueField = "Code"
        ddl01ChargeTo.DataTextField = "Name"
        ddl01ChargeTo.DataBind()
        'fill data

        'update display
        upnlContent.Update()
        'update display

    End Function

    Function bind01PRDtl(PRNo As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].pr_code [PRCode] ")
        Query.Append("  ,[A].seq_no [PRSeqNo] ")
        Query.Append("  ,[A].item [PRItem] ")
        Query.Append("  ,(case when [A].ForSRBalance < 0 then '0.00' else [A].ForSRBalance end) [PRQty] ")
        Query.Append("  ,[A].unit [PRUnit] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
        Query.Append("where ")
        Query.Append("  [A].for_sr > 0 ")
        Query.Append("  and [B].form_no = '" & PRNo & "' ")
        Query.Append("order by ")
        Query.Append("  [A].item ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'bind
        gv01PRDtl.DataSource = DT
        gv01PRDtl.EmptyDataText = "No data. Please input the required fields."
        gv01PRDtl.DataBind()
        'bind

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv01PRDtl.Rows.Count > 0 Then
            gv01PRDtl.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update
        upnlContent.Update()
        'update

    End Function

    Private Sub gv01PRDtl_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv01PRDtl.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim HeaderGridRow As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
            HeaderGridRow.TableSection = TableRowSection.TableHeader
            Dim HeaderCell As TableCell = New TableCell
            HeaderCell.Text = "Stock Request"
            HeaderCell.ColumnSpan = 3
            HeaderCell.CssClass = "fw-bolder fs-7 text-gray-400"
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell
            HeaderCell.Text = "Warehouse"
            HeaderCell.ColumnSpan = 4
            HeaderCell.CssClass = "fw-bolder fs-7 text-gray-400"
            HeaderGridRow.Cells.Add(HeaderCell)

            gv01PRDtl.Controls(0).Controls.AddAt(0, HeaderGridRow)
        End If
    End Sub

    Protected Sub gv01PRDtl_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gv01PRDtl.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddl01Item As DropDownList = DirectCast(e.Row.FindControl("ddl01Item"), DropDownList)
            Dim ddl01Contractor As DropDownList = DirectCast(e.Row.FindControl("ddl01Contractor"), DropDownList)

            Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            Dim QueryItem As String = "select '' [Code], 'Select a Item' [Item], '' [Order], '' [UMName] union select ItemCode [Code], ItemName [Name], ItemName [Order], UMName [UMName] from ItemBalance where year = year(getdate()) and period = month(getdate()) and WhseCode = '" & ddl01Warehouse.SelectedValue & "' and qty > 0 order by [Order]"
            Dim QueryContractor As String = "select '' [Code], 'Select a Contractor' [Name], '' [Order] union select v_code [Code], vendor [Name], vendor [Order] from ogm_vendor where type = 'Contractor' and lock = 1 order by [Order] "

            Dim SqlCon As New SqlConnection(ConStr)

            'ddl Item request
            Dim SDAItem As New SqlDataAdapter(QueryItem, SqlCon)
            Dim DTItem As New DataTable()
            SDAItem.Fill(DTItem)

            ddl01Item.DataSource = DTItem
            ddl01Item.DataValueField = "Code"
            ddl01Item.DataTextField = "Item"
            ddl01Item.DataBind()

            'ddl Contractor
            Dim SDAContractor As New SqlDataAdapter(QueryContractor, SqlCon)
            Dim DTContractor As New DataTable()
            SDAContractor.Fill(DTContractor)

            ddl01Contractor.DataSource = DTContractor
            ddl01Contractor.DataValueField = "Code"
            ddl01Contractor.DataTextField = "Name"
            ddl01Contractor.DataBind()
        End If
    End Sub

    Private Sub ddl01Warehouse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl01Warehouse.SelectedIndexChanged
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim Query As String = "select '' [Code], 'Select a Item' [Name], '' [Order] union select ItemCode [Code], ItemName [Name], ItemName [Order] from ItemBalance where year = year(getdate()) and period = month(getdate()) and WhseCode = '" & ddl01Warehouse.SelectedValue & "' and qty > 0 order by [Order] "
        Dim SqlCon As New SqlConnection(ConStr)

        'ddl Item request
        Dim SDA As New SqlDataAdapter(Query, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)

        Dim RowIdx = 0
        Do Until RowIdx = gv01PRDtl.Rows.Count
            Dim ddl01Item As DropDownList = gv01PRDtl.Rows(RowIdx).FindControl("ddl01Item")

            ddl01Item.DataSource = DT
            ddl01Item.DataValueField = "Code"
            ddl01Item.DataTextField = "Name"
            ddl01Item.DataBind()

            RowIdx = RowIdx + 1
        Loop

        upnlContent.Update()
    End Sub

    Protected Sub ddl01Item_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim ddl01Item As DropDownList = DirectCast(sender, DropDownList)
        Dim row As GridViewRow = DirectCast(ddl01Item.NamingContainer, GridViewRow)
        Dim lblBalance As Label = DirectCast(row.FindControl("lblBalance"), Label)
        Dim lblUMCode As Label = DirectCast(row.FindControl("lblUMCode"), Label)
        Dim lblUMName As Label = DirectCast(row.FindControl("lblUMName"), Label)

        Dim query As New StringBuilder
        query.Append("select ")
        query.Append("	Qty ")
        query.Append("	,UMCode ")
        query.Append("	,UMName ")
        query.Append("from ")
        query.Append("	ItemBalance ")
        query.Append("where ")
        query.Append("  Year = year(getdate()) ")
        query.Append("  and Period = month(getdate()) ")
        query.Append("  and WhseCode = '" & ddl01Warehouse.SelectedValue & "' ")
        query.Append("  and ItemCode = '" & ddl01Item.SelectedValue & "' ")
        query.Append("  and Qty > 0 ")
        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblBalance.Text = Format(DR.GetDecimal(0), "N2")
                    lblUMCode.Text = DR.GetString(1)
                    lblUMName.Text = DR.GetString(2)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        If ddl01Item.SelectedValue = "" Then
            lblBalance.Text = Format(0, "N2")
            lblUMCode.Text = ""
            lblUMName.Text = ""
        End If

        upnlContent.Update()
    End Sub

    Private Sub gv01Review_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv01Review.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim HeaderGridRow As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
            HeaderGridRow.TableSection = TableRowSection.TableHeader
            Dim HeaderCell As TableCell = New TableCell
            HeaderCell.Text = "Stock Request"
            HeaderCell.ColumnSpan = 3
            HeaderCell.CssClass = "fw-bolder fs-7 text-gray-400"
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell
            HeaderCell.Text = "Warehouse"
            HeaderCell.ColumnSpan = 4
            HeaderCell.CssClass = "fw-bolder fs-7 text-gray-400"
            HeaderGridRow.Cells.Add(HeaderCell)

            gv01Review.Controls(0).Controls.AddAt(0, HeaderGridRow)
        End If
    End Sub

    Function GetMaterials()
        'TODO:get the final materials from modal
        Dim pItemSrs As String = ""
        Dim RowIdx = 0
        Do Until RowIdx = gv01Review.Rows.Count
            Dim lblItemCode As Label = gv01Review.Rows(RowIdx).FindControl("lblItemCode")
            Dim lblQty As Label = gv01Review.Rows(RowIdx).FindControl("lblQty")
            Dim lblUMCode As Label = gv01Review.Rows(RowIdx).FindControl("lblUMCode")
            Dim lblContractorCode As Label = gv01Review.Rows(RowIdx).FindControl("lblContractorCode")
            Dim lblRemarks As Label = gv01Review.Rows(RowIdx).FindControl("lblRemarks")
            Dim lblPRSeqNo As Label = gv01Review.Rows(RowIdx).FindControl("lblPRSeqNo")
            Dim lblPRItem As Label = gv01Review.Rows(RowIdx).FindControl("lblPRItem")
            Dim lblPRQty As Label = gv01Review.Rows(RowIdx).FindControl("lblQty")
            Dim lblPRUnit As Label = gv01Review.Rows(RowIdx).FindControl("lblPRUnit")


            Dim ItemCode As String = lblItemCode.Text
            Dim Qty As String = CDbl(lblQty.Text)
            Dim Unit As String = lblUMCode.Text
            Dim Contractor As String = lblContractorCode.Text
            Dim Remarks As String = lblRemarks.Text
            Dim PRSeqNo As String = lblPRSeqNo.Text
            Dim PRItem As String = lblPRItem.Text
            Dim PRQty As String = CDbl(lblPRQty.Text)
            Dim PRUnit As String = lblPRUnit.Text

            If pItemSrs = "" Then
                pItemSrs = ItemCode & "©" & Qty & "©" & Unit & "©" & Contractor & "©" & Remarks & "©" & PRSeqNo & "©" & PRItem & "©" & PRQty & "©" & PRUnit
            Else
                pItemSrs = pItemSrs & "®" & ItemCode & "©" & Qty & "©" & Unit & "©" & Contractor & "©" & Remarks & "©" & PRSeqNo & "©" & PRItem & "©" & PRQty & "©" & PRUnit
            End If
            RowIdx = RowIdx + 1
        Loop
        Return pItemSrs
    End Function
    Function GetCode(ByVal pID As String)

        'variable
        Dim pSICode As String = ""
        'variable

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  si_code [SICode] ")
        Query.Append("from ")
        Query.Append("  ogm_si_hdr ")
        Query.Append("where ")
        Query.Append("  SINo = @pID ")
        'get query

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()
                    pSICode = DR("SICode")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        Return pSICode

    End Function

#End Region

#Region "Report"

    Protected Sub btn01Report_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'variable
        Dim ID As String
        'variable

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].si_code [SICode] ")
        Query.Append("from ")
        Query.Append("  ogm_si_hdr [A] ")
        Query.Append("where ")
        Query.Append("  [A].SINo = '" & hfSINo.Value & "' ")
        'get query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    ID = DR("SICode")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/"))
        End If
        'create new folder

        'remove file within the folder
        Dim RptFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/"))
        Try
            Dim file As FileInfo
            For Each file In RptFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file within the folder

        'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/"))
        End If
        'create new folder

        'remove file within the folder
        Dim PayslipPDFFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/"))
        Try
            Dim file As FileInfo
            For Each file In PayslipPDFFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file within the folder

        'copy template report
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPTMIS001.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPTMIS001.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPTMIS001.rpt"))
        Dim logoninfo As TableLogOnInfo
        For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
            logoninfo = tbcurrent.LogOnInfo()
            logoninfo.ConnectionInfo.ServerName = DataSource
            logoninfo.ConnectionInfo.DatabaseName = catalog
            logoninfo.ConnectionInfo.UserID = UserID
            logoninfo.ConnectionInfo.Password = Password
            tbcurrent.ApplyLogOnInfo(logoninfo)
        Next
        RptDoc.SetDatabaseLogon(UserID, Password, DataSource, catalog)
        RptDoc.SetParameterValue("@pSICode", ID)
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPTMIS001.pdf"), Buf)
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

        'view report
        RptDoc.Dispose()
        RptDoc.Close()
        Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTMIS001.pdf")
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
        'view report

    End Sub
#End Region

End Class