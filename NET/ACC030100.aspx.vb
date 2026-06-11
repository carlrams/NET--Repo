Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ACC030100
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "ACC030100")
        'active account / menu

        'load page
        If IsPostBack = False Then
            bindCashAdvance()
        End If
        'load page
    End Sub

#End Region

#Region "Button"

    Protected Sub lbtnRefresh_Click(ByVal sender As Object, e As EventArgs)
        bindCashAdvance()
    End Sub

    Protected Sub btnRPT_Single_Click(ByVal sender As Object, ByVal e As EventArgs)

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

        'Work Order
        If hfFormCode.Value = "FRM000001" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000001.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000001.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000001.rpt"))
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
            RptDoc.SetParameterValue("@wo_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000001.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000001.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Work Order

        'Purchase Request
        If hfFormCode.Value = "FRM000010" Then

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
                logoninfo.ConnectionInfo.DatabaseName = Catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next
            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, Catalog)
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "PRPrintoutwNote.rpt")
            RptDoc.SetParameterValue("@pFormNo", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Purchase Request

        'Service Request Form
        If hfFormCode.Value = "FRM000012" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000002.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000002.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000002.rpt"))
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
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000002.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000002.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Service Request Form

        'Occupancy Clearance
        If hfFormCode.Value = "FRM000013" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000009.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000009.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000009.rpt"))
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
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000009.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000009.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Occupancy Clearance

        'Cash Advance - Cash Advance
        If hfFormCode.Value = "FRM000015" And hrRPT.Value = "1" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000004.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000004.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000004.rpt"))
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
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAAPVPrintout.rpt")
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAPrintout.rpt")
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000004.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000004.pdf")
                ScriptManager.RegisterStartupScript(upnlContent, upnlContent.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Cash Advance - Cash Advance

        'Cash Advance - Cash Liquidation
        If hfFormCode.Value = "FRM000015" And hrRPT.Value = "2" Then
            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000005.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000005.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000005.rpt"))
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
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAPrintout.rpt")
            RptDoc.SetParameterValue("@pFormNo", hfID.Value, "CAPrintoutwNote.rpt")
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000005.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000005.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Cash Advance - Cash Liquidation

        'Petty Cash
        If hfFormCode.Value = "FRM000016" Then

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

        End If
        'Petty Cash

        'Payment Request
        If hfFormCode.Value = "FRM000017" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000008.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000008.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000008.rpt"))
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
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000008.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000008.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Payment Request

        'Capital Expenditure Request
        If hfFormCode.Value = "FRM000018" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000010.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000010.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000010.rpt"))
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
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000010.pdf"), Buf)
                CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/RPT000010.pdf"
                Response.Cookies.Add(CIIS_UserInfo)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000010.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Capital Expenditure Request

        'Construction Clearance
        If hfFormCode.Value = "FRM000022" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000012.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000012.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000012.rpt"))
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
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000012.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000012.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Construction Clearance

        'Electrical Service Connection
        If hfFormCode.Value = "FRM000023" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000013.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000013.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000013.rpt"))
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
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000013.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000013.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Electrical Service Connection

        'Water Service Connection
        If hfFormCode.Value = "FRM000025" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000003.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000003.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000003.rpt"))
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
            RptDoc.SetParameterValue("@pFCode", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000003.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000003.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Water Service Connection

        'TCT Clearance
        If hfFormCode.Value = "FRM000027" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000014.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000014.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000014.rpt"))
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
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000014.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000014.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'TCT Clearance

        'Transfer of Title Routing Slip
        If hfFormCode.Value = "FRM000032" Then

            'copy template report
            System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000006.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000006.rpt"))
            'copy template report

            'fill report
            Dim RptDoc As ReportDocument = New ReportDocument()
            RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000006.rpt"))
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
            RptDoc.SetParameterValue("@f_code", hfID.Value)
            'fill report

            'export file
            Try
                Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim Buf As Byte()
                Buf = New Byte(Stream.Length - 1) {}
                Stream.Read(Buf, 0, Buf.Length)
                File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000006.pdf"), Buf)

                'view report
                RptDoc.Dispose()
                RptDoc.Close()
                Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000006.pdf")
                ScriptManager.RegisterStartupScript(upnlBreadcrumbbar, upnlBreadcrumbbar.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
                'view report
            Catch ex As Exception
                Alert("error", ex.ToString)
            End Try
            'export file

        End If
        'Transfer of Title Routing Slip

    End Sub

#End Region

#Region "Function"

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

    End Function

    Function bindCashAdvance()

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
        Query.Append("   ,[FormCode] ")
        Query.Append("   ,[wRPT] ")
        Query.Append("   ,[RPT] ")
        Query.Append("   ,[RefNo] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[C].description [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("      ,Format(isnull((select sum([E].BdgtAmt) from Form_CADtl [E] where [E].CVCode = [D].CVCode),0),'N2') [Amount] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,isnull([C].wRPT,0) [wRPT] ")
        Query.Append("      ,(case when [C].FormCode = 'FRM000015' and [A].remarks = 'Cash Liquidation' then '2' else '1' end) [RPT] ")
        Query.Append("      ,(case when [C].FormCode = 'FRM000015' and [A].remarks = 'Cash Liquidation' then (select top 1 [E].RefNo from Form_CAHdr [E] where [E].CVCode = [A].tbl_code) else [A].f_code end) [RefNo] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("	    left join Form_CAHdr [D] on [A].tbl_code = [D].CVCode ")
        Query.Append("   where ")
        Query.Append("      [D].CreatedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [D].CVType = 'Cash Advance' ")
        Query.Append("      and [D].Status = '' ")
        Query.Append("      and [A].tbl_from = 'Form_CAHdr' ")
        Query.Append("      and [A].Status In ('Accepted') ")
        Query.Append("   union  ")
        Query.Append("   select  ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[C].description [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("      ,Format(isnull((select sum([E].Amount) from Form_PCDtl [E] where [E].PCCode = [D].PCCode),0),'N2') [Amount] ")
        Query.Append("      ,[C].FormCode ")
        Query.Append("      ,isnull([C].wRPT,0) [wRPT] ")
        Query.Append("      ,(case when [C].FormCode = 'FRM000015' and [A].remarks = 'Cash Liquidation' then '2' else '1' end) [RPT] ")
        Query.Append("      ,(case when [C].FormCode = 'FRM000015' and [A].remarks = 'Cash Liquidation' then (select top 1 [E].RefNo from Form_CAHdr [E] where [E].CVCode = [A].tbl_code) else [A].f_code end) [RefNo] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("	    left join Form_PCHdr [D] on [A].tbl_code = [D].PCCode ")
        Query.Append("   where ")
        Query.Append("      [D].CreatedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("      and [D].PCType = 'Cash Advance' ")
        Query.Append("      and [D].Status = '' ")
        Query.Append("      and [A].tbl_from = 'Form_PCHdr' ")
        Query.Append("      and [A].Status In ('Accepted')) [A] ")
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
        dtable.Columns.Add(New DataColumn("RPT_Single"))
        dtable.Columns.Add(New DataColumn("RPT_Display"))
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
                    Dim RPT_Single As String = "RPT_Single('" & DR("FormCode") & "','" & DR("RefNo") & "','" & DR("RPT") & "')"
                    Dim RPT_Display As String = IIf(DR("wRPT") = 1, "", "style='display:none'")
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, Link, Icon, Title, ID, Name, Date_, Amount, RPT_Single, RPT_Display}
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

#End Region

End Class