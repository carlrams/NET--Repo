Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Net.Http
Imports System.Net.PeerToPeer.Collaboration
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Threading
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.WebSockets
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports NET.FINRTDatasetTableAdapters
Imports Newtonsoft.Json.Linq
Imports OfficeOpenXml.ConditionalFormatting.Contracts

Public Class DSB280000HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

    Dim DataSource1 As String = "10.10.30.10"
    Dim catalog1 As String = "cldc_live_acc"
    Dim UserID1 As String = "ciis"
    Dim Password1 As String = "Cii5s"
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

            If pFormCode = "DSB280000" And pType = "Get-PO-Header" Then

                Dim json As String = Me.Get_PO_Header()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "General-Filter-PO-Header" Then

                Dim pMonth = context.Request("pMonth")
                Dim pYear = context.Request("pYear")

                Dim json As String = Me.General_Filter_PO_Header(pMonth, pYear)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-Commodity-Total" Then

                Dim json As String = Me.Get_Commodity_Value()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "General-Filter-Commodity-Total" Then

                Dim pMonth = context.Request("pMonth")
                Dim pYear = context.Request("pYear")

                Dim json As String = Me.General_Filter_Commodity_Total(pMonth, pYear)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-Commodity-Item" Then

                Dim json As String = Me.Get_Commodity_Item()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "General-Filter-Commodity-Item" Then

                Dim pMonth = context.Request("pMonth")
                Dim pYear = context.Request("pYear")

                Dim json As String = Me.General_Filter_Commodity_Item(pMonth, pYear)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-Supplier-Evaluation" Then

                Dim json As String = Me.Get_Supplier_Evaluation()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-Purchase-Order" Then

                Dim json As String = Me.Get_Purchase_Order()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-Purchase-Filter" Then

                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")

                Dim json As String = Me.Get_Purchase_Order_Filter(pDateFrom, pDateTo)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-Purchase-Commodity" Then

                Dim json As String = Me.Get_Purchase_Commodity()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "General-Filter-Purchase-Commodity" Then

                Dim pMonth = context.Request("pMonth")
                Dim pYear = context.Request("pYear")

                Dim json As String = Me.General_Filter_Purchase_Commodity(pMonth, pYear)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-YTD-Purchase" Then

                Dim json As String = Me.Get_YTD_Purchase()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-YTD-Supplier" Then

                Dim json As String = Me.Get_YTD_Supplier()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB280000" And pType = "Get-YTD-Item" Then

                Dim json As String = Me.Get_YTD_Item()
                context.Response.ContentType = "application/json"
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

