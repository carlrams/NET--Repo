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
Imports Newtonsoft.Json.Linq
Imports OfficeOpenXml.ConditionalFormatting.Contracts

Public Class DSB290000HND
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

            If pFormCode = "DSB290000" And pType = "Get-Cost-Header" Then

                Dim json As String = Me.Get_Cost_Header()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB290000" And pType = "Get-Project-Division" Then

                Dim json As String = Me.Get_Project_Region()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB290000" And pType = "Get-Project-Status" Then

                Dim json As String = Me.Get_Project_Status()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB290000" And pType = "Get-Monthly-Construction" Then

                Dim json As String = Me.Get_Monthly_Construction()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB290000" And pType = "Get-Estimate-Category" Then

                Dim json As String = Me.Get_Estimate_Category()
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

#Region "DSB290000"
    Function Get_Cost_Header()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select count(1) from Form_HWHdr), 0) [Project] ")
        Query.Append("  ,ISNULL((select SUM([A].Budget) from Trxn_CEDtl [A] left join Trxn_CEHdr [B] on [A].CECode = [B].CECode and [B].Post = 1 and [B].Rvrs = 0), 0) [Budget] ")
        Query.Append("  ,ISNULL((select SUM([A].Actualize) from Trxn_CEDtl [A] left join Trxn_CEHdr [B] on [A].CECode = [B].CECode and [B].Post = 1 and [B].Rvrs = 0), 0) [Cost] ")
        Query.Append("  ,ISNULL((select SUM([A].Actualize) * 1.0 / COUNT(distinct [A].WCode) from Trxn_CEDtl [A] left join Trxn_CEHdr [B] on [A].CECode = [B].CECode and [B].Post = 1 and [B].Rvrs = 0), 0) [CostScope] ")
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
                        .Project = DR("Project"),
                        .Budget = DR("Budget"),
                        .Cost = DR("Cost"),
                        .CostScope = DR("CostScope")
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
    Function Get_Project_Region()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [B].Division ")
        Query.Append("  ,COUNT([B].Division) [Total] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("group by ")
        Query.Append("  [B].Division ")
        Query.Append("order by ")
        Query.Append("  [B].Division ")
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
                        .Division = DR("Division"),
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
    Function Get_Project_Status()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  COUNT([A].Status) [Total] ")
        Query.Append("  ,[A].Status ")
        Query.Append("from ")
        Query.Append("  Form_HWTask [A] ")
        Query.Append("where ")
        Query.Append("  [A].TaskCode = '006' ")
        Query.Append("group by ")
        Query.Append("  [A].Status ")
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
    Function Get_Monthly_Construction()

        'get query
        Dim Query As New StringBuilder
        Query.Append("WITH Months AS ( ")
        Query.Append("  SELECT 1 AS MonthNum UNION ALL ")
        Query.Append("  SELECT 2 UNION ALL ")
        Query.Append("  SELECT 3 UNION ALL ")
        Query.Append("  SELECT 4 UNION ALL ")
        Query.Append("  SELECT 5 UNION ALL ")
        Query.Append("  SELECT 6 UNION ALL ")
        Query.Append("  SELECT 7 UNION ALL ")
        Query.Append("  SELECT 8 UNION ALL ")
        Query.Append("  SELECT 9 UNION ALL ")
        Query.Append("  SELECT 10 UNION ALL ")
        Query.Append("  SELECT 11 UNION ALL ")
        Query.Append("  SELECT 12 ")
        Query.Append(") ")
        Query.Append("select ")
        Query.Append("  [A].MonthNum [Month] ")
        Query.Append("  ,COUNT([B].DateEnd) [Total] ")
        Query.Append("  ,DATENAME(MONTH, DATEFROMPARTS(YEAR(GETDATE()), [A].MonthNum, 1)) [MonthName] ")
        Query.Append("from ")
        Query.Append("  Months [A] ")
        Query.Append("  LEFT JOIN Form_HWTask [B] ON MONTH([B].DateEnd) = [A].MonthNum AND YEAR([B].DateEnd) = YEAR(GETDATE()) AND [B].TaskCode = '006' AND [B].Status = 'Complete' ")
        Query.Append("  LEFT JOIN Form_HWHdr [C] ON [B].HWCode = [C].HWCode ")
        Query.Append("group by ")
        Query.Append("  [A].MonthNum ")
        Query.Append("order by ")
        Query.Append("  [A].MonthNum ")
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
                        .Month = DR("Month"),
                        .Total = DR("Total"),
                        .MonthName = DR("MonthName")
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
    Function Get_Estimate_Category()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Category ")
        Query.Append("  ,COUNT([A].Category) [Total] ")
        Query.Append("from ")
        Query.Append("  Trxn_CEHdr [A] ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  and [A].Rvrs = 0 ")
        Query.Append("  and ISNULL([A].Category, '') != '' ")
        Query.Append("group by ")
        Query.Append("  [A].Category ")
        Query.Append("order by ")
        Query.Append("  [A].Category ")
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
                        .Category = DR("Category")
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