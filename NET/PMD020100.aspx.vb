Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports Azure
Imports Azure.Core
Imports System.Data.OleDb
Imports System.Data
Imports System.Web.UI.HtmlControl
Imports OfficeOpenXml
Imports Newtonsoft.Json
Imports System.Drawing.Drawing2D
Imports CrystalDecisions.Web
Public Class MyDataModel
    Public Property Subd As String
    Public Property Phase As String
    Public Property Block As String
    Public Property Lot As String
    Public Property Code As String
    Public Property Name As String
    Public Property Present As Nullable(Of Decimal)
    Public Property Previous As Nullable(Of Decimal)
    Public Property KwhUsed As Nullable(Of Decimal)
    Public Property FactorRate As Nullable(Of Decimal)
    Public Property Amount As Nullable(Of Decimal)
    Public Property CurrentBill As Nullable(Of Decimal)
    Public Property Arrears As Nullable(Of Decimal)
    Public Property Others As Nullable(Of Decimal)
    Public Property Total As Nullable(Of Decimal)

End Class
Public Class PMD020100

    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String

    'cookies

    'connection
    Dim DataSource As String = "IISV2"
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim FormCode As String = "PMD020100"
    'connection

    Private Shared DataSource1 As String = "IISV2"
    Private Shared catalog1 As String = "cldc_live_acc"
    Private Shared UserID1 As String = "ciisv2"
    Private Shared Password1 As String = "Cii5s"


    Protected Property FormDataSet As DataSet


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
        Master.setActiveMenu("APP", "PMD020100")
        'active account / menu

        'create variable
        Dim Msg As String = Access(CIIS_EmpCode, FormCode, "DTL")
        'create variable

        'Record
        ltrlFormCode.Text = "PMD020100"
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

            bind01Overview()
            bindForm()
            bindconnectioncode()
            bind02Files()
            bind05Notes()
            'display record

        End If
        'load page

    End Sub

    Protected Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If lblID.Text = "-" Then
            DisableBtn01()
        Else
            EnableBtn01()

        End If
    End Sub

    ' WebMethod for updating electric bill
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function UpdateElectricBill(pBillCode As String, pSRS As String, pAuditUser As String) As Object
        Dim result As New Dictionary(Of String, String)()

        Try
            Using conn As New SqlConnection("Data Source=" & DataSource1 & "; Initial Catalog=" & catalog1 & "; User ID=" & UserID1 & "; Password=" & Password1)
                Using cmd As New SqlCommand("calmardblive.dbo.JCF_UpdElecBillDtl", conn)
                    cmd.CommandType = CommandType.StoredProcedure

                    ' Add Parameters
                    cmd.Parameters.AddWithValue("@pBillCode", pBillCode)
                    cmd.Parameters.AddWithValue("@pSRS", pSRS)
                    cmd.Parameters.AddWithValue("@pAuditUser", pAuditUser)

                    conn.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    ' Return JSON response
                    If rowsAffected > 0 Then
                        result("status") = "success"
                        result("rowsAffected") = rowsAffected.ToString()
                    Else
                        result("status") = "no rows affected"
                    End If
                End Using
            End Using
        Catch ex As Exception
            result("error") = ex.Message
        End Try

        Return result

    End Function


    <WebMethod()>
    Public Shared Function UploadAndReadExcel(ByVal billCode As String, ByVal fileName As String, ByVal fileData As String) As Object
        Try
            ' Convert Base64 to Byte Array
            Dim decodedBytes As Byte() = Convert.FromBase64String(fileData)

            ' Save the uploaded file in a temporary folder
            Dim tempFolder As String = HttpContext.Current.Server.MapPath("~/Uploads/")
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
                Dim Code As String = If(dt.Columns.Contains("No."), row("No.").ToString(), "")
                dataList.Add(New MyDataModel With {
                .Subd = row("Subd").ToString(),
                .Phase = row("Phase").ToString(),
                .Block = row("Block").ToString(),
                .Lot = row("Lot").ToString(),
                .Code = Code,
                .Name = row("Name").ToString(),
                .Present = Convert.ToDecimal(row("Present")),
                .Previous = Convert.ToDecimal(row("Previous")),
                .KwhUsed = Convert.ToDecimal(row("Kwh Used")),
                .FactorRate = Convert.ToDecimal(row("Factor Rate")),
                .Amount = Convert.ToDecimal(row("Amount")),
                .CurrentBill = row("Current Bill").ToString(),
                .Arrears = row("Arrears").ToString().Trim(),
                .Others = row("Others").ToString().Trim(),
                .Total = Convert.ToDecimal(row("Total"))
            })
            Next


            ' Return JSON-safe object
            Return New With {.success = True, .data = dataList}

        Catch ex As Exception
            ' Return full error message
            Return New With {.success = False, .message = "Error in UploadAndReadExcel: " & ex.Message}
        End Try
    End Function


    <WebMethod()>
    Public Shared Function SaveToDatabase(billCode As String, data As Object, AuditUser As String) As Object
        Dim response As New Dictionary(Of String, Object)
        Dim serializer As New JavaScriptSerializer()

        Try
            ' 🔹 Step 1: Convert JSON data into the required format for SQL

            Dim pSRS As String = ""
            For Each row As Dictionary(Of String, Object) In data

                Dim rowString As String = $"{row("Code")}©{row("Present")}©{row("Previous")}©{row("KwhUsed")}©{row("FactorRate")}©{row("Amount")}©{row("Arrears")}©{row("Others")}©{row("Total")}"

                If pSRS = "" Then
                    pSRS = rowString
                Else
                    pSRS &= "®" & rowString  ' 🔹 Append with `®` separator
                End If
            Next



            ' 🔹 Step 2: Call the stored procedure
            Using conn As New SqlConnection("Data Source=" & DataSource1 & "; Initial Catalog=" & catalog1 & "; User ID=" & UserID1 & "; Password=" & Password1)
                conn.Open()
                Dim cmd As New SqlCommand("calmardblive.dbo.JCF_UpdElecBillDtl", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@pBillCode", billCode)
                cmd.Parameters.AddWithValue("@pSRS", pSRS)
                cmd.Parameters.AddWithValue("@pAuditUser", AuditUser)

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

    Public Shared Function LoadTableData(BillCode As String) As String
        Dim query As New StringBuilder()
        query.AppendLine("SELECT")
        query.AppendLine("    [A].Project AS [Project],")
        query.AppendLine("    [B].ProjInit AS [Subd],")
        query.AppendLine("    [A].Phase AS [Phase],")
        query.AppendLine("    [A].Block AS [Block],")
        query.AppendLine("    [A].Lot AS [Lot],")
        query.AppendLine("    [C].Name AS [Name],")
        query.AppendLine("    [A].BillCode AS [BillCode],")
        query.AppendLine("    [A].Connected AS [Connected],")
        query.AppendLine("    [A].Status AS [Status],")
        query.AppendLine("    [A].DueDate AS [DueDate],")
        query.AppendLine("    [A].Description AS [Description],")
        query.AppendLine("    [A].CurrRead AS [CurrRead],")
        query.AppendLine("    [A].PrevRead AS [PrevRead],")
        query.AppendLine("    [A].KWHUsed AS [KWHUsed],")
        query.AppendLine("    [A].BillAmt AS [BillAmt],")
        query.AppendLine("    [A].LostAmt AS [LostAmt],")
        query.AppendLine("    [A].LostRate AS [LostRate],")
        query.AppendLine("    [A].TotBill AS [TotBill],")
        query.AppendLine("    [A].Arrears AS [Arrears],")
        query.AppendLine("    [A].NetBill AS [NetBill],")
        query.AppendLine("    [A].DatePaid AS [DatePaid],")
        query.AppendLine("    [A].AmtPaid AS [AmtPaid],")
        query.AppendLine("    [A].AuditUser AS [AuditUser],")
        query.AppendLine("    [A].AuditDate AS [AuditDate],")
        query.AppendLine("    [A].Code AS [Code],")
        query.AppendLine("    [A].OthAmt AS [OthAmt],")
        query.AppendLine("    [A].SerialNo AS [SerialNo],")
        query.AppendLine("    [A].DocNo AS [DocNo],")
        query.AppendLine("    [A].FactorRate AS [FactorRate]")
        query.AppendLine("FROM")
        query.AppendLine("    calmardblive.dbo.JCF_ElecBillDtl [A] ")
        query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.mstr_Projects [B] ON [A].Project = [B].ProjCode")
        query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.JCF_LotConnection [C] ON [A].Code = [C].Code")
        query.AppendLine("WHERE")
        query.AppendLine("   [A].BillCode = @BillCode")

        Dim htmlOutput As New StringBuilder()

        ' 🔹 Connect to Database and Execute Query
        Using conn As New SqlConnection("Data Source=" & DataSource1 & "; Initial Catalog=" & catalog1 & "; User ID=" & UserID1 & "; Password=" & Password1)
            conn.Open()
            Dim cmd As New SqlCommand(query.ToString(), conn)
            cmd.Parameters.AddWithValue("@BillCode", BillCode)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            ' 🔥 Build the table rows
            While reader.Read()
                htmlOutput.Append($"<tr data-id='{reader("Code")}' >
                               <td>{reader("Subd")}</td>
                               <td>{reader("Phase")}</td>
                               <td>{reader("Block")}</td>
                               <td>{reader("Lot")}</td>
                               <td>{reader("Code")}</td>
                               <td>{reader("Name")}</td>
                               <td>{reader("CurrRead")}</td>
                               <td>{reader("PrevRead")}</td>
                               <td>{reader("KWHUsed")}</td>
                               <td>{reader("FactorRate")}</td>
                               <td>{reader("BillAmt")}</td>
                               <td>{reader("TotBill")}</td>
                               <td>{reader("Arrears")}</td>
                               <td>{reader("OthAmt")}</td>
                               <td>{reader("NetBill")}</td>
                            </tr>")
            End While
            reader.Close()
        End Using

        ' 🔹 Return the generated HTML
        Return htmlOutput.ToString()
    End Function


    <WebMethod()>
    Public Shared Function GetUpdatedTable(BillCode As String) As Object
        Try
            ' 🔹 Get the latest table HTML
            Dim tableHtml As String = LoadTableData(BillCode)

            ' 🔹 Return success response with updated HTML
            Return New With {
            .success = True,
            .html = tableHtml
        }
        Catch ex As Exception
            Return New With {
            .success = False,
            .message = ex.Message
        }
        End Try
    End Function


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


    Function Access(EmpCode, FormCode, Action)

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Restriction"
        sqlCmd.Parameters.AddWithValue("@pUserId", EmpCode)
        sqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
        sqlCmd.Parameters.AddWithValue("@pRes", Action)
        Dim oConf As New SqlClient.SqlParameter("@oConf", SqlDbType.NVarChar, 1000)
        oConf.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oConf)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        Return oConf.Value.ToString
    End Function
    Function CheckPassword(UserPassword)
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Password"
        sqlCmd.Parameters.AddWithValue("@pEmpCode", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pPassword", UserPassword)
        Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
        oMsg.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oMsg)
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        Return oMsg.Value.ToString
    End Function



    Function Validate01(TblName, TblCode, Type)
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "calmardblive.dbo.JCF_ConfRecord"
        sqlCmd.Parameters.AddWithValue("@pTblName", "JCF_ElecBillHdr")
        sqlCmd.Parameters.AddWithValue("@pTblCode", ltrlID.Text)
        sqlCmd.Parameters.AddWithValue("@pTblVal", "")
        sqlCmd.Parameters.AddWithValue("@pType", Type)
        Dim oMessage As New SqlClient.SqlParameter("@oMessage", SqlDbType.NVarChar, 1000)
        oMessage.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oMessage)
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        Return oMessage.Value.ToString
    End Function

    Function Alert01(ByVal Alert_01 As String, ByVal Message_01 As String, AdditionalScript As String)
        Dim class_01 As String = IIf(Alert_01 = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & AdditionalScript & "Swal.fire({text: '" & Message_01 & "',icon: '" & Alert_01 & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_01 & "'}});</script>", False)
    End Function

    Function Alert02(ByVal Alert_02 As String, ByVal Message_02 As String, AdditionalScript2 As String)
        Dim class_01 As String = IIf(Alert_02 = "success", "btn btn-primary", "btn btn-danger")
        Dim script As String = "<script>" & AdditionalScript2 & "Swal.fire({" &
        "text: '" & Message_02 & "'," &
        "icon: '" & Alert_02 & "'," &
        "buttonsStyling: false," &
        "timer: 500," & ' Automatically close after 2 seconds
        "showConfirmButton: false" & ' Hide the confirm button
    "});</script>"
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", script, False)
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
            });
        }, 200);
    </script>", False)
    End Function



    Function EnableBtn()

        'overview
        'lbtn01Find.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Refresh.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-danger align-self-center m-1"
        lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
        lbtn01Unlock.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
        lbtn01Lock.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
        lbtn02add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        lbtn01Post.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Unpost.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Tools.CssClass = "btn btn-sm btn-icon btn-info align-self-center m-1"
        lbtn01Refresh.OnClientClick = "location.reload(); return false;"
        upnl01table.Update()

        lbtn02add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        editTableBtn.Attributes("class") = "btn btn-sm btn-icon btn-warning align-self-center m-1"
        editTableBtn.Disabled = False

        'overview




    End Function

    Function EnableBtn01()
        upnl05Notes.Update()
        upnl02Files.Update()
        lbtn05Add.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1"
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-success align-self-center m-1 "
    End Function

    Function DisableBtn()

        'overview
        'lbtn01Find.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1"
        lbtn01Add.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1 disabled"
        lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-white align-self-center m-1 disabled"
        lbtn01Refresh.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Unlock.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Lock.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn02add.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Post.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Unpost.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Refresh.OnClientClick = ""
        lbtn01Refresh.OnClientClick = "this.style.pointerEvents='none';"
        upnl01table.Update()
        lbtn02add.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        editTableBtn.Attributes("class") = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        editTableBtn.Disabled = True
        cbxlock.Checked = False
        cbxpost.Checked = False
        lbtn01Tools.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        'overview


    End Function

    Function DisableBtn01()

        'overview
        lbtn01Unlock.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Lock.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn02Upload.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Post.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Unpost.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn01Tools.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        lbtn05Add.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        upnl01table.Update()
        upnl05Notes.Update()
        upnl02Files.Update()
        lbtn02add.CssClass = "btn btn-sm btn-icon btn-secondary align-self-center m-1 disabled"
        editTableBtn.Attributes("class") = "btn btn-sm btn-secondary align-self-center m-1 disabled"
        'overview


    End Function


