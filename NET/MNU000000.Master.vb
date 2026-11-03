Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Configuration
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.VisualBasic.ApplicationServices

Public Class MNU000000
    Inherits System.Web.UI.MasterPage

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    Dim CIIS_Department As String
    Dim CIIS_Section As String
    Dim CIIS_JobDesc As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    'connection

#Region "Form"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'get user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        CIIS_Department = CIIS_UserInfo("CIIS_Department")
        CIIS_Section = CIIS_UserInfo("CIIS_Section")
        CIIS_JobDesc = CIIS_UserInfo("CIIS_JobDesc")

        'load page
        If IsPostBack = False Then
            bindFilterFormType()
            bindFilterStatus()
            bindFilterUserRequestBy()
            bindFilterUserAssignTo()
            bindFilterUserEndorsedBy()
            bindFilterUserApprovedBy()
            bindFilterUserImplementedBy()
            bindFilterUserMonitoredBy()
            bindAccount()
            bindNotificationNew()
            bindotificationPrevious()
            bindMode()

        End If
    End Sub

#End Region

#Region "General"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

#End Region

#Region "Menu"

    Public Sub bindAccount()

        'hide
        spnNewNotifier.Style.Item("display") = "none"
        'hide

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   isnull(WhatsNewNotification,0) [WhatsNewNotification] ")
        Query.Append("from ")
        Query.Append("   duser ")
        Query.Append("where ")
        Query.Append("   emp_no = '" & CIIS_EmpCode & "' ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        Dim Cnt As Integer = 0
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    If DR("WhatsNewNotification") = 0 Then spnNewNotifier.Style("display") = ""

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        If Cnt > 0 Then spnNotifier.Style.Item("display") = ""
        If Cnt = 0 Then divNotificationNothing.Style.Item("display") = ""
        If Cnt > 0 Then divNotificationNew.Style.Item("display") = ""
        divNotificationListNew.InnerHtml = InnerHtml.ToString
        'display 


        If File.Exists(Server.MapPath("~/Assets/media/avatars/" & CIIS_EmpCode & ".png")) = True Then
            imgUser1.ImageUrl = "Assets/media/avatars/" & CIIS_EmpCode & ".png"
            imgUser2.ImageUrl = "Assets/media/avatars/" & CIIS_EmpCode & ".png"
        ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & CIIS_EmpCode & ".jpg")) = True Then
            imgUser1.ImageUrl = "Assets/media/avatars/" & CIIS_EmpCode & ".jpg"
            imgUser2.ImageUrl = "Assets/media/avatars/" & CIIS_EmpCode & ".jpg"
        Else
            imgUser1.ImageUrl = "Assets/media/avatars/blank.png"
            imgUser2.ImageUrl = "Assets/media/avatars/blank.png"
        End If

        lblName.Text = CIIS_FirstName & " " & CIIS_LastName
        lblDepartment.Text = CIIS_Department & IIf(CIIS_Section = "", "", " - " & CIIS_Section)
        lblPosition.Text = CIIS_JobDesc

        upnlToolBar.Update()
        upnlAccount.Update()
    End Sub

    Function bindMode()

        Dim Query As New StringBuilder()
        Query.AppendLine("SELECT ISNULL(Mode, '') AS [Mode] ")
        Query.AppendLine("FROM Mstr_UserSettings ")
        Query.AppendLine("WHERE EmpCode = @EmpCode")

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)

                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    If DR.Read() Then
                        Dim modeValue As String = DR("Mode").ToString()
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "runJS", "loadmode('" & modeValue & "');", True)
                    End If
                End Using
            End Using
        End Using

    End Function
    Function bindNotificationNew()
        spnNotifier.Style.Item("display") = "none"
        spnFilterAll.Style.Item("display") = "none"
        spnFilterApprovals.Style.Item("display") = "none"
        If spnFilterMentions IsNot Nothing Then spnFilterMentions.Style.Item("display") = "none"
        spnFilterFormUpdates.Style.Item("display") = "none"
        spnFilterModuleUpdates.Style.Item("display") = "none"
        divNotificationNothing.Style.Item("display") = "none"
        divNotificationNew.Style.Item("display") = "none"

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,isnull([A].Type,'') + ' ' + isnull([A].Description,'') [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'ReadDiv' + ltrim(str([A].SeqNo)) [ReadDiv] ")
        Query.Append("   ,'ReadA' + ltrim(str([A].SeqNo)) [ReadA] ")
        Query.Append("   ,isnull([A].Type,'') [Type] ")
        Query.Append("   ,isnull(nullif((select top 1 [T].Category from Mstr_Notif_Type [T] ")
        Query.Append("            where rtrim([T].NotifType) <> '' and ([A].Type like '%' + rtrim([T].NotifType) + '%' or rtrim([T].NotifType) like '%' + [A].Type + '%') ")
        Query.Append("            order by len([T].NotifType) desc),''), ")
        Query.Append("            (case ")
        Query.Append("               when [A].Type like '%Approv%' or [A].Type like '%Endors%' or [A].Type like '%Declined%' then 'Approvals' ")
        Query.Append("               when [A].Type like '%Mention%' or [A].Type like '%Menition%' then 'Mentions' ")
        Query.Append("               when [A].Type like '%Form%' or [A].Type like '%PR%' or [A].Type like '%WO%' or [A].Type like '%Completed%' or [A].Type like '%LV%' or [A].Type like '%BTS%' then 'FormUpdates' ")
        Query.Append("               when [A].Type like '%Module%' or [A].Type like '%System%' then 'ModuleUpdates' ")
        Query.Append("               else 'FormUpdates' end)) [Category] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 0 ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate desc ")

        Dim InnerHtml As New StringBuilder
        Dim Cnt As Integer = 0
        Dim CntApprovals As Integer = 0
        Dim CntMentions As Integer = 0
        Dim CntFormUpdates As Integer = 0
        Dim CntModuleUpdates As Integer = 0

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
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

                    Dim Category As String = DR("Category").ToString().Trim().ToLower().Replace(" ", "")

                    If Category = "approvals" Then
                        CntApprovals += 1
                    ElseIf Category = "mentions" Then
                        CntMentions += 1
                    ElseIf Category = "formupdates" Then
                        CntFormUpdates += 1
                    ElseIf Category = "moduleupdates" Then
                        CntModuleUpdates += 1
                    End If

                    InnerHtml.Append("<div id='" & ReadDiv & "' data-notif-category='" & Category & "' class='notification-item overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <div Class='symbol-label' style='background-image:url(" & Image & ")'></div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6 nowrap-280px'>" & Title & "</span> ")
                    InnerHtml.Append("               <span Class='text-muted fw-bold text-muted d-block fs-7 nowrap-280px'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & ReadA & "' onclick='MarkAsRead(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")

                    Cnt = Cnt + 1
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        If Cnt > 0 Then
            spnNotifier.Style.Item("display") = ""
            spnFilterAll.Style.Item("display") = ""
        End If
        If CntApprovals > 0 Then spnFilterApprovals.Style.Item("display") = ""
        If CntMentions > 0 AndAlso spnFilterMentions IsNot Nothing Then spnFilterMentions.Style.Item("display") = ""
        If CntFormUpdates > 0 Then spnFilterFormUpdates.Style.Item("display") = ""
        If CntModuleUpdates > 0 Then spnFilterModuleUpdates.Style.Item("display") = ""

        If Cnt = 0 Then divNotificationNothing.Style.Item("display") = ""
        If Cnt > 0 Then divNotificationNew.Style.Item("display") = ""
        divNotificationListNew.InnerHtml = InnerHtml.ToString
    End Function
    Function bindotificationPrevious()

        'hide
        divNotificationPrevious.Style.Item("display") = "none"
        'hide

        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,isnull([A].Type,'') + ' ' + isnull([A].Description,'') [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'UnreadDiv' + ltrim(str([A].SeqNo)) [UnreadDiv] ")
        Query.Append("   ,'UnreadA' + ltrim(str([A].SeqNo)) [UnreadA] ")
        Query.Append("   ,isnull([A].Type,'') [Type] ")
        Query.Append("   ,isnull(nullif((select top 1 [T].Category from Mstr_Notif_Type [T] ")
        Query.Append("            where rtrim([T].NotifType) <> '' and ([A].Type like '%' + rtrim([T].NotifType) + '%' or rtrim([T].NotifType) like '%' + [A].Type + '%') ")
        Query.Append("            order by len([T].NotifType) desc),''), ")
        Query.Append("            (case ")
        Query.Append("               when [A].Type like '%Approv%' or [A].Type like '%Endors%' or [A].Type like '%Declined%' then 'Approvals' ")
        Query.Append("               when [A].Type like '%Mention%' or [A].Type like '%Menition%' then 'Mentions' ")
        Query.Append("               when [A].Type like '%Form%' or [A].Type like '%PR%' or [A].Type like '%WO%' or [A].Type like '%Completed%' or [A].Type like '%LV%' or [A].Type like '%BTS%' then 'FormUpdates' ")
        Query.Append("               when [A].Type like '%Module%' or [A].Type like '%System%' then 'ModuleUpdates' ")
        Query.Append("               else 'FormUpdates' end)) [Category] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 1 ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate desc ")

        Dim InnerHtml As New StringBuilder
        Dim Cnt As Integer = 0

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

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

                    Dim Category As String = DR("Category").ToString().Trim().ToLower().Replace(" ", "")

                    InnerHtml.Append("<div id='" & UnreadDiv & "' data-notif-category='" & Category & "' class='notification-item overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <div Class='symbol-label' style='background-image:url(" & Image & ")'></div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6 nowrap-280px'>" & Title & "</span> ")
                    InnerHtml.Append("               <span Class='text-muted fw-bold text-muted d-block fs-7 nowrap-280px'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & UnreadA & "' onclick='MarkAsUnread(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as unread'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")

                    Cnt = Cnt + 1

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        If Cnt > 0 Then divNotificationPrevious.Style.Item("display") = ""
        divNotificationListPrevious.InnerHtml = InnerHtml.ToString

    End Function


    Public Sub setActiveMenu(ByVal Menu As String, ByVal SubMenu As String)
        If Menu = "DSB" Then
            divDSB.Attributes.Add("class", "menu-item here show menu-lg-down-accordion me-lg-1")
            If SubMenu = "DSB010000" Then
                aDSB010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB020000" Then
                aDSB020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB030000" Then
                aDSB030000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB040000" Then
                aDSB040000.Attributes.Add("class", "menu-link active py-3")
                sDSB040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB040100" Then
                aDSB040000.Attributes.Add("class", "menu-link active py-3")
                sDSB040100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB040200" Then
                aDSB040000.Attributes.Add("class", "menu-link active py-3")
                sDSB040200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB040300" Then
                aDSB040000.Attributes.Add("class", "menu-link active py-3")
                sDSB040300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB040400" Then
                aDSB040000.Attributes.Add("class", "menu-link active py-3")
                sDSB040400.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB150000" Then
                aDSB150000.Attributes.Add("class", "menu-link active py-3")
                sDSB150000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB170000" Then
                aDSB150000.Attributes.Add("class", "menu-link active py-3")
                sDSB170000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB230000" Then
                aDSB150000.Attributes.Add("class", "menu-link active py-3")
                sDSB230000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB210000" Then
                aDSB150000.Attributes.Add("class", "menu-link active py-3")
                sDSB210000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB240000" Then
                aDSB240000.Attributes.Add("class", "menu-link active py-3")
                sDSB240000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB250000" Then
                aDSB240000.Attributes.Add("class", "menu-link active py-3")
                sDSB250000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB280000" Then
                aDSB240000.Attributes.Add("class", "menu-link active py-3")
                sDSB280000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB050000" Then
                aDSB050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB060000" Then
                aDSB060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB070300" Then
                aDSB070300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB080000" Then
                aDSB080000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB110000" Then
                aDSB110000.Attributes.Add("class", "menu-link active py-3")
            End If
            'If SubMenu = "DSB120000" Then
            '    aDSB120000.Attributes.Add("class", "menu-link active py-3")
            'End If
            If SubMenu = "DSB130000" Then
                aDSB130000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB140000" Then
                aDSB140000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB200000" Then
                aDSB200000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB310000" Then
                aDSB310000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB310000" Then
                aDSB320000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB180000" Then
                aDSB180000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC030200" Then
                aACC030200.Attributes.Add("class", "menu-link active py-3")
            End If
            'If SubMenu = "DSB150000" Then
            '    aDSB150000.Attributes.Add("class", "menu-link active py-3")
            'End If
            'If SubMenu = "DSB160000" Then
            '    aDSB160000.Attributes.Add("class", "menu-link active py-3")
            'End If
            'If SubMenu = "001002" Then
            '    aDSB000007.Attributes.Add("class", "menu-link active py-3")
            'End If
        End If
        If Menu = "APP" Then
            divAPP.Attributes.Add("class", "menu-item here show menu-lg-down-accordion me-lg-1")
            If SubMenu = "FRM010000" Then
                aFRM010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "WRK010000" Then
                aWRK010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAA010000" Then
                aAAA010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN030100" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnFIN030000.Attributes.Add("class", "menu-link active py-3")
                aFIN030100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0001" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0001" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0002" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0003" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0003.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0004" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0004.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0005" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0005.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0006" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0006.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0007" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0007.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0008" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0008.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0009" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0009.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0010" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0010.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0011" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0011.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0012" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0012.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0013" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0013.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0014" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0014.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0015" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0015.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0016" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0016.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0017" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0017.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDDRT0018" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDReport.Attributes.Add("class", "menu-link active py-3")
                aPDDRT0018.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD010100" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnPDD010000.Attributes.Add("class", "menu-link active py-3")
                aPDD010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD010000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD010200" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnPDD010000.Attributes.Add("class", "menu-link active py-3")
                aPDD010200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD010300" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnPDD010000.Attributes.Add("class", "menu-link active py-3")
                aPDD010300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD030000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD030000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD040000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD050000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD060000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD070000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD070000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD080000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD080000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD090000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aPDD090000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PDD100000" Then
                spnPDD000000.Attributes.Add("class", "menu-link active py-3")
                spnPDDParameter.Attributes.Add("class", "menu-link active py-3")
                aPDD100000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FAB010000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnFAB010000.Attributes.Add("class", "menu-link active py-3")
                aFAB010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG050100" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aENG050100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG050200" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aENG050200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG040200" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aENG040200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG040300" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aENG040300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG040100" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aENG040100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD010000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aPMD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD020000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aPMD020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD030000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aPMD030000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD040000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aPMD040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD050000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aPMD050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD060000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aPMD060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD070000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG040000.Attributes.Add("class", "menu-link active py-3")
                aPMD070000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG020100" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG020000.Attributes.Add("class", "menu-link active py-3")
                aENG020100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG020200" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG020000.Attributes.Add("class", "menu-link active py-3")
                aENG020200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG030100" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG030000.Attributes.Add("class", "menu-link active py-3")
                aENG030100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG010100" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG010200" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG010200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG010300" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG010300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG010400" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG010400.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG010500" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG010500.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG010600" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG010600.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG010700" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG010700.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG060000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENG070000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnENG010100.Attributes.Add("class", "menu-link active py-3")
                aENG070000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0001" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0002" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0003" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0003.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0004" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0004.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0005" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0005.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0006" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0006.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0007" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0007.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0008" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0008.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0009" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0009.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ENGRT0010" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aENGRT0010.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD080000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aPMD080000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD090000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aPMD090000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD100000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aPMD100000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "PMD110000" Then
                spnENG000000.Attributes.Add("class", "menu-link active py-3")
                spnENGReport.Attributes.Add("class", "menu-link active py-3")
                aPMD110000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS010000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS020000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS030000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS030000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS040000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS050000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS060000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS140000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS140000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS150000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS150000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS160000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSParameter.Attributes.Add("class", "menu-link active py-3")
                aSLS160000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS170000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSParameter.Attributes.Add("class", "menu-link active py-3")
                aSLS170000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS180000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSParameter.Attributes.Add("class", "menu-link active py-3")
                aSLS180000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS190000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS190000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLS200000" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSLS200000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLSRT0001" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSReport.Attributes.Add("class", "menu-link active py-3")
                aSLSRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SLSRT0002" Then
                spnSLS000000.Attributes.Add("class", "menu-link active py-3")
                spnSLSReport.Attributes.Add("class", "menu-link active py-3")
                aSLSRT0002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD010000" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAAD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD040000" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAAD040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD050000" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAAD050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD060000" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAAD060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD002000" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAAD002000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD003000" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAAD003000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD010300" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                aAAD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD010400" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                aAAD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD010500" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                aAAD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AAD010600" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                aAAD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0001" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0002" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0003" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0003.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0004" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0004.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0007" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0007.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0008" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0008.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0009" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0009.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0010" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0010.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0011" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0011.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0012" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0012.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0013" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0013.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0014" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0014.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0015" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0015.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0016" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0016.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0017" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0017.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0018" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0018.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0019" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0019.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0020" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0020.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0021" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0021.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0022" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0022.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0023" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0023.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0025" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0025.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0026" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0026.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0027" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0027.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0028" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0028.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0029" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0029.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0030" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0030.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0031" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0031.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0032" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0032.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0034" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0034.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0035" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0035.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0036" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0036.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0040" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0040.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AADRT0048" Then
                spnAAD000000.Attributes.Add("class", "menu-link active py-3")
                spnAADReport.Attributes.Add("class", "menu-link active py-3")
                aAADRT0048.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN010000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN020000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN040000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN050000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN060000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN070000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN070000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN080000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN080000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN090000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN090000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN100000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN100000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN100001" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN100001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN100002" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN100002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN110000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN110000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN120000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN120000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN130000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnFIN130000.Attributes.Add("class", "menu-link active py-3")
                aFIN130000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN130001" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnFIN130000.Attributes.Add("class", "menu-link active py-3")
                aFIN130001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN140000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN140000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN150000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN150000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN160000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN160000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FIN170000" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINDataEntry.Attributes.Add("class", "menu-link active py-3")
                aFIN170000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0001" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0004" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0004.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0005" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0005.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0006" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0006.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0008" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0008.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0029" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0029.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0030" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0030.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0009" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0009.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0010" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0010.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0013" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0013.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0014" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0014.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0015" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0015.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0016" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0016.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0018" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0018.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0019" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0019.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0021" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0021.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "FINRT0023" Then
                spnFIN000000.Attributes.Add("class", "menu-link active py-3")
                spnFINReport.Attributes.Add("class", "menu-link active py-3")
                aFINRT0023.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM050000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM040000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM030100" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                spnSCM030000.Attributes.Add("class", "menu-link active py-3")
                aSCM030100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM010100" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                aSCM010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM010200" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                aSCM010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM010300" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                aSCM010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM010400" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                aSCM010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM020000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                aSCM020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM060000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM070000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM070000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM080000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM080000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM090000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM090000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM100000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM100000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM110000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM110000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM120000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM120000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM130000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM130000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM160000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM160000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCM170000" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMDataEntry.Attributes.Add("class", "menu-link active py-3")
                aSCM170000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0001" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0002" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0003" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0003.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0004" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0004.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0005" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0005.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0006" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0006.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0007" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0007.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0008" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0008.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0010" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0010.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0011" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0011.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "SCMRT0012" Then
                spnSCM000000.Attributes.Add("class", "menu-link active py-3")
                spnSCMReport.Attributes.Add("class", "menu-link active py-3")
                aSCMRT0012.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC010100" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC010000.Attributes.Add("class", "menu-link active py-3")
                aACC010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC010200" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC010000.Attributes.Add("class", "menu-link active py-3")
                aACC010200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC010300" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC010000.Attributes.Add("class", "menu-link active py-3")
                aACC010300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC020100" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC020000.Attributes.Add("class", "menu-link active py-3")
                aACC020100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC020200" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC020000.Attributes.Add("class", "menu-link active py-3")
                aACC020200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC020300" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC020000.Attributes.Add("class", "menu-link active py-3")
                aACC020300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC030100" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC030000.Attributes.Add("class", "menu-link active py-3")
                aACC030100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC040000" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC030000.Attributes.Add("class", "menu-link active py-3")
                aACC040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC050000" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC030000.Attributes.Add("class", "menu-link active py-3")
                aACC050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACC060000" Then
                spnACC000000.Attributes.Add("class", "menu-link active py-3")
                spnACC030000.Attributes.Add("class", "menu-link active py-3")
                aACC060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AUD010100" Then
                spnAUD000000.Attributes.Add("class", "menu-link active py-3")
                spnAUDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAUD010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AUD020000" Then
                spnAUD000000.Attributes.Add("class", "menu-link active py-3")
                spnAUDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAUD020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0001" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0002" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0003" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0003.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0004" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0004.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0005" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0005.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0006" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0006.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0007" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0007.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0008" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0008.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0009" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0009.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0010" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0010.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0011" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0011.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0012" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0012.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0013" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0013.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0014" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0014.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0015" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0015.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0016" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0016.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0017" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0017.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0018" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0018.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0019" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0019.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0020" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0020.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0021" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0021.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDRT0022" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDReport.Attributes.Add("class", "menu-link active py-3")
                aCSDRT0022.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSD010100" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aCSD010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSD010200" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aCSD010200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSD010300" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aCSD010300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSD010400" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aCSD010400.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSD010500" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aCSD010500.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDDSB001" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aCSDDSB001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CSDDSB002" Then
                spnCSD000000.Attributes.Add("class", "menu-link active py-3")
                spnCSDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aCSDDSB002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA010000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAParameter.Attributes.Add("class", "menu-link active py-3")
                aHRA010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA020000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAParameter.Attributes.Add("class", "menu-link active py-3")
                aHRA020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA030000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAParameter.Attributes.Add("class", "menu-link active py-3")
                aHRA030000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA110000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAParameter.Attributes.Add("class", "menu-link active py-3")
                aHRA110000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA040000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA040000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA050000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA050000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA060000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA060000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA070000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA070000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA080000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA080000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA090000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA090000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA100000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA100000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA120000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA120000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRA130000" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRADataEntry.Attributes.Add("class", "menu-link active py-3")
                aHRA130000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0001" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0001.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0002" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0002.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0003" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0003.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0004" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0004.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0005" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0005.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0006" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0006.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0007" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0007.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0008" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0008.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0009" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0009.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0010" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0010.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0011" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0011.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0012" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0012.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0013" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0013.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0014" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0014.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0015" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0015.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0016" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0016.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0017" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0017.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0018" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0018.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0019" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0019.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0020" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0020.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0021" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0021.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0022" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0022.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0023" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0023.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0024" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0024.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0025" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0025.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0026" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0026.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0027" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0027.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0028" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0028.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0029" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0029.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0030" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0030.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0031" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0031.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0032" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0032.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0033" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0033.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0034" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0034.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0035" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0035.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "HRART0036" Then
                spnHRA000000.Attributes.Add("class", "menu-link active py-3")
                spnHRAReport.Attributes.Add("class", "menu-link active py-3")
                aHRART0036.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AMD010000" Then
                spnAMD000000.Attributes.Add("class", "menu-link active py-3")
                spnAMDParameter.Attributes.Add("class", "menu-link active py-3")
                aAMD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AMD020000" Then
                spnAMD000000.Attributes.Add("class", "menu-link active py-3")
                spnAMDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAMD020000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "AMD030000" Then
                spnAMD000000.Attributes.Add("class", "menu-link active py-3")
                spnAMDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAMD030000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "ACQ010000" Then
                spnACQ010000.Attributes.Add("class", "menu-link active py-3")
                spnACQDataEntry.Attributes.Add("class", "menu-link active py-3")
                aAMD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "BTD010000" Then
                spnBTD000000.Attributes.Add("class", "menu-link active py-3")
                spnBTDParameter.Attributes.Add("class", "menu-link active py-3")
                aBTD010000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB070100" Then
                spnBTD000000.Attributes.Add("class", "menu-link active py-3")
                spnBTDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aDSB070100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DSB070400" Then
                spnBTD000000.Attributes.Add("class", "menu-link active py-3")
                spnBTDDataEntry.Attributes.Add("class", "menu-link active py-3")
                aDSB070400.Attributes.Add("class", "menu-link active py-3")
            End If
        End If
        If Menu = "CLD" Then
            divCLD.Attributes.Add("class", "menu-item here show menu-lg-down-accordion me-lg-1")
            If SubMenu = "CLD010100" Then
                aCLD010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CLD010200" Then
                aCLD010200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CLD010300" Then
                aCLD010300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CLD010400" Then
                aCLD010400.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CLD010500" Then
                aCLD010500.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "CLD010600" Then
                aCLD010600.Attributes.Add("class", "menu-link active py-3")
            End If
        End If
        If Menu = "DOC" Then
            divDOC.Attributes.Add("class", "menu-item here show menu-lg-down-accordion me-lg-1")
            If SubMenu = "DOC010000" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010100" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010200" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010300" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010300" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010400" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010400.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010500" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010500.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010600" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010600.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010700" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010700.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010800" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010800.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC010900" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC010900.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC011000" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC011000.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC011100" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC011100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC011200" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC011200.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC011300" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC011300.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC011400" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC011400.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC011500" Then
                spnDOC010000.Attributes.Add("class", "menu-link active py-3")
                aDOC011500.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC020100" Then
                aDOC020100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC040100" Then
                aDOC040100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC050100" Then
                aDOC040100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC060100" Then
                aDOC040100.Attributes.Add("class", "menu-link active py-3")
            End If
            If SubMenu = "DOC030000" Then
                spnDOC030000.Attributes.Add("class", "menu-link active py-3")
                aDOC030000.Attributes.Add("class", "menu-link active py-3")
            End If
        End If
    End Sub

    Private Sub lbtnSignOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSignOut.Click


        Response.Cookies.Clear()
        CIIS_UserInfo = New HttpCookie("CIIS_UserInfo")
        CIIS_UserInfo("CIIS_EmpCode") = ""
        CIIS_UserInfo("CIIS_FirstName") = ""
        CIIS_UserInfo("CIIS_LastName") = ""
        CIIS_UserInfo("CIIS_Department") = ""
        CIIS_UserInfo("CIIS_Section") = ""
        CIIS_UserInfo("CIIS_Position") = ""
        CIIS_UserInfo.Expires = Date.Now.AddDays(-1)
        Response.Cookies.Add(CIIS_UserInfo)
        Response.Redirect("MNU010100")
    End Sub


#End Region

#Region "Search"

    Function bindFilterFormType()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Form Type' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   t_code [Code] ")
        Query.Append("   ,description [Name] ")
        Query.Append("   ,description [Order] ")
        Query.Append("from ")
        Query.Append("   oop_form_type ")
        Query.Append("where ")
        Query.Append("    Active = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_FormType.DataSource = DT
        ddlFLT_FormType.DataValueField = "Code"
        ddlFLT_FormType.DataTextField = "Name"
        ddlFLT_FormType.DataBind()
        'fill data

    End Function

    Function bindFilterStatus()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Status' [Name] ")
        Query.Append("   ,'00' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   'New' [Code] ")
        Query.Append("   ,'New' [Name] ")
        Query.Append("   ,'01' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   'Endorsed' [Code] ")
        Query.Append("   ,'Endorsed' [Name] ")
        Query.Append("   ,'02' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   'Approved' [Code] ")
        Query.Append("   ,'Approved' [Name] ")
        Query.Append("   ,'03' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   'Closed' [Code] ")
        Query.Append("   ,'Closed' [Name] ")
        Query.Append("   ,'04' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   'Clarify' [Code] ")
        Query.Append("   ,'Clarify' [Name] ")
        Query.Append("   ,'05' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   'Cancelled' [Code] ")
        Query.Append("   ,'Cancelled' [Name] ")
        Query.Append("   ,'06' [Order] ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_Status.DataSource = DT
        ddlFLT_Status.DataValueField = "Code"
        ddlFLT_Status.DataTextField = "Name"
        ddlFLT_Status.DataBind()
        'fill data

    End Function

    Function bindFilterUserRequestBy()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Requested By' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("    lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_RequestedBy.DataSource = DT
        ddlFLT_RequestedBy.DataValueField = "Code"
        ddlFLT_RequestedBy.DataTextField = "Name"
        ddlFLT_RequestedBy.DataBind()
        'fill data

    End Function

    Function bindFilterUserAssignTo()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Assigned To' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("    lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_AssignedTo.DataSource = DT
        ddlFLT_AssignedTo.DataValueField = "Code"
        ddlFLT_AssignedTo.DataTextField = "Name"
        ddlFLT_AssignedTo.DataBind()
        'fill data

    End Function

    Function bindFilterUserEndorsedBy()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Endorsed By' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("    lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_EndorsedBy.DataSource = DT
        ddlFLT_EndorsedBy.DataValueField = "Code"
        ddlFLT_EndorsedBy.DataTextField = "Name"
        ddlFLT_EndorsedBy.DataBind()
        'fill data

    End Function

    Function bindFilterUserApprovedBy()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Approved By' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("    lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_ApprovedBy.DataSource = DT
        ddlFLT_ApprovedBy.DataValueField = "Code"
        ddlFLT_ApprovedBy.DataTextField = "Name"
        ddlFLT_ApprovedBy.DataBind()
        'fill data

    End Function

    Function bindFilterUserImplementedBy()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Implemented By' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("    lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_ImplementedBy.DataSource = DT
        ddlFLT_ImplementedBy.DataValueField = "Code"
        ddlFLT_ImplementedBy.DataTextField = "Name"
        ddlFLT_ImplementedBy.DataBind()
        'fill data

    End Function

    Function bindFilterUserMonitoredBy()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Monitored By' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("    lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password 
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlFLT_MonitoredBy.DataSource = DT
        ddlFLT_MonitoredBy.DataValueField = "Code"
        ddlFLT_MonitoredBy.DataTextField = "Name"
        ddlFLT_MonitoredBy.DataBind()
        'fill data

    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)

        If tbxFLTR_Search.Text = "" And tbxFLTR_FormNo.Text = "" And ddlFLT_FormType.SelectedValue = "" And tbxFLTR_DateRequested_From.Value = "" And tbxFLTR_DateRequested_To.Value = "" And tbxFLTR_DateRequired_From.Value = "" And tbxFLTR_DateRequired_To.Value = "" And ddlFLT_RequestedBy.SelectedValue = "" And ddlFLT_AssignedTo.SelectedValue = "" And ddlFLT_Status.SelectedValue = "" And tbxFLT_Title.Text = "" And ddlFLT_MonitoredBy.SelectedValue = "" And ddlFLT_EndorsedBy.SelectedValue = "" And ddlFLT_ApprovedBy.SelectedValue = "" And ddlFLT_ImplementedBy.SelectedValue = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        End If

        'processing time
        System.Threading.Thread.Sleep(6000)
        'processing time

        'get approver
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
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
        Query.Append("	    left join oop_form_type [D] on [A].form_type = [D].t_code ")
        Query.Append("   where ")
        Query.Append("      [D].IsSearchable = 1 ")
        If tbxFLTR_Search.Text = "" Then
            'advance search
            If tbxFLTR_FormNo.Text <> "" Then Query.Append("      and [A].f_code = '" & tbxFLTR_FormNo.Text & "' ")
            If ddlFLT_FormType.SelectedValue <> "" Then Query.Append("      and [A].form_type = '" & ddlFLT_FormType.SelectedValue & "' ")
            If tbxFLTR_DateRequested_From.Value <> "" And tbxFLTR_DateRequested_To.Value <> "" Then
                Query.Append("      and cast([A].created_date as date) between '" & tbxFLTR_DateRequested_From.Value & "' and '" & tbxFLTR_DateRequested_To.Value & "' ")
            ElseIf tbxFLTR_DateRequested_From.Value <> "" Then
                Query.Append("      and cast([A].created_date as date) = '" & tbxFLTR_DateRequested_From.Value & "' ")
            ElseIf tbxFLTR_DateRequested_To.Value <> "" Then
                Query.Append("      and cast([A].created_date as date) = '" & tbxFLTR_DateRequested_To.Value & "' ")
            End If
            If tbxFLTR_DateRequired_From.Value <> "" And tbxFLTR_DateRequired_To.Value <> "" Then
                Query.Append("      and cast([A].date_required as date) between '" & tbxFLTR_DateRequired_From.Value & "' and '" & tbxFLTR_DateRequired_To.Value & "' ")
            ElseIf tbxFLTR_DateRequired_From.Value <> "" Then
                Query.Append("      and cast([A].date_required as date) = '" & tbxFLTR_DateRequired_From.Value & "' ")
            ElseIf tbxFLTR_DateRequired_To.Value <> "" Then
                Query.Append("      and cast([A].date_required as date) = '" & tbxFLTR_DateRequired_To.Value & "' ")
            End If
            If ddlFLT_RequestedBy.SelectedValue <> "" Then Query.Append("      and [A].created_by = '" & ddlFLT_RequestedBy.SelectedValue & "' ")
            If ddlFLT_AssignedTo.SelectedValue <> "" Then Query.Append("      and [A].approver = '" & ddlFLT_AssignedTo.SelectedValue & "' ")
            If ddlFLT_Status.SelectedValue = "New" Then Query.Append("      and [A].status in ('New','Requested') ")
            If ddlFLT_Status.SelectedValue = "Endorsed" Then Query.Append("      and [A].status in ('Endorsed') ")
            If ddlFLT_Status.SelectedValue = "Approved" Then Query.Append("      and [A].status in ('Approved','Implemented') ")
            If ddlFLT_Status.SelectedValue = "Closed" Then Query.Append("      and [A].status in ('Accepted') ")
            If ddlFLT_Status.SelectedValue = "Clarify" Then Query.Append("      and [A].status in ('Clarification') ")
            If ddlFLT_Status.SelectedValue = "Cancelled" Then Query.Append("      and [A].status in ('Cancelled','Declined') ")
            If tbxFLT_Title.Text <> "" Then Query.Append("      and [A].FormTitle like '%" & tbxFLT_Title.Text & "%' ")
            If ddlFLT_MonitoredBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_monitor [D] where [D].monitored_by = '" & ddlFLT_MonitoredBy.SelectedValue & "') ")
            If ddlFLT_EndorsedBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_appr [D] where [D].type = 'Endorsed By' and [D].approver = '" & ddlFLT_EndorsedBy.SelectedValue & "') ")
            If ddlFLT_ApprovedBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_appr [D] where [D].type = 'Approved By' and [D].approver = '" & ddlFLT_ApprovedBy.SelectedValue & "') ")
            If ddlFLT_ImplementedBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_appr [D] where [D].type = 'Implementer' and [D].approver = '" & ddlFLT_ImplementedBy.SelectedValue & "') ")
            'advance search
        Else
            'noral search
            Query.Append("      and ([A].f_code like '%" & tbxFLTR_Search.Text & "%' ")
            Query.Append("      or [A].FormTitle like '%" & tbxFLTR_Search.Text & "%') ")
            'noral search
        End If
        Query.Append("   ) [A]  ")
        Query.Append("union ")
        Query.Append("Select  ")
        Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select  ")
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
        Query.Append("	    left join oop_form_type [D] on [A].form_type = [D].t_code ")
        Query.Append("   where ")
        Query.Append("      [D].IsSearchable = 0 ")
        Query.Append("      and [A].f_code in (select [E].f_code from oop_form_hdr [E] where [E].created_by = '" & CIIS_EmpCode & "' union select [E].f_code from oop_form_dtl_monitor [E] where [E].monitored_by = '" & CIIS_EmpCode & "' union select [E].f_code from oop_form_dtl_appr [E] where [E].approver = '" & CIIS_EmpCode & "') ")
        If tbxFLTR_Search.Text = "" Then
            'advance search
            If tbxFLTR_FormNo.Text <> "" Then Query.Append("      and [A].f_code = '" & tbxFLTR_FormNo.Text & "' ")
            If ddlFLT_FormType.SelectedValue <> "" Then Query.Append("      and [A].form_type = '" & ddlFLT_FormType.SelectedValue & "' ")
            If tbxFLTR_DateRequested_From.Value <> "" And tbxFLTR_DateRequested_To.Value <> "" Then
                Query.Append("      and cast([A].created_date as date) between '" & tbxFLTR_DateRequested_From.Value & "' and '" & tbxFLTR_DateRequested_To.Value & "' ")
            ElseIf tbxFLTR_DateRequested_From.Value <> "" Then
                Query.Append("      and cast([A].created_date as date) = '" & tbxFLTR_DateRequested_From.Value & "' ")
            ElseIf tbxFLTR_DateRequested_To.Value <> "" Then
                Query.Append("      and cast([A].created_date as date) = '" & tbxFLTR_DateRequested_To.Value & "' ")
            End If
            If tbxFLTR_DateRequired_From.Value <> "" And tbxFLTR_DateRequired_To.Value <> "" Then
                Query.Append("      and cast([A].date_required as date) between '" & tbxFLTR_DateRequired_From.Value & "' and '" & tbxFLTR_DateRequired_To.Value & "' ")
            ElseIf tbxFLTR_DateRequired_From.Value <> "" Then
                Query.Append("      and cast([A].date_required as date) = '" & tbxFLTR_DateRequired_From.Value & "' ")
            ElseIf tbxFLTR_DateRequired_To.Value <> "" Then
                Query.Append("      and cast([A].date_required as date) = '" & tbxFLTR_DateRequired_To.Value & "' ")
            End If
            If ddlFLT_RequestedBy.SelectedValue <> "" Then Query.Append("      and [A].created_by = '" & ddlFLT_RequestedBy.SelectedValue & "' ")
            If ddlFLT_AssignedTo.SelectedValue <> "" Then Query.Append("      and [A].approver = '" & ddlFLT_AssignedTo.SelectedValue & "' ")
            If ddlFLT_Status.SelectedValue = "New" Then Query.Append("      and [A].status in ('New','Requested') ")
            If ddlFLT_Status.SelectedValue = "Endorsed" Then Query.Append("      and [A].status in ('Endorsed') ")
            If ddlFLT_Status.SelectedValue = "Approved" Then Query.Append("      and [A].status in ('Approved','Implemented') ")
            If ddlFLT_Status.SelectedValue = "Closed" Then Query.Append("      and [A].status in ('Accepted') ")
            If ddlFLT_Status.SelectedValue = "Clarify" Then Query.Append("      and [A].status in ('Clarification') ")
            If ddlFLT_Status.SelectedValue = "Cancelled" Then Query.Append("      and [A].status in ('Cancelled','Declined') ")
            If tbxFLT_Title.Text <> "" Then Query.Append("      and [A].FormTitle like '%" & tbxFLT_Title.Text & "%' ")
            If ddlFLT_MonitoredBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_monitor [D] where [D].monitored_by = '" & ddlFLT_MonitoredBy.SelectedValue & "') ")
            If ddlFLT_EndorsedBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_appr [D] where [D].type = 'Endorsed By' and [D].approver = '" & ddlFLT_EndorsedBy.SelectedValue & "') ")
            If ddlFLT_ApprovedBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_appr [D] where [D].type = 'Approved By' and [D].approver = '" & ddlFLT_ApprovedBy.SelectedValue & "') ")
            If ddlFLT_ImplementedBy.SelectedValue <> "" Then Query.Append("      and [A].f_code in (select [D].f_code from oop_form_dtl_appr [D] where [D].type = 'Implementer' and [D].approver = '" & ddlFLT_ImplementedBy.SelectedValue & "') ")
            'advance search
        Else
            'noral search
            Query.Append("      and ([A].f_code like '%" & tbxFLTR_Search.Text & "%' ")
            Query.Append("      or [A].FormTitle like '%" & tbxFLTR_Search.Text & "%') ")
            'noral search
        End If
        Query.Append("   ) [A]  ")

        Query.Append("order by ")
        Query.Append("   [Date] desc ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("Link"))
        dtable.Columns.Add(New DataColumn("Icon"))
        dtable.Columns.Add(New DataColumn("Title"))
        dtable.Columns.Add(New DataColumn("ID"))
        dtable.Columns.Add(New DataColumn("Name"))
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("lbtnSUBS"))
        dtable.Columns.Add(New DataColumn("DisplayRPT"))
        dtable.Columns.Add(New DataColumn("lbtnRPT"))
        dtable.Columns.Add(New DataColumn("lbtnSTSSUpd"))
        dtable.Columns.Add(New DataColumn("lbtnUPLSUpd"))
        dtable.Columns.Add(New DataColumn("lbtnNTESUpd"))
        'Create datatable and columns

        Dim RowIdx = 0

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'create varialble
                    Dim Bullet As String = DR("Bullet")
                    Dim Link As String = DR("Link")
                    Dim Icon As String = DR("Icon")
                    Dim Title As String = DR("Title")
                    Dim ID As String = DR("ID")
                    Dim Name As String = DR("Name")
                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    'create varialble

                    'add new row
                    Dim NewRowValues As Object() = {Bullet, Link, Icon, Title, ID, Name, Date_}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                    RowIdx = RowIdx + 1

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record





    End Sub

#End Region

End Class