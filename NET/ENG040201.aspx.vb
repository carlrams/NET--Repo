Imports System.Data.SqlClient
Imports System.IO

Public Class ENG040201
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
        Master.setActiveMenu("APP", "ENG040200")
        'active account / menu

        'Record
        ltrlFormCode.Text = "ENG040201"
        'Record

        ''create variable
        'Dim Msg As String = Validate("Access", "View", "")
        ''create variable

        ''validate access
        'If Msg <> "" Then
        '    Response.Redirect("MNU000022")
        'End If
        ''validate access

        'load page
        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString().Replace("No", "#")
            ltrlSubID.Text = "009"
            'Record

            'tagged notifition as seen
            Seen()
            'tagged notifition as seen

            'display record
            bindTitle()
            bind01Overview()
            bind02Files()
            bind05Notes()
            'display record

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

        'set value
        'lblTask.Text = "-"
        lblTitle.Text = "-"
        lblID.Text = "-"
        lblStatus.Text = "-"
        'set value

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [ID] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].Status ")
        Query.Append("   ,[E].TaskName [Task] ")
        Query.Append("   ,dbo.Get_Icon('Form_HWTask-' + [A].TaskCode) [Icon] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join Mstr_TaskTemplate [E] on [A].TaskCode = [E].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ltrlID.Text & "' ")
        Query.Append("   and [A].TaskCode = '" & ltrlSubID.Text & "' ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    'lblTask.Text = DR("Task")
                    'imgIcon.ImageUrl = DR("Icon")
                    lblTitle.Text = DR("Title")
                    lblID.Text = DR("ID")
                    lblStatus.Text = DR("Status")
                    If lblStatus.Text = "Assign" Then
                        lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                    ElseIf lblStatus.Text = "On-Going" Then
                        lblStatus.Attributes.Add("class", "badge badge-lg badge-light-info")
                    ElseIf lblStatus.Text = "On-Hold" Then
                        lblStatus.Attributes.Add("class", "badge badge-lg badge-light-warning")
                    ElseIf lblStatus.Text = "Complete" Then
                        lblStatus.Attributes.Add("class", "badge badge-lg badge-light-success")
                    ElseIf lblStatus.Text = "Clarify" Then
                        lblStatus.Attributes.Add("class", "badge badge-lg badge-light-danger")
                    ElseIf lblStatus.Text = "Close" Then
                        lblStatus.Attributes.Add("class", "badge badge-lg badge-light-secondary")
                    End If
                    'set value

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display record
        upnlTitle.Update()
        'display record

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

        If Group_ = "02Files" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select Status from Form_HWTask where HWCode = '" & ltrlID.Text & "' and TaskCode = '" & ltrlSubID.Text & "') in ('Close') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select Status from Form_HWTask where HWCode = '" & ltrlID.Text & "' and TaskCode = '" & ltrlSubID.Text & "') in ('Close') ")
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
            If Type = "Status" Then
                Query.Append("if (select AssignTo from Form_HWTask where HWCode = '" & ltrlID.Text & "' and TaskCode = '" & ltrlSubID.Text & "') not in ('" & CIIS_EmpCode & "') ")
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
        lbtn01Refresh.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Status.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1"
        'overview

        'file
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'file

        'approval path
        lbtn05Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        'approval path

        'update controls
        upnl01Overview.Update()
        upnl02Files.Update()
        upnl05Notes.Update()
        'update controls

    End Function

    Function DisableBtn()

        'overview
        lbtn01Refresh.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Status.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'overview

        'file
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'file

        'approval path
        lbtn05Add.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'approval path

        'update controls
        upnl01Overview.Update()
        upnl02Files.Update()
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

    Function bind01Overview()

        'set value
        lbl01ID.Text = "-"
        lbl01Project.Text = "-"
        lbl01AssignTo.Text = "-"
        lbl01Status.Text = "-"
        'set value

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [ID] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Project] ")
        Query.Append("   ,isnull([E].vendor,'') [Contractor] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) + ' ' + dbo.ProperCase([F].last_name) [AssignTo] ")
        Query.Append("   ,[A].Status ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ltrlID.Text & "' ")
        Query.Append("   and [A].TaskCode = '" & ltrlSubID.Text & "' ")
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
                    lbl01Project.Text = DR("Project")
                    lbl01AssignTo.Text = DR("AssignTo")
                    lbl01Status.Text = DR("Status")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        upnl01Overview.Update()
        'display data

    End Function

    Protected Sub lbtn01Refresh_Click(ByVal sender As Object, e As EventArgs)

        'display record
        bindTitle()
        bind01Overview()
        bind02Files()
        bind05Notes()
        'display record

    End Sub

    Protected Sub lbtn01Status_Click(ByVal sender As Object, e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
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
            hdnMention.Value = ""
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
        Query.Append("   lock = 1 ")
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

    Protected Sub lbtn01StatusSave_Click(ByVal sender As Object, e As EventArgs)

        'validate fields
        If ddl01Status.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
        ElseIf ddl01AssignTo.SelectedValue = "" Then
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
                SqlCmd.CommandText = "Upd_CON_Status"
                SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
                SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
                SqlCmd.Parameters.AddWithValue("@pSubID", ltrlSubID.Text)
                SqlCmd.Parameters.AddWithValue("@pStatus", ddl01Status.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pActDateEnd", Date.Now)
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
                bind05Notes()
                'refresh record

            End If
            'validate record

        End If
        'validate fields

    End Sub

#End Region

#Region "Files"

    Function bind02Files()

        'Create datatable for list
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        dtable.Columns.Add(New DataColumn("lbtn02Delete1"))
        dtable.Columns.Add(New DataColumn("lbtn02Download1"))
        'Create datatable for list

        'create inner html for photos
        Dim Photos As New StringBuilder

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
                    'gallery
                    Photos.Append("<div class='col'> ")
                    Photos.Append("   <a class='d-block overlay' data-fslightbox='lightbox-hot-sales' href='Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/" & File.Name & "'> ")
                    Photos.Append("      <div class='overlay-wrapper bgi-no-repeat bgi-position-center bgi-size-cover card-rounded min-h-175px' style=""background-image:url('Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/" & File.Name & "')""></div> ")
                    Photos.Append("      <div class='overlay-layer card-rounded bg-dark bg-opacity-25'> ")
                    Photos.Append("         <i class='bi bi-eye-fill fs-2x text-white'></i> ")
                    Photos.Append("      </div> ")
                    Photos.Append("   </a> ")
                    Photos.Append("</div> ")
                    'gallery
                ElseIf File.Name.Contains(".jpg") Or File.Name.Contains(".jpeg") Or File.Name.Contains(".jpe") Or File.Name.Contains(".jfif") Or File.Name.Contains(".JPG") Or File.Name.Contains(".JPEG") Or File.Name.Contains(".JPE") Or File.Name.Contains(".JFIF") Then
                    Icon = "<i class='las la-file-image fs-2qx'></i>"
                    'gallery
                    Photos.Append("<div class='col'> ")
                    Photos.Append("   <a class='d-block overlay' data-fslightbox='lightbox-hot-sales' href='Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/" & File.Name & "'> ")
                    Photos.Append("      <div class='overlay-wrapper bgi-no-repeat bgi-position-center bgi-size-cover card-rounded min-h-175px' style=""background-image:url('Assets/Upload/" & ltrlFormCode.Text & "/" & ltrlID.Text & "/" & File.Name & "')""></div> ")
                    Photos.Append("      <div class='overlay-layer card-rounded bg-dark bg-opacity-25'> ")
                    Photos.Append("         <i class='bi bi-eye-fill fs-2x text-white'></i> ")
                    Photos.Append("      </div> ")
                    Photos.Append("   </a> ")
                    Photos.Append("</div> ")
                    'gallery
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
                Dim current_RowValues As Object() = {Icon, File.Name, Format(File.CreationTime, "MM/dd/yyyy hh:mm tt"), "lbtn02Delete1(this, '" & File.Name & "')", "lbtn02Download1(this, '" & File.Name & "')"}
                Dim current_dRow As DataRow
                current_dRow = dtable.Rows.Add(current_RowValues)
                dtable.AcceptChanges()
                'add file

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gv02Files.DataSource = dataView
            gv02Files.DataBind()
            'bind datatable

            div02Photos.InnerHtml = Photos.ToString & "<script src='assets/plugins/custom/fslightbox/fslightbox.bundle.js'></script>"

            'display data
            upnl02Files.Update()
            upnl02Photos.Update()
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
            upnl02Photos.Update()
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

    Protected Sub lbtn02Upload_Click(ByVal sender As Object, e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
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

    Protected Sub lbtn02UploadSave_Click(ByVal sender As Object, e As EventArgs)
        bind02Files()
    End Sub

    Protected Sub lbtn02Delete(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
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
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Del_File"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pType", "Removed a file:")
            SqlCmd.Parameters.AddWithValue("@pDescription", hfFileName.Value)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

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
        Query.Append("   and [A].SubID = '" & ltrlSubID.Text & "' ")
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

    Protected Sub lbtn05Add_Click(ByVal sender As Object, e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        'validate

        'clear record
        tbx05Note.Text = ""
        'clear record

        'display modal
        mdl05Comment.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl05Comment').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub lbtn05NoteAdd_Click(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
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
            SqlCmd.Parameters.AddWithValue("@pSubID", ltrlSubID.Text)
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

End Class