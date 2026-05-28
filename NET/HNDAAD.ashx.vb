Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Net.PeerToPeer.Collaboration
Imports System.Numerics
Imports System.Reflection.Emit
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Web.WebSockets
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Ajax.Utilities
Imports Microsoft.Owin
Imports Microsoft.Reporting.Map.WebForms.VirtualEarth
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer
Imports Newtonsoft.Json
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Finance.Implementations
Imports WebGrease.Css

Public Class HNDAAD
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim cldc_live As String = "cldc_live"
    Dim calmardblive As String = "calmardblive"
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

            If pFormCode = "FRM000030" And pType = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000030_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000030" And pType = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000030_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "FRM000032" And pType = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000032_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000032" And pType = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000032_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "FRM000042" And pType = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000042_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000042" And pType = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000042_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "AAD040000" And pType = "Get Record - List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                Dim pCode1 = context.Request("pCode1")

                Dim json As String = Me.AAD040000_Get_Record_List(pTblName, pPlaceHolder, pCode1)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Redraw - Hdr" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD040000_Redraw_Hdr(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Get Record - HDR" Then

                Dim pLock = context.Request("pLock")
                Dim pComputation = context.Request("pComputation")
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")
                Dim pCustomer = context.Request("pCustomer")
                Dim pProject = context.Request("pProject")


                Dim json As String = Me.AAD040000_Get_Record_Hdr(pLock, pComputation, pDateFrom, pDateTo, pCustomer, pProject)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Get Info - DTL" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD040000_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Get Record - DTL - Breakdown" Then

                Dim pComputation = context.Request("pComputation")
                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD040000_Get_Record_Dtl_Breakdown(pComputation, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Add Record" Then

                Dim pMode = context.Request("pMode")
                Dim pOffice = context.Request("pOffice")
                Dim pLname = context.Request("pLname")
                Dim pFname = context.Request("pFname")
                Dim pMname = context.Request("pMname")
                Dim pEntry = context.Request("pEntry")
                Dim pAssessment = context.Request("pAssessment")
                Dim pSubd = context.Request("pSubd")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pLottype = context.Request("pLottype")
                Dim pProjecttype = context.Request("pProjecttype")
                Dim pArea = context.Request("pArea")
                Dim pPrice = context.Request("pPrice")
                Dim pHousecost = context.Request("pHousecost")
                Dim pTransactiontype = context.Request("pTransactiontype")
                Dim pYear = context.Request("pYear")
                Dim pDiscount = context.Request("pDiscount")
                Dim pLoan = context.Request("pLoan")
                Dim pSellingprice = context.Request("pSellingprice")
                Dim pTransfer = context.Request("pTransfer")
                Dim pFee = context.Request("pFee")
                Dim pDue = context.Request("pDue")

                Dim json As String = Me.AAD040000_Add_Record(pMode, pOffice, pLname, pFname, pMname, pEntry, pAssessment, pSubd, pPhase, pBlock, pLot, pLottype, pProjecttype, pArea, pPrice, pHousecost, pTransactiontype, pYear, pDiscount, pLoan, pSellingprice, pTransfer, pFee, pDue)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Edit Record" Then

                Dim pMode = context.Request("pMode")
                Dim pID = context.Request("pID")
                Dim pOffice = context.Request("pOffice")
                Dim pLname = context.Request("pLname")
                Dim pFname = context.Request("pFname")
                Dim pMname = context.Request("pMname")
                Dim pEntry = context.Request("pEntry")
                Dim pAssessment = context.Request("pAssessment")
                Dim pSubd = context.Request("pSubd")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pLottype = context.Request("pLottype")
                Dim pProjecttype = context.Request("pProjecttype")
                Dim pArea = context.Request("pArea")
                Dim pPrice = context.Request("pPrice")
                Dim pHousecost = context.Request("pHousecost")
                Dim pTransactiontype = context.Request("pTransactiontype")
                Dim pYear = context.Request("pYear")
                Dim pDiscount = context.Request("pDiscount")
                Dim pLoan = context.Request("pLoan")
                Dim pSellingprice = context.Request("pSellingprice")
                Dim pTransfer = context.Request("pTransfer")
                Dim pFee = context.Request("pFee")
                Dim pDue = context.Request("pDue")

                Dim json As String = Me.AAD040000_Edit_Record(pMode, pID, pOffice, pLname, pFname, pMname, pEntry, pAssessment, pSubd, pPhase, pBlock, pLot, pLottype, pProjecttype, pArea, pPrice, pHousecost, pTransactiontype, pYear, pDiscount, pLoan, pSellingprice, pTransfer, pFee, pDue)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Generate One Page" Then
                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD040000_Generate_OnePage(pID, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD040000" And pType = "Generate Two Pages" Then
                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD040000_Generate_TwoPages(pID, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "AAD050000" And pType = "Get Record - HDR" Then

                Dim pPost = context.Request("pPost")
                Dim pDivision = context.Request("pDivision")

                Dim json As String = Me.AAD050000_Get_Record_Hdr(IIf(pPost = True, 1, 0), pDivision)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD050000" And pType = "Redraw - Hdr" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD050000_Redraw_Hdr(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD050000" And pType = "Post Record" Then

                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pPostedBy = context.Request("pPostedBy")
                Dim pPost = context.Request("pPost")

                Dim json As String = Me.AAD050000_Post_Record(pTrxnNo, pPostedBy, pPost)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD050000" And pType = "Get Info - DTL" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD050000_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD050000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pReleaseDate = context.Request("pReleaseDate")
                Dim pStatus = context.Request("pStatus")
                Dim pQualifyingDate = context.Request("pQualifyingDate")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.AAD050000_Edit_Record(pID, pReleaseDate, pStatus, pQualifyingDate, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AAD050000" And pType = "Generate CES" Then
                Dim pID = context.Request("pID")

                Dim json As String = Me.AAD050000_Generate_CES(pID, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)



            End If

            If pFormCode = "FIN080000" And pType = "Get Class Code" Then

                Dim json As String = Me.FIN080000_Get_Class_Code()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Get Payor Name" Then

                Dim pFind = context.Request("pFind")
                Dim pClassCode = context.Request("pClassCode")

                Dim json As String = Me.FIN080000_Get_Payor_Name(pFind, pClassCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Get Project" Then

                Dim pID = context.Request("pID")
                Dim pProject = context.Request("pProject")

                Dim json As String = Me.FIN080000_Get_Project(pID, pProject)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Get Subdivision" Then

                Dim json As String = Me.FIN080000_Get_Subdivision()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Get Payment Application" Then

                Dim json As String = Me.FIN080000_Get_Payment_Application()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Get Record - HDR" Then

                Dim pPost = context.Request("pPost")
                Dim pClassCode = context.Request("pClassCode")

                Dim json As String = Me.FIN080000_Get_Record_Hdr(IIf(pPost = True, 1, 0), pClassCode)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Redraw - Hdr" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.FIN080000_Redraw_Hdr(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Post Record" Then

                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pPostedBy = context.Request("pPostedBy")

                Dim json As String = Me.FIN080000_Post_Record(pTrxnNo, pPostedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Get Info - DTL" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.FIN080000_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)


            ElseIf pFormCode = "FIN080000" And pType = "Add Record" Then

                Dim pTransactionDate = context.Request("pTransactionDate")
                Dim pClassCode = context.Request("pClassCode")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pPayorName = context.Request("pPayorName")
                Dim pProjCode = context.Request("pProjCode")
                Dim pPhaseNo = context.Request("pPhaseNo")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pRemarks = context.Request("pRemarks")
                Dim pRmtCode = context.Request("pRmtCode")
                Dim pAuditUser = CIIS_EmpCode
                Dim pAuditDate = context.Request("pAuditDate")
                Dim pPreparedBy = CIIS_EmpCode

                Dim json As String = Me.FIN080000_Add_Record(pTransactionDate, pClassCode, pAcctNo, pPayorName, pProjCode, pPhaseNo, pBlock, pLot, pRemarks, pRmtCode, pAuditUser, pAuditDate, pPreparedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pClassCode = context.Request("pClassCode")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pPayorName = context.Request("pPayorName")
                Dim pProjCode = context.Request("pProjCode")
                Dim pPhaseNo = context.Request("pPhaseNo")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pRemarks = context.Request("pRemarks")
                Dim pRmtCode = context.Request("pRmtCode")
                Dim pPreparedBy = CIIS_EmpCode

                Dim json As String = Me.FIN080000_Edit_Record(pID, pClassCode, pAcctNo, pPayorName, pProjCode, pPhaseNo, pBlock, pLot, pRemarks, pRmtCode, pPreparedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Get Record - DTL - Application" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.FIN080000_Get_Record_Dtl_Application(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Redraw - DTL - Application" Then

                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pApplication = context.Request("pApplication")

                Dim json As String = Me.FIN080000_Redraw_Dtl_Application(pTrxnNo, pApplication)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Add Application" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pApplication = context.Request("pApplication")
                Dim pPaymentDate = context.Request("pPaymentDate")
                Dim pAmount = context.Request("pAmount")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN080000_Add_Application(pAcctNo, pTrxnNo, pApplication, pPaymentDate, pAmount, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN080000" And pType = "Edit Application" Then

                Dim pID = context.Request("pID")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pApplication = context.Request("pApplication")
                Dim pAmount = context.Request("pAmount")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN080000_Edit_Application(pID, pAcctNo, pTrxnNo, pApplication, pAmount, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "FIN090000" And pType = "Get Branch" Then

                Dim json As String = Me.FIN090000_Get_BranchCode()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)


            ElseIf pFormCode = "FIN090000" And pType = "Get Bank" Then

                Dim json As String = Me.FIN090000_Get_Bank()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Get Record - HDR" Then

                Dim pPost = context.Request("pPost")
                Dim pBranch = context.Request("pBranch")
                Dim pDocNoFrom = context.Request("pDocNoFrom")
                Dim pDocNoTo = context.Request("pDocNoTo")
                Dim pDocDateFrom = context.Request("pDocDateFrom")
                Dim pDocDateTo = context.Request("pDocDateTo")
                Dim pAuditUser = context.Request("pAuditUser")

                Dim json As String = Me.FIN090000_Get_Record_Hdr(pBranch, IIf(pPost = True, 1, 0), pDocNoFrom, pDocNoTo, pDocDateFrom, pDocDateTo, pAuditUser)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Get Mode" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.FIN090000_Get_Mode(pAcctNo, pTrxnNo, pSeqNo)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Redraw - Hdr" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.FIN090000_Redraw_Hdr(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Post Record" Then

                Dim pDocNo = context.Request("pDocNo")
                Dim pPostedBy = context.Request("pPostedBy")

                Dim json As String = Me.FIN090000_Post_Record(pDocNo, pPostedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate CI" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_CI(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate SOR" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_SOR(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate RORMN" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_RORMN(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate SORMN" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_SORMN(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate RORSM" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_RORSM(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate SORSM" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_SORSM(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate RORLO" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_RORLO(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate SORLO" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_SORLO(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate RORBT" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_RORBT(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate SORBT" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_SORBT(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate RORSO" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_RORSO(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate SORSO" Then
                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_SORSO(pID, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate PL" Then
                Dim pBranch = context.Request("pBranch")
                Dim pUser = CIIS_EmpCode
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_PL(pBranch, pUser, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Generate PLA" Then
                Dim pBranch = context.Request("pBranch")
                Dim pUser = CIIS_EmpCode
                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090000_Generate_PLA(pBranch, pUser, pDate, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Get Info - DTL" Then

                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")
                Dim pAcctNo = context.Request("pAcctNo")

                Dim json As String = Me.FIN090000_Get_Info_Dtl(pID, pDate, pAcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Get Application - DTL" Then

                Dim pID = context.Request("pID")
                Dim pDate = context.Request("pDate")
                Dim pAcctNo = context.Request("pAcctNo")

                Dim json As String = Me.FIN090000_Get_Application_Dtl(pID, pDate, pAcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Get Record Add" Then

                Dim pBranch = context.Request("pBranch")

                Dim json As String = Me.FIN090000_Get_Record_Add(pBranch)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Add Record" Then

                Dim pIsRegularOR = context.Request("pIsRegularOR")
                Dim pBranch = context.Request("pBranch")
                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.FIN090000_Add_Record(pIsRegularOR, pBranch, pTrxnNo, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pDocNo = context.Request("pDocNo")
                Dim pDocDate = context.Request("pDocDate")
                Dim pTransactionNumber = context.Request("pTransactionNumber")
                Dim pParticular = context.Request("pParticular")
                Dim pIsCash = context.Request("pIsCash")
                Dim pCashAmt = context.Request("pCashAmt")
                Dim pIsCheck = context.Request("pIsCheck")
                Dim pCheckAmt = context.Request("pCheckAmt")
                Dim pIsRem = context.Request("pIsRem")
                Dim pRmtCode = context.Request("pRmtCode")
                Dim pBankCode = context.Request("pBankCode")
                Dim pPRDate = context.Request("pPRDate")
                Dim pRemAmt = context.Request("pRemAmt")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090000_Edit_Record(pID, pDocNo, pDocDate, pTransactionNumber, pParticular, IIf(pIsCash = True, 1, 0), pCashAmt, IIf(pIsCheck = True, 1, 0), pCheckAmt, IIf(pIsRem = True, 1, 0), pRmtCode, pBankCode, pPRDate, pRemAmt, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Get Check" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.FIN090000_Get_Check(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Add Check" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pORNo = context.Request("pORNo")
                Dim pProjCode = context.Request("pProjCode")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pAcctname = context.Request("pAcctname")
                Dim pBank = context.Request("pBank")
                Dim pCheckNo = context.Request("pCheckNo")
                Dim pCheckDate = context.Request("pCheckDate")
                Dim pCheckAmt = context.Request("pCheckAmt")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090000_Add_Check(pAcctNo, pTrxnNo, pSeqNo, pORNo, pProjCode, pPhase, pBlock, pLot, pAcctname, pBank, pCheckNo, pCheckDate, pCheckAmt, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Update Check" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pBank = context.Request("pBank")
                Dim pCheckNo = context.Request("pCheckNo")
                Dim pCheckDate = context.Request("pCheckDate")
                Dim pCheckAmt = context.Request("pCheckAmt")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090000_Upd_Check(pAcctNo, pTrxnNo, pSeqNo, pBank, pCheckNo, pCheckDate, pCheckAmt, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Delete Check" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pTrxnNo = context.Request("pTrxnNo")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.FIN090000_Del_Check(pAcctNo, pTrxnNo, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090000" And pType = "Update OR" Then

                Dim pTotalAmount = context.Request("pTotalAmount")
                Dim pORNo = context.Request("pORNo")
                Dim pORDate = context.Request("pORDate")

                Dim json As String = Me.FIN090000_Upd_OR(pTotalAmount, pORNo, pORDate)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "FIN090100" And pType = "Cashiering Tools - Payment Order" Then

                Dim pDate = context.Request("pDate")

                Dim json As String = Me.FIN090100_Get_Payment_Order(pDate)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Cashiering Tools - New PDC Payment" Then

                Dim pCheckSrs = context.Request("pCheckSrs")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090100_New_Payment_Order(pCheckSrs, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Cashiering Tools - Remittance" Then

                Dim json As String = Me.FIN090100_Get_Remittance()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Remittance Class" Then

                Dim json As String = Me.FIN090100_Remittance_Class()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Remittance Payor" Then

                Dim pClass = context.Request("pClass")

                Dim json As String = Me.FIN090100_Remittance_Payor(pClass)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Remittance - Application" Then

                Dim json As String = Me.FIN090100_Remittance_Application()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Cashiering Tools - Add Remittance" Then

                Dim pRmtCode = context.Request("pRmtCode")
                Dim pClassCode = context.Request("pClassCode")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pAcctName = context.Request("pAcctName")
                Dim pPmtType = context.Request("pPmtType")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090100_Add_Remittance(pRmtCode, pClassCode, pAcctNo, pAcctName, pPmtType, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Cashiering Tools - Get OR Settings" Then

                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090100_Get_OR(pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Cashiering Tools - Update OR/SOR" Then

                Dim pORNo = context.Request("pORNo")
                Dim pSORNo = context.Request("pSORNo")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090100_Edit_OR_SOR(pORNo, pSORNo, pAuditUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Cashiering Tools - OR Reversal" Then

                Dim pDocNo = context.Request("pDocNo")

                Dim json As String = Me.FIN090100_Get_OR_Reversal(pDocNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FIN090100" And pType = "Cashiering Tools - Reverse OR Record" Then

                Dim pDocNo = context.Request("pDocNo")
                Dim pDocDate = context.Request("pDocDate")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pReason = context.Request("pReason")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.FIN090100_OR_Reverse_Record(pDocNo, pDocDate, pAcctNo, pReason, pAuditUser)
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

#End Region

#Region "FRM000030"

    Private Function FRM000030_Get_Buyer_List(Account)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Account & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Account & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Account & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get total task

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

                    Dim Bullet As New StringBuilder
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectBuyer('" & DR("AcctNo") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("AcctName") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("AcctNo") & " " & DR("Project") & "</span>")
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

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000030_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].LotCode ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,isnull(FORMAT([A].DOE, 'MM/dd/yyyy'),'') [DOE] ")
        Query.Append("   ,isnull(FORMAT([A].TCPNet, 'N2'),'') [TCPNet] ")
        Query.Append("   ,isnull((select top 1 [I].ContactNo from calmardbLive.dbo.mstr_ContactNos [I] where [I].AcctNo = [A].AcctNo and [I].NoCode = 1), '-') [MobileNo] ")
        Query.Append("   ,isnull([A].eMail, '-') [Email] ")
        Query.Append("   ,isnull((select mstr_HouseModels.ModelName from calmardbLive.dbo.ICR_Buyers left join calmardbLive.dbo.mstr_HouseModels on ICR_Buyers.ModelCode = mstr_HouseModels.ModelCode where ICR_Buyers.AcctNo = [A].AcctNo),'N/A') [ModelHouse] ")
        Query.Append("   ,isnull((select sum(LotArea) from calmardbLive.dbo.mstr_LotsInventory where AcctNo = [A].AcctNo),0) [LotArea] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Account [A] ")
        Query.Append("where ")
        Query.Append("	 [A].AcctNo like '%" & AcctNo & "%' ")
        'get total task

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName"),
                        .LotCode = DR("LotCode"),
                        .Project = DR("Project"),
                        .DOE = DR("DOE"),
                        .TCPNet = DR("TCPNet"),
                        .MobileNo = DR("MobileNo"),
                        .Email = DR("Email"),
                        .ModelHouse = DR("ModelHouse"),
                        .LotArea = DR("LotArea")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordInfo))
        'display 

    End Function

#End Region

#Region "FRM000032"

    Private Function FRM000032_Get_Buyer_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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

                    Dim Bullet As New StringBuilder
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectBuyer('" & DR("AcctNo") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("AcctName") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("AcctNo") & " " & DR("Project") & "</span>")
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

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000032_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].TCTNo ")
        Query.Append("   ,[A].TCPNet ")
        Query.Append("   ,isnull((select top 1 [B].DocDate from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = [A].AcctNo and [B].TRCode in ('RF','DP','MA') order by [B].DocDate desc),'') [TCPDatePaid] ")
        Query.Append("   ,([A].TCPNet * 0.10) [PF] ")
        Query.Append("   ,isnull((select top 1 cast(NULLIF([B].DocDate,'') AS DATE) from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = [A].AcctNo and [B].TRCode in ('RF','DP','MA') order by [B].DocDate desc),'') [PFDatePaid] ")
        Query.Append("   ,isnull((select top 1 [B].DocNo from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = [A].AcctNo and [B].TRCode in ('RF','DP','MA') order by [B].DocDate desc),'') [PFORNo] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Account [A] ")
        Query.Append("where ")
        Query.Append("	 [A].AcctNo = '" & AcctNo & "' ")
        'get total task

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                    .AcctNo = DR("AcctNo"),
                    .AcctName = DR("AcctName"),
                    .Project = DR("Project"),
                    .TCTNo = DR("TCTNo"),
                    .TCPNet = Format(CDbl(DR("TCPNet")), "N2"),
                    .TCPDatePaid = Format(CDate(DR("TCPDatePaid")), "MM/dd/yyyy"),
                    .PF = Format(CDbl(DR("PF")), "N2"),
                    .PFDatePaid = Format(CDate(DR("PFDatePaid")), "MM/dd/yyyy"),
                    .PFORNo = DR("PFORNo")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordInfo))
        'display 

    End Function

#End Region

#Region "FRM000042"

    Private Function FRM000042_Get_Buyer_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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

                    Dim Bullet As New StringBuilder
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectBuyer('" & DR("AcctNo") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("AcctName") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("AcctNo") & " " & DR("Project") & "</span>")
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

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000042_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].TCTNo ")
        Query.Append("   ,[A].TCPNet ")
        Query.Append("   ,isnull((select top 1 [B].DocDate from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = [A].AcctNo and [B].TRCode in ('RF','DP','MA') order by [B].DocDate desc),'') [TCPDatePaid] ")
        Query.Append("   ,([A].TCPNet * 0.10) [PF] ")
        Query.Append("   ,isnull((select top 1 [B].DocNo from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = [A].AcctNo and [B].TRCode in ('RF','DP','MA') order by [B].DocDate desc),'') [PFORNo] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Account [A] ")
        Query.Append("where ")
        Query.Append("	 [A].AcctNo = '" & AcctNo & "' ")
        'get total task

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                    .AcctNo = DR("AcctNo"),
                    .AcctName = DR("AcctName"),
                    .Project = DR("Project"),
                    .TCTNo = DR("TCTNo"),
                    .TCPNet = Format(CDbl(DR("TCPNet")), "N2"),
                    .TCPDatePaid = Format(CDate(DR("TCPDatePaid")), "MM/dd/yyyy"),
                    .PF = Format(CDbl(DR("PF")), "N2"),
                    .PFORNo = DR("PFORNo")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordInfo))
        'display 

    End Function

#End Region

#Region "AAD040000"

    Function AAD040000_Get_Record_List(pTblName, pPlaceHolder, pCode1)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Mstr_Subdivision" Then
            Query.Append("select ")
            Query.Append("    '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("    code [ID] ")
            Query.Append("   ,abbr [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,abbr [Order2] ")
            Query.Append("from ")
            Query.Append("    cldc_live_acc.dbo.subdivision a ")
            Query.Append("where ")
            Query.Append("    Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Phase(Subd)" Then
            Query.Append("select ")
            Query.Append("    '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("    code [ID] ")
            Query.Append("   ,description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,description [Order2] ")
            Query.Append("from ")
            Query.Append("    cldc_live_acc.dbo.phase a ")
            Query.Append("where ")
            Query.Append("    scode = '" & pCode1 & "' ")
            Query.Append("    and Lock = 1 ")
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

    Function AAD040000_Get_Record_Hdr(pLock, pComputation, pDateFrom, pDateTo, pCustomer, pProject)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("    processing_fee.code [ID], ")
        Query.Append("    (CASE processing_fee.office ")
        Query.Append("        WHEN 0 THEN 'CALMAR' ")
        Query.Append("        WHEN 1 THEN 'COSMO' ")
        Query.Append("    END) [Computation], ")
        Query.Append("    pdate [Date], ")
        Query.Append("    processing_fee.fullname [Customer], ")
        Query.Append("    subdivision.abbr + ' ' + phase.description + ' B' + processing_fee.block + ' L' + processing_fee.lot [Project], ")
        Query.Append("    processing_fee.updated_by, ")
        Query.Append("    processing_fee.lock_by, ")
        Query.Append("    ISNULL(processing_fee.lock, 0) [Lock] ")
        Query.Append("FROM ")
        Query.Append("    cldc_live.dbo.processing_fee ")
        Query.Append("    LEFT JOIN subdivision ON processing_fee.scode = subdivision.code ")
        Query.Append("    LEFT JOIN phase ON processing_fee.pcode = phase.code ")
        Query.Append("WHERE ")
        Query.Append("    processing_fee.lock = " & IIf(pLock = True, 1, 0) & " ")
        If pComputation <> "" Then
            Query.Append(" AND (CASE processing_fee.office WHEN 0 THEN 'CALMAR' WHEN 1 THEN 'COSMO' END) = '" & pComputation & "' ")
        End If
        If pDateFrom <> "" Or pDateTo <> "" Then
            Query.Append(" AND pdate >= '" & pDateFrom & "' AND pdate <= '" & pDateTo & "' ")
        End If
        If pCustomer <> "" Then
            Query.Append(" AND processing_fee.fullname LIKE '%" & pCustomer & "%' ")
        End If
        If pProject <> "" Then
            Query.Append(" AND (subdivision.abbr + ' ' + phase.description + ' B' + processing_fee.block + ' L' + processing_fee.lot) LIKE '%" & pProject & "%' ")
        End If
        Query.Append(" ORDER BY Customer, [Date] ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AAD040100-DTL-" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Computation = If(IsDBNull(DR("Computation")), "", DR("Computation").ToString()),
                        .Date = If(IsDBNull(DR("Date")), "", Convert.ToDateTime(DR("Date")).ToString("MM/dd/yyyy")),
                        .Customer = If(IsDBNull(DR("Customer")), "", DR("Customer").ToString()),
                        .Project = If(IsDBNull(DR("Project")), "", DR("Project").ToString())
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

    Function AAD040000_Redraw_Hdr(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("    processing_fee.code [ID], ")
        Query.Append("    (CASE processing_fee.office ")
        Query.Append("        WHEN 0 THEN 'CALMAR' ")
        Query.Append("        WHEN 1 THEN 'COSMO' ")
        Query.Append("    END) [Computation], ")
        Query.Append("    pdate [Date], ")
        Query.Append("    processing_fee.fullname [Customer], ")
        Query.Append("    subdivision.abbr + ' ' + phase.description + ' B' + processing_fee.block + ' L' + processing_fee.lot [Project], ")
        Query.Append("    processing_fee.updated_by, ")
        Query.Append("    processing_fee.lock_by, ")
        Query.Append("    ISNULL(processing_fee.lock, 0) [Lock] ")
        Query.Append("FROM ")
        Query.Append("    cldc_live.dbo.processing_fee ")
        Query.Append("    LEFT JOIN subdivision ON processing_fee.scode = subdivision.code ")
        Query.Append("    LEFT JOIN phase ON processing_fee.pcode = phase.code ")
        Query.Append("WHERE ")
        Query.Append("   processing_fee.code = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AAD040100-DTL-" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Computation = If(IsDBNull(DR("Computation")), "", DR("Computation").ToString()),
                        .Date = If(IsDBNull(DR("Date")), "", Convert.ToDateTime(DR("Date")).ToString("MM/dd/yyyy")),
                        .Customer = If(IsDBNull(DR("Customer")), "", DR("Customer").ToString()),
                        .Project = If(IsDBNull(DR("Project")), "", DR("Project").ToString())
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

    Function AAD040000_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("    processing_fee.code [ID], ")
        Query.Append("    (CASE processing_fee.office ")
        Query.Append("        WHEN 0 THEN 'CALMARLAND DEVELOPMENT CORPORATION' ")
        Query.Append("        WHEN 1 THEN 'Cosmopolitan Communities Incorporated' ")
        Query.Append("    END) [Computation], ")
        Query.Append("    processing_fee.office [Office], ")
        Query.Append("    processing_fee.lname [LastName], ")
        Query.Append("    processing_fee.fname [FirstName], ")
        Query.Append("    processing_fee.mname [MiddleName], ")
        Query.Append("    format(processing_fee.entry_date, 'MM/dd/yyyy') [DateEntry], ")
        Query.Append("    format(processing_fee.pdate, 'MM/dd/yyyy') [AssessmentDate], ")
        Query.Append("    subdivision.abbr [Subdivision], ")
        Query.Append("    processing_fee.scode [SCode], ")
        Query.Append("    phase.description [Phase], ")
        Query.Append("    processing_fee.pcode [PCode], ")
        Query.Append("    processing_fee.block [Block], ")
        Query.Append("    processing_fee.lot [Lot], ")
        Query.Append("    processing_fee.ltype [LotType], ")
        Query.Append("    processing_fee.ptype [ProjectType], ")
        Query.Append("    format(processing_fee.area, 'N2') [Area], ")
        Query.Append("    format(processing_fee.price, 'N2') [Price], ")
        Query.Append("    format(processing_fee.hcost, 'N2') [HouseCost], ")
        Query.Append("    processing_fee.type [TransactionType], ")
        Query.Append("    processing_fee.nyear [Years], ")
        Query.Append("    format(processing_fee.discount, 'N2') [Discount], ")
        Query.Append("    format(processing_fee.lvalue, 'N2') [LoanValue], ")
        Query.Append("    format(processing_fee.sprice, 'N2') [SellingPrice], ")
        Query.Append("    format(processing_fee.transfer, 'N2') [Transfer], ")
        Query.Append("    format(processing_fee.mfee, 'N2') [Membership], ")
        Query.Append("    format(processing_fee.mdues, 'N2') [Maintenance], ")
        Query.Append("    processing_fee.updated_by [UpdatedBy], ")
        Query.Append("    processing_fee.lock_by [LockedBy], ")
        Query.Append("    isnull(processing_fee.lock,0) [Lock], ")
        Query.Append("    format(processing_fee.updated_date,'MM/dd/yyyy hh:mm tt') [UpdatedDate], ")
        Query.Append("    updater.fullname [UpdatedByName], ")
        Query.Append("    (case when isnull(processing_fee.lock,0) = 1 then locker.fullname else '' end) [LockedByName], ")
        Query.Append("    (case when isnull(processing_fee.lock,0) = 1 then format(processing_fee.lock_date,'MM/dd/yyyy hh:mm tt') else '' end) [LockedDate], ")
        Query.Append("    (case when processing_fee.lock = 0 then 'New' when processing_fee.lock = 1 then 'Locked' when processing_fee.lock is null then 'Unlocked' end) [RecordStatus] ")
        Query.Append("FROM ")
        Query.Append("    cldc_live.dbo.processing_fee ")
        Query.Append("    LEFT JOIN cldc_live_acc.dbo.subdivision ON processing_fee.scode = subdivision.code ")
        Query.Append("    LEFT JOIN cldc_live_acc.dbo.phase ON processing_fee.pcode = phase.code ")
        Query.Append("    LEFT JOIN cldc_live_acc.dbo.employee AS updater ON processing_fee.updated_by = updater.emp_no ")
        Query.Append("    LEFT JOIN cldc_live_acc.dbo.employee AS locker ON processing_fee.lock_by = locker.emp_no ")
        Query.Append("WHERE ")
        Query.Append("    processing_fee.code = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .Computation = DR("Computation"),
                        .Office = DR("Office"),
                        .LastName = DR("LastName"),
                        .FirstName = DR("FirstName"),
                        .MiddleName = DR("MiddleName"),
                        .DateEntry = DR("DateEntry"),
                        .AssessmentDate = DR("AssessmentDate"),
                        .Subdivision = DR("Subdivision"),
                        .SCode = DR("SCode"),
                        .Phase = DR("Phase"),
                        .PCode = DR("PCode"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .LotType = DR("LotType"),
                        .ProjectType = DR("ProjectType"),
                        .Area = DR("Area"),
                        .Price = DR("Price"),
                        .HouseCost = DR("HouseCost"),
                        .TransactionType = DR("TransactionType"),
                        .Years = DR("Years"),
                        .Discount = DR("Discount"),
                        .LoanValue = DR("LoanValue"),
                        .SellingPrice = DR("SellingPrice"),
                        .Transfer = DR("Transfer"),
                        .Membership = DR("Membership"),
                        .Maintenance = DR("Maintenance"),
                        .UpdatedBy = DR("UpdatedBy"),
                        .LockedBy = DR("LockedBy"),
                        .Lock = DR("Lock"),
                        .RecordStatus = DR("RecordStatus"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

    Function AAD040000_Get_Record_Dtl_Breakdown(pComputation, pID)

        'query
        Dim Query As New StringBuilder
        If pComputation = "CALMARLAND DEVELOPMENT CORPORATION" Then
            Query.Append("select ")
            Query.Append(" 1 [seq_no], 1 [bold], 'BIR REGISTRATION' [description], isnull((select bir from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append(" union select 2, 0, '&nbsp;', null ")
            Query.Append(" union select 3, 0, 'Certification Fee', isnull((select bir_cf from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 4, 0, 'Cert. True Copy No Imp. & PRF', isnull((select bir_ct from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 5, 0, 'Cert. True Copy of Title', isnull((select bir_ctc_tct from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 6, 0, 'Documentary Stamp', isnull((select bir_ds from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 7, 0, 'Doc. Stamp and TIN Verification', isnull((select bir_dsv from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 8, 0, 'Documentary Stamp Tax', isnull((select bir_dst from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 9, 0, 'Expanded Withholding Tax', isnull((select bir_ewt from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 10, 0, 'Facilitation Fee', isnull((select bir_ff from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 11, 0, 'Promissory Note', isnull((select bir_pn from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 12, 0, 'Tax Clearance', isnull((select bir_tc from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 13, 0, 'Transfer Cert. of Title Traceback', isnull((select bir_tct from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 14, 0, '&nbsp;', null ")
            Query.Append(" union select 15, 1, 'REGISTER OF DEEDS', isnull((select rod from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 16, 0, '&nbsp;', null ")
            Query.Append(" union select 17, 1, '   Regular', isnull((select reg_ds + reg_ef + reg_it + reg_i + reg_lrf + reg_ras + reg_spo + reg_tct + reg_tt from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 18, 0, '   Tax Clearance', isnull((select reg_ds from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 19, 0, '   Entry Fee', isnull((select reg_ef from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 20, 0, '   IT Fee', isnull((select reg_it from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 21, 0, '   Issuance Fee', isnull((select reg_i from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 22, 0, '   Legal Research Fee', isnull((select reg_lrf from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 23, 0, '   Resolution / Annotation', isnull((select reg_ras from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 24, 0, '   Special Power of Attoney', isnull((select reg_spo from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 25, 0, '   TCT Transfer Fee / Reg. Fee', isnull((select reg_tct from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 26, 0, '   Transfer Tax', isnull((select reg_tt from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 27, 0, '&nbsp;', null ")
            Query.Append(" union select 28, 1, '   Loan', isnull((select reg_cancel + reg_br + reg_e + reg_dst + reg_mf + reg_ff + reg_s + reg_sop from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 29, 0, '   Cancellation of Deed of Assign.', isnull((select reg_cancel from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 30, 0, '   Board Resolution', isnull((select reg_br from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 31, 0, '   Entry', isnull((select reg_e from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 32, 0, '   Documentary Stamp Tax', isnull((select reg_dst from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 33, 0, '   Mortgage Fee', isnull((select reg_mf from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 34, 0, '   Facilitation Fee (Annotation)', isnull((select reg_ff from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 35, 0, '   Stamp', isnull((select reg_s from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 36, 0, '   SOP / Documentary Stamp', isnull((select reg_sop from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 37, 0, '&nbsp;', null ")
            Query.Append(" union select 38, 1, 'LOAN TAXES & FEES', isnull((select tdf from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 39, 0, '&nbsp;', null ")
            Query.Append(" union select 40, 0, 'Facilitation Fee', isnull((select td_ff from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 41, 0, 'Issuance Fee', isnull((select td_if from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 42, 0, 'Real Property Tax (Lot)', isnull((select td_rpt from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 43, 0, 'Real Property Tax (House)', isnull((select td_rpth from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 44, 0, 'TD Transfer and Transfer Tax Fee', isnull((select td_e from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 45, 0, 'Transfer Fee', isnull((select td_tf from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 46, 0, '&nbsp;', null ")
            Query.Append(" union select 47, 1, 'OTHER FEES', isnull((select other from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 48, 0, '&nbsp;', null ")
            Query.Append(" union select 49, 0, 'Additional Notarial Fee', isnull((select td_anf from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 50, 0, 'Location Plan', isnull((select td_lp from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 51, 0, 'Miscellaneous', isnull((select td_m from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 52, 0, 'Notarial Fee (DOAS)', isnull((select td_nf from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 53, 0, 'Solid Waste Mangement', isnull((select td_waste from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 54, 0, '&nbsp;', null ")
            Query.Append(" union select 55, 1, 'Penalty', isnull((select RPTPenalty from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" union select 56, 0, '&nbsp;', null ")
            Query.Append(" union select 57, 1, 'PROCESSING FEE', isnull((select ptotal from processing_fee where code = '" & pID & "'),0) ")
            Query.Append(" order by [seq_no] ")
        ElseIf pComputation = "Cosmopolitan Communities Incorporated" Then
            Query.Append("select 1 [seq_no], 1 [bold], 'BIR REGISTRATION' [description], isnull((select bir from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 2 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 3 [seq_no], 1 [bold], '   Regular' [description], isnull((select bir_ctc_tct + bir_tc + bir_ct + bir_ff + bir_ewt + bir_dst + bir_cf + bir_ds + bir_dsv from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 4 [seq_no], 0 [bold], '   No-Improvements' [description], isnull((select bir_ctc_tct from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 5 [seq_no], 0 [bold], '   No-Imp. Documentary Stamp' [description], isnull((select bir_tc from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 6 [seq_no], 0 [bold], '   Tax Declaration' [description], isnull((select bir_ct from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 7 [seq_no], 0 [bold], '   Tax Dec. Documentary Stamp' [description], isnull((select bir_ff from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 8 [seq_no], 0 [bold], '   Expanded Withholding Tax' [description], isnull((select bir_ewt from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 9 [seq_no], 0 [bold], '   Documentary Stamp Tax' [description], isnull((select bir_dst from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 10 [seq_no], 0 [bold], '   Certification Fee' [description], isnull((select bir_cf from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 11 [seq_no], 0 [bold], '   Documentary Stamp' [description], isnull((select bir_ds from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 12 [seq_no], 0 [bold], '   Documentation Expense' [description], isnull((select bir_dsv from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 13 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 14 [seq_no], 1 [bold], '   Loan' [description], isnull((select bir_tct + reg_ff + reg_cancel + reg_dst + reg_mf from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 15 [seq_no], 0 [bold], '   Cert. True Copy of Title' [description], isnull((select bir_tct from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 16 [seq_no], 0 [bold], '   Promissory Note' [description], isnull((select reg_ff from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 17 [seq_no], 0 [bold], '   Tax Clearance' [description], isnull((select reg_cancel from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 18 [seq_no], 0 [bold], '   Transfer Cert. of Title Traceback' [description], isnull((select reg_dst from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 19 [seq_no], 0 [bold], '   Documentary Stamp' [description], isnull((select reg_mf from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 20 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 21 [seq_no], 1 [bold], 'REGISTER OF DEEDS' [description], isnull((select rod from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 22 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 23 [seq_no], 1 [bold], '   Regular' [description], isnull((select reg_ef + reg_l + reg_tt + reg_e + reg_i + reg_it + reg_ras + reg_lrf + reg_br + reg_tct + reg_ds + reg_spo + reg_s from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 24 [seq_no], 0 [bold], '   Entry Fee' [description], isnull((select reg_ef from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 25 [seq_no], 0 [bold], '   Judicial Form Fee' [description], isnull((select reg_l from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 26 [seq_no], 0 [bold], '   IT Service Registration Fee' [description], isnull((select reg_tt from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 27 [seq_no], 0 [bold], '   IT Service Issuance Fee' [description], isnull((select reg_e from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 28 [seq_no], 0 [bold], '   Issuance Fee' [description], isnull((select reg_i from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 29 [seq_no], 0 [bold], '   Annotation' [description], isnull((select reg_it from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 30 [seq_no], 0 [bold], '   Inscription' [description], isnull((select reg_ras from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 31 [seq_no], 0 [bold], '   Legal Research Fee' [description], isnull((select reg_lrf from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 32 [seq_no], 0 [bold], '   Secretary(s) Certificate' [description], isnull((select reg_br from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 33 [seq_no], 0 [bold], '   Registration Fee' [description], isnull((select reg_tct from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 34 [seq_no], 0 [bold], '   Documentation Expense' [description], isnull((select reg_ds from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 35 [seq_no], 0 [bold], '   Documentary Stamp' [description], isnull((select reg_spo from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 36 [seq_no], 0 [bold], '   Registration Fee (per Document)' [description], isnull((select reg_s from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 37 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 38 [seq_no], 1 [bold], '   Loan' [description], isnull((select reg_sop + t1 + t2 + t3 + t4 + t5 + t6 + t7 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 39 [seq_no], 0 [bold], '   Cancellation of Deed of Assign.' [description], isnull((select reg_sop from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 40 [seq_no], 0 [bold], '   Board Resolution' [description], isnull((select t1 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 41 [seq_no], 0 [bold], '   Entry' [description], isnull((select t2 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 42 [seq_no], 0 [bold], '   Documentary Stamp Tax' [description], isnull((select t3 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 43 [seq_no], 0 [bold], '   Mortgage Fee' [description], isnull((select t4 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 44 [seq_no], 0 [bold], '   Facilitation Fee (Annotation)' [description], isnull((select t5 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 45 [seq_no], 0 [bold], '   Stamp' [description], isnull((select t6 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 46 [seq_no], 0 [bold], '   SOP / Documentary Stamp' [description], isnull((select t7 from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 47 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 48 [seq_no], 1 [bold], 'LOAN TAXES & FEES' [description], isnull((select tdf from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 49 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 50 [seq_no], 0 [bold], 'Transfer Tax Fee' [description], isnull((select td_e from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 51 [seq_no], 0 [bold], 'Tax Declaration Transfer Fee' [description], isnull((select td_if from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 52 [seq_no], 0 [bold], 'Secretary(s) Certificate' [description], isnull((select td_ff from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 53 [seq_no], 0 [bold], 'Document Stamp' [description], isnull((select td_rpt from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 54 [seq_no], 0 [bold], 'Property Tax (Lot)' [description], isnull((select td_rpth from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 55 [seq_no], 0 [bold], 'Property Tax (House)' [description], isnull((select bir_pn from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 56 [seq_no], 0 [bold], 'Documentation Expense' [description], isnull((select td_ff from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 57 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 58 [seq_no], 1 [bold], 'OTHER FEES' [description], isnull((select other from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 59 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 60 [seq_no], 0 [bold], 'Additional Notarial Fee' [description], isnull((select td_anf from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 61 [seq_no], 0 [bold], 'Notarial Fee' [description], isnull((select td_nf from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 62 [seq_no], 0 [bold], 'Location Plan' [description], isnull((select td_lp from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 63 [seq_no], 0 [bold], 'Miscellaneous' [description], isnull((select td_m from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 64 [seq_no], 0 [bold], 'Solid Waste Mangement' [description], isnull((select td_waste from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 65 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 66 [seq_no], 1 [bold], 'Penalty' [description], isnull((select RPTPenalty from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("union select 67 [seq_no], 0 [bold], '&nbsp;' [description], null [amount] ")
            Query.Append("union select 68 [seq_no], 1 [bold], 'PROCESSING FEE' [description], isnull((select ptotal from processing_fee where code = '" & pID & "'),0) [amount] ")
            Query.Append("order by [seq_no]")
        End If

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & cldc_live & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("seq_no"),
                        .Bold = DR("bold"),
                        .Description = DR("description"),
                        .Amount = If(IsDBNull(DR("amount")), "", Format(CDbl(DR("amount")), "N2"))
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

    Function AAD040000_Add_Record(pMode, pOffice, pLname, pFname, pMname, pEntry, pAssessment, pSubd, pPhase, pBlock, pLot, pLottype, pProjecttype, pArea, pPrice, pHousecost, pTransactiontype, pYear, pDiscount, pLoan, pSellingprice, pTransfer, pFee, pDue)

        'variables
        Dim RecordList As New List(Of Object)()
        Dim pCode As String = ""
        'variables

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            ConStr.Open()

            'newcode
            Using cmd As New SqlCommand("DECLARE @Code NVARCHAR(13); EXEC New_Code 'processing_fee', 'MN', @Code OUTPUT; SELECT @Code;", ConStr)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        pCode = reader(0).ToString()
                    End If
                End Using
            End Using
            'newcode

            'stored procedure
            Using Cmd As New SqlCommand("cldc_live.dbo.aad_upd_pf", ConStr)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pupdmode", pMode)
                Cmd.Parameters.AddWithValue("@ppf_code", pCode)
                Cmd.Parameters.AddWithValue("@poffice", pOffice)
                Cmd.Parameters.AddWithValue("@plname", pLname)
                Cmd.Parameters.AddWithValue("@pfname", pFname)
                Cmd.Parameters.AddWithValue("@pmname", pMname)
                Cmd.Parameters.AddWithValue("@pentry_date", pEntry)
                Cmd.Parameters.AddWithValue("@ppdate", pAssessment)
                Cmd.Parameters.AddWithValue("@pscode", pSubd)
                Cmd.Parameters.AddWithValue("@ppcode", pPhase)
                Cmd.Parameters.AddWithValue("@pblock", pBlock)
                Cmd.Parameters.AddWithValue("@plot", pLot)
                Cmd.Parameters.AddWithValue("@pltype", pLottype)
                Cmd.Parameters.AddWithValue("@pptype", pProjecttype)
                Cmd.Parameters.AddWithValue("@parea", Convert.ToDouble(pArea))
                Cmd.Parameters.AddWithValue("@pprice", Convert.ToDouble(pPrice))
                Cmd.Parameters.AddWithValue("@phcost", Convert.ToDouble(pHousecost))
                Cmd.Parameters.AddWithValue("@ptype", pTransactiontype)
                Cmd.Parameters.AddWithValue("@pnyear", Convert.ToDouble(pYear))
                Cmd.Parameters.AddWithValue("@pdiscount", Convert.ToDouble(pDiscount))
                Cmd.Parameters.AddWithValue("@plvalue", Convert.ToDouble(pLoan))
                Cmd.Parameters.AddWithValue("@psprice", Convert.ToDouble(pSellingprice))
                Cmd.Parameters.AddWithValue("@ptransfer", Convert.ToDouble(pTransfer))
                Cmd.Parameters.AddWithValue("@pmfees", Convert.ToDouble(pFee))
                Cmd.Parameters.AddWithValue("@pmdues", Convert.ToDouble(pDue))
                Cmd.Parameters.AddWithValue("@pupdated_by", CIIS_EmpCode)
                Cmd.ExecuteNonQuery()
            End Using
            'stored procedure

            ConStr.Close()
        End Using

        RecordList.Add(New With {.pCode = pCode})

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function AAD040000_Edit_Record(pMode, pID, pOffice, pLname, pFname, pMname, pEntry, pAssessment, pSubd, pPhase, pBlock, pLot, pLottype, pProjecttype, pArea, pPrice, pHousecost, pTransactiontype, pYear, pDiscount, pLoan, pSellingprice, pTransfer, pFee, pDue)

        'variables
        Dim RecordList As New List(Of Object)()
        'variables

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            ConStr.Open()

            'stored procedure
            Using Cmd As New SqlCommand("cldc_live.dbo.aad_upd_pf", ConStr)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pupdmode", pMode)
                Cmd.Parameters.AddWithValue("@ppf_code", pID)
                Cmd.Parameters.AddWithValue("@poffice", pOffice)
                Cmd.Parameters.AddWithValue("@plname", pLname)
                Cmd.Parameters.AddWithValue("@pfname", pFname)
                Cmd.Parameters.AddWithValue("@pmname", pMname)
                Cmd.Parameters.AddWithValue("@pentry_date", pEntry)
                Cmd.Parameters.AddWithValue("@ppdate", pAssessment)
                Cmd.Parameters.AddWithValue("@pscode", pSubd)
                Cmd.Parameters.AddWithValue("@ppcode", pPhase)
                Cmd.Parameters.AddWithValue("@pblock", pBlock)
                Cmd.Parameters.AddWithValue("@plot", pLot)
                Cmd.Parameters.AddWithValue("@pltype", pLottype)
                Cmd.Parameters.AddWithValue("@pptype", pProjecttype)
                Cmd.Parameters.AddWithValue("@parea", Convert.ToDouble(pArea))
                Cmd.Parameters.AddWithValue("@pprice", Convert.ToDouble(pPrice))
                Cmd.Parameters.AddWithValue("@phcost", Convert.ToDouble(pHousecost))
                Cmd.Parameters.AddWithValue("@ptype", pTransactiontype)
                Cmd.Parameters.AddWithValue("@pnyear", Convert.ToDouble(pYear))
                Cmd.Parameters.AddWithValue("@pdiscount", Convert.ToDouble(pDiscount))
                Cmd.Parameters.AddWithValue("@plvalue", Convert.ToDouble(pLoan))
                Cmd.Parameters.AddWithValue("@psprice", Convert.ToDouble(pSellingprice))
                Cmd.Parameters.AddWithValue("@ptransfer", Convert.ToDouble(pTransfer))
                Cmd.Parameters.AddWithValue("@pmfees", Convert.ToDouble(pFee))
                Cmd.Parameters.AddWithValue("@pmdues", Convert.ToDouble(pDue))
                Cmd.Parameters.AddWithValue("@pupdated_by", CIIS_EmpCode)
                Cmd.ExecuteNonQuery()
            End Using
            'stored procedure

            ConStr.Close()
        End Using

        RecordList.Add(New With {.pID = pID})

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function AAD040000_Generate_OnePage(pID As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/AAD04RPT01.rpt"), Path.Combine(reportFolderPath, "AAD04RPT01.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "AAD04RPT01.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "cldc_live"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "cldc_live")
            RptDoc.SetParameterValue("@ppf_code", pID)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "AAD04RPT01.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & pID & "/AAD04RPT01.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)
    End Function

    Function AAD040000_Generate_TwoPages(pID As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/AAD04RPT02.rpt"), Path.Combine(reportFolderPath, "AAD04RPT02.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "AAD04RPT02.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "cldc_live"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "cldc_live")
            RptDoc.SetParameterValue("@ppf_code", pID)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "AAD04RPT02.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & pID & "/AAD04RPT02.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)
    End Function

#End Region

#Region "AAD050000"
    Function AAD050000_Get_Record_Hdr(pPost, pDivision)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetCAList")
                Cmd.CommandTimeout = 300
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pPost", pPost)
                Cmd.Parameters.AddWithValue("@pDivision", pDivision)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AAD050100-DTL-" & DR("CACode") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("CACode") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn05Post('" & DR("CACode") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-cancel' title='Unpost' onclick=""fn06Unpost('" & DR("CACode") & "');return false;""><i class='las la-times-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("CACode"),
                        .Action = Action.ToString,
                        .Post = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Post") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .CESNo = "<span title='" & DR("CESNo") & "'>" & DR("CESNo") & "</span>",
                        .ReleaseDate = If(IsDBNull(DR("ReleaseDate")), "", Convert.ToDateTime(DR("ReleaseDate")).ToString("MM/dd/yyyy")),
                        .ReleaseStatus = "<span title='" & DR("ReleaseStatus") & "'>" & DR("ReleaseStatus") & "</span>",
                        .CommDesc = "<span title='" & DR("CommDesc") & "'>" & DR("CommDesc") & "</span>",
                        .AcctNo = "<span title='" & DR("AcctNo") & "'>" & DR("AcctNo") & "</span>",
                        .AcctName = "<span title='" & DR("AcctName") & "'>" & DR("AcctName") & "</span>",
                        .DOE = If(IsDBNull(DR("DOE")), "", Convert.ToDateTime(DR("DOE")).ToString("MM/dd/yyyy")),
                        .Subd = "<span title='" & DR("Subd") & "'>" & DR("Subd") & "</span>",
                        .PhaseNo = "<span title='" & DR("PhaseNo") & "'>" & DR("PhaseNo") & "</span>",
                        .Block = "<span title='" & DR("Block") & "'>" & DR("Block") & "</span>",
                        .Lot = "<span title='" & DR("Lot") & "'>" & DR("Lot") & "</span>"
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

    Function AAD050000_Redraw_Hdr(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("    [JCF_CAHdr].[CACode], ")
        Query.Append("    [JCF_CAHdr].[CESNo], ")
        Query.Append("    [JCF_CAHdr].Post, ")
        Query.Append("    [JCF_CAHdr].[ReleaseDate], ")
        Query.Append("    [JCF_CAHdr].[ReleaseStatus], ")
        Query.Append("    [JCF_CAHdr].[CommDesc], ")
        Query.Append("    [JCF_CAHdr].[AcctNo], ")
        Query.Append("    [ICR_Buyers].AcctName, ")
        Query.Append("    [ICR_Reservations].RFDate [DOE], ")
        Query.Append("    [mstr_Projects].ProjInit AS [Subd], ")
        Query.Append("    [JCF_CAHdr].[PhaseNo], ")
        Query.Append("    [JCF_CAHdr].[Block], ")
        Query.Append("    [JCF_CAHdr].[Lot] ")
        Query.Append("  FROM [JCF_CAHdr] ")
        Query.Append("  LEFT JOIN [ICR_Buyers] ON [JCF_CAHdr].AcctNo = [ICR_Buyers].AcctNo ")
        Query.Append("  LEFT JOIN [ICR_Reservations] ON [JCF_CAHdr].AcctNo = [ICR_Reservations].AcctNo ")
        Query.Append("  LEFT JOIN [mstr_Projects] ON [JCF_CAHdr].ProjCode = [mstr_Projects].ProjCode ")
        Query.Append("  WHERE [JCF_CAHdr].[CACode] = '" & pID & "'")

        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AAD050100-DTL-" & DR("CACode") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("CACode") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn05Post('" & DR("CACode") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-cancel' title='Unpost' onclick=""fn06Unpost('" & DR("CACode") & "');return false;""><i class='las la-times-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("CACode"),
                        .Action = Action.ToString,
                        .Post = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Post") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .CESNo = "<span title='" & DR("CESNo") & "'>" & DR("CESNo") & "</span>",
                        .ReleaseDate = If(IsDBNull(DR("ReleaseDate")), "", Convert.ToDateTime(DR("ReleaseDate")).ToString("MM/dd/yyyy")),
                        .ReleaseStatus = "<span title='" & DR("ReleaseStatus") & "'>" & DR("ReleaseStatus") & "</span>",
                        .CommDesc = "<span title='" & DR("CommDesc") & "'>" & DR("CommDesc") & "</span>",
                        .AcctNo = "<span title='" & DR("AcctNo") & "'>" & DR("AcctNo") & "</span>",
                        .AcctName = "<span title='" & DR("AcctName") & "'>" & DR("AcctName") & "</span>",
                        .DOE = If(IsDBNull(DR("DOE")), "", Convert.ToDateTime(DR("DOE")).ToString("MM/dd/yyyy")),
                        .Subd = "<span title='" & DR("Subd") & "'>" & DR("Subd") & "</span>",
                        .PhaseNo = "<span title='" & DR("PhaseNo") & "'>" & DR("PhaseNo") & "</span>",
                        .Block = "<span title='" & DR("Block") & "'>" & DR("Block") & "</span>",
                        .Lot = "<span title='" & DR("Lot") & "'>" & DR("Lot") & "</span>"
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

    Function AAD050000_Post_Record(pTrxnNo, pPostedBy, pPost)

        ' Get EmpName based on CIIS_EmpCode
        Using conn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            conn.Open()
            Using cmd As New SqlCommand("SELECT LogName FROM calmardbLive.dbo.mstr_Users WHERE EmpCode = @EmpCode", conn)
                cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    pPostedBy = result.ToString()
                End If
            End Using

            If String.IsNullOrWhiteSpace(pPostedBy) Then
                Using cmd As New SqlCommand("SELECT initialname FROM employee WHERE emp_no = @EmpCode", conn)
                    cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        pPostedBy = result.ToString()
                    End If
                End Using
            End If
            conn.Close()
        End Using

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'execute procedure
        Using SqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using SqlCmd As New SqlCommand("calmardblive.dbo.JCF_PostCAHdr", SqlConn)
                SqlCmd.CommandTimeout = 1500
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.Parameters.AddWithValue("@pTrxnNo", pTrxnNo)
                SqlCmd.Parameters.AddWithValue("@pPostedBy", pPostedBy)
                SqlCmd.Parameters.AddWithValue("@pPost", pPost)
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
            End Using
        End Using
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Function AAD050000_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("    JCF_CAHdr.CACode, ")
        Query.Append("    JCF_CAHdr.CADate, ")
        Query.Append("    JCF_CAHdr.CommDesc, ")
        Query.Append("    JCF_CAHdr.CommAmt, ")
        Query.Append("    JCF_CAHdr.CommRate, ")
        Query.Append("    JCF_CAHdr.CESNo, ")
        Query.Append("    JCF_CAHdr.ReleaseDate, ")
        Query.Append("    JCF_CAHdr.ReleaseStatus, ")
        Query.Append("    JCF_CAHdr.QualifyingDate, ")
        Query.Append("    JCF_CAHdr.DPStatus, ")
        Query.Append("    JCF_CAHdr.MAStatus, ")
        Query.Append("    JCF_CAHdr.AcctNo, ")
        Query.Append("    ICR_Buyers.AcctName, ")
        Query.Append("    JCF_CAHdr.Link, ")
        Query.Append("    (CASE WHEN JCF_CAHdr.Post = 1 THEN 'Paid' WHEN ICR_Ledger.Principal - ICR_Ledger.AmtPd2Prin <= 0 THEN 'Paid' ELSE '' END) AS Paid, ")
        Query.Append("    mstr_Projects.ProjInit + ' | ' + JCF_CAHdr.PhaseNo + ' | ' + JCF_CAHdr.Block + ' | ' + JCF_CAHdr.Lot AS Project, ")
        Query.Append("    mstr_Projects.ProjInit AS Subd, ")
        Query.Append("    JCF_CAHdr.PhaseNo, ")
        Query.Append("    JCF_CAHdr.Block, ")
        Query.Append("    JCF_CAHdr.Lot, ")
        Query.Append("    JCF_CAHdr.Area, ")
        Query.Append("    JCF_CAHdr.Price, ")
        Query.Append("    JCF_CAHdr.TLC, ")
        Query.Append("    JCF_CAHdr.AmtPaid, ")
        Query.Append("    JCF_CAHdr.Discount, ")
        Query.Append("    JCF_CAHdr.Production, ")
        Query.Append("    JCF_CAHdr.GSP, ")
        Query.Append("    JCF_CAHdr.CommBasis, ")
        Query.Append("    JCF_CAHdr.Total, ")
        Query.Append("    JCF_CAHdr.SlsCommRate, ")
        Query.Append("    JCF_CAHdr.GrossCommAmt, ")
        Query.Append("    ISNULL((SELECT TOP 1 SL.SellerName FROM ICR_Sellers ISL LEFT JOIN mstr_Sellers SL ON ISL.SellerCode = SL.SellerCode WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode IN (1,5)), '') AS SRName, ")
        Query.Append("    ISNULL((SELECT TOP 1 (CASE WHEN JCF_CAHdr.Production = 'Lot Only' THEN ISL.CommRate ELSE ISL.HLCommRate END) FROM ICR_Sellers ISL WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode IN (1,5)), 0) AS SRRate, ")
        Query.Append("    JCF_CAHdr.SRAmt, ")
        Query.Append("    JCF_CAHdr.SRAmt * (CASE WHEN JCF_CAHdr.Tax > 0 THEN 0.10 ELSE 0 END) AS SRTax, ")
        Query.Append("    (CASE WHEN JCF_CAHdr.Tax > 0 THEN JCF_CAHdr.SRAmt * 0.90 ELSE JCF_CAHdr.SRAmt END) AS SRNet, ")
        Query.Append("    ISNULL((SELECT TOP 1 SL.SellerName FROM ICR_Sellers ISL LEFT JOIN mstr_Sellers SL ON ISL.SellerCode = SL.SellerCode WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode IN (4,8)), '') AS GSMName, ")
        Query.Append("    ISNULL((SELECT TOP 1 (CASE WHEN JCF_CAHdr.Production = 'Lot Only' THEN ISL.CommRate ELSE ISL.HLCommRate END) FROM ICR_Sellers ISL WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode IN (4,8)), 0) AS GSMRate, ")
        Query.Append("    JCF_CAHdr.GSMAmt, ")
        Query.Append("    JCF_CAHdr.GSMAmt * (CASE WHEN JCF_CAHdr.Tax > 0 THEN 0.10 ELSE 0 END) AS GSMTax, ")
        Query.Append("    (CASE WHEN JCF_CAHdr.Tax > 0 THEN JCF_CAHdr.GSMAmt * 0.90 ELSE JCF_CAHdr.GSMAmt END) AS GSMNet, ")
        Query.Append("    ISNULL((SELECT TOP 1 SL.SellerName FROM ICR_Sellers ISL LEFT JOIN mstr_Sellers SL ON ISL.SellerCode = SL.SellerCode WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 2), '') AS SMName, ")
        Query.Append("    ISNULL((SELECT TOP 1 (CASE WHEN JCF_CAHdr.Production = 'Lot Only' THEN ISL.CommRate ELSE ISL.HLCommRate END) FROM ICR_Sellers ISL WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 2), 0) AS SMRate, ")
        Query.Append("    JCF_CAHdr.SMAmt, ")
        Query.Append("    JCF_CAHdr.SMAmt * (CASE WHEN JCF_CAHdr.Tax > 0 THEN 0.10 ELSE 0 END) AS SMTax, ")
        Query.Append("    (CASE WHEN JCF_CAHdr.Tax > 0 THEN JCF_CAHdr.SMAmt * 0.90 ELSE JCF_CAHdr.SMAmt END) AS SMNet, ")
        Query.Append("    ISNULL((SELECT TOP 1 SL.SellerName FROM ICR_Sellers ISL LEFT JOIN mstr_Sellers SL ON ISL.SellerCode = SL.SellerCode WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 7), '') AS BrokerName, ")
        Query.Append("    ISNULL((SELECT TOP 1 (CASE WHEN JCF_CAHdr.Production = 'Lot Only' THEN ISL.CommRate ELSE ISL.HLCommRate END) FROM ICR_Sellers ISL WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 7), 0) AS BrokerRate, ")
        Query.Append("    JCF_CAHdr.BrokerAmt, ")
        Query.Append("    JCF_CAHdr.BrokerAmt * (CASE WHEN JCF_CAHdr.Tax > 0 THEN 0.10 ELSE 0 END) AS BrokerTax, ")
        Query.Append("    (CASE WHEN JCF_CAHdr.Tax > 0 THEN JCF_CAHdr.BrokerAmt * 0.90 ELSE JCF_CAHdr.BrokerAmt END) AS BrokerNet, ")
        Query.Append("    ISNULL((SELECT TOP 1 SL.SellerName FROM ICR_Sellers ISL LEFT JOIN mstr_Sellers SL ON ISL.SellerCode = SL.SellerCode WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 6), '') AS JRSDName, ")
        Query.Append("    ISNULL((SELECT TOP 1 (CASE WHEN JCF_CAHdr.Production = 'Lot Only' THEN ISL.CommRate ELSE ISL.HLCommRate END) FROM ICR_Sellers ISL WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 6), 0) AS JRSDRate, ")
        Query.Append("    JCF_CAHdr.JRSDAmt, ")
        Query.Append("    JCF_CAHdr.JRSDAmt * (CASE WHEN JCF_CAHdr.Tax > 0 THEN 0.10 ELSE 0 END) AS JRSDTax, ")
        Query.Append("    (CASE WHEN JCF_CAHdr.Tax > 0 THEN JCF_CAHdr.JRSDAmt * 0.90 ELSE JCF_CAHdr.JRSDAmt END) AS JRSDNet, ")
        Query.Append("    ISNULL((SELECT TOP 1 SL.SellerName FROM ICR_Sellers ISL LEFT JOIN mstr_Sellers SL ON ISL.SellerCode = SL.SellerCode WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 3), '') AS SDName, ")
        Query.Append("    ISNULL((SELECT TOP 1 (CASE WHEN JCF_CAHdr.Production = 'Lot Only' THEN ISL.CommRate ELSE ISL.HLCommRate END) FROM ICR_Sellers ISL WHERE ISL.AcctNo = JCF_CAHdr.AcctNo AND ISL.TypeCode = 3), 0) AS SDRate, ")
        Query.Append("    JCF_CAHdr.SDAmt, ")
        Query.Append("    JCF_CAHdr.SDAmt * (CASE WHEN JCF_CAHdr.Tax > 0 THEN 0.10 ELSE 0 END) AS SDTax, ")
        Query.Append("    (CASE WHEN JCF_CAHdr.Tax > 0 THEN JCF_CAHdr.SDAmt * 0.90 ELSE JCF_CAHdr.SDAmt END) AS SDNet, ")
        Query.Append("    JCF_CAHdr.Tax, ")
        Query.Append("    JCF_CAHdr.NetCommAmt, ")
        Query.Append("    JCF_CAHdr.Remarks, ")
        Query.Append("    JCF_CAHdr.UpdatedBy, ")
        Query.Append("    JCF_CAHdr.Post, ")
        Query.Append("    JCF_CAHdr.PostedBy, ")
        Query.Append("    JCF_CAHdr.Cancel, ")
        Query.Append("    format(JCF_CAHdr.UpdatedDate,'MM/dd/yyyy hh:mm tt') [UpdatedDate], ")
        Query.Append("    ISNULL(updater.fullname, (SELECT TOP 1 emp2.fullname FROM mstr_users u JOIN cldc_live_acc.dbo.employee emp2 ON u.EmpCode = emp2.emp_no WHERE u.LogName = JCF_CAHdr.UpdatedBy)) AS UpdatedByName, ")
        Query.Append("    (CASE WHEN ISNULL(JCF_CAHdr.Post, 0) = 1 THEN ISNULL(locker.fullname, (SELECT TOP 1 emp2.fullname FROM mstr_users u JOIN cldc_live_acc.dbo.employee emp2 ON u.EmpCode = emp2.emp_no WHERE u.LogName = JCF_CAHdr.PostedBy)) ELSE '' END) AS PostedByName, ")
        Query.Append("    (case when isnull(JCF_CAHdr.Post,0) = 1 then format(JCF_CAHdr.PostedDate,'MM/dd/yyyy hh:mm tt') else '' end) [PostedDate], ")
        Query.Append("    (case when JCF_CAHdr.Post = 0 then 'New' when JCF_CAHdr.Post = 1 then 'Posted' when JCF_CAHdr.Post is null then 'Unposted' end) [RecordStatus] ")
        Query.Append("  FROM JCF_CAHdr ")
        Query.Append("  LEFT JOIN ICR_Buyers ON JCF_CAHdr.AcctNo = ICR_Buyers.AcctNo ")
        Query.Append("  LEFT JOIN ICR_Ledger ON JCF_CAHdr.AcctNo = ICR_Ledger.AcctNo AND JCF_CAHdr.Link = ICR_Ledger.Link ")
        Query.Append("  LEFT JOIN mstr_Projects ON JCF_CAHdr.ProjCode = mstr_Projects.ProjCode ")
        Query.Append("  LEFT JOIN cldc_live_acc.dbo.employee AS updater ON JCF_CAHdr.UpdatedBy = updater.emp_no ")
        Query.Append("  LEFT JOIN cldc_live_acc.dbo.employee AS locker ON JCF_CAHdr.PostedBy = locker.emp_no ")
        Query.Append("  WHERE JCF_CAHdr.CACode = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                    .CACode = DR("CACode"),
                    .CADate = DR("CADate"),
                    .Reference = DR("CommDesc"),
                    .CommAmt = If(IsDBNull(DR("CommAmt")), "0.00", Convert.ToDouble(DR("CommAmt")).ToString("N2")),
                    .CommRate = If(IsDBNull(DR("CommRate")), "0.00", Convert.ToDouble(DR("CommRate")).ToString("N2")),
                    .CESNo = DR("CESNo"),
                    .ReleaseDate = If(IsDBNull(DR("ReleaseDate")), "", Convert.ToDateTime(DR("ReleaseDate")).ToString("MM/dd/yyyy")),
                    .Status = DR("ReleaseStatus"),
                    .QualifyingDate = If(IsDBNull(DR("QualifyingDate")), "", Convert.ToDateTime(DR("QualifyingDate")).ToString("MM/dd/yyyy")),
                    .DPStatus = DR("DPStatus"),
                    .MAStatus = DR("MAStatus"),
                    .AcctNo = DR("AcctNo"),
                    .AcctName = DR("AcctName"),
                    .Link = DR("Link"),
                    .Paid = DR("Paid"),
                    .Project = DR("Project"),
                    .Subd = DR("Subd"),
                    .PhaseNo = DR("PhaseNo"),
                    .Block = DR("Block"),
                    .Lot = DR("Lot"),
                    .Area = If(IsDBNull(DR("Area")), "0.00", Convert.ToDouble(DR("Area")).ToString("N2")),
                    .Price = If(IsDBNull(DR("Price")), "0.00", Convert.ToDouble(DR("Price")).ToString("N2")),
                    .TLC = If(IsDBNull(DR("TLC")), "0.00", Convert.ToDouble(DR("TLC")).ToString("N2")),
                    .AmtPaid = If(IsDBNull(DR("AmtPaid")), "0.00", Convert.ToDouble(DR("AmtPaid")).ToString("N2")),
                    .Discount = If(IsDBNull(DR("Discount")), "0.00", Convert.ToDouble(DR("Discount")).ToString("N2")),
                    .Production = DR("Production"),
                    .GSP = If(IsDBNull(DR("GSP")), "0.00", Convert.ToDouble(DR("GSP")).ToString("N2")),
                    .CommBasis = If(IsDBNull(DR("CommBasis")), "0.00", Convert.ToDouble(DR("CommBasis")).ToString("N2")),
                    .Total = If(IsDBNull(DR("Total")), "0.00", Convert.ToDouble(DR("Total")).ToString("N2")),
                    .SlsCommRate = If(IsDBNull(DR("SlsCommRate")), "0.00", Convert.ToDouble(DR("SlsCommRate")).ToString("N2")),
                    .GSC = If(IsDBNull(DR("GrossCommAmt")), "0.00", Convert.ToDouble(DR("GrossCommAmt")).ToString("N2")),
                    .SRName = DR("SRName"),
                    .SRRate = If(IsDBNull(DR("SRRate")), "0.00", Convert.ToDouble(DR("SRRate")).ToString("N2")),
                    .SRAmt = If(IsDBNull(DR("SRAmt")), "0.00", Convert.ToDouble(DR("SRAmt")).ToString("N2")),
                    .SRTax = If(IsDBNull(DR("SRTax")), "0.00", Convert.ToDouble(DR("SRTax")).ToString("N2")),
                    .SRNet = If(IsDBNull(DR("SRNet")), "0.00", Convert.ToDouble(DR("SRNet")).ToString("N2")),
                    .GSMName = DR("GSMName"),
                    .GSMRate = If(IsDBNull(DR("GSMRate")), "0.00", Convert.ToDouble(DR("GSMRate")).ToString("N2")),
                    .GSMAmt = If(IsDBNull(DR("GSMAmt")), "0.00", Convert.ToDouble(DR("GSMAmt")).ToString("N2")),
                    .GSMTax = If(IsDBNull(DR("GSMTax")), "0.00", Convert.ToDouble(DR("GSMTax")).ToString("N2")),
                    .GSMNet = If(IsDBNull(DR("GSMNet")), "0.00", Convert.ToDouble(DR("GSMNet")).ToString("N2")),
                    .SMName = DR("SMName"),
                    .SMRate = If(IsDBNull(DR("SMRate")), "0.00", Convert.ToDouble(DR("SMRate")).ToString("N2")),
                    .SMAmt = If(IsDBNull(DR("SMAmt")), "0.00", Convert.ToDouble(DR("SMAmt")).ToString("N2")),
                    .SMTax = If(IsDBNull(DR("SMTax")), "0.00", Convert.ToDouble(DR("SMTax")).ToString("N2")),
                    .SMNet = If(IsDBNull(DR("SMNet")), "0.00", Convert.ToDouble(DR("SMNet")).ToString("N2")),
                    .BrokerName = DR("BrokerName"),
                    .BrokerRate = If(IsDBNull(DR("BrokerRate")), "0.00", Convert.ToDouble(DR("BrokerRate")).ToString("N2")),
                    .BrokerAmt = If(IsDBNull(DR("BrokerAmt")), "0.00", Convert.ToDouble(DR("BrokerAmt")).ToString("N2")),
                    .BrokerTax = If(IsDBNull(DR("BrokerTax")), "0.00", Convert.ToDouble(DR("BrokerTax")).ToString("N2")),
                    .BrokerNet = If(IsDBNull(DR("BrokerNet")), "0.00", Convert.ToDouble(DR("BrokerNet")).ToString("N2")),
                    .JRSDName = DR("JRSDName"),
                    .JRSDRate = If(IsDBNull(DR("JRSDRate")), "0.00", Convert.ToDouble(DR("JRSDRate")).ToString("N2")),
                    .JRSDAmt = If(IsDBNull(DR("JRSDAmt")), "0.00", Convert.ToDouble(DR("JRSDAmt")).ToString("N2")),
                    .JRSDTax = If(IsDBNull(DR("JRSDTax")), "0.00", Convert.ToDouble(DR("JRSDTax")).ToString("N2")),
                    .JRSDNet = If(IsDBNull(DR("JRSDNet")), "0.00", Convert.ToDouble(DR("JRSDNet")).ToString("N2")),
                    .SDName = DR("SDName"),
                    .SDRate = If(IsDBNull(DR("SDRate")), "0.00", Convert.ToDouble(DR("SDRate")).ToString("N2")),
                    .SDAmt = If(IsDBNull(DR("SDAmt")), "0.00", Convert.ToDouble(DR("SDAmt")).ToString("N2")),
                    .SDTax = If(IsDBNull(DR("SDTax")), "0.00", Convert.ToDouble(DR("SDTax")).ToString("N2")),
                    .SDNet = If(IsDBNull(DR("SDNet")), "0.00", Convert.ToDouble(DR("SDNet")).ToString("N2")),
                    .WHT = If(IsDBNull(DR("Tax")), "0.00", Convert.ToDouble(DR("Tax")).ToString("N2")),
                    .NSC = If(IsDBNull(DR("NetCommAmt")), "0.00", Convert.ToDouble(DR("NetCommAmt")).ToString("N2")),
                    .Remarks = DR("Remarks"),
                    .UpdatedBy = DR("UpdatedBy"),
                    .Post = DR("Post"),
                    .PostedBy = DR("PostedBy"),
                    .Cancel = DR("Cancel"),
                    .RecordStatus = DR("RecordStatus"),
                    .UpdatedByName = DR("UpdatedByName"),
                    .UpdatedDate = DR("UpdatedDate"),
                    .PostedByName = DR("PostedByName"),
                    .PostedDate = DR("PostedDate")
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

    Function AAD050000_Edit_Record(pID, pReleaseDate, pStatus, pQualifyingDate, pUpdatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("update JCF_CAHdr set ")
        If pReleaseDate = "" Then
            Query.Append("   ReleaseDate = NULL ")
        Else
            Query.Append("   ReleaseDate = '" & pReleaseDate & "' ")
        End If
        Query.Append("   ,ReleaseStatus = '" & pStatus & "' ")
        If pQualifyingDate = "" Then
            Query.Append("   ,QualifyingDate = NULL ")
        Else
            Query.Append("   ,QualifyingDate = '" & pQualifyingDate & "' ")
        End If
        Query.Append("   ,UpdatedBy = '" & pUpdatedBy & "' ")
        Query.Append("   ,UpdatedDate = getdate() ")
        Query.Append("where ")
        Query.Append("   CACode  = '" & pID & "' ")

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pID})

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

    Function AAD050000_Generate_CES(pID As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/AAD05RPT01.rpt"), Path.Combine(reportFolderPath, "AAD05RPT01.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "AAD05RPT01.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@pCACode", pID)
            RptDoc.SetParameterValue("@pCACode", pID, "CESAPV.rpt")

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "AAD05RPT01.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & pID & "/AAD05RPT01.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)
    End Function

#End Region

#Region "FIN080000"

    Function FIN080000_Get_Class_Code()

        'query
        Dim Query As New StringBuilder()
        Query.Append("  SELECT ")
        Query.Append("      '' AS [ID], ")
        Query.Append("      'Payor Class' AS [Name], ")
        Query.Append("      1 AS [Lock] ")
        Query.Append("  UNION ")
        Query.Append("  SELECT ")
        Query.Append("      ClassCode AS [ID], ")
        Query.Append("      ClassDescription AS [Name], ")
        Query.Append("      1 AS [Lock] ")
        Query.Append("  FROM ")
        Query.Append("      mstr_EntityClasses ")
        Query.Append("  ORDER BY ")
        Query.Append("      [Name]")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
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

    Function FIN080000_Get_Payor_Name(pFind, pClassCode)

        'query
        Dim Query As New StringBuilder()
        If pClassCode = "13" Then
            Query.Append("    select Code [ID],")
            Query.Append("    Name [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    Name [Order2] ")
            Query.Append("    from JCF_LotConnection")
            Query.Append("    where MgtLOStatus = 1")
            Query.Append("    and (Code like '%" & pFind & "%' ")
            Query.Append("    or Name like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "12" Then
            Query.Append("    select Code [ID],")
            Query.Append("    Name [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    Name [Order2] ")
            Query.Append("    from JCF_LotConnection")
            Query.Append("    where MgtStatus = 1")
            Query.Append("    and (Code like '%" & pFind & "%' ")
            Query.Append("    or Name like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "11" Then
            Query.Append("    select Code [ID],")
            Query.Append("    Name [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    Name [Order2] ")
            Query.Append("    from JCF_LotConnection")
            Query.Append("    where WaterStatus = 1")
            Query.Append("    and (Code like '%" & pFind & "%' ")
            Query.Append("    or Name like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "10" Then
            Query.Append("    select Code [ID],")
            Query.Append("    Name [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    Name [Order2] ")
            Query.Append("    from JCF_LotConnection")
            Query.Append("    where ElecStatus = 1")
            Query.Append("    and (Code like '%" & pFind & "%' ")
            Query.Append("    or Name like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "9" Then
            Query.Append("    select ei.EntityCode [ID],")
            Query.Append("    e.CompoundName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    e.CompoundName [Order2] ")
            Query.Append("    from mstr_EntityInstances ei ")
            Query.Append("    left join mstr_Entities e on ei.EntityCode = e.EntityCode ")
            Query.Append("    where ei.ClassCode = '9' ")
            Query.Append("    and (ei.EntityCode like '%" & pFind & "%' ")
            Query.Append("    or e.CompoundName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")


        ElseIf pClassCode = "7" Then
            Query.Append("    select ei.EntityCode [ID],")
            Query.Append("    e.CompoundName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    e.CompoundName [Order2] ")
            Query.Append("    from mstr_EntityInstances ei ")
            Query.Append("    left join mstr_Entities e on ei.EntityCode = e.EntityCode ")
            Query.Append("    where ei.ClassCode = '7' ")
            Query.Append("    and (ei.EntityCode like '%" & pFind & "%' ")
            Query.Append("    or e.CompoundName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "6" Then
            Query.Append("    select ei.EntityCode [ID],")
            Query.Append("    e.CompoundName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    e.CompoundName [Order2] ")
            Query.Append("    from mstr_EntityInstances ei ")
            Query.Append("    left join mstr_Entities e on ei.EntityCode = e.EntityCode ")
            Query.Append("    where ei.ClassCode = '6' ")
            Query.Append("    and (ei.EntityCode like '%" & pFind & "%' ")
            Query.Append("    or e.CompoundName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "5" Then
            Query.Append("    select ei.EntityCode [ID],")
            Query.Append("    e.CompoundName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    e.CompoundName [Order2] ")
            Query.Append("    from mstr_EntityInstances ei ")
            Query.Append("    left join mstr_Entities e on ei.EntityCode = e.EntityCode ")
            Query.Append("    where ei.ClassCode = '5' ")
            Query.Append("    and (ei.EntityCode like '%" & pFind & "%' ")
            Query.Append("    or e.CompoundName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "4" Then
            Query.Append("    select AcctNo [ID],")
            Query.Append("    AcctName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    AcctName [Order2] ")
            Query.Append("    from ICR_Buyers ")
            Query.Append("    left join mstr_Projects on ICR_Buyers.ProjCode = mstr_Projects.ProjCode ")
            Query.Append("    where ICR_Buyers.Active = 1 ")
            Query.Append("    and (AcctNo like '%" & pFind & "%' ")
            Query.Append("    or AcctName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "3" Then
            Query.Append("    select ei.EntityCode [ID],")
            Query.Append("    e.CompoundName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    e.CompoundName [Order2] ")
            Query.Append("    from mstr_EntityInstances ei ")
            Query.Append("    left join mstr_Entities e on ei.EntityCode = e.EntityCode ")
            Query.Append("    where ei.ClassCode = '3' ")
            Query.Append("    and (ei.EntityCode like '%" & pFind & "%' ")
            Query.Append("    or e.CompoundName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "2" Then
            Query.Append("    select ei.EntityCode [ID],")
            Query.Append("    e.CompoundName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    e.CompoundName [Order2] ")
            Query.Append("    from mstr_EntityInstances ei ")
            Query.Append("    left join mstr_Entities e on ei.EntityCode = e.EntityCode ")
            Query.Append("    where ei.ClassCode = '2' ")
            Query.Append("    and (ei.EntityCode like '%" & pFind & "%' ")
            Query.Append("    or e.CompoundName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")

        ElseIf pClassCode = "1" Then
            Query.Append("    select ei.EntityCode [ID],")
            Query.Append("    e.CompoundName [Name], ")
            Query.Append("    2 [Order1], ")
            Query.Append("    e.CompoundName [Order2] ")
            Query.Append("    from mstr_EntityInstances ei ")
            Query.Append("    left join mstr_Entities e on ei.EntityCode = e.EntityCode ")
            Query.Append("    where ei.ClassCode = '1' ")
            Query.Append("    and (ei.EntityCode like '%" & pFind & "%' ")
            Query.Append("    or e.CompoundName like '%" & pFind & "%') ")
            Query.Append("    order by [Order1], [Order2]")
        End If

        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As New StringBuilder
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectPayor('" & DR("ID") & "','" & Convert.ToString(DR("Name")).Replace(Chr(10), "").Replace(Chr(13), "").Replace(Chr(9), "") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & If(DR("Name") Is DBNull.Value OrElse Trim(Convert.ToString(DR("Name"))) = "", "-", Trim(Convert.ToString(DR("Name")))) & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & If(DR("ID") Is DBNull.Value OrElse Trim(Convert.ToString(DR("ID"))) = "", "-", Trim(Convert.ToString(DR("ID")))) & "</span>")
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

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function FIN080000_Get_Project(pID, pProject)

        'query
        Dim Query As New StringBuilder()

        If pProject = "ProjCode" Then
            Query.Append(" SELECT        ProjCode AS [Result]")
            Query.Append(" FROM            ICR_Buyers ")
            Query.Append(" WHERE        AcctNo = '" & pID & "' ")
        ElseIf pProject = "ProjInit" Then
            Query.Append("	SELECT        mstr_Projects.ProjInit AS [Result] ")
            Query.Append("	FROM            ICR_Buyers LEFT OUTER JOIN ")
            Query.Append("				    mstr_Projects ON ICR_Buyers.ProjCode = mstr_Projects.ProjCode ")
            Query.Append("	WHERE        ICR_Buyers.AcctNo = '" & pID & "' ")
        ElseIf pProject = "Phase" Then
            Query.Append(" SELECT        Phase AS [Result]")
            Query.Append(" FROM            ICR_Buyers ")
            Query.Append(" WHERE        AcctNo = '" & pID & "' ")
        ElseIf pProject = "Block" Then
            Query.Append(" SELECT        Block AS [Result]")
            Query.Append(" FROM            ICR_Buyers ")
            Query.Append(" WHERE        AcctNo = '" & pID & "' ")
        ElseIf pProject = "Lot" Then
            Query.Append(" SELECT        Lot AS [Result]")
            Query.Append(" FROM            ICR_Buyers ")
            Query.Append(" WHERE        AcctNo = '" & pID & "' ")
        ElseIf pProject = "PMDProjCode" Then
            Query.Append(" SELECT        ProjCode AS [Result]")
            Query.Append(" FROM            JCF_LotConnection ")
            Query.Append(" WHERE        Code = '" & pID & "' ")
        ElseIf pProject = "PMDProjInit" Then
            Query.Append("	SELECT        mstr_Projects.ProjInit AS [Result] ")
            Query.Append("	FROM            JCF_LotConnection LEFT OUTER JOIN ")
            Query.Append("				    mstr_Projects ON JCF_LotConnection.ProjCode = mstr_Projects.ProjCode ")
            Query.Append("	WHERE        JCF_LotConnection.Code = '" & pID & "' ")
        ElseIf pProject = "PMDPhase" Then
            Query.Append(" SELECT        PhaseNo AS [Result]")
            Query.Append(" FROM            JCF_LotConnection ")
            Query.Append(" WHERE        Code = '" & pID & "' ")
        ElseIf pProject = "PMDBlock" Then
            Query.Append(" SELECT        Block AS [Result]")
            Query.Append(" FROM            JCF_LotConnection ")
            Query.Append(" WHERE        Code = '" & pID & "' ")
        ElseIf pProject = "PMDLot" Then
            Query.Append(" SELECT        Lot AS [Result]")
            Query.Append(" FROM            JCF_LotConnection ")
            Query.Append(" WHERE        Code = '" & pID & "' ")
        End If
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                    .Result = DR("Result").ToString()
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

    Function FIN080000_Get_Subdivision()

        'query
        Dim Query As New StringBuilder()
        Query.Append("  SELECT ")
        Query.Append("      '0' AS [ID], ")
        Query.Append("      'Subdivision' AS [Name], ")
        Query.Append("      1 AS [Lock] ")
        Query.Append("  UNION ")
        Query.Append("  SELECT ")
        Query.Append("      cast(ProjCode as nvarchar(13)) AS [ID], ")
        Query.Append("      ProjInit AS [Name], ")
        Query.Append("      isnull(Lock,0) [Lock] ")
        Query.Append("  FROM ")
        Query.Append("      mstr_Projects ")
        Query.Append("  ORDER BY ")
        Query.Append("      [Name]")

        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
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

    Function FIN080000_Get_Payment_Application()

        'query
        Dim Query As New StringBuilder()
        Query.Append("    select '' [ID], 'Payment Application' [Name], 1 [Order1], 'Payment Application' [Order2]")
        Query.Append("    union")
        Query.Append("    select PayType, PayDesc, 2 [Order1], PayDesc [Order2]")
        Query.Append("    from mstr_PaymentType")
        Query.Append("    where Active = 1")
        Query.Append("    order by [Order1], [Order2]")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
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

    Function FIN080000_Get_Record_Hdr(pPost, pClassCode)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetPOList")
                Cmd.CommandTimeout = 300
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pPost", pPost)
                Cmd.Parameters.AddWithValue("@pClassCode", pClassCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('FIN080100-DTL-" & DR("TrxnNo").ToString().Replace("-", "") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("TrxnNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("TrxnNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn05Post('" & DR("TrxnNo") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("TrxnNo"),
                        .Action = Action.ToString,
                        .Posted = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Posted") = True, " checked='checked'", "") & " onclick='return false'/></div>",
                        .TrxnNo = "<span title='" & DR("TrxnNo") & "'>" & DR("TrxnNo") & "</span>",
                        .TransactionDate = If(IsDBNull(DR("TransactionDate")), "", Convert.ToDateTime(DR("TransactionDate")).ToString("MM/dd/yyyy")),
                        .PayorName = "<span title='" & DR("PayorName") & "'>" & DR("PayorName") & "</span>",
                        .Remarks = "<span title='" & DR("Remarks") & "'>" & DR("Remarks") & "</span>",
                        .TotalAmount = "<span title='" & If(IsDBNull(DR("TotalAmount")), "0.00", Convert.ToDouble(DR("TotalAmount")).ToString("N2")) & "'>" & If(IsDBNull(DR("TotalAmount")), "0.00", Convert.ToDouble(DR("TotalAmount")).ToString("N2")) & "</span>"
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

    Function FIN080000_Redraw_Hdr(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("	select ")
        Query.Append("		ICR_Assessment.TransactionNumber [TrxnNo] ")
        Query.Append("		,ICR_Assessment.Posted ")
        Query.Append("		,isnull(ICR_Assessment.Rvrs,0) [Rvrs] ")
        Query.Append("		,ICR_Assessment.TransactionDate ")
        Query.Append("		,mstr_EntityClasses.ClassDescription ")
        Query.Append("		,ICR_Assessment.PayorName ")
        Query.Append("		,ICR_Assessment.Remarks ")
        Query.Append("		,isnull((select sum(ICR_AssessmentDetails.Amount) from ICR_AssessmentDetails where ICR_AssessmentDetails.TransactionNumber = ICR_Assessment.TransactionNumber),0) [TotalAmount] ")
        Query.Append("	from ")
        Query.Append("		ICR_Assessment ")
        Query.Append("		left join mstr_EntityClasses on ICR_Assessment.ClassCode = mstr_EntityClasses.ClassCode ")
        Query.Append("		left join mstr_Projects on ICR_Assessment.ProjCode = mstr_Projects.ProjCode ")
        Query.Append("  WHERE ICR_Assessment.TransactionNumber = '" & pID & "'")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('FIN080100-DTL-" & DR("TrxnNo").ToString().Replace("-", "") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("TrxnNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("TrxnNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn05Post('" & DR("TrxnNo") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("TrxnNo"),
                        .Action = Action.ToString,
                        .Posted = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Posted") = True, " checked='checked'", "") & " onclick='return false'/></div>",
                        .TrxnNo = "<span title='" & DR("TrxnNo") & "'>" & DR("TrxnNo") & "</span>",
                        .TransactionDate = If(IsDBNull(DR("TransactionDate")), "", Convert.ToDateTime(DR("TransactionDate")).ToString("MM/dd/yyyy")),
                        .PayorName = "<span title='" & DR("PayorName") & "'>" & DR("PayorName") & "</span>",
                        .Remarks = "<span title='" & DR("Remarks") & "'>" & DR("Remarks") & "</span>",
                        .TotalAmount = "<span title='" & If(IsDBNull(DR("TotalAmount")), "0.00", Convert.ToDouble(DR("TotalAmount")).ToString("N2")) & "'>" & If(IsDBNull(DR("TotalAmount")), "0.00", Convert.ToDouble(DR("TotalAmount")).ToString("N2")) & "</span>"
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

    Function FIN080000_Post_Record(pTrxnNo, pPostedBy)

        ' Get EmpName based on CIIS_EmpCode
        Using conn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            conn.Open()
            Using cmd As New SqlCommand("SELECT LogName FROM calmardbLive.dbo.mstr_Users WHERE EmpCode = @EmpCode", conn)
                cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    pPostedBy = result.ToString()
                End If
            End Using

            If String.IsNullOrWhiteSpace(pPostedBy) Then
                Using cmd As New SqlCommand("SELECT initialname FROM employee WHERE emp_no = @EmpCode", conn)
                    cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        pPostedBy = result.ToString()
                    End If
                End Using
            End If
            conn.Close()
        End Using

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'execute procedure
        Using SqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using SqlCmd As New SqlCommand("calmardblive.dbo.JCF_PostPmtOrder", SqlConn)
                SqlCmd.CommandTimeout = 1500
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.Parameters.AddWithValue("@pTrxnNo", pTrxnNo)
                SqlCmd.Parameters.AddWithValue("@pPostedBy", pPostedBy)
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
            End Using
        End Using
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Function FIN080000_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("  SELECT ")
        Query.Append("      ICR_Assessment.TransactionNumber, ")
        Query.Append("      ICR_Assessment.TransactionDate, ")
        Query.Append("      ICR_Assessment.ClassCode, ")
        Query.Append("      mstr_EntityClasses.ClassDescription AS ClassCodeName, ")
        Query.Append("      ICR_Assessment.AcctNo, ")
        Query.Append("      ICR_Assessment.PayorName, ")
        Query.Append("      ICR_Assessment.ProjCode, ")
        Query.Append("      mstr_Projects.ProjInit AS ProjCodeName, ")
        Query.Append("      ICR_Assessment.PhaseNo, ")
        Query.Append("      ICR_Assessment.Block, ")
        Query.Append("      ICR_Assessment.Lot, ")
        Query.Append("      ICR_Assessment.Remarks, ")
        Query.Append("      ICR_Assessment.RmtCode, ")
        Query.Append("      ICR_Assessment.DocNo, ")
        Query.Append("      ICR_Assessment.DocDate, ")
        Query.Append("      ICR_Assessment.TotalAmount, ")
        Query.Append("      ICR_Assessment.AuditUser, ")
        Query.Append("      ICR_Assessment.AuditDate, ")
        Query.Append("      ICR_Assessment.PreparedBy, ")
        Query.Append("      ICR_Assessment.PostedBy, ")
        Query.Append("      ICR_Assessment.Posted, ")
        Query.Append("      ICR_Assessment.RvrsBy, ")
        Query.Append("      ICR_Assessment.RvrsDate, ")
        Query.Append("      ICR_Assessment.Rvrs, ")
        Query.Append("      ICR_Assessment.PayTypeCode, ")
        Query.Append("      format(ICR_Assessment.TransactionDate,'MM/dd/yyyy hh:mm tt') [PreparedDate], ")
        Query.Append("      ISNULL(updater.fullname, (SELECT TOP 1 emp2.fullname FROM mstr_users u JOIN cldc_live_acc.dbo.employee emp2 ON u.EmpCode = emp2.emp_no WHERE u.LogName = ICR_Assessment.PreparedBy)) AS PreparedByName, ")
        Query.Append("      (CASE WHEN ISNULL(ICR_Assessment.Posted, 0) = 1 THEN ISNULL(poster.fullname, (SELECT TOP 1 emp2.fullname FROM mstr_users u JOIN cldc_live_acc.dbo.employee emp2 ON u.EmpCode = emp2.emp_no WHERE u.LogName = ICR_Assessment.PostedBy)) ELSE '' END) AS PostedByName, ")
        Query.Append("      (CASE ")
        Query.Append("          WHEN ICR_Assessment.Posted = 0 THEN 'New' ")
        Query.Append("          WHEN ICR_Assessment.Posted = 1 THEN 'Posted' ")
        Query.Append("          WHEN ICR_Assessment.Posted IS NULL THEN 'Unposted' ")
        Query.Append("       END) AS RecordStatus ")
        Query.Append("  FROM ICR_Assessment ")
        Query.Append("  LEFT JOIN mstr_Projects ON ICR_Assessment.ProjCode = mstr_Projects.ProjCode ")
        Query.Append("  LEFT JOIN mstr_EntityClasses ON ICR_Assessment.ClassCode = mstr_EntityClasses.ClassCode ")
        Query.Append("  LEFT JOIN cldc_live_acc.dbo.employee AS updater ON ICR_Assessment.PreparedBy = updater.emp_no ")
        Query.Append("  LEFT JOIN cldc_live_acc.dbo.employee AS poster ON ICR_Assessment.PostedBy = poster.emp_no ")
        Query.Append("  WHERE ICR_Assessment.TransactionNumber = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                    .DocNo = DR("DocNo"),
                    .DocDate = If(IsDBNull(DR("DocDate")), "", Convert.ToDateTime(DR("DocDate")).ToString("MM/dd/yyyy")),
                    .TransactionNumber = DR("TransactionNumber"),
                    .TransactionDate = If(IsDBNull(DR("TransactionDate")), "", Convert.ToDateTime(DR("TransactionDate")).ToString("MM/dd/yyyy")),
                    .ClassCode = DR("ClassCode"),
                    .ClassCodeName = DR("ClassCodeName"),
                    .AcctNo = DR("AcctNo"),
                    .PayorName = DR("PayorName"),
                    .ProjCode = DR("ProjCode"),
                    .ProjCodeName = DR("ProjCodeName"),
                    .PhaseNo = DR("PhaseNo"),
                    .Block = DR("Block"),
                    .Lot = DR("Lot"),
                    .Remarks = DR("Remarks"),
                    .Posted = DR("Posted"),
                    .PreparedByName = DR("PreparedByName"),
                    .PreparedDate = DR("PreparedDate"),
                    .PostedByName = DR("PostedByName"),
                    .RecordStatus = DR("RecordStatus")
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

    Function FIN080000_Add_Record(pTransactionDate, pClassCode, pAcctNo, pPayorName, pProjCode, pPhaseNo, pBlock, pLot, pRemarks, pRmtCode, pAuditUser, pAuditDate, pPreparedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("DECLARE @ID NVARCHAR(13); ")
        Query.Append("EXEC New_Code 'ICR_Assessment', 'PO', @ID OUTPUT; ")
        Query.Append("INSERT INTO calmardblive.dbo.ICR_Assessment ")
        Query.Append("( [TransactionNumber], [TransactionDate], [ClassCode], [AcctNo], [PayorName], [ProjCode], ")
        Query.Append("[PhaseNo], [Block], [Lot], [Remarks], [RmtCode], [AuditUser], [AuditDate], ")
        Query.Append("[PreparedBy], [Posted], [Rvrs] ) ")
        Query.Append("VALUES ")
        Query.Append("( @ID, '" & pTransactionDate & "', '" & pClassCode & "', '" & pAcctNo & "', ")
        Query.Append("'" & pPayorName & "', '" & pProjCode & "', '" & pPhaseNo & "', '" & pBlock & "', ")
        Query.Append("'" & pLot & "', '" & pRemarks & "', '" & pRmtCode & "', '" & pAuditUser & "', ")
        Query.Append("GETDATE(), '" & pPreparedBy & "', 0, 0 ); ")
        Query.Append("SELECT @ID AS [oID];")
        'create variable

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function FIN080000_Edit_Record(pID, pClassCode, pAcctNo, pPayorName, pProjCode, pPhaseNo, pBlock, pLot, pRemarks, pRmtCode, pPreparedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("	UPDATE       calmardblive.dbo.ICR_Assessment ")
        Query.Append("	SET             ClassCode = '" & pClassCode & "', AcctNo = '" & pAcctNo & "', PayorName = '" & pPayorName & "', ProjCode = '" & pProjCode & "', PhaseNo = '" & pPhaseNo & "', Block = '" & pBlock & "', Lot = '" & pLot & "',  ")
        Query.Append("					Remarks = '" & pRemarks & "', RmtCode = '" & pRmtCode & "', PreparedBy = '" & pPreparedBy & "' ")
        Query.Append("	WHERE        TransactionNumber = '" & pID & "' ")
        'create variable

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

                    RecordList.Add(New With {.oID = pID})

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

    Function FIN080000_Get_Record_Dtl_Application(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append(" select ")
        Query.Append(" 	ICR_AssessmentDetails.TransactionNumber ")
        Query.Append(" 	,ICR_AssessmentDetails.AcctNo ")
        Query.Append(" 	,ICR_AssessmentDetails.PaymentFor AS [PaymentFor] ")
        Query.Append(" 	,mstr_PaymentType.PayDesc AS [Application] ")
        Query.Append(" 	,ICR_AssessmentDetails.PaymentDate ")
        Query.Append(" 	,ICR_AssessmentDetails.Amount AS [Amount] ")
        Query.Append(" 	,ICR_AssessmentDetails.AuditUser ")
        Query.Append(" 	,ICR_AssessmentDetails.AuditDate ")
        Query.Append(" from ")
        Query.Append(" 	ICR_AssessmentDetails ")
        Query.Append(" 	left join mstr_PaymentType on ICR_AssessmentDetails.PaymentFor = mstr_PaymentType.PayType ")
        Query.Append(" where  ")
        Query.Append(" 	ICR_AssessmentDetails.TransactionNumber = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & DR("TransactionNumber") & "','" & DR("PaymentFor") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn0102Edit('" & DR("PaymentFor") & "','" & DR("Amount") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("TransactionNumber"),
                        .Action = Action.ToString,
                        .Application = "<span title='" & DR("Application") & "'>" & DR("Application") & "</span>",
                        .Amount = "<span title='" & If(IsDBNull(DR("Amount")), "0.00", Convert.ToDouble(DR("Amount")).ToString("N2")) & "'>" & If(IsDBNull(DR("Amount")), "0.00", Convert.ToDouble(DR("Amount")).ToString("N2")) & "</span>"
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

    Function FIN080000_Redraw_Dtl_Application(pTrxnNo, pApplication)

        'query
        Dim Query As New StringBuilder
        Query.Append(" select ")
        Query.Append(" 	ICR_AssessmentDetails.TransactionNumber ")
        Query.Append(" 	,ICR_AssessmentDetails.AcctNo ")
        Query.Append(" 	,ICR_AssessmentDetails.PaymentFor AS [PaymentFor] ")
        Query.Append(" 	,mstr_PaymentType.PayDesc AS [Application] ")
        Query.Append(" 	,ICR_AssessmentDetails.PaymentDate ")
        Query.Append(" 	,ICR_AssessmentDetails.Amount AS [Amount] ")
        Query.Append(" 	,ICR_AssessmentDetails.AuditUser ")
        Query.Append(" 	,ICR_AssessmentDetails.AuditDate ")
        Query.Append(" from ")
        Query.Append(" 	ICR_AssessmentDetails ")
        Query.Append(" 	left join mstr_PaymentType on ICR_AssessmentDetails.PaymentFor = mstr_PaymentType.PayType ")
        Query.Append(" where  ")
        Query.Append(" 	ICR_AssessmentDetails.TransactionNumber = '" & pTrxnNo & "' ")
        Query.Append("  and ICR_AssessmentDetails.PaymentFor = '" & pApplication & "' ")
        Query.Append(" order by  ")
        Query.Append(" ICR_AssessmentDetails.AuditDate desc ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & DR("TransactionNumber") & "','" & DR("PaymentFor") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn0102Edit('" & DR("PaymentFor") & "','" & DR("Amount") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("TransactionNumber"),
                        .Action = Action.ToString,
                        .Application = "<span title='" & DR("Application") & "'>" & DR("Application") & "</span>",
                        .Amount = "<span title='" & If(IsDBNull(DR("Amount")), "0.00", Convert.ToDouble(DR("Amount")).ToString("N2")) & "'>" & If(IsDBNull(DR("Amount")), "0.00", Convert.ToDouble(DR("Amount")).ToString("N2")) & "</span>"
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

    Function FIN080000_Add_Application(pAcctNo, pTrxnNo, pApplication, pPaymentDate, pAmount, pAuditUser)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("INSERT INTO ICR_AssessmentDetails (")
        Query.Append("    [AcctNo],")
        Query.Append("    [TransactionNumber],")
        Query.Append("    [PaymentFor],")
        Query.Append("    [PaymentDate],")
        Query.Append("    [Amount],")
        Query.Append("    [AuditUser],")
        Query.Append("    [AuditDate]")
        Query.Append(") VALUES (")
        Query.Append("    '" & pAcctNo & "',")
        Query.Append("    '" & pTrxnNo & "',")
        Query.Append("    '" & pApplication & "',")
        Query.Append("    '" & pPaymentDate & "',")
        Query.Append("    " & CDbl(pAmount) & ",")
        Query.Append("    '" & pAuditUser & "',")
        Query.Append("    GETDATE()")
        Query.Append(");")
        'create variable

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pTrxnNo})

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

    Function FIN080000_Edit_Application(pID, pAcctNo, pTrxnNo, pApplication, pAmount, pAuditUser)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE ICR_AssessmentDetails SET ")
        Query.Append("PaymentFor = '" & pApplication & "', ")
        Query.Append("Amount = " & CDbl(pAmount) & ", ")
        Query.Append("AuditUser = '" & pAuditUser & "', ")
        Query.Append("AuditDate = GETDATE() ")
        Query.Append("WHERE TransactionNumber = '" & pTrxnNo & "' ")
        Query.Append("AND PaymentFor = '" & pID & "'; ")
        'create variable

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pTrxnNo})

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

#Region "FIN090000"

    Function FIN090000_Get_BranchCode()

        'query
        Dim Query As New StringBuilder()
        Query.Append("SELECT [A].OperatingCenterCode AS BranchCode ")
        Query.Append("       ,[A].OperatingCenterName AS BranchName ")
        Query.Append("FROM mstr_OperatingCenters [A] ")
        Query.Append("LEFT JOIN cldc_live_acc.dbo.employee [B] ON [A].BrnchCode = [B].buss_code  ")
        Query.Append("WHERE [B].emp_no = '" & CIIS_EmpCode & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .BranchCode = DR("BranchCode"),
                        .BranchName = DR("BranchName")
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

    Function FIN090000_Get_Bank()

        'query
        Dim Query As New StringBuilder()
        Query.Append("select ")
        Query.Append("	'' [ID] ")
        Query.Append("	,'Select Bank' [Name] ")
        Query.Append("    ,1 [Lock] ")
        Query.Append("    ,0 AS SortOrder  ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("	BankCode [ID] ")
        Query.Append("	,BankDesc [Name] ")
        Query.Append("    ,1 [Lock] ")
        Query.Append("	,1 AS SortOrder  ")
        Query.Append("from  ")
        Query.Append("	mstr_DraweeBanks ")
        Query.Append("ORDER BY SortOrder, [Name] ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
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

    Function FIN090000_Get_Record_Hdr(pBranch, pPost, pDocNoFrom, pDocNoTo, pDocDateFrom, pDocDateTo, pAuditUser)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetORList")
                Cmd.CommandTimeout = 300
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pBranch", pBranch)
                Cmd.Parameters.AddWithValue("@pPost", pPost)
                Cmd.Parameters.AddWithValue("@pDocNoFrom", pDocNoFrom)
                Cmd.Parameters.AddWithValue("@pDocNoTo", pDocNoTo)
                Cmd.Parameters.AddWithValue("@pDocDateFrom", pDocDateFrom)
                Cmd.Parameters.AddWithValue("@pDocDateTo", pDocDateTo)
                Cmd.Parameters.AddWithValue("@pAuditUser", pAuditUser)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('FIN090100-DTL-" & DR("DocNo") & "-" & CDate(DR("DocDate")).ToString("MMddyyyy") & "-" & DR("AcctNo") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("DocNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("DocNo") & "','" & CDate(DR("DocDate")).ToString("MMddyyyy") & "','" & DR("AcctNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn05Post('" & DR("DocNo") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("DocNo"),
                        .Action = Action.ToString,
                        .Posted = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Posted") = True, " checked='checked'", "") & " onclick='return false'/></div>",
                        .DocNo = "<span title='" & DR("DocNo") & "'>" & DR("DocNo") & "</span>",
                        .DocDate = If(IsDBNull(DR("DocDate")), "", Convert.ToDateTime(DR("DocDate")).ToString("MM/dd/yyyy")),
                        .Payee = "<span title='" & DR("Payee") & "'>" & DR("Payee") & "</span>",
                        .Particulars = "<span title='" & DR("Particulars") & "'>" & DR("Particulars") & "</span>",
                        .DocAmount = "<span title='" & If(IsDBNull(DR("DocAmount")), "0.00", Convert.ToDouble(DR("DocAmount")).ToString("N2")) & "'>" & If(IsDBNull(DR("DocAmount")), "0.00", Convert.ToDouble(DR("DocAmount")).ToString("N2")) & "</span>"
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

    Function FIN090000_Get_Mode(pAcctNo, pTrxnNo, pSeqNo)

        'query
        Dim Query As New StringBuilder
        Query.Append("select (case when '" & pSeqNo & "' in (select SeqNo from checks where AcctNo = '" & pAcctNo & "' and TrxnNo = '" & pTrxnNo & "') then 'Update' else 'Add' end) AS Mode ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Mode = DR("Mode")
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

    Function FIN090000_Redraw_Hdr(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append(" select ")
        Query.Append(" 	ICR_PaymentHeader.DocNo [DocNo] ")
        Query.Append(" 	,ICR_PaymentHeader.Posted ")
        Query.Append(" 	,(case when ICR_PaymentHeader.DocNo in (select ICR_ReversedORs.ORNumber from ICR_ReversedORs where ICR_ReversedORs.ORNumber = ICR_PaymentHeader.DocNo) then 1 else 0 end) [Cancel] ")
        Query.Append(" 	,ICR_PaymentHeader.DocDate ")
        Query.Append(" 	,ICR_PaymentHeader.Payee  ")
        Query.Append(" 	,ICR_PaymentHeader.Particulars  ")
        Query.Append(" 	,ICR_PaymentHeader.DocAmount ")
        Query.Append(" 	,ICR_PaymentHeader.AuditUser ")
        Query.Append(" 	,ICR_PaymentHeader.AcctNo ")
        Query.Append(" from ")
        Query.Append(" 	ICR_PaymentHeader ")
        Query.Append(" where ")
        Query.Append(" 	ICR_PaymentHeader.DocNo = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('FIN090100-DTL-" & DR("DocNo") & "-" & CDate(DR("DocDate")).ToString("MMddyyyy") & "-" & DR("AcctNo") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("DocNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("DocNo") & "','" & CDate(DR("DocDate")).ToString("MMddyyyy") & "','" & DR("AcctNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn05Post('" & DR("DocNo") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("DocNo"),
                        .Action = Action.ToString,
                        .Posted = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Posted") = True, " checked='checked'", "") & " onclick='return false'/></div>",
                        .DocNo = "<span title='" & DR("DocNo") & "'>" & DR("DocNo") & "</span>",
                        .DocDate = If(IsDBNull(DR("DocDate")), "", Convert.ToDateTime(DR("DocDate")).ToString("MM/dd/yyyy")),
                        .Payee = "<span title='" & DR("Payee") & "'>" & DR("Payee") & "</span>",
                        .Particulars = "<span title='" & DR("Particulars") & "'>" & DR("Particulars") & "</span>",
                        .DocAmount = "<span title='" & If(IsDBNull(DR("DocAmount")), "0.00", Convert.ToDouble(DR("DocAmount")).ToString("N2")) & "'>" & If(IsDBNull(DR("DocAmount")), "0.00", Convert.ToDouble(DR("DocAmount")).ToString("N2")) & "</span>"
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

    Function FIN090000_Post_Record(pDocNo, pPostedBy)

        ' Get EmpName based on CIIS_EmpCode
        Using conn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            conn.Open()
            Using cmd As New SqlCommand("SELECT LogName FROM calmardbLive.dbo.mstr_Users WHERE EmpCode = @EmpCode", conn)
                cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    pPostedBy = result.ToString()
                End If
            End Using

            If String.IsNullOrWhiteSpace(pPostedBy) Then
                Using cmd As New SqlCommand("SELECT initialname FROM employee WHERE emp_no = @EmpCode", conn)
                    cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        pPostedBy = result.ToString()
                    End If
                End Using
            End If
            conn.Close()
        End Using

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'execute procedure
        Using SqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using SqlCmd As New SqlCommand("calmardblive.dbo.JCF_PostOR", SqlConn)
                SqlCmd.CommandTimeout = 1500
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.Parameters.AddWithValue("@pDocNo", pDocNo)
                SqlCmd.Parameters.AddWithValue("@pPostedBy", pPostedBy)
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
            End Using
        End Using
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Function FIN090000_Generate_CI(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT01.rpt"), Path.Combine(reportFolderPath, "FIN09RPT01.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT01.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT01.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT01.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_SOR(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT02.rpt"), Path.Combine(reportFolderPath, "FIN09RPT02.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT02.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT02.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT02.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_RORMN(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT03.rpt"), Path.Combine(reportFolderPath, "FIN09RPT03.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT03.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT03.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT03.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_SORMN(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT04.rpt"), Path.Combine(reportFolderPath, "FIN09RPT04.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT04.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT04.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT04.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_RORSM(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT05.rpt"), Path.Combine(reportFolderPath, "FIN09RPT05.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT05.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT05.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT05.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_SORSM(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT06.rpt"), Path.Combine(reportFolderPath, "FIN09RPT06.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT06.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT06.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT06.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_RORLO(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT07.rpt"), Path.Combine(reportFolderPath, "FIN09RPT07.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT07.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT07.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT07.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_SORLO(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT08.rpt"), Path.Combine(reportFolderPath, "FIN09RPT08.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT08.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT08.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT08.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_RORBT(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT09.rpt"), Path.Combine(reportFolderPath, "FIN09RPT09.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT09.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT09.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT09.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_SORBT(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT10.rpt"), Path.Combine(reportFolderPath, "FIN09RPT10.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT10.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT10.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT10.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_RORSO(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT11.rpt"), Path.Combine(reportFolderPath, "FIN09RPT11.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT11.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT11.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT11.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_PL(pBranch As String, pUser As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pUser & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pUser & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT13.rpt"), Path.Combine(reportFolderPath, "FIN09RPT13.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT13.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@pBranch", pBranch)
            RptDoc.SetParameterValue("@pUser", pUser)
            RptDoc.SetParameterValue("@pDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT13.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & pUser & "/FIN09RPT13.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_PLA(pBranch As String, pUser As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pUser & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pUser & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT14.rpt"), Path.Combine(reportFolderPath, "FIN09RPT14.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT14.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@pBranch", pBranch)
            RptDoc.SetParameterValue("@pUser", pUser)
            RptDoc.SetParameterValue("@pDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT14.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & pUser & "/FIN09RPT14.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Generate_SORSO(pID As String, pDate As String, context As HttpContext) As String

        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim ID As String = pID.Trim().TrimEnd("."c)
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & ID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & ID & "/")

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
            File.Copy(context.Server.MapPath("~/Assets/Report/FIN09RPT12.rpt"), Path.Combine(reportFolderPath, "FIN09RPT12.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "FIN09RPT12.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = "calmardblive"
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, "calmardblive")
            RptDoc.SetParameterValue("@DocNo", pID)
            RptDoc.SetParameterValue("@DocDate", pDate)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "FIN09RPT12.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & ID & "/FIN09RPT12.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)

    End Function

    Function FIN090000_Get_Info_Dtl(pID, pDate, pAcctNo)

        'query
        Dim Query As New StringBuilder
        Query.Append(" select  ")
        Query.Append(" 	(case when ICR_PaymentHeader.IsSalesInvoice = 1 then 'Sales Invoice' when ICR_PaymentHeader.IsRegularReceipt = 1 then 'Regular OR' else 'Small OR' end) [Type] ")
        Query.Append(" 	,ICR_PaymentHeader.IsRegularReceipt ")
        Query.Append(" 	,ICR_PaymentHeader.IsSmallReceipt ")
        Query.Append(" 	,ICR_PaymentHeader.DocNo  ")
        Query.Append(" 	,ICR_PaymentHeader.DocDate  ")
        Query.Append(" 	,mstr_EntityClasses.ClassDescription  ")
        Query.Append(" 	,ICR_PaymentHeader.AcctNo AS AcctNo ")
        Query.Append(" 	,ICR_PaymentHeader.Payee [PayorName] ")
        Query.Append(" 	,ICR_Assessment.ProjCode ")
        Query.Append(" 	,mstr_Projects.ProjInit  ")
        Query.Append(" 	,ICR_Assessment.PhaseNo ")
        Query.Append(" 	,ICR_Assessment.Block  ")
        Query.Append(" 	,ICR_Assessment.Lot ")
        Query.Append(" 	,ICR_PaymentHeader.Particulars ")
        Query.Append(" 	,ICR_Assessment.TransactionNumber  ")
        Query.Append(" 	,ICR_Assessment.TransactionDate ")
        Query.Append(" 	,ICR_PaymentHeader.DocAmount ")
        Query.Append(" 	,ICR_PaymentHeader.IsCash ")
        Query.Append(" 	,ICR_PaymentHeader.CashAmt  ")
        Query.Append(" 	,ICR_PaymentHeader.IsCheckPayment ")
        Query.Append(" 	,ICR_PaymentHeader.CheckAmt  ")
        Query.Append(" 	,ICR_PaymentHeader.IsRemittance ")
        Query.Append(" 	,(case when ICR_PaymentHeader.IsRemittance = 1 then ICR_PaymentHeader.BankCode else '' end) [BankCode] ")
        Query.Append(" 	,(case when ICR_PaymentHeader.IsRemittance = 1 then mstr_DraweeBanks.BankDesc else '' end) [BankCodeName] ")
        Query.Append(" 	,(case when ICR_PaymentHeader.IsRemittance = 1 then ICR_PaymentHeader.PRDate else null end) [PRDate] ")
        Query.Append(" 	,ICR_PaymentHeader.RemittanceAmt  ")
        Query.Append(" 	,ICR_PaymentHeader.RmtCode ")
        Query.Append(" 	,isnull(ICR_PaymentHeader.CashAmt,0) + isnull(ICR_PaymentHeader.CheckAmt,0) + isnull(ICR_PaymentHeader.RemittanceAmt,0) [AmountReceived] ")
        Query.Append(" 	,(isnull(ICR_PaymentHeader.CashAmt,0) + isnull(ICR_PaymentHeader.CheckAmt,0) + isnull(ICR_PaymentHeader.RemittanceAmt,0)) - ICR_PaymentHeader.DocAmount [ChangeAmount] ")
        Query.Append(" 	,ICR_PaymentHeader.AuditUser  ")
        Query.Append(" 	,ICR_PaymentHeader.AuditDate ")
        Query.Append(" 	,ICR_PaymentHeader.PostedBy ")
        Query.Append(" 	,ICR_PaymentHeader.Posted ")
        Query.Append(" 	,(case when ICR_PaymentHeader.DocNo in (select ICR_ReversedORs.ORNumber from ICR_ReversedORs where ICR_ReversedORs.ORNumber = ICR_PaymentHeader.DocNo) then 1 else 0 end) [Cancel] ")
        Query.Append("  ,format(ICR_PaymentHeader.AuditDate,'MM/dd/yyyy hh:mm tt') [PreparedDate] ")
        Query.Append("  ,(case when isnull(ICR_PaymentHeader.Posted,0) = 1 then format(ICR_PaymentHeader.PostedDate,'MM/dd/yyyy hh:mm tt') else '' end) [PostedDate] ")
        Query.Append("  ,ISNULL(updater.fullname, (SELECT TOP 1 emp2.fullname FROM mstr_users u JOIN cldc_live_acc.dbo.employee emp2 ON u.EmpCode = emp2.emp_no WHERE u.LogName = ICR_PaymentHeader.AuditUser)) AS PreparedByName ")
        Query.Append("  ,(CASE WHEN ISNULL(ICR_PaymentHeader.Posted, 0) = 1 THEN ISNULL(poster.fullname, (SELECT TOP 1 emp2.fullname FROM mstr_users u JOIN cldc_live_acc.dbo.employee emp2 ON u.EmpCode = emp2.emp_no WHERE u.LogName = ICR_PaymentHeader.PostedBy)) ELSE '' END) AS PostedByName ")
        Query.Append("      ,(CASE ")
        Query.Append("          WHEN ICR_PaymentHeader.Posted = 0 THEN 'New' ")
        Query.Append("          WHEN ICR_PaymentHeader.Posted = 1 THEN 'Posted' ")
        Query.Append("          WHEN ICR_PaymentHeader.Posted IS NULL THEN 'Unposted' ")
        Query.Append("       END) AS RecordStatus ")
        Query.Append(" from ")
        Query.Append(" 	ICR_PaymentHeader  ")
        Query.Append(" 	left join ICR_Assessment on ICR_PaymentHeader.DocNo = ICR_Assessment.DocNo and cast(ICR_PaymentHeader.DocDate as date) = cast(ICR_Assessment.DocDate as date) and ICR_PaymentHeader.AcctNo = ICR_Assessment.AcctNo ")
        Query.Append(" 	left join mstr_EntityClasses on ICR_Assessment.ClassCode = mstr_EntityClasses.ClassCode ")
        Query.Append(" 	left join mstr_Projects on ICR_Assessment.ProjCode = mstr_Projects.ProjCode ")
        Query.Append(" 	left join mstr_DraweeBanks on ICR_PaymentHeader.BankCode = mstr_DraweeBanks.BankCode ")
        Query.Append("  left join cldc_live_acc.dbo.employee AS updater ON ICR_PaymentHeader.AuditUser = updater.emp_no ")
        Query.Append("  left join cldc_live_acc.dbo.employee AS poster ON ICR_PaymentHeader.PostedBy = poster.emp_no ")
        Query.Append(" where ")
        Query.Append(" 	ICR_PaymentHeader.DocNo = '" & pID & "' ")
        Query.Append(" 	and cast(ICR_PaymentHeader.DocDate as date) = '" & pDate & "' ")
        Query.Append(" 	and ICR_PaymentHeader.AcctNo = '" & pAcctNo & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                    .Type = DR("Type"),
                    .ORNo = DR("DocNo"),
                    .ORDate = If(IsDBNull(DR("DocDate")), "", Convert.ToDateTime(DR("DocDate")).ToString("MM/dd/yyyy")),
                    .Particular = DR("Particulars"),
                    .PayorClass = DR("ClassDescription"),
                    .AcctNo = DR("AcctNo"),
                    .PayorName = DR("PayorName"),
                    .ProjCode = DR("ProjCode"),
                    .ProjName = DR("ProjInit"),
                    .Phase = DR("PhaseNo"),
                    .Block = DR("Block"),
                    .Lot = DR("Lot"),
                    .TransactionNumber = DR("TransactionNumber"),
                    .TransactionDate = If(IsDBNull(DR("TransactionDate")), "", Convert.ToDateTime(DR("TransactionDate")).ToString("MM/dd/yyyy")),
                    .DocAmount = If(IsDBNull(DR("DocAmount")), "0.00", Convert.ToDouble(DR("DocAmount")).ToString("N2")),
                    .IsCash = DR("IsCash"),
                    .CashAmt = If(IsDBNull(DR("CashAmt")), "0.00", Convert.ToDouble(DR("CashAmt")).ToString("N2")),
                    .IsCheck = DR("IsCheckPayment"),
                    .CheckAmt = If(IsDBNull(DR("CheckAmt")), "0.00", Convert.ToDouble(DR("CheckAmt")).ToString("N2")),
                    .IsRemittance = DR("IsRemittance"),
                    .RemittanceAmt = If(IsDBNull(DR("RemittanceAmt")) OrElse String.IsNullOrWhiteSpace(DR("RemittanceAmt").ToString()), "0.00", Convert.ToDouble(DR("RemittanceAmt")).ToString("N2")),
                    .BankCode = DR("BankCode"),
                    .BankCodeName = If(IsDBNull(DR("BankCodeName")) OrElse String.IsNullOrWhiteSpace(DR("BankCodeName").ToString()), "-", DR("BankCodeName").ToString()),
                    .PRDate = If(IsDBNull(DR("PRDate")) OrElse String.IsNullOrWhiteSpace(DR("PRDate").ToString()), "-", Convert.ToDateTime(DR("PRDate")).ToString("MM/dd/yyyy")),
                    .RmtCode = If(IsDBNull(DR("RmtCode")) OrElse String.IsNullOrWhiteSpace(DR("RmtCode").ToString()), "-", DR("RmtCode").ToString()),
                    .Received = If(IsDBNull(DR("AmountReceived")), "0.00", Convert.ToDouble(DR("AmountReceived")).ToString("N2")),
                    .Change = If(IsDBNull(DR("ChangeAmount")), "0.00", Convert.ToDouble(DR("ChangeAmount")).ToString("N2")),
                    .Posted = DR("Posted"),
                    .PreparedByName = DR("PreparedByName"),
                    .PreparedDate = DR("PreparedDate"),
                    .PostedByName = DR("PostedByName"),
                    .PostedDate = DR("PostedDate"),
                    .RecordStatus = DR("RecordStatus")
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

    Function FIN090000_Get_Application_Dtl(pID, pDate, pAcctNo)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ICR_AssessmentDetails.TransactionNumber ")
        Query.Append("	,ICR_AssessmentDetails.AcctNo ")
        Query.Append("	,ICR_AssessmentDetails.PaymentFor ")
        Query.Append("	,mstr_PaymentType.PayDesc AS Application ")
        Query.Append("	,ICR_AssessmentDetails.PaymentDate ")
        Query.Append("	,ICR_AssessmentDetails.Amount AS Amount ")
        Query.Append("	,ICR_AssessmentDetails.AuditUser ")
        Query.Append("	,ICR_AssessmentDetails.AuditDate ")
        Query.Append("from ")
        Query.Append("	ICR_AssessmentDetails ")
        Query.Append("	left join ICR_Assessment on ICR_AssessmentDetails.TransactionNumber = ICR_Assessment.TransactionNumber  ")
        Query.Append("	left join ICR_PaymentHeader on ICR_Assessment.DocNo = ICR_PaymentHeader.DocNo and cast(ICR_Assessment.DocDate as date) = cast(ICR_PaymentHeader.DocDate as date) and ICR_PaymentHeader.AcctNo = ICR_Assessment.AcctNo   ")
        Query.Append("	left join mstr_PaymentType on ICR_AssessmentDetails.PaymentFor = mstr_PaymentType.PayType ")
        Query.Append("where  ")
        Query.Append(" 	ICR_PaymentHeader.DocNo = '" & pID & "' ")
        Query.Append(" 	and cast(ICR_PaymentHeader.DocDate as date) = '" & pDate & "' ")
        Query.Append(" 	and ICR_PaymentHeader.AcctNo = '" & pAcctNo & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Application = "<span title='" & DR("Application") & "'>" & DR("Application") & "</span>",
                        .Amount = "<span title='" & If(IsDBNull(DR("Amount")), "0.00", Convert.ToDouble(DR("Amount")).ToString("N2")) & "'>" & If(IsDBNull(DR("Amount")), "0.00", Convert.ToDouble(DR("Amount")).ToString("N2")) & "</span>"
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

    Function FIN090000_Get_Record_Add(pBranch)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetORPOList")
                Cmd.CommandTimeout = 300
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pBranch", pBranch)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("TransactionNumber"),
                        .CheckBox = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' data-trxno='" & DR("TransactionNumber") & "'/></div>",
                        .TrxnNo = "<span title='" & DR("TransactionNumber") & "'>" & DR("TransactionNumber") & "</span>",
                        .TrxnDate = If(IsDBNull(DR("TransactionDate")), "", Convert.ToDateTime(DR("TransactionDate")).ToString("MM/dd/yyyy")),
                        .PayorName = "<span title='" & DR("PayorName") & "'>" & DR("PayorName") & "</span>",
                        .TotalAmount = "<span title='" & If(IsDBNull(DR("TotalAmount")), "0.00", Convert.ToDouble(DR("TotalAmount")).ToString("N2")) & "'>" & If(IsDBNull(DR("TotalAmount")), "0.00", Convert.ToDouble(DR("TotalAmount")).ToString("N2")) & "</span>",
                        .Action = "<div class='d-flex justify-content-center flex-shrink-0'><button id='" & DR("TransactionNumber") & "' class='btn btn-sm btn-add w-100 receive' onclick="" fn01Add_Ok('" & DR("TransactionNumber") & "');return false""><span>Add</span></button></div>"
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

    Function FIN090000_Add_Record(pIsRegularOR, pBranch, pTrxnNo, pCreatedBy)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "JCF_NewOR"
        SqlCmd.Parameters.AddWithValue("@pIsRegularOR", pIsRegularOR)
        SqlCmd.Parameters.AddWithValue("@pBranch", pBranch)
        SqlCmd.Parameters.AddWithValue("@pTrxnNo", pTrxnNo)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        SqlCmd.Parameters.AddWithValue("@oDocNo", "")
        Dim oMessage As New SqlClient.SqlParameter("@oMessage", SqlDbType.NVarChar, 1000)
        oMessage.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oMessage)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = oMessage.Value.ToString})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Function FIN090000_Edit_Record(pID, pDocNo, pDocDate, pTransactionNumber, pParticular, pIsCash, pCashAmt, pIsCheck, pCheckAmt, pIsRem, pRmtCode, pBankCode, pPRDate, pRemAmt, pAuditUser)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE       calmardblive.dbo.ICR_Assessment ")
        Query.Append("SET          DocNo = '" & pDocNo & "' ")
        Query.Append("			  ,DocDate = '" & pDocDate & "' ")
        Query.Append("WHERE        (TransactionNumber = '" & pTransactionNumber & "') ")
        Query.Append("UPDATE       calmardblive.dbo.ICR_PaymentHeader ")
        Query.Append("SET          DocNo = '" & pDocNo & "' ")
        Query.Append("			  ,DocDate = '" & pDocDate & "' ")
        Query.Append("			  ,Particulars = '" & pParticular & "' ")
        Query.Append("			  ,IsCash = '" & pIsCash & "' ")
        Query.Append("			  ,CashAmt = '" & CDbl(pCashAmt) & "' ")
        Query.Append("			  ,IsCheckPayment = '" & pIsCheck & "' ")
        Query.Append("		  	  ,CheckAmt = '" & CDbl(pCheckAmt) & "' ")
        Query.Append("		  	  ,IsRemittance = '" & pIsRem & "' ")
        Query.Append("			  ,RmtCode = '" & pRmtCode & "' ")
        Query.Append("			  ,BankCode = '" & pBankCode & "' ")
        Query.Append("			  ,PRDate = '" & pPRDate & "' ")
        Query.Append("			  ,RemittanceAmt = '" & CDbl(pRemAmt) & "' ")
        Query.Append("			  ,AuditUser = '" & pAuditUser & "' ")
        Query.Append("			  ,AuditDate = getdate() ")
        Query.Append("WHERE        (DocNo = '" & pID & "') AND (Posted = 0) ")
        'create variable

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                RecordList.Add(New With {.oID = pID})
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function FIN090000_Get_Check(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	ICR_PaymentHeader.DocNo [ORNo] ")
        Query.Append("	,ICR_Assessment.TransactionNumber [TrxnNo] ")
        Query.Append("	,(select top 1 checks.DraweeBankCode from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 1) [DraweeBankCode1] ")
        Query.Append("	,(select top 1 mstr_DraweeBanks.BankDesc from checks left join mstr_DraweeBanks on checks.DraweeBankCode = mstr_DraweeBanks.BankCode where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 1) [DraweeBankCodeName1] ")
        Query.Append("	,(select top 1 checks.CheckNo from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 1) [CheckNo1] ")
        Query.Append("	,(select top 1 checks.CheckDate from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 1) [CheckDate1] ")
        Query.Append("	,isnull((select top 1 checks.CheckAmount from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 1),0) [CheckAmount1] ")
        Query.Append("	,(select top 1 checks.DraweeBankCode from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 2) [DraweeBankCode2] ")
        Query.Append("	,(select top 1 mstr_DraweeBanks.BankDesc from checks left join mstr_DraweeBanks on checks.DraweeBankCode = mstr_DraweeBanks.BankCode where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 2) [DraweeBankCodeName2] ")
        Query.Append("	,(select top 1checks.CheckNo from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 2) [CheckNo2] ")
        Query.Append("	,(select top 1 checks.CheckDate from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 2) [CheckDate2] ")
        Query.Append("	,isnull((select top 1 checks.CheckAmount from checks where checks.ORNo = ICR_PaymentHeader.DocNo and checks.TrxnNo = ICR_Assessment.TransactionNumber and checks.SeqNo = 2),0) [CheckAmount2] ")
        Query.Append("from ")
        Query.Append("	ICR_PaymentHeader  ")
        Query.Append("	left join ICR_Assessment on ICR_PaymentHeader.DocNo = ICR_Assessment.DocNo ")
        Query.Append("where ")
        Query.Append("	ICR_PaymentHeader.DocNo = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                    .ORNo = DR("ORNo"),
                    .TrxnNo = DR("TrxnNo"),
                    .Bank1 = DR("DraweeBankCodeName1"),
                    .BankCode1 = If(IsDBNull(DR("DraweeBankCode1")), 0, DR("DraweeBankCode1")),
                    .CheckNo1 = DR("CheckNo1"),
                    .CheckDate1 = If(IsDBNull(DR("CheckDate1")), "", Convert.ToDateTime(DR("CheckDate1")).ToString("MM/dd/yyyy")),
                    .CheckAmount1 = If(IsDBNull(DR("CheckAmount1")), "0.00", Convert.ToDouble(DR("CheckAmount1")).ToString("N2")),
                    .Bank2 = DR("DraweeBankCodeName2"),
                    .BankCode2 = If(IsDBNull(DR("DraweeBankCode2")), 0, DR("DraweeBankCode2")),
                    .CheckNo2 = DR("CheckNo2"),
                    .CheckDate2 = If(IsDBNull(DR("CheckDate2")), "", Convert.ToDateTime(DR("CheckDate2")).ToString("MM/dd/yyyy")),
                    .CheckAmount2 = If(IsDBNull(DR("CheckAmount2")), "0.00", Convert.ToDouble(DR("CheckAmount2")).ToString("N2"))
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

    Function FIN090000_Add_Check(pAcctNo, pTrxnNo, pSeqNo, pORNo, pProjCode, pPhase, pBlock, pLot, pAcctname, pBank, pCheckNo, pCheckDate, pCheckAmt, pAuditUser)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("INSERT INTO Checks(")
        Query.Append("AcctNo, ")
        Query.Append("TrxnNo, ")
        Query.Append("SeqNo, ")
        Query.Append("ORNo, ")
        Query.Append("ProjCode, ")
        Query.Append("Phase, ")
        Query.Append("Block, ")
        Query.Append("Lot, ")
        Query.Append("Acctname, ")
        Query.Append("DraweeBankCode, ")
        Query.Append("CheckNo, ")
        Query.Append("CheckDate, ")
        Query.Append("CheckAmount, ")
        Query.Append("AuditUser, ")
        Query.Append("AuditDate, ")
        Query.Append("Subs, ")
        Query.Append("CheckStatus, ")
        Query.Append("Posted,  ")
        Query.Append("PaymentApplication,  ")
        Query.Append("CheckType, ")
        Query.Append("CheckClass) ")
        Query.Append("VALUES( ")
        Query.Append("'" & pAcctNo & "', ")
        Query.Append("'" & pTrxnNo & "', ")
        Query.Append("'" & pSeqNo & "', ")
        Query.Append("'" & pORNo & "', ")
        Query.Append("'" & pProjCode & "', ")
        Query.Append("'" & pPhase & "', ")
        Query.Append("'" & pBlock & "', ")
        Query.Append("'" & pLot & "', ")
        Query.Append("'" & pAcctname & "', ")
        Query.Append("'" & pBank & "', ")
        Query.Append("'" & pCheckNo & "', ")
        If pCheckDate = "" Then
            Query.Append("NULL, ")
        Else
            Query.Append("'" & pCheckDate & "', ")
        End If
        Query.Append("'" & CDbl(pCheckAmt) & "', ")
        Query.Append("'" & pAuditUser & "', ")
        Query.Append("getdate(), ")
        Query.Append("'', ")
        Query.Append("0, ")
        Query.Append("0, ")
        Query.Append("- 1, ")
        Query.Append("2, ")
        Query.Append("1) ")
        'create variable

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pAcctNo})

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

    Function FIN090000_Upd_Check(pAcctNo, pTrxnNo, pSeqNo, pBank, pCheckNo, pCheckDate, pCheckAmt, pAuditUser)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE Checks SET  ")
        Query.Append("DraweeBankCode = '" & pBank & "',  ")
        Query.Append("CheckNo = '" & pCheckNo & "',  ")
        If pCheckDate = "" Then
            Query.Append("CheckDate = NULL, ")
        Else
            Query.Append("CheckDate = '" & pCheckDate & "', ")
        End If
        Query.Append("CheckAmount = '" & CDbl(pCheckAmt) & "',  ")
        Query.Append("AuditUser = '" & pAuditUser & "',  ")
        Query.Append("AuditDate = getdate() ")
        Query.Append("WHERE (AcctNo = '" & pAcctNo & "') AND  (TrxnNo = '" & pTrxnNo & "') AND (SeqNo = '" & pSeqNo & "') ")
        'create variable

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pAcctNo})

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

    Function FIN090000_Del_Check(pAcctNo, pTrxnNo, pSeqNo)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("DELETE FROM Checks ")
        Query.Append("WHERE        (AcctNo = '" & pAcctNo & "') AND (TrxnNo = '" & pTrxnNo & "') AND (SeqNo = '" & pSeqNo & "') ")
        'create variable

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pAcctNo})

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

    Function FIN090000_Upd_OR(pTotalAmount, pORNo, pORDate)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE       ICR_PaymentHeader ")
        Query.Append("SET                CheckAmt = '" & CDbl(pTotalAmount) & "', IsCheckPayment = 1 ")
        Query.Append("WHERE        (DocNo = '" & pORNo & "' and cast(DocDate as date) = '" & pORDate & "') ")
        'create variable

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {.oID = pORNo})

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

#Region "FIN090100"
    Function FIN090100_Get_Payment_Order(pDate)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetPDC_ForPO")
                Cmd.CommandTimeout = 300
                Cmd.CommandType = CommandType.StoredProcedure
                If pDate Is Nothing Then
                    Cmd.Parameters.AddWithValue("@pDate", DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue("@pDate", pDate)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check row-checkbox' type='checkbox' data-kt-code='" & DR("AcctNo") & "' data-kt-no='" & DR("CheckNo") & "' /></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("AcctNo"),
                        .Action = Action.ToString(),
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName"),
                        .Type = DR("Type"),
                        .CheckNo = DR("CheckNo"),
                        .CheckDate = If(IsDBNull(DR("CheckDate")), "", Convert.ToDateTime(DR("CheckDate")).ToString("MM/dd/yyyy")),
                        .CheckAmt = DR("CheckAmount"),
                        .TrxnNo = DR("TrxnNo"),
                        .DraweeBankCodeName = DR("DraweeBankCodeName"),
                        .DepositoryBankCodeName = DR("DepositoryBankCodeName"),
                        .Application = DR("Application")
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
    Function FIN090100_New_Payment_Order(pCheckSrs, pAuditUser)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "JCF_NewPDCPaymentOrder"
        SqlCmd.Parameters.AddWithValue("@pCheckNoSrs", pCheckSrs)
        SqlCmd.Parameters.AddWithValue("@pAuditUser", pAuditUser)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function FIN090100_Get_Remittance()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [RMT].RmtCode ")
        Query.Append("  ,[BNK].bank [BankName] ")
        Query.Append("  ,Format([RMT].Date, 'MM/dd/yyyy') [Date] ")
        Query.Append("  ,[RMT].Amount ")
        Query.Append("from ")
        Query.Append("  cldc_live_acc.dbo.Trxn_CashFlow_Remittance [RMT] ")
        Query.Append("  left join cldc_live_acc.dbo.fin_bank [BNK] on [RMT].Bank = [BNK].b_code ")
        Query.Append("where ")
        Query.Append("  [RMT].ORAmt = 0 ")
        Query.Append("order by ")
        Query.Append("  [BankName] ")
        Query.Append("  ,Date ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .rowId = "rowID0103" & DR("RmtCode"),
                        .RmtCode = DR("RmtCode"),
                        .BankName = DR("BankName"),
                        .Date = DR("Date"),
                        .Amount = DR("Amount"),
                        .Class = "",
                        .Payor = "",
                        .PayorName = "",
                        .Application = "",
                        .Status = ""
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
    Function FIN090100_Remittance_Class()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].ClassCode ")
        Query.Append("  ,[A].ClassDescription [Description] ")
        Query.Append("from ")
        Query.Append("  mstr_EntityClasses [A] ")
        Query.Append("order by ")
        Query.Append("  [Description] ")
        'get query

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                        .Code = DR("ClassCode"),
                        .Description = DR("Description")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordInfo, Formatting.None)
        'display 

    End Function
    Function FIN090100_Remittance_Payor(pClass)

        'get query
        Dim Query As New StringBuilder
        If pClass = 1 Then
            Query.Append("select ")
            Query.Append("  mstr_EntityInstances.EntityCode [Code] ")
            Query.Append("  ,mstr_Entities.CompoundName [Description] ")
            Query.Append("from ")
            Query.Append("  mstr_EntityInstances ")
            Query.Append("  left join mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("  mstr_EntityInstances.ClassCode = '1' ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 2 Then
            Query.Append("select ")
            Query.Append("  mstr_EntityInstances.EntityCode [Code] ")
            Query.Append("  ,mstr_Entities.CompoundName [Description] ")
            Query.Append("from ")
            Query.Append("  mstr_EntityInstances ")
            Query.Append("  left join mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("  mstr_EntityInstances.ClassCode = '2' ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 3 Then
            Query.Append("select ")
            Query.Append("  mstr_EntityInstances.EntityCode [Code] ")
            Query.Append("  ,mstr_Entities.CompoundName [Description] ")
            Query.Append("from ")
            Query.Append("  mstr_EntityInstances ")
            Query.Append("  left join mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("  mstr_EntityInstances.ClassCode = '3' ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 4 Then
            Query.Append("select ")
            Query.Append("  ICR_Buyers.AcctNo [Code] ")
            Query.Append("  ,ICR_Buyers.AcctName [Description] ")
            Query.Append("from ")
            Query.Append("  ICR_Buyers ")
            Query.Append("  left join mstr_Projects on ICR_Buyers.ProjCode = mstr_Projects.ProjCode ")
            Query.Append("where ")
            Query.Append("  ICR_Buyers.Active = 1 ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 5 Then
            Query.Append("select ")
            Query.Append("  mstr_EntityInstances.EntityCode [Code] ")
            Query.Append("  ,mstr_Entities.CompoundName [Description] ")
            Query.Append("from ")
            Query.Append("  mstr_EntityInstances ")
            Query.Append("  left join mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("  mstr_EntityInstances.ClassCode = '5' ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 6 Then
            Query.Append("select ")
            Query.Append("  mstr_EntityInstances.EntityCode [Code] ")
            Query.Append("  ,mstr_Entities.CompoundName [Description] ")
            Query.Append("from ")
            Query.Append("  mstr_EntityInstances ")
            Query.Append("  left join mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("  mstr_EntityInstances.ClassCode = '6' ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 7 Then
            Query.Append("select ")
            Query.Append("  mstr_EntityInstances.EntityCode [Code] ")
            Query.Append("  ,mstr_Entities.CompoundName [Description] ")
            Query.Append("from ")
            Query.Append("  mstr_EntityInstances ")
            Query.Append("  left join mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("  mstr_EntityInstances.ClassCode = '7' ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 9 Then
            Query.Append("select ")
            Query.Append("  mstr_EntityInstances.EntityCode [Code] ")
            Query.Append("  ,mstr_Entities.CompoundName [Description] ")
            Query.Append("from ")
            Query.Append("  mstr_EntityInstances ")
            Query.Append("  left join mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("  mstr_EntityInstances.ClassCode = '9' ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 10 Then
            Query.Append("select ")
            Query.Append("  Code [Code] ")
            Query.Append("  ,Name [Description] ")
            Query.Append("from ")
            Query.Append("  JCF_LotConnection ")
            Query.Append("where ")
            Query.Append("  ElecStatus = 1 ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 11 Then
            Query.Append("select ")
            Query.Append("  Code [Code] ")
            Query.Append("  ,Name [Description] ")
            Query.Append("from ")
            Query.Append("  JCF_LotConnection ")
            Query.Append("where ")
            Query.Append("  WaterStatus = 1 ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 12 Then
            Query.Append("select ")
            Query.Append("  Code [Code] ")
            Query.Append("  ,Name [Description] ")
            Query.Append("from ")
            Query.Append("  JCF_LotConnection ")
            Query.Append("where ")
            Query.Append("  MgtStatus = 1 ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        ElseIf pClass = 13 Then
            Query.Append("select ")
            Query.Append("  Code [Code] ")
            Query.Append("  ,Name [Description] ")
            Query.Append("from ")
            Query.Append("  JCF_LotConnection ")
            Query.Append("where ")
            Query.Append("  MgtLOStatus = 1 ")
            Query.Append("order by ")
            Query.Append("  [Description] ")
        End If
        'get query

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                        .Code = DR("Code"),
                        .Description = DR("Description")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordInfo, Formatting.None)
        'display 

    End Function
    Function FIN090100_Remittance_Application()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  cast(PayType as nvarchar(13)) [Code] ")
        Query.Append("  ,PayDesc [Description] ")
        Query.Append("from ")
        Query.Append("  mstr_PaymentType ")
        Query.Append("where ")
        Query.Append("  Active = 1 ")
        Query.Append("order by ")
        Query.Append("  [Description] ")
        'get query

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                        .Code = DR("Code"),
                        .Description = DR("Description")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordInfo, Formatting.None)
        'display 

    End Function
    Function FIN090100_Add_Remittance(pRmtCode, pClassCode, pAcctNo, pAcctName, pPmtType, pAuditUser)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "JCF_NewRmtPaymentOrder"
        SqlCmd.Parameters.AddWithValue("@pRmtCode", pRmtCode)
        SqlCmd.Parameters.AddWithValue("@pClassCode", pClassCode)
        SqlCmd.Parameters.AddWithValue("@pAcctNo", pAcctNo)
        SqlCmd.Parameters.AddWithValue("@pAcctName", pAcctName)
        SqlCmd.Parameters.AddWithValue("@pPmtType", pPmtType)
        SqlCmd.Parameters.AddWithValue("@pAuditUser", pAuditUser)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function FIN090100_Get_OR(pAuditUser)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @EmpCode nvarchar(13) = '" & pAuditUser & "' ")
        Query.Append("declare @LogName nvarchar(60) = (select top 1 LogName from mstr_Users where EmpCode = @EmpCode) ")
        Query.Append("declare @User nvarchar(60) = (select top 1 LastName + ', ' + FirstName from mstr_Users where EmpCode = @EmpCode) ")
        Query.Append("declare @Location nvarchar(20) = (select OCORID from mstr_OperatingCenters where BrnchCode = ((select buss_code from cldc_live_acc.dbo.employee where emp_no = @EmpCode))) ")
        Query.Append("declare @Branch nvarchar(60) = (select OperatingCenterName from mstr_OperatingCenters where BrnchCode = ((select buss_code from cldc_live_acc.dbo.employee where emp_no = @EmpCode))) ")
        Query.Append("declare @ORNo nvarchar(60) = (case when (select ParamValue from mstr_Parameters where ParamDesc = 'ORNO' and Remarks = @LogName) IS NULL then (select ParamValue from mstr_Parameters where ParamDesc = 'ORNO' and Remarks = @EmpCode) else (select ParamValue from mstr_Parameters where ParamDesc = 'ORNO' and Remarks = @LogName) end) ")
        Query.Append("declare @SORNo nvarchar(60) = (case when (select ParamValue from mstr_Parameters where ParamDesc = 'SORNO' and Remarks = @LogName) IS NULL then (select ParamValue from mstr_Parameters where ParamDesc = 'SORNO' and Remarks = @EmpCode) else (select ParamValue from mstr_Parameters where ParamDesc = 'SORNO' and Remarks = @LogName) end) ")
        Query.Append("select @User [User], @Location [Location], @Branch [Branch], @ORNo [ORNo], @SORNo [SORNo] ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .User = DR("User"),
                        .Location = DR("Location"),
                        .Branch = DR("Branch"),
                        .ORNo = DR("ORNo"),
                        .SORNo = If(IsDBNull(DR("SORNo")), "", DR("SORNo").ToString())
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
    Function FIN090100_Edit_OR_SOR(pORNo, pSORNo, pAuditUser)

        'update query
        Dim Query As New StringBuilder
        Query.Append("declare @EmpCode nvarchar(13) = '" & pAuditUser & "' ")
        Query.Append("declare @LogName nvarchar(60) = (select LogName from mstr_Users where EmpCode = @EmpCode) ")
        'OR No
        Query.Append("UPDATE mstr_Parameters SET ")
        Query.Append("  ParamValue = '" & pORNo & "' ")
        Query.Append("  ,AuditUser = @LogName ")
        Query.Append("  ,AuditDate = GETDATE() ")
        Query.Append("WHERE ")
        Query.Append("  ParamDesc = 'ORNO' ")
        Query.Append("  AND Remarks = @LogName ")
        'Small OR No
        Query.Append("UPDATE mstr_Parameters SET ")
        Query.Append("  ParamValue = '" & pSORNo & "' ")
        Query.Append("  ,AuditUser = @LogName ")
        Query.Append("  ,AuditDate = GETDATE() ")
        Query.Append("WHERE ")
        Query.Append("  ParamDesc = 'SORNO' ")
        Query.Append("  AND Remarks = @LogName ")
        'update query

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                        .oReturn = "Success"
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordInfo, Formatting.None)
        'display 

    End Function
    Function FIN090100_Get_OR_Reversal(pDocNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @DocNo nvarchar(500) = '" & pDocNo & "' ")
        Query.Append("select ")
        Query.Append("  DocNo ")
        Query.Append("  ,DocType ")
        Query.Append("  ,DocDate [InitDocDate] ")
        Query.Append("  ,Format(DocDate, 'MM/dd/yyyy') [DocDate] ")
        Query.Append("  ,AcctNo ")
        Query.Append("  ,Payee ")
        Query.Append("  ,BankCode ")
        Query.Append("  ,PRNo ")
        Query.Append("  ,PRDate ")
        Query.Append("  ,DocAmount ")
        Query.Append("  ,Particulars ")
        Query.Append("  ,IsCheckPayment ")
        Query.Append("  ,Posted ")
        Query.Append("  ,Active ")
        Query.Append("  ,PayType ")
        Query.Append("  ,IsRemittance ")
        Query.Append("  ,IsRegularReceipt ")
        Query.Append("  ,BatchDepositTransNo ")
        Query.Append("  ,OperatingCenterCode ")
        Query.Append("  ,AuditUser ")
        Query.Append("  ,AuditDate ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,Phase ")
        Query.Append("  ,Block ")
        Query.Append("  ,Lot ")
        Query.Append("  ,IsCash ")
        Query.Append("  ,IsSmallReceipt ")
        Query.Append("  ,CashAmt ")
        Query.Append("  ,CheckAmt ")
        Query.Append("  ,RemittanceAmt ")
        Query.Append("  ,PostedBy ")
        Query.Append("  ,PostedDate ")
        Query.Append("  ,RvrsBy ")
        Query.Append("  ,RvrsDate ")
        Query.Append("  ,Rvrs ")
        Query.Append("  ,Reason ")
        Query.Append("from ")
        Query.Append("  ICR_PaymentHeader ")
        Query.Append("where ")
        Query.Append("  Posted = 1 ")
        Query.Append(" and DocNo like '%' + @DocNo + '%' ")
        'get query

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check row-checkbox' type='checkbox' data-kt-no='" & DR("AcctNo") & "' data-kt-doc='" & DR("DocNo") & "' data-kt-date='" & DR("InitDocDate") & "' /></div>")

                    RecordInfo.Add(New With {
                        .rowId = "rowID0105" & DR("DocNo"),
                        .Action = Action.ToString(),
                        .DocNo = DR("DocNo"),
                        .DocType = DR("DocType"),
                        .DocDate = DR("DocDate"),
                        .Payee = DR("Payee"),
                        .DocAmount = DR("DocAmount")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordInfo, Formatting.None)
        'display 

    End Function
    Function FIN090100_OR_Reverse_Record(pDocNo, pDocDate, pAcctNo, pReason, pAuditUser)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & calmardblive & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "JCF_RvrsOR"
        SqlCmd.Parameters.AddWithValue("@pDocNo", pDocNo)
        SqlCmd.Parameters.AddWithValue("@pDocDate", pDocDate)
        SqlCmd.Parameters.AddWithValue("@pAcctNo", pAcctNo)
        SqlCmd.Parameters.AddWithValue("@pReason", pReason)
        SqlCmd.Parameters.AddWithValue("@pPostedBy", pAuditUser)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
#End Region

End Class