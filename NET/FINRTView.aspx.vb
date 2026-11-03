Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Net.PeerToPeer.Collaboration
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports Microsoft.Reporting.WebForms
Imports NET.FINRTDatasetTableAdapters

Public Class FINRTView1
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

            If FormCode = "FINRT0001" Then
                FINRT0001()
            End If
            If FormCode = "FINRT0004" Then
                FINRT0004()
            End If
            If FormCode = "FINRT0005" Then
                FINRT0005()
            End If
            If FormCode = "FINRT0008" Then
                FINRT0008()
            End If
            If FormCode = "FINRT0009" Then
                FINRT0009()
            End If
            If FormCode = "FINRT0013" Then
                FINRT0013()
            End If
            If FormCode = "FINRT0015" Then
                FINRT0015()
            End If
            If FormCode = "FINRT0016" Then
                FINRT0016()
            End If
            If FormCode = "FINRT0019" Then
                FINRT0019()
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

#Region "FINRT0001"

    Function FINRT0001()

        'parameter
        Dim pyear = HttpUtility.UrlDecode(Request.QueryString("pyear"))
        Dim pacct_from = HttpUtility.UrlDecode(Request.QueryString("pacct_from"))
        Dim pacct_to = HttpUtility.UrlDecode(Request.QueryString("pacct_to"))
        Dim pacct_srs = HttpUtility.UrlDecode(Request.QueryString("pacct_srs"))
        Dim pdiv_from = HttpUtility.UrlDecode(Request.QueryString("pdiv_from"))
        Dim pdiv_to = HttpUtility.UrlDecode(Request.QueryString("pdiv_to"))
        Dim pdiv_srs = HttpUtility.UrlDecode(Request.QueryString("pdiv_srs"))
        Dim pdept_from = HttpUtility.UrlDecode(Request.QueryString("pdept_from"))
        Dim pdept_to = HttpUtility.UrlDecode(Request.QueryString("pdept_to"))
        Dim pdept_srs = HttpUtility.UrlDecode(Request.QueryString("pdept_srs"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0001.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = fin_rpt_glb_hdr(pyear, pacct_from, pacct_to, pacct_srs, pdiv_from, pdiv_to, pdiv_srs, pdept_from, pdept_to, pdept_srs) 'fill data set
        Dim dsfin_rpt_glb_hdr As New ReportDataSource("GLB", dsFINRTDataset.Tables("fin_rpt_glb_hdr")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsfin_rpt_glb_hdr)
        'report

    End Function

    Private Function fin_rpt_glb_hdr(pyear, pacct_from, pacct_to, pacct_srs, pdiv_from, pdiv_to, pdiv_srs, pdept_from, pdept_to, pdept_srs) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_glb_hdr") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pyear", pyear)
                sqlCmd.Parameters.AddWithValue("@pacct_from", pacct_from)
                sqlCmd.Parameters.AddWithValue("@pacct_to", pacct_to)
                sqlCmd.Parameters.AddWithValue("@pacct_srs", pacct_srs)
                sqlCmd.Parameters.AddWithValue("@pdiv_from", pdiv_from)
                sqlCmd.Parameters.AddWithValue("@pdiv_to", pdiv_to)
                sqlCmd.Parameters.AddWithValue("@pdiv_srs", pdiv_srs)
                sqlCmd.Parameters.AddWithValue("@pdept_from", pdept_from)
                sqlCmd.Parameters.AddWithValue("@pdept_to", pdept_to)
                sqlCmd.Parameters.AddWithValue("@pdept_srs", pdept_srs)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_glb_hdr") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function

    Private Function fin_rpt_glb_dtl(pyear, pperiod_from, pperiod_to, pacct_from, pacct_to, pacct_srs, pdiv_from, pdiv_to, pdiv_srs, pdept_from, pdept_to, pdept_srs) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_glb_dtl") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pyear", pyear)
                sqlCmd.Parameters.AddWithValue("@pperiod_from", pperiod_from)
                sqlCmd.Parameters.AddWithValue("@pperiod_to", pperiod_to)
                sqlCmd.Parameters.AddWithValue("@pacct_from", pacct_from)
                sqlCmd.Parameters.AddWithValue("@pacct_to", pacct_to)
                sqlCmd.Parameters.AddWithValue("@pacct_srs", pacct_srs)
                sqlCmd.Parameters.AddWithValue("@pdiv_from", pdiv_from)
                sqlCmd.Parameters.AddWithValue("@pdiv_to", pdiv_to)
                sqlCmd.Parameters.AddWithValue("@pdiv_srs", pdiv_srs)
                sqlCmd.Parameters.AddWithValue("@pdept_from", pdept_from)
                sqlCmd.Parameters.AddWithValue("@pdept_to", pdept_to)
                sqlCmd.Parameters.AddWithValue("@pdept_srs", pdept_srs)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_glb_dtl") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function

    Private Function fin_rpt_je(trx_group) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_je") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlCmd.Parameters.AddWithValue("@trx_group", trx_group)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_je") 'table adapter name
                    Return dsFINRTDataset
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
        For Each ParmInfo In ParmClx
            If ParmInfo.Name = "Period" Then

                'parameter
                Dim pyear = HttpUtility.UrlDecode(Request.QueryString("pyear"))
                Dim pperiod_from = ParmInfo.Values(0).ToString
                Dim pperiod_to = ParmInfo.Values(0).ToString
                Dim pacct_from = HttpUtility.UrlDecode(Request.QueryString("pacct_from"))
                Dim pacct_to = HttpUtility.UrlDecode(Request.QueryString("pacct_to"))
                Dim pacct_srs = HttpUtility.UrlDecode(Request.QueryString("pacct_srs"))
                Dim pdiv_from = HttpUtility.UrlDecode(Request.QueryString("pdiv_from"))
                Dim pdiv_to = HttpUtility.UrlDecode(Request.QueryString("pdiv_to"))
                Dim pdiv_srs = HttpUtility.UrlDecode(Request.QueryString("pdiv_srs"))
                Dim pdept_from = HttpUtility.UrlDecode(Request.QueryString("pdept_from"))
                Dim pdept_to = HttpUtility.UrlDecode(Request.QueryString("pdept_to"))
                Dim pdept_srs = HttpUtility.UrlDecode(Request.QueryString("pdept_srs"))
                'parameter

                'report
                Dim SubReport As LocalReport
                SubReport = e.Report
                SubReport.DataSources.Clear()
                Dim dsFINRTDataset As FINRTDataset = fin_rpt_glb_dtl(pyear, pperiod_from, pperiod_to, pacct_from, pacct_to, pacct_srs, pdiv_from, pdiv_to, pdiv_srs, pdept_from, pdept_to, pdept_srs) 'fill data set
                Dim dsfin_rpt_glb_dtl As New ReportDataSource("GLB_detail", dsFINRTDataset.Tables("fin_rpt_glb_dtl")) 'rdlc dataset name
                SubReport.DataSources.Add(dsfin_rpt_glb_dtl)
                'report

            End If
            If ParmInfo.Name = "Trx_group" Then

                'parameter
                Dim Trx_group = ParmInfo.Values(0).ToString
                'parameter

                'report
                Dim SubReport As LocalReport
                SubReport = e.Report
                SubReport.DataSources.Clear()
                Dim dsFINRTDataset As FINRTDataset = fin_rpt_je(Trx_group) 'fill data set
                Dim dsfin_rpt_je As New ReportDataSource("JE", dsFINRTDataset.Tables("fin_rpt_je")) 'rdlc dataset name
                SubReport.DataSources.Add(dsfin_rpt_je)
                'report

            End If
        Next
    End Sub

