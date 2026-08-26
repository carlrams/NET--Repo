Imports System.ComponentModel.Design
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
Imports System.Runtime.Remoting.Contexts
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

            ElseIf pFunction = "Dropdown" And pType = "Get - Dropdown - List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                Dim pVal01 = context.Request("pVal01")
                Dim pVal02 = context.Request("pVal02")
                json = Me.Get_Dropdown_List(pTblName, pPlaceHolder, pVal01, pVal02)

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

            ElseIf pFormCode = "FRM000010" And pType = "Get - Estimate Charging" Then

                Dim pCode = context.Request("pCode")
                json = Me.Get_EstimateCode(pCode)

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

            ElseIf pFormCode = "FRM000010" And pType = "Get - Project" Then

                json = Me.Get_Project()

            ElseIf pFormCode = "FRM000010" And pType = "Get - Particular - SCM (Batch)" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Particular_SCM_Batch(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Particular - SCM (Estimate)" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Particular_SCM_Estimate(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Particular - OSM (Batch)" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Particular_OSM_Batch(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Particular - OSM (Estimate)" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Particular_OSM_Estimate(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Get - OSM Record (Batch)" Then

                Dim pID = context.Request("pID")
                json = Me.Get_OSM_Batch(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Get - OSM Record (Estimate)" Then

                Dim pID = context.Request("pID")
                json = Me.Get_OSM_Estimate(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Particular (Update)" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                json = Me.Get_Particular_Update(pID, pSeqNo)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Tagging Units" Then

                Dim pID = context.Request("pID")
                Dim pItemNo = context.Request("pItemNo")
                json = Me.Get_Tagging_Units(pID, pItemNo)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Tagged Units" Then

                Dim pID = context.Request("pID")
                Dim pItemNo = context.Request("pItemNo")
                json = Me.Get_Tagged_Units(pID, pItemNo)

            ElseIf pFormCode = "FRM000010" And pType = "View - PR Printout" Then

                Dim pID = context.Request("pID")
                Dim pEmpNo = CIIS_EmpCode
                json = Me.View_PR_Printout(pID, pEmpNo, context)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Record (Return)" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Record_Return(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Approval Path" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Approval_Path(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Update - Record Approver" Then

                Dim pID = context.Request("pID")
                Dim pStatus = context.Request("pStatus")
                Dim pAssignTo = context.Request("pAssignTo")
                Dim pRemarks = context.Request("pRemarks")
                Dim pMention = context.Request("pMention")
                json = Me.Update_Record_Approver(pFormCode, pID, pStatus, pAssignTo, pRemarks, pMention)

            ElseIf pFormCode = "FRM000010" And pType = "Delete - Record Approver" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                json = Me.Delete_Record_Approver(pFormCode, pID, pSeqNo)

            ElseIf pFormCode = "FRM000010" And pType = "Move - Up Record Approver" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                json = Me.Move_Up_Record_Approver(pFormCode, pID, pSeqNo)

            ElseIf pFormCode = "FRM000010" And pType = "Move - Down Record Approver" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                json = Me.Move_Down_Record_Approver(pFormCode, pID, pSeqNo)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Approver" Then

                Dim pID = context.Request("pID")
                Dim pAddForm = context.Request("pAddForm")
                Dim pApproverType = context.Request("pApproverType")
                Dim pApprover = context.Request("pApprover")
                Dim pNoDays = context.Request("pNoDays")
                Dim pTemplate = context.Request("pTemplate")
                json = Me.Add_Approver(pFormCode, pID, pAddForm, pApproverType, pApprover, pNoDays, pTemplate)

            ElseIf pFormCode = "FRM000010" And pType = "Delete - Approver" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                json = Me.Delete_Approver(pFormCode, pID, pSeqNo)

            ElseIf pFormCode = "FRM000010" And pType = "Update - Reason" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pReason = context.Request("pReason")
                json = Me.Update_Reason(pFormCode, pID, pSeqNo, pReason)

            ElseIf pFormCode = "FRM000010" And pType = "Get - Subscriber" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Subscriber(pID)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Subscriber" Then

                Dim pID = context.Request("pID")
                Dim pMonitorBy = context.Request("pMonitorBy")
                json = Me.Add_Subscriber(pFormCode, pID, pMonitorBy)

            ElseIf pFormCode = "FRM000010" And pType = "Delete - Subscriber" Then

                Dim pID = context.Request("pID")
                Dim pMonitorBy = context.Request("pMonitorBy")
                json = Me.Delete_Subscriber(pFormCode, pID, pMonitorBy)

            ElseIf pFormCode = "FRM000010" And pType = "Get - History" Then

                Dim pID = context.Request("pID")
                json = Me.Get_History(pFormCode, pID)

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
                Dim pCategory01 = context.Request("pCategory01")
                Dim pCategory02 = context.Request("pCategory02")
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
                json = Me.Add_Record(pDateRequired, pPurchaseType, pDeptCode, pProjType, pPurpose, pSubdCode, pPhase, pBlock, pLot, pCarCode, pCategory01, pCategory02, pActName, pActLocation, pActDate, pChargeCode, pAcctCode, pDivision, pCECode, pMisc, pRemarks, pCreatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Update - Record" Then

                Dim pID = context.Request("pID")
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
                Dim pCategory01 = context.Request("pCategory01")
                Dim pCategory02 = context.Request("pCategory02")
                Dim pActName = context.Request("pActName")
                Dim pActLocation = context.Request("pActLocation")
                Dim pActDate = context.Request("pActDate")
                Dim pChargeCode = context.Request("pChargeCode")
                Dim pAcctCode = context.Request("pAcctCode")
                Dim pDivision = context.Request("pDivision")
                Dim pCECode = context.Request("pCECode")
                Dim pMisc = context.Request("pMisc")
                Dim pRemarks = context.Request("pRemarks")
                Dim pUpdatedBy = CIIS_EmpCode
                json = Me.Update_Record(pID, pDateRequired, pPurchaseType, pDeptCode, pProjType, pPurpose, pSubdCode, pPhase, pBlock, pLot, pCarCode, pCategory01, pCategory02, pActName, pActLocation, pActDate, pChargeCode, pAcctCode, pDivision, pCECode, pMisc, pRemarks, pUpdatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Record (OSM Batch)" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                Dim pCreatedBy = CIIS_EmpCode
                json = Me.Add_Record_OSM_Batch(pID, pItemSrs, pCreatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Record (OSM Estimate)" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                Dim pCreatedBy = CIIS_EmpCode
                json = Me.Add_Record_OSM_Estimate(pID, pItemSrs, pCreatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Record (SCM Batch)" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                Dim pCreatedBy = CIIS_EmpCode
                json = Me.Add_Record_SCM_Batch(pID, pItemSrs, pCreatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Record (SCM Estimate)" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                Dim pCreatedBy = CIIS_EmpCode
                json = Me.Add_Record_SCM_Estimate(pID, pItemSrs, pCreatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Record (Return)" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                Dim pCreatedBy = CIIS_EmpCode
                json = Me.Add_Record_Return(pID, pItemSrs, pCreatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Delete - Particular" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pDeletedBy = CIIS_EmpCode
                json = Me.Delete_Particular(pID, pSeqNo, pDeletedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Add - Particular" Then

                Dim pID = context.Request("pID")
                Dim pItem = context.Request("pItem")
                Dim pQty = context.Request("pQty")
                Dim pUnit = context.Request("pUnit")
                Dim pBdgtAmt = context.Request("pBdgtAmt")
                Dim pCreatedBy = CIIS_EmpCode
                json = Me.Add_Particular(pID, pItem, pQty, pUnit, pBdgtAmt, pCreatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Update - Particular" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pItem = context.Request("pItem")
                Dim pQty = context.Request("pQty")
                Dim pUnit = context.Request("pUnit")
                Dim pBdgtAmt = context.Request("pBdgtAmt")
                Dim pStatus = context.Request("pStatus")
                Dim pForPO = context.Request("pForPO")
                Dim pForSR = context.Request("pForSR")
                Dim pForCP = context.Request("pForCP")
                Dim pCost = context.Request("pCost")
                Dim pTotal = context.Request("pTotal")
                Dim pRemarks = context.Request("pRemarks")
                Dim pUpdatedBy = CIIS_EmpCode
                json = Me.Update_Particular(pID, pSeqNo, pItem, pQty, pUnit, pBdgtAmt, pStatus, pForPO, pForSR, pForCP, pCost, pTotal, pRemarks, pUpdatedBy)

            ElseIf pFormCode = "FRM000010" And pType = "Update - Particular (Tag)" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                json = Me.Update_Particular_Tag(pID, pItemSrs)

            ElseIf pFormCode = "FRM000010" And pType = "Return - Particular (Tag)" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                json = Me.Return_Particular_Tag(pID, pItemSrs)

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
        Query.Append("declare @PRCode nvarchar(13) = isnull((select tbl_code from oop_form_hdr where f_code = '" & pID & "'), '') ")
        Dim Msg As String = ""
        'create variable


        If pGroup = "06PRDtl" Then

            'get total task
            If pFType = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' in (select top 1 approver from oop_form_dtl_appr where f_code = '" & pID & "' and approver = 'MN2023120000' and status = '') and isnull((select justification from ogm_pr_hdr where pr_code = @PRCode), '') LIKE '%(Stock Request)%' ")
                Query.Append("begin ")
                Query.Append("  select '' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by from oop_form_hdr where f_code = '" & pID & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' in (select top 1 approver from oop_form_dtl_appr where f_code = '" & pID & "' and approver = 'MN2023120000' and status = '') and isnull((select justification from ogm_pr_hdr where pr_code = @PRCode), '') LIKE '%(Stock Request)%' ")
                Query.Append("begin ")
                Query.Append("  select '' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by from oop_form_hdr where f_code = '" & pID & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' in (select top 1 approver from oop_form_dtl_appr where f_code = '" & pID & "' and approver = 'MN2023120000' and status = '') and isnull((select justification from ogm_pr_hdr where pr_code = @PRCode), '') LIKE '%(Stock Request)%' ")
                Query.Append("begin ")
                Query.Append("  select '' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by [authorize] from oop_form_hdr where f_code = '" & pID & "' union select approver [authorize] from oop_form_dtl_appr where f_code = '" & pID & "' and type = 'Implementer') ")
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
                Query.Append("else if (select status from oop_form_hdr where f_code = '" & pID & "') not in ('New') ")
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
    Function Get_Dropdown_List(pTblName, pPlaceHolder, pVal01, pVal02)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Branch_List" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].buss_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   business [A] ")
            Query.Append("where ")
            Query.Append("   [A].lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Change_Status" Then
            Query.Append("if (select top 1 created_by from oop_form_hdr where f_code = '" & pVal01 & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & pVal01 & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal01 & "' and status = '' order by seq_no asc) in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & pVal01 & "') not in ('For Cancellation')")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Approved' [ID] ")
            Query.Append("      ,'Approve' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Clarify' [ID] ")
            Query.Append("      ,'Clarify' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Cancelled' [ID] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & pVal01 & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & pVal01 & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal01 & "' and status = '' order by seq_no asc) in ('Clarification') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Reply' [ID] ")
            Query.Append("      ,'Reply' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & pVal01 & "') in ('" & CIIS_EmpCode & "') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Cancelled' [ID] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal01 & "' and status = '' order by seq_no desc) in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & pVal01 & "') not in ('For Cancellation') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Approved' [ID] ")
            Query.Append("      ,'Approve' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Clarify' [ID] ")
            Query.Append("      ,'Clarify' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Declined' [ID] ")
            Query.Append("      ,'Decline' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal01 & "' and status = '' order by seq_no desc) in ('Clarification') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Reply' [ID] ")
            Query.Append("      ,'Reply' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 status from oop_form_hdr where f_code = '" & pVal01 & "') in ('For Cancellation') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Cancelled' [ID] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("end ")
        ElseIf pTblName = "Clarify_To" Then
            Query.Append("select")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'Select a user' [Name] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].created_by [ID] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & pVal01 & "' ")
            Query.Append("   and [A].created_by not in ('" & CIIS_EmpCode & "') ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].approver [ID] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
            Query.Append("from ")
            Query.Append("   oop_form_dtl_appr [A] ")
            Query.Append("   left join employee [B] on [A].approver = [B].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & pVal01 & "' ")
            Query.Append("   and [A].approver not in ('" & CIIS_EmpCode & "') ")
            Query.Append("order by ")
            Query.Append("   [Order] ")
        ElseIf pTblName = "Approver_List" Then
            Query.Append("if '" & pVal01 & "' not in (select oop_form_type.FormCode from oop_form_appr left join oop_form_type on oop_form_appr.form_type = oop_form_type.t_code where oop_form_type.FormCode = '" & pVal01 & "' and oop_form_appr.type = '" & pVal02 & "') ")
            Query.Append("begin ")
            Query.Append("   select")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a user' [Name] ")
            Query.Append("      ,'' [Order] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      [A].emp_no [ID] ")
            Query.Append("      ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
            Query.Append("      ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
            Query.Append("   from ")
            Query.Append("      employee [A] ")
            Query.Append("   where ")
            Query.Append("      [A].emp_status in ('Contractual','Probationary','Regular') ")
            Query.Append("      and [A].lock = 1 ")
            Query.Append("   order by ")
            Query.Append("      [Order] ")
            Query.Append("end ")
            Query.Append("else ")
            Query.Append("begin ")
            Query.Append("   select")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a user' [Name] ")
            Query.Append("      ,'' [Order] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      [A].approver [ID] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
            Query.Append("   from ")
            Query.Append("      oop_form_appr [A] ")
            Query.Append("      left join employee [B] on [A].approver = [B].emp_no ")
            Query.Append("      left join oop_form_type [C] on [A].form_type = [C].t_code ")
            Query.Append("   where ")
            Query.Append("      [C].FormCode = '" & pVal01 & "' ")
            Query.Append("      and [A].type = '" & pVal02 & "' ")
            Query.Append("      and [B].emp_status in ('Contractual','Probationary','Regular') ")
            Query.Append("      and [B].lock = 1 ")
            Query.Append("   order by ")
            Query.Append("      [Order] ")
            Query.Append("end")
        ElseIf pTblName = "Template_List" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].Code [ID] ")
            Query.Append("   ,[A].Title [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Title [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_AppPathTempHdr [A] ")
            Query.Append("where ")
            Query.Append("   [A].FormCode = '" & pVal01 & "' ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Subscriber_List" Then
            Query.Append("select")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'Select a user' [Name] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].emp_no [ID] ")
            Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
            Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
            Query.Append("from ")
            Query.Append("   employee [A] ")
            Query.Append("where ")
            Query.Append("   [A].emp_status in ('Contractual','Probationary','Regular') ")
            Query.Append("   and [A].lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order] ")
        ElseIf pTblName = "Get_ProjectType" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].ProjectType [ID] ")
            Query.Append("   ,[A].ProjectType [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].ProjectType [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_PurposeType [A] ")
            Query.Append("where ")
            Query.Append("   [A].PurchaseType = '" & pVal01 & "' ")
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
            Query.Append("   and [A].PurchaseType = '" & pVal01 & "' ")
            Query.Append("   and [A].ProjectType = '" & pVal02 & "' ")
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
        Query.Append("  ,[M].PlateNo + ' - ' + [M].CarModel [VehicleName] ")
        Query.Append("  ,[B].PlateNo [VehiclePlate] ")
        Query.Append("  ,[M].CarCode [VehicleCode] ")
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
        Query.Append("                WHEN [B].Misc = 'NO SUBSIDIARY' THEN ISNULL((select Description from Mstr_PurposeType where Type + ' - ' + Purpose = [B].Purpose and AcctCode = [B].AcctCode and PurchaseType = [B].PurchaseType and ProjectType = [B].justification), '') ")
        Query.Append("                WHEN [B].Misc = 'SUBDIVISION' THEN (select description from sub_subdivision where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'PHASE' THEN (select description from sub_phase where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'VENDOR' THEN (select description from sub_vendor where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'WAREHOUSE' THEN (select description from sub_warehouse where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'AGENT' THEN (select description from sub_agent where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'BANK' THEN (select description from sub_bank where code = [B].ChargeCode) ")
        Query.Append("                WHEN [B].Misc = 'EMPLOYEE' THEN (select description from sub_employee where code = [B].ChargeCode) ")
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
                        .FormType = "Purchase Request",
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
                        .VehicleCode = DR("VehicleCode"),
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
        Query.Append("      [A].tbl_from = 'ogm_pr_hdr' ")
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
        Query.Append("      [A].tbl_from = 'ogm_pr_hdr' ")
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
        Query.Append("      [A].tbl_from = 'ogm_pr_hdr' ")
        Query.Append("      and [M].monitored_by = '" & CIIS_EmpCode & "') [A] ")
        Query.Append("order by ")
        Query.Append("   [ID] DESC ")
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
        Query.Append("	(case when isnull(dbo.ProperCase([E].first_name) + ' ' + ")
        Query.Append("	dbo.ProperCase([E].last_name),'') = '' then '-' else ")
        Query.Append("	isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [Name] ")
        Query.Append("	,[E].dept_code ")
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
                    .EmpName = If(IsDBNull(DR("Name")), "", DR("Name")),
                    .DeptCode = DR("dept_code")
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
    Function Get_EstimateCode(pCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [a].AcctCode ")
        Query.Append("  ,[a].DivCode ")
        Query.Append("  ,[b].description [DivName] ")
        Query.Append("  ,[a].DeptCode ")
        Query.Append("  ,[c].description [DeptName] ")
        Query.Append("  ,(CASE WHEN [a].Subsidiary = 'NO SUBSIDIARY' THEN 'NO SUBSIDIARY' ")
        Query.Append("         WHEN [a].Subsidiary = 'MODEL HOUSE' THEN ISNULL((select description from sub_house where code = [a].ChargeCode),'') ")
        Query.Append("         WHEN [a].Subsidiary = 'PHASE' THEN ISNULL((select description from sub_phase where code = [a].ChargeCode),'') ")
        Query.Append("         WHEN [a].Subsidiary = 'SUBDIVISION' THEN ISNULL((select description from subdivision where code = [a].ChargeCode),'') ")
        Query.Append("  END) [ChargeName] ")
        Query.Append("  ,[a].ChargeCode ")
        Query.Append("  ,[a].Subsidiary ")
        Query.Append("from ")
        Query.Append("  Trxn_CEHdr [a] ")
        Query.Append("  left join division [b] on [a].DivCode = [b].div_code ")
        Query.Append("  left join department [c] on [a].DeptCode = [c].dept_code ")
        Query.Append("where ")
        Query.Append("  [a].CECode = @pCode ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .AcctCode = DR("AcctCode"),
                        .DivCode = DR("DivCode"),
                        .DivName = DR("DivName"),
                        .DeptCode = DR("DeptCode"),
                        .DeptName = DR("DeptName"),
                        .ChargeName = DR("ChargeName"),
                        .ChargeCode = DR("ChargeCode"),
                        .Subsidiary = DR("Subsidiary")
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
    Function Get_Project()

        'get estimate
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      [A].LotCode [Code] ")
        Query.Append("      ,[A].s_code [SubdCode] ")
        Query.Append("      ,[A].p_code [PhaseCode] ")
        Query.Append("      ,[A].b_code [BlockCode] ")
        Query.Append("      ,[A].l_code [LotCode] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        'get estimate

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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view mt-1' title='Select' onclick=""fn0101AddProject('" & DR("SubdCode") & "', '" & DR("PhaseCode") & "', '" & DR("BlockCode") & "', '" & DR("LotCode") & "', '" & DR("Description") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    Dim Title As String = "Project - Record"

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Code = DR("Code"),
                        .Description = DR("Description"),
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
    Function Get_Particular_SCM_Batch(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @ProjType nvarchar(180) = isnull((select justification from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @CECode nvarchar(20) = isnull((select CECode from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @SubdCode nvarchar(13) = isnull((select Subdivision from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("if @ProjType in ('OSM Project (Advance PO)') and @Category in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("  [Scope] ")
        Query.Append("  ,[Particular] ")
        Query.Append("  ,[Qty1] ")
        Query.Append("  ,[Qty2] ")
        Query.Append("  ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("  ,[UOM] ")
        Query.Append("  ,[WBSNo] ")
        Query.Append("from  ")
        Query.Append("  (select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,[B].Description [Scope] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("      ,'' [WBSNo] ")
        Query.Append("  from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("  where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].BatchNo + ' ' + [A].Project = @CECode + ' ' + @SubdCode ")
        Query.Append("  union ")
        Query.Append("  select distinct ")
        Query.Append("      1 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,SUM([A].Qty + [A].QtyRev) - SUM([A].QtyPO) [Qty1] ")
        Query.Append("      ,ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[C].abbr [UOM] ")
        Query.Append("      ,[A].WBSNo ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      left join sys_um [C] on [A].UMCode = [C].u_code ")
        Query.Append("   where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].BatchNo + ' ' + [A].Project = @CECode + ' ' + @SubdCode ")
        Query.Append("   group by ")
        Query.Append("      [A].WBSNo, [B].WNo, [A].Particular, [C].abbr) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @ProjType in ('CCI Project (Advance PO)') and @Category in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("  [Scope] ")
        Query.Append("  ,[Particular] ")
        Query.Append("  ,[Qty1] ")
        Query.Append("  ,[Qty2] ")
        Query.Append("  ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("  ,[UOM] ")
        Query.Append("  ,[WBSNo] ")
        Query.Append("from  ")
        Query.Append("  (select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,[B].Description [Scope] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("      ,'' [WBSNo] ")
        Query.Append("  from ")
        Query.Append("      Trxn_CEDtl_PO_CCI [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("  where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].BatchNo + ' ' + [A].Project = @CECode + ' ' + @SubdCode ")
        Query.Append("  union ")
        Query.Append("  select distinct ")
        Query.Append("      1 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,SUM([A].Qty + [A].QtyRev) - SUM([A].QtyPO) [Qty1] ")
        Query.Append("      ,ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[C].abbr [UOM] ")
        Query.Append("      ,[A].WBSNo ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl_PO_CCI [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      left join sys_um [C] on [A].UMCode = [C].u_code ")
        Query.Append("   where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].BatchNo + ' ' + [A].Project = @CECode + ' ' + @SubdCode ")
        Query.Append("   group by ")
        Query.Append("      [A].WBSNo, [B].WNo, [A].Particular, [C].abbr) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        Query.Append("end ")
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
                        .Particular = DR("Particular"),
                        .WBSNo = DR("WBSNo"),
                        .Qty1 = DR("Qty1"),
                        .Qty2 = DR("Qty2"),
                        .Qty3 = DR("Qty3"),
                        .Unit = DR("UOM")
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
    Function Get_Particular_SCM_Estimate(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @ProjType nvarchar(180) = isnull((select justification from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @CECode nvarchar(20) = isnull((select CECode from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("if @ProjType in ('OSM Project (Advance PO)') and @Category not in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("  [Scope] ")
        Query.Append("  ,[Particular] ")
        Query.Append("  ,[Qty1] ")
        Query.Append("  ,[Qty2] ")
        Query.Append("  ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("  ,[UOM] ")
        Query.Append("  ,[WBSNo] ")
        Query.Append("from  ")
        Query.Append("  (select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,[B].Description [Scope] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("      ,'' [WBSNo] ")
        Query.Append("  from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("  where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].CECode = @CECode ")
        Query.Append("  union ")
        Query.Append("  select distinct ")
        Query.Append("      1 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,SUM([A].Qty + [A].QtyRev) - SUM([A].QtyPO) [Qty1] ")
        Query.Append("      ,ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[C].abbr [UOM] ")
        Query.Append("      ,[A].WBSNo ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl_PO [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      left join sys_um [C] on [A].UMCode = [C].u_code ")
        Query.Append("   where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].CECode = @CECode ")
        Query.Append("   group by ")
        Query.Append("      [A].WBSNo, [B].WNo, [A].Particular, [C].abbr) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @ProjType in ('CCI Project (Advance PO)') and @Category not in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("  [Scope] ")
        Query.Append("  ,[Particular] ")
        Query.Append("  ,[Qty1] ")
        Query.Append("  ,[Qty2] ")
        Query.Append("  ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("  ,[UOM] ")
        Query.Append("  ,[WBSNo] ")
        Query.Append("from  ")
        Query.Append("  (select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,[B].Description [Scope] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("      ,'' [WBSNo] ")
        Query.Append("  from ")
        Query.Append("      Trxn_CEDtl_PO_CCI [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("  where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].CECode = @CECode ")
        Query.Append("  union ")
        Query.Append("  select distinct ")
        Query.Append("      1 [SeqNo] ")
        Query.Append("      ,[B].WNo ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,SUM([A].Qty + [A].QtyRev) - SUM([A].QtyPO) [Qty1] ")
        Query.Append("      ,ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[C].abbr [UOM] ")
        Query.Append("      ,[A].WBSNo ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl_PO_CCI [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      left join sys_um [C] on [A].UMCode = [C].u_code ")
        Query.Append("   where ")
        Query.Append("      ([A].Qty + [A].QtyRev) - [A].QtyPO > 0 ")
        Query.Append("      AND ((([A].Qty + [A].QtyRev) - [A].QtyPO) - ISNULL((select sum([F].qty) from ogm_pr_dtl [F] left join oop_form_hdr [E] on [E].tbl_code = [F].pr_code where [F].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) ) > 0 ")
        Query.Append("      AND [A].CECode = @CECode ")
        Query.Append("   group by ")
        Query.Append("      [A].WBSNo, [B].WNo, [A].Particular, [C].abbr) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        Query.Append("end ")
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
                        .Particular = DR("Particular"),
                        .WBSNo = DR("WBSNo"),
                        .Qty1 = DR("Qty1"),
                        .Qty2 = DR("Qty2"),
                        .Qty3 = DR("Qty3"),
                        .Unit = DR("UOM")
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
    Function Get_Particular_OSM_Batch(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @ProjType nvarchar(180) = isnull((select justification from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("if @ProjType in ('OSM Project (Advance PO)') and @Category in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("  select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,'' [OSM] ")
        Query.Append("      ,[D].Description [Item] ")
        Query.Append("      ,NULL [Qty] ")
        Query.Append("      ,NULL [Unit] ")
        Query.Append("      ,NULL [BdgtAmt] ")
        Query.Append("      ,NULL [Status] ")
        Query.Append("      ,NULL [POQty] ")
        Query.Append("      ,NULL [SRQty] ")
        Query.Append("      ,NULL [CPQty] ")
        Query.Append("      ,NULL [CPCost] ")
        Query.Append("      ,NULL [CPTotal] ")
        Query.Append("      ,NULL [Remarks] ")
        Query.Append("      ,'' [ItemNo] ")
        Query.Append("      ,[D].Description [Scope] ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("      left join Trxn_CEDtl_PO [C] on [A].WBSNo = [C].WBSNo ")
        Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
        Query.Append("  where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("  group by ")
        Query.Append("      [D].Description ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,(CASE WHEN [A].WBSNo != '' THEN 'SCM' ELSE '' END) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when [A].WBSNo = '' then [A].ItemNo else [A].WBSNo end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl_PO [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].WBSNo  = [A].WBSNo GROUP BY [D].WNo), '') [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("   order by ")
        Query.Append("      [WNo] ")
        Query.Append("      ,[SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @ProjType in ('CCI Project (Advance PO)') and @Category in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("  select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,'' [OSM] ")
        Query.Append("      ,[D].Description [Item] ")
        Query.Append("      ,NULL [Qty] ")
        Query.Append("      ,NULL [Unit] ")
        Query.Append("      ,NULL [BdgtAmt] ")
        Query.Append("      ,NULL [Status] ")
        Query.Append("      ,NULL [POQty] ")
        Query.Append("      ,NULL [SRQty] ")
        Query.Append("      ,NULL [CPQty] ")
        Query.Append("      ,NULL [CPCost] ")
        Query.Append("      ,NULL [CPTotal] ")
        Query.Append("      ,NULL [Remarks] ")
        Query.Append("      ,'' [ItemNo] ")
        Query.Append("      ,[D].Description [Scope] ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("      left join Trxn_CEDtl_PO_CCI [C] on [A].WBSNo = [C].WBSNo ")
        Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
        Query.Append("  where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("  group by ")
        Query.Append("      [D].Description ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,(CASE WHEN [A].WBSNo != '' THEN 'CCI' ELSE '' END) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when [A].WBSNo = '' then [A].ItemNo else [A].WBSNo end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl_PO_CCI [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].WBSNo  = [A].WBSNo GROUP BY [D].WNo), '') [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("   order by ")
        Query.Append("      [WNo] ")
        Query.Append("      ,[SeqNo] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("select ")
        Query.Append("  [SeqNo] ")
        Query.Append("  ,[PRCode] ")
        Query.Append("  ,@ProjType [ProjType] ")
        Query.Append("  ,@Category [Category] ")
        Query.Append("  ,[OSM] ")
        Query.Append("  ,(CASE WHEN [Item] = '' THEN [Scope] ELSE [Item] END) [Item] ")
        Query.Append("  ,[Qty] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[BdgtAmt] ")
        Query.Append("  ,[Status] ")
        Query.Append("  ,[POQty] ")
        Query.Append("  ,[SRQty] ")
        Query.Append("  ,[CPQty] ")
        Query.Append("  ,[CPCost] ")
        Query.Append("  ,[CPTotal] ")
        Query.Append("  ,[Remarks] ")
        Query.Append("  ,[ItemNo] ")
        Query.Append("  ,[Scope] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [PRCode] ")
        Query.Append("      ,'' [OSM] ")
        Query.Append("      ,'' [Item] ")
        Query.Append("      ,NULL [Qty] ")
        Query.Append("      ,'' [Unit] ")
        Query.Append("      ,NULL [BdgtAmt] ")
        Query.Append("      ,'' [Status] ")
        Query.Append("      ,NULL [POQty] ")
        Query.Append("      ,NULL [SRQty] ")
        Query.Append("      ,NULL [CPQty] ")
        Query.Append("      ,NULL [CPCost] ")
        Query.Append("      ,NULL [CPTotal] ")
        Query.Append("      ,'' [Remarks] ")
        Query.Append("      ,'' [ItemNo] ")
        Query.Append("      ,[D].Description [Scope] ")
        Query.Append("      ,[D].WNo [WNo] ")
        Query.Append("  from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("      left join Trxn_CEDtl_HouseCon [C] on [A].WBSNo = [C].WBSNo ")
        Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
        Query.Append("  where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("  group by ")
        Query.Append("      [D].Description ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,(case when SCMNo != '' then 'SCM' when WBSNo != '' then 'OSM' else '' end) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when [A].WBSNo = '' then [A].SCMNo else [A].WBSNo end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl_HouseCon [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].WBSNo  = [A].WBSNo GROUP BY [D].WNo), '') [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        Query.Append("end ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & pID & "', '" & DR("SeqNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    'If DR("ProjType") = "Non OSM Project" Then
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn0102Edit('" & pID & "', '" & DR("SeqNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    'End If
                    If DR("Category").ToString.Contains("House Construction") And DR("ProjType").ToString.Contains("(Stock Request)") Then
                        Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='Tag' onclick=""fn0102Tag('" & pID & "', '" & DR("ItemNo") & "', '" & DR("SeqNo") & "');return false;""><i class='las la-tag fs-3'></i></button>")
                    End If
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    Dim Type As String
                    If DR("ProjType") = "OSM Project (Advance PO)" And DR("OSM") <> "" Then
                        Type = "SCM"
                    ElseIf DR("ProjType") = "OSM Project (Stock Request)" And DR("OSM") <> "" Then
                        Type = "OSM"
                    ElseIf DR("ProjType").ToString.Contains("CCI Project") And DR("OSM") <> "" Then
                        Type = "CCI"
                    Else
                        Type = ""
                    End If

                    RecordList.Add(New With {
                        .Action = Action.ToString(),
                        .PRCode = DR("PRCode"),
                        .SeqNo = DR("SeqNo"),
                        .Type = Type,
                        .Item = DR("Item"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .BdgtAmt = DR("BdgtAmt"),
                        .Status = DR("Status"),
                        .POQty = DR("POQty"),
                        .SRQty = DR("SRQty"),
                        .CPQty = DR("CPQty"),
                        .CPCost = DR("CPCost"),
                        .CPTotal = DR("CPTotal"),
                        .Remarks = DR("Remarks"),
                        .ItemNo = DR("ItemNo"),
                        .Scope = DR("Scope"),
                        .Category = DR("Category")
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
    Function Get_Particular_OSM_Estimate(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @ProjType nvarchar(180) = isnull((select justification from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("if @ProjType in ('OSM Project (Advance PO)') and @Category not in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("  select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,'' [OSM] ")
        Query.Append("      ,[D].Description [Item] ")
        Query.Append("      ,NULL [Qty] ")
        Query.Append("      ,NULL [Unit] ")
        Query.Append("      ,NULL [BdgtAmt] ")
        Query.Append("      ,NULL [Status] ")
        Query.Append("      ,NULL [POQty] ")
        Query.Append("      ,NULL [SRQty] ")
        Query.Append("      ,NULL [CPQty] ")
        Query.Append("      ,NULL [CPCost] ")
        Query.Append("      ,NULL [CPTotal] ")
        Query.Append("      ,NULL [Remarks] ")
        Query.Append("      ,'' [ItemNo] ")
        Query.Append("      ,[D].Description [Scope] ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("      left join Trxn_CEDtl_PO [C] on [A].WBSNo = [C].WBSNo ")
        Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
        Query.Append("  where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("  group by ")
        Query.Append("      [D].Description ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,(CASE WHEN [A].WBSNo != '' THEN 'SCM' ELSE '' END) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when [A].WBSNo = '' then [A].ItemNo else [A].WBSNo end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl_PO [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].WBSNo  = [A].WBSNo GROUP BY [D].WNo), '') [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("   order by ")
        Query.Append("      [WNo] ")
        Query.Append("      ,[SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @ProjType in ('CCI Project (Advance PO)') and @Category not in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("  select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,'' [OSM] ")
        Query.Append("      ,[D].Description [Item] ")
        Query.Append("      ,NULL [Qty] ")
        Query.Append("      ,NULL [Unit] ")
        Query.Append("      ,NULL [BdgtAmt] ")
        Query.Append("      ,NULL [Status] ")
        Query.Append("      ,NULL [POQty] ")
        Query.Append("      ,NULL [SRQty] ")
        Query.Append("      ,NULL [CPQty] ")
        Query.Append("      ,NULL [CPCost] ")
        Query.Append("      ,NULL [CPTotal] ")
        Query.Append("      ,NULL [Remarks] ")
        Query.Append("      ,'' [ItemNo] ")
        Query.Append("      ,[D].Description [Scope] ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("      left join Trxn_CEDtl_PO_CCI [C] on [A].WBSNo = [C].WBSNo ")
        Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
        Query.Append("  where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("  group by ")
        Query.Append("      [D].Description ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,(CASE WHEN [A].WBSNo != '' THEN 'CCI' ELSE '' END) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when [A].WBSNo = '' then [A].ItemNo else [A].WBSNo end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl_PO_CCI [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].WBSNo  = [A].WBSNo GROUP BY [D].WNo), '') [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("   order by ")
        Query.Append("      [WNo] ")
        Query.Append("      ,[SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @ProjType in ('OSM Project') and isnull((select Purpose from ogm_pr_hdr where form_no = @pID),'') LIKE '%Return%' ")
        Query.Append("begin ")
        Query.Append("  select distinct ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,'' [OSM] ")
        Query.Append("      ,[D].Description [Item] ")
        Query.Append("      ,NULL [Qty] ")
        Query.Append("      ,NULL [Unit] ")
        Query.Append("      ,NULL [BdgtAmt] ")
        Query.Append("      ,NULL [Status] ")
        Query.Append("      ,NULL [POQty] ")
        Query.Append("      ,NULL [SRQty] ")
        Query.Append("      ,NULL [CPQty] ")
        Query.Append("      ,NULL [CPCost] ")
        Query.Append("      ,NULL [CPTotal] ")
        Query.Append("      ,NULL [Remarks] ")
        Query.Append("      ,'' [ItemNo] ")
        Query.Append("      ,[D].Description [Scope] ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("      left join Trxn_CEDtl [C] on [A].ItemNo = [C].ItemNo ")
        Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
        Query.Append("  where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("  group by ")
        Query.Append("      [D].Description ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,(CASE WHEN [A].ItemNo != '' THEN 'OSM' ELSE '' END) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when [A].ItemNo = '' then [A].SCMNo else [A].ItemNo end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].ItemNo  = [A].ItemNo GROUP BY [D].WNo), '') [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("   order by ")
        Query.Append("      [WNo] ")
        Query.Append("      ,[SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @ProjType in ('Non OSM Project', 'OSM Project') and isnull((select Purpose from ogm_pr_hdr where form_no = @pID),'') NOT LIKE '%Return%' ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,@ProjType [ProjType] ")
        Query.Append("      ,@Category [Category] ")
        Query.Append("      ,(case when SCMNo != '' then 'SCM' when ItemNo != '' then 'OSM' else '' end) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when [A].ItemNo = '' then [A].SCMNo else [A].ItemNo end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,'' [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("select ")
        Query.Append("  [SeqNo] ")
        Query.Append("  ,[PRCode] ")
        Query.Append("  ,@ProjType [ProjType] ")
        Query.Append("  ,@Category [Category] ")
        Query.Append("  ,[OSM] ")
        Query.Append("  ,(CASE WHEN [Item] = '' THEN [Scope] ELSE [Item] END) [Item] ")
        Query.Append("  ,[Qty] ")
        Query.Append("  ,[Unit] ")
        Query.Append("  ,[BdgtAmt] ")
        Query.Append("  ,[Status] ")
        Query.Append("  ,[POQty] ")
        Query.Append("  ,[SRQty] ")
        Query.Append("  ,[CPQty] ")
        Query.Append("  ,[CPCost] ")
        Query.Append("  ,[CPTotal] ")
        Query.Append("  ,[Remarks] ")
        Query.Append("  ,[ItemNo] ")
        Query.Append("  ,[Scope] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [PRCode] ")
        Query.Append("      ,'' [OSM] ")
        Query.Append("      ,'' [Item] ")
        Query.Append("      ,NULL [Qty] ")
        Query.Append("      ,'' [Unit] ")
        Query.Append("      ,NULL [BdgtAmt] ")
        Query.Append("      ,'' [Status] ")
        Query.Append("      ,NULL [POQty] ")
        Query.Append("      ,NULL [SRQty] ")
        Query.Append("      ,NULL [CPQty] ")
        Query.Append("      ,NULL [CPCost] ")
        Query.Append("      ,NULL [CPTotal] ")
        Query.Append("      ,'' [Remarks] ")
        Query.Append("      ,'' [ItemNo] ")
        Query.Append("      ,[D].Description [Scope] ")
        Query.Append("      ,[D].WNo [WNo] ")
        Query.Append("  from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("      left join Trxn_CEDtl [C] on [A].ItemNo = [C].ItemNo and [C].Particular = [A].item ")
        Query.Append("      left join Mstr_Work [D] on [C].WCode = [D].WCode ")
        Query.Append("  where ")
        Query.Append("      [B].f_code = @pID ")
        Query.Append("  group by ")
        Query.Append("      [D].Description ")
        Query.Append("      ,[D].WNo ")
        Query.Append("  union ")
        Query.Append("  select ")
        Query.Append("      [A].seq_no [SeqNo] ")
        Query.Append("      ,[A].pr_code [PRCode] ")
        Query.Append("      ,(case when SCMNo != '' then 'SCM' when ItemNo != '' then 'OSM' else '' end) [OSM] ")
        Query.Append("      ,[A].item [Item] ")
        Query.Append("      ,[A].qty [Qty] ")
        Query.Append("      ,[A].unit [Unit] ")
        Query.Append("      ,[A].BdgtAmt ")
        Query.Append("      ,[A].status [Status] ")
        Query.Append("      ,[A].ForPO [POQty] ")
        Query.Append("      ,([A].for_sr + [A].ForWT + [A].ForIR) [SRQty] ")
        Query.Append("      ,[A].ForCP [CPQty] ")
        Query.Append("      ,[A].unit_cost [CPCost] ")
        Query.Append("      ,[A].tot_cost [CPTotal] ")
        Query.Append("      ,[A].remarks [Remarks] ")
        Query.Append("      ,(case when ISNULL([A].ItemNo,'') = '' then [A].SCMNo else ISNULL([A].ItemNo,'') end) [ItemNo] ")
        Query.Append("      ,'' [Scope] ")
        Query.Append("      ,ISNULL((select [D].WNo from Trxn_CEDtl [C] left join Mstr_Work [D] on [C].WCode = [D].WCode where [C].ItemNo = [A].ItemNo and [C].Particular = [A].item GROUP BY [D].WNo), '') [WNo] ")
        Query.Append("   from ")
        Query.Append("      ogm_pr_dtl [A] ")
        Query.Append("      left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("   where ")
        Query.Append("      [B].f_code = @pID) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [WNo], [SeqNo] ")
        Query.Append("end ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & pID & "', '" & DR("SeqNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    'If DR("ProjType") = "Non OSM Project" Then
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn0102Edit('" & pID & "', '" & DR("SeqNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    'End If
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    Dim Type As String
                    If DR("ProjType") = "OSM Project (Advance PO)" And DR("OSM") <> "" Then
                        Type = "SCM"
                    ElseIf DR("ProjType") = "OSM Project (Stock Request)" And DR("OSM") <> "" Then
                        Type = "OSM"
                    ElseIf DR("ProjType").ToString.Contains("CCI Project") And DR("OSM") <> "" Then
                        Type = "CCI"
                    ElseIf DR("ProjType") = "OSM Project" Then
                        Type = DR("OSM")
                    Else
                        Type = ""
                    End If

                    RecordList.Add(New With {
                        .Action = Action.ToString(),
                        .PRCode = DR("PRCode"),
                        .SeqNo = DR("SeqNo"),
                        .Type = Type,
                        .Item = DR("Item"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .BdgtAmt = DR("BdgtAmt"),
                        .Status = DR("Status"),
                        .POQty = DR("POQty"),
                        .SRQty = DR("SRQty"),
                        .CPQty = DR("CPQty"),
                        .CPCost = DR("CPCost"),
                        .CPTotal = DR("CPTotal"),
                        .Remarks = DR("Remarks"),
                        .ItemNo = DR("ItemNo"),
                        .Scope = DR("Scope"),
                        .Category = DR("Category")
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
    Function Get_OSM_Batch(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @CECode nvarchar(13) = isnull((select CECode from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("declare @SubdCode nvarchar(13) = isnull((select Subdivision from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("if @Category = 'House Construction' ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      [WBSNo] ")
        Query.Append("      ,[Particular] ")
        Query.Append("      ,[Unit] ")
        Query.Append("      ,[Qty1] ")
        Query.Append("      ,[Qty2] ")
        Query.Append("      ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("      ,[Count] ")
        Query.Append("  from ")
        Query.Append("      (select ")
        Query.Append("          [B].WNo [Order01] ")
        Query.Append("          ,'' [Order02] ")
        Query.Append("          ,'' [WBSNo] ")
        Query.Append("          ,[B].Description [Particular] ")
        Query.Append("          ,'' [Unit] ")
        Query.Append("          ,NULL [Qty1] ")
        Query.Append("          ,NULL [Qty2] ")
        Query.Append("          ,0 [Count] ")
        Query.Append("      from ")
        Query.Append("          Trxn_CEDtl_HouseCon [A] ")
        Query.Append("          left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      where ")
        Query.Append("          [A].BatchNo = @CECode ")
        Query.Append("          and [A].Project = @SubdCode ")
        Query.Append("          and [A].TblFrom = 'ogm_item' ")
        Query.Append("          and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0 ")
        Query.Append("      union ")
        Query.Append("      select ")
        Query.Append("          [B].WNo [Order01] ")
        Query.Append("          ,[A].WBSNo [Order02] ")
        Query.Append("          ,[A].WBSNo ")
        Query.Append("          ,[A].Particular ")
        Query.Append("          ,[c].abbr [Unit] ")
        Query.Append("          ,([A].Qty + [A].QtyRev) - [A].QtyReq [Qty1] ")
        Query.Append("          ,isnull((select sum([D].qty) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("          ,isnull((select count(1) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].f_code = @pID and [E].status not in ('Accepted','Declined','Cancelled')),0) [Count] ")
        Query.Append("      from ")
        Query.Append("          Trxn_CEDtl_HouseCon [A] ")
        Query.Append("          left join Mstr_Work [B] on [A].WCode = [b].WCode ")
        Query.Append("          left join sys_um [c] on [A].UMCode = [c].u_code ")
        Query.Append("      where ")
        Query.Append("          [A].BatchNo = @CECode ")
        Query.Append("          and [A].Project = @SubdCode ")
        Query.Append("          and [A].TblFrom = 'ogm_item' ")
        Query.Append("          and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0) [A] ")
        Query.Append("   order by ")
        Query.Append("      [Order01] ")
        Query.Append("      ,[Order02] ")
        Query.Append("end ")
        Query.Append("else if @Category = 'House Construction - CCI' ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      [WBSNo] ")
        Query.Append("      ,[Particular] ")
        Query.Append("      ,[Unit] ")
        Query.Append("      ,[Qty1] ")
        Query.Append("      ,[Qty2] ")
        Query.Append("      ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("      ,[Count] ")
        Query.Append("  from ")
        Query.Append("      (select ")
        Query.Append("          [B].WNo [Order01] ")
        Query.Append("          ,'' [Order02] ")
        Query.Append("          ,'' [WBSNo] ")
        Query.Append("          ,[B].Description [Particular] ")
        Query.Append("          ,'' [Unit] ")
        Query.Append("          ,NULL [Qty1] ")
        Query.Append("          ,NULL [Qty2] ")
        Query.Append("          ,0 [Count] ")
        Query.Append("      from ")
        Query.Append("          Trxn_CEDtl_HouseCon_CCI [A] ")
        Query.Append("          left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("      where ")
        Query.Append("          [A].BatchNo = @CECode ")
        Query.Append("          and [A].Project = @SubdCode ")
        Query.Append("          and [A].TblFrom = 'ogm_item' ")
        Query.Append("          and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0 ")
        Query.Append("      union ")
        Query.Append("      select ")
        Query.Append("          [B].WNo [Order01] ")
        Query.Append("          ,[A].WBSNo [Order02] ")
        Query.Append("          ,[A].WBSNo ")
        Query.Append("          ,[A].Particular ")
        Query.Append("          ,[c].abbr [Unit] ")
        Query.Append("          ,([A].Qty + [A].QtyRev) - [A].QtyReq [Qty1] ")
        Query.Append("          ,isnull((select sum([D].qty) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("          ,isnull((select count(1) from ogm_pr_dtl [D] left join oop_form_hdr [E] on [D].pr_code = [E].tbl_code where [D].WBSNo = [A].WBSNo and [E].tbl_from = 'ogm_pr_hdr' and [E].f_code = @pID and [E].status not in ('Accepted','Declined','Cancelled')),0) [Count] ")
        Query.Append("      from ")
        Query.Append("          Trxn_CEDtl_HouseCon_CCI [A] ")
        Query.Append("          left join Mstr_Work [B] on [A].WCode = [b].WCode ")
        Query.Append("          left join sys_um [c] on [A].UMCode = [c].u_code ")
        Query.Append("      where ")
        Query.Append("          [A].BatchNo = @CECode ")
        Query.Append("          and [A].Project = @SubdCode ")
        Query.Append("          and [A].TblFrom = 'ogm_item' ")
        Query.Append("          and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0) [A] ")
        Query.Append("   order by ")
        Query.Append("      [Order01] ")
        Query.Append("      ,[Order02] ")
        Query.Append("end ")
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

                    Dim Action01 As New StringBuilder
                    Action01.Append("<button id='btn0101AddOSM' class='btn btn-sm btn-icon btn-view mt-1' title='Select' onclick=""fn0101AddOSM('" & DR("WBSNo") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    Dim Action02 As New StringBuilder
                    Action02.Append("<button class='btn btn-sm btn-icon mt-1' title='Select' onclick=""return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .Action = If(DR("Count") = 0, Action01.ToString(), Action02.ToString()),
                        .Particular = DR("Particular"),
                        .WBSNo = DR("WBSNo"),
                        .Unit = DR("Unit"),
                        .Qty1 = DR("Qty1"),
                        .Qty2 = DR("Qty2"),
                        .Qty3 = DR("Qty3")
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
    Function Get_OSM_Estimate(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @CECode nvarchar(13) = isnull((select CECode from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("declare @SubdCode nvarchar(13) = isnull((select Subdivision from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("if @Category not in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("   [Particular] ")
        Query.Append("   ,[ItmNo] ")
        Query.Append("   ,[Qty1] ")
        Query.Append("   ,[Qty2] ")
        Query.Append("   ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("   ,[UOM] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [ItmNo] ")
        Query.Append("      ,[B].WNo [ItemNo] ")
        Query.Append("      ,[B].WNo [No] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        'Query.Append("      and isnull([A].Release,0) > 0 ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      [A].SeqNo ")
        Query.Append("      ,[A].ItemNo [ItmNo] ")
        Query.Append("      ,[C].WNo [ItemNo] ")
        Query.Append("      ,'' [No] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) [Qty1] ")
        'Query.Append("      ,isnull([A].Release,0) [Qty1] ")
        Query.Append("      ,isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status not in ('Accepted','Declined','Cancelled')),0) [Qty2] ")
        Query.Append("      ,[B].abbr [UOM] ")
        Query.Append("   FROM ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join sys_um [B] on [A].UMCode = [B].u_code ")
        Query.Append("      left join Mstr_Work [C] on [A].WCode = [C].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("      and isnull(([A].Qty + [A].QtyRev) - [A].QtyReq,0) > 0 ) [A] ")
        'Query.Append("      and isnull([A].Release,0) > 0 ) [A] ")
        Query.Append("order by ")
        Query.Append("   [ItemNo] ")
        Query.Append("   ,[SeqNo] ")
        Query.Append("end ")
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
                        .Particular = DR("Particular"),
                        .ItmNo = DR("ItmNo"),
                        .Qty1 = DR("Qty1"),
                        .Qty2 = DR("Qty2"),
                        .Qty3 = DR("Qty3"),
                        .Unit = DR("UOM")
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
    Function Get_Particular_Update(pID, pSeqNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("select ")
        Query.Append("   [A].seq_no [SeqNo] ")
        Query.Append("   ,[A].item [Item] ")
        Query.Append("   ,[A].qty [Qty] ")
        Query.Append("   ,[A].unit [Unit] ")
        Query.Append("   ,[A].BdgtAmt ")
        Query.Append("   ,[A].status [Status]  ")
        Query.Append("   ,[A].ForPO [POQty] ")
        Query.Append("   ,([A].for_sr + [A].FOrWT + [A].ForIR) [SRQty] ")
        Query.Append("   ,[A].ForCP [CPQty] ")
        Query.Append("   ,[A].unit_cost [CPCost] ")
        Query.Append("   ,[A].tot_cost [CPTotal] ")
        Query.Append("   ,[A].remarks [Remarks] ")
        Query.Append("   ,@Category [Category] ")
        Query.Append("   ,[A].ItemNo ")
        Query.Append("   ,[A].SCMNo ")
        Query.Append("   ,[A].WBSNo ")
        Query.Append("from ")
        Query.Append("   ogm_pr_dtl [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].pr_code = [B].tbl_code ")
        Query.Append("where ")
        Query.Append("  [B].f_code = @pID ")
        Query.Append("  and [A].seq_no = @pSeqNo ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
                Cmd.Connection = ConStr
                ConStr.Open()

                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .SeqNo = DR("SeqNo"),
                        .Item = DR("Item"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .BdgtAmt = DR("BdgtAmt"),
                        .Status = DR("Status"),
                        .POQty = DR("POQty"),
                        .SRQty = DR("SRQty"),
                        .CPQty = DR("CPQty"),
                        .Cost = DR("CPCost"),
                        .Total = DR("CPTotal"),
                        .Remarks = DR("Remarks"),
                        .Category = DR("Category"),
                        .ItemNo = DR("ItemNo"),
                        .SCMNo = DR("SCMNo"),
                        .WBSNo = DR("WBSNo")
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
    Function Get_Tagging_Units(pID, pItemNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @BatchNo nvarchar(20) = isnull((select CECode from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @SubdCode nvarchar(13) = isnull((select Subdivision from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @PRCode nvarchar(13) = isnull((select pr_code from ogm_pr_hdr where form_no = @pID),'') ")
        Query.Append("declare @Particular nvarchar(max) = isnull((select item from ogm_pr_dtl where pr_code = @PRCode and WBSNo = @pItemNo),'') ")
        Query.Append("if @Category in ('House Construction') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("  [a].ItemNo ")
        Query.Append("  ,ISNULL([a].[Project], [a].[Title]) [Project] ")
        Query.Append("  ,[a].[Unit] ")
        Query.Append("  ,[a].[Qty1] ")
        Query.Append("  ,[a].[Qty2] ")
        Query.Append("  ,[a].[Qty1] - [a].[Qty2] [Qty3] ")
        Query.Append("  ,[a].[Qty4] ")
        Query.Append("  ,[a].[LotCode] ")
        Query.Append("  ,isnull([a].[AcctCode], '') [AcctCode] ")
        Query.Append("  ,isnull([a].[DivCode], '') [DivCode] ")
        Query.Append("  ,isnull([a].[DeptCode], '') [DeptCode] ")
        Query.Append("  ,isnull([a].[Subsidiary], '') [Subsidiary] ")
        Query.Append("  ,isnull([a].[Code], '') [Code] ")
        Query.Append("  ,@Particular [Particular] ")
        Query.Append("  ,[a].Title ")
        Query.Append("  ,[a].CECode ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [a].ItemNo ")
        Query.Append("  ,[f].abbr + ' ' + [e].description + ' B' + [d].block + ' L' + [c].lot [Project] ")
        Query.Append("  ,[c].LotCode ")
        Query.Append("  ,[g].abbr [Unit] ")
        Query.Append("  ,([a].Qty + [a].QtyRev) - [a].QtyReq [Qty1] ")
        'Query.Append("  ,[a].Release [Qty1] ")
        Query.Append("  ,ISNULL((select sum([h].qty) from Trxn_PRDtl_HouseCon [h] left join oop_form_hdr [i] on [h].PRCode = [i].tbl_code where [h].WBSNo = @pItemNo and [h].ItemNo = [a].ItemNo and [i].tbl_from = 'ogm_pr_hdr' and [i].status not in ('Accepted','Declined','Cancelled')),0) [Qty2]  ")
        Query.Append("  ,ISNULL((select sum([h].qty) from Trxn_PRDtl_HouseCon [h] left join oop_form_hdr [i] on [h].PRCode = [i].tbl_code where [h].WBSNo = @pItemNo and [h].ItemNo = [a].ItemNo and [i].tbl_from = 'ogm_pr_hdr' and [i].f_code = @pID and [i].status not in ('Accepted','Declined','Cancelled')),0) [Qty4]  ")
        Query.Append("  ,[a].AcctCode ")
        Query.Append("  ,[a].DivCode ")
        Query.Append("  ,[a].DeptCode ")
        Query.Append("  ,[a].Subsidiary ")
        Query.Append("  ,[a].Code ")
        Query.Append("  ,[b].Title ")
        Query.Append("  ,[a].CECode ")
        Query.Append("from ")
        Query.Append("  Trxn_CEDtl [a] ")
        Query.Append("  left join Trxn_CEHdr [b] on [a].CECode = [b].CECode ")
        Query.Append("  left join eng_lot [c] on [b].Subdivision = [c].l_code ")
        Query.Append("  left join eng_block [d] on [c].b_code = [d].b_code ")
        Query.Append("  left join phase [e] on [c].p_code = [e].code ")
        Query.Append("  left join subdivision [f] on (CASE WHEN [c].s_code IS null then [b].SubdCode else [c].s_code end) = [f].code ")
        Query.Append("  left join sys_um [g] on [a].UMCode = [g].u_code ")
        Query.Append("where ")
        Query.Append("  [A].WBSNo = @pItemNo ")
        Query.Append("  and [b].Post = 1 ")
        Query.Append("  and [b].Rvrs = 0 ")
        'Query.Append("  and ISNULL([a].IsOSM, 0) = 1 ")
        Query.Append("  AND (@BatchNo = '' OR [b].Batch = @BatchNo) ")
        Query.Append("  and [B].SubdCode = @SubdCode ")
        Query.Append("  and ([a].Qty + [a].QtyRev) - [a].QtyReq > 0 ")
        'Query.Append("  and [a].Release > 0 ")
        Query.Append("  and [a].Particular = @Particular) [a] ")
        Query.Append("end ")
        Query.Append("else if @Category in ('House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("  [a].ItemNo ")
        Query.Append("  ,ISNULL([a].[Project], [a].[Title]) [Project] ")
        Query.Append("  ,[a].[Unit] ")
        Query.Append("  ,[a].[Qty1] ")
        Query.Append("  ,[a].[Qty2] ")
        Query.Append("  ,[a].[Qty1] - [a].[Qty2] [Qty3] ")
        Query.Append("  ,[a].[Qty4] ")
        Query.Append("  ,[a].[LotCode] ")
        Query.Append("  ,isnull([a].[AcctCode], '') [AcctCode] ")
        Query.Append("  ,isnull([a].[DivCode], '') [DivCode] ")
        Query.Append("  ,isnull([a].[DeptCode], '') [DeptCode] ")
        Query.Append("  ,isnull([a].[Subsidiary], '') [Subsidiary] ")
        Query.Append("  ,isnull([a].[Code], '') [Code] ")
        Query.Append("  ,@Particular [Particular] ")
        Query.Append("  ,[a].Title ")
        Query.Append("  ,[a].CECode ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [a].ItemNo ")
        Query.Append("  ,[f].abbr + ' ' + [e].description + ' B' + [d].block + ' L' + [c].lot [Project] ")
        Query.Append("  ,[c].LotCode ")
        Query.Append("  ,[g].abbr [Unit] ")
        Query.Append("  ,([a].Qty + [a].QtyRev) - [a].QtyReq [Qty1] ")
        'Query.Append("  ,[a].Release [Qty1] ")
        Query.Append("  ,ISNULL((select sum([h].qty) from Trxn_PRDtl_HouseCon_CCI [h] left join oop_form_hdr [i] on [h].PRCode = [i].tbl_code where [h].WBSNo = @pItemNo and [h].ItemNo = [a].ItemNo and [i].tbl_from = 'ogm_pr_hdr' and [i].status not in ('Accepted','Declined','Cancelled')),0) [Qty2]  ")
        Query.Append("  ,ISNULL((select sum([h].qty) from Trxn_PRDtl_HouseCon_CCI [h] left join oop_form_hdr [i] on [h].PRCode = [i].tbl_code where [h].WBSNo = @pItemNo and [h].ItemNo = [a].ItemNo and [i].tbl_from = 'ogm_pr_hdr' and [i].f_code = @pID and [i].status not in ('Accepted','Declined','Cancelled')),0) [Qty4] ")
        Query.Append("  ,[a].AcctCode ")
        Query.Append("  ,[a].DivCode ")
        Query.Append("  ,[a].DeptCode ")
        Query.Append("  ,[a].Subsidiary ")
        Query.Append("  ,[a].Code ")
        Query.Append("  ,[b].Title ")
        Query.Append("  ,[a].CECode ")
        Query.Append("from ")
        Query.Append("  Trxn_CEDtl [a] ")
        Query.Append("  left join Trxn_CEHdr [b] on [a].CECode = [b].CECode ")
        Query.Append("  left join eng_lot [c] on [b].Subdivision = [c].l_code ")
        Query.Append("  left join eng_block [d] on [c].b_code = [d].b_code ")
        Query.Append("  left join phase [e] on [c].p_code = [e].code ")
        Query.Append("  left join subdivision [f] on (CASE WHEN [c].s_code IS null then [b].SubdCode else [c].s_code end) = [f].code ")
        Query.Append("  left join sys_um [g] on [a].UMCode = [g].u_code ")
        Query.Append("where ")
        Query.Append("  [A].WBSNo = @pItemNo ")
        Query.Append("  and [b].Post = 1 ")
        Query.Append("  and [b].Rvrs = 0 ")
        'Query.Append("  and ISNULL([a].IsOSM, 0) = 1 ")
        Query.Append("  AND (@BatchNo = '' OR [b].Batch = @BatchNo) ")
        Query.Append("  and [B].SubdCode = @SubdCode ")
        Query.Append("  and ([a].Qty + [a].QtyRev) - [a].QtyReq > 0 ")
        'Query.Append("  and [a].Release > 0 ")
        Query.Append("  and [a].Particular = @Particular) [a] ")
        Query.Append("end ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pItemNo", pItemNo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Title = DR("Title"),
                        .CECode = DR("CECode"),
                        .ItemNo = DR("ItemNo"),
                        .Project = DR("Project"),
                        .LotCode = DR("LotCode"),
                        .Unit = DR("Unit"),
                        .Qty1 = DR("Qty1"),
                        .Qty2 = DR("Qty2"),
                        .Qty3 = DR("Qty3"),
                        .Qty4 = DR("Qty4"),
                        .AcctCode = DR("AcctCode"),
                        .DivCode = DR("DivCode"),
                        .DeptCode = DR("DeptCode"),
                        .Subsidiary = DR("Subsidiary"),
                        .Code = DR("Code"),
                        .Particular = DR("Particular")
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
    Function Get_Tagged_Units(pID, pItemNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = ISNULL((select Category from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("declare @PRCode nvarchar(13) = ISNULL((select pr_code from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("if @Category = 'House Construction' ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      [G].abbr + ' ' + [F].description + ' B' + [E].block  + ' L' + [D].lot [Project] ")
        Query.Append("      ,(select abbr from sys_um where u_code = [B].UMCode) [Unit] ")
        Query.Append("      ,[A].Qty [Qty] ")
        Query.Append("  from ")
        Query.Append("      Trxn_PRDtl_HouseCon [A] ")
        Query.Append("      left join Trxn_CEDtl [B] on [A].WBSNo = [B].WBSNo and [A].ItemNo = [B].ItemNo and [A].CECode = [B].CECode ")
        Query.Append("      left join Trxn_CEHdr [C] on [A].CECode = [C].CECode ")
        Query.Append("      left join eng_lot [D] on [C].subdivision = [D].l_code ")
        Query.Append("      left join eng_block [E] on [D].b_code = [E].b_code ")
        Query.Append("      left join phase [F] on [E].p_code = [F].code ")
        Query.Append("      left join subdivision [G] on [F].scode = [G].code ")
        Query.Append("  where ")
        Query.Append("      [A].PRCode = @PRCode ")
        Query.Append("      and [A].WBSNo = @pItemNo ")
        Query.Append("  order by ")
        Query.Append("      [A].ItemNo ")
        Query.Append("end ")
        Query.Append("else if @Category = 'House Construction - CCI' ")
        Query.Append("begin ")
        Query.Append("  select ")
        Query.Append("      [G].abbr + ' ' + [F].description + ' B' + [E].block  + ' L' + [D].lot [Project] ")
        Query.Append("      ,(select abbr from sys_um where u_code = [B].UMCode) [Unit] ")
        Query.Append("      ,[A].Qty ")
        Query.Append("  from ")
        Query.Append("      Trxn_PRDtl_HouseCon_CCI [A] ")
        Query.Append("      left join Trxn_CEDtl [B] on [A].WBSNo = [B].WBSNo and [A].ItemNo = [B].ItemNo and [A].CECode = [B].CECode ")
        Query.Append("      left join Trxn_CEHdr [C] on [A].CECode = [C].CECode ")
        Query.Append("      left join eng_lot [D] on [C].subdivision = [D].l_code ")
        Query.Append("      left join eng_block [E] on [D].b_code = [E].b_code ")
        Query.Append("      left join phase [F] on [E].p_code = [F].code ")
        Query.Append("      left join subdivision [G] on [F].scode = [G].code ")
        Query.Append("  where ")
        Query.Append("      [A].PRCode = @PRCode ")
        Query.Append("      and [A].WBSNo = @pItemNo ")
        Query.Append("  order by ")
        Query.Append("      [A].ItemNo ")
        Query.Append("end ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pItemNo", pItemNo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Project = DR("Project"),
                        .Unit = DR("Unit"),
                        .Qty = DR("Qty")
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
    Function View_PR_Printout(pID As String, pEmpNo As String, context As HttpContext)
        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pEmpNo & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pEmpNo & "/")

            ' Create report folder if it doesn't exist
            If Not Directory.Exists(reportFolderPath) Then
                Directory.CreateDirectory(reportFolderPath)
            End If

            ' Delete existing files in the report folder
            Dim reportDir As New DirectoryInfo(reportFolderPath)
            For Each file In reportDir.GetFiles()
                file.Delete()
            Next

            ' Create PDF folder if it doesn't exist
            If Not Directory.Exists(pdfFolderPath) Then
                Directory.CreateDirectory(pdfFolderPath)
            End If

            ' Delete existing files in the PDF folder
            Dim pdfDir As New DirectoryInfo(pdfFolderPath)
            For Each file In pdfDir.GetFiles()
                file.Delete()
            Next

            ' Copy template report
            File.Copy(context.Server.MapPath("~/Assets/Report/RPT000011.rpt"), Path.Combine(reportFolderPath, "RPT000011.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "RPT000011.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, catalog)
            RptDoc.SetParameterValue("@pFormNo", pID, "PRPrintoutwNote.rpt")
            RptDoc.SetParameterValue("@pFormNo", pID)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000011.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000011.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            'catch
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function
    Function Get_Record_Return(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @CECode nvarchar(13) = isnull((select CECode from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("declare @SubdCode nvarchar(13) = isnull((select Subdivision from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("declare @Category nvarchar(180) = isnull((select Category from ogm_pr_hdr where form_no = @pID), '') ")
        Query.Append("if @Category in ('House Construction') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("   [Particular] ")
        Query.Append("   ,[ItmNo] ")
        Query.Append("   ,[Qty1] ")
        Query.Append("   ,([Qty2] - [QtyReturn]) [Qty2] ")
        Query.Append("   ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("   ,[UOM] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [ItmNo] ")
        Query.Append("      ,[B].WNo [ItemNo] ")
        Query.Append("      ,[B].WNo [No] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [QtyReturn] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("      and isnull([A].QtyUsed,0) > 0 ")
        Query.Append("      and isnull((select sum([C].qty) from Trxn_PRDtl_HouseCon [C] left join ogm_pr_hdr [D] on [C].PRCode = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].WBSNo = [A].WBSNo and [C].ItemNo = [A].ItemNo and [C].CECode = [A].CECode and [E].status in ('Accepted')),0) > 0 ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      [A].SeqNo ")
        Query.Append("      ,[A].ItemNo [ItmNo] ")
        Query.Append("      ,[C].WNo [ItemNo] ")
        Query.Append("      ,'' [No] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,isnull(([A].Qty + [A].QtyRev),0) [Qty1] ")
        Query.Append("      ,[A].QtyUsed [Qty2] ")
        Query.Append("      ,isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status not in ('Cancelled', 'Declined')),0) [QtyReturn] ")
        Query.Append("      ,[B].abbr [UOM] ")
        Query.Append("   FROM ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join sys_um [B] on [A].UMCode = [B].u_code ")
        Query.Append("      left join Mstr_Work [C] on [A].WCode = [C].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("      and isnull([A].QtyUsed,0) > 0 ")
        Query.Append("      and isnull((select sum([C].qty) from Trxn_PRDtl_HouseCon [C] left join ogm_pr_hdr [D] on [C].PRCode = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].WBSNo = [A].WBSNo and [C].ItemNo = [A].ItemNo and [C].CECode = [A].CECode and [E].status in ('Accepted')),0) > 0 ) [A] ")
        Query.Append("order by ")
        Query.Append("   [ItemNo] ")
        Query.Append("   ,[SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @Category in ('House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("   [Particular] ")
        Query.Append("   ,[ItmNo] ")
        Query.Append("   ,[Qty1] ")
        Query.Append("   ,([Qty2] - [QtyReturn]) [Qty2] ")
        Query.Append("   ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("   ,[UOM] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [ItmNo] ")
        Query.Append("      ,[B].WNo [ItemNo] ")
        Query.Append("      ,[B].WNo [No] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [QtyReturn] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("      and isnull([A].QtyUsed,0) > 0 ")
        Query.Append("      and isnull((select sum([C].qty) from Trxn_PRDtl_HouseCon_CCI [C] left join ogm_pr_hdr [D] on [C].PRCode = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].WBSNo = [A].WBSNo and [C].ItemNo = [A].ItemNo and [C].CECode = [A].CECode and [E].status in ('Accepted')),0) > 0 ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      [A].SeqNo ")
        Query.Append("      ,[A].ItemNo [ItmNo] ")
        Query.Append("      ,[C].WNo [ItemNo] ")
        Query.Append("      ,'' [No] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,isnull(([A].Qty + [A].QtyRev),0) [Qty1] ")
        'Query.Append("      ,isnull((select sum([C].qty) from Trxn_PRDtl_HouseCon_CCI [C] left join ogm_pr_hdr [D] on [C].PRCode = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].WBSNo = [A].WBSNo and [C].ItemNo = [A].ItemNo and [C].CECode = [A].CECode and [E].status in ('Accepted')),0) [Qty2] ")
        Query.Append("      ,[A].QtyUsed [Qty2] ")
        Query.Append("      ,isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status not in ('Cancelled', 'Declined')),0) [QtyReturn] ")
        Query.Append("      ,[B].abbr [UOM] ")
        Query.Append("   FROM ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join sys_um [B] on [A].UMCode = [B].u_code ")
        Query.Append("      left join Mstr_Work [C] on [A].WCode = [C].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("      and isnull([A].QtyUsed,0) > 0 ")
        Query.Append("      and isnull((select sum([C].qty) from Trxn_PRDtl_HouseCon_CCI [C] left join ogm_pr_hdr [D] on [C].PRCode = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].WBSNo = [A].WBSNo and [C].ItemNo = [A].ItemNo and [C].CECode = [A].CECode and [E].status in ('Accepted')),0) > 0 ) [A] ")
        Query.Append("order by ")
        Query.Append("   [ItemNo] ")
        Query.Append("   ,[SeqNo] ")
        Query.Append("end ")
        Query.Append("else if @Category not in ('House Construction', 'House Construction - CCI') ")
        Query.Append("begin ")
        Query.Append("Select ")
        Query.Append("   [Particular] ")
        Query.Append("   ,[ItmNo] ")
        Query.Append("   ,[Qty1] ")
        Query.Append("   ,([Qty2] - [QtyReturn]) [Qty2] ")
        Query.Append("   ,([Qty1] - [Qty2]) [Qty3] ")
        Query.Append("   ,[UOM] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      0 [SeqNo] ")
        Query.Append("      ,'' [ItmNo] ")
        Query.Append("      ,[B].WNo [ItemNo] ")
        Query.Append("      ,[B].WNo [No] ")
        Query.Append("      ,[B].Description [Particular] ")
        Query.Append("      ,NULL [Qty1] ")
        Query.Append("      ,NULL [Qty2] ")
        Query.Append("      ,NULL [QtyReturn] ")
        Query.Append("      ,NULL [UOM] ")
        Query.Append("   from ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join Mstr_Work [B] on [A].WCode = [B].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("      and isnull([A].QtyUsed,0) > 0 ")
        Query.Append("      and isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status in ('Accepted')),0) > 0 ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      [A].SeqNo ")
        Query.Append("      ,[A].ItemNo [ItmNo] ")
        Query.Append("      ,[C].WNo [ItemNo] ")
        Query.Append("      ,'' [No] ")
        Query.Append("      ,[A].Particular ")
        Query.Append("      ,isnull(([A].Qty + [A].QtyRev),0) [Qty1] ")
        'Query.Append("      ,isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status in ('Accepted')),0) [Qty2] ")
        Query.Append("      ,[A].QtyUsed [Qty2] ")
        Query.Append("      ,isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status not in ('Cancelled', 'Declimed')),0) [QtyReturn] ")
        Query.Append("      ,[B].abbr [UOM] ")
        Query.Append("   FROM ")
        Query.Append("      Trxn_CEDtl [A] ")
        Query.Append("      left join sys_um [B] on [A].UMCode = [B].u_code ")
        Query.Append("      left join Mstr_Work [C] on [A].WCode = [C].WCode ")
        Query.Append("   where ")
        Query.Append("      [A].CECode = @CECode ")
        Query.Append("      and [A].TblFrom = 'ogm_item' ")
        Query.Append("      and isnull([A].QtyUsed,0) > 0 ")
        Query.Append("      and isnull((select sum([C].qty) from ogm_pr_dtl [C] left join ogm_pr_hdr [D] on [C].pr_code = [D].pr_code left join oop_form_hdr [E] on [E].f_code = [D].form_no where [C].ItemNo = [A].ItemNo and [E].status in ('Accepted')),0) > 0 ) [A] ")
        Query.Append("order by ")
        Query.Append("   [ItemNo] ")
        Query.Append("   ,[SeqNo] ")
        Query.Append("end ")
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
                        .Particular = DR("Particular"),
                        .ItmNo = DR("ItmNo"),
                        .Qty1 = DR("Qty1"),
                        .Qty2 = DR("Qty2"),
                        .Qty3 = DR("Qty3"),
                        .Unit = DR("UOM")
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
    Function Get_Approval_Path(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	(case when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) < cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger'  ")
        Query.Append("	       when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) >= cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success'  ")
        Query.Append("	       when [A].status in ('') then 'bullet bullet-margin bullet-vertical h-58px bg-secondary' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) < cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) >= cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success' end) [Bullet] ")
        Query.Append("	,[A].seq_no [SeqNo] ")
        Query.Append("	,[A].type [Type] ")
        Query.Append("	,[A].approver [Icon] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [ApprName] ")
        Query.Append("	,isnull(dbo.ProperCase([B].JobDesc),'-') [ApprJob] ")
        Query.Append("	,(case when [A].status = '' then '-' else [A].status end) [ApprStatus] ")
        Query.Append("	,(case when [A].status = '' then '-' else format([A].updated_date,'MM/dd/yy') end) [ApprDate] ")
        Query.Append("	,(case when [A].status = '' and [A].approver = [C].approver then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') when [A].status not in ('') then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') else '-' end ) [Coverage] ")
        Query.Append("	,format([A].NoDays,'N1') [Duration] ")
        Query.Append("	,(case when [A].Reason = '' then '-' else isnull([A].Reason,'-') end) [Reason] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_appr [A] ")
        Query.Append("   left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("   left join oop_form_hdr [C] on [A].f_code = [C].f_code ")
        Query.Append("where ")
        Query.Append("   [A].f_code = @pID ")
        Query.Append("order by ")
        Query.Append("  [A].seq_no ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable
        Dim rowIndex As Integer = 0
        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Icon As String
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR("Icon") & ".png")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Icon") & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR("Icon") & ".jpg")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Icon") & ".jpg"
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    Dim Bullet As New StringBuilder
                    Bullet.Append("<div class='h-100'><span class='" & DR("Bullet") & "'></span></div>")

                    Dim Action As New StringBuilder()
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Remove User' onclick=""fn0401Delete('" & DR("SeqNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Update reason for delay' onclick=""fn0402UpdateR4D('" & DR("SeqNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-add' title='Move user up' onclick=""fn0401Up('" & DR("SeqNo") & "');return false;""><i class='las la-angle-up'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-add' title='Move user down' onclick=""fn0401Down('" & DR("SeqNo") & "');return false;""><i class='las la-angle-down'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")


                    Dim User As New StringBuilder
                    User.Append("<div class='d-flex align-items-center w-100'>")
                    User.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3' >")
                    User.Append("       <div class='symbol symbol-30px overflow-hidden' >")
                    User.Append("           <img alt='' class='w-100' src='" & Icon & "' />")
                    User.Append("        </div> ")
                    User.Append("   </div> ")
                    User.Append("   <div class='d-flex flex-column' >")
                    User.Append("      <span class='fw-bold text-dark'>" & DR("ApprName") & "</span>")
                    User.Append("      <span class='text-muted' >" & DR("ApprJob") & "</span>")
                    User.Append("   </div>")
                    User.Append("</div>")

                    Dim Status As New StringBuilder
                    Status.Append("<div class='d-flex align-items-center'>")
                    Status.Append("     <div class='d-flex flex-column'>")
                    Status.Append("         <span class='fw-bold text-dark' >" & DR("ApprStatus") & "</span>")
                    Status.Append("         <span class='text-muted' >" & DR("ApprDate") & "</span>")
                    Status.Append("     </div>")
                    Status.Append("</div>")

                    Dim TAT As New StringBuilder
                    TAT.Append("<div class='d-flex align-items-center'>")
                    TAT.Append("     <div class='d-flex flex-column'>")
                    TAT.Append("         <span class='fw-bold text-dark' >" & DR("Coverage") & "</span>")
                    TAT.Append("         <span class='text-muted' >" & DR("Duration") & "</span>")
                    TAT.Append("     </div>")
                    TAT.Append("</div>")

                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Action = Action.ToString,
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .User = User.ToString,
                        .Status = Status.ToString,
                        .TAT = TAT.ToString,
                        .RFD = "<span title='" & DR("Reason") & "'>" & DR("Reason") & "</span>"
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
    Function Update_Record_Approver(pFormCode, pID, pStatus, pAssignTo, pRemarks, pMention)

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
        SqlCmd.CommandText = "Upd_FRM_Status"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
        SqlCmd.Parameters.AddWithValue("@pAssignTo", pAssignTo)
        SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
        SqlCmd.Parameters.AddWithValue("@pMention", pMention)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Delete_Record_Approver(pFormCode, pID, pSeqNo)

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
        SqlCmd.CommandText = "Del_FRM_Approver"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Move_Up_Record_Approver(pFormCode, pID, pSeqNo)

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
        SqlCmd.CommandText = "Upd_FRM_MoveApprover"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pMove", "Up")
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Move_Down_Record_Approver(pFormCode, pID, pSeqNo)

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
        SqlCmd.CommandText = "Upd_FRM_MoveApprover"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pMove", "Down")
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Add_Approver(pFormCode, pID, pAddForm, pApproverType, pApprover, pNoDays, pTemplate)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        If pAddForm = "Manual" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_Approver"
            SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
            SqlCmd.Parameters.AddWithValue("@pID", pID)
            SqlCmd.Parameters.AddWithValue("@pType", pApproverType)
            SqlCmd.Parameters.AddWithValue("@pApprover", pApprover)
            SqlCmd.Parameters.AddWithValue("@pNoDays", pNoDays)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'add value
            RecordList.Add(New With {
                .oReturn = "Success"
            })
            'add value

        End If

        If pAddForm = "Template" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_FRM_ApproverTemplate"
            SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
            SqlCmd.Parameters.AddWithValue("@pID", pID)
            SqlCmd.Parameters.AddWithValue("@pTemplate", pTemplate)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'add value
            RecordList.Add(New With {
                .oReturn = "Success"
            })
            'add value

        End If

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Delete_Approver(pFormCode, pID, pSeqNo)

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
        SqlCmd.CommandText = "Del_FRM_Approver"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Update_Reason(pFormCode, pID, pSeqNo, pReason)

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
        SqlCmd.CommandText = "Upd_FRM_ReasonForDelay"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pReason", pReason)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Get_Subscriber(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 [A].monitored_by [Code] ")
        Query.Append("	 ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	 ,isnull(dbo.ProperCase([B].JobDesc),'-') [JobDesc] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_monitor [A] ")
        Query.Append("   left join employee [B] on [A].monitored_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = @pID ")
        Query.Append("order by ")
        Query.Append("   [A].seq_no ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable
        Dim rowIndex As Integer = 0
        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Icon As String = ""
                    Dim iconName As String = If(IsDBNull(DR("Code")), "", DR("Code").ToString().Trim())

                    Dim avatarPath As String = HttpContext.Current.Server.MapPath("~/Assets/media/avatars/")

                    If Not String.IsNullOrEmpty(iconName) Then
                        Dim pngPath As String = Path.Combine(avatarPath, iconName & ".png")
                        Dim jpgPath As String = Path.Combine(avatarPath, iconName & ".jpg")

                        If File.Exists(pngPath) Then
                            Icon = "Assets/media/avatars/" & iconName & ".png"
                        ElseIf File.Exists(jpgPath) Then
                            Icon = "Assets/media/avatars/" & iconName & ".jpg"
                        Else
                            Icon = "Assets/media/avatars/blank.png"
                        End If
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    Dim Bullet As New StringBuilder
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-margin bullet-vertical h-58px bg-secondary'></span></div>")

                    Dim Action As New StringBuilder()
                    Action.Append("<div class='d-flex'>")
                    Action.Append("     <button id='lbtn04Delete' class='btn btn-sm btn-icon btn-active-success mr-5' title='Remove User' onclick=""fn0501Delete('" & DR("Code") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("</div>")


                    Dim User As New StringBuilder
                    User.Append("<div class='d-flex align-items-center w-100'>")
                    User.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3' >")
                    User.Append("       <div class='symbol symbol-30px overflow-hidden' >")
                    User.Append("           <img alt='' class='w-100' src='" & Icon & "' />")
                    User.Append("        </div> ")
                    User.Append("   </div> ")
                    User.Append("   <div class='d-flex flex-column' >")
                    User.Append("      <span class='fw-bold text-dark'>" & DR("Name") & "</span>")
                    User.Append("      <span class='text-muted' >" & DR("JobDesc") & "</span>")
                    User.Append("   </div>")
                    User.Append("</div>")

                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Action = Action.ToString,
                        .User = User.ToString
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
    Function Add_Subscriber(pFormCode, pID, pMonitorBy)

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
        SqlCmd.CommandText = "New_FRM_Monitor"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pMonitorBy", pMonitorBy)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Delete_Subscriber(pFormCode, pID, pMonitorBy)

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
        SqlCmd.CommandText = "Del_FRM_Monitor"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pMonitoredBy", pMonitorBy)
        SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Get_History(pFormCode, pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].CreatedDate [SeqNo01] ")
        Query.Append("	,0 [SeqNo02] ")
        Query.Append("	,[A].CreatedBy [Icon01] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	,Format([A].CreatedDate,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,'V2' [Version] ")
        Query.Append("	,[A].Type [Icon02] ")
        Query.Append("	,[A].Type ")
        Query.Append("	,[A].Description ")
        Query.Append("from ")
        Query.Append("	 Mstr_History [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TblName = @pFormCode ")
        Query.Append("   and [A].TblCode = @pID ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("	[A].updated_Date [SeqNo01] ")
        Query.Append("	,[A].seq_no [SeqNo02] ")
        Query.Append("	,[A].updated_by [Icon] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	,Format([A].updated_Date,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,'V1' [Version] ")
        Query.Append("	,[A].field [Icon02] ")
        Query.Append("	,[A].field [Type] ")
        Query.Append("	,[A].change [Description] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_history [A] ")
        Query.Append("   left join employee [B] on [A].updated_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = @pID ")
        Query.Append("order by ")
        Query.Append("  [SeqNo01] ")
        Query.Append("  ,[SeqNo02] ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable
        Dim rowIndex As Integer = 0
        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pFormCode", pFormCode)
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Icon01 As String
                    Dim iconPath As String = HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR("Icon01") & ".png")

                    If File.Exists(iconPath) Then
                        Icon01 = "Assets/media/avatars/" & DR("Icon01") & ".png"
                    Else
                        Icon01 = "Assets/media/avatars/blank.png"
                    End If

                    Dim Class02 As String
                    Dim Icon02 As String

                    If DR("Version") = "V1" And DR("Icon02") = "New Form" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-file-alt"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Assigned To" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Endorsed To" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Relation" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-sitemap"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Upload") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Download") Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Delete") Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Form Monitor" And DR("Description").ToString.Contains("Start Monitored") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V1" And (DR("Icon02") = "Form Monitor" And DR("Description").ToString.Contains("End Monitored")) Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Add Approver") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Remove Approver:") Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Move Approver") Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Note Added" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-comment"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Approved") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Clarify") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Declined") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Reply") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" Then
                        Class02 = "symbol-label bg-warning"
                        Icon02 = "fs-1 text-white las la-pencil-alt"
                    End If

                    If DR("Version") = "V2" And DR("Icon02") = "Form Created:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-file-alt"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Assigned to:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Uploaded a file:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Downloaded a file:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed a file:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added a subscriber:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed a subscriber:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added an approver:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed an approver:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Moved an approver up:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Moved an approver down:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added a note:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-comment"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Approved:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Clarify:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Declined:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Reply:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" Then
                        Class02 = "symbol-label bg-warning"
                        Icon02 = "fs-1 text-white las la-pencil-alt"
                    End If


                    Dim Data As New StringBuilder
                    Data.Append("<div class='d-flex align-items-center'>")
                    Data.Append("       <div class='symbol symbol-30px overflow-hidden me-3' >")
                    Data.Append("           <div class='symbol-label' >")
                    Data.Append("               <img alt='' class='w-100' src='" & Icon01 & "' />")
                    Data.Append("           </div> ")
                    Data.Append("        </div> ")
                    Data.Append("   <div class='d-flex flex-column min-w-200px me-3' >")
                    Data.Append("      <span class='fw-bold text-dark nowrap-200px'>" & DR("Name") & "</span>")
                    Data.Append("      <span class='text-muted nowrap-200px' >" & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3' >")
                    Data.Append("       <div class='" & Class02 & "' >")
                    Data.Append("             <i class='" & Icon02 & "'></i>")
                    Data.Append("       </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-200px me-3' >")
                    Data.Append("      <span class='fw-bold text-dark'>" & DR("Type") & "</span>")
                    Data.Append("      <span class='text-muted' >" & DR("Description") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")

                    RecordList.Add(New With {
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
#End Region

#Region "CRUD - Record"
    Function Add_Record(pDateRequired, pPurchaseType, pDeptCode, pProjType, pPurpose, pSubdCode, pPhase, pBlock, pLot, pCarCode, pCategory01, pCategory02, pActName, pActLocation, pActDate, pChargeCode, pAcctCode, pDivision, pCECode, pMisc, pRemarks, pCreatedBy)

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
        SqlCmd.Parameters.AddWithValue("@pCategory", If(pProjType.ToString.Contains("(Advance PO)") Or pProjType.ToString.Contains("(Stock Request)"), pCategory01, If(pPurpose.ToString.Contains("REPAIR AND MAINTENANCE"), pCategory02, pCategory01)))
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
    Function Update_Record(pID, pDateRequired, pPurchaseType, pDeptCode, pProjType, pPurpose, pSubdCode, pPhase, pBlock, pLot, pCarCode, pCategory01, pCategory02, pActName, pActLocation, pActDate, pChargeCode, pAcctCode, pDivision, pCECode, pMisc, pRemarks, pUpdatedBy)

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
        SqlCmd.CommandText = "Upd_FRM_FRM000010"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
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
        SqlCmd.Parameters.AddWithValue("@pCategory", If(pProjType.ToString.Contains("(Advance PO)") Or pProjType.ToString.Contains("(Stock Request)"), pCategory01, If(pPurpose.ToString.Contains("REPAIR AND MAINTENANCE"), pCategory02, pCategory01)))
        SqlCmd.Parameters.AddWithValue("@pActName", pActName)
        SqlCmd.Parameters.AddWithValue("@pActLocation", pActLocation)
        SqlCmd.Parameters.AddWithValue("@pActDate", pActDate)
        SqlCmd.Parameters.AddWithValue("@pCECode", pCECode)
        SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
        SqlCmd.Parameters.AddWithValue("@pChargeCode", pChargeCode)
        SqlCmd.Parameters.AddWithValue("@pAcctCode", pAcctCode)
        SqlCmd.Parameters.AddWithValue("@pMisc", pMisc)
        SqlCmd.Parameters.AddWithValue("@pDivCode", pDivision)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", pUpdatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Add_Record_OSM_Batch(pID, pItemSrs, pCreatedBy)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_OSM"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Add_Record_OSM_Estimate(pID, pItemSrs, pCreatedBy)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_OSM"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Add_Record_SCM_Batch(pID, pItemSrs, pCreatedBy)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_SCM"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Add_Record_SCM_Estimate(pID, pItemSrs, pCreatedBy)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_SCM"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Add_Record_Return(pID, pItemSrs, pCreatedBy)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl_Return"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Delete_Particular(pID, pSeqNo, pDeletedBy)

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
        SqlCmd.CommandText = "Del_FRM_FRM000010_PRDtl"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pDeletedBy", pDeletedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Add_Particular(pID, pItem, pQty, pUnit, pBdgtAmt, pCreatedBy)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_PRDtl"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItem", pItem)
        SqlCmd.Parameters.AddWithValue("@pQty", CDbl(pQty))
        SqlCmd.Parameters.AddWithValue("@pUnit", pUnit)
        SqlCmd.Parameters.AddWithValue("@pBdgtAmt", CDbl(pBdgtAmt))
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Update_Particular(pID, pSeqNo, pItem, pQty, pUnit, pBdgtAmt, pStatus, pForPO, pForSR, pForCP, pCost, pTotal, pRemarks, pUpdateDBy)

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
        SqlCmd.CommandText = "Upd_FRM_FRM000010_PRDtl"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000010")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pItem", pItem)
        SqlCmd.Parameters.AddWithValue("@pQty", CDbl(pQty))
        SqlCmd.Parameters.AddWithValue("@pUnit", pUnit)
        SqlCmd.Parameters.AddWithValue("@pBdgtAmt", CDbl(pBdgtAmt))
        SqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
        SqlCmd.Parameters.AddWithValue("@pForPO", CDbl(pForPO))
        SqlCmd.Parameters.AddWithValue("@pForSR", CDbl(pForSR))
        SqlCmd.Parameters.AddWithValue("@pForCP", CDbl(pForCP))
        SqlCmd.Parameters.AddWithValue("@pCost", CDbl(pCost))
        SqlCmd.Parameters.AddWithValue("@pTotal", CDbl(pTotal))
        SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
        SqlCmd.Parameters.AddWithValue("@pUpdateDBy", pUpdateDBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {
            .oReturn = "Success"
        })
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function Update_Particular_Tag(pID, pItemSrs)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_Tagging_OSM"
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pResultData", pItemSrs)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Function Return_Particular_Tag(pID, pItemSrs)

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
        SqlCmd.CommandText = "New_FRM_FRM000010_Return_OSM"
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
#End Region

End Class