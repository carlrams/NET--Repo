Imports System.Data.SqlClient
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.EnterpriseServices
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net.PeerToPeer.Collaboration
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Web
Imports System.Web.DynamicData
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.WebSockets
Imports System.Windows.Automation
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.[Shared].Json
Imports Microsoft.Ajax.Utilities
Imports Microsoft.Identity.Client.AuthScheme
Imports Microsoft.Identity.Client.Cache
Imports Microsoft.IdentityModel.Protocols.OpenIdConnect
Imports Microsoft.Reporting.Map.WebForms.VirtualEarth
Imports Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports OfficeOpenXml.ConditionalFormatting.Contracts
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Infrastructure
Imports System.ComponentModel.DataAnnotations
Imports System.CodeDom

Public Class SCM080100HND
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
            'general parameter

            If Type = "Post" Then

                Dim pRecType = context.Request("pRecType")
                Dim pTblCode = context.Request("pTblCode")
                Dim pPostBy = CIIS_EmpCode

                Dim json As String = Me.Post_Record(pRecType, pTblCode, pPostBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "SCM080100" And Type = "Get Record : DTL" Then

                Dim pTblName = context.Request("pTblName")
                Dim pCode = context.Request("pCode")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.SCM080100_Get_Record_DTL(pTblName, pCode, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Get Record" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.SCM080100_Get_Record(pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance : Get SI Location" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM080100_Get_SI_Location(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Get Info : DTL" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM080100_Get_Info_DTL(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Add Record" Then

                Dim pSI = context.Request("pSI")
                Dim pSINo = context.Request("pSINo")
                Dim pSIDate = context.Request("pSIDate")
                Dim pSIDateCreated = context.Request("pSIDateCreated")
                Dim pCECode = context.Request("pCECode")
                Dim pWCode = context.Request("pWCode")
                Dim pTrxnType = context.Request("pTrxnType")
                Dim pTrxnCode = context.Request("pTrxnCode")
                Dim pPRNo = context.Request("pPRNo")
                Dim pRequestedBy = context.Request("pRequestedBy")
                Dim pWhseCode = context.Request("pWhseCode")
                Dim pIssuedBy = context.Request("pIssuedBy")
                Dim pSILocation = context.Request("pSILocation")
                Dim pGP = context.Request("pGP")
                Dim pGPNo = context.Request("pGPNo")
                Dim pGPDate = context.Request("pGPDate")
                Dim pAuthorizedBy = context.Request("pAuthorizedBy")
                Dim pGPLocation = context.Request("pGPLocation")
                Dim pCreatedBy = CIIS_EmpCode
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Add_Record(pSI, pSINo, pSIDate, pSIDateCreated, pCECode, pWCode, pTrxnType, pTrxnCode, pPRNo, pRequestedBy, pWhseCode, pIssuedBy, pSILocation, pGP, pGPNo, pGPDate, pAuthorizedBy, pGPLocation, pCreatedBy, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pSINo = context.Request("pSINo")
                Dim pSI = context.Request("pSI")
                Dim pSIDate = context.Request("pSIDate")
                Dim pSICreatedDate = context.Request("pSICreatedDate")
                Dim pCECode = context.Request("pCECode")
                Dim pWCode = context.Request("pWCode")
                Dim pTrxnType = context.Request("pTrxnType")
                Dim pTrxnCode = context.Request("pTrxnCode")
                Dim pPRNo = context.Request("pPRNo")
                Dim pRequestedBy = context.Request("pRequestedBy")
                Dim pDeptCode = context.Request("pDeptCode")
                Dim pWhseCode = context.Request("pWhseCode")
                Dim pIssuedBy = context.Request("pIssuedBy")
                Dim pSILocation = context.Request("pSILocation")
                Dim pGP = context.Request("pGP")
                Dim pGPNo = context.Request("pGPNo")
                Dim pGPDate = context.Request("pGPDate")
                Dim pAuthorizedBy = context.Request("pAuthorizedBy")
                Dim pGPLocation = context.Request("pGPLocation")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Edit_Record(pID, pSINo, pSI, pSIDate, pSICreatedDate, pCECode, pWCode, pTrxnType, pTrxnCode, pPRNo, pRequestedBy, pDeptCode, pWhseCode, pIssuedBy, pSILocation, pGP, pGPNo, pGPDate, pAuthorizedBy, pGPLocation, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Particular" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM080100_Get_Particular(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Add Record : Item" Then

                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.SCM080100_Get_Item(pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Edit Record : Item" Then

                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.SCM080100_Get_Item_Edit(pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Get Record : Item" Then

                Dim pTblFrom = context.Request("pTblFrom")
                Dim pItemCode = context.Request("pItemCode")
                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.SCM080100_Get_Record_Item(pTblFrom, pItemCode, pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Add Record : Particular" Then

                Dim pID = context.Request("pID")
                Dim pType = context.Request("pType")
                Dim pItemCode = context.Request("pItemCode")
                Dim pQty = context.Request("pQty")
                Dim pUOMCode = context.Request("pUOMCode")
                Dim pCost = context.Request("pCost")
                Dim pTotal = context.Request("pTotal")
                Dim pRemarks = context.Request("pRemarks")
                Dim pCreatedBy = CIIS_EmpCode
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Add_Record_Particular(pID, pType, pItemCode, pQty, pUOMCode, pCost, pTotal, pRemarks, pCreatedBy, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Edit Record : Particular" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pType = context.Request("pType")
                Dim pItemCode = context.Request("pItemCode")
                Dim pQty = context.Request("pQty")
                Dim pUOMCode = context.Request("pUOMCode")
                Dim pCost = context.Request("pCost")
                Dim pTotal = context.Request("pTotal")
                Dim pRemarks = context.Request("pRemarks")
                Dim pCreatedBy = CIIS_EmpCode
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Edit_Record_Particular(pID, pSeqNo, pType, pItemCode, pQty, pUOMCode, pCost, pTotal, pRemarks, pCreatedBy, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Get Record - DTL - Particular : Redraw" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.SCM080100_Get_Record_Particular_Redraw(pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Get Record - DTL - Particular : PR" Then

                Dim pRequestor = context.Request("pRequestor")

                Dim json As String = Me.SCM080100_Get_Record_Particular_PR(pRequestor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Get Record - DTL - Particular : PR Redraw" Then

                Dim pRequestor = context.Request("pRequestor")
                Dim pPRNo = context.Request("pPRNo")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.SCM080100_Get_Record_Particular_PR_Redraw(pRequestor, pPRNo, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Add Record - DTL - Particular : PR" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Add_Record_Particular_PR(pID, pItemSrs, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Get Record - DTL - Particular : DI Redraw" Then

                Dim pRequestor = context.Request("pRequestor")
                Dim pIRNo = context.Request("pIRNo")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.SCM080100_Get_Record_Particular_DI_Redraw(pRequestor, pIRNo, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)


            ElseIf FormCode = "SCM080100" And Type = "Get Record - DTL - Particular : DI" Then

                Dim pRequestor = context.Request("pRequestor")

                Dim json As String = Me.SCM080100_Get_Record_Particular_DI(pRequestor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Add Record - DTL - Particular : DI" Then

                Dim pID = context.Request("pID")
                Dim pItemSrs = context.Request("pItemSrs")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Add_Record_Particular_DI(pID, pItemSrs, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Delete Record - DTL - Particular" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.SCM080100_Delete_Record_Particular(pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Get Record - DTL - Particular : Edit" Then

                Dim pID = context.Request("pID")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.SCM080100_Get_Record_Particular_Edit(pID, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Cancel Record" Then

                Dim pID = context.Request("pID")
                Dim pReason = context.Request("pReason")
                Dim pReasonDate = context.Request("pReasonDate")
                Dim pReversedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Cancel_Record(pID, pReason, pReasonDate, pReversedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "PR Find" Then

                Dim json As String = Me.SCM080100_Get_PR_Find()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "PR Find (Trxn)" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM080100_Get_PR_Trxn(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Trasfer Item : SR > PO" Then

                Dim json As String = Me.SCM080100_Transfer_SRPO()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Add Transfer Item : SR > PO" Then

                Dim pItemSrs = context.Request("pItemSrs")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Add_Transfer_SRPO(pItemSrs, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Trasfer Item : SR > CP" Then

                Dim json As String = Me.SCM080100_Transfer_SRCP()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Add Transfer Item : SR > CP" Then

                Dim pItemSrs = context.Request("pItemSrs")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Add_Transfer_SRCP(pItemSrs, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Cancel Item : SR" Then

                Dim json As String = Me.SCM080100_Cancel_SR()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Add Cancel Item : SR" Then

                Dim pItemSrs = context.Request("pItemSrs")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.SCM080100_Add_Cancel_SR(pItemSrs, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Preview Report" Then

                Dim pID = context.Request("pID")
                Dim pReport = context.Request("pReport")
                Dim pCategory = context.Request("pCategory")

                Dim json As String = Me.SCM080100_Preview_Report(pID, pReport, pCategory, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080100" And Type = "Stock Issuance - Preview RDLC" Then

                Dim pCategory = context.Request("pCategory")

                Dim json As String = Me.SCM080100_Preview_RDLC(pCategory, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf FormCode = "SCM080100" And Type = "Purchaser" Then

                Dim json As String = Me.SCM080100_Get_Purchaser()
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



#Region "Post"
    Function Post_Record(pRecType, pTblCode, pPostBy)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable


        If pRecType = "SI" Then

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Post_SIHdr"
            SqlCmd.Parameters.AddWithValue("@pSICode", pTblCode)
            SqlCmd.Parameters.AddWithValue("@pPostBy", pPostBy)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            'add value
            RecordList.Add(New With {.oReturn = "Success"})
            'add value

        End If


        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
#End Region


#Region "SCM080100"
    Function SCM080100_Get_Record_DTL(pTblName, pCode, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Trxn_SIHdr(TrxnType)" Then
            If pCode = "OSM Project" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_misc [A] ")
                Query.Append("where ")
                Query.Append("   [A].account = '07030004' ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Land Development" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_subdivision [A] ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Subdivision Maintenance" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_subdivision [A] ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Model House" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_house [A] ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Water Connection" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_lot [A] ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Electricity Connection" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_lot [A] ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Office Supplies" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_misc [A] ")
                Query.Append("where ")
                Query.Append("  [A].account = '62010400' ")
                Query.Append("  and [A].code in ('MN2012070011','MN2012070014','MN2012070094') ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Advances (Employee)" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_employee [A] ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Advances (Contractor)" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_vendor [A] ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Service Vehicle" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_misc [A] ")
                Query.Append("where ")
                Query.Append("  [A].account = '62040000' ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            ElseIf pCode = "Branch Marketing" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   [A].code [ID] ")
                Query.Append("   ,[A].description [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[A].description [Order2] ")
                Query.Append("from ")
                Query.Append("   sub_misc [A] ")
                Query.Append("where ")
                Query.Append("  [A].account = '62020002' ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            End If
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
    Function SCM080100_Get_Record(pTblName, pPlaceHolder)

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
    Function SCM080100_Get_SI_Location(pID)

        'get query 
        Dim Query As New StringBuilder
        If pID.ToString.Contains("PR#") Or pID.ToString.StartsWith("010") Then
            Query.Append("select ")
            Query.Append("  [A].justification [Justification] ")
            Query.Append("  ,[A].created_by [RequestedBy] ")
            Query.Append("  ,[B].dept_code [DeptCode] ")
            Query.Append("from ")
            Query.Append("  ogm_pr_hdr [A] ")
            Query.Append("  left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("where ")
            Query.Append("  [A].form_no = '" & pID & "' ")
        Else
            Query.Append("select distinct ")
            Query.Append("  [B].justification [Justification] ")
            Query.Append("  ,[B].created_by [RequestedBy] ")
            Query.Append("  ,[C].dept_code [DeptCode] ")
            Query.Append("from ")
            Query.Append("  IRDtl [A] ")
            Query.Append("  left join ogm_pr_hdr [B] on [A].PRNo = [B].form_no ")
            Query.Append("  left join employee [C] on [B].created_by = [C].emp_no ")
            Query.Append("where ")
            Query.Append("  [A].IRNo = '" & pID & "' ")
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

                    RecordList.Add(New With {
                        .Justification = DR("Justification"),
                        .RequestedBy = DR("RequestedBy"),
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
    Function SCM080100_Get_Info_DTL(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [SI].si_code [SICode] ")
        Query.Append("  ,[SI].SI ")
        Query.Append("  ,[SI].SINo ")
        Query.Append("  ,FORMAT([SI].si_date, 'MM/dd/yyyy') [SIDate] ")
        Query.Append("  ,isnull(CAST(FORMAT([SI].si_date_created, 'MM/dd/yyyy') AS NVARCHAR), '') [SIDateCreated] ")
        Query.Append("  ,isnull([SI].CECode, '') [CECode] ")
        Query.Append("  ,isnull(Trxn_CEHdr.Title, '') [Title] ")
        Query.Append("  ,isnull([SI].WCode, '') [WCode] ")
        Query.Append("  ,isnull(Mstr_Work.Description, '') [WName] ")
        Query.Append("  ,[SI].TrxnType ")
        Query.Append("  ,[SI].TrxnCode ")
        Query.Append("  ,(case	when [SI].TrxnType = 'Land Development' then [PRJ].description ")
        Query.Append("          when [SI].TrxnType = 'Model House' then [MH].description ")
        Query.Append("          when [SI].TrxnType = 'Water Connection' then [LOT].description ")
        Query.Append("          when [SI].TrxnType = 'Electricity Connection' then [LOT].description ")
        Query.Append("          when [SI].TrxnType = 'Subdivision Maintenance' then [PRJ].description ")
        Query.Append("          when [SI].TrxnType = 'Office Supplies' then [MISC].description ")
        Query.Append("          when [SI].TrxnType = 'Advances (Employee)' then [SE].description ")
        Query.Append("          when [SI].TrxnType = 'Advances (Contractor)' then [SC].description ")
        Query.Append("          when [SI].TrxnType = 'Service Vehicle' then [MISC].description ")
        Query.Append("          when [SI].TrxnType = 'Branch Marketing' then [MISC].description ")
        Query.Append("          when [SI].TrxnType = 'OSM Project' then [MISC].description ")
        Query.Append("  else '' end) [TrxnName] ")
        Query.Append("  ,[SI].SILocation ")
        Query.Append("  ,[SI].PRNo ")
        Query.Append("  ,[SI].DeptCode [DeptCode] ")
        Query.Append("  ,[SI].RequestedBy [RequestedByCode] ")
        Query.Append("  ,[SI].PRNo + ' - ' + [RQST].fullname [RequestedByName] ")
        Query.Append("  ,[SI].WhseCode ")
        Query.Append("  ,[WHSE].warehouse [WhseName] ")
        Query.Append("  ,[SI].IssuedBy [IssuedByCode] ")
        Query.Append("  ,[ISS].fullname [IssuedByName] ")
        Query.Append("  ,[SI].GP ")
        Query.Append("  ,[SI].GPNo ")
        Query.Append("  ,[SI].GPDate ")
        Query.Append("  ,[SI].GPLocation ")
        Query.Append("  ,[SI].AuthorizedBy [AuthorizedByCode] ")
        Query.Append("  ,[AUT].fullname [AuthorizedByName] ")
        Query.Append("  ,[SI].created_by [CreatedBy] ")
        Query.Append("  ,[SI].created_date [CreatedDate] ")
        Query.Append("  ,[SI].UpdatedBy ")
        Query.Append("  ,FORMAT([SI].UpdatedDate,'MM/dd/yyyy hh:mm tt') [UpdatedDate] ")
        Query.Append("  ,[SI].LockedBy ")
        Query.Append("  ,FORMAT([SI].LockedDate,'MM/dd/yyyy hh:mm tt') [LockedDate] ")
        Query.Append("  ,isnull([SI].Lock, 0) [Lock] ")
        Query.Append("  ,[SI].PostedBy ")
        Query.Append("  ,FORMAT([SI].PostedDate,'MM/dd/yyyy hh:mm tt') [PostedDate] ")
        Query.Append("  ,isnull([SI].Post, 0) [Post] ")
        Query.Append("  ,[SI].rvrs_by [RvrsBy] ")
        Query.Append("  ,FORMAT([SI].rvrs_date,'MM/dd/yyyy hh:mm tt') [RvrsDate] ")
        Query.Append("  ,isnull([SI].rvrs, 0) [Rvrs] ")
        Query.Append("  ,(case when [SI].Lock = 1 and [SI].Post = 0 and [SI].rvrs = 0 then 'Locked' when [SI].Post = 1 and [SI].Lock = 1 and [SI].rvrs = 0 then 'Posted' when [SI].rvrs = 1 and [SI].Post = 1 and [SI].Lock = 1 then 'Cancelled' when [SI].Lock IS NULL and [SI].Post = 0 and [SI].rvrs = 0 then 'Unlocked' else 'New' end) [RecordStatus] ")
        Query.Append("  ,[UPD].fullname [UpdatedByName] ")
        Query.Append("  ,[LCK].fullname [LockedByName] ")
        Query.Append("  ,[PST].fullname [PostedByName] ")
        Query.Append("  ,[RVRS].fullname [CancelledByName] ")
        Query.Append("from ")
        Query.Append("  ogm_si_hdr [SI] ")
        Query.Append("  left join Trxn_CEHdr on [SI].CECode = Trxn_CEHdr.CECode ")
        Query.Append("  left join Mstr_Work on [SI].WCode = Mstr_Work.WCode ")
        Query.Append("  left join sub_subdivision [PRJ] on [SI].TrxnType in ('Land Development','Subdivision Maintenance') and [SI].TrxnCode = [PRJ].code ")
        Query.Append("  left join sub_house [MH] on [SI].TrxnType = 'Model House' and [SI].TrxnCode = [MH].code ")
        Query.Append("  left join sub_lot [LOT] on [SI].TrxnType in ('Water Connection','Electricity Connection') and [SI].TrxnCode = [LOT].code ")
        Query.Append("  left join sub_misc [MISC] on [SI].TrxnType in ('Office Supplies','Service Vehicle','Branch Marketing','OSM Project') and [SI].TrxnCode = [MISC].code ")
        Query.Append("  left join sub_employee [SE] on [SI].TrxnType = 'Advances (Employee)' and [SI].TrxnCode = [SE].code ")
        Query.Append("  left join sub_vendor [SC] on [SI].TrxnType = 'Advances (Contractor)' and [SI].TrxnCode = [SC].code ")
        Query.Append("  left join ogm_warehouse [WHSE] on [SI].WhseCode = [WHSE].w_code ")
        Query.Append("  left join employee [RQST] on [SI].RequestedBy = [RQST].emp_no ")
        Query.Append("  left join employee [ISS] on [SI].IssuedBy = [ISS].emp_no ")
        Query.Append("  left join employee [AUT] on [SI].AuthorizedBy = [AUT].emp_no ")
        Query.Append("  left join employee [UPD] on [SI].UpdatedBy = [UPD].emp_no ")
        Query.Append("  left join employee [LCK] on [SI].LockedBy = [LCK].emp_no ")
        Query.Append("  left join employee [PST] on [SI].PostedBy = [PST].emp_no ")
        Query.Append("  left join employee [RVRS] on [SI].rvrs_by = [RVRS].emp_no ")
        Query.Append("where ")
        Query.Append("  [SI].si_code = '" & pID & "' ")
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
                        .SICode = DR("SICode"),
                        .SI = IIf(DR("SI") = 1, True, False),
                        .SINo = DR("SINo"),
                        .SIDate = DR("SIDate"),
                        .SIDateCreated = DR("SIDateCreated"),
                        .CECode = DR("CECode"),
                        .Title = DR("Title"),
                        .WCode = DR("WCode"),
                        .WName = DR("WName"),
                        .TrxnType = DR("TrxnType"),
                        .TrxnCode = DR("TrxnCode"),
                        .TrxnName = DR("TrxnName"),
                        .SILocation = DR("SILocation"),
                        .PRNo = DR("PRNo"),
                        .DeptCode = DR("DeptCode"),
                        .RequestedByCode = DR("RequestedByCode"),
                        .RequestedByName = DR("RequestedByName"),
                        .WhseCode = DR("WhseCode"),
                        .WhseName = DR("WhseName"),
                        .IssuedByCode = DR("IssuedByCode"),
                        .IssuedByName = DR("IssuedByName"),
                        .GP = IIf(DR("GP") = 1, True, False),
                        .GPNo = DR("GPNo"),
                        .GPLocation = DR("GPLocation"),
                        .AuthorizedByCode = DR("AuthorizedByCode"),
                        .AuthorizedByName = DR("AuthorizedByName"),
                        .CreatedBy = DR("CreatedBy"),
                        .CreatedDate = DR("CreatedDate"),
                        .UpdatedBy = DR("UpdatedBy"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedBy = DR("LockedBy"),
                        .LockedDate = DR("LockedDate"),
                        .Lock = DR("Lock"),
                        .PostedBy = DR("PostedBy"),
                        .PostedDate = DR("PostedDate"),
                        .Post = DR("Post"),
                        .ReversedBy = DR("RvrsBy"),
                        .ReversedDate = DR("RvrsDate"),
                        .Rvrs = DR("Rvrs"),
                        .RecordStatus = DR("RecordStatus"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .LockedByName = DR("LockedByName"),
                        .PostedByName = DR("PostedByName"),
                        .CancelledByName = DR("CancelledByName")
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
    Function SCM080100_Add_Record(pSI, pSINo, pSIDate, pSIDateCreated, pCECode, pWCode, pTrxnType, pTrxnCode, pPRNo, pRequestedBy, pWhseCode, pIssuedBy, pSILocation, pGP, pGPNo, pGPDate, pAuthorizedBy, pGPLocation, pCreatedBy, pUpdatedBy)

        'insert
        Dim Query As New StringBuilder
        Query.Append("declare @DeptCode nvarchar(13) = (select dept_code from employee where emp_no = '" & pRequestedBy & "') ")
        Query.Append("declare @ID nvarchar(13) ")
        Query.Append("exec New_Code 'Trxn_SIHdr','MN',@ID output ")
        Query.Append("INSERT INTO ogm_si_hdr ")
        Query.Append("  (si_code ")
        Query.Append("  ,SI ")
        Query.Append("  ,SINo ")
        Query.Append("  ,si_date ")
        Query.Append("  ,si_date_created ")
        Query.Append("  ,CECode ")
        Query.Append("  ,WCode ")
        Query.Append("  ,TrxnType ")
        Query.Append("  ,TrxnCode ")
        Query.Append("  ,PRNo ")
        Query.Append("  ,RequestedBy ")
        Query.Append("  ,DeptCode ")
        Query.Append("  ,WhseCode ")
        Query.Append("  ,IssuedBy ")
        Query.Append("  ,SILocation ")
        Query.Append("  ,GP ")
        Query.Append("  ,GPNo ")
        Query.Append("  ,GPDate ")
        Query.Append("  ,AuthorizedBy ")
        Query.Append("  ,GPLocation ")
        Query.Append("  ,created_by ")
        Query.Append("  ,created_date ")
        Query.Append("  ,UpdatedBy ")
        Query.Append("  ,UpdatedDate ")
        Query.Append("  ,Lock ")
        Query.Append("  ,Post ")
        Query.Append("  ,rvrs) ")
        Query.Append("VALUES ")
        Query.Append("  (@ID ")
        Query.Append("  ,'" & IIf(pSI = True, 1, 0) & "' ")
        Query.Append("  ,'" & pSINo & "' ")
        If pSIDate = "" Then
            Query.Append("  ,NULL ")
        Else
            Query.Append("  ,'" & pSIDate & "' ")
        End If
        Query.Append("  ,'" & pSIDateCreated & "' ")
        Query.Append("  ,'" & pCECode & "' ")
        Query.Append("  ,'" & pWCode & "' ")
        Query.Append("  ,'" & pTrxnType & "' ")
        Query.Append("  ,'" & pTrxnCode & "' ")
        Query.Append("  ,'" & pPRNo & "' ")
        Query.Append("  ,'" & pRequestedBy & "' ")
        Query.Append("  ,@DeptCode ")
        Query.Append("  ,'" & pWhseCode & "' ")
        Query.Append("  ,'" & pIssuedBy & "' ")
        Query.Append("  ,'" & pSILocation.ToString.Replace("'", "''") & "' ")
        Query.Append("  ,'" & IIf(pGP = True, 1, 0) & "' ")
        Query.Append("  ,'" & pGPNo & "' ")
        If pGPDate = "" Then
            Query.Append("  ,NULL ")
        Else
            Query.Append("  ,'" & pGPDate & "' ")
        End If
        Query.Append("  ,'" & pAuthorizedBy & "' ")
        Query.Append("  ,'" & pGPLocation.ToString.Replace("'", "''") & "' ")
        Query.Append("  ,'" & pCreatedBy & "' ")
        Query.Append("  ,GETDATE() ")
        Query.Append("  ,'" & pUpdatedBy & "' ")
        Query.Append("  ,GETDATE() ")
        Query.Append("  ,0 ")
        Query.Append("  ,0 ")
        Query.Append("  ,0) ")
        Query.Append("select @ID [oID] ")
        'insert

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
    Function SCM080100_Edit_Record(pID, pSINo, pSI, pSIDate, pSICreatedDate, pCECode, pWCode, pTrxnType, pTrxnCode, pPRNo, pRequestedBy, pDeptCode, pWhseCode, pIssuedBy, pSILocation, pGP, pGPNo, pGPDate, pAuthorizedBy, pGPLocation, pUpdatedBy)

        'query
        Dim Query As New StringBuilder
        Query.Append("UPDATE ogm_si_hdr SET ")
        Query.Append("  SI = " & IIf(pSI = True, 1, 0) & " ")
        Query.Append("  ,SINo = '" & pSINo & "' ")
        If pSIDate = "" Then
            Query.Append("  ,si_date = NULL ")
        Else
            Query.Append("  ,si_date = '" & pSIDate & "' ")
        End If
        Query.Append("  ,si_date_created = '" & pSICreatedDate & "' ")
        Query.Append("  ,CECode = '" & pCECode & "' ")
        Query.Append("  ,WCode = '" & pWCode & "' ")
        Query.Append("  ,TrxnType = '" & pTrxnType & "' ")
        Query.Append("  ,TrxnCode = '" & pTrxnCode & "' ")
        Query.Append("  ,PRNo = '" & pPRNo & "' ")
        Query.Append("  ,RequestedBy = '" & pRequestedBy & "' ")
        Query.Append("  ,DeptCode = '" & pDeptCode & "' ")
        Query.Append("  ,WhseCode = '" & pWhseCode & "' ")
        Query.Append("  ,IssuedBy = '" & pIssuedBy & "' ")
        Query.Append("  ,SILocation = '" & pSILocation.ToString.Replace("'", "''") & "' ")
        Query.Append("  ,GP = " & IIf(pGP = True, 1, 0) & " ")
        Query.Append("  ,GPNo = '" & pGPNo & "' ")
        If pGPDate = "" Then
            Query.Append("  ,GPDate = NULL ")
        Else
            Query.Append("  ,GPDate = '" & pGPDate & "' ")
        End If
        Query.Append("  ,AuthorizedBy = '" & pAuthorizedBy & "' ")
        Query.Append("  ,GPLocation = '" & pGPLocation.ToString.Replace("'", "''") & "' ")
        Query.Append("  ,UpdatedBy = '" & pUpdatedBy & "' ")
        Query.Append("  ,UpdatedDate = GETDATE() ")
        Query.Append("WHERE ")
        Query.Append("  si_code = '" & pID & "' ")
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
    Function SCM080100_Get_Particular(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  0 [Check] ")
        Query.Append("  ,SINo ")
        Query.Append("  ,SIDate ")
        Query.Append("  ,RequestedByCode ")
        Query.Append("  ,RequestedByName ")
        Query.Append("  ,DeptCode ")
        Query.Append("  ,DeptName ")
        Query.Append("  ,WhseCode ")
        Query.Append("  ,WhseName ")
        Query.Append("  ,IssuedByCode ")
        Query.Append("  ,IssuedByName ")
        Query.Append("  ,SILocation ")
        Query.Append("  ,GPNo ")
        Query.Append("  ,AuthorizedByCode ")
        Query.Append("  ,AuthorizedByName ")
        Query.Append("  ,GPLocation ")
        Query.Append("  ,SICode ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,Type ")
        Query.Append("  ,ItemCode ")
        Query.Append("  ,ItemName ")
        Query.Append("  ,UMCode ")
        Query.Append("  ,UMName ")
        Query.Append("  ,qty ")
        Query.Append("  ,Cost ")
        Query.Append("  ,Total ")
        Query.Append("  ,remarks ")
        Query.Append("  ,PRCode ")
        Query.Append("  ,PRNo ")
        Query.Append("  ,PRSeqNo ")
        Query.Append("  ,PRItem ")
        Query.Append("  ,PRUnit ")
        Query.Append("  ,PRQty ")
        Query.Append("  ,CreatedBy ")
        Query.Append("  ,CreatedDate ")
        Query.Append("  ,UpdatedBy ")
        Query.Append("  ,UpdatedDate ")
        Query.Append("from ")
        Query.Append("  SIDtl ")
        Query.Append("where ")
        Query.Append("  SICode = '" & pID & "' ")
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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn010201Delete('" & DR("SICode") & "', '" & DR("SeqNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn010201Edit('" & DR("SICode") & "', '" & DR("SeqNo") & "', '" & DR("Type") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("SICode") & DR("SeqNo"),
                        .Action = Action.ToString,
                        .No = DR("SeqNo"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("qty"),
                        .UMName = DR("UMName"),
                        .Remarks = DR("remarks"),
                        .PRNo = "<span class='text-primary pointer' onclick=""fn010101_SCM03RPT00('" & DR("PRNo") & "'); return false;"">" & DR("PRNo") & "</span>",
                        .PRSeqNo = DR("PRSeqNo"),
                        .PRItem = DR("PRItem"),
                        .PRQty = DR("PRQty"),
                        .PRUnit = DR("PRUnit"),
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
    Function SCM080100_Get_Record_Particular_Redraw(pID, pSeqNo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  0 [Check] ")
        Query.Append("  ,SINo ")
        Query.Append("  ,SIDate ")
        Query.Append("  ,RequestedByCode ")
        Query.Append("  ,RequestedByName ")
        Query.Append("  ,DeptCode ")
        Query.Append("  ,DeptName ")
        Query.Append("  ,WhseCode ")
        Query.Append("  ,WhseName ")
        Query.Append("  ,IssuedByCode ")
        Query.Append("  ,IssuedByName ")
        Query.Append("  ,SILocation ")
        Query.Append("  ,GPNo ")
        Query.Append("  ,AuthorizedByCode ")
        Query.Append("  ,AuthorizedByName ")
        Query.Append("  ,GPLocation ")
        Query.Append("  ,SICode ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,ItemCode ")
        Query.Append("  ,ItemName ")
        Query.Append("  ,UMCode ")
        Query.Append("  ,UMName ")
        Query.Append("  ,qty ")
        Query.Append("  ,Cost ")
        Query.Append("  ,Total ")
        Query.Append("  ,remarks ")
        Query.Append("  ,ISNULL(PRCode, '') [PRCode] ")
        Query.Append("  ,ISNULL(PRNo, '') [PRNo] ")
        Query.Append("  ,ISNULL(CAST(PRSeqNo AS NVARCHAR), '') [PRSeqNo] ")
        Query.Append("  ,ISNULL(PRItem, '') [PRItem] ")
        Query.Append("  ,ISNULL(PRUnit, '') [PRUnit] ")
        Query.Append("  ,ISNULL(CAST(PRQty AS NVARCHAR), '') [PRQty] ")
        Query.Append("  ,CreatedBy ")
        Query.Append("  ,CreatedDate ")
        Query.Append("  ,UpdatedBy ")
        Query.Append("  ,UpdatedDate ")
        Query.Append("from ")
        Query.Append("  SIDtl ")
        Query.Append("where ")
        Query.Append("  SICode = '" & pID & "' ")
        Query.Append("  AND SeqNo = '" & pSeqNo & "' ")
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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn010201Delete('" & DR("SICode") & "', '" & DR("SeqNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn010201Edit('" & DR("SICode") & "', '" & DR("SeqNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    Dim PRNo As New StringBuilder
                    If DR("PRNo") <> "" Then
                        PRNo.Append("<span class='text-primary pointer' onclick=""fn010101_SCM03RPT01('" & DR("PRNo") & "'); return false;"">" & DR("PRNo") & "</span>")
                    End If

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("SICode") & DR("SeqNo"),
                        .Action = Action.ToString,
                        .No = DR("SeqNo"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("qty"),
                        .UMName = DR("UMName"),
                        .Remarks = DR("remarks"),
                        .PRNo = PRNo.ToString,
                        .PRSeqNo = DR("PRSeqNo"),
                        .PRItem = DR("PRItem"),
                        .PRQty = DR("PRQty"),
                        .PRUnit = DR("PRUnit"),
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
    Function SCM080100_Get_Item(pWarehouse)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("Get_RcrdList_WhseItem")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pYear", Date.Now.Year)
                Cmd.Parameters.AddWithValue("@pPeriod", Date.Now.Month)
                Cmd.Parameters.AddWithValue("@pWhseCode", pWarehouse)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select Item' onclick=""fn010202Item('" & DR("ItemCode") & "', '" & DR("Lock") & "');return false;""><i class='las la-check fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ItemCode"),
                        .Code = DR("ItemCode"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ItemName = DR("ItemName"),
                        .UMCode = DR("UMCode"),
                        .UMName = DR("UMName"),
                        .Qty = DR("Qty"),
                        .Cost = DR("Cost"),
                        .Total = DR("Total")
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
    Function SCM080100_Get_Item_Edit(pWarehouse)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("Get_RcrdList_WhseItem")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pYear", Date.Now.Year)
                Cmd.Parameters.AddWithValue("@pPeriod", Date.Now.Month)
                Cmd.Parameters.AddWithValue("@pWhseCode", pWarehouse)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select Item' onclick=""fn010302Item('" & DR("ItemCode") & "', '" & DR("Lock") & "');return false;""><i class='las la-check fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ItemCode"),
                        .Code = DR("ItemCode"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ItemName = DR("ItemName"),
                        .UMCode = DR("UMCode"),
                        .UMName = DR("UMName"),
                        .Qty = DR("Qty"),
                        .Cost = DR("Cost"),
                        .Total = DR("Total")
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
    Function SCM080100_Get_Record_Item(pTblFrom, pItemCode, pWarehouse)

        'query
        Dim Query As New StringBuilder
        If pTblFrom = "SI" Then
            Query.Append("select ")
            Query.Append("  ItemBalance.ItemCode ")
            Query.Append("  ,ISNULL(ogm_item.Lock, 0) [Lock] ")
            Query.Append("  ,ItemBalance.ItemName ")
            Query.Append("  ,ItemBalance.UMCode ")
            Query.Append("  ,ItemBalance.UMName ")
            Query.Append("  ,ItemBalance.qty [Qty] ")
            Query.Append("  ,ISNULL(ItemBalance.Cost, 0) [Cost] ")
            Query.Append("  ,ISNULL(ItemBalance.Total, 0) [Total] ")
            Query.Append("from ")
            Query.Append("  ItemBalance ")
            Query.Append("  left join ogm_item on ItemBalance.ItemCode = ogm_item.i_code ")
            Query.Append("where ")
            Query.Append("  Year = YEAR(GETDATE()) ")
            Query.Append("  and Period = MONTH(GETDATE()) ")
            Query.Append("  and WhseCode = '" & pWarehouse & "' ")
            Query.Append("  and ItemCode = '" & pItemCode & "' ")
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
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("Qty"),
                        .Cost = DR("Cost"),
                        .UMCode = DR("UMCode"),
                        .UMName = DR("UMName")
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
    Function SCM080100_Add_Record_Particular(pID, pType, pItemCode, pQty, pUOMCode, pCost, pTotal, pRemarks, pCreatedBy, pUpdatedBy)

        'query
        Dim Query As New StringBuilder
        Query.Append("declare @pID nvarchar(13) = '" & pID & "' ")
        Query.Append("declare @pSeqNo int = (isnull((select MAX(SeqNo) from ogm_si_dtl where si_code = @pID),0) + 1) ")
        Query.Append("INSERT INTO ogm_si_dtl ")
        Query.Append("  (si_code ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,Type ")
        Query.Append("  ,item ")
        Query.Append("  ,qty ")
        Query.Append("  ,unit ")
        Query.Append("  ,unit_cost ")
        Query.Append("  ,total_cost ")
        Query.Append("  ,remarks ")
        Query.Append("  ,created_by ")
        Query.Append("  ,created_date ")
        Query.Append("  ,UpdatedBy ")
        Query.Append("  ,UpdatedDate) ")
        Query.Append("VALUES ")
        Query.Append("  (@pID ")
        Query.Append("  ,@pSeqNo ")
        Query.Append("  ,'" & pType & "' ")
        Query.Append("  ,'" & pItemCode & "' ")
        Query.Append("  ," & CDbl(pQty) & " ")
        Query.Append("  ,'" & pUOMCode & "' ")
        Query.Append("  ,'" & CDbl(pCost) & "' ")
        Query.Append("  ,'" & CDbl(pTotal) & "' ")
        Query.Append("  ,'" & pRemarks.ToString.Replace("'", "''") & "' ")
        Query.Append("  ,'" & pCreatedBy & "' ")
        Query.Append("  ,GETDATE() ")
        Query.Append("  ,'" & pUpdatedBy & "' ")
        Query.Append("  ,GETDATE() ) ")
        Query.Append("select @pID [oID], @pSeqNo [oSeqNo] ")
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

                    RecordList.Add(New With {.oID = DR("oID"), .oSeqNo = DR("oSeqNo")})

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
    Function SCM080100_Edit_Record_Particular(pID, pSeqNo, pType, pItemCode, pQty, pUOMCode, pCost, pTotal, pRemarks, pCreatedBy, pUpdatedBy)

        'query
        Dim Query As New StringBuilder
        Query.Append("declare @pID nvarchar(13) = '" & pID & "' ")
        Query.Append("declare @pSeqNo int = " & pSeqNo & " ")
        Query.Append("UPDATE ogm_si_dtl SET ")
        Query.Append("  Type = 'SI' ")
        Query.Append("  ,item = '" & pItemCode & "' ")
        Query.Append("  ,qty = " & CDbl(pQty) & " ")
        Query.Append("  ,unit = '" & pUOMCode & "' ")
        Query.Append("  ,unit_cost = " & CDbl(pCost) & " ")
        Query.Append("  ,total_cost = " & CDbl(pTotal) & " ")
        Query.Append("  ,remarks = '" & pRemarks.ToString.Replace("'", "''") & "' ")
        Query.Append("WHERE ")
        Query.Append("  si_code = @pID ")
        Query.Append("  and SeqNo = @pSeqNo ")
        Query.Append("select @pID [oID], @pSeqNo [oSeqNo] ")
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

                    RecordList.Add(New With {.oID = DR("oID"), .oSeqNo = DR("oSeqNo")})

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
    Function SCM080100_Get_Record_Particular_PR(pRequestor)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ogm_pr_hdr.form_no + LTRIM(str(ogm_pr_dtl.seq_no)) [Code] ")
        Query.Append("  ,ogm_pr_hdr.form_no [PRNo] ")
        Query.Append("  ,oop_form_hdr.date_required [DateRequired] ")
        Query.Append("  ,employee.FullName [Requestor] ")
        Query.Append("  ,ogm_pr_dtl.seq_no [SeqNo] ")
        Query.Append("  ,ogm_pr_dtl.item [Item] ")
        Query.Append("  ,ogm_pr_dtl.ForPO ")
        Query.Append("  ,ogm_pr_dtl.ForPOBalance ")
        Query.Append("  ,ogm_pr_dtl.ForPO - ogm_pr_dtl.ForPOBalance [ProcessedPO] ")
        Query.Append("  ,ogm_pr_dtl.for_sr [ForSR] ")
        Query.Append("  ,ogm_pr_dtl.ForSRBalance ")
        Query.Append("  ,ogm_pr_dtl.for_sr - ogm_pr_dtl.ForSRBalance [IssuedSR] ")
        Query.Append("  ,ogm_pr_dtl.unit [Unit] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl ")
        Query.Append("  left join ogm_pr_hdr on ogm_pr_dtl.pr_code = ogm_pr_hdr.pr_code ")
        Query.Append("  left join oop_form_hdr on ogm_pr_hdr.form_no = oop_form_hdr.f_code ")
        Query.Append("  left join employee on oop_form_hdr.created_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  oop_form_hdr.status = 'Accepted' ")
        Query.Append("  and ogm_pr_dtl.Status = '' ")
        Query.Append("  and ogm_pr_dtl.ForSRBalance > 0 ")
        Query.Append("  and oop_form_hdr.created_by = '" & pRequestor & "' ")
        Query.Append("order by ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[SeqNo] ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                Cmd.CommandTimeout = 0
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check cbxPR01020201' type='checkbox' value='" & DR("PRNo") & "' data-kt-no='" & DR("SeqNo") & "' data-kt-code='" & DR("Code") & "'/></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01020201" & DR("Code"),
                        .Action = Action.ToString,
                        .PRNo = DR("PRNo"),
                        .SeqNo = DR("SeqNo"),
                        .Item = DR("Item"),
                        .ForSR = DR("ForSR"),
                        .ForSRBalance = DR("ForSRBalance"),
                        .Issuance = "",
                        .Unit = DR("Unit")
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
    Function SCM080100_Get_Record_Particular_PR_Redraw(pRequestor, pPRNo, pSeqNo)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ogm_pr_hdr.form_no + LTRIM(str(ogm_pr_dtl.seq_no)) [Code] ")
        Query.Append("  ,ogm_pr_hdr.form_no [PRNo] ")
        Query.Append("  ,oop_form_hdr.date_required [DateRequired] ")
        Query.Append("  ,employee.FullName [Requestor] ")
        Query.Append("  ,ogm_pr_dtl.seq_no [SeqNo] ")
        Query.Append("  ,ogm_pr_dtl.item [Item] ")
        Query.Append("  ,ogm_pr_dtl.ForPO ")
        Query.Append("  ,ogm_pr_dtl.ForPOBalance ")
        Query.Append("  ,ogm_pr_dtl.ForPO - ogm_pr_dtl.ForPOBalance [ProcessedPO] ")
        Query.Append("  ,ogm_pr_dtl.for_sr [ForSR] ")
        Query.Append("  ,ogm_pr_dtl.ForSRBalance ")
        Query.Append("  ,ogm_pr_dtl.for_sr - ogm_pr_dtl.ForSRBalance [IssuedSR] ")
        Query.Append("  ,ogm_pr_dtl.unit [Unit] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl ")
        Query.Append("  left join ogm_pr_hdr on ogm_pr_dtl.pr_code = ogm_pr_hdr.pr_code ")
        Query.Append("  left join oop_form_hdr on ogm_pr_hdr.form_no = oop_form_hdr.f_code ")
        Query.Append("  left join employee on oop_form_hdr.created_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  oop_form_hdr.status = 'Accepted' ")
        Query.Append("  and ogm_pr_dtl.Status = '' ")
        Query.Append("  and ogm_pr_dtl.ForSRBalance > 0 ")
        Query.Append("  and oop_form_hdr.created_by = '" & pRequestor & "' ")
        Query.Append("  and ogm_pr_hdr.form_no = '" & pPRNo & "' ")
        Query.Append("  and ogm_pr_dtl.seq_no = '" & pSeqNo & "' ")
        Query.Append("order by ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[SeqNo] ")
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
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check cbxPR01020201' type='checkbox' value='" & DR("PRNo") & "' data-kt-no='" & DR("SeqNo") & "' data-kt-code='" & DR("Code") & "'/></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01020201" & DR("Code"),
                        .Action = Action.ToString,
                        .PRNo = DR("PRNo"),
                        .SeqNo = DR("SeqNo"),
                        .Item = DR("Item"),
                        .ForSR = DR("ForSR"),
                        .ForSRBalance = DR("ForSRBalance"),
                        .Issuance = "",
                        .Unit = DR("Unit")
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
    Function SCM080100_Add_Record_Particular_PR(pID, pItemSrs, pCreatedBy)

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
        SqlCmd.CommandText = "New_SIDtl"
        SqlCmd.Parameters.AddWithValue("@pSICode", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Add"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function SCM080100_Get_Record_Particular_DI_Redraw(pRequestor, pRRNo, pSeqNo)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  IRDtl.IRNo + LTRIM(str(IRDtl.SeqNo)) [Code] ")
        Query.Append("  ,IRDtl.IRNo [IRNo] ")
        Query.Append("  ,oop_form_hdr.date_required [DateRequired] ")
        Query.Append("  ,employee.FullName [Requestor] ")
        Query.Append("  ,IRDtl.SeqNo ")
        Query.Append("  ,IRDtl.ItemName [Item] ")
        Query.Append("  ,IRDtl.UMInit [Unit] ")
        Query.Append("  ,IRDtl.ForSI [ForGP] ")
        Query.Append("  ,IRDtl.ForSIBalance [ForGPBalance] ")
        Query.Append("  ,IRDtl.ForSI - IRDtl.ForSIBalance [ProcessedGP] ")
        Query.Append("from ")
        Query.Append("  IRDtl ")
        Query.Append("  left join ogm_por_hdr on IRDtl.IRCode = ogm_por_hdr.r_code ")
        Query.Append("  left join oop_form_hdr on IRDtl.PRNo = oop_form_hdr.f_code ")
        Query.Append("  left join employee on oop_form_hdr.created_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  ogm_por_hdr.Post = 1 ")
        Query.Append("  and ogm_por_hdr.rvrs = 0 ")
        Query.Append("  and IRDtl.Type = 'DI' ")
        Query.Append("  and IRDtl.ForSIBalance > 0 ")
        Query.Append("  and oop_form_hdr.created_by = '" & pRequestor & "' ")
        Query.Append("  and IRDtl.IRNo = '" & pRRNo & "' ")
        Query.Append("  and IRDtl.SeqNo = '" & pSeqNo & "' ")

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
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check cbxDI01020202' type='checkbox' value='" & DR("IRNo") & "' data-kt-no='" & DR("SeqNo") & "' data-kt-code='" & DR("Code") & "'/></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01020202" & DR("Code"),
                        .Action = Action.ToString,
                        .IRNo = DR("IRNo"),
                        .SeqNo = DR("SeqNo"),
                        .Item = DR("Item"),
                        .ForGP = DR("ForGP"),
                        .ForGPBalance = DR("ForGPBalance"),
                        .Issuance = "",
                        .Unit = DR("Unit")
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
    Function SCM080100_Get_Record_Particular_DI(pRequestor)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  IRDtl.IRNo + LTRIM(str(IRDtl.SeqNo)) [Code] ")
        Query.Append("  ,IRDtl.IRNo [IRNo] ")
        Query.Append("  ,oop_form_hdr.date_required [DateRequired] ")
        Query.Append("  ,employee.FullName [Requestor] ")
        Query.Append("  ,IRDtl.SeqNo ")
        Query.Append("  ,IRDtl.ItemName [Item] ")
        Query.Append("  ,IRDtl.UMInit [Unit] ")
        Query.Append("  ,IRDtl.ForSI [ForGP] ")
        Query.Append("  ,IRDtl.ForSIBalance [ForGPBalance] ")
        Query.Append("  ,IRDtl.ForSI - IRDtl.ForSIBalance [ProcessedGP] ")
        Query.Append("from ")
        Query.Append("  IRDtl ")
        Query.Append("  left join ogm_por_hdr on IRDtl.IRCode = ogm_por_hdr.r_code ")
        Query.Append("  left join oop_form_hdr on IRDtl.PRNo = oop_form_hdr.f_code ")
        Query.Append("  left join employee on oop_form_hdr.created_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  ogm_por_hdr.Post = 1 ")
        Query.Append("  and ogm_por_hdr.rvrs = 0 ")
        Query.Append("  and IRDtl.Type = 'DI' ")
        Query.Append("  and IRDtl.ForSIBalance > 0 ")
        Query.Append("  and oop_form_hdr.created_by = '" & pRequestor & "' ")
        'Query.Append("  and datediff(day,ogm_por_hdr.PostedDate,getdate()) between 0 and 7 ")
        Query.Append("  and ogm_por_hdr.PostedDate BETWEEN '2025-03-01' AND '2025-03-30' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                Cmd.CommandTimeout = 0
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check cbxDI01020202' type='checkbox' value='" & DR("IRNo") & "' data-kt-no='" & DR("SeqNo") & "' data-kt-code='" & DR("Code") & "'/></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01020202" & DR("Code"),
                        .Action = Action.ToString,
                        .IRNo = DR("IRNo"),
                        .SeqNo = DR("SeqNo"),
                        .Item = DR("Item"),
                        .ForGP = DR("ForGP"),
                        .ForGPBalance = DR("ForGPBalance"),
                        .Issuance = "",
                        .Unit = DR("Unit")
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
    Function SCM080100_Add_Record_Particular_DI(pID, pItemSrs, pCreatedBy)

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
        SqlCmd.CommandText = "New_SIDtlGP"
        SqlCmd.Parameters.AddWithValue("@pSICode", pID)
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Add"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function SCM080100_Delete_Record_Particular(pID, pSeqNo)

        'update
        Dim Query As New StringBuilder
        Query.Append("declare @SICode nvarchar(13) = '" & pID & "' ")
        Query.Append("declare @SeqNo int = " & pSeqNo & " ")
        Query.Append("DELETE FROM ogm_si_dtl ")
        Query.Append("WHERE ")
        Query.Append("  si_code = @SICode ")
        Query.Append("  and SeqNo = @SeqNo ")
        Query.Append("select @SICode [oID], @SeqNo [oSeqNo] ")
        'update

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

                    RecordList.Add(New With {.oID = DR("oID"), .oSeqNo = DR("oSeqNo")})

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
    Function SCM080100_Get_Record_Particular_Edit(pID, pSeqNo)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  SINo ")
        Query.Append("  ,SIDate ")
        Query.Append("  ,RequestedByCode ")
        Query.Append("  ,RequestedByName ")
        Query.Append("  ,DeptCode ")
        Query.Append("  ,DeptName ")
        Query.Append("  ,WhseCode ")
        Query.Append("  ,WhseName ")
        Query.Append("  ,IssuedByCode ")
        Query.Append("  ,IssuedByName ")
        Query.Append("  ,SILocation ")
        Query.Append("  ,GPNo ")
        Query.Append("  ,AuthorizedByCode ")
        Query.Append("  ,AuthorizedByName ")
        Query.Append("  ,GPLocation ")
        Query.Append("  ,SICode ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,Type ")
        Query.Append("  ,ISNULL(ItemCode, '') [ItemCode] ")
        Query.Append("  ,ISNULL(ItemName, '') [ItemName] ")
        Query.Append("  ,ISNULL(UMCode, '') [UMCode] ")
        Query.Append("  ,ISNULL(UMName, '') [UMName] ")
        Query.Append("  ,qty ")
        Query.Append("  ,Cost ")
        Query.Append("  ,Total ")
        Query.Append("  ,remarks ")
        Query.Append("  ,PRCode ")
        Query.Append("  ,PRNo ")
        Query.Append("  ,PRSeqNo ")
        Query.Append("  ,PRItem ")
        Query.Append("  ,PRUnit ")
        Query.Append("  ,PRQty ")
        Query.Append("  ,CreatedBy ")
        Query.Append("  ,CreatedDate ")
        Query.Append("  ,UpdatedBy ")
        Query.Append("  ,UpdatedDate ")
        Query.Append("from ")
        Query.Append("  SIDtl ")
        Query.Append("where ")
        Query.Append("  SICode = '" & pID & "' ")
        Query.Append("  and SeqNo = '" & pSeqNo & "' ")
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
                        .ItemCode = DR("ItemCode"),
                        .ItemName = DR("ItemName"),
                        .Qty = DR("qty"),
                        .UMCode = DR("UMCode"),
                        .UMName = DR("UMName"),
                        .Cost = DR("Cost"),
                        .Total = DR("Total"),
                        .Remarks = DR("remarks"),
                        .PRNo = DR("PRNo"),
                        .PRSeqNo = DR("PRSeqNo"),
                        .PRItem = DR("PRItem"),
                        .PRQty = DR("PRQty"),
                        .PRUnit = DR("PRUnit")
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
    Function SCM080100_Cancel_Record(pID, pReason, pReasonDate, pReversedBy)

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
        SqlCmd.CommandText = "Rvrs_SIHdr"
        SqlCmd.Parameters.AddWithValue("@pSICode", pID)
        SqlCmd.Parameters.AddWithValue("@pReversedRemarks", pReason.ToString.Replace("'", "''"))
        SqlCmd.Parameters.AddWithValue("@pReversedBy", pReversedBy)
        SqlCmd.Parameters.AddWithValue("@pReversedDate", pReasonDate)
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
    Function SCM080100_Get_PR_Find()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [PR].form_no [PRNo] ")
        Query.Append("  ,(case when [FM].Status = 'Accepted' then 'Approved' when [FM].Status = 'Cancelled' then 'Cancelled' else 'On-Going' end) [Status] ")
        Query.Append("  ,Format([PR].rq_date, 'MM/dd/yyyy') [PRDate] ")
        Query.Append("  ,[PR].PurchaseType ")
        Query.Append("  ,[PR].Justification [Project] ")
        Query.Append("  ,[PR].Remarks ")
        Query.Append("  ,[EM].FullName [Requestor] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_hdr [PR] ")
        Query.Append("  left join employee [EM] on [PR].created_by = [EM].emp_no ")
        Query.Append("  left join oop_form_hdr [FM] on [PR].form_no = [FM].f_code ")
        Query.Append("order by ")
        Query.Append("  [PR].form_no ")
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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View Record' onclick=""fn01010201View('" & DR("PRNo") & "');return false;""><i class='las la-search fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID010102" & DR("PRNo"),
                        .Action = Action.ToString,
                        .PRNo = DR("PRNo"),
                        .Status = DR("Status"),
                        .DateRequired = DR("PRDate"),
                        .PurchaseType = DR("PurchaseType"),
                        .Project = DR("Project"),
                        .Remarks = DR("Remarks"),
                        .Requestor = DR("Requestor")
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
    Function SCM080100_Get_PR_Trxn(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @PRNo nvarchar(13) = '" & pID & "' ")
        Query.Append("	select distinct ")
        Query.Append("	1 [SeqNo] ")
        Query.Append("	,'PR' [Type] ")
        Query.Append("	,[PR].pr_code [Code] ")
        Query.Append("	,[PR].form_no [No] ")
        Query.Append("	,Format([PR].pr_Date, 'MM/dd/yyyy') [Date] ")
        Query.Append("	,(case when [FM].Status = 'Accepted' then 1 else 0 end) [Post] ")
        Query.Append("	,(case when [FM].Status = 'Cancelled' then 1 else 0 end) [Rvrs] ")
        Query.Append("	,[EM].FullName [PreparedBy] ")
        Query.Append("from ")
        Query.Append("	ogm_pr_hdr [PR] ")
        Query.Append("	left join employee [EM] on [PR].created_by = [EM].emp_no ")
        Query.Append("	left join oop_form_hdr [FM] on [PR].form_no = [FM].f_code ")
        Query.Append("where ")
        Query.Append("	[PR].form_no = @PRNo ")
        Query.Append("union ")
        Query.Append("select distinct ")
        Query.Append("	2 [SeqNo] ")
        Query.Append("	,'PO' [Type] ")
        Query.Append("	,[PO].POCode [Code] ")
        Query.Append("	,[PO].PONo [No] ")
        Query.Append("	,Format([PO].PODate, 'MM/dd/yyyy') [Date] ")
        Query.Append("	,[PO].Post ")
        Query.Append("	,[PO].Rvrs ")
        Query.Append("	,[EM].FullName [PreparedBy] ")
        Query.Append("from ")
        Query.Append("	PODtl [PO] ")
        Query.Append("	left join employee [EM] on [PO].UpdateBy = [EM].emp_no ")
        Query.Append("where ")
        Query.Append("	[PO].PRNo = @PRNo ")
        Query.Append("union ")
        Query.Append("select distinct ")
        Query.Append("	3 [SeqNo] ")
        Query.Append("	,'SI' [Type] ")
        Query.Append("	,[SI].SICode [Code] ")
        Query.Append("	,[SI].SINo [No] ")
        Query.Append("	,Format([SI].SIDate, 'MM/dd/yyyy') [Date] ")
        Query.Append("	,[SI].Post ")
        Query.Append("	,[SI].Cancelled [Rvrs] ")
        Query.Append("	,[EM].FullName [PreparedBy] ")
        Query.Append("from ")
        Query.Append("	SIDtl [SI] ")
        Query.Append("	left join employee [EM] on [SI].UpdatedBy = [EM].emp_no ")
        Query.Append("where ")
        Query.Append("	[SI].PRNo = @PRNo ")
        Query.Append("union ")
        Query.Append("select distinct ")
        Query.Append("	4 [SeqNo] ")
        Query.Append("	,'WT' [Type] ")
        Query.Append("	,[WT].WTCode [Code] ")
        Query.Append("	,[WT].WTNo [No] ")
        Query.Append("	,Format([WT].WTDate, 'MM/dd/yyyy') [Date] ")
        Query.Append("	,[WT].Post ")
        Query.Append("	,[WT].Cancelled [Rvrs] ")
        Query.Append("	,[EM].FullName [PreparedBy] ")
        Query.Append("from ")
        Query.Append("	WTDtl [WT] ")
        Query.Append("	left join employee [EM] on [WT].UpdatedBy = [EM].emp_no ")
        Query.Append("where ")
        Query.Append("	[WT].PRNo = @PRNo ")
        Query.Append("union ")
        Query.Append("select distinct ")
        Query.Append("	5 [SeqNo] ")
        Query.Append("	,'IR' [Type] ")
        Query.Append("	,[IR].IRCode [Code] ")
        Query.Append("	,[IR].IRNo [No] ")
        Query.Append("	,Format([IR].IRDate, 'MM/dd/yyyy') [Date] ")
        Query.Append("	,[IR].Post ")
        Query.Append("	,[IR].Cancelled [Rvrs] ")
        Query.Append("	,[EM].FullName [PreparedBy] ")
        Query.Append("from ")
        Query.Append("	IRDtl [IR] ")
        Query.Append("	left join employee [EM] on [IR].UpdatedBy = [EM].emp_no ")
        Query.Append("where ")
        Query.Append("	[IR].[Return] = '/' ")
        Query.Append("	and [IR].FromCode = (select top 1 [PR].pr_code from ogm_pr_hdr [PR] where [PR].form_no = @PRNo) ")
        Query.Append("order by ")
        Query.Append("	[SeqNo] ")
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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View Record' onclick=""fn010501View('" & DR("No") & "', '" & DR("Code") & "', '" & DR("Type") & "');return false;""><i class='las la-search fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID010501" & DR("Code"),
                        .Action = Action.ToString,
                        .Type = DR("Type"),
                        .No = DR("No"),
                        .Date = DR("Date"),
                        .Post = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Post") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Rvrs = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Rvrs") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .PreparedBy = DR("PreparedBy")
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
    Function SCM080100_Transfer_SRPO()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ogm_pr_hdr.form_no + ltrim(STR(ogm_pr_dtl.seq_no)) [Code] ")
        Query.Append("  ,ogm_pr_hdr.form_no [PRNo] ")
        Query.Append("  ,oop_form_hdr.date_required [DateRequired] ")
        Query.Append("  ,employee.FullName [Requestor] ")
        Query.Append("  ,ogm_pr_dtl.seq_no [SeqNo] ")
        Query.Append("  ,ogm_pr_dtl.item [Item] ")
        Query.Append("  ,ogm_pr_dtl.unit [Unit] ")
        Query.Append("  ,ogm_pr_dtl.for_sr [ForCP] ")
        Query.Append("  ,ogm_pr_dtl.ForSRBalance [ForCPBalance] ")
        Query.Append("  ,ogm_pr_dtl.BdgtDesc ")
        Query.Append("  ,ogm_pr_dtl.BdgtAmt ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl ")
        Query.Append("  left join ogm_pr_hdr on ogm_pr_dtl.pr_code = ogm_pr_hdr.pr_code ")
        Query.Append("  left join oop_form_hdr on ogm_pr_hdr.form_no = oop_form_hdr.f_code ")
        Query.Append("  left join employee on oop_form_hdr.created_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  oop_form_hdr.status = 'Accepted' ")
        Query.Append("  and ogm_pr_dtl.ForSRBalance > 0 ")
        Query.Append("  and ogm_pr_dtl.Status = '' ")
        Query.Append("order by ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[SeqNo] ")
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
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check cbx01010301SRPO' type='checkbox' value='" & DR("PRNo") & "' data-kt-no='" & DR("SeqNo") & "' data-kt-code='" & DR("Code") & "'/></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01010301" & DR("Code"),
                        .Action = Action.ToString,
                        .PRNo = DR("PRNo"),
                        .SeqNo = DR("SeqNo"),
                        .DateRequired = Format(DR("DateRequired"), "MM/dd/yyyy"),
                        .Requestor = DR("Requestor"),
                        .Item = DR("Item"),
                        .Unit = DR("Unit"),
                        .ForCP = DR("ForCP"),
                        .ForCPBalance = DR("ForCPBalance"),
                        .Transfer = "",
                        .Purchaser = ""
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
    Function SCM080100_Add_Transfer_SRPO(pItemSrs, pUpdatedBy)

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
        SqlCmd.CommandText = "Upd_PRDtl_SRtoPO"
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", pUpdatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Add"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function SCM080100_Transfer_SRCP()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ogm_pr_hdr.form_no + ltrim(STR(ogm_pr_dtl.seq_no)) [Code] ")
        Query.Append("  ,ogm_pr_hdr.form_no [PRNo] ")
        Query.Append("  ,oop_form_hdr.date_required [DateRequired] ")
        Query.Append("  ,employee.FullName [Requestor] ")
        Query.Append("  ,ogm_pr_dtl.seq_no [SeqNo] ")
        Query.Append("  ,ogm_pr_dtl.item [Item] ")
        Query.Append("  ,ogm_pr_dtl.unit [Unit] ")
        Query.Append("  ,ogm_pr_dtl.for_sr [ForCP] ")
        Query.Append("  ,ogm_pr_dtl.ForSRBalance [ForCPBalance] ")
        Query.Append("  ,ogm_pr_dtl.BdgtDesc ")
        Query.Append("  ,ogm_pr_dtl.BdgtAmt ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl ")
        Query.Append("  left join ogm_pr_hdr on ogm_pr_dtl.pr_code = ogm_pr_hdr.pr_code ")
        Query.Append("  left join oop_form_hdr on ogm_pr_hdr.form_no = oop_form_hdr.f_code ")
        Query.Append("  left join employee on oop_form_hdr.created_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  oop_form_hdr.status = 'Accepted' ")
        Query.Append("  and ogm_pr_dtl.ForSRBalance > 0 ")
        Query.Append("  and ogm_pr_dtl.Status = '' ")
        Query.Append("order by ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[SeqNo] ")
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
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check cbx01010401SRCP' type='checkbox' value='" & DR("PRNo") & "' data-kt-no='" & DR("SeqNo") & "' data-kt-code='" & DR("Code") & "'/></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01010401" & DR("Code"),
                        .Action = Action.ToString,
                        .PRNo = DR("PRNo"),
                        .SeqNo = DR("SeqNo"),
                        .DateRequired = Format(DR("DateRequired"), "MM/dd/yyyy"),
                        .Requestor = DR("Requestor"),
                        .Item = DR("Item"),
                        .Unit = DR("Unit"),
                        .ForCP = DR("ForCP"),
                        .ForCPBalance = DR("ForCPBalance"),
                        .Transfer = ""
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
    Function SCM080100_Add_Transfer_SRCP(pItemSrs, pUpdatedBy)

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
        SqlCmd.CommandText = "Upd_PRDtl_SRtoCP"
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", pUpdatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Add"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function SCM080100_Cancel_SR()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ogm_pr_hdr.form_no + ltrim(STR(ogm_pr_dtl.seq_no)) [Code] ")
        Query.Append("  ,ogm_pr_hdr.form_no [PRNo] ")
        Query.Append("  ,oop_form_hdr.date_required [DateRequired] ")
        Query.Append("  ,employee.FullName [Requestor] ")
        Query.Append("  ,ogm_pr_dtl.seq_no [SeqNo] ")
        Query.Append("  ,ogm_pr_dtl.item [Item] ")
        Query.Append("  ,ogm_pr_dtl.ForPO ")
        Query.Append("  ,ogm_pr_dtl.ForPOBalance ")
        Query.Append("  ,ogm_pr_dtl.ForPO - ogm_pr_dtl.ForPOBalance [ProcessedPO] ")
        Query.Append("  ,ogm_pr_dtl.for_sr [ForSR] ")
        Query.Append("  ,ogm_pr_dtl.ForSRBalance ")
        Query.Append("  ,ogm_pr_dtl.for_sr - ogm_pr_dtl.ForSRBalance [IssuedSR] ")
        Query.Append("  ,ogm_pr_dtl.unit [Unit] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl ")
        Query.Append("  left join ogm_pr_hdr on ogm_pr_dtl.pr_code = ogm_pr_hdr.pr_code ")
        Query.Append("  left join oop_form_hdr on ogm_pr_hdr.form_no = oop_form_hdr.f_code ")
        Query.Append("  left join employee on oop_form_hdr.created_by = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  oop_form_hdr.status = 'Accepted' ")
        Query.Append("  and ogm_pr_dtl.ForSRBalance > 0 ")
        Query.Append("  and ogm_pr_dtl.Status = '' ")
        Query.Append("order by ")
        Query.Append("  [PRNo] ")
        Query.Append("  ,[SeqNo] ")
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
                    Action.Append("<div class='d-flex justify-content-center form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input widget-9-check cbx01010501CancelSR' type='checkbox' value='" & DR("PRNo") & "' data-kt-no='" & DR("SeqNo") & "' data-kt-code='" & DR("Code") & "'/></div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01010501" & DR("Code"),
                        .Action = Action.ToString,
                        .PRNo = DR("PRNo"),
                        .SeqNo = DR("SeqNo"),
                        .DateRequired = Format(DR("DateRequired"), "MM/dd/yyyy"),
                        .Requestor = DR("Requestor"),
                        .Item = DR("Item"),
                        .Unit = DR("Unit"),
                        .ForSR = DR("ForSR"),
                        .ForSRBalance = DR("ForSRBalance"),
                        .Cancel = ""
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
    Function SCM080100_Add_Cancel_SR(pItemSrs, pUpdatedBy)

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
        SqlCmd.CommandText = "Rvrs_SRDtl"
        SqlCmd.Parameters.AddWithValue("@pItemSrs", pItemSrs)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", pUpdatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Add"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function
    Function SCM080100_Preview_Report(pID As String, pReport As String, pCategory As String, context As HttpContext)

        If pReport = "PR" Then

            If pCategory = "PR Printout" Then

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
                    result("status") = "error"
                    result("message") = ex.Message
                End Try

                Return New JavaScriptSerializer().Serialize(result)

            End If

        ElseIf pReport = "MIS" Then

            If pCategory = "OSM Project" Then

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

                    ' Copy template report
                    File.Copy(context.Server.MapPath("~/Assets/Report/RPTMIS001.rpt"), Path.Combine(reportFolderPath, "RPTMIS001.rpt"), True)

                    ' Load and configure report
                    Dim RptDoc As New ReportDocument()
                    RptDoc.Load(Path.Combine(reportFolderPath, "RPTMIS001.rpt"))

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
                    RptDoc.SetParameterValue("@pSICode", pID)

                    ' Export to PDF
                    Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                    Dim buf(CInt(stream.Length - 1)) As Byte
                    stream.Read(buf, 0, buf.Length)
                    File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTMIS001.pdf"), buf)

                    ' Cleanup
                    RptDoc.Close()
                    RptDoc.Dispose()

                    ' Encrypt path and return response
                    Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTMIS001.pdf")
                    result("status") = "success"
                    result("viewUrl") = "MNU020200?View=" & encryptedPath

                Catch ex As Exception
                    result("status") = "error"
                    result("message") = ex.Message
                End Try

                Return New JavaScriptSerializer().Serialize(result)

            Else

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

                    ' Copy template report
                    File.Copy(context.Server.MapPath("~/Assets/Report/RPTMIS002.rpt"), Path.Combine(reportFolderPath, "RPTMIS002.rpt"), True)

                    ' Load and configure report
                    Dim RptDoc As New ReportDocument()
                    RptDoc.Load(Path.Combine(reportFolderPath, "RPTMIS002.rpt"))

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
                    RptDoc.SetParameterValue("@pSICode", pID)

                    ' Export to PDF
                    Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                    Dim buf(CInt(stream.Length - 1)) As Byte
                    stream.Read(buf, 0, buf.Length)
                    File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTMIS002.pdf"), buf)

                    ' Cleanup
                    RptDoc.Close()
                    RptDoc.Dispose()

                    ' Encrypt path and return response
                    Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTMIS002.pdf")
                    result("status") = "success"
                    result("viewUrl") = "MNU020200?View=" & encryptedPath

                Catch ex As Exception
                    result("status") = "error"
                    result("message") = ex.Message
                End Try

                Return New JavaScriptSerializer().Serialize(result)

            End If

        ElseIf pReport = "GP" Then

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

                ' Copy template report
                File.Copy(context.Server.MapPath("~/Assets/Report/RPTGP001.rpt"), Path.Combine(reportFolderPath, "RPTGP001.rpt"), True)

                ' Load and configure report
                Dim RptDoc As New ReportDocument()
                RptDoc.Load(Path.Combine(reportFolderPath, "RPTGP001.rpt"))

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
                RptDoc.SetParameterValue("@pSICode", pID)

                ' Export to PDF
                Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
                Dim buf(CInt(stream.Length - 1)) As Byte
                stream.Read(buf, 0, buf.Length)
                File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPTGP001.pdf"), buf)

                ' Cleanup
                RptDoc.Close()
                RptDoc.Dispose()

                ' Encrypt path and return response
                Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & CIIS_EmpCode & "/RPTGP001.pdf")
                result("status") = "success"
                result("viewUrl") = "MNU020200?View=" & encryptedPath

            Catch ex As Exception
                result("status") = "error"
                result("message") = ex.Message
            End Try

            Return New JavaScriptSerializer().Serialize(result)

        End If

    End Function
    Function SCM080100_Preview_RDLC(pCategory As String, context As HttpContext)

        If pCategory = "For Issuance (SR - OSM)" Then

            Dim result As New Dictionary(Of String, String)

            Try
                ' Define paths
                Dim FolderPath = context.Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(FolderPath) Then
                    Directory.CreateDirectory(FolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(FolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(context.Server.MapPath("~/Assets/RDLC/SCMRT0019.rdlc"), Path.Combine(FolderPath, "SCMRT0019.rdlc"), True)

                result("status") = "success"
                result("viewUrl") = "SCMRTView?FormCode=SCMRT0019"

            Catch ex As Exception
                result("status") = "error"
                result("message") = ex.Message
            End Try

            Return New JavaScriptSerializer().Serialize(result)

        ElseIf pCategory = "For Issuance (SR - Non OSM)" Then

            Dim result As New Dictionary(Of String, String)

            Try
                ' Define paths
                Dim FolderPath = context.Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(FolderPath) Then
                    Directory.CreateDirectory(FolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(FolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(context.Server.MapPath("~/Assets/RDLC/SCMRT0020.rdlc"), Path.Combine(FolderPath, "SCMRT0020.rdlc"), True)

                result("status") = "success"
                result("viewUrl") = "SCMRTView?FormCode=SCMRT0020"

            Catch ex As Exception
                result("status") = "error"
                result("message") = ex.Message
            End Try

            Return New JavaScriptSerializer().Serialize(result)

        ElseIf pCategory = "For Issuance (DI)" Then

            Dim result As New Dictionary(Of String, String)

            Try
                ' Define paths
                Dim FolderPath = context.Server.MapPath("~/Assets/RDLC/" & CIIS_EmpCode & "/")

                ' Create report folder if it doesn't exist
                If Not Directory.Exists(FolderPath) Then
                    Directory.CreateDirectory(FolderPath)
                End If

                ' Delete existing files in the report folder
                Dim reportDir As New DirectoryInfo(FolderPath)
                For Each file In reportDir.GetFiles()
                    file.Delete()
                Next

                ' Copy template report
                File.Copy(context.Server.MapPath("~/Assets/RDLC/SCMRT0021.rdlc"), Path.Combine(FolderPath, "SCMRT0021.rdlc"), True)

                result("status") = "success"
                result("viewUrl") = "SCMRTView?FormCode=SCMRT0021"

            Catch ex As Exception
                result("status") = "error"
                result("message") = ex.Message
            End Try

            Return New JavaScriptSerializer().Serialize(result)

        End If

    End Function

    Private Function SCM080100_Get_Purchaser()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].emp_no ")
        Query.Append("  ,dbo.ProperCase([A].fullname) [Fullname] ")
        Query.Append("from ")
        Query.Append("  employee [A] ")
        Query.Append("where ")
        Query.Append("  isnull([A].PBE,0) = 0 ")
        Query.Append("  and [A].Lock = 1 ")
        Query.Append("  and [A].emp_status != 'Resigned' ")
        'get query

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
                        .ID = DR("emp_no"),
                        .Name = DR("Fullname")
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

#End Region


End Class