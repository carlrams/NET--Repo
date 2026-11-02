Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Threading.Tasks
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.UI.WebControls.Expressions
Imports System.Windows.Interop
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.Web
Imports Microsoft.Ajax.Utilities
Imports Microsoft.SqlServer
Imports Microsoft.SqlServer.Server
Imports Microsoft.VisualBasic.ApplicationServices
Imports OfficeOpenXml.ConditionalFormatting.Contracts
Imports WebGrease.Css.Ast


Public Class SCM000011
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

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")
            Dim pFormCode = context.Request("pFormCode")
            Dim pType = context.Request("pType")
            'general parameter

            If pFormCode = "SCM010101" And pType = "Validate - Record" Then

                Dim pID = context.Request("pID")
                Dim pValue01 = context.Request("pValue01")
                Dim pValue02 = context.Request("pValue02")
                Dim pGroup = context.Request("pGroup")
                Dim pFType = context.Request("pFType")

                Dim json As String = Me.Validate_Record(pID, pValue01, pValue02, pGroup, pFType)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010102" And pType = "Validate - House Construction - Record" Then

                Dim pID = context.Request("pID")
                Dim pValue01 = context.Request("pValue01")
                Dim pValue02 = context.Request("pValue02")
                Dim pGroup = context.Request("pGroup")
                Dim pFType = context.Request("pFType")

                Dim json As String = Me.Validate02_Record(pID, pValue01, pValue02, pGroup, pFType)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCD010000" And Type = "Dashboard - Form (Project)" Then

                Dim Year = context.Request("Year")

                Dim json As String = Me.SCD010000_Get_Form_Year(Year)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCD010000" And Type = "Dashboard - Batch (Project)" Then

                Dim Year = context.Request("Year")

                Dim json As String = Me.SCD010000_Get_Batch_Year(Year)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If pFormCode = "SCM010100" And pType = "Contract Management - For Award - Header" Then

                Dim json As String = Me.SCM010100_Get_Header()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010100" And pType = "Contract Management - Get Record - Repair" Then

                Dim pEmpCode = CIIS_EmpCode

                Dim json As String = Me.SCM010100_Get_Record_Repair(pEmpCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010100" And pType = "Contract Management - Get Record - House Construction" Then

                Dim json As String = Me.SCM010100_Get_Record_House_Construction()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010100" And pType = "Contract Management - Get Record - Repair Details" Then

                Dim pDivCode = context.Request("pDivCode")
                Dim pEmpCode = CIIS_EmpCode

                Dim json As String = Me.SCM010100_Get_Record_Repair_Details(pDivCode, pEmpCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010100" And pType = "Contract Management - Get Record - House Construction Details" Then

                Dim pDivCode = context.Request("pDivCode")

                Dim json As String = Me.SCM010100_Get_Record_House_Construction_Details(pDivCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010100" And pType = "Contract Management - Get Record" Then

                Dim pCode = context.Request("pCode")
                Dim pSubdCode = context.Request("pSubdCode")

                Dim json As String = Me.SCM010100_Get_Record(pCode, pSubdCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010100" And pType = "Contract Management - House Construction - Get Record" Then

                Dim pSubdCode = context.Request("pSubdCode")

                Dim json As String = Me.SCM010100_House_Construction_Get_Record(pSubdCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Project Image" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM010101_For_Award_Img(pID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - General" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM010101_For_Award_General(pID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Compose Email" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                Dim pSearch = context.Request("pSearch")

                Dim json As String = Me.SCM010101_For_Award_Get_Compose(pTblName, pPlaceHolder, pSearch)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "Upload - Get Record" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM010101_Get_Upload_Record(pID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "Upload - Download" Then

                Dim pID = context.Request("pID")
                Dim pFileName = context.Request("pFileName")
                Dim pDownloadedBy = CIIS_EmpCode

                Dim json As String = Me.Upload_Download(pID, pFileName, pDownloadedBy)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "Upload - Delete" Then

                Dim pID = context.Request("pID")
                Dim pFileName = context.Request("pFileName")
                Dim pDownloadedBy = CIIS_EmpCode

                Dim json As String = Me.Upload_Delete(pID, pFileName, pDownloadedBy)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "Upload - Get Record (Notice)" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM010101_Get_Upload_Record_Notice(pID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "Upload - Download (Notice)" Then

                Dim pID = context.Request("pID")
                Dim pFileName = context.Request("pFileName")
                Dim pDownloadedBy = CIIS_EmpCode

                Dim json As String = Me.Upload_Download_Notice(pID, pFileName, pDownloadedBy)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "Upload - Delete (Notice)" Then

                Dim pID = context.Request("pID")
                Dim pFileName = context.Request("pFileName")
                Dim pDownloadedBy = CIIS_EmpCode

                Dim json As String = Me.Upload_Delete_Notice(pID, pFileName, pDownloadedBy)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Contractor (List)" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.For_Award_Get_Contractor_List(pID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Contractor (List - Project)" Then

                Dim pCode = context.Request("pCode")

                Dim json As String = Me.For_Award_Get_Contractor_List_Project(pCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Contractor" Then

                Dim json As String = Me.Get_Contractor()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Email (COF)" Then

                Dim pID = context.Request("pID")
                Dim pCodeSrs = context.Request("pCodeSrs")
                Dim pEmailSrs = context.Request("pEmailSrs")
                Dim pContent = HttpUtility.UrlDecode(context.Request("pContent"))
                Dim pTagBy = CIIS_EmpCode
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")
                Dim pCC = context.Request("pCC")

                Dim json As String = Me.For_Award_Email_COF(pID, pCodeSrs, pEmailSrs, pContent, pTagBy, pDateFrom, pDateTo, pCC)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Contractor (Awarded)" Then

                Dim pID = context.Request("pID")
                Dim pCode = context.Request("pCode")
                Dim pNTPNo = context.Request("pNTPNo")
                Dim pNTPDate = context.Request("pNTPDate")
                Dim pPOCStart = context.Request("pPOCStart")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.For_Awarding_COF(pID, pCode, pNTPNo, pNTPDate, pPOCStart, pUpdatedBy)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Contractor (Deadline)" Then

                Dim pID = context.Request("pID")
                Dim pCode = context.Request("pCode")

                Dim json As String = Me.For_Award_Get_Update_Deadline(pID, pCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Update Contractor (Deadline)" Then

                Dim pID = context.Request("pID")
                Dim pCode = context.Request("pCode")
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")

                Dim json As String = Me.For_Award_Update_Deadline(pID, pCode, pDateFrom, pDateTo)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Update Contractor (Decline)" Then

                Dim pID = context.Request("pID")
                Dim pCode = context.Request("pCode")

                Dim json As String = Me.For_Award_Declined_Project(pID, pCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Contractor Note (Decline)" Then

                Dim pID = context.Request("pID")
                Dim pCode = context.Request("pCode")

                Dim json As String = Me.For_Award_Get_Contractor_Note(pID, pCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010101" And pType = "For Award - Get Contractor Status (Re-Open)" Then

                Dim pID = context.Request("pID")
                Dim pCode = context.Request("pCode")

                Dim json As String = Me.For_Award_Get_Contractor_ReOpen(pID, pCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Contractor Details" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.SCM010100_Get_Details(Code)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Contractor" Then

                Dim ConType = context.Request("ConType")

                Dim json As String = Me.SCM010100_Get_Contractor(ConType)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Contractor (Batch)" Then

                'Dim BatchType = context.Request("BatchType")

                Dim json As String = Me.SCM010100_Get_BatchContractor()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Submit" Then

                Dim FormNo = context.Request("FormNo")
                Dim FCode = context.Request("FCode")
                Dim Category = context.Request("Category")
                Dim ConType = context.Request("ConType")
                Dim ConNo = context.Request("ConNo")
                Dim Price = context.Request("Price")
                Dim VAT = context.Request("VAT")
                Dim EWT = context.Request("EWT")
                Dim DP = context.Request("DP")
                Dim RF = context.Request("RF")
                Dim PriorStart = context.Request("PriorStart")
                Dim Code = context.Request("Code")

                Dim json As String = Me.SCM010100_Upd_Form(FormNo, FCode, Category, ConType, ConNo, Price, VAT, EWT, DP, RF, PriorStart, Code)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Deadline" Then

                Dim FCode = context.Request("FCode")
                Dim DateFrom = context.Request("DateFrom")
                Dim DateTo = context.Request("DateTo")
                Dim FormNo = context.Request("FormNo")

                Dim json As String = Me.SCM010100_Upd_Deadline(FCode, DateFrom, DateTo, FormNo)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Contractor Note" Then

                Dim FCode = context.Request("FCode")
                Dim Code = context.Request("Code")

                Dim json As String = Me.SCM010100_Con_Notes(FCode, Code)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Message Notification" Then

                Dim json As String = Me.SCM010100_Get_Notified()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Form Details (Project)" Then

                Dim Subd = context.Request("Subd")
                Dim Code = context.Request("Code")

                Dim json As String = Me.SCM010100_Get_Form_List(Subd, Code)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010100" And Type = "Form Details (Batch)" Then

                Dim Subd = context.Request("Subd")

                Dim json As String = Me.SCM010100_Get_Batch_List(Subd)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCM010101" And Type = "Update Tagging Status (Detail)" Then

                Dim ID = context.Request("ID")

                Dim json As String = Me.SCM010101_Get_Deadline(ID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCM010102" And Type = "Update Tagging Status (Detail)" Then

                Dim ID = context.Request("ID")

                Dim json As String = Me.SCM010102_Get_Deadline(ID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010102" And pType = "For Award - Email (House Construction)" Then

                Dim pID = context.Request("pID")
                Dim pCodeSrs = context.Request("pCodeSrs")
                Dim pEmailSrs = context.Request("pEmailSrs")
                Dim pContent = HttpUtility.UrlDecode(context.Request("pContent"))
                Dim pTagBy = CIIS_EmpCode
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")
                Dim pCC = context.Request("pCC")

                Dim json As String = Me.For_Award_Email_House_Construction(pID, pCodeSrs, pEmailSrs, pContent, pTagBy, pDateFrom, pDateTo, pCC)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If pFormCode = "SCM010200" And pType = "Contract Management - Awarded - Header" Then

                Dim json As String = Me.SCM010200_Get_Awarded_Header()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010200" And pType = "Contract Management - Awarded - Repair" Then

                Dim json As String = Me.SCM010200_Get_Awarded_Record()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010200" And pType = "Contract Management - Awarded - Repair Details" Then

                Dim pDivCode = context.Request("pDivCode")

                Dim json As String = Me.SCM010200_Get_Awarded_Record_Repair(pDivCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010200" And pType = "Contract Management - Get Record - Awarded" Then

                Dim pSubdCode = context.Request("pSubdCode")

                Dim json As String = Me.SCM010200_Get_Record_Awarded(pSubdCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010200" And pType = "Contract Management - Awarded - House Construction" Then

                Dim json As String = Me.SCM010200_Awarded_House_Construction()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010200" And pType = "Contract Management - Awarded - House Construction Details" Then

                Dim pDivCode = context.Request("pDivCode")

                Dim json As String = Me.SCM010200_Awarded_House_Construction_Details(pDivCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010200" And pType = "Contract Management - Get Record - Awarded - House Construction" Then

                Dim pSubdCode = context.Request("pSubdCode")

                Dim json As String = Me.SCM010200_Get_Record_Awarded_House_Construction(pSubdCode)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010200" And Type = "Form Details (Project)" Then

                Dim Subd = context.Request("Subd")

                Dim json As String = Me.SCM010200_Get_Form_List(Subd)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010200" And Type = "Form Details (Batch)" Then

                Dim Subd = context.Request("Subd")

                Dim json As String = Me.SCM010200_Get_Batch_List(Subd)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010102" And pType = "For Award - House Construction - Project Image" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM010102_For_Award_Img(pID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf pFormCode = "SCM010102" And pType = "For Award - House Construction - General" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM010102_For_Award_House_Construction_General(pID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCM010300" And Type = "Form Details (Project)" Then

                Dim Subd = context.Request("Subd")

                Dim json As String = Me.SCM010300_Get_Form_List(Subd)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM010300" And Type = "Form Details (Batch)" Then

                Dim Subd = context.Request("Subd")

                Dim json As String = Me.SCM010300_Get_Batch_List(Subd)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCM010400" And Type = "Form Details (Project)" Then

                Dim Subd = context.Request("Subd")

                Dim json As String = Me.SCM010400_Get_Form_List(Subd)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCM020000" And Type = "Contractor Verification" Then

                Dim ID = context.Request("ID")

                Dim json As String = Me.SCM020000_Get_Verification(ID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "Contractor Details (For Approval)" Then

                Dim ID = context.Request("ID")

                Dim json As String = Me.SCM020000_Get_Details_Approval(ID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "Contractor Details (Approved)" Then

                Dim json As String = Me.SCM020000_Get_Details_Approved(ID)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "For Approval (Contractor)" Then

                Dim json As String = Me.SCM020000_Get_Record_Approval()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "For Verification (Contractor)" Then

                Dim json As String = Me.SCM020000_Get_Record_Verification()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "User details (Contrator)" Then

                Dim Num = context.Request("Num")

                Dim json As String = Me.SCM020000_Get_Details(Num)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "For Resubmission (Contractor)" Then

                Dim json As String = Me.SCM020000_Get_Record_Resubmission()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "For Approved (Contractor)" Then

                Dim json As String = Me.SCM020000_Get_Record_Approved()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "For Declined (Contractors)" Then

                Dim json As String = Me.SCM020000_Get_Record_Declined()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM020000" And Type = "Get Record - Contractor" Then

                Dim json As String = Me.SCM020000_Get_Record_Contractor()
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCM040101" And Type = "Search Item - Upd" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.SCM040101_Get_Item_Upd_List(Find)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM040101" And Type = "Get Item - Upd" Then

                Dim SeqNo = context.Request("SeqNo")
                Dim ItemCode = context.Request("ItemCode")
                Dim UpdateDate = context.Request("UpdateDate")

                Dim json As String = Me.SCM040101_Get_Item_Upd_Info(SeqNo, ItemCode, UpdateDate)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM040101" And Type = "Find Record" Then

                Dim Find = context.Request("Find")
                Dim Post = context.Request("Post")

                Dim json As String = Me.SCM040101_Get_Record_List(Find, Post)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM040101" And Type = "Search Item - Add" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.SCM040101_Get_Item_Add_List(Find)
                context.Response.ContentType = "application/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM040101" And Type = "Get Item - Add" Then

                Dim SeqNo = context.Request("SeqNo")
                Dim ItemCode = context.Request("ItemCode")
                Dim UpdateDate = context.Request("UpdateDate")

                Dim json As String = Me.SCM040101_Get_Item_Add_Info(SeqNo, ItemCode, UpdateDate)
                context.Response.ContentType = "application/json"
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
    Function Validate02_Record(pID, pValue01, pValue02, pGroup, pFType)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If pGroup = "02Files" Then

            'get total task
            If pFType = "Add" Then
                Query.Append("if exists (select 1 from Form_HWHdr where HWCode = '" & pID & "') ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select 'No record found!' ")
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

#Region "SCD010000"
    Private Function SCD010000_Get_Form_Year(Year As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  count(1) [Total] ")
        Query.Append("  ,[B].abbr [Subdivision] ")
        Query.Append("from ")
        Query.Append("  Form_CRT [A] ")
        Query.Append("  left join subdivision [B] on [A].Subdivision = [B].code ")
        Query.Append("where ")
        Query.Append("  [A].ContractStatus = 'Awarded' ")
        Query.Append("  and [A].Subdivision not in ('', 'Rawland') ")
        Query.Append("  and YEAR([A].DateAwarded) = '" & Year & "' ")
        Query.Append("group by ")
        Query.Append("  [B].abbr ")
        Query.Append("order by ")
        Query.Append("  [Subdivision] ")
        'get query

        'variable
        Dim Form As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Form.Add(New With {
                        .Total = DR("Total"),
                        .Form = DR("Subdivision")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(Form))
        'display 

    End Function

    Private Function SCD010000_Get_Batch_Year(Year As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  count(1) [Total] ")
        Query.Append("  ,[B].ProjInit [Subdivision] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Awarded' ")
        Query.Append("  and YEAR([A].ConDate) = '" & Year & "' ")
        Query.Append("group by ")
        Query.Append("  [B].ProjInit ")
        Query.Append("order by ")
        Query.Append("  [Subdivision] ")
        'get query

        'variable
        Dim Batch As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Batch.Add(New With {
                        .Total = DR("Total"),
                        .Batch = DR("Subdivision")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(Batch))
        'display 

    End Function
#End Region

#Region "SCM010100"

    Function SCM010100_Get_Header()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select count(1) from Form_HWHdr [A] where [A].ConStatus not in ('Awarded', 'Cancelled', 'Declined') and YEAR([A].HWDate) = YEAR(GETDATE()) ), 0) [HouseConAward] ")
        Query.Append("  ,ISNULL((select COUNT(1) from oop_form_hdr [A] LEFT JOIN Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].status not in ('Accepted', 'Cancelled', 'Declined') and [B].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') and [A].tbl_from = 'Form_CRT' and ISNULL([B].Subdivision, '') not in ('Rawland') and ISNULL([B].Subdivision, '') <> '' and YEAR([B].CreatedDate) = YEAR(GETDATE()) ), 0) [COFAward] ")
        Query.Append("  ,ISNULL((select count(1) from Form_HWHdr [A] where [A].ConStatus in ('Awarded') and YEAR([A].HWDate) = YEAR(GETDATE()) ), 0) [HouseConAwarded] ")
        Query.Append("  ,ISNULL((select COUNT(1) from oop_form_hdr [A] LEFT JOIN Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].status = 'Accepted' and [B].ContractStatus in ('Awarded') and [A].tbl_from = 'Form_CRT' and ISNULL([B].Subdivision, '') not in ('Rawland') and ISNULL([B].Subdivision, '') <> '' and YEAR([B].CreatedDate) = YEAR(GETDATE()) ), 0) [COFAwarded] ")
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
                        .HouseConAward = DR("HouseConAward"),
                        .COFAward = DR("COFAward"),
                        .HouseConAwarded = DR("HouseConAwarded"),
                        .COFAwarded = DR("COFAwarded")
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
    Function SCM010100_Get_Record_Repair(pEmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [D].DivCode ")
        Query.Append("  ,[D].ProvinceName ")
        Query.Append("  ,COUNT([D].DivCode) [Total] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].code ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [D] on [C].division = [D].DivCode ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
        'Query.Append("  and [A].approver = @pEmpCode ")
        Query.Append("  and [B].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') ")
        Query.Append("  and ISNULL([B].Subdivision, '') not in ('Rawland') ")
        Query.Append("  and ISNULL([B].Subdivision, '') <> '' ")
        Query.Append("  and ISNULL([D].ProvinceName, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [D].DivCode ")
        Query.Append("  ,[D].ProvinceName) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [Total] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .DivCode = DR("DivCode"),
                        .ProvName = DR("ProvinceName")
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
    Function SCM010100_Get_Record_House_Construction()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].DivCode ")
        Query.Append("  ,[B].ProvinceName ")
        Query.Append("  ,COUNT([B].DivCode) [Total] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus not in ('For Award', 'Awarded', 'Declined') ")
        Query.Append("  and ISNULL([B].DivCode, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [B].DivCode ")
        Query.Append("  ,[B].ProvinceName) [Tbl] ")
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
                        .DivCode = DR("DivCode"),
                        .ProvName = DR("ProvinceName")
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
    Function SCM010100_Get_Record_Repair_Details(pDivCode, pEmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  dbo.ProperCase([C].description) [Subdivision] ")
        Query.Append("  ,dbo.ProperCase([C].address) [Address] ")
        Query.Append("  ,[D].ProvinceName [ProvName] ")
        'Query.Append("  ,(select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode where [HDR].tbl_from = 'Form_CRT' and [HDR].status not in ('Accepted', 'Cancelled', 'Declined') and [CRT].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') and [CRT].Subdivision = [B].Subdivision and ISNULL([CRT].Subdivision, '') not in ('Rawland') and ISNULL([CRT].Subdivision, '') <> '' and YEAR([CRT].CreatedDate) = YEAR(GETDATE()) ) [ForAward] ")
        'Query.Append("  ,(select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode where [HDR].tbl_from = 'Form_CRT' and [HDR].status in ('Accepted') and [CRT].ContractStatus in ('Awarded') and [CRT].Subdivision = [B].Subdivision and YEAR([CRT].CreatedDate) = YEAR(GETDATE()) ) [Awarded] ")
        Query.Append("  ,[C].abbr ")
        Query.Append("  ,[B].Subdivision [SubdCode] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode left join SCM_TagContractors [TAG] on [HDR].f_code = [TAG].tag_code where [HDR].status not in ('Accepted', 'Cancelled', 'Declined') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' and ISNULL([TAG].acct_status, '') = '' and [TAG].status = 0 ), 0) [SrtByTag] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode left join SCM_TagContractors [TAG] on [HDR].f_code = [TAG].tag_code where [HDR].status not in ('Accepted', 'Cancelled', 'Declined') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' and isnull([TAG].acct_status, '') = '' and [TAG].status = 0 ), 0) [Endorsed] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode left join SCM_TagContractors [TAG] on [HDR].f_code = [TAG].tag_code where [HDR].status not in ('Accepted', 'Cancelled', 'Declined') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' and isnull([TAG].acct_status, '') = '' and [TAG].status = 1 ), 0) [Applied] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode left join SCM_TagContractors [TAG] on [HDR].f_code = [TAG].tag_code where [HDR].status not in ('Accepted', 'Cancelled', 'Declined') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' and isnull([TAG].acct_status, '') in ('Cancelled', 'Declined') and [TAG].status = 1 ), 0) [Declined] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode left join SCM_TagContractors [TAG] on [HDR].f_code = [TAG].tag_code where [HDR].status not in ('Accepted', 'Cancelled', 'Declined') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' and isnull([TAG].acct_status, '') in ('Due') and [TAG].status = 1 ), 0) [Due] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode where [HDR].status not in ('Accepted', 'Cancelled', 'Declined') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' ), 0) [TotalForms] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].code ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [D] on [C].division = [D].DivCode ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
        'Query.Append("  and [A].approver = @pEmpCode ")
        Query.Append("  and [D].DivCode = @pDivCode ")
        Query.Append("  and [B].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') ")
        Query.Append("  and ISNULL([B].Subdivision, '') not in ('Rawland') ")
        Query.Append("  and ISNULL([B].Subdivision, '') <> '' ")
        Query.Append("  and ISNULL([D].ProvinceName, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [C].description ")
        Query.Append("  ,[C].address ")
        Query.Append("  ,[D].ProvinceName ")
        Query.Append("  ,[B].Subdivision")
        Query.Append("  ,[C].abbr ")
        Query.Append("order by ")
        Query.Append("  [Subdivision], [SrtByTag] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
                Cmd.Parameters.AddWithValue("@pDivCode", pDivCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim BodyHTML As New StringBuilder

                    BodyHTML.Append("<div Class='col-md-6 col-xl-4'> ")
                    BodyHTML.Append("  <div class='card ribbon ribbon-top'> ")
                    BodyHTML.Append("      <div class='ribbon-label bg-primary'>" & DR("ProvName") & "</div> ")
                    BodyHTML.Append("      <div class='card-body d-flex flex-center flex-column p-9'> ")
                    BodyHTML.Append("      <div class='symbol symbol-65px mb-5'> ")
                    BodyHTML.Append("          <img src='Assets/media/svg/project/" & DR("abbr") & ".svg' alt='" & DR("abbr") & "' /> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='fs-4 text-gray-800 fw-bolder mb-0'>" & DR("Subdivision") & "</div> ")
                    BodyHTML.Append("      <div class='fw-bold text-gray-400 mb-6'>" & IIf(DR("Address") = "", "-", DR("Address")) & "</div> ")
                    BodyHTML.Append("      <div class='d-flex flex-center flex-wrap'> ")
                    BodyHTML.Append("          <div class='border border-dashed rounded min-w-125px py-3 px-4 mx-3 mb-3' style='text-align: center;'> ")
                    BodyHTML.Append("              <div class='fs-6 fw-bolder text-gray-700'>" & DR("TotalForms") & "</div> ")
                    BodyHTML.Append("              <div class='fw-bold text-gray-400'>Total Form</div> ")
                    BodyHTML.Append("          </div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='d-flex flex-center flex-wrap mb-5'> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-info fs-7 me-3' data-bs-toggle='tooltip' title='Endorsed'>" & DR("Endorsed") & "</span> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-success fs-7 me-3' data-bs-toggle='tooltip' title='Applied'>" & DR("Applied") & "</span> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-danger fs-7 me-3' data-bs-toggle='tooltip' title='Declined'>" & DR("Declined") & "</span> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-warning fs-7 me-3' data-bs-toggle='tooltip' title='Due'>" & DR("Due") & "</span> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='btn btn-sm btn-primary pointer' onclick=""fn01Table('" & DR("SubdCode") & "', '" & pEmpCode & "')""> ")
                    BodyHTML.Append("          <span class='svg-icon svg-icon-3'> ")
                    BodyHTML.Append("              <svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    BodyHTML.Append("                  <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'> ")
                    BodyHTML.Append("                      <rect x='0' y='0' width='24' height='24'/> ")
                    BodyHTML.Append("                      <path d='M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z' fill='currentColor' fill-rule='nonzero' opacity='0.3'/> ")
                    BodyHTML.Append("                      <path d='M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z' fill='currentColor' fill-rule='nonzero'/> ")
                    BodyHTML.Append("                  </g> ")
                    BodyHTML.Append("              </svg> ")
                    BodyHTML.Append("          </span>View Details</div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("  </div> ")
                    BodyHTML.Append("</div> ")

                    RecordList.Add(New With {
                        .Content = BodyHTML.ToString()
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
    Function SCM010100_Get_Record_House_Construction_Details(pDivCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].ProjName [Subdivision] ")
        Query.Append("  ,[B].Address [Address] ")
        Query.Append("  ,[B].ProvinceName [ProvName] ")
        Query.Append("  ,ISNULL((select count(1) from Form_HWHdr [HDR] where [HDR].ConStatus not in ('Awarded', 'Cancelled', 'Declined') and [HDR].Subd = [A].Subd ), 0) [TotalRecord] ")
        Query.Append("  ,[A].Subd ")
        Query.Append("  ,[B].ProjInit ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors [C] left join Form_HWHdr [D] on [C].tag_code = [D].HWCode where [D].Subd = [A].Subd), 0) [SrtByTag] ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors [C] left join Form_HWHdr [D] on [C].tag_code = [D].HWCode where [D].Subd = [A].Subd and [C].acct_status IS NULL and [C].status = 0), 0) [Endorsed] ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors [C] left join Form_HWHdr [D] on [C].tag_code = [D].HWCode where [D].Subd = [A].Subd and [C].acct_status IS NULL and [C].status = 1), 0) [Applied] ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors [C] left join Form_HWHdr [D] on [C].tag_code = [D].HWCode where [D].Subd = [A].Subd and [C].acct_status in ('Cancelled', 'Declined') and [C].status = 1), 0) [Declined] ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors [C] left join Form_HWHdr [D] on [C].tag_code = [D].HWCode where [D].Subd = [A].Subd and [C].acct_status in ('Due') and [C].status = 1), 0) [Due] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus not in ('Awarded', 'Declined') ")
        Query.Append("  and ISNULL([B].DivCode, '') = @pDivCode ")
        Query.Append("  and ISNULL([B].DivCode, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [A].Subd ")
        Query.Append("  ,[B].ProjName ")
        Query.Append("  ,[B].Address ")
        Query.Append("  ,[B].ProvinceName ")
        Query.Append("  ,[B].ProjInit) [Tbl] ")
        Query.Append("where ")
        Query.Append("  [TotalRecord] > 0 ")
        Query.Append("order by ")
        Query.Append("  [Subdivision] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pDivCode", pDivCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim BodyHTML As New StringBuilder

                    BodyHTML.Append("<div Class='col-md-6 col-xl-4'> ")
                    BodyHTML.Append("  <div class='card ribbon ribbon-top'> ")
                    BodyHTML.Append("      <div class='ribbon-label bg-primary'>" & DR("ProvName") & "</div> ")
                    BodyHTML.Append("      <div class='card-body d-flex flex-center flex-column p-9'> ")
                    BodyHTML.Append("      <div class='symbol symbol-65px mb-5'> ")
                    BodyHTML.Append("          <img src='Assets/media/svg/project/" & DR("ProjInit") & ".svg' alt='" & DR("ProjInit") & "' /> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='fs-4 text-gray-800 fw-bolder mb-0'>" & DR("Subdivision") & "</div> ")
                    BodyHTML.Append("      <div class='fw-bold text-gray-400 mb-6'>" & IIf(DR("Address") = "", "-", DR("Address")) & "</div> ")
                    BodyHTML.Append("      <div class='d-flex flex-center flex-wrap mb-5'> ")
                    BodyHTML.Append("          <div class='border border-dashed rounded min-w-125px py-3 px-4 mx-3 mb-3' style='text-align: center;'> ")
                    BodyHTML.Append("              <div class='fs-6 fw-bolder text-gray-700'>" & DR("TotalRecord") & "</div> ")
                    BodyHTML.Append("              <div class='fw-bold text-gray-400'>Total Record</div> ")
                    BodyHTML.Append("          </div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='d-flex flex-center flex-wrap mb-5'> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-info fs-7 me-3' data-bs-toggle='tooltip' title='Endorsed'>" & DR("Endorsed") & "</span> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-success fs-7 me-3' data-bs-toggle='tooltip' title='Applied'>" & DR("Applied") & "</span> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-danger fs-7 me-3' data-bs-toggle='tooltip' title='Declined'>" & DR("Declined") & "</span> ")
                    BodyHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-warning fs-7 me-3' data-bs-toggle='tooltip' title='Due'>" & DR("Due") & "</span> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='btn btn-sm btn-primary pointer' onclick=""fn02Table('" & DR("Subd") & "')""> ")
                    BodyHTML.Append("          <span class='svg-icon svg-icon-3'> ")
                    BodyHTML.Append("              <svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    BodyHTML.Append("                  <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'> ")
                    BodyHTML.Append("                      <rect x='0' y='0' width='24' height='24'/> ")
                    BodyHTML.Append("                      <path d='M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z' fill='currentColor' fill-rule='nonzero' opacity='0.3'/> ")
                    BodyHTML.Append("                      <path d='M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z' fill='currentColor' fill-rule='nonzero'/> ")
                    BodyHTML.Append("                  </g> ")
                    BodyHTML.Append("              </svg> ")
                    BodyHTML.Append("          </span>View Details</div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("  </div> ")
                    BodyHTML.Append("</div> ")


                    RecordList.Add(New With {
                        .Content = BodyHTML.ToString()
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
    Function SCM010100_Get_Record(pCode, pSubdCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'Closed' then '<span class=""mt-3 badge badge-for-closed"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""mt-3 badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'New' then '<span class=""mt-3 badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'For Endorsement' then '<span class=""mt-3 badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'For Approval' then '<span class=""mt-3 badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'For Implementation' then '<span class=""mt-3 badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'For Clarification' then '<span class=""mt-3 badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("   ,Format([DateCreated],'MM/dd/yyyy') [DateCreated] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("   ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("	 ,(case when [DateExpected] < cast(getdate() as date) then '<span class=""mt-3 badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateExpected] = cast(getdate() as date) then '<span class=""mt-3 badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateExpected] > cast(getdate() as date) then '<span class=""mt-3 badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("   ,[TotalTag] ")
        Query.Append("   ,[TotalApplied] ")
        Query.Append("   ,[TotalDeclined] ")
        Query.Append("   ,[TotalDue] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("      ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].f_code and acct_status is null and status = 0), 0) [TotalTag] ")
        Query.Append("      ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].f_code and status = 1 and acct_status is null), 0) [TotalApplied] ")
        Query.Append("      ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].f_code and Acct_status in ('Cancelled', 'Declined') and status = 1), 0) [TotalDeclined] ")
        Query.Append("      ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].f_code and Acct_status in ('Due') and status = 1), 0) [TotalDue] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("	    left join Form_CRT [D] on [A].tbl_code = [D].CRTCode ")
        Query.Append("   where ")
        Query.Append("      [A].status Not In ('Accepted','Declined','Cancelled') ")
        Query.Append("      and [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [D].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') ")
        'Query.Append("      and [A].approver = @pCode ")
        Query.Append("      and [D].Subdivision = @pSubdCode) [A] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                Cmd.Parameters.AddWithValue("@pSubdCode", pSubdCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim Requestor As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"

                    Dim TagColumn As New StringBuilder
                    TagColumn.Append("<div class='d-flex justify-content-end me-5 mt-2'> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-info fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Endorsed'>" & DR("TotalTag") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-success fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Applied'>" & DR("TotalApplied") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-danger fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Declined'>" & DR("TotalDeclined") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-warning fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Due'>" & DR("TotalDue") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("</div> ")

                    RecordList.Add(New With {
                        .Link = DR("Link"),
                        .Icon = DR("Icon"),
                        .ID = DR("ID"),
                        .Title = DR("Title"),
                        .Type = DR("Type"),
                        .DateCreated = DR("DateCreated"),
                        .DateRequired = DR("DateRequired"),
                        .DateExpected = DR("DateExpected"),
                        .Status = DR("Status"),
                        .RequestedByCode = DR("RequestedByCode"),
                        .RequestedByName = DR("RequestedByName"),
                        .Requestor = Requestor.ToString(),
                        .TagColumn = TagColumn.ToString()
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
    Function SCM010100_House_Construction_Get_Record(pSubdCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status [Status] ")
        Query.Append("  ,'SCM010102-DTL-' + [A].HWCode [Link] ")
        Query.Append("  ,'assets/media/svg/apps/CNS.svg' [Icon] ")
        Query.Append("  ,'CON - ' + [A].Type + ' / ' + [C].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [D].ModelName + ') '  [Title] ")
        Query.Append("  ,[A].HWCode [ID] ")
        Query.Append("  ,[A].CreatedBy [RequestedByCode] ")
        Query.Append("  ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("  ,IIf(Year([A].CreatedDate) < Year(GETDATE()), Format([A].CreatedDate, 'MMM d, yyyy'), IIf(Day([A].CreatedDate) < Day(GETDATE()), Format([A].CreatedDate, 'MMM d'), Format([A].CreatedDate, 'hh:mm tt'))) [Date]  ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].HWCode and acct_status is null and status = 0), 0) [TotalTag] ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].HWCode and acct_status is null and status = 1), 0) [TotalApplied] ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].HWCode and Acct_status in ('Cancelled', 'Declined') and status = 1), 0) [TotalDeclined] ")
        Query.Append("  ,ISNULL((select count(1) from SCM_TagContractors where tag_code = [A].HWCode and Acct_status in ('Due') and status = 1), 0) [TotalDue] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus not in ('For Award', 'Awarded', 'Declined') ")
        Query.Append("  and ISNULL([C].DivCode, '') <> '' ")
        Query.Append("  and [A].Subd = @pSubdCode ")
        Query.Append("order by ")
        Query.Append("  [TotalTag] ")
        Query.Append("  ,[Date] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pSubdCode", pSubdCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim CreatedBy As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("Name") & "</div>"

                    Dim TagColumn As New StringBuilder
                    TagColumn.Append("<div class='d-flex justify-content-end me-5 mt-2'> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-info fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Endorsed'>" & DR("TotalTag") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-success fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Applied'>" & DR("TotalApplied") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-danger fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Declined'>" & DR("TotalDeclined") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("    <div class='card-toolbar me-3'> ")
                    TagColumn.Append("        <div class='symbol symbol-30px'> ")
                    TagColumn.Append("            <span class='symbol-label bg-warning fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Due'>" & DR("TotalDue") & "</span> ")
                    TagColumn.Append("        </div> ")
                    TagColumn.Append("    </div> ")
                    TagColumn.Append("</div> ")

                    RecordList.Add(New With {
                        .Link = DR("Link"),
                        .Icon = DR("Icon"),
                        .ID = DR("ID"),
                        .Title = DR("Title"),
                        .CreatedBy = CreatedBy.ToString(),
                        .TagColumn = TagColumn.ToString()
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
    Function SCM010100_Get_Details(Code)

        'get contractor details
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].v_code [Code] ")
        Query.Append("  ,dbo.ProperCase([A].vendor) [Name] ")
        Query.Append("  ,isnull([A].fax_no, '-') [FaxNo] ")
        Query.Append("  ,isnull([A].tin_no, '-') [TinNo] ")
        Query.Append("  ,isnull([A].email, '-') [Email] ")
        Query.Append("  ,isnull([A].con_name1, '-') [ContactPerson] ")
        Query.Append("  ,isnull([A].type, '-') [Type] ")
        Query.Append("  ,[A].address [Address] ")
        Query.Append("  ,isnull([A].tel_no, '-') [TelNo] ")
        Query.Append("  ,isnull([A].cel_no, '-') [MobileNo] ")
        Query.Append("  ,isnull([B].vat, '-') [VAT] ")
        Query.Append("  ,isnull([C].description, '-') [EWT] ")
        Query.Append("  ,isnull([D].description, '-') [CreditTerms] ")
        Query.Append("  ,isnull([A].BankName, '-') [BankName] ")
        Query.Append("  ,isnull([A].BankAcctName, '-') [AcctName] ")
        Query.Append("  ,isnull([A].BankAcctNo, '-') [AcctNo] ")
        Query.Append("from ")
        Query.Append("  ogm_vendor [A] ")
        Query.Append("  left join fin_vat [B] on [A].vat = [B].v_code ")
        Query.Append("  left join fin_ewt [C] on [A].ewt = [C].ewt_code ")
        Query.Append("  left join ogm_credit_terms [D] on [A].credit_terms = [D].ct_code ")
        Query.Append("where ")
        Query.Append("  [A].v_code = '" & Code & "' ")
        'get contractor details

        'variable
        Dim ContractorDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    ContractorDetails.Add(New With {
                        .Code = DR("Code"),
                        .Name = DR("Name"),
                        .FaxNo = DR("FaxNo"),
                        .TinNo = DR("TinNo"),
                        .Email = DR("Email"),
                        .ContactPerson = DR("ContactPerson"),
                        .Type = DR("Type"),
                        .Address = DR("Address"),
                        .TelNo = DR("TelNo"),
                        .MobileNo = DR("MobileNo"),
                        .VAT = DR("VAT"),
                        .EWT = DR("EWT"),
                        .CreditTerms = DR("CreditTerms"),
                        .BankName = DR("BankName"),
                        .AcctName = DR("AcctName"),
                        .AcctNo = DR("AcctNo")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ContractorDetails))
        'display 

    End Function
    Function SCM010100_Get_Contractor(Type)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  v_code [Code] ")
        Query.Append("  ,vendor [Name] ")
        Query.Append("  ,type [Type] ")
        Query.Append("  ,email [Email] ")
        Query.Append("from ")
        Query.Append("  ogm_vendor ")
        Query.Append("where ")
        Query.Append("  lock = 1 ")
        Query.Append("  and type = '" & Type & "' ")
        Query.Append("  and email LIKE '%@__%' ")
        'get total task

        'variable
        Dim ContractorList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Bullet As String = "<span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span>"
                    Dim View As String = "<div class='d-flex justify-content-end'><span type = 'button' Class='btn btn btn-sm btn-primary btn-active-light-primary' code='" & DR("Code") & "' onclick='spnExpand(this);'>View</span></div>"
                    Dim Add As String = "<button type = 'button' Class='btn btn btn-sm btn-primary btn-active-light-primary' code='" & DR("Code") & "' data-val='" & DR("Email") & "' onclick='btnAdd(this);'><span class='indicator-label'>Add</span><span class='indicator-progress'>Adding... <span class='spinner-border spinner-border-sm align-middle ms-2'></span></span></button>"
                    ContractorList.Add(New With {
                        .Bullet = Bullet,
                        .Code = DR("Code"),
                        .Name = DR("Name"),
                        .Type = DR("Type"),
                        .View = View,
                        .Add = Add,
                        .Email = DR("Email")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ContractorList))
        'display 

    End Function

    Function SCM010100_Get_BatchContractor()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  v_code [Code] ")
        Query.Append("  ,vendor [Name] ")
        Query.Append("  ,type [Type] ")
        Query.Append("  ,email [Email] ")
        Query.Append("from ")
        Query.Append("  ogm_vendor ")
        Query.Append("where ")
        Query.Append("  lock = 1 ")
        'Query.Append("  and type = '" & Type & "' ")
        Query.Append("  and type = 'Contractor' ")
        Query.Append("  and email LIKE '%@__%'; ")
        'get total task

        'variable
        Dim ContractorList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Check As String = "<div class='form-check form-check-sm form-check-custom form-check-solid' data-code='" & DR("Code") & "' data-val='" & DR("Email") & "'><input name='RowCheckbox' type='checkbox' runat='server' class='form-check-input checkBoxBatchClass' value='1' onchange='toggleCheckBatch(this)' /></div>"
                    Dim Bullet As String = "<span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span>"
                    'Dim View As String = "<div class='d-flex justify-content-end'><span type = 'button' Class='btn btn btn-sm btn-primary btn-active-light-primary' code='" & DR("Code") & "' onclick='spnExpand(this);'>View</span></div>"
                    ContractorList.Add(New With {
                        .Bullet = Bullet,
                        .Check = Check,
                        .Code = DR("Code"),
                        .Name = DR("Name"),
                        .Type = DR("Type")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ContractorList))
        'display 

    End Function

    Private Function SCM010100_Upd_Form(FormNo, ID, Category, ConType, ConNo, Price, VAT, EWT, DP, RF, PriorStart, Code)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SCM_CON_Upd"
        SqlCmd.Parameters.AddWithValue("@pFormCode", FormNo)
        SqlCmd.Parameters.AddWithValue("@pID", ID)
        SqlCmd.Parameters.AddWithValue("@pContractCategory", Category)
        SqlCmd.Parameters.AddWithValue("@pContractType", ConType)
        SqlCmd.Parameters.AddWithValue("@pContractNo", ConNo)
        SqlCmd.Parameters.AddWithValue("@pContractPrice", Price)
        SqlCmd.Parameters.AddWithValue("@pContractVAT", IIf(VAT = "", 0.00, VAT))
        SqlCmd.Parameters.AddWithValue("@pContractEWT", IIf(EWT = "", 0.00, EWT))
        SqlCmd.Parameters.AddWithValue("@pContractDP", IIf(DP = "", 0.00, DP))
        SqlCmd.Parameters.AddWithValue("@pContractRF", IIf(RF = "", 0.00, RF))
        SqlCmd.Parameters.AddWithValue("@pPOCRate", IIf(PriorStart = "", 0.00, PriorStart))
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", IIf(CIIS_EmpCode = "", Code, CIIS_EmpCode))
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

    End Function
    Private Function SCM010100_Upd_Deadline(FCode, DateFrom, DateTo, TblCode)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SCM_CON_Deadline"
        SqlCmd.Parameters.AddWithValue("@pFormNo", FCode)
        SqlCmd.Parameters.AddWithValue("@pDateFrom", DateFrom)
        SqlCmd.Parameters.AddWithValue("@pDateTo", DateTo)
        SqlCmd.Parameters.AddWithValue("@pTblCode", TblCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

    End Function
    Private Function SCM010100_Con_Notes(FCode, Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append(" note ")
        Query.Append("from ")
        Query.Append(" SCM_TagContractors ")
        Query.Append("where ")
        Query.Append("  tag_code = '" & FCode & "' ")
        Query.Append("  and v_code = '" & Code & "' ")
        'get total task

        'variable
        Dim ContractorNote As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    ContractorNote.Add(New With {
                        .Note = DR("note")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ContractorNote))
        'display 

    End Function
    Private Function SCM010100_Get_Notified()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [B].FormTitle [Detail] ")
        Query.Append("  ,[A].Description [Message] ")
        Query.Append("  ,[A].TblCode [ID] ")
        Query.Append("  ,[A].Notify [NotifyBy] ")
        Query.Append("  ,[A].SeqNo  ")
        Query.Append("  ,[A].Seen  ")
        Query.Append("  ,[A].CreatedBy  ")
        Query.Append("from ")
        Query.Append("  SCM_CON_Notes [A] ")
        Query.Append("  left join oop_form_hdr [B] on [A].TblCode = [B].f_code ")
        Query.Append("  left join ogm_vendor [C] on [A].CreatedBy = [C].v_code ")
        Query.Append("where ")
        Query.Append("  [A].ContentType = 'OUT' ")
        Query.Append("  and [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("  and [A].Seen = 0 ")
        Query.Append("order by ")
        Query.Append("  [A].CreatedDate DESC ")
        'get query

        'variable
        Dim Notified As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Notified.Add(New With {
                        .Detail = DR("Detail"),
                        .Message = DR("Message"),
                        .ID = DR("ID"),
                        .NotifyBy = DR("NotifyBy"),
                        .SeqNo = DR("SeqNo"),
                        .Seen = DR("Seen"),
                        .CreatedBy = DR("CreatedBy")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(Notified))
        'display 

    End Function
    Private Function SCM010100_Get_Form_List(Subd As String, Code As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Link] ")
        Query.Append("  ,[Icon] ")
        Query.Append("  ,[Title] ")
        Query.Append("  ,[ID] ")
        Query.Append("  ,[Name] ")
        Query.Append("  ,[Date] ")
        Query.Append("  ,[TotalTag] ")
        Query.Append("  ,[TotalApplied] ")
        Query.Append("  ,[TotalDeclined] ")
        Query.Append("  ,[TotalDue] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      [A].status [Status] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,IIf(Year([A].created_date) < Year(GETDATE()), Format([A].created_date, 'MMM d, yyyy'), IIf(Day([A].created_date) < Day(GETDATE()), Format([A].created_date, 'MMM d'), Format([A].created_date, 'hh:mm tt'))) [Date] ")
        Query.Append("      ,(select count(1) from SCM_TagContractors where tag_code = [A].f_code and acct_status is null and status = 0) [TotalTag] ")
        Query.Append("      ,(select count(1) from SCM_TagContractors where tag_code = [A].f_code and status = 1 and acct_status is null) [TotalApplied] ")
        Query.Append("      ,(select count(1) from SCM_TagContractors where tag_code = [A].f_code and Acct_status in ('Cancelled', 'Declined') and status = 1) [TotalDeclined] ")
        Query.Append("      ,(select count(1) from SCM_TagContractors where tag_code = [A].f_code and Acct_status in ('Due') and status = 1) [TotalDue] ")
        Query.Append("  from ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("      left join Form_CRT [C] on [A].tbl_code = [C].CRTCode ")
        Query.Append("  where ")
        Query.Append("      [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
        Query.Append("      and [A].approver = '" & Code & "' ")
        Query.Append("      and [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [C].ContractStatus not in ('For Award', 'Awarded', 'Declined') ")
        Query.Append("      and [C].Subdivision = '" & Subd & "') [TBL] ")
        Query.Append("order by ")
        Query.Append("  [TotalTag] ")
        Query.Append("  ,[TotalApplied] ")
        Query.Append("  ,[Date] ")
        'get query

        'variable
        Dim FormDetails As New List(Of Object)()
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

                    Dim Link As String = "SCM010101-DTL-" + DR("ID")
                    Dim Data As New StringBuilder
                    Data.Append("<a href='" & Link & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    Dim Tag As New StringBuilder
                    Tag.Append("<div class='d-flex justify-content-end me-5'> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-info fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Endorsed'>" & DR("TotalTag") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-success fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Applied'>" & DR("TotalApplied") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-danger fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Declined'>" & DR("TotalDeclined") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-warning fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Due'>" & DR("TotalDue") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("</div> ")
                    FormDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString,
                        .Tag = Tag.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(FormDetails))
        'display 

    End Function
    Private Function SCM010100_Get_Batch_List(Subd As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status [Status] ")
        Query.Append("  ,'SCM010101-DTL-' + [A].HWCode [Link] ")
        Query.Append("  ,'assets/media/svg/apps/CNS.svg' [Icon] ")
        Query.Append("  ,'CON - ' + [A].Type + ' / ' + [C].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [D].ModelName + ') '  [Title] ")
        Query.Append("  ,[A].HWCode [ID] ")
        Query.Append("  ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("  ,IIf(Year([A].CreatedDate) < Year(GETDATE()), Format([A].CreatedDate, 'MMM d, yyyy'), IIf(Day([A].CreatedDate) < Day(GETDATE()), Format([A].CreatedDate, 'MMM d'), Format([A].CreatedDate, 'hh:mm tt'))) [Date]  ")
        Query.Append("  ,(select count(1) from SCM_TagContractors where tag_code = [A].HWCode and acct_status is null and status = 0) [TotalTag] ")
        Query.Append("  ,(select count(1) from SCM_TagContractors where tag_code = [A].HWCode and acct_status is null and status = 1) [TotalApplied] ")
        Query.Append("  ,(select count(1) from SCM_TagContractors where tag_code = [A].HWCode and Acct_status in ('Cancelled', 'Declined') and status = 1) [TotalDeclined] ")
        Query.Append("  ,(select count(1) from SCM_TagContractors where tag_code = [A].HWCode and Acct_status in ('Due') and status = 1) [TotalDue] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus not in ('For Award', 'Awarded', 'Declined') ")
        Query.Append("  and [A].Subd = '" & Subd & "' ")
        Query.Append("order by ")
        Query.Append("  [TotalTag] ")
        Query.Append("  ,[Date] ")
        'get query

        'variable
        Dim BatchDetails As New List(Of Object)()
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

                    Dim Link As String = "SCM010102-DTL-" + DR("ID")
                    Dim Data As New StringBuilder
                    Data.Append("<a href='" & Link & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    Dim Tag As New StringBuilder
                    Tag.Append("<div class='d-flex justify-content-end me-5'> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-info fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Endorsed'>" & DR("TotalTag") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-success fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Applied'>" & DR("TotalApplied") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-danger fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Declined'>" & DR("TotalDeclined") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("    <div class='card-toolbar me-3'> ")
                    Tag.Append("        <div class='symbol symbol-30px'> ")
                    Tag.Append("            <span class='symbol-label bg-warning fw-bolder text-white fs-6' data-bs-toggle='tooltip' title='Due'>" & DR("TotalDue") & "</span> ")
                    Tag.Append("        </div> ")
                    Tag.Append("    </div> ")
                    Tag.Append("</div> ")

                    BatchDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString,
                        .Tag = Tag.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(BatchDetails))
        'display 

    End Function

#End Region

#Region "SCM010101"
    Function SCM010101_For_Award_Img(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [C].abbr [ProjInit] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].code ")
        Query.Append("where ")
        Query.Append("  [A].f_code = @pID ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ProjImage = DR("ProjInit")
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
    Function SCM010101_For_Award_General(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].f_code [ID] ")
        Query.Append("   ,FORMAT([A].created_date, 'MM/dd/yyyy') [DateCreated] ")
        Query.Append("   ,FORMAT([A].date_required, 'MM/dd/yyyy') [DateRequired] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
        Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
        Query.Append("   ,[A].status [Status] ")
        Query.Append("   ,[B].Category ")
        Query.Append("   ,isnull([B].Project,'-') [Project] ")
        Query.Append("   ,isnull([F].house,'-') [House] ")
        Query.Append("   ,isnull([B].Batch, '-') [Batch] ")
        Query.Append("   ,isnull([B].Theme, '-') [Theme] ")
        Query.Append("   ,(case when FORMAT([B].Budget,'N2') = '0.00' then '-' else FORMAT([B].Budget,'N2') end) [Budget] ")
        Query.Append("   ,isnull([B].Remarks, '-') [Purpose] ")
        Query.Append("   ,ISNULL((select count(1) from Form_CRT where CRTCode = [B].CRTCode and ContractStatus = 'Awarded'), 0) [ProjectAwarded] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
        Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
        Query.Append("   left join eng_house [F] on [B].House = [F].h_code ")
        Query.Append("where ")
        Query.Append("   [A].f_code = @pID ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .DateCreated = DR("DateCreated"),
                        .DateRequired = DR("DateRequired"),
                        .RequestedBy = DR("RequestedBy"),
                        .AssignedTo = DR("AssignedTo"),
                        .EndorsedTo = DR("EndorsedTo"),
                        .Status = DR("Status"),
                        .Category = DR("Category"),
                        .Project = DR("Project"),
                        .House = DR("House"),
                        .Batch = DR("Batch"),
                        .Theme = DR("Theme"),
                        .Budget = DR("Budget"),
                        .Purpose = DR("Purpose"),
                        .ProjectAwarded = DR("ProjectAwarded")
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
    Function SCM010101_For_Award_Get_Compose(pTblName, pPlaceHolder, pSearch)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Mstr_EmailList" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].emp_no [ID] ")
            Query.Append("   ,[A].email [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].email [Order2] ")
            Query.Append("from ")
            Query.Append("   employee [A] ")
            Query.Append("where ")
            Query.Append("   isnull([A].Lock, 0) = 1 ")
            Query.Append("   and ISNULL([A].emp_status, '') not in ('Resigned') ")
            Query.Append("   and isnull([A].email, '') LIKE '%" & pSearch & "%' ")
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

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        If RecordList Is Nothing Then
            RecordList = New List(Of Object)()
        End If
        Return serializer.Serialize(RecordList)
        'display

    End Function
    Function SCM010101_Get_Upload_Record(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("   [A].FileName ")
        Query.Append("   ,dbo.ProperCase([B].first_name) [UploadedBy] ")
        Query.Append("   ,format([A].UploadedDate,'MM/dd/yyyy hh:mm tt') [UploadedDate] ")
        Query.Append("FROM ")
        Query.Append("   Mstr_Attachment [A] ")
        Query.Append("   left join employee [B] on [A].UploadedBy = [B].emp_no ")
        Query.Append("   left join Mstr_History [C] on [A].ID = [C].TblCode and [A].FormCode = [C].TblName and [A].UploadedDate = [C].CreatedDate ")
        Query.Append("where ")
        Query.Append("   [A].FormCode = 'FRM000009' ")
        Query.Append("   and [A].ID = '" & pID & "' ")
        Query.Append("   and [C].Type NOT LIKE '%notice to proceed file%' ")
        Query.Append("order by ")
        Query.Append("   [A].UploadedDate ")
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

                    'create variable
                    Dim Icon As String
                    'create variable

                    'set icon for specific file
                    If DR("FileName").Contains(".png") Or DR("FileName").Contains(".PNG") Then
                        Icon = "<i class='las la-file-image text-purple fs-1' title='Image'></i>"
                    ElseIf DR("FileName").Contains(".jpg") Or DR("FileName").Contains(".jpeg") Or DR("FileName").Contains(".jpe") Or DR("FileName").Contains(".jfif") Or DR("FileName").Contains(".JPG") Or DR("FileName").Contains(".JPEG") Or DR("FileName").Contains(".JPE") Or DR("FileName").Contains(".JFIF") Then
                        Icon = "<i class='las la-file-image text-purple fs-1' title='Image'></i>"
                    ElseIf DR("FileName").Contains(".txt") Or DR("FileName").Contains(".TXT") Then
                        Icon = "<i class='las la-file-alt text-muted fs-1' title='Text'></i>"
                    ElseIf DR("FileName").Contains(".xlsx") Or DR("FileName").Contains(".xls") Or DR("FileName").Contains(".XLSX") Or DR("FileName").Contains(".XLS") Then
                        Icon = "<i class='las la-file-excel text-primary fs-1' title='Excel'></i>"
                    ElseIf DR("FileName").Contains(".docx") Or DR("FileName").Contains(".doc") Or DR("FileName").Contains(".DOCX") Or DR("FileName").Contains(".DOC") Then
                        Icon = "<i class='las la-file-word text-info fs-1' title='Word'></i>"
                    ElseIf DR("FileName").Contains(".pptx") Or DR("FileName").Contains(".ppt") Or DR("FileName").Contains(".PPTX") Or DR("FileName").Contains(".PPT") Then
                        Icon = "<i class='las la-file-powerpoint text-warning fs-1' title='Powerpoint'></i>"
                    ElseIf DR("FileName").Contains(".pdf") Or DR("FileName").Contains(".PDF") Then
                        Icon = "<i class='las la-file-pdf text-danger fs-1' title='PDF'></i>"
                    End If
                    'set icon for specific file


                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='Download' onclick=""fn0201Download('FRM000009','" & pID & "','" & DR("FileName") & "');return false;""><i class='las la-download fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0201Delete('FRM000009','" & pID & "','" & DR("FileName") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Type = Icon,
                        .Attachment = DR("FileName"),
                        .UploadedBy = DR("UploadedBy"),
                        .UploadedDate = DR("UploadedDate")
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
    Function Upload_Download(pID, pFileName, pDownloadedBy)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 15000
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Download_File"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000009")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pType", "Downloaded a file:")
        SqlCmd.Parameters.AddWithValue("@pDescription", pFileName)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pDownloadedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'view/download
        Dim View As String = "https://ciisportal.calmarland.com/Assets/Upload/Contracts/FRM000009/" & pID & "/" & pFileName
        'Dim View As String = "/Assets/Upload/Contracts/FRM000009/" & pID & "/" & pFileName
        'view/download

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        RecordList.Add(New With {
            .View = View
        })

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Function Upload_Delete(pID, pFileName, pDownloadedBy)

        'remove file
        'Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/FRM000009/" & pID & "/") & pFileName
        Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/FRM000009/" & pID & "/") & pFileName
        File.Delete(FilePath)
        'remove file

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Del_File"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000009")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pType", "Removed a file:")
        SqlCmd.Parameters.AddWithValue("@pDescription", pFileName)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        RecordList.Add(New With {
            .oReturn = "Attachment successfully remove."
        })

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Function SCM010101_Get_Upload_Record_Notice(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("   [A].FileName ")
        Query.Append("   ,dbo.ProperCase([B].first_name) [UploadedBy] ")
        Query.Append("   ,format([A].UploadedDate,'MM/dd/yyyy hh:mm tt') [UploadedDate] ")
        Query.Append("FROM ")
        Query.Append("   Mstr_Attachment [A] ")
        Query.Append("   left join employee [B] on [A].UploadedBy = [B].emp_no ")
        Query.Append("   left join Mstr_History [C] on [A].ID = [C].TblCode and [A].FormCode = [C].TblName and [A].UploadedDate = [C].CreatedDate ")
        Query.Append("where ")
        Query.Append("   [A].FormCode = 'FRM000009' ")
        Query.Append("   and [C].Type LIKE '%notice to proceed file%' ")
        Query.Append("   and [A].ID = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("   [A].UploadedDate ")
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

                    'create variable
                    Dim Icon As String
                    'create variable

                    'set icon for specific file
                    If DR("FileName").Contains(".png") Or DR("FileName").Contains(".PNG") Then
                        Icon = "<i class='las la-file-image text-purple fs-1' title='Image'></i>"
                    ElseIf DR("FileName").Contains(".jpg") Or DR("FileName").Contains(".jpeg") Or DR("FileName").Contains(".jpe") Or DR("FileName").Contains(".jfif") Or DR("FileName").Contains(".JPG") Or DR("FileName").Contains(".JPEG") Or DR("FileName").Contains(".JPE") Or DR("FileName").Contains(".JFIF") Then
                        Icon = "<i class='las la-file-image text-purple fs-1' title='Image'></i>"
                    ElseIf DR("FileName").Contains(".txt") Or DR("FileName").Contains(".TXT") Then
                        Icon = "<i class='las la-file-alt text-muted fs-1' title='Text'></i>"
                    ElseIf DR("FileName").Contains(".xlsx") Or DR("FileName").Contains(".xls") Or DR("FileName").Contains(".XLSX") Or DR("FileName").Contains(".XLS") Then
                        Icon = "<i class='las la-file-excel text-primary fs-1' title='Excel'></i>"
                    ElseIf DR("FileName").Contains(".docx") Or DR("FileName").Contains(".doc") Or DR("FileName").Contains(".DOCX") Or DR("FileName").Contains(".DOC") Then
                        Icon = "<i class='las la-file-word text-info fs-1' title='Word'></i>"
                    ElseIf DR("FileName").Contains(".pptx") Or DR("FileName").Contains(".ppt") Or DR("FileName").Contains(".PPTX") Or DR("FileName").Contains(".PPT") Then
                        Icon = "<i class='las la-file-powerpoint text-warning fs-1' title='Powerpoint'></i>"
                    ElseIf DR("FileName").Contains(".pdf") Or DR("FileName").Contains(".PDF") Then
                        Icon = "<i class='las la-file-pdf text-danger fs-1' title='PDF'></i>"
                    End If
                    'set icon for specific file


                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='Download' onclick=""fn0401Download('FRM000009','" & pID & "','" & DR("FileName") & "');return false;""><i class='las la-download fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0401Delete('FRM000009','" & pID & "','" & DR("FileName") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Type = Icon,
                        .Attachment = DR("FileName"),
                        .UploadedBy = DR("UploadedBy"),
                        .UploadedDate = DR("UploadedDate")
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
    Function Upload_Download_Notice(pID, pFileName, pDownloadedBy)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 15000
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Download_File"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000009")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pType", "Downloaded a file:")
        SqlCmd.Parameters.AddWithValue("@pDescription", pFileName)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pDownloadedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'view/download
        Dim View As String = "https://ciisportal.calmarland.com/Assets/Upload/Contracts/Notice/FRM000009/" & pID & "/" & pFileName
        'Dim View As String = "/Assets/Upload/Contracts/Notice/FRM000009/" & pID & "/" & pFileName
        'view/download

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        RecordList.Add(New With {
            .View = View
        })

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Function Upload_Delete_Notice(pID, pFileName, pDownloadedBy)

        'remove file
        'Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Notice/FRM000009/" & pID & "/") & pFileName
        Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/Notice/FRM000009/" & pID & "/") & pFileName
        File.Delete(FilePath)
        'remove file

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Del_File"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000009")
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pType", "Removed a file:")
        SqlCmd.Parameters.AddWithValue("@pDescription", pFileName)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        RecordList.Add(New With {
            .oReturn = "Attachment successfully remove."
        })

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Function For_Award_Get_Contractor_List(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].tag_code [ID] ")
        Query.Append("  ,[B].vendor [ConName] ")
        Query.Append("  ,[A].v_code [Code] ")
        Query.Append("  ,ISNULL([B].type, '-') [Type] ")
        Query.Append("  ,[A].seq_no [SeqNo] ")
        Query.Append("  ,[C].fullname [TagByName] ")
        Query.Append("  ,FORMAT([A].tag_date, 'MM/dd/yyyy') [TagDate] ")
        Query.Append("  ,(CASE WHEN [A].status = 1 and ISNULL([A].acct_status, '') = 'Due' then 'Due' ")
        Query.Append("         WHEN [A].status = 1 and ISNULL([A].acct_status, '') = 'Cancelled' then 'Cancelled' ")
        Query.Append("         WHEN [A].status = 1 and ISNULL([A].acct_status, '') = 'Declined' then 'Declined' ")
        Query.Append("         WHEN [A].status = 1 and ISNULL([A].acct_status, '') = '' then 'Confirmed' ")
        Query.Append("         WHEN [A].status = 1 and ISNULL([A].acct_status, '') = 'Awarded' then 'Awarded' ")
        Query.Append("         WHEN [A].status = 0 and ISNULL([A].acct_status, '') = '' then 'Pending' ")
        Query.Append("         END) [Status] ")
        Query.Append("  ,isnull([A].note, '') [Note] ")
        Query.Append("from ")
        Query.Append("  SCM_TagContractors [A] ")
        Query.Append("  left join ogm_vendor [B] on [A].v_code = [B].v_code ")
        Query.Append("  left join employee [C] on [A].tag_by = [C].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].tag_code = @pID ")
        Query.Append("order by ")
        Query.Append("  [A].seq_no ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this); return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn0301View('" & DR("Code") & "'); return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-add' title='Award' onclick=""fn0301Award('" & pID & "', '" & DR("Code") & "', '" & DR("Status") & "'); return false;""><i class='las la-check-square fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Update' onclick=""fn0301Update('" & pID & "', '" & DR("Code") & "', '" & DR("Status") & "'); return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Decline' onclick=""fn0301Declined('" & pID & "', '" & DR("Code") & "', '" & DR("Status") & "'); return false;""><i class='las la-window-close fs-3'></i></button>")
                    If {"Cancelled", "Declined"}.Contains(DR("Status")) And DR("Note") <> "" Then
                        Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Note' onclick=""fn0301ViewNote('" & pID & "', '" & DR("Code") & "'); return false;""><i class='las la-comment fs-3'></i></button>")
                    End If
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .Action = Action.ToString(),
                        .ID = DR("ID"),
                        .ConName = DR("ConName"),
                        .Code = DR("Code"),
                        .Type = DR("Type"),
                        .SeqNo = DR("SeqNo"),
                        .TagByName = DR("TagByName"),
                        .TagDate = DR("TagDate"),
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
    Function For_Award_Get_Contractor_List_Project(pCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  1 [SeqNo] ")
        Query.Append("  ,[B].Category ")
        Query.Append("  ,[B].Project ")
        Query.Append("  ,[A].f_code [ID] ")
        Query.Append("  ,dbo.Get_Link([A].tbl_from) + '-DTL-' + [A].f_code [Link] ")
        Query.Append("  ,Format([B].ContractPrice, 'N2') [ContractPrice] ")
        Query.Append("  ,[B].ContractCategory ")
        Query.Append("  ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("  ,[B].ContractStatus [Status] ")
        Query.Append("  ,Format([B].DateAwarded, 'MM/dd/yyyy') [Date] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [B].Contractor = 'MN2021020000' ")
        'Query.Append("  and [B].Contractor = @pCode ")
        Query.Append("  and [B].ContractStatus in ('Awarded') ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  2 [SeqNo] ")
        Query.Append("  ,[A].Type [Category] ")
        Query.Append("  ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("  ,[A].HWCode [ID] ")
        Query.Append("  ,'SCM000007-' + [A].HWCode [Link] ")
        Query.Append("  ,Format([A].ConPrice, 'N2') [ContractPrice] ")
        Query.Append("  ,[A].ConCategory [ContractCategory] ")
        Query.Append("  ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [Name] ")
        Query.Append("  ,[A].ConStatus [Status] ")
        Query.Append("  ,Format([A].ConDate, 'MM/dd/yyyy') [Date] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [C] on [A].House = [C].ModelCode ")
        Query.Append("  left join employee [D] on [A].CreatedBy = [D].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].Contractor = 'MN2021020000' ")
        'Query.Append("  [A].Contractor = @pCode ")
        Query.Append("  and [A].ConStatus in ('Awarded') ")
        Query.Append("order by ")
        Query.Append("  [SeqNo],[Date] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .Category = DR("Category"),
                        .Project = DR("Project"),
                        .Link = DR("Link"),
                        .ContractPrice = DR("ContractPrice"),
                        .ContractCategory = DR("ContractCategory"),
                        .Name = DR("Name"),
                        .Status = DR("Status"),
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
    Function Get_Contractor()

        'get query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("  v_code [Code] ")
        Query.Append("  ,vendor [Name] ")
        Query.Append("  ,type [Type] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,cel_no [MobileNo] ")
        Query.Append("from ")
        Query.Append("  ogm_vendor ")
        Query.Append("where ")
        Query.Append("  isnull(lock, 0) = 1 ")
        Query.Append("  and type = 'Contractor' ")
        Query.Append("  and email LIKE '%@__%' ")
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
                        .Code = DR("Code"),
                        .Name = DR("Name"),
                        .Type = DR("Type"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .MobileNo = DR("MobileNo")
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
    Function For_Award_Email_COF(pID, pCodeSrs, pEmailSrs, pContent, pTagBy, pDateFrom, pDateTo, pCC)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [C].description [SubdName] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].Code ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].f_code = @pID ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    'create connection
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim SqlCmd As New SqlCommand
                    SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.Connection = SqlConn
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandText = "SCM_Batch_Tag"
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pCodeSrs", pCodeSrs)
                    SqlCmd.Parameters.AddWithValue("@pTagBy", pTagBy)
                    SqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                    SqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                    Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
                    oMsg.Direction = ParameterDirection.Output
                    SqlCmd.Parameters.Add(oMsg)
                    'create connection

                    'execute procedure
                    SqlConn.Open()
                    SqlCmd.ExecuteNonQuery()
                    SqlConn.Close()
                    'execute procedure

                    'mail
                    If oMsg.Value.ToString = "" Then
                        'seperate
                        Dim sepEmail As String() = pEmailSrs.ToString.Split(","c)
                        Dim CarbonCopy As String() = pCC.ToString.Split(","c)
                        'seperate

                        'loop
                        For Each val As String In sepEmail

                            'mail
                            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
                            Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
                            Dim mail As MailMessage
                            Dim body As String
                            smtp.Credentials = New NetworkCredential("emailnotification@calmarland.com", "bnyqrxvdcvxxctyd")
                            smtp.Host = "smtp.office365.com"
                            smtp.Port = 587
                            smtp.EnableSsl = True
                            mail = New MailMessage()
                            mail.From = New MailAddress("ciissystems@calmarland.com")
                            mail.To.Add(val)
                            For Each cc As String In CarbonCopy
                                mail.CC.Add(cc)
                            Next
                            mail.Subject = "FINISHING WORKS FOR " + DR("SubdName")
                            body = pContent
                            mail.Body = body
                            mail.IsBodyHtml = True

                            'attachment
                            Dim folderPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/FRM000009/" & pID & "/")
                            If Directory.Exists(folderPath) Then
                                For Each filePath As String In Directory.GetFiles(folderPath)
                                    Dim attachment As New System.Net.Mail.Attachment(filePath)
                                    mail.Attachments.Add(attachment)
                                Next
                            End If
                            'attachment

                            smtp.Send(mail)
                            mail.Dispose()
                            'mail

                        Next
                        'loop

                    End If
                    'mail

                    'add value
                    RecordList.Add(New With {.oReturn = oMsg.Value.ToString})
                    'add value

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function For_Awarding_COF(pID, pCode, pNTPNo, pNTPDate, pPOCStart, pUpdatedBy)

        'variable
        Dim RecordList As New List(Of Object)()
        Dim ConEmail As String
        Dim ConName As String
        Dim Category As String
        Dim Project As String
        Dim ConCategory As String
        Dim ConPrice As String
        Dim SeqNo As Int32
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SCM_CON_Award"
        SqlCmd.Parameters.AddWithValue("@pFCode", pID)
        SqlCmd.Parameters.AddWithValue("@pCode", pCode)
        SqlCmd.Parameters.AddWithValue("@pNTPNo", pNTPNo)
        SqlCmd.Parameters.AddWithValue("@pNTPDate", pNTPDate)
        SqlCmd.Parameters.AddWithValue("@pPOCStart", pPOCStart)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", pUpdatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'get con email, name
        Dim ConQuery As New StringBuilder
        ConQuery.Append("select ")
        ConQuery.Append("   vendor [Name] ")
        ConQuery.Append("   ,email [Email] ")
        ConQuery.Append("from ")
        ConQuery.Append("   ogm_vendor  ")
        ConQuery.Append("where ")
        ConQuery.Append("   v_code = @pCode ")
        'get con email, name

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(ConQuery.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()
                    ConName = DR("Name")
                    ConEmail = DR("Email")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'get details
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  1 [SeqNo] ")
        Query.Append("  ,[B].Category [Category] ")
        Query.Append("  ,[C].description [Project] ")
        Query.Append("  ,[B].ContractCategory [ContractCategory] ")
        Query.Append("  ,FORMAT([B].ContractPrice, 'N2') [ContractPrice] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].code ")
        Query.Append("where ")
        Query.Append("  [A].f_code = @pID ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  2 [SeqNo] ")
        Query.Append("  ,'House Construction' [Category] ")
        Query.Append("  ,UPPER([B].ProjName) [Project] ")
        Query.Append("  ,[A].ConCategory [ContractCategory] ")
        Query.Append("  ,FORMAT([A].ConPrice, 'N2') [ContractPrice] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].HWCode = @pID ")
        'get details

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()
                    SeqNo = DR("SeqNo")
                    Category = DR("Category")
                    Project = DR("Project")
                    ConCategory = DR("ContractCategory")
                    ConPrice = DR("ContractPrice")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        NotifyContractor(pID)

        'notify tag contractor that is awarded
        Dim Content As New StringBuilder
        Content.Append("<style>html,body { padding: 0; margin:0; } </style> ")
        Content.Append("<div style='font-family: Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7'>")
        Content.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse:collapse;margin:0 auto; padding:0; max-width:600px'>")
        Content.Append("    <tbody>")
        Content.Append("        <tr>")
        Content.Append("            <td align='center' valign='center' style='text-align:center; padding: 40px'>")
        Content.Append("                <a href='#'>")
        Content.Append("                    <img alt='Logo' src='https://raw.githubusercontent.com/carlrams/Image/main/ciislogo2-sticky.png' />")
        Content.Append("                </a>")
        Content.Append("            </td>")
        Content.Append("        </tr>")
        Content.Append("        <tr>")
        Content.Append("            <td align='left' valign='center'>")
        Content.Append("                <div style='text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px'>")
        Content.Append("                <div style='padding-bottom: 30px; font-size: 17px;'>")
        Content.Append("                    <strong>Happy Calmar Land Day! <span style='cursor: pointer;' onmouseover='this.style.color='#009EF7' onmouseout='this.style.color='#000'''>" & ConName & "</span></strong>")
        Content.Append("                </div>")
        Content.Append("                <div style='padding-bottom: 10px; font-size: 15px;'>")
        Content.Append("                    <strong>You have been awarded!</strong>")
        Content.Append("                </div>")
        Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'> ")
        Content.Append("                <br> ")
        Content.Append("                <strong>Type: <span style='font-style: italic;'> " & Category & " </span> </strong> ")
        Content.Append("                <br> ")
        Content.Append("                <strong>Project: <span style='font-style: italic;'> " & Project & " </span> </strong> ")
        Content.Append("                <br> ")
        Content.Append("                <strong>Contract Order: <span style='font-style: italic;'> " & ConCategory & " </span> </strong> ")
        Content.Append("                <br> ")
        Content.Append("                <strong>Contract Price: <span style='font-style: italic;'> ₱ " & ConPrice & " </span> </strong> ")
        Content.Append("                <br> ")
        Content.Append("                <br> ")
        Content.Append("                For more information visit Contractors Dashboard to see more details: ")
        Content.Append("                </div>")
        Content.Append("                <div style='padding-bottom: 40px; text-align:center;'> ")
        Content.Append("            	<a href='https://contractorsportal.calmarland.com/CNU000001' rel='noopener' style='text-decoration:none;display:inline-block;text-align:center;padding:0.75575rem 1.3rem;font-size:0.925rem;line-height:1.5;border-radius:0.35rem;color:#ffffff;background-color:#009EF7;border:0px;margin-right:0.75rem!important;font-weight:600!important;outline:none!important;vertical-align:middle' target='_blank'>Contractor's Portal</a>")
        Content.Append("				</div> ")
        Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'>If you have any questions or inquiry, get in touch with us at ")
        Content.Append("                <a href='#' rel='noopener' target='_blank' style='text-decoration:none;color: #009EF7'>info@calmarland.com</a>.</div> ")
        Content.Append("                <div style='padding-bottom: 10px'>Kind regards,")
        Content.Append("                <br>CDLC Team.")
        Content.Append("                    <tr>")
        Content.Append("                        <td align='center' valign='center' style='font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;'> ")
        Content.Append("                            <div style='display: flex; justify-content: center; flex-wrap: wrap; padding: 5px;'> ")
        Content.Append("                                <div style='display: flex; justify-content: center;'> ")
        Content.Append("                                <span style='font-weight: bold; margin: 5px; border-style: none;'>2023 ©</span><img src='https://calmarland.net/Resources/logo-single.png' height='25' width='25'><span style='color: gray; font-weight: bold; margin: 5px;'>   CIIS 2023.08.04</span> ")
        Content.Append("                                </div> ")
        Content.Append("                            </div>")
        Content.Append("                        </td>")
        Content.Append("                    </tr></br></div>")
        Content.Append("                </div>")
        Content.Append("            </td>")
        Content.Append("        </tr>")
        Content.Append("        </tbody>")
        Content.Append("    </table>")
        Content.Append("</div>")

        'send email
        If ConEmail <> "" Then

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
            Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
            Dim mail As MailMessage
            Dim body As String
            smtp.Credentials = New NetworkCredential("emailnotification@calmarland.com", "bnyqrxvdcvxxctyd")
            smtp.Host = "smtp.office365.com"
            smtp.Port = 587
            smtp.EnableSsl = True
            mail = New MailMessage()
            mail.From = New MailAddress("ciissystems@calmarland.com")
            mail.To.Add(ConEmail)
            mail.CC.Add("carl.ramos@calmarland.com")
            'mail.CC.Add("evangeline.pasinio@calmarland.com")
            'mail.CC.Add("haryete.alperez@calmarland.com")
            'mail.CC.Add("arvin.rey@calmarland.com")
            'mail.CC.Add("ira.satur@calmarland.com")
            If SeqNo = 1 Then
                mail.Subject = "FINISHING WORKS FOR " + Project
            ElseIf SeqNo = 2 Then
                mail.Subject = "HOUSE PROPOSAL FOR " + Project
            End If
            mail.IsBodyHtml = True
            mail.Body = Content.ToString
            smtp.Send(mail)
            mail.Dispose()

        End If

        'add value
        RecordList.Add(New With {.oReturn = "Successfully awarded"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function For_Award_Get_Update_Deadline(pID, pCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  FORMAT(date_from, 'MM/dd/yyyy') [DateFrom] ")
        Query.Append("  ,FORMAT(date_to, 'MM/dd/yyyy') [DateTo] ")
        Query.Append("from ")
        Query.Append("  SCM_Tag_Deadline ")
        Query.Append("where ")
        Query.Append("  f_code = @pID ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .DateFrom = DR("DateFrom"),
                        .DateTo = DR("DateTo")
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
    Function For_Award_Update_Deadline(pID, pCode, pDateFrom, pDateTo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("UPDATE SCM_Tag_Deadline SET ")
        Query.Append("  date_from = @pDateFrom ")
        Query.Append("  ,date_to = @pDateTo ")
        Query.Append("where ")
        Query.Append("  f_code = @pID ")
        Query.Append("UPDATE SCM_TagContractors SET ")
        Query.Append("  status = 0 ")
        Query.Append("  ,acct_status = NULL ")
        Query.Append("where ")
        Query.Append("  tag_code = @pID ")
        Query.Append("  and v_code = @pCode ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                Cmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                Cmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()
                    RecordList.Add(New With {.oReturn = "Successfully updated the deadline"})
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
    Function NotifyContractor(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  1 [SeqNo] ")
        Query.Append("  ,[B].email [Email] ")
        Query.Append("  ,[D].Project [Project] ")
        Query.Append("  ,[B].vendor [Contractor] ")
        Query.Append("  ,[E].description [SubdName] ")
        Query.Append("from ")
        Query.Append("  SCM_TagContractors [A] ")
        Query.Append("  left join ogm_vendor [B] on [A].v_code = [B].v_code ")
        Query.Append("  left join oop_form_hdr [C] on [A].tag_code = [C].f_code ")
        Query.Append("  left join Form_CRT [D] on [C].tbl_code = [D].CRTCode ")
        Query.Append("  left join subdivision [E] on [D].Subdivision = [E].Code ")
        Query.Append("where ")
        Query.Append("  [A].tag_code = @pID ")
        Query.Append("  and [A].acct_status = 'Cancelled' ")
        Query.Append("  and ISNULL([D].CRTCode, '') != '' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  2 [SeqNo] ")
        Query.Append("  ,[B].email [Email] ")
        Query.Append("  ,[D].ProjInit + ' ' + [C].Phase + ' B' + [C].Block + ' L' + [C].Lot [Project] ")
        Query.Append("  ,[B].vendor [Contractor] ")
        Query.Append("  ,UPPER([D].ProjName) [SubdName] ")
        Query.Append("from ")
        Query.Append("  SCM_TagContractors [A] ")
        Query.Append("  left join ogm_vendor [B] on [A].v_code = [B].v_code ")
        Query.Append("  left join Form_HWHdr [C] on [A].tag_code = [C].HWCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [D] on [C].Subd = [D].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].tag_code = @pID ")
        Query.Append("  and [A].acct_status = 'Cancelled' ")
        Query.Append("  and ISNULL([C].HWCode, '') != '' ")
        'get query

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    'mailing
                    Dim Content As New StringBuilder
                    Content.Append("<style>html,body { padding: 0; margin:0; }</style> ")
                    Content.Append("<div style='font-family: Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7'>")
                    Content.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse:collapse;margin:0 auto; padding:0; max-width:600px'>")
                    Content.Append("    <tbody>")
                    Content.Append("        <tr>")
                    Content.Append("            <td align='center' valign='center' style='text-align:center; padding: 40px'>")
                    Content.Append("                <a href='#'>")
                    Content.Append("                    <img alt='Logo' src='https://raw.githubusercontent.com/carlrams/Image/main/ciislogo2-sticky.png' />")
                    Content.Append("                </a>")
                    Content.Append("            </td>")
                    Content.Append("        </tr>")
                    Content.Append("        <tr>")
                    Content.Append("            <td align='left' valign='center'>")
                    Content.Append("                <div style='text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px'>")
                    Content.Append("                <div style='padding-bottom: 30px; font-size: 17px;'>")
                    Content.Append("                    <strong>Happy Calmar Land Day! <span style='cursor: pointer;' onmouseover='this.style.color='#009EF7' onmouseout='this.style.color='#000'''>" & DR("Contractor") & "</span></strong>")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 10px; font-size: 15px;'>")
                    Content.Append("                    We would like to inform you that the project <strong style='font-style: italic;'>" & DR("Project") & "</strong> has been awarded to another contractor. We appreciate your interest and involvement in this process.")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'>")
                    Content.Append("                <br>")
                    Content.Append("                    While your proposal was not selected for this project, we value your expertise and hope to engage with you in future projects. Should there be any additional opportunities or if there is any other project in which you are interested, please do not hesitate to contact us.")
                    Content.Append("                <br> ")
                    Content.Append("                <br> ")
                    Content.Append("                    For more information visit Contractors Dashboard to see more details: ")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 40px; text-align:center;'> ")
                    Content.Append("            	<a href='https://contractorsportal.calmarland.com/' rel='noopener' style='text-decoration:none;display:inline-block;text-align:center;padding:0.75575rem 1.3rem;font-size:0.925rem;line-height:1.5;border-radius:0.35rem;color:#ffffff;background-color:#009EF7;border:0px;margin-right:0.75rem!important;font-weight:600!important;outline:none!important;vertical-align:middle' target='_blank'>Contractor's Portal</a>")
                    Content.Append("				</div>")
                    Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'>If you have any questions or inquiry, get in touch with us at")
                    Content.Append("                <a href='#' rel='noopener' target='_blank' style='text-decoration:none;color: #009EF7'>info@calmarland.com</a>.</div>")
                    Content.Append("                <div style='padding-bottom: 10px'>Kind regards,")
                    Content.Append("                <br>CDLC Team.")
                    Content.Append("                    <tr>")
                    Content.Append("                        <td align='center' valign='center' style='font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;'>")
                    Content.Append("                            <div style='display: flex; justify-content: center; flex-wrap: wrap; padding: 5px;'>")
                    Content.Append("                                <div style='display: flex; justify-content: center;'>")
                    Content.Append("                                <span style='font-weight: bold; margin: 5px; border-style: none;'>2023 ©</span><img src='https://calmarland.net/Resources/logo-single.png' height='25' width='25'><span style='color: gray; font-weight: bold; margin: 5px;'>   CIIS 2023.08.04</span>")
                    Content.Append("                                </div>")
                    Content.Append("                            </div>")
                    Content.Append("                        </td>")
                    Content.Append("                    </tr></br></div>")
                    Content.Append("                </div>")
                    Content.Append("            </td>")
                    Content.Append("        </tr>")
                    Content.Append("        </tbody>")
                    Content.Append("    </table>")
                    Content.Append("</div>")
                    'mailing

                    'send email
                    Dim Email As String = DR("Email")
                    If Email <> "" Then

                        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
                        Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
                        Dim mail As MailMessage
                        Dim body As String
                        smtp.Credentials = New NetworkCredential("emailnotification@calmarland.com", "bnyqrxvdcvxxctyd")
                        smtp.Host = "smtp.office365.com"
                        smtp.Port = 587
                        smtp.EnableSsl = True
                        mail = New MailMessage()
                        mail.From = New MailAddress("ciissystems@calmarland.com")
                        mail.To.Add(Email)
                        mail.CC.Add("carl.ramos@calmarland.com")
                        'mail.CC.Add("evangeline.pasinio@calmarland.com")
                        'mail.CC.Add("haryete.alperez@calmarland.com")
                        'mail.CC.Add("arvin.rey@calmarland.com")
                        'mail.CC.Add("ira.satur@calmarland.com")
                        If DR("SeqNo") = 1 Then
                            mail.Subject = "FINISHING WORKS FOR " + DR("SubdName")
                        ElseIf DR("SeqNo") = 2 Then
                            mail.Subject = "HOUSE CONSTRUCTION FOR " + DR("SubdName")
                        End If
                        mail.IsBodyHtml = True
                        mail.Body = Content.ToString
                        smtp.Send(mail)
                        mail.Dispose()
                    End If
                    'send email

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

    End Function
    Function For_Award_Declined_Project(pID, pCode)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'get query
        Dim Query As New StringBuilder
        Query.Append("UPDATE SCM_TagContractors set ")
        Query.Append("  status = 1 ")
        Query.Append("  ,acct_status = 'Cancelled' ")
        Query.Append("where ")
        Query.Append("  tag_code = @pID ")
        Query.Append("  and v_code = @pCode ")
        Query.Append("select ")
        Query.Append("  1 [SeqNo] ")
        Query.Append("  ,[b].Project [Project] ")
        Query.Append("  ,[c].description [SubdName] ")
        Query.Append("  ,[d].vendor [ConName] ")
        Query.Append("  ,ISNULL((select email from ogm_vendor where v_code= @pCode), '') [Email] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [a] ")
        Query.Append("  left join Form_CRT [b] on [a].tbl_code = [b].CRTCode ")
        Query.Append("  left join subdivision [c] on [b].Subdivision = [c].code ")
        Query.Append("  left join ogm_vendor [d] on [b].Contractor = [d].v_code ")
        Query.Append("where ")
        Query.Append("  [a].tbl_from = 'Form_CRT' ")
        Query.Append("  and [a].f_code = @pID ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  2 [SeqNo] ")
        Query.Append("  ,[b].ProjInit + ' ' + [a].Phase + ' B' + [a].Block + ' L' + [a].Lot [Project] ")
        Query.Append("  ,UPPER([b].ProjName) [SubdName] ")
        Query.Append("  ,[c].vendor [ConName] ")
        Query.Append("  ,ISNULL((select email from ogm_vendor where v_code = @pCode), '') [Email] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [a] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [b] on [a].Subd = [b].ProjCode ")
        Query.Append("  left join ogm_vendor [c] on [a].Contractor = [c].v_code ")
        Query.Append("where ")
        Query.Append("  [a].HWCode = @pID ")
        'get query

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    'mailing
                    Dim Content As New StringBuilder
                    Content.Append("<style>html,body { padding: 0; margin:0; }</style> ")
                    Content.Append("<div style='font-family: Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7'>")
                    Content.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse:collapse;margin:0 auto; padding:0; max-width:600px'>")
                    Content.Append("    <tbody>")
                    Content.Append("        <tr>")
                    Content.Append("            <td align='center' valign='center' style='text-align:center; padding: 40px'>")
                    Content.Append("                <a href='#'>")
                    Content.Append("                    <img alt='Logo' src='https://raw.githubusercontent.com/carlrams/Image/main/ciislogo2-sticky.png' />")
                    Content.Append("                </a>")
                    Content.Append("            </td>")
                    Content.Append("        </tr>")
                    Content.Append("        <tr>")
                    Content.Append("            <td align='left' valign='center'>")
                    Content.Append("                <div style='text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px'>")
                    Content.Append("                <div style='padding-bottom: 30px; font-size: 17px;'>")
                    Content.Append("                    <strong>Happy Calmar Land Day! <span style='cursor: pointer;' onmouseover='this.style.color='#009EF7' onmouseout='this.style.color='#000'''>" & DR("ConName") & "</span></strong>")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 10px; font-size: 15px;'>")
                    Content.Append("                    We would like to inform you that the project <strong style='font-style: italic;'>" & DR("Project") & "</strong> that was endorsed to you has been declined. We sincerely appreciate your interest, time, and participation in this process. Thank you for your continued support and understanding.")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'>")
                    Content.Append("                <br>")
                    Content.Append("                    While the proposal project was declined, we value your expertise and hope to engage with you in future projects. Should there be any additional opportunities or if there is any other project in which you are interested, please do not hesitate to contact us.")
                    Content.Append("                <br> ")
                    Content.Append("                <br> ")
                    Content.Append("                    For more information visit Contractors Dashboard to see more details: ")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 40px; text-align:center;'> ")
                    Content.Append("            	<a href='https://contractorsportal.calmarland.com/' rel='noopener' style='text-decoration:none;display:inline-block;text-align:center;padding:0.75575rem 1.3rem;font-size:0.925rem;line-height:1.5;border-radius:0.35rem;color:#ffffff;background-color:#009EF7;border:0px;margin-right:0.75rem!important;font-weight:600!important;outline:none!important;vertical-align:middle' target='_blank'>Contractor's Portal</a>")
                    Content.Append("				</div>")
                    Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'>If you have any questions or inquiry, get in touch with us at")
                    Content.Append("                <a href='#' rel='noopener' target='_blank' style='text-decoration:none;color: #009EF7'>info@calmarland.com</a>.</div>")
                    Content.Append("                <div style='padding-bottom: 10px'>Kind regards,")
                    Content.Append("                <br>CDLC Team.")
                    Content.Append("                    <tr>")
                    Content.Append("                        <td align='center' valign='center' style='font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;'>")
                    Content.Append("                            <div style='display: flex; justify-content: center; flex-wrap: wrap; padding: 5px;'>")
                    Content.Append("                                <div style='display: flex; justify-content: center;'>")
                    Content.Append("                                <span style='font-weight: bold; margin: 5px; border-style: none;'>2023 ©</span><img src='https://calmarland.net/Resources/logo-single.png' height='25' width='25'><span style='color: gray; font-weight: bold; margin: 5px;'>   CIIS 2023.08.04</span>")
                    Content.Append("                                </div>")
                    Content.Append("                            </div>")
                    Content.Append("                        </td>")
                    Content.Append("                    </tr></br></div>")
                    Content.Append("                </div>")
                    Content.Append("            </td>")
                    Content.Append("        </tr>")
                    Content.Append("        </tbody>")
                    Content.Append("    </table>")
                    Content.Append("</div>")
                    'mailing

                    'send email
                    Dim Email As String = DR("Email")
                    If Email <> "" Then
                        Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
                        Dim mail As MailMessage
                        Dim body As String
                        smtp.Credentials = New NetworkCredential("ciissystems@calmarland.com", "!@CLDCciisCS@23")
                        smtp.Host = "mail.calmarland.com"
                        smtp.Port = 587
                        mail = New MailMessage()
                        mail.From = New MailAddress("ciissystems@calmarland.com")
                        mail.To.Add(Email)
                        'mail.CC.Add("evangeline.pasinio@calmarland.com")
                        'mail.CC.Add("haryete.alperez@calmarland.com")
                        'mail.CC.Add("arvin.rey@calmarland.com")
                        'mail.CC.Add("ira.satur@calmarland.com")
                        If DR("SeqNo") = 1 Then
                            mail.Subject = "FINISHING WORKS FOR " + DR("SubdName")
                        ElseIf DR("SeqNo") = 2 Then
                            mail.Subject = "HOUSE PROPOSAL FOR " + DR("SubdName")
                        End If
                        mail.IsBodyHtml = True
                        mail.Body = Content.ToString
                        smtp.Send(mail)
                        mail.Dispose()
                    End If
                    'send email

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'add value
        RecordList.Add(New With {.oReturn = "Successfully declined"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function For_Award_Get_Contractor_Note(pID, pCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL(note, '') [Note] ")
        Query.Append("from ")
        Query.Append("  SCM_TagContractors ")
        Query.Append("where ")
        Query.Append("  tag_code = @pID ")
        Query.Append("  and v_code = @pCode ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordList.Add(New With {
                        .Note = DR("Note")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function For_Award_Get_Contractor_ReOpen(pID, pCode)

        'update
        Dim Query As New StringBuilder
        Query.Append("UPDATE SCM_TagContractors set ")
        Query.Append("  status = 0 ")
        Query.Append("  ,acct_status = NULL ")
        Query.Append("  ,note = NULL ")
        Query.Append("WHERE ")
        Query.Append("  tag_code = @pID ")
        Query.Append("  and v_code = @pCode ")
        Query.Append("select ")
        Query.Append("  1 [SeqNo] ")
        Query.Append("  ,[b].Project [Project] ")
        Query.Append("  ,[c].description [SubdName] ")
        Query.Append("  ,[d].vendor [ConName] ")
        Query.Append("  ,ISNULL((select email from ogm_vendor where v_code = @pCode), '') [Email] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [a] ")
        Query.Append("  left join Form_CRT [b] on [a].tbl_code = [b].CRTCode ")
        Query.Append("  left join subdivision [c] on [b].Subdivision = [c].code ")
        Query.Append("  left join ogm_vendor [d] on [b].Contractor = [d].v_code ")
        Query.Append("where ")
        Query.Append("  [a].tbl_from = 'Form_CRT' ")
        Query.Append("  and [a].f_code = @pID ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  2 [SeqNo] ")
        Query.Append("  ,[b].ProjInit + ' ' + [a].Phase + ' B' + [a].Block + ' L' + [a].Lot [Project] ")
        Query.Append("  ,UPPER([b].ProjName) [SubdName] ")
        Query.Append("  ,[c].vendor [ConName] ")
        Query.Append("  ,ISNULL((select email from ogm_vendor where v_code = @pCode), '') [Email] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [a] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [b] on [a].Subd = [b].ProjCode ")
        Query.Append("  left join ogm_vendor [c] on [a].Contractor = [c].v_code ")
        Query.Append("where ")
        Query.Append("  [a].HWCode = @pID ")
        'update

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pCode", pCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'mailing
                    Dim Content As New StringBuilder
                    Content.Append("<style>html,body { padding: 0; margin:0; }</style> ")
                    Content.Append("<div style='font-family: Arial,Helvetica,sans-serif; line-height: 1.5; font-weight: normal; font-size: 15px; color: #2F3044; min-height: 100%; margin:0; padding:0; width:100%; background-color:#edf2f7'>")
                    Content.Append("<table align='center' border='0' cellpadding='0' cellspacing='0' width='100%' style='border-collapse:collapse;margin:0 auto; padding:0; max-width:600px'>")
                    Content.Append("    <tbody>")
                    Content.Append("        <tr>")
                    Content.Append("            <td align='center' valign='center' style='text-align:center; padding: 40px'>")
                    Content.Append("                <a href='#'>")
                    Content.Append("                    <img alt='Logo' src='https://raw.githubusercontent.com/carlrams/Image/main/ciislogo2-sticky.png' />")
                    Content.Append("                </a>")
                    Content.Append("            </td>")
                    Content.Append("        </tr>")
                    Content.Append("        <tr>")
                    Content.Append("            <td align='left' valign='center'>")
                    Content.Append("                <div style='text-align:left; margin: 0 20px; padding: 40px; background-color:#ffffff; border-radius: 6px'>")
                    Content.Append("                <div style='padding-bottom: 30px; font-size: 17px;'>")
                    Content.Append("                    <strong>Happy Calmar Land Day! <span style='cursor: pointer;' onmouseover='this.style.color='#009EF7' onmouseout='this.style.color='#000'''>" & DR("ConName") & "</span></strong>")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 10px; font-size: 15px;'>")
                    Content.Append("                    We would like to inform you that the project <strong style='font-style: italic;'>" & DR("Project") & "</strong> that was endorsed is already been re-opened. We sincerely appreciate your interest, time, and participation in this process. Thank you for your continued support and understanding.")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'>")
                    Content.Append("                <br>")
                    Content.Append("                    Should there be any additional opportunities or if there is any other project in which you are interested, please do not hesitate to contact us.")
                    Content.Append("                <br> ")
                    Content.Append("                <br> ")
                    Content.Append("                    For more information visit Contractors Dashboard to see more details: ")
                    Content.Append("                </div>")
                    Content.Append("                <div style='padding-bottom: 40px; text-align:center;'> ")
                    Content.Append("            	<a href='https://contractorsportal.calmarland.com/' rel='noopener' style='text-decoration:none;display:inline-block;text-align:center;padding:0.75575rem 1.3rem;font-size:0.925rem;line-height:1.5;border-radius:0.35rem;color:#ffffff;background-color:#009EF7;border:0px;margin-right:0.75rem!important;font-weight:600!important;outline:none!important;vertical-align:middle' target='_blank'>Contractor's Portal</a>")
                    Content.Append("				</div>")
                    Content.Append("                <div style='padding-bottom: 30px; text-align: justify;'>If you have any questions or inquiry, get in touch with us at")
                    Content.Append("                <a href='#' rel='noopener' target='_blank' style='text-decoration:none;color: #009EF7'>info@calmarland.com</a>.</div>")
                    Content.Append("                <div style='padding-bottom: 10px'>Kind regards,")
                    Content.Append("                <br>CDLC Team.")
                    Content.Append("                    <tr>")
                    Content.Append("                        <td align='center' valign='center' style='font-size: 13px; text-align:center;padding: 20px; color: #6d6e7c;'>")
                    Content.Append("                            <div style='display: flex; justify-content: center; flex-wrap: wrap; padding: 5px;'>")
                    Content.Append("                                <div style='display: flex; justify-content: center;'>")
                    Content.Append("                                <span style='font-weight: bold; margin: 5px; border-style: none;'>2023 ©</span><img src='https://calmarland.net/Resources/logo-single.png' height='25' width='25'><span style='color: gray; font-weight: bold; margin: 5px;'>   CIIS 2023.08.04</span>")
                    Content.Append("                                </div>")
                    Content.Append("                            </div>")
                    Content.Append("                        </td>")
                    Content.Append("                    </tr></br></div>")
                    Content.Append("                </div>")
                    Content.Append("            </td>")
                    Content.Append("        </tr>")
                    Content.Append("        </tbody>")
                    Content.Append("    </table>")
                    Content.Append("</div>")
                    'mailing

                    'send email
                    Dim Email As String = DR("Email")
                    If Email <> "" Then
                        Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
                        Dim mail As MailMessage
                        Dim body As String
                        smtp.Credentials = New NetworkCredential("ciissystems@calmarland.com", "!@CLDCciisCS@23")
                        smtp.Host = "mail.calmarland.com"
                        smtp.Port = 587
                        mail = New MailMessage()
                        mail.From = New MailAddress("ciissystems@calmarland.com")
                        mail.To.Add(Email)
                        mail.CC.Add("carl.ramos@calmarland.com")
                        'mail.CC.Add("evangeline.pasinio@calmarland.com")
                        'mail.CC.Add("haryete.alperez@calmarland.com")
                        'mail.CC.Add("arvin.rey@calmarland.com")
                        'mail.CC.Add("ira.satur@calmarland.com")
                        If DR("SeqNo") = 1 Then
                            mail.Subject = "FINISHING WORKS FOR " + DR("SubdName")
                        ElseIf DR("SeqNo") = 2 Then
                            mail.Subject = "HOUSE PROPOSAL FOR " + DR("SubdName")
                        End If
                        mail.IsBodyHtml = True
                        mail.Body = Content.ToString
                        smtp.Send(mail)
                        mail.Dispose()
                    End If
                    'send email

                    RecordList.Add(New With {
                        .oReturn = "Successfully re-open project"
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Private Function SCM010101_Get_Deadline(ID As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  Format(date_from, 'MM/dd/yyyy') [DateFrom] ")
        Query.Append("  ,Format(date_to, 'MM/dd/yyyy') [DateTo] ")
        Query.Append("from ")
        Query.Append("  SCM_Tag_Deadline ")
        Query.Append("where ")
        Query.Append("  f_code = '" & ID & "' ")
        'get query

        'variable
        Dim DeadlineDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    DeadlineDetails.Add(New With {
                        .DateFrom = DR("DateFrom"),
                        .DateTo = DR("DateTo")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(DeadlineDetails))
        'display 

    End Function

#End Region

#Region "SCM010102"
    Function SCM010102_For_Award_Img(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [B].ProjInit ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].HWCode = @pID ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ProjImage = DR("ProjInit")
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
    Function SCM010102_For_Award_House_Construction_General(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].HWCode [ID] ")
        Query.Append("   ,FORMAT([A].CreatedDate, 'MM/dd/yyyy') [DateCreated] ")
        Query.Append("   ,[A].Status [Status] ")
        Query.Append("   ,[A].Type ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,isnull([A].BatchNo, '-') [Batch] ")
        Query.Append("   ,FORMAT([A].ConPrice, 'N2') [Budget] ")
        Query.Append("from ")
        Query.Append("   Form_HWHdr [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = @pID ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .DateCreated = DR("DateCreated"),
                        .Status = DR("Status"),
                        .Type = DR("Type"),
                        .Project = DR("Project"),
                        .BatchNo = DR("Batch"),
                        .Budget = DR("Budget")
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
    Private Function SCM010102_Get_Deadline(ID As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  Format(date_from, 'MM/dd/yyyy') [DateFrom] ")
        Query.Append("  ,Format(date_to, 'MM/dd/yyyy') [DateTo] ")
        Query.Append("from ")
        Query.Append("  SCM_Tag_Deadline ")
        Query.Append("where ")
        Query.Append("  f_code = '" & ID & "' ")
        'get query

        'variable
        Dim DeadlineDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    DeadlineDetails.Add(New With {
                        .DateFrom = DR("DateFrom"),
                        .DateTo = DR("DateTo")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(DeadlineDetails))
        'display 

    End Function
    Function For_Award_Email_House_Construction(pID, pCodeSrs, pEmailSrs, pContent, pTagBy, pDateFrom, pDateTo, pCC)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  UPPER([B].ProjName) [SubdName] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].HWCode = @pID ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    'create connection
                    Dim SqlConn As New SqlClient.SqlConnection
                    Dim SqlCmd As New SqlCommand
                    SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.Connection = SqlConn
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandText = "SCM_Batch_Tag"
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pCodeSrs", pCodeSrs)
                    SqlCmd.Parameters.AddWithValue("@pTagBy", pTagBy)
                    SqlCmd.Parameters.AddWithValue("@pDateFrom", pDateFrom)
                    SqlCmd.Parameters.AddWithValue("@pDateTo", pDateTo)
                    Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
                    oMsg.Direction = ParameterDirection.Output
                    SqlCmd.Parameters.Add(oMsg)
                    'create connection

                    'execute procedure
                    SqlConn.Open()
                    SqlCmd.ExecuteNonQuery()
                    SqlConn.Close()
                    'execute procedure

                    'mail
                    If oMsg.Value.ToString = "" Then

                        'seperate
                        Dim sepEmail As String() = pEmailSrs.ToString.Split(","c)
                        Dim CarbonCopy As String() = pCC.ToString.Split(","c)
                        'seperate

                        'loop
                        For Each val As String In sepEmail

                            'mail
                            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12
                            Dim smtp As SmtpClient = New System.Net.Mail.SmtpClient()
                            Dim mail As MailMessage
                            Dim body As String
                            smtp.Credentials = New NetworkCredential("emailnotification@calmarland.com", "bnyqrxvdcvxxctyd")
                            smtp.Host = "smtp.office365.com"
                            smtp.Port = 587
                            smtp.EnableSsl = True
                            mail = New MailMessage()
                            mail.From = New MailAddress("ciissystems@calmarland.com")
                            mail.To.Add(val)
                            For Each cc As String In CarbonCopy
                                mail.CC.Add(cc)
                            Next
                            mail.Subject = "HOUSE PROPOSAL FOR " + DR("SubdName")
                            body = pContent
                            mail.Body = body
                            mail.IsBodyHtml = True

                            'attachment
                            Dim folderPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/Contracts/FRM000009/" & pID & "/")
                            If Directory.Exists(folderPath) Then
                                For Each filePath As String In Directory.GetFiles(folderPath)
                                    Dim attachment As New System.Net.Mail.Attachment(filePath)
                                    mail.Attachments.Add(attachment)
                                Next
                            End If
                            'attachment

                            smtp.Send(mail)
                            mail.Dispose()
                            'mail

                        Next
                        'loop

                    End If
                    'mail

                    'add value
                    RecordList.Add(New With {.oReturn = oMsg.Value.ToString})
                    'add value

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'connection

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
#End Region

#Region "SCM010200"
    Function SCM010200_Get_Awarded_Header()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select count(1) from Form_HWHdr [A] where [A].ConStatus not in ('Awarded', 'Cancelled', 'Declined') and YEAR([A].HWDate) = YEAR(GETDATE()) ), 0) [HouseConAward] ")
        Query.Append("  ,ISNULL((select COUNT(1) from oop_form_hdr [A] LEFT JOIN Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].status not in ('Accepted', 'Cancelled', 'Declined') and [B].ContractStatus not in ('Awarded', 'Cancelled', 'Declined') and [A].tbl_from = 'Form_CRT' and ISNULL([B].Subdivision, '') not in ('Rawland') and ISNULL([B].Subdivision, '') <> '' and YEAR([B].CreatedDate) = YEAR(GETDATE()) ), 0) [COFAward] ")
        Query.Append("  ,ISNULL((select count(1) from Form_HWHdr [A] where [A].ConStatus in ('Awarded') and YEAR([A].HWDate) = YEAR(GETDATE()) ), 0) [HouseConAwarded] ")
        Query.Append("  ,ISNULL((select COUNT(1) from oop_form_hdr [A] LEFT JOIN Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].status = 'Accepted' and [B].ContractStatus in ('Awarded') and [A].tbl_from = 'Form_CRT' and ISNULL([B].Subdivision, '') not in ('Rawland') and ISNULL([B].Subdivision, '') <> '' and YEAR([B].CreatedDate) = YEAR(GETDATE()) ), 0) [COFAwarded] ")
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
                        .HouseConAward = DR("HouseConAward"),
                        .COFAward = DR("COFAward"),
                        .HouseConAwarded = DR("HouseConAwarded"),
                        .COFAwarded = DR("COFAwarded")
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
    Function SCM010200_Get_Awarded_Record()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [D].DivCode ")
        Query.Append("  ,[D].ProvinceName ")
        Query.Append("  ,COUNT([D].DivCode) [Total] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].code ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [D] on [C].division = [D].DivCode ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].status in ('Accepted') ")
        Query.Append("  and [B].ContractStatus in ('Awarded') ")
        Query.Append("  and ISNULL([B].Subdivision, '') not in ('Rawland') ")
        Query.Append("  and ISNULL([B].Subdivision, '') <> '' ")
        Query.Append("  and ISNULL([D].ProvinceName, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [D].DivCode ")
        Query.Append("  ,[D].ProvinceName) [Tbl] ")
        Query.Append("order by ")
        Query.Append("  [Total] DESC ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .DivCode = DR("DivCode"),
                        .ProvName = DR("ProvinceName")
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
    Function SCM010200_Get_Awarded_Record_Repair(pDivCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  dbo.ProperCase([C].description) [Subdivision] ")
        Query.Append("  ,dbo.ProperCase([C].address) [Address] ")
        Query.Append("  ,[D].ProvinceName [ProvName] ")
        Query.Append("  ,[C].abbr ")
        Query.Append("  ,[B].Subdivision [SubdCode] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode left join SCM_TagContractors [TAG] on [HDR].f_code = [TAG].tag_code where [HDR].status in ('Accepted') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus in ('Awarded') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' and ISNULL([TAG].acct_status, '') = '' and [TAG].status = 0 ), 0) [SrtByTag] ")
        Query.Append("  ,ISNULL((select count(1) from oop_form_hdr [HDR] left join Form_CRT [CRT] on [HDR].tbl_code = [CRT].CRTCode where [HDR].status in ('Accepted') and [HDR].tbl_from = 'Form_CRT' and [CRT].Subdivision = [B].Subdivision and [CRT].ContractStatus in ('Awarded') AND ISNULL([CRT].Subdivision, '') <> 'Rawland' and ISNULL([CRT].Subdivision, '') <> '' ), 0) [TotalForms] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].code ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [D] on [C].division = [D].DivCode ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [A].status in ('Accepted') ")
        Query.Append("  and [D].DivCode = @pDivCode ")
        Query.Append("  and [B].ContractStatus in ('Awarded') ")
        Query.Append("  and ISNULL([B].Subdivision, '') not in ('Rawland') ")
        Query.Append("  and ISNULL([B].Subdivision, '') <> '' ")
        Query.Append("  and ISNULL([D].ProvinceName, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [C].description ")
        Query.Append("  ,[C].address ")
        Query.Append("  ,[D].ProvinceName ")
        Query.Append("  ,[B].Subdivision")
        Query.Append("  ,[C].abbr ")
        Query.Append("order by ")
        Query.Append("  [Subdivision], [SrtByTag] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pDivCode", pDivCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim BodyHTML As New StringBuilder

                    BodyHTML.Append("<div Class='col-md-6 col-xl-4'> ")
                    BodyHTML.Append("  <div class='card ribbon ribbon-top'> ")
                    BodyHTML.Append("      <div class='ribbon-label bg-primary'>" & DR("ProvName") & "</div> ")
                    BodyHTML.Append("      <div class='card-body d-flex flex-center flex-column p-9'> ")
                    BodyHTML.Append("      <div class='symbol symbol-65px mb-5'> ")
                    BodyHTML.Append("          <img src='Assets/media/svg/project/" & DR("abbr") & ".svg' alt='" & DR("abbr") & "' /> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='fs-4 text-gray-800 fw-bolder mb-0'>" & DR("Subdivision") & "</div> ")
                    BodyHTML.Append("      <div class='fw-bold text-gray-400 mb-6'>" & IIf(DR("Address") = "", "-", DR("Address")) & "</div> ")
                    BodyHTML.Append("      <div class='d-flex flex-center flex-wrap'> ")
                    BodyHTML.Append("          <div class='border border-dashed rounded min-w-125px py-3 px-4 mx-3 mb-3' style='text-align: center;'> ")
                    BodyHTML.Append("              <div class='fs-6 fw-bolder text-gray-700'>" & DR("TotalForms") & "</div> ")
                    BodyHTML.Append("              <div class='fw-bold text-gray-400'>Total Form</div> ")
                    BodyHTML.Append("          </div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='btn btn-sm btn-primary pointer' onclick=""fn01Table('" & DR("SubdCode") & "')""> ")
                    BodyHTML.Append("          <span class='svg-icon svg-icon-3'> ")
                    BodyHTML.Append("              <svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    BodyHTML.Append("                  <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'> ")
                    BodyHTML.Append("                      <rect x='0' y='0' width='24' height='24'/> ")
                    BodyHTML.Append("                      <path d='M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z' fill='currentColor' fill-rule='nonzero' opacity='0.3'/> ")
                    BodyHTML.Append("                      <path d='M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z' fill='currentColor' fill-rule='nonzero'/> ")
                    BodyHTML.Append("                  </g> ")
                    BodyHTML.Append("              </svg> ")
                    BodyHTML.Append("          </span>View Details</div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("  </div> ")
                    BodyHTML.Append("</div> ")

                    RecordList.Add(New With {
                        .Content = BodyHTML.ToString()
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
    Function SCM010200_Get_Record_Awarded(pSubdCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,(case [Type] ")
        Query.Append("         when 'Closed' then '<span class=""mt-3 badge badge-for-closed"">' + [Type] + '</span>'")
        Query.Append("         when 'Cancelled' then '<span class=""mt-3 badge badge-for-cancelled"">' + [Type] + '</span>'")
        Query.Append("         when 'New' then '<span class=""mt-3 badge badge-for-new"">' + [Type] + '</span>'")
        Query.Append("         when 'For Endorsement' then '<span class=""mt-3 badge badge-for-endorsement"">' + [Type] + '</span>'")
        Query.Append("         when 'For Approval' then '<span class=""mt-3 badge badge-for-approval"">' + [Type] + '</span>'")
        Query.Append("         when 'For Implementation' then '<span class=""mt-3 badge badge-for-implementation"">' + [Type] + '</span>'")
        Query.Append("         when 'For Clarification' then '<span class=""mt-3 badge badge-for-clarification"">' + [Type] + '</span>' end) [Type] ")
        Query.Append("   ,Format([DateCreated],'MM/dd/yyyy') [DateCreated] ")
        Query.Append("   ,Format([DateRequired],'MM/dd/yyyy') [DateRequired] ")
        Query.Append("   ,Format([DateExpected],'MM/dd/yyyy') [DateExpected] ")
        Query.Append("	 ,(case when [DateExpected] < cast(getdate() as date) then '<span class=""mt-3 badge badge-danger"">Delay</span>' ")
        Query.Append("         when [DateExpected] = cast(getdate() as date) then '<span class=""mt-3 badge badge-warning"">Due</span>' ")
        Query.Append("	       when [DateExpected] > cast(getdate() as date) then '<span class=""mt-3 badge badge-success"">Within</span>' end) [Status] ")
        Query.Append("   ,[RequestedByCode] ")
        Query.Append("   ,[RequestedByName] ")
        Query.Append("   ,[ConName] ")
        Query.Append("from ")
        Query.Append("   (select  ")
        Query.Append("      dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,(case [A].status when 'Accepted' then 'Closed' when 'Cancelled' then 'Cancelled' when 'Declined' then 'Cancelled' else (case [A].approver_type when 'Creator' then 'New' when 'Endorsed By' then 'For Endorsement' when 'Approved By' then 'For Approval' when 'Implementer' then 'For Implementation' when 'Clarification' then 'For Clarification' end) end) [Type] ")
        Query.Append("      ,[A].created_date [DateCreated] ")
        Query.Append("      ,[A].date_required [DateRequired] ")
        Query.Append("      ,isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateExpected] ")
        Query.Append("      ,[A].created_by [RequestedByCode] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) [RequestedByName] ")
        Query.Append("      ,dbo.ProperCase([E].vendor) [ConName] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
        Query.Append("	    left join Form_CRT [D] on [A].tbl_code = [D].CRTCode ")
        Query.Append("	    left join ogm_vendor [E] on [D].Contractor = [E].v_code ")
        Query.Append("   where ")
        Query.Append("      [A].status in ('Accepted') ")
        Query.Append("      and [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [D].ContractStatus in ('Awarded') ")
        Query.Append("      and [D].Subdivision = @pSubdCode) [A] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pSubdCode", pSubdCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim Requestor As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"

                    RecordList.Add(New With {
                        .Link = DR("Link"),
                        .Icon = DR("Icon"),
                        .ID = DR("ID"),
                        .Title = DR("Title"),
                        .Type = DR("Type"),
                        .DateCreated = DR("DateCreated"),
                        .DateRequired = DR("DateRequired"),
                        .DateExpected = DR("DateExpected"),
                        .Status = DR("Status"),
                        .RequestedByCode = DR("RequestedByCode"),
                        .RequestedByName = DR("RequestedByName"),
                        .Requestor = Requestor.ToString(),
                        .ConName = DR("ConName")
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
    Function SCM010200_Awarded_House_Construction()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].DivCode ")
        Query.Append("  ,[B].ProvinceName ")
        Query.Append("  ,COUNT([B].DivCode) [Total] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus in ('Awarded') ")
        Query.Append("  and ISNULL([B].DivCode, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [B].DivCode ")
        Query.Append("  ,[B].ProvinceName) [Tbl] ")
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
                        .DivCode = DR("DivCode"),
                        .ProvName = DR("ProvinceName")
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
    Function SCM010200_Awarded_House_Construction_Details(pDivCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [B].ProjName [Subdivision] ")
        Query.Append("  ,[B].Address [Address] ")
        Query.Append("  ,[B].ProvinceName [ProvName] ")
        Query.Append("  ,ISNULL((select count(1) from Form_HWHdr [HDR] where [HDR].ConStatus in ('Awarded') and [HDR].Subd = [A].Subd ), 0) [TotalRecord] ")
        Query.Append("  ,[A].Subd ")
        Query.Append("  ,[B].ProjInit ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus in ('Awarded') ")
        Query.Append("  and ISNULL([B].DivCode, '') = @pDivCode ")
        Query.Append("  and ISNULL([B].DivCode, '') <> '' ")
        Query.Append("group by ")
        Query.Append("  [A].Subd ")
        Query.Append("  ,[B].ProjName ")
        Query.Append("  ,[B].Address ")
        Query.Append("  ,[B].ProvinceName ")
        Query.Append("  ,[B].ProjInit) [Tbl] ")
        Query.Append("where ")
        Query.Append("  [TotalRecord] > 0 ")
        Query.Append("order by ")
        Query.Append("  [Subdivision] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pDivCode", pDivCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim BodyHTML As New StringBuilder

                    BodyHTML.Append("<div Class='col-md-6 col-xl-4'> ")
                    BodyHTML.Append("  <div class='card ribbon ribbon-top'> ")
                    BodyHTML.Append("      <div class='ribbon-label bg-primary'>" & DR("ProvName") & "</div> ")
                    BodyHTML.Append("      <div class='card-body d-flex flex-center flex-column p-9'> ")
                    BodyHTML.Append("      <div class='symbol symbol-65px mb-5'> ")
                    BodyHTML.Append("          <img src='Assets/media/svg/project/" & DR("ProjInit") & ".svg' alt='" & DR("ProjInit") & "' /> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='fs-4 text-gray-800 fw-bolder mb-0'>" & DR("Subdivision") & "</div> ")
                    BodyHTML.Append("      <div class='fw-bold text-gray-400 mb-6'>" & IIf(DR("Address") = "", "-", DR("Address")) & "</div> ")
                    BodyHTML.Append("      <div class='d-flex flex-center flex-wrap mb-5'> ")
                    BodyHTML.Append("          <div class='border border-dashed rounded min-w-125px py-3 px-4 mx-3 mb-3' style='text-align: center;'> ")
                    BodyHTML.Append("              <div class='fs-6 fw-bolder text-gray-700'>" & DR("TotalRecord") & "</div> ")
                    BodyHTML.Append("              <div class='fw-bold text-gray-400'>Total Record</div> ")
                    BodyHTML.Append("          </div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("      <div class='btn btn-sm btn-primary pointer' onclick=""fn02Table('" & DR("Subd") & "')""> ")
                    BodyHTML.Append("          <span class='svg-icon svg-icon-3'> ")
                    BodyHTML.Append("              <svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    BodyHTML.Append("                  <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'> ")
                    BodyHTML.Append("                      <rect x='0' y='0' width='24' height='24'/> ")
                    BodyHTML.Append("                      <path d='M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z' fill='currentColor' fill-rule='nonzero' opacity='0.3'/> ")
                    BodyHTML.Append("                      <path d='M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z' fill='currentColor' fill-rule='nonzero'/> ")
                    BodyHTML.Append("                  </g> ")
                    BodyHTML.Append("              </svg> ")
                    BodyHTML.Append("          </span>View Details</div> ")
                    BodyHTML.Append("      </div> ")
                    BodyHTML.Append("  </div> ")
                    BodyHTML.Append("</div> ")


                    RecordList.Add(New With {
                        .Content = BodyHTML.ToString()
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
    Function SCM010200_Get_Record_Awarded_House_Construction(pSubdCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status [Status] ")
        Query.Append("  ,'SCM000007-' + [A].HWCode [Link] ")
        Query.Append("  ,'assets/media/svg/apps/CNS.svg' [Icon] ")
        Query.Append("  ,'CON - ' + [A].Type + ' / ' + [C].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [D].ModelName + ') '  [Title] ")
        Query.Append("  ,[A].HWCode [ID] ")
        Query.Append("  ,[A].CreatedBy [RequestedByCode] ")
        Query.Append("  ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("  ,IIf(Year([A].CreatedDate) < Year(GETDATE()), Format([A].CreatedDate, 'MMM d, yyyy'), IIf(Day([A].CreatedDate) < Day(GETDATE()), Format([A].CreatedDate, 'MMM d'), Format([A].CreatedDate, 'hh:mm tt'))) [Date]  ")
        Query.Append("  ,dbo.ProperCase([E].vendor) [ConName] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("  left join ogm_vendor [E] on [A].Contractor = [E].v_code ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus in ('Awarded') ")
        Query.Append("  and ISNULL([C].DivCode, '') <> '' ")
        Query.Append("  and [A].Subd = @pSubdCode ")
        Query.Append("order by ")
        Query.Append("  [Date] ")
        'get query

        'list
        Dim RecordList As New List(Of Object)()
        'list

        'connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pSubdCode", pSubdCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim CreatedBy As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("Name") & "</div>"

                    RecordList.Add(New With {
                        .Link = DR("Link"),
                        .Icon = DR("Icon"),
                        .ID = DR("ID"),
                        .Title = DR("Title"),
                        .CreatedBy = CreatedBy.ToString(),
                        .ConName = DR("ConName")
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
    Private Function SCM010200_Get_Form_List(Subd As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Link] ")
        Query.Append("  ,[Icon] ")
        Query.Append("  ,[Title] ")
        Query.Append("  ,[ID] ")
        Query.Append("  ,[Name] ")
        Query.Append("  ,[Date] ")
        Query.Append("  ,[TCPCondition] ")
        Query.Append("  ,[TCPBal] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      [A].status [Status] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,IIf(Year([A].created_date) < Year(GETDATE()), Format([A].created_date, 'MMM d, yyyy'), IIf(Day([A].created_date) < Day(GETDATE()), Format([A].created_date, 'MMM d'), Format([A].created_date, 'hh:mm tt'))) [Date] ")
        Query.Append("      ,(case when [C].TCPBal != 0.00 then '' else 'd-none' end) [TCPCondition] ")
        Query.Append("      ,Format([C].TCPBal, 'N2') [TCPBal] ")
        Query.Append("  from ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("      left join Form_CRT [C] on [A].tbl_code = [C].CRTCode ")
        Query.Append("  where ")
        Query.Append("      [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [C].ContractStatus = 'Awarded' ")
        Query.Append("      and [C].Subdivision = '" & Subd & "') [TBL] ")
        Query.Append("order by ")
        Query.Append("  [Date] ")
        'get query

        'variable
        Dim FormDetails As New List(Of Object)()
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

                    Dim Link As String = "SCM000006-" + DR("ID")
                    Dim Data As New StringBuilder
                    Data.Append("<a href='" & Link & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    Dim Tag As New StringBuilder
                    Tag.Append("<div class='d-flex justify-content-end me-5'> ")
                    Tag.Append("    <div class='card-toolbar me-3 " & DR("TCPCondition") & "'> ")
                    Tag.Append("        <span class='d-flex justify-content-center w-100px badge badge-warning fs-7 me-3' data-bs-toggle='tooltip' title='Remaining Balance'>₱ " & DR("TCPBal") & "</span> ")
                    Tag.Append("    </div> ")
                    Tag.Append("</div> ")
                    FormDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString,
                        .Tag = Tag.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(FormDetails))
        'display 

    End Function

    Private Function SCM010200_Get_Batch_List(Subd As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status [Status] ")
        Query.Append("  ,'SCM000007-' + [A].HWCode [Link] ")
        Query.Append("  ,'assets/media/svg/apps/CNS.svg' [Icon] ")
        Query.Append("  ,'CON - ' + [A].Type + ' / ' + [C].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [D].ModelName + ') '  [Title] ")
        Query.Append("  ,[A].HWCode [ID] ")
        Query.Append("  ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("  ,IIf(Year([A].CreatedDate) < Year(GETDATE()), Format([A].CreatedDate, 'MMM d, yyyy'), IIf(Day([A].CreatedDate) < Day(GETDATE()), Format([A].CreatedDate, 'MMM d'), Format([A].CreatedDate, 'hh:mm tt'))) [Date]  ")
        Query.Append("  ,(case when [A].TCPBal != 0.00 then '' else 'd-none' end) [TCPCondition] ")
        Query.Append("  ,Format([A].TCPBal, 'N2') [TCPBal] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Awarded' ")
        Query.Append("  and [A].Subd = '" & Subd & "' ")
        Query.Append("order by ")
        Query.Append("  [Date] ")
        'get query

        'variable
        Dim BatchDetails As New List(Of Object)()
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
                    Data.Append("<a href='" & DR("Link") & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    Dim Tag As New StringBuilder
                    Tag.Append("<div class='d-flex justify-content-end me-5'> ")
                    Tag.Append("    <div class='card-toolbar me-3 " & DR("TCPCondition") & "'> ")
                    Tag.Append("        <span class='d-flex justify-content-center w-100px badge badge-warning fs-7 me-3' data-bs-toggle='tooltip' title='Remaining Balance'>₱ " & DR("TCPBal") & "</span> ")
                    Tag.Append("    </div> ")
                    Tag.Append("</div> ")

                    BatchDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString,
                        .Tag = Tag.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(BatchDetails))
        'display 

    End Function

#End Region

#Region "SCM010300"
    Private Function SCM010300_Get_Form_List(Subd As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Link] ")
        Query.Append("  ,[Icon] ")
        Query.Append("  ,[Title] ")
        Query.Append("  ,[ID] ")
        Query.Append("  ,[Name] ")
        Query.Append("  ,[Date] ")
        Query.Append("  ,[TCPCondition] ")
        Query.Append("  ,[TCPBal] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      [A].status [Status] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,IIf(Year([A].created_date) < Year(GETDATE()), Format([A].created_date, 'MMM d, yyyy'), IIf(Day([A].created_date) < Day(GETDATE()), Format([A].created_date, 'MMM d'), Format([A].created_date, 'hh:mm tt'))) [Date] ")
        Query.Append("      ,(case when [C].TCPBal != 0.00 then '' else 'd-none' end) [TCPCondition] ")
        Query.Append("      ,Format([C].TCPBal, 'N2') [TCPBal] ")
        Query.Append("  from ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("      left join Form_CRT [C] on [A].tbl_code = [C].CRTCode ")
        Query.Append("  where ")
        Query.Append("      [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [C].ContractStatus = 'Awarded' ")
        Query.Append("      and [C].POCRate >= 95.00 ")
        Query.Append("      and [C].Subdivision = '" & Subd & "') [TBL] ")
        Query.Append("order by ")
        Query.Append("  [Date] ")
        'get query

        'variable
        Dim FormDetails As New List(Of Object)()
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

                    Dim Link As String = "SCM000006-" + DR("ID")
                    Dim Data As New StringBuilder
                    Data.Append("<a href='" & Link & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    Dim Tag As New StringBuilder
                    Tag.Append("<div class='d-flex justify-content-end me-5'> ")
                    Tag.Append("    <div class='card-toolbar me-3 " & DR("TCPCondition") & "'> ")
                    Tag.Append("        <span class='d-flex justify-content-center w-100px badge badge-warning fs-7 me-3' data-bs-toggle='tooltip' title='Remaining Balance'>₱ " & DR("TCPBal") & "</span> ")
                    Tag.Append("    </div> ")
                    Tag.Append("</div> ")
                    FormDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString,
                        .Tag = Tag.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(FormDetails))
        'display 

    End Function

    Private Function SCM010300_Get_Batch_List(Subd As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status [Status] ")
        Query.Append("  ,'SCM000007-' + [A].HWCode [Link] ")
        Query.Append("  ,'assets/media/svg/apps/CNS.svg' [Icon] ")
        Query.Append("  ,'CON - ' + [A].Type + ' / ' + [C].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [D].ModelName + ') '  [Title] ")
        Query.Append("  ,[A].HWCode [ID] ")
        Query.Append("  ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("  ,IIf(Year([A].CreatedDate) < Year(GETDATE()), Format([A].CreatedDate, 'MMM d, yyyy'), IIf(Day([A].CreatedDate) < Day(GETDATE()), Format([A].CreatedDate, 'MMM d'), Format([A].CreatedDate, 'hh:mm tt'))) [Date]  ")
        Query.Append("  ,(case when [A].TCPBal != 0.00 then '' else 'd-none' end) [TCPCondition] ")
        Query.Append("  ,Format([A].TCPBal, 'N2') [TCPBal] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Awarded' ")
        Query.Append("  [A].POCRate >= 95.00 ")
        Query.Append("  and [A].Subd = '" & Subd & "' ")
        Query.Append("order by ")
        Query.Append("  [Date] ")
        'get query

        'variable
        Dim BatchDetails As New List(Of Object)()
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
                    Data.Append("<a href='" & DR("Link") & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    Dim Tag As New StringBuilder
                    Tag.Append("<div class='d-flex justify-content-end me-5'> ")
                    Tag.Append("    <div class='card-toolbar me-3 " & DR("TCPCondition") & "'> ")
                    Tag.Append("        <span class='d-flex justify-content-center w-100px badge badge-warning fs-7 me-3' data-bs-toggle='tooltip' title='Remaining Balance'>₱ " & DR("TCPBal") & "</span> ")
                    Tag.Append("    </div> ")
                    Tag.Append("</div> ")

                    BatchDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString,
                        .Tag = Tag.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(BatchDetails))
        'display 

    End Function
#End Region

#Region "SCM010400"
    Private Function SCM010400_Get_Form_List(Subd As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Link] ")
        Query.Append("  ,[Icon] ")
        Query.Append("  ,[Title] ")
        Query.Append("  ,[ID] ")
        Query.Append("  ,[Name] ")
        Query.Append("  ,[Date] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      [A].status [Status] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,IIf(Year([A].created_date) < Year(GETDATE()), Format([A].created_date, 'MMM d, yyyy'), IIf(Day([A].created_date) < Day(GETDATE()), Format([A].created_date, 'MMM d'), Format([A].created_date, 'hh:mm tt'))) [Date] ")
        Query.Append("  from ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("      left join Form_CRT [C] on [A].tbl_code = [C].CRTCode ")
        Query.Append("  where ")
        Query.Append("      [A].tbl_from = 'Form_CRT' ")
        Query.Append("      and [C].ContractStatus = 'Cancelled' ")
        Query.Append("      and [C].Subdivision = '" & Subd & "') [TBL] ")
        Query.Append("order by ")
        Query.Append("  [Date] ")
        'get query

        'variable
        Dim FormDetails As New List(Of Object)()
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

                    Dim Link As String = "SCM000006-" + DR("ID")
                    Dim Data As New StringBuilder
                    Data.Append("<a href='" & Link & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")
                    FormDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(FormDetails))
        'display 

    End Function

    Private Function SCM010400_Get_Batch_List(Subd As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].status [Status] ")
        Query.Append("  ,'SCM000007-' + [A].HWCode [Link] ")
        Query.Append("  ,'assets/media/svg/apps/CNS.svg' [Icon] ")
        Query.Append("  ,'CON - ' + [A].Type + ' / ' + [C].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [D].ModelName + ') '  [Title] ")
        Query.Append("  ,[A].HWCode [ID] ")
        Query.Append("  ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("  ,IIf(Year([A].CreatedDate) < Year(GETDATE()), Format([A].CreatedDate, 'MMM d, yyyy'), IIf(Day([A].CreatedDate) < Day(GETDATE()), Format([A].CreatedDate, 'MMM d'), Format([A].CreatedDate, 'hh:mm tt'))) [Date]  ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [C] on [A].Subd = [C].ProjCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Cancelled' ")
        Query.Append("  and [A].Subd = '" & Subd & "' ")
        Query.Append("order by ")
        Query.Append("  [Date] ")
        'get query

        'variable
        Dim BatchDetails As New List(Of Object)()
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
                    Data.Append("<a href='" & DR("Link") & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("Title") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("ID") & " | " & DR("Name") & " | " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    BatchDetails.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display FormDetails
        Return (New JavaScriptSerializer().Serialize(BatchDetails))
        'display 

    End Function
#End Region

#Region "SCM020000"

    Function SCM020000_Get_Verification(Code)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [Code] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Name] ")
        Query.Append("  ,type [Type] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,tel_no [TelNo] ")
        Query.Append("  ,mobile_no [MobileNo] ")
        Query.Append("  ,fax_no [FaxNo] ")
        Query.Append("  ,tin_no [TinNo] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,contact_person [ContactPerson] ")
        Query.Append("  ,acct_progress [AcctStatus] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("where ")
        Query.Append("  contractor_id = '" & Code & "' ")
        Query.Append("  and acct_progress = 'For Verification' ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                        .Code = DR("Code"),
                        .Name = DR("Name"),
                        .Type = DR("Type"),
                        .Address = DR("Address"),
                        .TelNo = DR("TelNo"),
                        .MobileNo = DR("MobileNo"),
                        .FaxNo = DR("FaxNo"),
                        .TinNo = DR("TinNo"),
                        .Email = DR("Email"),
                        .ContactPerson = DR("ContactPerson"),
                        .AcctStatus = DR("AcctStatus")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function SCM020000_Get_Details_Approval(Code)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [Code] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Name] ")
        Query.Append("  ,type [Type] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,tel_no [TelNo] ")
        Query.Append("  ,mobile_no [MobileNo] ")
        Query.Append("  ,fax_no [FaxNo] ")
        Query.Append("  ,tin_no [TinNo] ")
        Query.Append("  ,dbo.ProperCase(contact_person) [ContactPerson] ")
        Query.Append("  ,Email [Email] ")
        Query.Append("  ,acct_progress [AcctStatus] ")
        Query.Append("  ,[B].vat [VAT] ")
        Query.Append("  ,[C].description [EWT] ")
        Query.Append("  ,[D].description [CreditTerms] ")
        Query.Append("  ,[A].bank_name [BankName] ")
        Query.Append("  ,[A].bank_acctno [AcctNo] ")
        Query.Append("  ,[A].bank_acctname [AcctName] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor [A] ")
        Query.Append("  left join fin_vat [B] on [A].vat = [B].v_code ")
        Query.Append("  left join fin_ewt [C] on [A].ewt = [C].ewt_code ")
        Query.Append("  left join ogm_credit_terms [D] on [A].credit_terms = [D].ct_code ")
        Query.Append("where ")
        Query.Append("  contractor_id = '" & Code & "' ")
        Query.Append("  and acct_progress = 'For Approval' ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                        .Code = DR("Code"),
                        .Name = DR("Name"),
                        .Type = DR("Type"),
                        .Address = DR("Address"),
                        .TelNo = DR("TelNo"),
                        .MobileNo = DR("MobileNo"),
                        .FaxNo = DR("FaxNo"),
                        .TinNo = DR("TinNo"),
                        .ContactPerson = DR("ContactPerson"),
                        .Email = DR("Email"),
                        .AcctStatus = DR("AcctStatus"),
                        .VAT = DR("VAT"),
                        .EWT = DR("EWT"),
                        .CreditTerms = DR("CreditTerms"),
                        .BankName = DR("BankName"),
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function SCM020000_Get_Details_Approved(Code)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [Code] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Name] ")
        Query.Append("  ,type [Type] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,tel_no [TelNo] ")
        Query.Append("  ,mobile_no [MobileNo] ")
        Query.Append("  ,fax_no [FaxNo] ")
        Query.Append("  ,tin_no [TinNo] ")
        Query.Append("  ,dbo.ProperCase(contact_person) [ContactPerson] ")
        Query.Append("  ,Email [Email] ")
        Query.Append("  ,acct_progress [AcctStatus] ")
        Query.Append("  ,[B].vat [VAT] ")
        Query.Append("  ,[C].description [EWT] ")
        Query.Append("  ,[D].description [CreditTerms] ")
        Query.Append("  ,[A].bank_name [BankName] ")
        Query.Append("  ,[A].bank_acctno [AcctNo] ")
        Query.Append("  ,[A].bank_acctname [AcctName] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor [A] ")
        Query.Append("  left join fin_vat [B] on [A].vat = [B].v_code ")
        Query.Append("  left join fin_ewt [C] on [A].ewt = [C].ewt_code ")
        Query.Append("  left join ogm_credit_terms [D] on [A].credit_terms = [D].ct_code ")
        Query.Append("where ")
        Query.Append("  contractor_id = '" & Code & "' ")
        Query.Append("  and acct_progress = 'Approved' ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormList.Add(New With {
                        .Code = DR("Code"),
                        .Name = DR("Name"),
                        .Type = DR("Type"),
                        .Address = DR("Address"),
                        .TelNo = DR("TelNo"),
                        .MobileNo = DR("MobileNo"),
                        .FaxNo = DR("FaxNo"),
                        .TinNo = DR("TinNo"),
                        .ContactPerson = DR("ContactPerson"),
                        .Email = DR("Email"),
                        .AcctStatus = DR("AcctStatus"),
                        .VAT = DR("VAT"),
                        .EWT = DR("EWT"),
                        .CreditTerms = DR("CreditTerms"),
                        .BankName = DR("BankName"),
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Private Function SCM020000_Get_Record_Approval()

        'get approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [ID] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Contractor] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,acct_progress [AcctProgress] ")
        Query.Append("  ,Format(created_date, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,acct_type [AcctType] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("where ")
        Query.Append("  status = 0 ")
        Query.Append("  and acct_progress  = 'For Approval' ")
        'get approval

        'variable
        Dim FormList As New List(Of Object)()
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
                    Action.Append("     <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('SCM020100-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    FormList.Add(New With {
                        .Code = DR("ID"),
                        .Action = Action.ToString,
                        .Contractor = DR("Contractor"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .AcctProgress = DR("AcctProgress"),
                        .CreatedDate = DR("CreatedDate"),
                        .Type = DR("AcctType")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function SCM020000_Get_Record_Verification()

        'get approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [ID] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Contractor] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,acct_progress [AcctProgress] ")
        Query.Append("  ,Format(created_date, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,acct_type [AcctType] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("where ")
        Query.Append("  status = 0 ")
        Query.Append("  and acct_progress in ('For Verification', 'For Approval') ")
        'get approval

        'variable
        Dim FormList As New List(Of Object)()
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
                    Action.Append("     <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('SCM020100-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    FormList.Add(New With {
                        .Code = DR("ID"),
                        .Action = Action.ToString,
                        .Contractor = DR("Contractor"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .AcctProgress = DR("AcctProgress"),
                        .CreatedDate = DR("CreatedDate"),
                        .Type = DR("AcctType")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 
    End Function
    Private Function SCM020000_Get_Details(Num As Integer)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [ID] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Contractor] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,acct_progress [AcctProgress] ")
        Query.Append("  ,Format(created_date, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,acct_type [AcctType] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("where ")
        Query.Append("  YEAR(created_date) = YEAR(GETDATE()) ")
        Query.Append("  AND MONTH(created_date) = '" & Num & "' ")
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    If DR("AcctProgress") = "For Verification" Or DR("AcctProgress") = "For Approval" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('SCM020100-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    ElseIf DR("AcctProgress") = "For Resubmission" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-warning' title='View' onclick=""window.open('SCM020200-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    ElseIf DR("AcctProgress") = "Approved" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-success' title='View' onclick=""window.open('SCM020300-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    ElseIf DR("AcctProgress") = "Cancelled" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-danger' title='View' onclick=""window.open('SCM020400-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    End If
                    Action.Append("</div>")

                    FormList.Add(New With {
                        .Code = DR("ID"),
                        .Action = Action.ToString,
                        .Contractor = DR("Contractor"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .AcctProgress = DR("AcctProgress"),
                        .CreatedDate = DR("CreatedDate"),
                        .Type = DR("AcctType")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function SCM020000_Get_Record_Resubmission()

        'get approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [ID] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Contractor] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,acct_progress [AcctProgress] ")
        Query.Append("  ,Format(created_date, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,acct_type [AcctType] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("where ")
        Query.Append("  status = 1 ")
        Query.Append("  and acct_progress in ('For Resubmission') ")
        'get approval

        'variable
        Dim FormList As New List(Of Object)()
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
                    Action.Append("     <button class='btn btn-sm btn-icon btn-warning' title='View' onclick=""window.open('SCM020200-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    FormList.Add(New With {
                        .Code = DR("ID"),
                        .Action = Action.ToString,
                        .Contractor = DR("Contractor"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .AcctProgress = DR("AcctProgress"),
                        .CreatedDate = DR("CreatedDate"),
                        .Type = DR("AcctType")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function SCM020000_Get_Record_Approved()

        'get approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [ID] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Contractor] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,acct_progress [AcctProgress] ")
        Query.Append("  ,Format(created_date, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,acct_type [AcctType] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("where ")
        Query.Append("  status = 1 ")
        Query.Append("  and acct_progress in ('Approved') ")
        'get approval

        'variable
        Dim FormList As New List(Of Object)()
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
                    Action.Append("     <button class='btn btn-sm btn-icon btn-success' title='View' onclick=""window.open('SCM020300-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    FormList.Add(New With {
                        .Code = DR("ID"),
                        .Action = Action.ToString,
                        .Contractor = DR("Contractor"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .AcctProgress = DR("AcctProgress"),
                        .CreatedDate = DR("CreatedDate"),
                        .Type = DR("AcctType")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function SCM020000_Get_Record_Declined()

        'get approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [ID] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Contractor] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,acct_progress [AcctProgress] ")
        Query.Append("  ,Format(created_date, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,acct_type [AcctType] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("where ")
        Query.Append("  status = 2 ")
        Query.Append("  and acct_progress in ('Declined') ")
        'get approval

        'variable
        Dim FormList As New List(Of Object)()
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
                    Action.Append("     <button class='btn btn-sm btn-icon btn-danger' title='View' onclick=""window.open('SCM020300-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    FormList.Add(New With {
                        .Code = DR("ID"),
                        .Action = Action.ToString,
                        .Contractor = DR("Contractor"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .AcctProgress = DR("AcctProgress"),
                        .CreatedDate = DR("CreatedDate"),
                        .Type = DR("AcctType")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function SCM020000_Get_Record_Contractor()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  contractor_id [ID] ")
        Query.Append("  ,dbo.ProperCase(contractor) [Contractor] ")
        Query.Append("  ,email [Email] ")
        Query.Append("  ,address [Address] ")
        Query.Append("  ,acct_progress [AcctProgress] ")
        Query.Append("  ,Format(created_date, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,created_date ")
        Query.Append("  ,acct_type [AcctType] ")
        Query.Append("from ")
        Query.Append("  SCM_Contractor ")
        Query.Append("order by ")
        Query.Append("  created_date desc ")
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    If DR("AcctProgress") = "For Verification" Or DR("AcctProgress") = "For Approval" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-view' title='Approval/Verification' onclick=""window.open('SCM020100-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    ElseIf DR("AcctProgress") = "For Resubmission" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-warning' title='Resubmission' onclick=""window.open('SCM020200-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    ElseIf DR("AcctProgress") = "Approved" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-success' title='Approved' onclick=""window.open('SCM020300-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    ElseIf DR("AcctProgress") = "Declined" Then
                        Action.Append("     <button class='btn btn-sm btn-icon btn-danger' title='Declined' onclick=""window.open('SCM020400-DTL-" & DR("ID") & "'); fn01DisableToggle(); return false;""><i class='las la-search fs-3'></i></button>")
                    End If
                    Action.Append("</div>")

                    FormList.Add(New With {
                        .Code = DR("ID"),
                        .Action = Action.ToString,
                        .Contractor = DR("Contractor"),
                        .Email = DR("Email"),
                        .Address = DR("Address"),
                        .AcctProgress = DR("AcctProgress"),
                        .CreatedDate = DR("CreatedDate"),
                        .Type = DR("AcctType")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
#End Region

#Region "SCM040101"
    Function SCM040101_Get_Item_Upd_List(Find As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [ItemCode] ")
        Query.Append("  ,[Lock] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[UMCode] ")
        Query.Append("  ,[UMName] ")
        Query.Append("  ,[Cost] ")
        Query.Append("  ,[Canvass] ")
        Query.Append("  ,[UpdateDate] ")
        Query.Append("  ,[VenName] ")
        Query.Append("  ,[LockedBy] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("from ")
        Query.Append("  (select distinct ")
        Query.Append("  [A].item [ItemCode] ")
        Query.Append("  ,isnull([B].Lock,0) [Lock] ")
        Query.Append("  ,[B].item [ItemName] ")
        Query.Append("  ,isnull([A].unit, '') [UMCode] ")
        Query.Append("  ,isnull([C].abbr, '') [UMName] ")
        Query.Append("  ,[A].unit_cost [Cost] ")
        Query.Append("  ,isnull([A].Canvass,0) [Canvass] ")
        Query.Append("  ,[D].po_date [UpdateDate] ")
        Query.Append("  ,[E].vendor [VenName] ")
        Query.Append("  ,[A].seq_no [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([F].first_name) + ' ' + dbo.ProperCase([F].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A]  ")
        Query.Append("  left join ogm_item [B] on [A].item = [B].i_code ")
        Query.Append("  left join sys_um [C] on [A].unit = [C].u_code ")
        Query.Append("  left join ogm_po_hdr [D] on [A].po_code = [d].po_code ")
        Query.Append("  left join ogm_vendor [E] on [D].vendor = [E].v_code ")
        Query.Append("  left join employee [F] on [B].locked_by = [F].emp_no ")
        Query.Append("where ")
        Query.Append("  [D].post = 1 ")
        Query.Append("  and [D].Rvrs = 0 ")
        Query.Append("  and [A].item != '' ")
        Query.Append("  and [A].unit_cost > 0 ")
        Query.Append("  and [A].unit != '' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  [A].i_code [ItemCode] ")
        Query.Append("  ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,[A].Item [ItemName] ")
        Query.Append("  ,isnull([B].u_code, '') [UMCode] ")
        Query.Append("  ,isnull([B].abbr, '') [UMName] ")
        Query.Append("  ,0 [Cost] ")
        Query.Append("  ,0 [Canvass] ")
        Query.Append("  ,'' [UpdateDate] ")
        Query.Append("  ,'' [VenName] ")
        Query.Append("  ,0 [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_item [A] ")
        Query.Append("  left join sys_um [B] on [A].um = [B].u_code ")
        Query.Append("  left join employee [C] on [A].locked_by = [C].emp_no ) [TBL]")
        Query.Append("where ")
        Query.Append("  ([ItemName] like '%" & Find & "%' ")
        Query.Append("  or [UMName] like '%" & Find & "%' ")
        Query.Append("  or [VenName] like '%" & Find & "%') ")
        Query.Append("order by ")
        Query.Append("  [ItemName] ")
        Query.Append("  ,[UpdateDate] ")
        'get query

        'variable
        Dim ItemDetails As New List(Of Object)()
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
                    Data.Append("<div data-itemcode='" & DR("ItemCode") & "' data-seqno='" & DR("SeqNo") & "' data-updatedate='" & DR("UpdateDate") & "' class='d-flex align-items-center w-100 pointer' onclick='SelectUpdItem(this);'>")
                    Data.Append("   <div Class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("ItemName") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("ItemCode") & " " & DR("UMName") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex justify-content-end'>")
                    Data.Append("       <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>Locked By</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("LockedBy") & "</span>")
                    Data.Append("       </div>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    ItemDetails.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(ItemDetails))
        'display 

    End Function

    Function SCM040101_Get_Item_Upd_Info(SeqNo As String, ItemCode As String, UpdateDate As Date)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [ItemCode] ")
        Query.Append("  ,[Lock] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[UMCode] ")
        Query.Append("  ,[UMName] ")
        Query.Append("  ,[Cost] ")
        Query.Append("  ,[Canvass] ")
        Query.Append("  ,[UpdateDate] ")
        Query.Append("  ,[VenName] ")
        Query.Append("  ,[LockedBy] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("from ")
        Query.Append("  (select distinct ")
        Query.Append("  [A].item [ItemCode] ")
        Query.Append("  ,isnull([B].Lock,0) [Lock] ")
        Query.Append("  ,[B].item [ItemName] ")
        Query.Append("  ,isnull([A].unit, '') [UMCode] ")
        Query.Append("  ,isnull([C].abbr, '') [UMName] ")
        Query.Append("  ,[A].unit_cost [Cost] ")
        Query.Append("  ,isnull([A].Canvass,0) [Canvass] ")
        Query.Append("  ,[D].po_date [UpdateDate] ")
        Query.Append("  ,[E].vendor [VenName] ")
        Query.Append("  ,[A].seq_no [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([F].first_name) + ' ' + dbo.ProperCase([F].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A]  ")
        Query.Append("  left join ogm_item [B] on [A].item = [B].i_code ")
        Query.Append("  left join sys_um [C] on [A].unit = [C].u_code ")
        Query.Append("  left join ogm_po_hdr [D] on [A].po_code = [d].po_code ")
        Query.Append("  left join ogm_vendor [E] on [D].vendor = [E].v_code ")
        Query.Append("  left join employee [F] on [B].locked_by = [F].emp_no ")
        Query.Append("where ")
        Query.Append("  [D].post = 1 ")
        Query.Append("  and [D].Rvrs = 0 ")
        Query.Append("  and [A].item != '' ")
        Query.Append("  and [A].unit_cost > 0 ")
        Query.Append("  and [A].unit != '' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  [A].i_code [ItemCode] ")
        Query.Append("  ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,[A].Item [ItemName] ")
        Query.Append("  ,isnull([B].u_code, '') [UMCode] ")
        Query.Append("  ,isnull([B].abbr, '') [UMName] ")
        Query.Append("  ,0 [Cost] ")
        Query.Append("  ,0 [Canvass] ")
        Query.Append("  ,'' [UpdateDate] ")
        Query.Append("  ,'' [VenName] ")
        Query.Append("  ,0 [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_item [A] ")
        Query.Append("  left join sys_um [B] on [A].um = [B].u_code ")
        Query.Append("  left join employee [C] on [A].locked_by = [C].emp_no ) [TBL]")
        Query.Append("where ")
        Query.Append("  [SeqNo] = '" & SeqNo & "' ")
        Query.Append("  and [ItemCode] = '" & ItemCode & "' ")
        Query.Append("  and [UpdateDate] = '" & UpdateDate & "' ")
        Query.Append("order by ")
        Query.Append("  [ItemName] ")
        Query.Append("  ,[UpdateDate] ")
        'get query

        'variable
        Dim ItemInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    ItemInfo.Add(New With {
                        .SeqNo = DR("SeqNo"),
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ItemInfo))
        'display 

    End Function

    Function SCM040101_Get_Record_List(Find As String, Post As Integer)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'SCM040101-DTL-' + ogm_po_hdr.po_code [Link] ")
        Query.Append("  ,ogm_po_hdr.po_code [POCode] ")
        Query.Append("  ,ogm_po_hdr.po_no [PONo] ")
        Query.Append("  ,ogm_po_hdr.po_date [PODate] ")
        Query.Append("  ,isnull(ogm_vendor.vendor, '') [VenName] ")
        Query.Append("  ,ogm_po_hdr.deliver_addr [DeliverTo] ")
        Query.Append("  ,isnull(ogm_po_hdr.Status,'''') [Status] ")
        Query.Append("  ,ogm_po_hdr.lock [Lock] ")
        Query.Append("  ,ogm_po_hdr.post [Post] ")
        Query.Append("  ,ogm_po_hdr.Rvrs ")
        Query.Append("  ,'Assets/media/svg/apps/SCM040100.svg' [Icon] ")
        Query.Append("  ,employee.initialname [UpdatedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_po_hdr ")
        Query.Append("  left join ogm_vendor on ogm_po_hdr.vendor = ogm_vendor.v_code ")
        Query.Append("  left join ogm_warehouse on ogm_po_hdr.warehouse = ogm_warehouse.w_code ")
        Query.Append("  left join employee on ogm_po_hdr.updated_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  ogm_po_hdr.Post = " & Post & " ")

        If Find <> "" Then
            Query.Append("  AND ogm_vendor.vendor LIKE '%" & Find & "%' ")
        End If

        If Post = 0 Then
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("  'SCM040101-DTL-' + ogm_po_hdr.po_code [Link] ")
            Query.Append("  ,ogm_po_hdr.po_code [POCode] ")
            Query.Append("  ,ogm_po_hdr.po_no [PONo] ")
            Query.Append("  ,ogm_po_hdr.po_date [PODate] ")
            Query.Append("  ,isnull(ogm_vendor.vendor, '') [VenName] ")
            Query.Append("  ,ogm_po_hdr.deliver_addr [DeliverTo] ")
            Query.Append("  ,isnull(ogm_po_hdr.Status,'''') [Status] ")
            Query.Append("  ,ogm_po_hdr.lock [Lock] ")
            Query.Append("  ,ogm_po_hdr.post [Post] ")
            Query.Append("  ,ogm_po_hdr.Rvrs ")
            Query.Append("  ,'Assets/media/svg/apps/SCM040100.svg' [Icon] ")
            Query.Append("  ,employee.initialname [UpdatedBy] ")
            Query.Append("from ")
            Query.Append("  ogm_po_hdr ")
            Query.Append("  left join ogm_vendor on ogm_po_hdr.vendor = ogm_vendor.v_code ")
            Query.Append("  left join ogm_warehouse on ogm_po_hdr.warehouse = ogm_warehouse.w_code ")
            Query.Append("  left join employee on ogm_po_hdr.updated_by = employee.emp_no ")
            Query.Append("where ")
            Query.Append("  ogm_po_hdr.Post = 1  ")
            Query.Append("  and ogm_po_hdr.status in ('for Cancellation','for Clarification','for Printing','for Re-Open','for Re-Posting') ")
            Query.Append("order by ")
            Query.Append("  [Status] ")
        End If
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
                    Dim Bullet As New StringBuilder
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href='" & DR("Link") & "' class='d-flex align-items-center'>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    Data.Append("       <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column'>")
                    Data.Append("       <span class='text-dark fw-bolder fs-7'>" & DR("VenName") & "</span>")
                    Data.Append("       <span class='text-muted fw-bold text-muted d-block fs-8'>" & DR("PONo") & " | " & DR("PODate") & " | " & DR("UpdatedBy") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")
                    Dim Dtl As New StringBuilder
                    Dtl.Append("<div class='d-flex justify-content-end'>")

                    Dtl.Append("   <div class='form-check form-check-custom form-check-solid form-check-sm me-5'>")
                    If DR("Lock") = 1 Then
                        Dtl.Append("<input class='form-check-input disable-check' type='checkbox' value='' checked='checked' onclick='return false;' />")
                    Else
                        Dtl.Append("<input class='form-check-input disable-check' type='checkbox' value='' onclick='return false;' />")
                    End If
                    Dtl.Append("   </div>")

                    Dtl.Append("   <div class='form-check form-check-custom form-check-solid form-check-sm me-5'>")
                    If DR("Post") = 1 Then
                        Dtl.Append("<input class='form-check-input disable-check' type='checkbox' value='' checked='checked' onclick='return false;' />")
                    Else
                        Dtl.Append("<input class='form-check-input disable-check' type='checkbox' value='' onclick='return false;' />")
                    End If
                    Dtl.Append("   </div>")

                    Dtl.Append("   <div class='form-check form-check-custom form-check-solid form-check-sm me-8'>")
                    If DR("Rvrs") = 1 Then
                        Dtl.Append("<input class='form-check-input disable-check' type='checkbox' value='' checked='checked' onclick='return false;' />")
                    Else
                        Dtl.Append("<input class='form-check-input disable-check' type='checkbox' value='' onclick='return false;' />")
                    End If
                    Dtl.Append("   </div>")
                    Dtl.Append("</div>")
                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString,
                        .Dtl = Dtl.ToString
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

    Function SCM040101_Get_Item_Add_List(Find As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [ItemCode] ")
        Query.Append("  ,[Lock] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[UMCode] ")
        Query.Append("  ,[UMName] ")
        Query.Append("  ,[Cost] ")
        Query.Append("  ,[Canvass] ")
        Query.Append("  ,[UpdateDate] ")
        Query.Append("  ,[VenName] ")
        Query.Append("  ,[LockedBy] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("from ")
        Query.Append("  (select distinct ")
        Query.Append("  [A].item [ItemCode] ")
        Query.Append("  ,isnull([B].Lock,0) [Lock] ")
        Query.Append("  ,[B].item [ItemName] ")
        Query.Append("  ,isnull([A].unit, '') [UMCode] ")
        Query.Append("  ,isnull([C].abbr, '') [UMName] ")
        Query.Append("  ,[A].unit_cost [Cost] ")
        Query.Append("  ,isnull([A].Canvass,0) [Canvass] ")
        Query.Append("  ,[D].po_date [UpdateDate] ")
        Query.Append("  ,[E].vendor [VenName] ")
        Query.Append("  ,[A].seq_no [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([F].first_name) + ' ' + dbo.ProperCase([F].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A]  ")
        Query.Append("  left join ogm_item [B] on [A].item = [B].i_code ")
        Query.Append("  left join sys_um [C] on [A].unit = [C].u_code ")
        Query.Append("  left join ogm_po_hdr [D] on [A].po_code = [d].po_code ")
        Query.Append("  left join ogm_vendor [E] on [D].vendor = [E].v_code ")
        Query.Append("  left join employee [F] on [B].locked_by = [F].emp_no ")
        Query.Append("where ")
        Query.Append("  [D].post = 1 ")
        Query.Append("  and [D].Rvrs = 0 ")
        Query.Append("  and [A].item != '' ")
        Query.Append("  and [A].unit_cost > 0 ")
        Query.Append("  and [A].unit != '' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  [A].i_code [ItemCode] ")
        Query.Append("  ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,[A].Item [ItemName] ")
        Query.Append("  ,isnull([B].u_code, '') [UMCode] ")
        Query.Append("  ,isnull([B].abbr, '') [UMName] ")
        Query.Append("  ,0 [Cost] ")
        Query.Append("  ,0 [Canvass] ")
        Query.Append("  ,'' [UpdateDate] ")
        Query.Append("  ,'' [VenName] ")
        Query.Append("  ,0 [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_item [A] ")
        Query.Append("  left join sys_um [B] on [A].um = [B].u_code ")
        Query.Append("  left join employee [C] on [A].locked_by = [C].emp_no ) [TBL]")
        Query.Append("where ")
        Query.Append("  ([ItemName] like '%" & Find & "%' ")
        Query.Append("  or [UMName] like '%" & Find & "%' ")
        Query.Append("  or [VenName] like '%" & Find & "%') ")
        Query.Append("order by ")
        Query.Append("  [ItemName] ")
        Query.Append("  ,[UpdateDate] ")
        'get query

        'variable
        Dim ItemDetails As New List(Of Object)()
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
                    Data.Append("<div data-itemcode='" & DR("ItemCode") & "' data-seqno='" & DR("SeqNo") & "' data-updatedate='" & DR("UpdateDate") & "' class='d-flex align-items-center w-100 pointer' onclick='SelectAddItem(this);'>")
                    Data.Append("   <div Class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("ItemName") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("ItemCode") & " " & DR("UMName") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex justify-content-end'>")
                    Data.Append("       <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>Locked By</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("LockedBy") & "</span>")
                    Data.Append("       </div>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    ItemDetails.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(ItemDetails))
        'display 

    End Function

    Function SCM040101_Get_Item_Add_Info(SeqNo As String, ItemCode As String, UpdateDate As Date)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [ItemCode] ")
        Query.Append("  ,[Lock] ")
        Query.Append("  ,[ItemName] ")
        Query.Append("  ,[UMCode] ")
        Query.Append("  ,[UMName] ")
        Query.Append("  ,[Cost] ")
        Query.Append("  ,[Canvass] ")
        Query.Append("  ,[UpdateDate] ")
        Query.Append("  ,[VenName] ")
        Query.Append("  ,[LockedBy] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("from ")
        Query.Append("  (select distinct ")
        Query.Append("  [A].item [ItemCode] ")
        Query.Append("  ,isnull([B].Lock,0) [Lock] ")
        Query.Append("  ,[B].item [ItemName] ")
        Query.Append("  ,isnull([A].unit, '') [UMCode] ")
        Query.Append("  ,isnull([C].abbr, '') [UMName] ")
        Query.Append("  ,[A].unit_cost [Cost] ")
        Query.Append("  ,isnull([A].Canvass,0) [Canvass] ")
        Query.Append("  ,[D].po_date [UpdateDate] ")
        Query.Append("  ,[E].vendor [VenName] ")
        Query.Append("  ,[A].seq_no [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([F].first_name) + ' ' + dbo.ProperCase([F].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_po_dtl [A]  ")
        Query.Append("  left join ogm_item [B] on [A].item = [B].i_code ")
        Query.Append("  left join sys_um [C] on [A].unit = [C].u_code ")
        Query.Append("  left join ogm_po_hdr [D] on [A].po_code = [d].po_code ")
        Query.Append("  left join ogm_vendor [E] on [D].vendor = [E].v_code ")
        Query.Append("  left join employee [F] on [B].locked_by = [F].emp_no ")
        Query.Append("where ")
        Query.Append("  [D].post = 1 ")
        Query.Append("  and [D].Rvrs = 0 ")
        Query.Append("  and [A].item != '' ")
        Query.Append("  and [A].unit_cost > 0 ")
        Query.Append("  and [A].unit != '' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  [A].i_code [ItemCode] ")
        Query.Append("  ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,[A].Item [ItemName] ")
        Query.Append("  ,isnull([B].u_code, '') [UMCode] ")
        Query.Append("  ,isnull([B].abbr, '') [UMName] ")
        Query.Append("  ,0 [Cost] ")
        Query.Append("  ,0 [Canvass] ")
        Query.Append("  ,'' [UpdateDate] ")
        Query.Append("  ,'' [VenName] ")
        Query.Append("  ,0 [SeqNo] ")
        Query.Append("  ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [LockedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_item [A] ")
        Query.Append("  left join sys_um [B] on [A].um = [B].u_code ")
        Query.Append("  left join employee [C] on [A].locked_by = [C].emp_no ) [TBL]")
        Query.Append("where ")
        Query.Append("  [SeqNo] = '" & SeqNo & "' ")
        Query.Append("  and [ItemCode] = '" & ItemCode & "' ")
        Query.Append("  and [UpdateDate] = '" & UpdateDate & "' ")
        Query.Append("order by ")
        Query.Append("  [ItemName] ")
        Query.Append("  ,[UpdateDate] ")
        'get query

        'variable
        Dim ItemInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    ItemInfo.Add(New With {
                        .SeqNo = DR("SeqNo"),
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ItemInfo))
        'display 

    End Function
#End Region

End Class