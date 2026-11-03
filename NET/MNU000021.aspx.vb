Imports System.Data.SqlClient

Public Class MNU000021
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
        Master.setActiveMenu("APP", "001003")
        'active account / menu

        'Record
        ltrlFormCode.Text = "ENG010501"
        'Record

        'load page
        If IsPostBack = False Then
            bindBreadcrumbbar()
            bindCounter()
            bindTask()
            bindBatch()
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
        Query.Append("	isnull((select count(1) from Form_HWTask where AssignTo = '" & CIIS_EmpCode & "' and DateStart <= cast(getdate() as date) And status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) [Current] ")
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
                    Total = DR("Current")
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
        Query.Append("	isnull((select count(1) from Form_HWTask where AssignTo = '" & CIIS_EmpCode & "' and DateStart <= cast(getdate() as date) And status in ('','Assign','On-Going')),0) [Current] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask where AssignTo = '" & CIIS_EmpCode & "' And status in ('On-Hold')),0) [OnHold] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask where AssignTo = '" & CIIS_EmpCode & "' And status in ('Complete')),0) [Complete] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask where AssignTo = '" & CIIS_EmpCode & "' And status in ('Clarify')),0) [Clarify] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask where AssignTo = '" & CIIS_EmpCode & "' and DateStart > cast(getdate() as date) And status in ('','Assign','On-Going')),0) [Upcomming] ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblCntTask.Text = DR("Current")
                    lblCntOnHold.Text = DR("OnHold")
                    lblCntCompleted.Text = DR("Complete")
                    lblCntClarify.Text = DR("Clarify")
                    lblCntUpcoming.Text = DR("Upcomming")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        If lblCntTask.Text = "0" Then lblCntTask.Visible = False
        If lblCntOnHold.Text = "0" Then lblCntOnHold.Visible = False
        If lblCntCompleted.Text = "0" Then lblCntCompleted.Visible = False
        If lblCntClarify.Text = "0" Then lblCntClarify.Visible = False
        If lblCntUpcoming.Text = "0" Then lblCntUpcoming.Visible = False

        'display data
        upnlContent.Update()
        'display data

    End Function

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Contract" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select Status from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') in ('Close') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select TaskCode from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') not in ('005') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (AssignTo) then 1 end) from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') = 1 ")
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

        If Group_ = "Progress" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select Status from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') in ('Close') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select TaskCode from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') not in ('006') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (AssignTo) then 1 end) from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') = 1 ")
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
                Query.Append("if (select (case when '" + CIIS_EmpCode + "' not in (AssignTo) then 1 end) from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') = 1 ")
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
                Query.Append("if (select Status from Form_HWTask where HWCode = '" & hfID.Value & "' and TaskCode = '" & hfSubID.Value & "') in ('Close') ")
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
        If gvCONSelected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvCONSelected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvCONSelected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvCONSelected.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvPRGSelected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvPRGSelected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvPRGSelected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvPRGSelected.FooterRow.TableSection = TableRowSection.TableFooter
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
        Query.Append("	 (case when [A].[DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [A].[DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [A].[DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,'ENG010501-' + [A].HWCode + '-' + [A].TaskCode [Link] ")
        Query.Append("   ,dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("   ,isnull([H].vendor,'-') [Contractor] ")
        Query.Append("   ,FORMAT(isnull([A].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("   left join ogm_vendor [H] on [B].Contractor = [H].v_code ")
        Query.Append("where ")
        Query.Append("   [A].AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].DateStart > cast(getdate() as date) ")
        Query.Append("   and [A].Status in ('','Assign','On-Going') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("checkBoxClass"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("divProgress"))
        dtable.Columns.Add(New DataColumn("Progress"))
        dtable.Columns.Add(New DataColumn("Parameter"))
        dtable.Columns.Add(New DataColumn("DisplayContract"))
        dtable.Columns.Add(New DataColumn("lbtnCONSUpd"))
        dtable.Columns.Add(New DataColumn("DisplayProgress"))
        dtable.Columns.Add(New DataColumn("lbtnPRGSUpd"))
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
                    Dim checkBoxClass As String = IIf(DR("SubID") = "005", "form-check-input checkBoxClass subid005", IIf(DR("SubID") = "006", "form-check-input checkBoxClass subid006", "form-check-input checkBoxClass"))
                    Dim Link As String = DR("Link")
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    Dim divProgress As String = "ID='div" & DR("ID") & DR("SubID") & "'"
                    Dim Progress As String = IIf(DR("SubID") = "006", "<div class='d-flex flex-column w-100'><div class='d-flex flex-stack mb-2'><span class='text-muted fs-8 fw-bold'>" & DR("POCRate") & "% <i class='las la-calendar'></i>" & DR("POCDate") & "</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(DR("POCRate")) >= 66.66, "bg-sucess", IIf(CDbl(DR("POCRate")) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & DR("POCRate") & "%' aria-valuenow='" & DR("POCRate") & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>", IIf(DR("SubID") = "005", DR("Contractor"), ""))
                    Dim Parameter As String = DR("ID") & "," & DR("SubID")
                    Dim DisplayContract As String = IIf(DR("SubID") = "005", "", "style='display:none'")
                    Dim lbtnCONSUpd As String = "lbtnCONSUpd('" & DR("ID") & "','" & DR("SubID") & "'," & RowIdx & ")"
                    Dim DisplayProgress As String = IIf(DR("SubID") = "006", "", "style='display:none'")
                    Dim lbtnPRGSUpd As String = "lbtnPRGSUpd('" & DR("ID") & "','" & DR("SubID") & "'," & RowIdx & ")"
                    Dim lbtnSTSSUpd As String = "lbtnSTSSUpd('" & DR("ID") & "','" & DR("SubID") & "'," & RowIdx & ")"
                    Dim lbtnUPLSUpd As String = "lbtnUPLSUpd('" & DR("ID") & "','" & DR("SubID") & "'," & RowIdx & ")"
                    Dim lbtnNTESUpd As String = "lbtnNTESUpd('" & DR("ID") & "','" & DR("SubID") & "'," & RowIdx & ")"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, checkBoxClass, Link, Icon, Title, ID, SubID, Name, Date_, divProgress, Progress, Parameter, DisplayContract, lbtnCONSUpd, DisplayProgress, lbtnPRGSUpd, lbtnSTSSUpd, lbtnUPLSUpd, lbtnNTESUpd}
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

#Region "Add New Unit"

    Function bindBatch()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select batch' [Text] ")
        Query.Append("	 ,'1900-01-01' [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [BatchNo] [Value] ")
        Query.Append("	 ,[BatchNo] [Text] ")
        Query.Append("	 ,[DateReleased] [Order] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.mstr_BatchNo ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlANUBatch.DataSource = DT
        ddlANUBatch.DataValueField = "Value"
        ddlANUBatch.DataTextField = "Text"
        ddlANUBatch.DataBind()
        'fill data

    End Function

#End Region

#Region "Contract"

    Function bindContractor()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select contractor' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [v_code] [Value] ")
        Query.Append("	 ,[vendor] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 ogm_vendor ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlCONContractor.DataSource = DT
        ddlCONContractor.DataValueField = "Value"
        ddlCONContractor.DataTextField = "Text"
        ddlCONContractor.DataBind()
        'fill data

    End Function

    Protected Sub lbtnCONSUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("   ,[B].Contractor ")
        Query.Append("   ,[B].ConCategory [Category] ")
        Query.Append("   ,[B].ConType [Type] ")
        Query.Append("   ,[B].ConNo [No] ")
        Query.Append("   ,FORMAT([B].Conprice,'N2') [Price] ")
        Query.Append("   ,FORMAT([B].VAT,'N2') [VAT] ")
        Query.Append("   ,FORMAT([B].EWT,'N2') [EWT] ")
        Query.Append("   ,FORMAT([B].DP,'N2') [DP] ")
        Query.Append("   ,FORMAT([B].RF,'N2') [RF] ")
        Query.Append("   ,FORMAT([B].ConPriorStart,'N2') [PriorStart] ")
        Query.Append("   ,[B].ConStatus [Status] ")
        Query.Append("   ,isnull(FORMAT([B].ConDate,'MM/dd/yyyy'),'') [DateAwarded] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & hfID.Value & "' ")
        Query.Append("   and [A].TaskCode = '" & hfSubID.Value & "' ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].TaskCode = '005' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Contract", "Save", "")
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'set value
                    bindContractor()
                    ddlCONContractor.SelectedValue = DR("Contractor")
                    ddlCONCategory.SelectedValue = DR("Category")
                    ddlCONType.SelectedValue = DR("Type")
                    tbxCONNo.Value = DR("No")
                    tbxCONPrice.Value = DR("Price")
                    tbxCONVAT.Value = DR("VAT")
                    tbxCONEWT.Value = DR("EWT")
                    tbxCONDP.Value = DR("DP")
                    tbxCONRF.Value = DR("RF")
                    tbxCONPriorStart.Value = DR("PriorStart")
                    ddlCONStatus.SelectedValue = DR("Status")
                    tbxCONDateAwarded.Value = DR("Date")
                    'set value

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvCONSelected.DataSource = dtable
        gvCONSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlCON.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlCON').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnCONMUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTask.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            Dim lblSubID As Label = gvTask.Rows(RowIdx).FindControl("lblSubID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text & "-" & lblSubID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode + '-' + [A].TaskCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].TaskCode = '005' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Contract", "Save", "")
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvCONSelected.DataSource = dtable
        gvCONSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'set value
        bindContractor()
        ddlCONContractor.SelectedValue = ""
        ddlCONCategory.SelectedValue = ""
        ddlCONType.SelectedValue = ""
        tbxCONNo.Value = ""
        tbxCONPrice.Value = ""
        tbxCONVAT.Value = ""
        tbxCONEWT.Value = ""
        tbxCONDP.Value = ""
        tbxCONRF.Value = ""
        tbxCONPriorStart.Value = ""
        ddlCONStatus.SelectedValue = ""
        tbxCONDateAwarded.Value = ""
        'set value

        'update
        mdlCON.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlCON').modal('show');</script>", False)
        'modal

    End Sub

    Private Sub lbtnCONUpdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnCONUpdOk.Click

        'create variable
        Dim RowIdx = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gvCONSelected.Rows.Count
            Dim lblID As Label = gvCONSelected.Rows(RowIdx).FindControl("lblID")
            Dim lblSubID As Label = gvCONSelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

            'create variable
            Dim Msg As String = Validate("Contract", "Save", "")
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
        Do Until RowIdx = gvCONSelected.Rows.Count
            Dim lblID As Label = gvCONSelected.Rows(RowIdx).FindControl("lblID")
            Dim lblSubID As Label = gvCONSelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Contract"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
            SqlCmd.Parameters.AddWithValue("@pSubID", hfSubID.Value)
            SqlCmd.Parameters.AddWithValue("@pContractor", ddlCONContractor.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pContractCategory", ddlCONCategory.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pContractType", ddlCONType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pContractNo", tbxCONNo.Value)
            SqlCmd.Parameters.AddWithValue("@pContractPrice", CDbl(tbxCONPrice.Value))
            SqlCmd.Parameters.AddWithValue("@pContractVAT", CDbl(tbxCONVAT.Value))
            SqlCmd.Parameters.AddWithValue("@pContractEWT", CDbl(tbxCONEWT.Value))
            SqlCmd.Parameters.AddWithValue("@pContractDP", CDbl(tbxCONDP.Value))
            SqlCmd.Parameters.AddWithValue("@pContractRF", CDbl(tbxCONRF.Value))
            SqlCmd.Parameters.AddWithValue("@pContractPriorStart", CDbl(tbxCONPriorStart.Value))
            SqlCmd.Parameters.AddWithValue("@pContractStatus", ddlCONStatus.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pDateAwarded", tbxCONDateAwarded.Value)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'update progress
            For Each Row As GridViewRow In gvTask.Rows
                Dim ID As Label = gvTask.Rows(Row.RowIndex).FindControl("lblID")
                Dim SubID As Label = gvTask.Rows(Row.RowIndex).FindControl("lblSubID")
                If ID.Text = hfID.Value And SubID.Text = hfSubID.Value Then
                    Dim upnlProgress As UpdatePanel = gvTask.Rows(Row.RowIndex).FindControl("upnlProgress")
                    Dim divProgress As HtmlGenericControl = gvTask.Rows(Row.RowIndex).FindControl("divProgress")
                    divProgress.InnerHtml = IIf(ddlCONContractor.SelectedValue = "", "-", ddlCONContractor.SelectedItem.Text)
                    upnlProgress.Update()
                End If
            Next
            'update progress

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'success message
        Alert("success", "Contract successfully saved.")
        'success message

        'update panel 
        mdlCON.Update()
        'update panel 

    End Sub

#End Region

#Region "Progress"

    Protected Sub lbtnPRGSUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("   ,FORMAT(ISNULL([B].POCRate,0),'N2') [POCRate] ")
        Query.Append("   ,FORMAT(isnull([B].POCDate,getdate()),'MM/dd/yyyy') [POCDate] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & hfID.Value & "' ")
        Query.Append("   and [A].TaskCode = '" & hfSubID.Value & "' ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].TaskCode = '006' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Progress", "Save", "")
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'set value
                    tbxPRGRate.Value = DR("POCRate")
                    tbxPRGDate.Value = DR("POCDate")
                    tbxPRGRemarks.Text = ""
                    hfMention.Value = ""
                    'set value

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvPRGSelected.DataSource = dtable
        gvPRGSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'update
        mdlPRG.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlPRG').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub lbtnPRGMUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'create variable
        Dim RowIdx = 0
        Dim IDSrs = ""
        'create variable

        'get selected rows
        Do Until RowIdx = gvTask.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            Dim lblSubID As Label = gvTask.Rows(RowIdx).FindControl("lblSubID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text & "-" & lblSubID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode + '-' + [A].TaskCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].TaskCode = '006' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
                    'set value

                    'create variable
                    Dim Msg As String = Validate("Progress", "Save", "")
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvPRGSelected.DataSource = dtable
        gvPRGSelected.DataBind()
        RenderDatatable()
        'bind datatable

        'set value
        tbxPRGRate.Value = "0.00"
        tbxPRGDate.Value = ""
        tbxPRGRemarks.Text = ""
        hfMention.Value = ""
        'set value

        'update
        mdlPRG.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlPRG').modal('show');</script>", False)
        'modal

    End Sub

    Private Sub lbtnPRGUpdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnPRGUpdOk.Click

        'create variable
        Dim RowIdx = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gvPRGSelected.Rows.Count
            Dim lblID As Label = gvPRGSelected.Rows(RowIdx).FindControl("lblID")
            Dim lblSubID As Label = gvPRGSelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

            'create variable
            Dim Msg As String = Validate("Progress", "Save", "")
            'create variable

            'validate record
            If Msg <> "" Then
                Alert("error", Msg)
                Exit Sub
            ElseIf CDbl(tbxPRGRate.Value) <= 0 Then
                Alert("error", "Some fields are missing!")
                Exit Sub
            ElseIf CDbl(tbxPRGRate.Value) > 100 Then
                Alert("error", "Rate should be between 0.01 and 100.00!")
                Exit Sub
            ElseIf tbxPRGDate.Value = "" Then
                Alert("error", "Some fields are missing!")
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
        Do Until RowIdx = gvPRGSelected.Rows.Count
            Dim lblID As Label = gvPRGSelected.Rows(RowIdx).FindControl("lblID")
            Dim lblSubID As Label = gvPRGSelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
            SqlCmd.Parameters.AddWithValue("@pSubID", hfSubID.Value)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(tbxPRGRate.Value))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", tbxPRGDate.Value)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbxPRGRemarks.Text)
            SqlCmd.Parameters.AddWithValue("@pMention", hfMention.Value)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'update progress
            For Each Row As GridViewRow In gvTask.Rows
                Dim ID As Label = gvTask.Rows(Row.RowIndex).FindControl("lblID")
                Dim SubID As Label = gvTask.Rows(Row.RowIndex).FindControl("lblSubID")
                If ID.Text = hfID.Value And SubID.Text = hfSubID.Value Then
                    Dim upnlProgress As UpdatePanel = gvTask.Rows(Row.RowIndex).FindControl("upnlProgress")
                    Dim divProgress As HtmlGenericControl = gvTask.Rows(Row.RowIndex).FindControl("divProgress")
                    divProgress.InnerHtml = "<div class='d-flex flex-column w-100'><div class='d-flex flex-stack mb-2'><span class='text-muted fs-8 fw-bold'>" & tbxPRGRate.Value & "% <i class='las la-calendar'></i>" & tbxPRGDate.Value & "</span></div><div class='progress h-6px w-100'><div class='progress-bar " & IIf(CDbl(tbxPRGRate.Value) >= 66.66, "bg-sucess", IIf(CDbl(tbxPRGRate.Value) >= 33.33, "bg-warning", "bg-danger")) & "' role='progressbar' style='width: " & tbxPRGRate.Value & "%' aria-valuenow='" & tbxPRGRate.Value & "' aria-valuemin='0' aria-valuemax='100'></div></div></div>"
                    upnlProgress.Update()
                End If
            Next
            'update progress

            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'success message
        Alert("success", "Progess successfully saved.")
        'success message

        'update panel 
        mdlSTS.Update()
        'update panel 

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
        ddlSTSAssignTo.DataSource = DT
        ddlSTSAssignTo.DataValueField = "Value"
        ddlSTSAssignTo.DataTextField = "Text"
        ddlSTSAssignTo.DataBind()
        'fill data

    End Function

    Protected Sub lbtnSTSSUpd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & hfID.Value & "' ")
        Query.Append("   and [A].TaskCode = '" & hfSubID.Value & "' ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
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
                    Dim ID As String = DR("ID")
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
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
        divSTSActDateEnd.Style.Add("display", "none")
        tbxSTSActDateEnd.Value = ""
        bindUser()
        ddlSTSAssignTo.SelectedValue = ""
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
            Dim lblSubID As Label = gvTask.Rows(RowIdx).FindControl("lblSubID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text & "-" & lblSubID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode + '-' + [A].TaskCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
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
                    Dim ID As String = DR("ID")
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
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
        '
        'set value
        ddlSTSStatus.SelectedValue = ""
        divSTSActDateEnd.Style.Add("display", "none")
        tbxSTSActDateEnd.Value = ""
        bindUser()
        ddlSTSAssignTo.SelectedValue = ""
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
            Dim lblSubID As Label = gvSTSSelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

            'create variable
            Dim Msg As String = Validate("Status", "Save", "")
            'create variable

            'validate record
            If Msg <> "" Then
                Alert("error", Msg)
                Exit Sub
            ElseIf ddlSTSStatus.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
                Exit Sub
            ElseIf ddlSTSStatus.SelectedValue = "Complete" And tbxSTSActDateEnd.Value = "" Then
                Alert("error", "Some field(s) are missing!")
                Exit Sub
            ElseIf ddlSTSAssignTo.SelectedValue = "" Then
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
            Dim lblID As Label = gvSTSSelected.Rows(RowIdx).FindControl("lblID")
            Dim lblSubID As Label = gvSTSSelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
            SqlCmd.Parameters.AddWithValue("@pSubID", hfSubID.Value)
            SqlCmd.Parameters.AddWithValue("@pStatus", ddlSTSStatus.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", tbxSTSActDateEnd.Value)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", ddlSTSAssignTo.SelectedValue)
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
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & hfID.Value & "' ")
        Query.Append("   and [A].TaskCode = '" & hfSubID.Value & "' ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
                    lblUPLIDsrs.Value = DR("ID") & "-" & DR("SubID")
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
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
            Dim lblSubID As Label = gvTask.Rows(RowIdx).FindControl("lblSubID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text & "-" & lblSubID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode + '-' + [A].TaskCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    hfSubID.Value = DR("SubID")
                    lblUPLIDsrs.Value = IIf(lblUPLIDsrs.Value = "", DR("ID") & "-" & DR("SubID"), lblUPLIDsrs.Value & ";" & DR("ID") & "-" & DR("SubID"))
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
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
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & hfID.Value & "' ")
        Query.Append("   and [A].TaskCode = '" & hfSubID.Value & "' ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
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
            Dim lblSubID As Label = gvTask.Rows(RowIdx).FindControl("lblSubID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text & "-" & lblSubID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [E].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,[A].TaskCode [SubID] ")
        Query.Append("   ,[G].TaskName [Name] ")
        Query.Append("   ,[A].DateStart [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [E] on [B].House = [E].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode + '-' + [A].TaskCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("   and [A].AssignTo = '" & CIIS_EmpCode & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("SubID"))
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
                    Dim SubID As String = DR("SubID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), Format(DR("Date"), "MMM d"))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Icon, Title, ID, SubID, Name, Date_}
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
            Dim lblSubID As Label = gvNTESelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

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
            Dim lblSubID As Label = gvNTESelected.Rows(RowIdx).FindControl("lblSubID")
            hfID.Value = lblID.Text
            hfSubID.Value = lblSubID.Text

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
            SqlCmd.Parameters.AddWithValue("@pSubID", hfSubID.Value)
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