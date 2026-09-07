Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net.Http
Imports System.Net.PeerToPeer.Collaboration
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.WebSockets
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports NET.FINRTDatasetTableAdapters
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class DSB240000HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim pFormCode = context.Request("pFormCode")
            Dim pFunction = context.Request("pFunction")
            Dim pType = context.Request("pType")
            'general parameter

            If pFunction = "Dropdown" And pType = "Get Record" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Dropdown_Get_Record(pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Dropdown" And pType = "Get Record (ID)" Then

                Dim pTblName = context.Request("pTblName")
                Dim pTblCode = context.Request("pTblCode")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Dropdown_Get_Record_ID(pTblName, pTblCode, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "DSB240000" And pType = "Get-Issuance-Header" Then

                Dim json As String = Me.Get_Issuance_Header()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Stock-Volume" Then

                Dim json As String = Me.Get_Stock_Volume()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Issuance-Warehouse" Then

                Dim json As String = Me.Get_Issuance_Warehouse()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Issued-Item" Then

                Dim json As String = Me.Get_Issued_Item()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Percentage-Item" Then

                Dim json As String = Me.Get_Percentage_Item()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Percentage-Filter" Then

                Dim pWarehouse = context.Request("pWarehouse")
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")

                Dim json As String = Me.Get_Percentage_Filter(pWarehouse, pDateFrom, pDateTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Progress-Item" Then

                Dim json As String = Me.Get_Progress_Item()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Progress-Filter" Then

                Dim pStatus = context.Request("pStatus")
                Dim pFormStatus = context.Request("pFormStatus")
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")

                Dim json As String = Me.Get_Progress_Filter(pStatus, pFormStatus, pDateFrom, pDateTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Moving-PO" Then

                Dim json As String = Me.Get_Moving_PO()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Moving-PO-Filter" Then

                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")

                Dim json As String = Me.Get_Moving_PO_Filter(pDateFrom, pDateTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-PO-Detail" Then

                Dim pPRNo = context.Request("pPRNo")

                Dim json As String = Me.Get_PO_Detail(pPRNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Moving-SR" Then

                Dim json As String = Me.Get_Moving_SR()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Moving-SR-Filter" Then

                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")

                Dim json As String = Me.Get_Moving_SR_Filter(pDateFrom, pDateTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-SR-Detail" Then

                Dim pPRNo = context.Request("pPRNo")

                Dim json As String = Me.Get_SR_Detail(pPRNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-PR-Status" Then

                Dim json As String = Me.Get_PR_Status()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-PR-Stage" Then

                Dim json As String = Me.Get_PR_Stage()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Stage-Filter" Then

                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")

                Dim json As String = Me.Get_Stage_Filter(pDateFrom, pDateTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Stock-Warehouse" Then

                Dim json As String = Me.Get_Stock_Warehouse()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Stock-Category" Then

                Dim json As String = Me.Get_Stock_Category()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Stock-Inventory" Then

                Dim json As String = Me.Get_Stock_Inventory()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Warehouse - Get Record : Item" Then

                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.Warehouse_Get_Record_Item(pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Warehouse - Get Record : Filter" Then

                Dim pWarehouse = context.Request("pWarehouse")
                Dim pItemCode = context.Request("pItemCode")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.Warehouse_Get_Record_Filter(pWarehouse, pItemCode, pDate)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Stock-Detail" Then

                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.Get_Stock_Detail(pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Actual-Usage" Then

                Dim json As String = Me.Get_Actual_Usage()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Incoming-Stock" Then

                Dim json As String = Me.Get_Incoming_Stock()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Incoming-Filter" Then

                Dim pWarehouse = context.Request("pWarehouse")
                Dim pVendor = context.Request("pVendor")

                Dim json As String = Me.Get_Incoming_Filter(pWarehouse, pVendor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-Projected-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pEstimate = context.Request("pEstimate")
                Dim pProject = context.Request("pProject")
                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.Get_Projected_Filter(pCategory, pEstimate, pProject, pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB240000" And pType = "Get-PR-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pProject = context.Request("pProject")
                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.Get_PR_Filter(pCategory, pProject, pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#Region "Dropdown"
    Function Dropdown_Get_Record(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Get_Status" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].status [ID] ")
            Query.Append("   ,[A].status [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].status [Order2] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].status != '' AND [A].status is not null ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_ItemCategory" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].ic_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_item_cat [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].lock, 0) = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_BOQCategory" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].Category [ID] ")
            Query.Append("   ,[A].Category [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Category [Order2] ")
            Query.Append("from ")
            Query.Append("   Parm_CECategory [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].lock, 0) = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Estimate" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].CECode [ID] ")
            Query.Append("   ,[A].Title [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Title [Order2] ")
            Query.Append("from ")
            Query.Append("   Trxn_CEHdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].Post = 1 ")
            Query.Append("  and [A].Rvrs = 0 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Batch" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].Batch [ID] ")
            Query.Append("   ,[A].Batch [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Batch [Order2] ")
            Query.Append("from ")
            Query.Append("   Trxn_CEHdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].Post = 1 ")
            Query.Append("  and [A].Rvrs = 0 ")
            Query.Append("  and ISNULL([A].Batch, '') != '' ")
            Query.Append("  and ISNULL([A].Batch, '') != '-' ")
            Query.Append("  and [A].Category in ('House Construction', 'House Construction - CCI') ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Warehouse" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].w_code [ID] ")
            Query.Append("   ,[A].warehouse [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].warehouse [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_warehouse [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        End If
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .Name = DR("Name")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Function Dropdown_Get_Record_ID(pTblName, pTblCode, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Get_Estimate" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].CECode [ID] ")
            Query.Append("   ,[A].Title [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Title [Order2] ")
            Query.Append("from ")
            Query.Append("   Trxn_CEHdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].Post = 1 ")
            Query.Append("  and [A].Rvrs = 0 ")
            Query.Append("  and [A].Category = @pTblCode ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Batch" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].Batch [ID] ")
            Query.Append("   ,[A].Batch [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Batch [Order2] ")
            Query.Append("from ")
            Query.Append("   Trxn_CEHdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].Post = 1 ")
            Query.Append("  and [A].Rvrs = 0 ")
            Query.Append("  and [A].Category = @pTblCode ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Project" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].SubdCode [ID] ")
            Query.Append("   ,[B].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[B].description [Order2] ")
            Query.Append("from ")
            Query.Append("   Trxn_CEHdr [A] ")
            Query.Append("   left join subdivision [B] on [A].SubdCode = [B].code ")
            Query.Append("where ")
            Query.Append("  [A].Post = 1 ")
            Query.Append("  and [A].Rvrs = 0 ")
            Query.Append("  and ISNULL([A].SubdCode, '') != '' ")
            Query.Append("  and [A].Category = @pTblCode ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        End If
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pTblCode", pTblCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .Name = DR("Name")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
#End Region

#Region "DSB240000"
    Function Get_Issuance_Header()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select COUNT([SINo]) from (select COUNT(SINo) [SINo] from SIDtl where Post = 1 and Cancelled = 0 and YEAR(CreatedDate) = YEAR(GETDATE()) and MONTH(CreatedDate) = MONTH(GETDATE()) group by SINo) [Tbl]), 0) [Overall] ")
        Query.Append("  ,ISNULL((select COUNT([A].ItemName) from SIDtl [A] left join ogm_item [B] on [A].ItemCode = [B].i_code where YEAR([A].CreatedDate) = YEAR(GETDATE()) and MONTH([A].CreatedDate) = MONTH(GETDATE()) and [A].Post = 1 and [A].Cancelled = 0), 0) [Posted] ")
        'Query.Append("  ,ISNULL((select SUM([A].qty) from SIDtl [A] left join ogm_item [B] on [A].ItemCode = [B].i_code left join ogm_item_cat [C] on [B].item_cat = [C].ic_code where YEAR([A].CreatedDate) = YEAR(GETDATE()) and MONTH([A].CreatedDate) = MONTH(GETDATE()) and [C].ic_code = 'MN2018100003' and [A].Post = 1 and [A].Cancelled = 0), 0) [Posted] ")
        Query.Append("  ,ISNULL((select COUNT(1) from SIDtl where Post = 0 and Cancelled = 0 and YEAR(CreatedDate) = YEAR(GETDATE()) and MONTH(CreatedDate) = MONTH(GETDATE())), 0) [Pending] ")
        Query.Append("  ,ISNULL((select COUNT(1) from(select (CASE WHEN ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and [B].year = [A].year - 1), 0) = 0 THEN 100 ElSE ([A].qty / ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and [B].year = [A].year - 1), 0) * 100) END) [Percentage] from ItemBalance [A] where[A].year = YEAR(GETDATE()) and [A].period = MONTH(GETDATE()) and ISNULL([A].ClassName, '') != '' and [A].qty > 0) [Tbl] where [Percentage] <= 40), 0) [LowStock] ")
        Query.Append("  ,ISNULL((select COUNT([A].ItemCode) from ItemBalance [A] where [A].year = YEAR(GETDATE()) and [A].period = MONTH(GETDATE()) and ISNULL([A].ClassCode, '') != '' and [A].qty > 0), 0) [TotalStock] ")
        Query.Append("OPTION (RECOMPILE) ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Overvall = DR("Overall"),
                        .Posted = DR("Posted"),
                        .Pending = DR("Pending"),
                        .LowStock = DR("LowStock"),
                        .TotalStock = DR("TotalStock")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Stock_Volume()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  COUNT([A].SINo) [Total] ")
        Query.Append("  ,SUM([A].qty) [VolQty] ")
        Query.Append("  ,YEAR([A].PostedDate) [Yr] ")
        Query.Append("  ,MONTH([A].PostedDate) [MnthNo] ")
        Query.Append("  ,FORMAT([A].PostedDate, 'MMM') [Mnth] ")
        Query.Append("from ")
        Query.Append("   SIDtl [A] ")
        Query.Append("   left join ogm_item [B] on [A].ItemCode = [B].i_code ")
        Query.Append("   left join ogm_item_cat [C] on [B].item_cat = [C].ic_code ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  AND [A].Cancelled = 0 ")
        Query.Append("  AND [A].PostedDate >= DATEADD(MONTH, -5,DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  AND [A].PostedDate < DATEADD(MONTH, 1,DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  AND [C].ic_code = 'MN2018100003' ")
        Query.Append("group by ")
        Query.Append("  YEAR([A].PostedDate) ")
        Query.Append("  ,MONTH([A].PostedDate) ")
        Query.Append("  ,FORMAT([A].PostedDate, 'MMM') ")
        Query.Append("order by ")
        Query.Append("  [Yr], [MnthNo] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Total = DR("Total"),
                        .VolQty = DR("VolQty"),
                        .Yr = DR("Yr"),
                        .MonthNo = DR("MnthNo"),
                        .Month = DR("Mnth")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Issuance_Warehouse()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 7 ")
        Query.Append("  [DeliveredCount] ")
        Query.Append("  ,[PartialCount] ")
        Query.Append("  ,[PendingCount] ")
        Query.Append("  ,[WhseName] ")
        Query.Append("  ,[WhseCode] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  ISNULL((select COUNT(1) from ogm_pr_dtl [DTL] left join ogm_pr_hdr [HDR] on [DTL].pr_code = [HDR].pr_code LEFT join SIDtl [A] on [HDR].form_no = [A].PRNo and [DTL].seq_no = [A].PRSeqNo where [DTL].for_sr = [A].qty and [A].Post = 1 and [A].Cancelled = 0 and YEAR([A].CreatedDate) = YEAR(GETDATE()) and MONTH([A].CreatedDate) = MONTH(GETDATE()) and [A].WhseCode = ogm_warehouse.w_code), 0) [DeliveredCount] ")
        Query.Append("  ,ISNULL((select COUNT(1) from ogm_pr_dtl [DTL] left join ogm_pr_hdr [HDR] on [DTL].pr_code = [HDR].pr_code LEFT join SIDtl [A] on [HDR].form_no = [A].PRNo and [DTL].seq_no = [A].PRSeqNo where [DTL].for_sr > [A].qty and [A].Post = 1 and [A].Cancelled = 0 and YEAR([A].CreatedDate) = YEAR(GETDATE()) and MONTH([A].CreatedDate) = MONTH(GETDATE()) and [A].WhseCode = ogm_warehouse.w_code), 0) [PartialCount] ")
        Query.Append("  ,ISNULL((select COUNT(1) from ogm_pr_dtl [DTL] left join ogm_pr_hdr [HDR] on [DTL].pr_code = [HDR].pr_code LEFT join SIDtl [A] on [HDR].form_no = [A].PRNo and [DTL].seq_no = [A].PRSeqNo where [A].Post = 0 and [A].Cancelled = 0 and YEAR([A].CreatedDate) = YEAR(GETDATE()) and MONTH([A].CreatedDate) = MONTH(GETDATE()) and [A].WhseCode = ogm_warehouse.w_code), 0) [PendingCount] ")
        Query.Append("  ,w_code [WhseCode] ")
        Query.Append("  ,warehouse [WhseName] ")
        Query.Append("from ")
        Query.Append("  ogm_warehouse ")
        Query.Append("where ")
        Query.Append("  ISNULL(ogm_warehouse.lock, 0) = 1) [Tbl] ")
        Query.Append("where ")
        Query.Append("  [DeliveredCount] > 0 ")
        Query.Append("  OR [PartialCount] > 0 ")
        Query.Append("  OR [PendingCount] > 0 ")
        Query.Append("order by ")
        Query.Append("  [DeliveredCount] DESC, [PartialCount] DESC, [PendingCount] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Delivered = DR("DeliveredCount"),
                        .Partial = DR("PartialCount"),
                        .Pending = DR("PendingCount"),
                        .WhseCode = DR("WhseCode"),
                        .WhseName = DR("WhseName")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Issued_Item()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 10 ")
        Query.Append("  [A].ItemName ")
        Query.Append("  ,SUM([A].Qty) [QtyIssued] ")
        Query.Append("from ")
        Query.Append("  SIDtl [A] ")
        Query.Append("  left join ogm_item [B] on [A].ItemCode = [B].i_code ")
        Query.Append("  left join ogm_item_cat [C] on [B].item_cat = [C].ic_code ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  and [A].Cancelled = 0 ")
        Query.Append("  and [A].PostedDate >= DATEADD(MONTH, -6, GETDATE()) ")
        Query.Append("  and [C].ic_code = 'MN2018100003' ")
        Query.Append("group by ")
        Query.Append("  [A].ItemName ")
        Query.Append("order by ")
        Query.Append("  SUM([A].Qty) DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ItemName = DR("ItemName"),
                        .QtyIssued = DR("QtyIssued")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Moving_PO()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [B].form_no [PRNo] ")
        Query.Append("  ,ISNULL((select ISNULL(STRING_AGG([PO].PONO, ','), '') from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), '') [PONo] ")
        Query.Append("  ,(case when [C].Status = 'Accepted' then 'Approved' when [C].Status = 'Cancelled' then 'Cancelled' else 'On-Going' end) [FormStatus] ")
        Query.Append("  ,[A].item [ItemName] ")
        Query.Append("  ,[A].unit [Unit] ")
        Query.Append("  ,[A].ForPO [PRQty] ")
        Query.Append("  ,ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) [POQty] ")
        Query.Append("  ,([A].ForPO - ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0)) [Balance] ")
        Query.Append("  ,(case when ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) = 0 then 0  ")
        Query.Append("         else (ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) / [A].ForPO) * 100 end) [Percentage]  ")
        Query.Append("  ,CAST(100 * SUM(CASE WHEN (ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) / [A].ForPO) >= 0.95 THEN 1 ELSE 0 END) OVER (PARTITION By [B].form_no) / COUNT(1) OVER (PARTITION By [B].form_no) AS decimal(21, 2)) [Overall] ")
        Query.Append("  ,[D].fullname [Requestor] ")
        Query.Append("  ,[E].fullname [Purchaser] ")
        Query.Append("  ,ISNULL((select top 1 [PO].WhseName from PODtl [PO] where [PO].Post = 1 and [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), '') [Warehouse] ")
        Query.Append("  ,[B].Category [Category] ")
        Query.Append("  ,[C].remarks [PRRemarks] ")
        Query.Append("  ,FORMAT([C].created_date, 'MM/dd/yyyy') [PRDate] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT(oop_form_dtl_appr.updated_date, 'MM/dd/yyyy') from oop_form_dtl_appr left join employee on oop_form_dtl_appr.approver = employee.emp_no where employee.dept_code = '2014000003' and oop_form_dtl_appr.f_code = [B].form_no order by seq_no), '') [ApprDate] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
        Query.Append("  left join oop_form_hdr [C] on [B].form_no = [C].f_code ")
        Query.Append("  left join employee [D] on [C].created_by = [D].emp_no ")
        Query.Append("  left join employee [E] on [A].Purchaser = [E].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].ForPO > 0 ")
        Query.Append("  and [C].status not in ('Cancelled', 'Declined') ")
        Query.Append("  and [C].created_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0) ")
        Query.Append("  and [C].created_date < GETDATE() ")
        Query.Append("order by ")
        Query.Append("  [B].form_no DESC ")
        'get query 

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .PONo = DR("PONo"),
                        .FormStatus = DR("FormStatus"),
                        .ItemName = DR("ItemName"),
                        .Unit = DR("Unit"),
                        .PRQty = DR("PRQty"),
                        .POQty = DR("POQty"),
                        .Balance = DR("Balance"),
                        .Percentage = DR("Percentage"),
                        .Overall = DR("Overall"),
                        .Requestor = DR("Requestor"),
                        .Purchaser = DR("Purchaser"),
                        .Warehouse = DR("Warehouse"),
                        .Category = DR("Category"),
                        .PRRemarks = DR("PRRemarks"),
                        .PRDate = DR("PRDate"),
                        .ApprDate = DR("ApprDate")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Moving_PO_Filter(pDateFrom, pDateTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [B].form_no [PRNo] ")
        Query.Append("  ,ISNULL((select ISNULL(STRING_AGG([PO].PONO, ','), '') from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), '') [PONo] ")
        Query.Append("  ,(case when [C].Status = 'Accepted' then 'Approved' when [C].Status = 'Cancelled' then 'Cancelled' else 'On-Going' end) [FormStatus] ")
        Query.Append("  ,[A].item [ItemName] ")
        Query.Append("  ,[A].unit [Unit] ")
        Query.Append("  ,[A].ForPO [PRQty] ")
        Query.Append("  ,ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) [POQty] ")
        Query.Append("  ,([A].ForPO - ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0)) [Balance] ")
        Query.Append("  ,(case when ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) = 0 then 0  ")
        Query.Append("         else (ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) / [A].ForPO) * 100 end) [Percentage]  ")
        Query.Append("  ,CAST(100 * SUM(CASE WHEN (ISNULL((select SUM([PO].Qty) from PODtl [PO] where [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), 0) / [A].ForPO) >= 0.95 THEN 1 ELSE 0 END) OVER (PARTITION By [B].form_no) / COUNT(1) OVER (PARTITION By [B].form_no) AS decimal(21, 2)) [Overall] ")
        Query.Append("  ,[D].fullname [Requestor] ")
        Query.Append("  ,[E].fullname [Purchaser] ")
        Query.Append("  ,ISNULL((select top 1 [PO].WhseName from PODtl [PO] where [PO].Post = 1 and [PO].Rvrs = 0 and [PO].PRNo = [B].form_no and [PO].PRSeqNo = [A].seq_no), '') [Warehouse] ")
        Query.Append("  ,[B].Category [Category] ")
        Query.Append("  ,[C].remarks [PRRemarks] ")
        Query.Append("  ,FORMAT([C].created_date, 'MM/dd/yyyy') [PRDate] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT(oop_form_dtl_appr.updated_date, 'MM/dd/yyyy') from oop_form_dtl_appr left join employee on oop_form_dtl_appr.approver = employee.emp_no where employee.dept_code = '2014000003' and oop_form_dtl_appr.f_code = [B].form_no order by seq_no), '') [ApprDate] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
        Query.Append("  left join oop_form_hdr [C] on [B].form_no = [C].f_code ")
        Query.Append("  left join employee [D] on [C].created_by = [D].emp_no ")
        Query.Append("  left join employee [E] on [A].Purchaser = [E].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].ForPO > 0 ")
        Query.Append("  and [C].status not in ('Cancelled', 'Declined') ")
        Query.Append("  and FORMAT([C].created_date, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo ")
        Query.Append("order by ")
        Query.Append("  [B].form_no DESC ")
        'get query 


        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                Cmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .PONo = DR("PONo"),
                        .FormStatus = DR("FormStatus"),
                        .ItemName = DR("ItemName"),
                        .Unit = DR("Unit"),
                        .PRQty = DR("PRQty"),
                        .POQty = DR("POQty"),
                        .Balance = DR("Balance"),
                        .Percentage = DR("Percentage"),
                        .Overall = DR("Overall"),
                        .Requestor = DR("Requestor"),
                        .Purchaser = DR("Purchaser"),
                        .Warehouse = DR("Warehouse"),
                        .Category = DR("Category"),
                        .PRRemarks = DR("PRRemarks"),
                        .PRDate = DR("PRDate"),
                        .ApprDate = DR("ApprDate")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_PO_Detail(pPRNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].PRNo ")
        Query.Append("  ,[A].PONo ")
        Query.Append("  ,[A].POCode ")
        Query.Append("  ,ISNULL((select top 1 IRDtl.IRNo from IRDtl where IRDtl.Origin = 'PO' and IRDtl.POCode = [A].POCode and IRDtl.Post = 1 and IRDtl.Cancelled = 0 order by IRDtl.IRDate desc), '') [IRNo] ")
        Query.Append("  ,ISNULL((select top 1 IRDtl.IRCode from IRDtl where IRDtl.Origin = 'PO' and IRDtl.POCode = [A].POCode and IRDtl.Post = 1 and IRDtl.Cancelled = 0 order by IRDtl.IRDate desc), '') [IRCode] ")
        Query.Append("  ,FORMAT([A].PODate, 'MM/dd/yyyy') [PODate] ")
        Query.Append("  ,[A].status ")
        Query.Append("  ,[A].ItemName ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,[A].UMName [Unit] ")
        Query.Append("  ,[A].WhseName [Warehouse] ")
        Query.Append("  ,[A].VenName [Supplier] ")
        Query.Append("  ,(CASE WHEN [A].DlvrType = 0 THEN 'Pick-Up' ")
        Query.Append("         WHEN [A].DlvrType = 1 THEN 'Deliver To' ")
        Query.Append("         WHEN [A].DlvrType = 2 THEN 'For Warehouse Pick-up' END) [DlvrType] ")
        Query.Append("  ,(CASE WHEN [A].DlvrType = 2 THEN FORMAT([A].PickUpDate, 'MM/dd/yyyy') ")
        Query.Append("         ELSE '' END) [PickUpDate] ")
        Query.Append("from ")
        Query.Append("  PODtl [A] ")
        Query.Append("where ")
        Query.Append("  [A].PRNo = @pPRNo ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pPRNo", pPRNo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .PONo = DR("PONo"),
                        .POCode = DR("POCode"),
                        .IRCode = DR("IRCode"),
                        .IRNo = DR("IRNo"),
                        .PODate = DR("PODate"),
                        .Status = DR("status"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .Warehouse = DR("Warehouse"),
                        .Supplier = DR("Supplier"),
                        .DlvrType = DR("DlvrType"),
                        .PickUpDate = DR("PickUpDate")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Moving_SR()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[SINo] ")
        Query.Append("  ,[FormStatus] ")
        Query.Append("  ,(case when [Percentage] >= 95 then 'Delivered' ")
        Query.Append("         when [Percentage] = 0 then 'On-Going' ")
        Query.Append("         else 'Partial' end) [Status] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[PRQty] ")
        Query.Append("  ,[SIQty] ")
        Query.Append("  ,[Balance] ")
        Query.Append("  ,[Percentage] ")
        Query.Append("  ,[Overall] ")
        Query.Append("  ,[Requestor] ")
        Query.Append("  ,[IssuedBy] ")
        Query.Append("  ,[Warehouse] ")
        Query.Append("  ,[Category] ")
        Query.Append("  ,[PRRemarks] ")
        Query.Append("  ,[PRDate] ")
        Query.Append("  ,[ApprDate] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].form_no [PRNo] ")
        Query.Append("  ,ISNULL((select ISNULL(STRING_AGG([SI].SINo, ','), '') from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), '') [SINo] ")
        Query.Append("  ,(case when [C].Status = 'Accepted' then 'Approved' when [C].Status = 'Cancelled' then 'Cancelled' else 'On-Going' end) [FormStatus] ")
        Query.Append("  ,[A].item [ItemName] ")
        Query.Append("  ,[A].unit [Unit] ")
        Query.Append("  ,[A].for_sr [PRQty] ")
        Query.Append("  ,ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) [SIQty] ")
        Query.Append("  ,([A].for_sr - ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0)) [Balance] ")
        Query.Append("  ,(case when ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) = 0 then 0 ")
        Query.Append("         else (ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) / [A].for_sr) * 100 end) [Percentage] ")
        Query.Append("  ,CAST(100 * SUM(CASE WHEN (ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) / [A].for_sr) >= 0.95 THEN 1 ELSE 0 END) OVER (PARTITION By [B].form_no) / COUNT(1) OVER (PARTITION By [B].form_no) AS decimal(21, 2)) [Overall] ")
        Query.Append("  ,[D].fullname [Requestor] ")
        Query.Append("  ,ISNULL((select top 1 [EMP].fullname from SIDtl [SI] left join employee [EMP] on [SI].CreatedBy = [EMP].emp_no where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), '') [IssuedBy] ")
        Query.Append("  ,ISNULL((select top 1 [SI].WhseName from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), '') [Warehouse] ")
        Query.Append("  ,[B].Category [Category] ")
        Query.Append("  ,[C].remarks [PRRemarks] ")
        Query.Append("  ,FORMAT([C].created_date, 'MM/dd/yyyy') [PRDate] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT(oop_form_dtl_appr.updated_date, 'MM/dd/yyyy') from oop_form_dtl_appr left join employee on oop_form_dtl_appr.approver = employee.emp_no where employee.dept_code = '2014000003' and oop_form_dtl_appr.f_code = [B].form_no order by seq_no), '') [ApprDate] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
        Query.Append("  left join oop_form_hdr [C] on [B].form_no = [C].f_code ")
        Query.Append("  left join employee [D] on [C].created_by = [D].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].for_sr > 0 ")
        Query.Append("  and [C].status not in ('Cancelled', 'Declined') ")
        Query.Append("  and [C].created_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0) ")
        Query.Append("  and [C].created_date < GETDATE() ) [Tbl] ")
        Query.Append("order by  ")
        Query.Append("  [PRNo] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .SINo = DR("SINo"),
                        .FormStatus = DR("FormStatus"),
                        .Status = DR("Status"),
                        .ItemName = DR("ItemName"),
                        .Unit = DR("Unit"),
                        .PRQty = DR("PRQty"),
                        .SIQty = DR("SIQty"),
                        .Balance = DR("Balance"),
                        .Percentage = DR("Percentage"),
                        .Overall = DR("Overall"),
                        .Requestor = DR("Requestor"),
                        .IssuedBy = DR("IssuedBy"),
                        .Warehouse = DR("Warehouse"),
                        .Category = DR("Category"),
                        .PRRemarks = DR("PRRemarks"),
                        .PRDate = DR("PRDate"),
                        .ApprDate = DR("ApprDate")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Moving_SR_Filter(pDateFrom, pDateTo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[SINo] ")
        Query.Append("  ,[FormStatus] ")
        Query.Append("  ,(case when [Percentage] >= 95 then 'Delivered' ")
        Query.Append("         when [Percentage] = 0 then 'On-Going' ")
        Query.Append("         else 'Partial' end) [Status] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[PRQty] ")
        Query.Append("  ,[SIQty] ")
        Query.Append("  ,[Balance] ")
        Query.Append("  ,[Percentage] ")
        Query.Append("  ,[Overall] ")
        Query.Append("  ,[Requestor] ")
        Query.Append("  ,[IssuedBy] ")
        Query.Append("  ,[Warehouse] ")
        Query.Append("  ,[Category] ")
        Query.Append("  ,[PRRemarks] ")
        Query.Append("  ,[PRDate] ")
        Query.Append("  ,[ApprDate] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].form_no [PRNo] ")
        Query.Append("  ,ISNULL((select ISNULL(STRING_AGG([SI].SINo, ','), '') from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), '') [SINo] ")
        Query.Append("  ,(case when [C].Status = 'Accepted' then 'Approved' when [C].Status = 'Cancelled' then 'Cancelled' else 'On-Going' end) [FormStatus] ")
        Query.Append("  ,[A].item [ItemName] ")
        Query.Append("  ,[A].unit [Unit] ")
        Query.Append("  ,[A].for_sr [PRQty] ")
        Query.Append("  ,ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) [SIQty] ")
        Query.Append("  ,([A].for_sr - ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0)) [Balance] ")
        Query.Append("  ,(case when ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) = 0 then 0 ")
        Query.Append("         else (ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) / [A].for_sr) * 100 end) [Percentage] ")
        Query.Append("  ,CAST(100 * SUM(CASE WHEN (ISNULL((select SUM([SI].Qty) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), 0) / [A].for_sr) >= 0.95 THEN 1 ELSE 0 END) OVER (PARTITION By [B].form_no) / COUNT(1) OVER (PARTITION By [B].form_no) AS decimal(21, 2)) [Overall] ")
        Query.Append("  ,[D].fullname [Requestor] ")
        Query.Append("  ,ISNULL((select top 1 [EMP].fullname from SIDtl [SI] left join employee [EMP] on [SI].CreatedBy = [EMP].emp_no where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), '') [IssuedBy] ")
        Query.Append("  ,ISNULL((select top 1 [SI].WhseName from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no), '') [Warehouse] ")
        Query.Append("  ,[B].Category [Category] ")
        Query.Append("  ,[C].remarks [PRRemarks] ")
        Query.Append("  ,FORMAT([C].created_date, 'MM/dd/yyyy') [PRDate] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT(oop_form_dtl_appr.updated_date, 'MM/dd/yyyy') from oop_form_dtl_appr left join employee on oop_form_dtl_appr.approver = employee.emp_no where employee.dept_code = '2014000003' and oop_form_dtl_appr.f_code = [B].form_no order by seq_no), '') [ApprDate] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
        Query.Append("  left join oop_form_hdr [C] on [B].form_no = [C].f_code ")
        Query.Append("  left join employee [D] on [C].created_by = [D].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].for_sr > 0 ")
        Query.Append("  and [C].status not in ('Cancelled', 'Declined') ")
        Query.Append("  and FORMAT([C].created_date, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo ) [Tbl] ")
        Query.Append("order by  ")
        Query.Append("  [PRNo] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                Cmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .SINo = DR("SINo"),
                        .FormStatus = DR("FormStatus"),
                        .Status = DR("Status"),
                        .ItemName = DR("ItemName"),
                        .Unit = DR("Unit"),
                        .PRQty = DR("PRQty"),
                        .SIQty = DR("SIQty"),
                        .Balance = DR("Balance"),
                        .Percentage = DR("Percentage"),
                        .Overall = DR("Overall"),
                        .Requestor = DR("Requestor"),
                        .IssuedBy = DR("IssuedBy"),
                        .Warehouse = DR("Warehouse"),
                        .Category = DR("Category"),
                        .PRRemarks = DR("PRRemarks"),
                        .PRDate = DR("PRDate"),
                        .ApprDate = DR("ApprDate")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_SR_Detail(pPRNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].PRNo ")
        Query.Append("  ,[A].SINo ")
        Query.Append("  ,[A].GPNo ")
        Query.Append("  ,[A].SICode ")
        Query.Append("  ,FORMAT([A].SIDate, 'MM/dd/yyyy') [SIDate] ")
        Query.Append("  ,(CASE WHEN ISNULL([A].post, 0) = 0 and ISNULL([A].Cancelled, 0) = 0 THEN 'Processing' ")
        Query.Append("         WHEN ISNULL([A].post, 0) = 1 and ISNULL([A].Cancelled, 0) = 0 THEN 'Posted' ")
        Query.Append("         WHEN ISNULL([A].post, 0) = 1 and ISNULL([A].Cancelled, 0) = 1 THEN 'Cancelled' END) [Status] ")
        Query.Append("  ,[A].ItemName ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,[A].UMName [Unit] ")
        Query.Append("  ,[A].WhseName [Warehouse] ")
        Query.Append("  ,[A].Type [Type] ")
        Query.Append("  ,[A].TrxnType [TrxnType] ")
        Query.Append("  ,[A].TrxnName [ChargeTo] ")
        Query.Append("  ,FORMAT([A].CreatedDate, 'MM/dd/yyyy') [SICreatedDate] ")
        Query.Append("from ")
        Query.Append("  SIDtl [A] ")
        Query.Append("where ")
        Query.Append("  [A].PRNo = @pPRNo ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pPRNo", pPRNo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .SINo = DR("SINo"),
                        .GPNo = DR("GPNo"),
                        .SICode = DR("SICode"),
                        .SIDate = DR("SIDate"),
                        .Status = DR("Status"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .Type = DR("Type"),
                        .Warehouse = DR("Warehouse"),
                        .TrxnType = DR("TrxnType"),
                        .ChargeTo = DR("ChargeTo"),
                        .SICreatedDate = DR("SICreatedDate")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Percentage_Item()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Category] ")
        Query.Append("  ,[Overall] ")
        Query.Append("  ,(CAST([Overall] AS DECIMAL(21, 2)) / CAST([Total] AS DECIMAL(21, 2))) * 100 [Percent] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].ICName [Category] ")
        Query.Append("  ,COUNT([B].ICName) [Overall] ")
        Query.Append("  ,ISNULL((select COUNT(1) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].TrxnType LIKE '%OSM Project%'), 0) [Total] ")
        Query.Append("from ")
        Query.Append("  SIDtl [A] ")
        Query.Append("  left join Item [B] on [A].ItemCode = [B].ItemCode ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  and [A].Cancelled = 0 ")
        Query.Append("  and [A].TrxnType LIKE '%OSM Project%' ")
        Query.Append("group by ")
        Query.Append("  [B].ICName) [Tbl] ")
        Query.Append("where ")
        Query.Append("  ISNULL([Category], '') != '' ")
        Query.Append("order by ")
        Query.Append("  [Overall] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Category = DR("Category"),
                        .Overall = DR("Overall"),
                        .Percent = DR("Percent")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Percentage_Filter(pWarehouse, pDateFrom, pDateTo)


        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Category] ")
        Query.Append("  ,[Overall] ")
        Query.Append("  ,(CAST([Overall] AS DECIMAL(21, 2)) / CAST([Total] AS DECIMAL(21, 2))) * 100 [Percent] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].ICName [Category] ")
        Query.Append("  ,COUNT([B].ICName) [Overall] ")
        If pWarehouse <> "" Then
            Query.Append("  ,ISNULL((select COUNT(1) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].TrxnType LIKE '%OSM Project%' and [SI].WhseCode = @pWarehouse and FORMAT([SI].SIDate, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo), 0) [Total] ")
        Else
            Query.Append("  ,ISNULL((select COUNT(1) from SIDtl [SI] where [SI].Post = 1 and [SI].Cancelled = 0 and [SI].TrxnType LIKE '%OSM Project%' and FORMAT([SI].SIDate, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo), 0) [Total] ")
        End If
        Query.Append("from ")
        Query.Append("  SIDtl [A] ")
        Query.Append("  left join Item [B] on [A].ItemCode = [B].ItemCode ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  and [A].Cancelled = 0 ")
        Query.Append("  and [A].TrxnType LIKE '%OSM Project%' ")
        If pWarehouse <> "" Then
            Query.Append("  and [A].WhseCode = @pWarehouse ")
        End If
        Query.Append("  and FORMAT([A].SIDate, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo ")
        Query.Append("group by ")
        Query.Append("  [B].ICName) [Tbl] ")
        Query.Append("where ")
        Query.Append("  ISNULL([Category], '') != '' ")
        Query.Append("order by ")
        Query.Append("  [Overall] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                If pWarehouse <> "" Then
                    Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                End If
                Cmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                Cmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Category = DR("Category"),
                        .Overall = DR("Overall"),
                        .Percent = DR("Percent")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Progress_Item()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[PRSeqNo] ")
        Query.Append("  ,[FormStatus] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[PRQty] ")
        Query.Append("  ,[PostedQty] ")
        Query.Append("  ,[PendingQty] ")
        Query.Append("  ,(CASE WHEN [Status] != '' AND [FormStatus] = 'Accepted' AND [PRQty] = [PostedQty] AND ROUND([Percentage], 2) > 95 AND ([PostedQty] - [PRQty]) = 0 THEN 'Delivered' ")
        Query.Append("         WHEN [Status] != '' AND [FormStatus] = 'Accepted' AND [PRQty] > [PostedQty] AND ROUND([Percentage], 2) < 95 AND ([PostedQty] - [PRQty]) != 0 THEN 'Partial' ")
        Query.Append("         WHEN [Status] = '' AND [FormStatus] = 'Accepted' AND [PostedQty] = 0 AND [PendingQty] = 0 THEN 'Pending' ")
        Query.Append("         WHEN [Status] = '' AND [FormStatus] != 'Accepted' AND [PostedQty] = 0 AND [PendingQty] = 0 THEN 'For Approval' END) [Status] ")
        Query.Append("  ,FORMAT([DateRequested], 'MM/dd/yyyy') [DateRequested] ")
        Query.Append("  ,FORMAT([ApprDate], 'MM/dd/yyyy') [ApprDate] ")
        Query.Append("  ,[Type] ")
        Query.Append("  ,[Subdivision] ")
        Query.Append("  ,[Estimate] ")
        Query.Append("  ,[Percentage] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].form_no [PRNo] ")
        Query.Append("  ,[A].seq_no [PRSeqNo] ")
        Query.Append("  ,[C].status [FormStatus] ")
        Query.Append("  ,[A].for_sr [PRQty] ")
        Query.Append("  ,ISNULL((select sum([SI].Qty) from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 1 and [SI].Cancelled = 0 group by [SI].PRNo), 0) [PostedQty] ")
        Query.Append("  ,ISNULL((select sum([SI].Qty) from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 0 and [SI].Cancelled = 0 group by [SI].PRNo), 0) [PendingQty] ")
        Query.Append("  ,IIF(EXISTS(select 1 from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 1 and [SI].Cancelled = 0), 'Exists', '') [Status] ")
        Query.Append("  ,(ISNULL((select sum([SI].Qty) from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 1 and [SI].Cancelled = 0 group by [SI].PRNo), 0) / [A].for_sr) * 100 [Percentage] ")
        Query.Append("  ,[C].created_date [DateRequested] ")
        Query.Append("  ,ISNULL((select top 1 updated_date from oop_form_dtl_appr where f_code = [C].f_code and oop_form_dtl_appr.status != '' order by seq_no desc), '') [ApprDate] ")
        Query.Append("  ,[A].item [ItemName] ")
        Query.Append("  ,[B].justification [Type] ")
        Query.Append("  ,ISNULL((select description from subdivision where code = [B].Subdivision), '') [Subdivision] ")
        Query.Append("  ,ISNULL((CASE WHEN (select Title from Trxn_CEHdr where CECode = [B].CECode) IS NULL then [B].CECode ELSE (select Title from Trxn_CEHdr where CECode = [B].CECode) END), '') [Estimate] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
        Query.Append("  left join oop_form_hdr [C] on [A].pr_code = [C].tbl_code and [C].tbl_from = 'ogm_pr_hdr' ")
        Query.Append("where ")
        Query.Append("  [A].for_sr > 0) [Tbl] ")
        Query.Append("where ")
        Query.Append("  YEAR([ApprDate]) = YEAR(GETDATE()) ")
        Query.Append("  and MONTH([ApprDate]) = MONTH(GETDATE()) ")
        Query.Append("order by ")
        Query.Append("  [ApprDate] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .PRSeqNo = DR("PRSeqNo"),
                        .FormStatus = DR("FormStatus"),
                        .ItemName = DR("ItemName"),
                        .PRQty = DR("PRQty"),
                        .PostedQty = DR("PostedQty"),
                        .PendingQty = DR("PendingQty"),
                        .Status = DR("Status"),
                        .DateRequested = DR("DateRequested"),
                        .ApprDate = DR("ApprDate"),
                        .Type = DR("Type"),
                        .Subdivision = DR("Subdivision"),
                        .Estimate = DR("Estimate"),
                        .Percentage = DR("Percentage")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Progress_Filter(pStatus, pFormStatus, pDateFrom, pDateTo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[PRSeqNo] ")
        Query.Append("  ,[FormStatus] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[PRQty] ")
        Query.Append("  ,[PostedQty] ")
        Query.Append("  ,[PendingQty] ")
        Query.Append("  ,(CASE WHEN [Status] != '' AND [FormStatus] = 'Accepted' AND [PRQty] = [PostedQty] AND ROUND([Percentage], 2) > 95 AND ([PostedQty] - [PRQty]) = 0 THEN 'Delivered' ")
        Query.Append("         WHEN [Status] != '' AND [FormStatus] = 'Accepted' AND [PRQty] > [PostedQty] AND ROUND([Percentage], 2) < 95 AND ([PostedQty] - [PRQty]) != 0 THEN 'Partial' ")
        Query.Append("         WHEN [Status] = '' AND [FormStatus] = 'Accepted' AND [PostedQty] = 0 AND [PendingQty] = 0 THEN 'Pending' ")
        Query.Append("         WHEN [Status] = '' AND [FormStatus] != 'Accepted' AND [PostedQty] = 0 AND [PendingQty] = 0 THEN 'For Approval' END) [Status] ")
        Query.Append("  ,FORMAT([DateRequested], 'MM/dd/yyyy') [DateRequested] ")
        Query.Append("  ,FORMAT([ApprDate], 'MM/dd/yyyy') [ApprDate] ")
        Query.Append("  ,[Type] ")
        Query.Append("  ,[Subdivision] ")
        Query.Append("  ,[Estimate] ")
        Query.Append("  ,[Percentage] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].form_no [PRNo] ")
        Query.Append("  ,[A].seq_no [PRSeqNo] ")
        Query.Append("  ,[C].status [FormStatus] ")
        Query.Append("  ,[A].for_sr [PRQty] ")
        Query.Append("  ,ISNULL((select sum([SI].Qty) from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 1 and [SI].Cancelled = 0 group by [SI].PRNo), 0) [PostedQty] ")
        Query.Append("  ,ISNULL((select sum([SI].Qty) from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 0 and [SI].Cancelled = 0 group by [SI].PRNo), 0) [PendingQty] ")
        Query.Append("  ,IIF(EXISTS(select 1 from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 1 and [SI].Cancelled = 0), 'Exists', '') [Status] ")
        Query.Append("  ,(ISNULL((select sum([SI].Qty) from SIDtl [SI] where [SI].PRNo = [B].form_no and [SI].PRSeqNo = [A].seq_no and [SI].Post = 1 and [SI].Cancelled = 0 group by [SI].PRNo), 0) / [A].for_sr) * 100 [Percentage] ")
        Query.Append("  ,[C].created_date [DateRequested] ")
        Query.Append("  ,ISNULL((select top 1 updated_date from oop_form_dtl_appr where f_code = [C].f_code and oop_form_dtl_appr.status != '' order by seq_no desc), '') [ApprDate] ")
        Query.Append("  ,[A].item [ItemName] ")
        Query.Append("  ,[B].justification [Type] ")
        Query.Append("  ,ISNULL((select description from subdivision where code = [B].Subdivision), '') [Subdivision] ")
        Query.Append("  ,ISNULL((CASE WHEN (select Title from Trxn_CEHdr where CECode = [B].CECode) IS NULL then [B].CECode ELSE (select Title from Trxn_CEHdr where CECode = [B].CECode) END), '') [Estimate] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
        Query.Append("  left join oop_form_hdr [C] on [A].pr_code = [C].tbl_code and [C].tbl_from = 'ogm_pr_hdr' ")
        Query.Append("where ")
        Query.Append("  [A].for_sr > 0) [Tbl] ")
        Query.Append("where ")
        Query.Append("  YEAR([ApprDate]) = YEAR(GETDATE()) ")
        Query.Append("  and MONTH([ApprDate]) = MONTH(GETDATE()) ")
        If pFormStatus = "Accepted" Then
            Query.Append("  and [FormStatus] = @pFormStatus ")
            Query.Append("  and [ApprDate] between @pDateFrom and @pDateTo ")
        ElseIf pFormStatus <> "" Then
            Query.Append("  and [FormStatus] = @pFormStatus ")
            Query.Append("  and [DateRequested] between @pDateFrom and @pDateTo ")
        Else
            Query.Append("  and [DateRequested] between @pDateFrom and @pDateTo ")
        End If
        If pStatus <> "" Then
            Query.Append("  and (CASE WHEN [Status] != '' AND [FormStatus] = 'Accepted' AND [PRQty] = [PostedQty] AND ([PostedQty] - [PRQty]) = 0 THEN 'Delivered' ")
            Query.Append("         WHEN [Status] != '' AND [FormStatus] = 'Accepted' AND [PRQty] > [PostedQty] and ([PostedQty] - [PRQty]) != 0 THEN 'Partial' ")
            Query.Append("         WHEN [Status] = '' AND [FormStatus] = 'Accepted' AND [PostedQty] = 0 AND [PendingQty] = 0 THEN 'Pending' ")
            Query.Append("         WHEN [Status] = '' AND [FormStatus] != 'Accepted' AND [PostedQty] = 0 AND [PendingQty] = 0 THEN 'For Approval' END) = @pStatus ")
        End If
        Query.Append("order by ")
        Query.Append("  [ApprDate] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                If pStatus <> "" Then
                    Cmd.Parameters.AddWithValue("@pStatus", pStatus)
                End If
                Cmd.Parameters.AddWithValue("@pFormStatus", pFormStatus)
                Cmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                Cmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PRNo = DR("PRNo"),
                        .PRSeqNo = DR("PRSeqNo"),
                        .FormStatus = DR("FormStatus"),
                        .ItemName = DR("ItemName"),
                        .PRQty = DR("PRQty"),
                        .PostedQty = DR("PostedQty"),
                        .PendingQty = DR("PendingQty"),
                        .Status = DR("Status"),
                        .DateRequested = DR("DateRequested"),
                        .ApprDate = DR("ApprDate"),
                        .Type = DR("Type"),
                        .Subdivision = DR("Subdivision"),
                        .Estimate = DR("Estimate"),
                        .Percentage = DR("Percentage")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_PR_Status()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select COUNT(1) from (select ISNULL((select top 1 [C].updated_date from oop_form_dtl_appr [C] where [C].f_code = [B].f_code and [C].status != '' order by [C].seq_no desc), '') [ApprDate] from ogm_pr_hdr [A] left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code and [B].tbl_from = 'ogm_pr_hdr' and [B].status = 'Accepted') [Tbl] where YEAR([ApprDate]) = YEAR(GETDATE()) and MONTH([ApprDate]) = MONTH(GETDATE())), 0) [Accepted] ")
        Query.Append("  ,ISNULL((select COUNT(1) from ogm_pr_hdr [A] left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code and [B].tbl_from = 'ogm_pr_hdr' where YEAR([B].created_date) = YEAR(GETDATE()) AND MONTH([B].created_date) = MONTH(GETDATE()) and [B].status not in ('Accepted', 'Cancelled', 'Declined', 'New') ), 0) [OnGoing] ")
        Query.Append("  ,ISNULL((select COUNT(1) from ogm_pr_hdr [A] left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code and [B].tbl_from = 'ogm_pr_hdr' where YEAR([B].created_date) = YEAR(GETDATE()) AND MONTH([B].created_date) = MONTH(GETDATE()) and [B].status in ('New') ), 0) [New] ")
        Query.Append("  ,ISNULL((select COUNT(1) from ogm_pr_hdr [A] left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code and [B].tbl_from = 'ogm_pr_hdr' where YEAR([B].created_date) = YEAR(GETDATE()) AND MONTH([B].created_date) = MONTH(GETDATE()) and [B].status in ('Cancelled', 'Declined') ), 0) [Cancelled] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Accepted = DR("Accepted"),
                        .OnGoing = DR("OnGoing"),
                        .New = DR("New"),
                        .Cancelled = DR("Cancelled")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_PR_Stage()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select COUNT(1) from (select ISNULL((select top 1 [C].updated_date from oop_form_dtl_appr [C] where [C].f_code = [B].f_code and [C].status != '' order by [C].seq_no desc), '') [ApprDate] from ogm_pr_hdr [A] left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code and [B].tbl_from = 'ogm_pr_hdr' and [B].status = 'Accepted') [Tbl] where YEAR([ApprDate]) = YEAR(GETDATE()) and MONTH([ApprDate]) = MONTH(GETDATE())), 0) [PurchaseRequest] ")
        Query.Append("  ,ISNULL((select COUNT([SI]) from(select COUNT(*) [SI] from SIDtl [A] where [A].PRNo != '' and [A].PRNo is not null and [A].Post = 1 and [A].Cancelled = 0 and YEAR([A].PostedDate) = YEAR(GETDATE()) and MONTH([A].PostedDate) = MONTH(GETDATE()) group by [A].PRNo) [Tbl]), 0) [StockIssuance] ")
        Query.Append("  ,ISNULL((select COUNT([PO]) from(select COUNT(*) [PO] from PODtl [A] where [A].PRNo != '' and [A].PRNo is not null and [A].Post = 1 and [A].Rvrs = 0 and YEAR([A].PostedDate) = YEAR(GETDATE()) and MONTH([A].PostedDate) = MONTH(GETDATE()) group by [A].PRNo) [Tbl]), 0) [PurchaseOrder] ")
        Query.Append("  ,ISNULL((select COUNT([IR]) from(select COUNT(*) [IR] from IRDtl [A] where [A].PRNo != '' and [A].PRNo is not null and [A].Post = 1 and [A].Cancelled = 0 and YEAR([A].PostedDate) = YEAR(GETDATE()) and MONTH([A].PostedDate) = MONTH(GETDATE()) group by [A].PRNo) [Tbl]), 0) [Receiving] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PR = DR("PurchaseRequest"),
                        .SI = DR("StockIssuance"),
                        .PO = DR("PurchaseOrder"),
                        .IR = DR("Receiving")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Stage_Filter(pDateFrom, pDateTo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select COUNT(1) from (select ISNULL((select top 1 [C].updated_date from oop_form_dtl_appr [C] where [C].f_code = [B].f_code and [C].status != '' order by [C].seq_no desc), '') [ApprDate] from ogm_pr_hdr [A] left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code and [B].tbl_from = 'ogm_pr_hdr' and [B].status = 'Accepted') [Tbl] where FORMAT([ApprDate], 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo ), 0) [PurchaseRequest] ")
        Query.Append("  ,ISNULL((select COUNT([SI]) from(select COUNT(*) [SI] from SIDtl [A] where [A].PRNo != '' and [A].PRNo is not null and [A].Post = 1 and [A].Cancelled = 0 and FORMAT([A].PostedDate, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo group by [A].PRNo) [Tbl]), 0) [StockIssuance] ")
        Query.Append("  ,ISNULL((select COUNT([PO]) from(select COUNT(*) [PO] from PODtl [A] where [A].PRNo != '' and [A].PRNo is not null and [A].Post = 1 and [A].Rvrs = 0 and FORMAT([A].PostedDate, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo group by [A].PRNo) [Tbl]), 0) [PurchaseOrder] ")
        Query.Append("  ,ISNULL((select COUNT([IR]) from(select COUNT(*) [IR] from IRDtl [A] where [A].PRNo != '' and [A].PRNo is not null and [A].Post = 1 and [A].Cancelled = 0 and FORMAT([A].PostedDate, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo group by [A].PRNo) [Tbl]), 0) [Receiving] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                Cmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .PR = DR("PurchaseRequest"),
                        .SI = DR("StockIssuance"),
                        .PO = DR("PurchaseOrder"),
                        .IR = DR("Receiving")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Stock_Warehouse()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 10 ")
        Query.Append("  COUNT(1) [Count] ")
        Query.Append("  ,[A].WhseName ")
        Query.Append("from ")
        Query.Append("  ItemBalance [A] ")
        Query.Append("where ")
        Query.Append("  [A].year = YEAR(GETDATE()) ")
        Query.Append("  and [A].period = MONTH(GETDATE()) ")
        Query.Append("group by ")
        Query.Append("  [A].WhseName ")
        Query.Append("order by ")
        Query.Append("  [Count] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Warehouse = DR("WhseName"),
                        .Count = DR("Count")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Stock_Category()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 10 ")
        Query.Append("  COUNT(1) [Count] ")
        Query.Append("  ,[A].ClassName ")
        Query.Append("from ")
        Query.Append("  ItemBalance [A] ")
        Query.Append("where ")
        Query.Append("  [A].year = YEAR(GETDATE()) ")
        Query.Append("  and [A].period = MONTH(GETDATE()) ")
        Query.Append("  and ISNULL([A].ClassName, '') != '' ")
        Query.Append("group by ")
        Query.Append("  [A].ClassName ")
        Query.Append("order by ")
        Query.Append("  [Count] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ClassName = DR("ClassName"),
                        .Count = DR("Count")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Stock_Inventory()

        'get query
        Dim Query As New StringBuilder
        'Query.Append("select ")
        'Query.Append("  [Warehouse] ")
        'Query.Append("  ,[WhseCode] ")
        'Query.Append("  ,[TotalStock] ")
        'Query.Append("  ,[Division] ")
        'Query.Append("  ,[Address] ")
        'Query.Append("from ")
        'Query.Append("(select ")
        'Query.Append("  [A].warehouse [Warehouse] ")
        'Query.Append("  ,[A].w_code [WhseCode] ")
        'Query.Append("  ,ISNULL((select COUNT(1) from ItemBalance where ItemBalance.year = YEAR(GETDATE()) and ItemBalance.period = MONTH(GETDATE()) and ISNULL(ItemBalance.ClassCode, '') != '' and ItemBalance.WhseCode = [A].w_code), 0) [TotalStock] ")
        'Query.Append("  ,[B].description [Division] ")
        'Query.Append("  ,ISNULL([A].address, '') [Address] ")
        'Query.Append("from ")
        'Query.Append("  ogm_warehouse [A] ")
        'Query.Append("  left join division [B] on [A].division = [B].div_code ")
        'Query.Append("where ")
        'Query.Append("  ISNULL([A].lock, 0) = 1) [Tbl] ")
        'Query.Append("where ")
        'Query.Append("  [TotalStock] > 0 ")
        'Query.Append("order by ")
        'Query.Append("  [TotalStock] DESC ")
        Query.Append("select ")
        Query.Append("  ItemBalance.Year ")
        Query.Append("  ,ItemBalance.Period ")
        Query.Append("  ,ItemBalance.WhseCode ")
        Query.Append("  ,ItemBalance.WhseName ")
        Query.Append("  ,ItemBalance.ClassCode ")
        Query.Append("  ,ItemBalance.ClassName ")
        Query.Append("  ,ItemBalance.ItemCode ")
        Query.Append("  ,ItemBalance.ItemName ")
        Query.Append("  ,ItemBalance.Qty + isnull((select sum(ItemLedger.Qty) * -1 from ItemLedger where ItemLedger.Year = ItemBalance.Year and ItemLedger.Period = ItemBalance.Period and ItemLedger.TrxDate > GETDATE() and ItemLedger.WhseCode = ItemBalance.WhseCode and ItemLedger.ItemCode = ItemBalance.ItemCode and ItemLedger.UMCode = ItemBalance.UMCode),0) [Qty] ")
        Query.Append("  ,ItemBalance.UMCode ")
        Query.Append("  ,ItemBalance.UMName ")
        Query.Append("  ,ItemBalance.Cost ")
        Query.Append("  ,ItemBalance.Total ")
        Query.Append("  ,(select top 1 replace(replace(ItemLedger.TblFrom,'Trxn_',''),'Hdr','') from ItemLedger where ItemLedger.WhseCode = ItemBalance.WhseCode and ItemLedger.ItemCode = ItemBalance.ItemCode and ItemLedger.UMCode = ItemBalance.UMCode and ItemLedger.Qty > 0 order by ItemLedger.TrxDate desc) [TrxnType] ")
        Query.Append("from ")
        Query.Append("  ItemBalance ")
        Query.Append("where ")
        Query.Append("  Year = YEAR(GETDATE()) ")
        Query.Append("  and Period = MONTH(GETDATE()) ")
        Query.Append("  and [Qty] > 0 ")
        Query.Append("  and ISNULL(ItemCode, '') != '' ")
        Query.Append("order by ")
        Query.Append("  ItemBalance.WhseName ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    '.Warehouse = DR("Warehouse"),
                    '.WhseCode = DR("WhseCode"),
                    '.TotalStock = DR("TotalStock"),
                    '.Division = DR("Division"),
                    '.Address = DR("Address")

                    RecordList.Add(New With {
                        .WhseCode = DR("WhseCode"),
                        .Warehouse = DR("WhseName"),
                        .ClassCode = DR("ClassCode"),
                        .ClassName = DR("ClassName"),
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .UMCode = DR("UMCode"),
                        .UMName = DR("UMName"),
                        .Cost = DR("Cost"),
                        .Total = DR("Total"),
                        .Type = DR("TrxnType")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Warehouse_Get_Record_Item(pWarehouse)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].item [i_code] ")
        Query.Append("  ,isnull([B].lock, 0) [Lock] ")
        Query.Append("  ,[B].item ")
        Query.Append("from ")
        Query.Append("  ogm_item_bal [A] ")
        Query.Append("  left join ogm_item [B] on [A].item = [B].i_code ")
        Query.Append("where ")
        Query.Append("  [A].year = YEAR(GETDATE()) ")
        Query.Append("  and [A].period = MONTH(GETDATE()) ")
        Query.Append("  and [A].qty > 0 ")
        Query.Append("  and [A].warehouse = @pWarehouse ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view mt-1' title='Select Item' onclick=""fn0301GetItem('" & DR("item") & "', '" & DR("i_code") & "', '" & DR("Lock") & "');return false;""><i class='las la-check fs-3'></i></button>")

                    RecordList.Add(New With {
                        .Action = Action.ToString(),
                        .ItemCode = DR("i_code"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center mt-3'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ItemName = DR("item")
                        })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display
    End Function
    Function Warehouse_Get_Record_Filter(pWarehouse, pItemCode, pDate)

        Dim vDate As Date = IIf(pDate = "", Date.Now, pDate)

        'get query
        Dim Query As New StringBuilder
        'Query.Append("select ")
        'Query.Append("  [Warehouse] ")
        'Query.Append("  ,[WhseCode] ")
        'Query.Append("  ,[TotalStock] ")
        'Query.Append("  ,[Division] ")
        'Query.Append("  ,[Address] ")
        'Query.Append("from ")
        'Query.Append("(select ")
        'Query.Append("  [A].warehouse [Warehouse] ")
        'Query.Append("  ,[A].w_code [WhseCode] ")
        'Query.Append("  ,ISNULL((select COUNT(1) from ItemBalance where ItemBalance.year = YEAR(GETDATE()) and ItemBalance.period = MONTH(GETDATE()) and ISNULL(ItemBalance.ClassCode, '') != '' and ItemBalance.WhseCode = [A].w_code), 0) [TotalStock] ")
        'Query.Append("  ,[B].description [Division] ")
        'Query.Append("  ,ISNULL([A].address, '') [Address] ")
        'Query.Append("from ")
        'Query.Append("  ogm_warehouse [A] ")
        'Query.Append("  left join division [B] on [A].division = [B].div_code ")
        'Query.Append("where ")
        'Query.Append("  ISNULL([A].lock, 0) = 1) [Tbl] ")
        'Query.Append("where ")
        'Query.Append("  [TotalStock] > 0 ")
        'Query.Append("order by ")
        'Query.Append("  [TotalStock] DESC ")
        Query.Append("select ")
        Query.Append("  ItemBalance.Year ")
        Query.Append("  ,ItemBalance.Period ")
        Query.Append("  ,ItemBalance.WhseCode ")
        Query.Append("  ,ItemBalance.WhseName ")
        Query.Append("  ,ItemBalance.ClassCode ")
        Query.Append("  ,ItemBalance.ClassName ")
        Query.Append("  ,ItemBalance.ItemCode ")
        Query.Append("  ,ItemBalance.ItemName ")
        Query.Append("  ,ItemBalance.Qty + isnull((select sum(ItemLedger.Qty) * -1 from ItemLedger where ItemLedger.Year = ItemBalance.Year and ItemLedger.Period = ItemBalance.Period and ItemLedger.TrxDate > @Date and ItemLedger.WhseCode = ItemBalance.WhseCode and ItemLedger.ItemCode = ItemBalance.ItemCode and ItemLedger.UMCode = ItemBalance.UMCode),0) [Qty] ")
        Query.Append("  ,ItemBalance.UMCode ")
        Query.Append("  ,ItemBalance.UMName ")
        Query.Append("  ,ItemBalance.Cost ")
        Query.Append("  ,ItemBalance.Total ")
        Query.Append("  ,(select top 1 replace(replace(ItemLedger.TblFrom,'Trxn_',''),'Hdr','') from ItemLedger where ItemLedger.WhseCode = ItemBalance.WhseCode and ItemLedger.ItemCode = ItemBalance.ItemCode and ItemLedger.UMCode = ItemBalance.UMCode and ItemLedger.Qty > 0 order by ItemLedger.TrxDate desc) [TrxnType] ")
        Query.Append("from ")
        Query.Append("  ItemBalance ")
        Query.Append("where ")
        Query.Append("  Year = @Year ")
        Query.Append("  and Period = @Period ")
        Query.Append("  and [Qty] > 0 ")
        Query.Append("  and ISNULL(ItemCode, '') != '' ")
        If pItemCode <> "" Then Query.Append("  and ItemCode = @pItemCode ")
        If pWarehouse <> "" Then Query.Append("  and WhseCode = @pWhseCode ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.Parameters.AddWithValue("@Date", vDate)
                Cmd.Parameters.AddWithValue("@Year", Year(vDate))
                Cmd.Parameters.AddWithValue("@Period", Month(vDate))
                Cmd.Parameters.AddWithValue("@pItemCode", pItemCode)
                Cmd.Parameters.AddWithValue("@pWhseCode", pWarehouse)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    '.Warehouse = DR("Warehouse"),
                    '.WhseCode = DR("WhseCode"),
                    '.TotalStock = DR("TotalStock"),
                    '.Division = DR("Division"),
                    '.Address = DR("Address")

                    RecordList.Add(New With {
                        .WhseCode = DR("WhseCode"),
                        .Warehouse = DR("WhseName"),
                        .ClassCode = DR("ClassCode"),
                        .ClassName = DR("ClassName"),
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .UMCode = DR("UMCode"),
                        .UMName = DR("UMName"),
                        .Cost = DR("Cost"),
                        .Total = DR("Total"),
                        .Type = DR("TrxnType")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Stock_Detail(pWarehouse)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].WhseName [Warehouse] ")
        Query.Append("  ,[A].WhseCode ")
        Query.Append("  ,[A].ItemName ")
        Query.Append("  ,[A].ItemCode ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,[A].UMName [Unit] ")
        Query.Append("  ,[A].ClassName ")
        Query.Append("  ,ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and DATEFROMPARTS([B].Year, [B].period, 1) >= DATEADD(MONTH, -6, DATEFROMPARTS([A].YEAR, [A].Period, 1)) and DATEFROMPARTS([B].year, [B].period, 1) < DATEFROMPARTS([A].year, [A].period, 1)), 0) [PrevAvg] ")
        Query.Append("  ,ISNULL((select top 1 [IR].IRNo from IRDtl [IR] where [IR].WhseCode = [A].WhseCode and [IR].Post = 1 and [IR].Cancelled = 0 and [IR].ItemCode = [A].ItemCode order by [IR].PostedDate DESC), '') [IRNo] ")
        Query.Append("  ,ISNULL((select top 1 [IR].IRCode from IRDtl [IR] where [IR].WhseCode = [A].WhseCode and [IR].Post = 1 and [IR].Cancelled = 0 and [IR].ItemCode = [A].ItemCode order by [IR].PostedDate DESC), '') [IRCode] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT([IR].PostedDate, 'MM/dd/yyyy') from IRDtl [IR] where [IR].WhseCode = [A].WhseCode and [IR].Post = 1 and [IR].Cancelled = 0 and [IR].ItemCode = [A].ItemCode order by [IR].PostedDate DESC), '') [IRDate] ")
        Query.Append("  ,ISNULL((select top 1 CAST([IR].qty AS NVARCHAR) from IRDtl [IR] where [IR].WhseCode = [A].WhseCode and [IR].Post = 1 and [IR].Cancelled = 0 and [IR].ItemCode = [A].ItemCode order by [IR].PostedDate DESC), '') [IRQty] ")
        Query.Append("  ,ISNULL((select top 1 [SI].SINo from SIDtl [SI] where [SI].WhseCode = [A].WhseCode and [SI].Post = 1 and [SI].Cancelled = 0 and [SI].ItemCode = [A].ItemCode order by [SI].PostedDate DESC), '') [SINo] ")
        Query.Append("  ,ISNULL((select top 1 [SI].SICode from SIDtl [SI] where [SI].WhseCode = [A].WhseCode and [SI].Post = 1 and [SI].Cancelled = 0 and [SI].ItemCode = [A].ItemCode order by [SI].PostedDate DESC), '') [SICode] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT([SI].PostedDate, 'MM/dd/yyyy') from SIDtl [SI] where [SI].WhseCode = [A].WhseCode and [SI].Post = 1 and [SI].Cancelled = 0 and [SI].ItemCode = [A].ItemCode order by [SI].PostedDate DESC), '') [SIDate] ")
        Query.Append("  ,ISNULL((select top 1 CAST([SI].qty AS NVARCHAR) from SIDtl [SI] where [SI].WhseCode = [A].WhseCode and [SI].Post = 1 and [SI].Cancelled = 0 and [SI].ItemCode = [A].ItemCode order by [SI].PostedDate DESC), '') [SIQty] ")
        Query.Append("  ,ISNULL((select top 1 [WT].WTNo from WTDtl [WT] where [WT].FromWhseCode = [A].WhseCode and [WT].Post = 1 and [WT].rvrs = 0 and [WT].ItemCode = [A].ItemCode order by [WT].PostedDate DESC), '') [WTNo] ")
        Query.Append("  ,ISNULL((select top 1 [WT].WTCode from WTDtl [WT] where [WT].FromWhseCode = [A].WhseCode and [WT].Post = 1 and [WT].rvrs = 0 and [WT].ItemCode = [A].ItemCode order by [WT].PostedDate DESC), '') [WTCode] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT([WT].PostedDate, 'MM/dd/yyyy') from WTDtl [WT] where [WT].FromWhseCode = [A].WhseCode and [WT].Post = 1 and [WT].rvrs = 0 and [WT].ItemCode = [A].ItemCode order by [WT].PostedDate DESC), '') [WTDate] ")
        Query.Append("  ,ISNULL((select top 1 CAST([WT].qty AS NVARCHAR) from WTDtl [WT] where [WT].FromWhseCode = [A].WhseCode and [WT].Post = 1 and [WT].rvrs = 0 and [WT].ItemCode = [A].ItemCode order by [WT].PostedDate DESC), '') [WTQty] ")
        Query.Append("  ,ISNULL((select top 1 [IC].ConvNo from Trxn_ItemConvertion [IC] where [IC].WhseCode = [A].WhseCode and [IC].Post = 1 and [IC].Rvrs = 0 and [IC].FromItemCode = [A].ItemCode order by [IC].PostedDate DESC), '') [ICNo] ")
        Query.Append("  ,ISNULL((select top 1 [IC].ICCode from Trxn_ItemConvertion [IC] where [IC].WhseCode = [A].WhseCode and [IC].Post = 1 and [IC].Rvrs = 0 and [IC].FromItemCode = [A].ItemCode order by [IC].PostedDate DESC), '') [ICCode] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT([IC].PostedDate, 'MM/dd/yyyy') from Trxn_ItemConvertion [IC] where [IC].WhseCode = [A].WhseCode and [IC].Post = 1 and [IC].Rvrs = 0 and [IC].FromItemCode = [A].ItemCode order by [IC].PostedDate DESC), '') [ICDate] ")
        Query.Append("  ,ISNULL((select top 1 CAST([IC].FromQty AS NVARCHAR) from Trxn_ItemConvertion [IC] where [IC].WhseCode = [A].WhseCode and [IC].Post = 1 and [IC].Rvrs = 0 and [IC].FromItemCode = [A].ItemCode order by [IC].PostedDate DESC), '') [ICQty] ")
        Query.Append("  ,(CASE WHEN ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and DATEFROMPARTS([B].Year, [B].period, 1) >= DATEADD(MONTH, -6, DATEFROMPARTS([A].YEAR, [A].Period, 1)) and DATEFROMPARTS([B].year, [B].period, 1) < DATEFROMPARTS([A].year, [A].period, 1)), 0) = 0 THEN 100 ")
        Query.Append("         WHEN ([A].qty / ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and DATEFROMPARTS([B].Year, [B].period, 1) >= DATEADD(MONTH, -6, DATEFROMPARTS([A].YEAR, [A].Period, 1)) and DATEFROMPARTS([B].year, [B].period, 1) < DATEFROMPARTS([A].year, [A].period, 1)), 0)) * 100 > 100 THEN 100 ")
        Query.Append("         ELSE ([A].qty / ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and DATEFROMPARTS([B].Year, [B].period, 1) >= DATEADD(MONTH, -6, DATEFROMPARTS([A].YEAR, [A].Period, 1)) and DATEFROMPARTS([B].year, [B].period, 1) < DATEFROMPARTS([A].year, [A].period, 1)), 0)) * 100 END) [Percentage] ")
        Query.Append("from ")
        Query.Append("  ItemBalance [A] ")
        Query.Append("where ")
        Query.Append("  [A].year = YEAR(GETDATE()) ")
        Query.Append("  and [A].period = MONTH(GETDATE()) ")
        Query.Append("  and ISNULL([A].ClassName, '') != '' ")
        Query.Append("  and [A].qty	> 0 ")
        Query.Append("  and [A].WhseCode = @pWarehouse ")
        Query.Append("order by ")
        Query.Append("  [A].ItemName ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Warehouse = DR("Warehouse"),
                        .WhseCode = DR("WhseCode"),
                        .ItemName = DR("ItemName"),
                        .ItemCode = DR("ItemCode"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .ClassName = DR("ClassName"),
                        .PrevAvg = DR("PrevAvg"),
                        .IRNo = DR("IRNo"),
                        .IRCode = DR("IRCode"),
                        .IRDate = DR("IRDate"),
                        .IRQty = DR("IRQty"),
                        .SINo = DR("SINo"),
                        .SICode = DR("SICode"),
                        .SIDate = DR("SIDate"),
                        .SIQty = DR("SIQty"),
                        .WTNo = DR("WTNo"),
                        .WTCode = DR("WTCode"),
                        .WTDate = DR("WTDate"),
                        .WTQty = DR("WTQty"),
                        .ICNo = DR("ICNo"),
                        .ICCode = DR("ICCode"),
                        .ICDate = DR("ICDate"),
                        .ICQty = DR("ICQty"),
                        .Percentage = DR("Percentage")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Actual_Usage()

        'get query
        Dim Query As New StringBuilder
        Query.Append("WITH RawData AS ( ")
        Query.Append("  SELECT ")
        Query.Append("    [A].ItemName ")
        Query.Append("    ,ISNULL([A].WhseName, '') [WhseName] ")
        Query.Append("    ,ISNULL([A].WhseCode, '') [WhseCode] ")
        Query.Append("    ,SUM(CASE WHEN [A].period = MONTH(DATEADD(MONTH,-6,GETDATE())) AND [A].year = YEAR(DATEADD(MONTH,-6,GETDATE())) THEN [A].qty ELSE 0 END) [Mnth7] ")
        Query.Append("    ,SUM(CASE WHEN [A].period = MONTH(DATEADD(MONTH,-5,GETDATE())) AND [A].year = YEAR(DATEADD(MONTH,-5,GETDATE())) THEN [A].qty ELSE 0 END) [Mnth6] ")
        Query.Append("    ,SUM(CASE WHEN [A].period = MONTH(DATEADD(MONTH,-4,GETDATE())) AND [A].year = YEAR(DATEADD(MONTH,-4,GETDATE())) THEN [A].qty ELSE 0 END) [Mnth5] ")
        Query.Append("    ,SUM(CASE WHEN [A].period = MONTH(DATEADD(MONTH,-3,GETDATE())) AND [A].year = YEAR(DATEADD(MONTH,-3,GETDATE())) THEN [A].qty ELSE 0 END) [Mnth4] ")
        Query.Append("    ,SUM(CASE WHEN [A].period = MONTH(DATEADD(MONTH,-2,GETDATE())) AND [A].year = YEAR(DATEADD(MONTH,-2,GETDATE())) THEN [A].qty ELSE 0 END) [Mnth3] ")
        Query.Append("    ,SUM(CASE WHEN [A].period = MONTH(DATEADD(MONTH,-1,GETDATE())) AND [A].year = YEAR(DATEADD(MONTH,-1,GETDATE())) THEN [A].qty ELSE 0 END) [Mnth2] ")
        Query.Append("    ,SUM(CASE WHEN [A].period = MONTH(GETDATE()) AND [A].year = YEAR(GETDATE()) THEN [A].qty ELSE 0 END) [Mnth1] ")
        Query.Append("    ,SUM(CASE WHEN (YEAR(GETDATE()) * 12 + MONTH(GETDATE()) - ([A].year * 12 + [A].period)) BETWEEN 0 AND 6 THEN [A].qty ELSE 0 END) [Total] ")
        Query.Append("  FROM ItemBalance [A] ")
        Query.Append("  WHERE ISNULL([A].ClassName, '') != '' AND [A].qty > 0 ")
        Query.Append("  GROUP BY [A].ItemName, [A].WhseName, [A].WhseCode ")
        Query.Append("), ")
        Query.Append("WarehouseSummary AS ( ")
        Query.Append("  SELECT DISTINCT ")
        Query.Append("    R1.ItemName ")
        Query.Append("    ,STUFF(( ")
        Query.Append("      SELECT ' ' + R2.WhseName ")
        Query.Append("      FROM RawData R2 ")
        Query.Append("      WHERE R2.ItemName = R1.ItemName ")
        Query.Append("      GROUP BY R2.WhseName ")
        Query.Append("      FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 1, '') [AllWarehouses] ")
        Query.Append("  FROM RawData R1 ")
        Query.Append(") ")
        Query.Append("SELECT ")
        Query.Append("  [ItemName] ")
        Query.Append("  ,[Parent] ")
        Query.Append("  ,[WhseCode] ")
        Query.Append("  ,[Mnth7] ")
        Query.Append("  ,[Mnth6] ")
        Query.Append("  ,[Mnth5] ")
        Query.Append("  ,[Mnth4] ")
        Query.Append("  ,[Mnth3] ")
        Query.Append("  ,[Mnth2] ")
        Query.Append("  ,[Mnth1] ")
        Query.Append("  ,[Total] ")
        Query.Append("  ,([Total] / 7.0) [AvgMnth] ")
        Query.Append("  ,(CASE WHEN [Total] = 0 THEN 0 ELSE ([Mnth1] / ([Total] / 7.0)) END) [Projection] ")
        Query.Append("  ,[No] ")
        Query.Append("  ,[SearchText] ")
        Query.Append("FROM ( ")
        Query.Append("  SELECT ")
        Query.Append("    R.ItemName [ItemName] ")
        Query.Append("    ,R.ItemName [Parent] ")
        Query.Append("    ,'' [WhseCode] ")
        Query.Append("    ,SUM(R.Mnth7) [Mnth7] ")
        Query.Append("    ,SUM(R.Mnth6) [Mnth6] ")
        Query.Append("    ,SUM(R.Mnth5) [Mnth5] ")
        Query.Append("    ,SUM(R.Mnth4) [Mnth4] ")
        Query.Append("    ,SUM(R.Mnth3) [Mnth3] ")
        Query.Append("    ,SUM(R.Mnth2) [Mnth2] ")
        Query.Append("    ,SUM(R.Mnth1) [Mnth1] ")
        Query.Append("    ,SUM(R.Total) [Total] ")
        Query.Append("    ,0 [No] ")
        Query.Append("    ,R.ItemName + ' ' + ISNULL(WS.AllWarehouses, '') [SearchText] ")
        Query.Append("  FROM RawData R ")
        Query.Append("  LEFT JOIN WarehouseSummary WS ON R.ItemName = WS.ItemName ")
        Query.Append("  GROUP BY R.ItemName, WS.AllWarehouses ")
        Query.Append("  UNION ALL ")
        Query.Append("  SELECT ")
        Query.Append("    R.WhseName [ItemName] ")
        Query.Append("    ,R.ItemName [Parent] ")
        Query.Append("    ,R.WhseCode ")
        Query.Append("    ,R.Mnth7 ")
        Query.Append("    ,R.Mnth6 ")
        Query.Append("    ,R.Mnth5 ")
        Query.Append("    ,R.Mnth4 ")
        Query.Append("    ,R.Mnth3 ")
        Query.Append("    ,R.Mnth2 ")
        Query.Append("    ,R.Mnth1 ")
        Query.Append("    ,R.Total ")
        Query.Append("    ,1 [No] ")
        Query.Append("    ,R.ItemName + ' ' + R.WhseName [SearchText] ")
        Query.Append("  FROM RawData R ")
        Query.Append(") T ")
        Query.Append("WHERE ISNULL([ItemName], '') != '' ")
        Query.Append("ORDER BY [Parent], [No], [WhseCode] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .SearchText = DR("SearchText"),
                        .ItemName = DR("ItemName"),
                        .WhseCode = DR("WhseCode"),
                        .Month7 = DR("Mnth7"),
                        .Month6 = DR("Mnth6"),
                        .Month5 = DR("Mnth5"),
                        .Month4 = DR("Mnth4"),
                        .Month3 = DR("Mnth3"),
                        .Month2 = DR("Mnth2"),
                        .Month1 = DR("Mnth1"),
                        .Total = DR("Total"),
                        .AvgMonth = DR("AvgMnth"),
                        .Projection = DR("Projection"),
                        .No = DR("No")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Stock_Filter(pWarehouse, pCategory)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].WhseName [Warehouse] ")
        Query.Append("  ,[A].ItemCode ")
        Query.Append("  ,[A].ItemName ")
        Query.Append("  ,[A].ClassName ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and [B].year = [A].year - 1), 0) [PrevAvg] ")
        Query.Append("  ,(CASE WHEN ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and [B].year = [A].year - 1), 0) = 0 THEN 100 ")
        Query.Append("         WHEN ([A].qty / ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and [B].year = [A].year - 1), 0)) * 100 > 100 THEN 100 ")
        Query.Append("         WHEN ([A].qty / ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and [B].year = [A].year - 1), 0)) * 100 < 0 THEN 100 ")
        Query.Append("         ElSE ([A].qty / ISNULL((select AVG([B].qty) from ItemBalance [B] where [B].ItemCode = [A].ItemCode and [B].WhseCode = [A].WhseCode and [B].ClassCode = [A].ClassCode and [B].year = [A].year - 1), 0) * 100) END) [Percentage] ")
        Query.Append("  ,ISNULL([A].UMName, '') [Unit] ")
        Query.Append("from ")
        Query.Append("  ItemBalance [A] ")
        Query.Append("where ")
        Query.Append("  [A].year = YEAR(GETDATE()) ")
        Query.Append("  and [A].period = MONTH(GETDATE()) ")
        Query.Append("  and ISNULL([A].ClassName, '') != '' ")
        Query.Append("  and [A].qty > 0 ")
        If pWarehouse <> "" Then
            Query.Append("  and [A].WhseCode = @pWarehouse ")
        End If
        If pCategory <> "" Then
            Query.Append("  and [A].ClassCode = @pCategory ")
        End If
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                If pWarehouse <> "" Then
                    Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                End If
                If pCategory <> "" Then
                    Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Warehouse = DR("Warehouse"),
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName"),
                        .ClassName = DR("ClassName"),
                        .Qty = DR("Qty"),
                        .PrevAvg = DR("PrevAvg"),
                        .Percentage = DR("Percentage"),
                        .Unit = DR("Unit")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Incoming_Stock()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].PRNo [Reference] ")
        Query.Append("  ,[A].POCode [Code] ")
        Query.Append("  ,ISNULL([A].ItemName, [A].PRItem) [ItemName] ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,FORMAT((CASE WHEN [A].post = 0 and [A].Rvrs = 0 THEN [A].CreateDate WHEN [A].post = 1 and [A].Rvrs = 0 THEN [A].PostedDate END), 'MM/dd/yyyy') [Date] ")
        Query.Append("  ,ISNULL([A].VenName, '-') [Supplier] ")
        Query.Append("  ,ISNULL([A].WhseName, '-') [Warehouse] ")
        Query.Append("  ,ISNULL([A].status, 'Processing') [Status] ")
        Query.Append("  ,ISNULL((select SUM([Bal].qty) from ItemBalance [Bal] where [Bal].year = YEAR(GETDATE()) and [Bal].period = MONTH(GETDATE()) and [Bal].WhseCode = [A].WhseCode and [Bal].ItemCode = [A].ItemCode), 0) + [A].qty [NewBal] ")
        Query.Append("  ,ISNULL((select SUM([Bal].qty) from ItemBalance [Bal] where [Bal].year = YEAR(GETDATE()) and [Bal].period = MONTH(GETDATE()) and [Bal].WhseCode = [A].WhseCode and [Bal].ItemCode = [A].ItemCode), 0) [CurrBal] ")
        Query.Append("  ,ISNULL((select top 1 [D].fullname from ogm_pr_dtl [B] left join ogm_pr_hdr [C] on [B].pr_code = [C].pr_code left join employee [D] on [B].Purchaser = [D].emp_no where [A].PRNo = [C].form_no and [A].PRSeqNo = [B].seq_no), '') [Purchaser] ")
        Query.Append("from ")
        Query.Append("  PODtl [A] ")
        Query.Append("where ")
        Query.Append("  [A].Rvrs = 0 ")
        Query.Append("  and ISNULL([A].PRNo, '') != '' ")
        Query.Append("  and ISNULL([A].status, 'Processing') not in ('Delivered') ")
        Query.Append("order by ")
        Query.Append("  (CASE WHEN [A].post = 0 and [A].Rvrs = 0 THEN [A].CreateDate WHEN [A].post = 1 and [A].Rvrs = 0 THEN [A].PostedDate END) desc ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .RefNo = DR("Reference"),
                        .Code = DR("Code"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .Date = DR("Date"),
                        .Supplier = DR("Supplier"),
                        .Warehouse = DR("Warehouse"),
                        .Status = DR("Status"),
                        .NewBal = DR("NewBal"),
                        .CurrBal = DR("CurrBal"),
                        .Purchaser = DR("Purchaser")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Incoming_Filter(pWarehouse, pVendor)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].PRNo [Reference] ")
        Query.Append("  ,[A].POCode [Code] ")
        Query.Append("  ,ISNULL([A].ItemName, [A].PRItem) [ItemName] ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,FORMAT((CASE WHEN [A].post = 0 and [A].Rvrs = 0 THEN [A].CreateDate WHEN [A].post = 1 and [A].Rvrs = 0 THEN [A].PostedDate END), 'MM/dd/yyyy') [Date] ")
        Query.Append("  ,ISNULL([A].VenName, '-') [Supplier] ")
        Query.Append("  ,ISNULL([A].WhseName, '-') [Warehouse] ")
        Query.Append("  ,ISNULL([A].status, 'Processing') [Status] ")
        Query.Append("  ,ISNULL((select SUM([Bal].qty) from ItemBalance [Bal] where [Bal].year = YEAR(GETDATE()) and [Bal].period = MONTH(GETDATE()) and [Bal].WhseCode = [A].WhseCode and [Bal].ItemCode = [A].ItemCode), 0) + [A].qty [NewBal] ")
        Query.Append("  ,ISNULL((select SUM([Bal].qty) from ItemBalance [Bal] where [Bal].year = YEAR(GETDATE()) and [Bal].period = MONTH(GETDATE()) and [Bal].WhseCode = [A].WhseCode and [Bal].ItemCode = [A].ItemCode), 0) [CurrBal] ")
        Query.Append("  ,ISNULL((select top 1 [D].fullname from ogm_pr_dtl [B] left join ogm_pr_hdr [C] on [B].pr_code = [C].pr_code left join employee [D] on [B].Purchaser = [D].emp_no where [A].PRNo = [C].form_no and [A].PRSeqNo = [B].seq_no), '') [Purchaser] ")
        Query.Append("from ")
        Query.Append("  PODtl [A] ")
        Query.Append("where ")
        Query.Append("  [A].Rvrs = 0 ")
        Query.Append("  and ISNULL([A].PRNo, '') != '' ")
        Query.Append("  and ISNULL([A].status, 'Processing') not in ('Delivered') ")
        If pWarehouse <> "" Then
            Query.Append("  and ISNULL([A].WhseCode, '') = @pWarehouse ")
        End If
        If pVendor <> "" Then
            Query.Append("  and ISNULL([A].VenCode, '') = @pVendor ")
        End If
        Query.Append("order by ")
        Query.Append("  (CASE WHEN [A].post = 0 and [A].Rvrs = 0 THEN [A].CreateDate WHEN [A].post = 1 and [A].Rvrs = 0 THEN [A].PostedDate END) desc ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                If pWarehouse <> "" Then
                    Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                End If
                If pVendor <> "" Then
                    Cmd.Parameters.AddWithValue("@pVendor", pVendor)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .RefNo = DR("Reference"),
                        .Code = DR("Code"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .Date = DR("Date"),
                        .Supplier = DR("Supplier"),
                        .Warehouse = DR("Warehouse"),
                        .Status = DR("Status"),
                        .NewBal = DR("NewBal"),
                        .CurrBal = DR("CurrBal"),
                        .Purchaser = DR("Purchaser")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Projected_Filter(pCategory, pEstimate, pProject, pWarehouse)

        'get query
        Dim Query As New StringBuilder
        If pCategory = "House Construction" And pEstimate <> "" And pProject <> "" And pWarehouse = "" Then
            Query.Append("select ")
            Query.Append("  [ItemName] ")
            Query.Append("  ,[EstQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,[Scope] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [A].Particular [ItemName] ")
            Query.Append("  ,([A].Qty + [A].QtyRev) - [A].QtyReq [EstQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) - (([A].Qty + [A].QtyRev) - [A].QtyReq) [Remaining] ")
            Query.Append("  ,'All warehouses' [Warehouse] ")
            Query.Append("  ,[B].Description [Scope] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl_HouseCon [A] ")
            Query.Append("  left join Mstr_Work [B] on [A].WCode = [B].WCode ")
            Query.Append("where ")
            Query.Append("  ([A].Qty + [A].QtyRev) - [A].QtyReq > 0 ")
            Query.Append("  and ISNULL([A].TblCode, '') != '' ")
            Query.Append("  and ISNULL([A].TblFrom, '') = 'ogm_item' ")
            Query.Append("  and [A].BatchNo = @pEstimate ")
            Query.Append("  and [A].Project = @pProject) [Tbl] ")
        ElseIf pCategory = "House Construction - CCI" And pEstimate <> "" And pProject <> "" And pWarehouse = "" Then
            Query.Append("select ")
            Query.Append("  [ItemName] ")
            Query.Append("  ,[EstQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,[Scope] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [A].Particular [ItemName] ")
            Query.Append("  ,([A].Qty + [A].QtyRev) - [A].QtyReq [EstQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) - (([A].Qty + [A].QtyRev) - [A].QtyReq) [Remaining] ")
            Query.Append("  ,'All warehouses' [Warehouse] ")
            Query.Append("  ,[B].Description [Scope] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl_HouseCon_CCI [A] ")
            Query.Append("  left join Mstr_Work [B] on [A].WCode = [B].WCode ")
            Query.Append("where ")
            Query.Append("  ([A].Qty + [A].QtyRev) - [A].QtyReq > 0 ")
            Query.Append("  and ISNULL([A].TblCode, '') != '' ")
            Query.Append("  and ISNULL([A].TblFrom, '') = 'ogm_item' ")
            Query.Append("  and [A].BatchNo = @pEstimate ")
            Query.Append("  and [A].Project = @pProject) [Tbl] ")
        ElseIf pCategory = "House Construction" And pEstimate <> "" And pProject <> "" And pWarehouse <> "" Then
            Query.Append("select ")
            Query.Append("  [ItemName] ")
            Query.Append("  ,[EstQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,[Scope] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [A].Particular [ItemName] ")
            Query.Append("  ,([A].Qty + [A].QtyRev) - [A].QtyReq [EstQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) - (([A].Qty + [A].QtyRev) - [A].QtyReq) [Remaining] ")
            Query.Append("  ,ISNULL((select warehouse from ogm_warehouse where w_code = @pWarehouse), '') [Warehouse]  ")
            Query.Append("  ,[B].Description [Scope] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl_HouseCon [A] ")
            Query.Append("  left join Mstr_Work [B] on [A].WCode = [B].WCode ")
            Query.Append("where ")
            Query.Append("  ([A].Qty + [A].QtyRev) - [A].QtyReq > 0 ")
            Query.Append("  and ISNULL([A].TblCode, '') != '' ")
            Query.Append("  and ISNULL([A].TblFrom, '') = 'ogm_item' ")
            Query.Append("  and [A].BatchNo = @pEstimate ")
            Query.Append("  and [A].Project = @pProject) [Tbl] ")
        ElseIf pCategory = "House Construction - CCI" And pEstimate <> "" And pProject <> "" And pWarehouse <> "" Then
            Query.Append("select ")
            Query.Append("  [ItemName] ")
            Query.Append("  ,[EstQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,[Scope] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [A].Particular [ItemName] ")
            Query.Append("  ,([A].Qty + [A].QtyRev) - [A].QtyReq [EstQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) - (([A].Qty + [A].QtyRev) - [A].QtyReq) [Remaining] ")
            Query.Append("  ,ISNULL((select warehouse from ogm_warehouse where w_code = @pWarehouse), '') [Warehouse]  ")
            Query.Append("  ,[B].Description [Scope] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl_HouseCon_CCI [A] ")
            Query.Append("  left join Mstr_Work [B] on [A].WCode = [B].WCode ")
            Query.Append("where ")
            Query.Append("  ([A].Qty + [A].QtyRev) - [A].QtyReq > 0 ")
            Query.Append("  and ISNULL([A].TblCode, '') != '' ")
            Query.Append("  and ISNULL([A].TblFrom, '') = 'ogm_item' ")
            Query.Append("  and [A].BatchNo = @pEstimate ")
            Query.Append("  and [A].Project = @pProject) [Tbl] ")
        ElseIf (pCategory <> "House Construction" Or pCategory <> "House Construction - CCI") And pEstimate <> "" And pWarehouse = "" Then
            Query.Append("select ")
            Query.Append("  [ItemName] ")
            Query.Append("  ,[EstQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,[Scope] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [A].Particular [ItemName] ")
            Query.Append("  ,([A].Qty + [A].QtyRev) - [A].QtyReq [EstQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,IIF(ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) = 0, 0, ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) - ([A].Qty + [A].QtyRev) - [A].QtyReq) [Remaining] ")
            Query.Append("  ,'All warehouses' [Warehouse] ")
            Query.Append("  ,[C].Description [Scope] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl [A] ")
            Query.Append("  left join Trxn_CEHdr [B] on [A].CECode = [B].CECode ")
            Query.Append("  left join Mstr_Work [C] on [A].WCode = [C].WCode ")
            Query.Append("where ")
            Query.Append("  ([A].Qty + [A].QtyRev) - [A].QtyReq > 0 ")
            Query.Append("  and ISNULL([A].TblCode, '') != '' ")
            Query.Append("  and ISNULL([A].TblFrom, '') = 'ogm_item' ")
            Query.Append("  and [B].Post = 1 ")
            Query.Append("  and [B].Rvrs = 0 ")
            Query.Append("  and [B].Category = @pCategory ")
            Query.Append("  and [B].CECode = @pEstimate) [Tbl] ")
        ElseIf (pCategory <> "House Construction" Or pCategory <> "House Construction - CCI") And pEstimate <> "" And pWarehouse <> "" Then
            Query.Append("select ")
            Query.Append("  [ItemName] ")
            Query.Append("  ,[EstQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,[Scope] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [A].Particular [ItemName] ")
            Query.Append("  ,([A].Qty + [A].QtyRev) - [A].QtyReq [EstQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) [BalQty]  ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [A].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) - (([A].Qty + [A].QtyRev) - [A].QtyReq) [Remaining] ")
            Query.Append("  ,ISNULL((select warehouse from ogm_warehouse where w_code = @pWarehouse), '') [Warehouse]  ")
            Query.Append("  ,[C].Description [Scope] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl [A] ")
            Query.Append("  left join Trxn_CEHdr [B] on [A].CECode = [B].CECode ")
            Query.Append("  left join Mstr_Work [C] on [A].WCode = [C].WCode ")
            Query.Append("where ")
            Query.Append("  ([A].Qty + [A].QtyRev) - [A].QtyReq > 0 ")
            Query.Append("  and ISNULL([A].TblCode, '') != '' ")
            Query.Append("  and ISNULL([A].TblFrom, '') = 'ogm_item' ")
            Query.Append("  and [B].Post = 1 ")
            Query.Append("  and [B].Rvrs = 0 ")
            Query.Append("  and [B].Category = @pCategory ")
            Query.Append("  and [B].CECode = @pEstimate) [Tbl] ")
        End If
        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                If pEstimate <> "" Then
                    Cmd.Parameters.AddWithValue("@pEstimate", pEstimate)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pWarehouse <> "" Then
                    Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ItemName = DR("ItemName"),
                        .EstQty = DR("EstQty"),
                        .BalQty = DR("BalQty"),
                        .Remaining = DR("Remaining"),
                        .Warehouse = DR("Warehouse"),
                        .Scope = DR("Scope"),
                        .Percent = DR("Percent")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_PR_Filter(pCategory, pProject, pWarehouse)

        'get query
        Dim Query As New StringBuilder
        If pCategory = "House Construction" And pProject <> "" And pWarehouse = "" Then
            Query.Append("select ")
            Query.Append("  [Reference] ")
            Query.Append("  ,[ItemName] ")
            Query.Append("  ,[PRQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("  ,[Status] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [B].form_no [Reference] ")
            Query.Append("  ,[A].item [ItemName] ")
            Query.Append("  ,[A].qty [PRQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) - [A].qty [Remaining] ")
            Query.Append("  ,'All warehouses' [Warehouse] ")
            Query.Append("  ,'On-Going' [Status] ")
            Query.Append("from ")
            Query.Append("  ogm_pr_dtl [A] ")
            Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
            Query.Append("  left join oop_form_hdr [C] on [B].pr_code = [C].tbl_code ")
            Query.Append("  left join Trxn_CEDtl_HouseCon [D] on [A].WBSNo = [D].WBSNo ")
            Query.Append("where ")
            Query.Append("  [A].for_sr > 0 ")
            Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
            Query.Append("  and ISNULL([A].WBSNo, '') != '' ")
            Query.Append("  and [B].justification not in ('Non OSM Project', 'OSM Project', 'OSM Project (Advance PO)', 'CCI Project (Advance PO)') ")
            Query.Append("  and [B].Purpose like '%CONSTRUCTION MATERIALS%' ")
            Query.Append("  and [C].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and [C].tbl_from = 'ogm_pr_hdr' ")
            Query.Append("  and ISNULL([D].TblCode, '') != '' ")
            Query.Append("  and [B].Category = @pCategory ")
            Query.Append("  and [D].Project = @pProject) [Tbl] ")
        ElseIf pCategory = "House Construction - CCI" And pProject <> "" And pWarehouse = "" Then
            Query.Append("select ")
            Query.Append("  [Reference] ")
            Query.Append("  ,[ItemName] ")
            Query.Append("  ,[PRQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("  ,[Status] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [B].form_no [Reference] ")
            Query.Append("  ,[A].item [ItemName] ")
            Query.Append("  ,[A].qty [PRQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) - [A].qty [Remaining] ")
            Query.Append("  ,'All warehouses' [Warehouse] ")
            Query.Append("  ,'On-Going' [Status] ")
            Query.Append("from ")
            Query.Append("  ogm_pr_dtl [A] ")
            Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
            Query.Append("  left join oop_form_hdr [C] on [B].pr_code = [C].tbl_code ")
            Query.Append("  left join Trxn_CEDtl_HouseCon_CCI [D] on [A].WBSNo = [D].WBSNo ")
            Query.Append("where ")
            Query.Append("  [A].for_sr > 0 ")
            Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
            Query.Append("  and ISNULL([A].WBSNo, '') != '' ")
            Query.Append("  and [B].justification not in ('Non OSM Project', 'OSM Project', 'OSM Project (Advance PO)', 'CCI Project (Advance PO)') ")
            Query.Append("  and [B].Purpose like '%CONSTRUCTION MATERIALS%' ")
            Query.Append("  and [C].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and [C].tbl_from = 'ogm_pr_hdr' ")
            Query.Append("  and ISNULL([D].TblCode, '') != '' ")
            Query.Append("  and [B].Category = @pCategory ")
            Query.Append("  and [D].Project = @pProject) [Tbl] ")
        ElseIf pCategory = "House Construction" And pProject <> "" And pWarehouse <> "" Then
            Query.Append("select ")
            Query.Append("  [Reference] ")
            Query.Append("  ,[ItemName] ")
            Query.Append("  ,[PRQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("  ,[Status] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [B].form_no [Reference] ")
            Query.Append("  ,[A].item [ItemName] ")
            Query.Append("  ,[A].qty [PRQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) - [A].qty [Remaining] ")
            Query.Append("  ,ISNULL((select warehouse from ogm_warehouse where w_code = @pWarehouse), '') [Warehouse]  ")
            Query.Append("  ,'On-Going' [Status] ")
            Query.Append("from ")
            Query.Append("  ogm_pr_dtl [A] ")
            Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
            Query.Append("  left join oop_form_hdr [C] on [B].pr_code = [C].tbl_code ")
            Query.Append("  left join Trxn_CEDtl_HouseCon [D] on [A].WBSNo = [D].WBSNo ")
            Query.Append("where ")
            Query.Append("  [A].for_sr > 0 ")
            Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
            Query.Append("  and ISNULL([A].WBSNo, '') != '' ")
            Query.Append("  and [B].justification not in ('Non OSM Project', 'OSM Project', 'OSM Project (Advance PO)', 'CCI Project (Advance PO)') ")
            Query.Append("  and [B].Purpose like '%CONSTRUCTION MATERIALS%' ")
            Query.Append("  and [C].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and [C].tbl_from = 'ogm_pr_hdr' ")
            Query.Append("  and ISNULL([D].TblCode, '') != '' ")
            Query.Append("  and [B].Category = @pCategory ")
            Query.Append("  and [D].Project = @pProject) [Tbl] ")
        ElseIf pCategory = "House Construction - CCI" And pProject <> "" And pWarehouse <> "" Then
            Query.Append("select ")
            Query.Append("  [Reference] ")
            Query.Append("  ,[ItemName] ")
            Query.Append("  ,[PRQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("  ,[Status] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [B].form_no [Reference] ")
            Query.Append("  ,[A].item [ItemName] ")
            Query.Append("  ,[A].qty [PRQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) - [A].qty [Remaining] ")
            Query.Append("  ,ISNULL((select warehouse from ogm_warehouse where w_code = @pWarehouse), '') [Warehouse]  ")
            Query.Append("  ,'On-Going' [Status] ")
            Query.Append("from ")
            Query.Append("  ogm_pr_dtl [A] ")
            Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
            Query.Append("  left join oop_form_hdr [C] on [B].pr_code = [C].tbl_code ")
            Query.Append("  left join Trxn_CEDtl_HouseCon_CCI [D] on [A].WBSNo = [D].WBSNo ")
            Query.Append("where ")
            Query.Append("  [A].for_sr > 0 ")
            Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
            Query.Append("  and ISNULL([A].WBSNo, '') != '' ")
            Query.Append("  and [B].justification not in ('Non OSM Project', 'OSM Project', 'OSM Project (Advance PO)', 'CCI Project (Advance PO)') ")
            Query.Append("  and [B].Purpose like '%CONSTRUCTION MATERIALS%' ")
            Query.Append("  and [C].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and [C].tbl_from = 'ogm_pr_hdr' ")
            Query.Append("  and ISNULL([D].TblCode, '') != '' ")
            Query.Append("  and [B].Category = @pCategory ")
            Query.Append("  and [D].Project = @pProject) [Tbl] ")
        ElseIf (pCategory <> "House Construction" Or pCategory <> "House Construction - CCI") And pWarehouse = "" Then
            Query.Append("select ")
            Query.Append("  [Reference] ")
            Query.Append("  ,[ItemName] ")
            Query.Append("  ,[PRQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("  ,[Status] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [B].form_no [Reference] ")
            Query.Append("  ,[A].item [ItemName] ")
            Query.Append("  ,[A].qty [PRQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' GROUP BY ItemCode), 0) - [A].qty [Remaining] ")
            Query.Append("  ,'All warehouses' [Warehouse] ")
            Query.Append("  ,'On-Going' [Status] ")
            Query.Append("from ")
            Query.Append("  ogm_pr_dtl [A] ")
            Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
            Query.Append("  left join oop_form_hdr [C] on [B].pr_code = [C].tbl_code ")
            Query.Append("  left join Trxn_CEDtl [D] on [A].ItemNo = [D].ItemNo ")
            Query.Append("  left join Trxn_CEHdr [E] on [D].CECode = [E].CECode ")
            Query.Append("where ")
            Query.Append("  [A].for_sr > 0 ")
            Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
            Query.Append("  and ISNULL([A].ItemNo, '') != '' ")
            Query.Append("  and [B].justification not in ('Non OSM Project', 'OSM Project', 'OSM Project (Advance PO)', 'CCI Project (Advance PO)') ")
            Query.Append("  and [B].Purpose like '%CONSTRUCTION MATERIALS%' ")
            Query.Append("  and [C].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and [C].tbl_from = 'ogm_pr_hdr' ")
            Query.Append("  and ISNULL([D].TblCode, '') != '' ")
            Query.Append("  and [E].Category = @pCategory) [Tbl] ")
        ElseIf (pCategory <> "House Construction" Or pCategory <> "House Construction - CCI") And pWarehouse <> "" Then
            Query.Append("select ")
            Query.Append("  [Reference] ")
            Query.Append("  ,[ItemName] ")
            Query.Append("  ,[PRQty] ")
            Query.Append("  ,[BalQty] ")
            Query.Append("  ,[Remaining] ")
            Query.Append("  ,[Warehouse] ")
            Query.Append("  ,(CASE WHEN [Remaining] = 0 THEN 0 ")
            Query.Append("         WHEN [Remaining] <= 0 THEN 0 ")
            Query.Append("         ELSE ([Remaining] / [BalQty] * 100) END) [Percent] ")
            Query.Append("  ,[Status] ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  [B].form_no [Reference] ")
            Query.Append("  ,[A].item [ItemName] ")
            Query.Append("  ,[A].qty [PRQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) [BalQty] ")
            Query.Append("  ,ISNULL((select SUM(Qty) from ItemBalance where year = YEAR(GETDATE()) and period = MONTH(GETDATE()) and ItemCode = [D].TblCode and ISNULL(ClassCode, '') != '' and WhseCode = @pWarehouse GROUP BY ItemCode), 0) - [A].qty [Remaining] ")
            Query.Append("  ,ISNULL((select warehouse from ogm_warehouse where w_code = @pWarehouse), '') [Warehouse]  ")
            Query.Append("  ,'On-Going' [Status]  ")
            Query.Append("from ")
            Query.Append("  ogm_pr_dtl [A] ")
            Query.Append("  left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
            Query.Append("  left join oop_form_hdr [C] on [B].pr_code = [C].tbl_code ")
            Query.Append("  left join Trxn_CEDtl [D] on [A].ItemNo = [D].ItemNo ")
            Query.Append("  left join Trxn_CEHdr [E] on [D].CECode = [E].CECode ")
            Query.Append("where ")
            Query.Append("  [A].for_sr > 0 ")
            Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
            Query.Append("  and ISNULL([A].ItemNo, '') != '' ")
            Query.Append("  and [B].justification not in ('Non OSM Project', 'OSM Project', 'OSM Project (Advance PO)', 'CCI Project (Advance PO)') ")
            Query.Append("  and [B].Purpose like '%CONSTRUCTION MATERIALS%' ")
            Query.Append("  and [C].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and [C].tbl_from = 'ogm_pr_hdr' ")
            Query.Append("  and ISNULL([D].TblCode, '') != '' ")
            Query.Append("  and [E].Category = @pCategory) [Tbl] ")
        End If
        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString())
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pWarehouse <> "" Then
                    Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Reference = DR("Reference"),
                        .ItemName = DR("ItemName"),
                        .PRQty = DR("PRQty"),
                        .BalQty = DR("BalQty"),
                        .Remaining = DR("Remaining"),
                        .Warehouse = DR("Warehouse"),
                        .Percent = DR("Percent"),
                        .Status = DR("Status")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
#End Region

End Class