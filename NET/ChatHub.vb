Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.Remoting.Contexts
Imports System.Threading.Tasks
Imports System.Web.Script.Services
Imports System.Web.Services
Imports System.Windows.Media.Media3D
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports Microsoft.Ajax.Utilities
Imports Microsoft.AspNet.SignalR
Imports Microsoft.SqlServer
Imports Microsoft.SqlServer.Server
Imports Microsoft.VisualBasic.ApplicationServices

Public Class ChatHub

    Inherits Hub

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim catalog01 As String = "cldc_contractorportal"
    Dim UserID As String = ""
    Dim Password As String = ""

#Region "Send"

    Public Sub Send(tblName As String, tblCode As String, Notify As String, Description As String, CreatedBy As String)

        'save mention
        SaveMention(tblName, tblCode, Notify, Description, CreatedBy)
        'save mention

    End Sub

    Public Sub SendRemarks(pFormCode As String, pID As String, pRemarks As String, pMention As String, pCreatedBy As String)
        SaveRemarks(pFormCode, pID, pRemarks, pMention, pCreatedBy)
    End Sub

#End Region

#Region "Mention Insert"

    Private Sub SaveMention(tblName As String, tblCode As String, Notify As String, Description As String, CreatedBy As String)
        ' For example, using ADO.NET
        Dim connectionString As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO test (TblName, TblCode, Notify, Description, CreatedBy, CreatedDate, Link, Seen) VALUES (@tblName, @tblCode, @Notify, @Description, @CreatedBy, @CreateDate, @Link, @Seen)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@tblName", tblName)
                command.Parameters.AddWithValue("@tblCode", tblCode)
                command.Parameters.AddWithValue("@Notify", Notify)
                command.Parameters.AddWithValue("@Description", Description)
                command.Parameters.AddWithValue("@CreatedBy", CreatedBy)
                command.Parameters.AddWithValue("@CreateDate", DateTime.Now)
                command.Parameters.AddWithValue("@Link", 0)
                command.Parameters.AddWithValue("@Seen", 0)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SaveRemarks(pFormCode As String, pID As String, pRemarks As String, pMention As String, pCreatedBy As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_Remarks"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
        SqlCmd.Parameters.AddWithValue("@pMention", pMention)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

    End Sub

#End Region

#Region "Employee Mention"

    Public Function GetEmployeeData() As List(Of Object)

        Dim connectionString As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password & ";"
        Dim data As New List(Of Object)()
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT emp_no,emp_no [empPic], (select top 1 data from SplitString(first_name,' ')) [fname], dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [fullname], dbo.ProperCase(JobDesc) [email]  FROM employee WHERE emp_status != 'Resigned' ORDER BY fullname ASC"
            Using command As New SqlCommand(query, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim fname As String = Convert.ToString(reader("fname"))
                        Dim name As String = Convert.ToString(reader("fullname"))
                        Dim email As String = Convert.ToString(reader("email"))
                        Dim empCode As String = Convert.ToString(reader("emp_no"))
                        Dim empPic As String = Convert.ToString(reader("empPic"))

                        If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & empPic & ".png")) = True Then
                            empPic = empPic & ".png"
                        ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & empCode & ".jpg")) = True Then
                            empPic = empPic & ".jpg"
                        Else
                            empPic = "blank.png"
                        End If

                        data.Add(New With {
                            .fname = fname,
                            .name = name,
                            .email = email,
                            .empCode = empCode,
                            .empPic = empPic
                        })
                    End While
                End Using
            End Using
        End Using

        Return data
    End Function

#End Region