#End Region

#Region "FINRT0004"

    Function FINRT0004()

        'parameter
        Dim pyear = HttpUtility.UrlDecode(Request.QueryString("pyear"))
        Dim pperiod = HttpUtility.UrlDecode(Request.QueryString("pperiod"))

        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0004.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = fin_rpt_scit(pyear, pperiod) 'fill data set
        Dim dsfin_rpt_scit As New ReportDataSource("SCIT", dsFINRTDataset.Tables("fin_rpt_scit")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True

        Dim _pyear As New ReportParameter("Year", pyear)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pyear})
        Dim _pperiod As New ReportParameter("Month", pperiod)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pperiod})



        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsfin_rpt_scit)
        'report

    End Function


    Private Function fin_rpt_scit(pyear, pperiod) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_scit") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pyear", pyear)
                sqlCmd.Parameters.AddWithValue("@pperiod", pperiod)


                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_scit") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function
#End Region

#Region "FINRT0005"

    Function FINRT0005()

        'parameter
        Dim pyear = HttpUtility.UrlDecode(Request.QueryString("pyear"))
        Dim pperiod = HttpUtility.UrlDecode(Request.QueryString("pperiod"))

        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0005.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = fin_rpt_swte(pyear, pperiod) 'fill data set
        Dim dsfin_rpt_swte As New ReportDataSource("SWTE", dsFINRTDataset.Tables("fin_rpt_swte")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True

        Dim _pyear As New ReportParameter("Year", pyear)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pyear})
        Dim _pperiod As New ReportParameter("Month", pperiod)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pperiod})



        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsfin_rpt_swte)
        'report

    End Function


    Private Function fin_rpt_swte(pyear, pperiod) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_swte") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pyear", pyear)
                sqlCmd.Parameters.AddWithValue("@pperiod", pperiod)


                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_swte") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function
