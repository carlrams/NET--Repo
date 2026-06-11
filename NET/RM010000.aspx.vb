Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Web.Script.Serialization
Imports System.Web.WebSockets
Imports System.Net.Http
Imports System.Net
Imports System.Web.Http
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Azure.Core

Public Class RM010000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
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

        'active account / menu
        Master.setActiveMenu("APP", "FRM010000")
        'active account / menu

        If IsPostBack = False Then
            bindCounter()
            bindForm()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
        End If
    End Sub

#End Region

#Region "Function"
    Function bindCounter()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  count(1) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_por_hdr  ")
        Query.Append("  left join ogm_warehouse on ogm_por_hdr.warehouse = ogm_warehouse.w_code ")
        Query.Append("  left join ogm_vendor [PO] on ogm_por_hdr.vendor = [PO].v_code ")
        Query.Append("where ")
        Query.Append("  ogm_por_hdr.post = 1 ")
        Query.Append("  and ogm_por_hdr.rvrs = 0 ")
        Query.Append("  and datediff(day,ogm_por_hdr.PostedDate,getdate()) between 0 and 90 ")
        Query.Append("  and ogm_por_hdr.IsOSM_IR = 1 ")
        'get query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    spn01Total.InnerText = DR("Total") & " OSM Receive Material(s)"
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function
    Function bindForm()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ogm_por_hdr.r_code [Code] ")
        Query.Append("  ,ogm_por_hdr.reference [RRNo] ")
        Query.Append("  ,Format(ogm_por_hdr.trx_date, 'MM/dd/yyyy') [RRDate] ")
        Query.Append("  ,ogm_warehouse.warehouse [WhseName] ")
        Query.Append("  ,isnull([PO].vendor,'') [VenName] ")
        Query.Append("  ,(case when ogm_por_hdr.rvrs = 0 then 'Accepted' else 'Cancelled' end) [Status] ")
        Query.Append("  ,ogm_por_hdr.CreatedBy [EmpNo] ")
        Query.Append("  ,dbo.ProperCase([EMP].first_name) [CreatedBy] ")
        Query.Append("  ,'assets/media/svg/apps/FRM000009.svg' [Icon] ")
        Query.Append("from ")
        Query.Append("  ogm_por_hdr  ")
        Query.Append("  left join ogm_warehouse on ogm_por_hdr.warehouse = ogm_warehouse.w_code ")
        Query.Append("  left join ogm_vendor [PO] on ogm_por_hdr.vendor = [PO].v_code ")
        Query.Append("  left join employee [EMP] on ogm_por_hdr.CreatedBy = [EMP].emp_no ")
        Query.Append("where ")
        Query.Append("  ogm_por_hdr.post = 1 ")
        Query.Append("  and ogm_por_hdr.rvrs = 0 ")
        Query.Append("  and datediff(day,ogm_por_hdr.PostedDate,getdate()) between 0 and 90 ")
        Query.Append("  and ogm_por_hdr.IsOSM_IR = 1 ")
        Query.Append("order by ")
        Query.Append("   [RRNo] desc")
        'get query

        'variable
        Dim FormDataTable As DataTable = New DataTable()
        'FormDataTable.Columns.Add(New DataColumn("Code"))
        FormDataTable.Columns.Add(New DataColumn("RRNo"))
        FormDataTable.Columns.Add(New DataColumn("RRDate"))
        FormDataTable.Columns.Add(New DataColumn("WhseName"))
        FormDataTable.Columns.Add(New DataColumn("VenName"))
        FormDataTable.Columns.Add(New DataColumn("CreatedBy"))
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    'variable
                    Dim ID As String = "<a href='RM010100-DTL-" & DR("Code") & "' class='text-primary'>" & DR("RRNo") & "</a>"
                    Dim Vendor As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px'><img alt='' class='w-100' src='" & DR("Icon") & "' /></div>&nbsp" & DR("VenName") & "</div>"
                    Dim CreatedBy As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("EmpNo") & ".png)'></div></div>&nbsp" & DR("CreatedBy") & "</div>"

                    FormDataTable.Rows.Add(ID, DR("RRDate"), Vendor, DR("WhseName"), CreatedBy)

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        FormDataSet = New DataSet()
        FormDataSet.Tables.Add(FormDataTable)

    End Function
#End Region

End Class