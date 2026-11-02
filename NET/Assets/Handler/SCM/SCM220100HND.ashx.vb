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

Public Class SCM220100HND
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

            If pFormCode = "SCM220100" And pType = "Dropdown" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                json = Me.Dropdown(pTblName, pPlaceHolder)

            End If

            If pFormCode = "SCM220100" And pType = "Get - Record" Then

                Dim pID = context.Request("pID")
                json = Me.Get_Record(pID)

            ElseIf pFormCode = "SCM220100" And pType = "Find - Record" Then

                json = Me.Find_Record()

            ElseIf pFormCode = "SCM220100" And pType = "Add - Record" Then

                Dim pWarehouse = context.Request("pWarehouse")
                Dim pTerritory = context.Request("pTerritory")
                Dim pAbbr = context.Request("pAbbr")
                Dim pAddress = context.Request("pAddress")
                Dim pRcvdWhse = context.Request("pRcvdWhse")
                json = Me.Add_Record(pWarehouse, pTerritory, pAbbr, pAddress, pRcvdWhse, CIIS_EmpCode)

            ElseIf pFormCode = "SCM220100" And pType = "Edit - Record" Then

                Dim pID = context.Request("pID")
                Dim pWarehouse = context.Request("pWarehouse")
                Dim pTerritory = context.Request("pTerritory")
                Dim pAbbr = context.Request("pAbbr")
                Dim pAddress = context.Request("pAddress")
                Dim pRcvdWhse = context.Request("pRcvdWhse")
                json = Me.Edit_Record(pID, pWarehouse, pTerritory, pAbbr, pAddress, pRcvdWhse, CIIS_EmpCode)

            End If

            'general - context
            context.Response.ContentType = "application/json"
            context.Response.Write(json)
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

    Function Dropdown(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Mstr_Territory" Then
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
            Query.Append("   ISNULL([A].Lock, 0) = 1 ")
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

    Function Get_Record(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [a].w_code [ID] ")
        Query.Append("  ,[a].warehouse [Warehouse] ")
        Query.Append("  ,isnull([a].CodeInit, '') [CodeInit] ")
        Query.Append("  ,[a].division [DivCode] ")
        Query.Append("  ,[b].description [DivName] ")
        Query.Append("  ,[a].address [Address] ")
        Query.Append("  ,ISNULL([a].RcvdWhse, 0) [RcvdWhse] ")
        Query.Append("  ,[c].fullname [UpdatedByName] ")
        Query.Append("  ,FORMAT([a].updated_date,'MM/dd/yyyy hh:mm tt') [UpdatedDate] ")
        Query.Append("  ,[d].fullname [LockedByName] ")
        Query.Append("  ,FORMAT([a].lock_date,'MM/dd/yyyy hh:mm tt') [LockedDate] ")
        Query.Append("  ,(case when [a].lock = 1 then 'Locked' when [a].lock is null then 'Unlocked' else 'New' end) [RecordStatus] ")
        Query.Append("  ,isnull([a].lock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("  ogm_warehouse [a] ")
        Query.Append("  left join division [b] on [a].division = [b].div_code ")
        Query.Append("  left join employee [c] on [a].updated_by = [c].emp_no ")
        Query.Append("  left join employee [d] on [a].lock_by = [d].emp_no ")
        Query.Append("where ")
        Query.Append("  [a].w_code = @pID ")
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
                        .ID = DR("ID"),
                        .RecordStatus = DR("RecordStatus"),
                        .Warehouse = DR("Warehouse"),
                        .CodeInit = DR("CodeInit"),
                        .DivCode = DR("DivCode"),
                        .DivName = DR("DivName"),
                        .Address = DR("Address"),
                        .RcvdWhse = DR("RcvdWhse"),
                        .Lock = DR("Lock"),
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

    Function Find_Record()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  w_code [ID] ")
        Query.Append("  ,warehouse [Description] ")
        Query.Append("  ,isnull(lock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("  ogm_warehouse ")
        Query.Append("order by ")
        Query.Append("  warehouse ")
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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.location.href = 'SCM220100-DTL-" & DR("ID").ToString.Replace("-", "No") & "';return false;""><i class='las la-search fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>"
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

    Function Add_Record(pWarehouse, pTerritory, pAbbr, pAddress, pRcvdWhse, pEmpCode)

        'add
        Dim Query As New StringBuilder
        Query.Append("declare @pID nvarchar(13) ")
        Query.Append("exec cldc_live_acc.dbo.New_Code 'Mstr_Warehouse', 'MN', @pID output ")
        Query.Append("INSERT INTO ogm_warehouse ")
        Query.Append("  (w_code ")
        Query.Append("  ,warehouse ")
        Query.Append("  ,division ")
        Query.Append("  ,CodeInit ")
        Query.Append("  ,address ")
        Query.Append("  ,RcvdWhse ")
        Query.Append("  ,created_by ")
        Query.Append("  ,created_date ")
        Query.Append("  ,lock) ")
        Query.Append("VALUES ")
        Query.Append("  (@pID ")
        Query.Append("  ,@pWarehouse ")
        Query.Append("  ,@pTerritory ")
        Query.Append("  ,@pAbbr ")
        Query.Append("  ,@pAddress ")
        Query.Append("  ,@pRcvdWhse ")
        Query.Append("  ,@pEmpCode ")
        Query.Append("  ,GETDATE() ")
        Query.Append("  ,0) ")
        Query.Append("select @pID [oID] ")
        'add

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                Cmd.Parameters.AddWithValue("@pTerritory", pTerritory)
                Cmd.Parameters.AddWithValue("@pAbbr", pAbbr)
                Cmd.Parameters.AddWithValue("@pAddress", pAddress)
                Cmd.Parameters.AddWithValue("@pRcvdWhse", If(pRcvdWhse = True, 1, 0))
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
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

    Function Edit_Record(pID, pWarehouse, pTerritory, pAbbr, pAddress, pRcvdWhse, pEmpCode)

        'update
        Dim Query As New StringBuilder
        Query.Append("UPDATE ogm_warehouse SET ")
        Query.Append("  warehouse = @pWarehouse ")
        Query.Append("  ,division = @pTerritory ")
        Query.Append("  ,CodeInit = @pAbbr ")
        Query.Append("  ,address = @pAddress ")
        Query.Append("  ,RcvdWhse = @pRcvdWhse ")
        Query.Append("  ,updated_by = @pEmpCode ")
        Query.Append("  ,updated_date = GETDATE() ")
        Query.Append("where ")
        Query.Append("  w_code = @pID ")
        'update

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@pWarehouse", pWarehouse)
                Cmd.Parameters.AddWithValue("@pTerritory", pTerritory)
                Cmd.Parameters.AddWithValue("@pAbbr", pAbbr)
                Cmd.Parameters.AddWithValue("@pAddress", pAddress)
                Cmd.Parameters.AddWithValue("@pRcvdWhse", If(pRcvdWhse = True, 1, 0))
                Cmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
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

End Class