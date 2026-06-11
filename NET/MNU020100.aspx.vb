Imports System.Data.SqlClient
Imports System.IO

Public Class MNU020100
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'load page
        If IsPostBack = False Then
            bindNotificationNew()
            bindotificationPrevious()
        End If
        'load page

    End Sub

#End Region

#Region "overview"

    Function bindNotificationNew()

        'hide
        divNotificationNew.Style("display") = "none"
        'hide

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'ReadDiv' + ltrim(str([A].SeqNo)) [ReadDiv] ")
        Query.Append("   ,'ReadA' + ltrim(str([A].SeqNo)) [ReadA] ")
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
        Dim Cnt As Integer = 0
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim ReadDiv As String = DR("ReadDiv")
                    Dim ReadA As String = DR("ReadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & ReadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <div Class='symbol-label' style='background-image:url(" & Image & ")'></div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6'>" & Title & "</span> ")
                    InnerHtml.Append("               <span Class='text-muted fw-bold text-muted d-block fs-7'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & ReadA & "' onclick='MNU020100_MarkAsRead(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                    Cnt = Cnt + 1

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        If Cnt > 0 Then divNotificationNew.Style("display") = ""
        divNotificationListNew.InnerHtml = InnerHtml.ToString
        'display 

    End Function

    Function bindotificationPrevious()

        'hide
        divNotificationPrevious.Style("display") = "none"
        'hide

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'UnreadDiv' + ltrim(str([A].SeqNo)) [UnreadDiv] ")
        Query.Append("   ,'UnreadA' + ltrim(str([A].SeqNo)) [UnreadA] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 1 ")
        Query.Append("   and [A].CreatedDate <= DATEADD(month,6,[A].CreatedDate) ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        Dim Cnt As Integer = 0
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim UnreadDiv As String = DR("UnreadDiv")
                    Dim UnreadA As String = DR("UnreadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & UnreadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <div Class='symbol-label' style='background-image:url(" & Image & ")'></div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6'>" & Title & "</span> ")
                    InnerHtml.Append("               <span Class='text-muted fw-bold text-muted d-block fs-7'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & UnreadA & "' onclick='MNU020100_MarkAsUnread(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as unread'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                    Cnt = Cnt + 1

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        If Cnt > 0 Then divNotificationPrevious.Style("display") = ""
        divNotificationListPrevious.InnerHtml = InnerHtml.ToString
        'display 

    End Function

#End Region

#Region "Refresh"

    Protected Sub btnRefresh_Click(ByVal sender As Object, e As EventArgs)
        bindNotificationNew()
        bindotificationPrevious()
    End Sub

#End Region

End Class