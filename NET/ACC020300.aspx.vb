Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO

Public Class ACC020300
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

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
        Master.setActiveMenu("APP", "ACC020300")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'display record
            bindPeriod()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Protected Sub lbtnView_Click(ByVal sender As Object, e As EventArgs)

        If ddlPeriod.SelectedValue = "" Or tbxPassword.Text = "" Then
            Alert("error", "Some fields are missing!")
            Exit Sub
        End If

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Password"
        sqlCmd.Parameters.AddWithValue("@pEmpCode", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pPassword", tbxPassword.Text)
        Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
        oMsg.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oMsg)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        If oMsg.Value.ToString <> "" Then
            Alert("error", oMsg.Value.ToString)
            Exit Sub
        End If

        'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/"))
        End If
        'create new folder

        'remove file within the folder
        Dim RptFile As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/"))
        Try
            Dim file As FileInfo
            For Each file In RptFile.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file 

        'create new folder
        If Directory.Exists(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/")) = False Then
            Directory.CreateDirectory(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/"))
        End If
        'create new folder

        'remove file within the folder
        Dim PDFIle As DirectoryInfo = New DirectoryInfo(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/"))
        Try
            Dim file As FileInfo
            For Each file In PDFIle.GetFiles()
                file.Delete()
            Next
        Catch ex As Exception
        End Try
        'remove file 

        'copy template report
        System.IO.File.Copy(Server.MapPath("~/Assets/Report/RPT000016.rpt"), Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/RPT000016.rpt"))
        'copy template report

        'fill report
        Dim RptDoc As ReportDocument = New ReportDocument()
       RptDoc.Load(Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/RPT000016.rpt"))
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
        RptDoc.SetParameterValue("@pEmpCode", CIIS_EmpCode)
        RptDoc.SetParameterValue("@pPSCode", ddlPeriod.SelectedValue)
        'fill report

        'export file
        Try
            'export file
            Dim Stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim Buf As Byte()
            Buf = New Byte(Stream.Length - 1) {}
            Stream.Read(Buf, 0, Buf.Length)
            File.WriteAllBytes(Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/RPT000016.pdf"), Buf)
            CIIS_UserInfo("CIIS_File") = "~/Assets/PDF/" & CIIS_EmpCode & "/" & ddlPeriod.SelectedValue & "/RPT000016.pdf"
            Response.Cookies.Add(CIIS_UserInfo)
            'export file

            'view file
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenWindow", "window.open('MNU020200');", True)
            'view file
        Catch ex As Exception
            Alert("error", ex.ToString)
        End Try
        'export file

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function bindPeriod()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select period' [Text] ")
        Query.Append("	 ,0 [Order01] ")
        Query.Append("	 ,'9000-01-01' [Order02] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [Value] ")
        Query.Append("   ,[Text] ")
        Query.Append("   ,[Order01] ")
        Query.Append("   ,[Order02] ")
        Query.Append("from ")
        Query.Append("   (select top 10  ")
        Query.Append("      Mstr_PayrollPeriod.PSCode [Value] ")
        Query.Append("	    ,Mstr_PayrollPeriod.PSName [Text] ")
        Query.Append("	    ,1 [Order01] ")
        Query.Append("	    ,Mstr_PayrollPeriod.DateFrom [Order02] ")
        Query.Append("   from ")
        Query.Append("	    Trxn_PayrollDtl ")
        Query.Append("	    Left Join Trxn_PayrollHdr on Trxn_PayrollDtl.PSCode = Trxn_PayrollHdr.PSCode ")
        Query.Append("	    Left Join Mstr_PayrollPeriod on Trxn_PayrollDtl.PSCode = Mstr_PayrollPeriod.PSCode ")
        Query.Append("   where ")
        Query.Append("      Trxn_PayrollDtl.EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("      and Trxn_PayrollHdr.Lock = 1  ")
        Query.Append("   order by ")
        Query.Append("      Mstr_PayrollPeriod.DateFrom desc) [A] ")
        Query.Append("order by ")
        Query.Append("   [Order01] ")
        Query.Append("   ,[Order02] desc ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlPeriod.DataSource = DT
        ddlPeriod.DataValueField = "Value"
        ddlPeriod.DataTextField = "Text"
        ddlPeriod.DataBind()
        'fill data

    End Function

#End Region

End Class