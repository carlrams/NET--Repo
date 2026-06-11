Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Reflection.Emit
Imports Microsoft.Reporting.WebForms

Public Class PDDRTView
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim cldc_live_acc As String = "cldc_live_acc"
    Dim calmardbLive As String = "calmardbLive"
    Dim UserID As String = "ciisv2"
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

            If FormCode = "PDDRT0001" Then
                PDDRT0001()
                Exit Sub
            ElseIf FormCode = "PDDRT0002" Then
                PDDRT0002()
                Exit Sub
            ElseIf FormCode = "PDDRT0003" Then
                PDDRT0003()
                Exit Sub
            ElseIf FormCode = "PDDRT0004" Then
                Exit Sub
            ElseIf FormCode = "PDDRT0005" Then
                PDDRT0005()
                Exit Sub
            ElseIf FormCode = "PDDRT0006" Then
                PDDRT0006()
                Exit Sub
            ElseIf FormCode = "PDDRT0007" Then
                PDDRT0007()
                Exit Sub
            ElseIf FormCode = "PDDRT0008" Then
                PDDRT0008()
                Exit Sub
            ElseIf FormCode = "PDDRT0009" Then
                PDDRT0009()
                Exit Sub
            ElseIf FormCode = "PDDRT0010" Then
                PDDRT0010()
                Exit Sub
            ElseIf FormCode = "PDDRT0011" Then
                PDDRT0011()
                Exit Sub
            ElseIf FormCode = "PDDRT0012" Then
                PDDRT0012()
                Exit Sub
            ElseIf FormCode = "PDDRT0013" Then
                PDDRT0013()
                Exit Sub
            ElseIf FormCode = "PDDRT0014" Then
                PDDRT0014()
                Exit Sub
            ElseIf FormCode = "PDDRT0015" Then
                PDDRT0015()
                Exit Sub
            ElseIf FormCode = "PDDRT0016" Then
                PDDRT0016()
                Exit Sub
            ElseIf FormCode = "PDDRT0017" Then
                PDDRT0017()
                Exit Sub
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

