Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Threading.Tasks
Imports System.Windows.Interop
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Ajax.Utilities


Public Class PMD020000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "PMD020000"
    Dim AssignToDT As New DataTable
    Protected Property FormDataSet As DataSet

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
        'create variable
        Dim Msg As String = Access(CIIS_EmpCode, FormCode, "View")
        'create variable

        'validate access
        If Msg <> "1" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        'active account / menu
        Master.setActiveMenu("APP", "PMD020000")
        'active account / menu


        'load page
        If IsPostBack = False Then
            'bindCounter()
            bindForm()
            bindconnectioncode()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
        End If
        'load page
    End Sub

#End Region

#Region "Function"

    Protected Sub lbtnFLT_Click(ByVal sender As Object, e As EventArgs)
        bindForm()
        bindconnectioncode()
        ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
    End Sub


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
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
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





    'Function bindCounter()

    '    'get total task
    '    Dim Query As New StringBuilder
    '    Query.Append("select")
    '    Query.Append("	isnull((select count(1) from oop_form_hdr [A] where [A].approver = '" & CIIS_EmpCode & "' and [A].status Not In ('Accepted','Declined','Cancelled') And [A].f_code in (select [B].f_code from oop_form_dtl_appr [B] where [B].approver = [A].approver and [B].status = '' and cast([B].DateStart as date) = cast(getdate() as date))),0) [New] ")
    '    Query.Append("	,isnull((select count(1) from oop_form_dtl_monitor [A] left join oop_form_hdr [B] on [A].f_code = [B].f_code where [A].monitored_by = '" & CIIS_EmpCode & "' and [B].status Not In ('Accepted','Declined','Cancelled')),0) [Subscribed] ")
    '    Query.Append("	,isnull((select count(1) from oop_form_hdr [A] where [A].approver = '" & CIIS_EmpCode & "' And [A].status Not In ('Accepted','Declined','Cancelled')),0) [Total] ")
    '    'get total task

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                'blink01New.Style.Add("display", IIf(DR("New") = 0, "none", ""))
    '                'blink01Subscribed.Style.Add("display", IIf(DR("Subscribed") = 0, "none", ""))
    '            End While
    '            DR.Close()
    '            ConStr.Close()
    '        End Using
    '    End Using
    '    'read record

    'End Function

    Function bindForm()


        System.Threading.Thread.Sleep(1000)



        ' Create a DataTable to store the results
        Dim FormDataTable As New DataTable()
        FormDataTable.Columns.Add(New DataColumn("BillCode"))
        FormDataTable.Columns.Add(New DataColumn("Post"))
        FormDataTable.Columns.Add(New DataColumn("Connection"))
        FormDataTable.Columns.Add(New DataColumn("DateIssue"))
        FormDataTable.Columns.Add(New DataColumn("DateDue"))
        FormDataTable.Columns.Add(New DataColumn("BillingFrom"))
        FormDataTable.Columns.Add(New DataColumn("BillingTo"))


        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetElecHdrList", ConStr)
                Cmd.CommandType = CommandType.StoredProcedure
                If cbxFLT.Checked = False Then
                    ' Add parameters for the stored procedure
                    Cmd.Parameters.AddWithValue("@pPost", 0)
                    Cmd.Parameters.AddWithValue("@pConnection", ddlAdd_Connection.SelectedValue)
                ElseIf cbxFLT.Checked = True Then
                    Cmd.Parameters.AddWithValue("@pPost", 1)
                    Cmd.Parameters.AddWithValue("@pConnection", ddlAdd_Connection.SelectedValue)
                End If
                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    While DR.Read()

                        Dim link As String = "PMD020100-DTL-" & DR("BillCode").ToString()
                        Dim ID As String = "<a href='" & link & "' class='text-dark'>" & DR("BillCode") & "</a>"
                        Dim posted As String = If(DR("Post").ToString() = "1", "1", "0")

                        ' Styled checkbox with a hidden value for export
                        Dim elecStatus As String = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-6' " &
                        "style='background-color: white; padding-right: 3px; margin-right: 3px; align-content: center'>" &
                        "<input id='chkSelect' runat='server' class='form-check-input checkBoxAllClass chkSelect' " &
                        "type='checkbox' " & If(posted = "1", "checked='1'", "0") & " style='pointer-events: none;' />" &
                        "<span style='display:none;'>" & posted & "</span>" & ' Hidden numeric value
                        "</div>"

                        'Add the row to the DataTable
                        FormDataTable.Rows.Add(ID,
                    elecStatus,
                    DR("SINNo").ToString(),
                    Convert.ToDateTime(DR("IssueDate")).ToString("MM/dd/yyyy"),
                    Convert.ToDateTime(DR("DueDate")).ToString("MM/dd/yyyy"),
                    Convert.ToDateTime(DR("FromDate")).ToString("MM/dd/yyyy"),
                    Convert.ToDateTime(DR("ToDate")).ToString("MM/dd/yyyy")
                )
                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
        End Using

        ' Assign the DataTable to a DataSet if needed
        FormDataSet = New DataSet()
        FormDataSet.Tables.Add(FormDataTable)
    End Function

    Function Access(EmpCode, FormCode, Action)

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
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

End Class
