Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class MNU000009
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
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "FRM010000")
        'active account / menu

        'load page
        If IsPostBack = False Then
            bindBreadcrumbbar()
            bindCounter()
            bindTask()
        ElseIf IsPostBack = True Then
            RenderDatatable()
            If ddlSTSStatus.SelectedValue = "Clarify" Then divSTSClarifyTo.Style.Add("display", "")
        End If
        'load page
    End Sub

#End Region

#Region "General"

    Function bindBreadcrumbbar()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And status Not In ('Accepted','Declined','Cancelled')),0) [FM] ")
        'get total task

        'create variable
        Dim Total As String = "0"
        'create variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Total = DR.GetInt32(0)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        spnTotal.InnerText = "You have " & Total & " tasks"
        upnlBreadcrumbbar.Update()
        'display data

    End Function

    Function bindCounter()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Endorsed By','Approved By') and status not in ('Accepted','Declined','Cancelled')),0) ")
        Query.Append("	,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Implementer') and status not in ('Accepted','Declined','Cancelled')),0) ")
        Query.Append("	,isnull((select count(1) from oop_form_hdr where EndorsedTo = '" & CIIS_EmpCode & "' and status not in ('Accepted','Declined','Cancelled')),0) ")
        Query.Append("	,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Clarification') and status not in ('Accepted','Declined','Cancelled')),0) ")
        Query.Append("	,isnull((select count(1) from oop_form_dtl_monitor left join oop_form_hdr on oop_form_dtl_monitor.f_code = oop_form_hdr.f_code where oop_form_dtl_monitor.monitored_by = '" & CIIS_EmpCode & "' and oop_form_hdr.status not in ('Accepted','Declined','Cancelled')),0) ")
        Query.Append("	,isnull((select count(1) from oop_form_hdr where created_by = '" & CIIS_EmpCode & "'),0) ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblCntApproval.Text = DR.GetInt32(0)
                    lblCntTask.Text = DR.GetInt32(1)
                    lblCntEndorsed.Text = DR.GetInt32(2)
                    lblCntClarification.Text = DR.GetInt32(3)
                    lblCntSubscriber.Text = DR.GetInt32(4)
                    lblCntRequest.Text = DR.GetInt32(5)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        If lblCntApproval.Text = "0" Then lblCntApproval.Visible = False
        If lblCntTask.Text = "0" Then lblCntTask.Visible = False
        If lblCntEndorsed.Text = "0" Then lblCntEndorsed.Visible = False
        If lblCntClarification.Text = "0" Then lblCntClarification.Visible = False
        If lblCntSubscriber.Text = "0" Then lblCntSubscriber.Visible = False
        If lblCntRequest.Text = "0" Then lblCntRequest.Visible = False

        'display data
        upnlContent.Update()
        'display data

    End Function

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Subscribed" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & hfID.Value & "') in ('Accepted','Cancelled','Declined') ")
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

        If Group_ = "Status" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & hfID.Value & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by,approver) then 1 end) from oop_form_hdr where f_code = '" & hfID.Value & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & Value & "' in ('Approved','Clarify') and (select (case when '" + CIIS_EmpCode + "' not in (approver) then 1 end) from oop_form_hdr where f_code = '" & hfID.Value & "') = 1 ")
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

        If Group_ = "Files" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & hfID.Value & "') in ('Accepted','Cancelled','Declined') ")
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

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function RenderDatatable()
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTask.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTask.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTask.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTask.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvSUBSelected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvSUBSelected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvSUBSelected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvSUBSelected.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvSTSSelected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvSTSSelected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvSTSSelected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvSTSSelected.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvUPLSelected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvUPLSelected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvUPLSelected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvUPLSelected.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvNTESelected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvNTESelected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvNTESelected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvNTESelected.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
    End Function

#End Region