#End Region


#Region "Overview"

    Function bind01Overview()

        'hide fields
        pnl01Edit.Visible = False
        pnl01Dtl.Visible = True
        pnl01Add.Visible = False
        'hide fields



        'add record
        If ltrlMode.Text = "ADD" Then

            'hide and display buttons
            DisableBtn()

            lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-danger align-self-center m-1"
            lbtn01Delete.ToolTip = "Cancel record"
            lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
            lbtn01Edit.Text = "<i Class='las la-save fs-2'></i>"
            lbtn01Edit.ToolTip = "Save record"
            'hide and display buttons

            'display fields
            pnl01Edit.Visible = False
            pnl01Dtl.Visible = False
            pnl01Add.Visible = True
            'display fields

            'set value
            ddlAdd_Connection.Text = ""

            tbx02IssueDate.Text = ""
            tbx02DueDate.Text = ""
            cbx02CLS.Checked = False
            cbx02WithEWT.Checked = False
            tbx02WithEWT.Text = ""

            tbx02BillingPeriodFrom.Text = ""
            tbx02BillingPeriodTo.Text = ""
            tbx02PmtPosted.Text = ""

            lbl02TotalBill.Text = "0.00"
            lbl02Kwh.Text = "0.00"
            lbl02Factor.Text = "0.00"

        End If

        'update record
        If ltrlMode.Text = "UPD" Then

            'display fields
            pnl01Edit.Visible = True
            pnl01Dtl.Visible = False
            pnl01Add.Visible = False
            'display fields


            ' Build the SQL query
            Dim query As New StringBuilder()
            query.AppendLine("SELECT")
            query.AppendLine("    [A].BillCode AS [BillCode],")
            query.AppendLine("    [B].SINNo AS [ConnectionName],")
            query.AppendLine("    [A].IssueDate AS [IssueDate],")
            query.AppendLine("    [A].DueDate AS [DueDate],")
            query.AppendLine("    [A].FromDate AS [FromDate],")
            query.AppendLine("    [A].ToDate AS [ToDate],")
            query.AppendLine("    [A].PmtDate AS [PmtDate],")
            query.AppendLine("    [A].WithLost AS [WithLost],")
            query.AppendLine("    [A].WithEWT AS [WithEWT],")
            query.AppendLine("    [A].EWTAmt AS [EWTAmt],")
            query.AppendLine("    [A].BillAmt AS [BillAmt],")
            query.AppendLine("    [A].KWHUsed AS [KWHUsed],")
            query.AppendLine("    [A].FactorRate AS [FactorRate],")
            query.AppendLine("    [A].AuditUser AS [AuditUser],")
            query.AppendLine("    [A].AuditDate AS [AuditDate],")
            query.AppendLine("    [A].LockBy AS [LockBy],")
            query.AppendLine("    [A].LockDate AS [LockDate],")
            query.AppendLine("    [A].Lock AS [Lock],")
            query.AppendLine("    [A].PostBy AS [PostBy],")
            query.AppendLine("    [A].PostDate AS [PostDate],")
            query.AppendLine("    [A].Post AS [Post]")
            query.AppendLine("FROM")
            query.AppendLine("    calmardblive.dbo.JCF_ElecBillHdr [A]")
            query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.JCF_ElectricityConnection [B] ON [A].Connection = [B].Code")
            query.AppendLine("WHERE")
            query.AppendLine("    ([A].BillCode = @BillCode)")

            ' Execute the SQL command
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(query.ToString, ConStr)
                    ' Add parameter to prevent SQL injection
                    Cmd.Parameters.AddWithValue("@BillCode", ltrlID.Text)

                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader()


                    If DR.Read() Then
                        'Headers
                        lblTitle.Text = DR("ConnectionName").ToString()
                        lblID.Text = DR("BillCode").ToString()
                        Empcode.Value = DR("AuditUser").ToString()

                        'Retrieve values

                        lbl03Connection.Text = DR("ConnectionName").ToString()


                        lbl03DueDateFrom.Text = Convert.ToDateTime(DR("IssueDate")).ToShortDateString()
                        lbl03DueDateTo.Text = Convert.ToDateTime(DR("DueDate")).ToShortDateString()

                        cbx03CSL.Value = Convert.ToBoolean(DR("WithLost"))
                        cbx03WithEWT.Value = Convert.ToBoolean(DR("WithEWT"))
                        tbx03EWT.Text = DR("EWTAmt").ToString()


                        lbl03BillingPeriodFrom.Text = Convert.ToDateTime(DR("FromDate")).ToShortDateString()
                        lbl03BillingPeriodTo.Text = Convert.ToDateTime(DR("ToDate")).ToShortDateString()
                        lbl03PmtPosted.Text = If(IsDBNull(DR("PostDate")), "", Convert.ToDateTime(DR("PostDate")).ToShortDateString())

                        lbl03TotalBill.Text = DR("BillAmt").ToString()
                        Lalbl03Kwh.Text = DR("KWHUsed").ToString()
                        lbl03Factor.Text = DR("FactorRate").ToString()



                    End If

                    DR.Close()
                    ConStr.Close()
                End Using
            End Using



            DisableBtn()
            lbtn01Delete.CssClass = "btn btn-sm btn-icon btn-danger align-self-center m-1"
            lbtn01Delete.ToolTip = "Cancel record"
            lbtn01Edit.CssClass = "btn btn-sm btn-icon btn-warning align-self-center m-1"
            lbtn01Edit.Text = "<i class='las la-save fs-2'></i>"
            lbtn01Edit.ToolTip = "Save record"
            'hide and display buttons

            'display fields
            pnl01Edit.Visible = True
            pnl01Add.Visible = False
            pnl01Dtl.Visible = False
            'displa fields


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
            pnl01Edit.Visible = False
            pnl01Dtl.Visible = True
            pnl01Add.Visible = False
            'displa fields


            Dim lockValue As String = String.Empty
            Dim postValue As String = String.Empty

            ' Build the SQL query
            Dim query As New StringBuilder()
            query.AppendLine("SELECT")
            query.AppendLine("    [A].BillCode AS [BillCode],")
            query.AppendLine("    [B].SINNo AS [ConnectionName],")
            query.AppendLine("    [A].IssueDate AS [IssueDate],")
            query.AppendLine("    [A].DueDate AS [DueDate],")
            query.AppendLine("    [A].FromDate AS [FromDate],")
            query.AppendLine("    [A].ToDate AS [ToDate],")
            query.AppendLine("    [A].PmtDate AS [PmtDate],")
            query.AppendLine("    [A].WithLost AS [WithLost],")
            query.AppendLine("    [A].WithEWT AS [WithEWT],")
            query.AppendLine("    [A].EWTAmt AS [EWTAmt],")
            query.AppendLine("    [A].BillAmt AS [BillAmt],")
            query.AppendLine("    [A].KWHUsed AS [KWHUsed],")
            query.AppendLine("    [A].FactorRate AS [FactorRate],")
            query.AppendLine("    [A].AuditUser AS [AuditUser],")
            query.AppendLine("    [A].AuditDate AS [AuditDate],")
            query.AppendLine("    [A].LockBy AS [LockBy],")
            query.AppendLine("    [A].LockDate AS [LockDate],")
            query.AppendLine("    [A].Lock AS [Lock],")
            query.AppendLine("    [A].PostBy AS [PostBy],")
            query.AppendLine("    [A].PostDate AS [PostDate],")
            query.AppendLine("    [A].Post AS [Post]")
            query.AppendLine("FROM")
            query.AppendLine("    calmardblive.dbo.JCF_ElecBillHdr [A]")
            query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.JCF_ElectricityConnection [B] ON [A].Connection = [B].Code")
            query.AppendLine("WHERE")
            query.AppendLine("    ([A].BillCode = @BillCode)")

            ' Execute the SQL command
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(query.ToString, ConStr)
                    ' Add parameter to prevent SQL injection
                    Cmd.Parameters.AddWithValue("@BillCode", ltrlID.Text)

                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader()


                    If DR.Read() Then
                        'Headers
                        lblTitle.Text = DR("ConnectionName").ToString()
                        lblID.Text = DR("BillCode").ToString()
                        Empcode.Value = DR("AuditUser").ToString()
                        lbl01ID.Value = DR("BillCode").ToString()
                        'Retrieve values
                        lbl01Connection.Text = DR("ConnectionName").ToString()
                        lbl01TotalBill.Text = DR("BillAmt").ToString()

                        lbl01DueDateFrom.Text = Convert.ToDateTime(DR("IssueDate")).ToShortDateString()
                        lbl01DueDateTo.Text = Convert.ToDateTime(DR("DueDate")).ToShortDateString()

                        cbxCSL.Value = Convert.ToBoolean(DR("WithLost"))
                        cbxWithEWT.Value = Convert.ToBoolean(DR("WithEWT"))
                        tbxEWT.Text = DR("EWTAmt").ToString()
                        Lalbl01Kwh.Text = DR("KWHUsed").ToString()

                        lbl01BillingPeriodFrom.Text = Convert.ToDateTime(DR("FromDate")).ToShortDateString()
                        lbl01BillingPeriodTo.Text = Convert.ToDateTime(DR("ToDate")).ToShortDateString()
                        lbl01PmtPosted.Text = Convert.ToDateTime(DR("PmtDate")).ToShortDateString()
                        lbl01Factor.Text = DR("FactorRate").ToString()


                        ' Get the Lock value
                        lockValue = DR("Lock").ToString()
                        postValue = DR("Post").ToString()
                    End If

                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
            If lockValue = "1" Then
                cbxlock.Checked = True

            ElseIf lockValue = "0" Then
                cbxlock.Checked = False

            End If
            If postValue = "1" Then
                cbxpost.Checked = True

            ElseIf postValue = "0" Then
                cbxpost.Checked = False

            End If


            'display data
            upnl01Overview.Update()
            upnlTitle.Update()
            upnl01table.Update()
            'display data

        End If
        'view record

        'display record
        upnl01Overview.Update()
        upnlTitle.Update()
        upnl01table.Update()
        'display record

    End Function

    Function bindconnectioncode()
        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select connection' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].Code [Code] ")
        Query.Append("   ,[A].SINNo [Name] ")
        Query.Append("   ,[A].SINNo [Order] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.JCF_ElectricityConnection [A] ")
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
        ddlAdd_Connection.DataSource = DT
        ddlAdd_Connection.DataValueField = "Code"
        ddlAdd_Connection.DataTextField = "Name"
        ddlAdd_Connection.DataBind()

        'fill data
    End Function


    Function bindForm()


        System.Threading.Thread.Sleep(1000)
        ' Build the SQL query

        Dim query As New StringBuilder()
        query.AppendLine("SELECT")
        query.AppendLine("    [A].Project AS [Project],")
        query.AppendLine("    [B].ProjInit AS [Subd],")
        query.AppendLine("    [A].Phase AS [Phase],")
        query.AppendLine("    [A].Block AS [Block],")
        query.AppendLine("    [A].Lot AS [Lot],")
        query.AppendLine("    [C].Name AS [Name],")
        query.AppendLine("    [A].BillCode AS [BillCode],")
        query.AppendLine("    [A].Connected AS [Connected],")
        query.AppendLine("    [A].Status AS [Status],")
        query.AppendLine("    [A].DueDate AS [DueDate],")
        query.AppendLine("    [A].Description AS [Description],")
        query.AppendLine("    [A].CurrRead AS [CurrRead],")
        query.AppendLine("    [A].PrevRead AS [PrevRead],")
        query.AppendLine("    [A].KWHUsed AS [KWHUsed],")
        query.AppendLine("    [A].BillAmt AS [BillAmt],")
        query.AppendLine("    [A].LostAmt AS [LostAmt],")
        query.AppendLine("    [A].LostRate AS [LostRate],")
        query.AppendLine("    [A].TotBill AS [TotBill],")
        query.AppendLine("    [A].Arrears AS [Arrears],")
        query.AppendLine("    [A].NetBill AS [NetBill],")
        query.AppendLine("    [A].DatePaid AS [DatePaid],")
        query.AppendLine("    [A].AmtPaid AS [AmtPaid],")
        query.AppendLine("    [A].AuditUser AS [AuditUser],")
        query.AppendLine("    [A].AuditDate AS [AuditDate],")
        query.AppendLine("    [A].Code AS [Code],")
        query.AppendLine("    [A].OthAmt AS [OthAmt],")
        query.AppendLine("    [A].SerialNo AS [SerialNo],")
        query.AppendLine("    [A].DocNo AS [DocNo],")
        query.AppendLine("    [A].FactorRate AS [FactorRate]")
        query.AppendLine("FROM")
        query.AppendLine("    calmardblive.dbo.JCF_ElecBillDtl [A] ")
        query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.mstr_Projects [B] ON [A].Project = [B].ProjCode")
        query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.JCF_LotConnection [C] ON [A].Code = [C].Code")
        query.AppendLine("WHERE")
        query.AppendLine("   [A].BillCode = @BillCode")



        ' Create a DataTable to store the results
        Dim FormDataTable As New DataTable()
        FormDataTable.Columns.Add(New DataColumn("Subd"))
        FormDataTable.Columns.Add(New DataColumn("Phase"))
        FormDataTable.Columns.Add(New DataColumn("Block"))
        FormDataTable.Columns.Add(New DataColumn("Lot"))
        FormDataTable.Columns.Add(New DataColumn("Code"))
        FormDataTable.Columns.Add(New DataColumn("Name"))
        FormDataTable.Columns.Add(New DataColumn("CurrRead"))
        FormDataTable.Columns.Add(New DataColumn("PrevRead"))
        FormDataTable.Columns.Add(New DataColumn("KWHUsed"))
        FormDataTable.Columns.Add(New DataColumn("FactorRate"))
        FormDataTable.Columns.Add(New DataColumn("BillAmt"))
        FormDataTable.Columns.Add(New DataColumn("TotBill"))
        FormDataTable.Columns.Add(New DataColumn("Arrears"))
        FormDataTable.Columns.Add(New DataColumn("OthAmt"))
        FormDataTable.Columns.Add(New DataColumn("NetBill"))


        Dim FormDatafooter As New DataTable()


        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            ConStr.Open()
            Using Cmd As New SqlCommand(query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@BillCode", ltrlID.Text)
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    FormDataTable.Rows.Add(
                            If(DR.IsDBNull(DR.GetOrdinal("Subd")), "", DR("Subd").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Phase")), "", DR("Phase").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Block")), "", DR("Block").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Lot")), "", DR("Lot").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Code")), "", DR("Code").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Name")), "", DR("Name").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("CurrRead")), "", DR("CurrRead").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("PrevRead")), "", DR("PrevRead").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("KWHUsed")), "", DR("KWHUsed").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("FactorRate")), "", DR("FactorRate").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("BillAmt")), "", DR("BillAmt").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("TotBill")), "", DR("TotBill").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Arrears")), "", DR("Arrears").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("OthAmt")), "", DR("OthAmt").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("NetBill")), "", DR("NetBill").ToString()))



                    Dim sumCurrRead As Decimal = 0
                    Dim sumPrevRead As Decimal = 0
                    Dim sumKWHUsed As Decimal = 0
                    Dim sumFactorRate As Decimal = 0
                    Dim sumBillAmt As Decimal = 0
                    Dim sumTotBill As Decimal = 0
                    Dim sumArrears As Decimal = 0
                    Dim sumOthAmt As Decimal = 0
                    Dim sumNetBill As Decimal = 0


                    For Each row As DataRow In FormDataTable.Rows
                        sumCurrRead += If(IsNumeric(row("CurrRead")), Convert.ToDecimal(row("CurrRead")), 0)
                        sumPrevRead += If(IsNumeric(row("PrevRead")), Convert.ToDecimal(row("PrevRead")), 0)
                        sumKWHUsed += If(IsNumeric(row("KWHUsed")), Convert.ToDecimal(row("KWHUsed")), 0)
                        sumFactorRate += If(IsNumeric(row("FactorRate")), Convert.ToDecimal(row("FactorRate")), 0)
                        sumBillAmt += If(IsNumeric(row("BillAmt")), Convert.ToDecimal(row("BillAmt")), 0)
                        sumTotBill += If(IsNumeric(row("TotBill")), Convert.ToDecimal(row("TotBill")), 0)
                        sumArrears += If(IsNumeric(row("Arrears")), Convert.ToDecimal(row("Arrears")), 0)
                        sumOthAmt += If(IsNumeric(row("OthAmt")), Convert.ToDecimal(row("OthAmt")), 0)
                        sumNetBill += If(IsNumeric(row("NetBill")), Convert.ToDecimal(row("NetBill")), 0)
                    Next

                    ' Format the values with thousands separator for display
                    Dim formattedCurrRead As String = Math.Max(0, sumCurrRead).ToString("N2")
                    Dim formattedPrevRead As String = Math.Max(0, sumPrevRead).ToString("N2")
                    Dim formattedKWHUsed As String = Math.Max(0, sumKWHUsed).ToString("N2")
                    Dim formattedFactorRate As String = Math.Max(0, sumFactorRate).ToString("N2")
                    Dim formattedBillAmt As String = Math.Max(0, sumBillAmt).ToString("N2")
                    Dim formattedTotBill As String = Math.Max(0, sumTotBill).ToString("N2")
                    Dim formattedArrears As String = Math.Max(0, sumArrears).ToString("N2")
                    Dim formattedOthAmt As String = Math.Max(0, sumOthAmt).ToString("N2")
                    Dim formattedNetBill As String = Math.Max(0, sumNetBill).ToString("N2")

                    Dim sumEWTBill As String

                    If cbxWithEWT.Checked = True And sumTotBill > 0 Then
                        sumEWTBill = Format(CDbl(tbxEWT.Text), "N2")
                    Else
                        tbxEWT.Text = Format(0, "N2")

                        sumEWTBill = Format(0, "N2")
                    End If



                    Dim Totalnetbill As String = (formattedTotBill - sumEWTBill).ToString("N2")

                    ViewState("sumCurrRead") = formattedCurrRead
                    ViewState("sumPrevRead") = formattedPrevRead
                    ViewState("sumKWHUsed") = formattedKWHUsed
                    ViewState("sumFactorRate") = formattedFactorRate
                    ViewState("sumBillAmt") = formattedBillAmt
                    ViewState("sumTotBill") = formattedTotBill
                    ViewState("sumArrears") = sumArrears
                    ViewState("sumOthAmt") = formattedOthAmt
                    ViewState("sumNetBill") = formattedNetBill
                    ViewState("sumEWTBill") = sumEWTBill
                    ViewState("Totalnetbill") = Totalnetbill

                    'Add totals to the footer DataTable
                    'FormDatafooter.Rows.Add(sumCurrRead, sumPrevRead, sumKWHUsed, sumFactorRate, sumBillAmt, sumLostAmt, sumLostRate, sumTotBill, sumArrears, sumOthAmt, sumNetBill)

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'read record
        FormDataSet = New DataSet()
        FormDataSet.Tables.Add(FormDataTable)
        'FormDataSet.Tables.Add(FormDatafooter)

        'update record
        upnl01table.Update()
        'update record


    End Function


    'Protected Sub lbtn01Find_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Find.Click

    '    ''validate
    '    If ltrlMode.Text = "ADD" Then Exit Sub
    '    If ltrlMode.Text = "UPD" Then Exit Sub
    '    ''validate

    '    'display modal
    '    bind01Find()
    '    'mdl01Find.Update()
    '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01Find').modal('show');</script>", False)
    '    'display modal

    'End Sub

    Protected Sub lbtn01Refresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Refresh.Click

        ''validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        ''validate

        'display record
        Debug.WriteLine("refressh")
        bind01Overview()

    End Sub


    Protected Sub lbtn01Add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Add.Click

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'display add
        ltrlMode.Text = "ADD"

        lblTitle.Text = "-"
        lblID.Text = "-"
        bind01Overview()
        Dim emptyTable As New DataTable()
        emptyTable.Columns.Add("Column1")
        emptyTable.Columns.Add("Column2")
        emptyTable.Columns.Add("Column3")

        ' Set FormDataSet to the empty table
        Me.FormDataSet = New DataSet()
        Me.FormDataSet.Tables.Add(emptyTable)

        Debug.WriteLine(ltrlMode.Text)

    End Sub


    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "none", "$('#ContentPlaceHolder1_mdl02DialogBox').modal('hide');", True)

        bind01Overview()
        bindForm()
        bindconnectioncode()
        bind02Files()


    End Sub

    Protected Sub lbtn02add_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn02add.Click


        'Update
        bind01Overview()
        bindForm()
        bindconnectioncode()
        'Update

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Post")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")

            Exit Sub
        End If
        'validate



    End Sub



    Protected Sub editTableBtn_Click(ByVal sender As Object, ByVal e As EventArgs)

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'Access
        Dim Msg = Access(CIIS_EmpCode, FormCode, "Save")
        If Msg = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Save")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'Record
        ltrlMode.Text = "DTL"
        'Record

        System.Threading.Thread.Sleep(1000)
        ' Build the SQL query

        Dim query As New StringBuilder()
        query.AppendLine("SELECT")
        query.AppendLine("    [A].Project AS [Project],")
        query.AppendLine("    [B].ProjInit AS [Subd],")
        query.AppendLine("    [A].Phase AS [Phase],")
        query.AppendLine("    [A].Block AS [Block],")
        query.AppendLine("    [A].Lot AS [Lot],")
        query.AppendLine("    [C].Name AS [Name],")
        query.AppendLine("    [A].BillCode AS [BillCode],")
        query.AppendLine("    [A].Connected AS [Connected],")
        query.AppendLine("    [A].Status AS [Status],")
        query.AppendLine("    [A].DueDate AS [DueDate],")
        query.AppendLine("    [A].Description AS [Description],")
        query.AppendLine("    [A].CurrRead AS [CurrRead],")
        query.AppendLine("    [A].PrevRead AS [PrevRead],")
        query.AppendLine("    [A].KWHUsed AS [KWHUsed],")
        query.AppendLine("    [A].BillAmt AS [BillAmt],")
        query.AppendLine("    [A].LostAmt AS [LostAmt],")
        query.AppendLine("    [A].LostRate AS [LostRate],")
        query.AppendLine("    [A].TotBill AS [TotBill],")
        query.AppendLine("    [A].Arrears AS [Arrears],")
        query.AppendLine("    [A].NetBill AS [NetBill],")
        query.AppendLine("    [A].DatePaid AS [DatePaid],")
        query.AppendLine("    [A].AmtPaid AS [AmtPaid],")
        query.AppendLine("    [A].AuditUser AS [AuditUser],")
        query.AppendLine("    [A].AuditDate AS [AuditDate],")
        query.AppendLine("    [A].Code AS [Code],")
        query.AppendLine("    [A].OthAmt AS [OthAmt],")
        query.AppendLine("    [A].SerialNo AS [SerialNo],")
        query.AppendLine("    [A].DocNo AS [DocNo],")
        query.AppendLine("    [A].FactorRate AS [FactorRate]")
        query.AppendLine("FROM")
        query.AppendLine("    calmardblive.dbo.JCF_ElecBillDtl [A] ")
        query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.mstr_Projects [B] ON [A].Project = [B].ProjCode")
        query.AppendLine("    LEFT OUTER JOIN calmardblive.dbo.JCF_LotConnection [C] ON [A].Code = [C].Code")
        query.AppendLine("WHERE")
        query.AppendLine("   [A].BillCode = @BillCode")



        ' Create a DataTable to store the results
        Dim FormDataTable As New DataTable()
        FormDataTable.Columns.Add(New DataColumn("Subd"))
        FormDataTable.Columns.Add(New DataColumn("Phase"))
        FormDataTable.Columns.Add(New DataColumn("Block"))
        FormDataTable.Columns.Add(New DataColumn("Lot"))
        FormDataTable.Columns.Add(New DataColumn("Code"))
        FormDataTable.Columns.Add(New DataColumn("Name"))
        FormDataTable.Columns.Add(New DataColumn("CurrRead"))
        FormDataTable.Columns.Add(New DataColumn("PrevRead"))
        FormDataTable.Columns.Add(New DataColumn("KWHUsed"))
        FormDataTable.Columns.Add(New DataColumn("FactorRate"))
        FormDataTable.Columns.Add(New DataColumn("BillAmt"))
        FormDataTable.Columns.Add(New DataColumn("TotBill"))
        FormDataTable.Columns.Add(New DataColumn("Arrears"))
        FormDataTable.Columns.Add(New DataColumn("OthAmt"))
        FormDataTable.Columns.Add(New DataColumn("NetBill"))


        Dim FormDatafooter As New DataTable()


        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            ConStr.Open()
            Using Cmd As New SqlCommand(query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@BillCode", ltrlID.Text)
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    FormDataTable.Rows.Add(
                            If(DR.IsDBNull(DR.GetOrdinal("Subd")), "", DR("Subd").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Phase")), "", DR("Phase").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Block")), "", DR("Block").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Lot")), "", DR("Lot").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Code")), "", DR("Code").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Name")), "", DR("Name").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("CurrRead")), "", DR("CurrRead").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("PrevRead")), "", DR("PrevRead").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("KWHUsed")), "", DR("KWHUsed").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("FactorRate")), "", DR("FactorRate").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("BillAmt")), "", DR("BillAmt").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("TotBill")), "", DR("TotBill").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("Arrears")), "", DR("Arrears").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("OthAmt")), "", DR("OthAmt").ToString()),
                            If(DR.IsDBNull(DR.GetOrdinal("NetBill")), "", DR("NetBill").ToString()))


                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record
        FormDataSet = New DataSet()
        FormDataSet.Tables.Add(FormDataTable)
        'FormDataSet.Tables.Add(FormDatafooter)


    End Sub

    Protected Sub saveTableBtn_Click(ByVal sender As Object, ByVal e As EventArgs)

        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub

    End Sub

    Protected Sub lbtn01Tools_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Tools.Click

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate


    End Sub

    Protected Sub lbtn01Delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Delete.Click

        'cancel record
        If ltrlMode.Text = "ADD" Then

            'hide button
            lbtn01DeleteOk.Visible = False
            lbtn01SaveOk.Visible = False
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
            lbtn01DeleteOk.Visible = False
            lbtn01SaveOk.Visible = False
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

            'Access
            Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Delete")
            If Msg01 = "0" Then
                Alert("error", "Access denied!")
                Exit Sub
            End If
            'Access

            'validate record
            Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Delete")
            If Msg02 <> "" Then
                Alert("error", Msg02)
            ElseIf ltrlID.Text = "0000000000000" Or ltrlFormCode.Text = "" Then
                Alert("error", "No active form found!")
            Else

                'hide button
                lbtn01DeleteOk.Visible = False
                lbtn01SaveOk.Visible = False
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

            ltrlMode.Text = "DTL"
            'Record

            'hide modal
            ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('hide');</script>", False)
            'hide modal

            'display record


            bind01Overview()
            bindconnectioncode()
            bindForm()


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


            bind01Overview()
            bindconnectioncode()
            bindForm()

            'display record

            Exit Sub

        End If
        'cancel record

        'delete record
        If ltrlMode.Text = "DTL" Then

            'Access
            Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Delete")
            If Msg01 = "0" Then
                Alert01("error", "Access denied!", "")
                Exit Sub
            End If
            'Access

            'validate
            Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Delete")
            If Msg02 <> "" Then
                Alert01("error", Msg02, "")
                Exit Sub
            End If

            'validate
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "calmardblive.dbo.JCF_DelRecord"
            SqlCmd.Parameters.AddWithValue("@TblaName", "JCF_ElecBillHdr")
            SqlCmd.Parameters.AddWithValue("@TblCode", ltrlID.Text)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'Record

            ltrlMode.Text = "DTL"
            ltrlID.Text = "0000000000000"

            'Record

            Debug.WriteLine(ltrlID.Text)

            'set value
            lbl01Connection.Text = "-"
            lbl01TotalBill.Text = "-"
            lbl01DueDateFrom.Text = "-"
            lbl01DueDateTo.Text = "-"
            cbxCSL.Checked = False
            cbxWithEWT.Checked = False
            tbxEWT.Text = "-"
            Lalbl01Kwh.Text = "-"
            lbl01BillingPeriodFrom.Text = "-"
            lbl01BillingPeriodTo.Text = "-"
            lbl01PmtPosted.Text = "-"
            lbl01Factor.Text = "-"
            lblID.Text = "-"
            lblTitle.Text = "-"
            'set value

            'success alert
            Alert("success", "Record successfully removed.")
            'success alert

            'display record
            bind01Overview()
            bindForm()
            bindconnectioncode()
            'display record


        End If
        'delete record


    End Sub

    Protected Sub lbtn01Edit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Edit.Click


        'Save record
        If ltrlMode.Text = "ADD" Then

            If ddlAdd_Connection.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx02IssueDate.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx02DueDate.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx02BillingPeriodFrom.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx02BillingPeriodTo.Text = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx02PmtPosted.Text = "" Then
                Alert("error", "Some fields are missing!")
            Else

                'hide button
                lbtn01DeleteOk.Visible = False
                lbtn01SaveOk.Visible = False
                'hide button

                'display modal
                lbl01ConfirmMessageDialogBox.Text = "Save record?"
                lbtn01SaveOk.Visible = True
                mdl01DialogBox.Update()
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('show');</script>", False)
                'display modal

            End If

            ' Handle unexpected errors

        End If
        'save record

        'Save record
        If ltrlMode.Text = "UPD" Then


            ''validate record
            'If tbx02Pricelistno.Text = "" Then
            '    Alert("error", "Some fields are missing!")
            'ElseIf tbx02MemoNo.Text = "" Then
            '    Alert("error", "Some fields are missing!")
            'ElseIf tbx02EffectiveDate.Text = "" Then
            '    Alert("error", "Some fields are missing!")
            'ElseIf tbx02DateReleased.Text = "" Then
            '    Alert("error", "Some fields are missing!")

            'Else

            '    'hide button
            '    lbtn01DeleteOk.Visible = False
            '    lbtn01SaveOk.Visible = False
            '    'hide button

            '    'display modal
            '    lbl01ConfirmMessageDialogBox.Text = "Save record?"
            '    lbtn01SaveOk.Visible = True
            '    mdl01DialogBox.Update()
            '    ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01DialogBox').modal('show');</script>", False)
            '    'display modal

            'End If

        End If
        'save record

        'Edit record
        If ltrlMode.Text = "DTL" And ltrlID.Text <> "0000000000000" Then

            'Access
            Dim Msg = Access(CIIS_EmpCode, FormCode, "Save")
            If Msg = "0" Then
                Alert01("error", "Access denied!", "")
                Exit Sub
            End If
            'Access

            'validate
            Dim Msg03 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Save")
            If Msg03 <> "" Then
                Alert01("error", Msg03, "")
                Exit Sub
            End If
            'validate

            'Record
            ltrlMode.Text = "UPD"
            'Record

            'display record

            bind01Overview()

            'display record

            Exit Sub

        End If
        'Edit record
        Debug.WriteLine(ltrlMode.Text)
    End Sub

    Protected Sub lbtn01SaveOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01SaveOk.Click

        'cancel record
        If ltrlMode.Text = "ADD" Then



            ' Create StringBuilder for the query
            Dim Query As New StringBuilder
            Query.Append("DECLARE @Code NVARCHAR(13);") ' Declare @Code
            Query.Append("EXEC calmardblive.dbo.JCF_NewCode 'JCF_ElecBillHdr', @Code OUTPUT;") ' Execute procedure
            Query.Append("SELECT @Code AS GeneratedCode;") ' Retrieve the output value



            ' Create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password

            Try
                ' Prepare SQL command for retrieving the generated code
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.Text ' Use Text to run the query directly
                SqlCmd.CommandText = Query.ToString()

                ' Open connection
                SqlConn.Open()

                ' Execute the query and retrieve the generated code
                Dim generatedCode As String = ""
                Dim reader As SqlDataReader = SqlCmd.ExecuteReader()
                If reader.Read() Then
                    generatedCode = reader("GeneratedCode").ToString()
                End If
                reader.Close()

                ' Assign the retrieved code to ltrlID.Text
                ltrlID.Text = generatedCode
                Debug.WriteLine($"Generated Code: {ltrlID.Text}")

                ' Step 2: Now, you can call the second procedure, passing the generated code
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "calmardblive.dbo.JCF_UpdElecBillHdr"

                ' Add parameters for the second procedure
                SqlCmd.Parameters.Clear() ' Clear existing parameters from the first command
                SqlCmd.Parameters.AddWithValue("@pUpdMode", "New")
                SqlCmd.Parameters.AddWithValue("@pBillCode", ltrlID.Text)
                SqlCmd.Parameters.AddWithValue("@pConnection", ddlAdd_Connection.SelectedValue)

                SqlCmd.Parameters.AddWithValue("@pIssueDate", tbx02IssueDate.Text)
                SqlCmd.Parameters.AddWithValue("@pDueDate", tbx02DueDate.Text)
                SqlCmd.Parameters.AddWithValue("@pFromDate", tbx02BillingPeriodFrom.Text)
                SqlCmd.Parameters.AddWithValue("@pToDate", tbx02BillingPeriodTo.Text)
                SqlCmd.Parameters.AddWithValue("@pPmtDate", tbx02PmtPosted.Text)


                SqlCmd.Parameters.AddWithValue("@pWithLoss", If(cbx02CLS.Checked, 1, 0))
                SqlCmd.Parameters.AddWithValue("@pWthEWT", If(cbx02WithEWT.Checked, 1, 0))

                SqlCmd.Parameters.AddWithValue("@pEWTAmt", If(String.IsNullOrWhiteSpace(tbx02WithEWT.Text), 0, Convert.ToDecimal(tbx02WithEWT.Text)))
                SqlCmd.Parameters.AddWithValue("@pBillAmt", If(String.IsNullOrWhiteSpace(lbl02TotalBill.Text), DBNull.Value, Convert.ToDecimal(lbl02TotalBill.Text)))
                SqlCmd.Parameters.AddWithValue("@pKWHUsed", If(String.IsNullOrWhiteSpace(lbl02Kwh.Text), DBNull.Value, Convert.ToDecimal(lbl02Kwh.Text)))
                SqlCmd.Parameters.AddWithValue("@pFactorRate", If(String.IsNullOrWhiteSpace(lbl02Factor.Text), DBNull.Value, Convert.ToDecimal(lbl02Factor.Text)))

                SqlCmd.Parameters.AddWithValue("@pAuditUser", CIIS_EmpCode)

                ' Execute second procedure
                SqlCmd.ExecuteNonQuery()
                Debug.WriteLine("Second procedure executed successfully.")


            Catch ex As SqlException
                ' Handle SQL exception
                For Each err As SqlError In ex.Errors
                    Debug.WriteLine($"SQL Error: {err.Message}, LineNumber: {err.LineNumber}, Procedure: {err.Procedure}")
                Next
            Catch ex As Exception
                ' Handle general exception
                Debug.WriteLine($"General Error: {ex.Message}")
            Finally
                ' Close connection
                If SqlConn.State = ConnectionState.Open Then
                    SqlConn.Close()
                End If
            End Try




            'Record

            ltrlMode.Text = "DTL"
            Debug.WriteLine(ltrlID.Text)



            'success alert
            Alert("success", "Record successfully saved.")
            'success alert

            'display record
            bind01Overview()
            bindForm()
            bindconnectioncode()
            bind02Files()


            Exit Sub



        End If
        'cancel record

        'cancel record
        If ltrlMode.Text = "UPD" Then

            '' Declare your query
            'Dim Query As New StringBuilder
            'Query.Append("UPDATE calmardblive.dbo.JCF_ElecBillHdr Set ")
            'Query.Append("  [PricelistNo] = '" & tbx02Pricelistno.Text & "' ")
            'Query.Append("  ,[MemoNo] = '" & tbx02MemoNo.Text & "' ")
            'Query.Append("  ,[EffectiveDate] = '" & tbx02EffectiveDate.Text & "' ")
            'Query.Append("  ,[DateReleased] = '" & tbx02DateReleased.Text & "' ")
            'Query.Append("  ,[Remarks] = '" & tbx02Remarks.Text & "' ")
            'Query.Append("  ,[AuditUser] = '" & CIIS_EmpCode & "' ")
            'Query.Append("   ,[AuditDate] = getdate() ")
            'Query.Append("WHERE ")
            'Query.Append(" Code = '" & ltrlID.Text & "'; ")
            'Query.Append("SELECT Code, PriceListNo, MemoNo, EffectiveDate, DateReleased, Remarks, AuditUser, AuditDate, LockedBy, LockedDate, Lock ")
            'Query.Append("FROM calmardblive.dbo.JCF_ElecBillHdr ")
            'Query.Append("WHERE Code = '" & ltrlID.Text & "'; ")

            'Debug.WriteLine("Constructed Query: " & Query.ToString())

            ' Create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.Text
            'SqlCmd.CommandText = Query.ToString()

            Try
                Debug.WriteLine("Attempting to open SQL connection.")
                ' Open the connection
                SqlConn.Open()
                Debug.WriteLine("Connection opened successfully.")

                ' Execute the query
                SqlCmd.ExecuteNonQuery()
                Debug.WriteLine("Query executed successfully.")

                ' Close the connection
                SqlConn.Close()
                Debug.WriteLine("Connection closed successfully.")

                ' Alert success
                Alert("success", "Record successfully added.")

            Catch ex As Exception
                Debug.WriteLine("An error occurred: " & ex.Message)
                Debug.WriteLine("Stack Trace: " & ex.StackTrace)

                ' Close the connection in case of error
                If SqlConn.State = ConnectionState.Open Then
                    SqlConn.Close()
                    Debug.WriteLine("Connection closed due to an error.")
                End If

                ' Check for truncation error
                If ex.Message.Contains("String or binary data would be truncated") Then
                    Alert("error", "Input exceeds the maximum allowed length (5 characters).")
                Else
                    ' General error handling
                    Alert("error", "An unexpected error occurred: " & ex.Message)
                End If
            End Try

            ' Record
            ltrlMode.Text = "DTL"
            'Record

            ' Success alert
            Alert("success", "Record successfully saved.")

            ' Display record
            bind01Overview()

            Debug.WriteLine("End of procedure.")

            Exit Sub

        End If


    End Sub

    Protected Sub lbtn01Lock_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Lock.Click

        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Lock")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Lock")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'set value
        tbxLock_Password.Value = ""
        'set value

        'update modal
        mdlLock.Update()
        'update modal

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlLock').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnLock_Ok_Click(ByVal sender As Object, e As EventArgs)

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Lock")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Lock")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'password
        Dim Msg03 = CheckPassword(tbxLock_Password.Value)
        If Msg03 <> "" Then
            Alert01("error", Msg03, "")
            Exit Sub
        End If
        'password

        'create connection
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "calmardblive.dbo.JCF_LockRecord"
        sqlCmd.Parameters.AddWithValue("@pTblName", "JCF_ElecBillHdr")
        sqlCmd.Parameters.AddWithValue("@pTblCode", ltrlID.Text)
        sqlCmd.Parameters.AddWithValue("@pLockBy", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pLock", 1)
        'create connection

        'execute procedure
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'execute procedure

        bind01Overview()
        bindForm()
        bindconnectioncode()

        'alert success
        Alert01("success", "Record successfully locked.", "$('#ContentPlaceHolder1_mdlLock').modal('hide');")
        'alert success

    End Sub

    Protected Sub lbtn01Unlock_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Unlock.Click

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Unlock")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Unlock")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'set value
        tbxUnlock_Password.Value = ""
        'set value

        'update modal
        mdlUnlock.Update()
        'update modal

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUnlock').modal('show');</script>", False)
        'display modal


    End Sub

    Protected Sub btnUnlock_Ok_Click(ByVal sender As Object, e As EventArgs)

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate


        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Unlock")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Unlock")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'password
        Dim Msg03 = CheckPassword(tbxUnlock_Password.Value)
        If Msg03 <> "" Then
            Alert01("error", Msg03, "")
            Exit Sub
        End If
        'password

        'create connection
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "calmardblive.dbo.JCF_LockRecord"
        sqlCmd.Parameters.AddWithValue("@pTblName", "JCF_ElecBillHdr")
        sqlCmd.Parameters.AddWithValue("@pTblCode", ltrlID.Text)
        sqlCmd.Parameters.AddWithValue("@pLockBy", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pLock", 0)
        'create connection

        'execute procedure
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'execute procedure

        bind01Overview()
        bindForm()
        bindconnectioncode()

        'alert success
        Alert01("success", "Record successfully unlocked.", "$('#ContentPlaceHolder1_mdlUnlock').modal('hide');")
        'alert success

    End Sub

    Protected Sub lbtn01Post_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Post.Click

        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Post")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Post")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'set value
        tbxPost_Password.Value = ""
        'set value

        'update modal   
        mdlPost.Update()
        'update modal

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlPost').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnPost_Ok_Click(ByVal sender As Object, e As EventArgs)

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate


        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Post")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Post")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'password
        Dim Msg03 = CheckPassword(tbxPost_Password.Value)
        If Msg03 <> "" Then
            Alert01("error", Msg03, "")
            Exit Sub
        End If
        'password

        'create connection
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "calmardblive.dbo.JCF_PostElecBillHdr"
        sqlCmd.Parameters.AddWithValue("@pBillCode", ltrlID.Text)
        sqlCmd.Parameters.AddWithValue("@pPostBy", CIIS_EmpCode)
        'create connection

        'create connection

        'execute procedure
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'execute procedure

        bind01Overview()
        bindForm()
        bindconnectioncode()

        'alert success
        Alert01("success", "Record successfully Posted.", "$('#ContentPlaceHolder1_mdlPost').modal('hide');")
        'alert success


    End Sub

    Protected Sub lbtn01UnPost_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Unpost.Click

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Unpost")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Unpost")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'set value
        tbxUnpost_Password.Value = ""
        'set value

        'update modal
        mdlUnlock.Update()
        'update modal

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlUnPost').modal('show');</script>", False)
        'display modal


    End Sub

    Protected Sub btnUnPost_Ok_Click(ByVal sender As Object, e As EventArgs)

        'validate
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate


        'Access
        Dim Msg01 = Access(CIIS_EmpCode, FormCode, "Unpost")
        If Msg01 = "0" Then
            Alert01("error", "Access denied!", "")
            Exit Sub
        End If
        'Access

        'validate
        Dim Msg02 = Validate01("calmardblive.dbo.JCF_ElecBillHdr", ltrlID.Text, "Unpost")
        If Msg02 <> "" Then
            Alert01("error", Msg02, "")
            Exit Sub
        End If
        'validate

        'password
        Dim Msg03 = CheckPassword(tbxUnpost_Password.Value)
        If Msg03 <> "" Then
            Alert01("error", Msg03, "")
            Exit Sub
        End If
        'password

        'create connection
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "calmardblive.dbo.JCF_RvrsElecBillHdr"
        sqlCmd.Parameters.AddWithValue("@pBillCode", ltrlID.Text)
        sqlCmd.Parameters.AddWithValue("@pPostBy", CIIS_EmpCode)
        'create connection


        'execute procedure
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'execute procedure

        bind01Overview()
        bindForm()
        bindconnectioncode()


        'alert success
        Alert01("success", "Record successfully unposted.", "$('#ContentPlaceHolder1_mdlUnPost').modal('hide');")
        'alert success


    End Sub



