Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Pipes
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net.PeerToPeer.Collaboration
Imports System.Reflection.Emit
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Principal
Imports System.Web
Imports System.Web.ApplicationServices
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Windows.Forms
Imports System.Windows.Forms.LinkLabel
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft
Imports Microsoft.Ajax.Utilities
Imports Microsoft.AspNet.SignalR.Infrastructure
Imports Microsoft.Identity.Client
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports OfficeOpenXml.ConditionalFormatting.Contracts


Public Class FRM000010HND
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
    Dim calmardblive As String = "calmardblive"
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim pFunction = context.Request("pFunction")
            Dim pFormCode = context.Request("pFormCode")
            Dim pType = context.Request("pType")
            Dim json As String
            'general parameter

            If pFunction = "Dropdown" And pType = "Get - Dropdown" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                json = Me.Get_Dropdown(pTblName, pPlaceHolder)

            ElseIf pFunction = "Dropdown" And pType = "Get - Dropdown - Filter" Then

                Dim pFilter = context.Request("pFilter")
                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                json = Me.Get_Dropdown_Filter(pFilter, pTblName, pPlaceHolder)

            End If

            If pFormCode = "FRM000010" And pType = "Validate - Record" Then

                Dim pID = context.Request("pID")
                Dim pValue01 = context.Request("pValue01")
                Dim pValue02 = context.Request("pValue02")
                Dim pGroup = context.Request("pGroup")
                Dim pFType = context.Request("pFType")
                json = Me.Validate_Record(pID, pValue01, pValue02, pGroup, pFType)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Record" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Record(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Find - Record" Then

                json = Me.Find_Record()

            ElseIf pFormCode = "FRM000010" And pType = "Get - Employee" Then

                Dim pEmpCode = CIIS_EmpCode
                json = Me.Get_Employee(pEmpCode)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Division" Then

                Dim pEmpCode = CIIS_EmpCode
                json = Me.Get_Division(pEmpCode)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Department" Then

                Dim pEmpCode = CIIS_EmpCode
                json = Me.Get_Department(pEmpCode)

            ElseIf pFormCode = "FRM000010" And pType = "Get - GL Account" Then

                Dim pPurpose = context.Request("pPurpose")
                Dim pEmpCode = CIIS_EmpCode
                json = Me.Get_GLAccount(pPurpose, pEmpCode)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Batch" Then

                Dim pProjType = context.Request("pProjType")
                Dim pSubdCode = context.Request("pSubdCode")
                Dim pCategory = context.Request("pCategory")
                Dim pEmpCode = CIIS_EmpCode
                json = Me.Get_Batch(pProjType, pSubdCode, pCategory, pEmpCode)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Estimate" Then

                Dim pSubdCode = context.Request("pSubdCode")
                Dim pCategory = context.Request("pCategory")
                Dim pEmpCode = CIIS_EmpCode
                json = Me.Get_Estimate(pSubdCode, pCategory, pEmpCode)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Charging" Then

                Dim pTblFrom = context.Request("pTblFrom")
                Dim pCode1 = context.Request("pCode1")
                Dim pCode2 = context.Request("pCode2")
                Dim pCode3 = context.Request("pCode3")
                Dim pCode4 = context.Request("pCode4")
                Dim pCode5 = context.Request("pCode5")
                json = Me.Get_Charging(pTblFrom, pCode1, pCode2, pCode3, pCode4, pCode5)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Record" Then

                Dim pDateRequired = context.Request("pDateRequired")
                Dim pPurchaseType = context.Request("pPurchaseType")
                Dim pDeptCode = context.Request("pDeptCode")
                Dim pProjType = context.Request("pProjType")
                Dim pPurpose = context.Request("pPurpose")
                Dim pSubdCode = context.Request("pSubdCode")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pCarCode = context.Request("pCarCode")
                Dim pCategory = context.Request("pCategory")
                Dim pActName = context.Request("pActName")
                Dim pActLocation = context.Request("pActLocation")
                Dim pActDate = context.Request("pActDate")
                Dim pChargeCode = context.Request("pChargeCode")
                Dim pAcctCode = context.Request("pAcctCode")
                Dim pDivision = context.Request("pDivision")
                Dim pCECode = context.Request("pCECode")
                Dim pMisc = context.Request("pMisc")
                Dim pRemarks = context.Request("pRemarks")
                Dim pCreatedBy = CIIS_EmpCode
                json = Me.Add_Record(pDateRequired, pPurchaseType, pDeptCode, pProjType, pPurpose, pSubdCode, pPhase, pBlock, pLot, pCarCode, pCategory, pActName, pActLocation, pActDate, pChargeCode, pAcctCode, pDivision, pCECode, pMisc, pRemarks, pCreatedBy)

            End If

            'general - context
            context.Response.ContentType = "application/json"
            context.Response.Write(json)
            'general - context

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#Region "Validate"
    Function Validate_Record(pID, pValue01, pValue02, pGroup, pFType)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable


        If pGroup = "04ApprovalPath" Then

            'get total task
            If pFType = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Clarification') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue01 & ") in ('Approved') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Save(ReasonForDelay)" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & CIIS_EmpCode & "' not in (select approver from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue01 & " ) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Up" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue01 & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Down" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue01 & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

        If pGroup = "03Subscribers" Then

            'get total task
            If pFType = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

        If pGroup = "02Files" Then

            'get total task
            If pFType = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

        If pGroup = "01Overview" Then

            'get total task
            If pFType = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') not in ('New','Requested') ")
                Query.Append("begin ")
                Query.Append("   select 'Record cannot be deleted!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Record cannot be deleted!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') not in ('New','Requested') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by,'2010000030') then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Status" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by,approver) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & pValue01 & "' in ('Approved','Clarify') and (select (case when '" + CIIS_EmpCode + "' not in (approver) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

        'variable
        Dim RecordList As New List(Of Object)()
        'variable
        Dim rowIndex As Integer = 0
        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                         .Msg = DR.GetString(0)
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
#End Region

#Region "Dropdown"
    Function Get_Dropdown(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Get_Department" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].dept_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   department [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].lock, 0) = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Purpose" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].Type + ' - ' + [A].Purpose [ID] ")
            Query.Append("   ,[A].Type + ' - ' + [A].Purpose [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Type + ' - ' + [A].Purpose [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_PurposeType [A] ")
            Query.Append("where ")
            Query.Append("   ISNULL([A].AcctCode, '') <> '' ")
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
            Query.Append("   Parm_CECategory [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].Lock, 0) = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Vehicle" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].CarCode [ID] ")
            Query.Append("   ,[A].PlateNo + ' - ' + [A].CarModel [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].PlateNo + ' - ' + [A].CarModel [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_Vehicle [A] ")
            Query.Append("where ")
            Query.Append("  [A].PlateNo not in ('NA','Others') ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Get_Subdivision" Then
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
    Function Get_Dropdown_Filter(pFilter, pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Get_Purpose" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].Type + ' - ' + [A].Purpose [ID] ")
            Query.Append("   ,[A].Type + ' - ' + [A].Purpose [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Type + ' - ' + [A].Purpose [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_PurposeType [A] ")
            Query.Append("where ")
            Query.Append("   ISNULL([A].AcctCode, '') <> '' ")
            Query.Append("   and [A].ProjectType = @pFilter ")
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
                Cmd.Parameters.AddWithValue("@pFilter", pFilter)
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

#Region "Record"
    Function Get_Record(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].f_code ")
        Query.Append("  ,FORMAT([A].created_date, 'MM/dd/yyyy') [DateCreated] ")
        Query.Append("  ,FORMAT([A].date_required, 'MM/dd/yyyy') [DateRequired] ")
        Query.Append("  ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
        Query.Append("  ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [Approver] ")
        Query.Append("  ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
        Query.Append("  ,isnull([A].status, 'New') [Status] ")
        Query.Append("  ,isnull([A].FormTitle, '') [FormTitle] ")
        Query.Append("  ,[B].PurchaseType ")
        Query.Append("  ,[B].justification [ProjType] ")
        Query.Append("  ,[B].Purpose ")
        Query.Append("  ,ISNULL(FORMAT([B].DateReturn, 'MM/dd/yyyy'),'') [DateReturn] ")
        Query.Append("  ,ISNULL(FORMAT([B].DateIssue, 'MM/dd/yyyy'),'') [DateIssue] ")
        Query.Append("  ,isnull([F].abbr + ' ' + [G].description + ' B' + [H].block + ' L' + [I].lot,'') [Project] ")
        Query.Append("  ,isnull([F].description, '') [SubdName] ")
        Query.Append("  ,isnull([F].abbr, '') [SubdAbbr] ")
        Query.Append("  ,[B].Subdivision [SubdCode] ")
        Query.Append("  ,[G].description [PhaseName] ")
        Query.Append("  ,[B].Phase [PhaseCode] ")
        Query.Append("  ,[H].block [BlockName] ")
        Query.Append("  ,[B].Block [BlockCode] ")
        Query.Append("  ,[I].lot [LotName] ")
        Query.Append("  ,[B].Lot [LotCode] ")
        Query.Append("  ,[M].CarCode + ' - ' + [M].PlateNo [VehicleName] ")
        Query.Append("  ,[B].PlateNo [VehiclePlate] ")
        Query.Append("  ,[B].Type ")
        Query.Append("  ,[B].Category ")
        Query.Append("  ,[B].ActName ")
        Query.Append("  ,[B].ActLocation ")
        Query.Append("  ,isnull(format([B].ActDate, 'MM/dd/yyyy'), '') [ActDate] ")
        Query.Append("  ,[B].remarks [Remarks] ")
        Query.Append("  ,isnull([B].CECode, '') [CECode] ")
        Query.Append("  ,isnull([J].Title, '') [EstTitle] ")
        Query.Append("  ,isnull([B].AcctCode, '') [AcctCode] ")
        Query.Append("  ,ISNULL([K].description, '') [DivName] ")
        Query.Append("  ,[B].Division [DivCode] ")
        Query.Append("  ,ISNULL([L].description, '') [DeptName] ")
        Query.Append("  ,[B].department [DeptCode] ")
        Query.Append("  ,ISNULL((CASE WHEN [B].Misc = 'MISCELLANEOUS' THEN (select description from sub_misc where account = [B].AcctCode and code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'MODEL HOUSE' THEN (select description from sub_house where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'NO SUBSIDIARY' THEN ISNULL((select Description from Mstr_PurposeType where Type + ' - ' + Purpose = [B].Purpose and AcctCode = [B].AcctCode), '') ")
        Query.Append("                WHEN [B].Misc = 'SUBDIVISION' THEN (select description from sub_subdivision where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'PHASE' THEN (select description from sub_phase where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'VENDOR' THEN (select description from sub_vendor where code = [B].ChargeCode) ")
        Query.Append("  ELSE '' END), '') [ChargeName] ")
        Query.Append("  ,isnull([B].ChargeCode, '') [ChargeCode] ")
        Query.Append("  ,isnull([B].Misc, '') [Misc] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join ogm_pr_hdr [B] on [A].tbl_code = [B].pr_code and [A].tbl_from = 'ogm_pr_hdr' ")
        Query.Append("  left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("  left join employee [D] on [A].approver = [D].emp_no ")
        Query.Append("  left join employee [E] on [A].EndorsedTo = [E].emp_no ")
        Query.Append("  left join subdivision [F] on [B].Subdivision = [F].code ")
        Query.Append("  left join phase [G] on [B].Phase = [G].code ")
        Query.Append("  left join eng_block [H] on [B].Block = [H].b_code ")
        Query.Append("  left join eng_lot [I] on [B].lot = [I].l_code ")
        Query.Append("  left join Trxn_CEHdr [J] on [B].CECode = [J].CECode ")
        Query.Append("  left join division [K] on [B].Division = [K].div_code ")
        Query.Append("  left join department [L] on [B].department = [L].dept_code ")
        Query.Append("  left join Mstr_Vehicle [M] on [B].Vehicle + ' - ' + [B].PlateNo = [M].CarModel + ' - ' + [M].PlateNo ")
        Query.Append("where ")
        Query.Append("  [A].f_code = @pID ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .FormNo = DR("f_code"),
                        .FormType = "Price Inquiry",
                        .DateCreated = DR("DateCreated"),
                        .DateRequired = DR("DateRequired"),
                        .RequestedBy = DR("RequestedBy"),
                        .Approver = DR("Approver"),
                        .EndorsedTo = DR("EndorsedTo"),
                        .Status = DR("Status"),
                        .FormTitle = DR("FormTitle"),
                        .PurchaseType = DR("PurchaseType"),
                        .ProjType = DR("ProjType"),
                        .Purpose = DR("Purpose"),
                        .DateReturn = DR("DateReturn"),
                        .DateIssue = DR("DateIssue"),
                        .Project = DR("Project"),
                        .SubdName = DR("SubdName"),
                        .SubdAbbr = DR("SubdAbbr"),
                        .SubdCode = DR("SubdCode"),
                        .PhaseName = DR("PhaseName"),
                        .PhaseCode = DR("PhaseCode"),
                        .BlockName = DR("BlockName"),
                        .BlockCode = DR("BlockCode"),
                        .LotName = DR("LotName"),
                        .LotCode = DR("LotCode"),
                        .VehicleName = DR("VehicleName"),
                        .VehiclePlate = DR("VehiclePlate"),
                        .Type = DR("Type"),
                        .Category = DR("Category"),
                        .ActName = DR("ActName"),
                        .ActLocation = DR("ActLocation"),
                        .ActDate = DR("ActDate"),
                        .Remarks = DR("Remarks"),
                        .CECode = DR("CECode"),
                        .EstTitle = DR("EstTitle"),
                        .AcctCode = DR("AcctCode"),
                        .DivName = DR("DivName"),
                        .DivCode = DR("DivCode"),
                        .DeptName = DR("DeptName"),
                        .DeptCode = DR("DeptCode"),
                        .ChargeName = DR("ChargeName"),
                        .ChargeCode = DR("ChargeCode"),
                        .Misc = DR("Misc")
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
    Function Find_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_PIHdr' ")
        Query.Append("      and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_PIHdr' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_dtl_monitor [M] ")
        Query.Append("	    left join oop_form_hdr [A] on [M].f_code = [A].f_code ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_PIHdr' ")
        Query.Append("      and [M].monitored_by = '" & CIIS_EmpCode & "') [A] ")
        Query.Append("order by ")
        Query.Append("   [ID] ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable
        Dim rowIndex As Integer = 0
        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Name As String = DR("Name")
                    Dim d As Date = DR("Date")
                    Dim t As Date = Date.Today
                    Dim Date_ As String =
                    If(d.Date = t, "Today",
                    If(d.Year < t.Year, Format(d, "MMM d, yyyy"),
                    If(d.Month = t.Month And d.Year = t.Year, Format(d, "MMM d"),
                    "On " & Format(d, "MMM d"))))
                    'Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble
                    Dim Bullet As New StringBuilder
                    Bullet.Append("<div class='h-100'><span class='" & DR("Bullet") & "'></span></div>")
                    Dim Data As New StringBuilder
                    Data.Append("<a href='" & DR("Link") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("       <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("           <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("       </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>" & DR("ID") & " " & DR("Name") & " " & Date_ & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")
                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString
                    })


                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Get_Employee(pEmpCode)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	(case when isnull(dbo.ProperCase([E].first_name) + ' ' +  ")
        Query.Append("	dbo.ProperCase([E].last_name),'') = '' then '-' else  ")
        Query.Append("	isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [Name]  ")
        Query.Append("from  ")
        Query.Append("	employee [E] ")
        Query.Append("where ")
        Query.Append("	emp_no = @pEmpCode ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                    .EmpName = If(IsDBNull(DR("Name")), "", DR("Name"))
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
    Function Get_Division(pEmpCode)

        'get division
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [c].div_code [DivCode] ")
        Query.Append("  ,[c].description [DivName] ")
        Query.Append("from ")
        Query.Append("  employee [a] ")
        Query.Append("  left join business [b] on [a].buss_code = [b].buss_code ")
        Query.Append("  left join division [c] on [b].div_code = [c].div_code ")
        Query.Append("where ")
        Query.Append("  [a].emp_no = @pEmpCode ")
        'get division

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .DivName = DR("DivName"),
                        .DivCode = DR("DivCode")
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
    Function Get_Department(pEmpCode)

        'get department
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [a].dept_code [DeptCode] ")
        Query.Append("  ,[b].description [DeptName] ")
        Query.Append("from ")
        Query.Append("  employee [a] ")
        Query.Append("  left join department [b] on [a].dept_code = [b].dept_code ")
        Query.Append("where ")
        Query.Append("  [a].emp_no = @pEmpCode ")
        'get department

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .DeptName = DR("DeptName"),
                        .DeptCode = DR("DeptCode")
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
    Function Get_GLAccount(pPurpose, pEmpCode)

        'get account
        Dim Query As New StringBuilder
        Query.Append("declare @pDeptCode nvarchar(13) = ISNULL((select dept_code from employee where emp_no = @pEmpCode), '') ")
        Query.Append("declare @pBussCode nvarchar(13) = ISNULL((select buss_code from employee where emp_no = @pEmpCode), '') ")
        Query.Append("declare @pDivCode nvarchar(13) = ISNULL((select div_code from business where buss_code = @pBussCode), '') ")
        Query.Append("select ")
        Query.Append("  ISNULL(AcctCode, '') [AcctCode] ")
        Query.Append("  ,(CASE WHEN ISNULL(DivCode, '') = '' THEN @pDivCode ELSE ISNULL(DivCode, '') END) [DivCode] ")
        Query.Append("  ,isnull((select description from division where div_code = (CASE WHEN ISNULL(DivCode, '') = '' THEN @pDivCode ELSE ISNULL(DivCode, '') END)), '') [DivName] ")
        Query.Append("  ,(CASE WHEN ISNULL(DeptCode, '') = '' THEN @pDeptCode ELSE ISNULL(DeptCode, '') END) [DeptCode] ")
        Query.Append("  ,isnull((select description from department where dept_code = (CASE WHEN ISNULL(DeptCode, '') = '' THEN @pDeptCode ELSE ISNULL(DeptCode, '') END)), '') [DeptName] ")
        Query.Append("  ,ISNULL(Subsidiary, '') [Subsidiary] ")
        Query.Append("  ,ISNULL(ChargeCode, '') [ChargeCode] ")
        Query.Append("  ,ISNULL(Description, '') [Description] ")
        Query.Append("from ")
        Query.Append("  Mstr_PurposeType ")
        Query.Append("where ")
        Query.Append("  Type + ' - ' + Purpose = @pPurpose ")
        'get account

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pPurpose", pPurpose)
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .AcctCode = DR("AcctCode"),
                        .DivName = DR("DivName"),
                        .DivCode = DR("DivCode"),
                        .DeptCode = DR("DeptCode"),
                        .DeptName = DR("DeptName"),
                        .Subsidiary = DR("Subsidiary"),
                        .ChargeCode = DR("ChargeCode"),
                        .Description = DR("Description")
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
    Function Get_Batch(pProjType, pSubdCode, pCategory, pEmpCode)

        'get batch
        Dim Query As New StringBuilder
        Query.Append("declare @pDeptCode nvarchar(13) = ISNULL((select dept_code from employee where emp_no = @pEmpCode), '') ")
        Query.Append("declare @pBussCode nvarchar(13) = ISNULL((select buss_code from employee where emp_no = @pEmpCode), '') ")
        Query.Append("declare @pDivCode nvarchar(13) = ISNULL((select div_code from business where buss_code = @pBussCode), '') ")
        Query.Append("declare @pDivName nvarchar(60) = ISNULL((select description from division where div_code = @pDivCode), '') ")
        If pProjType = "OSM Project (Advance PO)" Or pProjType = "CCI Project (Advance PO)" Then
            Query.Append("select distinct ")
            Query.Append("  (CASE WHEN [A].BatchNo IS NULL OR [A].BatchNo = '' OR [A].BatchNo = '-' THEN [A].CECode ELSE [A].BatchNo END) [Batch] ")
            Query.Append("  ,(CASE WHEN [A].BatchNo IS NULL OR [A].BatchNo = '' OR [A].BatchNo = '-' THEN [A].BatchNo ELSE [A].BatchNo + ' - ' + (select top 1 subdivision.description from subdivision where subdivision.code = @pSubdCode ) END) [Project]  ")
            Query.Append("  ,ISNULL([C].div_code, @pDivCode) [DivCode] ")
            Query.Append("  ,ISNULL([C].description, @pDivName) [DivName] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl_PO [A] ")
            Query.Append("  left join subdivision [B] on [A].Project = [B].Code ")
            Query.Append("  left join division [C] on [B].division = [C].div_code ")
            Query.Append("where ")
            Query.Append("  [A].Project = @pSubdCode ")
            Query.Append("  and [A].Category = 'House Construction' ")
        Else
            Query.Append("select distinct ")
            Query.Append("  (CASE WHEN [A].Batch IS NULL OR [A].Batch = '' OR [A].Batch = '-' THEN [A].CECode ELSE [A].Batch END) [Batch] ")
            Query.Append("  ,(CASE WHEN [A].Batch IS NULL OR [A].Batch = '' OR [A].Batch = '-' THEN [A].Title ELSE [A].Batch + ' - ' + (select top 1 subdivision.description from subdivision where subdivision.code = @pSubdCode or subdivision.code = @pSubdCode) END) [Project] ")
            Query.Append("  ,ISNULL([D].div_code, @pDivCode) [DivCode] ")
            Query.Append("  ,ISNULL([D].description, @pDivName) [DivName] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEHdr [A] ")
            Query.Append("  left join eng_lot [B] on [A].Subdivision = [B].l_code ")
            Query.Append("  left join subdivision [C] on (CASE WHEN [B].s_code IS NULL THEN [A].SubdCode ELSE [B].s_code END) = [C].Code ")
            Query.Append("  left join division [D] on [C].division = [D].div_code ")
            Query.Append("where ")
            Query.Append("  [A].Post = 1 ")
            Query.Append("  and [A].Rvrs = 0 ")
            Query.Append("  and ([A].Subdivision = @pSubdCode OR [A].SubdCode = @pSubdCode) ")
            Query.Append("  and [A].Category = @pCategory ")
        End If
        'get batch

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pSubdCode", pSubdCode)
                Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view mt-1' title='Select' onclick=""fn0101AddEstimate('" & DR("Batch") & "', '" & DR("Project") & "', '" & DR("DivCode") & "', '" & DR("DivName") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    Dim Title As String = "Batch - Transaction"

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Batch = DR("Batch"),
                        .Project = DR("Project"),
                        .Title = Title
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function
    Function Get_Estimate(pSubdCode, pCategory, pEmpCode)

        'get estimate
        Dim Query As New StringBuilder
        Query.Append("declare @pDeptCode nvarchar(13) = ISNULL((select dept_code from employee where emp_no = @pEmpCode), '') ")
        Query.Append("declare @pBussCode nvarchar(13) = ISNULL((select buss_code from employee where emp_no = @pEmpCode), '') ")
        Query.Append("declare @pDivCode nvarchar(13) = ISNULL((select div_code from business where buss_code = @pBussCode), '') ")
        Query.Append("declare @pDivName nvarchar(60) = ISNULL((select description from division where div_code = @pDivCode), '') ")
        Query.Append("select distinct ")
        Query.Append("  (CASE WHEN [A].Batch IS NULL OR [A].Batch = '' OR [A].Batch = '-' THEN [A].CECode ELSE [A].Batch END) [Batch] ")
        Query.Append("  ,[A].Title [Project] ")
        Query.Append("  ,[A].CECode ")
        Query.Append("  ,ISNULL([D].div_code, @pDivCode) [DivCode]  ")
        Query.Append("  ,ISNULL([D].description, @pDivName) [DivName]  ")
        Query.Append("from ")
        Query.Append("  Trxn_CEHdr [A] ")
        Query.Append("  left join eng_lot [B] on [A].Subdivision = [B].l_code ")
        Query.Append("  left join subdivision [C] on (CASE WHEN [B].s_code IS NULL THEN [A].SubdCode ELSE [B].s_code END) = [C].Code ")
        Query.Append("  left join division [D] on [C].division = [D].div_code ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  and [A].Rvrs = 0 ")
        Query.Append("  and [A].Category = @pCategory ")
        If pSubdCode <> "" Then
            Query.Append("  and ([A].Subdivision = @pSubdCode OR [A].SubdCode = @pSubdCode) ")
        End If
        'get estimate

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pSubdCode", pSubdCode)
                Cmd.Parameters.AddWithValue("@pCategory", pCategory)
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view mt-1' title='Select' onclick=""fn0101AddEstimate('" & DR("CECode") & "', '" & DR("Project") & "', '" & DR("DivCode") & "', '" & DR("DivName") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    Dim Title As String = "Estimate - Transaction"

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Batch = DR("Batch"),
                        .Project = DR("Project"),
                        .Title = Title
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 
    End Function
    Function Get_Charging(pTblFrom, pCode1, pCode2, pCode3, pCode4, pCode5)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("Get_RcrdList_PRChargeTo")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pTblFrom", pTblFrom)
                Cmd.Parameters.AddWithValue("@pCode1", pCode1)
                Cmd.Parameters.AddWithValue("@pCode2", pCode2)
                Cmd.Parameters.AddWithValue("@pCode3", pCode3)
                Cmd.Parameters.AddWithValue("@pCode4", pCode4)
                Cmd.Parameters.AddWithValue("@pCode5", pCode5)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view mt-1' title='Select' onclick=""fn0101AddChargeTo('" & DR("Code") & "', '" & DR("Description") & "','" & DR("Lock") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Code = DR("code"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center mt-3'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = DR("description")
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

#Region "CRUD - Record"
    Function Add_Record(pDateRequired, pPurchaseType, pDeptCode, pProjType, pPurpose, pSubdCode, pPhase, pBlock, pLot, pCarCode, pCategory, pActName, pActLocation, pActDate, pChargeCode, pAcctCode, pDivision, pCECode, pMisc, pRemarks, pCreatedBy)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_FRM000010"
        SqlCmd.Parameters.AddWithValue("@pDateRequired", pDateRequired)
        SqlCmd.Parameters.AddWithValue("@pPurchaseType", pPurchaseType)
        SqlCmd.Parameters.AddWithValue("@pDeptCode", pDeptCode)
        SqlCmd.Parameters.AddWithValue("@pProjType", pProjType)
        SqlCmd.Parameters.AddWithValue("@pPurpose", pPurpose)
        SqlCmd.Parameters.AddWithValue("@pSubdCode", pSubdCode)
        SqlCmd.Parameters.AddWithValue("@pPhase", pPhase)
        SqlCmd.Parameters.AddWithValue("@pBlock", pBlock)
        SqlCmd.Parameters.AddWithValue("@pLot", pLot)
        SqlCmd.Parameters.AddWithValue("@pCarCode", pCarCode)
        SqlCmd.Parameters.AddWithValue("@pCategory", pCategory)
        SqlCmd.Parameters.AddWithValue("@pActName", pActName)
        SqlCmd.Parameters.AddWithValue("@pActLocation", pActLocation)
        SqlCmd.Parameters.AddWithValue("@pActDate", pActDate)
        SqlCmd.Parameters.AddWithValue("@pCECode", pCECode)
        SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
        SqlCmd.Parameters.AddWithValue("@pChargeCode", pChargeCode)
        SqlCmd.Parameters.AddWithValue("@pAcctCode", pAcctCode)
        SqlCmd.Parameters.AddWithValue("@pMisc", pMisc)
        SqlCmd.Parameters.AddWithValue("@pDivCode", pDivision)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        Dim oFCode As New SqlClient.SqlParameter("@oFCode", SqlDbType.NVarChar, 1000)
        oFCode.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oFCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oFCode = oFCode.Value.ToString
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
#End Region

End Class