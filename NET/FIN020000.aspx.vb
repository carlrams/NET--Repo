Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Services.Description
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FIN020000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

    Dim AssignToDT As New DataTable

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "FIN020000")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'load
            bindBreadcrumbbar()
            bindREP()
            'load

        ElseIf IsPostBack = True Then

            'render
            RenderDatatable()
            'render

        End If
        'load page
    End Sub

#End Region

#Region "Button"

    Protected Sub btnRefresh_REP_Click(ByVal sender As Object, e As EventArgs)
        bindREP()
    End Sub

    Protected Sub btnCreate_REP01_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim IDSrs = ""
        Dim RowIdx = 0
        Dim Total As Double = 0
        'create variable

        'get selected rows
        Do Until RowIdx = gvTask.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'get selected rows

        'validate
        If IDSrs = "" Then
            Alert("error", "No record selected!")
            Exit Sub
        End If
        'validate

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [ID] ")
        Query.Append("   ,[Date] ")
        Query.Append("   ,[RequestedBy] ")
        Query.Append("   ,[Remarks] ")
        Query.Append("   ,[Amount] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      [A].f_code [ID] ")
        Query.Append("      ,Format([A].created_date,'MM/dd/yyyy') [Date] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [RequestedBy] ")
        Query.Append("      ,[C].Remarks ")
        Query.Append("      ,Format(isnull((select sum([D].Amount) from Form_PCDtl [D] where [D].PCCode = [C].PCCode),0),'N2') [Amount] ")
        Query.Append("      ,isnull((select top 1 [D].approver from oop_form_dtl_appr [D] where [D].f_code = [A].f_code and [D].type = 'Implementer' ),'') [Custodian] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join Form_PCHdr [C] on [A].tbl_code = [C].PCCode ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_PCHdr' ")
        Query.Append("      and [A].Status = 'Accepted' ")
        Query.Append("      and [C].PCType = 'Cash Payment and Cash Liquidation' ")
        Query.Append("      and [C].APVNo = '') [A] ")
        Query.Append("where ")
        Query.Append("   [A].Custodian = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].ID in (select * from SplitString('" & IDSrs & "',',')) ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("RequestedBy"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("Amount"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Total = Total + CDbl(DR("Amount"))
                    'set value

                    'create varialble
                    Dim ID As String = DR("ID")
                    Dim Date_ As String = DR("Date")
                    Dim RequestedBy As String = DR("RequestedBy")
                    Dim Remarks As String = DR("Remarks")
                    Dim Amount As String = DR("Amount")
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {DR("ID"), DR("Date"), DR("RequestedBy"), DR("Remarks"), DR("Amount")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvREP.DataSource = dtable
        gvREP.DataBind()
        RenderDatatable()
        'bind datatable

        'gv06PCDtl.FooterRow.TableSection = TableRowSection.TableFooter
        gvREP.FooterRow.Cells(0).ColumnSpan = 3
        gvREP.FooterRow.Cells.RemoveAt(1)
        gvREP.FooterRow.Cells.RemoveAt(2)
        gvREP.FooterRow.Cells(0).Text = "Total Expense"
        gvREP.FooterRow.Cells(2).Text = Format(Total, "N2")
        gvREP.FooterRow.CssClass = "border-top fw-bold text-dark"
        'Adds TFOOT section. 

        'set value
        tbxEXP.Value = Format(Total, "N2")
        tbxTOT.Value = Format(Total, "N2")
        'set value

        'update
        mdlREP.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlREP').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnCreate_REP02_Click(ByVal sender As Object, e As EventArgs)

        'create variable
        Dim Total = 0
        'create variable

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [ID] ")
        Query.Append("   ,[Date] ")
        Query.Append("   ,[RequestedBy] ")
        Query.Append("   ,[Remarks] ")
        Query.Append("   ,[Amount] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      [A].f_code [ID] ")
        Query.Append("      ,Format([A].created_date,'MM/dd/yyyy') [Date] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [RequestedBy] ")
        Query.Append("      ,[C].Remarks ")
        Query.Append("      ,Format(isnull((select sum([D].Amount) from Form_PCDtl [D] where [D].PCCode = [C].PCCode),0),'N2') [Amount] ")
        Query.Append("      ,isnull((select top 1 [D].approver from oop_form_dtl_appr [D] where [D].f_code = [A].f_code and [D].type = 'Implementer' ),'') [Custodian] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join Form_PCHdr [C] on [A].tbl_code = [C].PCCode ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_PCHdr' ")
        Query.Append("      and [A].Status = 'Accepted' ")
        Query.Append("      and [C].PCType = 'Cash Payment and Cash Liquidation' ")
        Query.Append("      and [C].APVNo = '') [A] ")
        Query.Append("where ")
        Query.Append("   [A].Custodian = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].ID = '" & hfID.Value & "' ")
        'get item

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("RequestedBy"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("Amount"))
        'Create datatable and columns

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Total = Total + CDbl(DR("Amount"))
                    'set value

                    'create varialble
                    Dim ID As String = DR("ID")
                    Dim Date_ As String = DR("Date")
                    Dim RequestedBy As String = DR("RequestedBy")
                    Dim Remarks As String = DR("Remarks")
                    Dim Amount As String = DR("Amount")
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {DR("ID"), DR("Date"), DR("RequestedBy"), DR("Remarks"), DR("Amount")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'bind datatable 
        gvREP.DataSource = dtable
        gvREP.DataBind()
        RenderDatatable()
        'bind datatable

        'gv06PCDtl.FooterRow.TableSection = TableRowSection.TableFooter
        gvREP.FooterRow.Cells(0).ColumnSpan = 3
        gvREP.FooterRow.Cells.RemoveAt(1)
        gvREP.FooterRow.Cells.RemoveAt(2)
        gvREP.FooterRow.Cells(0).Text = "Total Expense"
        gvREP.FooterRow.Cells(2).Text = Format(Total, "N2")
        gvREP.FooterRow.CssClass = "border-top fw-bold text-dark"
        'Adds TFOOT section. 

        'set value
        tbxEXP.Value = Format(Total, "N2")
        tbxTOT.Value = Format(Total, "N2")
        'set value

        'update
        mdlREP.Update()
        'update

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlREP').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnCreate_REP03_Click(ByVal sender As Object, e As EventArgs)

        'Petty Cash
        Dim IDSrs As String = ""
        Dim RowIdx = 0
        Do Until RowIdx = gvREP.Rows.Count
            Dim RowCheckbox As HtmlInputCheckBox = gvTask.Rows(RowIdx).FindControl("RowCheckbox")
            Dim lblID As Label = gvTask.Rows(RowIdx).FindControl("lblID")
            If RowCheckbox.Checked = True Then
                IDSrs = IDSrs & "," & lblID.Text
            End If
            RowIdx = RowIdx + 1
        Loop
        'Petty Cash

        'validation
        If CDbl(tbxEXP.Value) <= 0 Then
            Alert("error", "Requires atleast one Petty Cash!")
            Exit Sub
        ElseIf CDbl(tbxRF.Value) < CDbl(tbxTOT.Value) Or CDbl(tbxRF.Value) > CDbl(tbxTOT.Value) Then
            Alert("error", "Total Fund should be equal to Revolving Fund!")
            Exit Sub
        End If
        'validation

        'procedure
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=iis; Initial Catalog=cldc_live_acc; User ID=ciis; Password=Cii5s"
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "New_Replenishment"
        sqlCmd.Parameters.AddWithValue("@pPCNoSRS", IDSrs)
        sqlCmd.Parameters.AddWithValue("@pEXP", CDbl(tbxEXP.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH1000", CDbl(tbxAmt1000.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH500", CDbl(tbxAmt500.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH200", CDbl(tbxAmt200.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH100", CDbl(tbxAmt100.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH50", CDbl(tbxAmt50.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH20", CDbl(tbxAmt20.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH10", CDbl(tbxAmt10.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH5", CDbl(tbxAmt5.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH1", CDbl(tbxAmt1.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH025", CDbl(tbxAmt025.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH010", CDbl(tbxAmt010.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH005", CDbl(tbxAmt005.Value))
        sqlCmd.Parameters.AddWithValue("@pCOH001", CDbl(tbxAmt001.Value))
        sqlCmd.Parameters.AddWithValue("@pRF", CDbl(tbxRF.Value))
        sqlCmd.Parameters.AddWithValue("@pCA", CDbl(tbxCA.Value))
        sqlCmd.Parameters.AddWithValue("@pREP", CDbl(tbxREP.Value))
        sqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        Dim oAPVNo As New SqlClient.SqlParameter("@oAPVNo", SqlDbType.NVarChar, 1000)
        oAPVNo.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oAPVNo)
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        'procedure

        'message
        Alert("success", "Replenishment successfully created.")
        'message

        'updaet record
        bindBreadcrumbbar()
        bindREP()
        'updaet record

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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000018.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000018.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000018.rpt"))
        Dim logoninfo As TableLogOnInfo
        For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
            logoninfo = tbcurrent.LogOnInfo()
            logoninfo.ConnectionInfo.ServerName = DataSource
            logoninfo.ConnectionInfo.DatabaseName = Catalog
            logoninfo.ConnectionInfo.UserID = UserID
            logoninfo.ConnectionInfo.Password = Password
            tbcurrent.ApplyLogOnInfo(logoninfo)
        Next
        RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
        RptDoc.SetParameterValue("@pAPVNo", oAPVNo.Value.ToString, "CARFP1.rpt")
        RptDoc.SetParameterValue("@pAPVNo", oAPVNo.Value.ToString, "CARFP2.rpt")
        RptDoc.SetParameterValue("@pAPVNo", oAPVNo.Value.ToString, "CARFP3.rpt")
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000018.pdf"), Buf)

            'view report
            RptDoc.Dispose()
            RptDoc.Close()
            Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000018.pdf")
            ScriptManager.RegisterStartupScript(upnlContent, upnlContent.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
            'view report
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

    End Sub

    Protected Sub btnRPT_REP_Click(ByVal sender As Object, ByVal e As EventArgs)

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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000007.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000007.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000007.rpt"))
        Dim logoninfo As TableLogOnInfo
        For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
            logoninfo = tbcurrent.LogOnInfo()
            logoninfo.ConnectionInfo.ServerName = DataSource
            logoninfo.ConnectionInfo.DatabaseName = Catalog
            logoninfo.ConnectionInfo.UserID = UserID
            logoninfo.ConnectionInfo.Password = Password
            tbcurrent.ApplyLogOnInfo(logoninfo)
        Next
        RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
        RptDoc.SetParameterValue("@pFormNo", hfID.Value)
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000007.pdf"), Buf)

            'view report
            RptDoc.Dispose()
            RptDoc.Close()
            Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000007.pdf")
            ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
            'view report
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

    End Sub

    Protected Sub btnRefresh_CA_Click(ByVal sender As Object, e As EventArgs)
        bindCA()
    End Sub

    Protected Sub btnCancel_CA01_Click(ByVal sender As Object, e As EventArgs)

        'fill record
        bindCA()
        'fill record

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlCA').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnCancel_CA02_Click(ByVal sender As Object, e As EventArgs)

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDBCA').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnCancel_CA03_Click(ByVal sender As Object, e As EventArgs)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Upd_FRM_Status"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000016")
        SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
        SqlCmd.Parameters.AddWithValue("@pStatus", "Cancelled")
        SqlCmd.Parameters.AddWithValue("@pAssignTo", "")
        SqlCmd.Parameters.AddWithValue("@pRemarks", "")
        SqlCmd.Parameters.AddWithValue("@pMention", "")
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'message
        Alert("success", "Cash Advance successfully cancelled.")
        'message

        'updaet record
        bindCA()
        'updaet record

    End Sub

    Protected Sub btnRPT_CA_Click(ByVal sender As Object, ByVal e As EventArgs)

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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000007.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000007.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000007.rpt"))
        Dim logoninfo As TableLogOnInfo
        For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
            logoninfo = tbcurrent.LogOnInfo()
            logoninfo.ConnectionInfo.ServerName = DataSource
            logoninfo.ConnectionInfo.DatabaseName = Catalog
            logoninfo.ConnectionInfo.UserID = UserID
            logoninfo.ConnectionInfo.Password = Password
            tbcurrent.ApplyLogOnInfo(logoninfo)
        Next
        RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
        RptDoc.SetParameterValue("@pFormNo", hfID.Value)
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000007.pdf"), Buf)

            'view report
            RptDoc.Dispose()
            RptDoc.Close()
            Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000007.pdf")
            ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
            'view report
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

    End Sub

    Protected Sub btnRefresh_APV_Click(ByVal sender As Object, e As EventArgs)
        bindAPV()
    End Sub

    Protected Sub btnCancel_APV01_Click(ByVal sender As Object, e As EventArgs)

        'fill record
        bindAPV()
        'fill record

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlAPV').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnCancel_APV02_Click(ByVal sender As Object, e As EventArgs)

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDBAPV').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub btnCancel_APV03_Click(ByVal sender As Object, e As EventArgs)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Rvrs_Replenishment"
        SqlCmd.Parameters.AddWithValue("@pAPVNo", hfID.Value)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'message
        Alert("success", "APV successfully cancelled.")
        'message

        'updaet record
        bindAPV()
        'updaet record

    End Sub

    Protected Sub btnRPT_APV_Click(ByVal sender As Object, ByVal e As EventArgs)

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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000018.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000018.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000018.rpt"))
        Dim logoninfo As TableLogOnInfo
        For Each tbcurrent As CrystalDecisions.CrystalReports.Engine.Table In RptDoc.Database.Tables
            logoninfo = tbcurrent.LogOnInfo()
            logoninfo.ConnectionInfo.ServerName = DataSource
            logoninfo.ConnectionInfo.DatabaseName = Catalog
            logoninfo.ConnectionInfo.UserID = UserID
            logoninfo.ConnectionInfo.Password = Password
            tbcurrent.ApplyLogOnInfo(logoninfo)
        Next
        RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
        RptDoc.SetParameterValue("@pAPVNo", hfID.Value, "CARFP1.rpt")
        RptDoc.SetParameterValue("@pAPVNo", hfID.Value, "CARFP2.rpt")
        RptDoc.SetParameterValue("@pAPVNo", hfID.Value, "CARFP3.rpt")
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000018.pdf"), Buf)

            'view report
            RptDoc.Dispose()
            RptDoc.Close()
            Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000018.pdf")
            ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
            'view report
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

    End Sub

#End Region

#Region "Function"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Change Status" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & hfID.Value & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by,approver) then 1 end) from oop_form_hdr where f_code = '" & hfID.Value & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & Value & "' in ('Approved','Clarify') and (select (case when '" + CIIS_EmpCode + "' not in (approver) then 1 end) from oop_form_hdr where f_code = '" & hfID.Value & "') = 1 ")
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

        If Group_ = "Subscribed" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & hfID.Value & "') in ('Accepted','Cancelled','Declined') ")
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

        If Group_ = "Upload File" Then

            'get total task
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & hfID.Value & "') in ('Accepted','Cancelled','Declined') ")
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
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
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

    Function RenderDatatable()
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvTask.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvTask.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvTask.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvTask.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvREP.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvREP.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvREP.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvREP.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvca.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvca.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvca.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvca.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvAPV.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvAPV.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvAPV.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvAPV.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
    End Function

    Function bindBreadcrumbbar()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from (select isnull((select top 1 [E].approver from oop_form_dtl_appr [E] where [E].f_code = [B].f_code and [E].type = 'Implementer'), '') [Custodian] from Form_PCHdr [A] left join oop_form_hdr [B] on [A].PCCode = [B].tbl_code where [A].PCType = 'Cash Payment and Cash Liquidation' and [A].APVNo = '' and [B].tbl_from = 'Form_PCHdr' and [B].status = 'Accepted') [A] where [Custodian] = '" & CIIS_EmpCode & "'), 0) [FM] ")
        'get total task

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
                    Total = DR.GetInt32(0)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        spnTotal.InnerText = "You have " & Total & " for replenishment"
        upnlBreadcrumbbar.Update()
        'display data

    End Function

    Function bindREP()

        'processing time
        System.Threading.Thread.Sleep(2000)
        'processing time

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("   ,[Amount] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [D].DateEnd from oop_form_dtl_appr [D] where [D].f_code = [A].f_code and [D].approver = [A].approver and [D].status = '' order by [D].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("      ,Format(isnull((select sum([E].Amount) from Form_PCDtl [E] where [E].PCCode = [C].PCCode),0),'N2') [Amount] ")
        Query.Append("      ,isnull((select top 1 [D].approver from oop_form_dtl_appr [D] where [D].f_code = [A].f_code and [D].type = 'Implementer' ),'') [Custodian] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join Form_PCHdr [C] on [A].tbl_code = [C].PCCode ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_PCHdr' ")
        Query.Append("      and [A].Status = 'Accepted' ")
        Query.Append("      and [C].PCType = 'Cash Payment and Cash Liquidation' ")
        Query.Append("      and [C].APVNo = '') [A] ")
        Query.Append("where ")
        Query.Append("      [A].Custodian = '" & CIIS_EmpCode & "' ")
        Query.Append("order by ")
        Query.Append("   [DateEnd] desc ")
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
        dtable.Columns.Add(New DataColumn("Amount"))
        dtable.Columns.Add(New DataColumn("Create_REP02"))
        dtable.Columns.Add(New DataColumn("RPT_REP"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
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
                    Dim Amount As String = DR("Amount")
                    Dim Create_REP02 As String = "Create_REP02('" & DR("ID") & "')"
                    Dim RPT As String = "RPT_REP('" & DR("ID") & "')"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, Link, Icon, Title, ID, Name, Date_, Amount, Create_REP02, RPT}
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
        gvTask.EmptyDataText = "No data"
        gvTask.DataSource = dtable
        gvTask.DataBind()
        RenderDatatable()
        'bind datatable 

        'display
        upnlContent.Update()
        'display

    End Function

    Function bindCA()

        'processing time
        System.Threading.Thread.Sleep(2000)
        'processing time

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 (case when [DateEnd] < cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("   ,[Amount] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [D].DateEnd from oop_form_dtl_appr [D] where [D].f_code = [A].f_code and [D].approver = [A].approver and [D].status = '' order by [D].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("      ,Format(isnull((select sum([E].Amount) from Form_PCDtl [E] where [E].PCCode = [C].PCCode),0),'N2') [Amount] ")
        Query.Append("      ,isnull((select top 1 [D].approver from oop_form_dtl_appr [D] where [D].f_code = [A].f_code and [D].type = 'Implementer' ),'') [Custodian] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join Form_PCHdr [C] on [A].tbl_code = [C].PCCode ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_PCHdr' ")
        Query.Append("      and [A].Status = 'Accepted' ")
        Query.Append("      and [C].PCType = 'Cash Advance' ")
        Query.Append("      and [C].Status = '') [A] ")
        Query.Append("where ")
        Query.Append("      [A].Custodian = '" & CIIS_EmpCode & "' ")
        Query.Append("order by ")
        Query.Append("   [DateEnd] desc ")
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
        dtable.Columns.Add(New DataColumn("Amount"))
        dtable.Columns.Add(New DataColumn("Cancel_CA02"))
        dtable.Columns.Add(New DataColumn("RPT_CA"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
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
                    Dim Amount As String = DR("Amount")
                    Dim Cancel_CA02 As String = "Cancel_CA02('" & DR("ID") & "')"
                    Dim RPT_CA As String = "RPT_CA('" & DR("ID") & "')"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, Link, Icon, Title, ID, Name, Date_, Amount, Cancel_CA02, RPT_CA}
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
        gvCA.EmptyDataText = "No data"
        gvCA.DataSource = dtable
        gvCA.DataBind()
        RenderDatatable()
        'bind datatable 

        'display
        mdlCA.Update()
        'display

    End Function

    Function bindAPV()

        'processing time
        System.Threading.Thread.Sleep(2000)
        'processing time

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	 (case when [B].post = 0 and [B].cancel = 0 then 'bullet bullet-vertical bullet-margin h-58px bg-info'  ")
        Query.Append("	       when [B].post = 1 and [B].cancel = 0 then 'bullet bullet-vertical bullet-margin h-58px bg-success'  ")
        Query.Append("	       when [B].post = 1 and [B].cancel = 1 then 'bullet bullet-vertical bullet-margin h-58px bg-danger' end) [Bullet]  ")
        Query.Append("  ,(case when [B].post = 0 and [B].cancel = 0 then 'For Processing' when [B].post = 1 and [B].cancel = 0 then 'Processed' else 'Cancelled' end) [Status] ")
        Query.Append("  ,[A].APVNo ")
        Query.Append("  ,Format([A].CreatedDate,'MM/dd/yyyy') [APVDate] ")
        Query.Append("  ,Format((select sum([D].Amount) from Trxn_REPDtl [D] where [D].APVNo = [A].APVNo and [D].Type = '003'),'N2') [RF] ")
        Query.Append("  ,Format((select sum([D].Amount) from Trxn_REPDtl [D] where [D].APVNo = [A].APVNo and [D].Type = '004' and [D].SeqNo = 1),'N2') [EXP] ")
        Query.Append("  ,Format((select sum([D].Amount) from Trxn_REPDtl [D] where [D].APVNo = [A].APVNo and [D].Type = '004' and [D].SeqNo = 2),'N2') [COH] ")
        Query.Append("  ,Format((select sum([D].Amount) from Trxn_REPDtl [D] where [D].APVNo = [A].APVNo and [D].Type = '004' and [D].SeqNo = 3),'N2') [CA] ")
        Query.Append("  ,Format((select sum([D].Amount) from Trxn_REPDtl [D] where [D].APVNo = [A].APVNo and [D].Type = '004' and [D].SeqNo = 4),'N2') [REP] ")
        Query.Append("  ,Format((select sum([D].Amount) from Trxn_REPDtl [D] where [D].APVNo = [A].APVNo and [D].Type = '004'),'N2') [Total] ")
        Query.Append("from ")
        Query.Append("  Trxn_REPHdr [A] ")
        Query.Append("  left join fin_apv_hdr [B] on [A].APVNo = [B].v_code ")
        Query.Append("where ")
        Query.Append("  [A].CreatedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("order by ")
        Query.Append("  [A].APVNo ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("APVNo"))
        dtable.Columns.Add(New DataColumn("APVDate"))
        dtable.Columns.Add(New DataColumn("RF"))
        dtable.Columns.Add(New DataColumn("EXP"))
        dtable.Columns.Add(New DataColumn("COH"))
        dtable.Columns.Add(New DataColumn("CA"))
        dtable.Columns.Add(New DataColumn("REP"))
        dtable.Columns.Add(New DataColumn("Total"))
        dtable.Columns.Add(New DataColumn("Cancel_APV02"))
        dtable.Columns.Add(New DataColumn("RPT_APV"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Cancel_CA02 As String = "Cancel_APV02('" & DR("APVNo") & "')"
                    Dim RPT As String = "RPT_APV('" & DR("APVNo") & "')"
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {DR("Bullet"), DR("Status"), DR("APVNo"), DR("APVDate"), DR("RF"), DR("EXP"), DR("COH"), DR("CA"), DR("REP"), DR("Total"), Cancel_CA02, RPT}
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
        gvAPV.EmptyDataText = "No data"
        gvAPV.DataSource = dtable
        gvAPV.DataBind()
        RenderDatatable()
        'bind datatable 

        'display
        mdlAPV.Update()
        'display

    End Function

#End Region

End Class