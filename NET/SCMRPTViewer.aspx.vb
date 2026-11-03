Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.EnterpriseServices
Imports System.IO
Imports System.Reflection.Emit
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Reporting.WebForms

Public Class SCMRPTViewer
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim cldc_live_acc As String = "cldc_live_acc"
    Dim calmardblive As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim FormCode As String = ""
    Dim pID As String = ""
    Dim pType As String = ""

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
            pID = HttpUtility.UrlDecode(Request.QueryString("pID")).Replace("No", "#")
            pType = HttpUtility.UrlDecode(Request.QueryString("pType"))

            'Validate Access
            Dim msg As String = Access(CIIS_EmpCode, FormCode, "View")
            If msg <> "1" Then
                Response.Redirect("MNU000022")
            End If
            'Validate Access

            If FormCode = "SCMRT0014" Then
                SCMRT0014(pID, pType)
            End If

            If FormCode = "SCMRT0015" Then
                SCMRT0015(pID, pType)
            End If

            If FormCode = "SCMRT0016" Then
                SCMRT0016(pID, pType)
            End If

            If FormCode = "SCMRT0017" Then
                SCMRT0017(pID, pType)
            End If

            If FormCode = "SCMRT0019" Then
                SCMRT0019(pID, pType)
            End If

            If FormCode = "SCMRT0020" Then
                SCMRT0020(pID, pType)
            End If

            If FormCode = "SCMRT0022" Then
                SCMRT0022(pID, pType)
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

#Region "Function"