#Region "DSB280000"
    Function Get_PO_Header()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select COUNT(*) from PODtl where Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE())), 0) [Posted] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE()) - 1), 0) [PrevPosted] ")
        Query.Append("  ,ISNULL((select SUM(Cost) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE())), 0) [Cost] ")
        Query.Append("  ,ISNULL((select SUM(Cost) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE()) - 1), 0) [PrevCost]  ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE()) and status not in ('Delivered', 'Cancelled') and ICCode not in ('MN2013010008', 'MN2021010003') ), 0) [InProgress] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE()) - 1 and status not in ('Delivered', 'Cancelled') and ICCode not in ('MN2013010008', 'MN2021010003') ), 0) [PrevInProgress] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE()) and status = 'Delivered'), 0) [Completed] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = YEAR(GETDATE()) and MONTH(PODate) = MONTH(GETDATE()) - 1 and status = 'Delivered'), 0) [PrevCompleted] ")
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
                        .Posted = DR("Posted"),
                        .PrevPosted = DR("PrevPosted"),
                        .Cost = DR("Cost"),
                        .PrevCost = DR("PrevCost"),
                        .InProgress = DR("InProgress"),
                        .PrevInProgress = DR("PrevInProgress"),
                        .Completed = DR("Completed"),
                        .PrevCompleted = DR("PrevCompleted")
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
    Function General_Filter_PO_Header(pMonth, pYear)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @pPrevMonth int = (CASE WHEN @pMonth = 1 THEN 12 ELSE @pMonth - 1 END) ")
        Query.Append("declare @pPrevYear int = (CASE WHEN @pMonth = 1 THEN @pYear - 1 ELSE @pYear END) ")
        Query.Append("select ")
        Query.Append("  ISNULL((select COUNT(*) from PODtl where Rvrs = 0 and YEAR(PODate) = @pYear and MONTH(PODate) = @pMonth ), 0) [Posted] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Rvrs = 0 and YEAR(PODate) = @pPrevYear and MONTH(PODate) = @pPrevMonth - 1), 0) [PrevPosted] ")
        Query.Append("  ,ISNULL((select SUM(Cost) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = @pYear and MONTH(PODate) = @pMonth ), 0) [Cost] ")
        Query.Append("  ,ISNULL((select SUM(Cost) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = @pPrevYear and MONTH(PODate) = @pPrevMonth - 1), 0) [PrevCost]  ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Rvrs = 0 and YEAR(PODate) = @pYear and MONTH(PODate) = @pMonth and status not in ('Delivered', 'Cancelled') and ICCode not in ('MN2013010008', 'MN2021010003') ), 0) [InProgress] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Rvrs = 0 and YEAR(PODate) = @pPrevYear and MONTH(PODate) = @pPrevMonth - 1 and status not in ('Delivered', 'Cancelled') and ICCode not in ('MN2013010008', 'MN2021010003') ), 0) [PrevInProgress] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = @pYear and MONTH(PODate) = @pMonth and status = 'Delivered'), 0) [Completed] ")
        Query.Append("  ,ISNULL((select COUNT(*) from PODtl where Post = 1 and Rvrs = 0 and YEAR(PODate) = @pPrevYear and MONTH(PODate) = @pPrevMonth - 1 and status = 'Delivered'), 0) [PrevCompleted] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pMonth", pMonth)
                Cmd.Parameters.AddWithValue("@pYear", pYear)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Posted = DR("Posted"),
                        .PrevPosted = DR("PrevPosted"),
                        .Cost = DR("Cost"),
                        .PrevCost = DR("PrevCost"),
                        .InProgress = DR("InProgress"),
                        .PrevInProgress = DR("PrevInProgress"),
                        .Completed = DR("Completed"),
                        .PrevCompleted = DR("PrevCompleted")
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
    Function Get_PO_Type()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Commodity ")
        Query.Append("  ,SUM([A].unit_cost) [Total] ")
        Query.Append("  ,SUM([A].qty) [Qty] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  and [B].Rvrs = 0 ")
        Query.Append("  and YEAR([B].po_date) = YEAR(GETDATE()) ")
        Query.Append("  and MONTH([B].po_date) = MONTH(GETDATE()) ")
        Query.Append("  and ISNULL([A].Commodity, '') != '' ")
        Query.Append("group by ")
        Query.Append("  [A].Commodity ")
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
                        .Commodity = DR("Commodity"),
                        .Total = DR("Total"),
                        .Qty = DR("Qty")
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
    Function Get_Commodity_Value()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Commodity ")
        Query.Append("  ,SUM([A].unit_cost) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  and [B].Rvrs = 0 ")
        Query.Append("  and YEAR([B].po_date) = YEAR(GETDATE()) ")
        Query.Append("  and MONTH([B].po_date) = MONTH(GETDATE()) ")
        Query.Append("  and ISNULL([A].Commodity, '') != '' ")
        Query.Append("group by ")
        Query.Append("  [A].Commodity ")
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
                        .Commodity = DR("Commodity"),
                        .Total = DR("Total")
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
    Function General_Filter_Commodity_Total(pMonth, pYear)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Commodity ")
        Query.Append("  ,SUM([A].unit_cost) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  and [B].Rvrs = 0 ")
        Query.Append("  and YEAR([B].po_date) = @pYear ")
        Query.Append("  and MONTH([B].po_date) = @pMonth ")
        Query.Append("  and ISNULL([A].Commodity, '') != '' ")
        Query.Append("group by ")
        Query.Append("  [A].Commodity ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pMonth", pMonth)
                Cmd.Parameters.AddWithValue("@pYear", pYear)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Commodity = DR("Commodity"),
                        .Total = DR("Total")
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
    Function Get_Commodity_Item()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Commodity ")
        Query.Append("  ,COUNT([A].item) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  and [B].Rvrs = 0 ")
        Query.Append("  and YEAR([B].post_date) = YEAR(GETDATE()) ")
        Query.Append("  and MONTH([B].post_date) = MONTH(GETDATE()) ")
        Query.Append("  and ISNULL([A].Commodity, '') != '' ")
        Query.Append("group by ")
        Query.Append("  [A].Commodity ")
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
                        .Commodity = DR("Commodity"),
                        .Total = DR("Total")
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
    Function General_Filter_Commodity_Item(pMonth, pYear)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Commodity ")
        Query.Append("  ,COUNT([A].item) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  and [B].Rvrs = 0 ")
        Query.Append("  and YEAR([B].post_date) = @pYear ")
        Query.Append("  and MONTH([B].post_date) = @pMonth ")
        Query.Append("  and ISNULL([A].Commodity, '') != '' ")
        Query.Append("group by ")
        Query.Append("  [A].Commodity ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pMonth", pMonth)
                Cmd.Parameters.AddWithValue("@pYear", pYear)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Commodity = DR("Commodity"),
                        .Total = DR("Total")
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
    Function Get_Supplier_Evaluation()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("  [C].vendor [Supplier] ")
        Query.Append("  ,[B].OverallA + [B].OverallB + [B].OverallC [OverallTotal] ")
        Query.Append("  ,(CASE WHEN [B].OverallA + [B].OverallB + [B].OverallC >= 90 THEN 'Good' ")
        Query.Append("         WHEN [B].OverallA + [B].OverallB + [B].OverallC <= 89 AND [B].OverallA + [B].OverallB + [B].OverallC >= 80 THEN 'Satisfactory' ")
        Query.Append("         WHEN [B].OverallA + [B].OverallB + [B].OverallC <= 79 AND [B].OverallA + [B].OverallB + [B].OverallC >= 70 THEN 'Poor' ")
        Query.Append("         WHEN [B].OverallA + [B].OverallB + [B].OverallC <= 69 THEN 'Drop' END) [Rating] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_SPE [B] on [A].tbl_code = [B].SPECode ")
        Query.Append("  left join ogm_vendor [C] on [B].SupplierCode = [C].v_code ")
        Query.Append("where  ")
        Query.Append("  [A].tbl_from = 'Form_SPE' ")
        Query.Append("order by ")
        Query.Append("  [B].OverallA + [B].OverallB + [B].OverallC DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource1 & "; Initial Catalog=" & catalog1 & "; User ID=" & UserID1 & "; Password=" & Password1)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Supplier = DR("Supplier"),
                        .OverallTotal = DR("OverallTotal"),
                        .Rating = DR("Rating")
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
    Function Get_Purchase_Order()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  FORMAT([PRDate], 'MM/dd/yyyy') [PRDate] ")
        Query.Append("  ,FORMAT([PODate], 'MM/dd/yyyy') [PODate] ")
        Query.Append("  ,(select count(ExplodeDates.thedate) - 1 from ExplodeDates(PRDate,PODate) where datepart(dw,ExplodeDates.thedate) not in (7,1)) [Cycle] ")
        Query.Append("  ,[Department] ")
        Query.Append("  ,[PONo] ")
        Query.Append("  ,[POCode] ")
        Query.Append("  ,[PRNo] ")
        Query.Append("  ,[Project] ")
        Query.Append("  ,[Qty] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[Supplier] ")
        Query.Append("  ,[Cost] ")
        Query.Append("  ,[Strategy] ")
        Query.Append("  ,[Commodity] ")
        Query.Append("  ,[Status] ")
        Query.Append("  ,[Purchaser] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  (select top 1 (case when status = 'Approved' then cast(oop_form_dtl_appr.updated_date as date) else [A].PODate end) from oop_form_dtl_appr where oop_form_dtl_appr.f_code = [B].form_no and oop_form_dtl_appr.type = 'Implementer' order by oop_form_dtl_appr.seq_no desc) [PRDate] ")
        Query.Append("  ,[A].PODate [PODate] ")
        Query.Append("  ,[D].description [Department] ")
        Query.Append("  ,[A].PONo [PONo] ")
        Query.Append("  ,[A].POCode [POCode] ")
        Query.Append("  ,[A].PRNo [PRNo] ")
        Query.Append("  ,[B].justification [Project] ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,[A].UMName [Unit] ")
        Query.Append("  ,[A].ItemName [ItemName] ")
        Query.Append("  ,[A].VenName [Supplier] ")
        Query.Append("  ,[A].Cost [Cost] ")
        Query.Append("  ,[A].Commodity [Strategy] ")
        Query.Append("  ,[A].Classification [Commodity] ")
        Query.Append("  ,[A].status [Status] ")
        Query.Append("  ,[E].fullname [Purchaser] ")
        Query.Append("from ")
        Query.Append("  PODtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].PRNo = [B].form_no ")
        Query.Append("  left join ogm_pr_dtl [C] on [B].pr_code = [C].pr_code and [A].PRSeqNo = [C].seq_no ")
        Query.Append("  left join department [D] on [A].DeptCode = [D].dept_code ")
        Query.Append("  left join employee [E] on [C].Purchaser = [E].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].post = 1 ")
        Query.Append("  and [A].Rvrs = 0 ")
        Query.Append("  and YEAR([A].PODate) = YEAR(GETDATE()) ")
        Query.Append("  and MONTH([A].PODate) = MONTH(GETDATE()) ) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [Status], [PODate] ")
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
                        .PRDate = DR("PRDate"),
                        .PODate = DR("PODate"),
                        .Cycle = DR("Cycle"),
                        .Department = DR("Department"),
                        .POCode = DR("POCode"),
                        .PONo = DR("PONo"),
                        .PRNo = DR("PRNo"),
                        .Project = DR("Project"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .ItemName = DR("ItemName"),
                        .Supplier = DR("Supplier"),
                        .Cost = DR("Cost"),
                        .Strategy = DR("Strategy"),
                        .Commodity = DR("Commodity"),
                        .Status = DR("Status"),
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
    Function Get_Purchase_Order_Filter(pDateFrom, pDateTo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  FORMAT([PRDate], 'MM/dd/yyyy') [PRDate] ")
        Query.Append("  ,FORMAT([PODate], 'MM/dd/yyyy') [PODate] ")
        Query.Append("  ,(select count(ExplodeDates.thedate) - 1 from ExplodeDates(PRDate,PODate) where datepart(dw,ExplodeDates.thedate) not in (7,1)) [Cycle] ")
        Query.Append("  ,[Department] ")
        Query.Append("  ,[PONo] ")
        Query.Append("  ,[POCode] ")
        Query.Append("  ,[PRNo] ")
        Query.Append("  ,[Project] ")
        Query.Append("  ,[Qty] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[Supplier] ")
        Query.Append("  ,[Cost] ")
        Query.Append("  ,[Strategy] ")
        Query.Append("  ,[Commodity] ")
        Query.Append("  ,[Status] ")
        Query.Append("  ,[Purchaser] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  (select top 1 (case when status = 'Approved' then cast(oop_form_dtl_appr.updated_date as date) else [A].PODate end) from oop_form_dtl_appr where oop_form_dtl_appr.f_code = [B].form_no and oop_form_dtl_appr.type = 'Implementer' order by oop_form_dtl_appr.seq_no desc) [PRDate] ")
        Query.Append("  ,[A].PODate [PODate] ")
        Query.Append("  ,[D].description [Department] ")
        Query.Append("  ,[A].PONo [PONo] ")
        Query.Append("  ,[A].POCode [POCode] ")
        Query.Append("  ,[A].PRNo [PRNo] ")
        Query.Append("  ,[B].justification [Project] ")
        Query.Append("  ,[A].qty [Qty] ")
        Query.Append("  ,[A].UMName [Unit] ")
        Query.Append("  ,[A].ItemName [ItemName] ")
        Query.Append("  ,[A].VenName [Supplier] ")
        Query.Append("  ,[A].Cost [Cost] ")
        Query.Append("  ,[A].Commodity [Strategy] ")
        Query.Append("  ,[A].Classification [Commodity] ")
        Query.Append("  ,[A].status [Status] ")
        Query.Append("  ,[E].fullname [Purchaser] ")
        Query.Append("from ")
        Query.Append("  PODtl [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].PRNo = [B].form_no ")
        Query.Append("  left join ogm_pr_dtl [C] on [B].pr_code = [C].pr_code and [A].PRSeqNo = [C].seq_no ")
        Query.Append("  left join department [D] on [A].DeptCode = [D].dept_code ")
        Query.Append("  left join employee [E] on [C].Purchaser = [E].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].post = 1 ")
        Query.Append("  and [A].Rvrs = 0 ")
        Query.Append("  and FORMAT([A].PODate, 'MM/dd/yyyy') BETWEEN @pDateFrom AND @pDateTo) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [Status], [PODate] ")
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
                        .PRDate = DR("PRDate"),
                        .PODate = DR("PODate"),
                        .Cycle = DR("Cycle"),
                        .Department = DR("Department"),
                        .POCode = DR("POCode"),
                        .PONo = DR("PONo"),
                        .PRNo = DR("PRNo"),
                        .Project = DR("Project"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .ItemName = DR("ItemName"),
                        .Supplier = DR("Supplier"),
                        .Cost = DR("Cost"),
                        .Strategy = DR("Strategy"),
                        .Commodity = DR("Commodity"),
                        .Status = DR("Status"),
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
    Function Get_Purchase_Commodity()

        'get query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("  [C].description [Commodity] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = MONTH(GETDATE()) THEN [A].unit_cost ELSE 0 END) [Amount] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = MONTH(GETDATE()) THEN [A].item END) [CountItem] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = MONTH(GETDATE()) THEN [A].qty ELSE 0 END) [Qty] ")
        Query.Append("  ,SUM([A].unit_cost) [YTD_Amount] ")
        Query.Append("  ,COUNT([A].item) [YTD_CountItem] ")
        Query.Append("  ,SUM([A].qty) [YTD_Qty] ")
        Query.Append("  ,(CASE WHEN SUM(CASE WHEN MONTH([B].po_date) = MONTH(GETDATE()) THEN [A].unit_cost ELSE 0 END) = 0 THEN 0 ELSE SUM(CASE WHEN MONTH([B].po_date) = MONTH(GETDATE()) THEN [A].unit_cost ELSE 0 END) / ISNULL((SELECT SUM([DTL].unit_cost) FROM ogm_po_dtl [DTL] LEFT JOIN ogm_po_hdr [HDR] ON [DTL].po_code = [HDR].po_code WHERE [HDR].post = 1 AND [HDR].Rvrs = 0 AND YEAR([HDR].po_date) = YEAR(GETDATE()) AND MONTH([HDR].po_date) = MONTH(GETDATE())), 0) END) [Percentage] ")
        Query.Append("  ,ISNULL((SELECT COUNT([DTL].item) FROM ogm_po_dtl [DTL] LEFT JOIN ogm_po_hdr [HDR] ON [DTL].po_code = [HDR].po_code WHERE [HDR].post = 1 AND [HDR].Rvrs = 0 AND YEAR([HDR].po_date) = YEAR(GETDATE()) AND MONTH([HDR].po_date) = MONTH(GETDATE())), 0) [Count] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] On [A].po_code = [B].po_code ")
        Query.Append("  left join ogm_item_cat [C] On [A].ICCode = [C].ic_code ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  And [B].Rvrs = 0 ")
        Query.Append("  And YEAR([B].po_date) = YEAR(GETDATE()) ")
        Query.Append("group by ")
        Query.Append("  [C].description ")
        Query.Append("order by ")
        Query.Append("  [C].description ")
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
                        .Commodity = DR("Commodity"),
                        .Amount = DR("Amount"),
                        .TotalItem = DR("CountItem"),
                        .CountItem = DR("Count"),
                        .Qty = DR("Qty"),
                        .Percentage = DR("Percentage"),
                        .YTDAmount = DR("YTD_Amount"),
                        .YTDItem = DR("YTD_CountItem"),
                        .YTDQty = DR("YTD_Qty")
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
    Function General_Filter_Purchase_Commodity(pMonth, pYear)

        'get query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("  [C].description [Commodity] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = @pMonth THEN [A].unit_cost ELSE 0 END) [Amount] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = @pMonth THEN [A].item END) [CountItem] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = @pMonth THEN [A].qty ELSE 0 END) [Qty] ")
        Query.Append("  ,SUM([A].unit_cost) [YTD_Amount] ")
        Query.Append("  ,COUNT([A].item) [YTD_CountItem] ")
        Query.Append("  ,SUM([A].qty) [YTD_Qty] ")
        Query.Append("  ,(CASE WHEN SUM(CASE WHEN MONTH([B].po_date) = @pMonth THEN [A].unit_cost ELSE 0 END) = 0 THEN 0 ELSE SUM(CASE WHEN MONTH([B].po_date) = @pMonth THEN [A].unit_cost ELSE 0 END) / ISNULL((SELECT SUM([DTL].unit_cost) FROM ogm_po_dtl [DTL] LEFT JOIN ogm_po_hdr [HDR] ON [DTL].po_code = [HDR].po_code WHERE [HDR].post = 1 AND [HDR].Rvrs = 0 AND YEAR([HDR].po_date) = @pYear AND MONTH([HDR].po_date) = @pMonth ), 0) END) [Percentage] ")
        Query.Append("  ,ISNULL((SELECT COUNT([DTL].item) FROM ogm_po_dtl [DTL] LEFT JOIN ogm_po_hdr [HDR] ON [DTL].po_code = [HDR].po_code WHERE [HDR].post = 1 AND [HDR].Rvrs = 0 AND YEAR([HDR].po_date) = @pYear AND MONTH([HDR].po_date) = @pMonth ), 0) [Count] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] On [A].po_code = [B].po_code ")
        Query.Append("  left join ogm_item_cat [C] On [A].ICCode = [C].ic_code ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  And [B].Rvrs = 0 ")
        Query.Append("  And YEAR([B].po_date) = @pYear ")
        Query.Append("group by ")
        Query.Append("  [C].description ")
        Query.Append("order by ")
        Query.Append("  [C].description ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pMonth", pMonth)
                Cmd.Parameters.AddWithValue("@pYear", pYear)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Commodity = DR("Commodity"),
                        .Amount = DR("Amount"),
                        .TotalItem = DR("CountItem"),
                        .CountItem = DR("Count"),
                        .Qty = DR("Qty"),
                        .Percentage = DR("Percentage"),
                        .YTDAmount = DR("YTD_Amount"),
                        .YTDItem = DR("YTD_CountItem"),
                        .YTDQty = DR("YTD_Qty")
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
    Function Get_YTD_Purchase()

        'get query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("  ISNULL(C.description, '') [Commodity] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 1 THEN A.tot_cost ELSE 0 END) [January] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 2 THEN A.tot_cost ELSE 0 END) [February] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 3 THEN A.tot_cost ELSE 0 END) [March] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 4 THEN A.tot_cost ELSE 0 END) [April] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 5 THEN A.tot_cost ELSE 0 END) [May] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 6 THEN A.tot_cost ELSE 0 END) [June] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 7 THEN A.tot_cost ELSE 0 END) [July] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 8 THEN A.tot_cost ELSE 0 END) [August] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 9 THEN A.tot_cost ELSE 0 END) [September] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 10 THEN A.tot_cost ELSE 0 END) [October] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 11 THEN A.tot_cost ELSE 0 END) [November] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 12 THEN A.tot_cost ELSE 0 END) [December] ")
        Query.Append("  ,SUM(A.tot_cost) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("  left join ogm_item_cat [C] ON [A].ICCode = [C].ic_code AND [C].lock = 1 ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  AND [B].Rvrs = 0 ")
        Query.Append("  AND [B].po_date >= DATEFROMPARTS(YEAR(GETDATE()), 1, 1) ")
        Query.Append("  AND [B].po_date < DATEFROMPARTS(YEAR(GETDATE()) + 1, 1, 1) ")
        Query.Append("group by ")
        Query.Append("  [C].description ")
        Query.Append("order by ")
        Query.Append("  [C].description ")
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
                        .Commodity = DR("Commodity"),
                        .January = DR("January"),
                        .February = DR("February"),
                        .March = DR("March"),
                        .April = DR("April"),
                        .May = DR("May"),
                        .June = DR("June"),
                        .July = DR("July"),
                        .August = DR("August"),
                        .September = DR("September"),
                        .October = DR("October"),
                        .November = DR("November"),
                        .December = DR("December"),
                        .Total = DR("Total")
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
    Function Get_YTD_Supplier()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL(C.vendor, '') [Vendor] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 1 THEN A.tot_cost ELSE 0 END) [January] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 2 THEN A.tot_cost ELSE 0 END) [February] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 3 THEN A.tot_cost ELSE 0 END) [March] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 4 THEN A.tot_cost ELSE 0 END) [April] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 5 THEN A.tot_cost ELSE 0 END) [May] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 6 THEN A.tot_cost ELSE 0 END) [June] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 7 THEN A.tot_cost ELSE 0 END) [July] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 8 THEN A.tot_cost ELSE 0 END) [August] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 9 THEN A.tot_cost ELSE 0 END) [September] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 10 THEN A.tot_cost ELSE 0 END) [October] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 11 THEN A.tot_cost ELSE 0 END) [November] ")
        Query.Append("  ,SUM(CASE WHEN MONTH([B].po_date) = 12 THEN A.tot_cost ELSE 0 END) [December] ")
        Query.Append("  ,SUM(A.tot_cost) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("  left join ogm_vendor [C] on [B].vendor = [C].v_code and [C].lock = 1 ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  AND [B].Rvrs = 0 ")
        Query.Append("  AND [B].po_date >= DATEFROMPARTS(YEAR(GETDATE()), 1, 1) ")
        Query.Append("  AND [B].po_date < DATEFROMPARTS(YEAR(GETDATE()) + 1, 1, 1) ")
        Query.Append("group by ")
        Query.Append("  [C].vendor ")
        Query.Append("order by ")
        Query.Append("  [Total] DESC ")
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
                        .Vendor = DR("Vendor"),
                        .January = DR("January"),
                        .February = DR("February"),
                        .March = DR("March"),
                        .April = DR("April"),
                        .May = DR("May"),
                        .June = DR("June"),
                        .July = DR("July"),
                        .August = DR("August"),
                        .September = DR("September"),
                        .October = DR("October"),
                        .November = DR("November"),
                        .December = DR("December"),
                        .Total = DR("Total")
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
    Function Get_YTD_Item()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL(C.description, '') [Commodity] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 1 THEN [A].item END) [January] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 2 THEN [A].item END) [February] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 3 THEN [A].item END) [March] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 4 THEN [A].item END) [April] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 5 THEN [A].item END) [May] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 6 THEN [A].item END) [June] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 7 THEN [A].item END) [July] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 8 THEN [A].item END) [August] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 9 THEN [A].item END) [September] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 10 THEN [A].item END) [October] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 11 THEN [A].item END) [November] ")
        Query.Append("  ,COUNT(CASE WHEN MONTH([B].po_date) = 12 THEN [A].item END) [December] ")
        Query.Append("  ,SUM(A.qty) [Total] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A] ")
        Query.Append("  left join ogm_po_hdr [B] on [A].po_code = [B].po_code ")
        Query.Append("  left join ogm_item_cat [C] ON [A].ICCode = [C].ic_code AND [C].lock = 1 ")
        Query.Append("where ")
        Query.Append("  [B].post = 1 ")
        Query.Append("  AND [B].Rvrs = 0 ")
        Query.Append("  AND [B].po_date >= DATEFROMPARTS(YEAR(GETDATE()), 1, 1) ")
        Query.Append("  AND [B].po_date < DATEFROMPARTS(YEAR(GETDATE()) + 1, 1, 1) ")
        Query.Append("group by ")
        Query.Append("  [C].description ")
        Query.Append("order by ")
        Query.Append("  [C].description ")
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
                        .Commodity = DR("Commodity"),
                        .January = DR("January"),
                        .February = DR("February"),
                        .March = DR("March"),
                        .April = DR("April"),
                        .May = DR("May"),
                        .June = DR("June"),
                        .July = DR("July"),
                        .August = DR("August"),
                        .September = DR("September"),
                        .October = DR("October"),
                        .November = DR("November"),
                        .December = DR("December"),
                        .Total = DR("Total")
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