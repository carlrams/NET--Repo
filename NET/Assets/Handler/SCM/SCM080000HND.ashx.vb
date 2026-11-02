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

Public Class SCM080000HND
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

            If FormCode = "SCM080000" And Type = "Stock Issuance - Get Record" Then

                Dim pPosted = context.Request("pPosted")
                Dim pWarehouse = context.Request("pWarehouse")

                Dim json As String = Me.SCM080000_Get_Record(pPosted, pWarehouse)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM080000" And Type = "Stock Issuance - Get Record : Redraw" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.SCM080000_Get_Record_Redraw(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf FormCode = "SCM080000" And Type = "Get Record" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Get_Record(pTblName, pPlaceHolder)
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

#Region "SCM080000"
    Function SCM080000_Get_Record(pPost, pWarehouse)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("Get_SIHdrList")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pPost", IIf(pPost = True, 1, 0))
                Cmd.Parameters.AddWithValue("@pWhseCode", pWarehouse)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('SCM080100-DTL-" & DR("SICode") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("SICode") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("SICode") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("SICode") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("SICode") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn07Post('" & DR("SICode") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-cancel' title='Cancel' onclick=""fn08Rvrs('" & DR("SICode") & "');return false;""><i class='las la-times-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("SICode"),
                        .Code = DR("SICode"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Post = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Post") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Rvrs = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Rvrs") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .SINo = "<span title='" & DR("SINo") & "'>" & DR("SINo") & "</span>",
                        .SIDate = "<span title='" & DR("SIDate") & "'>" & DR("SIDate") & "</span>",
                        .GPNo = "<span title='" & DR("GPNo") & "'>" & DR("GPNo") & "</span>",
                        .RequestedBy = "<span title='" & DR("RequestedByName") & "'>" & DR("RequestedByName") & "</span>",
                        .WhseName = "<span title='" & DR("WhseName") & "'>" & DR("WhseName") & "</span>",
                        .PreparedBy = "<span title='" & DR("UpdatedBy") & "'>" & DR("UpdatedBy") & "</span>"
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
    Function SCM080000_Get_Record_Redraw(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ogm_si_hdr.si_code [SICode] ")
        Query.Append("  ,ogm_si_hdr.SINo ")
        Query.Append("  ,ogm_si_hdr.si_date [SIDate] ")
        Query.Append("  ,ogm_si_hdr.GPNo ")
        Query.Append("  ,ogm_si_hdr.GPDate ")
        Query.Append("  ,isnull(ogm_warehouse.warehouse,'''') [WhseName] ")
        Query.Append("  ,[req].fullname [RequestedByName] ")
        Query.Append("  ,isnull(ogm_si_hdr.Lock, 0) [Lock] ")
        Query.Append("  ,isnull(ogm_si_hdr.Post, 0) [Post] ")
        Query.Append("  ,isnull(ogm_si_hdr.rvrs, 0) [Rvrs] ")
        Query.Append("  ,[upd].initialname [UpdatedBy] ")
        Query.Append("from ")
        Query.Append("  ogm_si_hdr ")
        Query.Append("  left join ogm_warehouse on ogm_si_hdr.WhseCode = ogm_warehouse.w_code ")
        Query.Append("  left join employee [req] on ogm_si_hdr.RequestedBy = [req].emp_no ")
        Query.Append("  left join employee [upd] on ogm_si_hdr.UpdatedBy = [upd].emp_no ")
        Query.Append("where ")
        Query.Append("  ogm_si_hdr.si_code = '" & pID & "' ")
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
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('SCM080100-DTL-" & DR("SICode") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("SICode") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("SICode") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("SICode") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("SICode") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-post' title='Post' onclick=""fn07Post('" & DR("SICode") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-cancel' title='Cancel' onclick=""fn08Rvrs('" & DR("SICode") & "');return false;""><i class='las la-times-circle fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("SICode"),
                        .Code = DR("SICode"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Post = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Post") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Rvrs = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Rvrs") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .SINo = "<span title='" & DR("SINo") & "'>" & DR("SINo") & "</span>",
                        .SIDate = "<span title='" & DR("SIDate") & "'>" & DR("SIDate") & "</span>",
                        .GPNo = "<span title='" & DR("GPNo") & "'>" & DR("GPNo") & "</span>",
                        .RequestedBy = "<span title='" & DR("RequestedByName") & "'>" & DR("RequestedByName") & "</span>",
                        .WhseName = "<span title='" & DR("WhseName") & "'>" & DR("WhseName") & "</span>",
                        .PreparedBy = "<span title='" & DR("UpdatedBy") & "'>" & DR("UpdatedBy") & "</span>"
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

    Function Get_Record(pTblName, pPlaceHolder)

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
        ElseIf pTblName = "Mstr_Warehouse(Receiving)" Then
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
            Query.Append("   [A].RcvdWhse = 1 ")
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
        ElseIf pTblName = "Mstr_Vehicle" Then
            Query.Append("select ")
            Query.Append("   [A].CarCode [ID] ")
            Query.Append("   ,[A].PlateNo + ' - ' + [A].CarModel [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].PlateNo + ' - ' + [A].CarModel [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_Vehicle [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Destination" Then
            Query.Append("select ")
            Query.Append("  [ID] ")
            Query.Append("  ,[Name] ")
            Query.Append("  ,[Order1] ")
            Query.Append("  ,[Order2] ")
            Query.Append("from ")
            Query.Append("(select distinct ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,[A].address [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].address [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_warehouse [A] ")
            Query.Append("union ")
            Query.Append("select distinct")
            Query.Append("  '' [ID] ")
            Query.Append("  ,[A].deliver_addr [Name] ")
            Query.Append("  ,2 [Order1] ")
            Query.Append("  ,[A].deliver_addr [Order2] ")
            Query.Append("from ")
            Query.Append("  ogm_po_hdr [A]) [TBL] ")
            Query.Append("where ")
            Query.Append("  [Name] IS NOT NULL ")
            Query.Append("  AND [Name] != '' ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_CreditTerms" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].ct_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_credit_terms [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_VAT" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].v_code [ID] ")
            Query.Append("   ,[A].vat [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].vat [Order2] ")
            Query.Append("from ")
            Query.Append("   fin_vat [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_EWT" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].ewt_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].ewt_code [Order2] ")
            Query.Append("from ")
            Query.Append("   fin_ewt [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Classification" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].ic_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   ogm_item_cat [A] ")
            Query.Append("where ")
            Query.Append("  [A].lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_OSMCodes" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].OSMCode [ID] ")
            Query.Append("   ,[A].OSMDescription [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].OSMDescription [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_OSMCodes [A] ")
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

End Class