#Region "PDDRT0001"

    Function PDDRT0001()

        'parameter
        Dim pTerritory = HttpUtility.UrlDecode(Request.QueryString("pTerritory"))
        Dim pNotForSale = HttpUtility.UrlDecode(Request.QueryString("pNotForSale"))
        Dim pOpen = HttpUtility.UrlDecode(Request.QueryString("pOpen"))
        Dim pHold = HttpUtility.UrlDecode(Request.QueryString("pHold"))
        Dim pSold = HttpUtility.UrlDecode(Request.QueryString("pSold"))
        Dim pSubd = HttpUtility.UrlDecode(Request.QueryString("pSubd"))
        Dim pPhase = HttpUtility.UrlDecode(Request.QueryString("pPhase"))
        Dim pBlock = HttpUtility.UrlDecode(Request.QueryString("pBlock"))
        Dim pLot = HttpUtility.UrlDecode(Request.QueryString("pLot"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/LI.rdlc")
        Dim dsPDDRTDataSet As PDDRTDataSet = RPT_LI(pTerritory, pNotForSale, pOpen, pHold, pSold, pSubd, pPhase, pBlock, pLot)
        Dim dsRPT_LI As New ReportDataSource("LI", dsPDDRTDataSet.Tables(0))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_LI)
        'report

    End Function



    Private Function RPT_LI(pTerritory, pNotForSale, pOpen, pHold, pSold, pSubd, pPhase, pBlock, pLot) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptLotInventory")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pTerritory", pTerritory)
                sqlCmd.Parameters.AddWithValue("@pNotForSale", pNotForSale)
                sqlCmd.Parameters.AddWithValue("@pOpen", pOpen)
                sqlCmd.Parameters.AddWithValue("@pHold", pHold)
                sqlCmd.Parameters.AddWithValue("@pSold", pSold)
                sqlCmd.Parameters.AddWithValue("@pSubd", pSubd)
                sqlCmd.Parameters.AddWithValue("@pPhase", pPhase)
                sqlCmd.Parameters.AddWithValue("@pBlock", pBlock)
                sqlCmd.Parameters.AddWithValue("@pLot", pLot)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "RPT_LI")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "PDDRT0002"

    Function PDDRT0002()

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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/PDDRT0002.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0002.rdlc"))
        'copy template report

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0002.rdlc")
        Dim dsPDDRTDataSet As PDDRTDataSet = RPT_OIS()
        Dim dsRPT_OIS As New ReportDataSource("OIS", dsPDDRTDataSet.Tables("JCF_RptOverallInventory"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_OIS)
        'report

    End Function

    Private Function RPT_OIS() As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptOverallInventory")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptOverallInventory")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "PDDRT0003"
    Function PDDRT0003()

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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/PDDRT0003.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0003.rdlc"))
        'copy template report



        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0003.rdlc")
        Dim dsPDDRTDataSet As PDDRTDataSet = RPT_HUB()
        Dim dsRPT_HUB As New ReportDataSource("HUB", dsPDDRTDataSet.Tables("JCF_RptHoldUnitsBreakdown"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_HUB)
        'report

    End Function



    Private Function RPT_HUB() As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptHoldUnitsBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptHoldUnitsBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "PDDRT0004"
    Function PDDRT0004()

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
        System.IO.File.Copy(Server.MapPath("~/Assets/RDLC/PDDRT0004.rdlc"), Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0004.rdlc"))
        'copy template report



        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0004.rdlc")
        Dim dsPDDRTDataSet As PDDRTDataSet = RPT_OO()
        Dim dsRPT_OO As New ReportDataSource("OO", dsPDDRTDataSet.Tables("JCF_RptOverallOpen"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_OO)
        'report

    End Function



    Private Function RPT_OO() As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptOverallOpen")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.CommandTimeout = 180000
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptOverallOpen")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "PDDRT0005"

    Function PDDRT0005()

        'parameter
        Dim pYear = HttpUtility.UrlDecode(Request.QueryString("pYear"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0005.rdlc")
        Dim dsPDDRTDataSet As PDDRTDataSet = RPT_AS(pYear)
        Dim dsRPT_AS As New ReportDataSource("AS", dsPDDRTDataSet.Tables("JCF_RptActualSale"))

        Dim _Year As New ReportParameter("Year", pYear.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Year})

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_AS)
        'report

    End Function



    Private Function RPT_AS(pYear) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptActualSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptActualSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "PDDRT0006"

    Function PDDRT0006()

        'parameter
        Dim pYear = HttpUtility.UrlDecode(Request.QueryString("pYear"))
        Dim pType = HttpUtility.UrlDecode(Request.QueryString("pType"))

        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0006.rdlc")
        Dim dsPDDRTDataSet_LO As PDDRTDataSet = RPT_TGS_LO(pYear, pType)
        Dim dsPDDRTDataSet_HL As PDDRTDataSet = RPT_TGS_HL(pYear, pType)
        Dim dsPDDRTDataSet_ALL As PDDRTDataSet = RPT_TGS_All(pYear, pType)


        Dim _Year As New ReportParameter("Year", pYear.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Year})


        Dim dsRPT_LO As New ReportDataSource("LO", dsPDDRTDataSet_LO.Tables("JCF_RptTotalGrossSale"))
        Dim dsRPT_HL As New ReportDataSource("HL", dsPDDRTDataSet_HL.Tables("JCF_RptTotalGrossSale"))
        Dim dsRPT_ALL As New ReportDataSource("All", dsPDDRTDataSet_ALL.Tables("JCF_RptTotalGrossSale"))

        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_LO)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_HL)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_ALL)
        'report

    End Function



    Private Function RPT_TGS_LO(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptTotalGrossSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "LO")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptTotalGrossSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function
    Private Function RPT_TGS_HL(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptTotalGrossSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "HL")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptTotalGrossSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

    Private Function RPT_TGS_All(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptTotalGrossSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "All")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptTotalGrossSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function



#End Region

