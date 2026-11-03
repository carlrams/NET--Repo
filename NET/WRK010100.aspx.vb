Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Web.Services.WebMethodAttribute
Imports Microsoft.Ajax.Utilities
Imports System.Net.NetworkInformation
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports System.Runtime.CompilerServices.RuntimeHelpers

Public Class WRK010100
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
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
        Master.setActiveMenu("APP", "001002")
        'active account / menu

        'Record
        ltrlFormCode.Text = "WRK010100"
        'Record

        'load page
        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString().Replace("No", "#")
            ltrlMode.Text = Me.Page.RouteData.Values("Mode").ToString()
            'Record

            'tagged notifition as seen
            Seen()
            'tagged notifition as seen

            'display record
            bindTitle()
            bind01Overview()
            bind02Files()
            bind03Subscribers()
            bind04ApprovalPath()
            bind05Notes()
            'display record

        ElseIf IsPostBack = True Then

            If ltrlMode.Text = "UPD" Then
                bind01Category()
                ddl01Category.SelectedValue = hf01Category.Value
                bind01Project(hf01Category.Value)
                ddl01Project.SelectedValue = hf01Project.Value
            End If

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function Seen()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = getdate() ")
        Query.Append("   ,Seen = 1 ")
        Query.Append("where ")
        Query.Append("   TblName = '" & ltrlFormCode.Text & "' ")
        Query.Append("   and TblCode = '" & ltrlID.Text & "' ")
        Query.Append("   and Notify = '" & CIIS_EmpCode & "' ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Function bindTitle()

        'update record
        If ltrlMode.Text = "UPD" Then

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select")
            Query.Append("   wo_code [ID] ")
            Query.Append("   ,summary [Title] ")
            Query.Append("   ,(case when status = '' then 'New' else status end) [Status] ")
            Query.Append("from ")
            Query.Append("   oop_wo_hdr ")
            Query.Append("where ")
            Query.Append("   wo_code = '" & ltrlID.Text & "' ")
            'get total task

            'create variable
            Dim Total As String = "0"
            'create variable

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()

                        'set value
                        lblTitle.Text = DR("Title")
                        lblID.Text = DR("ID")
                        lblStatus.Text = DR("Status")
                        If lblStatus.Text = "New" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                        ElseIf lblStatus.Text = "Assigned" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Accepted" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Completed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-success")
                        ElseIf lblStatus.Text = "Clarify" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Cancelled" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Closed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-secondary")
                        End If
                        'set value

                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
            'read record

        End If
        'update record

        'view record
        If ltrlMode.Text = "DTL" Then

            'set value
            lblTitle.Text = "-"
            lblID.Text = "-"
            lblStatus.Text = "-"
            'set value

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select")
            Query.Append("   wo_code [ID] ")
            Query.Append("   ,summary [Title] ")
            Query.Append("   ,(case when status = '' then 'New' else status end) [Status] ")
            Query.Append("from ")
            Query.Append("   oop_wo_hdr ")
            Query.Append("where ")
            Query.Append("   wo_code = '" & ltrlID.Text & "' ")
            'get total task

            'create variable
            Dim Total As String = "0"
            'create variable

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()

                        'set value
                        lblTitle.Text = DR("Title")
                        lblID.Text = DR("ID")
                        lblStatus.Text = DR("Status")
                        If lblStatus.Text = "New" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                        ElseIf lblStatus.Text = "Assigned" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Accepted" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Completed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-success")
                        ElseIf lblStatus.Text = "Clarify" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Cancelled" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Closed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-secondary")
                        End If
                        'set value

                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
            'read record

        End If
        'view record

        'display record
        upnlTitle.Update()
        'display record

    End Function

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "03Subscribers" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') in ('Closed','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') in ('Closed','Cancelled') ")
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

        If Group_ = "02Files" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') in ('Closed','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') in ('Closed','Cancelled') ")
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

        If Group_ = "01Overview" Then

            'get total task
            If Type = "Delete" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') in ('Closed','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') in ('Closed','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Status" Then
                Query.Append("if (select status from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') in ('Closed','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & Value & "' in ('Closed') and (select (case when '" + CIIS_EmpCode + "' not in (created_by) then 1 end) from oop_wo_hdr where wo_code = '" & ltrlID.Text & "') = 1 ")
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
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
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

    Function EnableBtn()

        'overview
        lbtn01Find.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Refresh.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-danger align-self-center m-1"
        lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
        lbtn01Status.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1"
        lbtn01Print.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1"
        'overview

        'file
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'file

        'copy furnished
        lbtn03Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'copy furnished

        'approval path
        lbtn05Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'approval path

        'update controls
        upnl01Overview.Update()
        upnl02Files.Update()
        upnl03Subscribers.Update()
        upnl04ApprovalPath.Update()
        upnl05Notes.Update()
        'update controls

    End Function

    Function DisableBtn()

        'overview
        lbtn01Find.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Refresh.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Add.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Status.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Print.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'overview

        'file
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'file

        'copy furnished
        lbtn03Add.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'copy furnished

        'approval path
        lbtn05Add.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'approval path

        'update controls
        upnl01Overview.Update()
        upnl02Files.Update()
        upnl03Subscribers.Update()
        upnl04ApprovalPath.Update()
        upnl05Notes.Update()
        'update controls

    End Function

    Function HideBtn()
        lbtn01DeleteOk.Visible = False
        lbtn01SaveOk.Visible = False
        lbtn02DeleteOk.Visible = False
    End Function

#End Region

#Region "Overview"

#Region "Overview"

    Function bind01Overview()

        'hide fiels
        pnl01Edit.Visible = False
        pnl01Dtl.Visible = False
        'hide fiels

        'update record
        If ltrlMode.Text = "UPD" Then

            'hide and display buttons
            DisableBtn()
            lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-danger align-self-center m-1"
            lbtn01Delete.ToolTip = "Cancel record"
            lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
            lbtn01Edit.Text = "<i class='las la-save fs-2'></i>"
            lbtn01Edit.ToolTip = "Save record"
            'hide and display buttons

            'display fields
            pnl01Edit.Visible = True
            'displa fields

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select")
            Query.Append("   [A].wo_code [ID] ")
            Query.Append("   ,FORMAT([A].created_date,'MM/dd/yyyy') [DateRequested] ")
            Query.Append("   ,FORMAT([A].date_end,'MM/dd/yyyy') [DateRequired] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [RequestedBy] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [AssignedTo] ")
            Query.Append("   ,'-' [EndorsedTo]  ")
            Query.Append("   ,[A].status [Status] ")
            Query.Append("   ,[A].category [Category] ")
            Query.Append("   ,[A].project [Project] ")
            Query.Append("   ,[A].priority [Priority] ")
            Query.Append("   ,[A].summary [Summary] ")
            Query.Append("   ,[A].description [Description] ")
            Query.Append("from ")
            Query.Append("   oop_wo_hdr [A] ")
            Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("   left join employee [C] on [A].assigned_to = [C].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].wo_code = '" & ltrlID.Text & "' ")
            Query.Append("   and [A].status in ('Accepted','Assigned','Completed','Clarify') ")
            'get total task

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        tbx01ID.Text = DR("ID")
                        tbx01FormType.Text = "Work Order"
                        tbx01DateRequested.Text = DR("DateRequested")
                        tbx01DateRequired.Value = DR("DateRequired")
                        tbx01RequestedBy.Text = DR("RequestedBy")
                        tbx01AssignedTo.Text = DR("AssignedTo")
                        tbx01EndorsedTo.Text = DR("EndorsedTo")
                        tbx01Status.Text = DR("Status")
                        bind01Category()
                        ddl01Category.SelectedValue = DR("Category")
                        hf01Category.Value = DR("Category")
                        bind01Project(DR("Category"))
                        ddl01Project.SelectedValue = DR("Project")
                        hf01Project.Value = DR("Project")
                        ddl01Priority.SelectedValue = DR("Priority")
                        tbx01Summary.Text = DR("Summary")
                        tbx01Description.Text = DR("Description")
                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
            'read record

            'display data
            upnl01Overview.Update()
            'display data

        End If
        'update record

        'view record
        If ltrlMode.Text = "DTL" Then

            'hide and display buttons
            EnableBtn()
            lbtn01Delete.ToolTip = "Delete record"
            lbtn01Edit.Text = "<i class='las la-pencil-alt fs-2'></i>"
            lbtn01Edit.ToolTip = "Edit record"
            'hide and display buttons

            'display fields
            pnl01Dtl.Visible = True
            'displa fields

            'set value
            lbl01ID.Text = "-"
            lbl01FormType.Text = "-"
            lbl01DateRequested.Text = "-"
            lbl01DateRequired.Text = "-"
            lbl01RequestedBy.Text = "-"
            lbl01AssignedTo.Text = "-"
            lbl01EndorsedTo.Text = "-"
            lbl01Status.Text = "-"
            lbl01Category.Text = "-"
            lbl01Project.Text = "-"
            lbl01Priority.Text = "-"
            lbl01Summary.Text = "-"
            lbl01Description.Text = "-"
            'set value

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select")
            Query.Append("   [A].wo_code [ID] ")
            Query.Append("   ,FORMAT([A].created_date,'MM/dd/yyyy') [DateRequested] ")
            Query.Append("   ,FORMAT([A].date_end,'MM/dd/yyyy') [DateRequired] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [RequestedBy] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [AssignedTo] ")
            Query.Append("   ,'-' [EndorsedTo]  ")
            Query.Append("   ,[A].status [Status] ")
            Query.Append("   ,[D].description [Category] ")
            Query.Append("   ,[E].description [Project] ")
            Query.Append("   ,[A].priority [Priority] ")
            Query.Append("   ,[A].summary [Summary] ")
            Query.Append("   ,[A].description [Description] ")
            Query.Append("from ")
            Query.Append("   oop_wo_hdr [A] ")
            Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("   left join employee [C] on [A].assigned_to = [C].emp_no ")
            Query.Append("   left join oop_category [D] on [A].category = [D].c_code ")
            Query.Append("   left join oop_project [E] on [A].project = [E].p_code ")
            Query.Append("where ")
            Query.Append("   [A].wo_code = '" & ltrlID.Text & "' ")
            'get total task

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        lbl01ID.Text = DR("ID")
                        lbl01FormType.Text = "Work Order"
                        lbl01DateRequested.Text = DR("DateRequested")
                        lbl01DateRequired.Text = DR("DateRequired")
                        lbl01RequestedBy.Text = DR("RequestedBy")
                        lbl01AssignedTo.Text = DR("AssignedTo")
                        lbl01EndorsedTo.Text = DR("EndorsedTo")
                        lbl01Status.Text = DR("Status")
                        lbl01Category.Text = DR("Category")
                        lbl01Project.Text = DR("Project")
                        lbl01Priority.Text = DR("Priority")
                        lbl01Summary.Text = DR("Summary")
                        lbl01Description.Text = DR("Description")
                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
            'read record

            'display data
            upnl01Overview.Update()
            'display data

        End If
        'view record

        'display record
        upnl01Overview.Update()
        'display record

    End Function

    Function bind01Category()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'select a category' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].c_code [Code] ")
        Query.Append("   ,[A].description [Name] ")
        Query.Append("   ,[A].description [Order] ")
        Query.Append("from ")
        Query.Append("   oop_category [A] ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Category.DataSource = DT
        ddl01Category.DataValueField = "Code"
        ddl01Category.DataTextField = "Name"
        ddl01Category.DataBind()
        'fill data

    End Function

    Function bind01Project(Category As String)

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'select a project' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].p_code [Code] ")
        Query.Append("   ,[A].description [Name] ")
        Query.Append("   ,[A].description [Order] ")
        Query.Append("from ")
        Query.Append("   oop_project [A] ")
        Query.Append("where ")
        Query.Append("   [A].c_code = '" & Category & "' ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Project.DataSource = DT
        ddl01Project.DataValueField = "Code"
        ddl01Project.DataTextField = "Name"
        ddl01Project.DataBind()
        'fill data

        'display record
        upnl01Overview.Update()
        'display record

    End Function

    Protected Sub lbtn01Find_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Find.Click

        'validate
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'display modal
        bind01Find()
        mdl01Find.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Find').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub lbtn01Refresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Refresh.Click

        'validate
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'display record
        bindTitle()
        bind01Overview()
        bind02Files()
        bind03Subscribers()
        bind04ApprovalPath()
        bind05Notes()
        'display record

    End Sub

    Protected Sub lbtn01Add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Add.Click

        'validate
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'display add
        ltrlID.Text = "0000000000000"
        ltrlMode.Text = "ADD"
        bindTitle()
        bind01Overview()
        bind02Files()
        bind03Subscribers()
        bind04ApprovalPath()
        bind05Notes()
        'display add

    End Sub

    Protected Sub lbtn01Delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Delete.Click

        'cancel record
        If ltrlMode.Text = "UPD" Then

            'hide button
            HideBtn()
            'hide button

            'display modal
            lbl01ConfirmMessageDialogBox.Text = "Cancel record?"
            lbtn01DeleteOk.Visible = True
            mdl01DialogBox.Update()
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('show');</script>", False)
            'display modal

        End If
        'cancel record

        'delete record
        If ltrlMode.Text = "DTL" Then

            'create variable
            Dim Msg01 As String = Validate("01Overview", "Delete", "")
            'create variable

            'validate record
            If Msg01 <> "" Then
                Alert("error", Msg01)
            Else

                'hide button
                HideBtn()
                'hide button

                'display modal
                lbl01ConfirmMessageDialogBox.Text = "Delete record?"
                lbtn01DeleteOk.Visible = True
                mdl01DialogBox.Update()
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('show');</script>", False)
                'display modal

            End If
            'validate record

            Exit Sub

        End If
        'delete record

    End Sub

    Protected Sub lbtn01DeleteOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01DeleteOk.Click

        'hide modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');</script>", False)
        'hide modal

        'cancel record
        If ltrlMode.Text = "UPD" Then

            'Record
            ltrlMode.Text = "DTL"
            'Record

            'display record
            bindTitle()
            bind01Overview()
            'display record

            Exit Sub

        End If
        'cancel record

        'delete record
        If ltrlMode.Text = "DTL" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Del_Record"
            SqlCmd.Parameters.AddWithValue("@pTblName", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pTblCode", ltrlID.Text)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'remove file within the folder
            Dim UploadFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/"))
            Try
                Dim File As FileInfo
                For Each File In UploadFile.GetFiles()
                    File.Delete()
                Next
            Catch ex As Exception
            End Try
            'remove file within the folder


            'Record
            ltrlMode.Text = "DTL"
            ltrlID.Text = "0000000000000"
            'Record

            'success alert
            Alert("success", "Record successfully removed.")
            'success alert

            'display record
            bindTitle()
            bind01Overview()
            bind02Files()
            bind03Subscribers()
            bind04ApprovalPath()
            bind05Notes()
            'display record

        End If
        'delete record

    End Sub

    Protected Sub lbtn01Edit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Edit.Click

        'Save record
        If ltrlMode.Text = "ADD" Then

            'validate record
            If tbx01DateRequired.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01FormType.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Category.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Project.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Priority.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Summary.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Description.Text = "" Then
                Alert("error", "Some fields are missing!")
            Else

                'hide button
                HideBtn()
                'hide button

                'display modal
                lbl01ConfirmMessageDialogBox.Text = "Save record?"
                lbtn01SaveOk.Visible = True
                mdl01DialogBox.Update()
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('show');</script>", False)
                'display modal

            End If

        End If
        'save record

        'Save record
        If ltrlMode.Text = "UPD" Then

            'validate record
            If tbx01DateRequired.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01FormType.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Category.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Project.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Priority.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Summary.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Description.Text = "" Then
                Alert("error", "Some fields are missing!")
            Else

                'hide button
                HideBtn()
                'hide button

                'display modal
                lbl01ConfirmMessageDialogBox.Text = "Save record?"
                lbtn01SaveOk.Visible = True
                mdl01DialogBox.Update()
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('show');</script>", False)
                'display modal

            End If

        End If
        'save record

        'Edit record
        If ltrlMode.Text = "DTL" And ltrlID.Text <> "0000000000000" Then

            'create variable
            Dim Msg As String = Validate("01Overview", "Save", "")
            'create variable

            'validate record
            If Msg <> "" Then
                Alert("error", Msg)
            Else

                'Record
                ltrlMode.Text = "UPD"
                'Record

                'display record
                bindTitle()
                bind01Overview()
                'display record

            End If
            'validate record

            Exit Sub

        End If
        'Edit record

    End Sub

    Protected Sub lbtn01SaveOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01SaveOk.Click

        'hide modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');</script>", False)
        'hide modal

        'cancel record
        If ltrlMode.Text = "UPD" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_WRK_WRK010100"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Value)
            SqlCmd.Parameters.AddWithValue("@pCategory", ddl01Category.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pProject", ddl01Project.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pPriority", ddl01Priority.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pSummary", tbx01Summary.Text)
            SqlCmd.Parameters.AddWithValue("@pDescription", tbx01Description.Text)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'Record
            ltrlMode.Text = "DTL"
            'Record

            'success alert
            Alert("success", "Record successfully saved.")
            'success alert

            'display record
            bindTitle()
            bind01Overview()
            'display record

            Exit Sub

        End If
        'cancel record

    End Sub

    Protected Sub lbtn01Status_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Status.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("01Overview", "Status", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'reset 
            ddl01Status.SelectedValue = ""
            bind01User()
            ddl01AssignTo.SelectedValue = ""
            tbx01Note.Text = ""
            'reset 

            'update data
            mdl01Status.Update()
            'update data

            'display modal
            mdl01Status.Update()
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Status').modal('show');</script>", False)
            'display modal

        End If
        'validate record

    End Sub

    Protected Sub lbtn01Print_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Print.Click

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
        Dim PDFFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/"))
        Try
            Dim file As FileInfo
            For Each file In PDFFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file within the folder

        'copy template report
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000001.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000001.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000001.rpt"))
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
        RptDoc.SetParameterValue("@wo_code", ltrlID.Text)
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000001.pdf"), Buf)

            'view report
            RptDoc.Dispose()
            RptDoc.Close()
            Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000001.pdf")
            ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
            'view report
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

    End Sub

#End Region

#Region "Modal Find"

    Function bind01Find()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,[A].status [Status] ")
        Query.Append("   ,[A].summary [Description] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [RequestedBy] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [AssignedTo] ")
        Query.Append("from ")
        Query.Append("   oop_wo_hdr [A] ")
        Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   left join employee [C] on [A].assigned_to = [C].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].status in ('Assigned','Clarify','Completed','Accepted') ")
        Query.Append("union  ")
        Query.Append("select  ")
        Query.Append("   'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,[A].status [Status] ")
        Query.Append("   ,[A].summary [Description] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [RequestedBy] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [AssignedTo] ")
        Query.Append("from ")
        Query.Append("   oop_wo_hdr [A] ")
        Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   left join employee [C] on [A].assigned_to = [C].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].assigned_to = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].status in ('Assigned','Clarify','Completed','Accepted') ")
        Query.Append("union  ")
        Query.Append("select  ")
        Query.Append("   'WRK010100-DTL-' + [A].wo_code [Link] ")
        Query.Append("   ,[A].wo_code [ID] ")
        Query.Append("   ,[A].status [Status] ")
        Query.Append("   ,[A].summary [Description] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [RequestedBy] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [AssignedTo] ")
        Query.Append("from ")
        Query.Append("from ")
        Query.Append("	 oop_wo_dtl_monitor [D] ")
        Query.Append("	 left join oop_wo_hdr [A] on [D].wo_code = [A].wo_code ")
        Query.Append("	 left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	 left join employee [C] on [A].approver = [C].emp_no ")
        Query.Append("where ")
        Query.Append("   [D].monitored_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].status in ('Assigned','Clarify','Completed','Accepted') ")
        Query.Append("order by ")
        Query.Append("   [ID] ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Description"))
        dtable.Columns.Add(New DataColumn("RequestedBy"))
        dtable.Columns.Add(New DataColumn("AssignedTo"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Try
                        Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5)}
                        Dim NewRow As DataRow
                        NewRow = dtable.Rows.Add(NewRowValues)
                    Catch ex As Exception
                    End Try
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gv01Find.DataSource = dtable
        gv01Find.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv01Find.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv01Find.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gv01Find.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gv01Find.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

