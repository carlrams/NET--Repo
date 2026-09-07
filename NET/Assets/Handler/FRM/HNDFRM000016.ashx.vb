Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.PeerToPeer.Collaboration
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Windows.Forms
Imports System.Windows.Forms.LinkLabel
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Ajax.Utilities
Imports Microsoft.Identity.Client
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json

Public Class HNDFRM000016
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
    Dim calmardblive As String = "calmardblive"
    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'user info
        CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'general parameter
        Dim pFormCode = context.Request("pFormCode")
        Dim pType = context.Request("pType")
        'general parameter  
#Region "form"
        Try

            If pFormCode = "FRM000016" And pType = "Get - Record" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.FRM000016_Get_Record_hdr_info(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Seen" Then
                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")

                Dim json As String = Me.FRM000016_Seen(pFCode, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Get - FullName" Then

                Dim json As String = Me.FRM000016_Get_FullName()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Add - Record" Then

                Dim pDateRequired = context.Request("pDateRequired")
                Dim pPCType = context.Request("pPCType")
                Dim pFund = context.Request("pFund")
                Dim pBrnchCode = context.Request("pBrnchCode")
                Dim pDeptCode = context.Request("pDeptCode")
                Dim pPayeeType = context.Request("pPayeeType")
                Dim pPayor = context.Request("pPayor")
                Dim pRefNo = context.Request("pRefNo")
                Dim pRemarks = context.Request("pRemarks")
                Dim pDueDate = context.Request("pDueDate")
                Dim pIsPIckUp = context.Request("pIsPIckUp")
                Dim pIsDeposit = context.Request("pIsDeposit")
                Dim pBankName = context.Request("pBankName")
                Dim pAcctName = context.Request("pAcctName")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pWithEWT = context.Request("pWithEWT")
                Dim pGrossAmt = context.Request("pGrossAmt")
                Dim pEWT = context.Request("pEWT")
                Dim pNetAmt = context.Request("pNetAmt")

                Dim json As String = Me.FRM000016_Add_Record(pDateRequired, pPCType, pFund, pBrnchCode, pDeptCode, pPayeeType, pPayor, pRefNo, pRemarks, pDueDate, pIsPIckUp, pIsDeposit, pBankName, pAcctName, pAcctNo, pWithEWT, pGrossAmt, pEWT, pNetAmt)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Upd - Record" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pDateRequired = context.Request("pDateRequired")
                Dim pPCType = context.Request("pPCType")
                Dim pFund = context.Request("pFund")
                Dim pBrnchCode = context.Request("pBrnchCode")
                Dim pDeptCode = context.Request("pDeptCode")
                Dim pPayeeType = context.Request("pPayeeType")
                Dim pPayor = context.Request("pPayor")
                Dim pRefNo = context.Request("pRefNo")
                Dim pRemarks = context.Request("pRemarks")
                Dim pDueDate = context.Request("pDueDate")
                Dim pIsPIckUp = context.Request("pIsPIckUp")
                Dim pIsDeposit = context.Request("pIsDeposit")
                Dim pBankName = context.Request("pBankName")
                Dim pAcctName = context.Request("pAcctName")
                Dim pAcctNo = context.Request("pAcctNo")
                Dim pWithEWT = context.Request("pWithEWT")
                Dim pGrossAmt = context.Request("pGrossAmt")
                Dim pEWT = context.Request("pEWT")
                Dim pNetAmt = context.Request("pNetAmt")

                Dim json As String = Me.FRM000016_UPD_Record(pFCode, pID, pDateRequired, pPCType, pFund, pBrnchCode, pDeptCode, pPayeeType, pPayor, pRefNo, pRemarks, pDueDate, pIsPIckUp, pIsDeposit, pBankName, pAcctName, pAcctNo, pWithEWT, pGrossAmt, pEWT, pNetAmt)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000016" And pType = "Get Record - DTL - Movement" Then

                Dim pID = context.Request("pID")
                Dim json As String = Me.FRM000016_Get_Record_dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Add - Record DTL" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pItem = context.Request("pItem")
                Dim pQty = context.Request("pQty")
                Dim pUnit = context.Request("pUnit")
                Dim pAmount = context.Request("pAmount")
                Dim pPType = context.Request("pPType")
                Dim pdivision = context.Request("pdivision")
                Dim pExpense = context.Request("pExpense")
                Dim psubsidiary = context.Request("psubsidiary")
                Dim pCLSub = context.Request("pCLSub")
                Dim pEWT = context.Request("pEWT")


                Dim json As String = Me.FRM000016_Add_Record_DTL(pFCode, pID, pItem, pQty, pUnit, pAmount, pPType, pdivision, pExpense, psubsidiary, pCLSub, pEWT)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Upd - Record DTL" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pSeqno = context.Request("pSeqno")
                Dim pItem = context.Request("pItem")
                Dim pQty = context.Request("pQty")
                Dim pUnit = context.Request("pUnit")
                Dim pAmount = context.Request("pAmount")
                Dim pPType = context.Request("pPType")
                Dim pdivision = context.Request("pdivision")
                Dim pExpense = context.Request("pExpense")
                Dim psubsidiary = context.Request("psubsidiary")
                Dim pCLSub = context.Request("pCLSub")
                Dim pEWT = context.Request("pEWT")


                Dim json As String = Me.FRM000016_Upd_Record_DTL(pFCode, pSeqno, pID, pItem, pQty, pUnit, pAmount, pPType, pdivision, pExpense, psubsidiary, pCLSub, pEWT)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Conf Petty Cash Entry" Then

                Dim pItem = context.Request("pItem")
                Dim pQty = context.Request("pQty")
                Dim pUnit = context.Request("pUnit")
                Dim pAmount = context.Request("pAmount")
                Dim pDivision = context.Request("pDivision")
                Dim pExpense = context.Request("pExpense")
                Dim pSubsidiary = context.Request("pSubsidiary")
                Dim pCode = context.Request("pCode")


                Dim json As String = Me.FRM000016_Conf_PettyCashEntry(pItem, pQty, pUnit, pAmount, pDivision, pExpense, pSubsidiary, pCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000016" And pType = "Get Record - DTL - Movement - Modal" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim json As String = Me.FRM000016_Get_Record_DTL_Modal(pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Delete Record DTL" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pEWT = context.Request("pEWT")
                Dim json As String = Me.FRM000016_Del_Record_DTL(pFCode, pID, pSeqNo, pEWT)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "FRM000016 RPT" Then

                Dim pID = context.Request("pID")
                Dim plblFund = context.Request("plblFund")
                Dim plblType = context.Request("plblType")
                Dim pBranch = context.Request("pBranch")

                Dim json As String = Me.FRM000016_RPT(pID, plblFund, plblType, pBranch, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Change Status" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pStatus = context.Request("pStatus")
                Dim pAssignTo = context.Request("pAssignTo")
                Dim pRemarks = context.Request("pRemarks")
                Dim pMention = context.Request("pMention")

                Dim json As String = Me.FRM000016_ChangeStatus(pFCode, pID, pStatus, pAssignTo, pRemarks, pMention)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Get - Record - Approver" Then

                Dim pID = context.Request("pID")


                Dim json As String = Me.FRM000016_Get_Record_ApprovalPath(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Add - Record - Approver" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pAddForm = context.Request("pAddForm")
                Dim pApproverType = context.Request("pApproverType")
                Dim pApprover = context.Request("pApprover")
                Dim pNoDays = context.Request("pNoDays")
                Dim pTemplate = context.Request("pTemplate")


                Dim json As String = Me.FRM000016_AddApprover_Record_DTL(pFCode, pID, pAddForm, pApproverType, pApprover, pNoDays, pTemplate)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000016" And pType = "Delete Record Approver" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim json As String = Me.FRM000016_Del_Record_Approver(pFCode, pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000016" And pType = "Up Record Approver" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim json As String = Me.FRM000016_Up_Record_Approver(pFCode, pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000016" And pType = "Down Record Approver" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim json As String = Me.FRM000016_Down_Record_Approver(pFCode, pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000016" And pType = "Reason - For - Delay" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pReason = context.Request("pReason")
                Dim json As String = Me.FRM000016_Reason4Delay_Record(pFCode, pID, pSeqNo, pReason)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "FRM000016" And pType = "Get - Record - Subscriber" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.FRM000016_Get_Record_Subscriber(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Get - Record - History" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")

                Dim json As String = Me.FRM000016_Get_Record_History(pFCode, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Add - User - Subscriber" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pMonitorBy = context.Request("pMonitorBy")

                Dim json As String = FRM000016_Add_Subscriber_Record(pFCode, pID, pMonitorBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Delete - User - Subscriber" Then

                Dim pFCode = "FRM000016"
                Dim pID = context.Request("pID")
                Dim pMonitoredBy = context.Request("pMonitoredBy")

                Dim json As String = FRM000016_Delete_Subscriber_Record(pFCode, pID, pMonitoredBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If


            If pFormCode = "FRM000016" And pType = "Get - Dropdown - List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                Dim pVal = context.Request("pVal")
                Dim pVal2 = context.Request("pVal2")

                Dim json As String = Me.Get_Record_List(pTblName, pPlaceHolder, pVal, pVal2)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Get - Description" Then

                Dim pExpense = context.Request("pExpense")

                Dim json As String = Me.FRM000016_Get_Description(pExpense)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFormCode = "FRM000016" And pType = "Get - Find - Record" Then


                Dim json As String = Me.FRM000016_Get_All_Records()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If
            If pFormCode = "FRM000016" And pType = "Get Msg Alert" Then

                Dim pID = context.Request("pID")
                Dim pValue = context.Request("pValue")
                Dim pValue2 = context.Request("pValue2")
                Dim pGroup = context.Request("pGroup")
                Dim pFType = context.Request("pFType")


                Dim json As String = Me.FRM000016_Alert(pGroup, pFType, pID, pValue, pValue2)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If


        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try
#End Region
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#Region "FRM000016"
    Function FRM000016_Seen(pFCode, pID)
        'create variable
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = getdate() ")
        Query.Append("   ,Seen = 1 ")
        Query.Append("where ")
        Query.Append("   TblName = '" & pFCode & "' ")
        Query.Append("   and TblCode = '" & pID & "' ")
        Query.Append("   and Notify = '" & CIIS_EmpCode & "' ")

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

                    RecordList.Add(New With {.oReturn = "Success"})

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

    Function FRM000016_Alert(pGroup, pFType, pID, pValue, pValue2)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If pGroup = "06PCDtl" Then

            'get total task
            If pFType = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
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
            If pFType = "Upload" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" + CIIS_EmpCode + "' not in (select created_by from oop_form_hdr where f_code = '" & pID & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & pValue & "' not in ('Cash Liquidation', 'Cash Payment') or '" & pValue2 & "' not in ('PDD Fund (Permits)', 'PDD Fund (Titling)', 'PDD Fund (Licensing)') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue & ") in ('Approved') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Save(ReasonForDelay)" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & CIIS_EmpCode & "' not in (select approver from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue & ") ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Up" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If pFType = "Down" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & pValue & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
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
                Query.Append("   select 'Access denied!' ")
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
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Declined','Cancelled') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
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
            If pFType = "Save (Reference)" Then
                Query.Append("if '" & pValue & "' = 'Cash Advance' and (select dept_code from employee where emp_no =  '" & CIIS_EmpCode & "') = '2023000000' ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("  if '" & pValue & "' = 'Cash Advance' and (select count(1) from oop_form_hdr [A] left join Form_PCHdr [B] on [A].tbl_code = [B].PCCode where [A].tbl_from = 'Form_PCHdr' and [A].status not in ('Accepted','Cancelled','Declined') and [A].created_by = '" & CIIS_EmpCode & "' and [B].PCType = 'Cash Advance' and [B].Fund = 'General Fund') >= 1 ")
                Query.Append("      begin ")
                Query.Append("          select 'You are only allowed one cash advance on general fund. Please wait until your current cash advance to be fully approved!' ")
                Query.Append("      end ")
                Query.Append("  else if '" & pValue & "' = 'Cash Liquidation' and '" & pValue2 & "' not in (select [A].f_code from oop_form_hdr [A] left join Form_PCHdr [B] on [A].tbl_code = [B].PCCode where [A].f_code = '" & pValue2 & "' and [A].tbl_from = 'Form_PCHdr' and [A].status = 'Accepted' and [B].PCType = 'Cash Advance') ")
                Query.Append("      begin ")
                Query.Append("          select '" & pValue2 & " is not a valid Cash Advance reference!' ")
                Query.Append("      end ")
                Query.Append("  else ")
                Query.Append("      begin ")
                Query.Append("          select '' ")
                Query.Append("      end ")
                Query.Append("end ")
            End If
            If pFType = "Save (UPD)" Then
                Query.Append("if '" & pValue & "' = 'Cash Advance' and (select dept_code from employee where emp_no =  '" & CIIS_EmpCode & "') = '2023000000' ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("  if '" & pValue & "' = 'Cash Advance' and exists (select 1 from oop_form_hdr [A] left join Form_PCHdr [B] on [A].tbl_code = [B].PCCode where [A].tbl_from = 'Form_PCHdr' and [A].status not in ('Accepted','Cancelled','Declined') and [A].created_by = '" & CIIS_EmpCode & "' and [B].PCType = 'Cash Advance' and [B].Fund = 'General Fund' and [A].f_code <> '" & pID & "') ")
                Query.Append("      begin ")
                Query.Append("          select 'You are only allowed one cash advance on general fund. Please wait until your current cash advance to be fully approved!' ")
                Query.Append("      end ")
                Query.Append("  else if '" & pValue & "' = 'Cash Liquidation' and '" & pValue2 & "' not in (select [A].f_code from oop_form_hdr [A] left join Form_PCHdr [B] on [A].tbl_code = [B].PCCode where [A].f_code = '" & pValue2 & "' and [A].tbl_from = 'Form_PCHdr' and [A].status = 'Accepted' and [B].PCType = 'Cash Advance') ")
                Query.Append("      begin ")
                Query.Append("          select '" & pValue2 & " is not a valid Cash Advance reference!' ")
                Query.Append("      end ")
                Query.Append("  else ")
                Query.Append("      begin ")
                Query.Append("          select '' ")
                Query.Append("      end ")
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
                Query.Append("else if '" & pValue & "' in ('Approved','Clarify') and (select (case when '" + CIIS_EmpCode + "' not in (approver) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select count(1) from oop_form_hdr [A] left join Form_PCdtl [B] on [A].tbl_code = [B].PCCode  where Subsidiary not in ('NO SUBSIDIARY','','-') and code = '' and [A].f_code = '" & pID & "') >= 1 ")
                Query.Append("begin ")
                Query.Append("	select 'Missing subsidiary' ")
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
    Function FRM000016_Get_All_Records()

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
        Query.Append("      [A].tbl_from = 'Form_PCHdr' ")
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
        Query.Append("      [A].tbl_from = 'Form_PCHdr' ")
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
        Query.Append("      [A].tbl_from = 'Form_PCHdr' ")
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
    Function FRM000016_Get_FullName()

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("    dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [fullname] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("   emp_no = '" & CIIS_EmpCode & "' ")
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



                    RecordList.Add(New With {
                        .fullname = DR("fullname"),
                        .DateNow = Format(Date.Now, "MM/dd/yyyy")
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
    Function FRM000016_Get_Record_hdr_info(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].f_code [ID] ")
        Query.Append("   ,[A].created_date [DateCreated] ")
        Query.Append("   ,[A].date_required [DateRequired] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
        Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo] ")
        Query.Append("   ,[A].status [Status] ")
        Query.Append("   ,[B].PCType [Type] ")
        Query.Append("   ,[F].description [Branch] ")
        Query.Append("   ,[B].Fund ")
        Query.Append("   ,[G].description [Department] ")
        Query.Append("   ,[B].PayeeType ")
        Query.Append("   ,[B].Payor [PayorCode] ")
        Query.Append("   ,(case [B].PayeeType ")
        Query.Append("   				when 'Agent' then agent.fullname ")
        Query.Append("   				when 'Customer' then customer.fullname ")
        Query.Append("   				when 'Employee' then employee.fullname ")
        Query.Append("   				when 'Vendor' then ogm_vendor.vendor ")
        Query.Append("   			end) [Payor] ")
        Query.Append("   ,[B].RefNo ")
        Query.Append("   ,[B].Remarks ")
        Query.Append("   ,isnull(format([B].DueDate,'MM/dd/yyyy'),'') [DueDate] ")
        Query.Append("   ,[B].IsPickUp ")
        Query.Append("   ,[B].IsDeposit ")
        Query.Append("   ,[B].BankName ")
        Query.Append("   ,[B].AcctName ")
        Query.Append("   ,[B].AcctNo ")
        Query.Append("   ,isnull([B].WithEWT, 0) [WithEWT] ")
        Query.Append("   ,isnull(Format([B].GrossAmount, 'N2'), 0.00) [GrossAmt] ")
        Query.Append("   ,isnull(Format([B].EWT, 'N2'), 0.00) [EWT] ")
        Query.Append("   ,isnull(Format([B].NetAmount, 'N2'), 0.00) [NetAmt] ")
        Query.Append("   ,isnull([A].FormTitle,'') [FormTitle] ")
        Query.Append("   ,[F].buss_code [buss_code] ")
        Query.Append("   ,[B].Fund ")
        Query.Append("   ,[G].dept_code [dept_code] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_PCHdr [B] on [A].tbl_code = [B].PCCode ")
        Query.Append("   left join business [BRH] on [B].BrnchCode = [BRH].buss_code ")
        Query.Append("   left join department [DEPT] on [B].DeptCode = [DEPT].dept_code ")
        Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
        Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
        Query.Append("   left join business [F] on [B].BrnchCode = [F].buss_code ")
        Query.Append("   left join department [G] on [B].DeptCode = [G].dept_code ")
        Query.Append("   left join agent on [B].Payor = agent.agent_code ")
        Query.Append("   left join customer on [B].Payor = customer.cust_code ")
        Query.Append("   left join employee on [B].Payor = employee.emp_no ")
        Query.Append("   left join ogm_vendor on [B].Payor = ogm_vendor.v_code ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & Replace(pID, "No", "#") & "' ")
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



                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .FormType = "Petty Cash/Revolving Fund",
                        .DateCreated = Format(DR("DateCreated"), "MM/dd/yyyy"),
                        .DateRequired = Format(DR("DateRequired"), "MM/dd/yyyy"),
                        .RequestedBy = DR("RequestedBy"),
                        .AssignedTo = DR("AssignedTo"),
                        .EndorsedTo = DR("EndorsedTo"),
                        .RecordStatus = DR("Status"),
                        .Type = DR("Type"),
                        .Branch = DR("Branch"),
                        .Fund = DR("Fund"),
                        .Department = DR("Department"),
                        .PayeeType = DR("PayeeType"),
                        .PayorCode = DR("PayorCode"),
                        .Payor = DR("Payor"),
                        .RefNo = DR("RefNo"),
                        .Remarks = DR("Remarks"),
                        .DueDate = DR("DueDate"),
                        .IsPickUp = DR("IsPickUp"),
                        .IsDeposit = DR("IsDeposit"),
                        .BankName = DR("BankName"),
                        .AcctName = DR("AcctName"),
                        .AcctNo = DR("AcctNo"),
                        .WithEWT = DR("WithEWT"),
                        .GrossAmt = DR("GrossAmt"),
                        .EWT = DR("EWT"),
                        .NetAmt = DR("NetAmt"),
                        .FormTitle = DR("FormTitle"),
                        .buss_code = DR("buss_code"),
                        .dept_code = DR("dept_code")
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
    Function FRM000016_Add_Record(pDateRequired, pPCType, pFund, pBrnchCode, pDeptCode, pPayeeType, pPayor, pRefNo, pRemarks, pDueDate, pIsPIckUp, pIsDeposit, pBankName, pAcctName, pAcctNo, pWithEWT, pGrossAmt, pEWT, pNetAmt)

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
        SqlCmd.CommandText = "New_FRM_FRM000016"
        SqlCmd.Parameters.AddWithValue("@pDateRequired", pDateRequired)
        SqlCmd.Parameters.AddWithValue("@pPCType", pPCType)
        SqlCmd.Parameters.AddWithValue("@pFund", pFund)
        SqlCmd.Parameters.AddWithValue("@pBrnchCode", pBrnchCode)
        SqlCmd.Parameters.AddWithValue("@pDeptCode", pDeptCode)
        SqlCmd.Parameters.AddWithValue("@pPayeeType", pPayeeType)
        SqlCmd.Parameters.AddWithValue("@pPayor", pPayor)
        SqlCmd.Parameters.AddWithValue("@pRefNo", pRefNo)
        SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
        SqlCmd.Parameters.AddWithValue("@pDueDate", pDueDate)
        SqlCmd.Parameters.AddWithValue("@pIsPIckUp", pIsPIckUp)
        SqlCmd.Parameters.AddWithValue("@pIsDeposit", pIsDeposit)
        SqlCmd.Parameters.AddWithValue("@pBankName", pBankName)
        SqlCmd.Parameters.AddWithValue("@pAcctName", pAcctName)
        SqlCmd.Parameters.AddWithValue("@pAcctNo", pAcctNo)
        SqlCmd.Parameters.AddWithValue("@pWithEWT", pWithEWT)
        SqlCmd.Parameters.AddWithValue("@pGrossAmt", CDbl(pGrossAmt))
        SqlCmd.Parameters.AddWithValue("@pEWT", CDbl(pEWT))
        SqlCmd.Parameters.AddWithValue("@pNetAmt", CDbl(pNetAmt))
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
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
    Function FRM000016_UPD_Record(pFCode, pID, pDateRequired, pPCType, pFund, pBrnchCode, pDeptCode, pPayeeType, pPayor, pRefNo, pRemarks, pDueDate, pIsPIckUp, pIsDeposit, pBankName, pAcctName, pAcctNo, pWithEWT, pGrossAmt, pEWT, pNetAmt)

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
        SqlCmd.CommandText = "Upd_FRM_FRM000016"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pDateRequired", pDateRequired)
        SqlCmd.Parameters.AddWithValue("@pPCType", pPCType)
        SqlCmd.Parameters.AddWithValue("@pFund", pFund)
        SqlCmd.Parameters.AddWithValue("@pBrnchCode", pBrnchCode)
        SqlCmd.Parameters.AddWithValue("@pDeptCode", pDeptCode)
        SqlCmd.Parameters.AddWithValue("@pPayeeType", pPayeeType)
        SqlCmd.Parameters.AddWithValue("@pPayor", pPayor)
        SqlCmd.Parameters.AddWithValue("@pRefNo", pRefNo)
        SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
        SqlCmd.Parameters.AddWithValue("@pDueDate", pDueDate)
        SqlCmd.Parameters.AddWithValue("@pIsPIckUp", pIsPIckUp)
        SqlCmd.Parameters.AddWithValue("@pIsDeposit", pIsDeposit)
        SqlCmd.Parameters.AddWithValue("@pBankName", pBankName)
        SqlCmd.Parameters.AddWithValue("@pAcctName", pAcctName)
        SqlCmd.Parameters.AddWithValue("@pAcctNo", pAcctNo)
        SqlCmd.Parameters.AddWithValue("@pWithEWT", pWithEWT)
        SqlCmd.Parameters.AddWithValue("@pGrossAmt", CDbl(pGrossAmt))
        SqlCmd.Parameters.AddWithValue("@pEWT", CDbl(pEWT))
        SqlCmd.Parameters.AddWithValue("@pNetAmt", CDbl(pNetAmt))
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)

        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        RecordList.Add(New With {.oID = pID})

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function FRM000016_Get_Record_dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].SeqNo ")
        Query.Append("   ,[B].f_code ")
        Query.Append("   ,[A].Item [Item] ")
        Query.Append("   ,FORMAT([A].Qty,'N2') [Qty] ")
        Query.Append("   ,[A].Unit [Unit] ")
        Query.Append("   ,[A].Amount [Amount] ")
        Query.Append("   ,isnull([C].description,'') [Division] ")
        Query.Append("   ,isnull([D].description,'') [Expense] ")
        Query.Append("   ,isnull([A].Subsidiary,'') [Subsidiary] ")
        Query.Append("   ,(case	  when [A].Subsidiary = 'LOT' then [LT].description ")
        Query.Append("            when [A].Subsidiary = 'MISCELLANEOUS' then [MS].description ")
        Query.Append("            when [A].Subsidiary = 'MODEL HOUSE' then [HS].description ")
        Query.Append("            when [A].Subsidiary = 'NO SUBSIDIARY' then '' ")
        Query.Append("            when [A].Subsidiary = 'PHASE' then [PH].description ")
        Query.Append("            when [A].Subsidiary = 'SUBDIVISION' then [SB].description ")
        Query.Append("            else '' end) [Code] ")
        Query.Append("from ")
        Query.Append("   Form_PCDtl [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].PCCode = [B].tbl_code ")
        Query.Append("   left join Division [C] on [A].Division = [C].div_code ")
        Query.Append("   left join fin_chart [D] on [A].Expense = [D].acct_code ")
        Query.Append("   left join sub_lot [LT] on [A].Code = [LT].code ")
        Query.Append("   left join sub_misc [MS] on [A].Code = [MS].code ")
        Query.Append("   left join sub_house [HS] on [A].Code = [HS].code ")
        Query.Append("   left join sub_phase [PH] on [A].Code = [PH].code ")
        Query.Append("   left join sub_subdivision [SB] on [A].Code = [SB].code ")
        Query.Append("where ")
        Query.Append("   [B].f_code = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("   [A].SeqNo ")
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

                    Dim Division = IIf(DR("Division") = "", "-", DR("Division"))
                    Dim Expense = IIf(DR("Expense") = "", "-", DR("Expense"))
                    Dim Subsidiary = IIf(DR("Subsidiary") = "", "-", DR("Subsidiary"))
                    Dim Code = IIf(DR("Code") = "", "-", DR("Code"))

                    Dim Action As New StringBuilder

                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & DR("SeqNo") & "', '" & DR("f_code") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn0102Edit('" & DR("SeqNo") & "', '" & DR("f_code") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("SeqNo") & "_" & DR("f_code"),
                        .Action = Action.ToString,
                        .Item = DR("Item"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .Amount = DR("Amount"),
                        .Division = "<span title='" & Division & "'>" & Division & "</span>",
                        .Expense = "<span title='" & Expense & "'>" & Expense & "</span>",
                        .Subsidiary = "<span title='" & Subsidiary & "'>" & Subsidiary & "</span>",
                        .Code = "<span title='" & Code & "'>" & Code & "</span>"
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
    Function FRM000016_Get_Record_DTL_Modal(pID, pSeqNo)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].SeqNo ")
        Query.Append("   ,[A].Item [Item] ")
        Query.Append("   ,FORMAT([A].Qty,'N2') [Qty] ")
        Query.Append("   ,[A].Unit [Unit] ")
        Query.Append("   ,FORMAT([A].Amount,'N2') [Amount] ")
        Query.Append("   ,[A].Division ")
        Query.Append("   ,[A].Expense ")
        Query.Append("   ,[A].Subsidiary ")
        Query.Append("   ,[A].Code ")
        Query.Append("from ")
        Query.Append("   Form_PCDtl [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].PCCode = [B].tbl_code ")
        Query.Append("where ")
        Query.Append("   [B].f_code = '" & pID & "' ")
        Query.Append("   and [A].SeqNo = '" & pSeqNo & "' ")

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



                    Dim Action As New StringBuilder

                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & DR("SeqNo") & "', '" & pID & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn0102Edit('" & DR("SeqNo") & "', '" & pID & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("SeqNo") & "_" & pID,
                        .Action = Action.ToString,
                        .Item = DR("Item"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .Amount = DR("Amount"),
                        .Division = DR("Division"),
                        .Expense = DR("Expense"),
                        .Subsidiary = DR("Subsidiary"),
                        .Code = DR("Code")
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
    Function FRM000016_Add_Record_DTL(pFCode, pID, pItem, pQty, pUnit, pAmount, pPType, pdivision, pExpense, psubsidiary, pCLSub, pEWT)

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
        SqlCmd.CommandText = "New_FRM_FRM000016_PCDtl"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItem", pItem)
        SqlCmd.Parameters.AddWithValue("@pQty", CDbl(pQty))
        SqlCmd.Parameters.AddWithValue("@pUnit", pUnit)
        SqlCmd.Parameters.AddWithValue("@pAmt", CDbl(pAmount))
        SqlCmd.Parameters.AddWithValue("@pDivision", IIf(pPType = "Cash Liquidation", pdivision, IIf(pPType = "Cash Payment", pdivision, "")))
        SqlCmd.Parameters.AddWithValue("@pExpense", IIf(pPType = "Cash Liquidation", pExpense, IIf(pPType = "Cash Payment", pExpense, "")))
        SqlCmd.Parameters.AddWithValue("@pSubsidiary", IIf(pPType = "Cash Liquidation", pCLSub, IIf(pPType = "Cash Payment", pCLSub, "")))
        SqlCmd.Parameters.AddWithValue("@pCode", IIf(pPType = "Cash Liquidation", psubsidiary, IIf(pPType = "Cash Payment", psubsidiary, "")))
        SqlCmd.Parameters.AddWithValue("@pEWT", IIf(pEWT = "-", 0.00, CDbl(pEWT)))
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
    Function FRM000016_Upd_Record_DTL(pFCode, pSeqno, pID, pItem, pQty, pUnit, pAmount, pPType, pdivision, pExpense, psubsidiary, pCLSub, pEWT)

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
        SqlCmd.CommandText = "Upd_FRM_FRM000016_PCDtl"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqno)
        SqlCmd.Parameters.AddWithValue("@pItem", pItem)
        SqlCmd.Parameters.AddWithValue("@pQty", CDbl(pQty))
        SqlCmd.Parameters.AddWithValue("@pUnit", pUnit)
        SqlCmd.Parameters.AddWithValue("@pAmt", CDbl(pAmount))
        SqlCmd.Parameters.AddWithValue("@pDivision", IIf(pPType = "Cash Liquidation", pdivision, IIf(pPType = "Cash Payment", pdivision, "")))
        SqlCmd.Parameters.AddWithValue("@pExpense", IIf(pPType = "Cash Liquidation", pExpense, IIf(pPType = "Cash Payment", pExpense, "")))
        SqlCmd.Parameters.AddWithValue("@pSubsidiary", IIf(pPType = "Cash Liquidation", pCLSub, IIf(pPType = "Cash Payment", pCLSub, "")))
        SqlCmd.Parameters.AddWithValue("@pCode", IIf(pPType = "Cash Liquidation", psubsidiary, IIf(pPType = "Cash Payment", psubsidiary, "")))
        SqlCmd.Parameters.AddWithValue("@pEWT", IIf(pEWT = "-", 0.00, CDbl(pEWT)))
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
    Function FRM000016_Get_Description(pExpense)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   subsidiary ")
        Query.Append("from ")
        Query.Append("   fin_chart ")
        Query.Append("where ")
        Query.Append("   acct_code = '" & pExpense & "' ")
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



                    RecordList.Add(New With {
                        .subsidiary = DR("subsidiary")
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
    Function FRM000016_Del_Record_DTL(pFCode, pID, pSeqNo, pEWT)

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
        SqlCmd.CommandText = "Del_FRM_FRM000016_PCDtl"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
        SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
        SqlCmd.Parameters.AddWithValue("@pEWT", IIf(pEWT = "-", 0.00, CDbl(pEWT)))
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
    Function FRM000016_RPT(pID As String, plblFund As String, plblType As String, pBranch As String, context As HttpContext)
        Dim result As New Dictionary(Of String, String)

        Try
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & CIIS_EmpCode & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & CIIS_EmpCode & "/")

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
            If plblType = "Cash Payment" And plblFund = "SCM Fund" Then
                ' Copy template report
                File.Copy(context.Server.MapPath("~/Assets/Report/RPT000017.rpt"), Path.Combine(reportFolderPath, "RPT000017.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000017.rpt"))

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
                RptDoc.SetParameterValue("@pFormNo", pID)
                RptDoc.SetParameterValue("@pFund", plblFund)
                RptDoc.SetParameterValue("@pBranch", pBranch)
                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000017.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000017.pdf")
                result("status") = "success"
                result("viewUrl") = "MNU020200?View=" & encryptedPath

            ElseIf plblType = "Cash Payment" And plblFund = "MKTG Fund" Then
                ' Copy template report
                File.Copy(context.Server.MapPath("~/Assets/Report/RPT000045.rpt"), Path.Combine(reportFolderPath, "RPT000045.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000045.rpt"))

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
                RptDoc.SetParameterValue("@pFormNo", pID)
                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000045.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000045.pdf")
                result("status") = "success"
                result("viewUrl") = "MNU020200?View=" & encryptedPath
            Else
                ' Copy template report
                File.Copy(context.Server.MapPath("~/Assets/Report/RPT000007.rpt"), Path.Combine(reportFolderPath, "RPT000007.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPT000007.rpt"))

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
                RptDoc.SetParameterValue("@pFormNo", pID)
                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000007.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPT000007.pdf")
                result("status") = "success"
                result("viewUrl") = "MNU020200?View=" & encryptedPath
            End If
        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)
    End Function

    Function FRM000016_Conf_PettyCashEntry(pItem, pQty, pUnit, pAmount, pDivision, pExpense, pSubsidiary, pCode)

        Dim RecordList As New List(Of Object)()

        Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using SqlCmd As New SqlClient.SqlCommand("Conf_PettyCashEntry", SqlConn)
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandTimeout = 1500

                SqlCmd.Parameters.AddWithValue("@pItem", pItem)
                SqlCmd.Parameters.AddWithValue("@pQty", pQty)
                SqlCmd.Parameters.AddWithValue("@pUnit", pUnit)
                SqlCmd.Parameters.AddWithValue("@pAmount", pAmount)
                SqlCmd.Parameters.AddWithValue("@pDivision", pDivision)
                SqlCmd.Parameters.AddWithValue("@pExpense", pExpense)
                SqlCmd.Parameters.AddWithValue("@pSubsidiary", pSubsidiary)
                SqlCmd.Parameters.AddWithValue("@pCode", pCode)


                SqlCmd.Parameters.Add("@oStatus", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                SqlCmd.Parameters.Add("@oDivCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                SqlCmd.Parameters.Add("@oExpenseCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                SqlCmd.Parameters.Add("@oSubsidiary", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                SqlCmd.Parameters.Add("@oCode", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output

                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()

                RecordList.Add(New With {
                .oReturn = "Success",
                .oStatus = SqlCmd.Parameters("@oStatus").Value.ToString(),
                .oDivCode = SqlCmd.Parameters("@oDivCode").Value.ToString(),
                .oExpenseCode = SqlCmd.Parameters("@oExpenseCode").Value.ToString(),
                .oSubsidiary = SqlCmd.Parameters("@oSubsidiary").Value.ToString(),
                .oCode = SqlCmd.Parameters("@oCode").Value.ToString()
            })
            End Using
        End Using

        Return New JavaScriptSerializer().Serialize(RecordList)
    End Function


    Function FRM000016_ChangeStatus(pFCode, pID, pStatus, pAssignTo, pRemarks, pMention)

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
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
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

    Function FRM000016_Get_Record_ApprovalPath(pID)

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
        Query.Append("   [A].f_code = '" & pID & "' ")
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

    Function FRM000016_AddApprover_Record_DTL(pFCode, pID, pAddForm, pType, pApprover, pNoDays, pTemplate)

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
            SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
            SqlCmd.Parameters.AddWithValue("@pID", pID)
            SqlCmd.Parameters.AddWithValue("@pType", pType)
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
            SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
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

    Function FRM000016_Del_Record_Approver(pFCode, pID, pSeqNo)

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
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
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

    Function FRM000016_Up_Record_Approver(pFCode, pID, pSeqNo)

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
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
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

    Function FRM000016_Down_Record_Approver(pFCode, pID, pSeqNo)

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
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
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
    Function FRM000016_Reason4Delay_Record(pFCode, pID, pSeqNo, pReason)

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
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
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
    Function FRM000016_Get_Record_Subscriber(pID)

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
        Query.Append("   [A].f_code = '" & pID & "' ")
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

    Function FRM000016_Add_Subscriber_Record(pFCode, pID, pMonitorBy)

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
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
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
    Function FRM000016_Delete_Subscriber_Record(pFCode, pID, pMonitoredBy)

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
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pMonitoredBy", pMonitoredBy)
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
    Function FRM000016_Get_Record_History(pFCode, pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
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
        Query.Append("   [A].TblName = '" & pFCode & "' ")
        Query.Append("   and [A].TblCode = '" & pID & "' ")
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
        Query.Append("   [A].f_code = '" & pID & "' ")
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
#Region "Get Record"
    Function Get_Record_List(pTblName, pPlaceHolder, pVal, pVal2)

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
        ElseIf pTblName = "Fund_List" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].Fund [ID] ")
            Query.Append("   ,[A].Fund [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Fund [Order2] ")
            Query.Append("from ")
            Query.Append("   Parm_PettyCash_Fund [A] ")
            Query.Append("where ")
            Query.Append("   BrnchCode = '" & pVal & "' ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Dept_List" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].dept_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   department [A] ")
            Query.Append("where ")
            Query.Append("   [A].lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Payee_List" Then
            If pVal = "Employee" Then
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
                Query.Append("   [A].lock = 1 ")
                Query.Append("   and [A].emp_status in ('Contractual','Probationary','Regular') ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pVal = "Vendor" Then
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
                Query.Append("   [A].lock = 1 ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            End If
        ElseIf pTblName = "Expense_List" Then
            Query.Append("if '" & pVal & "' = 'General Fund' and (select [D].DeptCode from oop_form_hdr [C] left join Form_PCHDr [D] on [C].tbl_code = [D].PCCode where [C].f_code = '" & pVal2 & "') = '2010000001' ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   union ")
            Query.Append("   select  ")
            Query.Append("      [A].Expense [ID] ")
            Query.Append("      ,[B].description [Name] ")
            Query.Append("      ,2 [Order1] ")
            Query.Append("   	,[B].description [Order2] ")
            Query.Append("   from ")
            Query.Append("	    Parm_PettyCash_Expense [A] ")
            Query.Append("	    left join fin_chart [B] on [A].Expense = [B].acct_code ")
            Query.Append("   where ")
            Query.Append("      [A].Fund = '" & pVal & "' ")
            Query.Append("      and [A].Department = '2010000001' ")
            Query.Append("      and [B].lock = 1 ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
            Query.Append("else  ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   union ")
            Query.Append("   select  ")
            Query.Append("      [A].Expense [ID] ")
            Query.Append("   	,[B].description [Name] ")
            Query.Append("      ,2 [Order1] ")
            Query.Append("   	,[B].description [Order2] ")
            Query.Append("   from ")
            Query.Append("	    Parm_PettyCash_Expense [A] ")
            Query.Append("	    left join fin_chart [B] on [A].Expense = [B].acct_code ")
            Query.Append("   where ")
            Query.Append("      [A].Fund = '" & pVal & "' ")
            Query.Append("      and [B].lock = 1 ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
        ElseIf pTblName = "Division_List" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].div_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   division [A] ")
            Query.Append("where ")
            Query.Append("   [A].lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Description_List" Then
            Query.Append("declare @Subsidiary nvarchar(20) = isnull((select subsidiary from fin_chart where acct_code = '" & pVal & "'),'') ")
            Query.Append("if @Subsidiary = 'LOT' ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("       code [ID] ")
            Query.Append("       ,description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("       ,description [Order2] ")
            Query.Append("   from ")
            Query.Append("      sub_lot ")
            Query.Append("   where ")
            Query.Append("      lock = 1 ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
            Query.Append("else if @Subsidiary = 'MISCELLANEOUS' ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("       code [ID] ")
            Query.Append("       ,description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("       ,description [Order2] ")
            Query.Append("   from ")
            Query.Append("      sub_misc ")
            Query.Append("   where ")
            Query.Append("      lock = 1 ")
            Query.Append("      and account = '" & pVal & "' ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
            Query.Append("else if @Subsidiary = 'MODEL HOUSE' ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("       code [ID] ")
            Query.Append("       ,description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("       ,description [Order2] ")
            Query.Append("   from ")
            Query.Append("      sub_house ")
            Query.Append("   where ")
            Query.Append("      lock = 1 ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
            Query.Append("else if @Subsidiary in ('NO SUBSIDIARY','') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
            Query.Append("else if @Subsidiary = 'PHASE' ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("       code [ID] ")
            Query.Append("       ,description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("       ,description [Order2] ")
            Query.Append("   from ")
            Query.Append("      sub_phase ")
            Query.Append("   where ")
            Query.Append("      lock = 1 ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
            Query.Append("else if @Subsidiary = 'SUBDIVISION' ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("       code [ID] ")
            Query.Append("       ,description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("       ,description [Order2] ")
            Query.Append("   from ")
            Query.Append("      sub_subdivision ")
            Query.Append("   where ")
            Query.Append("      lock = 1 ")
            Query.Append("   order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
            Query.Append("end ")
        ElseIf pTblName = "Change_Status" Then
            Query.Append("if (select top 1 created_by from oop_form_hdr where f_code = '" & pVal & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & pVal & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal & "' and status = '') in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & pVal & "') not in ('For Cancellation')")
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
            Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & pVal & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & pVal & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal & "' and status = '') in ('Clarification') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Reply' [ID] ")
            Query.Append("      ,'Reply' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & pVal & "') in ('" & CIIS_EmpCode & "') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Cancelled' [ID] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal & "' and status = '') in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & pVal & "') not in ('For Cancellation') ")
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
            Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & pVal & "' and status = '') in ('Clarification') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [ID] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Reply' [ID] ")
            Query.Append("      ,'Reply' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 status from oop_form_hdr where f_code = '" & pVal & "') in ('For Cancellation') ")
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
            Query.Append("   [A].f_code = '" & pVal & "' ")
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
            Query.Append("   [A].f_code = '" & pVal & "' ")
            Query.Append("   and [A].approver not in ('" & CIIS_EmpCode & "') ")
            Query.Append("order by ")
            Query.Append("   [Order] ")
        ElseIf pTblName = "Approver_List" Then
            Query.Append("if '" & pVal & "' not in (select oop_form_type.FormCode from oop_form_appr left join oop_form_type on oop_form_appr.form_type = oop_form_type.t_code where oop_form_type.FormCode = '" & pVal & "' and oop_form_appr.type = '" & pVal2 & "') ")
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
            Query.Append("      [C].FormCode = '" & pVal & "' ")
            Query.Append("      and [A].type = '" & pVal2 & "' ")
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
            Query.Append("   [A].FormCode = '" & pVal & "' ")
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
        ElseIf pTblName = "GetRecord_AcctName" Then
            Query.Append("select  ")
            Query.Append("	v_code [ID] ")
            Query.Append("	,(case when v_code in ('MN2012060001','MN2012080004') then '' else company end) [Name] ")
            Query.Append("from  ")
            Query.Append("	ogm_vendor ")
            Query.Append("where ")
            Query.Append("	v_code = '" & pVal & "' ")
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
End Class