#Region "PDDRT0007"

    Function PDDRT0007()

        'parameter
        Dim pYearto = HttpUtility.UrlDecode(Request.QueryString("pYearTo"))
        Dim pYearfrom = HttpUtility.UrlDecode(Request.QueryString("pYearfrom"))
        Dim pType = HttpUtility.UrlDecode(Request.QueryString("pType"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0007.rdlc")
        Dim dsPDDRTDataSet_UNIT As PDDRTDataSet = RPT_GS_UNIT(pYearto, pYearfrom, pType)
        Dim dsPDDRTDataSet_TCP As PDDRTDataSet = RPT_GS_TCP(pYearto, pYearfrom, pType)
        Dim dsPDDRTDataSet_AVG As PDDRTDataSet = RPT_GS_AVG(pYearto, pYearfrom, pType)
        Dim dsPDDRTDataSet_GROWTH As PDDRTDataSet = RPT_GS_GWORTH(pYearto, pYearfrom, pType)



        Dim dsRPT_UNIT As New ReportDataSource("Unit", dsPDDRTDataSet_UNIT.Tables("JCF_RptGrossSale"))
        Dim dsRPT_TCP As New ReportDataSource("TCP", dsPDDRTDataSet_TCP.Tables("JCF_RptGrossSale"))
        Dim dsRPT_AVG As New ReportDataSource("AVG", dsPDDRTDataSet_AVG.Tables("JCF_RptGrossSale"))
        Dim dsRPT_GROWTH As New ReportDataSource("Growth", dsPDDRTDataSet_GROWTH.Tables("JCF_RptGrossSale"))


        Dim _Yearfrom As New ReportParameter("From", pYearfrom.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Yearfrom})

        Dim _Yearto As New ReportParameter("To", pYearto.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Yearto})




        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_UNIT)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_TCP)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_AVG)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_GROWTH)
        'report


    End Function



    Private Function RPT_GS_UNIT(pYearto, pYearfrom, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYearFrom", pYearfrom)
                sqlCmd.Parameters.AddWithValue("@pYearTo", pYearto)
                sqlCmd.Parameters.AddWithValue("@pType", "Unit")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function


    Private Function RPT_GS_TCP(pYearto, pYearfrom, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYearFrom", pYearfrom)
                sqlCmd.Parameters.AddWithValue("@pYearTo", pYearto)
                sqlCmd.Parameters.AddWithValue("@pType", "TCP")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function


    Private Function RPT_GS_AVG(pYearto, pYearfrom, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYearfrom", pYearfrom)
                sqlCmd.Parameters.AddWithValue("@pYearTo", pYearto)
                sqlCmd.Parameters.AddWithValue("@pType", "AVG")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function


    Private Function RPT_GS_GWORTH(pYearto, pYearfrom, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYearfrom", pYearfrom)
                sqlCmd.Parameters.AddWithValue("@pYearTo", pYearto)
                sqlCmd.Parameters.AddWithValue("@pType ", "Growth")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function


#End Region

#Region "PDDRT0008"

    Function PDDRT0008()

        'parameter
        Dim pYear = HttpUtility.UrlDecode(Request.QueryString("pYear"))
        Dim pType = HttpUtility.UrlDecode(Request.QueryString("pType"))

        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0008.rdlc")
        Dim dsPDDRTDataSet_Total As PDDRTDataSet = RPT_HLGSB_TOTAL(pYear, pType)
        Dim dsPDDRTDataSet_RFOP As PDDRTDataSet = RPT_HLGSB_RFOP(pYear, pType)
        Dim dsPDDRTDataSet_RFOR As PDDRTDataSet = RPT_HLGSB_RFOR(pYear, pType)
        Dim dsPDDRTDataSet_NRFOP As PDDRTDataSet = RPT_HLGSB_NRFOP(pYear, pType)
        Dim dsPDDRTDataSet_NRFOR As PDDRTDataSet = RPT_HLGSB_NRFOR(pYear, pType)

        Dim dsRPT_TOTAL As New ReportDataSource("Total", dsPDDRTDataSet_Total.Tables("JCF_RptGrossSaleBreakdown"))
        Dim dsRPT_RFOP As New ReportDataSource("RFOP", dsPDDRTDataSet_RFOP.Tables("JCF_RptGrossSaleBreakdown"))
        Dim dsRPT_RFOR As New ReportDataSource("RFOR", dsPDDRTDataSet_RFOR.Tables("JCF_RptGrossSaleBreakdown"))
        Dim dsRPT_NRFOP As New ReportDataSource("NRFOP", dsPDDRTDataSet_NRFOP.Tables("JCF_RptGrossSaleBreakdown"))
        Dim dsRPT_NRFOR As New ReportDataSource("NRFOR", dsPDDRTDataSet_NRFOR.Tables("JCF_RptGrossSaleBreakdown"))


        Dim _Year As New ReportParameter("Year", pYear.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Year})


        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True


        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_TOTAL)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_RFOP)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_RFOR)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_NRFOP)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_NRFOR)
        'report

    End Function



    Private Function RPT_HLGSB_TOTAL(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "H&L Total")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

    Private Function RPT_HLGSB_RFOP(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "RFO Promo")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

    Private Function RPT_HLGSB_RFOR(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "RFO Regular")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

    Private Function RPT_HLGSB_NRFOP(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "NRFO Promo")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

    Private Function RPT_HLGSB_NRFOR(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "NRFO Regular")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function