#End Region

#Region "FINRT0008"

    Function FINRT0008()

        'create new folder
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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/FINRT0008.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0008.rdlc"))
        'copy template report



        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0008.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = fin_rpt_CA() 'fill data set
        Dim dsfin_rpt_CA As New ReportDataSource("CAL", dsFINRTDataset.Tables("fin_rpt_CA")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True





        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsfin_rpt_CA)
        'report

    End Function


    Private Function fin_rpt_CA() As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_CA") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_CA") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function
#End Region

#Region "FINRT0009"

    Function FINRT0009()

        'parameter
        Dim pDateFrom = HttpUtility.UrlDecode(Request.QueryString("pDateFrom"))
        Dim pDateTo = HttpUtility.UrlDecode(Request.QueryString("pDateTo"))


        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0009.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = Rpt_CAPEXMonitoring(pDateFrom, pDateTo) 'fill data set
        Dim dsRpt_CAPEXMonitoring As New ReportDataSource("CAPEX", dsFINRTDataset.Tables("Rpt_CAPEXMonitoring")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True



        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRpt_CAPEXMonitoring)
        'report

    End Function


    Private Function Rpt_CAPEXMonitoring(pDateFrom, pDateTo) As FINRTDataset
        Dim sqlCmd As New SqlCommand("Rpt_CAPEXMonitoring") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "Rpt_CAPEXMonitoring") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function
#End Region

#Region "FINRT0013"

    Function FINRT0013()

        'parameter
        Dim pSubd = HttpUtility.UrlDecode(Request.QueryString("pSubd"))
        Dim pPhase = HttpUtility.UrlDecode(Request.QueryString("pPhase"))
        Dim pBlock = HttpUtility.UrlDecode(Request.QueryString("pBlock"))
        Dim pLot = HttpUtility.UrlDecode(Request.QueryString("pLot"))


        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0013.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = Rpt_IncRec(pSubd, pPhase, pBlock, pLot) 'fill data set
        Dim dsRpt_IncRec As New ReportDataSource("IR", dsFINRTDataset.Tables("Rpt_IncRec")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True



        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRpt_IncRec)
        'report

    End Function


    Private Function Rpt_IncRec(pSubd, pPhase, pBlock, pLot) As FINRTDataset
        Dim sqlCmd As New SqlCommand("Rpt_IncRec") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pSubd", pSubd)
                sqlCmd.Parameters.AddWithValue("@pPhase", pPhase)
                sqlCmd.Parameters.AddWithValue("@pBlock", pBlock)
                sqlCmd.Parameters.AddWithValue("@pLot", pLot)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "Rpt_IncRec") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function



