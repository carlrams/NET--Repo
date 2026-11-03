Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports Microsoft.SqlServer

Public Class HND000002
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        'user info
        CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        Try
            Dim Type = context.Request("Type")

            If Type = "MarkAllRead" Then

                'get total task
                Dim Query As New StringBuilder
                Query.Append("update Mstr_Notification set ")
                Query.Append("   SeenDate = getdate() ")
                Query.Append("   ,Seen = 1 ")
                Query.Append("where ")
                Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
                Query.Append("   and Seen = 0 ")
                'get total task

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Cmd.ExecuteNonQuery()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                Dim json As String = Me.GetTotalNotification()
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            End If

            If Type = "MarkAsRead" Then
                Dim ID = Replace(context.Request("ID"), "UnreadA", "")

                'get total task
                Dim Query As New StringBuilder
                Query.Append("update Mstr_Notification set ")
                Query.Append("   SeenDate = getdate() ")
                Query.Append("   ,Seen = 1 ")
                Query.Append("where ")
                Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
                Query.Append("   and SeqNo = " & ID & " ")
                'get total task

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Cmd.ExecuteNonQuery()
                        ConStr.Close()

                    End Using
                End Using
                'read record

                Dim json As String = Me.GetUnread(ID)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            End If

            If Type = "MarkAsUnread" Then
                Dim ID = Replace(context.Request("ID"), "ReadA", "")

                'get total task
                Dim Query As New StringBuilder
                Query.Append("update Mstr_Notification set ")
                Query.Append("   SeenDate = null ")
                Query.Append("   ,Seen = 0 ")
                Query.Append("where ")
                Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
                Query.Append("   and SeqNo = " & ID & " ")
                'get total task

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Cmd.ExecuteNonQuery()
                        ConStr.Close()

                    End Using
                End Using
                'read record

                Dim json As String = Me.GetRead(ID)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            End If

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try
    End Sub

    Private Function GetTotalNotification()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   count(1) ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 0 ")
        'get total task

        'variable
        Dim Cnt As Integer = 0
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Cnt = DR.GetInt32(0)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Return Cnt

    End Function

    Private Function GetUnread(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy ")
        Query.Append("   ,[A].Type + ' ' + [A].Description ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) ")
        Query.Append("   ,[A].CreatedDate ")
        Query.Append("   ,'ReadDiv' + ltrim(str([A].SeqNo)) ")
        Query.Append("   ,'ReadA' + ltrim(str([A].SeqNo)) ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 1 ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Link As String = DR.GetString(0)
                    Dim Image As String = DR.GetString(1)
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR.GetString(2)
                    Dim Detail As String = DR.GetString(3) & " " & IIf(Year(DR.GetDateTime(4)) < Year(Date.Now), Format(DR.GetDateTime(4), "MMM d, yyyy"), IIf(Day(DR.GetDateTime(4)) < Day(Date.Now), Format(DR.GetDateTime(4), "MMM d"), Format(DR.GetDateTime(4), "hh:mm tt")))

                    InnerHtml.Append("<div id='" & DR.GetString(5) & "' class='alert alert-dismissible d-flex flex-column flex-sm-row p-0'> ")
                    InnerHtml.Append("   <a href='" & Link & "' class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("      <div class='symbol-label'> ")
                    InnerHtml.Append("         <img alt='' class='w-100' src='" & Image & "' /> ")
                    InnerHtml.Append("      </div>")
                    InnerHtml.Append("   </a>")
                    InnerHtml.Append("   <a href='" & Link & "' class='d-flex flex-column text-light pe-0 pe-sm-10' title='" & Title & "'> ")
                    InnerHtml.Append("      <span class='text-dark fw-bolder fs-6 nowrap-240px'>" & Title & "</span> ")
                    InnerHtml.Append("      <span class='text-muted fw-bold text-muted d-block fs-7'>" & Detail & "</span> ")
                    InnerHtml.Append("   </a>")
                    InnerHtml.Append("   <button id='" & DR.GetString(6) & "' onclick='MarkAsUnread(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto' data-bs-dismiss='alert' title='Mark as unread'> ")
                    InnerHtml.Append("      <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("   </button>")
                    InnerHtml.Append("</div>")

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return InnerHtml.ToString
        'display 

    End Function

    Private Function GetRead(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy ")
        Query.Append("   ,[A].Type + ' ' + [A].Description ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) ")
        Query.Append("   ,[A].CreatedDate ")
        Query.Append("   ,'UnreadDiv' + ltrim(str([A].SeqNo)) ")
        Query.Append("   ,'UnreadA' + ltrim(str([A].SeqNo)) ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 0 ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Link As String = DR.GetString(0)
                    Dim Image As String = DR.GetString(1)
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR.GetString(2)
                    Dim Detail As String = DR.GetString(3) & " " & IIf(Year(DR.GetDateTime(4)) < Year(Date.Now), Format(DR.GetDateTime(4), "MMM d, yyyy"), IIf(Day(DR.GetDateTime(4)) < Day(Date.Now), Format(DR.GetDateTime(4), "MMM d"), Format(DR.GetDateTime(4), "hh:mm tt")))

                    InnerHtml.Append("<div id='" & DR.GetString(5) & "' class='alert alert-dismissible d-flex flex-column flex-sm-row p-0'> ")
                    InnerHtml.Append("   <a href='" & Link & "' class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("      <div class='symbol-label'> ")
                    InnerHtml.Append("         <img alt='' class='w-100' src='" & Image & "' /> ")
                    InnerHtml.Append("      </div>")
                    InnerHtml.Append("   </a>")
                    InnerHtml.Append("   <a href='" & Link & "' class='d-flex flex-column text-light pe-0 pe-sm-10' title='" & Title & "'> ")
                    InnerHtml.Append("      <span class='text-dark fw-bolder fs-6 nowrap-240px'>" & Title & "</span> ")
                    InnerHtml.Append("      <span class='text-muted fw-bold text-muted d-block fs-7'>" & Detail & "</span> ")
                    InnerHtml.Append("   </a>")
                    InnerHtml.Append("   <button id='" & DR.GetString(6) & "' onclick='MarkAsRead(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto' data-bs-dismiss='alert' title='Mark as read'> ")
                    InnerHtml.Append("      <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("   </button>")
                    InnerHtml.Append("</div>")

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return InnerHtml.ToString
        'display 

    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class