#End Region

#Region "Upload"

    Protected Sub lbtn02UploadSave_Click(ByVal sender As Object, e As EventArgs)
        bind02Files()
        upnl02Files.Update()
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
        If lblID.Text = "-" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate01("02Files", "Add", "")
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
    Function HideBtn()
        lbtn01DeleteOk.Visible = False
        lbtn01SaveOk.Visible = False
        lbtn02DeleteOk.Visible = False
    End Function

    Private Sub lbtn02DeleteOk_Click(sender As Object, e As EventArgs) Handles lbtn02DeleteOk.Click

        'validate
        If ltrlID.Text = "0000000000000" Then Exit Sub
        If ltrlMode.Text = "ADD" Then Exit Sub
        If ltrlMode.Text = "UPD" Then Exit Sub
        'validate

        'create variable
        Dim Msg As String = Validate01("02Files", "Delete", "")
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
            'bind06History()
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
        'bind06History()
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

    '#Region "Modal Find"

    '    Function bind01Find()

    '        'processing time
    '        System.Threading.Thread.Sleep(1000)
    '        'processing time


    '        'Create datatable and columns
    '        Dim dtable As New DataTable
    '        dtable.Columns.Add(New DataColumn("BillCode"))
    '        dtable.Columns.Add(New DataColumn("Post"))
    '        dtable.Columns.Add(New DataColumn("Connection"))
    '        dtable.Columns.Add(New DataColumn("DateIssue"))
    '        dtable.Columns.Add(New DataColumn("DateDue"))
    '        dtable.Columns.Add(New DataColumn("BillingFrom"))
    '        dtable.Columns.Add(New DataColumn("BillingTo"))



    '        'Create datatable and columns

    '        'read record
    '        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetElecHdrList", ConStr)
    '                Cmd.CommandType = CommandType.StoredProcedure

    '                ' Add parameters for the stored procedure
    '                Cmd.Parameters.AddWithValue("@pPost", 0)
    '                    Cmd.Parameters.AddWithValue("@pConnection", "")

    '                    ConStr.Open()
    '                Using DR As SqlDataReader = Cmd.ExecuteReader()
    '                    While DR.Read()

    '                        Dim Link As String = "PMD020100-DTL-" & DR("BillCode").ToString()
    '                        Dim ID As String = "<a href='" & Link & "' class='text-dark'>" & DR("BillCode") & "</a>"
    '                        Dim posted As String = "<div class='d-flex align-items-center form-check form-check-sm form-check-custom form-check-solid ' " &
    '                "style='background-color: white; justify-content: flex-start;'>" &
    '                "<input id='chkSelectPosted' class='form-check-input checkBoxAllClass chkSelect' " &
    '                "type='checkbox' " & If(DR("Post").ToString() = "1", "checked='checked'", "") & " style='pointer-events:none;' />" &
    '                "</div>"


    '                        'Add the row to the DataTable

    '                        dtable.Rows.Add(ID,
    '                    posted,
    '                    DR("SINNo").ToString(),
    '                    Convert.ToDateTime(DR("IssueDate")).ToString("MM/dd/yyyy"),
    '                    Convert.ToDateTime(DR("DueDate")).ToString("MM/dd/yyyy"),
    '                    Convert.ToDateTime(DR("FromDate")).ToString("MM/dd/yyyy"),
    '                    Convert.ToDateTime(DR("ToDate")).ToString("MM/dd/yyyy")
    '                )
    '                    End While

    '                End Using
    '            End Using
    '        End Using
    '        'read record

    '        ' Assign the DataTable to a DataSet if needed
    '        FormDataSet = New DataSet()
    '        FormDataSet.Tables.Add(dtable)

    '        'bind datatable 

    '        'display
    '        mdl01Find.Update()
    '        'display
    '        'read record


    '    End Function

    '#End Region

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