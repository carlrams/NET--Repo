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

Public Class DSB250000HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
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

            End If

            If pFormCode = "DSB250000" And pType = "Get-Construction-Header" Then

                Dim json As String = Me.Get_Construction_Header()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contractor-Amount" Then

                Dim json As String = Me.Get_Contractor_Amount()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contractor-Filter" Then

                Dim pBatchNo = context.Request("pBatchNo")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")
                Dim pStatus = context.Request("pStatus")

                Dim json As String = Me.Get_Contractor_Filter(pBatchNo, pProject, pContractor, pStatus)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Project-Status" Then

                Dim json As String = Me.Get_Project_Status()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Project-Filter" Then

                Dim pBatchNo = context.Request("pBatchNo")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")
                Dim pStatus = context.Request("pStatus")

                Dim json As String = Me.Get_Project_Filter(pBatchNo, pProject, pContractor, pStatus)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Unit-Batch" Then

                Dim json As String = Me.Get_Unit_Batch()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Unit-Filter" Then

                Dim pProject = context.Request("pProject")

                Dim json As String = Me.Get_Unit_Filter(pProject)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Trend" Then

                Dim json As String = Me.Get_Contract_Trend()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Filter" Then

                Dim pBatchNo = context.Request("pBatchNo")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")
                Dim pStatus = context.Request("pStatus")

                Dim json As String = Me.Get_Contract_Filter(pBatchNo, pProject, pContractor, pStatus)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Batch" Then

                Dim json As String = Me.Get_Contract_Batch()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Batch-Filter" Then

                Dim pBatchNo = context.Request("pBatchNo")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")
                Dim pStatus = context.Request("pStatus")

                Dim json As String = Me.Get_Batch_Filter(pBatchNo, pProject, pContractor, pStatus)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Construction-Batch" Then

                Dim json As String = Me.Get_Construction_Batch()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Construction-Filter" Then

                Dim pBatchNo = context.Request("pBatchNo")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")
                Dim pStatus = context.Request("pStatus")

                Dim json As String = Me.Get_Construction_Filter(pBatchNo, pProject, pContractor, pStatus)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Category" Then

                Dim json As String = Me.Get_Contract_Category()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Category-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")

                Dim json As String = Me.Get_Contract_Category_Filter(pCategory, pProject, pContractor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contractor-Amount-COF" Then

                Dim json As String = Me.Get_Contract_Category_COF()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contractor-Amount-COF-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")

                Dim json As String = Me.Get_Contractor_Amount_COF_Filter(pCategory, pProject, pContractor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Trend-COF" Then

                Dim json As String = Me.Get_Contract_Trend_COF()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Trend-COF-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")

                Dim json As String = Me.Get_Contract_Trend_COF_Filter(pCategory, pProject, pContractor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Status" Then

                Dim json As String = Me.Get_Contract_Status()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Status-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")

                Dim json As String = Me.Get_Contract_Status_Filter(pCategory, pProject, pContractor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Batch-COF" Then

                Dim json As String = Me.Get_Contract_Batch_COF()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Batch-COF-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")

                Dim json As String = Me.Get_Contract_Batch_COF_Filter(pCategory, pProject, pContractor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Order" Then

                Dim json As String = Me.Get_Contract_Order()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "DSB250000" And pType = "Get-Contract-Order-Filter" Then

                Dim pCategory = context.Request("pCategory")
                Dim pProject = context.Request("pProject")
                Dim pContractor = context.Request("pContractor")

                Dim json As String = Me.Get_Contract_Order_Filter(pCategory, pProject, pContractor)
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
        If pTblName = "Get_Batch" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].BatchNo [ID] ")
            Query.Append("   ,[A].BatchNo [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].BatchNo [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.mstr_BatchNo [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].Active, 0) = 1 ")
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
            Query.Append("   CAST([A].ProjCode AS NVARCHAR) [ID] ")
            Query.Append("   ,[A].ProjName [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].ProjName [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.mstr_Projects [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].Lock, 0) = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Contractor" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].v_code [ID] ")
            Query.Append("   ,[A].vendor [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].vendor [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_vendor [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].Lock, 0) = 1 ")
            Query.Append("  AND ISNULL([A].Type, '') = 'Contractor' ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Status" Then
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
            Query.Append("   Form_HWTask [A] ")
            Query.Append("where ")
            Query.Append("  [A].TaskCode = '006' ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Category" Then
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
            Query.Append("   Form_CRT [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Project_COF" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   subdivision [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].Lock, 0) = 1 ")
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
#End Region

#Region "DSB250000"
    Function Get_Construction_Header()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select COUNT(1) from ogm_vendor where ISNULL(Lock, 0) = 1 and type = 'Contractor'), 0) [Contractor] ")
        Query.Append("  ,ISNULL((select COUNT(1) from calmardbLive.dbo.mstr_BatchNo where ISNULL(Active, 0) = 1), 0) [Batch] ")
        Query.Append("  ,ISNULL((select COUNT(1) from calmardbLive.dbo.mstr_LotsInventory [A]), 0) [Unit] ")
        Query.Append("  ,ISNULL((select COUNT(1) from Form_HWHdr where TCPBal < 0), 0) [OnGoing] ")
        Query.Append("  ,ISNULL((select COUNT(1) from Form_HWTask where TaskCode = '006' and Status = 'Complete'), 0) [Complete] ")
        Query.Append("  ,ISNULL((select COUNT(1) from Form_HWTask where TaskCode = '006' and Status = 'Not Started'), 0) [NotStarted] ")
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
                        .Contractor = DR("Contractor"),
                        .Batch = DR("Batch"),
                        .Unit = DR("Unit"),
                        .OnGoing = DR("OnGoing"),
                        .Complete = DR("Complete"),
                        .NotStarted = DR("NotStarted")
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
    Function Get_Contractor_Amount()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 10 ")
        Query.Append("  [C].vendor [Contractor] ")
        Query.Append("  ,SUM([A].ConPrice) [ContractAmt] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join Form_HWTask [B] on [A].HWCode = [B].HWCode ")
        Query.Append("  left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Awarded' ")
        Query.Append("  and [B].TaskCode = '006' ")
        Query.Append("  and ISNULL([C].type, '') = 'Contractor' ")
        Query.Append("group by ")
        Query.Append("  [C].vendor ")
        Query.Append("order by ")
        Query.Append("  [ContractAmt] DESC ")
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
                        .Contractor = DR("Contractor"),
                        .ContractAmt = DR("ContractAmt")
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
    Function Get_Contractor_Filter(pBatchNo, pProject, pContractor, pStatus)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 10 ")
        Query.Append("  [C].vendor [Contractor] ")
        Query.Append("  ,SUM([A].ConPrice) [ContractAmt] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join Form_HWTask [B] on [A].HWCode = [B].HWCode ")
        Query.Append("  left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("  left join calmardbLive.dbo.mstr_LotsInventory [D] on [A].LotCode = [D].LotCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Awarded' ")
        Query.Append("  and [B].TaskCode = '006' ")
        Query.Append("  and ISNULL([C].type, '') = 'Contractor' ")
        If pBatchNo <> "" Then
            Query.Append("  and ISNULL([A].BatchNo, '') = @pBatchNo ")
        End If
        If pProject <> "" Then
            Query.Append("  and [D].ProjCode = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [C].v_code = @pContractor ")
        End If
        If pStatus <> "" Then
            Query.Append("  and [B].Status = @pStatus ")
        End If
        Query.Append("group by ")
        Query.Append("  [C].vendor ")
        Query.Append("order by ")
        Query.Append("  [ContractAmt] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pBatchNo <> "" Then
                    Cmd.Parameters.AddWithValue("@pBatchNo", pBatchNo)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                If pStatus <> "" Then
                    Cmd.Parameters.AddWithValue("@pStatus", pStatus)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Contractor = DR("Contractor"),
                        .ContractAmt = DR("ContractAmt")
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
    Function Get_Project_Filter(pBatchNo, pProject, pContractor, pStatus)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  COUNT([A].Status) [Total] ")
        Query.Append("  ,[A].Status ")
        Query.Append("from ")
        Query.Append("  Form_HWTask [A] ")
        Query.Append("  left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_LotsInventory [C] on [B].LotCode = [C].LotCode ")
        Query.Append("  left join ogm_vendor [D] on [B].Contractor = [D].v_code ")
        Query.Append("where ")
        Query.Append("  [A].TaskCode = '006' ")
        Query.Append("  and [B].ConStatus = 'Awarded' ")
        If pBatchNo <> "" Then
            Query.Append("  and ISNULL([B].BatchNo, '') = @pBatchNo ")
        End If
        If pProject <> "" Then
            Query.Append("  and [C].ProjCode = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [D].v_code = @pContractor ")
        End If
        If pStatus <> "" Then
            Query.Append("  and [A].Status = @pStatus ")
        End If
        Query.Append("group by ")
        Query.Append("  [A].Status ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pBatchNo <> "" Then
                    Cmd.Parameters.AddWithValue("@pBatchNo", pBatchNo)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                If pStatus <> "" Then
                    Cmd.Parameters.AddWithValue("@pStatus", pStatus)
                End If
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
    Function Get_Unit_Batch()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 20 ")
        Query.Append("  COUNT([A].BatchNo) [Unit] ")
        Query.Append("  ,[A].BatchNo ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_LotsInventory [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_BatchNo [B] on [A].BatchNo = [B].BatchNo ")
        Query.Append("where ")
        Query.Append("  ISNULL([A].BatchNo, '') != '' ")
        Query.Append("  and ISNULL([A].BatchNo, '') != '-' ")
        Query.Append("group by ")
        Query.Append("  [A].BatchNo ")
        Query.Append("order by ")
        Query.Append("  [A].BatchNo DESC ")
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
                        .Unit = DR("Unit"),
                        .BatchNo = DR("BatchNo")
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
    Function Get_Unit_Filter(pProject)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 20 ")
        Query.Append("  COUNT([A].BatchNo) [Unit] ")
        Query.Append("  ,[A].BatchNo ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_LotsInventory [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_BatchNo [B] on [A].BatchNo = [B].BatchNo ")
        Query.Append("where ")
        Query.Append("  ISNULL([A].BatchNo, '') != '' ")
        Query.Append("  and ISNULL([A].BatchNo, '') != '-' ")
        If pProject <> "" Then
            Query.Append("  and [A].ProjCode = @pProject ")
        End If
        Query.Append("group by ")
        Query.Append("  [A].BatchNo ")
        Query.Append("order by ")
        Query.Append("  [A].BatchNo DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Unit = DR("Unit"),
                        .BatchNo = DR("BatchNo")
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
    Function Get_Contract_Trend()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  SUM([SumAmt]) [AwardAmt] ")
        Query.Append("  ,[HWDate] [Date] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  SUM([A].ConPrice) [SumAmt] ")
        Query.Append("  ,FORMAT([A].HWDate, 'yyyy-MM') [HWDate] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("where ")
        Query.Append("  [A].HWDate >= DATEADD(MONTH, -10, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  AND [A].HWDate <= GETDATE() ")
        Query.Append("  AND [A].ConStatus = 'Awarded' ")
        Query.Append("group by ")
        Query.Append("  [A].HWDate) [Tbl] ")
        Query.Append("group by ")
        Query.Append("  [HWDate] ")
        Query.Append("order by ")
        Query.Append("  [HWDate] DESC ")
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
                        .AwardAmt = DR("AwardAmt"),
                        .Date = DR("Date")
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
    Function Get_Contract_Filter(pBatchNo, pProject, pContractor, pStatus)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  SUM([SumAmt]) [AwardAmt] ")
        Query.Append("  ,[HWDate] [Date] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  SUM([A].ConPrice) [SumAmt] ")
        Query.Append("  ,FORMAT([A].HWDate, 'yyyy-MM') [HWDate] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join Form_HWTask [B] on [A].HWCode = [B].HWCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_LotsInventory [C] on [A].LotCode = [C].LotCode ")
        Query.Append("  left join ogm_vendor [D] on [A].Contractor = [D].v_code ")
        Query.Append("where ")
        Query.Append("  [A].HWDate >= DATEADD(MONTH, -10, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  AND [A].HWDate <= GETDATE() ")
        Query.Append("  AND [A].ConStatus = 'Awarded' ")
        If pBatchNo <> "" Then
            Query.Append("  and ISNULL([A].BatchNo, '') = @pBatchNo ")
        End If
        If pProject <> "" Then
            Query.Append("  and [C].ProjCode = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [D].v_code = @pContractor ")
        End If
        If pStatus <> "" Then
            Query.Append("  and [B].Status = @pStatus ")
        End If
        Query.Append("group by ")
        Query.Append("  [A].HWDate) [Tbl] ")
        Query.Append("group by ")
        Query.Append("  [HWDate] ")
        Query.Append("order by ")
        Query.Append("  [HWDate] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pBatchNo <> "" Then
                    Cmd.Parameters.AddWithValue("@pBatchNo", pBatchNo)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                If pStatus <> "" Then
                    Cmd.Parameters.AddWithValue("@pStatus", pStatus)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .AwardAmt = DR("AwardAmt"),
                        .Date = DR("Date")
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
    Function Get_Contract_Batch()

        'get query
        Dim Query As New StringBuilder
        Query.Append("DECLARE @pDate DATE = DATEADD(MONTH, -12, GETDATE()); ")
        Query.Append("WITH DataAgg AS ( ")
        Query.Append("  SELECT ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [A].ConType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [A].ConType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) [ConType] ")
        Query.Append("      ,FORMAT([A].HWDate, 'yyyy-MM') [Date] ")
        Query.Append("      ,SUM([A].ConPrice) [Amount] ")
        Query.Append("  FROM ")
        Query.Append("      Form_HWHdr [A] ")
        Query.Append("  WHERE ")
        Query.Append("      [A].HWDate >= @pDate ")
        Query.Append("  GROUP BY ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [A].ConType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [A].ConType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) ")
        Query.Append("      ,FORMAT([A].HWDate, 'yyyy-MM') ")
        Query.Append(") ")
        Query.Append("SELECT ")
        Query.Append("  [Date] ")
        Query.Append("  ,ISNULL([OSM], 0) [OSM] ")
        Query.Append("  ,ISNULL([Straight], 0) [Straight] ")
        Query.Append("  ,ISNULL((select SUM([A].ContractPrice) from Form_CRT [A] where [A].ContractStatus = 'Awarded' and [A].Category in ('House Construction') and [A].ContractCategory = 'Variation Order' and FORMAT([A].DateAwarded, 'yyyy-MM') = [Date]), 0) [VariationOrder] ")
        Query.Append("FROM ")
        Query.Append("  DataAgg ")
        Query.Append("PIVOT( ")
        Query.Append("  SUM([Amount]) ")
        Query.Append("  FOR [ConType] IN ([OSM], [Straight]) ")
        Query.Append(") P ")
        Query.Append("ORDER BY [Date] DESC ")
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
                        .OSM = DR("OSM"),
                        .Straight = DR("Straight"),
                        .VariationOrder = DR("VariationOrder"),
                        .Date = DR("Date")
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
    Function Get_Batch_Filter(pBatchNo, pProject, pContractor, pStatus)

        'get query
        Dim Query As New StringBuilder
        Query.Append("DECLARE @pDate DATE = DATEADD(MONTH, -12, GETDATE()); ")
        Query.Append("WITH DataAgg AS ( ")
        Query.Append("  SELECT ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [A].ConType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [A].ConType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) [ConType] ")
        Query.Append("      ,FORMAT([A].HWDate, 'yyyy-MM') [Date] ")
        Query.Append("      ,SUM([A].ConPrice) [Amount] ")
        Query.Append("  FROM ")
        Query.Append("      Form_HWHdr [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [A].LotCode = [B].LotCode ")
        Query.Append("      left join Form_HWTask [C] on [A].HWCode = [C].HWCode ")
        Query.Append("  WHERE ")
        Query.Append("      [A].HWDate >= @pDate ")
        If pBatchNo <> "" Then
            Query.Append("  and ISNULL([A].BatchNo, '') = @pBatchNo ")
        End If
        If pProject <> "" Then
            Query.Append("  and [B].ProjCode = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [A].Contractor = @pContractor ")
        End If
        If pStatus <> "" Then
            Query.Append("  and [C].Status = @pStatus ")
        End If
        Query.Append("  GROUP BY ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [A].ConType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [A].ConType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) ")
        Query.Append("      ,FORMAT([A].HWDate, 'yyyy-MM') ")
        Query.Append(") ")
        Query.Append("SELECT ")
        Query.Append("  [Date] ")
        Query.Append("  ,ISNULL([OSM], 0) [OSM] ")
        Query.Append("  ,ISNULL([Straight], 0) [Straight] ")
        Query.Append("  ,ISNULL((select SUM([A].ContractPrice) from Form_CRT [A] where [A].ContractStatus = 'Awarded' and [A].Category in ('House Construction') and [A].ContractCategory = 'Variation Order' and FORMAT([A].DateAwarded, 'yyyy-MM') = [Date]), 0) [VariationOrder] ")
        Query.Append("FROM ")
        Query.Append("  DataAgg ")
        Query.Append("PIVOT( ")
        Query.Append("  SUM([Amount]) ")
        Query.Append("  FOR [ConType] IN ([OSM], [Straight]) ")
        Query.Append(") P ")
        Query.Append("ORDER BY [Date] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pBatchNo <> "" Then
                    Cmd.Parameters.AddWithValue("@pBatchNo", pBatchNo)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                If pStatus <> "" Then
                    Cmd.Parameters.AddWithValue("@pStatus", pStatus)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .OSM = DR("OSM"),
                        .Straight = DR("Straight"),
                        .VariationOrder = DR("VariationOrder"),
                        .Date = DR("Date")
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
    Function Get_Construction_Batch()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].BatchNo ")
        Query.Append("  ,[C].ProjInit + ' ' + [A].Phase  + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("  ,[C].ProvinceName [Location] ")
        Query.Append("  ,[B].Vendor [Contractor] ")
        Query.Append("  ,[A].ConNo ")
        Query.Append("  ,[A].ConType ")
        Query.Append("  ,[A].ConPrice ")
        Query.Append("  ,[A].TCPBal ")
        Query.Append("  ,[A].VAT ")
        Query.Append("  ,[A].EWT ")
        Query.Append("  ,[A].RF ")
        Query.Append("  ,ISNULL(FORMAT([A].NTPDate, 'MM/dd/yyyy'), '') [NTPDate] ")
        Query.Append("  ,FORMAT([A].DateStart, 'MM/dd/yyyy') [DateStart] ")
        Query.Append("  ,FORMAT([A].DateEnd, 'MM/dd/yyyy') [DateEnd] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join ogm_vendor [B] on [A].Contractor = [B].v_code ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Awarded' ")
        Query.Append("  and [A].TCPBal > 0 ")
        Query.Append("order by ")
        Query.Append("  [A].BatchNo DESC ")
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
                        .BatchNo = DR("BatchNo"),
                        .Project = DR("Project"),
                        .Location = DR("Location"),
                        .Contractor = DR("Contractor"),
                        .ConNo = DR("ConNo"),
                        .ConPrice = DR("ConPrice"),
                        .TCPBal = DR("TCPBal"),
                        .VAT = DR("VAT"),
                        .EWT = DR("EWT"),
                        .RF = DR("RF"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd")
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
    Function Get_Construction_Filter(pBatchNo, pProject, pContractor, pStatus)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].BatchNo ")
        Query.Append("  ,[F].ProjName + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("  ,[F].ProvinceName [Location] ")
        Query.Append("  ,[D].vendor [Contractor] ")
        Query.Append("  ,[B].ConNo ")
        Query.Append("  ,[B].ConPrice ")
        Query.Append("  ,[B].VAT ")
        Query.Append("  ,[B].EWT ")
        Query.Append("  ,[B].RF ")
        Query.Append("  ,FORMAT([B].DateStart, 'MM/dd/yyyy') [DateStart] ")
        Query.Append("  ,FORMAT([B].DateEnd, 'MM/dd/yyyy') [DateEnd] ")
        Query.Append("  ,[C].Status ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_BatchNo [A] ")
        Query.Append("  left join Form_HWHdr [B] on [A].BatchNo = [B].BatchNo ")
        Query.Append("  left join Form_HWTask [C] on [B].HWCode = [C].HWCode ")
        Query.Append("  left join ogm_vendor [D] on [B].Contractor = [D].v_code ")
        Query.Append("  left join calmardbLive.dbo.mstr_LotsInventory [E] on [B].HWCode = [E].LotCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [F] on [E].ProjCode = [F].ProjCode ")
        Query.Append("where ")
        Query.Append("  ISNULL([A].Active, 0) = 1 ")
        Query.Append("  and [B].ConStatus = 'Awarded' ")
        Query.Append("  and [C].TaskCode = '006' ")
        Query.Append("  and [D].type = 'Contractor' ")
        If pBatchNo <> "" Then
            Query.Append("  and [A].BatchNo = @pBatchNo ")
        End If
        If pProject <> "" Then
            Query.Append("  and [E].ProjCode = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [D].v_code = @pContractor ")
        End If
        If pStatus <> "" Then
            Query.Append("  and [C].Status = @pStatus ")
        End If
        Query.Append("order by ")
        Query.Append("  [A].BatchNo DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pBatchNo <> "" Then
                    Cmd.Parameters.AddWithValue("@pBatchNo", pBatchNo)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                If pStatus <> "" Then
                    Cmd.Parameters.AddWithValue("@pStatus", pStatus)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .BatchNo = DR("BatchNo"),
                        .Project = DR("Project"),
                        .Location = DR("Location"),
                        .Contractor = DR("Contractor"),
                        .ConNo = DR("ConNo"),
                        .ConPrice = DR("ConPrice"),
                        .VAT = DR("VAT"),
                        .EWT = DR("EWT"),
                        .RF = DR("RF"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
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
    Function Get_Contract_Category()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("  [B].Category ")
        Query.Append("  ,COUNT([B].Category) [TotalCount] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].status in ('Accepted') ")
        Query.Append("  and [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
        Query.Append("  and [B].ContractStatus = 'Awarded' ")
        Query.Append("group by ")
        Query.Append("  [B].Category ")
        Query.Append("order by ")
        Query.Append("  [TotalCount] DESC ")
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
                        .Category = DR("Category"),
                        .Total = DR("TotalCount")
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
    Function Get_Contract_Category_Filter(pCategory, pProject, pContractor)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("  [B].Category ")
        Query.Append("  ,COUNT([B].Category) [TotalCount] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].status in ('Accepted') ")
        Query.Append("  and [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
        Query.Append("  and [B].ContractStatus = 'Awarded' ")
        If pCategory <> "" Then
            Query.Append("  and [B].Category = @pCategory ")
        End If
        If pProject <> "" Then
            Query.Append("  and [B].Subdivision = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [B].Contractor = @pContractor ")
        End If
        Query.Append("group by ")
        Query.Append("  [B].Category ")
        Query.Append("order by ")
        Query.Append("  [TotalCount] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pCategory <> "" Then
                    Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Category = DR("Category"),
                        .Total = DR("TotalCount")
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
    Function Get_Contract_Category_COF()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 10 ")
        Query.Append("  [C].vendor [Contractor] ")
        Query.Append("  ,SUM([B].ContractPrice) [ConPrice] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join ogm_vendor [C]  on [B].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("  [A].status in ('Accepted') ")
        Query.Append("  and [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
        Query.Append("  and [B].ContractStatus = 'Awarded' ")
        Query.Append("  and [B].ContractPrice > 0 ")
        Query.Append("group by ")
        Query.Append("  [C].vendor ")
        Query.Append("order by ")
        Query.Append("  [ConPrice] DESC ")
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
                        .Contractor = DR("Contractor"),
                        .ConPrice = DR("ConPrice")
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
    Function Get_Contractor_Amount_COF_Filter(pCategory, pProject, pContractor)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 10 ")
        Query.Append("  [C].vendor [Contractor] ")
        Query.Append("  ,SUM([B].ContractPrice) [ConPrice] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join ogm_vendor [C]  on [B].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("  [A].status in ('Accepted') ")
        Query.Append("  and [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and YEAR([A].created_date) = YEAR(GETDATE()) ")
        Query.Append("  and [B].ContractStatus = 'Awarded' ")
        Query.Append("  and [B].ContractPrice > 0 ")
        If pCategory <> "" Then
            Query.Append("  and [B].Category = @pCategory ")
        End If
        If pProject <> "" Then
            Query.Append("  and [B].Subdivision = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [B].Contractor = @pContractor ")
        End If
        Query.Append("group by ")
        Query.Append("  [C].vendor ")
        Query.Append("order by ")
        Query.Append("  [ConPrice] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pCategory <> "" Then
                    Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Contractor = DR("Contractor"),
                        .ConPrice = DR("ConPrice")
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
    Function Get_Contract_Trend_COF()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [DateAwarded] ")
        Query.Append("  ,SUM([SumAmt]) [AwardAmt] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  FORMAT([B].DateAwarded, 'yyyy-MM') [DateAwarded] ")
        Query.Append("  ,SUM([B].ContractPrice) [SumAmt] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].status in ('Accepted') ")
        Query.Append("  and [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [B].DateAwarded >= DATEADD(MONTH, -10, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  and [B].ContractStatus = 'Awarded' ")
        Query.Append("  and [B].ContractCategory = 'Job Order' ")
        Query.Append("  and [B].Category not in ('House Construction') ")
        Query.Append("  and [B].ContractPrice > 0 ")
        Query.Append("group by ")
        Query.Append("  [B].DateAwarded) [Tbl] ")
        Query.Append("group by ")
        Query.Append("  [DateAwarded] ")
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
                        .DateAwarded = DR("DateAwarded"),
                        .AwardAmt = DR("AwardAmt")
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
    Function Get_Contract_Trend_COF_Filter(pCategory, pProject, pContractor)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [DateAwarded] ")
        Query.Append("  ,SUM([SumAmt]) [AwardAmt] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  FORMAT([B].DateAwarded, 'yyyy-MM') [DateAwarded] ")
        Query.Append("  ,SUM([B].ContractPrice) [SumAmt] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].status in ('Accepted') ")
        Query.Append("  and [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [B].DateAwarded >= DATEADD(MONTH, -10, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  and [B].ContractStatus = 'Awarded' ")
        Query.Append("  and [B].ContractCategory = 'Job Order' ")
        Query.Append("  and [B].Category not in ('House Construction') ")
        Query.Append("  and [B].ContractPrice > 0 ")
        If pCategory <> "" Then
            Query.Append("  and [B].Category = @pCategory ")
        End If
        If pProject <> "" Then
            Query.Append("  and [B].Subdivision = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [B].Contractor = @pContractor ")
        End If
        Query.Append("group by ")
        Query.Append("  [B].DateAwarded) [Tbl] ")
        Query.Append("group by ")
        Query.Append("  [DateAwarded] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pCategory <> "" Then
                    Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .DateAwarded = DR("DateAwarded"),
                        .AwardAmt = DR("AwardAmt")
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
    Function Get_Contract_Status()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status ")
        Query.Append("  ,COUNT([A].status) [Total] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [B].DateAwarded >= DATEADD(MONTH, -10, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  and [B].ContractCategory = 'Job Order' ")
        Query.Append("  and [B].Category not in ('House Construction') ")
        Query.Append("  and [B].ContractPrice > 0 ")
        Query.Append("group by ")
        Query.Append("  [A].status ")
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
                        .Status = DR("status"),
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
    Function Get_Contract_Status_Filter(pCategory, pProject, pContractor)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status ")
        Query.Append("  ,COUNT([A].status) [Total] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [B].DateAwarded >= DATEADD(MONTH, -10, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) ")
        Query.Append("  and [B].ContractCategory = 'Job Order' ")
        Query.Append("  and [B].Category not in ('House Construction') ")
        Query.Append("  and [B].ContractPrice > 0 ")
        If pCategory <> "" Then
            Query.Append("  and [B].Category = @pCategory ")
        End If
        If pProject <> "" Then
            Query.Append("  and [B].Subdivision = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [B].Contractor = @pContractor ")
        End If
        Query.Append("group by ")
        Query.Append("  [A].status ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pCategory <> "" Then
                    Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Status = DR("status"),
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
    Function Get_Contract_Batch_COF()

        'get query
        Dim Query As New StringBuilder
        Query.Append("DECLARE @pDate DATE = DATEADD(MONTH, -12, GETDATE()); ")
        Query.Append("WITH DataAgg AS ( ")
        Query.Append("  SELECT ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [B].ContractType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [B].ContractType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) [ConType] ")
        Query.Append("      ,FORMAT([B].DateAwarded, 'yyyy-MM') [Date] ")
        Query.Append("      ,SUM([B].ContractPrice) [Amount] ")
        Query.Append("  FROM ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  WHERE ")
        Query.Append("      [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [A].status in ('Accepted') ")
        Query.Append("      and [B].ContractStatus = 'Awarded' ")
        Query.Append("      and [B].ContractCategory = 'Job Order' ")
        Query.Append("      and [B].Category not in ('House Construction') ")
        Query.Append("      and [B].DateAwarded >= @pDate ")
        Query.Append("  GROUP BY ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [B].ContractType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [B].ContractType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) ")
        Query.Append("      ,FORMAT([B].DateAwarded, 'yyyy-MM') ")
        Query.Append(") ")
        Query.Append("SELECT ")
        Query.Append("  [Date] ")
        Query.Append("  ,ISNULL([OSM], 0) [OSM] ")
        Query.Append("  ,ISNULL([Straight], 0) [Straight] ")
        Query.Append("  ,ISNULL((select SUM([A].ContractPrice) from Form_CRT [A] where [A].ContractStatus = 'Awarded' and [A].Category in ('House Construction') and [A].ContractCategory = 'Variation Order' and FORMAT([A].DateAwarded, 'yyyy-MM') = [Date]), 0) [VariationOrder] ")
        Query.Append("FROM ")
        Query.Append("  DataAgg ")
        Query.Append("PIVOT( ")
        Query.Append("  SUM([Amount]) ")
        Query.Append("  FOR [ConType] IN ([OSM], [Straight]) ")
        Query.Append(") P ")
        Query.Append("ORDER BY [Date] DESC ")
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
                        .Date = DR("Date"),
                        .OSM = DR("OSM"),
                        .Straight = DR("Straight"),
                        .VariationOrder = DR("VariationOrder")
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
    Function Get_Contract_Batch_COF_Filter(pCategory, pProject, pContractor)

        'get query
        Dim Query As New StringBuilder
        Query.Append("DECLARE @pDate DATE = DATEADD(MONTH, -12, GETDATE()); ")
        Query.Append("WITH DataAgg AS ( ")
        Query.Append("  SELECT ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [B].ContractType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [B].ContractType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) [ConType] ")
        Query.Append("      ,FORMAT([B].DateAwarded, 'yyyy-MM') [Date] ")
        Query.Append("      ,SUM([B].ContractPrice) [Amount] ")
        Query.Append("  FROM ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  WHERE ")
        Query.Append("      [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [A].status in ('Accepted') ")
        Query.Append("      and [B].ContractStatus = 'Awarded' ")
        Query.Append("      and [B].ContractCategory = 'Job Order' ")
        Query.Append("      and [B].Category not in ('House Construction') ")
        Query.Append("      and [B].DateAwarded >= @pDate ")
        If pCategory <> "" Then
            Query.Append("  and [B].Category = @pCategory ")
        End If
        If pProject <> "" Then
            Query.Append("  and [B].Subdivision = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [B].Contractor = @pContractor ")
        End If
        Query.Append("  GROUP BY ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN [B].ContractType = 'OSM' THEN 'OSM' ")
        Query.Append("          WHEN [B].ContractType LIKE '%Package%' THEN 'Straight' ")
        Query.Append("      END) ")
        Query.Append("      ,FORMAT([B].DateAwarded, 'yyyy-MM') ")
        Query.Append(") ")
        Query.Append("SELECT ")
        Query.Append("  [Date] ")
        Query.Append("  ,ISNULL([OSM], 0) [OSM] ")
        Query.Append("  ,ISNULL([Straight], 0) [Straight] ")
        Query.Append("  ,ISNULL((select SUM([A].ContractPrice) from Form_CRT [A] where [A].ContractStatus = 'Awarded' and [A].Category in ('House Construction') and [A].ContractCategory = 'Variation Order' and FORMAT([A].DateAwarded, 'yyyy-MM') = [Date]), 0) [VariationOrder] ")
        Query.Append("FROM ")
        Query.Append("  DataAgg ")
        Query.Append("PIVOT( ")
        Query.Append("  SUM([Amount]) ")
        Query.Append("  FOR [ConType] IN ([OSM], [Straight]) ")
        Query.Append(") P ")
        Query.Append("ORDER BY [Date] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                If pCategory <> "" Then
                    Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Date = DR("Date"),
                        .OSM = DR("OSM"),
                        .Straight = DR("Straight"),
                        .VariationOrder = DR("VariationOrder")
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
    Function Get_Contract_Order()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].f_code [FormNo] ")
        Query.Append("  ,(CASE WHEN [A].status = 'Accepted' THEN 'Accepted' WHEN [A].status in ('Cancelled', 'Declined') THEN 'Cancelled' ELSE 'On-Going' END) [Status] ")
        Query.Append("  ,ISNULL([B].ContractNo, '') [ConNo] ")
        Query.Append("  ,ISNULL([C].vendor, '') [Contractor] ")
        Query.Append("  ,[B].ContractType [ConType] ")
        Query.Append("  ,[B].Category ")
        Query.Append("  ,[B].Project ")
        Query.Append("  ,[B].ContractPrice ")
        Query.Append("  ,[B].VAT ")
        Query.Append("  ,[B].EWT ")
        Query.Append("  ,[B].DP ")
        Query.Append("  ,[B].RF ")
        Query.Append("  ,[B].ContractPriorStart ")
        Query.Append("  ,[B].ContractStatus ")
        Query.Append("  ,ISNULL(FORMAT([B].DateAwarded, 'MM/dd/yyyy'), '') [DateAwarded] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT([APPR].updated_date, 'MM/dd/yyyy') from oop_form_dtl_appr [APPR] where [APPR].f_code = [A].f_code order by [APPR].updated_date desc), '') [ApprDate] ")
        Query.Append("  ,[A].remarks ")
        Query.Append("  ,[B].TCPBal ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join ogm_vendor [C] on [B].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].status not in ('Cancelled', 'Declined') ")
        Query.Append("order by ")
        Query.Append("  [A].created_date desc ")
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
                        .FormNo = DR("FormNo"),
                        .Status = DR("Status"),
                        .ConNo = DR("ConNo"),
                        .Contractor = DR("Contractor"),
                        .ConType = DR("ConType"),
                        .Category = DR("Category"),
                        .Project = DR("Project"),
                        .ContractPrice = DR("ContractPrice"),
                        .VAT = DR("VAT"),
                        .EWT = DR("EWT"),
                        .DP = DR("DP"),
                        .RF = DR("RF"),
                        .ContractPriorStart = DR("ContractPriorStart"),
                        .ContractStatus = DR("ContractStatus"),
                        .DateAwarded = DR("DateAwarded"),
                        .ApprDate = DR("ApprDate"),
                        .Remarks = DR("remarks"),
                        .TCPBal = DR("TCPBal")
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
    Function Get_Contract_Order_Filter(pCategory, pProject, pContractor)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].f_code [FormNo] ")
        Query.Append("  ,(CASE WHEN [A].status = 'Accepted' THEN 'Accepted' WHEN [A].status in ('Cancelled', 'Declined') THEN 'Cancelled' ELSE 'On-Going' END) [Status] ")
        Query.Append("  ,ISNULL([B].ContractNo, '') [ConNo] ")
        Query.Append("  ,ISNULL([C].vendor, '') [Contractor] ")
        Query.Append("  ,[B].ContractType [ConType] ")
        Query.Append("  ,[B].Category ")
        Query.Append("  ,[B].Project ")
        Query.Append("  ,[B].ContractPrice ")
        Query.Append("  ,[B].VAT ")
        Query.Append("  ,[B].EWT ")
        Query.Append("  ,[B].DP ")
        Query.Append("  ,[B].RF ")
        Query.Append("  ,[B].ContractPriorStart ")
        Query.Append("  ,[B].ContractStatus ")
        Query.Append("  ,ISNULL(FORMAT([B].DateAwarded, 'MM/dd/yyyy'), '') [DateAwarded] ")
        Query.Append("  ,ISNULL((select top 1 FORMAT([APPR].updated_date, 'MM/dd/yyyy') from oop_form_dtl_appr [APPR] where [APPR].f_code = [A].f_code order by [APPR].updated_date desc), '') [ApprDate] ")
        Query.Append("  ,[A].remarks ")
        Query.Append("  ,[B].TCPBal ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join ogm_vendor [C] on [B].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].status not in ('Cancelled', 'Declined') ")
        If pCategory <> "" Then
            Query.Append("  and [B].Category = @pCategory ")
        End If
        If pProject <> "" Then
            Query.Append("  and [B].Subdivision = @pProject ")
        End If
        If pContractor <> "" Then
            Query.Append("  and [B].Contractor = @pContractor ")
        End If
        Query.Append("order by ")
        Query.Append("  [A].created_date desc ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                If pCategory <> "" Then
                    Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                End If
                If pProject <> "" Then
                    Cmd.Parameters.AddWithValue("@pProject", pProject)
                End If
                If pContractor <> "" Then
                    Cmd.Parameters.AddWithValue("@pContractor", pContractor)
                End If
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .FormNo = DR("FormNo"),
                        .Status = DR("Status"),
                        .ConNo = DR("ConNo"),
                        .Contractor = DR("Contractor"),
                        .ConType = DR("ConType"),
                        .Category = DR("Category"),
                        .Project = DR("Project"),
                        .ContractPrice = DR("ContractPrice"),
                        .VAT = DR("VAT"),
                        .EWT = DR("EWT"),
                        .DP = DR("DP"),
                        .RF = DR("RF"),
                        .ContractPriorStart = DR("ContractPriorStart"),
                        .ContractStatus = DR("ContractStatus"),
                        .DateAwarded = DR("DateAwarded"),
                        .ApprDate = DR("ApprDate"),
                        .Remarks = DR("remarks"),
                        .TCPBal = DR("TCPBal")
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