#End Region

#Region "PDDRT0009"

    Function PDDRT0009()

        'parameter
        Dim pYear = HttpUtility.UrlDecode(Request.QueryString("pYear"))
        Dim pType = HttpUtility.UrlDecode(Request.QueryString("pType"))

        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0009.rdlc")
        Dim dsPDDRTDataSet_Total As PDDRTDataSet = Rpt_LOGSB_total(pYear, pType)
        Dim dsPDDRTDataSet_RFOP As PDDRTDataSet = Rpt_LOGSB_LOP(pYear, pType)
        Dim dsPDDRTDataSet_RFOR As PDDRTDataSet = Rpt_LOGSB_LOR(pYear, pType)

        Dim dsRPT_TOTAL As New ReportDataSource("Total", dsPDDRTDataSet_Total.Tables("JCF_RptGrossSaleBreakdown"))
        Dim dsRPT_LOP As New ReportDataSource("LOP", dsPDDRTDataSet_RFOP.Tables("JCF_RptGrossSaleBreakdown"))
        Dim dsRPT_LOR As New ReportDataSource("LOR", dsPDDRTDataSet_RFOR.Tables("JCF_RptGrossSaleBreakdown"))



        Dim _Year As New ReportParameter("Year", pYear.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Year})


        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True


        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_TOTAL)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_LOP)
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_LOR)

        'report

    End Function



    Private Function Rpt_LOGSB_total(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "LO Total")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

    Private Function Rpt_LOGSB_LOP(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "LO Promo")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

    Private Function Rpt_LOGSB_LOR(pYear, pType) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleBreakdown")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlCmd.Parameters.AddWithValue("@pType", "LO Regular")
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleBreakdown")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "PDDRT0010"

    Function PDDRT0010()

        'parameter
        Dim pYear = HttpUtility.UrlDecode(Request.QueryString("pYear"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0010.rdlc")
        Dim dsPDDRTDataSet_GSP As PDDRTDataSet = Rpt_GSProject(pYear)
        Dim dsRPT_TOTAL As New ReportDataSource("GSP", dsPDDRTDataSet_GSP.Tables("JCF_RptGrossSaleProject"))


        Dim _Year As New ReportParameter("Year", pYear.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Year})


        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True


        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_TOTAL)


        'report

    End Function



    Private Function Rpt_GSProject(pYear) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptGrossSaleProject")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptGrossSaleProject")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "PDDRT0011"

    Function PDDRT0011()

        'parameter
        Dim pYear = HttpUtility.UrlDecode(Request.QueryString("pYear"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0011.rdlc")
        Dim dsPDDRTDataSet_PDDP As PDDRTDataSet = Rpt_PDDP(pYear)
        Dim dsRPT_TOTAL As New ReportDataSource("PDDP", dsPDDRTDataSet_PDDP.Tables("JCF_RptPDDPromos"))


        Dim _Year As New ReportParameter("Year", pYear.ToString())
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Year})


        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True


        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_TOTAL)
        'report

    End Function



    Private Function Rpt_PDDP(pYear) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptPDDPromos")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pYear", pYear)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptPDDPromos")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "PDDRT0012"

    Function PDDRT0012()

        'parameter
        Dim pDate = HttpUtility.UrlDecode(Request.QueryString("pDate"))
        Dim pProjCode = HttpUtility.UrlDecode(Request.QueryString("pProjCode"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0012.rdlc")
        Dim dsPDDRTDataSet_PDDP As PDDRTDataSet = Rpt_PL(pDate, pProjCode)
        Dim dsRPT_PL As New ReportDataSource("PL", dsPDDRTDataSet_PDDP.Tables("JCF_RptPriceList"))


        Dim _Date As New ReportParameter("pDate", DateTime.ParseExact(pDate, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_Date})


        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True


        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PL)
        'report

    End Function



    Private Function Rpt_PL(pDate, pProjCode) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptPriceList")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDate", pDate)
                sqlCmd.Parameters.AddWithValue("@pProjCode", pProjCode)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptPriceList")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

