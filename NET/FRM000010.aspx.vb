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

Public Class FRM000010

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

    Private Shared DataSource1 As String = "10.10.30.20"
    Private Shared catalog1 As String = "cldc_live_acc"
    Private Shared UserID1 As String = "ciisv2"
    Private Shared Password1 As String = "Cii5s"
    'connection

#Region "Data Model"
    Public Class MyDataModel
        Public Property WBSNo As String
        Public Property Item As String
        Public Property Qty As Nullable(Of Decimal)
        Public Property Remarks As String
    End Class
#End Region

#Region "WebMethod"
    <WebMethod>
    Public Shared Function UploadAndReadExcel(ByVal fileName As String, ByVal fileData As String) As Object
        Try
            ' Convert Base64 to Byte Array
            Dim decodedBytes As Byte() = Convert.FromBase64String(fileData)

            ' Save the uploaded file in a temporary folder
            Dim tempFolder As String = HttpContext.Current.Server.MapPath("~/Assets/temp/")
            If Not Directory.Exists(tempFolder) Then
                Directory.CreateDirectory(tempFolder)
            End If

            Dim filePath As String = Path.Combine(tempFolder, fileName)
            File.WriteAllBytes(filePath, decodedBytes) ' Save the file

            ' Read the Excel Data
            Dim dt As DataTable = ReadExceldata(filePath)

            ' Convert DataTable to List of YourDataModel (to avoid circular reference issues)
            Dim dataList As New List(Of MyDataModel)()
            For Each row As DataRow In dt.Rows
                dataList.Add(New MyDataModel With {
                .WBSNo = row("WBS No").ToString(),
                .Item = row("Item").ToString(),
                .Qty = Convert.ToDecimal(row("Qty")),
                .Remarks = row("Remarks").ToString()
            })
            Next

            ' Return JSON-safe object
            Return New With {.success = True, .data = dataList}

        Catch ex As Exception
            ' Return full error message
            Return New With {.success = False, .message = "Error in UploadAndReadExcel: " & ex.Message}
        End Try
    End Function

    Private Shared Function ReadExceldata(filePath As String) As DataTable
        Dim dt As New DataTable()
        Try
            ' 🔹 Check if file exists before reading
            If Not File.Exists(filePath) Then
                Throw New Exception("File does not exist: " & filePath)
            End If

            ' Load Excel file
            Using package As New ExcelPackage(New FileInfo(filePath))
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                Dim ws As ExcelWorksheet = package.Workbook.Worksheets.FirstOrDefault()

                If ws Is Nothing Then
                    Throw New Exception("No worksheet found in Excel file.")
                End If

                ' Get column headers
                For col As Integer = 1 To ws.Dimension.End.Column
                    dt.Columns.Add(ws.Cells(1, col).Text)
                Next

                ' Get data rows
                For row As Integer = 2 To ws.Dimension.End.Row
                    Dim dataRow As DataRow = dt.NewRow()
                    For col As Integer = 1 To dt.Columns.Count
                        dataRow(col - 1) = ws.Cells(row, col).Text
                    Next
                    dt.Rows.Add(dataRow)
                Next
            End Using

            ' 🔹 Return Data
            Return dt

        Catch ex As Exception
            ' 🔹 Return empty DataTable with error logging
            HttpContext.Current.Response.Write("Error reading Excel: " & ex.Message & "<br>")
            Return New DataTable()
        End Try
    End Function

    <WebMethod>
    Public Shared Function SaveToOSM(ID As String, data As Object, Code As String) As Object
        Dim response As New Dictionary(Of String, Object)
        Dim serializer As New JavaScriptSerializer()
        Try
            Dim pSRS As String = ""
            For Each row As Dictionary(Of String, Object) In data

                Dim rowString As String = $"{row("WBSNo")}©{row("Item")}©{CDbl(row("Qty"))}©{""}©{row("Remarks")}"

                If pSRS = "" Then
                    pSRS = rowString
                Else
                    pSRS &= "®" & rowString
                End If
            Next

            ' 🔹 Step 2: Call the stored procedure
            Using conn As New SqlConnection("Data Source=" & DataSource1 & "; Initial Catalog=" & catalog1 & "; User ID=" & UserID1 & "; Password=" & Password1)
                conn.Open()
                Dim cmd As New SqlCommand("New_FRM_FRM000010_PRDtl_OSM", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
                cmd.Parameters.AddWithValue("@pID", ID)
                cmd.Parameters.AddWithValue("@pItemSrs", pSRS)
                cmd.Parameters.AddWithValue("@pCreatedBy", Code)

                cmd.ExecuteNonQuery()
            End Using

            response("success") = True
            response("message") = "Data saved successfully"
        Catch ex As Exception
            response("success") = False
            response("message") = "Error in SaveToDatabase: " & ex.Message
        End Try

        HttpContext.Current.Response.ContentType = "application/json"
        Return serializer.Serialize(response)
    End Function

    <WebMethod>
    Public Shared Function SaveToSCM(ID As String, data As Object, Code As String) As Object
        Dim response As New Dictionary(Of String, Object)
        Dim serializer As New JavaScriptSerializer()
        Try
            Dim pSRS As String = ""
            For Each row As Dictionary(Of String, Object) In data

                Dim rowString As String = $"{row("WBSNo")}©{row("Item")}©{CDbl(row("Qty"))}©{""}©{row("Remarks")}"

                If pSRS = "" Then
                    pSRS = rowString
                Else
                    pSRS &= "®" & rowString
                End If
            Next

            ' 🔹 Step 2: Call the stored procedure
            Using conn As New SqlConnection("Data Source=" & DataSource1 & "; Initial Catalog=" & catalog1 & "; User ID=" & UserID1 & "; Password=" & Password1)
                conn.Open()
                Dim cmd As New SqlCommand("New_FRM_FRM000010_PRDtl_SCM", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
                cmd.Parameters.AddWithValue("@pID", ID)
                cmd.Parameters.AddWithValue("@pItemSrs", pSRS)
                cmd.Parameters.AddWithValue("@pCreatedBy", Code)

                cmd.ExecuteNonQuery()
            End Using

            response("success") = True
            response("message") = "Data saved successfully"
        Catch ex As Exception
            response("success") = False
            response("message") = "Error in SaveToDatabase: " & ex.Message
        End Try

        HttpContext.Current.Response.ContentType = "application/json"
        Return serializer.Serialize(response)
    End Function
#End Region

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
        ltrlFormCode.Text = "FRM000010"
        ltrlCode.Text = CIIS_EmpCode
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
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
            bind02Files()
            bind03Subscribers()
            bind04ApprovalPath()
            bind05Notes()
            bind06History()
            'display record

            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
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
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-new")
            ElseIf lblStatus.Text = "Requested" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-new")
            ElseIf lblStatus.Text = "Endorsed" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-endorsement")
            ElseIf lblStatus.Text = "Approved" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-approval")
            ElseIf lblStatus.Text = "Implemented" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-implementation")
            ElseIf lblStatus.Text = "Clarification" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-clarification")
            ElseIf lblStatus.Text = "For Cancellation" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
            ElseIf lblStatus.Text = "Cancelled" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
            ElseIf lblStatus.Text = "Declined" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
            ElseIf lblStatus.Text = "Accepted" Then
                lblStatus.Attributes.Add("class", "badge badge-lg badge-for-closed")
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
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-new")
                        ElseIf lblStatus.Text = "Requested" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-new")
                        ElseIf lblStatus.Text = "Endorsed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-endorsement")
                        ElseIf lblStatus.Text = "Approved" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-approval")
                        ElseIf lblStatus.Text = "Implemented" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-implementation")
                        ElseIf lblStatus.Text = "Clarification" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-clarification")
                        ElseIf lblStatus.Text = "For Cancellation" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
                        ElseIf lblStatus.Text = "Cancelled" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
                        ElseIf lblStatus.Text = "Declined" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
                        ElseIf lblStatus.Text = "Accepted" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-closed")
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
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-new")
                        ElseIf lblStatus.Text = "Requested" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-new")
                        ElseIf lblStatus.Text = "Endorsed" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-endorsement")
                        ElseIf lblStatus.Text = "Approved" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-approval")
                        ElseIf lblStatus.Text = "Implemented" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-implementation")
                        ElseIf lblStatus.Text = "Clarification" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-clarification")
                        ElseIf lblStatus.Text = "For Cancellation" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
                        ElseIf lblStatus.Text = "Cancelled" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
                        ElseIf lblStatus.Text = "Declined" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-cancelled")
                        ElseIf lblStatus.Text = "Accepted" Then
                            lblStatus.Attributes.Add("class", "badge badge-lg badge-for-closed")
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
        Query.Append("declare @PRCode nvarchar(13) = isnull((select tbl_code from oop_form_hdr where f_code = '" & ltrlID.Text & "'), '') ")
        Dim Msg As String = ""
        'create variable

        If Group_ = "06PRDtl" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' in (select top 1 approver from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and approver = 'MN2023120000' and status = '') and isnull((select justification from ogm_pr_hdr where pr_code = @PRCode), '') LIKE '%(Stock Request)%' ")
                Query.Append("begin ")
                Query.Append("  select '' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' in (select top 1 approver from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and approver = 'MN2023120000' and status = '') and isnull((select justification from ogm_pr_hdr where pr_code = @PRCode), '') LIKE '%(Stock Request)%' ")
                Query.Append("begin ")
                Query.Append("  select '' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' in (select top 1 approver from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and approver = 'MN2023120000' and status = '') and isnull((select justification from ogm_pr_hdr where pr_code = @PRCode), '') LIKE '%(Stock Request)%' ")
                Query.Append("begin ")
                Query.Append("  select '' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by [authorize] from oop_form_hdr where f_code = '" & ltrlID.Text & "' union select approver [authorize] from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and type = 'Implementer') ")
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

        If Group_ = "04ApprovalPath" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
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
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' in (select top 1 approver from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and approver = 'MN2023120000' and status = '') and isnull((select justification from ogm_pr_hdr where pr_code = @PRCode), '') LIKE '%(Stock Request)%' ")
                Query.Append("begin ")
                Query.Append("  select '' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') ")
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
        lbtn01Print.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1"
        'overview

        'item
        lbtn06PRDtlAdd.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1 p-5"
        div06PRDtlAdd_SCM.Attributes("class") = "menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretch btn-sm btn-primary align-self-center m-1"
        div06PRDtlAdd_SCM.Attributes("data-kt-menu") = "true"
        div06PRDtlAdd_OSM.Attributes("class") = "menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretch btn-sm btn-primary align-self-center m-1"
        div06PRDtlAdd_OSM.Attributes("data-kt-menu") = "true"
        mnuSCM.Attributes("class") = "menu-title text-white"
        mnuOSM.Attributes("class") = "menu-title text-white"
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
        lbtn01Print.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        'overview

        'item
        lbtn06PRDtlAdd.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1 p-5"
        div06PRDtlAdd_SCM.Attributes("class") = "menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretch btn-sm btn-white align-self-center m-1"
        div06PRDtlAdd_SCM.Attributes("data-kt-menu") = "false"
        div06PRDtlAdd_OSM.Attributes("class") = "menu menu-l-rounded menu-column menu-lg-row menu-title-gray-700 menu-state-icon-primary menu-state-bullet-primary align-items-stretchtn btn-sm btn-white align-self-center m-1"
        div06PRDtlAdd_OSM.Attributes("data-kt-menu") = "false"
        mnuSCM.Attributes("class") = "menu-title"
        mnuOSM.Attributes("class") = "menu-title"
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

    Function ShowFields()

        If ltrlMode.Text = "ADD" Or ltrlMode.Text = "UPD" Then
            div01DateReturn.Style("display") = "none"
            div01DateReIssue.Style("display") = "none"
            div01WorkCode.Style("display") = "none"
            div01Subdivision.Style("display") = "none"
            div01VehiclePlate.Style("display") = "none"
            div01Project.Style("display") = "none"
            div01Type.Style("display") = "none"
            div0101Category.Style("display") = "none"
            div0102Category.Style("display") = "none"
            div01ActName.Style("display") = "none"
            div01ActLocation.Style("display") = "none"
            div01ActDate.Style("display") = "none"
            'div01Estimate.Style("display") = "none"
            div06PRDtlAdd_SCM.Style("display") = "none"
            div06PRDtlAdd_OSM.Style("display") = "none"
            div02Estimate.Style("display") = "none"
            div01ChargeTo.Style("display") = "none"
            div01Division.Style("display") = ""
            div01ProjectCat.Style("display") = "none"
            div01Department.Style("display") = "none"
            div02Department.Style("display") = ""

            'If ddl01PurchaseType.SelectedValue = "Return" Then div01DateReturn.Style("display") = ""
            'If ddl01PurchaseType.SelectedValue = "Return" Then div01DateReIssue.Style("display") = ""

            'OSM Type - Non OSM
            If ddl01OSMAType.SelectedValue = "Non OSM Project" Or ddl01OSMAType.SelectedValue = "OSM Project" Or ddl01OSMAType.SelectedValue.Contains("Advance PO") Then
                div01ChargeTo.Style("display") = ""
                div01Division.Style("display") = ""
            End If

            'Project Category
            If ddl01ProjectCat.SelectedValue = "House Construction" Or ddl01ProjectCat.SelectedValue = "House Construction - CCI" Then
                div01Subdivision.Style("display") = ""
            End If

            'OSM Type - Advance PO
            If ddl01OSMAType.SelectedValue = "OSM Project (Advance PO)" Then
                div01ProjectCat.Style("display") = ""
                div02Estimate.Style("display") = ""
            End If
            If ddl01OSMAType.SelectedValue = "CCI Project (Advance PO)" Then
                div01ProjectCat.Style("display") = ""
                div02Estimate.Style("display") = ""
            End If

            'OSM Type - Stock Request
            If ddl01OSMAType.SelectedValue = "OSM Project (Stock Request)" Then
                div01ProjectCat.Style("display") = ""
                div02Estimate.Style("display") = ""
            End If
            If ddl01OSMAType.SelectedValue = "CCI Project (Stock Request)" Then
                div01ProjectCat.Style("display") = ""
                div02Estimate.Style("display") = ""
            End If

            If ddl01Purpose.SelectedValue = "Others - FUEL" Then div01VehiclePlate.Style("display") = ""
            If ddl01Purpose.SelectedValue = "Others - GRASS CUTTER MAINTENANCE" Then div01Subdivision.Style("display") = ""
            If ddl01Purpose.SelectedValue = "Others - HOUSE REPAIR" Then div01Project.Style("display") = ""

            If ddl01Purpose.SelectedValue = "MARKETING MATERIALS - Events & Activities" Then div01ActName.Style("display") = ""
            If ddl01Purpose.SelectedValue = "MARKETING MATERIALS - Events & Activities" Then div01ActLocation.Style("display") = ""
            If ddl01Purpose.SelectedValue = "MARKETING MATERIALS - Events & Activities" Then div01ActDate.Style("display") = ""
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Aircon" Then div0102Category.Style("display") = ""
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Aircon" Then lbl0102TitleCategory.Text = "FFE No."
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Grass Cutter" Then div0102Category.Style("display") = ""
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Grass Cutter" Then lbl0102TitleCategory.Text = "Model No."
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Tools and Equipment" Then div0102Category.Style("display") = ""
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Tools and Equipment" Then lbl0102TitleCategory.Text = "Tools"
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Vehicle" Then div0102Category.Style("display") = ""
            If ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Vehicle" Then lbl0102TitleCategory.Text = "Plate No."

            If ddl01Purpose.SelectedValue = "SALES EVENTS AND ACTIVITIES - Sales Events" Then div01ActName.Style("display") = ""
            If ddl01Purpose.SelectedValue = "SALES EVENTS AND ACTIVITIES - Sales Events" Then div01ActLocation.Style("display") = ""
            If ddl01Purpose.SelectedValue = "SALES EVENTS AND ACTIVITIES - Sales Events" Then div01ActDate.Style("display") = ""

        End If

        If ltrlMode.Text = "DTL" Then
            pnl01DateReturn.Visible = False
            pnl01DateIssue.Visible = False
            pnl01Batch.Visible = False
            pnl01WorkCode.Visible = False
            pnl01Subdivision.Visible = False
            pnl01VehiclePlate.Visible = False
            pnl01Project.Visible = False
            pnl01Type.Visible = False
            pnl01Category.Visible = False
            pnl01ActName.Visible = False
            pnl01ActLocation.Visible = False
            pnl01ActDate.Visible = False
            pnl01Estimate.Visible = False
            pnl01ChargeTo.Visible = False
            pnl01Division.Visible = True
            pnl01ProjectCat.Visible = False
            div06Body.Style("display") = "none"
            div0601Body.Style("display") = "none"
            pnl01Department.Visible = False
            pnl02Department.Visible = True

            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                div06Body.Style("display") = ""
                div0601Body.Style("display") = "none"
            Else
                div06Body.Style("display") = "none"
                div0601Body.Style("display") = ""
            End If

            'If lbl01PurchaseType.Text = "Return" Then pnl01DateReturn.Visible = True
            'If lbl01PurchaseType.Text = "Return" Then pnl01DateIssue.Visible = True

            'Project Type
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then pnl01Subdivision.Visible = True

            If lbl01OSMType.Text.Contains("Stock Request") Or lbl01OSMType.Text.Contains("Advance PO") Then
                lbtn06PRDtlAdd.Visible = False
            Else
                lbtn06PRDtlAdd.Visible = True
            End If

            'OSM Type - Non OSM
            If lbl01OSMType.Text = "Non OSM Project" Or lbl01OSMType.Text = "OSM Project" Or lbl01OSMType.Text.Contains("Advance PO") Then
                pnl01ChargeTo.Visible = True
                'pnl01Division.Visible = True
            End If

            'OSM Type - Advance PO
            If lbl01OSMType.Text = "OSM Project (Advance PO)" Then
                pnl01Estimate.Visible = True
                pnl01ProjectCat.Visible = True
            End If
            If lbl01OSMType.Text = "CCI Project (Advance PO)" Then
                pnl01Estimate.Visible = True
                pnl01ProjectCat.Visible = True
            End If

            'OSM Type - Stock Request
            If lbl01OSMType.Text = "OSM Project (Stock Request)" Then
                pnl01Estimate.Visible = True
                pnl01ProjectCat.Visible = True
            End If
            If lbl01OSMType.Text = "CCI Project (Stock Request)" Then
                pnl01Estimate.Visible = True
                pnl01ProjectCat.Visible = True
            End If

            If lbl01OSMType.Text = "OSM Project" Then div06PRDtlAdd_OSM.Style("display") = "none"
            If lbl01OSMType.Text = "OSM Project" Then div06PRDtlAdd_SCM.Style("display") = "none"

            If lbl01OSMType.Text = "OSM Project (Advance PO)" Or lbl01OSMType.Text = "CCI Project (Advance PO)" Then div06PRDtlAdd_OSM.Style("display") = "none"
            If lbl01OSMType.Text = "OSM Project (Advance PO)" Or lbl01OSMType.Text = "CCI Project (Advance PO)" Then div06PRDtlAdd_SCM.Style("display") = ""
            If lbl01OSMType.Text = "OSM Project (Stock Request)" Or lbl01OSMType.Text = "CCI Project (Stock Request)" Then div06PRDtlAdd_SCM.Style("display") = "none"
            If lbl01OSMType.Text = "OSM Project (Stock Request)" Or lbl01OSMType.Text = "CCI Project (Stock Request)" Then div06PRDtlAdd_OSM.Style("display") = ""

            If lbl01OSMType.Text = "Non OSM Project" Or lbl01OSMType.Text = "OSM Project" Then div06PRDtlAdd_OSM.Style("display") = "none"
            If lbl01OSMType.Text = "Non OSM Project" Or lbl01OSMType.Text = "OSM Project" Then div06PRDtlAdd_SCM.Style("display") = "none"

            If lbl01Purpose.Text = "Others - FUEL" Then pnl01VehiclePlate.Visible = True
            If lbl01Purpose.Text = "Others - GRASS CUTTER MAINTENANCE" Then pnl01Subdivision.Visible = True
            If lbl01Purpose.Text = "Others - HOUSE REPAIR" Then pnl01Project.Visible = True

            If lbl01Purpose.Text = "MARKETING MATERIALS - Events & Activities" Then pnl01ActName.Visible = True
            If lbl01Purpose.Text = "MARKETING MATERIALS - Events & Activities" Then pnl01ActLocation.Visible = True
            If lbl01Purpose.Text = "MARKETING MATERIALS - Events & Activities" Then pnl01ActDate.Visible = True

            If lbl01Purpose.Text = "OFFICE FURNITURES, FIXTURES & EQUIPMENTS" And lbl01Type.Text = "Aircon" Then pnl01Category.Visible = True
            If lbl01Purpose.Text = "OFFICE FURNITURES, FIXTURES & EQUIPMENTS" And lbl01Type.Text = "Printer" Then pnl01Category.Visible = True

            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Aircon" Then pnl01Category.Visible = True
            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Aircon" Then lbl01TitleCategory.Text = "FFE No."
            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Grass Cutter" Then pnl01Category.Visible = True
            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Grass Cutter" Then lbl01TitleCategory.Text = "Model No."
            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Tools and Equipment" Then pnl01Category.Visible = True
            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Tools and Equipment" Then lbl01TitleCategory.Text = "Tools"
            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Vehicle" Then pnl01Category.Visible = True
            If lbl01Purpose.Text = "REPAIR AND MAINTENANCE - Vehicle" Then lbl01TitleCategory.Text = "Plate No."

            If lbl01Purpose.Text = "SALES EVENTS AND ACTIVITIES - Sales Events" Then pnl01ActName.Visible = True
            If lbl01Purpose.Text = "SALES EVENTS AND ACTIVITIES - Sales Events" Then pnl01ActLocation.Visible = True
            If lbl01Purpose.Text = "SALES EVENTS AND ACTIVITIES - Sales Events" Then pnl01ActDate.Visible = True
        End If

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
            'pnl01Purpose.Visible = True
            'displa fields

            'set value
            tbx01ID.Text = "0000000000000"
            tbx01FormType.Text = "Purchase Request"
            tbx01DateRequested.Text = Format(Date.Now, "MM/dd/yyyy")
            tbx01DateRequired.Text = Format(Date.Now, "MM/dd/yyyy")
            tbx01RequestedBy.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01AssignedTo.Text = CIIS_FirstName & " " & CIIS_LastName
            tbx01EndorsedTo.Text = "-"
            tbx01Status.Text = "New"
            ddl01PurchaseType.SelectedValue = ""
            bind01Department()
            ddl01Department.SelectedValue = ""
            ddl01OSMAType.SelectedValue = ""
            bind01Purpose("")
            ddl01Purpose.SelectedValue = ""
            hf01Purpose.Value = ""
            tbx01DateReturn.Value = ""
            tbx01DateReIssue.Value = ""
            'tbx01WorkCode.Value = ""
            bind01Subdivision()
            ddl01Subdivision.SelectedValue = ""
            bind01Vehicle()
            ddl01VehiclePlate.SelectedValue = ""
            tbx01Project.Value = ""
            hf01Subdivision.Value = ""
            hf01Phase.Value = ""
            hf01Block.Value = ""
            hf01Lot.Value = ""
            bind01Type("")
            ddl01Type.SelectedValue = ""
            hf01Type.Value = ""
            bind01Category("")
            bind02Department()
            hf01Division.Value = ""
            bind01ProjectCategory()
            ddl01ProjectCat.SelectedValue = ""
            lbl0101TitleCategory.Text = "Category"
            ddl0101Category.SelectedValue = ""
            hf01Category.Value = ""
            lbl0102TitleCategory.Text = "Category"
            tbx0102Category.Value = ""
            tbx01ActName.Value = ""
            tbx01ActLocation.Value = ""
            tbx01ActDate.Value = ""
            tbx01Remarks.Text = ""
            tbx01ChargeTo.Value = ""
            hf01ChargeCode.Value = ""
            hf01AcctCode.Value = ""
            'ddl01Estimate.SelectedValue = ""
            tbx01Estimate.Value = ""
            ShowFields()
            'set value

            'display data
            upnl01Overview.Update()
            'display data

            'add record
        End If

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
            Query.Append("   [A].f_code [ID] ")
            Query.Append("   ,[A].created_date [DateCreated] ")
            Query.Append("   ,[A].date_required [DateRequired] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
            Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
            Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
            Query.Append("   ,[A].status [Status] ")
            Query.Append("   ,[B].PurchaseType ")
            Query.Append("   ,[B].department [Department] ")
            Query.Append("   ,[B].justification [OSMType] ")
            Query.Append("   ,[B].Purpose ")
            Query.Append("   ,isnull(FORMAT([B].DateReturn,'MM/dd/yyyy'),'') [DateReturn] ")
            Query.Append("   ,isnull(FORMAT([B].DateIssue,'MM/dd/yyyy'),'') [DateIssue] ")
            Query.Append("   ,[B].Batch ")
            Query.Append("   ,[B].WorkCode ")
            Query.Append("   ,isnull([F].abbr + ' ' + [G].description + ' B' + [H].block + ' L' + [I].lot,'') [Project] ")
            Query.Append("   ,ISNULL([B].Subdivision, '') [Subdivision] ")
            Query.Append("   ,ISNULL([F].description, '') [SubdName] ")
            Query.Append("   ,[B].Phase ")
            Query.Append("   ,[B].Block ")
            Query.Append("   ,[B].Lot ")
            Query.Append("   ,[B].PlateNo [VehiclePlate] ")
            Query.Append("   ,[B].Vehicle ")
            Query.Append("   ,[B].PlateNo ")
            Query.Append("   ,[B].Type ")
            Query.Append("   ,[B].Category ")
            Query.Append("   ,[B].ActName ")
            Query.Append("   ,[B].ActLocation ")
            Query.Append("   ,isnull(FORMAT([B].ActDate,'MM/dd/yyyy'),'') [ActDate] ")
            Query.Append("   ,[B].remarks [Remarks] ")
            Query.Append("   ,ISNULL([B].CECode, '') [CECode] ")
            Query.Append("   ,ISNULL([J].Title, '') [EstimateTitle] ")
            Query.Append("   ,ISNULL([F].abbr, '') [Abbr] ")
            Query.Append("   ,ISNULL((select Title from Trxn_CEHdr where Trxn_CEHdr.CECode = [B].Subdivision), '') [Title] ")
            Query.Append("   ,ISNULL([B].ChargeCode, '') [ChargeCode] ")
            Query.Append("   ,ISNULL([B].AcctCode, '') [AcctCode] ")
            Query.Append("   ,ISNULL((CASE WHEN [B].Misc = 'MISCELLANEOUS' THEN (select description from sub_misc where account = [B].AcctCode and code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'MODEL HOUSE' THEN (select description from sub_house where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'NO SUBSIDIARY' THEN ISNULL((select Description from Mstr_PurposeType where Type + ' - ' + Purpose = [B].Purpose and AcctCode = [B].AcctCode), '') ")
            Query.Append("                 WHEN [B].Misc = 'SUBDIVISION' THEN (select description from sub_subdivision where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'PHASE' THEN (select description from sub_phase where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'VENDOR' THEN (select description from sub_vendor where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'WAREHOUSE' THEN (select description from sub_warehouse where code = [B].ChargeCode) ")
            Query.Append("      ELSE '' END), '') [ChargeTo] ")
            Query.Append("   ,ISNULL([B].Misc, '') [Misc] ")
            Query.Append("   ,ISNULL([B].Division, '') [Division] ")
            Query.Append("   ,ISNULL(division.description, '') [DivName] ")
            Query.Append("   ,ISNULL(department.description, '') [DeptName] ")
            Query.Append("   ,ISNULL(department.dept_code, '') [DeptCode] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join ogm_pr_hdr [B] on [A].tbl_code = [B].pr_code  ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("   left join subdivision [F] on [B].Subdivision = [F].code ")
            Query.Append("   left join phase [G] on [B].Phase = [G].code ")
            Query.Append("   left join eng_block [H] on [B].Block = [H].b_code ")
            Query.Append("   left join eng_lot [I] on [B].Lot = [I].l_code ")
            Query.Append("   left join Trxn_CEHdr [J] on [B].CECode = [J].CECode ")
            Query.Append("   left join division on [B].Division = division.div_code ")
            Query.Append("   left join department on [C].dept_code = department.dept_code ")
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
                        tbx01ID.Text = DR("ID")
                        tbx01FormType.Text = "Purchase Request"
                        tbx01DateRequested.Text = Format(DR("DateCreated"), "MM/dd/yyyy")
                        tbx01DateRequired.Text = Format(DR("DateRequired"), "MM/dd/yyyy")
                        tbx01RequestedBy.Text = DR("RequestedBy")
                        tbx01AssignedTo.Text = DR("AssignedTo")
                        tbx01EndorsedTo.Text = DR("EndorsedTo")
                        tbx01Status.Text = DR("Status")
                        ddl01PurchaseType.SelectedValue = DR("PurchaseType")
                        hf01PurchaseType.Value = DR("PurchaseType")
                        tbx01Department.Value = DR("DeptName")
                        hf01Department.Value = DR("DeptCode")
                        bind01Purpose(DR("PurchaseType"))
                        If ddl01Purpose.Items.FindByValue(DR("Purpose").ToString()) IsNot Nothing Then
                            ddl01Purpose.SelectedValue = DR("Purpose")
                        Else
                            ddl01Purpose.SelectedValue = ""
                        End If
                        hf01Purpose.Value = DR("Purpose")
                        ddl01OSMAType.SelectedValue = DR("OSMType")
                        hf01OSMType.Value = DR("OSMType")
                        tbx01DateReturn.Value = DR("DateReturn")
                        tbx01DateReIssue.Value = DR("DateIssue")
                        'tbx01WorkCode.Value = DR("WorkCode")
                        bind01Subdivision()
                        ddl01Subdivision.SelectedValue = IIf(DR("Title") = "", DR("Subdivision"), "")
                        tbx01Project.Value = DR("Project")
                        hf01Subdivision.Value = DR("Subdivision")
                        hf01Phase.Value = DR("Phase")
                        hf01Block.Value = DR("Block")
                        hf01Lot.Value = DR("Lot")
                        bind01Vehicle()
                        ddl01VehiclePlate.SelectedValue = DR("VehiclePlate")
                        hf01Vehicle.Value = DR("Vehicle")
                        hf01PlateNo.Value = DR("PlateNo")
                        bind01Type(DR("Purpose"))
                        ddl01Type.SelectedValue = DR("Type")
                        hf01Type.Value = DR("Type")
                        bind01Category(DR("Type"))
                        tbx01Division.Value = DR("DivName")
                        hf01Division.Value = DR("Division")
                        lbl0101TitleCategory.Text = "Category"
                        If DR("OSMType") = "OSM Project (Advance PO)" Or DR("OSMType") = "CCI Project (Advance PO)" Then
                            bind01ProjectCategory()
                            ddl01ProjectCat.SelectedValue = DR("Category")
                        End If
                        'hf01Estimate.Value = DR("CECode")
                        tbx01Estimate.Value = IIf(DR("EstimateTitle") <> "", DR("EstimateTitle"), DR("CECode") & " " & DR("SubdName"))
                        If DR("OSMType") = "OSM Project (Stock Request)" Or DR("OSMType") = "CCI Project (Stock Request)" Then
                            bind01ProjectCategory()
                            ddl01ProjectCat.SelectedValue = DR("Category")
                        End If
                        hf01Category.Value = DR("Category")
                        lbl0102TitleCategory.Text = "Category"
                        tbx0102Category.Value = DR("Category")
                        tbx01ActName.Value = DR("ActName")
                        tbx01ActLocation.Value = DR("ActLocation")
                        tbx01ActDate.Value = DR("ActDate")
                        tbx01Remarks.Text = DR("Remarks")
                        tbx01ChargeTo.Value = DR("ChargeTo")
                        hf01ChargeCode.Value = DR("ChargeCode")
                        hf01AcctCode.Value = DR("AcctCode")
                        hf01Subsidiary.Value = DR("Misc")
                        ShowFields()
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
            lbl01PurchaseType.Text = "-"
            lbl01Department.Text = "-"
            lbl01OSMType.Text = "-"
            lbl01Purpose.Text = "-"
            lbl01DateReturn.Text = "-"
            lbl01DateIssue.Text = "-"
            'lbl01WorkCode.Text = "-"
            lbl01Subdivision.Text = "-"
            lbl01Project.Text = "-"
            lbl01VehiclePlate.Text = "-"
            lbl01Type.Text = "-"
            lbl01TitleCategory.Text = "-"
            lbl01Category.Text = "-"
            lbl01ActName.Text = "-"
            lbl01ActLocation.Text = "-"
            lbl01ActDate.Text = "-"
            lbl01Remarks.Text = "-"
            lbl01ChargeTo.Text = "-"
            lbl01Estimate.Text = "-"
            hf02Estimate.Value = ""
            lbl01ProjectCat.Text = "-"
            lbl01Division.Text = "-"
            lbl02Department.Text = "-"
            'set value

            'get total task
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].f_code [ID] ")
            Query.Append("   ,[A].created_date [DateCreated] ")
            Query.Append("   ,[A].date_required [DateRequired] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
            Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
            Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
            Query.Append("   ,[A].status [Status] ")
            Query.Append("   ,[B].PurchaseType ")
            Query.Append("   ,[J].description [Department] ")
            Query.Append("   ,[B].justification [OSMType] ")
            Query.Append("   ,isnull([B].Purpose,'') [Purpose] ")
            Query.Append("   ,isnull(FORMAT([B].DateReturn,'MM/dd/yyyy'),'') [DateReturn] ")
            Query.Append("   ,isnull(FORMAT([B].DateIssue,'MM/dd/yyyy'),'') [DateIssue] ")
            Query.Append("   ,isnull([B].Batch,'') [Batch] ")
            Query.Append("   ,isnull((CASE WHEN (select distinct [HDR].Batch + ' ' + [SUBD].description [Name] from Trxn_CEHdr [HDR] left join subdivision [SUBD] on [HDR].SubdCode = [SUBD].code where [HDR].Batch + ' ' + [HDR].SubdCode = [B].Batch group by [HDR].Batch + ' ' + [SUBD].description) IS NULL THEN (select distinct [HDR].Title + ' ' + [SUBD].description [Name] from Trxn_CEHdr [HDR] left join subdivision [SUBD] on [HDR].SubdCode = [SUBD].code where [HDR].CECode + ' ' + [HDR].SubdCode = [B].Batch group by [HDR].Title + ' ' + [SUBD].description) ELSE (select distinct [HDR].Batch + ' ' + [SUBD].description [Name] from Trxn_CEHdr [HDR] left join subdivision [SUBD] on [HDR].SubdCode = [SUBD].code where [HDR].Batch + ' ' + [HDR].SubdCode = [B].Batch group by [HDR].Batch + ' ' + [SUBD].description) END), '') [BatchName] ")
            Query.Append("   ,isnull([B].WorkCode,'') [WorkCode] ")
            Query.Append("   ,isnull([F].description,'') [Subdivision] ")
            Query.Append("   ,isnull([F].abbr + ' ' + [G].description + ' B' + [H].block + ' L' + [I].lot,'') [Project] ")
            Query.Append("   ,isnull([B].PlateNo + ' - ' + [B].Vehicle,'') [VehiclePlate] ")
            Query.Append("   ,isnull([B].Type,'') [Type] ")
            Query.Append("   ,isnull([B].Category,'') [Category] ")
            Query.Append("   ,isnull([B].ActName,'') [ActName] ")
            Query.Append("   ,isnull([B].ActLocation,'') [ActLocation] ")
            Query.Append("   ,isnull(FORMAT([B].ActDate,'MM/dd/yyyy'),'') [ActDate] ")
            Query.Append("   ,[B].remarks [Remarks] ")
            Query.Append("   ,ISNULL([B].CECode, '') [CECode] ")
            Query.Append("   ,ISNULL([K].Title, '') [EstimateTitle] ")
            Query.Append("   ,ISNULL([B].Subdivision, '') [SubdCode] ")
            Query.Append("   ,ISNULL((select Title from Trxn_CEHdr where Trxn_CEHdr.CECode = [B].Subdivision), '') [Title] ")
            Query.Append("   ,ISNULL([B].ChargeCode, '') [ChargeCode] ")
            Query.Append("   ,ISNULL([B].AcctCode, '') [AcctCode] ")
            Query.Append("   ,ISNULL((CASE WHEN [B].Misc = 'MISCELLANEOUS' THEN (select description from sub_misc where account = [B].AcctCode and code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'MODEL HOUSE' THEN (select description from sub_house where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'NO SUBSIDIARY' THEN ISNULL((select Description from Mstr_PurposeType where Type + ' - ' + Purpose = [B].Purpose and AcctCode = [B].AcctCode and ProjectType = [B].justification), '') ")
            Query.Append("                 WHEN [B].Misc = 'SUBDIVISION' THEN (select description from sub_subdivision where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'PHASE' THEN (select description from sub_phase where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'VENDOR' THEN (select description from sub_vendor where code = [B].ChargeCode) ")
            Query.Append("                 WHEN [B].Misc = 'WAREHOUSE' THEN (select description from sub_warehouse where code = [B].ChargeCode) ")
            Query.Append("      ELSE '' END), '') [ChargeTo] ")
            Query.Append("   ,ISNULL([B].Misc, '') [Misc] ")
            Query.Append("   ,ISNULL([B].Division, '') [Division] ")
            Query.Append("   ,ISNULL(division.description, '') [DivName] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join ogm_pr_hdr [B] on [A].tbl_code = [B].pr_code  ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
            Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
            Query.Append("   left join subdivision [F] on [B].Subdivision = [F].code ")
            Query.Append("   left join phase [G] on [B].Phase = [G].code ")
            Query.Append("   left join eng_block [H] on [B].Block = [H].b_code ")
            Query.Append("   left join eng_lot [I] on [B].Lot = [I].l_code ")
            Query.Append("   left join department [J] on [B].Department = [J].dept_Code ")
            Query.Append("   left join Trxn_CEHdr [K] on [B].CECode = [K].CECode ")
            Query.Append("   left join division on [B].Division = division.div_code ")
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
                        lbl01ID.Text = DR("ID")
                        lbl01FormType.Text = "Purchase Request"
                        lbl01DateRequested.Text = Format(DR("DateCreated"), "MM/dd/yyyy")
                        lbl01DateRequired.Text = Format(DR("DateRequired"), "MM/dd/yyyy")
                        lbl01RequestedBy.Text = DR("RequestedBy")
                        lbl01AssignedTo.Text = DR("AssignedTo")
                        lbl01EndorsedTo.Text = DR("EndorsedTo")
                        lbl01Status.Text = DR("Status")
                        lbl01PurchaseType.Text = DR("PurchaseType")
                        lbl01Department.Text = DR("Department")
                        lbl02Department.Text = DR("Department")
                        lbl01OSMType.Text = DR("OSMType")
                        lbl01Purpose.Text = DR("Purpose")
                        lbl01DateReturn.Text = DR("DateReturn")
                        lbl01DateIssue.Text = DR("DateIssue")
                        lbl01Batch.Text = DR("Batch")
                        'lbl01WorkCode.Text = DR("WorkCode")
                        lbl01Subdivision.Text = DR("Subdivision")
                        hf01Subdivision.Value = DR("SubdCode")
                        lbl01Project.Text = DR("Project")
                        lbl01VehiclePlate.Text = DR("VehiclePlate")
                        lbl01Type.Text = DR("Type")
                        lbl01TitleCategory.Text = "Category"
                        lbl01Category.Text = DR("Category")
                        lbl01ProjectCat.Text = DR("Category")
                        lbl01ActName.Text = DR("ActName")
                        lbl01ActLocation.Text = DR("ActLocation")
                        lbl01ActDate.Text = DR("ActDate")
                        lbl01Remarks.Text = DR("Remarks")
                        lbl01ChargeTo.Text = DR("ChargeTo")
                        lbl01Division.Text = DR("DivName")
                        If DR("OSMType") = "OSM Project (Advance PO)" Or DR("OSMType") = "CCI Project (Advance PO)" Then
                            lbl01Estimate.Text = IIf(DR("EstimateTitle") <> "", DR("EstimateTitle"), DR("CECode") & " " & DR("Subdivision"))
                            hf02Estimate.Value = DR("CECode") & " " & DR("SubdCode")
                        ElseIf DR("OSMType") = "OSM Project (Stock Request)" Or DR("OSMType") = "CCI Project (Stock Request)" Then
                            lbl01Estimate.Text = IIf(DR("EstimateTitle") <> "", DR("EstimateTitle"), DR("CECode") & " " & DR("Subdivision"))
                            hf02Estimate.Value = DR("CECode")
                        End If
                        ShowFields()
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

        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select department'  [Text] ")
        Query.Append("   ,0  [Order] ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("   dept_code [Value] ")
        Query.Append("   ,description  [Text] ")
        Query.Append("   ,1  [Order] ")
        Query.Append("from ")
        Query.Append("   department ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")

        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim con As New SqlConnection(ConStr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl01Department.DataSource = dt
        ddl01Department.DataValueField = "Value"
        ddl01Department.DataTextField = "Text"
        ddl01Department.DataBind()
        'fill data

    End Function
    Function bind01NonDept(DivCode)

        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select department'  [Text] ")
        Query.Append("   ,0  [Order] ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("   [B].dept_code [Value] ")
        Query.Append("   ,[B].description  [Text] ")
        Query.Append("   ,1  [Order] ")
        Query.Append("from ")
        Query.Append("   sys_dept_div [A] ")
        Query.Append("   left join department [B] on [A].d_code = [B].dept_code ")
        Query.Append("where ")
        Query.Append("   isnull([A].lock, 0) = 1 ")
        Query.Append("   and [A].division = '" & DivCode & "' ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")

        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim con As New SqlConnection(ConStr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl01Department.DataSource = dt
        ddl01Department.DataValueField = "Value"
        ddl01Department.DataTextField = "Text"
        ddl01Department.DataBind()
        'fill data

    End Function
    Function bind01Purpose(Purchase)
        Dim Query As New StringBuilder
        Query.Append("declare @Purchase nvarchar(60) = '" & Purchase & "' ")
        Query.Append("declare @Purpose nvarchar(60) = '" & ddl01OSMAType.SelectedValue & "' ")
        'Query.Append("if @Purchase = 'Return' ")
        'Query.Append("begin ")
        'Query.Append("   select ")
        'Query.Append("      '' [Value] ")
        'Query.Append("      ,'Select purpose' [Text] ")
        'Query.Append("   	 ,0 [Order] ")
        'Query.Append("   union ")
        'Query.Append("   select ")
        'Query.Append("       Purpose [Value] ")
        'Query.Append("       ,Purpose [Text] ")
        'Query.Append("	    ,1 [Order] ")
        'Query.Append("   from ")
        'Query.Append("      Mstr_PurposeType ")
        'Query.Append("   where ")
        'Query.Append("      Type = 'Return' ")
        'Query.Append("   order by ")
        'Query.Append("      [Order] ")
        'Query.Append("      ,[Text] ")
        'Query.Append("end ")
        Query.Append("if @Purchase = '' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select purpose' [Text] ")
        Query.Append("   	 ,0 [Order] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select purpose' [Text] ")
        Query.Append("   	 ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       Type + ' - ' + Purpose [Value] ")
        Query.Append("       ,Type + ' - ' + Purpose [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      Mstr_PurposeType ")
        Query.Append("   where  ")
        Query.Append("      isnull(AcctCode, '') <> '' ")
        Query.Append("      and ProjectType = @Purpose ")
        Query.Append("   order by ")
        Query.Append("     [Order], [Value] ")
        Query.Append("end ")

        Dim constr As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password
        Dim con As New SqlConnection(constr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl01Purpose.DataSource = dt
        ddl01Purpose.DataValueField = "Value"
        ddl01Purpose.DataTextField = "Text"
        ddl01Purpose.DataBind()
        'fill data

        If Purchase = "Return" Then
            ddl01OSMAType.Items.Clear()
            ddl01OSMAType.Items.Add(New ListItem("Select project", ""))
            ddl01OSMAType.Items.Add(New ListItem("Non OSM Project", "Non OSM Project"))
            ddl01OSMAType.Items.Add(New ListItem("OSM Project", "OSM Project"))
        Else
            ddl01OSMAType.Items.Clear()
            ddl01OSMAType.Items.Add(New ListItem("Select project", ""))
            ddl01OSMAType.Items.Add(New ListItem("Non OSM Project", "Non OSM Project"))
            ddl01OSMAType.Items.Add(New ListItem("OSM Project", "OSM Project"))
            ddl01OSMAType.Items.Add(New ListItem("OSM Project (Advance PO)", "OSM Project (Advance PO)"))
            ddl01OSMAType.Items.Add(New ListItem("OSM Project (Stock Request)", "OSM Project (Stock Request)"))
            ddl01OSMAType.Items.Add(New ListItem("CCI Project (Advance PO)", "CCI Project (Advance PO)"))
            ddl01OSMAType.Items.Add(New ListItem("CCI Project (Stock Request)", "CCI Project (Stock Request)"))
        End If

        upnl01Overview.Update()

    End Function
    Function bind02Purpose(pProjType)

        Dim Query As New StringBuilder
        Query.Append("declare @ProjType nvarchar(60) = '" & pProjType & "' ")
        'Query.Append("if @Purchase = 'Return' ")
        'Query.Append("begin ")
        'Query.Append("   select ")
        'Query.Append("      '' [Value] ")
        'Query.Append("      ,'Select purpose' [Text] ")
        'Query.Append("   	 ,0 [Order] ")
        'Query.Append("   union ")
        'Query.Append("   select ")
        'Query.Append("       Purpose [Value] ")
        'Query.Append("       ,Purpose [Text] ")
        'Query.Append("	    ,1 [Order] ")
        'Query.Append("   from ")
        'Query.Append("      Mstr_PurposeType ")
        'Query.Append("   where ")
        'Query.Append("      Type = 'Return' ")
        'Query.Append("   order by ")
        'Query.Append("      [Order] ")
        'Query.Append("      ,[Text] ")
        'Query.Append("end ")
        Query.Append("if @ProjType = '' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select purpose' [Text] ")
        Query.Append("   	 ,0 [Order] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select purpose' [Text] ")
        Query.Append("   	 ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       Type + ' - ' + Purpose [Value] ")
        Query.Append("       ,Type + ' - ' + Purpose [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      Mstr_PurposeType ")
        Query.Append("   where  ")
        Query.Append("      isnull(AcctCode, '') <> '' ")
        Query.Append("      and ProjectType = @ProjType ")
        Query.Append("   order by ")
        Query.Append("     [Order], [Value] ")
        Query.Append("end ")

        Dim constr As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password
        Dim con As New SqlConnection(constr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl01Purpose.DataSource = dt
        ddl01Purpose.DataValueField = "Value"
        ddl01Purpose.DataTextField = "Text"
        ddl01Purpose.DataBind()
        'fill data

    End Function
    Function bind01Vehicle()

        'get house
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select vehicle'  [Text] ")
        Query.Append("   ,0  [Order] ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("   PlateNo [Value] ")
        Query.Append("   ,PlateNo + ' - ' + CarModel  [Text] ")
        Query.Append("   ,1  [Order] ")
        Query.Append("from ")
        Query.Append("   Mstr_Vehicle ")
        Query.Append("where ")
        Query.Append("   PlateNo not in ('NA','Others') ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select vehicle'  [Text] ")
        Query.Append("   ,0  [Order] ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("   PlateNo [Value] ")
        Query.Append("   ,PlateNo  [Text] ")
        Query.Append("   ,1  [Order] ")
        Query.Append("from ")
        Query.Append("   Mstr_Vehicle ")
        Query.Append("where ")
        Query.Append("   PlateNo in ('Others') ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get house

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01VehiclePlate.DataSource = DT
        ddl01VehiclePlate.DataValueField = "Value"
        ddl01VehiclePlate.DataTextField = "Text"
        ddl01VehiclePlate.DataBind()
        'fill data

    End Function

    Function bind01Subdivision()

        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select subdivision'  [Text] ")
        Query.Append("   ,0  [Order] ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("   code [Value] ")
        Query.Append("   ,abbr  [Text] ")
        Query.Append("   ,1  [Order] ")
        Query.Append("from ")
        Query.Append("   subdivision ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")

        Dim constr As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password
        Dim con As New SqlConnection(constr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl01Subdivision.DataSource = dt
        ddl01Subdivision.DataValueField = "Value"
        ddl01Subdivision.DataTextField = "Text"
        ddl01Subdivision.DataBind()
        'fill data

    End Function

    Function bind01Type(Purpose)

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select type' [Text] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   Purpose [Value] ")
        Query.Append("   ,Purpose [Text] ")
        Query.Append("from ")
        Query.Append("   Mstr_PurposeType ")
        Query.Append("where ")
        Query.Append("   Type + ' - ' + Purpose = '" & Purpose & "' ")
        Query.Append("order by ")
        Query.Append("   [Value] ")

        Dim constr As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password
        Dim con As New SqlConnection(constr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl01Type.DataSource = dt
        ddl01Type.DataValueField = "Value"
        ddl01Type.DataTextField = "Text"
        ddl01Type.DataBind()
        'fill data

    End Function
    Function bind01GLAccount(Purpose)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @DeptCode nvarchar(13) = ISNULL((select dept_code from employee where emp_no = '" & CIIS_EmpCode & "'), '') ")
        Query.Append("declare @BussCode nvarchar(13) = ISNULL((select buss_code from employee where emp_no = '" & CIIS_EmpCode & "'), '') ")
        Query.Append("declare @DivCode nvarchar(13) = ISNULL((select div_code from business where buss_code = @BussCode), '') ")
        Query.Append("select ")
        Query.Append("  ISNULL(AcctCode, '') [AcctCode] ")
        Query.Append("  ,(CASE WHEN ISNULL(DivCode, '') = '' THEN @DivCode ELSE ISNULL(DivCode, '') END) [DivCode] ")
        Query.Append("  ,isnull((select description from division where div_code = (CASE WHEN ISNULL(DivCode, '') = '' THEN @DivCode ELSE ISNULL(DivCode, '') END)), '') [DivName] ")
        Query.Append("  ,(CASE WHEN ISNULL(DeptCode, '') = '' THEN @DeptCode ELSE ISNULL(DeptCode, '') END) [DeptCode] ")
        Query.Append("  ,isnull((select description from department where dept_code = (CASE WHEN ISNULL(DeptCode, '') = '' THEN @DeptCode ELSE ISNULL(DeptCode, '') END)), '') [DeptName] ")
        Query.Append("  ,ISNULL(Subsidiary, '') [Subsidiary] ")
        Query.Append("  ,ISNULL(ChargeCode, '') [ChargeCode] ")
        Query.Append("  ,ISNULL(Description, '') [Description] ")
        Query.Append("from ")
        Query.Append("  Mstr_PurposeType ")
        Query.Append("where ")
        Query.Append("  Type + ' - ' + Purpose = '" & Purpose & "' ")
        'get query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    hf01AcctCode.Value = DR("AcctCode")
                    hf01Division.Value = DR("DivCode")
                    tbx01Division.Value = DR("DivName")
                    hf01Department.Value = DR("DeptCode")
                    tbx01Department.Value = DR("DeptName")
                    hf01Subsidiary.Value = DR("Subsidiary")
                    hf01ChargeCode.Value = DR("ChargeCode")
                    tbx01ChargeTo.Value = DR("Description")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Function bind01Category(Type)

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select type' [Text] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   Purpose [Value] ")
        Query.Append("   ,Purpose [Text] ")
        Query.Append("from ")
        Query.Append("   Mstr_PurposeType ")
        Query.Append("where ")
        Query.Append("   Type = '" & Type & "' ")
        Query.Append("order by ")
        Query.Append("   [Value] ")

        Dim constr As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password
        Dim con As New SqlConnection(constr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl0101Category.DataSource = dt
        ddl0101Category.DataValueField = "Value"
        ddl0101Category.DataTextField = "Text"
        ddl0101Category.DataBind()
        'fill data

    End Function
    Function bind01ProjectCategory()

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select Category' [Text] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   Category [Value] ")
        Query.Append("   ,Category [Text] ")
        Query.Append("from ")
        Query.Append("   Parm_CECategory ")
        Query.Append("where ")
        Query.Append("   ISNULL(Lock, 0) = 1 ")
        Query.Append("order by ")
        Query.Append("   [Value] ")

        Dim constr As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password
        Dim con As New SqlConnection(constr)
        Dim sda As New SqlDataAdapter(Query.ToString, con)
        Dim dt As New DataTable()
        sda.Fill(dt)

        'fill data
        ddl01ProjectCat.DataSource = dt
        ddl01ProjectCat.DataValueField = "Value"
        ddl01ProjectCat.DataTextField = "Text"
        ddl01ProjectCat.DataBind()
        'fill data

    End Function

    Function bind01Estimate(Type)

        'set query
        Dim Query As New StringBuilder
        If Type = "OSM Project (Advance PO)" Or Type = "CCI Project (Advance PO)" Then

            Query.Append("select ")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Select a estimate' [Name] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   (CASE WHEN [A].Batch = '-' OR [A].Batch = '' OR [A].Batch IS NULL THEN [A].CECode ELSE [A].Batch END) + ' ' + [A].SubdCode [Code] ")
            Query.Append("   ,(CASE WHEN [A].Batch = '-' OR [A].Batch = '' OR [A].Batch IS NULL THEN [A].Title ELSE [A].Batch END) + ' ' + [B].description [Name] ")
            Query.Append("   ,(CASE WHEN [A].Batch = '-' OR [A].Batch = '' OR [A].Batch IS NULL THEN [A].Title ELSE [A].Batch END) + ' ' + [B].description [Order] ")
            'Query.Append("   [A].Batch + ' ' + [A].SubdCode [Code] ")
            'Query.Append("   ,[A].Batch + ' ' + [B].description [Name] ")
            'Query.Append("   ,[A].Batch + ' ' + [B].description [Order] ")
            Query.Append("from ")
            Query.Append("   Trxn_CEHdr [A] ")
            Query.Append("   left join subdivision [B] on [A].SubdCode = [B].code ")
            Query.Append("where ")
            Query.Append("   [A].Post = 1 ")
            Query.Append("   and [A].Rvrs = 0 ")
            Query.Append("   and [B].description IS NOT NULL ")
            'Query.Append("   and [A].Category in ('House Construction') ")
            Query.Append("group by ")
            Query.Append("  (CASE WHEN [A].Batch = '-' OR [A].Batch = '' OR [A].Batch IS NULL THEN [A].CECode ELSE [A].Batch END) + ' ' + [A].SubdCode ")
            Query.Append("  ,(CASE WHEN [A].Batch = '-' OR [A].Batch = '' OR [A].Batch IS NULL THEN [A].Title ELSE [A].Batch END) + ' ' + [B].description ")
            'Query.Append("  [A].Batch + ' ' + [A].SubdCode ")
            'Query.Append("  ,[A].Batch + ' ' + [B].description ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        ElseIf Type = "OSM Project (Stock Request)" Or Type = "CCI Project (Stock Request)" Then

            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Select a estimate' [Name] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].CECode [Code] ")
            Query.Append("   ,[B].Title [Name] ")
            Query.Append("   ,[B].Title [Order] ")
            Query.Append("from ")
            Query.Append("   Trxn_CEDtl [A] ")
            Query.Append("   left join Trxn_CEHdr [B] on [A].CECode = [B].CECode ")
            Query.Append("where ")
            Query.Append("   ([A].Qty + [A].QtyRev) - [A].QtyReq > 0 ")
            Query.Append("   and [B].Post = 1 ")
            Query.Append("   and [B].Rvrs = 0 ")
            Query.Append("order by ")
            Query.Append("   [Order] ")

        End If
        'set query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        'ddl01Estimate.DataSource = DT
        'ddl01Estimate.DataValueField = "Code"
        'ddl01Estimate.DataTextField = "Name"
        'ddl01Estimate.DataBind()
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
        If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
            bind06PRDtl()
        Else
            bind0601PRDtl()
        End If
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
        If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
            bind06PRDtl()
        Else
            bind0601PRDtl()
        End If
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
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
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
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
            bind06History()
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
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
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

            If tbx01DateRequired.Text = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf tbx01FormType.Text = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01PurchaseType.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
                'ElseIf ddl01PurchaseType.SelectedValue = "Return" And (tbx01DateReturn.Value = "" Or tbx01DateReIssue.Value = "") Then
                '    Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "OSM Project (Advance PO)" And ddl01ProjectCat.SelectedIndex = 0 Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "OSM Project (Stock Request)" And tbx01Estimate.Value = "" And ddl01ProjectCat.SelectedIndex = 0 Then
                Alert("error", "Some field(s) are missing!")
            ElseIf div01ProjectCat.Style("display") = "" And ddl01ProjectCat.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "CCI Project (Advance PO)" And ddl01ProjectCat.SelectedIndex = 0 Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "CCI Project (Stock Request)" And ddl01ProjectCat.SelectedIndex = 0 And tbx01Estimate.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf (ddl01ProjectCat.SelectedValue = "House Construction" Or ddl01ProjectCat.SelectedValue = "House Construction - CCI") And hf01Subdivision.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01ProjectCat.SelectedIndex <> 0 And tbx01Estimate.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "FUEL" And (hf01Vehicle.Value = "" Or hf01PlateNo.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "GRASS CUTTER MAINTENANCE" And (hf01Subdivision.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "HOUSE REPAIR" And (hf01Subdivision.Value = "" Or hf01Phase.Value = "" Or hf01Block.Value = "" Or hf01Lot.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Aircon" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Grass Cutter" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Tools and Equipment" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Vehicle" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "SALES EVENTS AND ACTIVITIES - Sales Events" And (tbx01ActName.Value = "" Or tbx01ActLocation.Value = "" Or tbx01ActDate.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf (ddl01OSMAType.SelectedValue = "Non OSM Project" OrElse ddl01OSMAType.SelectedValue = "OSM Project" OrElse ddl01OSMAType.SelectedValue.Contains("Advance PO")) And (tbx01ChargeTo.Value = "") Then
                Alert("error", "Some field(s) are missing!")
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
            If tbx01DateRequired.Text = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf tbx01FormType.Text = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01PurchaseType.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
                'ElseIf ddl01PurchaseType.SelectedValue = "Return" And (tbx01DateReturn.Value = "" Or tbx01DateReIssue.Value = "") Then
                '    Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "OSM Project (Advance PO)" And ddl01ProjectCat.SelectedIndex = 0 Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "OSM Project (Stock Request)" And tbx01Estimate.Value = "" And ddl01ProjectCat.SelectedIndex = 0 Then
                Alert("error", "Some field(s) are missing!")
            ElseIf div01ProjectCat.Style("display") = "" And ddl01ProjectCat.SelectedValue = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "CCI Project (Advance PO)" And ddl01ProjectCat.SelectedIndex = 0 Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01OSMAType.SelectedValue = "CCI Project (Stock Request)" And ddl01ProjectCat.SelectedIndex = 0 And tbx01Estimate.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf (ddl01ProjectCat.SelectedValue = "House Construction" Or ddl01ProjectCat.SelectedValue = "House Construction - CCI") And hf01Subdivision.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01ProjectCat.SelectedIndex <> 0 And tbx01Estimate.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "FUEL" And (hf01Vehicle.Value = "" Or hf01PlateNo.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "GRASS CUTTER MAINTENANCE" And (hf01Subdivision.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "HOUSE REPAIR" And (hf01Subdivision.Value = "" Or hf01Phase.Value = "" Or hf01Block.Value = "" Or hf01Lot.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Aircon" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Grass Cutter" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Tools and Equipment" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "REPAIR AND MAINTENANCE - Vehicle" And tbx0102Category.Value = "" Then
                Alert("error", "Some field(s) are missing!")
            ElseIf ddl01Purpose.SelectedValue = "SALES EVENTS AND ACTIVITIES - Sales Events" And (tbx01ActName.Value = "" Or tbx01ActLocation.Value = "" Or tbx01ActDate.Value = "") Then
                Alert("error", "Some field(s) are missing!")
            ElseIf (ddl01OSMAType.SelectedValue = "Non OSM Project" Or ddl01OSMAType.SelectedValue = "OSM Project" Or ddl01OSMAType.SelectedValue.Contains("Advance PO")) And (tbx01ChargeTo.Value = "") Then
                Alert("error", "Some field(s) are missing!")
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
                If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                    bind06PRDtl()
                Else
                    bind0601PRDtl()
                End If
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
            SqlCmd.CommandText = "New_FRM_FRM000010"
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Text)
            SqlCmd.Parameters.AddWithValue("@pPurchaseType", ddl01PurchaseType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pDepartment", hf01Department.Value)
            SqlCmd.Parameters.AddWithValue("@pOSMType", ddl01OSMAType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pPurpose", ddl01Purpose.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pDateReturn", tbx01DateReturn.Value)
            SqlCmd.Parameters.AddWithValue("@pDateIssue", tbx01DateReIssue.Value)
            SqlCmd.Parameters.AddWithValue("@pBatch", "")
            SqlCmd.Parameters.AddWithValue("@pSubdivision", hf01Subdivision.Value)
            SqlCmd.Parameters.AddWithValue("@pPhase", hf01Phase.Value)
            SqlCmd.Parameters.AddWithValue("@pBlock", hf01Block.Value)
            SqlCmd.Parameters.AddWithValue("@pLot", hf01Lot.Value)
            SqlCmd.Parameters.AddWithValue("@pVehicle", hf01Vehicle.Value)
            SqlCmd.Parameters.AddWithValue("@pPlateNo", hf01PlateNo.Value)
            SqlCmd.Parameters.AddWithValue("@pType", ddl01Type.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pCategory", IIf(ddl01OSMAType.SelectedValue = "OSM Project (Stock Request)" Or ddl01OSMAType.SelectedValue = "CCI Project (Stock Request)" Or ddl01OSMAType.SelectedValue = "OSM Project (Advance PO)" Or ddl01OSMAType.SelectedValue = "CCI Project (Advance PO)", ddl01ProjectCat.SelectedValue, IIf(ddl01Purpose.SelectedValue.Contains("REPAIR AND MAINTENANCE"), tbx0102Category.Value, ddl0101Category.SelectedValue)))
            SqlCmd.Parameters.AddWithValue("@pActName", tbx01ActName.Value)
            SqlCmd.Parameters.AddWithValue("@pActLocation", tbx01ActLocation.Value)
            SqlCmd.Parameters.AddWithValue("@pActDate", tbx01ActDate.Value)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Remarks.Text)
            SqlCmd.Parameters.AddWithValue("@pChargeCode", hf01ChargeCode.Value)
            SqlCmd.Parameters.AddWithValue("@pAcctCode", hf01AcctCode.Value)
            SqlCmd.Parameters.AddWithValue("@pDivision", hf01Division.Value)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            SqlCmd.Parameters.AddWithValue("@pCECode", hf01Estimate.Value)
            SqlCmd.Parameters.AddWithValue("@pMisc", hf01Subsidiary.Value)
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
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
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
            SqlCmd.CommandText = "Upd_FRM_FRM000010"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pDateRequired", tbx01DateRequired.Text)
            SqlCmd.Parameters.AddWithValue("@pPurchaseType", ddl01PurchaseType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pDepartment", hf01Department.Value)
            SqlCmd.Parameters.AddWithValue("@pOSMType", ddl01OSMAType.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pPurpose", ddl01Purpose.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pDateReturn", tbx01DateReturn.Value)
            SqlCmd.Parameters.AddWithValue("@pDateIssue", tbx01DateReIssue.Value)
            SqlCmd.Parameters.AddWithValue("@pBatch", "")
            SqlCmd.Parameters.AddWithValue("@pSubdivision", hf01Subdivision.Value)
            SqlCmd.Parameters.AddWithValue("@pPhase", hf01Phase.Value)
            SqlCmd.Parameters.AddWithValue("@pBlock", hf01Block.Value)
            SqlCmd.Parameters.AddWithValue("@pLot", hf01Lot.Value)
            SqlCmd.Parameters.AddWithValue("@pVehicle", hf01Vehicle.Value)
            SqlCmd.Parameters.AddWithValue("@pPlateNo", hf01PlateNo.Value)
            SqlCmd.Parameters.AddWithValue("@pType", ddl01Type.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pCategory", IIf(ddl01OSMAType.SelectedValue = "OSM Project (Stock Request)" Or ddl01OSMAType.SelectedValue = "CCI Project (Stock Request)" Or ddl01OSMAType.SelectedValue = "OSM Project (Advance PO)" Or ddl01OSMAType.SelectedValue = "CCI Project (Advance PO)", ddl01ProjectCat.SelectedValue, IIf(ddl01Purpose.SelectedValue.Contains("REPAIR AND MAINTENANCE"), tbx0102Category.Value, ddl0101Category.SelectedValue)))
            SqlCmd.Parameters.AddWithValue("@pActName", tbx01ActName.Value)
            SqlCmd.Parameters.AddWithValue("@pActLocation", tbx01ActLocation.Value)
            SqlCmd.Parameters.AddWithValue("@pActDate", tbx01ActDate.Value)
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Remarks.Text)
            SqlCmd.Parameters.AddWithValue("@pChargeCode", hf01ChargeCode.Value)
            SqlCmd.Parameters.AddWithValue("@pAcctCode", hf01AcctCode.Value)
            SqlCmd.Parameters.AddWithValue("@pCECode", hf01Estimate.Value)
            SqlCmd.Parameters.AddWithValue("@pMisc", hf01Subsidiary.Value)
            SqlCmd.Parameters.AddWithValue("@pDivision", hf01Division.Value)
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
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
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
            tbx01Note.Value = ""
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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000011.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000011.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000011.rpt"))
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
        RptDoc.SetParameterValue("@pFormNo", ltrlID.Text, "PRPrintoutwNote.rpt")
        RptDoc.SetParameterValue("@pFormNo", ltrlID.Text)
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf"), Buf)
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

        'view report
        RptDoc.Dispose()
        RptDoc.Close()
        Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
        ScriptManager.RegisterStartupScript(upnl01Overview, upnl01Overview.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
        'view report

    End Sub
    Private Sub ddl01PurchaseType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl01PurchaseType.SelectedIndexChanged

        'bind
        bind01Purpose(ddl01PurchaseType.SelectedValue)
        'bind

        'set value
        ddl01Department.SelectedValue = ""
        ddl01OSMAType.SelectedValue = ""
        ddl01Purpose.SelectedValue = ""
        tbx01DateReturn.Value = ""
        tbx01DateReIssue.Value = ""
        'tbx01WorkCode.Value = ""
        tbx01Project.Value = ""
        ddl01Type.SelectedValue = ""
        tbx0102Category.Value = ""
        tbx01ActName.Value = ""
        tbx01ActName.Value = ""
        tbx01ActDate.Value = ""
        'set value

        'display
        ShowFields()
        'display

    End Sub
    Private Sub ddl01OSMAType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl01OSMAType.SelectedIndexChanged

        If ddl01OSMAType.SelectedValue = "OSM Project (Advance PO)" Or ddl01OSMAType.SelectedValue = "OSM Project (Stock Request)" Or ddl01OSMAType.SelectedValue = "CCI Project (Advance PO)" Or ddl01OSMAType.SelectedValue = "CCI Project (Stock Request)" Then
            bind01Estimate(ddl01OSMAType.SelectedValue)
        End If

        'If ddl01PurchaseType.SelectedValue <> "Return" And (ddl01OSMAType.SelectedValue = "OSM Project (Stock Request)" Or ddl01OSMAType.SelectedValue = "CCI Project (Stock Request)") Then
        '    ddl01Purpose.SelectedValue = "Others - CONSTRUCTION MATERIALS"
        'End If

        'set value
        'tbx01WorkCode.Value = ""
        'set value

        'display
        bind02Purpose(ddl01OSMAType.SelectedValue)
        bind02Department()
        ShowFields()
        'display

    End Sub
    Function bind02Department()

        'get department
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].dept_code ")
        Query.Append("  ,[B].div_code ")
        Query.Append("  ,[D].description [DivDesc] ")
        Query.Append("  ,[C].description [DeptDesc] ")
        Query.Append("from ")
        Query.Append("  employee [A] ")
        Query.Append("  left join business [B] on [A].buss_code = [B].buss_code ")
        Query.Append("  left join department [C] on [A].dept_code = [C].dept_code ")
        Query.Append("  left join division [D] on [B].div_code = [D].div_code ")
        Query.Append("where ")
        Query.Append("  [A].emp_no = '" & CIIS_EmpCode & "' ")
        'get department

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    tbx01Division.Value = DR("DivDesc")
                    hf01Division.Value = DR("div_code")
                    tbx01Department.Value = DR("DeptDesc")
                    hf01Department.Value = DR("dept_code")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function
    Private Sub ddl01Purpose_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl01Purpose.SelectedIndexChanged

        'bind
        bind01Type(ddl01Purpose.SelectedValue)
        bind01GLAccount(ddl01Purpose.SelectedValue)
        'bind

        'set value
        tbx01Project.Value = ""
        tbx0102Category.Value = ""
        tbx01ActName.Value = ""
        tbx01ActName.Value = ""
        tbx01ActDate.Value = ""
        'set value

        'display
        ShowFields()
        'display

    End Sub
    Private Sub ddl01Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl01Type.SelectedIndexChanged

        'bind
        bind01Category(ddl01Type.SelectedValue)
        'bind

        'set value
        hf01Category.Value = ""
        tbx0102Category.Value = ""
        tbx01ActName.Value = ""
        tbx01ActName.Value = ""
        tbx01ActDate.Value = ""
        'set value

        'display
        ShowFields()
        'display

    End Sub
    Private Sub ddl01ProjectCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl01ProjectCat.SelectedIndexChanged

        If ddl01ProjectCat.SelectedValue <> "" Then
            tbx01Estimate.Value = ""
            hf01Estimate.Value = ""
        End If

        If ddl01ProjectCat.SelectedValue <> "House Construction" Or ddl01ProjectCat.SelectedValue = "House Construction - CCI" Then
            spn02Estimate.InnerText = "Estimate"
            tbx01Estimate.Attributes("placeholder") = "Estimate"
        Else
            spn02Estimate.InnerText = "Batch"
            tbx01Estimate.Attributes("placeholder") = "Batch"
        End If

        ShowFields()

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
        Query.Append("      [A].tbl_from = 'ogm_pr_hdr' ")
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
        Query.Append("      [A].tbl_from = 'ogm_pr_hdr' ")
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
        Query.Append("      [A].tbl_from = 'ogm_pr_hdr' ")
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
        Query.Append("if (select top 1 created_by from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and status = '') in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & ltrlID.Text & "') not in ('For Cancellation')")
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
        Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and status = '') in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & ltrlID.Text & "') not in ('For Cancellation') ")
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
        Query.Append("      'Declined' [Code] ")
        Query.Append("      ,'Decline' [Name] ")
        Query.Append("end ")
        Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & ltrlID.Text & "' and status = '') in ('Clarification') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("   union ")
        Query.Append("   select")
        Query.Append("      'Reply' [Code] ")
        Query.Append("      ,'Reply' [Name] ")
        Query.Append("end ")
        Query.Append("else if (select top 1 status from oop_form_hdr where f_code = '" & ltrlID.Text & "') in ('For Cancellation') ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a status' [Name] ")
        Query.Append("   union")
        Query.Append("   select")
        Query.Append("      'Cancelled' [Code] ")
        Query.Append("      ,'Cancel' [Name] ")
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

        If ddl01Status.SelectedValue = "Declined" Then
            spn01Note.Attributes("class") = "col-lg-3 fw-bold text-muted pt-2 required"
        Else
            spn01Note.Attributes("class") = "col-lg-3 fw-bold text-muted pt-2"
        End If

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
        ElseIf ddl01Status.SelectedValue = "Declined" And tbx01Note.Value = "" Then
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
                SqlCmd.Parameters.AddWithValue("@pRemarks", tbx01Note.Value)
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
                tbx01Note.Value = ""
                hdnMention.Value = ""

                'clear record

                'display success message
                Alert("success", "Record successfully saved.")
                'display success message

                'refresh record
                bindTitle()
                bind01Overview()
                If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                    bind06PRDtl()
                Else
                    bind0601PRDtl()
                End If
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

#Region "Particular"

    Function bind06SCMMaterial(ByVal pBatch As String)

        'get item
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("  [Scope] ")
        Query.Append("  ,[Particular] ")
        Query.Append("  ,FORMAT([Qty1],'N2') [Qty1] ")
        Query.Append("  ,FORMAT([Qty2],'N2') [Qty2] ")
        Query.Append("   ,FORMAT([Qty1] - [Qty2],'N2') [Qty3] ")
        Query.Append("  ,[UOM] ")
        Query.Append("  ,[WBSNo] ")
        Query.Append("from  ")
        Query.Append("  (select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,[B].Description [Scope] ")
        Query.Append("      ,'' [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("      ,NULL [WBSNo] ")
        Query.Append("  from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("  where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND [A].BatchNo + ' ' + [A].Project = '" & pBatch & "' ")
        Query.Append("  union ")
        Query.Append("  select distinct ")
        Query.Append("      1 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,SUM([A].Qty + [A].QtyRev) - SUM([A].QtyPO) [Qty1] ")
        Query.Append("      ,ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[C].abbr [UOM] ")
        Query.Append("      ,[A].WBSNo ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      left join sys_um [C] on [A].UMCode = [C].u_code ")
        Query.Append("   where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND [A].BatchNo + ' ' + [A].Project = '" & pBatch & "' ")
        Query.Append("   group by ")
        Query.Append("      [A].WBSNo, [B].WNo, [A].Particular, [C].abbr) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        'get item

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Scope"))
        dtable.Columns.Add(New DataColumn("Particular"))
        dtable.Columns.Add(New DataColumn("Qty1"))
        dtable.Columns.Add(New DataColumn("Qty2"))
        dtable.Columns.Add(New DataColumn("Qty3"))
        dtable.Columns.Add(New DataColumn("UOM"))
        dtable.Columns.Add(New DataColumn("WBSNo"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Dim NewRowValues As Object() = {DR("Scope"), DR("Particular"), DR("Qty1"), DR("Qty2"), DR("Qty3"), DR("UOM"), DR("WBSNo")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv06SCMMaterial.DataSource = dtable
        gv06SCMMaterial.DataBind()
        'bind datatable

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv06SCMMaterial.Rows.Count > 0 Then

            'Adds THEAD and TBODY Section.
            gv06SCMMaterial.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv06SCMMaterial.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 

        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update 
        mdl06PRDtlAddSCM.Update()
        'update 

        If gv06SCMMaterial.Rows.Count = 0 Then
            Return False
        End If

        Return True

    End Function
    Function bind06SCM01Material(ByVal pBatch As String)

        'get item
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("  [Scope] ")
        Query.Append("  ,[Particular] ")
        Query.Append("  ,FORMAT([Qty1],'N2') [Qty1] ")
        Query.Append("  ,FORMAT([Qty2],'N2') [Qty2] ")
        Query.Append("   ,FORMAT([Qty1] - [Qty2],'N2') [Qty3] ")
        Query.Append("  ,[UOM] ")
        Query.Append("  ,[WBSNo] ")
        Query.Append("from  ")
        Query.Append("  (select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,[B].Description [Scope] ")
        Query.Append("      ,'' [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("      ,NULL [WBSNo] ")
        Query.Append("  from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("  where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND [A].CECode  = '" & pBatch & "' ")
        Query.Append("  union ")
        Query.Append("  select distinct ")
        Query.Append("      1 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,SUM([A].Qty + [A].QtyRev) - SUM([A].QtyPO) [Qty1] ")
        Query.Append("      ,ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[C].abbr [UOM] ")
        Query.Append("      ,[A].WBSNo ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      left join sys_um [C] on [A].UMCode = [C].u_code ")
        Query.Append("   where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND [A].CECode = '" & pBatch & "' ")
        Query.Append("   group by ")
        Query.Append("      [A].WBSNo, [B].WNo, [A].Particular, [C].abbr) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        'get item

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Scope"))
        dtable.Columns.Add(New DataColumn("Particular"))
        dtable.Columns.Add(New DataColumn("Qty1"))
        dtable.Columns.Add(New DataColumn("Qty2"))
        dtable.Columns.Add(New DataColumn("Qty3"))
        dtable.Columns.Add(New DataColumn("UOM"))
        dtable.Columns.Add(New DataColumn("WBSNo"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Dim NewRowValues As Object() = {DR("Scope"), DR("Particular"), DR("Qty1"), DR("Qty2"), DR("Qty3"), DR("UOM"), DR("WBSNo")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv06SCMMaterial.DataSource = dtable
        gv06SCMMaterial.DataBind()
        'bind datatable

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv06SCMMaterial.Rows.Count > 0 Then

            'Adds THEAD and TBODY Section.
            gv06SCMMaterial.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv06SCMMaterial.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 

        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update 
        mdl06PRDtlAddSCM.Update()
        'update 

    End Function
    Function bind0601OSMMaterial(ByVal CECode As String)

        'get item
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("   (case when [SeqNo] = 0 then 'd-none' else '' end) [Style] ")
        Query.Append("   ,(case when [SeqNo] = 0 then 'text-gray-200 text-weight-500 min-w-200px' else '' end) [TextStyle] ")
        Query.Append("   ,[Particular] ")
        Query.Append("   ,[ItmNo] ")
        Query.Append("   ,FORMAT([Qty1],'N2') [Qty1] ")
        Query.Append("   ,FORMAT([Qty2],'N2') [Qty2] ")
        Query.Append("   ,FORMAT([Qty1] - [Qty2],'N2') [Qty3] ")
        Query.Append("   ,[UOM] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,NULL [ItmNo] ")
        Query.Append("      ,[B].WNo [ItemNo] ")
        Query.Append("      ,[B].WNo [No] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = '" & CECode & "' ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      [A].SeqNo ")
        Query.Append("      ,[A].ItemNo [ItmNo] ")
        Query.Append("      ,[C].WNo [ItemNo] ")
        Query.Append("      ,'' [No] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) [Qty1] ")
        Query.Append("      ,isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[B].abbr [UOM] ")
        Query.Append("   FROM ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join sys_um [B] on [A].UMCode = [B].u_code ")
        Query.Append("      left join Mstr_Work [C] on [A].WCode = [C].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = '" & CECode & "' ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ) [A] ")
        Query.Append("where ")
        Query.Append("   [Qty1] > 0 ")
        Query.Append("order by ")
        Query.Append("   [ItemNo] ")
        Query.Append("   ,[SeqNo] ")
        'get item

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Style"))
        dtable.Columns.Add(New DataColumn("TextStyle"))
        dtable.Columns.Add(New DataColumn("Particular"))
        dtable.Columns.Add(New DataColumn("ItmNo"))
        dtable.Columns.Add(New DataColumn("Qty1"))
        dtable.Columns.Add(New DataColumn("Qty2"))
        dtable.Columns.Add(New DataColumn("Qty3"))
        dtable.Columns.Add(New DataColumn("UOM"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Dim NewRowValues As Object() = {DR("Style"), DR("TextStyle"), DR("Particular"), DR("ItmNo"), DR("Qty1"), DR("Qty2"), DR("Qty3"), DR("UOM")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv0601OSMMaterial.DataSource = dtable
        gv0601OSMMaterial.DataBind()
        'bind datatable

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv0601OSMMaterial.Rows.Count > 0 Then

            'Adds THEAD and TBODY Section.
            gv0601OSMMaterial.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv0601OSMMaterial.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 

        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update 
        mdl0601PRDtlAddOSM.Update()
        'update 

    End Function
    Function bind06OSMMaterial(ByVal CECode As String, ByVal Subd As String)

        'get item
        Dim Query As New StringBuilder
        If lbl01ProjectCat.Text = "House Construction" Then
            Query.Append("select ")
            Query.Append("   [WBSNo] ")
            Query.Append("   ,[Particular] ")
            Query.Append("   ,[Unit] ")
            Query.Append("   ,FORMAT([Qty1],'N2') [Qty1] ")
            Query.Append("   ,FORMAT([Qty2],'N2') [Qty2] ")
            Query.Append("   ,FORMAT([Qty1] - [Qty2],'N2') [Qty3] ")
            Query.Append("   ,[Count] ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      [B].WNo [Order01] ")
            Query.Append("      ,'' [Order02] ")
            Query.Append("      ,'' [WBSNo] ")
            Query.Append("      ,[B].Description [Particular] ")
            Query.Append("      ,'' [Unit] ")
            Query.Append("      ,NULL [Qty1] ")
            Query.Append("      ,NULL [Qty2] ")
            Query.Append("      ,NULL [Count] ")
            Query.Append("   from ")
            Query.Append("      Trxn_CEDtl_HouseCon [A] ")
            Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
            Query.Append("   where ")
            Query.Append("      [A].BatchNo = '" & CECode & "' ")
            Query.Append("      and [A].Project = '" & Subd & "' ")
            Query.Append("      and [A].TblFrom = 'ogm_item' ")
            Query.Append("      and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0 ")
            Query.Append("   group by ")
            Query.Append("      [B].WNo ")
            Query.Append("      ,[B].description ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      [B].WNo [Order01] ")
            Query.Append("      ,[A].WBSNo [Order02] ")
            Query.Append("      ,[A].WBSNo ")
            Query.Append("      ,[A].Particular  ")
            Query.Append("      ,[c].abbr [Unit] ")
            Query.Append("      ,([A].Qty + [A].QtyRev) - [A].QtyReq [Qty1] ")
            Query.Append("      ,isnull((select sum([D].qty) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in		('Accepted','Declined','Cancelled')),0) [Qty2] ")
            Query.Append("      ,isnull((select count(1) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].f_code = '" & ltrlID.Text & "' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Count] ")
            Query.Append("   FROM ")
            Query.Append("      Trxn_CEDtl_HouseCon [A] ")
            Query.Append("      left join Mstr_Work [B] on [A].WCode = [b].WCode ")
            Query.Append("      left join sys_um [c] on [A].UMCode = [c].u_code ")
            Query.Append("   where ")
            Query.Append("      [A].BatchNo = '" & CECode & "' ")
            Query.Append("      and [A].Project = '" & Subd & "' ")
            Query.Append("      and [A].TblFrom = 'ogm_item' ")
            Query.Append("      and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0) [A] ")
            Query.Append("order by ")
            Query.Append("   [Order01] ")
            Query.Append("   ,[Order02] ")
        ElseIf lbl01ProjectCat.Text = "House Construction - CCI" Then
            Query.Append("select ")
            Query.Append("   [WBSNo] ")
            Query.Append("   ,[Particular] ")
            Query.Append("   ,[Unit] ")
            Query.Append("   ,FORMAT([Qty1],'N2') [Qty1] ")
            Query.Append("   ,FORMAT([Qty2],'N2') [Qty2] ")
            Query.Append("   ,FORMAT([Qty1] - [Qty2],'N2') [Qty3] ")
            Query.Append("   ,[Count] ")
            Query.Append("from ")
            Query.Append("   (select ")
            Query.Append("      [B].WNo [Order01] ")
            Query.Append("      ,'' [Order02] ")
            Query.Append("      ,'' [WBSNo] ")
            Query.Append("      ,[B].Description [Particular] ")
            Query.Append("      ,'' [Unit] ")
            Query.Append("      ,NULL [Qty1] ")
            Query.Append("      ,NULL [Qty2] ")
            Query.Append("      ,NULL [Count] ")
            Query.Append("   from ")
            Query.Append("      Trxn_CEDtl_HouseCon_CCI [A] ")
            Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
            Query.Append("   where ")
            Query.Append("      [A].BatchNo = '" & CECode & "' ")
            Query.Append("      and [A].Project = '" & Subd & "' ")
            Query.Append("      and [A].TblFrom = 'ogm_item' ")
            Query.Append("      and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0 ")
            Query.Append("   group by ")
            Query.Append("      [B].WNo ")
            Query.Append("      ,[B].description ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      [B].WNo [Order01] ")
            Query.Append("      ,[A].WBSNo [Order02] ")
            Query.Append("      ,[A].WBSNo ")
            Query.Append("      ,[A].Particular  ")
            Query.Append("      ,[c].abbr [Unit] ")
            Query.Append("      ,([A].Qty + [A].QtyRev) - [A].QtyReq [Qty1] ")
            Query.Append("      ,isnull((select sum([D].qty) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in	('Accepted','Declined','Cancelled')),0) [Qty2] ")
            Query.Append("      ,isnull((select count(1) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].f_code = '" & ltrlID.Text & "' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Count] ")
            Query.Append("   FROM ")
            Query.Append("      Trxn_CEDtl_HouseCon_CCI [A] ")
            Query.Append("      left join Mstr_Work [B] on [A].WCode = [b].WCode ")
            Query.Append("      left join sys_um [c] on [A].UMCode = [c].u_code ")
            Query.Append("   where ")
            Query.Append("      [A].BatchNo = '" & CECode & "' ")
            Query.Append("      and [A].Project = '" & Subd & "' ")
            Query.Append("      and [A].TblFrom = 'ogm_item' ")
            Query.Append("      and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0) [A] ")
            Query.Append("order by ")
            Query.Append("   [Order01] ")
            Query.Append("   ,[Order02] ")
        End If
        'get item

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("WBSNo"))
        dtable.Columns.Add(New DataColumn("Particular"))
        dtable.Columns.Add(New DataColumn("Qty1"))
        dtable.Columns.Add(New DataColumn("Qty2"))
        dtable.Columns.Add(New DataColumn("Qty3"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("Count"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Dim NewRowValues As Object() = {DR("WBSNo"), DR("Particular"), DR("Qty1"), DR("Qty2"), DR("Qty3"), DR("Unit"), DR("Count")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv06OSMMaterial.DataSource = dtable
        gv06OSMMaterial.DataBind()
        'bind datatable

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv06OSMMaterial.Rows.Count > 0 Then

            'Adds THEAD and TBODY Section.
            gv06OSMMaterial.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv06OSMMaterial.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 

        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update 
        mdl06PRDtlAddOSM.Update()
        'update 

    End Function
    Function bind06OSMTagMaterial(ByVal ItemNo As String, ByVal SubdCode As String)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Subd] ")
        Query.Append("  ,[Phase] ")
        Query.Append("  ,[Block] ")
        Query.Append("  ,[Lot] ")
        Query.Append("  ,[ModelName] ")
        Query.Append("  ,[Particular] ")
        Query.Append("  ,[Qty1] ")
        Query.Append("  ,[Qty2] ")
        Query.Append("  ,[Qty1] - [Qty2] [Qty3] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [D].abbr [Subd] ")
        Query.Append("  ,[C].description [Phase] ")
        Query.Append("  ,[B].block ")
        Query.Append("  ,[A].lot ")
        Query.Append("  ,[F].ModelName ")
        Query.Append("  ,ISNULL((select Trxn_CEDtl.Particular from Trxn_CEDtl where Trxn_CEDtl.ItemNo = '" & ItemNo & "'), '') [Particular] ")
        Query.Append("  ,ISNULL((select (Trxn_CEDtl.Qty + Trxn_CEDtl.QtyRev) - Trxn_CEDtl.QtyReq from Trxn_CEDtl where Trxn_CEDtl.ItemNo = '" & ItemNo & "'), 0) [Qty1] ")
        Query.Append("  ,ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join ogm_pr_hdr [G] on [F].pr_code = [G].pr_code left join oop_form_hdr [E] on [E].f_code = [G].form_no where [F].ItemNo = '" & ItemNo & "' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("from ")
        Query.Append("  eng_lot [A] ")
        Query.Append("  left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("  left join phase [C] on [B].p_code = [C].code ")
        Query.Append("  left join subdivision [D] on [C].scode = [D].code ")
        Query.Append("  left join calmardbLive.dbo.mstr_LotsInventory [E] on [A].LotCode = [E].LotCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [F] on [E].Model = [F].ModelCode ")
        Query.Append("where ")
        Query.Append("  [D].code = '" & SubdCode & "') [Tbl] ")
        'query

    End Function
    Protected Sub gv06SCMMaterial_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv06SCMMaterial.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl06SCMParticular As Label = CType(e.Row.FindControl("lbl06SCMParticular"), Label)
            Dim tbx06SCMQty As HtmlInputText = CType(e.Row.FindControl("tbx06SCMQty"), HtmlInputText)
            Dim tbx06SCMRemarks As HtmlInputText = CType(e.Row.FindControl("tbx06SCMRemarks"), HtmlInputText)
            If lbl06SCMParticular.Text = "" Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#92d050")
                e.Row.ForeColor = Color.Black
                e.Row.Font.Bold = True
                tbx06SCMQty.Visible = False
                tbx06SCMRemarks.Visible = False
            End If
        End If
    End Sub
    Protected Sub gv06OSMMaterial_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv06OSMMaterial.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblItemNo As Label = CType(e.Row.FindControl("lbl06OSMItemNo"), Label)
            Dim lbl06OSMCount As Label = CType(e.Row.FindControl("lbl06OSMCount"), Label)
            Dim lbl06OSMQty3 As Label = CType(e.Row.FindControl("lbl06OSMQty3"), Label)
            Dim tbx06OSMRemarks As HtmlInputText = CType(e.Row.FindControl("tbx06OSMRemarks"), HtmlInputText)
            Dim lbtn06Add As LinkButton = CType(e.Row.FindControl("lbtn06Add"), LinkButton)
            If IIf(lbl06OSMCount.Text = "", 0, lbl06OSMCount.Text) <> 0 Then
                lbtn06Add.Enabled = False
                lbtn06Add.CssClass = "btn btn-sm btn-icon btn-secondary w-100"
            End If
            If lblItemNo.Text = "" Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#92d050")
                e.Row.ForeColor = Color.Black
                e.Row.Font.Bold = True
                tbx06OSMRemarks.Visible = False
                lbtn06Add.Visible = False
            End If
            If IIf(lbl06OSMQty3.Text = "", 0, lbl06OSMQty3.Text) > 0 Then
                lbtn06Add.Visible = True
            Else
                lbtn06Add.Visible = False
            End If
        End If
    End Sub
    Protected Sub gv0601OSMMaterial_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv0601OSMMaterial.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblItemNo As Label = CType(e.Row.FindControl("lbl0601OSMItemNo"), Label)
            If lblItemNo.Text = "" Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#92d050")
                e.Row.ForeColor = Color.Black
                e.Row.Font.Bold = True
            End If
        End If
    End Sub
    Function bind06PRDtl()

        'get item
        Dim Query As New StringBuilder
        If (lbl01OSMType.Text = "OSM Project (Advance PO)" Or lbl01OSMType.Text = "CCI Project (Advance PO)") And (lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI") Then
            Query.Append("  select ")
            Query.Append("      [A].seq_no [SeqNo] ")
            Query.Append("      ,(case when SCMNo != '' then 'SCM' when ItemNo != '' then 'OSM' else '' end) [OSM] ")
            Query.Append("      ,[A].item [Item] ")
            Query.Append("      ,FORMAT([A].qty,'N2') [Qty] ")
            Query.Append("      ,[A].unit [Unit] ")
            Query.Append("      ,FORMAT([A].BdgtAmt,'N2') [BdgtAmt] ")
            Query.Append("      ,[A].status [Status] ")
            Query.Append("      ,FORMAT([A].ForPO,'N2') [POQty] ")
            Query.Append("      ,FORMAT([A].for_sr + [A].ForWT + [A].ForIR,'N2') [SRQty] ")
            Query.Append("      ,FORMAT([A].ForCP,'N2') [CPQty] ")
            Query.Append("      ,FORMAT([A].unit_cost,'N2') [CPCost] ")
            Query.Append("      ,FORMAT([A].tot_cost,'N2') [CPTotal] ")
            Query.Append("      ,[A].remarks [Remarks] ")
            Query.Append("      ,(case when [A].ItemNo = '' then [A].SCMNo else [A].ItemNo end) [ItemNo] ")
            Query.Append("      ,'' [Scope] ")
            Query.Append("   from ")
            Query.Append("      ogm_pr_dtl [A] ")
            Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("   where ")
            Query.Append("      [B].f_code = '" & ltrlID.Text & "' ")
        Else
            Query.Append("select ")
            Query.Append("  [SeqNo] ")
            Query.Append("  ,[OSM] ")
            Query.Append("  ,(CASE WHEN [Item] = '' THEN [Scope] ELSE [Item] END) [Item] ")
            Query.Append("  ,[Qty] ")
            Query.Append("  ,[Unit] ")
            Query.Append("  ,[BdgtAmt] ")
            Query.Append("  ,[Status] ")
            Query.Append("  ,[POQty] ")
            Query.Append("  ,[SRQty] ")
            Query.Append("  ,[CPQty] ")
            Query.Append("  ,[CPCost] ")
            Query.Append("  ,[CPTotal] ")
            Query.Append("  ,[Remarks] ")
            Query.Append("  ,[ItemNo] ")
            Query.Append("  ,[Scope] ")
            Query.Append("from ")
            Query.Append("  (select ")
            Query.Append("      0 [SeqNo] ")
            Query.Append("      ,'' [OSM] ")
            Query.Append("      ,'' [Item] ")
            Query.Append("      ,NULL [Qty] ")
            Query.Append("      ,'' [Unit] ")
            Query.Append("      ,NULL [BdgtAmt] ")
            Query.Append("      ,'' [Status] ")
            Query.Append("      ,NULL [POQty] ")
            Query.Append("      ,NULL [SRQty] ")
            Query.Append("      ,NULL [CPQty] ")
            Query.Append("      ,NULL [CPCost] ")
            Query.Append("      ,NULL [CPTotal] ")
            Query.Append("      ,'' [Remarks] ")
            Query.Append("      ,'' [ItemNo] ")
            Query.Append("      ,[D].Description [Scope] ")
            Query.Append("      ,[D].WNo [WNo] ")
            Query.Append("  from ")
            Query.Append("      ogm_pr_dtl [A] ")
            Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("      left join Trxn_CEDtl_HouseCon [C] on [A].WBSNo = [C].WBSNo ")
            Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
            Query.Append("  where ")
            Query.Append("      [B].f_code = '" & ltrlID.Text & "' ")
            Query.Append("  group by ")
            Query.Append("      [D].Description ")
            Query.Append("      ,[D].WNo ")
            Query.Append("  union ")
            Query.Append("  select ")
            Query.Append("      [A].seq_no [SeqNo] ")
            Query.Append("      ,(case when SCMNo != '' then 'SCM' when WBSNo != '' then 'OSM' else '' end) [OSM] ")
            Query.Append("      ,[A].item [Item] ")
            Query.Append("      ,FORMAT([A].qty,'N2') [Qty] ")
            Query.Append("      ,[A].unit [Unit] ")
            Query.Append("      ,FORMAT([A].BdgtAmt,'N2') [BdgtAmt] ")
            Query.Append("      ,[A].status [Status] ")
            Query.Append("      ,FORMAT([A].ForPO,'N2') [POQty] ")
            Query.Append("      ,FORMAT([A].for_sr + [A].ForWT + [A].ForIR,'N2') [SRQty] ")
            Query.Append("      ,FORMAT([A].ForCP,'N2') [CPQty] ")
            Query.Append("      ,FORMAT([A].unit_cost,'N2') [CPCost] ")
            Query.Append("      ,FORMAT([A].tot_cost,'N2') [CPTotal] ")
            Query.Append("      ,[A].remarks [Remarks] ")
            Query.Append("      ,(case when [A].WBSNo = '' then [A].SCMNo else [A].WBSNo end) [ItemNo] ")
            Query.Append("      ,'' [Scope] ")
            Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl_HouseCon [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].WBSNo  = [A].WBSNo GROUP BY [D].WNo), '') [WNo] ")
            Query.Append("   from ")
            Query.Append("      ogm_pr_dtl [A] ")
            Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("   where ")
            Query.Append("      [B].f_code = '" & ltrlID.Text & "') [Tbl] ")
            Query.Append("order by ")
            Query.Append("  [WNo], [SeqNo] ")
        End If
        'get item

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("OSM"))
        dtable.Columns.Add(New DataColumn("Item"))
        dtable.Columns.Add(New DataColumn("Qty"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("BdgtAmt"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("POQty"))
        dtable.Columns.Add(New DataColumn("SRQty"))
        dtable.Columns.Add(New DataColumn("CPQty"))
        dtable.Columns.Add(New DataColumn("CPCost"))
        dtable.Columns.Add(New DataColumn("CPTotal"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("ItemNo"))
        dtable.Columns.Add(New DataColumn("Scope"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Dim NewRowValues As Object() = {DR("SeqNo"), IIf(lbl01OSMType.Text = "OSM Project (Advance PO)", "SCM", IIf(lbl01OSMType.Text = "OSM Project (Stock Request)", "OSM", IIf(lbl01OSMType.Text = "CCI Project (Advance PO)", "CCI", IIf(lbl01OSMType.Text = "CCI Project (Stock Request)", "CCI", DR("OSM"))))), DR("Item"), DR("Qty"), DR("Unit"), DR("BdgtAmt"), DR("Status"), DR("POQty"), DR("SRQty"), DR("CPQty"), DR("CPCost"), DR("CPTotal"), DR("Remarks"), DR("ItemNo"), DR("Scope")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv06PRDtl.DataSource = dtable
        gv06PRDtl.DataBind()
        'bind datatable

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv06PRDtl.Rows.Count > 0 Then

            'Adds THEAD and TBODY Section.
            gv06PRDtl.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv06PRDtl.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 

        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update 
        upnl06PRDtl.Update()
        'update 

    End Function
    Function bind0601PRDtl()

        'get item
        Dim Query As New StringBuilder
        If (lbl01OSMType.Text = "OSM Project (Advance PO)" Or lbl01OSMType.Text = "CCI Project (Advance PO)") And lbl01ProjectCat.Text <> "House Construction" Or lbl01ProjectCat.Text <> "House Construction - CCI" Then
            Query.Append("  select ")
            Query.Append("      [A].seq_no [SeqNo] ")
            Query.Append("      ,(case when SCMNo != '' then 'SCM' when ItemNo != '' then 'OSM' else '' end) [OSM] ")
            Query.Append("      ,[A].item [Item] ")
            Query.Append("      ,FORMAT([A].qty,'N2') [Qty] ")
            Query.Append("      ,[A].unit [Unit] ")
            Query.Append("      ,FORMAT([A].BdgtAmt,'N2') [BdgtAmt] ")
            Query.Append("      ,[A].status [Status] ")
            Query.Append("      ,FORMAT([A].ForPO,'N2') [POQty] ")
            Query.Append("      ,FORMAT([A].for_sr + [A].ForWT + [A].ForIR,'N2') [SRQty] ")
            Query.Append("      ,FORMAT([A].ForCP,'N2') [CPQty] ")
            Query.Append("      ,FORMAT([A].unit_cost,'N2') [CPCost] ")
            Query.Append("      ,FORMAT([A].tot_cost,'N2') [CPTotal] ")
            Query.Append("      ,[A].remarks [Remarks] ")
            Query.Append("      ,(case when [A].ItemNo = '' then [A].SCMNo else [A].ItemNo end) [ItemNo] ")
            Query.Append("      ,'' [Scope] ")
            Query.Append("   from ")
            Query.Append("      ogm_pr_dtl [A] ")
            Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("   where ")
            Query.Append("      [B].f_code = '" & ltrlID.Text & "' ")
        Else
            Query.Append("select ")
            Query.Append("  [SeqNo] ")
            Query.Append("  ,[OSM] ")
            Query.Append("  ,(CASE WHEN [Item] = '' THEN [Scope] ELSE [Item] END) [Item] ")
            Query.Append("  ,[Qty] ")
            Query.Append("  ,[Unit] ")
            Query.Append("  ,[BdgtAmt] ")
            Query.Append("  ,[Status] ")
            Query.Append("  ,[POQty] ")
            Query.Append("  ,[SRQty] ")
            Query.Append("  ,[CPQty] ")
            Query.Append("  ,[CPCost] ")
            Query.Append("  ,[CPTotal] ")
            Query.Append("  ,[Remarks] ")
            Query.Append("  ,[ItemNo] ")
            Query.Append("  ,[Scope] ")
            Query.Append("from ")
            Query.Append("  (select ")
            Query.Append("      0 [SeqNo] ")
            Query.Append("      ,'' [OSM] ")
            Query.Append("      ,'' [Item] ")
            Query.Append("      ,NULL [Qty] ")
            Query.Append("      ,'' [Unit] ")
            Query.Append("      ,NULL [BdgtAmt] ")
            Query.Append("      ,'' [Status] ")
            Query.Append("      ,NULL [POQty] ")
            Query.Append("      ,NULL [SRQty] ")
            Query.Append("      ,NULL [CPQty] ")
            Query.Append("      ,NULL [CPCost] ")
            Query.Append("      ,NULL [CPTotal] ")
            Query.Append("      ,'' [Remarks] ")
            Query.Append("      ,'' [ItemNo] ")
            Query.Append("      ,[D].Description [Scope] ")
            Query.Append("      ,[D].WNo [WNo] ")
            Query.Append("  from ")
            Query.Append("      ogm_pr_dtl [A] ")
            Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("      left join Trxn_CEDtl [C] on [A].ItemNo = [C].ItemNo and [C].Particular = [A].item ")
            Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
            Query.Append("  where ")
            Query.Append("      [B].f_code = '" & ltrlID.Text & "' ")
            Query.Append("  group by ")
            Query.Append("      [D].Description ")
            Query.Append("      ,[D].WNo ")
            Query.Append("  union ")
            Query.Append("  select ")
            Query.Append("      [A].seq_no [SeqNo] ")
            Query.Append("      ,(case when SCMNo != '' then 'SCM' when ItemNo != '' then 'OSM' else '' end) [OSM] ")
            Query.Append("      ,[A].item [Item] ")
            Query.Append("      ,FORMAT([A].qty,'N2') [Qty] ")
            Query.Append("      ,[A].unit [Unit] ")
            Query.Append("      ,FORMAT([A].BdgtAmt,'N2') [BdgtAmt] ")
            Query.Append("      ,[A].status [Status] ")
            Query.Append("      ,FORMAT([A].ForPO,'N2') [POQty] ")
            Query.Append("      ,FORMAT([A].for_sr + [A].ForWT + [A].ForIR,'N2') [SRQty] ")
            Query.Append("      ,FORMAT([A].ForCP,'N2') [CPQty] ")
            Query.Append("      ,FORMAT([A].unit_cost,'N2') [CPCost] ")
            Query.Append("      ,FORMAT([A].tot_cost,'N2') [CPTotal] ")
            Query.Append("      ,[A].remarks [Remarks] ")
            Query.Append("      ,(case when ISNULL([A].ItemNo,'') = '' then [A].SCMNo else ISNULL([A].ItemNo,'') end) [ItemNo] ")
            Query.Append("      ,'' [Scope] ")
            Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].ItemNo = [A].ItemNo and [C].Particular = [A].item GROUP BY [D].WNo), '') [WNo] ")
            Query.Append("   from ")
            Query.Append("      ogm_pr_dtl [A] ")
            Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("   where ")
            Query.Append("      [B].f_code = '" & ltrlID.Text & "') [Tbl] ")
            Query.Append("order by ")
            Query.Append("  [WNo], [SeqNo] ")
        End If
        'get item

        'create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SeqNo"))
        dtable.Columns.Add(New DataColumn("OSM"))
        dtable.Columns.Add(New DataColumn("Item"))
        dtable.Columns.Add(New DataColumn("Qty"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("BdgtAmt"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("POQty"))
        dtable.Columns.Add(New DataColumn("SRQty"))
        dtable.Columns.Add(New DataColumn("CPQty"))
        dtable.Columns.Add(New DataColumn("CPCost"))
        dtable.Columns.Add(New DataColumn("CPTotal"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("ItemNo"))
        dtable.Columns.Add(New DataColumn("Scope"))
        'create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'add new row
                    Dim NewRowValues As Object() = {DR("SeqNo"), IIf(lbl01OSMType.Text = "OSM Project (Advance PO)", "SCM", IIf(lbl01OSMType.Text = "OSM Project (Stock Request)", If(DR("ItemNo").ToString() <> "", "OSM", ""), IIf(lbl01OSMType.Text = "CCI Project (Advance PO)", "CCI", IIf(lbl01OSMType.Text = "CCI Project (Stock Request)", If(DR("ItemNo").ToString() <> "", "CCI", ""), DR("OSM"))))), DR("Item"), DR("Qty"), DR("Unit"), DR("BdgtAmt"), DR("Status"), DR("POQty"), DR("SRQty"), DR("CPQty"), DR("CPCost"), DR("CPTotal"), DR("Remarks"), DR("ItemNo"), DR("Scope")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind DataTable
        gv0601PRDtl.DataSource = dtable
        gv0601PRDtl.DataBind()
        'bind datatable

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gv0601PRDtl.Rows.Count > 0 Then

            'Adds THEAD and TBODY Section.
            gv0601PRDtl.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TFOOT section. 
            gv0601PRDtl.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 

        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'update 
        upnl06PRDtl.Update()
        'update 

    End Function
    Private Sub gv06PRDtl_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv06PRDtl.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim HeaderGridRow As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
            HeaderGridRow.TableSection = TableRowSection.TableHeader
            Dim HeaderCell As TableCell = New TableCell
            HeaderCell.Text = ""
            HeaderCell.ColumnSpan = 6
            HeaderGridRow.Cells.Add(HeaderCell)

            gv06PRDtl.Controls(0).Controls.AddAt(0, HeaderGridRow)
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim unitValue As Object = DataBinder.Eval(e.Row.DataItem, "Unit")
            Dim row As GridViewRow = e.Row

            If lbl01OSMType.Text = "Non OSM Project" Then
                Dim lbtnTag As LinkButton = TryCast(row.FindControl("lbtn06PRDtlTag"), LinkButton)
                lbtnTag.Visible = False
            End If
        End If
    End Sub
    Protected Sub gv06PRDtl_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv06PRDtl.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblUnit As Label = TryCast(e.Row.FindControl("lbl06Unit"), Label)
            Dim unitValue As String = If(lblUnit IsNot Nothing, lblUnit.Text, "")

            Dim lbtnDel As LinkButton = TryCast(e.Row.FindControl("lbtn06PRDtlDel"), LinkButton)
            Dim lbtnUpd As LinkButton = TryCast(e.Row.FindControl("lbtn06PRDtlUpd"), LinkButton)
            Dim lbtnTag As LinkButton = TryCast(e.Row.FindControl("lbtn06PRDtlTag"), LinkButton)
            Dim lblOSM As Label = TryCast(e.Row.FindControl("lbl06OSM"), Label)
            Dim lblItem As Label = TryCast(e.Row.FindControl("lbl06Item"), Label)
            Dim itemValue As String = If(lblItem IsNot Nothing, lblItem.Text.Trim(), String.Empty)

            If String.IsNullOrEmpty(itemValue) Then
                e.Row.Visible = False
                Exit Sub  ' No need to process other conditions
            End If

            If String.IsNullOrWhiteSpace(unitValue) OrElse unitValue = "0" Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#92d050")
                e.Row.ForeColor = Color.Black
                e.Row.Font.Bold = True

                If lbtnDel IsNot Nothing Then lbtnDel.Visible = False
                If lbtnUpd IsNot Nothing Then lbtnUpd.Visible = False
                If lbtnTag IsNot Nothing Then lbtnTag.Visible = False
                If lblOSM IsNot Nothing Then lblOSM.Visible = False
            Else
                If lbl01OSMType.Text = "OSM Project (Advance PO)" Or lbl01OSMType.Text = "CCI Project (Advance PO)" Then
                    lbtnUpd.Visible = True
                    lbtnTag.Visible = False
                ElseIf lbl01OSMType.Text = "OSM Project (Stock Request)" Or lbl01OSMType.Text = "CCI Project (Stock Request)" Then
                    lbtnTag.Visible = True
                End If
            End If

        End If
    End Sub
    Private Sub gv0601PRDtl_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv0601PRDtl.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            Dim HeaderGridRow As GridViewRow = New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
            HeaderGridRow.TableSection = TableRowSection.TableHeader
            Dim HeaderCell As TableCell = New TableCell
            HeaderCell.Text = ""
            HeaderCell.ColumnSpan = 8
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell
            HeaderCell.Text = "For"
            HeaderCell.ColumnSpan = 2
            HeaderCell.CssClass = "fw-bold fs-6 text-dark table-header-hover"
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell
            HeaderCell.Text = "For Cash Purchase"
            HeaderCell.ColumnSpan = 4
            HeaderCell.CssClass = "fw-bold fs-6 text-dark table-header-hover"
            HeaderGridRow.Cells.Add(HeaderCell)

            gv0601PRDtl.Controls(0).Controls.AddAt(0, HeaderGridRow)
        End If
    End Sub
    Protected Sub gv0601PRDtl_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv0601PRDtl.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lblUnit As Label = TryCast(e.Row.FindControl("lbl0601Unit"), Label)
            Dim unitValue As String = If(lblUnit IsNot Nothing, lblUnit.Text, "")
            Dim lblItem As Label = TryCast(e.Row.FindControl("lbl0601Item"), Label)
            Dim itemValue As String = If(lblItem IsNot Nothing, lblItem.Text.Trim(), String.Empty)

            If String.IsNullOrEmpty(itemValue) Then
                e.Row.Visible = False
                Exit Sub  ' No need to process other conditions
            End If

            If String.IsNullOrWhiteSpace(unitValue) OrElse unitValue = "0" Then
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#92d050")
                e.Row.ForeColor = Color.Black
                e.Row.Font.Bold = True

                Dim lbtnDel As LinkButton = TryCast(e.Row.FindControl("lbtn0601PRDtlDel"), LinkButton)
                Dim lbtnUpd As LinkButton = TryCast(e.Row.FindControl("lbtn0601PRDtlUpd"), LinkButton)

                If lbtnDel IsNot Nothing Then lbtnDel.Visible = False
                If lbtnUpd IsNot Nothing Then lbtnUpd.Visible = False
            End If
        End If
    End Sub
    Private Sub lbtn06PRDtlAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn06PRDtlAdd.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'set value
            ltrlDtlMode.Text = "ADD"
            tbx06PRDtlAddItem.Text = ""
            tbx06PRDtlAddQty.Value = "0.00"
            tbx06PRDtlAddUnit.Text = ""
            tbx06PRDtlAddBdgtAmt.Value = "0.00"
            mdl06PRDtlAdd.Update()
            'set value

            'modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl06PRDtlAdd').modal('show');</script>", False)
            'modal

        End If

    End Sub
    Private Sub lbtn06PRDtlAddOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn06PRDtlAddOk.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        ElseIf tbx06PRDtlAddItem.Text = "" Then
            Alert("error", "Some field(s) are missing!")
        ElseIf CDbl(tbx06PRDtlAddQty.Value) <= 0 Then
            Alert("error", "Some field(s) are missing!")
        ElseIf tbx06PRDtlAddUnit.Text = "" Then
            Alert("error", "Some field(s) are missing!")
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pItem", tbx06PRDtlAddItem.Text)
            SqlCmd.Parameters.AddWithValue("@pQty", CDbl(tbx06PRDtlAddQty.Value))
            SqlCmd.Parameters.AddWithValue("@pUnit", tbx06PRDtlAddUnit.Text)
            SqlCmd.Parameters.AddWithValue("@pBdgtAmt", CDbl(tbx06PRDtlAddBdgtAmt.Value))
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'reset value
            ltrlDtlMode.Text = "ADD"
            tbx06PRDtlAddItem.Text = ""
            tbx06PRDtlAddQty.Value = "0.00"
            tbx06PRDtlAddUnit.Text = ""
            tbx06PRDtlAddBdgtAmt.Value = "0.00"
            mdl06PRDtlAdd.Update()
            'reset value

            'success message
            Alert("success", "Particular successfully saved.")
            'success message

            'display item
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
            'display item

            'update panel 
            upnl06PRDtl.Update()
            'update panel 

        End If
        'validate record

    End Sub
    Protected Sub btn06PRDtlAdd_SCM_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            'set value
            If lbl01OSMType.Text = "OSM Project (Advance PO)" Or lbl01OSMType.Text = "CCI Project (Advance PO)" Then
                Dim result As Boolean = bind06SCMMaterial(hf02Estimate.Value)
                If result = True Then
                    bind06SCMMaterial(hf02Estimate.Value)
                Else
                    bind06SCM01Material(hf02Estimate.Value)
                End If
            End If
            'set value

            'update data
            mdl06PRDtlAddSCM.Update()
            'update data

            'modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl06PRDtlAddSCM').modal('show');</script>", False)
            'modal

        End If

    End Sub
    Private Sub lbtn06PRDtlAdd_SCM_Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn06PRDtlAdd_SCM_Ok.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Add", "")
        'create variable

        'create variable
        Dim RowIdx = 0
        Dim ItemSrs = ""
        Dim Cnt = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gv06SCMMaterial.Rows.Count
            Dim lbl06SCMParticular As Label = gv06SCMMaterial.Rows(RowIdx).FindControl("lbl06SCMParticular")
            Dim tbx06SCMQty As HtmlInputText = gv06SCMMaterial.Rows(RowIdx).FindControl("tbx06SCMQty")
            Dim lbl06SCMUnit As Label = gv06SCMMaterial.Rows(RowIdx).FindControl("lbl06SCMUnit")
            Dim tbx06SCMRemarks As HtmlInputText = gv06SCMMaterial.Rows(RowIdx).FindControl("tbx06SCMRemarks")
            Dim lbl06SCMWBSNo As Label = gv06SCMMaterial.Rows(RowIdx).FindControl("lbl06SCMWBSNo")
            If CDbl(tbx06SCMQty.Value) > 0 Then
                If ItemSrs = "" Then
                    ItemSrs = lbl06SCMParticular.Text & "©" & CDbl(tbx06SCMQty.Value) & "©" & lbl06SCMUnit.Text & "©" & tbx06SCMRemarks.Value & "©" & lbl06SCMWBSNo.Text
                Else
                    ItemSrs = ItemSrs & "®" & lbl06SCMParticular.Text & "©" & CDbl(tbx06SCMQty.Value) & "©" & lbl06SCMUnit.Text & "©" & tbx06SCMRemarks.Value & "©" & lbl06SCMWBSNo.Text
                End If
                Cnt = Cnt + 1
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'validate record
        If Cnt = 0 Then
            Alert("error", "No record selected!")
            Exit Sub
        End If

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_SCM"
        SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
        SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", ItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'display item
        Dim result As Boolean = bind06SCMMaterial(hf02Estimate.Value)
        If result = True Then
            bind06SCMMaterial(hf02Estimate.Value)
        Else
            bind06SCM01Material(hf02Estimate.Value)
        End If
        'display item

        'update panel 
        mdl06PRDtlAddSCM.Update()
        'update panel

        'display item
        If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
            bind06PRDtl()
        Else
            bind0601PRDtl()
        End If
        'display item

        'success message
        Alert("success", "Particular successfully saved.")
        'success message

    End Sub
    Protected Sub btn06PRDtlAdd_OSM_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Add", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        Else

            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then

                'set value
                bind06OSMMaterial(hf02Estimate.Value, hf01Subdivision.Value)
                'set value

                'update data
                mdl06PRDtlAddOSM.Update()
                'update data

                'modal
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl06PRDtlAddOSM').modal('show');</script>", False)
                'modal

            Else
                'set value
                bind0601OSMMaterial(hf02Estimate.Value)
                'set value

                'update data
                mdl0601PRDtlAddOSM.Update()
                'update data

                'modal
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl0601PRDtlAddOSM').modal('show');</script>", False)
                'modal

            End If

        End If
        'validate record

    End Sub
    Private Sub lbtn0601PRDtlAdd_OSM_Ok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn0601PRDtlAdd_OSM_Ok.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Add", "")
        'create variable

        'create variable
        Dim RowIdx = 0
        Dim ItemSrs = ""
        Dim Cnt = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gv0601OSMMaterial.Rows.Count
            Dim lbl06OSMItemNo As Label = gv0601OSMMaterial.Rows(RowIdx).FindControl("lbl0601OSMItemNo")
            Dim lbl06OSMParticular As Label = gv0601OSMMaterial.Rows(RowIdx).FindControl("lbl0601OSMParticular")
            Dim tbx06OSMQty As HtmlInputText = gv0601OSMMaterial.Rows(RowIdx).FindControl("tbx0601OSMQty")
            Dim lbl06OSMUnit As Label = gv0601OSMMaterial.Rows(RowIdx).FindControl("lbl0601OSMUnit")
            Dim tbx06OSMRemarks As HtmlInputText = gv0601OSMMaterial.Rows(RowIdx).FindControl("tbx0601OSMRemarks")
            If CDbl(tbx06OSMQty.Value) > 0 Then
                If ItemSrs = "" Then
                    ItemSrs = lbl06OSMItemNo.Text & "©" & lbl06OSMParticular.Text & "©" & CDbl(tbx06OSMQty.Value) & "©" & lbl06OSMUnit.Text & "©" & tbx06OSMRemarks.Value
                Else
                    ItemSrs = ItemSrs & "®" & lbl06OSMItemNo.Text & "©" & lbl06OSMParticular.Text & "©" & CDbl(tbx06OSMQty.Value) & "©" & lbl06OSMUnit.Text & "©" & tbx06OSMRemarks.Value
                End If
                Cnt = Cnt + 1
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'validate record
        If Cnt = 0 Then
            Alert("error", "No record selected!")
            Exit Sub
        End If
        'validate record

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_OSM"
        SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
        SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", ItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()

        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'display item
        bind0601OSMMaterial(hf02Estimate.Value)
        'display item

        'update panel 
        mdl0601PRDtlAddOSM.Update()
        'update panel

        'display item
        bind0601PRDtl()
        'display item

        'success message
        Alert("success", "Particular successfully saved.")
        'success message

    End Sub
    Function bind06PRDtlOSM(Particular, Qty, Remarks)

        'variable
        Dim ItemSrs = ""
        'variable

        'query
        Dim Query As New StringBuilder
        Query.Append("DECLARE @Particular nvarchar(max) = '" & Particular.ToString.Replace("'", "") & "' ")
        Query.Append("DECLARE @CECode nvarchar(13) = '" & hf02Estimate.Value & "' ")
        Query.Append("DECLARE @ItemNo nvarchar(60) ")
        Query.Append("DECLARE @CEQty decimal(21, 2) ")
        Query.Append("DECLARE @Qty decimal(21, 2) = " & CDbl(Qty) & " ")
        Query.Append("DECLARE @RunningTotal decimal(21, 2) = 0 ")
        Query.Append("DECLARE @LastQty decimal(21, 2) = 0 ")
        Query.Append("DECLARE @CRSMaterial cursor ")
        Query.Append("  SET @CRSMaterial = CURSOR STATIC FOR ")
        Query.Append("      select  ")
        Query.Append("          ItemNo ")
        Query.Append("          ,Qty ")
        Query.Append("      from ")
        Query.Append("          Trxn_CEDtl ")
        Query.Append("      where ")
        Query.Append("          CECode = @CECode ")
        Query.Append("          and REPLACE(Particular, '''','') = @Particular ")
        Query.Append("      order by ")
        Query.Append("          SeqNo ")
        Query.Append("  OPEN @CRSMaterial ")
        Query.Append("      while 1 = 1 ")
        Query.Append("      begin ")
        Query.Append("          fetch @CRSMaterial into ")
        Query.Append("              @ItemNo ")
        Query.Append("              ,@CEQty ")
        Query.Append("          if @@FETCH_STATUS <> 0 ")
        Query.Append("              break ")
        Query.Append("          set @RunningTotal = @RunningTotal + @CEQty ")
        Query.Append("          set @LastQty = @CEQty ")
        Query.Append("          if @RunningTotal <= @Qty ")
        Query.Append("          begin ")
        Query.Append("              select ")
        Query.Append("                  Particular ")
        Query.Append("                  ,ItemNo ")
        Query.Append("                  ,Qty ")
        Query.Append("                  ,(select abbr from sys_um where u_code = Trxn_CEDtl.UMCode) [UOM] ")
        Query.Append("                      ,@LastQty [LastQty] ")
        Query.Append("               from ")
        Query.Append("                  Trxn_CEDtl ")
        Query.Append("               where ")
        Query.Append("                  ItemNo = @ItemNo ")
        Query.Append("          end ")
        Query.Append("          if @RunningTotal >= @Qty ")
        Query.Append("          begin ")
        Query.Append("              if @RunningTotal > @Qty ")
        Query.Append("              begin ")
        Query.Append("                  set @LastQty = @LastQty - (@RunningTotal - @Qty) ")
        Query.Append("                  select ")
        Query.Append("                      Particular ")
        Query.Append("                      ,ItemNo ")
        Query.Append("                      ,Qty ")
        Query.Append("                      ,(select abbr from sys_um where u_code = Trxn_CEDtl.UMCode) [UOM] ")
        Query.Append("                      ,@LastQty [LastQty] ")
        Query.Append("                  from ")
        Query.Append("                      Trxn_CEDtl ")
        Query.Append("                  where ")
        Query.Append("                      ItemNo = @ItemNo ")
        Query.Append("              end ")
        Query.Append("              break ")
        Query.Append("          end ")
        Query.Append("      end ")
        Query.Append("close @CRSMaterial ")
        Query.Append("DEALLOCATE @CRSMaterial ")
        'query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    Dim firstRow As Boolean = True
                    Do
                        While DR.Read()
                            Dim thisRow = DR("ItemNo") & "©" & DR("Particular") & "©" & CDbl(DR("LastQty")) & "©" & DR("UOM") & "©" & Remarks
                            If firstRow Then
                                ItemSrs = thisRow
                                firstRow = False
                            Else
                                ItemSrs &= "®" & thisRow
                            End If
                        End While
                    Loop While DR.NextResult()
                End Using
            End Using
        End Using
        'read record

        Return ItemSrs

    End Function
    Function bind06PRDtlSCM(Particular, Qty, Remarks)

        'variable
        Dim ItemSrs = ""
        'variable

        'query
        Dim Query As New StringBuilder
        Query.Append("DECLARE @Particular nvarchar(max) = '" & Particular.ToString.Replace("'", "") & "' ")
        Query.Append("DECLARE @Batch nvarchar(60) = '" & lbl01Batch.Text & "' ")
        Query.Append("DECLARE @ItemNo nvarchar(60) ")
        Query.Append("DECLARE @CEQty decimal(21, 2) ")
        Query.Append("DECLARE @Qty decimal(21, 2) = " & CDbl(Qty) & " ")
        Query.Append("DECLARE @RunningTotal decimal(21, 2) = 0 ")
        Query.Append("DECLARE @LastQty decimal(21, 2) = 0 ")
        Query.Append("DECLARE @CRSMaterial cursor ")
        Query.Append("  SET @CRSMaterial = CURSOR STATIC FOR ")
        Query.Append("      select  ")
        Query.Append("          ItemNo ")
        Query.Append("          ,Qty ")
        Query.Append("      from ")
        Query.Append("          Trxn_CEDtl ")
        Query.Append("      where ")
        Query.Append("          CECode = @CECode ")
        Query.Append("          and REPLACE(Particular, '''','') = @Particular ")
        Query.Append("      order by ")
        Query.Append("          SeqNo ")
        Query.Append("  OPEN @CRSMaterial ")
        Query.Append("      while 1 = 1 ")
        Query.Append("      begin ")
        Query.Append("          fetch @CRSMaterial into ")
        Query.Append("              @ItemNo ")
        Query.Append("              ,@CEQty ")
        Query.Append("          if @@FETCH_STATUS <> 0 ")
        Query.Append("              break ")
        Query.Append("          set @RunningTotal = @RunningTotal + @CEQty ")
        Query.Append("          set @LastQty = @CEQty ")
        Query.Append("          if @RunningTotal <= @Qty ")
        Query.Append("          begin ")
        Query.Append("              select ")
        Query.Append("                  Particular ")
        Query.Append("                  ,ItemNo ")
        Query.Append("                  ,Qty ")
        Query.Append("                  ,(select abbr from sys_um where u_code = Trxn_CEDtl.UMCode) [UOM] ")
        Query.Append("                  ,@LastQty [LastQty] ")
        Query.Append("               from ")
        Query.Append("                  Trxn_CEDtl ")
        Query.Append("               where ")
        Query.Append("                  ItemNo = @ItemNo ")
        Query.Append("          end ")
        Query.Append("          if @RunningTotal >= @Qty ")
        Query.Append("          begin ")
        Query.Append("              if @RunningTotal > @Qty ")
        Query.Append("              begin ")
        Query.Append("                  set @LastQty = @LastQty - (@RunningTotal - @Qty) ")
        Query.Append("                  select ")
        Query.Append("                      Particular ")
        Query.Append("                      ,ItemNo ")
        Query.Append("                      ,Qty ")
        Query.Append("                      ,(select abbr from sys_um where u_code = Trxn_CEDtl.UMCode) [UOM] ")
        Query.Append("                      ,@LastQty [LastQty] ")
        Query.Append("                  from ")
        Query.Append("                      Trxn_CEDtl ")
        Query.Append("                  where ")
        Query.Append("                      ItemNo = @ItemNo ")
        Query.Append("              end ")
        Query.Append("              break ")
        Query.Append("          end ")
        Query.Append("      end ")
        Query.Append("close @CRSMaterial ")
        Query.Append("DEALLOCATE @CRSMaterial ")
        'query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    Dim firstRow As Boolean = True
                    Do
                        While DR.Read()
                            Dim thisRow = DR("ItemNo") & "©" & DR("Particular") & "©" & CDbl(DR("LastQty")) & "©" & DR("UOM") & "©" & Remarks
                            If firstRow Then
                                ItemSrs = thisRow
                                firstRow = False
                            Else
                                ItemSrs &= "®" & thisRow
                            End If
                        End While
                    Loop While DR.NextResult()
                End Using
            End Using
        End Using
        'read record

        Return ItemSrs

    End Function
    Protected Sub lbtn0601PRDtlDel(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        If CType(sender, LinkButton).CommandArgument = 0 Then Exit Sub

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Delete", "")
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
            SqlCmd.CommandText = "Del_FRM_FRM000010_PRDtl"
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

            'fill
            bind0601PRDtl()
            'fill

            'alert
            Alert("success", "Particular successfully removed.")
            'alert

        End If
        'validate record

    End Sub
    Protected Sub lbtn0601PRDtlUpd(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        If CType(sender, LinkButton).CommandArgument = 0 Then Exit Sub

        'validate record

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Save", "")
        'create variable

        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'get item
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].seq_no [SeqNo] ")
            Query.Append("   ,[A].item [Item] ")
            Query.Append("   ,FORMAT([A].qty,'N2') [Qty] ")
            Query.Append("   ,[A].unit [Unit] ")
            Query.Append("   ,FORMAT([A].BdgtAmt,'N2') [BdgtAmt] ")
            Query.Append("   ,[A].status [Status]  ")
            Query.Append("   ,FORMAT([A].ForPO,'N2') [POQty] ")
            Query.Append("   ,FORMAT([A].for_sr + [A].FOrWT + [A].FOrIR,'N2') [SRQty] ")
            Query.Append("   ,FORMAT([A].ForCP,'N2') [CPQty] ")
            Query.Append("   ,FORMAT([A].unit_cost,'N2') [CPCost] ")
            Query.Append("   ,FORMAT([A].tot_cost,'N2') [CPTotal] ")
            Query.Append("   ,[A].remarks [Remarks]  ")
            Query.Append("from ")
            Query.Append("   ogm_pr_dtl [A] ")
            Query.Append("   left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("where ")
            Query.Append("   [B].f_code = '" & ltrlID.Text & "' ")
            Query.Append("   and [A].seq_no = '" & CType(sender, LinkButton).CommandArgument & "' ")
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
                        tbx06PRDtlUpdItem.Text = DR("Item")
                        tbx06PRDtlUpdQty.Value = DR("Qty")
                        tbx06PRDtlUpdUnit.Text = DR("Unit")
                        tbx06PRDtlUpdBdgtAmt.Value = DR("BdgtAmt")
                        ddl06PRDtlUpdStatus.SelectedValue = DR("Status")
                        tbx06PRDtlUpdPOQty.Value = DR("POQty")
                        tbx06PRDtlUpdSRQty.Value = DR("SRQty")
                        tbx06PRDtlUpdCPQty.Value = DR("CPQty")
                        tbx06PRDtlUpdCPCost.Value = DR("CPCost")
                        tbx06PRDtlUpdCPTotal.Value = DR("CPTotal")
                        tbx06PRDtlUpdRemarks.Text = DR("Remarks")

                        mdl06PRDtlUpd.Update()

                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using

            'modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl06PRDtlUpd').modal('show');</script>", False)
            'modal

        End If
        'validate record
    End Sub
    Protected Sub lbtn06PRDtlDel(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        If CType(sender, LinkButton).CommandArgument = 0 Then Exit Sub

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Delete", "")
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
            SqlCmd.CommandText = "Del_FRM_FRM000010_PRDtl"
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

            'fill
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
            'fill

            'alert
            Alert("success", "Particular successfully removed.")
            'alert

        End If
        'validate record

    End Sub
    Protected Sub lbtn06PRDtlUpd(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        If CType(sender, LinkButton).CommandArgument = 0 Then Exit Sub

        'validate record

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Save", "")
        'create variable

        If Msg <> "" Then
            Alert("error", Msg)
        Else

            'get item
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].seq_no [SeqNo] ")
            Query.Append("   ,[A].item [Item] ")
            Query.Append("   ,FORMAT([A].qty,'N2') [Qty] ")
            Query.Append("   ,[A].unit [Unit] ")
            Query.Append("   ,FORMAT([A].BdgtAmt,'N2') [BdgtAmt] ")
            Query.Append("   ,[A].status [Status]  ")
            Query.Append("   ,FORMAT([A].ForPO,'N2') [POQty] ")
            Query.Append("   ,FORMAT([A].for_sr + [A].FOrWT + [A].FOrIR,'N2') [SRQty] ")
            Query.Append("   ,FORMAT([A].ForCP,'N2') [CPQty] ")
            Query.Append("   ,FORMAT([A].unit_cost,'N2') [CPCost] ")
            Query.Append("   ,FORMAT([A].tot_cost,'N2') [CPTotal] ")
            Query.Append("   ,[A].remarks [Remarks]  ")
            Query.Append("from ")
            Query.Append("   ogm_pr_dtl [A] ")
            Query.Append("   left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
            Query.Append("where ")
            Query.Append("   [B].f_code = '" & ltrlID.Text & "' ")
            Query.Append("   and [A].seq_no = '" & CType(sender, LinkButton).CommandArgument & "' ")
            'get item

            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()

                        If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                            tbx06PRDtlUpdItem.Attributes("readonly") = "readonly"
                            tbx06PRDtlUpdQty.Attributes("readonly") = "readonly"
                            tbx06PRDtlUpdUnit.Attributes("readonly") = "readonly"
                        Else
                            tbx06PRDtlUpdItem.Attributes.Remove("readonly")
                            tbx06PRDtlUpdQty.Attributes.Remove("readonly")
                            tbx06PRDtlUpdUnit.Attributes.Remove("readonly")
                        End If

                        ltrlDtlMode.Text = "UPD"
                        ltrlSeqNo.Text = DR("SeqNo")
                        tbx06PRDtlUpdItem.Text = DR("Item")
                        tbx06PRDtlUpdQty.Value = DR("Qty")
                        tbx06PRDtlUpdUnit.Text = DR("Unit")
                        tbx06PRDtlUpdBdgtAmt.Value = DR("BdgtAmt")
                        ddl06PRDtlUpdStatus.SelectedValue = DR("Status")
                        tbx06PRDtlUpdPOQty.Value = DR("POQty")
                        tbx06PRDtlUpdSRQty.Value = DR("SRQty")
                        tbx06PRDtlUpdCPQty.Value = DR("CPQty")
                        tbx06PRDtlUpdCPCost.Value = DR("CPCost")
                        tbx06PRDtlUpdCPTotal.Value = DR("CPTotal")
                        tbx06PRDtlUpdRemarks.Text = DR("Remarks")

                        mdl06PRDtlUpd.Update()

                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using

            'modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl06PRDtlUpd').modal('show');</script>", False)
            'modal

        End If
        'validate record
    End Sub
    Protected Sub lbtn06PRDtlTag(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        If CType(sender, LinkButton).CommandArgument = 0 Then Exit Sub

        'validate record

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Save", "")
        'create variable

        If Msg <> "" Then
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>fn02PRDtlTag('" & ltrlID.Text & "','" & CType(sender, LinkButton).CommandName & "');</script>", False)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>fn01PRDtlTag('" & ltrlID.Text & "','" & CType(sender, LinkButton).CommandName & "');</script>", False)
        End If
        'validate record

    End Sub
    Protected Sub lbtn06Add(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Add", "")
        'create variable

        'create variable
        Dim ItemSrs = ""

        'create variable
        Dim row As GridViewRow = CType(sender.NamingContainer, GridViewRow)
        Dim rowIndex As Integer = row.RowIndex

        Dim lbl06OSMItemNo As Label = gv06OSMMaterial.Rows(rowIndex).FindControl("lbl06OSMItemNo")
        Dim lbl06OSMParticular As Label = gv06OSMMaterial.Rows(rowIndex).FindControl("lbl06OSMParticular")
        Dim lbl06OSMQty1 As Label = gv06OSMMaterial.Rows(rowIndex).FindControl("lbl06OSMQty1")
        Dim lbl06OSMUnit As Label = gv06OSMMaterial.Rows(rowIndex).FindControl("lbl06OSMUnit")
        Dim tbx06OSMRemarks As HtmlInputText = gv06OSMMaterial.Rows(rowIndex).FindControl("tbx06OSMRemarks")

        If CDbl(lbl06OSMQty1.Text) > 0 Then
            ItemSrs = lbl06OSMItemNo.Text & "©" & lbl06OSMParticular.Text & "©" & 0.00 & "©" & lbl06OSMUnit.Text & "©" & tbx06OSMRemarks.Value
        End If

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_OSM"
        SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
        SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", ItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
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
        bind06OSMMaterial(hf02Estimate.Value, hf01Subdivision.Value)
        'display item

        'update panel 
        mdl06PRDtlAddOSM.Update()
        'update panel

        'display item
        bind06PRDtl()
        'display item

    End Sub
    Protected Sub btnBind_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'fill
        If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
            bind06PRDtl()
        Else
            bind0601PRDtl()
        End If
        'fill

    End Sub
    Private Sub lbtn06PRDtlUpdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtn06PRDtlUpdOk.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "Upd" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate("06PRDtl", "Save", "")
        'create variable

        'validate record
        If Msg <> "" Then
            Alert("error", Msg)
        ElseIf tbx06PRDtlUpdItem.Text = "" Then
            Alert("error", "Some field(s) are missing!")
        ElseIf CDbl(tbx06PRDtlUpdQty.Value) <= 0 Then
            Alert("error", "Some field(s) are missing!")
        ElseIf tbx06PRDtlUpdUnit.Text = "" Then
            Alert("error", "Some field(s) are missing!")
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_FRM_FRM000010_PRDtl"
            SqlCmd.Parameters.AddWithValue("@pFormCode", ltrlFormCode.Text)
            SqlCmd.Parameters.AddWithValue("@pID", ltrlID.Text)
            SqlCmd.Parameters.AddWithValue("@pSeqNo", ltrlSeqNo.Text)
            SqlCmd.Parameters.AddWithValue("@pItem", tbx06PRDtlUpdItem.Text)
            SqlCmd.Parameters.AddWithValue("@pQty", CDbl(tbx06PRDtlUpdQty.Value))
            SqlCmd.Parameters.AddWithValue("@pUnit", tbx06PRDtlUpdUnit.Text)
            SqlCmd.Parameters.AddWithValue("@pBdgtAmt", CDbl(tbx06PRDtlUpdBdgtAmt.Value))
            SqlCmd.Parameters.AddWithValue("@pStatus", ddl06PRDtlUpdStatus.SelectedValue)
            SqlCmd.Parameters.AddWithValue("@pForPO", CDbl(tbx06PRDtlUpdPOQty.Value))
            SqlCmd.Parameters.AddWithValue("@pForSR", CDbl(tbx06PRDtlUpdSRQty.Value))
            SqlCmd.Parameters.AddWithValue("@pForCP", CDbl(tbx06PRDtlUpdCPQty.Value))
            SqlCmd.Parameters.AddWithValue("@pCost", CDbl(tbx06PRDtlUpdCPCost.Value))
            SqlCmd.Parameters.AddWithValue("@pTotal", CDbl(tbx06PRDtlUpdCPTotal.Value))
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx06PRDtlUpdRemarks.Text)
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
            If lbl01ProjectCat.Text = "House Construction" Or lbl01ProjectCat.Text = "House Construction - CCI" Then
                bind06PRDtl()
            Else
                bind0601PRDtl()
            End If
            'display item

            'update panel
            upnl06PRDtl.Update()
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
                Alert("error", "Some field(s) are missing!")
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
            tbx04NoDays.Value = "1.00"
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
        Query.Append("   select ")
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
        tbx04NoDays.Value = "1.00"
        pnl04Template.Visible = False
        ddl04Template.SelectedValue = ""
        'clear record

        If ddl04AddFrom.SelectedValue = "Manual" Then
            pnl04Type.Visible = True
            ddl04Type.SelectedValue = ""
            pnl04AssignTo.Visible = True
            ddl04Approver.SelectedValue = ""
            pnl04NoDays.Visible = True
            tbx04NoDays.Value = "1.00"
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
            Alert("error", "Some field(s) are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Manual" And ddl04Type.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Manual" And ddl04Approver.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Manual" And CDbl(tbx04NoDays.Value) <= 0 Then
            Alert("error", "Some field(s) are missing!")
        ElseIf ddl04AddFrom.SelectedValue = "Template" And ddl04Template.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
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
                tbx04NoDays.Value = "1.00"
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
        tbx05Note.Value = ""
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
        If tbx05Note.Value = "" Then
            Alert("error", "Some field(s) are missing!")
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
            SqlCmd.Parameters.AddWithValue("@pRemarks", tbx05Note.Value)
            SqlCmd.Parameters.AddWithValue("@pMention", hdnMention.Value)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'clear record
            tbx05Note.Value = ""
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