#End Region

#Region "FINRT0015"

    Function FINRT0015()

        'parameter
        Dim pDate = HttpUtility.UrlDecode(Request.QueryString("pDate"))


        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0015.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = Rpt_CAAging(pDate) 'fill data set
        Dim dsRpt_CAAging As New ReportDataSource("CAAging", dsFINRTDataset.Tables("Rpt_CAAging")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True

        Dim _pDate As New ReportParameter("Date", DateTime.ParseExact(pDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDate})

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRpt_CAAging)
        'report

    End Function


    Private Function Rpt_CAAging(pDate) As FINRTDataset
        Dim sqlCmd As New SqlCommand("Rpt_CAAging") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDate", pDate)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "Rpt_CAAging") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function



#End Region

#Region "FINRT0016"

    Function FINRT0016()

        'parameter
        Dim ptype = HttpUtility.UrlDecode(Request.QueryString("pType"))
        Dim pDate = HttpUtility.UrlDecode(Request.QueryString("pDate"))
        Dim pcrdtr_type = HttpUtility.UrlDecode(Request.QueryString("pcrdtr_type"))
        Dim pcrdtr_code = HttpUtility.UrlDecode(Request.QueryString("pcrdtr_code"))

        'parameter

        If ptype = "Detailed" Then

            'report
            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0016.rdlc") 'rdlc name
            Dim dsFINRTDataset As FINRTDataset = fin_rpt_apa(pDate, pcrdtr_type, pcrdtr_code) 'fill data set
            Dim dsfin_rpt_apa As New ReportDataSource("APA", dsFINRTDataset.Tables("fin_rpt_apa")) 'rdlc dataset name
            ReportViewer1.LocalReport.EnableHyperlinks = True

            Dim _pDate As New ReportParameter("Date", DateTime.ParseExact(pDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
            ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDate})

            ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
            ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(dsfin_rpt_apa)
            'report


        ElseIf ptype = "Summary" Then

            'report
            ReportViewer1.ProcessingMode = ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0017.rdlc") 'rdlc name
            Dim dsFINRTDataset As FINRTDataset = fin_rpt_apa(pDate, pcrdtr_type, pcrdtr_code) 'fill data set
            Dim dsfin_rpt_apa As New ReportDataSource("APA", dsFINRTDataset.Tables("fin_rpt_apa")) 'rdlc dataset name
            ReportViewer1.LocalReport.EnableHyperlinks = True

            Dim _pDate As New ReportParameter("Date", DateTime.ParseExact(pDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
            ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDate})

            ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
            ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(dsfin_rpt_apa)
            'report

        End If

    End Function


    Private Function fin_rpt_apa(pDate, pcrdtr_type, pcrdtr_code) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_apa") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDate", pDate)
                sqlCmd.Parameters.AddWithValue("@pcrdtr_type", pcrdtr_type)
                sqlCmd.Parameters.AddWithValue("@pcrdtr_code", pcrdtr_code)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_apa") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function






#End Region