#Region "PDDRT0013"

    Function PDDRT0013()

        'parameter
        Dim pTerritory = HttpUtility.UrlDecode(Request.QueryString("pTerritory"))
        Dim pNotForSale = HttpUtility.UrlDecode(Request.QueryString("pNotForSale"))
        Dim pOpen = HttpUtility.UrlDecode(Request.QueryString("pOpen"))
        Dim pHold = HttpUtility.UrlDecode(Request.QueryString("pHold"))
        Dim pSold = HttpUtility.UrlDecode(Request.QueryString("pSold"))
        Dim pSubd = HttpUtility.UrlDecode(Request.QueryString("pSubd"))
        Dim pPhase = HttpUtility.UrlDecode(Request.QueryString("pPhase"))
        Dim pBlock = HttpUtility.UrlDecode(Request.QueryString("pBlock"))
        Dim pLot = HttpUtility.UrlDecode(Request.QueryString("pLot"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0013.rdlc")
        Dim dsPDDRTDataSet As PDDRTDataSet = RPT_PLS(pTerritory, pNotForSale, pOpen, pHold, pSold, pSubd, pPhase, pBlock, pLot)
        Dim dsRPT_PLS As New ReportDataSource("PLS", dsPDDRTDataSet.Tables("JCF_RptPriceListSpecific"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PLS)
        'report

    End Function



    Private Function RPT_PLS(pTerritory, pNotForSale, pOpen, pHold, pSold, pSubd, pPhase, pBlock, pLot) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptPriceListSpecific")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pTerritory", pTerritory)
                sqlCmd.Parameters.AddWithValue("@pNotForSale", pNotForSale)
                sqlCmd.Parameters.AddWithValue("@pOpen", pOpen)
                sqlCmd.Parameters.AddWithValue("@pHold", pHold)
                sqlCmd.Parameters.AddWithValue("@pSold", pSold)
                sqlCmd.Parameters.AddWithValue("@pSubd", pSubd)
                sqlCmd.Parameters.AddWithValue("@pPhase", pPhase)
                sqlCmd.Parameters.AddWithValue("@pBlock", pBlock)
                sqlCmd.Parameters.AddWithValue("@pLot", pLot)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptPriceListSpecific")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using

    End Function

#End Region

#Region "PDDRT0014"

    Function PDDRT0014()

        'parameter
        Dim pDateto = HttpUtility.UrlDecode(Request.QueryString("pDateto"))
        Dim pDatefrom = HttpUtility.UrlDecode(Request.QueryString("pDatefrom"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0014.rdlc")

        Dim dsPDDRTDataSet_RS As PDDRTDataSet = RPT_RS(pDateto, pDatefrom)
        Dim dsRPT_RS As New ReportDataSource("RS", dsPDDRTDataSet_RS.Tables("JCF_RptReservedSale"))


        Dim _pDatefrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDatefrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDatefrom})

        Dim _pDateto As New ReportParameter("DateTo", DateTime.ParseExact(pDateto, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDateto})



        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_RS)
        'report


    End Function



    Private Function RPT_RS(pDateto, pDatefrom) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptReservedSale")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrome", pDatefrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateto)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptReservedSale")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function



#End Region

