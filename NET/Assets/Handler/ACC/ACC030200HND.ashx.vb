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


Public Class ACC030200HND
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
            Dim json As String
            'general parameter

            If pFormCode = "ACC030200" And pType = "Get - PR - (House Construction)" Then

                json = Me.Get_List_PR(CIIS_EmpCode)

            End If

            'general - context
            context.Response.ContentType = "application/json"
            context.Response.Write(Json)
            'general - context

        Catch ex As Exception
            'nothing
        End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Function Get_List_PR(pEmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [b].form_no [ID] ")
        Query.Append("  ,[b].pr_code [PRCode] ")
        Query.Append("  ,[b].Category ")
        Query.Append("  ,[a].WBSNo ")
        Query.Append("  ,[a].item [Item] ")
        Query.Append("  ,[a].qty [OverallQty] ")
        Query.Append("  ,[d].Qty [Qty] ")
        Query.Append("  ,[a].unit [Unit] ")
        Query.Append("  ,ISNULL((select top 1 [d].approver from oop_form_dtl_appr [d] where [d].f_code = [c].f_code and ISNULL([d].status, '') = '' order by [d].seq_no DESC), '') [Approver] ")
        Query.Append("  ,[f].Title [Estimate] ")
        Query.Append("  ,[f].CENo [EstNo] ")
        Query.Append("  ,[j].abbr + ' ' + [i].description + ' B' + [h].block + ' L' + [g].lot [Project] ")
        Query.Append("from ")
        Query.Append("  ogm_pr_dtl [a] ")
        Query.Append("  left join ogm_pr_hdr [b] on [a].pr_code = [b].pr_code ")
        Query.Append("  left join oop_form_hdr [c] on [a].pr_code = [c].tbl_code ")
        Query.Append("  left join Trxn_PRDtl_HouseCon [d] on [a].pr_code = [d].PRCode and [a].WBSNo = [d].WBSNo ")
        Query.Append("  left join Trxn_CEDtl [e] on [d].CECode = [e].CECode and [d].ItemNo = [e].ItemNo and [e].WBSNo = [d].WBSNo ")
        Query.Append("  left join Trxn_CEHdr [f] on [e].CECode = [f].CECode ")
        Query.Append("  left join eng_lot [g] on [f].Subdivision = [g].l_code ")
        Query.Append("  left join eng_block [h] on [g].b_code = [h].b_code ")
        Query.Append("  left join phase [i] on [h].p_code = [i].code ")
        Query.Append("  left join subdivision [j] on [i].scode = [j].code ")
        Query.Append("where ")
        Query.Append("  [b].PurchaseType not in ('Return') ")
        Query.Append("  and [b].Purpose not like '%Return%' ")
        Query.Append("  and [b].Category in ('House Construction') ")
        Query.Append("  and [c].tbl_from = 'ogm_pr_hdr' ")
        Query.Append("  and [c].status not in ('Accepted', 'Cancelled', 'Declined', 'For Cancellation') ) [Tbl] ")
        Query.Append("where ")
        Query.Append("  [Approver] = @pEmpCode ")
        Query.Append("order by ")
        Query.Append("  [ID], [Project] ")
        'get query

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
                        .ID = DR("ID"),
                        .PRCode = DR("PRCode"),
                        .Category = DR("Category"),
                        .WBSNo = DR("WBSNo"),
                        .Item = DR("Item"),
                        .OverallQty = DR("OverallQty"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .Estimate = DR("Estimate"),
                        .EstNo = DR("EstNo"),
                        .Project = DR("Project")
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

End Class