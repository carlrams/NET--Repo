Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel

Public Class RM010100
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
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

        'load page
        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString().Replace("No", "#")
            'Record

            'hdr
            bindTitle()
            bindForm()

            'dtl
            bind06RMDtl()
        End If
        'load page
    End Sub
#End Region

#Region "Function"
    Function bindTitle()

        'set value
        lblTitle.Text = "-"
        lblID.Text = "-"
        lblStatus.Text = "-"
        'set value

        'get hdr
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [IR].reference ")
        Query.Append("  ,[WH].warehouse ")
        Query.Append("  ,(case when [IR].rvrs = 0 then 'Accepted' else 'Cancelled' end) [Status] ")
        Query.Append("from ")
        Query.Append("  ogm_por_hdr [IR] ")
        Query.Append("  left join ogm_vendor [VN] on [IR].vendor = [VN].v_code ")
        Query.Append("  left join ogm_warehouse [WH] on [IR].warehouse = [WH].w_code ")
        Query.Append("where ")
        Query.Append("  [IR].r_code = '" & ltrlID.Text & "' ")
        'get hdr

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

                    'bind
                    bindFiles(DR.GetString(0))

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
    Function bindForm()
        'enabled
        pnl01Dtl.Visible = True
        'enabled

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [IR].reference ")
        Query.Append("  ,[VN].vendor ")
        Query.Append("from ")
        Query.Append("  ogm_por_hdr [IR] ")
        Query.Append("  left join ogm_vendor [VN] on [IR].vendor = [VN].v_code ")
        Query.Append("where ")
        Query.Append("  [IR].r_code = '" & ltrlID.Text & "' ")
        'get query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lbl01RRNo.Text = DR.GetString(0)
                    lbl01Vendor.Text = DR.GetString(1)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'update
        upnl01Overview.Update()
    End Function
    Function bind06RMDtl()

        'get query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("  PRNo ")
        Query.Append("  ,SIDRNo ")
        Query.Append("  ,ItemName ")
        Query.Append("  ,Qty ")
        Query.Append("  ,UMInit ")
        Query.Append("  ,isnull(ContractorName,'-') [Contractor] ")
        Query.Append("  ,Type ")
        Query.Append("  ,Remarks ")
        Query.Append("from ")
        Query.Append("  IRDtl ")
        Query.Append("where ")
        Query.Append("  IRCode = '" & ltrlID.Text & "' ")
        Query.Append("order by ")
        Query.Append("   SeqNo ")
        'get query

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("PRNo"))
        dtable.Columns.Add(New DataColumn("SIDRNo"))
        dtable.Columns.Add(New DataColumn("ItemName"))
        dtable.Columns.Add(New DataColumn("Qty"))
        dtable.Columns.Add(New DataColumn("UMInit"))
        dtable.Columns.Add(New DataColumn("Contractor"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Dim NewRowValues As Object() = {DR("PRNo"), DR("SIDRNo"), DR("ItemName"), DR("Qty"), DR("UMInit"), DR("Contractor"), DR("Type"), DR("Remarks")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv06RMDtl.DataSource = dtable
        gv06RMDtl.DataBind()
        'bind datatable

        'update
        upnl06RMDtl.Update()
    End Function

#End Region

#Region "Files"

#Region "Function"
    Function bindFiles(ID As String)

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        If Directory.Exists(Server.MapPath("~/Assets/Upload/" & ID & "/")) Then

            'set folder
            Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/" & ID & "/"))
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
#End Region

#Region "Button"
    Protected Sub lbtn02Download(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
#End Region
#End Region
End Class