#Region "Modal Status"

    Function bind01User()

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
        Query.Append("   emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("   and lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01AssignTo.DataSource = DT
        ddl01AssignTo.DataValueField = "Value"
        ddl01AssignTo.DataTextField = "Text"
        ddl01AssignTo.DataBind()
        'fill data

    End Function

    Protected Sub lbtn01SaveStatus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01SaveStatus.Click

        'create variable
        Dim Msg As String = Validate("01Overview", "Status", ddl01Status.SelectedValue)
        'create variable

        'validate fields
        If Msg <> "" Then
            Alert("error", Msg)
        ElseIf ddl01Status.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
        ElseIf ddl01AssignTo.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_WRK_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pStatus", ddl01Status.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", ddl01AssignTo.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Note.Text)
            SqlCmd.Parameters.AddWithValue("@pMention", hdnMention.Value)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'clear record
            ddl01Status.SelectedValue = ""
            ddl01AssignTo.SelectedValue = ""
            tbx01Note.Text = ""
            hdnMention.Value = ""

            'clear record

            'display success message
            Alert("success", "Record successfully saved.")
            'display success message

            'refresh record
            bindTitle()
            bind01Overview()
            bind04ApprovalPath()
            bind05Notes()
            'refresh record

        End If
        'validate fields

    End Sub

