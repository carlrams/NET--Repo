Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services

Public Class AAD003000HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "jfevidal"
    Dim Password As String = "jfevidal"
    'connection


    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim pFunction = context.Request("pFunction")
            Dim pType = context.Request("pType")
            'general parameter

            If pType = "Get - Record" Then

                Dim json As String = Me.Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "View - Record" Then

                Dim pID = context.Request("pID")
                Dim json As String = Me.View_Record(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Update - Announcement" Then

                Dim pID = context.Request("pID")
                Dim pTitle = context.Request("pTitle")
                Dim pMessage = HttpUtility.UrlDecode(context.Request("pMessage"))

                Dim json As String = Me.Update_Announcement(pID, pTitle, pMessage)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Delete - Announcement" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Delete_Announcement(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Submit - Announcement" Then

                Dim pTitle = context.Request("pTitle")
                Dim pMessage = HttpUtility.UrlDecode(context.Request("pMessage"))

                Dim json As String = Me.Submit_Announcement(pTitle, pMessage)
                context.Response.ContentType = "text/json"
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
    Function Get_Record()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ID ")
        Query.Append("  ,Title ")
        Query.Append("  ,FORMAT(Date, 'MM/dd/yyyy') [Date] ")
        Query.Append("  ,Date [CreatedDate] ")
        Query.Append("  ,Message ")
        Query.Append("from ")
        Query.Append("  cldc_buyersportal.dbo.Mstr_BuyerAnnouncement ")
        Query.Append("order by ")
        Query.Append("  Date DESC ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        ' Execute query
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Using DR = Cmd.ExecuteReader()
                    While DR.Read()

                        Dim Action As New StringBuilder
                        Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                        Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                        Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                        Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn02View('" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                        Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn02Edit('" & DR("ID") & "', 'UPD');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                        Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn02Delete('" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                        Action.Append("   </div>")
                        Action.Append("</div>")

                        RecordList.Add(New With {
                            .Action = Action.ToString(),
                            .ID = DR("ID"),
                            .Title = DR("Title"),
                            .Date = DR("Date"),
                            .Message = DR("Message")
                    })


                    End While
                End Using
            End Using
        End Using

        'Display
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'Display

    End Function
    Function Update_Announcement(pID, pTitle, pMessage)

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
        SqlCmd.CommandText = "bp_upd_announcement"
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pTitle", pTitle)
        SqlCmd.Parameters.AddWithValue("@pMessage", pMessage)
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
    Function Delete_Announcement(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("if exists (select 1 from cldc_buyersportal.dbo.Mstr_BuyerAnnouncement where ID = @pID) ")
        Query.Append("begin ")
        Query.Append("  delete from cldc_buyersportal.dbo.Mstr_BuyerAnnouncement where ID = @pID ")
        Query.Append("end ")
        Query.Append("if exists (select 1 from cldc_buyersportal.dbo.Mstr_ReadStatus where ID = @pID) ")
        Query.Append("begin ")
        Query.Append("  delete from cldc_buyersportal.dbo.Mstr_ReadStatus where ID = @pID ")
        Query.Append("end ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        ' Execute query
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Using DR = Cmd.ExecuteReader()
                    While DR.Read()

                        RecordList.Add(New With {
                            .oReturn = "Success"
                    })


                    End While
                End Using
            End Using
        End Using

        'Display
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'Display

    End Function
    Function View_Record(pID)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  ID ")
        Query.Append("  ,Title ")
        Query.Append("  ,FORMAT(Date, 'MM/dd/yyyy') [Date] ")
        Query.Append("  ,Message ")
        Query.Append("from ")
        Query.Append("  cldc_buyersportal.dbo.Mstr_BuyerAnnouncement ")
        Query.Append("where ")
        Query.Append("  ID = @pID ")
        'get query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        ' Execute query
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Using DR = Cmd.ExecuteReader()
                    While DR.Read()

                        RecordList.Add(New With {
                            .ID = DR("ID"),
                            .Title = DR("Title"),
                            .Date = DR("Date"),
                            .Message = DR("Message")
                    })


                    End While
                End Using
            End Using
        End Using

        'Display
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'Display

    End Function
    Function Submit_Announcement(pTitle As String, pMessage As String)

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
        SqlCmd.CommandText = "bp_new_announcement"
        SqlCmd.Parameters.AddWithValue("@pTitle", pTitle)
        SqlCmd.Parameters.AddWithValue("@pMessage", pMessage)
        Dim oID As New SqlClient.SqlParameter("@oID", SqlDbType.NVarChar, 1000)
        oID.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oID)
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

End Class