Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading.Tasks
Imports System.Web.Services
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Azure
Imports Azure.Core
Imports System.Data.OleDb
Imports System.Data
Imports System.Web.UI.HtmlControl
Imports OfficeOpenXml
Imports Newtonsoft.Json
Imports System.Drawing.Drawing2D
Imports CrystalDecisions.Web
Imports System.Web.Script.Serialization
Imports Microsoft.Identity.Client.Cache
Imports System.Data.SqlTypes
Imports System.Web.WebSockets
Imports System.Data.Common
Imports NET.ENGRTDataSetTableAdapters
Imports System.Windows.Media.Media3D
Imports NET.SCMRTDataSetTableAdapters
Imports System.Drawing
Imports OfficeOpenXml.Drawing.Chart.ChartEx
Imports Microsoft.ReportingServices.Interfaces
Imports System.Runtime.Remoting.Messaging

Public Class SCM040000
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
        Master.setActiveMenu("APP", "SCM040000")
        'active account / menu

        'Record
        ltrlEmpNo.Text = CIIS_EmpCode
        'Record

        'load page
        If IsPostBack = False Then

            'bind
            bind01Warehouse()
            bind01PODtl("")
            bind02Files()
            'bind

        ElseIf IsPostBack = True Then

            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
            If gv01PODtl.Rows.Count > 0 Then
                gv01PODtl.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
            If gv01Review.Rows.Count > 0 Then
                gv01Review.HeaderRow.TableSection = TableRowSection.TableHeader
            End If
            'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Protected Sub lbtn01Fill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn01Fill.Click
        If tbx01PONo.Value = "" Then
            Alert("error", "Some field(s) are missing!")
        Else
            bind01POHdr(tbx01PONo.Value)
            bind01PODtl(tbx01PONo.Value)
        End If
    End Sub

    Private Sub lbtn01Preview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn01Preview.Click

        'validate
        If tbx01PONo.Value = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf tbx01DateReceived.Value = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf tbx01ORDate.Value = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf ddl01Warehouse.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf tbx01Supplier.Text = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf tbx01Location.Text = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        ElseIf tbx01SIDRNo.Text = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        End If
        'validate

        'set value
        lbl01PONo.Text = tbx01PONo.Value
        lbl01DateReceived.Text = tbx01DateReceived.Value
        lbl01DateReceived.Text = tbx01DateReceived.Value
        lbl01ORDate.Text = tbx01ORDate.Value
        lbl01Warehouse.Text = ddl01Warehouse.SelectedItem.Text
        lbl01Supplier.Text = tbx01Supplier.Text
        lbl01Location.Text = tbx01Location.Text
        lbl01SIDRNo.Text = tbx01SIDRNo.Text
        'set value

        'hidden
        hf01Warehouse.Value = ddl01Warehouse.SelectedValue
        'hidden

        'Create datatable for final materials
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("PRNo"))
        dtable.Columns.Add(New DataColumn("ItemName"))
        dtable.Columns.Add(New DataColumn("PONo"))
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("Qty"))
        dtable.Columns.Add(New DataColumn("QtyRcvd"))
        dtable.Columns.Add(New DataColumn("QtyBalance"))
        dtable.Columns.Add(New DataColumn("UMName"))
        dtable.Columns.Add(New DataColumn("ContractorName"))
        dtable.Columns.Add(New DataColumn("ContractorCode"))
        dtable.Columns.Add(New DataColumn("Type"))
        dtable.Columns.Add(New DataColumn("Cost"))
        dtable.Columns.Add(New DataColumn("Receive"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        'Create datatable for final materials

        'validate detail field
        Dim Cnt = 0
        Dim RowIdx = 0
        Do Until RowIdx = gv01PODtl.Rows.Count
            Dim lblPRNo As Label = gv01PODtl.Rows(RowIdx).FindControl("lblPRNo")
            Dim lblItemName As Label = gv01PODtl.Rows(RowIdx).FindControl("lblItemName")
            Dim lblPONo As Label = gv01PODtl.Rows(RowIdx).FindControl("lblPONo")
            Dim lblSeqNo As Label = gv01PODtl.Rows(RowIdx).FindControl("lblSeqNo")
            Dim lblQty As Label = gv01PODtl.Rows(RowIdx).FindControl("lblQty")
            Dim lblQtyRcvd As Label = gv01PODtl.Rows(RowIdx).FindControl("lblQtyRcvd")
            Dim lblQtyBalance As Label = gv01PODtl.Rows(RowIdx).FindControl("lblQtyBalance")
            Dim lblUMName As Label = gv01PODtl.Rows(RowIdx).FindControl("lblUMName")
            Dim ddl01Contractor As DropDownList = gv01PODtl.Rows(RowIdx).FindControl("ddl01Contractor")
            Dim ddl01Type As DropDownList = gv01PODtl.Rows(RowIdx).FindControl("ddl01Type")
            Dim tbx01Receive As HtmlInputText = gv01PODtl.Rows(RowIdx).FindControl("tbx01Receive")
            Dim tbx01Cost As HtmlInputText = gv01PODtl.Rows(RowIdx).FindControl("tbx01Cost")
            Dim tbx01Remarks As HtmlInputText = gv01PODtl.Rows(RowIdx).FindControl("tbx01Remarks")

            If CDbl(tbx01Receive.Value) > CDbl(lblQtyBalance.Text) Then
                Alert("error", "Item receive exceed balance!")
                Exit Sub
            ElseIf CDbl(tbx01Receive.Value) > 0 And CDbl(tbx01Cost.Value) > 0 Then
                Cnt = Cnt + 1
                Dim rValues As Object() = {lblPRNo.Text, lblItemName.Text, lblPONo.Text, lblSeqNo.Text, lblQty.Text, lblQtyRcvd.Text, lblQtyBalance.Text, lblUMName.Text, ddl01Contractor.SelectedItem.Text, ddl01Contractor.SelectedValue, ddl01Type.SelectedValue, tbx01Cost.Value, tbx01Receive.Value, tbx01Remarks.Value}
                Dim dRow As DataRow
                dRow = dtable.Rows.Add(rValues)
                dtable.AcceptChanges()
            End If

            RowIdx = RowIdx + 1
        Loop
        'validate detail field

        'validate
        If Cnt = 0 Then
            Alert("error", "Requires atleast one material to receive!")
            Exit Sub
        End If
        'validate

        'bind
        gv01Review.DataSource = dtable
        gv01Review.DataBind()
        'bind

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv01Review.Rows.Count > 0 Then
            gv01Review.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update display
        mdl01Review.Update()
        'update display

        'show modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Review').modal('show');</script>", False)
        'show modal

    End Sub

    Protected Sub btn01SaveOk_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_IRDtl_OSM"
        SqlCmd.Parameters.AddWithValue("@pPONo", lbl01PONo.Text)
        SqlCmd.Parameters.AddWithValue("@pDateReceived", lbl01DateReceived.Text)
        SqlCmd.Parameters.AddWithValue("@pORDate", lbl01ORDate.Text)
        SqlCmd.Parameters.AddWithValue("@pWarehouse", hf01Warehouse.Value)
        SqlCmd.Parameters.AddWithValue("@pSIDRNo", lbl01SIDRNo.Text)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", GetMaterials())
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        Dim IRNo As New SqlClient.SqlParameter("@oIRNo", SqlDbType.NVarChar, 1000)
        IRNo.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(IRNo)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'success alert
        Alert("success", "Record successfully saved. " & IRNo.Value)
        bind01Record(IRNo.Value)
        'success alert

        'display record
        tbx01PONo.Value = ""
        tbx01DateReceived.Value = ""
        tbx01ORDate.Value = ""
        ddl01Warehouse.SelectedValue = ""
        tbx01Supplier.Text = ""
        tbx01Location.Text = ""
        tbx01SIDRNo.Text = ""
        bind01PODtl("")
        bind02Files()
        'display record

        Exit Sub

    End Sub

#End Region

#Region "Files"

    Function bind02Files()

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("CreationTime"))
        'Create datatable and columns

        'GET A LIST OF FILES FROM A SPECIFILED FOLDER.
        If Directory.Exists(Server.MapPath("~/Assets/Upload/SCM040000/" & ltrlEmpNo.Text & "/")) Then

            'set folder
            Dim objDir As New DirectoryInfo(Server.MapPath("~/Assets/Upload/SCM040000/" & ltrlEmpNo.Text & "/"))
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

    Protected Sub lbtn02Delete(ByVal sender As Object, ByVal e As EventArgs)

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

        'remove file
        Dim FilePath As String = Server.MapPath("~/Assets/Upload/SCM040000/" & ltrlEmpNo.Text & "/") & hfFileName.Value
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
        SqlCmd01.Parameters.AddWithValue("@pFormCode", "SCM040000")
        SqlCmd01.Parameters.AddWithValue("@pID", ltrlEmpNo.Text)
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
        'fill new data

        'display success message
        Alert02("success", "File successfully remove.")
        'display success message

    End Sub

    Protected Sub lbtn02Download(ByVal sender As Object, ByVal e As EventArgs)

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
        SqlCmd01.Parameters.AddWithValue("@pFormCode", "SCM040000")
        SqlCmd01.Parameters.AddWithValue("@pID", ltrlEmpNo.Text)
        SqlCmd01.Parameters.AddWithValue("@pType", "Downloaded a file:")
        SqlCmd01.Parameters.AddWithValue("@pDescription", CType(sender, LinkButton).CommandArgument)
        SqlCmd01.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn01.Open()
        SqlCmd01.ExecuteNonQuery()
        SqlConn01.Close()
        'execute procedure

        'transfer file
        File.Copy(Server.MapPath("~/Assets/Upload/SCM040000/" & ltrlEmpNo.Text & "/") & CType(sender, LinkButton).CommandArgument, Server.MapPath("~/Assets/View/" & CIIS_EmpCode & "/") & CType(sender, LinkButton).CommandArgument, True)
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
    End Sub

