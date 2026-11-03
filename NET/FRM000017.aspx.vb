Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FRM000017
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
        Master.setActiveMenu("APP", "FRM010000")
        'active account / menu

        'Record
        ltrlFormCode.Text = "FRM000017"
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
            bind06RMBDtl()
            bind02Files()
            bind03Subscribers()
            bind04ApprovalPath()
            bind05Notes()
            bind06History()
            'display record

        ElseIf IsPostBack = True Then

            'rebind type
            If ltrlMode.Text = "ADD" And ddl01PayeeType.SelectedValue <> "" Then
                ddl01Payee.SelectedValue = ""
                bind01Payee(ddl01PayeeType.SelectedValue)
                ddl01Payee.SelectedValue = hf01Payee.Value
            End If
            If ltrlMode.Text = "UPD" And ddl01PayeeType.SelectedValue <> "" Then
                ddl01Payee.SelectedValue = ""
                bind01Payee(ddl01PayeeType.SelectedValue)
                ddl01Payee.SelectedValue = hf01Payee.Value
            End If
            If ltrlDtlMode.Text = "ADD" And ddl06RMBDtlAddExpense.SelectedValue <> "" Then
                bind06Description(ltrlDtlMode.Text, ddl06RMBDtlAddExpense.SelectedValue)
                ddl06RMBDtlAddCode.SelectedValue = hf06RMBDtlAddCode.Value
                mdl06RMBDtlAdd.Update()
            End If
            If ltrlDtlMode.Text = "ADD" And ddl06RMBDtlAddExpense.SelectedValue = "70010000" Then
                bind06Description(ltrlDtlMode.Text, ddl06RMBDtlAddExpense.SelectedValue)
                ddl06RMBDtlAddCode.SelectedValue = "MN2012090001"
                hf06RMBDtlAddCode.Value = "MN2012090001"
                hf06RMBDtlAddSubsidiary.Value = "MISCELLANEOUS"
            End If
            If ltrlDtlMode.Text = "UPD" And ddl06RMBDtlUpdExpense.SelectedValue <> "" Then
                bind06Description(ltrlDtlMode.Text, ddl06RMBDtlUpdExpense.SelectedValue)
                ddl06RMBDtlUpdCode.SelectedValue = hf06RMBDtlUpdCode.Value
            End If
            If ltrlDtlMode.Text = "UPD" And ddl06RMBDtlUpdExpense.SelectedValue = "70010000" Then
                bind06Description(ltrlDtlMode.Text, ddl06RMBDtlUpdExpense.SelectedValue)
                ddl06RMBDtlUpdCode.SelectedValue = "MN2012090001"
                hf06RMBDtlUpdCode.Value = "MN2012090001"
                hf06RMBDtlUpdSubsidiary.Value = "MISCELLANEOUS"
            End If
            'rebind type

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function Seen()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   Seen = 1 ")
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
            ElseIf lblStatus.Text = "Endorsed" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
            ElseIf lblStatus.Text = "Approved" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
            ElseIf lblStatus.Text = "Implemented" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
            ElseIf lblStatus.Text = "Clarification" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-light-dark")
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
                        ElseIf lblStatus.Text = "Endorsed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Approved" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Implemented" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Clarification" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-dark")
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

            'get hdr
            Dim Query As New StringBuilder
            Query.Append("select")
            Query.Append("   f_code ")
            Query.Append("   ,formtitle ")
            Query.Append("   ,isnull(status,'New') ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr ")
            Query.Append("where ")
            Query.Append("   f_code = '" & ltrlID.Text & "' ")
            'get hdr

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
                        ElseIf lblStatus.Text = "Endorsed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Approved" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Implemented" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                        ElseIf lblStatus.Text = "Clarification" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-light-dark")
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

        If Group_ = "06RMBDtl" Then

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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') not in ('New','Requested','Implementer') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') not in ('New','Requested', 'Clarification') ")
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

        'item
        lbtn06RMBDtlAdd.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'item

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
        upnl06RMBDtl.Update()
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

        'item
        lbtn06RMBDtlAdd.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'item

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
        upnl06RMBDtl.Update()
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
            tbx01FormType.Text = "Payment Request"
            tbx01DateRequested.Text = Format(Date.Now, "MM/dd/yyyy")
            tbx01DateRequired.Value = Format(Date.Now, "MM/dd/yyyy")
            tbx01RequestedBy.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01AssignedTo.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01EndorsedTo.Text = "-"
            tbx01Status.Text = "New"
            bind01Branch()
            ddl01Branch.SelectedValue = ""
            ddl01Fund.SelectedValue = ""
            ddl01PayeeType.SelectedValue = ""
            bind01Payee("")
            ddl01Payee.SelectedValue = ""
            bind01Department()
            ddl01Department.SelectedValue = ""
            tbx01ReferenceNo.Value = ""
            tbx01Remarks.Text = ""
            tbx01DueDate.Value = ""
            cbx0101IsPickUp.Checked = False
            cbx0101IsDeposit.Checked = False
            tbx01BankName.Value = ""
            tbx01AcctName.Value = ""
            tbx01AcctNo.Value = ""
            cbx0101WithEWT.Checked = False
            tbx01GrossAmt.Value = "0.00"
            tbx01EWT.Value = "0.00"
            tbx01NetAmt.Value = "0.00"
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
            'display fields

            'get reimbursement
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].f_code [ID] ")
            Query.Append("   ,[A].created_date [DateCreated] ")
            Query.Append("   ,[A].date_required [DateRequired] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
            Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
            Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
            Query.Append("   ,[A].status [Status] ")
            Query.Append("   ,[B].BrnchCode ")
            Query.Append("   ,[B].Fund ")
            Query.Append("   ,[B].PayeeType ")
            Query.Append("   ,[B].Payor ")
            Query.Append("   ,[B].DeptCode ")
            Query.Append("   ,[B].RefNo ")
            Query.Append("   ,[B].Remarks ")
            Query.Append("   ,isnull(format([B].DueDate,'MM/dd/yyyy'),'') [DueDate] ")
            Query.Append("   ,[B].IsPickUp ")
            Query.Append("   ,[B].IsDeposit ")
            Query.Append("   ,[B].BankName ")
            Query.Append("   ,[B].AcctName ")
            Query.Append("   ,[B].AcctNo ")
            Query.Append("   ,isnull([B].WithEWT, 0) [WithEWT] ")
            Query.Append("   ,isnull(Format([B].GrossAmount, 'N2'), 0.00) [GrossAmt] ")
            Query.Append("   ,isnull(Format([B].EWT, 'N2'), 0.00) [EWT] ")
            Query.Append("   ,isnull(Format([B].NetAmount, 'N2'), 0.00) [NetAmt] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join Form_RMBHdr [B] on [A].tbl_code = [B].RMBCode ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
            'get reimbursement

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        tbx01ID.Text = DR("ID")
                        tbx01FormType.Text = "Payment Request"
                        tbx01DateRequested.Text = Format(DR("DateCreated"), "MM/dd/yyyy")
                        tbx01DateRequired.Value = Format(DR("DateRequired"), "MM/dd/yyyy")
                        tbx01RequestedBy.Text = DR("RequestedBy")
                        tbx01AssignedTo.Text = DR("AssignedTo")
                        tbx01EndorsedTo.Text = DR("EndorsedTo")
                        tbx01Status.Text = DR("Status")
                        bind01Branch()
                        ddl01Branch.SelectedValue = DR("BrnchCode")
                        ddl01Fund.SelectedValue = DR("Fund")
                        ddl01PayeeType.SelectedValue = DR("PayeeType")
                        bind01Payee(DR("PayeeType"))
                        ddl01Payee.SelectedValue = DR("Payor")
                        hf01Payee.Value = DR("Payor")
                        bind01Department()
                        ddl01Department.SelectedValue = DR("DeptCode")
                        tbx01ReferenceNo.Value = DR("RefNo")
                        tbx01Remarks.Text = DR("Remarks")
                        tbx01DueDate.Value = DR("DueDate")
                        cbx0101IsPickUp.Checked = IIf(DR("IsPickUp") = 1, True, False)
                        cbx0101IsDeposit.Checked = IIf(DR("IsDeposit") = 1, True, False)
                        tbx01BankName.Value = DR("BankName")
                        tbx01AcctName.Value = DR("AcctName")
                        tbx01AcctNo.Value = DR("AcctNo")
                        cbx0101WithEWT.Checked = IIf(DR("WithEWT") = 1, True, False)
                        tbx01GrossAmt.Value = DR("GrossAmt")
                        tbx01EWT.Value = DR("EWT")
                        tbx01NetAmt.Value = DR("NetAmt")
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
            lbl01Branch.Text = "-"
            lbl01Fund.Text = "-"
            lbl01PayeeType.Text = "-"
            lbl01Payee.Text = "-"
            lbl01Department.Text = "-"
            lbl01ReferenceNo.Text = "-"
            lbl01Remarks.Text = "-"
            lbl01DueDate.Text = "-"
            cbx0102IsPickUp.Checked = False
            cbx0102IsDeposit.Checked = False
            lbl01BankName.Text = "-"
            lbl01AcctName.Text = "-"
            lbl01AcctNo.Text = "-"
            cbx0102WithEWT.Checked = False
            lbl01GrossAmt.Text = "0.00"
            lbl01EWT.Text = "0.00"
            lbl01NetAmt.Text = "0.00"
            'set value

            'get reimbursement
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].f_code [ID] ")
            Query.Append("   ,[A].created_date [DateCreated] ")
            Query.Append("   ,[A].date_required [DateRequired] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
            Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
            Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
            Query.Append("   ,[A].status [Status] ")
            Query.Append("   ,[F].description [Branch] ")
            Query.Append("   ,[B].Fund ")
            Query.Append("   ,[B].PayeeType ")
            Query.Append("   ,(case when [B].PayeeType = 'Employee' then [G].Fullname else [H].vendor end) [Payee] ")
            Query.Append("   ,[I].description [Department] ")
            Query.Append("   ,[B].RefNo ")
            Query.Append("   ,[B].Remarks ")
            Query.Append("   ,isnull(format([B].DueDate,'MM/dd/yyyy'),'') [DueDate] ")
            Query.Append("   ,[B].IsPickUp ")
            Query.Append("   ,[B].IsDeposit ")
            Query.Append("   ,[B].BankName ")
            Query.Append("   ,[B].AcctName ")
            Query.Append("   ,[B].AcctNo ")
            Query.Append("   ,isnull([B].WithEWT, 0) [WithEWT] ")
            Query.Append("   ,isnull(Format([B].GrossAmount, 'N2'), 0.00) [GrossAmt] ")
            Query.Append("   ,isnull(Format([B].EWT, 'N2'), 0.00) [EWT] ")
            Query.Append("   ,isnull(Format([B].NetAmount, 'N2'), 0.00) [NetAmt] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join Form_RMBHdr [B] on [A].tbl_code = [B].RMBCode ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("   left join business [F] on [B].BrnchCode = [F].buss_code ")
            Query.Append("   left join employee [G] on [B].Payor = [G].emp_no ")
            Query.Append("   left join ogm_vendor [H] on [B].Payor = [H].v_code ")
            Query.Append("   left join department [I] on [B].DeptCode = [I].dept_code ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & ltrlID.Text & "' ")
            'get reimbursement

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        lbl01ID.Text = DR("ID")
                        lbl01FormType.Text = "Payment Request"
                        lbl01DateRequested.Text = Format(DR("DateCreated"), "MM/dd/yyyy")
                        lbl01DateRequired.Text = Format(DR("DateRequired"), "MM/dd/yyyy")
                        lbl01RequestedBy.Text = DR("RequestedBy")
                        lbl01AssignedTo.Text = DR("AssignedTo")
                        lbl01EndorsedTo.Text = DR("EndorsedTo")
                        lbl01Status.Text = DR("Status")
                        lbl01Branch.Text = DR("Branch")
                        lbl01Fund.Text = DR("Fund")
                        lbl01PayeeType.Text = DR("PayeeType")
                        lbl01Payee.Text = DR("Payee")
                        lbl01Department.Text = DR("Department")
                        lbl01ReferenceNo.Text = DR("RefNo")
                        lbl01Remarks.Text = DR("Remarks")
                        lbl01DueDate.Text = DR("DueDate")
                        cbx0102IsPickUp.Checked = IIf(DR("IsPickUp") = 1, True, False)
                        cbx0102IsDeposit.Checked = IIf(DR("IsDeposit") = 1, True, False)
                        lbl01BankName.Text = DR("BankName")
                        lbl01AcctName.Text = DR("AcctName")
                        lbl01AcctNo.Text = DR("AcctNo")
                        cbx0102WithEWT.Checked = IIf(DR("WithEWT") = 1, True, False)
                        lbl01GrossAmt.Text = DR("GrossAmt")
                        lbl01EWT.Text = DR("EWT")
                        lbl01NetAmt.Text = DR("NetAmt")
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

    Function bind01Branch()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select branch' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [buss_code] [Value] ")
        Query.Append("	 ,[description] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 [business] ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Branch.DataSource = DT
        ddl01Branch.DataValueField = "Value"
        ddl01Branch.DataTextField = "Text"
        ddl01Branch.DataBind()
        'fill data

    End Function

    Function bind01Payee(Payee)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("if '" & Payee & "' = 'Employee' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_employee ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if '" & Payee & "'  = 'Vendor' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_vendor ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        'get total task

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Payee.DataSource = DT
        ddl01Payee.DataValueField = "Value"
        ddl01Payee.DataTextField = "Text"
        ddl01Payee.DataBind()
        'fill data

    End Function

    Function bind01Department()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select department' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [dept_code] [Value] ")
        Query.Append("	 ,[description] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 [department] ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

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

        ''validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        ''validate

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
            bind06RMBDtl()
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
            ElseIf ddl01Branch.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Fund.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01PayeeType.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Payee.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Department.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01ReferenceNo.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Remarks.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01DueDate.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf cbx0101IsDeposit.Checked = True And (tbx01BankName.Value = "" Or tbx01AcctName.Value = "" Or tbx01AcctNo.Value = "") Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Department.SelectedValue = "2014000003" And cbx0101WithEWT.Checked = True And (tbx01EWT.Value = "") Then
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

            'Validate record
            If tbx01DateRequired.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Branch.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Fund.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01PayeeType.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Payee.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Department.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01ReferenceNo.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Remarks.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01DueDate.Value = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf cbx0101IsDeposit.Checked = True And (tbx01BankName.Value = "" Or tbx01AcctName.Value = "" Or tbx01AcctNo.Value = "") Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Department.SelectedValue = "2014000003" And cbx0101WithEWT.Checked = True And (tbx01EWT.Value = "") Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01PayeeType.SelectedValue = "" Or ddl01Payee.SelectedValue = "" Then
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

        'cancel record
        If ltrlMode.Text = "ADD" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_FRM000017"
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Value)
            SqlCmd.Parameters.AddWithValue("@pBranch", ddl01Branch.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pFund", ddl01Fund.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pPayeeType", ddl01PayeeType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pPayee", ddl01Payee.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pDepartment", ddl01Department.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pReferenceNo", tbx01ReferenceNo.Value)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Remarks.Text)
            SqlCmd.Parameters.AddWithValue("@pDueDate", tbx01DueDate.Value)
            SqlCmd.Parameters.AddWithValue("@pIsPickUp", IIf(cbx0101IsPickUp.Checked = True, 1, 0))
            SqlCmd.Parameters.AddWithValue("@pIsDeposit", IIf(cbx0101IsDeposit.Checked = True, 1, 0))
            SqlCmd.Parameters.AddWithValue("@pBankName", IIf(cbx0101IsDeposit.Checked = True, tbx01BankName.Value, "-"))
            SqlCmd.Parameters.AddWithValue("@pAcctName", IIf(cbx0101IsDeposit.Checked = True, tbx01AcctName.Value, "-"))
            SqlCmd.Parameters.AddWithValue("@pAcctNo", IIf(cbx0101IsDeposit.Checked = True, tbx01AcctNo.Value, "-"))
            SqlCmd.Parameters.AddWithValue("@pWithEWT", IIf(cbx0101WithEWT.Checked = True, 1, 0))
            SqlCmd.Parameters.AddWithValue("@pGrossAmt", IIf(tbx01GrossAmt.Value = "", 0.00, CDbl(tbx01GrossAmt.Value)))
            SqlCmd.Parameters.AddWithValue("@pEWT", IIf(tbx01EWT.Value = "", 0.00, CDbl(tbx01EWT.Value)))
            SqlCmd.Parameters.AddWithValue("@pNetAmt", IIf(tbx01NetAmt.Value = "", 0.00, CDbl(tbx01NetAmt.Value)))
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
            SqlCmd.CommandText = "Upd_FRM_FRM000017"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Value)
            SqlCmd.Parameters.AddWithValue("@pBranch", ddl01Branch.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pFund", ddl01Fund.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pPayeeType", ddl01PayeeType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pPayee", ddl01Payee.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pDepartment", ddl01Department.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pReferenceNo", tbx01ReferenceNo.Value)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Remarks.Text)
            SqlCmd.Parameters.AddWithValue("@pDueDate", tbx01DueDate.Value)
            SqlCmd.Parameters.AddWithValue("@pIsPIckUp", IIf(cbx0101IsPickUp.Checked = True, 1, 0))
            SqlCmd.Parameters.AddWithValue("@pIsDeposit", IIf(cbx0101IsDeposit.Checked = True, 1, 0))
            SqlCmd.Parameters.AddWithValue("@pBankName", IIf(cbx0101IsDeposit.Checked = True, tbx01BankName.Value, "-"))
            SqlCmd.Parameters.AddWithValue("@pAcctName", IIf(cbx0101IsDeposit.Checked = True, tbx01AcctName.Value, "-"))
            SqlCmd.Parameters.AddWithValue("@pAcctNo", IIf(cbx0101IsDeposit.Checked = True, tbx01AcctNo.Value, "-"))
            SqlCmd.Parameters.AddWithValue("@pWithEWT", IIf(cbx0101WithEWT.Checked = True, 1, 0))
            SqlCmd.Parameters.AddWithValue("@pGrossAmt", IIf(tbx01GrossAmt.Value = "", 0.00, CDbl(tbx01GrossAmt.Value)))
            SqlCmd.Parameters.AddWithValue("@pEWT", IIf(tbx01EWT.Value = "", 0.00, CDbl(tbx01EWT.Value)))
            SqlCmd.Parameters.AddWithValue("@pNetAmt", IIf(tbx01NetAmt.Value = "", 0.00, CDbl(tbx01NetAmt.Value)))
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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000008.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000008.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000008.rpt"))
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
        RptDoc.SetParameterValue("@pFormNo", ltrlID.Text)
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000008.pdf"), Buf)
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

        'view report
        RptDoc.Dispose()
        RptDoc.Close()
        Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000008.pdf")
        ScriptManager.RegisterStartupScript(upnl01Overview, upnl01Overview.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
        'view report

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
        Query.Append("      [A].tbl_from = 'Form_RMBHdr' ")
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
        Query.Append("      [A].tbl_from = 'Form_RMBHdr' ")
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
        Query.Append("      [A].tbl_from = 'Form_RMBHdr' ")
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
        Query.Append("   [A].created_by [Code] ")
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

#Region "Paymet Request"

    Function bind06RMBDtl()

        'get item
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].SeqNo ")
        Query.Append("   ,[A].Item [Item] ")
        Query.Append("   ,FORMAT([A].Qty,'N2') [Qty] ")
        Query.Append("   ,[A].Unit [Unit] ")
        Query.Append("   ,FORMAT([A].Amount,'N2') [Amount] ")
        Query.Append("   ,isnull([C].description,'') [Division] ")
        Query.Append("   ,isnull([D].description,'') [Expense] ")
        Query.Append("   ,isnull([A].Subsidiary,'') [Subsidiary] ")
        Query.Append("   ,isnull((case	  when [A].Subsidiary = 'LOT' then [LT].description ")
        Query.Append("            when [A].Subsidiary = 'MISCELLANEOUS' then [MS].description ")
        Query.Append("            when [A].Subsidiary = 'MODEL HOUSE' then [HS].description ")
        Query.Append("            when [A].Subsidiary = 'NO SUBSIDIARY' then '' ")
        Query.Append("            when [A].Subsidiary = 'PHASE' then [PH].description ")
        Query.Append("            when [A].Subsidiary = 'SUBDIVISION' then [SB].description ")
        Query.Append("            else '' end),'') [Code] ")
        Query.Append("from ")
        Query.Append("   Form_RMBDtl [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].RMBCode = [B].tbl_code ")
        Query.Append("   left join Division [C] on [A].Division = [C].div_code ")
        Query.Append("   left join fin_chart [D] on [A].Expense = [D].acct_code ")
        Query.Append("   left join sub_lot [LT] on [A].Code = [LT].code ")
        Query.Append("   left join sub_misc [MS] on [A].Code = [MS].code ")
        Query.Append("   left join sub_house [HS] on [A].Code = [HS].code ")
        Query.Append("   left join sub_phase [PH] on [A].Code = [PH].code ")
        Query.Append("   left join sub_subdivision [SB] on [A].Code = [SB].code ")
        Query.Append("where ")
        Query.Append("   [B].f_code = '" & ltrlID.Text & "' ")
        Query.Append("order by ")
        Query.Append("   [A].SeqNo ")
        'get item

        Dim Total As Decimal = 0

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("Item"))
        dtable.Columns.Add(New DataColumn("Qty"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("Amount"))
        dtable.Columns.Add(New DataColumn("Division"))
        dtable.Columns.Add(New DataColumn("Expense"))
        dtable.Columns.Add(New DataColumn("Subsidiary"))
        dtable.Columns.Add(New DataColumn("Code"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Total = Total + CDbl(DR("Amount"))

                    Dim Division = IIf(DR("Division") = "", "-", DR("Division"))
                    Dim Expense = IIf(DR("Expense") = "", "-", DR("Expense"))
                    Dim Subsidiary = IIf(DR("Subsidiary") = "", "-", DR("Subsidiary"))
                    Dim Code = IIf(DR("Code") = "", "-", DR("Code"))
                    'add new row
                    Dim NewRowValues As Object() = {DR("SeqNo"), DR("Item"), DR("Qty"), DR("Unit"), DR("Amount"), Division, Expense, Subsidiary, Code}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv06RMBDtl.DataSource = dtable
        gv06RMBDtl.DataBind()
        'bind datatable

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv06RMBDtl.Rows.Count > 0 Then

            'Adds THEAD and TBODY Section.
            gv06RMBDtl.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv06RMBDtl.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 

            'gv06RMBDtl.FooterRow.TableSection = TableRowSection.TableFooter
            gv06RMBDtl.FooterRow.Cells(4).Text = "Total"
            gv06RMBDtl.FooterRow.Cells(5).Text = Format(Total, "N2")
            gv06RMBDtl.FooterRow.CssClass = "border-top fw-bold fs-6 text-dark"
            'Adds TFOOT section. 

        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'set value
        lbl01GrossAmt.Text = Format(Total, "N2")
        tbx01GrossAmt.Value = Format(Total, "N2")

        'condition
        If lbl01EWT.Text = "-" Then
            lbl01NetAmt.Text = "0.00"
            tbx01NetAmt.Value = "0.00"
        Else
            If Total = 0 Then
                lbl01NetAmt.Text = "0.00"
                tbx01NetAmt.Value = "0.00"
            Else
                lbl01NetAmt.Text = Format(CDbl(lbl01GrossAmt.Text) - CDbl(lbl01EWT.Text), "N2")
                tbx01NetAmt.Value = Format(CDbl(tbx01GrossAmt.Value) - CDbl(tbx01EWT.Value), "N2")
            End If
        End If

        'update 
        upnl01Overview.Update()
        upnl06RMBDtl.Update()
        'update 

    End Function

    Function bind06Division(Mode)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select division' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [div_code] [Value] ")
        Query.Append("	 ,[description] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 [division] ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        If Mode = "ADD" Then
            ddl06RMBDtlAddDivision.DataSource = DT
            ddl06RMBDtlAddDivision.DataValueField = "Value"
            ddl06RMBDtlAddDivision.DataTextField = "Text"
            ddl06RMBDtlAddDivision.DataBind()
        ElseIf Mode = "UPD" Then
            ddl06RMBDtlUpdDivision.DataSource = DT
            ddl06RMBDtlUpdDivision.DataValueField = "Value"
            ddl06RMBDtlUpdDivision.DataTextField = "Text"
            ddl06RMBDtlUpdDivision.DataBind()
        End If
        'fill data

    End Function

    Function bind06Expsense(Mode)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select expense' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [A].Expense [Value] ")
        Query.Append("	,[B].[description] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 Parm_PaymentRequest_Expense [A] ")
        Query.Append("	 left join fin_chart [B] on [A].Expense = [B].acct_code ")
        Query.Append("where ")
        Query.Append("   [A].Fund = '" & lbl01Fund.Text & "' ")
        Query.Append("   and [B].acct_type = 'EXPENSE' ")
        Query.Append("   and [B].lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        If Mode = "ADD" Then
            ddl06RMBDtlAddExpense.DataSource = DT
            ddl06RMBDtlAddExpense.DataValueField = "Value"
            ddl06RMBDtlAddExpense.DataTextField = "Text"
            ddl06RMBDtlAddExpense.DataBind()
        ElseIf Mode = "UPD" Then
            ddl06RMBDtlUpdExpense.DataSource = DT
            ddl06RMBDtlUpdExpense.DataValueField = "Value"
            ddl06RMBDtlUpdExpense.DataTextField = "Text"
            ddl06RMBDtlUpdExpense.DataBind()
        End If
        'fill data

    End Function

    Function bind06Description(Mode, Expense)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("declare @Subsidiary nvarchar(20) = isnull((select subsidiary from fin_chart where acct_code = '" & Expense & "'),'') ")
        Query.Append("if @Subsidiary = 'LOT' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_lot ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'MISCELLANEOUS' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_misc ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("      and account = '" & Expense & "' ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'MODEL HOUSE' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_house ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary in ('NO SUBSIDIARY','') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      '-' [Value] ")
        Query.Append("      ,'No Subsidiary' [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'PHASE' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_phase ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'SUBDIVISION' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_subdivision ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        If Mode = "ADD" Then
            ddl06RMBDtlAddCode.Items.Clear()
            ddl06RMBDtlAddCode.DataSource = DT
            ddl06RMBDtlAddCode.DataValueField = "Value"
            ddl06RMBDtlAddCode.DataTextField = "Text"
            ddl06RMBDtlAddCode.DataBind()
        ElseIf Mode = "UPD" Then
            ddl06RMBDtlUpdCode.Items.Clear()
            ddl06RMBDtlUpdCode.DataSource = DT
            ddl06RMBDtlUpdCode.DataValueField = "Value"
            ddl06RMBDtlUpdCode.DataTextField = "Text"
            ddl06RMBDtlUpdCode.DataBind()
        End If
        'fill data

    End Function

    Private Sub gv06RMBDtl_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv06RMBDtl.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim HeaderGridRow As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
            HeaderGridRow.TableSection = TableRowSection.TableHeader
            Dim HeaderCell As TableCell = New TableCell
            HeaderCell.Text = ""
            HeaderCell.ColumnSpan = 5
            HeaderGridRow.Cells.Add(HeaderCell)
            HeaderCell = New TableCell
            HeaderCell.Text = "For Cash Payment and Cash Liquidation Only"
            HeaderCell.ColumnSpan = 3
            HeaderCell.CssClass = "fw-bold fs-6 text-dark table-header-hover"
            HeaderGridRow.Cells.Add(HeaderCell)
            gv06RMBDtl.Controls(0).Controls.AddAt(0, HeaderGridRow)
        End If
    End Sub

    Private Sub lbtn06RMBDtlAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn06RMBDtlAdd.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06RMBDtl", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'set value
            ltrlDtlMode.Text = "ADD"
            tbx06RMBDtlAddItem.Text = ""
            tbx06RMBDtlAddQty.Value = "0.00"
            tbx06RMBDtlAddUnit.Text = ""
            tbx06RMBDtlAddAmt.Value = "0.00"
            bind06Division("ADD")
            ddl06RMBDtlAddDivision.SelectedValue = ""
            bind06Expsense("ADD")
            ddl06RMBDtlAddExpense.SelectedValue = ""
            hf06RMBDtlAddSubsidiary.Value = ""
            bind06Description("ADD", "")
            ddl06RMBDtlAddCode.SelectedValue = ""
            mdl06RMBDtlAdd.Update()
            'set value

            'modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl06RMBDtlAdd').modal('show');</script>", False)
            'modal

        End If

    End Sub

    Private Sub lbtn06RMBDtlAddOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn06RMBDtlAddOk.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06RMBDtl", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        ElseIf tbx06RMBDtlAddItem.Text = "" Then
            Alert("error", "Some fields are missing! 1")
        ElseIf CDbl(tbx06RMBDtlAddQty.Value) <= 0 Then
            Alert("error", "Some fields are missing! 2")
        ElseIf tbx06RMBDtlAddUnit.Text = "" Then
            Alert("error", "Some fields are missing! 3")
        ElseIf CDbl(tbx06RMBDtlAddAmt.Value) <= 0 Then
            Alert("error", "Some fields are missing! 4")
        ElseIf ddl06RMBDtlAddDivision.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 5")
        ElseIf ddl06RMBDtlAddExpense.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 6")
        ElseIf hf06RMBDtlAddSubsidiary.Value = "" Then
            Alert("error", "Some fields are missing! 7")
        ElseIf hf06RMBDtlAddSubsidiary.Value = "LOT" Then
            Alert("error", "Some fields are missing! 8")
        ElseIf hf06RMBDtlAddSubsidiary.Value = "MISCELLANEOUS" And ddl06RMBDtlAddCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 9")
        ElseIf hf06RMBDtlAddSubsidiary.Value = "MODEL HOUSE" And ddl06RMBDtlAddCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 10")
        ElseIf hf06RMBDtlAddSubsidiary.Value = "PHASE" And ddl06RMBDtlAddCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 11")
        ElseIf hf06RMBDtlAddSubsidiary.Value = "SUBDIVISION" And ddl06RMBDtlAddCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 12")
        Else


            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_FRM000017_RMBDtl"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pItem", tbx06RMBDtlAddItem.Text)
            SqlCmd.Parameters.AddWithValue("@pQty", CDbl(tbx06RMBDtlAddQty.Value))
            SqlCmd.Parameters.AddWithValue("@pUnit", tbx06RMBDtlAddUnit.Text)
            SqlCmd.Parameters.AddWithValue("@pAmount", CDbl(tbx06RMBDtlAddAmt.Value))
            SqlCmd.Parameters.AddWithValue("@pDivision", ddl06RMBDtlAddDivision.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pExpense", ddl06RMBDtlAddExpense.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pSubsidiary", hf06RMBDtlAddSubsidiary.Value)
            SqlCmd.Parameters.AddWithValue("@pCode", ddl06RMBDtlAddCode.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pEWT", CDbl(lbl01EWT.Text))
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'reset value
            ltrlDtlMode.Text = "ADD"
            tbx06RMBDtlAddItem.Text = ""
            tbx06RMBDtlAddQty.Value = "0.00"
            tbx06RMBDtlAddUnit.Text = ""
            tbx06RMBDtlAddAmt.Value = "0.00"
            bind06Division("ADD")
            ddl06RMBDtlAddDivision.SelectedValue = ""
            bind06Expsense("ADD")
            ddl06RMBDtlAddExpense.SelectedValue = ""
            hf06RMBDtlAddSubsidiary.Value = ""
            ddl06RMBDtlAddCode.SelectedValue = ""
            bind06Description("ADD", "")
            mdl06RMBDtlAdd.Update()
            'reset value

            'success message
            Alert("success", "Particular successfully saved.")
            'success message

            'display item
            bind06RMBDtl()
            'display item

            'update panel 
            upnl06RMBDtl.Update()
            'update panel 

        End If
        'validate record

    End Sub

    Protected Sub lbtn06RMBDtlDel(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06RMBDtl", "Delete", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("danger", Msg)
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Del_FRM_FRM000017_RMBDtl"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", CType(sender, LinkButton).CommandArgument)
            SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
            SqlCmd.Parameters.AddWithValue("@pEWT", CDbl(lbl01EWT.Text))
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'fill
            bind06RMBDtl()
            'fill

            'alert
            Alert("success", "Particular successfully remove.")
            'alert

        End If
        'validate record

    End Sub

    Protected Sub lbtn06RMBDtlUpd(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'validate record

        'create variable
        Dim Msg As String = Validate("06RMBDtl", "Save", "")
        'create variable

        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'get item
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].SeqNo ")
            Query.Append("   ,[A].Item [Item] ")
            Query.Append("   ,FORMAT([A].Qty,'N2') [Qty] ")
            Query.Append("   ,[A].Unit [Unit] ")
            Query.Append("   ,FORMAT([A].Amount,'N2') [Amount] ")
            Query.Append("   ,[A].Division ")
            Query.Append("   ,[A].Expense ")
            Query.Append("   ,[A].Subsidiary ")
            Query.Append("   ,[A].Code ")
            Query.Append("from ")
            Query.Append("   Form_RMBDtl [A] ")
            Query.Append("   left join oop_form_hdr [B] on [A].RMBCode = [B].tbl_code ")
            Query.Append("where ")
            Query.Append("   [B].f_code = '" & ltrlID.Text & "' ")
            Query.Append("   and [A].SeqNo = '" & CType(sender, LinkButton).CommandArgument & "' ")
            'get item

            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()

                        ltrlDtlMode.Text = "UPD"
                        ltrlSeqNo.Text = DR("SeqNo")
                        tbx06RMBDtlUpdItem.Text = DR("Item")
                        tbx06RMBDtlUpdQty.Value = DR("Qty")
                        tbx06RMBDtlUpdUnit.Text = DR("Unit")
                        tbx06RMBDtlUpdAmt.Value = DR("Amount")
                        bind06Division("UPD")
                        ddl06RMBDtlUpdDivision.SelectedValue = DR("Division")
                        bind06Expsense("UPD")
                        ddl06RMBDtlUpdExpense.SelectedValue = DR("Expense")
                        hf06RMBDtlUpdSubsidiary.Value = DR("Subsidiary")
                        bind06Description("UPD", DR("Expense"))
                        ddl06RMBDtlUpdCode.SelectedValue = DR("Code")
                        mdl06RMBDtlUpd.Update()

                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using

            'modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl06RMBDtlUpd').modal('show');</script>", False)
            'modal

        End If

        'validate record

    End Sub

    Private Sub lbtn06RMBDtlUpdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn06RMBDtlUpdOk.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "Upd" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06RMBDtl", "Save", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        ElseIf tbx06RMBDtlUpdItem.Text = "" Then
            Alert("error", "Some fields are missing! 1")
        ElseIf CDbl(tbx06RMBDtlUpdQty.Value) <= 0 Then
            Alert("error", "Some fields are missing! 2")
        ElseIf tbx06RMBDtlUpdUnit.Text = "" Then
            Alert("error", "Some fields are missing! 3")
        ElseIf CDbl(tbx06RMBDtlUpdAmt.Value) <= 0 Then
            Alert("error", "Some fields are missing! 4")
        ElseIf ddl06RMBDtlUpdDivision.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 5")
        ElseIf ddl06RMBDtlUpdExpense.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 6")
        ElseIf hf06RMBDtlUpdSubsidiary.Value = "" Then
            Alert("error", "Some fields are missing! 7")
        ElseIf hf06RMBDtlUpdSubsidiary.Value = "LOT" Then
            Alert("error", "Some fields are missing! 8")
        ElseIf hf06RMBDtlUpdSubsidiary.Value = "MISCELLANEOUS" And ddl06RMBDtlUpdCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 9")
        ElseIf hf06RMBDtlUpdSubsidiary.Value = "MODEL HOUSE" And ddl06RMBDtlUpdCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 10")
        ElseIf hf06RMBDtlUpdSubsidiary.Value = "PHASE" And ddl06RMBDtlUpdCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 11")
        ElseIf hf06RMBDtlUpdSubsidiary.Value = "SUBDIVISION" And ddl06RMBDtlUpdCode.SelectedValue = "" Then
            Alert("error", "Some fields are missing! 12")
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_FRM_FRM000017_RMBDtl"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", ltrlSeqNo.Text)
            SqlCmd.Parameters.AddWithValue("@pItem", tbx06RMBDtlUpdItem.Text)
            SqlCmd.Parameters.AddWithValue("@pQty", CDbl(tbx06RMBDtlUpdQty.Value))
            SqlCmd.Parameters.AddWithValue("@pUnit", tbx06RMBDtlUpdUnit.Text)
            SqlCmd.Parameters.AddWithValue("@pAmount", CDbl(tbx06RMBDtlUpdAmt.Value))
            SqlCmd.Parameters.AddWithValue("@pDivision", ddl06RMBDtlUpdDivision.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pExpense", ddl06RMBDtlUpdExpense.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pSubsidiary", hf06RMBDtlUpdSubsidiary.Value)
            SqlCmd.Parameters.AddWithValue("@pCode", ddl06RMBDtlUpdCode.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pEWT", CDbl(lbl01EWT.Text))
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'success message
            Alert("success", "Particular successfully saved.")
            'success message

            'display item
            bind06RMBDtl()
            'display item

            'update panel 
            upnl06RMBDtl.Update()
            'update panel 

        End If
        'validate record

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