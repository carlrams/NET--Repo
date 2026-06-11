Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class MNU000015
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
        Master.setActiveMenu("APP", "001002")
        'active account / menu

        'Record
        ltrlFormCode.Text = "WRK010100"
        'Record

        'load page
        If IsPostBack = False Then
            bindBreadcrumbbar()
            bindCounter()
            bindTask()
        ElseIf IsPostBack = True Then
            RenderDatatable()
        End If
        'load page
    End Sub

#End Region

#Region "General"

    Function bindBreadcrumbbar()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' and status in ('Assigned','Clarify','Completed','Accepted')),0)  [Total] ")
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
                    Total = DR("Total")
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
        Query.Append("	isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' and status in ('Accepted','Assigned')),0) [Task] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' and status in ('Completed')),0) [Completed] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' and status in ('Clarify')),0) [Clarify] ")
        Query.Append("	,isnull((select count(1) from oop_wo_dtl_monitor [A] left join oop_wo_hdr [B] on [A].wo_code = [B].wo_code where [A].monitored_by = '" & CIIS_EmpCode & "' and [B].status in ('Accepted','Assigned','Completed','Clarify')),0) [Subscription] ")
        Query.Append("	,isnull((select count(1) from oop_wo_hdr where reported_by = '" & CIIS_EmpCode & "'),0) [MyRequest] ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblCntTask.Text = DR("Task")
                    lblCntCompleted.Text = DR("Completed")
                    lblCntClarification.Text = DR("Clarify")
                    lblCntSubscriber.Text = DR("Subscription")
                    lblCntRequest.Text = DR("MyRequest")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        If lblCntTask.Text = "0" Then lblCntTask.Visible = False
        If lblCntCompleted.Text = "0" Then lblCntCompleted.Visible = False
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
            If Type = "Delete" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & hfID.Value & "') in ('Closed','Cancelled') ")
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
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & hfID.Value & "') in ('Closed','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & Value & "' in ('Closed') and (select (case when '" + CIIS_EmpCode + "' not in (created_by) then 1 end) from oop_wo_hdr where wo_code = '" & hfID.Value & "') = 1 ")
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
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & hfID.Value & "') in ('Closed','Cancelled') ")
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
        If gvDELSelected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvDELSelected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvDELSelected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvDELSelected.FooterRow.TableSection = TableRowSection.TableFooter
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
        Query.Append("	 (case when [A].priority = 'Low' then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [A].priority = 'Normal' then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].priority = 'High' then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("   ,'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,'assets/media/svg/apps/FRM000001.svg' [Icon] ")
        Query.Append("   ,[A].summary [Title] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,[A].created_date [Date] ")
        Query.Append("from ")
        Query.Append("   oop_wo_dtl_monitor [C] ")
        Query.Append("       left join oop_wo_hdr [A] on [A].wo_code = [C].wo_code ")
        Query.Append("   left join employee [B] on [A].assigned_to = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [C].monitored_by = '" & CIIS_EmpCode & "'  ")
        Query.Append("   and [A].status in ('Accepted','Assigned','Completed','Clarify') ")
        Query.Append("order by ")
        Query.Append("   [A].created_date desc ")
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
        dtable.Columns.Add(New DataColumn("lbtnDELS"))
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
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    Dim lbtnDELS As String = "lbtnDELS('" & DR("ID") & "')"
                    Dim lbtnRPT As String = "lbtnRPT('" & DR("ID") & "')"
                    Dim lbtnSTSSUpd As String = "lbtnSTSSUpd('" & DR("ID") & "')"
                    Dim lbtnUPLSUpd As String = "lbtnUPLSUpd('" & DR("ID") & "')"
                    Dim lbtnNTESUpd As String = "lbtnNTESUpd('" & DR("ID") & "')"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, Link, Icon, Title, ID, Name, Date_, lbtnDELS, lbtnRPT, lbtnSTSSUpd, lbtnUPLSUpd, lbtnNTESUpd}
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

    Protected Sub lbtnDELS_Click(ByVal sender As Object, ByVal e As EventArgs)

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [A].priority = 'Low' then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [A].priority = 'Normal' then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].priority = 'High' then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("   ,'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,'assets/media/svg/apps/FRM000001.svg' [Icon] ")
        Query.Append("   ,[A].summary [Title] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,[A].created_date [Date] ")
        Query.Append("from ")
        Query.Append("   oop_wo_dtl_monitor [C] ")
        Query.Append("       left join oop_wo_hdr [A] on [A].wo_code = [C].wo_code ")
        Query.Append("   left join employee [B] on [A].assigned_to = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].wo_code = '" & hfID.Value & "' ")
        Query.Append("   and [C].monitored_by = '" & CIIS_EmpCode & "' ")
        Query.Append("order by ")
        Query.Append("   [A].created_date desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
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
                    Dim Msg As String = Validate("Subscribed", "Delete", "")
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
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvDELSelected.DataSource = dtable
        gvDELSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlDEL.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDEL').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnDELM_Click(ByVal sender As Object, ByVal e As EventArgs)

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
        Query.Append("	 (case when [A].priority = 'Low' then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [A].priority = 'Normal' then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].priority = 'High' then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("   ,'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,'assets/media/svg/apps/FRM000001.svg' [Icon] ")
        Query.Append("   ,[A].summary [Title] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,[A].created_date [Date] ")
        Query.Append("from ")
        Query.Append("   oop_wo_dtl_monitor [C] ")
        Query.Append("   left join oop_wo_hdr [A] on [A].wo_code = [C].wo_code ")
        Query.Append("   left join employee [B] on [A].assigned_to = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].wo_code in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [C].monitored_by = '" & CIIS_EmpCode & "' ")
        Query.Append("order by ")
        Query.Append("   [A].created_date desc ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
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
                    Dim Msg As String = Validate("Subscribed", "Delete", "")
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
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvDELSelected.DataSource = dtable
        gvDELSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlDEL.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDEL').modal('show');</script>", False)
        'modal

    End Sub

    Private Sub lbtnDELOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnDELOk.Click

        'create variable
        Dim RowIdx = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gvDELSelected.Rows.Count
            Dim lblID As Label = gvDELSelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'create variable
            Dim Msg As String = Validate("Subscribed", "Delete", "")
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
        Do Until RowIdx = gvDELSelected.Rows.Count
            Dim lblID As Label = gvDELSelected.Rows(RowIdx).FindControl("lblID")
            hfID.Value = lblID.Text

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Del_WRK_Monitor"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
            SqlCmd.Parameters.AddWithValue("@pMonitoredBy", CIIS_EmpCode)
            SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
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
        Alert("success", "Subscription successfully removed.")
        'success message

        'display item
        bindBreadcrumbbar()
        bindCounter()
        bindTask()
        'display item

        'update panel 
        mdlDEL.Update()
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

        'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/"))
        End If
        'create new folder

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000001.pdf"), Buf)
            CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & hfID.Value & "/RPT000001.pdf"
            Response.Cookies.Add(CIIS_UserInfo)
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

        'view file
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
        'view file

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
        Query.Append("	 (case when [A].priority = 'Low' then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [A].priority = 'Normal' then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].priority = 'High' then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("   ,'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,'assets/media/svg/apps/FRM000001.svg' [Icon] ")
        Query.Append("   ,[A].summary [Title] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,[A].created_date [Date] ")
        Query.Append("from ")
        Query.Append("   oop_wo_hdr [A] ")
        Query.Append("   left join employee [B] on [A].assigned_to = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].wo_code = '" & hfID.Value & "'  ")
        Query.Append("   and [A].assigned_to = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
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
                    lblUPLIDsrs.Value = DR("ID")
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
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, Name, Date_}
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
        Query.Append("	 (case when [A].priority = 'Low' then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [A].priority = 'Normal' then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].priority = 'High' then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("   ,'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,'assets/media/svg/apps/FRM000001.svg' [Icon] ")
        Query.Append("   ,[A].summary [Title] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,[A].created_date [Date] ")
        Query.Append("from ")
        Query.Append("   oop_wo_hdr [A] ")
        Query.Append("   left join employee [B] on [A].assigned_to = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].wo_code in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [A].assigned_to = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
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
                    lblUPLIDsrs.Value = IIf(lblUPLIDsrs.Value = "", DR("ID"), lblUPLIDsrs.Value & ";" & DR("ID"))
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
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, Name, Date_}
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
        Query.Append("	 (case when [A].priority = 'Low' then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [A].priority = 'Normal' then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].priority = 'High' then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("   ,'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,'assets/media/svg/apps/FRM000001.svg' [Icon] ")
        Query.Append("   ,[A].summary [Title] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,[A].created_date [Date] ")
        Query.Append("from ")
        Query.Append("   oop_wo_hdr [A] ")
        Query.Append("   left join employee [B] on [A].assigned_to = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].wo_code = '" & hfID.Value & "'  ")
        Query.Append("   and [A].assigned_to = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
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
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, Name, Date_}
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
        Query.Append("	 (case when [A].priority = 'Low' then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [A].priority = 'Normal' then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].priority = 'High' then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("   ,'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,'assets/media/svg/apps/FRM000001.svg' [Icon] ")
        Query.Append("   ,[A].summary [Title] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,[A].created_date [Date] ")
        Query.Append("from ")
        Query.Append("   oop_wo_hdr [A] ")
        Query.Append("   left join employee [B] on [A].assigned_to = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].wo_code in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [A].assigned_to = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
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
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, Name, Date_}
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
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
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