#End Region

#Region "Function"

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
                    " & IIf(Alert_ = "success", "$('#ContentPlaceHolder1_mdl01Review').modal('hide');", "console.log('Error');") & "
              }
            });
        }, 200);
    </script>", False)
    End Function
    Function Alert02(ByVal Alert_ As String, ByVal Message_ As String)
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
                    " & IIf(Alert_ = "success", "$('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');", "console.log('Error');") & "
              }
            });
        }, 200);
    </script>", False)
    End Function
    Function bind01Record(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  r_code [Code] ")
        Query.Append("from ")
        Query.Append("  ogm_por_hdr ")
        Query.Append("where ")
        Query.Append("  reference = '"  & pID & "' ")
        'get query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Try
                        If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/SCM040000/" & CIIS_EmpCode & "/")) Then
                            'insert into Mstr_Attachment
                            Dim Files() As String = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Assets/Upload/SCM040000/" & CIIS_EmpCode & "/"))
                            For Each File As String In Files
                                'Filename
                                Dim FileName As String = Path.GetFileName(File)

                                'create connection
                                Dim SqlConn01 As New SqlClient.SqlConnection
                                Dim SqlCmd01 As New SqlCommand
                                SqlConn01.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                                SqlCmd01.CommandTimeout = 1500
                                SqlCmd01.Connection = SqlConn01
                                SqlCmd01.CommandType = CommandType.StoredProcedure
                                SqlCmd01.CommandText = "New_File"
                                SqlCmd01.Parameters.AddWithValue("@pFormCode", "SCM070000")
                                SqlCmd01.Parameters.AddWithValue("@pID", DR("Code"))
                                SqlCmd01.Parameters.AddWithValue("@pType", "Uploaded a file:")
                                SqlCmd01.Parameters.AddWithValue("@pDescription", FileName)
                                SqlCmd01.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                                'create connection

                                'execute procedure
                                SqlConn01.Open()
                                SqlCmd01.ExecuteNonQuery()
                                SqlConn01.Close()
                                'execute procedure

                            Next

                            'move
                            Directory.Move(HttpContext.Current.Server.MapPath("~/Assets/Upload/SCM040000/" & CIIS_EmpCode & "/"), HttpContext.Current.Server.MapPath("~/Assets/Upload/SCM070000/" & DR("Code") & "/"))
                        End If
                    Catch ex As Exception
                        Console.WriteLine("Error: " & ex.Message)
                    End Try
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function
    Function bind01Warehouse()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a warehouse' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   w_code [Code] ")
        Query.Append("   ,warehouse [Name] ")
        Query.Append("   ,warehouse [Order] ")
        Query.Append("from ")
        Query.Append("   ogm_warehouse ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Warehouse.DataSource = DT
        ddl01Warehouse.DataValueField = "Code"
        ddl01Warehouse.DataTextField = "Name"
        ddl01Warehouse.DataBind()
        'fill data

        'update display
        upnlContent.Update()
        'update display

    End Function

    Function bind01ChargeTo()

        ''get query
        'Dim Query As New StringBuilder
        'Query.Append("select")
        'Query.Append("  '' [Code] ")
        'Query.Append("  ,'Select a charge to' [Name] ")
        'Query.Append("  ,'' [Order] ")
        'Query.Append("union ")
        'Query.Append("select ")
        'Query.Append("  ms_code [Code] ")
        'Query.Append("  ,description [Name] ")
        'Query.Append("  ,description [Order] ")
        'Query.Append("from ")
        'Query.Append("  fin_misc_sub ")
        'Query.Append("where ")
        'Query.Append("  a_code = '07030004' ")
        'Query.Append("order by ")
        'Query.Append("  [Order] ")
        ''get query

        ''execute query
        'Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        'Dim SqlCon As New SqlConnection(ConStr)
        'Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        'Dim DT As New DataTable()
        'SDA.Fill(DT)
        ''execute query

        ''fill data
        'ddl01ChargeTo.DataSource = DT
        'ddl01ChargeTo.DataValueField = "Code"
        'ddl01ChargeTo.DataTextField = "Name"
        'ddl01ChargeTo.DataBind()
        ''fill data

        ''update display
        'upnlContent.Update()
        ''update display

    End Function

    Function bind01POHdr(PONo As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   WhseCode ")
        Query.Append("   ,VenName ")
        Query.Append("   ,DlvrAddress ")
        Query.Append("from ")
        Query.Append("   PODtl ")
        Query.Append("where ")
        Query.Append("   PONo = '" & PONo & "' ")
        Query.Append("   and post = 1 ")
        Query.Append("   and Rvrs = 0 ")
        Query.Append("   and QtyBalance > 0 ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    ddl01Warehouse.SelectedValue = DR("WhseCode")
                    tbx01Supplier.Text = DR("VenName")
                    tbx01Location.Text = DR("DlvrAddress")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        upnlContent.Update()
        'display data

    End Function

    Function bind01PODtl(PONo As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   PRNo ")
        Query.Append("   ,ItemName ")
        Query.Append("   ,PONo ")
        Query.Append("   ,SeqNo ")
        Query.Append("   ,Cost ")
        Query.Append("   ,Qty ")
        Query.Append("   ,QtyRcvd ")
        Query.Append("   ,QtyBalance ")
        Query.Append("   ,UMName ")
        Query.Append("from ")
        Query.Append("   PODtl ")
        Query.Append("where ")
        Query.Append("   PONo = '" & PONo & "' ")
        Query.Append("   and post = 1 ")
        Query.Append("   and Rvrs = 0 ")
        Query.Append("   and QtyBalance > 0 ")
        Query.Append("order by ")
        Query.Append("   SeqNo ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'bind
        gv01PODtl.DataSource = DT
        gv01PODtl.EmptyDataText = "No data. Please input the required fields."
        gv01PODtl.DataBind()
        'bind

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv01PODtl.Rows.Count > 0 Then
            gv01PODtl.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update
        upnlContent.Update()
        'update

    End Function

    Protected Sub gv01PODtl_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gv01PODtl.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddl01Contractor As DropDownList = DirectCast(e.Row.FindControl("ddl01Contractor"), DropDownList)

            Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
            Dim QueryCon As String = "select '' [Code], 'Select contractor' [Name], '' [Order] union select v_code [Code], vendor [Name], vendor [Order] from ogm_vendor where type = 'Contractor' and lock = 1 order by [Order] "
            Dim SqlCon As New SqlConnection(ConStr)

            'ddl Contractor
            Dim SDACon As New SqlDataAdapter(QueryCon, SqlCon)
            Dim DTCon As New DataTable()
            SDACon.Fill(DTCon)

            ddl01Contractor.DataSource = DTCon
            ddl01Contractor.DataValueField = "Code"
            ddl01Contractor.DataTextField = "Name"
            ddl01Contractor.DataBind()

        End If
    End Sub

    Function GetMaterials()
        'TODO:get the final materials from modal
        Dim pItemSrs As String = ""
        Dim RowIdx = 0
        Do Until RowIdx = gv01Review.Rows.Count
            Dim lblPONo As Label = gv01Review.Rows(RowIdx).FindControl("lblPONo")
            Dim lblSeqNo As Label = gv01Review.Rows(RowIdx).FindControl("lblSeqNo")
            Dim lbl01ContractorCode As Label = gv01Review.Rows(RowIdx).FindControl("lbl01ContractorCode")
            Dim lbl01Type As Label = gv01Review.Rows(RowIdx).FindControl("lbl01Type")
            Dim lbl01Cost As Label = gv01Review.Rows(RowIdx).FindControl("lbl01Cost")
            Dim lbl01QtyRcv As Label = gv01Review.Rows(RowIdx).FindControl("lbl01QtyRcv")
            Dim lbl01Remarks As Label = gv01Review.Rows(RowIdx).FindControl("lbl01Remarks")

            If pItemSrs = "" Then
                pItemSrs = lblPONo.Text & "©" & lblSeqNo.Text & "©" & lbl01ContractorCode.Text & "©" & lbl01Type.Text & "©" & CDbl(lbl01Cost.Text) & "©" & CDbl(lbl01QtyRcv.Text) & "©" & lbl01Remarks.Text
            Else
                pItemSrs = pItemSrs & "®" & lblPONo.Text & "©" & lblSeqNo.Text & "©" & lbl01ContractorCode.Text & "©" & lbl01Type.Text & "©" & CDbl(lbl01Cost.Text) & "©" & CDbl(lbl01QtyRcv.Text) & "©" & lbl01Remarks.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        Return pItemSrs
    End Function

#End Region

End Class
