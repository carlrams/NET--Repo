Imports System.Data.SqlClient

Public Class ENG010700
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

    Dim AssignToDT As New DataTable

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
        Master.setActiveMenu("APP", "ENG010700")
        'active account / menu

        'Record
        ltrlFormCode.Text = "ENG010701"
        'Record

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
            'set current view
            hfView.Value = "On-Going"
            'set current view

            'load
            bindBreadcrumbbar()
            bindCounter()
            bindTask(hfView.Value, CIIS_EmpCode, "", "", "")
            bindFLTRAssignTo()
            bindFLTContractor()
            'load
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
        Query.Append("	isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [OnGoing] ")
        Query.Append("	,isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('On-Hold') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [OnHold] ")
        Query.Append("	,isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('Complete') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [Complete] ")
        Query.Append("	,isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [Clarify] ")
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
                    Total = DR("OnGoing") + DR("OnHold") + DR("Complete") + DR("Clarify")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        spnTotal.InnerText = "You have " & Total & " task"
        upnlBreadcrumbbar.Update()
        'display data

    End Function

    Function bindCounter()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [OnGoing] ")
        Query.Append("	,isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('On-Hold') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [OnHold] ")
        Query.Append("	,isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('Complete') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [Complete] ")
        Query.Append("	,isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) [Clarify] ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblCntOnGoing.Text = DR("OnGoing")
                    lblCntOnHold.Text = DR("OnHold")
                    lblCntCompleted.Text = DR("Complete")
                    lblCntClarify.Text = DR("Clarify")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        If lblCntOnGoing.Text = "0" Then lblCntOnGoing.Visible = False
        If lblCntOnHold.Text = "0" Then lblCntOnHold.Visible = False
        If lblCntCompleted.Text = "0" Then lblCntCompleted.Visible = False
        If lblCntClarify.Text = "0" Then lblCntClarify.Visible = False

        'display data
        upnlContent.Update()
        'display data

    End Function

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Access" Then

            'get total task
            If Type = "View" Then
                Query.Append("if '" & ltrlFormCode.Text & "' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = '" & ltrlFormCode.Text & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if '" & ltrlFormCode.Text & "' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = '" & ltrlFormCode.Text & "' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if '" & ltrlFormCode.Text & "' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = '" & ltrlFormCode.Text & "' and Save_ = 1) ")
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
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none",
        "<script>
           setTimeout(function() {
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
                    " & IIf(Alert_ = "success", "$('#ContentPlaceHolder1_mdlCS').modal('hide');", "console.log('Error');") & "
              }
           });
        }, 200);
    </script>", False)
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
        If gvCS.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvCS.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvCS.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvCS.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvUP.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvUP.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvUP.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvUP.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

