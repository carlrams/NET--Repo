Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports System.Web
Imports System.Web.Services
Imports Microsoft.Ajax.Utilities
Imports System.IO
Imports System.Runtime.InteropServices
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Windows.Media
Imports Newtonsoft.Json
Imports System.Net.Mime

Public Class HNDACC
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
    'connection

#Region "Form"

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim pFormCode = context.Request("pFormCode")
            Dim pType = context.Request("pType")
            'general parameter

            If pFormCode = "ACC040000" And pType = "Get Record" Then

                Dim json As String = Me.ACC040000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC040000" And pType = "Get Record - Redraw" Then

                Dim pSICode = context.Request("pSICode")
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.ACC040000_Get_Record_Redraw(pSICode, pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC040000" And pType = "Get Record - HDR" Then

                Dim pPosted = context.Request("pPosted")

                Dim json As String = Me.ACC040000_Get_Record_HDR(pPosted)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC040000" And pType = "Get Info" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.ACC040000_Get_Info(pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC040000" And pType = "Edit Record Info" Then

                Dim pSICode = context.Request("pSICode")
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.ACC040000_Edit_Record_Info(pSICode, pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC040000" And pType = "Get Info - Redraw" Then

                Dim pSICode = context.Request("pSICode")
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.ACC040000_Get_Info_Redraw(pSICode, pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "ACC050000" And pType = "Get Record" Then

                Dim json As String = Me.ACC050000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC050000" And pType = "PO Record" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.ACC050000_Get_PO_Record(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC050000" And pType = "IR Record" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.ACC050000_Get_IR_Record(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "ACC060000" And pType = "Get Record" Then

                Dim pItem = context.Request("pItem")
                Dim pDate = context.Request("pDate")
                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.ACC060000_Get_Record(pItem, pDate, pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "ACC060000" And pType = "Get Record : Item" Then

                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.ACC060000_Get_Record_Item(pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Dropdown" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Dropdown_Get_Record(pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

        Catch ex As Exception
            'nothing
        End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#End Region

#Region "Dropdown"

    Function Dropdown_Get_Record(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Mstr_Employee" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].emp_no [ID] ")
            Query.Append("   ,[A].fullname [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].fullname [Order2] ")
            Query.Append("from ")
            Query.Append("   employee [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Warehouse" Then
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
        ElseIf pTblName = "Mstr_Vendor" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].v_code [ID] ")
            Query.Append("   ,[A].vendor [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].vendor [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_vendor [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Trxn_PRHdr(CP)" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].pr_code [ID] ")
            Query.Append("   ,[A].form_no [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].form_no [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_pr_hdr [A] ")
            Query.Append("   left join oop_form_hdr [B] on [A].form_no = [B].f_code ")
            Query.Append("where ")
            Query.Append("  [A].PurchaseType in ('Credit Purchase','Cash Purchase','Stock Request') ")
            Query.Append("  and [B].status = 'Accepted' ")
            Query.Append("  and (select count(*) from ogm_pr_dtl where ogm_pr_dtl.pr_code = [A].pr_code and ogm_pr_dtl.ForCP > 0) > 0 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Trxn_PRHdr(Return)" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].pr_code [ID] ")
            Query.Append("   ,[A].form_no [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].form_no [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_pr_hdr [A] ")
            Query.Append("   left join oop_form_hdr [B] on [A].form_no = [B].f_code ")
            Query.Append("where ")
            Query.Append("  [A].PurchaseType in ('Return') ")
            Query.Append("  and [B].status = 'Accepted' ")
            Query.Append("  and (select count(*) from ogm_pr_dtl where ogm_pr_dtl.pr_code = [A].pr_code and ogm_pr_dtl.ForIR > 0) > 0 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Employee(SR)" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [B].form_no [ID] ")
            Query.Append("   ,[B].form_no + ' - ' + [E].FullName [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[E].FullName [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_pr_dtl [A] ")
            Query.Append("   left join ogm_pr_hdr [B] on [A].pr_code = [B].pr_code ")
            Query.Append("   left join oop_form_hdr [C] on [B].form_no = [C].f_code ")
            Query.Append("   left join employee [E] on [C].created_by = [E].emp_no ")
            Query.Append("where ")
            Query.Append("  [C].status = 'Accepted' ")
            Query.Append("  and [A].Status = '' ")
            Query.Append("  and [A].ForSRBalance > 0 ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].IRNo [ID] ")
            Query.Append("   ,[A].IRNo + ' - ' + [D].FullName [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[D].FullName [Order2] ")
            Query.Append("from ")
            Query.Append("   IRDtl [A] ")
            Query.Append("   left join ogm_por_hdr [B] on [A].IRCode = [B].r_code ")
            Query.Append("   left join oop_form_hdr [C] on [A].PRNo = [C].f_code ")
            Query.Append("   left join employee [D] on [C].created_by = [D].emp_no ")
            Query.Append("where ")
            Query.Append("  [B].Post = 1 ")
            Query.Append("  and [B].rvrs = 0 ")
            Query.Append("  and [A].Type = 'DI' ")
            Query.Append("  and datediff(day,[B].PostedDate,getdate()) between 0 and 7 ")
            Query.Append("  and [A].ForSIBalance > 0 ")
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

#Region "ACC040000"
    Function ACC040000_Get_Record()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [SICode] ")
        Query.Append("  ,[PRNo] ")
        Query.Append("  ,[DateRequired] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("  ,[Item] ")
        Query.Append("  ,[Qty] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[Status] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      [A].SICode [SICode] ")
        Query.Append("      ,[A].PRNo [PRNo] ")
        Query.Append("      ,[B].date_required [DateRequired] ")
        Query.Append("      ,[A].PRSeqNo [SeqNo] ")
        Query.Append("      ,[A].PRItem [Item] ")
        Query.Append("      ,(select SUM(qty) from ogm_si_dtl where PRNo = [A].PRNo and PRSeqNo = [A].PRSeqNo) [Qty] ")
        Query.Append("      ,[A].PRUnit [Unit] ")
        Query.Append("      ,(select ISNULL(ReceiveStatus, 'for Receiving') from ogm_pr_dtl [DTL] where [DTL].pr_code = [C].pr_code and [DTL].seq_no = [A].PRSeqNo) [Status] ")
        Query.Append("  from ")
        Query.Append("      SIDtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].PRNo = [B].f_code ")
        Query.Append("      left join ogm_pr_hdr [C] on [A].PRNo = [C].form_no ")
        Query.Append("  where ")
        Query.Append("      [A].Post = 1 ")
        Query.Append("      AND [A].Cancelled = 0 ")
        Query.Append("      AND [B].status in ('Accepted') ")
        Query.Append("      and datediff(day,[A].PostedDate,getdate()) between 0 and 3) [TBL] ")
        Query.Append("order by ")
        Query.Append("  [DateRequired] DESC ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('" & DR("PRNo") & "', '" & DR("SeqNo") & "');return false;""><i class='las la-search fs-3'></i></button>")

                    Dim Status As New StringBuilder
                    If DR("Status") = "Prtl. Dlvrd." Then
                        Status.Append("<span class='badge badge-light-danger fs-7 ms-2'>" & DR("Status") & "</span>")
                    ElseIf DR("Status") = "for Receiving" Then
                        Status.Append("<span class='badge badge-light-info fs-7 ms-2'>" & DR("Status") & "</span>")
                    ElseIf DR("Status") = "Delivered" Then
                        Status.Append("<span class='badge badge-light-success fs-7 ms-2'>" & DR("Status") & "</span>")
                    End If

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("PRNo") & DR("SeqNo"),
                        .Action = Action.ToString,
                        .PRNo = "<span title='" & DR("PRNo") & "'>" & DR("PRNo") & "</span>",
                        .DateRequired = "<span title='" & Format(DR("DateRequired"), "MM/dd/yyyy") & "'>" & Format(DR("DateRequired"), "MM/dd/yyyy") & "</span>",
                        .SeqNo = "<span title='" & DR("SeqNo") & "'>" & DR("SeqNo") & "</span>",
                        .ItemName = "<span title='" & DR("Item") & "'>" & DR("Item") & "</span>",
                        .Qty = "<span title='" & DR("Qty") & "'>" & Format(DR("Qty"), "N2") & "</span>",
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .Status = Status.ToString
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function ACC040000_Get_Record_Redraw(pSICode, pID, pSeqNo)

        'get updated
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [SICode] ")
        Query.Append("  ,[PRNo] ")
        Query.Append("  ,[DateRequired] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("  ,[Item] ")
        Query.Append("  ,[Qty] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[Status] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      [A].SICode [SICode] ")
        Query.Append("      ,[A].PRNo [PRNo] ")
        Query.Append("      ,[B].date_required [DateRequired] ")
        Query.Append("      ,[A].PRSeqNo [SeqNo] ")
        Query.Append("      ,[A].PRItem [Item] ")
        Query.Append("      ,(select SUM(qty) from ogm_si_dtl where PRNo = [A].PRNo and PRSeqNo = [A].PRSeqNo) [Qty] ")
        Query.Append("      ,[A].PRUnit [Unit] ")
        Query.Append("      ,(select ISNULL(ReceiveStatus, 'for Receiving') from ogm_pr_dtl [DTL] where [DTL].pr_code = [C].pr_code and [DTL].seq_no = [A].PRSeqNo) [Status] ")
        Query.Append("  from ")
        Query.Append("      SIDtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].PRNo = [B].f_code ")
        Query.Append("      left join ogm_pr_hdr [C] on [A].PRNo = [C].form_no ")
        Query.Append("  where ")
        Query.Append("      [A].Post = 1 ")
        Query.Append("      AND [A].Cancelled = 0 ")
        Query.Append("      AND [B].status in ('Accepted') ) [TBL] ")
        'Query.Append("      and datediff(day,[A].PostedDate,getdate()) between 0 and 3) [TBL] ")
        Query.Append("where ")
        Query.Append("  [SICode] = '" & pSICode & "' ")
        Query.Append("  AND [PRNo] = '" & pID & "' ")
        Query.Append("  AND [SeqNo] = " & pSeqNo & " ")
        'get updated

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

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('" & DR("PRNo") & "', '" & DR("SeqNo") & "');return false;""><i class='las la-search fs-3'></i></button>")

                    Dim Status As New StringBuilder
                    If DR("Status") = "Prtl. Dlvrd." Then
                        Status.Append("<span class='badge badge-light-danger fs-7 ms-2'>" & DR("Status") & "</span>")
                    ElseIf DR("Status") = "for Receiving" Then
                        Status.Append("<span class='badge badge-light-info fs-7 ms-2'>" & DR("Status") & "</span>")
                    ElseIf DR("Status") = "Delivered" Then
                        Status.Append("<span class='badge badge-light-success fs-7 ms-2'>" & DR("Status") & "</span>")
                    End If

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("PRNo") & DR("SeqNo"),
                        .Action = Action.ToString,
                        .PRNo = "<span title='" & DR("PRNo") & "'>" & DR("PRNo") & "</span>",
                        .DateRequired = "<span title='" & Format(DR("DateRequired"), "MM/dd/yyyy") & "'>" & Format(DR("DateRequired"), "MM/dd/yyyy") & "</span>",
                        .SeqNo = "<span title='" & DR("SeqNo") & "'>" & DR("SeqNo") & "</span>",
                        .ItemName = "<span title='" & DR("Item") & "'>" & DR("Item") & "</span>",
                        .Qty = "<span title='" & DR("Qty") & "'>" & Format(DR("Qty"), "N2") & "</span>",
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .Status = Status.ToString
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    'Filter
    Function ACC040000_Get_Record_HDR(pPosted)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [SICode] ")
        Query.Append("  ,[PRNo] ")
        Query.Append("  ,[DateRequired] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("  ,[Item] ")
        Query.Append("  ,[Qty] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[Status] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      [A].SICode [SICode] ")
        Query.Append("      ,[A].PRNo [PRNo] ")
        Query.Append("      ,[B].date_required [DateRequired] ")
        Query.Append("      ,[A].PRSeqNo [SeqNo] ")
        Query.Append("      ,[A].PRItem [Item] ")
        Query.Append("      ,(select SUM(qty) from ogm_si_dtl where PRNo = [A].PRNo and PRSeqNo = [A].PRSeqNo) [Qty] ")
        Query.Append("      ,[A].PRUnit [Unit] ")
        Query.Append("      ,(select ISNULL(ReceiveStatus, 'for Receiving') from ogm_pr_dtl [DTL] where [DTL].pr_code = [C].pr_code and [DTL].seq_no = [A].PRSeqNo) [Status] ")
        Query.Append("  from ")
        Query.Append("      SIDtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].PRNo = [B].f_code ")
        Query.Append("      left join ogm_pr_hdr [C] on [A].PRNo = [C].form_no ")
        Query.Append("  where ")
        Query.Append("      [A].Post = 1 ")
        Query.Append("      AND [A].Cancelled = 0 ")
        Query.Append("      AND [B].status in ('Accepted') ")
        Query.Append("      and datediff(day,[A].PostedDate,getdate()) between 0 and 3) [TBL] ")
        Query.Append("order by ")
        Query.Append("  [DateRequired] DESC ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('" & DR("PRNo") & "', '" & DR("SeqNo") & "');return false;""><i class='las la-search fs-3'></i></button>")

                    Dim Status As New StringBuilder
                    If DR("Status") = "Prtl. Dlvrd." Then
                        Status.Append("<span class='badge badge-light-danger fs-7 ms-2'>" & DR("Status") & "</span>")
                    ElseIf DR("Status") = "for Receiving" Then
                        Status.Append("<span class='badge badge-light-info fs-7 ms-2'>" & DR("Status") & "</span>")
                    ElseIf DR("Status") = "Delivered" Then
                        Status.Append("<span class='badge badge-light-success fs-7 ms-2'>" & DR("Status") & "</span>")
                    End If

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("PRNo") & DR("SeqNo"),
                        .Action = Action.ToString,
                        .PRNo = "<span title='" & DR("PRNo") & "'>" & DR("PRNo") & "</span>",
                        .DateRequired = "<span title='" & Format(DR("DateRequired"), "MM/dd/yyyy") & "'>" & Format(DR("DateRequired"), "MM/dd/yyyy") & "</span>",
                        .SeqNo = "<span title='" & DR("SeqNo") & "'>" & DR("SeqNo") & "</span>",
                        .ItemName = "<span title='" & DR("Item") & "'>" & DR("Item") & "</span>",
                        .Qty = "<span title='" & DR("Qty") & "'>" & Format(DR("Qty"), "N2") & "</span>",
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .Status = Status.ToString
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function

    Function ACC040000_Get_Info(pID, pSeqNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].SICode ")
        Query.Append("   ,[A].SeqNo ")
        Query.Append("   ,[A].ItemName ")
        Query.Append("   ,[A].qty ")
        Query.Append("   ,[A].UMName ")
        Query.Append("   ,[A].remarks ")
        Query.Append("   ,[A].PRNo ")
        Query.Append("   ,[A].PRSeqNo ")
        Query.Append("   ,[A].PRItem ")
        Query.Append("   ,[A].PRQty ")
        Query.Append("   ,[A].PRUnit ")
        Query.Append("   ,(CASE WHEN ISNULL([A].IsReceived, 0) = 0 then 'Pending' else 'Received' end) [Status] ")
        Query.Append("from ")
        Query.Append("  SIDtl [A] ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  AND [A].Cancelled = 0 ")
        Query.Append("  AND [A].PRNo = '" & pID & "' ")
        Query.Append("  AND [A].PRSeqNo = '" & pSeqNo & "' ")
        Query.Append("order by ")
        Query.Append("  [A].SeqNo ")
        'get query

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

                    Dim Action As New StringBuilder
                    If DR("Status") = "Pending" Then
                        Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Mark as Received' onclick=""fn0101Received('" & DR("SICode") & "', '" & DR("PRNo") & "', '" & DR("PRSeqNo") & "');return false;""><i class='las la-check fs-3'></i></button>")
                    Else
                        Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                        Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-check fs-3'></i></button>")
                        Action.Append("</div>")
                    End If

                    Dim Status As New StringBuilder
                    If DR("Status") = "Pending" Then
                        Status.Append("<span class='badge badge-light-info fs-7 ms-2'>" & DR("Status") & "</span>")
                    Else
                        Status.Append("<span class='badge badge-light-success fs-7 ms-2'>" & DR("Status") & "</span>")
                    End If

                    RecordList.Add(New With {
                        .rowId = "rowID0101" & DR("SICode") & DR("SeqNo"),
                        .Action = Action.ToString,
                        .SeqNo = "<span title='" & DR("SeqNo") & "'>" & DR("SeqNo") & "</span>",
                        .ItemName = "<span title='" & DR("ItemName") & "'>" & DR("ItemName") & "</span>",
                        .Qty = "<span title='" & Format(DR("qty"), "N2") & "'>" & Format(DR("qty"), "N2") & "</span>",
                        .UMName = "<span title='" & DR("UMName") & "'>" & DR("UMName") & "</span>",
                        .Remarks = "<span title='" & DR("remarks") & "'>" & DR("remarks") & "</span>",
                        .PRNo = "<span title='" & DR("PRNo") & "'>" & DR("PRNo") & "</span>",
                        .PRItem = "<span title='" & DR("PRItem") & "'>" & DR("PRItem") & "</span>",
                        .PRSeqNo = "<span title='" & DR("PRSeqNo") & "'>" & DR("PRSeqNo") & "</span>",
                        .PRQty = "<span title='" & Format(DR("PRQty"), "N2") & "'>" & Format(DR("PRQty"), "N2") & "</span>",
                        .PRUnit = "<span title='" & DR("PRUnit") & "'>" & DR("PRUnit") & "</span>",
                        .Status = Status.ToString
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function ACC040000_Edit_Record_Info(pSICode, pID, pSeqno)

        'update query
        Dim Query As New StringBuilder
        Query.Append("UPDATE ogm_si_dtl SET ")
        Query.Append("  IsReceived = 1 ")
        Query.Append("  ,ReceivedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("  ,ReceivedDate = GETDATE() ")
        Query.Append("WHERE ")
        Query.Append("  si_code = '" & pSICode & "' ")
        Query.Append("  AND PRNo = '" & pID & "' ")
        Query.Append("  AND PRSeqNo = " & pSeqno & " ")
        Query.Append("DECLARE @PRCode nvarchar(13) = (select pr_code from ogm_pr_hdr where form_no = '" & pID & "' and Post = 1) ")
        Query.Append("IF (select SUM([A].qty) from ogm_si_dtl [A] left join ogm_si_hdr [B] on [A].si_code = [B].si_code where [A].PRNo = '" & pID & "' and [A].PRSeqNo = " & pSeqno & " and [B].Post = 1 and [B].rvrs = 0) > (select sum(qty) from ogm_si_dtl where PRNo = '" & pID & "' and PRSeqNo = " & pSeqno & " and IsReceived = 1) ")
        Query.Append("BEGIN ")
        Query.Append("  UPDATE ogm_pr_dtl SET ")
        Query.Append("      ReceiveStatus = 'Prtl. Dlvrd.' ")
        Query.Append("  WHERE ")
        Query.Append("      pr_code = @PRCode ")
        Query.Append("      AND seq_no = " & pSeqno & " ")
        Query.Append("END ")
        Query.Append("ELSE IF (select SUM([A].qty) from ogm_si_dtl [A] left join ogm_si_hdr [B] on [A].si_code = [B].si_code where [A].PRNo = '" & pID & "' and [A].PRSeqNo = " & pSeqno & " and [B].Post = 1 and [B].rvrs = 0) = (select sum(qty) from ogm_si_dtl where PRNo = '" & pID & "' and PRSeqNo = " & pSeqno & " and IsReceived = 1) ")
        Query.Append("BEGIN ")
        Query.Append("  UPDATE ogm_pr_dtl SET ")
        Query.Append("      ReceiveStatus = 'Delivered' ")
        Query.Append("  WHERE ")
        Query.Append("      pr_code = @PRCode ")
        Query.Append("      AND seq_no = " & pSeqno & " ")
        Query.Append("END ")
        Query.Append("select '" & pSICode & "' [oSICode], '" & pID & "' [oID], " & pSeqno & " [oSeqNo] ")
        'update query

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
                    RecordList.Add(New With {.oSICode = DR("oSICode"), .oID = DR("oID"), .oSeqNo = DR("oSeqNo")})
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

    Function ACC040000_Get_Info_Redraw(pSICode, pID, pSeqNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].SICode ")
        Query.Append("   ,[A].SeqNo ")
        Query.Append("   ,[A].ItemName ")
        Query.Append("   ,[A].qty ")
        Query.Append("   ,[A].UMName ")
        Query.Append("   ,[A].remarks ")
        Query.Append("   ,[A].PRNo ")
        Query.Append("   ,[A].PRSeqNo ")
        Query.Append("   ,[A].PRItem ")
        Query.Append("   ,[A].PRQty ")
        Query.Append("   ,[A].PRUnit ")
        Query.Append("   ,(CASE WHEN ISNULL([A].IsReceived, 0) = 1 then 'Received' else 'Pending' end) [Status] ")
        Query.Append("from ")
        Query.Append("  SIDtl [A] ")
        Query.Append("where ")
        Query.Append("  [A].SICode = '" & pSICode & "' ")
        Query.Append("  AND [A].PRNo = '" & pID & "' ")
        Query.Append("  AND [A].PRSeqNo = '" & pSeqNo & "' ")
        Query.Append("order by ")
        Query.Append("  [A].SeqNo ")
        'get query

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

                    Dim Action As New StringBuilder
                    If DR("Status") = "Pending" Then
                        Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Mark as Received' onclick=""fn0101Received('" & DR("SICode") & "', '" & DR("PRNo") & "', '" & DR("PRSeqNo") & "');return false;""><i class='las la-check fs-3'></i></button>")
                    Else
                        Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                        Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-check fs-3'></i></button>")
                        Action.Append("</div>")
                    End If

                    Dim Status As New StringBuilder
                    If DR("Status") = "Pending" Then
                        Status.Append("<span class='badge badge-light-info fs-7 ms-2'>" & DR("Status") & "</span>")
                    Else
                        Status.Append("<span class='badge badge-light-success fs-7 ms-2'>" & DR("Status") & "</span>")
                    End If

                    RecordList.Add(New With {
                        .rowId = "rowID0101" & DR("SICode") & DR("SeqNo"),
                        .Action = Action.ToString,
                        .SeqNo = "<span title='" & DR("SeqNo") & "'>" & DR("SeqNo") & "</span>",
                        .ItemName = "<span title='" & DR("ItemName") & "'>" & DR("ItemName") & "</span>",
                        .Qty = "<span title='" & Format(DR("qty"), "N2") & "'>" & Format(DR("qty"), "N2") & "</span>",
                        .UMName = "<span title='" & DR("UMName") & "'>" & DR("UMName") & "</span>",
                        .Remarks = "<span title='" & DR("remarks") & "'>" & DR("remarks") & "</span>",
                        .PRNo = "<span title='" & DR("PRNo") & "'>" & DR("PRNo") & "</span>",
                        .PRItem = "<span title='" & DR("PRItem") & "'>" & DR("PRItem") & "</span>",
                        .PRSeqNo = "<span title='" & DR("PRSeqNo") & "'>" & DR("PRSeqNo") & "</span>",
                        .PRQty = "<span title='" & Format(DR("PRQty"), "N2") & "'>" & Format(DR("PRQty"), "N2") & "</span>",
                        .PRUnit = "<span title='" & DR("PRUnit") & "'>" & DR("PRUnit") & "</span>",
                        .Status = Status.ToString
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
#End Region

#Region "ACC050000"
    Function ACC050000_Get_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("  [Link] ")
        Query.Append("  ,[ID] ")
        Query.Append("  ,[Title] ")
        Query.Append("  ,(case [Type] ")
        Query.Append("          when 'Closed' then '<span class=""badge badge-for-closed"">' + [Type] + '</span>' ")
        Query.Append("          when 'Cancelled' then '<span class=""badge badge-for-cancelled"">' + [Type] + '</span>' ")
        Query.Append("          when 'New' then '<span class=""badge badge-for-new"">' + [Type] + '</span>' ")
        Query.Append("          when 'For Endorsement' then '<span class=""badge badge-for-endorsement"">' + [Type] + '</span>' ")
        Query.Append("          when 'For Approval' then '<span class=""badge badge-for-approval"">' + [Type] + '</span>' ")
        Query.Append("          when 'For Implementation' then '<span class=""badge badge-for-implementation"">' + [Type] + '</span>' ")
        Query.Append("          when 'For Clarification' then '<span class=""badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("  ,Format([DateCreated],'MM/dd/yyyy') [DateCreated] ")
        Query.Append("  ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("  ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("  ,(case when [DateExpected] < cast(getdate() as date) then '<span class=""badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateExpected] = cast(getdate() as date) then '<span class=""badge badge-warning"">Due</span>' ")
        Query.Append("         when [DateExpected] > cast(getdate() as date) then '<span class=""badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("  ,[RequestedByCode] ")
        Query.Append("  ,[RequestedByName] ")
        Query.Append("  ,[POStatus] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("      ,ISNULL((select status from ogm_po_hdr where po_code = (select top 1 po_Code from ogm_po_dtl where pr_no = [A].f_code)), '') [POStatus] ")
        Query.Append("      ,ISNULL((select top 1 [C].approver from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no), '') [Approver] ")
        Query.Append("      ,[A].approver [FormApprover] ")
        Query.Append("   from ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("      left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("      left join ogm_po_dtl [E] on [A].f_code = [E].pr_no ")
        Query.Append("      left join ogm_po_hdr [F] on [E].po_code = [F].po_code ")
        Query.Append("      left join ogm_por_dtl [G] on [F].po_code = [G].po_code ")
        Query.Append("      left join ogm_por_hdr [H] on [G].r_code = [H].r_code ")
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Declined','Cancelled') ")
        Query.Append("      and [A].tbl_from = 'ogm_pr_hdr') [A] ")
        Query.Append("where ")
        Query.Append("  [POStatus] not in ('Delivered', 'Cancelled') ")
        Query.Append("  and ([FormApprover] = '" & CIIS_EmpCode & "' OR [Approver] = '" & CIIS_EmpCode & "') ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper mt-1' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View PR' onclick=""fn01View('" & DR("Link") & "'); return false;""><i class='las la-external-link-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon text-white btn-cancel' title='View PO' onclick=""fn02View('" & DR("ID") & "'); return false;"">PO</button>")
                    Action.Append("      <button class='btn btn-sm btn-icon text-white btn-cancel' title='View IR' onclick=""fn03View('" & DR("ID") & "');  return false;"">IR</button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .Action = Action.ToString(),
                        .ID = DR("ID"),
                        .Title = DR("Title"),
                        .Type = DR("Type"),
                        .DateCreated = DR("DateCreated"),
                        .DateExpected = DR("DateExpected"),
                        .FormStatus = DR("Status"),
                        .RequestedBy = DR("RequestedByName"),
                        .POStatus = DR("POStatus")
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
    Function ACC050000_Get_PO_Record(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  PONo ")
        Query.Append("  ,POCode ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,ChangeQTY ")
        Query.Append("  ,ChangeItem ")
        Query.Append("  ,ItemCode ")
        Query.Append("  ,ItemName ")
        Query.Append("  ,Spec ")
        Query.Append("  ,qty AS Qty ")
        Query.Append("  ,UMCode ")
        Query.Append("  ,UMName ")
        Query.Append("  ,Cost ")
        Query.Append("  ,Total ")
        Query.Append("  ,OSMCode ")
        Query.Append("  ,Remarks ")
        Query.Append("  ,PRNo ")
        Query.Append("  ,PRSeqNo ")
        Query.Append("  ,PRItem ")
        Query.Append("  ,PRQty ")
        Query.Append("  ,PRUnit ")
        Query.Append("  ,CreateBy ")
        Query.Append("  ,CreateDate ")
        Query.Append("  ,UpdateBy ")
        Query.Append("  ,UpdateDate ")
        Query.Append("  ,ICCode ")
        Query.Append("  ,Classification ")
        Query.Append("  ,Commodity ")
        Query.Append("from ")
        Query.Append("  PODtl ")
        Query.Append("where ")
        Query.Append("  PRNo = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("  SeqNo ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn02ViewPO('" & DR("POCode") & "');return false;""><i class='las la-search fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("POCode") & DR("SeqNo"),
                        .Action = Action.ToString(),
                        .PONo = DR("PONo"),
                        .ChangeItem = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("ChangeItem") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ChangeQty = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("ChangeQTY") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ItemName = DR("ItemName"),
                        .ItemCode = DR("ItemCode"),
                        .Qty = DR("Qty"),
                        .UMCode = DR("UMCode"),
                        .UMName = DR("UMName"),
                        .Cost = DR("Cost"),
                        .Total = DR("Total"),
                        .OSMCode = DR("OSMCode"),
                        .Remarks = DR("Remarks"),
                        .PRNo = DR("PRNo"),
                        .PRSeqNo = DR("PRSeqNo"),
                        .PRItem = DR("PRItem"),
                        .PRQty = DR("PRQty"),
                        .PRUnit = DR("PRUnit"),
                        .ICCode = DR("ICCode"),
                        .Classification = DR("Classification"),
                        .Commodity = DR("Commodity"),
                        .SeqNo = DR("SeqNo")
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
    Function ACC050000_Get_IR_Record(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  POCode ")
        Query.Append("  ,PRNo ")
        Query.Append("  ,IRNo ")
        Query.Append("  ,PRSeqNo ")
        Query.Append("  ,PONo ")
        Query.Append("  ,POSeqNo ")
        Query.Append("  ,IRCode ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,SIDRNo ")
        Query.Append("  ,Type ")
        Query.Append("  ,ItemCode ")
        Query.Append("  ,ItemName ")
        Query.Append("  ,Qty ")
        Query.Append("  ,UMCode ")
        Query.Append("  ,UMInit ")
        Query.Append("  ,Cost ")
        Query.Append("  ,Total ")
        Query.Append("  ,remarks ")
        Query.Append("  ,CreatedBy ")
        Query.Append("  ,createdDate ")
        Query.Append("  ,UpdatedBy ")
        Query.Append("  ,UpdatedDate ")
        Query.Append("  ,WT ")
        Query.Append("from ")
        Query.Append("  IRDtl ")
        Query.Append("where ")
        Query.Append("  PRNo = '" & pID & "' ")
        'get query

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
                    '.PRNo = "<span class='text-primary pointer' onclick=""fn010101_SCM03RPT01('" & DR("PRNo") & "'); return false;"">" & DR("PRNo") & "</span>",

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn03ViewIR('" & DR("IRCode") & "');return false;""><i class='las la-search fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("IRCode") & DR("SeqNo"),
                        .Action = Action.ToString(),
                        .PRNo = DR("PRNo"),
                        .IRNo = DR("IRNo"),
                        .PONo = DR("PONo"),
                        .PRSeqNo = DR("PRSeqNo"),
                        .POSeqNo = DR("POSeqNo"),
                        .IRCode = DR("IRCode"),
                        .SeqNo = DR("SeqNo"),
                        .SIDRNo = DR("SIDRNo"),
                        .Type = DR("Type"),
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .UMCode = DR("UMCode"),
                        .UMInit = DR("UMInit"),
                        .Cost = DR("Cost"),
                        .Total = DR("Total"),
                        .Remarks = DR("Remarks"),
                        .POCode = DR("POCode")
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

#Region "ACC060000"
    Function ACC060000_Get_Record(pItem, pDate, pWarehouse)

        Dim vDate As Date = IIf(pDate = "", Date.Now, pDate)

        'get query
        Dim Query As New StringBuilder
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
        If pItem <> "" Then Query.Append("  and ItemCode = @ItemCode ")
        If pWarehouse <> "" Then Query.Append("  and WhseCode = @WhseCode ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Date", vDate)
                Cmd.Parameters.AddWithValue("@Year", Year(vDate))
                Cmd.Parameters.AddWithValue("@Period", Month(vDate))
                Cmd.Parameters.AddWithValue("@ItemCode", pItem)
                Cmd.Parameters.AddWithValue("@WhseCode", pWarehouse)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Action = "",
                        .WhseCode = DR("WhseCode"),
                        .WhseName = DR("WhseName"),
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
        'read record

        'display 
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display

    End Function
    Function ACC060000_Get_Record_Item(pWarehouse)

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
        Query.Append("  and [A].warehouse = '" & pWarehouse & "' ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select Item' onclick=""fn01GetItem('" & DR("item") & "', '" & DR("i_code") & "', '" & DR("Lock") & "');return false;""><i class='las la-check fs-3'></i></button>")

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
#End Region

End Class