#Region "Purchasing Dashoard"
    Public Function GetPurchaseOrder() As List(Of Object)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ISNULL((select count(1) from ogm_po_hdr where YEAR(created_date) = year(GETDATE())), 0) [Overall] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where Post = 1 and Rvrs = 0 and YEAR(created_date) = year(GETDATE()) and status = 'Delivered'), 0) [Delivered] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where Post = 1 and Rvrs = 0 and YEAR(created_date) = year(getdate()) and status = 'Prtl. Dlvrd.'), 0) [Partial] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where Post = 1 and Rvrs = 0 and YEAR(created_date) = year(getdate()) and status = 'Processed'), 0) [Processed] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where Post = 1 and Rvrs = 0 and YEAR(created_date) = year(getdate()) and status = 'for Printing'), 0) [Print] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where lock = 1 and Post = 0 and Rvrs = 0 and YEAR(created_date) = year(getdate()) and status = 'for Posting'), 0) [Post] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where Post = 0 and Rvrs = 0 and YEAR(created_date) = year(getdate()) and status = 'for Locking'), 0) [Lock] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where Post = 1 and Rvrs = 1 and YEAR(created_date) = year(getdate())), 0) [Cancelled] ")
        Query.Append("  ,ISNULL((select count(1) from ogm_po_hdr where lock = 0 and Post = 0 and Rvrs = 0 and YEAR(created_date) = year(getdate())), 0) [New] ")
        Query.Append("from ")
        Query.Append("  ogm_po_hdr ")
        Query.Append("where ")
        Query.Append("  YEAR(created_date) = YEAR(GETDATE()) ")
        Query.Append("  and ISNULL(lock, 0) = 1 ")
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
                    FormList.Add(New With {
                        .Overall = DR("Overall"),
                        .Delivered = DR("Delivered"),
                        .Partial = DR("Partial"),
                        .Processed = DR("Processed"),
                        .Print = DR("Print"),
                        .Post = DR("Post"),
                        .Lock = DR("Lock"),
                        .Cancelled = DR("Cancelled"),
                        .New = DR("New")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Return FormList

    End Function
    Public Function GetOverallSuppliers() As List(Of Object)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select top 20 ")
        Query.Append("  [B].vendor ")
        Query.Append("  ,COUNT(1) [TotalPO] ")
        Query.Append("from ")
        Query.Append("  ogm_po_hdr [A] ")
        Query.Append("  left join ogm_vendor [B] on [A].vendor = [B].v_code ")
        Query.Append("where ")
        Query.Append("  YEAR([A].created_date) = YEAR(GETDATE()) ")
        Query.Append("  and isnull([A].post, 0) = 1 ")
        Query.Append("  and isnull([A].Rvrs, 0) = 0 ")
        Query.Append("group by ")
        Query.Append("  [B].vendor ")
        Query.Append("order by ")
        Query.Append("  [TotalPO] DESC ")
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
                    FormList.Add(New With {
                        .Vendor = DR("Vendor").ToString(),
                        .Total = Convert.ToInt32(DR("TOtalPO"))
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Return FormList

    End Function
    Public Function GetCostPurchase() As List(Of Object)

        'get query
        Dim Query As New StringBuilder
        Query.Append("WITH Months AS ( ")
        Query.Append("  select 1 AS MonthNo, 'Jan' AS MonthName union all ")
        Query.Append("  select 2, 'Feb' union all ")
        Query.Append("  select 3, 'Mar' union all ")
        Query.Append("  select 4, 'Apr' union all ")
        Query.Append("  select 5, 'May' union all ")
        Query.Append("  select 6, 'Jun' union all ")
        Query.Append("  select 7, 'Jul' union all ")
        Query.Append("  select 8, 'Aug' union all ")
        Query.Append("  select 9, 'Sep' union all ")
        Query.Append("  select 10, 'Oct' union all ")
        Query.Append("  select 11, 'Nov' union all ")
        Query.Append("  select 12, 'Dec') ")
        Query.Append("select ")
        Query.Append("  [A].MonthNo ")
        Query.Append("  ,[A].MonthName ")
        Query.Append("  ,ISNULL(SUM(Cost), 0) [Cost] ")
        Query.Append("  ,IIF(SUM(Cost) > 0, COUNT(1), 0) [TotalPO] ")
        Query.Append("from ")
        Query.Append("  Months [A] ")
        Query.Append("  left join PODtl [B] on [A].MonthNo = MONTH([B].PODate)  ")
        Query.Append("  and YEAR([B].PODate) = YEAR(GETDATE()) ")
        Query.Append("  and [B].ItemName not like '%DISCOUNT%' ")
        Query.Append("  and [B].post = 1 ")
        Query.Append("  and [B].Rvrs = 0 ")
        Query.Append("  and [B].status not in ('Cancelled', 'for Cancellation') ")
        Query.Append("group by ")
        Query.Append("  [A].MonthNo ")
        Query.Append("  ,[A].MonthName ")
        Query.Append("order by ")
        Query.Append("  [A].MonthNo ")
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
                    FormList.Add(New With {
                        .MonthNo = DR("MonthNo"),
                        .MonthName = DR("MonthName"),
                        .Cost = DR("Cost"),
                        .TotalPO = DR("TotalPO")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Return FormList

    End Function
    Public Function GetDiscountPurchase() As List(Of Object)

        'get query
        Dim Query As New StringBuilder
        Query.Append("WITH Months AS ( ")
        Query.Append("  select 1 AS MonthNo, 'Jan' AS MonthName union all ")
        Query.Append("  select 2, 'Feb' union all ")
        Query.Append("  select 3, 'Mar' union all ")
        Query.Append("  select 4, 'Apr' union all ")
        Query.Append("  select 5, 'May' union all ")
        Query.Append("  select 6, 'Jun' union all ")
        Query.Append("  select 7, 'Jul' union all ")
        Query.Append("  select 8, 'Aug' union all ")
        Query.Append("  select 9, 'Sep' union all ")
        Query.Append("  select 10, 'Oct' union all ")
        Query.Append("  select 11, 'Nov' union all ")
        Query.Append("  select 12, 'Dec') ")
        Query.Append("select ")
        Query.Append("  [A].MonthNo ")
        Query.Append("  ,[A].MonthName ")
        Query.Append("  ,ISNULL(SUM(Cost), 0) * -1 [Cost] ")
        Query.Append("  ,IIF(SUM(Cost) * -1 > 0, COUNT(1), 0) [TotalPO] ")
        Query.Append("from ")
        Query.Append("  Months [A] ")
        Query.Append("  left join PODtl [B] on [A].MonthNo = MONTH([B].PODate)  ")
        Query.Append("  and YEAR([B].PODate) = YEAR(GETDATE()) ")
        Query.Append("  and [B].ItemName like '%DISCOUNT%' ")
        Query.Append("  and [B].post = 1 ")
        Query.Append("  and [B].Rvrs = 0 ")
        Query.Append("  and [B].status not in ('Cancelled', 'for Cancellation') ")
        Query.Append("group by ")
        Query.Append("  [A].MonthNo ")
        Query.Append("  ,[A].MonthName ")
        Query.Append("order by ")
        Query.Append("  [A].MonthNo ")
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
                    FormList.Add(New With {
                        .MonthNo = DR("MonthNo"),
                        .MonthName = DR("MonthName"),
                        .Cost = DR("Cost"),
                        .TotalPO = DR("TotalPO")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Return FormList

    End Function
    Public Sub BroadcastPurchaseOrder()
        Dim PurchaseOrder = GetPurchaseOrder()
        Dim Suppliers = GetOverallSuppliers()
        Dim CostPurcoase = GetCostPurchase()
        Dim DiscountPurchase = GetDiscountPurchase()
        Clients.All.updatePurchaseOrder(PurchaseOrder)
        Clients.All.updateSuppliers(Suppliers)
        Clients.All.updateCostPurchase(CostPurcoase)
        Clients.All.updateDiscountPurchase(DiscountPurchase)
    End Sub
#End Region

#Region "Message - Contractor"
    Public Overrides Function OnConnected() As Task
        Groups.Add(Context.ConnectionId, "Admins")
        Return MyBase.OnConnected()
    End Function

    Public Function GetMessageContractor() As List(Of Object)
        Dim connectionString As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password & ";"
        Dim data As New List(Of Object)()

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim Query As New StringBuilder
            Query.Append("SELECT ")
            Query.Append("  * ")
            Query.Append("FROM ")
            Query.Append("(SELECT DISTINCT ")
            Query.Append("  [a].SenderID, ")
            Query.Append("  [b].vendor AS [Contractor], ")
            Query.Append("  ISNULL(( ")
            Query.Append("      SELECT TOP 1 ")
            Query.Append("          CASE ")
            Query.Append("              WHEN ISNULL([c].Message, '') <> '' THEN [c].Message ")
            Query.Append("              WHEN ISNULL([c].AttachmentName, '') <> '' THEN '📎 ' + [c].AttachmentName ")
            Query.Append("              WHEN ISNULL([c].AttachmentPath, '') <> '' THEN '📎 Attachment' ")
            Query.Append("              ELSE 'No messages yet' ")
            Query.Append("          END ")
            Query.Append("      FROM cldc_contractorportal.dbo.Mstr_Conversation [c] ")
            Query.Append("      WHERE [c].SenderID = [a].SenderID ")
            Query.Append("      ORDER BY [c].CreatedDate DESC ")
            Query.Append("  ), 'No messages yet') AS [Message], ")
            Query.Append("  ISNULL((SELECT TOP 1 [c].CreatedDate FROM cldc_contractorportal.dbo.Mstr_Conversation [c] WHERE [c].SenderID = [a].SenderID ORDER BY [c].CreatedDate DESC), '') AS [CreatedDate], ")
            Query.Append("  ISNULL(( ")
            Query.Append("      SELECT COUNT(1) ")
            Query.Append("      FROM cldc_contractorportal.dbo.Mstr_Conversation [u] ")
            Query.Append("      WHERE [u].SenderID = [a].SenderID ")
            Query.Append("        AND [u].SenderType = 'Contractor' ")
            Query.Append("        AND ISNULL([u].IsRead_Admin, 0) = 0 ")
            Query.Append("  ), 0) AS [UnreadCount] ")
            Query.Append("FROM ")
            Query.Append("  cldc_contractorportal.dbo.Mstr_Conversation [a] ")
            Query.Append("  LEFT JOIN cldc_live_acc.dbo.ogm_vendor [b] ON [a].SenderID = [b].v_code ")
            Query.Append("GROUP BY ")
            Query.Append("  [a].SenderID, ")
            Query.Append("  [b].vendor) [A] ")
            Query.Append("ORDER BY ")
            Query.Append("  [CreatedDate] DESC ")

            Using command As New SqlCommand(Query.ToString(), connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim SenderID As String = Convert.ToString(reader("SenderID"))
                        Dim Contractor As String = Convert.ToString(reader("Contractor"))
                        Dim Message As String = Convert.ToString(reader("Message"))
                        Dim CreatedDate As String = Convert.ToString(reader("CreatedDate"))
                        Dim UnreadCount As Integer = Convert.ToInt32(reader("UnreadCount"))

                        data.Add(New With {
                            .SenderID = SenderID,
                            .Contractor = Contractor,
                            .Message = Message,
                            .CreatedDate = CreatedDate,
                            .UnreadCount = UnreadCount
                        })
                    End While
                End Using
            End Using
        End Using

        Return data

    End Function
    Public Sub MarkAsReadAdmin(ByVal pCode As String)
        If String.IsNullOrWhiteSpace(pCode) Then
            Return
        End If

        Dim connectionString As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password & ";"

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "UPDATE cldc_contractorportal.dbo.Mstr_Conversation SET IsRead_Admin = 1 WHERE SenderID = @pSenderID AND SenderType = 'Contractor' AND ISNULL(IsRead_Admin, 0) = 0"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@pSenderID", pCode.Trim())
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function GetMessagesByContractor(ByVal pCode As String) As List(Of Object)
        Dim connectionString As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog & ";User ID=" & UserID & ";Password=" & Password & ";"
        Dim data As New List(Of Object)()

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim Query As New StringBuilder
            Query.Append("SELECT DISTINCT ")
            Query.Append("  [a].ID, ")
            Query.Append("  [a].SeqNo, ")
            Query.Append("  [a].SenderType, ")
            Query.Append("  [a].SenderID, ")
            Query.Append("  ISNULL([a].Message, '') AS [Message], ")
            'Query.Append("  'C:/inetpub/contractor/' + [a].AttachmentPath, ")
            'Query.Append("  'C:/Users/User/Desktop/.NET/Contractor Portal/NET v2.6/NET/NET/' + [a].AttachmentPath AS [AttachmentPath], ")
            Query.Append("  [a].AttachmentPath, ")
            Query.Append("  [a].AttachmentName, ")
            Query.Append("  [a].IsRead_Contractor, ")
            Query.Append("  [a].IsRead_Admin, ")
            Query.Append("  [a].CreatedDate, ")
            Query.Append("  [b].vendor AS [Contractor] ")
            Query.Append("FROM ")
            Query.Append("  cldc_contractorportal.dbo.Mstr_Conversation [a] ")
            Query.Append("  LEFT JOIN cldc_live_Acc.dbo.ogm_vendor [b] ON [a].SenderID = [b].v_code ")
            Query.Append("WHERE ")
            Query.Append("  [a].SenderID = @pSenderID ")
            Query.Append("ORDER BY ")
            Query.Append("  [a].CreatedDate ASC ")

            Using command As New SqlCommand(Query.ToString(), connection)
                command.Parameters.AddWithValue("@pSenderID", pCode.Trim())

                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim ID As String = Convert.ToString(reader("ID"))
                        Dim SeqNo As String = Convert.ToString(reader("SeqNo"))
                        Dim SenderType As String = Convert.ToString(reader("SenderType"))
                        Dim SenderID As String = Convert.ToString(reader("SenderID"))
                        Dim Message As String = Convert.ToString(reader("Message"))
                        Dim AttachmentPath As String = Convert.ToString(reader("AttachmentPath"))
                        Dim AttachmentName As String = Convert.ToString(reader("AttachmentName"))
                        Dim IsRead_Contractor As String = Convert.ToString(reader("IsRead_Contractor"))
                        Dim IsRead_Admin As String = Convert.ToString(reader("IsRead_Admin"))
                        Dim CreatedDate As String = Convert.ToString(reader("CreatedDate"))
                        Dim Contractor As String = Convert.ToString(reader("Contractor"))

                        data.Add(New With {
                            .ID = ID,
                            .SeqNo = SeqNo,
                            .SenderType = SenderType,
                            .SenderID = SenderID,
                            .Message = Message,
                            .AttachmentPath = AttachmentPath,
                            .AttachmentName = AttachmentName,
                            .IsRead_Contractor = IsRead_Contractor,
                            .IsRead_Admin = IsRead_Admin,
                            .CreatedDate = CreatedDate,
                            .Contractor = Contractor
                        })
                    End While
                End Using
            End Using
        End Using

        Return data
    End Function

    Public Function SendAdminReply(ByVal pCode As String, ByVal pMessage As String, ByVal pAttachmentPath As String, ByVal pAttachmentName As String) As Object
        If String.IsNullOrWhiteSpace(pMessage) AndAlso String.IsNullOrWhiteSpace(pAttachmentPath) Then
            Return Nothing
        End If

        Dim connectionString As String = "Data Source=" & DataSource & ";Initial Catalog=" & catalog01 & ";User ID=" & UserID & ";Password=" & Password & ";"
        Dim newID As String = "0"
        Dim createdDateStr As String = String.Empty

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand("cp_new_message", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@pSenderType", "Admin")
                command.Parameters.AddWithValue("@pSenderID", pCode.Trim())
                command.Parameters.AddWithValue("@pMessage", If(String.IsNullOrWhiteSpace(pMessage), DBNull.Value, pMessage.Trim()))
                command.Parameters.AddWithValue("@pIsRead_Contractor", 0)
                command.Parameters.AddWithValue("@pIsRead_Admin", 1)
                command.Parameters.AddWithValue("@pAttachmentPath", If(String.IsNullOrWhiteSpace(pAttachmentPath), DBNull.Value, pAttachmentPath.Trim()))
                command.Parameters.AddWithValue("@pAttachmentName", If(String.IsNullOrWhiteSpace(pAttachmentName), DBNull.Value, pAttachmentName.Trim()))

                connection.Open()

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        newID = Convert.ToString(reader("NewID"))
                        createdDateStr = Convert.ToDateTime(reader("CreatedDate")).ToString("yyyy-MM-dd HH:mm:ss")
                    End If
                End Using
            End Using
        End Using

        Dim messageObj = New With {
            .ID = newID,
            .SenderType = "Admin",
            .SenderID = pCode.Trim(),
            .Message = If(String.IsNullOrWhiteSpace(pMessage), "", pMessage.Trim()),
            .AttachmentPath = pAttachmentPath,
            .AttachmentName = pAttachmentName,
            .IsRead_Contractor = "0",
            .IsRead_Admin = "1",
            .CreatedDate = createdDateStr
        }

        Clients.Group(pCode.Trim().ToLower()).receiveMessage(messageObj)
        Clients.Caller.receiveMessage(messageObj)
        Clients.OthersInGroup("Admins").receiveMessage(messageObj)

        Return messageObj

    End Function

#End Region

End Class