#Region "Overview"

    Function bindTask()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[wRPT] ")
        Query.Append("   ,[RPT] ")
        Query.Append("   ,[RefNo] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,isnull([C].wRPT,0) [wRPT] ")
        Query.Append("      ,(case when [C].FormCode = 'FRM000015' and [A].remarks = 'Cash Liquidation' then '2' else '1' end) [RPT] ")
        Query.Append("      ,(case when [C].FormCode = 'FRM000015' and [A].remarks = 'Cash Liquidation' then (select top 1 [D].RefNo from Form_CAHdr [D] where [D].CVCode = [A].tbl_code) else [A].f_code end) [RefNo] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].approver_type in ('Clarification') ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("lbtnSUBS"))
        dtable.Columns.Add(New DataColumn("DisplayRPT"))
        dtable.Columns.Add(New DataColumn("lbtnRPT"))
        dtable.Columns.Add(New DataColumn("lbtnSTSSUpd"))
        dtable.Columns.Add(New DataColumn("lbtnUPLSUpd"))
        dtable.Columns.Add(New DataColumn("lbtnNTESUpd"))
        'Create datatable and columns

        Dim RowIdx = 0

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Bullet As String = DR("Bullet")
                    Dim Link As String = DR("Link")
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim lbtnSUBS As String = "lbtnSUBS('" & DR("ID") & "')"
                    Dim DisplayRPT As String = IIf(DR("wRPT") = 1, "", "style='display:none'")
                    Dim lbtnRPT As String = "lbtnRPT('" & DR("FormCode") & "','" & DR("RefNo") & "','" & DR("RPT") & "')"
                    Dim lbtnSTSSUpd As String = "lbtnSTSSUpd('" & DR("ID") & "')"
                    Dim lbtnUPLSUpd As String = "lbtnUPLSUpd('" & DR("ID") & "')"
                    Dim lbtnNTESUpd As String = "lbtnNTESUpd('" & DR("ID") & "')"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, Link, Icon, Title, ID, Name, Date_, lbtnSUBS, DisplayRPT, lbtnRPT, lbtnSTSSUpd, lbtnUPLSUpd, lbtnNTESUpd}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    RowIdx = RowIdx + 1

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvTask.DataSource = dtable
        gvTask.DataBind()
        RenderDatatable()
        'bind datatable 

        'display
        upnlContent.Update()
        'display

    End Function

#End Region

#Region "Subscription"

    Protected Sub lbtnSUBS_Click(ByVal sender As Object, ByVal e As EventArgs)

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code = '" & hfID.Value & "' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    hfID.Value = DR("ID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Subscribed", "Save", "")
                    'create variable

                    'validate record
                    If Msg <> "" Then
                        Alert("error", Msg)
                        Exit Sub
                    End If
                    'validate record

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvSUBSelected.DataSource = dtable
        gvSUBSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlSUB.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlSUB').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnSUBM_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTask.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")

        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    hfID.Value = DR("ID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Subscribed", "Save", "")
                    'create variable

                    'validate record
                    If Msg <> "" Then
                        Alert("error", Msg)
                        Exit Sub
                    End If
                    'validate record

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvSUBSelected.DataSource = dtable
        gvSUBSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlSUB.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlSUB').modal('show');</script>", False)
        'modal

    End Sub

    Private Sub lbtnSUBOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSUBOk.Click

        'create variable
        Dim RowIdx = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gvSUBSelected.Rows.Count
            Dim lblID As Label = gvSUBSelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'create variable
            Dim Msg As String = Validate("Subscribed", "Save", "")
            'create variable

            'validate record
            If Msg <> "" Then
                Alert("error", Msg)
                Exit Sub
            End If
            'validate record

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'set value
        RowIdx = 0
        'set value

        'get selected rows
        Do Until RowIdx = gvSUBSelected.Rows.Count
            Dim lblFormCode As Label = gvSUBSelected.Rows(RowIdx).FindControl("lblFormCode")
            hfFormCode.Value = lblFormCode.Text
            Dim lblID As Label = gvSUBSelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_Monitor"
            SqlCmd.Parameters.AddWithValue("@pFormCode", hfFormCode.Value)
            SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
            SqlCmd.Parameters.AddWithValue("@pMonitorBy", CIIS_EmpCode)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'success message
        Alert("success", "Successfully subscribe.")
        'success message

        'display item
        bindBreadcrumbbar()
        bindCounter()
        bindTask()
        'display item

        'update panel 
        mdlSUB.Update()
        'update panel 

    End Sub

#End Region

