Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Reflection.Emit
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting.WebForms

Public Class SCMRTView
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim cldc_live_acc As String = "cldc_live_acc"
    Dim calmardblive As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim FormCode As String = ""

#Region "Form"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        If IsPostBack = False Then

            FormCode = HttpUtility.UrlDecode(Request.QueryString("FormCode"))

            'Validate Access
            Dim msg As String = Access(CIIS_EmpCode, FormCode, "View")
            If msg <> "1" Then
                Response.Redirect("MNU000022")
            End If
            'Validate Access

            If FormCode = "SCMRT0001" Then
                SCMRT0001()
            End If

            If FormCode = "SCMRT0002" Then
                SCMRT0002()
            End If

            If FormCode = "SCMRT0003" Then
                SCMRT0003()
            End If

            If FormCode = "SCMRT0004" Then
                SCMRT0004()
            End If

            If FormCode = "SCMRT0005" Then
                SCMRT0005()
            End If

            If FormCode = "SCMRT0006" Then
                SCMRT0006()
            End If

            If FormCode = "SCMRT0007" Then
                SCMRT0007()
            End If

            If FormCode = "SCMRT0007" Then
                SCMRT0007()
            End If

            If FormCode = "SCMRT0008" Then
                SCMRT0008()
            End If

            If FormCode = "SCMRT0010" Then
                SCMRT0010()
            End If

            If FormCode = "SCMRT0011" Then
                SCMRT0011()
            End If

            If FormCode = "SCMRT0012" Then
                SCMRT0012()
            End If

            If FormCode = "SCMRT0013" Then
                SCMRT0013()
            End If

            If FormCode = "SCMRT0014" Then
                SCMRT0014()
            End If

            If FormCode = "SCMRT0015" Then
                SCMRT0015()
            End If

            If FormCode = "SCMRT0016" Then
                SCMRT0016()
            End If

            If FormCode = "SCMRT0017" Then
                SCMRT0017()
            End If

            If FormCode = "SCMRT0018" Then
                SCMRT0018()
            End If

            If FormCode = "SCMRT0019" Then
                SCMRT0019()
            End If

            If FormCode = "SCMRT0020" Then
                SCMRT0020()
            End If

            If FormCode = "SCMRT0021" Then
                SCMRT0021()
            End If

            If FormCode = "SCMRT0022" Then
                SCMRT0022()
            End If

            If FormCode = "SCMRT0023" Then
                SCMRT0023()
            End If

            If FormCode = "SCMRT0024" Then
                SCMRT0024()
            End If

        End If
    End Sub

#End Region

#Region "General"

    Function Access(EmpCode, FormCode, Action)

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password
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

#End Region

