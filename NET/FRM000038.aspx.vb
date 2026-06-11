Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FRM000038
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

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
        Master.setActiveMenu("APP", "001001")
        'active account / menu

        'Record
        ltrlFormCode.Text = "FRM000038"
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
            bind06History()
            'display record

        Else
            'nothing
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

        If Group_ = "06NODDtl" Then

            'get total task
            If Type = "Add" Then
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
            'get total task

        End If

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
                    " & IIf(Alert_ = "success", "$('#ContentPlaceHolder1_mdl01Status').modal('hide');", "console.log('Error');") & "
              }
            });
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

            'displa fields

            'set value
            tbx01ID.Text = "0000000000000"
            tbx01FormType.Text = "Notice of Delay"
            tbx01DateRequested.Text = Format(Date.Now, "MM/dd/yyyy")
            tbx01DateRequired.Value = Format(Date.Now, "MM/dd/yyyy")
            tbx01RequestedBy.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01AssignedTo.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01EndorsedTo.Text = "-"
            tbx01Status.Text = "New"

            ddl01Notice.SelectedValue = ""

            tbx01OtherReason.Text = ""
            tbx01Instruction.Text = ""
            'set value

            'bind
            bind01Contractor()
            'bind

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
            Query.Append("select ")
            Query.Append("  (case when [Project] is null or [Project] = '' then [Alternate] else [Project] end) [Project] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[DateCreated] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[RequestedBy] ")
            Query.Append("  ,[AssignedTo] ")
            Query.Append("  ,[EndorsedTo] ")
            Query.Append("  ,[Status] ")
            Query.Append("  ,[Notice] ")
            Query.Append("  ,[ConType] ")
            Query.Append("  ,[Contractor] ")
            Query.Append("  ,[NTPNo] ")
            Query.Append("  ,[NTPDate] ")
            Query.Append("  ,[ActualDate] ")
            Query.Append("  ,[ApprovedExtension] ")
            Query.Append("  ,[Address] ")
            Query.Append("  ,[ConNo] ")
            Query.Append("  ,[ConPrice] ")
            Query.Append("  ,[OrigDate] ")
            Query.Append("  ,[RevDate] ")
            Query.Append("  ,[POCDate] ")
            Query.Append("  ,[POCTarget] ")
            Query.Append("  ,[POCActual] ")
            Query.Append("  ,[POCSlippage] ")
            Query.Append("  ,[VOCTarget] ")
            Query.Append("  ,[VOCActual] ")
            Query.Append("  ,[VOCSlippage] ")
            Query.Append("  ,[DelayedWork01] ")
            Query.Append("  ,[Slippage01] ")
            Query.Append("  ,[ActionTaken01] ")
            Query.Append("  ,[Timetable01] ")

            Query.Append("  ,[DelayedWork02] ")
            Query.Append("  ,[Slippage02] ")
            Query.Append("  ,[ActionTaken02] ")
            Query.Append("  ,[Timetable02] ")

            Query.Append("  ,[DelayedWork03] ")
            Query.Append("  ,[Slippage03] ")
            Query.Append("  ,[ActionTaken03] ")
            Query.Append("  ,[Timetable03] ")

            Query.Append("  ,[DelayedWork04] ")
            Query.Append("  ,[Slippage04] ")
            Query.Append("  ,[ActionTaken04] ")
            Query.Append("  ,[Timetable04] ")

            Query.Append("  ,[cbx01Submital01] ")
            Query.Append("  ,[cbx01Submital02] ")

            Query.Append("  ,[cbx01Reason01] ")
            Query.Append("  ,[cbx01Reason02] ")
            Query.Append("  ,[cbx01Reason03] ")
            Query.Append("  ,[cbx01Reason04] ")
            Query.Append("  ,[cbx01Reason05] ")
            Query.Append("  ,[cbx01Reason06] ")
            Query.Append("  ,[cbx01Reason07] ")
            Query.Append("  ,[cbx01Reason08] ")
            Query.Append("  ,[cbx01Reason09] ")
            Query.Append("  ,[cbx01Reason10] ")
            Query.Append("  ,[cbx01Reason11] ")
            Query.Append("  ,[cbx01Reason12] ")

            Query.Append("  ,[OtherReason] ")
            Query.Append("  ,[Instruction] ")
            Query.Append("  ,[hfProject] ")
            Query.Append("  ,[hfContractor] ")
            Query.Append("from ")
            Query.Append("  (select ")
            Query.Append("      [A].f_code [ID] ")
            Query.Append("      ,[A].created_date [DateCreated] ")
            Query.Append("      ,[A].date_required [DateRequired] ")
            Query.Append("      ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
            Query.Append("      ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
            Query.Append("      ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
            Query.Append("      ,[A].status [Status] ")
            Query.Append("      ,[B].Project [hfProject] ")
            Query.Append("      ,[G].Project + ' / ' + [F].remarks [Project] ")
            Query.Append("      ,[I].ConNo + ' / ' + [J].ProjInit + ' ' + [I].Phase + ' B' + [I].Block + ' L' + [I].Lot + ' / ' + [K].ModelName [Alternate] ")
            Query.Append("      ,[B].Notice [Notice] ")
            Query.Append("      ,[B].ConType [ConType] ")
            Query.Append("      ,dbo.ProperCase([H].vendor) [Contractor] ")
            Query.Append("      ,[B].Contractor [hfContractor] ")
            Query.Append("      ,[B].NTPNo [NTPNo] ")
            Query.Append("      ,Format([B].NTPDate, 'MM/dd/yyyy') [NTPDate] ")
            Query.Append("      ,Format([B].ActualStartdate, 'MM/dd/yyyy') [ActualDate] ")
            Query.Append("      ,Format([B].ApprovedTimeExtention, 'MM/dd/yyyy') [ApprovedExtension] ")
            Query.Append("      ,[B].Address [Address] ")
            Query.Append("      ,[B].ConNo [ConNo] ")
            Query.Append("      ,Format([B].ConPrice, 'N2') [ConPrice] ")
            Query.Append("      ,Format([B].OriginalFinishDate, 'MM/dd/yyyy') [OrigDate] ")
            Query.Append("      ,Format([B].RevisedFinishDate, 'MM/dd/yyyy') [RevDate] ")
            Query.Append("      ,Format([B].POC_Date, 'MM/dd/yyyy') [POCDate] ")
            Query.Append("      ,[B].POC_Target [POCTarget] ")
            Query.Append("      ,[B].POC_Actual [POCActual] ")
            Query.Append("      ,[B].POC_Slippage [POCSlippage] ")
            Query.Append("      ,[B].VOC_Target [VOCTarget] ")
            Query.Append("      ,[B].VOC_Actual [VOCActual] ")
            Query.Append("      ,[B].VOC_Slippage [VOCSlippage] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [DelayedWork01] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [Slippage01] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [ActionTaken01] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [Timetable01] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [DelayedWork02] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [Slippage02] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [ActionTaken02] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [Timetable02] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [DelayedWork03] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [Slippage03] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [ActionTaken03] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [Timetable03] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [DelayedWork04] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [Slippage04] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [ActionTaken04] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [Timetable04] ")
            Query.Append("      ,(case when [B].Submital like '%001001%' then 1 else 0 end) [cbx01Submital01] ")
            Query.Append("      ,(case when [B].Submital like '%001002%' then 1 else 0 end) [cbx01Submital02] ")
            Query.Append("      ,(case when [B].Reason like '%002001%' then 1 else 0 end) [cbx01Reason01] ")
            Query.Append("      ,(case when [B].Reason like '%002002%' then 1 else 0 end) [cbx01Reason02] ")
            Query.Append("      ,(case when [B].Reason like '%002003%' then 1 else 0 end) [cbx01Reason03] ")
            Query.Append("      ,(case when [B].Reason like '%002004%' then 1 else 0 end) [cbx01Reason04] ")
            Query.Append("      ,(case when [B].Reason like '%002005%' then 1 else 0 end) [cbx01Reason05] ")
            Query.Append("      ,(case when [B].Reason like '%002006%' then 1 else 0 end) [cbx01Reason06] ")
            Query.Append("      ,(case when [B].Reason like '%002007%' then 1 else 0 end) [cbx01Reason07] ")
            Query.Append("      ,(case when [B].Reason like '%002008%' then 1 else 0 end) [cbx01Reason08] ")
            Query.Append("      ,(case when [B].Reason like '%002009%' then 1 else 0 end) [cbx01Reason09] ")
            Query.Append("      ,(case when [B].Reason like '%002010%' then 1 else 0 end) [cbx01Reason10] ")
            Query.Append("      ,(case when [B].Reason like '%002011%' then 1 else 0 end) [cbx01Reason11] ")
            Query.Append("      ,(case when [B].Reason like '%002012%' then 1 else 0 end) [cbx01Reason12] ")
            Query.Append("      ,[B].Others [OtherReason] ")
            Query.Append("      ,[B].Instruction [Instruction] ")
            Query.Append("  from ")
            Query.Append("      oop_form_hdr [A] ")
            Query.Append("      left join Form_NODHdr [B] on [A].tbl_code = [B].NODCode ")
            Query.Append("      left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("      left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("      left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("      left join oop_form_hdr [F] on [B].Project = [F].f_code ")
            Query.Append("      left join Form_CRT [G] on [F].tbl_code = [G].CRTCode ")
            Query.Append("      left join ogm_vendor [H] on [B].Contractor = [H].v_code ")
            Query.Append("      left join Form_HWHdr [I] on [B].Project = [I].HWCode ")
            Query.Append("      left join calmardbLive.dbo.mstr_Projects [J] on [I].Subd = [J].ProjCode ")
            Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [K] on [I].House = [K].ModelCode ")
            Query.Append("  where ")
            Query.Append("      [A].f_code = '" & ltrlID.Text & "') [TBL] ")
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
                        tbx01FormType.Text = "Notice of Delay"
                        tbx01DateRequested.Text = Format(DR("DateCreated"), "MM/dd/yyyy")
                        tbx01DateRequired.Value = Format(DR("DateRequired"), "MM/dd/yyyy")
                        tbx01RequestedBy.Text = DR("RequestedBy")
                        tbx01AssignedTo.Text = DR("AssignedTo")
                        tbx01EndorsedTo.Text = DR("EndorsedTo")
                        tbx01Status.Text = DR("Status")
                        tbx01Project.Value = DR("Project")
                        hf01Project.Value = DR("hfProject")
                        ddl01Notice.SelectedValue = DR("Notice")
                        ddl01ConType.SelectedValue = DR("ConType")
                        tbx01Contractor.Value = DR("Contractor")
                        hf01Contractor.Value = DR("hfContractor")
                        tbx01NTPNo.Text = DR("NTPNo")
                        tbx01NTPDate.Value = DR("NTPDate")
                        tbx01ActualStartdate.Value = DR("ActualDate")
                        tbx01ApprovedTimeExtention.Value = DR("ApprovedExtension")
                        tbx01Address.Text = DR("Address")
                        tbx01ConNo.Text = DR("ConNo")
                        tbx01ConPrice.Text = DR("ConPrice")
                        tbx01OriginalFinishDate.Value = DR("OrigDate")
                        tbx01RevisedFinishDate.Value = DR("RevDate")
                        tbx01POC_Date.Value = DR("POCDate")

                        'progress of completion
                        tbx01POC_Target.Value = DR("POCTarget")
                        tbx01POC_Actual.Value = DR("POCActual")
                        tbx01POC_Slippage.Value = DR("POCSlippage")

                        'value of completion
                        tbx01VOC_Target.Value = DR("VOCTarget")
                        tbx01VOC_Actual.Value = DR("VOCActual")
                        tbx01VOC_Slippage.Value = DR("VOCSlippage")

                        'delayed work
                        tbx01DelayedWork01.Value = DR("DelayedWork01")
                        tbx01Slippage01.Value = DR("Slippage01")
                        tbx01ActionTaken01.Value = DR("ActionTaken01")
                        tbx01TimeTable01.Value = DR("Timetable01")

                        tbx01DelayedWork02.Value = DR("DelayedWork02")
                        tbx01Slippage02.Value = DR("Slippage02")
                        tbx01ActionTaken02.Value = DR("ActionTaken02")
                        tbx01TimeTable02.Value = DR("Timetable02")

                        tbx01DelayedWork03.Value = DR("DelayedWork03")
                        tbx01Slippage03.Value = DR("Slippage03")
                        tbx01ActionTaken03.Value = DR("ActionTaken03")
                        tbx01TimeTable03.Value = DR("Timetable03")

                        tbx01DelayedWork04.Value = DR("DelayedWork04")
                        tbx01Slippage04.Value = DR("Slippage04")
                        tbx01ActionTaken04.Value = DR("ActionTaken04")
                        tbx01TimeTable04.Value = DR("Timetable04")


                        cbx01Submittal01.Checked = IIf(DR("cbx01Submital01") = 1, True, False)
                        cbx01Submittal02.Checked = IIf(DR("cbx01Submital02") = 1, True, False)

                        cbx01Reasons0101.Checked = IIf(DR("cbx01Reason01") = 1, True, False)
                        cbx01Reasons0102.Checked = IIf(DR("cbx01Reason02") = 1, True, False)
                        cbx01Reasons0103.Checked = IIf(DR("cbx01Reason03") = 1, True, False)
                        cbx01Reasons0104.Checked = IIf(DR("cbx01Reason04") = 1, True, False)
                        cbx01Reasons0105.Checked = IIf(DR("cbx01Reason05") = 1, True, False)
                        cbx01Reasons0106.Checked = IIf(DR("cbx01Reason06") = 1, True, False)
                        cbx01Reasons0107.Checked = IIf(DR("cbx01Reason07") = 1, True, False)
                        cbx01Reasons0108.Checked = IIf(DR("cbx01Reason08") = 1, True, False)
                        cbx01Reasons0109.Checked = IIf(DR("cbx01Reason09") = 1, True, False)
                        cbx01Reasons0110.Checked = IIf(DR("cbx01Reason10") = 1, True, False)
                        cbx01Reasons0111.Checked = IIf(DR("cbx01Reason11") = 1, True, False)
                        cbx01Reasons0112.Checked = IIf(DR("cbx01Reason12") = 1, True, False)

                        tbx01OtherReason.Text = DR("OtherReason")
                        tbx01Instruction.Text = DR("Instruction")
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
            lbl01Project.Text = "-"
            lbl01Notice.Text = "-"
            lbl01ConType.Text = "-"
            lbl01Contractor.Text = "-"
            lbl01NTPNo.Text = "-"
            lbl01NTPDate.Text = "-"
            lbl01ActualDateStart.Text = "-"
            lbl01ApprovedTimeExtention.Text = "-"
            lbl01Address.Text = "-"
            lbl01ConNo.Text = "-"
            lbl01ConPrice.Text = "-"
            lbl01OriginalFinishDate.Text = "-"
            lbl01RevisedFinishDate.Text = "-"
            lbl01POC_Date.Text = "-"
            lbl01POC_Target.Value = "-"
            lbl01POC_Actual.Value = "-"
            lbl01POC_Slippage.Value = "-"
            lbl01VOC_Target.Value = "-"
            lbl01VOC_Actual.Value = "-"
            lbl01VOC_Slippage.Value = "-"

            lbl01DelayedWork01.Value = "-"
            lbl01Slippage01.Value = "0.00"
            lbl01ActionTaken01.Value = "-"
            lbl01Timetable01.Value = "-"

            lbl01DelayedWork02.Value = "-"
            lbl01Slippage02.Value = "0.00"
            lbl01ActionTaken02.Value = "-"
            lbl01Timetable02.Value = "-"

            lbl01DelayedWork03.Value = "-"
            lbl01Slippage03.Value = "0.00"
            lbl01ActionTaken03.Value = "-"
            lbl01Timetable03.Value = "-"

            lbl01DelayedWork04.Value = "-"
            lbl01Slippage04.Value = "0.00"
            lbl01ActionTaken04.Value = "-"
            lbl01Timetable04.Value = "-"

            lbl01Slippage05.Value = "0.00"

            cbx02Submittal01.Checked = False
            cbx02Submittal02.Checked = False

            cbx01Reasons0201.Checked = False
            cbx01Reasons0202.Checked = False
            cbx01Reasons0203.Checked = False
            cbx01Reasons0204.Checked = False
            cbx01Reasons0205.Checked = False
            cbx01Reasons0206.Checked = False
            cbx01Reasons0207.Checked = False
            cbx01Reasons0208.Checked = False
            cbx01Reasons0209.Checked = False
            cbx01Reasons0210.Checked = False
            cbx01Reasons0211.Checked = False
            cbx01Reasons0212.Checked = False

            lbl01Others.Text = "-"
            lbl01Instruction.Text = "-"
            'set value

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("  (case when [Project] is null or [Project] = '' then [Alternate] else [Project] end) [Project] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[DateCreated] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[RequestedBy] ")
            Query.Append("  ,[AssignedTo] ")
            Query.Append("  ,[EndorsedTo] ")
            Query.Append("  ,[Status] ")
            Query.Append("  ,[Notice] ")
            Query.Append("  ,[ConType] ")
            Query.Append("  ,[Contractor] ")
            Query.Append("  ,[NTPNo] ")
            Query.Append("  ,[NTPDate] ")
            Query.Append("  ,[ActualDate] ")
            Query.Append("  ,[ApprovedExtension] ")
            Query.Append("  ,[Address] ")
            Query.Append("  ,[ConNo] ")
            Query.Append("  ,[ConPrice] ")
            Query.Append("  ,[OrigDate] ")
            Query.Append("  ,[RevDate] ")
            Query.Append("  ,[POCDate] ")
            Query.Append("  ,[POCTarget] ")
            Query.Append("  ,[POCActual] ")
            Query.Append("  ,[POCSlippage] ")
            Query.Append("  ,[VOCTarget] ")
            Query.Append("  ,[VOCActual] ")
            Query.Append("  ,[VOCSlippage] ")
            Query.Append("  ,[DelayedWork01] ")
            Query.Append("  ,[Slippage01] ")
            Query.Append("  ,[ActionTaken01] ")
            Query.Append("  ,[Timetable01] ")

            Query.Append("  ,[DelayedWork02] ")
            Query.Append("  ,[Slippage02] ")
            Query.Append("  ,[ActionTaken02] ")
            Query.Append("  ,[Timetable02] ")

            Query.Append("  ,[DelayedWork03] ")
            Query.Append("  ,[Slippage03] ")
            Query.Append("  ,[ActionTaken03] ")
            Query.Append("  ,[Timetable03] ")

            Query.Append("  ,[DelayedWork04] ")
            Query.Append("  ,[Slippage04] ")
            Query.Append("  ,[ActionTaken04] ")
            Query.Append("  ,[Timetable04] ")

            Query.Append("  ,[cbx01Submital01] ")
            Query.Append("  ,[cbx01Submital02] ")

            Query.Append("  ,[cbx01Reason01] ")
            Query.Append("  ,[cbx01Reason02] ")
            Query.Append("  ,[cbx01Reason03] ")
            Query.Append("  ,[cbx01Reason04] ")
            Query.Append("  ,[cbx01Reason05] ")
            Query.Append("  ,[cbx01Reason06] ")
            Query.Append("  ,[cbx01Reason07] ")
            Query.Append("  ,[cbx01Reason08] ")
            Query.Append("  ,[cbx01Reason09] ")
            Query.Append("  ,[cbx01Reason10] ")
            Query.Append("  ,[cbx01Reason11] ")
            Query.Append("  ,[cbx01Reason12] ")

            Query.Append("  ,[OtherReason] ")
            Query.Append("  ,[Instruction] ")
            Query.Append("from ")
            Query.Append("  (select ")
            Query.Append("      [A].f_code [ID] ")
            Query.Append("      ,[A].created_date [DateCreated] ")
            Query.Append("      ,[A].date_required [DateRequired] ")
            Query.Append("      ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
            Query.Append("      ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
            Query.Append("      ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
            Query.Append("      ,[A].status [Status] ")
            Query.Append("      ,[B].Project [hfProject] ")
            Query.Append("      ,[G].Project + ' / ' + [G].Remarks [Project] ")
            Query.Append("      ,[I].ConNo + ' / ' + [J].ProjInit + ' ' + [I].Phase + ' B' + [I].Block + ' L' + [I].Lot + ' / ' + [K].ModelName [Alternate] ")
            Query.Append("      ,[B].Notice [Notice] ")
            Query.Append("      ,[B].ConType [ConType] ")
            Query.Append("      ,dbo.ProperCase([H].vendor) [Contractor] ")
            Query.Append("      ,[B].Contractor [hfContractor] ")
            Query.Append("      ,[B].NTPNo [NTPNo] ")
            Query.Append("      ,Format([B].NTPDate, 'MM/dd/yyyy') [NTPDate] ")
            Query.Append("      ,Format([B].ActualStartdate, 'MM/dd/yyyy') [ActualDate] ")
            Query.Append("      ,Format([B].ApprovedTimeExtention, 'MM/dd/yyyy') [ApprovedExtension] ")
            Query.Append("      ,[B].Address [Address] ")
            Query.Append("      ,[B].ConNo [ConNo] ")
            Query.Append("      ,Format([B].ConPrice, 'N2') [ConPrice] ")
            Query.Append("      ,Format([B].OriginalFinishDate, 'MM/dd/yyyy') [OrigDate] ")
            Query.Append("      ,Format([B].RevisedFinishDate, 'MM/dd/yyyy') [RevDate] ")
            Query.Append("      ,Format([B].POC_Date, 'MM/dd/yyyy') [POCDate] ")
            Query.Append("      ,[B].POC_Target [POCTarget] ")
            Query.Append("      ,[B].POC_Actual [POCActual] ")
            Query.Append("      ,[B].POC_Slippage [POCSlippage] ")
            Query.Append("      ,[B].VOC_Target [VOCTarget] ")
            Query.Append("      ,[B].VOC_Actual [VOCActual] ")
            Query.Append("      ,[B].VOC_Slippage [VOCSlippage] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [DelayedWork01] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [Slippage01] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [ActionTaken01] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 1) [Timetable01] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [DelayedWork02] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [Slippage02] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [ActionTaken02] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 2) [Timetable02] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [DelayedWork03] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [Slippage03] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [ActionTaken03] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 3) [Timetable03] ")
            Query.Append("      ,(select DelayedWork from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [DelayedWork04] ")
            Query.Append("      ,(select Slippage from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [Slippage04] ")
            Query.Append("      ,(select ActionTaken from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [ActionTaken04] ")
            Query.Append("      ,(select Timetable from Form_NODDtl where NODCode = [B].NODCode and SeqNo = 4) [Timetable04] ")
            Query.Append("      ,(case when [B].Submital like '%001001%' then 1 else 0 end) [cbx01Submital01] ")
            Query.Append("      ,(case when [B].Submital like '%001002%' then 1 else 0 end) [cbx01Submital02] ")
            Query.Append("      ,(case when [B].Reason like '%002001%' then 1 else 0 end) [cbx01Reason01] ")
            Query.Append("      ,(case when [B].Reason like '%002002%' then 1 else 0 end) [cbx01Reason02] ")
            Query.Append("      ,(case when [B].Reason like '%002003%' then 1 else 0 end) [cbx01Reason03] ")
            Query.Append("      ,(case when [B].Reason like '%002004%' then 1 else 0 end) [cbx01Reason04] ")
            Query.Append("      ,(case when [B].Reason like '%002005%' then 1 else 0 end) [cbx01Reason05] ")
            Query.Append("      ,(case when [B].Reason like '%002006%' then 1 else 0 end) [cbx01Reason06] ")
            Query.Append("      ,(case when [B].Reason like '%002007%' then 1 else 0 end) [cbx01Reason07] ")
            Query.Append("      ,(case when [B].Reason like '%002008%' then 1 else 0 end) [cbx01Reason08] ")
            Query.Append("      ,(case when [B].Reason like '%002009%' then 1 else 0 end) [cbx01Reason09] ")
            Query.Append("      ,(case when [B].Reason like '%002010%' then 1 else 0 end) [cbx01Reason10] ")
            Query.Append("      ,(case when [B].Reason like '%002011%' then 1 else 0 end) [cbx01Reason11] ")
            Query.Append("      ,(case when [B].Reason like '%002012%' then 1 else 0 end) [cbx01Reason12] ")
            Query.Append("      ,[B].Others [OtherReason] ")
            Query.Append("      ,[B].Instruction [Instruction] ")
            Query.Append("  from ")
            Query.Append("      oop_form_hdr [A] ")
            Query.Append("      left join Form_NODHdr [B] on [A].tbl_code = [B].NODCode ")
            Query.Append("      left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("      left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("      left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("      left join Form_CRT [G] on [B].Project = [G].CRTCode ")
            Query.Append("      left join ogm_vendor [H] on [B].Contractor = [H].v_code ")
            Query.Append("      left join Form_HWHdr [I] on [B].Project = [I].HWCode ")
            Query.Append("      left join calmardbLive.dbo.mstr_Projects [J] on [I].Subd = [J].ProjCode ")
            Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [K] on [I].House = [K].ModelCode ")
            Query.Append("  where ")
            Query.Append("      [A].f_code = '" & ltrlID.Text & "') [TBL] ")
            'get total task

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        Dim TotalSlippage As String

                        lbl01ID.Text = DR("ID")
                        lbl01FormType.Text = "Notice of Delay"
                        lbl01DateRequested.Text = Format(DR("DateCreated"), "MM/dd/yyyy")
                        lbl01DateRequired.Text = Format(DR("DateRequired"), "MM/dd/yyyy")
                        lbl01RequestedBy.Text = DR("RequestedBy")
                        lbl01AssignedTo.Text = DR("AssignedTo")
                        lbl01EndorsedTo.Text = DR("EndorsedTo")
                        lbl01Status.Text = DR("Status")
                        lbl01Project.Text = DR("Project")
                        lbl01Notice.Text = DR("Notice")
                        lbl01ConType.Text = DR("ConType")
                        lbl01Contractor.Text = DR("Contractor")
                        lbl01NTPNo.Text = DR("NTPNo")
                        lbl01NTPDate.Text = DR("NTPDate")
                        lbl01ActualDateStart.Text = DR("ActualDate")
                        lbl01ApprovedTimeExtention.Text = DR("ApprovedExtension")
                        lbl01Address.Text = DR("Address")
                        lbl01ConNo.Text = DR("ConNo")
                        lbl01ConPrice.Text = DR("ConPrice")
                        lbl01OriginalFinishDate.Text = DR("OrigDate")
                        lbl01RevisedFinishDate.Text = DR("RevDate")
                        lbl01POC_Date.Text = DR("POCDate")

                        'progress of completion
                        lbl01POC_Target.Value = DR("POCTarget")
                        lbl01POC_Actual.Value = DR("POCActual")
                        lbl01POC_Slippage.Value = DR("POCSlippage")

                        'value of completion
                        lbl01VOC_Target.Value = DR("VOCTarget")
                        lbl01VOC_Actual.Value = DR("VOCActual")
                        lbl01VOC_Slippage.Value = DR("VOCSlippage")

                        'qualified reason
                        lbl01DelayedWork01.Value = DR("DelayedWork01")
                        lbl01Slippage01.Value = DR("Slippage01")
                        lbl01ActionTaken01.Value = DR("ActionTaken01")
                        lbl01Timetable01.Value = DR("Timetable01")

                        'submital
                        cbx02Submittal01.Checked = IIf(DR("cbx01Submital01") = 1, True, False)
                        cbx02Submittal02.Checked = IIf(DR("cbx01Submital02") = 1, True, False)

                        'reason
                        cbx01Reasons0201.Checked = IIf(DR("cbx01Reason01") = 1, True, False)
                        cbx01Reasons0202.Checked = IIf(DR("cbx01Reason02") = 1, True, False)
                        cbx01Reasons0203.Checked = IIf(DR("cbx01Reason03") = 1, True, False)
                        cbx01Reasons0204.Checked = IIf(DR("cbx01Reason04") = 1, True, False)
                        cbx01Reasons0205.Checked = IIf(DR("cbx01Reason05") = 1, True, False)
                        cbx01Reasons0206.Checked = IIf(DR("cbx01Reason06") = 1, True, False)
                        cbx01Reasons0207.Checked = IIf(DR("cbx01Reason07") = 1, True, False)
                        cbx01Reasons0208.Checked = IIf(DR("cbx01Reason08") = 1, True, False)
                        cbx01Reasons0209.Checked = IIf(DR("cbx01Reason09") = 1, True, False)
                        cbx01Reasons0210.Checked = IIf(DR("cbx01Reason10") = 1, True, False)
                        cbx01Reasons0211.Checked = IIf(DR("cbx01Reason11") = 1, True, False)
                        cbx01Reasons0212.Checked = IIf(DR("cbx01Reason12") = 1, True, False)

                        lbl01DelayedWork02.Value = DR("DelayedWork02")
                        lbl01Slippage02.Value = DR("Slippage02")
                        lbl01ActionTaken02.Value = DR("ActionTaken02")
                        lbl01Timetable02.Value = DR("Timetable02")

                        lbl01DelayedWork03.Value = DR("DelayedWork03")
                        lbl01Slippage03.Value = DR("Slippage03")
                        lbl01ActionTaken03.Value = DR("ActionTaken03")
                        lbl01Timetable03.Value = DR("Timetable03")

                        lbl01DelayedWork04.Value = DR("DelayedWork04")
                        lbl01Slippage04.Value = DR("Slippage04")
                        lbl01ActionTaken04.Value = DR("ActionTaken04")
                        lbl01Timetable04.Value = DR("Timetable04")

                        TotalSlippage = DR("Slippage01") + DR("Slippage02") + DR("Slippage03") + DR("Slippage04")
                        lbl01Slippage05.Value = TotalSlippage

                        lbl01Others.Text = DR("OtherReason")
                        lbl01Instruction.Text = DR("Instruction")
                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
            'read record

            'bind
            bind01Contractor()
            'bind

            'display data
            upnl01Overview.Update()
            'display data

        End If
        'view record

        'display record
        upnl01Overview.Update()
        'display record

    End Function

    Function bind01Contractor()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select contractor' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].v_code [Code] ")
        Query.Append("   ,dbo.Propercase([A].vendor) [Name] ")
        Query.Append("   ,[A].vendor [Order] ")
        Query.Append("from ")
        Query.Append("   ogm_vendor [A] ")
        Query.Append("   left join Form_CRT [B] on [A].v_code = [B].Contractor ")
        Query.Append("   left join Form_HWHdr [C] on [A].v_code = [C].ConStatus ")
        Query.Append("where ")
        Query.Append("   [A].lock = 1 ")
        Query.Append("   and [B].ContractStatus = 'Awarded' ")
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
        'ddl01Contractor.DataSource = DT
        'ddl01Contractor.DataValueField = "Code"
        'ddl01Contractor.DataTextField = "Name"
        'ddl01Contractor.DataBind()
        'fill data

    End Function

    Function bind01Project(Code As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Select project' [Project] ")
        Query.Append("  ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  [A].CRTCode [Code] ")
        Query.Append("  ,[B].FormTitle + ' : ' + [B].remarks [Project] ")
        Query.Append("  ,[A].CreatedDate [Order] ")
        Query.Append("from ")
        Query.Append("  Form_CRT [A] ")
        Query.Append("  left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("where ")
        Query.Append("  [A].ContractStatus = 'Awarded' ")
        Query.Append("  and [B].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].Contractor = '" & Code & "' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  [A].HWCode [Code] ")
        Query.Append("  ,[A].Type + ' - ' + [C].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' / ' + [B].ModelName [Project] ")
        Query.Append("  ,[A].CreatedDate [Order] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [B] on [A].House = [B].ModelCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Awarded' ")
        Query.Append("  and [A].Contractor = '" & Code & "' ")
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
        'ddl01Project.DataSource = DT
        'ddl01Project.DataValueField = "Code"
        'ddl01Project.DataTextField = "Project"
        'ddl01Project.DataBind()
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
        If ltrlMode.Text = "DTL" And ltrlID.Text <> "0000000000000" Then

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
        If ltrlMode.Text = "ADD" Then

            'Record
            ltrlID.Text = "0000000000000"
            ltrlMode.Text = "DTL"
            'Record

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
            ElseIf tbx01Project.Value = "" Then
                Alert("error", "Some fields are missing! Project")
            ElseIf ddl01Notice.SelectedValue = "" Then
                Alert("error", "Some fields are missing! Notice")
            ElseIf ddl01ConType.SelectedValue = "" Then
                Alert("error", "Some fields are missing! ConType")
            ElseIf tbx01Contractor.Value = "" Then
                Alert("error", "Some fields are missing! Contractor")
            ElseIf tbx01NTPNo.Text = "" Then
                Alert("error", "Some fields are missing! NTPNo")
            ElseIf tbx01NTPDate.Value = "" Then
                Alert("error", "Some fields are missing! NTPDate")
            ElseIf tbx01ActualStartdate.Value = "" Then
                Alert("error", "Some fields are missing! ActualStartDate")
            ElseIf tbx01ApprovedTimeExtention.Value = "" Then
                Alert("error", "Some fields are missing! ApprovedTimeExtension")
            ElseIf tbx01Address.Text = "" Then
                Alert("error", "Some fields are missing! Address")
            ElseIf tbx01ConNo.Text = "" Then
                Alert("error", "Some fields are missing! ConNo")
            ElseIf tbx01ConPrice.Text = "" Then
                Alert("error", "Some fields are missing! ContractPrice")
            ElseIf tbx01OriginalFinishDate.Value = "" Then
                Alert("error", "Some fields are missing! FinishDate")
            ElseIf tbx01RevisedFinishDate.Value = "" Then
                Alert("error", "Some fields are missing! RevisedDate")
            ElseIf tbx01POC_Date.Value = "" Then
                Alert("error", "Some fields are missing! POC_Date")

                'completion
            ElseIf tbx01POC_Target.Value = 0.00 Then
                Alert("error", "Some fields are missing! POC_Target")
            ElseIf tbx01POC_Actual.Value = 0.00 Then
                Alert("error", "Some fields are missing! POC_Actual")
            ElseIf tbx01POC_Slippage.Value = 0.00 Then
                Alert("error", "Some fields are missing! POC_Slippage")
                'completion

                'delayed works
            ElseIf (tbx01DelayedWork01.Value = "" Or tbx01Slippage01.Value = "" Or tbx01ActionTaken01.Value = "" Or tbx01TimeTable01.Value = "") Or
                   (tbx01DelayedWork02.Value = "" Or tbx01Slippage02.Value = "" Or tbx01ActionTaken02.Value = "" Or tbx01TimeTable02.Value = "") Or
                   (tbx01DelayedWork03.Value = "" Or tbx01Slippage03.Value = "" Or tbx01ActionTaken03.Value = "" Or tbx01TimeTable03.Value = "") Or
                   (tbx01DelayedWork04.Value = "" Or tbx01Slippage04.Value = "" Or tbx01ActionTaken04.Value = "" Or tbx01TimeTable04.Value = "") Then
                Alert("error", "Some fields are missing! Delayed Works")
                'delayed works

            ElseIf tbx01OtherReason.Text = "" Then
                Alert("error", "Some fields are missing! Other reasons")
            ElseIf tbx01Instruction.Text = "" Then
                Alert("error", "Some fields are missing! instruction")
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
            ElseIf tbx01Project.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Notice.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01ConType.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Contractor.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01NTPNo.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01NTPDate.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01ActualStartdate.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01ApprovedTimeExtention.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Address.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01ConNo.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01ConPrice.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01OriginalFinishDate.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01RevisedFinishDate.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01POC_Date.Value = "" Then
                Alert("error", "Some fields are missing!")

                'completion
            ElseIf tbx01POC_Target.Value = 0.00 Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01POC_Actual.Value = 0.00 Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01POC_Slippage.Value = 0.00 Then
                Alert("error", "Some fields are missing!")
                'completion

                'delayed works
            ElseIf (tbx01DelayedWork01.Value = "" Or tbx01Slippage01.Value = "" Or tbx01ActionTaken01.Value = "" Or tbx01TimeTable01.Value = "") Then
                Alert("error", "Some fields are missing!")
            ElseIf (tbx01DelayedWork02.Value = "" Or tbx01Slippage02.Value = "" Or tbx01ActionTaken02.Value = "" Or tbx01TimeTable02.Value = "") Then
                Alert("error", "Some fields are missing!")
            ElseIf (tbx01DelayedWork03.Value = "" Or tbx01Slippage03.Value = "" Or tbx01ActionTaken03.Value = "" Or tbx01TimeTable03.Value = "") Then
                Alert("error", "Some fields are missing!")
            ElseIf (tbx01TimeTable04.Value = "" Or tbx01Slippage04.Value = "" Or tbx01ActionTaken04.Value = "" Or tbx01ActionTaken04.Value = "") Then
                Alert("error", "Some fields are missing!")
                'delayed works

            ElseIf tbx01OtherReason.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Instruction.Text = "" Then
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
        If ltrlMode.Text = "ADD" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_FRM000038"
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Value)
            SqlCmd.Parameters.AddWithValue("@pProject", hf01Project.Value)
            SqlCmd.Parameters.AddWithValue("@pNotice", ddl01Notice.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pConType", ddl01ConType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pContractor", hf01Contractor.Value)
            SqlCmd.Parameters.AddWithValue("@pNTPNo", tbx01NTPNo.Text)
            SqlCmd.Parameters.AddWithValue("@pNTPDate", tbx01NTPDate.Value)
            SqlCmd.Parameters.AddWithValue("@pActualDate", tbx01ActualStartdate.Value)
            SqlCmd.Parameters.AddWithValue("@pApprovedExtension", tbx01ApprovedTimeExtention.Value)
            SqlCmd.Parameters.AddWithValue("@pAddress", tbx01Address.Text)
            SqlCmd.Parameters.AddWithValue("@pConNo", tbx01ConNo.Text)
            SqlCmd.Parameters.AddWithValue("@pConPrice", CDbl(tbx01ConPrice.Text))
            SqlCmd.Parameters.AddWithValue("@pOrigDate", tbx01OriginalFinishDate.Value)
            SqlCmd.Parameters.AddWithValue("@pRevisedDate", tbx01RevisedFinishDate.Value)
            SqlCmd.Parameters.AddWithValue("@pPOCDate", tbx01POC_Date.Value)

            'progress of completion
            SqlCmd.Parameters.AddWithValue("@pPOCTarget", tbx01POC_Target.Value)
            SqlCmd.Parameters.AddWithValue("@pPOCActual", tbx01POC_Actual.Value)
            SqlCmd.Parameters.AddWithValue("@pPOCSlippage", tbx01POC_Slippage.Value)

            'value of completion
            SqlCmd.Parameters.AddWithValue("@pVOCTarget", tbx01VOC_Target.Value)
            SqlCmd.Parameters.AddWithValue("@pVOCActual", tbx01VOC_Actual.Value)
            SqlCmd.Parameters.AddWithValue("@pVOCSlippage", tbx01VOC_Slippage.Value)

            'delayed works
            SqlCmd.Parameters.AddWithValue("@pDelayedWorks01", tbx01DelayedWork01.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage01", tbx01Slippage01.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken01", tbx01ActionTaken01.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable01", tbx01TimeTable01.Value)

            SqlCmd.Parameters.AddWithValue("@pDelayedWorks02", tbx01DelayedWork02.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage02", tbx01Slippage02.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken02", tbx01ActionTaken02.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable02", tbx01TimeTable02.Value)

            SqlCmd.Parameters.AddWithValue("@pDelayedWorks03", tbx01DelayedWork03.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage03", tbx01Slippage03.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken03", tbx01ActionTaken03.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable03", tbx01TimeTable03.Value)

            SqlCmd.Parameters.AddWithValue("@pDelayedWorks04", tbx01DelayedWork04.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage04", tbx01Slippage04.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken04", tbx01ActionTaken04.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable04", tbx01TimeTable04.Value)

            'submittal
            SqlCmd.Parameters.AddWithValue("@pSubmittal", GetSubmittal())

            'reason
            SqlCmd.Parameters.AddWithValue("@pReason", GetReason())

            SqlCmd.Parameters.AddWithValue("@pOtherReason", tbx01OtherReason.Text)
            SqlCmd.Parameters.AddWithValue("@pInstruction", tbx01Instruction.Text)
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
            SqlCmd.CommandText = "Upd_FRM_FRM000038"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Value)
            SqlCmd.Parameters.AddWithValue("@pProject", hf01Project.Value)
            SqlCmd.Parameters.AddWithValue("@pNotice", ddl01Notice.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pConType", ddl01ConType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pContractor", hf01Contractor.Value)
            SqlCmd.Parameters.AddWithValue("@pNTPNo", tbx01NTPNo.Text)
            SqlCmd.Parameters.AddWithValue("@pNTPDate", tbx01NTPDate.Value)
            SqlCmd.Parameters.AddWithValue("@pActualDate", tbx01ActualStartdate.Value)
            SqlCmd.Parameters.AddWithValue("@pApprovedExtension", tbx01ApprovedTimeExtention.Value)
            SqlCmd.Parameters.AddWithValue("@pAddress", tbx01Address.Text)
            SqlCmd.Parameters.AddWithValue("@pConNo", tbx01ConNo.Text)
            SqlCmd.Parameters.AddWithValue("@pConPrice", CDbl(tbx01ConPrice.Text))
            SqlCmd.Parameters.AddWithValue("@pOrigDate", tbx01OriginalFinishDate.Value)
            SqlCmd.Parameters.AddWithValue("@pRevisedDate", tbx01RevisedFinishDate.Value)
            SqlCmd.Parameters.AddWithValue("@pPOCDate", tbx01POC_Date.Value)

            'progress of completion
            SqlCmd.Parameters.AddWithValue("@pPOCTarget", tbx01POC_Target.Value)
            SqlCmd.Parameters.AddWithValue("@pPOCActual", tbx01POC_Actual.Value)
            SqlCmd.Parameters.AddWithValue("@pPOCSlippage", tbx01POC_Slippage.Value)

            'value of completion
            SqlCmd.Parameters.AddWithValue("@pVOCTarget", tbx01VOC_Target.Value)
            SqlCmd.Parameters.AddWithValue("@pVOCActual", tbx01VOC_Actual.Value)
            SqlCmd.Parameters.AddWithValue("@pVOCSlippage", tbx01VOC_Slippage.Value)

            'delayed works
            SqlCmd.Parameters.AddWithValue("@pDelayedWorks01", tbx01DelayedWork01.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage01", tbx01Slippage01.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken01", tbx01ActionTaken01.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable01", tbx01TimeTable01.Value)

            SqlCmd.Parameters.AddWithValue("@pDelayedWorks02", tbx01DelayedWork02.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage02", tbx01Slippage02.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken02", tbx01ActionTaken02.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable02", tbx01TimeTable02.Value)

            SqlCmd.Parameters.AddWithValue("@pDelayedWorks03", tbx01DelayedWork03.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage03", tbx01Slippage03.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken03", tbx01ActionTaken03.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable03", tbx01TimeTable03.Value)

            SqlCmd.Parameters.AddWithValue("@pDelayedWorks04", tbx01DelayedWork04.Value)
            SqlCmd.Parameters.AddWithValue("@pSlippage04", tbx01Slippage04.Value)
            SqlCmd.Parameters.AddWithValue("@pActionTaken04", tbx01ActionTaken04.Value)
            SqlCmd.Parameters.AddWithValue("@pTimeTable04", tbx01TimeTable04.Value)

            'submittal
            SqlCmd.Parameters.AddWithValue("@pSubmittal", GetSubmittal())

            'reason
            SqlCmd.Parameters.AddWithValue("@pReason", GetReason())

            SqlCmd.Parameters.AddWithValue("@pOtherReason", tbx01OtherReason.Text)
            SqlCmd.Parameters.AddWithValue("@pInstruction", tbx01Instruction.Text)
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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000038.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000038.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000038.rpt"))
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
        RptDoc.SetParameterValue("@pFCode", ltrlID.Text)
        RptDoc.SetParameterValue("@pID", ltrlID.Text, "RPT000038Dtl.rpt")
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000038.pdf"), Buf)
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

        'view report
        Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000038.pdf")
        ScriptManager.RegisterStartupScript(upnl01Overview, upnl01Overview.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
        'view report


    End Sub

    Function GetSubmittal()
        Dim Submittal As String = ""
        If cbx01Submittal01.Checked = True Then Submittal = Submittal & "001001,"
        If cbx01Submittal02.Checked = True Then Submittal = Submittal & "001002,"
        Return Submittal
    End Function

    Function GetReason()
        Dim Reason As String = ""
        If cbx01Reasons0101.Checked = True Then Reason = Reason & "002001,"
        If cbx01Reasons0102.Checked = True Then Reason = Reason & "002002,"
        If cbx01Reasons0103.Checked = True Then Reason = Reason & "002003,"
        If cbx01Reasons0104.Checked = True Then Reason = Reason & "002004,"
        If cbx01Reasons0105.Checked = True Then Reason = Reason & "002005,"
        If cbx01Reasons0106.Checked = True Then Reason = Reason & "002006,"
        If cbx01Reasons0107.Checked = True Then Reason = Reason & "002007,"
        If cbx01Reasons0108.Checked = True Then Reason = Reason & "002008,"
        If cbx01Reasons0109.Checked = True Then Reason = Reason & "002009,"
        If cbx01Reasons0110.Checked = True Then Reason = Reason & "002010,"
        If cbx01Reasons0111.Checked = True Then Reason = Reason & "002011,"
        If cbx01Reasons0112.Checked = True Then Reason = Reason & "002012,"
        Return Reason
    End Function

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
        'Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,'FRM000038-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_NODHdr' ")
        Query.Append("      and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        'Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,'FRM000038-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_NODHdr' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        'Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,'FRM000038-DTL-' + replace([A].f_code,'#','No') [Link] ")
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
        Query.Append("      [A].tbl_from = 'Form_NODHdr' ")
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

        'get assigned to
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a user' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].approver [Code] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
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
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get assigned to

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

        'display assigned to
        If ddl01Status.SelectedValue = "Clarify" Then

            ddl01ClarifyTo.SelectedValue = ""
            pnl01ClarifyTo.Visible = True
        End If
        'display assigned to

        'update data
        mdl01Status.Update()
        'update data

    End Sub

    Protected Sub lbtn01SaveStatus_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01SaveStatus.Click

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

End Class