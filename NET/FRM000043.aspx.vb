Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.Emit
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Ajax.Utilities

Public Class FRM000043
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
        Master.setActiveMenu("APP", "FRM010000")
        'active account / menu

        'Record
        ltrlFormCode.Text = "FRM000043"
        'Record

        'load page
        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString().Replace("No", "#").Replace("No", "#")
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
            bind06History()
            'display record

        ElseIf IsPostBack = True Then
            'nothing
        Else

            'Record
            ltrlID.Text = ltrlID.Text
            ltrlMode.Text = ltrlMode.Text
            'Record

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

        'add record
        If ltrlMode.Text = "ADD" Then

            'set value
            lblTitle.Text = "Add record"
            lblID.Text = "0000000000000"
            lblStatus.Text = "New"
            If lblStatus.Text = "New" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
            ElseIf lblStatus.Text = "Requested" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
            ElseIf lblStatus.Text = "Endorsed" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
            ElseIf lblStatus.Text = "Approved" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
            ElseIf lblStatus.Text = "Implemented" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
            ElseIf lblStatus.Text = "Clarification" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
            ElseIf lblStatus.Text = "Cancelled" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
            ElseIf lblStatus.Text = "Declined" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
            ElseIf lblStatus.Text = "Accepted" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-success")
            End If
            'set value

        End If
        'add record

        'update record
        If ltrlMode.Text = "UPD" Then

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select")
            Query.Append("   f_code ")
            Query.Append("   ,formtitle ")
            Query.Append("   ,status ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr ")
            Query.Append("where ")
            Query.Append("   f_code = '" & ltrlID.Text & "' ")
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
                        lblTitle.Text = DR.GetString(1)
                        lblID.Text = DR.GetString(0)
                        lblStatus.Text = DR.GetString(2)
                        If lblStatus.Text = "New" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                        ElseIf lblStatus.Text = "Requested" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                        ElseIf lblStatus.Text = "Endorsed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Approved" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Implemented" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Clarification" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Cancelled" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Declined" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Accepted" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-success")
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
            Query.Append("   f_code ")
            Query.Append("   ,formtitle ")
            Query.Append("   ,isnull(status,'New') ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr ")
            Query.Append("where ")
            Query.Append("   f_code = '" & ltrlID.Text & "' ")
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
                        lblTitle.Text = DR.GetString(1)
                        lblID.Text = DR.GetString(0)
                        lblStatus.Text = DR.GetString(2)
                        If lblStatus.Text = "New" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                        ElseIf lblStatus.Text = "Requested" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                        ElseIf lblStatus.Text = "Endorsed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Approved" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Implemented" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Clarification" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Cancelled" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Declined" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                        ElseIf lblStatus.Text = "Accepted" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-success")
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

        If Group_ = "04ApprovalPath" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Clarification') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and seq_no = " & Value & ") in ('Approved') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save(ReasonForDelay)" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & CIIS_EmpCode & "' not in (select approver from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and seq_no = " & Value & ") ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Up" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and seq_no = " & Value & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Down" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and seq_no = " & Value & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
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

        If Group_ = "03Subscribers" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') not in ('New','Requested') ")
                Query.Append("begin ")
                Query.Append("   select 'Record cannot be deleted!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by) then 1 end) from oop_form_hdr where f_code = '" & ltrlID.Text & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Record cannot be deleted!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') not in ('New','Requested') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by) then 1 end) from oop_form_hdr where f_code = '" & ltrlID.Text & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Status" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by,approver) then 1 end) from oop_form_hdr where f_code = '" & ltrlID.Text & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & Value & "' in ('Approved','Clarify') and (select (case when '" + CIIS_EmpCode + "' not in (approver) then 1 end) from oop_form_hdr where f_code = '" & ltrlID.Text & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Extension" Then
                Query.Append("if (select isnull([B].IsExtension, 0) from oop_form_hdr [A] left join Form_HRF [B] on [A].tbl_code = [B].HRFCode where [A].f_code = '" & ltrlID.Text & "' and [A].tbl_from = 'Form_HRF') = 1 ")
                Query.Append("begin ")
                Query.Append("  select 'Already created an Extension Form!' ")
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
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none",
        "<script>
            setTimeout(function() {
            const Toast = Swal.mixin({
                toast:  true,
                position: 'top-end',
                iconColor: 'white',
                customClass: {
                    popup: 'colored-toast',
                },
                showConfirmButton: false,
                timer: 1500,
                timerProgressBar: true
            });
            Toast.fire({
                icon: '" & Alert_ & "',
                title: '" & Message_ & "'
            });
            " & If(Alert_ = "success", "$('#ContentPlaceHolder1_mdl01Status').modal('hide');$('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');window.opener.FRMUpdate('" & ltrlID.Text & "');", "") & "
            }, 200);
        </script>", False)
    End Function

    Function EnableBtn()

        'overview
        lbtn01Find.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Refresh.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-danger align-self-center m-1"
        lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
        lbtn01Status.CssClass = "btn btn-sm btn-secondary align-self-center m-1"
        lbtn01Extension.CssClass = "btn btn-sm btn-secondary align-self-center m-1"
        'overview

        'file
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'file

        'copy furnished
        lbtn03Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'copy furnished

        'approval path
        lbtn04Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'approval path

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
        lbtn01Status.CssClass = "btn btn-sm btn-white align-self-center m-1"
        lbtn01Extension.CssClass = "btn btn-sm btn-white align-self-center m-1"
        'overview

        'file
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'file

        'copy furnished
        lbtn03Add.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'copy furnished

        'approval path
        lbtn04Add.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'approval path

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

        'add record
        If ltrlMode.Text = "ADD" Then

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
            'display fields

            'set value
            tbx01ID.Text = "0000000000000"
            tbx01FormType.Text = "Holding Request"
            tbx01DateRequested.Text = Format(Date.Now, "MM/dd/yyyy")
            tbx01DateRequired.Value = Format(Date.Now, "MM/dd/yyyy")
            tbx01RequestedBy.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01AssignedTo.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01EndorsedTo.Text = "-"
            tbx01Status.Text = "New"
            bind01Department()
            tbx01ReferenceForm.Text = ""
            tbx01HoldingDuration.Value = ""
            ddl01Department.SelectedValue = ""
            ddl01Category.SelectedValue = ""
            tbx01Project.Value = ""
            tbx01LotCode.Value = ""
            tbx01Remarks.Text = ""
            'set value

        End If
        'add record

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
            Query.Append("   [A].f_code ")
            Query.Append("   ,[A].created_date ")
            Query.Append("   ,[A].date_required ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) ")
            Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) ")
            Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) ")
            Query.Append("   ,[A].status ")
            Query.Append("   ,ISNULL(Format([B].HoldingDuration, 'MM/dd/yyyy'), '') [HoldingDuration] ")
            Query.Append("   ,[B].Department [Department] ")
            Query.Append("   ,[B].Category [Category] ")
            Query.Append("   ,ISNULL([B].Project, '') [Project] ")
            Query.Append("   ,ISNULL([B].LotCode, '') [LotCode] ")
            Query.Append("   ,[B].Remarks [Remarks] ")
            Query.Append("   ,ISNULL([B].ReferenceNo, '') [ReferenceNo] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join Form_HRF [B] on [A].tbl_code = [B].HRFCode ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
            'get total task

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        tbx01ID.Text = DR.GetString(0)
                        tbx01FormType.Text = "Holding Request"
                        tbx01DateRequested.Text = Format(DR.GetDateTime(1), "MM/dd/yyyy")
                        tbx01DateRequired.Value = Format(DR.GetDateTime(2), "MM/dd/yyyy")
                        tbx01RequestedBy.Text = DR.GetString(3)
                        tbx01AssignedTo.Text = DR.GetString(4)
                        tbx01EndorsedTo.Text = DR.GetString(5)
                        tbx01Status.Text = DR.GetString(6)
                        tbx01HoldingDuration.Value = DR("HoldingDuration")
                        bind01Department()
                        ddl01Department.SelectedValue = DR("Department")
                        ddl01Category.SelectedValue = DR("Category")
                        tbx01Project.Value = DR("Project")
                        tbx01LotCode.Value = DR("LotCode")
                        tbx01Remarks.Text = DR.GetString(13)
                        If DR("ReferenceNo") <> "" Then
                            div01ReferenceForm.Style("display") = ""
                            tbx01ReferenceForm.Text = DR("ReferenceNo")
                        Else
                            div01ReferenceForm.Style("display") = "none"
                        End If
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
            div02ReferenceForm.Style("display") = "none"
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
            lbl01ReferenceForm.Text = "-"
            lbl01HoldingDuration.Text = "-"
            lbl01Department.Text = "-"
            lbl01Category.Text = "-"
            lbl01Project.Text = "-"
            lbl01LotCode.Text = "-"
            lbl01Remarks.Text = "-"
            'set value

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select")
            Query.Append("   [A].f_code ")
            Query.Append("   ,[A].created_date ")
            Query.Append("   ,[A].date_required ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) ")
            Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) ")
            Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) ")
            Query.Append("   ,isnull([A].status,'New') [Status] ")
            Query.Append("   ,isnull(Format([B].HoldingDuration, 'MM/dd/yyyy'), '') [HoldingDuration] ")
            Query.Append("   ,[F].description [Department] ")
            Query.Append("   ,[B].Category ")
            Query.Append("   ,ISNULL([B].Project, '') [Project] ")
            Query.Append("   ,ISNULL([B].LotCode, '') [LotCode] ")
            Query.Append("   ,[B].Remarks ")
            Query.Append("   ,isnull([B].ReferenceNo, '') [ReferenceNo] ")
            Query.Append("   ,[B].Department [DeptCode] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join Form_HRF [B] on [A].tbl_code = [B].HRFCode ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("   left join oop_category [F] on [B].Department = [F].c_code ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
            'get total task

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        lbl01ID.Text = DR.GetString(0)
                        lbl01FormType.Text = "Holding Request"
                        lbl01DateRequested.Text = Format(DR.GetDateTime(1), "MM/dd/yyyy")
                        lbl01DateRequired.Text = Format(DR.GetDateTime(2), "MM/dd/yyyy")
                        lbl01RequestedBy.Text = DR.GetString(3)
                        lbl01AssignedTo.Text = DR.GetString(4)
                        lbl01EndorsedTo.Text = DR.GetString(5)
                        lbl01Status.Text = DR.GetString(6)
                        lbl01HoldingDuration.Text = DR("HoldingDuration")
                        hf01HoldingDuration.Value = DR("HoldingDuration")
                        lbl01Department.Text = DR("Department")
                        lbl01Category.Text = DR("Category")
                        lbl01Project.Text = DR("Project")
                        lbl01LotCode.Text = DR("LotCode")
                        lbl01Remarks.Text = DR("Remarks")
                        If DR("ReferenceNo") <> "" Then
                            div02ReferenceForm.Style("display") = ""
                            lbl01ReferenceForm.Text = DR("ReferenceNo")
                        Else
                            div02ReferenceForm.Style("display") = "none"
                            lbl01ReferenceForm.Text = ""
                        End If
                        hf01Department.Value = DR("DeptCode")
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

    Function bind01Department()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select department' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [c_code] [Value] ")
        Query.Append("	 ,[description] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 [oop_category] ")
        Query.Append("where ")
        Query.Append("   Active = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Department.DataSource = DT
        ddl01Department.DataValueField = "Value"
        ddl01Department.DataTextField = "Text"
        ddl01Department.DataBind()
        'fill data

    End Function

    Protected Sub lbtn01Find_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Find.Click

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
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
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'display record
        bindTitle()
        bind01Overview()
        bind02Files()
        bind03Subscribers()
        bind04ApprovalPath()
        bind05Notes()
        bind06History()
        'display record

    End Sub

    Protected Sub lbtn01Add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Add.Click

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
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
        bind06History()
        'display add

    End Sub

    Protected Sub lbtn01Delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Delete.Click

        'cancel record
        If ltrlMode.Text = "ADD" Then

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
            ElseIf ltrlID.Text = "0000000000000" Or ltrlFormCode.Text = "" Then
                Alert("error", "No active form found!")
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

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

        'cancel record
        If ltrlMode.Text = "ADD" Then

            'Record
            ltrlID.Text = "0000000000000"
            ltrlMode.Text = "DTL"
            'Record

            'hide modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');</script>", False)
            'hide modal

            'display record
            bindTitle()
            bind01Overview()
            bind02Files()
            bind03Subscribers()
            bind04ApprovalPath()
            bind05Notes()
            bind06History()
            'display record

            Exit Sub

        End If
        'cancel record

        'cancel record
        If ltrlMode.Text = "UPD" Then

            'Record
            ltrlMode.Text = "DTL"
            'Record

            'hide modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');</script>", False)
            'hide modal

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
            bind06History()
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
            ElseIf ddl01Department.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Category.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Project.Value = "" Then
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
            ElseIf ddl01Department.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Category.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Project.Value = "" Then
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

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

        'cancel record
        If ltrlMode.Text = "ADD" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_FRM000043"
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Value)
            SqlCmd.Parameters.AddWithValue("@pDepartment", ddl01Department.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pCategory", ddl01Category.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pProject", tbx01Project.Value)
            SqlCmd.Parameters.AddWithValue("@pLotCode", tbx01LotCode.Value)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Remarks.Text)
            SqlCmd.Parameters.AddWithValue("@pReference", tbx01ReferenceForm.Text)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            Dim oFCode As New SqlClient.SqlParameter("@oFCode", SqlDbType.NVarChar, 1000)
            oFCode.Direction = ParameterDirection.Output
            SqlCmd.Parameters.Add(oFCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'Record
            ltrlID.Text = oFCode.Value.ToString
            ltrlMode.Text = "DTL"
            'Record

            'success alert
            Alert("success", "Record successfully saved.")
            'success alert

            'display record
            bindTitle()
            bind01Overview()
            bind02Files()
            bind03Subscribers()
            bind04ApprovalPath()
            bind05Notes()
            bind06History()
            'display record

            Exit Sub

        End If
        'cancel record

        'cancel record
        If ltrlMode.Text = "UPD" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_FRM_FRM000043"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Value)
            SqlCmd.Parameters.AddWithValue("@pDepartment", ddl01Department.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pCategory", ddl01Category.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pProject", tbx01Project.Value)
            SqlCmd.Parameters.AddWithValue("@pLotCode", tbx01LotCode.Value)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Remarks.Text)
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
            bind06History()
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
            ddl01Status.Items.Clear()
            bind01StatusItem()
            ddl01Status.SelectedValue = ""
            bind01ClarifyTo()
            ddl01ClarifyTo.SelectedValue = ""
            pnl01ClarifyTo.Visible = False
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

    Protected Sub lbtn01Extension_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn01Extension.Click

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

        'validation
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validation

        'variable
        Dim Msg As String = Validate("01Overview", "Extension", "")
        'variable

        If Msg <> "" Then
            Alert("error", Msg)
        Else

            If lbl01Department.Text = "" Or hf01Department.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf lbl01Category.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf lbl01Project.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf lbl01LotCode.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf lbl01ID.Text = "" Then
                Alert("error", "Some fields are missing!")
            Else

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "New_FRM_FRM000043_Extension"
                SqlCmd.Parameters.AddWithValue("@pDepartment", hf01Department.Value)
                SqlCmd.Parameters.AddWithValue("@pCategory", lbl01Category.Text)
                SqlCmd.Parameters.AddWithValue("@pProject", lbl01Project.Text)
                SqlCmd.Parameters.AddWithValue("@pLotCode", lbl01LotCode.Text)
                SqlCmd.Parameters.AddWithValue("@pRemarks", lbl01Remarks.Text)
                SqlCmd.Parameters.AddWithValue("@pFCode", ltrlID.Text)
                SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                Dim oFCode As New SqlClient.SqlParameter("@oFCode", SqlDbType.NVarChar, 1000)
                oFCode.Direction = ParameterDirection.Output
                SqlCmd.Parameters.Add(oFCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
                'execute procedure

                'redirect
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({title: 'Success',html: 'Successfully created a Holding Form Extension. Continue to View the Form: <strong>" & oFCode.Value.ToString() & "</strong>',icon: 'success',showCancelButton: true,confirmButtonText: 'Proceed',customClass: {confirmButton: 'btn btn-primary',cancelButton: 'btn btn-secondary'}}).then((result) => { if(result.isConfirmed) { window.location.href = 'FRM000043-DTL-" & oFCode.Value.ToString() & "' }; });</script>", False)
                'redirect

            End If

        End If

    End Sub

#End Region

#Region "Modal Find"

    Function bind01Find()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_HRF' ")
        Query.Append("      and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_HRF' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_dtl_monitor [M] ")
        Query.Append("	    left join oop_form_hdr [A] on [M].f_code = [A].f_code ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_HRF' ")
        Query.Append("      and [M].monitored_by = '" & CIIS_EmpCode & "') [A] ")
        Query.Append("order by ")
        Query.Append("   [ID] ")
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
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
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
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, Link, Icon, Title, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

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

    Function bind01StatusItem()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("if (select top 1 created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and status = '') in ('Endorsed By','Approved By','Implementer') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Approved' [Code] ")
        Query.Append("      ,'Approve' [Name] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Clarify' [Code] ")
        Query.Append("      ,'Clarify' [Name] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Cancelled' [Code] ")
        Query.Append("      ,'Cancel' [Name] ")
        Query.Append("end ")
        Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and status = '') in ('Clarification') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("   union")
        Query.Append("   select")
        Query.Append("      'Reply' [Code] ")
        Query.Append("      ,'Reply' [Name] ")
        Query.Append("end ")
        Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('" & CIIS_EmpCode & "') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Cancelled' [Code] ")
        Query.Append("      ,'Cancel' [Name] ")
        Query.Append("end ")
        Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and status = '') in ('Endorsed By','Approved By','Implementer') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Approved' [Code] ")
        Query.Append("      ,'Approve' [Name] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Clarify' [Code] ")
        Query.Append("      ,'Clarify' [Name] ")
        Query.Append("end ")
        Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and status = '') in ('Clarification') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("   union")
        Query.Append("   select")
        Query.Append("      'Reply' [Code] ")
        Query.Append("      ,'Reply' [Name] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("end ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Status.DataSource = DT
        ddl01Status.DataValueField = "Code"
        ddl01Status.DataTextField = "Name"
        ddl01Status.DataBind()
        'fill data

    End Function

    Function bind01ClarifyTo()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a user' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].created_by [Code] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
        Query.Append("   and [A].created_by not in ('" & CIIS_EmpCode & "') ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].approver [Code] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   oop_form_dtl_appr [A] ")
        Query.Append("   left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
        Query.Append("   and [A].approver not in ('" & CIIS_EmpCode & "') ")
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
        ddl01ClarifyTo.DataSource = DT
        ddl01ClarifyTo.DataValueField = "Code"
        ddl01ClarifyTo.DataTextField = "Name"
        ddl01ClarifyTo.DataBind()
        'fill data

    End Function

    Private Sub ddl01Status_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl01Status.SelectedIndexChanged

        'reset 
        ddl01ClarifyTo.SelectedValue = ""
        pnl01ClarifyTo.Visible = False
        'reset 

        'display Assigned To
        If ddl01Status.SelectedValue = "Clarify" Then

            ddl01ClarifyTo.SelectedValue = ""
            pnl01ClarifyTo.Visible = True
        End If
        'display Assigned To

        'update data
        mdl01Status.Update()
        'update data

    End Sub

    Protected Sub lbtn01SaveStatus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01SaveStatus.Click

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

        'validate fields
        If ddl01Status.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
        ElseIf ddl01Status.SelectedValue = "Clarify" And ddl01ClarifyTo.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
        Else

            'create variable
            Dim Msg As String = Validate("01Overview", "Status", ddl01Status.SelectedValue)
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
                SqlCmd.CommandText = "Upd_FRM_Status"
                SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
                SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
                SqlCmd.Parameters.AddWithValue("@pStatus", ddl01Status.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pAssignTo", ddl01ClarifyTo.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Note.Text)
                SqlCmd.Parameters.AddWithValue("@pMention", hdnMention.Value)
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
                'execute procedure

                If ddl01Status.SelectedValue = "Approved" Then

                End If

                'clear record
                ddl01Status.SelectedValue = ""
                pnl01ClarifyTo.Visible = False
                ddl01ClarifyTo.SelectedValue = ""
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
                bind06History()
                'refresh record

            End If
            'validate record

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

                'blink01Attachment.Style.Add("display", "")
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

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

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
            Dim FilePath As String = Server.MapPath("~/Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/") & hfFileName.Value
            File.Delete(FilePath)
            'remove file

            'create connection
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
            SqlCmd01.Parameters.AddWithValue("@pDescription", hfFileName.Value)
            SqlCmd01.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn01.Open()
            SqlCmd01.ExecuteNonQuery()
            SqlConn01.Close()
            'execute procedure

            'fill new data
            bind02Files()
            bind06History()
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

        'create connection
        Dim SqlConn01 As New SqlClient.SqlConnection
        Dim SqlCmd01 As New SqlCommand
        SqlConn01.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd01.CommandTimeout = 1500
        SqlCmd01.Connection = SqlConn01
        SqlCmd01.CommandType = CommandType.StoredProcedure
        SqlCmd01.CommandText = "Download_File"
        SqlCmd01.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
        SqlCmd01.Parameters.AddWithValue("@pID", ltrlID.Text)
        SqlCmd01.Parameters.AddWithValue("@pType", "Downloaded a file:")
        SqlCmd01.Parameters.AddWithValue("@pDescription", CType(sender, LinkButton).CommandArgument)
        SqlCmd01.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn01.Open()
        SqlCmd01.ExecuteNonQuery()
        SqlConn01.Close()
        'execute procedure

        'fill new data
        bind06History()
        'fill new data

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

    Protected Sub lbtn02UploadSave_Click(ByVal sender As Object, e As EventArgs)
        bind02Files()
        bind06History()
    End Sub

#End Region

#End Region

#Region "Subscribers"

#Region "Subscribers"

    Function bind03Subscribers()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 [A].monitored_by [Code] ")
        Query.Append("	 ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	 ,isnull(dbo.ProperCase([B].JobDesc),'-') [JobDesc] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_monitor [A] ")
        Query.Append("   left join employee [B] on [A].monitored_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
        Query.Append("order by ")
        Query.Append("   [A].seq_no ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
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
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("Code") & ".png")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Code") & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("Code") & ".jpg")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Code") & ".jpg"
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    'add new row
                    Dim NewRowValues As Object() = {DR("Code"), Icon, DR("Name"), DR("JobDesc")}
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
            SqlCmd.CommandText = "Del_FRM_Monitor"
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
            bind06History()
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
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl03User.DataSource = DT
        ddl03User.DataValueField = "Code"
        ddl03User.DataTextField = "Name"
        ddl03User.DataBind()
        'fill data

    End Function

    Protected Sub lbtn03AddUser_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn03AddUser.Click

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

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
                SqlCmd.CommandText = "New_FRM_Monitor"
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
                bind06History()
                'refresh record

            End If
            'validate record

        End If
        'validate record

    End Sub

#End Region

#End Region

#Region "Approval Path"

#Region "Approval Path"

    Function bind04ApprovalPath()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	(case when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) < cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger'  ")
        Query.Append("	       when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) >= cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success'  ")
        Query.Append("	       when [A].status in ('') then 'bullet bullet-margin bullet-vertical h-58px bg-secondary' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) < cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) >= cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success' end) [Bullet] ")
        Query.Append("	,[A].seq_no [SeqNo] ")
        Query.Append("	,[A].type [Type] ")
        Query.Append("	,[A].approver [Icon] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [ApprName] ")
        Query.Append("	,isnull(dbo.ProperCase([B].JobDesc),'-') [ApprJob] ")
        Query.Append("	,(case when [A].status = '' then '-' else [A].status end) [ApprStatus] ")
        Query.Append("	,(case when [A].status = '' then '-' else format([A].updated_date,'MM/dd/yy') end) [ApprDate] ")
        Query.Append("	,(case when [A].status = '' and [A].approver = [C].approver then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') when [A].status not in ('') then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') else '-' end ) [Coverage] ")
        Query.Append("	,format([A].NoDays,'N1') [Duration] ")
        Query.Append("	,(case when [A].Reason = '' then '-' else isnull([A].Reason,'-') end) [Reason] ")
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
        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("ApprName"))
        dtable.Columns.Add(New DataColumn("ApprJob"))
        dtable.Columns.Add(New DataColumn("ApprStatus"))
        dtable.Columns.Add(New DataColumn("ApprDate"))

        dtable.Columns.Add(New DataColumn("Coverage"))
        dtable.Columns.Add(New DataColumn("Duration"))

        dtable.Columns.Add(New DataColumn("Reason"))

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
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("Icon") & ".png")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Icon") & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("Icon") & ".jpg")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Icon") & ".jpg"
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    'add new row
                    Dim NewRowValues As Object() = {DR("Bullet"), DR("SeqNo"), DR("Type"), Icon, DR("ApprName"), DR("ApprJob"), DR("ApprStatus"), DR("ApprDate"), DR("Coverage"), DR("Duration"), DR("Reason")}
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

    Protected Sub lbtn04Add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn04Add.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("04ApprovalPath", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'clear record
            ddl04AddFrom.SelectedValue = ""
            pnl04Type.Visible = False
            ddl04Type.SelectedValue = ""
            pnl04AssignTo.Visible = False
            bind04Approver("")
            ddl04Approver.SelectedValue = ""
            pnl04NoDays.Visible = False
            tbx04NoDays.Value = "0.00"
            pnl04Template.Visible = False
            bind04Template()
            ddl04Template.SelectedValue = ""
            'clear record

            'display modal
            mdl04Approver.Update()
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl04Approver').modal('show');</script>", False)
            'display modal

        End If
        'validate record

    End Sub

    Protected Sub lbtn04Delete(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("04ApprovalPath", "Delete", CType(sender, LinkButton).CommandArgument)
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
            SqlCmd.CommandText = "Del_FRM_Approver"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", CType(sender, LinkButton).CommandArgument)
            SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'fill new data
            bind04ApprovalPath()
            bind06History()
            'fill new data

            'display success message
            Alert("success", "Record successfully remove.")
            'display success message

        End If
        'validate

    End Sub

    Protected Sub lbtn04Update(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg01 As String = Validate("04ApprovalPath", "Save(ReasonForDelay)", CType(sender, LinkButton).CommandArgument)
        'create variable

        'validate record
        If Msg01 <> "" Then
            Alert("error", Msg01)
        Else

            'clear record
            ltrlSeqNo.Text = CType(sender, LinkButton).CommandArgument
            bindReasonForDelay(CType(sender, LinkButton).CommandArgument)
            'clear record

            'display modal
            mdl04ReasonForDelay.Update()
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl04ReasonForDelay').modal('show');</script>", False)
            'display modal

        End If
        'validate

    End Sub

    Protected Sub lbtn04Up(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("04ApprovalPath", "Up", CType(sender, LinkButton).CommandArgument)
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
            SqlCmd.CommandText = "Upd_FRM_MoveApprover"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", CType(sender, LinkButton).CommandArgument)
            SqlCmd.Parameters.AddWithValue("@pMove", "Up")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute query
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute query

            'fill record
            bind01Overview()
            bind04ApprovalPath()
            bind06History()
            'fill record

            'display success message
            Alert("success", "Record successfully moved.")
            'display success message

        End If
        'validate

    End Sub

    Protected Sub lbtn04Down(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("04ApprovalPath", "Down", CType(sender, LinkButton).CommandArgument)
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
            SqlCmd.CommandText = "Upd_FRM_MoveApprover"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", CType(sender, LinkButton).CommandArgument)
            SqlCmd.Parameters.AddWithValue("@pMove", "Down")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute query
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute query

            'fill record
            bind01Overview()
            bind04ApprovalPath()
            bind06History()
            'fill record

            'display success message
            Alert("success", "Record successfully moved.")
            'display success message

        End If
        'validate

    End Sub

#End Region

#Region "Approver"

    Function bind04Approver(Type As String)

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("if '" & ltrlFormCode.Text & "' not in (select oop_form_type.FormCode from oop_form_appr left join oop_form_type on oop_form_appr.form_type = oop_form_type.t_code where oop_form_type.FormCode = '" & ltrlFormCode.Text & "' and oop_form_appr.type = '" & Type & "') ")
        Query.Append("begin ")
        Query.Append("   select")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a user' [Name] ")
        Query.Append("      ,'' [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      [A].emp_no [Code] ")
        Query.Append("      ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
        Query.Append("      ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
        Query.Append("   from ")
        Query.Append("      employee [A] ")
        Query.Append("   where ")
        Query.Append("      [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("      and [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a user' [Name] ")
        Query.Append("      ,'' [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      [A].approver [Code] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
        Query.Append("   from ")
        Query.Append("      oop_form_appr [A] ")
        Query.Append("      left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("      left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("   where ")
        Query.Append("      [C].FormCode = '" & ltrlFormCode.Text & "' ")
        Query.Append("      and [A].type = '" & Type & "' ")
        Query.Append("      and [B].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("      and [B].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("end")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl04Approver.DataSource = DT
        ddl04Approver.DataValueField = "Code"
        ddl04Approver.DataTextField = "Name"
        ddl04Approver.DataBind()
        'fill data

    End Function

    Function bind04Template()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a template' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].Code [Code] ")
        Query.Append("   ,[A].Title [Name] ")
        Query.Append("   ,[A].Title [Order] ")
        Query.Append("from ")
        Query.Append("   Mstr_AppPathTempHdr [A] ")
        Query.Append("where ")
        Query.Append("   [A].FormCode = '" & ltrlFormCode.Text & "' ")
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
        ddl04Template.DataSource = DT
        ddl04Template.DataValueField = "Code"
        ddl04Template.DataTextField = "Name"
        ddl04Template.DataBind()
        'fill data

    End Function

    Private Sub ddl04AddFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl04AddFrom.SelectedIndexChanged

        'clear record
        pnl04Type.Visible = False
        ddl04Type.SelectedValue = ""
        pnl04AssignTo.Visible = False
        ddl04Approver.SelectedValue = ""
        pnl04NoDays.Visible = False
        tbx04NoDays.Value = "0.00"
        pnl04Template.Visible = False
        ddl04Template.SelectedValue = ""
        'clear record

        If ddl04AddFrom.SelectedValue = "Manual" Then
            pnl04Type.Visible = True
            ddl04Type.SelectedValue = ""
            pnl04AssignTo.Visible = True
            ddl04Approver.SelectedValue = ""
            pnl04NoDays.Visible = True
            tbx04NoDays.Value = "0.00"
        End If

        If ddl04AddFrom.SelectedValue = "Template" Then
            pnl04Template.Visible = True
            ddl04Template.SelectedValue = ""
        End If

    End Sub

    Private Sub ddl04Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl04Type.SelectedIndexChanged

        'reset 
        bind04Approver(ddl04Type.SelectedValue)
        ddl04Approver.SelectedValue = ""
        'reset 

        'update data
        mdl04Approver.Update()
        'update data

    End Sub

    Protected Sub lbtn04AddApprover_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn04AddApprover.Click

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'validate record
        If ddl04AddFrom.SelectedValue = "" Then
            Alert("error", "Some fields are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Manual" And ddl04Type.SelectedValue = "" Then
            Alert("error", "Some fields are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Manual" And ddl04Approver.SelectedValue = "" Then
            Alert("error", "Some fields are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Manual" And CDbl(tbx04NoDays.Value) <= 0 Then
            Alert("error", "Some fields are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Template" And ddl04Template.SelectedValue = "" Then
            Alert("error", "Some fields are missing!")
        Else

            'create variable
            Dim Msg As String = Validate("04ApprovalPath", "Add", "")
            'create variable

            'validate record
            If Msg <> "" Then
                Alert("error", Msg)
            Else

                If ddl04AddFrom.SelectedValue = "Manual" Then

                    'create connection
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim SqlCmd As New SqlCommand
                    SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.Connection = SqlConn
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandText = "New_FRM_Approver"
                    SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
                    SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
                    SqlCmd.Parameters.AddWithValue("@pType", ddl04Type.SelectedValue)
                    SqlCmd.Parameters.AddWithValue("@pApprover", ddl04Approver.SelectedValue)
                    SqlCmd.Parameters.AddWithValue("@pNoDays", tbx04NoDays.Value)
                    SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                    'create connection

                    'execute procedure
                    SqlConn.Open()
                    SqlCmd.ExecuteNonQuery()
                    SqlConn.Close()
                    'execute procedure

                End If

                If ddl04AddFrom.SelectedValue = "Template" Then

                    'create connection
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim SqlCmd As New SqlCommand
                    SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.Connection = SqlConn
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandText = "New_FRM_ApproverTemplate"
                    SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
                    SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
                    SqlCmd.Parameters.AddWithValue("@pTemplate", ddl04Template.SelectedValue)
                    SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                    'create connection

                    'execute procedure
                    SqlConn.Open()
                    SqlCmd.ExecuteNonQuery()
                    SqlConn.Close()
                    'execute procedure

                End If

                'clear record
                ddl04Type.SelectedValue = ""
                ddl04Approver.SelectedValue = ""
                tbx04NoDays.Value = "0.00"
                ddl04Template.SelectedValue = ""
                'clear record

                'display success message
                Alert("success", "Record successfully saved.")
                'display success message

                'refresh record
                bind01Overview()
                bind04ApprovalPath()
                bind06History()
                'refresh record

            End If
            'validate record

        End If
        'validate record

    End Sub

#End Region

#Region "Reason For Delay"

    Function bindReasonForDelay(SeqNo As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   isnull(Reason,'') ")
        Query.Append("from ")
        Query.Append("   oop_form_dtl_appr ")
        Query.Append("where ")
        Query.Append("   f_code = '" & ltrlID.Text & "' ")
        Query.Append("   and seq_no = '" & ltrlSeqNo.Text & "' ")
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
                    tbx04ReasonForDelay.Text = DR.GetString(0)
                    'set value

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Protected Sub lbtn04SaveReasonForDelay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn04SaveReasonForDelay.Click

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("04ApprovalPath", "Save(ReasonForDelay)", ltrlSeqNo.Text)
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
            SqlCmd.CommandText = "Upd_FRM_ReasonForDelay"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", ltrlSeqNo.Text)
            SqlCmd.Parameters.AddWithValue("@pReason", tbx04ReasonForDelay.Text)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'display success message
            Alert("success", "Record successfully saved.")
            'display success message

            'refresh record
            bind04ApprovalPath()
            bind06History()
            'refresh record

        End If
        'validate record

    End Sub

#End Region

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

        'threading
        System.Threading.Thread.Sleep(1000)
        'threading

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
            bind06History()
            'refresh record

        End If
        'validate record

    End Sub

#End Region

#End Region

#Region "History"

    Function bind06History()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	[A].CreatedDate [SeqNo01] ")
        Query.Append("	,0 [SeqNo02] ")
        Query.Append("	,[A].CreatedBy [Icon01] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	,Format([A].CreatedDate,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,'V2' [Version] ")
        Query.Append("	,[A].Type [Icon02] ")
        Query.Append("	,[A].Type ")
        Query.Append("	,[A].Description ")
        Query.Append("from ")
        Query.Append("	 Mstr_History [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TblName = '" & ltrlFormCode.Text & "' ")
        Query.Append("   and [A].TblCode = '" & ltrlID.Text & "' ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("	[A].updated_Date [SeqNo01] ")
        Query.Append("	,[A].seq_no [SeqNo02] ")
        Query.Append("	,[A].updated_by [Icon] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	,Format([A].updated_Date,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,'V1' [Version] ")
        Query.Append("	,[A].field [Icon02] ")
        Query.Append("	,[A].field [Type] ")
        Query.Append("	,[A].change [Description] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_history [A] ")
        Query.Append("   left join employee [B] on [A].updated_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
        Query.Append("order by ")
        Query.Append("  [SeqNo01] ")
        Query.Append("  ,[SeqNo02] ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon01"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("Class02"))
        dtable.Columns.Add(New DataColumn("Icon02"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Description"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Icon01 As String
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("Icon01") & ".png")) = True Then
                        Icon01 = "Assets/media/avatars/" & DR("Icon01") & ".png"
                    Else
                        Icon01 = "Assets/media/avatars/blank.png"
                    End If

                    Dim Class02 As String
                    Dim Icon02 As String

                    If DR("Version") = "V1" And DR("Icon02") = "New Form" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-file-alt"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Assigned To" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Endorsed To" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Relation" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-sitemap"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Upload") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Download") Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Delete") Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Form Monitor" And DR("Description").ToString.Contains("Start Monitored") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V1" And (DR("Icon02") = "Form Monitor" And DR("Description").ToString.Contains("End Monitored")) Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Add Approver") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Remove Approver:") Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Move Approver") Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Note Added" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-comment"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Approved") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Clarify") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Declined") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Reply") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" Then
                        Class02 = "symbol-label bg-warning"
                        Icon02 = "fs-1 text-white las la-pencil-alt"
                    End If

                    If DR("Version") = "V2" And DR("Icon02") = "Form Created:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-file-alt"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Assigned to:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Uploaded a file:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Downloaded a file:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed a file:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added a subscriber:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed a subscriber:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added a approver:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed a approver:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Moved a approver up:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Moved a approver down:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added a note:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-comment"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Approved:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Clarify:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Declined:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Reply:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" Then
                        Class02 = "symbol-label bg-warning"
                        Icon02 = "fs-1 text-white las la-pencil-alt"
                    End If

                    'add new row
                    Dim NewRowValues As Object() = {Icon01, DR("Name"), DR("Date"), Class02, Icon02, DR("Type"), DR("Description")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gv06History.DataSource = dtable
        gv06History.DataBind()
        'bind datatable 

        'display data
        upnl06History.Update()
        'display data

    End Function

#End Region

#Region "Request Extension"

#End Region

End Class