#Region "SCMRT0001"

    Function SCMRT0001()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0001.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_WT(pDateFrom, pDateTo)
        Dim dsRPT_WT As New ReportDataSource("WTrans", dsSCMRTDataSet.Tables("Rpt_WhseTrans"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_WT)
        'report

    End Function

    Private Function RPT_WT(pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_WhseTrans")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_WhseTrans")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0002"

    Function SCMRT0002()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0002.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_WC(pDateFrom, pDateTo)
        Dim dsRPT_WC As New ReportDataSource("WCancel", dsSCMRTDataSet.Tables("Rpt_WhseCancelled"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_WC)
        'report

    End Function

    Private Function RPT_WC(pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_WhseCancelled")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_WhseCancelled")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0003"

    Function SCMRT0003()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0003.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_CR(pDateFrom, pDateTo)
        Dim dsRPT_CR As New ReportDataSource("CycleRep", dsSCMRTDataSet.Tables("Rpt_ProcurementCycle"))
        Dim _DateFrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("DateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_CR)
        'report

    End Function

    Private Function RPT_CR(pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_ProcurementCycle")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_ProcurementCycle")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0004"

    Function SCMRT0004()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0004.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_OS(pDateFrom, pDateTo)
        Dim dsRPT_OS As New ReportDataSource("OSMMR", dsSCMRTDataSet.Tables("Rpt_OSMRequest"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_OS)
        'report

    End Function

    Private Function RPT_OS(pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_OSMRequest")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_OSMRequest")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0005"

    Function SCMRT0005()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0005.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_FD(pDateFrom, pDateTo)
        Dim dsRPT_FD As New ReportDataSource("FDeliver", dsSCMRTDataSet.Tables("Rpt_ForDeliver"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_FD)
        'report

    End Function

    Private Function RPT_FD(pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_ForDeliver")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_ForDeliver")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0006"

    Function SCMRT0006()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0006.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_PO(pDateFrom, pDateTo)
        Dim dsRPT_PO As New ReportDataSource("PONotes", dsSCMRTDataSet.Tables("Rpt_PONotes"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PO)
        'report

    End Function

    Private Function RPT_PO(pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_PONotes")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_PONotes")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0007"

    Function SCMRT0007()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        Dim pStatus = HttpUtility.UrlDecode(Request.QueryString("pStatus"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0007.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_COF(pDateFrom, pDateTo, pStatus)
        Dim dsRPT_COF As New ReportDataSource("COFMonitoring", dsSCMRTDataSet.Tables("Rpt_ApprovalMonitoring_CRF"))
        Dim _DateFrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("DateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_COF)
        'report

    End Function

    Private Function RPT_COF(pDateFrom, pDateTo, pStatus) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_ApprovalMonitoring_CRF")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_ApprovalMonitoring_CRF")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0008"

    Function SCMRT0008()

        'parameter
        Dim pDate = HttpUtility.UrlDecode(Request.QueryString("pDate"))
        Dim pWarehouse = HttpUtility.UrlDecode(Request.QueryString("pWarehouse"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0008.rdlc")
        Dim dsSCMRTDataset As SCMRTDataSet = RPT_WB(pDate, pWarehouse) 'fill data set
        Dim dsRPT_WB As New ReportDataSource("WBal", dsSCMRTDataset.Tables("Rpt_WhseBal")) 'rdlc dataset name
        Dim _Date As New ReportParameter("Date", DateTime.ParseExact(pDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Date})
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_WB)
        'report

    End Function

    Private Function RPT_WB(pDate, pWarehouse) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_WhseBal") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pWhseCode", pWarehouse)
                sqlCmd.Parameters.AddWithValue("@pDate", pDate)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataset As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataset, "Rpt_WhseBal") 'table adapter name
                    Return dsSCMRTDataset
                End Using
            End Using
        End Using

    End Function

    Private Function RPT_WBDtl(pYear, pPeriod, pWhseCode, pItemCode) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_WhseBalDtl") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pPeriod", pPeriod)
                sqlCmd.Parameters.AddWithValue("@pWhseCode", pWhseCode)
                sqlCmd.Parameters.AddWithValue("@ItemCode", pItemCode)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataset As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataset, "Rpt_WhseBalDtl") 'table adapter name
                    Return dsSCMRTDataset
                End Using
            End Using
        End Using

    End Function

    ''report drill through
    Private Sub ReportViewer1_Drillthrough(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.DrillthroughEventArgs) Handles ReportViewer1.Drillthrough

        'Get Parameter - general ledger balance
        Dim ParmClx As ReportParameterInfoCollection
        Dim ParmInfo As ReportParameterInfo
        ParmClx = e.Report.GetParameters
        Dim pYear As String
        Dim pPeriod As String
        Dim pWhseCode As String
        Dim pWhseName As String
        Dim pItemCode As String
        Dim pItemName As String
        For Each ParmInfo In ParmClx
            If ParmInfo.Name = "Year" Then
                pYear = ParmInfo.Values(0).ToString
            ElseIf ParmInfo.Name = "Period" Then
                pPeriod = ParmInfo.Values(0).ToString
            ElseIf ParmInfo.Name = "WhseCode" Then
                pWhseCode = ParmInfo.Values(0).ToString
            ElseIf ParmInfo.Name = "WhseName" Then
                pWhseName = ParmInfo.Values(0).ToString
            ElseIf ParmInfo.Name = "ItemCode" Then
                pItemCode = ParmInfo.Values(0).ToString
            ElseIf ParmInfo.Name = "ItemName" Then
                pItemName = ParmInfo.Values(0).ToString
            End If
        Next

        'report
        Dim SubReport As LocalReport
        SubReport = e.Report
        SubReport.DataSources.Clear()
        Dim dsSCMRTDataset As SCMRTDataSet = RPT_WBDtl(pYear, pPeriod, pWhseCode, pItemCode) 'fill data set
        Dim dsRPT_WBDtl As New ReportDataSource("WBalDtl", dsSCMRTDataset.Tables("Rpt_WhseBalDtl")) 'rdlc dataset name
        SubReport.DataSources.Add(dsRPT_WBDtl)
        'report

    End Sub

#End Region

#Region "SCMRT0010"

    Function SCMRT0010()

        'parameter
        Dim pEmployee = HttpUtility.UrlDecode(Request.QueryString("pEmployee"))
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        Dim pCancel = HttpUtility.UrlDecode(Request.QueryString("pCancel"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0010.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_PR(pEmployee, pDateFrom, pDateTo, pCancel)
        Dim dsRPT_PR As New ReportDataSource("Procurement", dsSCMRTDataSet.Tables("Rpt_Procurement"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PR)
        'report

    End Function

    Private Function RPT_PR(pEmployee, pDateFrom, pDateTo, pCancel) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_Procurement")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pCreatedBy", pEmployee)
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlCmd.Parameters.AddWithValue("@pIncCancel", pCancel)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_Procurement")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0011"

    Function SCMRT0011()

        'parameter
        Dim pType = HttpUtility.UrlDecode(Request.QueryString("pType"))
        Dim pCharge = HttpUtility.UrlDecode(Request.QueryString("pCharge"))
        Dim pWarehouse = HttpUtility.UrlDecode(Request.QueryString("pWarehouse"))
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0011.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_WI(pType, pCharge, pWarehouse, pDateFrom, pDateTo)
        Dim dsRPT_WI As New ReportDataSource("WIssue", dsSCMRTDataSet.Tables("Rpt_WhseIssue"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_WI)
        'report

    End Function

    Private Function RPT_WI(pType, pCharge, pWarehouse, pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_WhseIssue")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pTrxnType", pType)
                sqlCmd.Parameters.AddWithValue("@pTrxnCode", pCharge)
                sqlCmd.Parameters.AddWithValue("@pWhseCode", pWarehouse)
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_WhseIssue")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "SCMRT0012"

    Function SCMRT0012()

        'parameter
        Dim pTerritory = HttpUtility.UrlDecode(Request.QueryString("pTerritory"))
        Dim pWarehouse = HttpUtility.UrlDecode(Request.QueryString("pWarehouse"))
        Dim pOrigin = HttpUtility.UrlDecode(Request.QueryString("pOrigin"))
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0012.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_WR(pTerritory, pWarehouse, pOrigin, pDateFrom, pDateTo)
        Dim dsRPT_WR As New ReportDataSource("WReceived", dsSCMRTDataSet.Tables("Rpt_WhseRvcd"))
        Dim _DateFrom As New ReportParameter("pDateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("pDateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_WR)
        'report

    End Function

    Private Function RPT_WR(pTerritory, pWarehouse, pOrigin, pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_WhseRvcd")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDivCode", pTerritory)
                sqlCmd.Parameters.AddWithValue("@pWhsecode", pWarehouse)
                sqlCmd.Parameters.AddWithValue("@pOrigin", pOrigin)
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_WhseRvcd")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0013"

    Function SCMRT0013()

    End Function

#End Region

#Region "SCMRT0014"

    Function SCMRT0014()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0014.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_POBAL()
        Dim dsRPT_POBAL As New ReportDataSource("Rpt_POItemBalance", dsSCMRTDataSet.Tables("Rpt_POItemBalance"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_POBAL)
        'report

    End Function

    Private Function RPT_POBAL()
        Dim sqlCmd As New SqlCommand("Rpt_POItemBalance")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_POItemBalance")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0015"

    Private Function SCMRT0015()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0015.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_WTBAL()
        Dim dsRPT_WTBAL As New ReportDataSource("Rpt_WTItemBalance", dsSCMRTDataSet.Tables("Rpt_WTItemBalance"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_WTBAL)
        'report

    End Function

    Private Function RPT_WTBAL()
        Dim sqlCmd As New SqlCommand("Rpt_WTItmBalance")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_WTItemBalance")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0016"

    Private Function SCMRT0016()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0016.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_IRBAL()
        Dim dsRPT_IRBAL As New ReportDataSource("Rpt_IRBalance", dsSCMRTDataSet.Tables("Rpt_IRBalance"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_IRBAL)
        'report

    End Function

    Private Function RPT_IRBAL()
        Dim sqlCmd As New SqlCommand("Rpt_IRBalance")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_IRBalance")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0017"

    Function SCMRT0017()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0017.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_PORCVD(pDateFrom, pDateTo)
        Dim dsRPT_PORCVD As New ReportDataSource("PORcvd", dsSCMRTDataSet.Tables("Rpt_PORcvd"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PORCVD)
        'report

    End Function

    Private Function RPT_PORCVD(pDateFrom, pDateTo) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_PORcvd")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_PORcvd")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0018"

    Function SCMRT0018()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0018.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_POFWP()
        Dim dsRPT_PORCVD As New ReportDataSource("Rpt_POItemBalance_FWP", dsSCMRTDataSet.Tables("Rpt_POItemBalance_FWP"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PORCVD)
        'report

    End Function

    Private Function RPT_POFWP() As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_POItemBalance_FWP")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_POItemBalance_FWP")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0019"

    Function SCMRT0019()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0019.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_SRBalance()
        Dim dsRPT_PORCVD As New ReportDataSource("Rpt_SRItemBalance", dsSCMRTDataSet.Tables("Rpt_SRItemBalance"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PORCVD)
        'report

    End Function

    Private Function RPT_SRBalance() As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_SRItemBalance")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_SRItemBalance")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0020"

    Function SCMRT0020()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0020.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_SRBalanceNonOSM()
        Dim dsRPT_PORCVD As New ReportDataSource("Rpt_SRItemBalanceNonOSM", dsSCMRTDataSet.Tables("Rpt_SRItemBalanceNonOSM"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PORCVD)
        'report

    End Function

    Private Function RPT_SRBalanceNonOSM() As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_SRItemBalanceNonOSM")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_SRItemBalanceNonOSM")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0021"

    Function SCMRT0021()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0021.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = RPT_GPItemBalance()
        Dim dsRPT_PORCVD As New ReportDataSource("Rpt_GPItemBalance", dsSCMRTDataSet.Tables("Rpt_GPItemBalance"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PORCVD)
        'report

    End Function

    Private Function RPT_GPItemBalance() As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_GPItemBalance")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_GPItemBalance")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0022"

    Function SCMRT0022()

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0022.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = Rpt_WTBalance()
        Dim dsRPT_WTBal As New ReportDataSource("Rpt_WTBalance", dsSCMRTDataSet.Tables("Rpt_WTBalance"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_WTBal)
        'report

    End Function

    Private Function Rpt_WTBalance() As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_WTBalance")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_WTBalance")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0023"
    Function SCMRT0023()

        'parameter
        Dim pBatch = HttpUtility.UrlDecode(Request.QueryString("pBatch"))
        Dim pType = HttpUtility.UrlDecode(Request.QueryString("pType"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0023.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = Rpt_CostEstimateWBS(pBatch, pType)
        Dim dsRPT_CostEstimateWBS As New ReportDataSource("Rpt_CostEstimateWBS", dsSCMRTDataSet.Tables("Rpt_CostEstimateWBS"))
        Dim _BatchNo As New ReportParameter("pBatch", pBatch)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_BatchNo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_CostEstimateWBS)

    End Function

    Private Function Rpt_CostEstimateWBS(pBatch, pType) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_CostEstimateWBS")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 0 '
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pCECode", pBatch)
                sqlCmd.Parameters.AddWithValue("@pType", pType)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_CostEstimateWBS")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "SCMRT0024"
    Function SCMRT0024()

        'parameter
        Dim pBatch = HttpUtility.UrlDecode(Request.QueryString("pBatch"))
        Dim pType = HttpUtility.UrlDecode(Request.QueryString("pType"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/SCMRT0024.rdlc")
        Dim dsSCMRTDataSet As SCMRTDataSet = Rpt_CESummary(pBatch, pType)
        Dim dsRPT_CESummary As New ReportDataSource("Rpt_CESummary", dsSCMRTDataSet.Tables("Rpt_CESummary"))
        Dim _BatchNo As New ReportParameter("pBatch", pBatch)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_BatchNo})
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_CESummary)

    End Function

    Private Function Rpt_CESummary(pBatch, pType) As SCMRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_CESummary")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 0 '
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pBatch", pBatch)
                sqlCmd.Parameters.AddWithValue("@pType", pType)
                sqlSda.SelectCommand = sqlCmd
                Using dsSCMRTDataSet As New SCMRTDataSet
                    sqlSda.Fill(dsSCMRTDataSet, "Rpt_CESummary")
                    Return dsSCMRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

End Class