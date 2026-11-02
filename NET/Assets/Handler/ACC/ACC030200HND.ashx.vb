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
            Dim pFormCode = context.Request("pFormCode")
            Dim pFunction = context.Request("pFunction")
            Dim pType = context.Request("pType")
            Dim json As String
            'general parameter

            If pFormCode = "ACC030200" And pType = "Get - PR - (House Construction)" Then

                json = Me.Get_List_PR(CIIS_EmpCode)

            ElseIf pFormCode = "ACC030200" And pType = "Get - PR - (Others)" Then

                json = Me.Get_List_PR_others(CIIS_EmpCode)


            ElseIf pFunction = "Save-Quantity-01" Then

                Dim pPRno = context.Request("pPRno")
                Dim pNewValue = context.Request("pNewValue")
                Dim pEstCode = context.Request("pEstCode")
                Dim pEstItemNo = context.Request("pEstItemNo")

                json = Me.Save_Quantity_Record_01(pPRno, pNewValue, pEstCode, pEstItemNo)


            ElseIf pFunction = "Save-Release-01" Then

                Dim pQty = context.Request("pQty")
                Dim pCost = context.Request("pCost")
                Dim pEstCode = context.Request("pEstCode")
                Dim pEstItemNo = context.Request("pEstItemNo")

                json = Me.Save_Release_Record_01(pQty, pCost, pEstCode, pEstItemNo)

            ElseIf pFunction = "Save-Quantity-02" Then

                Dim pPRno = context.Request("pPRno")
                Dim pNewValue = context.Request("pNewValue")
                Dim pEstCode = context.Request("pEstCode")
                Dim pEstItemNo = context.Request("pEstItemNo")

                json = Me.Save_Quantity_Record_02(pPRno, pNewValue, pEstCode, pEstItemNo)


            ElseIf pFunction = "Save-Release-02" Then

                Dim pQty = context.Request("pQty")
                Dim pCost = context.Request("pCost")
                Dim pEstCode = context.Request("pEstCode")
                Dim pEstItemNo = context.Request("pEstItemNo")

                json = Me.Save_Release_Record_02(pQty, pCost, pEstCode, pEstItemNo)

            End If

            'general - context
            context.Response.ContentType = "application/json"
            context.Response.Write(Json)
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
        Query.Append("  ,[e].CECode [EstCode] ")
        Query.Append("  ,[e].ItemNo [EstItemNo] ")
        Query.Append("  ,[e].Release [Release] ")
        Query.Append("  ,[e].Cost [Cost] ")
        Query.Append("  ,0 [ForRelease] ")
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
        'Query.Append("  and [c].f_code = '0102025110024 ' ) [Tbl] ")
        'Query.Append("  and [c].status not in ('Accepted', 'Cancelled', 'Declined', 'For Cancellation') ) [Tbl] ")
        Query.Append("  and [c].status in ('Accepted') ) [Tbl] ")
        'Query.Append("where ")
        'Query.Append("  [Approver] = @pEmpCode ")
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
                        .EstCode = DR("EstCode"),
                        .EstItemNo = DR("EstItemNo"),
                        .Project = DR("Project"),
                        .Release = DR("Release"),
                        .ForRelease = DR("ForRelease"),
                        .Cost = DR("Cost")
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

    Function Get_List_PR_others(pEmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("    *  ")
        Query.Append("from  ")
        Query.Append("(select  ")
        Query.Append("    [b].form_no [ID]  ")
        Query.Append("    ,[b].pr_code [PRCode]  ")
        Query.Append("    ,[b].Category  ")
        Query.Append("    ,[a].WBSNo  ")
        Query.Append("    ,[a].item [Item]  ")
        Query.Append("    ,[a].qty [OverallQty]  ")
        Query.Append("    ,[a].Qty [Qty]  ")
        Query.Append("    ,[a].unit [Unit]  ")
        Query.Append("    ,ISNULL((select top 1 [d].approver from oop_form_dtl_appr [d] where [d].f_code = [c].f_code and ISNULL([d].status, '') = '' order by [d].seq_no DESC), '') [Approver]  ")
        Query.Append("    ,[e].Title [Estimate]  ")
        Query.Append("    ,[e].CENo [EstNo]  ")
        Query.Append("    ,[e].CECode [EstCode]  ")
        Query.Append("    ,[d].ItemNo [EstItemNo]  ")
        Query.Append("    ,[d].Cost [Cost]  ")
        Query.Append("    ,[d].Release [Release]  ")
        Query.Append("    ,0 [ForRelease] ")
        Query.Append("    ,[j].abbr + ' ' + [i].description + ' B' + [h].block + ' L' + [g].lot [Project]  ")
        Query.Append("from  ")
        Query.Append("    ogm_pr_dtl [a]  ")
        Query.Append("    left join ogm_pr_hdr [b] on [a].pr_code = [b].pr_code  ")
        Query.Append("    left join oop_form_hdr [c] on [a].pr_code = [c].tbl_code  ")
        Query.Append("    left join Trxn_CEDtl [d] on [a].ItemNo = [d].ItemNo  ")
        Query.Append("    left join Trxn_CEHdr [e] on [d].CECode = [e].CECode  ")
        Query.Append("    left join eng_lot [g] on [e].Subdivision = [g].l_code  ")
        Query.Append("    left join eng_block [h] on [g].b_code = [h].b_code  ")
        Query.Append("    left join phase [i] on [h].p_code = [i].code  ")
        Query.Append("    left join subdivision [j] on [i].scode = [j].code  ")
        Query.Append("where  ")
        Query.Append("    ISNULL([a].ItemNo, '') <> '' ")
        Query.Append("    and [b].PurchaseType not in ('Return')  ")
        Query.Append("    and [b].Purpose not like '%Return%'  ")
        Query.Append("    and [b].Category not in ('House Construction')  ")
        Query.Append("    and [c].tbl_from = 'ogm_pr_hdr' ")
        'Query.Append("    and [b].form_no = '0102025020118') [Tbl]  ")
        'Query.Append("  and [c].status not in ('Accepted', 'Cancelled', 'Declined', 'For Cancellation') ) [Tbl] ")
        Query.Append("  and [c].status in ('Accepted') ) [Tbl] ")
        'Query.Append("where ")
        'Query.Append("  [Approver] = @pEmpCode ")
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
                        .EstCode = DR("EstCode"),
                        .EstItemNo = DR("EstItemNo"),
                        .Project = DR("Project"),
                        .Release = DR("Release"),
                        .ForRelease = DR("ForRelease"),
                        .Cost = DR("Cost")
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

    Function Save_Quantity_Record_01(pPRno, pNewValue, pEstCode, pEstItemNo)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("UPD_CostQtyDSB", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pType", "HouseCon")
                    SqlCmd.Parameters.AddWithValue("@pPRno", pPRno)
                    SqlCmd.Parameters.AddWithValue("@pNewQTY", pNewValue)
                    SqlCmd.Parameters.AddWithValue("@pEstCode", pEstCode)
                    SqlCmd.Parameters.AddWithValue("@pEstItemNo", pEstItemNo)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

    Function Save_Release_Record_01(pQty, pCost, pEstCode, pEstItemNo)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("UPD_CostReleaseDSB", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pType", "HouseCon")
                    SqlCmd.Parameters.AddWithValue("@pQty", pQty)
                    SqlCmd.Parameters.AddWithValue("@pCost", pCost)
                    SqlCmd.Parameters.AddWithValue("@pEstCode", pEstCode)
                    SqlCmd.Parameters.AddWithValue("@pEstItemNo", pEstItemNo)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

    Function Save_Quantity_Record_02(pPRno, pNewValue, pEstCode, pEstItemNo)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("UPD_CostQtyDSB", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pType", "Others")
                    SqlCmd.Parameters.AddWithValue("@pPRno", pPRno)
                    SqlCmd.Parameters.AddWithValue("@pNewQTY", pNewValue)
                    SqlCmd.Parameters.AddWithValue("@pEstCode", pEstCode)
                    SqlCmd.Parameters.AddWithValue("@pEstItemNo", pEstItemNo)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using
            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

    Function Save_Release_Record_02(pQty, pCost, pEstCode, pEstItemNo)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("UPD_CostReleaseDSB", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pType", "Others")
                    SqlCmd.Parameters.AddWithValue("@pQty", pQty)
                    SqlCmd.Parameters.AddWithValue("@pCost", pCost)
                    SqlCmd.Parameters.AddWithValue("@pEstCode", pEstCode)
                    SqlCmd.Parameters.AddWithValue("@pEstItemNo", pEstItemNo)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

End Class