#Region "SCMRT0014"
    Function SCMRT0014(pID, pType)

        If pType = "PR" Then

            Try
                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
                RptDoc.SetParameterValue("@pFormNo", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

        If pType = "PO" Then

            Try
                'parameter
                Dim pCode As String

                'query
                Dim Query As New StringBuilder
                Query.Append("select ")
                Query.Append("  po_code [POCode] ")
                Query.Append("from ")
                Query.Append("  ogm_po_hdr ")
                Query.Append("where ")
                Query.Append("  po_no = '" & pID & "' ")
                'query

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Dim DR As SqlDataReader = Cmd.ExecuteReader
                        While DR.Read()
                            pCode = DR("POCode")
                        End While
                        DR.Close()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPTPO0001.rpt"), Path.Combine(reportFolderPath, "RPTPO0001.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPTPO0001.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("Action", "None")
                RptDoc.SetParameterValue("@pPOCode", pCode)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTPO0001.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTPO0001.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

    End Function
#End Region

#Region "SCMRT0015"
    Function SCMRT0015(pID, pType)

        If pType = "PR" Then

            Try
                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
                RptDoc.SetParameterValue("@pFormNo", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

        If pType = "WT" Then

            Try
                'parameter
                Dim pCode As String

                'query
                Dim Query As New StringBuilder
                Query.Append("select ")
                Query.Append("  wt_code [WTCode] ")
                Query.Append("from ")
                Query.Append("  ogm_wtran_hdr ")
                Query.Append("where ")
                Query.Append("  wt_refno = '" & pID & "' ")
                'query

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Dim DR As SqlDataReader = Cmd.ExecuteReader
                        While DR.Read()
                            pCode = DR("WTCode")
                        End While
                        DR.Close()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPTWT0001.rpt"), Path.Combine(reportFolderPath, "RPTWT0001.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPTWT0001.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pWTCode", pCode)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTWT0001.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTWT0001.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

    End Function
#End Region

#Region "SCMRT0016"
    Function SCMRT0016(pID, pType)

        If pType = "PR" Then

            Try
                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
                RptDoc.SetParameterValue("@pFormNo", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

    End Function
#End Region

#Region "SCMRT0017"
    Function SCMRT0017(pID, pType)

        If pType = "PR" Then

            Try
                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
                RptDoc.SetParameterValue("@pFormNo", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

        If pType = "PO" Then

            Try
                'parameter
                Dim pCode As String

                'query
                Dim Query As New StringBuilder
                Query.Append("select ")
                Query.Append("  po_code [POCode] ")
                Query.Append("from ")
                Query.Append("  ogm_po_hdr ")
                Query.Append("where ")
                Query.Append("  po_no = '" & pID & "' ")
                'query

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Dim DR As SqlDataReader = Cmd.ExecuteReader
                        While DR.Read()
                            pCode = DR("POCode")
                        End While
                        DR.Close()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPTPO0001.rpt"), Path.Combine(reportFolderPath, "RPTPO0001.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPTPO0001.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("Action", "None")
                RptDoc.SetParameterValue("@pPOCode", pCode)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTPO0001.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTPO0001.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

    End Function
#End Region

#Region "SCMRT0019"
    Function SCMRT0019(pID, pType)

        If pType = "PR" Then

            Try
                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
                RptDoc.SetParameterValue("@pFormNo", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

        If pType = "PO" Then

            Try
                'parameter
                Dim pCode As String

                'query
                Dim Query As New StringBuilder
                Query.Append("select ")
                Query.Append("  po_code [POCode] ")
                Query.Append("from ")
                Query.Append("  ogm_po_hdr ")
                Query.Append("where ")
                Query.Append("  po_no = '" & pID & "' ")
                'query

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Dim DR As SqlDataReader = Cmd.ExecuteReader
                        While DR.Read()
                            pCode = DR("POCode")
                        End While
                        DR.Close()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPTPO0001.rpt"), Path.Combine(reportFolderPath, "RPTPO0001.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPTPO0001.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("Action", "None")
                RptDoc.SetParameterValue("@pPOCode", pCode)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTPO0001.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTPO0001.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

    End Function
#End Region

#Region "SCMRT0020"
    Function SCMRT0020(pID, pType)

        If pType = "PR" Then

            Try
                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
                RptDoc.SetParameterValue("@pFormNo", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

        If pType = "PO" Then

            Try
                'parameter
                Dim pCode As String

                'query
                Dim Query As New StringBuilder
                Query.Append("select ")
                Query.Append("  po_code [POCode] ")
                Query.Append("from ")
                Query.Append("  ogm_po_hdr ")
                Query.Append("where ")
                Query.Append("  po_no = '" & pID & "' ")
                'query

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Dim DR As SqlDataReader = Cmd.ExecuteReader
                        While DR.Read()
                            pCode = DR("POCode")
                        End While
                        DR.Close()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPTPO0001.rpt"), Path.Combine(reportFolderPath, "RPTPO0001.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPTPO0001.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("Action", "None")
                RptDoc.SetParameterValue("@pPOCode", pCode)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTPO0001.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTPO0001.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

    End Function
#End Region

#Region "SCMRT0022"
    Function SCMRT0022(pID, pType)

        If pType = "PR" Then

            Try
                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
                RptDoc.SetParameterValue("@pFormNo", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

        If pType = "PO" Then

            Try
                'parameter
                Dim pCode As String

                'query
                Dim Query As New StringBuilder
                Query.Append("select ")
                Query.Append("  po_code [POCode] ")
                Query.Append("from ")
                Query.Append("  ogm_po_hdr ")
                Query.Append("where ")
                Query.Append("  po_no = '" & pID & "' ")
                'query

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live_acc & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Dim DR As SqlDataReader = Cmd.ExecuteReader
                        While DR.Read()
                            pCode = DR("POCode")
                        End While
                        DR.Close()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                ' Define paths
                Dim reportFolderPath = Context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
                Dim pdfFolderPath = Context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(reportFolderPath) Then
                    Directory.CreateDirectory(reportFolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(reportFolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Create PDF folder if it doesn't exist
                If Not Directory.Exists(pdfFolderPath) Then
                    Directory.CreateDirectory(pdfFolderPath)
                End If

                ' Delete existing files in the PDF folder
                Dim pdfDir As New DirectoryInfo(pdfFolderPath)
                For Each file In pdfDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(Context.Server.MapPath("~/Assets/Report/RPTPO0001.rpt"), Path.Combine(reportFolderPath, "RPTPO0001.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPTPO0001.rpt"))

                Dim logoninfo As TableLogOnInfo
                For Each tbcurrent As Table In RptDoc.Database.Tables
                    logoninfo = tbcurrent.LogOnInfo()
                    logoninfo.ConnectionInfo.ServerName = DataSource
                    logoninfo.ConnectionInfo.DatabaseName = cldc_live_acc
                    logoninfo.ConnectionInfo.UserID = UserID
                    logoninfo.ConnectionInfo.Password = Password
                    tbcurrent.ApplyLogOnInfo(logoninfo)
                Next

                RptDoc.SetDatabaseLogon(UserID, Password, DataSource, cldc_live_acc)
                RptDoc.SetParameterValue("Action", "None")
                RptDoc.SetParameterValue("@pPOCode", pCode)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTPO0001.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTPO0001.pdf")
                Response.Redirect("MNU020200?View=" & encryptedPath)

            Catch ex As Exception
                'nothing
            End Try

        End If

    End Function
#End Region

#End Region

End Class