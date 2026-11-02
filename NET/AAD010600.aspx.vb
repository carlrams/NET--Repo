Imports System.Data.SqlClient
Imports System.IO

Public Class PendingRequirements
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "iis"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "AAD010000")
        'active account / menu

        If IsPostBack = False Then

            lblDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")
            bindREQForVerificationListTotal()
            bindREQForVerificationList()
            bindREQVerified()
            bindREQVerifiedListTotal()

            'If CIIS_Department = "Business Tech Department" Then
            '    'If CIIS_Department = "Customer Service" Then
            '    divCSButton.Visible = True
            'Else
            '    divCSButton.Visible = False
            'End If

        End If

    End Sub

#End Region

#Region "Modal Verified Submitted"

    Protected Sub btnViewREQVerifiedSubmitted_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Msg As String = Validate("REQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", Msg, "error")
            Exit Sub
        End If
        'validate access

        ''get
        'Dim Query As New StringBuilder

        'Query.Append("Select ")
        'Query.Append("    (case when [A].CSVerified is not null then 'bullet bullet-margin bullet-vertical h-40px bg-success' else 'bullet bullet-margin bullet-vertical h-40px bg-danger' end) [Bullet] ")
        'Query.Append("	 ,[A].PDCCode ")
        'Query.Append("	 ,[A].CheckDate ")
        'Query.Append("	 ,[A].CheckNo ")
        'Query.Append("	 ,(case when [A].CSVerified is not null then 'Verified' end) [Status] ")
        'Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        'Query.Append("from ")
        'Query.Append("	 bp_pdc [A] ")
        'Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        'Query.Append("where ")
        'Query.Append("    [A].Status = 'Pending' ")
        'Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        'Query.Append("    and [A].CSVerified is not null ")
        'Query.Append("order by ")
        'Query.Append("   [A].CheckDate ")
        ''get

        ''Create datatable and columns
        'Dim dtable As New DataTable
        'dtable.Columns.Add(New DataColumn("Bullet"))
        'dtable.Columns.Add(New DataColumn("CheckDate"))
        'dtable.Columns.Add(New DataColumn("CheckNo"))
        'dtable.Columns.Add(New DataColumn("Status"))
        'dtable.Columns.Add(New DataColumn("ViewREQVerifiedSubmittedDtl"))
        'dtable.Columns.Add(New DataColumn("Code"))
        ''Create datatable and columns

        ''read record
        'Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
        '    Using Cmd As New SqlCommand(Query.ToString)
        '        Cmd.CommandType = CommandType.Text
        '        Cmd.Connection = ConStr
        '        ConStr.Open()
        '        Dim DR As SqlDataReader = Cmd.ExecuteReader
        '        While DR.Read()

        '            Dim Title As String = DR("Title")
        '            Dim Bullet As String = DR("Bullet")
        '            Dim CheckDate As String = DR("CheckDate")
        '            Dim CheckNo As String = DR("CheckNo")
        '            Dim Status As String = DR("Status")
        '            Dim ViewREQVerifiedSubmittedDtl As String = "ViewREQVerifiedSubmittedDtl('" & DR("PDCCode") & "')"
        '            Dim Code As String = DR("PDCCode")

        '            'add new row
        '            Dim NewRowValues As Object() = {Bullet, CheckDate, CheckNo, Status, ViewREQVerifiedSubmittedDtl, Code}
        '            Dim NewRow As DataRow
        '            NewRow = dtable.Rows.Add(NewRowValues)
        '            'add new row

        '            lblREQVerifiedSubmittedTitle.Text = Title

        '        End While
        '        DR.Close()
        '        ConStr.Close()

        '    End Using
        'End Using
        ''read record

        ''bind datatable 
        'gvREQVerifiedSubmitted.DataSource = dtable
        'gvREQVerifiedSubmitted.DataBind()
        ''bind datatable 

        ''display data
        'RenderDatatable()
        'mdlREQVerifiedSubmitted.Update()
        'CallJS("$('#ContentPlaceHolder1_mdlREQVerifiedSubmitted').modal('show');")
        ''display Data


        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("    [B].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("from ")
        Query.Append("	 bp_requirements [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].AcctNo = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'lbl01DocsCode.Text = DR.GetString(3)
                    'lbl01FilePath.Text = DR.GetString(4)
                    lbl01RequirementsTitle3.Text = DR.GetString(0) & " | " & DR.GetString(1) & " - Requirements"
                    lbl01AcctNo3.Text = DR.GetString(0)
                    lbl01Name3.Text = DR.GetString(1)
                    'lbl01Description.Text = DR.GetString(5)
                    'lbl01DateSubmitted.Text = Format(DR.GetDateTime(6), "MM/dd/yyyy")
                    'lbl01Remarks.Text = DR.GetString(7)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        bind03PendingTotalLackingDocs()
        bind03PendingLackingDocs()
        bind03PendingFiles()
        mdlREQForVerificationSubmitted3.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlREQForVerificationSubmitted3').modal('show');</script>", False)
        'display data

    End Sub

#End Region

#Region "Modal Verified Submitted Dtl"

#End Region

#Region "Modal For Verification Submitted"

    Protected Sub DownloadPending(ByVal sender As Object, ByVal e As EventArgs)

        'Response.Clear()
        'Response.Buffer = True
        'Response.Charset = ""
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.ContentType = "application/octet-stream"
        'Response.AddHeader("content-disposition", "attachment; filename=" & CType(sender, LinkButton).CommandArgument)
        'Response.WriteFile("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lbl01AcctNo.Text & "\" & "Requirements" & "\" & lbl01Description.Text & "\" & CType(sender, LinkButton).CommandArgument)
        'Response.Flush()
        'Response.End()

    End Sub

    Function bind01PendingLackingDocs()

        'get for submission
        Dim Query As New StringBuilder


        Query.Append("select ")
        Query.Append("    [A].Code ")
        Query.Append("	 ,[A].ReqDesc ")
        Query.Append("	 ,[A].Type ")
        Query.Append("	 ,(select (case when [A].Code = bp_requirements.DocsCode then 'Assets/media/svg/Custom/check.svg' else 'Assets/media/svg/Custom/x.svg' end) from bp_requirements where AcctNo = [A].AcctNo) [Status] ")
        Query.Append("from ")
        Query.Append("	 calmardbLive.dbo.JCF_AcctRequirements [A] ")
        Query.Append("	 left join bp_requirements [B] on [A].ReqDesc = [B].DocsDesc ")
        Query.Append("where ")
        Query.Append("   [B].DocsDesc is null ")
        Query.Append("   and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("   and isnull([A].Status,'') != 'N/A' ")
        Query.Append("   and [A].SeqNo != 0 ")
        Query.Append("   and [A].Rcvd = 0 ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("    [A].Code ")
        Query.Append("	 ,[A].ReqDesc ")
        Query.Append("	 ,[A].Type ")
        Query.Append("	 ,(select (case when [A].Code = bp_requirements.DocsCode then 'Assets/media/svg/Custom/check.svg' else 'Assets/media/svg/Custom/x.svg' end) from bp_requirements where AcctNo = [A].AcctNo) [Status] ")
        Query.Append("from ")
        Query.Append("	 calmardbLive.dbo.JCF_AcctRequirements [A] ")
        Query.Append("	 left join bp_requirements [B] on [A].ReqDesc = [B].DocsDesc ")
        Query.Append("where ")
        Query.Append("   [B].DocsDesc is not null ")
        Query.Append("   and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("   and isnull([A].Status,'') != 'N/A' ")
        Query.Append("   and [A].SeqNo != 0 ")
        Query.Append("   and [A].Rcvd = 0 ")
        Query.Append("order by ")
        Query.Append("   [A].Code ")

        'Query.Append("select  ")
        'Query.Append("    [A].Code ")
        'Query.Append("	 ,[A].ReqDesc ")
        'Query.Append("	 ,[A].Type ")
        ''Query.Append("	 ,(case when [A].Code = '" & lbl01DocsCode.Text & "' then 'Assets/media/svg/Custom/check.svg' else 'Assets/media/svg/Custom/x.svg' end) [SubmittedStatus] ")
        'Query.Append("from ")
        'Query.Append("	 calmardbLive.dbo.JCF_AcctRequirements [A] ")
        'Query.Append("	 left join bp_requirements [B] on [A].Code = [B].DocsCode ")
        'Query.Append("where ")
        ''Query.Append("   [A].AcctNo = '" & lbl01AcctNo.Text & "' ")
        'Query.Append("   [A].AcctNo = 'CHN0000066' ")
        'Query.Append("   and isnull([A].Status,'') != 'N/A' ")
        'Query.Append("   and [A].SeqNo != 0 ")
        'Query.Append("   and [A].Rcvd = 0 ")
        'Query.Append("order by ")
        'Query.Append("   [A].Code ")
        'get for submission 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("ReqDesc"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("SubmittedStatus"))
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
                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3)}
                    'Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2)}
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
        gv01LackingDocs.DataSource = dtable
        gv01LackingDocs.DataBind()
        'bind datatable 

        'display data
        'upnlRequirementsPending.Update()
        upnlREQForVerificationList.Update()
        'display data

    End Function

    Function bind03PendingLackingDocs()

        'get for submission
        Dim Query As New StringBuilder


        Query.Append("select ")
        Query.Append("    [A].Code ")
        Query.Append("	 ,[A].ReqDesc ")
        Query.Append("	 ,[A].Type ")
        Query.Append("	 ,(select (case when [A].AcctNo = [B].AcctNo and [A].Code = [B].DocsCode then 'Assets/media/svg/Custom/check.svg' else 'Assets/media/svg/Custom/x.svg' end)) [Status] ")
        Query.Append("	 ,(select (case when [A].AcctNo = [B].AcctNo and [A].Code = [B].DocsCode and [B].Status = 'Approved' then 'Assets/media/svg/Custom/check.svg' else 'Assets/media/svg/Custom/x.svg' end)) [StatusSubmitted] ")
        Query.Append("from ")
        Query.Append("	 calmardbLive.dbo.JCF_AcctRequirements [A] ")
        Query.Append("	 left join bp_requirements [B] on  [A].Code = [B].DocsCode ")
        Query.Append("where ")
        Query.Append("   [B].DocsDesc is null ")
        Query.Append("   and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("   and isnull([A].Status,'') != 'N/A' ")
        Query.Append("   and [A].SeqNo != 0 ")
        Query.Append("   and [A].Rcvd = 0 ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("    [A].Code ")
        Query.Append("	 ,[A].ReqDesc ")
        Query.Append("	 ,[A].Type ")
        Query.Append("	 ,(select (case when [A].AcctNo = [B].AcctNo and [A].Code = [B].DocsCode then 'Assets/media/svg/Custom/check.svg' else 'Assets/media/svg/Custom/x.svg' end)) [Status] ")
        Query.Append("	 ,(select (case when [A].AcctNo = [B].AcctNo and [A].Code = [B].DocsCode and [B].Status = 'Approved' then 'Assets/media/svg/Custom/check.svg' else 'Assets/media/svg/Custom/x.svg' end)) [StatusSubmitted] ")
        Query.Append(" from ")
        Query.Append("	 calmardbLive.dbo.JCF_AcctRequirements [A] ")
        Query.Append("	 left join bp_requirements [B] on [A].Code = [B].DocsCode ")
        Query.Append("where ")
        Query.Append("   [B].DocsDesc is not null ")
        Query.Append("   and [A].AcctNo = '" & hfID.Value & "' ")
        Query.Append("   and isnull([A].Status,'') != 'N/A' ")
        Query.Append("   and [A].SeqNo != 0 ")
        Query.Append("   and [A].Rcvd = 0 ")
        Query.Append("order by ")
        Query.Append("   [A].Code ")
        'get for submission 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("ReqDesc"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("SubmittedStatus"))
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
                    Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4)}
                    'Dim NewRowValues As Object() = {DR.GetString(0), DR.GetString(1), DR.GetString(2)}
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
        gv03LackingDocs.DataSource = dtable
        gv03LackingDocs.DataBind()
        'bind datatable 

        'display data
        'upnlRequirementsPending.Update()
        mdlREQForVerificationSubmitted3.Update()
        'display data

    End Function

    Function bind01PendingFiles()

        'get for submission
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("    REQCode ")
        Query.Append("	 ,DocsDesc ")
        Query.Append("from ")
        Query.Append("	 bp_requirements ")
        Query.Append("where ")
        Query.Append("   AcctNo = '" & hfID.Value & "' ")
        Query.Append("order by ")
        Query.Append("   REQCode ")
        'get for submission 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Description"))
        dtable.Columns.Add(New DataColumn("ViewREQForVerificationSubmittedDtl"))
        dtable.Columns.Add(New DataColumn("Code"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()


                    Dim Description As String = DR("DocsDesc")
                    Dim ViewREQForVerificationSubmittedDtl As String = "ViewREQForVerificationSubmittedDtl('" & DR("REQCode") & "')"
                    Dim Code As String = DR("REQCode")

                    'add new row
                    Dim NewRowValues As Object() = {Description, ViewREQForVerificationSubmittedDtl, Code}
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
        gv02Files.DataSource = dtable
        gv02Files.DataBind()
        'bind datatable 

        'display data
        'upnlRequirementsPending.Update()
        mdlREQForVerificationSubmitted2.Update()
        'display data

    End Function

    Function bind03PendingFiles()

        'get for submission
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("    REQCode ")
        Query.Append("	 ,DocsDesc ")
        Query.Append("from ")
        Query.Append("	 bp_requirements ")
        Query.Append("where ")
        Query.Append("   AcctNo = '" & hfID.Value & "' ")
        Query.Append("order by ")
        Query.Append("   REQCode ")
        'get for submission 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Description"))
        dtable.Columns.Add(New DataColumn("ViewREQVerifiedSubmittedDtl"))
        dtable.Columns.Add(New DataColumn("Code"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Description As String = DR("DocsDesc")
                    Dim ViewREQVerifiedSubmittedDtl As String = "ViewREQVerifiedSubmittedDtl('" & DR("REQCode") & "')"
                    Dim Code As String = DR("REQCode")

                    'add new row
                    Dim NewRowValues As Object() = {Description, ViewREQVerifiedSubmittedDtl, Code}
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
        gv03Files.DataSource = dtable
        gv03Files.DataBind()
        'bind datatable 

        'display data
        'upnlRequirementsPending.Update()
        mdlREQForVerificationSubmitted3.Update()
        'display data

    End Function

    Function bind01Attachments()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        'If Directory.Exists(Server.MapPath("~/Assets/Upload/" & lbl01AcctNo.Text & "/" & "Requirements" & "/" & lbl01Description.Text & "/")) Then
        If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lblREQForVerificationSubmittedDtlAcctNo.Text & "\" & "Requirements" & "\" & lblREQForVerificationSubmittedDtlDocument.Text & "\") Then

            'set folder
            'Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/" & lbl01AcctNo.Text & "/" & "Requirements" & "/" & lbl01Description.Text & "/"))
            Dim objDir As New DirectoryInfo("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lblREQForVerificationSubmittedDtlAcctNo.Text & "\" & "Requirements" & "\" & lblREQForVerificationSubmittedDtlDocument.Text & "\")
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

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvAttachments.DataSource = dataView
            gvAttachments.DataBind()
            'bind datatable

            'display data
            mdlREQForVerificationSubmittedDtl.Update()
            'display data

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvAttachments.DataSource = dataView
            gvAttachments.DataBind()
            'bind datatable

            'display data
            mdlREQForVerificationSubmittedDtl.Update()
            'display data

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvAttachments.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvAttachments.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gvAttachments.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bind01Attachments2()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        'If Directory.Exists(Server.MapPath("~/Assets/Upload/" & lbl01AcctNo.Text & "/" & "Requirements" & "/" & lbl01Description.Text & "/")) Then
        If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lblREQForVerificationSubmittedDtlAcctNo2.Text & "\" & "Requirements" & "\" & lblREQForVerificationSubmittedDtlDocument2.Text & "\") Then

            'set folder
            'Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/" & lbl01AcctNo.Text & "/" & "Requirements" & "/" & lbl01Description.Text & "/"))
            Dim objDir As New DirectoryInfo("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & lblREQForVerificationSubmittedDtlAcctNo2.Text & "\" & "Requirements" & "\" & lblREQForVerificationSubmittedDtlDocument2.Text & "\")
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

            Next
            'read file

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvAttachments2.DataSource = dataView
            gvAttachments2.DataBind()
            'bind datatable

            'display data
            mdlREQForVerificationSubmittedDtl2.Update()
            'display data

        Else

            'bind datatable
            Dim dataView As New Data.DataView(dtable)
            dataView.Sort = "CreationTime ASC"
            gvAttachments2.DataSource = dataView
            gvAttachments2.DataBind()
            'bind datatable

            'display data
            mdlREQForVerificationSubmittedDtl2.Update()
            'display data

        End If
        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvAttachments2.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvAttachments2.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gvAttachments2.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bind01PendingTotalLackingDocs()

        'get lacking docs count
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("	 (select count(REQCode) from bp_requirements where AcctNo = '" & hfID.Value & "' and Status = 'Pending') ")
        Query.Append("  ,count(Code) ")
        Query.Append("from ")
        Query.Append("	 calmardbLive.dbo.JCF_AcctRequirements ")
        Query.Append("where ")
        Query.Append("   AcctNo = '" & hfID.Value & "' ")
        Query.Append("   and isnull(Status,'') != 'N/A' ")
        Query.Append("   and SeqNo != 0 ")
        Query.Append("   and Rcvd = 0 ")
        'get lacking docs count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01TotalOverview.Text = DR.GetInt32(0) & " / " & DR.GetInt32(1)
                    lbl01SubmittedTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        'upnlRequirementsPending.Update()
        upnlREQForVerificationList.Update()
        'display data

    End Function

    Function bind03PendingTotalLackingDocs()

        'get lacking docs count
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("	 (select count(REQCode) from bp_requirements where AcctNo = '" & hfID.Value & "' and Status = 'Approved') ")
        Query.Append("  ,count(Code) ")
        Query.Append("from ")
        Query.Append("	 calmardbLive.dbo.JCF_AcctRequirements ")
        Query.Append("where ")
        Query.Append("   AcctNo = '" & hfID.Value & "' ")
        Query.Append("   and isnull(Status,'') != 'N/A' ")
        Query.Append("   and SeqNo != 0 ")
        Query.Append("   and Rcvd = 0 ")
        'get lacking docs count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl03TotalOverview.Text = DR.GetInt32(0) & " / " & DR.GetInt32(1)
                    lbl03SubmittedTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        'upnlRequirementsPending.Update()
        upnlREQForVerificationList.Update()
        'display data

    End Function

    Protected Sub btnViewREQForVerificationSubmitted_Click(ByVal sender As Object, e As EventArgs)

        ''create variable
        'Dim Msg As String = Validate("PDCAccess", "Save", "")
        ''create variable

        ''validate access
        'If Msg <> "" Then
        '    Alert("Access Denied!", Msg, "error")
        '    Exit Sub
        'End If
        ''validate access

        ''get
        'Dim Query As New StringBuilder

        'Query.Append("Select ")
        'Query.Append("	  [A].PDCCode ")
        'Query.Append("	 ,[A].CheckDate ")
        'Query.Append("	 ,[A].CheckNo ")
        'Query.Append("	 ,(case when [A].CSVerified is null then 'For Verification' end) [Status] ")
        'Query.Append("	 ,([A].AcctNo + ' - ' + [B].Fullname) [Title] ")
        'Query.Append("from ")
        'Query.Append("	 bp_pdc [A] ")
        'Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        'Query.Append("where ")
        'Query.Append("    [A].Status = 'Pending' ")
        'Query.Append("    and [A].AcctNo = '" & hfID.Value & "' ")
        'Query.Append("    and [A].CSVerified is null ")
        'Query.Append("order by ")
        'Query.Append("   [A].CheckDate ")
        ''get

        ''Create datatable and columns
        'Dim dtable As New DataTable
        'dtable.Columns.Add(New DataColumn("CheckDate"))
        'dtable.Columns.Add(New DataColumn("CheckNo"))
        'dtable.Columns.Add(New DataColumn("Status"))
        'dtable.Columns.Add(New DataColumn("ViewREQForVerificationSubmittedDtl"))
        'dtable.Columns.Add(New DataColumn("Code"))
        ''Create datatable and columns

        ''read record
        'Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
        '    Using Cmd As New SqlCommand(Query.ToString)
        '        Cmd.CommandType = CommandType.Text
        '        Cmd.Connection = ConStr
        '        ConStr.Open()
        '        Dim DR As SqlDataReader = Cmd.ExecuteReader
        '        While DR.Read()

        '            Dim Title As String = DR("Title")
        '            Dim CheckDate As String = DR("CheckDate")
        '            Dim CheckNo As String = DR("CheckNo")
        '            Dim Status As String = DR("Status")
        '            Dim ViewREQForVerificationSubmittedDtl As String = "ViewREQForVerificationSubmittedDtl('" & DR("PDCCode") & "')"
        '            Dim Code As String = DR("PDCCode")

        '            'add new row
        '            Dim NewRowValues As Object() = {CheckDate, CheckNo, Status, ViewREQForVerificationSubmittedDtl, Code}
        '            Dim NewRow As DataRow
        '            NewRow = dtable.Rows.Add(NewRowValues)
        '            'add new row

        '            lblREQForVerificationSubmittedTitle.Text = Title

        '        End While
        '        DR.Close()
        '        ConStr.Close()

        '    End Using
        'End Using
        ''read record

        ''bind datatable 
        'gvREQForVerificationSubmitted.DataSource = dtable
        'gvREQForVerificationSubmitted.DataBind()
        ''bind datatable 

        ''display data
        'RenderDatatable()
        'mdlREQForVerificationSubmitted2.Update()
        'CallJS("$('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').modal('show');")
        ''display Data

        'create variable
        Dim Msg As String = Validate("REQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert(Msg, "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("    [B].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("from ")
        Query.Append("	 bp_requirements [A] ")
        Query.Append("	 left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].AcctNo = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'lbl01DocsCode.Text = DR.GetString(3)
                    'lbl01FilePath.Text = DR.GetString(4)
                    lbl01RequirementsTitle.Text = DR.GetString(0) & " | " & DR.GetString(1) & " - Requirements"
                    lbl01AcctNo.Text = DR.GetString(0)
                    lbl01Name.Text = DR.GetString(1)
                    'lbl01Description.Text = DR.GetString(5)
                    'lbl01DateSubmitted.Text = Format(DR.GetDateTime(6), "MM/dd/yyyy")
                    'lbl01Remarks.Text = DR.GetString(7)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        bind01PendingTotalLackingDocs()
        bind01PendingLackingDocs()
        bind01PendingFiles()
        mdlREQForVerificationSubmitted2.Update()
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').modal('show');</script>", False)
        'display data


    End Sub

#End Region

#Region "Modal For Verification Submitted Dtl"

    Protected Sub btnViewREQForVerificationSubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("     [A].REQCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[B].Fullname ")
        Query.Append("    ,[A].DocsDesc ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,[B].Email ")
        Query.Append("from ")
        Query.Append("	bp_requirements [A] ")
        Query.Append("	left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].REQCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblREQForVerificationSubmittedDtlCode.Text = hfID.Value
                    lblREQForVerificationSubmittedDtlTitle.Text = DR.GetString(1) & " | " & DR.GetString(2) & " - Requirements"
                    lblREQForVerificationSubmittedDtlAcctNo.Text = DR.GetString(1)
                    lblREQForVerificationSubmittedDtlName.Text = DR.GetString(2)
                    lblREQForVerificationSubmittedDtlDocument.Text = DR.GetString(3)
                    lblREQForVerificationSubmittedDtlRemarks.Text = DR.GetString(4)
                    lblREQForVerificationSubmittedDtlEmail.Text = DR.GetString(5)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlREQForVerificationSubmittedDtl.Update()
        RenderDatatable()
        bind01Attachments()
        CallJS("$('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl').modal('show'); }, 250);")
        'display data


    End Sub

    Protected Sub btnViewREQVerifiedSubmittedDtl_Click(ByVal sender As Object, e As EventArgs)

        'get selected data
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("     [A].REQCode ")
        Query.Append("    ,[A].AcctNo ")
        Query.Append("    ,[B].Fullname ")
        Query.Append("    ,[A].DocsDesc ")
        Query.Append("    ,[A].Remarks ")
        Query.Append("    ,[A].Status ")
        Query.Append("    ,[B].Email ")
        Query.Append("from ")
        Query.Append("	bp_requirements [A] ")
        Query.Append("	left join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].REQCode = '" & hfID.Value & "' ")
        'get selected data

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblREQForVerificationSubmittedDtlCode2.Text = hfID.Value
                    lblREQForVerificationSubmittedDtlTitle2.Text = DR.GetString(1) & " | " & DR.GetString(2) & " - Requirements"
                    lblREQForVerificationSubmittedDtlAcctNo2.Text = DR.GetString(1)
                    lblREQForVerificationSubmittedDtlName2.Text = DR.GetString(2)
                    lblREQForVerificationSubmittedDtlDocument2.Text = DR.GetString(3)
                    lblREQForVerificationSubmittedDtlRemarks2.Text = DR.GetString(4)
                    lblREQForVerificationSubmittedDtlStatus2.Text = DR.GetString(5)
                    lblREQForVerificationSubmittedDtlEmail2.Text = DR.GetString(6)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        mdlREQForVerificationSubmittedDtl2.Update()
        RenderDatatable()
        bind01Attachments2()
        CallJS("$('#ContentPlaceHolder1_mdlREQForVerificationSubmitted3').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlREQForVerificationSubmitted3').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl2').modal('show'); }, 250);")
        'display data


    End Sub

    Protected Sub lbtnREQForVerificationSubmittedDtlClose2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQForVerificationSubmittedDtlClose2.Click

        lblREQForVerificationSubmittedDtlCode.Text = ""
        lblREQForVerificationSubmittedDtlEmail.Text = ""
        lblREQForVerificationSubmittedDtlAcctNo.Text = ""
        lblREQForVerificationSubmittedDtlName.Text = ""
        lblREQForVerificationSubmittedDtlDocument.Text = ""
        lblREQForVerificationSubmittedDtlRemarks.Text = ""
        ddlPDCPendingSubmittedDtlStatus.SelectedValue = ""
        tbxPDCPendingSubmittedDtlRemarks.Text = ""

        CallJS("$('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl2').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl2').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlREQForVerificationSubmitted3').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnPDCForVerificationSubmittedDtlCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQForVerificationSubmittedDtlCancel.Click

        lblREQForVerificationSubmittedDtlCode.Text = ""
        lblREQForVerificationSubmittedDtlEmail.Text = ""
        lblREQForVerificationSubmittedDtlAcctNo.Text = ""
        lblREQForVerificationSubmittedDtlName.Text = ""
        lblREQForVerificationSubmittedDtlDocument.Text = ""
        lblREQForVerificationSubmittedDtlRemarks.Text = ""
        ddlPDCPendingSubmittedDtlStatus.SelectedValue = ""
        tbxPDCPendingSubmittedDtlRemarks.Text = ""

        CallJS("$('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnREQForVerificationSubmittedDtlClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQForVerificationSubmittedDtlClose.Click

        lblREQForVerificationSubmittedDtlCode.Text = ""
        lblREQForVerificationSubmittedDtlEmail.Text = ""
        lblREQForVerificationSubmittedDtlAcctNo.Text = ""
        lblREQForVerificationSubmittedDtlName.Text = ""
        lblREQForVerificationSubmittedDtlDocument.Text = ""
        lblREQForVerificationSubmittedDtlRemarks.Text = ""
        ddlPDCPendingSubmittedDtlStatus.SelectedValue = ""
        tbxPDCPendingSubmittedDtlRemarks.Text = ""

        CallJS("$('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').modal('show'); }, 250);")

    End Sub

    Protected Sub lbtnINQBatchChangeStatusClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCBatchChangeStatusClose.Click

        ddlPDCBatchChangeStatusStatus.SelectedValue = ""
        tbxPDCBatchChangeStatusRemarks.Text = ""

        mdlREQForVerificationSubmitted2.Update()
        CallJS("$('#ContentPlaceHolder1_mdlREQBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlREQBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnPDCBatchChangeStatusCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCBatchChangeStatusCancel.Click

        ddlPDCBatchChangeStatusStatus.SelectedValue = ""
        tbxPDCBatchChangeStatusRemarks.Text = ""

        mdlREQForVerificationSubmitted2.Update()
        CallJS("$('#ContentPlaceHolder1_mdlREQBatchChangeStatus').delay(250); setTimeout(function(){ $('#ContentPlaceHolder1_mdlREQBatchChangeStatus').modal('hide'); }, 250); setTimeout(function () { $('#ContentPlaceHolder1_mdlREQForVerificationSubmitted2').modal('show'); }, 250); $('.checkBoxClass').prop('checked', false);")

    End Sub

    Protected Sub lbtnPDCBatchChangeStatusSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCBatchChangeStatusSave.Click

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        ' Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gv02Files.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gv02Files.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gv02Files.Rows(RowIdx).FindControl("lblID"), Label)

            ' If checkbox is checked, add the ID to the string
            If RowCheckbox.Checked = True Then
                IDSrs &= lblID.Text & "," ' Collect IDs, separated by commas
            End If

            RowIdx += 1
        Loop

        ' Remove the last comma
        If IDSrs.Length > 0 Then
            IDSrs = IDSrs.TrimEnd(","c)

            ' Call the method to delete the records using the stored procedure
            BatchChangeStatusSave(IDSrs)
        End If

    End Sub

    Function BatchChangeStatusSave(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprREQChangeStatus"
        SqlCmd.Parameters.AddWithValue("@pREQCode", "")
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pDocsCode", "")
        SqlCmd.Parameters.AddWithValue("@pAcctNo", "")
        SqlCmd.Parameters.AddWithValue("@pStatus", ddlPDCBatchChangeStatusStatus.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxPDCBatchChangeStatusRemarks.Text)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'success alert
        Alert("Success!", "Record Saved Successfully", "success")
        'success alert

        'clear fields
        ddlPDCBatchChangeStatusStatus.SelectedValue = ""
        tbxPDCBatchChangeStatusRemarks.Text = ""
        'clear fields

        CallJS("$('#ContentPlaceHolder1_mdlREQBatchChangeStatus').modal('hide');")

        'display record
        bindREQForVerificationList()
        bindREQForVerificationListTotal()
        bindREQVerified()
        bindREQVerifiedListTotal()
        'display record

    End Function

#End Region

#Region "Modal Verified Submitted Dtl"

    Protected Sub lbtnREQForVerificationSubmittedDtlVerified_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQForVerificationSubmittedDtlVerified.Click

        'create variable
        Dim Msg As String = Validate("REQAccess", "Save", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("Access Denied!", "You do not have permission to access this module. Please contact administrator for assistance.", "error")
            Exit Sub
        End If
        'validate access

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprREQChangeStatus"
        SqlCmd.Parameters.AddWithValue("@pREQCode", lblREQForVerificationSubmittedDtlCode.Text)
        SqlCmd.Parameters.AddWithValue("@pIDs", "")
        SqlCmd.Parameters.AddWithValue("@pDocsCode", "")
        SqlCmd.Parameters.AddWithValue("@pAcctNo", "")
        SqlCmd.Parameters.AddWithValue("@pStatus", ddlPDCPendingSubmittedDtlStatus.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxPDCPendingSubmittedDtlRemarks.Text)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'success alert
        Alert("Success!", "Record Saved Successfully!", "success")
        'success alert

        'send email
        'SendEmailNotification()
        'send email

        'clear fields
        'lblREQForVerificationSubmittedDtlTitle.Text = ""
        'lblREQForVerificationSubmittedDtlAcctNo.Text = ""
        'lblREQForVerificationSubmittedDtlCheckDate.Text = ""
        'lblREQForVerificationSubmittedDtlCheckNo.Text = ""
        'lblREQForVerificationSubmittedDtlAmount.Text = ""
        'lblREQForVerificationSubmittedDtlBank.Text = ""
        'lblREQForVerificationSubmittedDtlDateSubmitted.Text = ""
        'lblREQForVerificationSubmittedDtlRemarks.Text = ""
        'clear fields

        'hide modal
        CallJS("$('#ContentPlaceHolder1_mdlREQForVerificationSubmittedDtl').modal('hide');")
        'hide modal

        'display record
        bindREQVerified()
        bindREQVerifiedListTotal()
        bindREQForVerificationList()
        bindREQForVerificationListTotal()
        'display record

        Exit Sub

    End Sub

#End Region

#Region "Modal Batch Revert"

    Protected Sub lbtnREQVerifiedSubmittedBatchRevert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQVerifiedSubmittedBatchRevert.Click

        CallJS("Swal.fire({ title: 'Do you want to revert PDC?', showDenyButton: false, showCancelButton: true, confirmButtonText: 'Save', confirmButtonColor: '#279852', cancelButtonColor: '#cbd4d9' }).then((result) => { if (result.isConfirmed) { var clickButton = document.getElementById('" & btnREQVerifySubmittedRevert.ClientID & "'); clickButton.click(); } else if (result.dismiss === Swal.DismissReason.cancel) { $('.checkBoxClass').prop('checked', false); } }); ")

    End Sub

    Protected Sub btnREQVerifySubmittedRevert_Click(ByVal sender As Object, e As EventArgs)

        Dim IDSrs As String = String.Empty
        Dim RowIdx As Integer = 0

        ' Loop through the GridView rows and check the checkbox
        Do Until RowIdx = gvREQVerifiedSubmitted.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = CType(gvREQVerifiedSubmitted.Rows(RowIdx).FindControl("RowCheckbox"), HtmlInputCheckBox)
            Dim lblID As Label = CType(gvREQVerifiedSubmitted.Rows(RowIdx).FindControl("lblPDCVerifiedSubmittedID"), Label)

            ' If checkbox is checked, add the ID to the string
            If RowCheckbox.Checked = True Then
                IDSrs &= lblID.Text & "," ' Collect IDs, separated by commas
            End If

            RowIdx += 1
        Loop

        ' Remove the last comma
        If IDSrs.Length > 0 Then
            IDSrs = IDSrs.TrimEnd(","c)

            ' Call the method to delete the records using the stored procedure
            RevertVerifiedREQ(IDSrs)
        End If

    End Sub


#End Region

#Region "Modal Batch Verify"



#End Region

#Region "Function"

    Function Alert(ByVal Title_ As String, ByVal Message_ As String, ByVal Alert_ As String)

        Dim script As String = "Swal.fire({title: '" & Title_ & "', text: '" & Message_ & "', icon: '" & Alert_ & "', confirmButtonColor: '#279852'});"
        ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType(), "SweetAlert", script, True)

    End Function

    Function CallJS(ByVal Script As String)

        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & Script & "</script>", False)

    End Function

    Function RenderDatatable()

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvREQForVerificationList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvREQForVerificationList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvREQForVerificationList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvREQForVerificationList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvREQVerifiedList.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvREQVerifiedList.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvREQVerifiedList.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvREQVerifiedList.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        If gvREQVerifiedSubmitted.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvREQVerifiedSubmitted.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvREQVerifiedSubmitted.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvREQVerifiedSubmitted.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindHistoryTimeline()

        'get
        Dim Query As New StringBuilder

        Dim PDCCode As String = IIf(lblREQForVerificationSubmittedDtlCode.Text = "", lblREQVerifiedSubmittedDtlCode.Text, lblREQForVerificationSubmittedDtlCode.Text)

        Query.Append("select ")
        Query.Append("	  ([A].Type + ' ' + [A].Description) [Progress] ")
        Query.Append("	 ,[A].CreatedDate ")
        Query.Append("	 ,[A].CreatedBy ")
        Query.Append("	 ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	 ,[A].Type ")
        Query.Append("from ")
        Query.Append("	 BP_History [A] ")
        Query.Append("	 left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TblCode = '" & PDCCode & "' ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate ")
        'get 

        Dim innerHTML As New StringBuilder

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'icons
                    Dim img As String
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("CreatedBy") & ".png")) = True Then
                        img = "Assets/media/avatars/" & DR("CreatedBy") & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("CreatedBy") & ".jpg")) = True Then
                        img = "Assets/media/avatars/" & DR("CreatedBy") & ".jpg"
                    Else
                        img = "Assets/media/avatars/blank.png"
                    End If

                    Dim svg As String
                    If DR("Type") = "Edit PDC:" Then
                        svg = "<path d='M3,16 L5,16 C5.55228475,16 6,15.5522847 6,15 C6,14.4477153 5.55228475,14 5,14 L3,14 L3,12 L5,12 C5.55228475,12 6,11.5522847 6,11 C6,10.4477153 5.55228475,10 5,10 L3,10 L3,8 L5,8 C5.55228475,8 6,7.55228475 6,7 C6,6.44771525 5.55228475,6 5,6 L3,6 L3,4 C3,3.44771525 3.44771525,3 4,3 L10,3 C10.5522847,3 11,3.44771525 11,4 L11,19 C11,19.5522847 10.5522847,20 10,20 L4,20 C3.44771525,20 3,19.5522847 3,19 L3,16 Z' fill='#279852' opacity='0.3'/> <path d='M16,3 L19,3 C20.1045695,3 21,3.8954305 21,5 L21,15.2485298 C21,15.7329761 20.8241635,16.200956 20.5051534,16.565539 L17.8762883,19.5699562 C17.6944473,19.7777745 17.378566,19.7988332 17.1707477,19.6169922 C17.1540423,19.602375 17.1383289,19.5866616 17.1237117,19.5699562 L14.4948466,16.565539 C14.1758365,16.200956 14,15.7329761 14,15.2485298 L14,5 C14,3.8954305 14.8954305,3 16,3 Z' fill='#279852'/>"
                    End If
                    'icons

                    'history
                    innerHTML.Append(" <!--begin::Timeline item--> ")
                    innerHTML.Append(" <div class='timeline-item pe-3'> ")
                    innerHTML.Append("     <div class='timeline-line w-30px'></div> ")
                    innerHTML.Append("     <div class='timeline-icon symbol symbol-circle symbol-30px'> ")
                    innerHTML.Append("         <div class='symbol-label bg-light'> ")
                    innerHTML.Append("             <span class='svg-icon svg-icon-2 svg-icon-gray-500'> ")
                    innerHTML.Append("                 <svg xmlns='http//www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    innerHTML.Append(" 			        " & svg & " ")
                    innerHTML.Append("		            </svg>  ")
                    innerHTML.Append("            </span> ")
                    innerHTML.Append("         </div> ")
                    innerHTML.Append("     </div> ")
                    innerHTML.Append("     <div class='timeline-content mb-10 mt-n2'> ")
                    innerHTML.Append("         <div class='overflow-auto pe-3'> ")
                    innerHTML.Append("             <div class='fs-5 fw-bold mb-2'>" & DR("Progress") & "</div> ")
                    innerHTML.Append("             <div class='d-flex align-items-center mt-1 fs-6'> ")
                    innerHTML.Append("                 <div class='text-muted me-2 fs-7'>Updated at " & DR("CreatedDate") & " by</div> ")
                    innerHTML.Append("                 <div class='symbol symbol-circle symbol-25px' data-bs-toggle='tooltip' data-bs-boundary='window' data-bs-placement='top' title=" & DR("Name") & "> ")
                    innerHTML.Append("                     <img src=" & img & " alt='img' /> ")
                    innerHTML.Append("                 </div> ")
                    innerHTML.Append("             </div> ")
                    innerHTML.Append("         </div> ")
                    innerHTML.Append("     </div> ")
                    innerHTML.Append(" </div> ")
                    innerHTML.Append(" <!--end::Timeline item--> ")
                    'history

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        'divREQForVerificationSubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        divREQVerifiedSubmittedDtlTimeline.InnerHtml = innerHTML.ToString()
        'display data

    End Function


    Function RevertVerifiedREQ(ByVal ids As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "BP_ApprRevertPDCVerified"
        SqlCmd.Parameters.AddWithValue("@pIDs", ids)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'alert
        Alert("Success!", "Record revert successfully.", "success")
        'alert

        CallJS("$('#ContentPlaceHolder1_mdl02PDCVerifiedList').modal('hide');")

        'display record
        bindREQVerified()
        bindREQForVerificationList()
        bindREQForVerificationListTotal()
        bindREQVerifiedListTotal()
        'display record

    End Function

    Function bindREQVerifiedListTotal()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   CSVerified is not null ")
        Query.Append("   and Status not in ('Approved', 'Declined') ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblREQVerifiedListTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlPDCTotal.Update()
        'display data

    End Function

    Function bindREQForVerificationListTotal()

        'get pending count
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and CSVerified is null ")
        'get pending count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblREQForVerificationListTotal.Text = DR.GetInt32(0)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display data
        upnlPDCTotal.Update()
        'display data

    End Function

    Function bindREQVerified()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("	 ,(select count(REQCode) from bp_requirements left join bp_user on bp_requirements.AcctNo = bp_user.AcctNo where (bp_requirements.Status = 'Pending') and bp_requirements.AcctNo = [A].AcctNo) [TotalSubmitted] ")
        Query.Append("from ")
        Query.Append("	 bp_requirements [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   ([A].Status = 'Approved' or [A].Status = 'Declined') ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("TotalSubmitted"))
        dtable.Columns.Add(New DataColumn("ViewREQVerifiedList"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()


                    Dim AcctNo As String = DR("AcctNo")
                    Dim Name As String = DR("Fullname")
                    Dim TotalSubmitted As String = DR("TotalSubmitted")
                    Dim ViewREQVerifiedList As String = "ViewREQVerifiedList('" & DR("AcctNo") & "')"

                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Name, TotalSubmitted, ViewREQVerifiedList}
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
        gvREQVerifiedList.DataSource = dtable
        gvREQVerifiedList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlREQVerifiedList.Update()
        'display data

    End Function

    Function bindREQForVerificationList()

        'get pending
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("	  [A].AcctNo ")
        Query.Append("	 ,[B].Fullname ")
        Query.Append("	 ,(select count(REQCode) from bp_requirements left join bp_user on bp_requirements.AcctNo = bp_user.AcctNo where (bp_requirements.Status = 'Pending') and bp_requirements.AcctNo = [A].AcctNo) [TotalSubmitted] ")
        Query.Append("from ")
        Query.Append("	 bp_requirements [A] ")
        Query.Append("   left Join bp_user [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Pending' ")
        'get pending

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("AcctNo"))
        dtable.Columns.Add(New DataColumn("Fullname"))
        dtable.Columns.Add(New DataColumn("TotalSubmitted"))
        dtable.Columns.Add(New DataColumn("ViewREQForVerificationSubmitted"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim AcctNo As String = DR("AcctNo")
                    Dim Name As String = DR("Fullname")
                    Dim TotalSubmitted As String = DR("TotalSubmitted")
                    Dim ViewREQForVerificationSubmitted As String = "ViewREQForVerificationSubmitted('" & DR("AcctNo") & "')"


                    'add new row
                    Dim NewRowValues As Object() = {AcctNo, Name, TotalSubmitted, ViewREQForVerificationSubmitted}
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
        gvREQForVerificationList.DataSource = dtable
        gvREQForVerificationList.DataBind()
        'bind datatable 

        'display data
        RenderDatatable()
        upnlREQForVerificationList.Update()
        'display data

    End Function

#End Region

#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        'access
        If Group_ = "REQAccess" Then
            If Type = "Save" Then
                Query.Append("if 'AAD010400' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010400' and Save_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'access

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

#End Region

End Class