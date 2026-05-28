Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Reflection.Emit
Imports Microsoft.Reporting.WebForms


Public Class ENGRTView
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim cldc_live_acc As String = "cldc_live_acc"
    Dim calmardbLive As String = "calmardbLive"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
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

            If FormCode = "ENGRT0001" Then
                ENGRT0001()
            End If
            If FormCode = "ENGRT0002" Then
                ENGRT0002()
            End If
            If FormCode = "ENGRT0003" Then
                ENGRT0003()
            End If
            If FormCode = "ENGRT0004" Then
                ENGRT0004()
            End If
            If FormCode = "ENGRT0005" Then
                ENGRT0005()
            End If
            If FormCode = "ENGRT0006" Then
                ENGRT0006()
            End If
            If FormCode = "ENGRT0007" Then
                ENGRT0007()
            End If
            If FormCode = "ENGRT0008" Then
                ENGRT0008()
            End If
            If FormCode = "ENGRT0009" Then
                ENGRT0009()
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

#Region "ENGRT0001"

    Function ENGRT0001()

        ' 'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
        End If
        'create new folder

        'remove file within the folder
        Dim RptFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
        Try
            Dim file As FileInfo
            For Each file In RptFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file within the folder

        'copy template report
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/ENGRT0001.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0001.rdlc"))
        'copy template report

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0001.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_OSMM()
        Dim dsRPT_OSMM As New ReportDataSource("OSMM", dsENGRTDataSet.Tables(0))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_OSMM)
        'report

    End Function

    Private Function RPT_OSMM() As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_OSMMaterialMonitoring")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "Rpt_OSMMaterialMonitoring")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0002"

    Function ENGRT0002()

        'parameter
        Dim pBatchNo = HttpUtility.UrlDecode(Request.QueryString("pBatchNo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0002.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_BatchM(pBatchNo)
        Dim dsRPT_BatchM As New ReportDataSource("BatchM", dsENGRTDataSet.Tables("Rpt_BatchMonitoring"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_BatchM)
        'report

    End Function

    Private Function RPT_BatchM(pBatchNo) As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_BatchMonitoring")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pBatchNo", pBatchNo)
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "Rpt_BatchMonitoring")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0003"

    Function ENGRT0003()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        Dim pStatus = HttpUtility.UrlDecode(Request.QueryString("pStatus"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0003.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_BatchM(pDateFrom, pDateTo, pStatus)
        Dim dsRPT_CODFM As New ReportDataSource("CODFM", dsENGRTDataSet.Tables("Rpt_CODFormMonitoring"))

        Dim _DateFrom As New ReportParameter("DateFrom", CDate(pDateFrom))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("DateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_CODFM)
        'report

    End Function

    Private Function RPT_BatchM(pDateFrom, pDateTo, pStatus) As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_CODFormMonitoring")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "Rpt_CODFormMonitoring")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0004"

    Function ENGRT0004()

        'parameter
        Dim pBatchNo = HttpUtility.UrlDecode(Request.QueryString("pBatchNo"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0004.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_BillingM(pBatchNo)
        Dim dsRPT_BillingM As New ReportDataSource("BillingM", dsENGRTDataSet.Tables("Rpt_BillingMonitoring"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_BillingM)
        'report

    End Function

    Private Function RPT_BillingM(pBatchNo) As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_BillingMonitoring")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pBatchNo", pBatchNo)
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "Rpt_BillingMonitoring")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0005"

    Function ENGRT0005()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))

        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0005.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_DCR(pDateFrom, pDateTo)
        Dim dsRPT_DCR As New ReportDataSource("DCR", dsENGRTDataSet.Tables("JCF_RptDailyCollection"))

        Dim _DateFrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("DateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_DCR)
        'report

    End Function

    Private Function RPT_DCR(pDateFrom, pDateTo) As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptDailyCollection")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "JCF_RptDailyCollection")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0006"

    Function ENGRT0006()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        Dim pStatus = HttpUtility.UrlDecode(Request.QueryString("pStatus"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0006.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_SRFCRFCCFM(pDateFrom, pDateTo, pStatus)
        Dim dsRPT_SRFCRFCCFM As New ReportDataSource("SRFCRFCCFM", dsENGRTDataSet.Tables("Rpt_PMDFormMonitoring"))

        Dim _DateFrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("DateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_SRFCRFCCFM)
        'report

    End Function

    Private Function RPT_SRFCRFCCFM(pDateFrom, pDateTo, pStatus) As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_PMDFormMonitoring")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "Rpt_PMDFormMonitoring")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0007"

    Function ENGRT0007()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        Dim pStatus = HttpUtility.UrlDecode(Request.QueryString("pStatus"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0007.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_OCESCWSC(pDateFrom, pDateTo, pStatus)
        Dim dsRPT_OCESCWSC As New ReportDataSource("OCESCWSC", dsENGRTDataSet.Tables("Rpt_OCEECSWCSMonitoring"))

        Dim _DateFrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("DateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_OCESCWSC)
        'report

    End Function

    Private Function RPT_OCESCWSC(pDateFrom, pDateTo, pStatus) As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_OCEECSWCSMonitoring")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "Rpt_OCEECSWCSMonitoring")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0008"

    Function ENGRT0008()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))
        Dim pStatus = HttpUtility.UrlDecode(Request.QueryString("pStatus"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0008.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_AAA(pDateFrom, pDateTo, pStatus)
        Dim dsRPT_AAA As New ReportDataSource("AAA", dsENGRTDataSet.Tables("Rpt_AAASMonitoring"))

        Dim _DateFrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDateFrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateFrom})
        Dim _DateTo As New ReportParameter("DateTo", DateTime.ParseExact(pDateTo, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_DateTo})

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_AAA)
        'report

    End Function

    Private Function RPT_AAA(pDateFrom, pDateTo, pStatus) As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("Rpt_AAASMonitoring")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "Rpt_AAASMonitoring")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "ENGRT0009"

    Function ENGRT0009()

        ' 'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
        End If
        'create new folder

        'remove file within the folder
        Dim RptFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/"))
        Try
            Dim file As FileInfo
            For Each file In RptFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file within the folder

        'copy template report
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/ENGRT0009.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0009.rdlc"))
        'copy template report

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/ENGRT0009.rdlc")
        Dim dsENGRTDataSet As ENGRTDataSet = RPT_RFOM()
        Dim dsRPT_RFOM As New ReportDataSource("RFOM", dsENGRTDataSet.Tables("JCF_RptRFO"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_RFOM)
        'report

    End Function

    Private Function RPT_RFOM() As ENGRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptRFO")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlSda.SelectCommand = sqlCmd
                Using dsENGRTDataSet As New ENGRTDataSet
                    sqlSda.Fill(dsENGRTDataSet, "JCF_RptRFO")
                    Return dsENGRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

End Class