#Region "Print"

    Protected Sub lbtnRPT_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/"))
        End If
        'create new folder

        'remove file within the folder
        Dim RptFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/"))
        Try
            Dim file As FileInfo
            For Each file In RptFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file within the folder

        'Work Order
        If hfFormCode.Value = "FRM000001" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000001.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000001.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000001.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@wo_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000001.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000001.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Work Order

        'Purchase Request
        If hfFormCode.Value = "FRM000010" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000011.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000011.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000011.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "PRPrintoutwNote.rpt")
            RptDoc.SetParameterValue("@pFormNo", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000011.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000011.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Purchase Request

        'Service Request Form
        If hfFormCode.Value = "FRM000012" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000002.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000002.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000002.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000002.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000002.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Service Request Form

        'Occupancy Clearance
        If hfFormCode.Value = "FRM000013" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000009.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000009.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000009.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000009.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000009.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Occupancy Clearance

        'Cash Advance - Cash Advance
        If hfFormCode.Value = "FRM000015" And hrRPT.Value = "1" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000004.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000004.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000004.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAAPVPrintout.rpt")
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAPrintout.rpt")
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000004.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000004.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Cash Advance - Cash Advance

        'Cash Advance - Cash Liquidation
        If hfFormCode.Value = "FRM000015" And hrRPT.Value = "2" Then
            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000005.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000005.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000005.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAPrintout.rpt")
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAPrintoutwNote.rpt")
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000005.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000005.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

            'view file
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
            'view file
        End If
        'Cash Advance - Cash Liquidation

        'Petty Cash
        If hfFormCode.Value = "FRM000016" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000007.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000007.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000007.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFormNo", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000007.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000007.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Petty Cash

        'Payment Request
        If hfFormCode.Value = "FRM000017" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000008.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000008.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000008.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFormNo", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000008.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000008.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Payment Request

        'Capital Expenditure Request
        If hfFormCode.Value = "FRM000018" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000010.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000010.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000010.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000010.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000010.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Capital Expenditure Request

        'Construction Clearance
        If hfFormCode.Value = "FRM000022" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000012.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000012.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000012.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000012.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000012.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Construction Clearance

        'Electrical Service Connection
        If hfFormCode.Value = "FRM000023" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000013.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000013.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000013.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000013.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000013.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Electrical Service Connection

        'Water Service Connection
        If hfFormCode.Value = "FRM000025" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000003.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000003.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000003.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000003.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000003.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Water Service Connection

        'TCT Clearance
        If hfFormCode.Value = "FRM000027" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000014.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000014.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000014.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000014.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000014.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'TCT Clearance

        'Transfer of Title Routing Slip
        If hfFormCode.Value = "FRM000032" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000006.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000006.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
           RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000006.rpt"))
            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000006.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000006.pdf"
                Response.Cookies.Add(CIIS_UserInfo)
                'view file
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
                'view file
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Transfer of Title Routing Slip

    End Sub

#End Region

#Region "Status"

    Function bindUser()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select a user' [Text] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   emp_no [Value] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Text] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlSTSClarifyTo.DataSource = DT
        ddlSTSClarifyTo.DataValueField = "Value"
        ddlSTSClarifyTo.DataTextField = "Text"
        ddlSTSClarifyTo.DataBind()
        'fill data

    End Function

    Protected Sub lbtnSTSSUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code = '" & hfID.Value & "' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    hfID.Value = DR("ID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Status", "Save", "")
                    'create variable

                    'validate record
                    If Msg <> "" Then
                        Alert("error", Msg)
                        Exit Sub
                    End If
                    'validate record

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvSTSSelected.DataSource = dtable
        gvSTSSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'set value
        ddlSTSStatus.SelectedValue = ""
        divSTSClarifyTo.Style.Add("display", "none")
        bindUser()
        ddlSTSClarifyTo.SelectedValue = ""
        tbxSTSNote.Text = ""
        hfMention.Value = ""
        'set value

        'update
        mdlSTS.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlSTS').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnSTSMUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTask.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    hfID.Value = DR("ID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Status", "Save", "")
                    'create variable

                    'validate record
                    If Msg <> "" Then
                        Alert("error", Msg)
                        Exit Sub
                    End If
                    'validate record

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvSTSSelected.DataSource = dtable
        gvSTSSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'set value
        ddlSTSStatus.SelectedValue = ""
        divSTSClarifyTo.Style.Add("display", "none")
        bindUser()
        ddlSTSClarifyTo.SelectedValue = ""
        tbxSTSNote.Text = ""
        hfMention.Value = ""
        'set value

        'update
        mdlSTS.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlSTS').modal('show');</script>", False)
        'modal

    End Sub

    Private Sub lbtnSTSUpdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSTSUpdOk.Click

        'create variable
        Dim RowIdx = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gvSTSSelected.Rows.Count
            Dim lblID As Label = gvSTSSelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'create variable
            Dim Msg As String = Validate("Status", "Save", ddlSTSStatus.SelectedValue)
            'create variable

            'validate record
            If Msg <> "" Then
                Alert("error", Msg)
                Exit Sub
            ElseIf ddlSTSStatus.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
                Exit Sub
            ElseIf ddlSTSStatus.SelectedValue = "Clarify" And ddlSTSClarifyTo.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
                Exit Sub
            End If
            'validate record

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'set value
        RowIdx = 0
        'set value

        'get selected rows
        Do Until RowIdx = gvSTSSelected.Rows.Count
            Dim lblFormCode As Label = gvSTSSelected.Rows(RowIdx).FindControl("lblFormCode")
            hfFormCode.Value = lblFormCode.Text
            Dim lblID As Label = gvSTSSelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_FRM_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", hfFormCode.Value)
            SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
            SqlCmd.Parameters.AddWithValue("@pStatus", ddlSTSStatus.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", ddlSTSClarifyTo.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbxSTSNote.Text)
            SqlCmd.Parameters.AddWithValue("@pMention", hfMention.Value)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'success message
        Alert("success", "Status successfully saved.")
        'success message

        'display item
        bindBreadcrumbbar()
        bindCounter()
        bindTask()
        'display item

        'update panel 
        mdlSTS.Update()
        'update panel 

    End Sub

#End Region

#Region "Files"

    Protected Sub lbtnUPLSUpd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnUPLSUpd.Click

        'set value
        lblUPLIDsrs.Value = ""
        'set value

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code = '" & hfID.Value & "' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    hfID.Value = DR("ID")
                    lblUPLIDsrs.Value = IIf(lblUPLIDsrs.Value = "", DR("FormCode") & "/" & DR("ID"), lblUPLIDsrs.Value & ";" & DR("FormCode") & "/" & DR("ID"))
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Files", "Save", "")
                    'create variable

                    'validate record
                    If Msg <> "" Then
                        Alert("error", Msg)
                        Exit Sub
                    End If
                    'validate record

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvUPLSelected.DataSource = dtable
        gvUPLSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlUPL.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUPL').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnUPLMUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'set value
        lblUPLIDsrs.Value = ""
        'set value

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTask.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    hfID.Value = DR("ID")
                    lblUPLIDsrs.Value = IIf(lblUPLIDsrs.Value = "", DR("FormCode") & "/" & DR("ID"), lblUPLIDsrs.Value & ";" & DR("FormCode") & "/" & DR("ID"))
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Files", "Save", "")
                    'create variable

                    'validate record
                    If Msg <> "" Then
                        Alert("error", Msg)
                        Exit Sub
                    End If
                    'validate record

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvUPLSelected.DataSource = dtable
        gvUPLSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlUPL.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUPL').modal('show');</script>", False)
        'modal

    End Sub

#End Region

#Region "Notes"

    Protected Sub lbtnNTESUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code = '" & hfID.Value & "' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvNTESelected.DataSource = dtable
        gvNTESelected.DataBind()
        RenderDatatable()
        'bind datatable

        'set value
        tbxNTENote.Text = ""
        hfMention.Value = ""
        'set value

        'update
        mdlNTE.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlNTE').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnNTEMUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTask.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [A].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("FormCode"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim FormCode As String = DR("FormCode")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, FormCode, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvNTESelected.DataSource = dtable
        gvNTESelected.DataBind()
        RenderDatatable()
        'bind datatable

        'set value
        tbxNTENote.Text = ""
        hfMention.Value = ""
        'set value

        'update
        mdlNTE.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlNTE').modal('show');</script>", False)
        'modal

    End Sub

    Private Sub lbtnNTEUpdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNTEUpdOk.Click

        'create variable
        Dim RowIdx = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gvNTESelected.Rows.Count
            Dim lblID As Label = gvNTESelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'validate record
            If tbxNTENote.Text = "" Then
                Alert("error", "Some field(s) are missing!")
                Exit Sub
            End If
            'validate record

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'set value
        RowIdx = 0
        'set value

        'get selected rows
        Do Until RowIdx = gvNTESelected.Rows.Count
            Dim lblFormCode As Label = gvNTESelected.Rows(RowIdx).FindControl("lblFormCode")
            hfFormCode.Value = lblFormCode.Text
            Dim lblID As Label = gvNTESelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_Remarks"
            SqlCmd.Parameters.AddWithValue("@pFormCode", hfFormCode.Value)
            SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
            SqlCmd.Parameters.AddWithValue("@pSubID", "")
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbxNTENote.Text)
            SqlCmd.Parameters.AddWithValue("@pMention", hfMention.Value)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'success message
        Alert("success", "Status successfully saved.")
        'success message

        'update panel 
        mdlNTE.Update()
        'update panel 

    End Sub

#End Region

End Class