#End Region

#End Region

#Region "Files"

#Region "Files"

    Function bind02Files()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        If Directory.Exists(Server.MapPath("~/Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/")) Then

            'set folder
            Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/"))
            Dim listfiles As FileInfo() = objDir.GetFiles()
            Dim DefaultFiles As FileInfo() = (From file In listfiles Order By file.CreationTime Select file).ToArray()
            'set folder

            'read file
            For Each File In DefaultFiles

                'create variable
                Dim Icon As String
                'create variable

                'set icon for specific file
                If File.Name.Contains(".png") Or File.Name.Contains(".PNG") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".jpg") Or File.Name.Contains(".jpeg") Or File.Name.Contains(".jpe") Or File.Name.Contains(".jfif") Or File.Name.Contains(".JPG") Or File.Name.Contains(".JPEG") Or File.Name.Contains(".JPE") Or File.Name.Contains(".JFIF") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                ElseIf File.Name.Contains(".txt") Or File.Name.Contains(".TXT") Then
                    Icon = "<i class='las la-file-alt fs-2qx'></i>"
                ElseIf File.Name.Contains(".xlsx") Or File.Name.Contains(".xls") Or File.Name.Contains(".XLSX") Or File.Name.Contains(".XLS") Then
                    Icon = "<i class='las la-file-excel fs-2qx'></i>"
                ElseIf File.Name.Contains(".docx") Or File.Name.Contains(".doc") Or File.Name.Contains(".DOCX") Or File.Name.Contains(".DOC") Then
                    Icon = "<i class='las la-file-word fs-2qx'></i>"
                ElseIf File.Name.Contains(".pptx") Or File.Name.Contains(".ppt") Or File.Name.Contains(".PPTX") Or File.Name.Contains(".PPT") Then
                    Icon = "<i class='las la-file-powerpoint fs-2qx'></i>"
                ElseIf File.Name.Contains(".pdf") Or File.Name.Contains(".PDF") Then
                    Icon = "<i class='las la-file-pdf fs-2qx'></i>"
                End If
                'set icon for specific file

                'add file
                Dim current_RowValues As Object() = {Icon, File.Name, Format(File.CreationTime, "MM/dd/yyyy hh:mm tt")}
                Dim current_dRow As DataRow
                current_dRow = dtable.Rows.Add(current_RowValues)
                dtable.AcceptChanges()
                'add file

                blink01Attachment.Style.Add("display", "")
            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gv02Files.DataSource = dataView
            gv02Files.DataBind()
            'bind datatable

            'display data
            upnl02Files.Update()
            'display data

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gv02Files.DataSource = dataView
            gv02Files.DataBind()
            'bind datatable

            'display data
            upnl02Files.Update()
            'display data

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv02Files.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv02Files.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv02Files.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Protected Sub lbtn02Upload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn02Upload.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("02Files", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'display modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl02Upload').modal('show');</script>", False)
            'display modal

        End If
        'validate record

    End Sub

    Protected Sub lbtn02Delete(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'hide button
        HideBtn()
        'hide button

        'set value
        hfFileName.Value = CType(sender, LinkButton).CommandArgument

        'display modal
        lbl01ConfirmMessageDialogBox.Text = "Delete file?"
        lbtn02DeleteOk.Visible = True
        mdl01DialogBox.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('show');</script>", False)
        'display modal

    End Sub

    Private Sub lbtn02DeleteOk_Click(sender As Object, e As EventArgs) Handles lbtn02DeleteOk.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("02Files", "Delete", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'remove file
            Dim FilePath As String = Server.MapPath("~/Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/") & CType(sender, LinkButton).CommandArgument
            File.Delete(FilePath)
            'remove file

            'remove file
            FilePath = Server.MapPath("~/Assets/Upload/FRM000001/" & ltrlID.Text & "/") & CType(sender, LinkButton).CommandArgument
            File.Delete(FilePath)
            'remove file

            Dim SqlConn01 As New SqlClient.SqlConnection
            Dim SqlCmd01 As New SqlCommand
            SqlConn01.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd01.CommandTimeout = 1500
            SqlCmd01.Connection = SqlConn01
            SqlCmd01.CommandType = CommandType.StoredProcedure
            SqlCmd01.CommandText = "Del_File"
            SqlCmd01.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd01.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd01.Parameters.AddWithValue("@pType", "Removed a file:")
            SqlCmd01.Parameters.AddWithValue("@pDescription", CType(sender, LinkButton).CommandArgument)
            SqlCmd01.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn01.Open()
            SqlCmd01.ExecuteNonQuery()
            SqlConn01.Close()
            'execute procedure

            'file exchange
            Dim sqlConn02 As New SqlClient.SqlConnection
            Dim sqlCmd02 As New SqlCommand
            sqlConn02.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            sqlCmd02.CommandTimeout = 1500
            sqlCmd02.Connection = sqlConn02
            sqlCmd02.CommandType = CommandType.StoredProcedure
            sqlCmd02.CommandText = "New_TempFileExchange"
            sqlCmd02.Parameters.AddWithValue("@pServer", "V2")
            sqlCmd02.Parameters.AddWithValue("@pAction", "Delete")
            sqlCmd02.Parameters.AddWithValue("@pForm", ltrlID.Text)
            sqlCmd02.Parameters.AddWithValue("@pFile_", CType(sender, LinkButton).CommandArgument)
            sqlConn02.Open()
            sqlCmd02.ExecuteNonQuery()
            sqlConn02.Close()
            'file exchange

            'fill new data
            bind02Files()
            'fill new data

            'display success message
            Alert("success", "File successfully remove.")
            'display success message

        End If
        'validate

    End Sub

    Protected Sub lbtn02Download(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create new folder
        If Not Directory.Exists(Server.MapPath("~/Assets/View/" & CIIS_EmpCode & "/")) Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/View/" & CIIS_EmpCode & "/"))
        End If
        'create new folder

        'remove file
        Dim DirectoryPath As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/View/" & CIIS_EmpCode & "/"))
        Dim Files As FileInfo
        For Each Files In DirectoryPath.GetFiles()
            Files.Delete()
        Next
        'remove file

        'transfer file
        File.Copy(Server.MapPath("~/Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/") & CType(sender, LinkButton).CommandArgument, Server.MapPath("~/Assets/View/" & CIIS_EmpCode & "/") & CType(sender, LinkButton).CommandArgument, True)
        'transfer file

        'view/download
        Dim View As String = EncryptionHelper.EncryptString("~/Assets/View/" & CIIS_EmpCode & "/" & CType(sender, LinkButton).CommandArgument)
        ScriptManager.RegisterStartupScript(upnl02Files, upnl02Files.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
        'view/download

    End Sub

#End Region

#Region "Upload"

    Protected Sub lbtn02CancelUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn02CancelUpload.Click

        'close modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl02Upload').modal('hide');</script>", False)
        'close modal

        'update records
        bind02Files()
        'update records

    End Sub

    Protected Sub lbtn02CloseUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn02CloseUpload.Click

        'close modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl02Upload').modal('hide');</script>", False)
        'close modal

        'update records
        bind02Files()
        'update records

    End Sub

#End Region

#End Region

#Region "Subscribers"

#Region "Subscribers"

    Function bind03Subscribers()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].monitored_by ")
        Query.Append("	 ,[A].monitored_by ")
        Query.Append("	 ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) ")
        Query.Append("	 ,isnull(dbo.ProperCase([B].JobDesc),'-') ")
        Query.Append("from ")
        Query.Append("	 oop_wo_dtl_monitor [A] ")
        Query.Append("   left join employee [B] on [A].monitored_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].wo_code = '" & ltrlID.Text & "' ")
        Query.Append("order by ")
        Query.Append("   [A].seq_no ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Approver"))
        dtable.Columns.Add(New DataColumn("JobDesc"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Icon As String
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(1) & ".png")) = True Then
                        Icon = "Assets/media/avatars/" & DR.GetString(1) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(1) & ".jpg")) = True Then
                        Icon = "Assets/media/avatars/" & DR.GetString(1) & ".jpg"
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    'add new row
                    Dim NewRowValues As Object() = {DR.GetString(0), Icon, DR.GetString(2), DR.GetString(3)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gv03Subscribers.DataSource = dtable
        gv03Subscribers.DataBind()
        'bind datatable 

        'display data
        upnl03Subscribers.Update()
        'display data

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv03Subscribers.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv03Subscribers.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv03Subscribers.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Protected Sub lbtn03Add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn03Add.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("03Subscribers", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'clear record
            bind03User()
            ddl03User.SelectedValue = ""
            'clear record

            'display modal
            mdl03User.Update()
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl03User').modal('show');</script>", False)
            'display modal

        End If
        'validate record

    End Sub

    Protected Sub lbtn03Delete(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("03Subscribers", "Delete", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Del_WRK_Monitor"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pMonitoredBy", CType(sender, LinkButton).CommandArgument)
            SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'fill new data
            bind03Subscribers()
            'fill new data

            'display success message
            Alert("success", "Record successfully remove.")
            'display success message

        End If
        'validate

    End Sub

#End Region

#Region "Modal User"

    Function bind03User()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select a user' [Text] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].emp_no [Value] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Text] ")
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
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl03User.DataSource = DT
        ddl03User.DataValueField = "Value"
        ddl03User.DataTextField = "Text"
        ddl03User.DataBind()
        'fill data

    End Function

    Protected Sub lbtn03AddUser_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn03AddUser.Click

        'create variable
        Dim Msg As String = Validate("03Subscribers", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'validate record
            If ddl03User.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            Else

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "New_WRK_Monitor"
                SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
                SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
                SqlCmd.Parameters.AddWithValue("@pMonitorBy", ddl03User.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
                'execute procedure

                'set value
                ddl03User.SelectedValue = ""
                'set value

                'display success message
                Alert("success", "Record successfully saved.")
                'display success message

                'refresh record
                bind03Subscribers()
                'refresh record

            End If
            'validate record

        End If
        'validate record

    End Sub

#End Region

#End Region

#Region "Approval Path"

    Function bind04ApprovalPath()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	[A].seq_no ")
        Query.Append("	,[A].type ")
        Query.Append("	,[A].approver ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) ")
        Query.Append("	,isnull(dbo.ProperCase([B].JobDesc),'-') ")
        Query.Append("	,(case when [A].status = '' then '-' else [A].status end) ")
        Query.Append("	,[A].NoDays ")
        Query.Append("	,isnull(convert(varchar(10), cast([A].DateStart as date), 101),'-') ")
        Query.Append("	,isnull(convert(varchar(10), cast([A].DateEnd as date), 101),'-') ")
        Query.Append("	,(case when [A].status in ('') then '-' else isnull(convert(varchar(10), cast([A].updated_date as date), 101),'-') end) ")
        Query.Append("	,(case when [A].Reason = '' then '-' else isnull([A].Reason,'-') end) ")
        Query.Append("	,(case when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) < cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger'  ")
        Query.Append("	       when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) >= cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success'  ")
        Query.Append("	       when [A].status in ('') then 'bullet bullet-margin bullet-vertical h-58px bg-secondary' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) < cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) >= cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success' end) ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_appr [A] ")
        Query.Append("   left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("   left join oop_form_hdr [C] on [A].f_code = [C].f_code ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
        Query.Append("order by ")
        Query.Append("  [A].seq_no ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Approver"))
        dtable.Columns.Add(New DataColumn("JobDesc"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("Duration"))
        dtable.Columns.Add(New DataColumn("DateStart"))
        dtable.Columns.Add(New DataColumn("DateEnd"))
        dtable.Columns.Add(New DataColumn("DateApproved"))
        dtable.Columns.Add(New DataColumn("Reason"))
        dtable.Columns.Add(New DataColumn("Bullet"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Icon As String
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(2) & ".png")) = True Then
                        Icon = "Assets/media/avatars/" & DR.GetString(2) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(2) & ".jpg")) = True Then
                        Icon = "Assets/media/avatars/" & DR.GetString(2) & ".jpg"
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    'add new row
                    Dim NewRowValues As Object() = {DR.GetInt32(0), DR.GetString(1), Icon, DR.GetString(3), DR.GetString(4), DR.GetString(5), DR.GetDecimal(6), DR.GetString(7), DR.GetString(8), DR.GetString(9), DR.GetString(10), DR.GetString(11)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gv04ApprovalPath.DataSource = dtable
        gv04ApprovalPath.DataBind()
        'bind datatable 

        'display data
        upnl04ApprovalPath.Update()
        'display data

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv04ApprovalPath.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gv04ApprovalPath.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv04ApprovalPath.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

#Region "Notes"

#Region "Notes"

    Function bind05Notes()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	[A].SeqNo ")
        Query.Append("	,[A].CreatedBy ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) ")
        Query.Append("	,Format([A].CreatedDate,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,[A].Remarks ")
        Query.Append("from ")
        Query.Append("	 Mstr_Remarks [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].FormCode = '" & ltrlFormCode.Text & "' ")
        Query.Append("   and [A].ID = '" & ltrlID.Text & "' ")
        Query.Append("order by ")
        Query.Append("  [A].SeqNo ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("By"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("Notes"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Icon As String
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(1) & ".png")) = True Then
                        Icon = "Assets/media/avatars/" & DR.GetString(1) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(1) & ".jpg")) = True Then
                        Icon = "Assets/media/avatars/" & DR.GetString(1) & ".jpg"
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    'add new row
                    Dim NewRowValues As Object() = {DR.GetInt32(0), Icon, DR.GetString(2), DR.GetString(3), DR.GetString(4)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)

                    blink01Notes.Style.Add("display", "")
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gv05Notes.DataSource = dtable
        gv05Notes.DataBind()
        'bind datatable 

        'display data
        upnl05Notes.Update()
        'display data

    End Function

    Protected Sub lbtn05Add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn05Add.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'clear record
        tbx05Note.Text = ""
        'clear record

        'display modal
        mdl05Comment.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl05Comment').modal('show');</script>", False)
        'display modal

    End Sub

#End Region

#Region "Comment"

    Protected Sub lbtn05AddNote_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn05AddNote.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'validate record
        If tbx05Note.Text = "" Then
            Alert("error", "Some fields are missing!")
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_Remarks"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSubID", "")
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx05Note.Text)
            SqlCmd.Parameters.AddWithValue("@pMention", hdnMention.Value)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'clear record
            tbx05Note.Text = ""
            hdnMention.Value = ""
            'clear record

            'display success message
            Alert("success", "Record successfully saved.")
            'display success message

            'refresh record
            bind05Notes()
            'refresh record

        End If
        'validate record

    End Sub

#End Region

#End Region

End Class