#Region "PDDRT0015"

    Function PDDRT0015()

        'parameter
        Dim pDateto = HttpUtility.UrlDecode(Request.QueryString("pDateto"))
        Dim pDatefrom = HttpUtility.UrlDecode(Request.QueryString("pDatefrom"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0015.rdlc")

        Dim dsPDDRTDataSet_Cancel As PDDRTDataSet = RPT_CANCEL(pDateto, pDatefrom)
        Dim dsRPT_Cancel As New ReportDataSource("Cancel", dsPDDRTDataSet_Cancel.Tables("JCF_RptPDDCancellation"))


        Dim _pDatefrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDatefrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDatefrom})

        Dim _pDateto As New ReportParameter("DateTo", DateTime.ParseExact(pDateto, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDateto})



        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_Cancel)
        'report


    End Function



    Private Function RPT_CANCEL(pDateto, pDatefrom) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptPDDCancellation")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrome", pDatefrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateto)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptPDDCancellation")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function



#End Region

#Region "PDDRT0016"

    Function PDDRT0016()

        'parameter
        Dim pDateto = HttpUtility.UrlDecode(Request.QueryString("pDateto"))
        Dim pDatefrom = HttpUtility.UrlDecode(Request.QueryString("pDatefrom"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0016.rdlc")
        Dim dsPDDRTDataSet_PD As PDDRTDataSet = RPT_PD(pDateto, pDatefrom)
        Dim dsRPT_PD As New ReportDataSource("PD", dsPDDRTDataSet_PD.Tables("JCF_RptPromoDiscount"))


        Dim _pDatefrom As New ReportParameter("DateFrom", DateTime.ParseExact(pDatefrom, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDatefrom})

        Dim _pDateto As New ReportParameter("DateTo", DateTime.ParseExact(pDateto, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {_pDateto})



        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_PD)
        'report


    End Function



    Private Function RPT_PD(pDateto, pDatefrom) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptPromoDiscount")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pDateFrom", pDatefrom)
                sqlCmd.Parameters.AddWithValue("@pDateTo", pDateto)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptPromoDiscount")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function



#End Region

#Region "PDDRT0017"

    Function PDDRT0017()

        'parameter
        Dim pSubd = HttpUtility.UrlDecode(Request.QueryString("pSubd"))
        Dim pPhase = HttpUtility.UrlDecode(Request.QueryString("pPhase"))
        Dim pBlock = HttpUtility.UrlDecode(Request.QueryString("pBlock"))
        Dim pLot = HttpUtility.UrlDecode(Request.QueryString("pLot"))
        'parameter

        'report
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/PDDRT0017.rdlc")
        Dim dsPDDRTDataSet_TCU As PDDRTDataSet = RPT_TCU(pSubd, pPhase, pBlock, pLot)
        Dim dsRPT_TCU As New ReportDataSource("TCU", dsPDDRTDataSet_TCU.Tables("JCF_RptTrackingHistory"))
        ReportViewer1.ShowPrintButton = IIf(Access(CIIS_EmpCode, FormCode, "Print") = 1, True, False)
        ReportViewer1.ShowExportControls = IIf(Access(CIIS_EmpCode, FormCode, "Export") = 1, True, False)
        ReportViewer1.LocalReport.EnableHyperlinks = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dsRPT_TCU)
        'report

    End Function

    Private Function RPT_TCU(pSubd, pPhase, pBlock, pLot) As PDDRTDataSet
        Dim sqlCmd As New SqlCommand("JCF_RptTrackingHistory")
        Using sqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardbLive & "; User ID=" & UserID & "; Password=" & Password)
            Using sqlSda As New SqlDataAdapter()
                sqlCmd.Connection = sqlConn
                sqlCmd.CommandTimeout = 180000
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@pSubd", pSubd)
                sqlCmd.Parameters.AddWithValue("@pPhase", pPhase)
                sqlCmd.Parameters.AddWithValue("@pBlock", pBlock)
                sqlCmd.Parameters.AddWithValue("@pLot", pLot)
                sqlSda.SelectCommand = sqlCmd
                Using dsPDDRTDataSet As New PDDRTDataSet
                    sqlSda.Fill(dsPDDRTDataSet, "JCF_RptTrackingHistory")
                    Return dsPDDRTDataSet
                End Using
            End Using
        End Using
    End Function

#End Region

End Class