#Region "FINRT0019"

    Function FINRT0019()

        'parameter
        Dim pclear = HttpUtility.UrlDecode(Request.QueryString("pclear"))
        Dim pacct = HttpUtility.UrlDecode(Request.QueryString("pacct"))
        Dim pyear_from = HttpUtility.UrlDecode(Request.QueryString("pyear_from"))
        Dim pyear_to = HttpUtility.UrlDecode(Request.QueryString("pyear_to"))
        Dim pyear_srs = HttpUtility.UrlDecode(Request.QueryString("pyear_srs"))
        Dim pperiod_from = HttpUtility.UrlDecode(Request.QueryString("pperiod_from"))
        Dim pperiod_to = HttpUtility.UrlDecode(Request.QueryString("pperiod_to"))
        Dim pperiod_srs = HttpUtility.UrlDecode(Request.QueryString("pperiod_srs"))
        Dim psub_from = HttpUtility.UrlDecode(Request.QueryString("psub_from"))
        Dim psub_to = HttpUtility.UrlDecode(Request.QueryString("psub_to"))
        Dim psub_srs = HttpUtility.UrlDecode(Request.QueryString("psub_srs"))
        Dim pdiv_from = HttpUtility.UrlDecode(Request.QueryString("pdiv_from"))
        Dim pdiv_to = HttpUtility.UrlDecode(Request.QueryString("pdiv_to"))
        Dim pdiv_srs = HttpUtility.UrlDecode(Request.QueryString("pdiv_srs"))
        Dim pdept_from = HttpUtility.UrlDecode(Request.QueryString("pdept_from"))
        Dim pdept_to = HttpUtility.UrlDecode(Request.QueryString("pdept_to"))
        Dim pdept_srs = HttpUtility.UrlDecode(Request.QueryString("pdept_srs"))
        Dim pjtype_from = HttpUtility.UrlDecode(Request.QueryString("pjtype_from"))
        Dim pjtype_to = HttpUtility.UrlDecode(Request.QueryString("pjtype_to"))
        Dim pjtype_srs = HttpUtility.UrlDecode(Request.QueryString("pjtype_srs"))
        Dim pjdate_from = HttpUtility.UrlDecode(Request.QueryString("pjdate_from"))
        Dim pjdate_to = HttpUtility.UrlDecode(Request.QueryString("pjdate_to"))
        Dim pref_from = HttpUtility.UrlDecode(Request.QueryString("pref_from"))
        Dim pref_to = HttpUtility.UrlDecode(Request.QueryString("pref_to"))
        Dim jdesc = HttpUtility.UrlDecode(Request.QueryString("jdesc"))
        Dim pdebit_from = HttpUtility.UrlDecode(Request.QueryString("pdebit_from"))
        Dim pdebit_to = HttpUtility.UrlDecode(Request.QueryString("pdebit_to"))
        Dim pcredit_from = HttpUtility.UrlDecode(Request.QueryString("pcredit_from"))
        Dim pcredit_to = HttpUtility.UrlDecode(Request.QueryString("pcredit_to"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/FINRT0019.rdlc") 'rdlc name
        Dim dsFINRTDataset As FINRTDataset = fin_rpt_sld(pclear, pacct, pyear_from, pyear_to, pyear_srs, pperiod_from, pperiod_to, pperiod_srs, psub_from, psub_to, psub_srs, pdiv_from, pdiv_to, pdiv_srs, pdept_from, pdept_to, pdept_srs, pjtype_from, pjtype_to, pjtype_srs, pjdate_from, pjdate_to, pref_from, pref_to, jdesc, pdebit_from, pdebit_to, pcredit_from, pcredit_to) 'fill data set
        Dim dsfin_rpt_sld As New ReportDataSource("SLD", dsFINRTDataset.Tables("fin_rpt_sld")) 'rdlc dataset name
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsfin_rpt_sld)
        'report

    End Function
    Private Function fin_rpt_sld(pclear, pacct, pyear_from, pyear_to, pyear_srs, pperiod_from, pperiod_to, pperiod_srs, psub_from, psub_to, psub_srs, pdiv_from, pdiv_to, pdiv_srs, pdept_from, pdept_to, pdept_srs, pjtype_from, pjtype_to, pjtype_srs, pjdate_from, pjdate_to, pref_from, pref_to, jdesc, pdebit_from, pdebit_to, pcredit_from, pcredit_to) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_sld") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pclear", pclear)
                sqlCmd.Parameters.AddWithValue("@pacct", pacct)
                sqlCmd.Parameters.AddWithValue("@pyear_from", pyear_from)
                sqlCmd.Parameters.AddWithValue("@pyear_to", pyear_to)
                sqlCmd.Parameters.AddWithValue("@pyear_srs", pyear_srs)
                sqlCmd.Parameters.AddWithValue("@pperiod_from", pperiod_from)
                sqlCmd.Parameters.AddWithValue("@pperiod_to", pperiod_to)
                sqlCmd.Parameters.AddWithValue("@pperiod_srs", pperiod_srs)
                sqlCmd.Parameters.AddWithValue("@psub_from", psub_from)
                sqlCmd.Parameters.AddWithValue("@psub_to", psub_to)
                sqlCmd.Parameters.AddWithValue("@psub_srs", psub_srs)
                sqlCmd.Parameters.AddWithValue("@pdiv_from", pdiv_from)
                sqlCmd.Parameters.AddWithValue("@pdiv_to", pdiv_to)
                sqlCmd.Parameters.AddWithValue("@pdiv_srs", pdiv_srs)
                sqlCmd.Parameters.AddWithValue("@pdept_from", pdept_from)
                sqlCmd.Parameters.AddWithValue("@pdept_to", pdept_to)
                sqlCmd.Parameters.AddWithValue("@pdept_srs", pdept_srs)
                sqlCmd.Parameters.AddWithValue("@pjtype_from", pjtype_from)
                sqlCmd.Parameters.AddWithValue("@pjtype_to", pjtype_to)
                sqlCmd.Parameters.AddWithValue("@pjtype_srs", pjtype_srs)
                sqlCmd.Parameters.AddWithValue("@pjdate_from", pjdate_from)
                sqlCmd.Parameters.AddWithValue("@pjdate_to", pjdate_to)
                sqlCmd.Parameters.AddWithValue("@pref_from", pref_from)
                sqlCmd.Parameters.AddWithValue("@pref_to", pref_to)
                sqlCmd.Parameters.AddWithValue("@jdesc", jdesc)
                sqlCmd.Parameters.AddWithValue("@pdebit_from", pdebit_from)
                sqlCmd.Parameters.AddWithValue("@pdebit_to", pdebit_to)
                sqlCmd.Parameters.AddWithValue("@pcredit_from", pcredit_from)
                sqlCmd.Parameters.AddWithValue("@pcredit_to", pcredit_to)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_sld") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function

    Private Function fin_rpt_je1(trx_group) As FINRTDataset
        Dim sqlCmd As New SqlCommand("fin_rpt_je") 'Procedure Name
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlCmd.Parameters.AddWithValue("@trx_group", trx_group)
                sqlSda.SelectCommand = sqlCmd
                Using dsFINRTDataset As New FINRTDataset
                    sqlSda.Fill(dsFINRTDataset, "fin_rpt_je") 'table adapter name
                    Return dsFINRTDataset
                End Using
            End Using
        End Using

    End Function

    ''report drill through
    Private Sub ReportViewer1_Drillthrough2(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.DrillthroughEventArgs) Handles ReportViewer1.Drillthrough

        'Get Parameter - general ledger balance
        Dim ParmClx As ReportParameterInfoCollection
        Dim ParmInfo As ReportParameterInfo
        ParmClx = e.Report.GetParameters
        For Each ParmInfo In ParmClx
            If ParmInfo.Name = "Trx_group" Then

                'parameter
                Dim Trx_group = ParmInfo.Values(0).ToString
                'parameter

                'report
                Dim SubReport As LocalReport
                SubReport = e.Report
                SubReport.DataSources.Clear()
                Dim dsFINRTDataset As FINRTDataset = fin_rpt_je1(Trx_group) 'fill data set
                Dim dsfin_rpt_je As New ReportDataSource("JE", dsFINRTDataset.Tables("fin_rpt_je")) 'rdlc dataset name
                SubReport.DataSources.Add(dsfin_rpt_je)
                'report

            End If
        Next
    End Sub

#End Region

End Class