#Region "Overview"

    Function bindTask(pStatus, pAssignTo, pSubd, pPhase, pContractor)

        'processing time
        System.Threading.Thread.Sleep(2000)
        'processing time

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   'ENG010701-' + [B].f_code [Link] ")
        Query.Append("   ,[A].Category + ' / ' + [A].Project + ' / ' + [A].Remarks [Title] ")
        Query.Append("   ,[B].f_code [ID] ")
        Query.Append("   ,isnull([C].vendor,'-') [Name] ")
        Query.Append("   ,isnull([A].DateAwarded,getdate()) [Date] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) [AssignTo] ")
        Query.Append("   ,(case when [A].POCStatus = '' then 'On-Going' else [A].POCStatus end) [Status] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("   left join employee [D] on [A].POCAssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        'filter
        If pStatus = "On-Going" Then Query.Append("   and [A].POCStatus in ('','Assign','On-Going') ")
        If pStatus = "On-Hold" Then Query.Append("   and [A].POCStatus in ('On-Hold') ")
        If pStatus = "Complete" Then Query.Append("   and [A].POCStatus in ('Complete') ")
        If pStatus = "Clarify" Then Query.Append("   and [A].POCStatus in ('Clarify') ")
        If pStatus = "Close" Then Query.Append("   and [A].POCStatus in ('Close') ")
        If pAssignTo <> "" Then Query.Append("   and [A].POCAssignTo = '" & pAssignTo & "' ")
        If pSubd <> "" Then Query.Append("   and [A].Project like '%" & pSubd & "%' ")
        If pPhase <> "" Then Query.Append("   and [A].Project like '%" & pSubd & " " & pPhase & "%' ")
        If pContractor <> "" Then Query.Append("   and [B].Contractor = '" & pContractor & "' ")
        'filter
        Query.Append("order by ")
        Query.Append("   [A].Project ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("cbxClass"))
        dtable.Columns.Add(New DataColumn("cbxDisable"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("AssignTo"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Progress"))
        dtable.Columns.Add(New DataColumn("CS_Single"))
        dtable.Columns.Add(New DataColumn("UP_Single"))
        dtable.Columns.Add(New DataColumn("UF_Single"))
        dtable.Columns.Add(New DataColumn("AN_Single"))
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
                    Dim Link As String = DR("Link")
                    Dim cbxClass As String = "form-check-input checkBoxClass" 'IIf(CDbl(DR("Balance")) > 0, "form-check-input checkBoxClass", "form-check-input")
                    Dim cbxDisable As String = "false" 'IIf(CDbl(DR("Balance")) > 0, "false", "true")
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim AssignTo As String = DR("AssignTo")
                    Dim Status As String = DR("Status")
                    Dim Progress As String = "<div class='d-flex flex-column w-100'><div class='d-flex flex-stack mb-2'><span class='text-muted fs-8 fw-bold'>" & DR("POCRate") & "% <i class='las la-calendar'></i>" & DR("POCDate") & "</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(DR("POCRate")) >= 66.66, "bg-sucess", IIf(CDbl(DR("POCRate")) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & DR("POCRate") & "%' aria-valuenow='" & DR("POCRate") & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>"
                    Dim CS_Single As String = "CS_Single('" & DR("ID") & "')"
                    Dim UP_Single As String = "UP_Single('" & DR("ID") & "')"
                    Dim UF_Single As String = "UF_Single('" & DR("ID") & "')"
                    Dim AN_Single As String = "AN_Single('" & DR("ID") & "')"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Link, cbxClass, cbxDisable, Title, ID, Name, Date_, AssignTo, Status, Progress, CS_Single, UP_Single, UF_Single, AN_Single}
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

#Region "Tab Content"

    Protected Sub lbtnView_Click(ByVal sender As Object, e As EventArgs)
        bindTask(hfView.Value, ddlFLTRAssignTo.SelectedValue, tbxFLTRSubdivision.Text, tbxFLTRPhase.Text, ddlFLTRContractor.SelectedValue)
    End Sub

#End Region

#Region "Refresh"

    Protected Sub lbtnRFH_Click(ByVal sender As Object, e As EventArgs)
        bindCounter()
        bindTask(hfView.Value, ddlFLTRAssignTo.SelectedValue, tbxFLTRSubdivision.Text, tbxFLTRPhase.Text, ddlFLTRContractor.SelectedValue)
    End Sub

#End Region

#Region "Filter"

    Function bindFLTRAssignTo()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Assign to' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee [A] ")
        Query.Append("where ")
        Query.Append("   [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("   and [A].lock = 1 ")
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
        ddlFLTRAssignTo.DataSource = DT
        ddlFLTRAssignTo.DataValueField = "Code"
        ddlFLTRAssignTo.DataTextField = "Name"
        ddlFLTRAssignTo.DataBind()
        'fill data

        'default value
        ddlFLTRAssignTo.SelectedValue = CIIS_EmpCode
        'default value

    End Function

    Function bindFLTContractor()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Contractor' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].v_code [Code] ")
        Query.Append("   ,[A].vendor [Name] ")
        Query.Append("   ,[A].vendor [Order] ")
        Query.Append("from ")
        Query.Append("   ogm_vendor [A] ")
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
        ddlFLTRContractor.DataSource = DT
        ddlFLTRContractor.DataValueField = "Code"
        ddlFLTRContractor.DataTextField = "Name"
        ddlFLTRContractor.DataBind()
        'fill data

    End Function

    Protected Sub lbtnFLT_Click(ByVal sender As Object, e As EventArgs)
        bindTask(hfView.Value, ddlFLTRAssignTo.SelectedValue, tbxFLTRSubdivision.Text, tbxFLTRPhase.Text, ddlFLTRContractor.SelectedValue)
    End Sub

#End Region

#Region "Change Status"

    Function bindCSAssignTo()
        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a user' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee [A] ")
        Query.Append("where ")
        Query.Append("   [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("   and [A].lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        SDA.Fill(AssignToDT)
        'execute query
    End Function

    Protected Sub gvCS_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gvCS.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'fill data
            Dim ddlCSAssignTo As DropDownList = DirectCast(e.Row.FindControl("ddlCSAssignTo"), DropDownList)
            ddlCSAssignTo.DataSource = AssignToDT
            ddlCSAssignTo.DataValueField = "Code"
            ddlCSAssignTo.DataTextField = "Name"
            ddlCSAssignTo.DataBind()
            Dim lblID As Label = DirectCast(e.Row.FindControl("lblID"), Label)
            ddlCSAssignTo.Attributes.Add("prm_cs_assignto", lblID.Text)
            'fill data
        End If
    End Sub

    Protected Sub lbtnCS_Single_Click(ByVal sender As Object, ByVal e As EventArgs)

        'populate ddl
        bindCSAssignTo()
        'populate ddl

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].Category + ' / ' + [A].Category + ' / ' + [A].Project + ' / ' + [A].Remarks [Title] ")
        Query.Append("   ,[B].f_code [ID] ")
        Query.Append("   ,isnull([C].vendor,'-') [Name] ")
        Query.Append("   ,isnull([A].DateAwarded,getdate()) [Date] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) [AssignTo] ")
        Query.Append("   ,(case when [A].POCStatus = '' then 'On-Going' else [A].POCStatus end) [Status] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("   left join employee [D] on [A].POCAssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        Query.Append("   and [A].POCAssignTo = '" & CIIS_EmpCode & "'")
        Query.Append("   and [A].POCStatus not in ('Close') ")
        Query.Append("   and [B].f_code = '" & hfID.Value & "' ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("AssignTo"))
        dtable.Columns.Add(New DataColumn("Status"))
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

                    'create varialble
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim AssignTo As String = DR("AssignTo")
                    Dim Status As String = DR("Status")
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Title, ID, Name, Date_, AssignTo, Status}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvCS.DataSource = dtable
        gvCS.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlCS.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlCS').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnCS_Selected_Click(ByVal sender As Object, ByVal e As EventArgs)

        'populate ddl
        bindCSAssignTo()
        'populate ddl

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

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

        'validate
        If IDSrs = "" Then
            Alert("error", "No record selected.")
            Exit Sub
        End If
        'validate

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].Category + ' / ' + [A].Project + ' / ' + [A].Remarks [Title] ")
        Query.Append("   ,[B].f_code [ID] ")
        Query.Append("   ,isnull([C].vendor,'-') [Name] ")
        Query.Append("   ,isnull([A].DateAwarded,getdate()) [Date] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) [AssignTo] ")
        Query.Append("   ,(case when [A].POCStatus = '' then 'On-Going' else [A].POCStatus end) [Status] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("   left join employee [D] on [A].POCAssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        Query.Append("   and [A].POCAssignTo = '" & CIIS_EmpCode & "'")
        Query.Append("   and [A].POCStatus not in ('Close') ")
        Query.Append("   and [B].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("AssignTo"))
        dtable.Columns.Add(New DataColumn("Status"))
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

                    'create varialble
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim AssignTo As String = DR("AssignTo")
                    Dim Status As String = DR("Status")
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Title, ID, Name, Date_, AssignTo, Status}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvCS.DataSource = dtable
        gvCS.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlCS.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlCS').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnCS_Update_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

        'update progress
        For Each Row As GridViewRow In gvCS.Rows
            Dim ID As Label = gvCS.Rows(Row.RowIndex).FindControl("lblID")
            If ID.Text = hfID.Value Then
                Dim ddlCSStatus As DropDownList = gvCS.Rows(Row.RowIndex).FindControl("ddlCSStatus")
                Dim ddlCSAssignTo As DropDownList = gvCS.Rows(Row.RowIndex).FindControl("ddlCSAssignTo")

                'validate
                If ddlCSStatus.SelectedValue = "" Then
                    Dim upnlCSUpdate As UpdatePanel = gvCS.Rows(Row.RowIndex).FindControl("upnlCSUpdate")
                    Dim spnCSUpdate As HtmlGenericControl = gvCS.Rows(Row.RowIndex).FindControl("spnCSUpdate")
                    spnCSUpdate.InnerHtml = "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbspError "
                    upnlCSUpdate.Update()
                Else

                    'create connection
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim SqlCmd As New SqlCommand
                    SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.Connection = SqlConn
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandText = "Upd_ENG010701_Status"
                    SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
                    SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
                    SqlCmd.Parameters.AddWithValue("@pStatus", ddlCSStatus.SelectedValue)
                    SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(ddlCSAssignTo.SelectedValue = "", CIIS_EmpCode, ddlCSAssignTo.SelectedValue))
                    SqlCmd.Parameters.AddWithValue("@pRemarks", "")
                    SqlCmd.Parameters.AddWithValue("@pMention", "")
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    'create connection

                    'execute procedure
                    SqlConn.Open()
                    SqlCmd.ExecuteNonQuery()
                    SqlConn.Close()
                    'execute procedure

                    'return APV
                    Dim upnlCSUpdate As UpdatePanel = gvCS.Rows(Row.RowIndex).FindControl("upnlCSUpdate")
                    Dim spnCSUpdate As HtmlGenericControl = gvCS.Rows(Row.RowIndex).FindControl("spnCSUpdate")
                    spnCSUpdate.InnerHtml = "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success "
                    upnlCSUpdate.Update()
                    'return APV

                End If
                'validate
            End If
        Next
        'update progress

    End Sub

#End Region

#Region "Update Progress"

    Protected Sub lbtnUP_Single_Click(ByVal sender As Object, ByVal e As EventArgs)

        bindCSAssignTo()

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].Category + ' / ' + [A].Project + ' / ' + [A].Remarks [Title] ")
        Query.Append("   ,[B].f_code [ID] ")
        Query.Append("   ,isnull([C].vendor,'-') [Name] ")
        Query.Append("   ,isnull([A].DateAwarded,getdate()) [Date] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) [AssignTo] ")
        Query.Append("   ,(case when [A].POCStatus = '' then 'On-Going' else [A].POCStatus end) [Status] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("   left join employee [D] on [A].POCAssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        Query.Append("   and [A].POCAssignTo = '" & CIIS_EmpCode & "'")
        Query.Append("   and [A].POCStatus not in ('Close') ")
        Query.Append("   and [B].f_code = '" & hfID.Value & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("AssignTo"))
        dtable.Columns.Add(New DataColumn("Status"))
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

                    'create varialble
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim AssignTo As String = DR("AssignTo")
                    Dim Status As String = DR("Status")
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Title, ID, Name, Date_, AssignTo, Status}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvUP.DataSource = dtable
        gvUP.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlUP.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUP').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnUP_Selected_Click(ByVal sender As Object, ByVal e As EventArgs)

        'populate ddl
        bindCSAssignTo()
        'populate ddl

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

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

        'validate
        If IDSrs = "" Then
            Alert("error", "No record selected.")
            Exit Sub
        End If
        'validate

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].Category + ' / ' + [A].Project + ' / ' + [A].Remarks [Title] ")
        Query.Append("   ,[B].f_code [ID] ")
        Query.Append("   ,isnull([C].vendor,'-') [Name] ")
        Query.Append("   ,isnull([A].DateAwarded,getdate()) [Date] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) [AssignTo] ")
        Query.Append("   ,(case when [A].POCStatus = '' then 'On-Going' else [A].POCStatus end) [Status] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("   left join employee [D] on [A].POCAssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        Query.Append("   and [A].POCAssignTo = '" & CIIS_EmpCode & "'")
        Query.Append("   and [A].POCStatus not in ('Close') ")
        Query.Append("   and [B].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("AssignTo"))
        dtable.Columns.Add(New DataColumn("Status"))
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

                    'create varialble
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim AssignTo As String = DR("AssignTo")
                    Dim Status As String = DR("Status")
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Title, ID, Name, Date_, AssignTo, Status}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvUP.DataSource = dtable
        gvUP.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlUP.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUP').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnUP_Update_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

        'update progress
        For Each Row As GridViewRow In gvUP.Rows
            Dim ID As Label = gvUP.Rows(Row.RowIndex).FindControl("lblID")
            If ID.Text = hfID.Value Then
                Dim tbxPOCRate As HtmlInputText = gvUP.Rows(Row.RowIndex).FindControl("tbxPOCRate")
                Dim tbxPOCDate As HtmlInputText = gvUP.Rows(Row.RowIndex).FindControl("tbxPOCDate")

                'validate
                If CDbl(tbxPOCRate.Value) <= 0 Or tbxPOCDate.Value = "" Then
                    Dim upnlUpdate As UpdatePanel = gvUP.Rows(Row.RowIndex).FindControl("upnlUpdate")
                    Dim spnUPUpdate As HtmlGenericControl = gvUP.Rows(Row.RowIndex).FindControl("spnUPUpdate")
                    spnUPUpdate.InnerHtml = "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbspError "
                    upnlUpdate.Update()
                Else

                    'create connection
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim SqlCmd As New SqlCommand
                    SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.Connection = SqlConn
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandText = "Upd_ENG010701_Progress"
                    SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
                    SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
                    SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(tbxPOCRate.Value))
                    SqlCmd.Parameters.AddWithValue("@pPOCDate", tbxPOCDate.Value)
                    SqlCmd.Parameters.AddWithValue("@pRemarks", "")
                    SqlCmd.Parameters.AddWithValue("@pMention", "")
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    'create connection

                    'execute procedure
                    SqlConn.Open()
                    SqlCmd.ExecuteNonQuery()
                    SqlConn.Close()
                    'execute procedure

                    'return APV
                    Dim upnlUpdate As UpdatePanel = gvUP.Rows(Row.RowIndex).FindControl("upnlUpdate")
                    Dim spnUPUpdate As HtmlGenericControl = gvUP.Rows(Row.RowIndex).FindControl("spnUPUpdate")
                    spnUPUpdate.InnerHtml = "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success "
                    upnlUpdate.Update()
                    'return APV

                End If
                'validate
            End If
        Next
        'update progress

    End Sub

#End Region

#Region "Upload File"

    Protected Sub lbtnUF_Single_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].Category + ' / ' + [A].Project + ' / ' + [A].Remarks [Title] ")
        Query.Append("   ,[B].f_code [ID] ")
        Query.Append("   ,isnull([C].vendor,'-') [Name] ")
        Query.Append("   ,isnull([A].DateAwarded,getdate()) [Date] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) [AssignTo] ")
        Query.Append("   ,(case when [A].POCStatus = '' then 'On-Going' else [A].POCStatus end) [Status] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("   left join employee [D] on [A].POCAssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        Query.Append("   and [A].POCAssignTo = '" & CIIS_EmpCode & "'")
        Query.Append("   and [A].POCStatus not in ('Close') ")
        Query.Append("   and [B].f_code = '" & hfID.Value & "' ")
        'get item

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

                    'create varialble
                    lblUFTitle.Text = DR("Title")
                    lblUFID.Text = DR("ID")
                    lblUFName.Text = DR("Name")
                    lblUFDate.Text = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'update
        mdlUF.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUF').modal('show');</script>", False)
        'modal

    End Sub

#End Region

#Region "Add Note"

    Protected Sub lbtnAN_Single_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].Category + ' / ' + [A].Project + ' / ' + [A].Remarks [Title] ")
        Query.Append("   ,[B].f_code [ID] ")
        Query.Append("   ,isnull([C].vendor,'-') [Name] ")
        Query.Append("   ,isnull([A].DateAwarded,getdate()) [Date] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) [AssignTo] ")
        Query.Append("   ,(case when [A].POCStatus = '' then 'On-Going' else [A].POCStatus end) [Status] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("   left join employee [D] on [A].POCAssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        Query.Append("   and [A].POCAssignTo = '" & CIIS_EmpCode & "'")
        Query.Append("   and [A].POCStatus not in ('Close') ")
        Query.Append("   and [B].f_code = '" & hfID.Value & "' ")
        'get item

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

                    'create varialble
                    lblANTitle.Text = DR("Title")
                    lblANID.Text = DR("ID")
                    lblANName.Text = DR("Name")
                    lblANDate.Text = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'update
        mdlAN.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlAN').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnAN_Update_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim AlertMsg As String = Validate("Access", "Save", "")
        'create variable

        'validate access
        If AlertMsg <> "" Then
            Alert("error", "Access denied!")
            Exit Sub
        End If
        'validate access

        'validate
        If tbxANNote.Text = "" Then
            Alert("error", "Some fields are missing!!")
            Exit Sub
        End If
        'validate

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
        SqlCmd.Parameters.AddWithValue("@pSubID", "006")
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxANNote.Text)
        SqlCmd.Parameters.AddWithValue("@pMention", hfMention.Value)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'message
        Alert("success", "Note successfully added.")
        Exit Sub
        'message

    End Sub

#End Region

End Class