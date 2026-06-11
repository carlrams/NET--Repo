Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Ajax.Utilities

Public Class DSB080000
    Inherits System.Web.UI.Page

#Region "Page"

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_Deparment As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_Deparment = CIIS_UserInfo("CIIS_Department")

        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("DSB", "DSB080000")
        'active account / menu

        'load page
        If IsPostBack = False Then

            hfPostback.Value = "true"

            'load
            bindBatch()
            'load

        End If
        'load page
    End Sub

#End Region

#Region "Button"

    Protected Sub btnGenerate_Ok_Click(ByVal sender As Object, e As EventArgs)

        'validate
        Dim Msg01 = Validate("Form_HWHdr", hfID.Value, "COCA")
        If Msg01 <> "" Then
            Alert("error", Msg01)
            Exit Sub
        End If
        'validate

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
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000041.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000041.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
        RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/RPT000041.rpt"))
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
        RptDoc.SetParameterValue("@pHWCode", hfID.Value)
        'fill report

        'export file
        Try
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000041.pdf"), Buf)
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

        'view report
        RptDoc.Dispose()
        RptDoc.Close()
        Dim View As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000041.pdf")
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType, "OpenWindow", "window.open('MNU020200?View=" & View & "');", True)
        'view report


    End Sub


#End Region

#Region "Function"

    Function bindBatch()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select batch' [Name] ")
        Query.Append("   ,0 [Order01] ")
        Query.Append("   ,'' [Order02] ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("   'All' [Code] ")
        Query.Append("   ,'All' [Name] ")
        Query.Append("   ,1 [Order01] ")
        Query.Append("   ,'All' [Order02] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].BatchNo [Code] ")
        Query.Append("   ,[A].BatchNo [Name] ")
        Query.Append("   ,2 [Order01] ")
        Query.Append("   ,[A].BatchNo [Order02] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_BatchNo [A] ")
        Query.Append("order by ")
        Query.Append("   [Order01] ")
        Query.Append("   ,[Order02] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlBatch.DataSource = DT
        ddlBatch.DataValueField = "Code"
        ddlBatch.DataTextField = "Name"
        ddlBatch.DataBind()
        'fill data

        'display
        upnlBreadcrumbbar.Update()
        'display

    End Function

    Function bindUnit(Batch)

    End Function

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none",
        "<script>
        setTimeout(function() {
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

    Function Validate(TblName, TblCode, Type)
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Record"
        sqlCmd.Parameters.AddWithValue("@pTblName", "Form_HWHdr")
        sqlCmd.Parameters.AddWithValue("@pTblCode", hfID.Value)
        sqlCmd.Parameters.AddWithValue("@pTblVal", "")
        sqlCmd.Parameters.AddWithValue("@pType", Type)
        Dim oAns As New SqlClient.SqlParameter("@oAns", SqlDbType.NVarChar, 1000)
        oAns.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oAns)
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        Return oAns.Value.ToString
    End Function

#End Region

End Class