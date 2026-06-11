Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization

Public Class HNDWOC
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

            If FormCode = "DSB100000" And Type = "Work Order Contract - CCI" Then

                Dim json As String = Me.DSB100000_Get_CCI_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - FIN" Then

                Dim json As String = Me.DSB100000_Get_FIN_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - MKT" Then

                Dim json As String = Me.DSB100000_Get_MKT_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - PDD" Then

                Dim json As String = Me.DSB100000_Get_PDD_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB10000" And Type = "Work Order Contract - SCM" Then

                Dim json As String = Me.DSB100000_Get_SCM_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - TSG-COS" Then

                Dim json As String = Me.DSB100000_Get_TSG_COS_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - TSG-PAD" Then

                Dim json As String = Me.DSB100000_Get_TSG_PAD_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - TSG-PE" Then

                Dim json As String = Me.DSB100000_Get_TSG_PE_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - TSG-PMD" Then

                Dim json As String = Me.DSB100000_Get_TSG_PMD_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - Complete" Then

                Dim json As String = Me.DSB100000_Get_Complete_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB100000" And Type = "Work Order Contract - Cancelled" Then

                Dim json As String = Me.DSB100000_Get_Cancelled_Project_All()
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

#Region "DSB100000"
    Private Function DSB100000_Get_CCI_Project_All()
        Dim CCITotal As Integer = 0
        Dim CCIGood As Integer = 0
        Dim CCIDue As Integer = 0
        Dim CCIDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'CCI' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    CCITotal = CCITotal + 1

                    If DR("Status") = "Good" Then
                        CCIGood = CCIGood + 1
                    ElseIf DR("Status") = "Due" Then
                        CCIDue = CCIDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        CCIDelay = CCIDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = CCITotal,
                        .Good = CCIGood,
                        .Due = CCIDue,
                        .Delay = CCIDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_FIN_Project_All()

        Dim FINTotal As Integer = 0
        Dim FINGood As Integer = 0
        Dim FINDue As Integer = 0
        Dim FINDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'FIN' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    FINTotal = FINTotal + 1

                    If DR("Status") = "Good" Then
                        FINGood = FINGood + 1
                    ElseIf DR("Status") = "Due" Then
                        FINDue = FINDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        FINDelay = FINDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = FINTotal,
                        .Good = FINGood,
                        .Due = FINDue,
                        .Delay = FINDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_MKT_Project_All()

        Dim MKTTotal As Integer = 0
        Dim MKTGood As Integer = 0
        Dim MKTDue As Integer = 0
        Dim MKTDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'MKT' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    MKTTotal = MKTTotal + 1

                    If DR("Status") = "Good" Then
                        MKTGood = MKTGood + 1
                    ElseIf DR("Status") = "Due" Then
                        MKTDue = MKTDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        MKTDelay = MKTDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = MKTTotal,
                        .Good = MKTGood,
                        .Due = MKTDue,
                        .Delay = MKTDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_PDD_Project_All()

        Dim PDDTotal As Integer = 0
        Dim PDDGood As Integer = 0
        Dim PDDDue As Integer = 0
        Dim PDDDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'PDD' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    PDDTotal = PDDTotal + 1

                    If DR("Status") = "Good" Then
                        PDDGood = PDDGood + 1
                    ElseIf DR("Status") = "Due" Then
                        PDDDue = PDDDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        PDDDelay = PDDDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = PDDTotal,
                        .Good = PDDGood,
                        .Due = PDDDue,
                        .Delay = PDDDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_SCM_Project_All()

        Dim SCMTotal As Integer = 0
        Dim SCMGood As Integer = 0
        Dim SCMDue As Integer = 0
        Dim SCMDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'SCM' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    SCMTotal = SCMTotal + 1

                    If DR("Status") = "Good" Then
                        SCMGood = SCMGood + 1
                    ElseIf DR("Status") = "Due" Then
                        SCMDue = SCMDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        SCMDelay = SCMDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = SCMTotal,
                        .Good = SCMGood,
                        .Due = SCMDue,
                        .Delay = SCMDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_TSG_COS_Project_All()

        Dim TSGCOSTotal As Integer = 0
        Dim TSGCOSGood As Integer = 0
        Dim TSGCOSDue As Integer = 0
        Dim TSGCOSDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-COS' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    TSGCOSTotal = TSGCOSTotal + 1

                    If DR("Status") = "Good" Then
                        TSGCOSGood = TSGCOSGood + 1
                    ElseIf DR("Status") = "Due" Then
                        TSGCOSDue = TSGCOSDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        TSGCOSDelay = TSGCOSDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = TSGCOSTotal,
                        .Good = TSGCOSGood,
                        .Due = TSGCOSDue,
                        .Delay = TSGCOSDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_TSG_PAD_Project_All()

        Dim TSGPADTotal As Integer = 0
        Dim TSGPADGood As Integer = 0
        Dim TSGPADDue As Integer = 0
        Dim TSGPADDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-PAD' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    TSGPADTotal = TSGPADTotal + 1

                    If DR("Status") = "Good" Then
                        TSGPADGood = TSGPADGood + 1
                    ElseIf DR("Status") = "Due" Then
                        TSGPADDue = TSGPADDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        TSGPADDelay = TSGPADDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = TSGPADTotal,
                        .Good = TSGPADGood,
                        .Due = TSGPADDue,
                        .Delay = TSGPADDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_TSG_PE_Project_All()

        Dim TSGPETotal As Integer = 0
        Dim TSGPEGood As Integer = 0
        Dim TSGPEDue As Integer = 0
        Dim TSGPEDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-PE' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    TSGPETotal = TSGPETotal + 1

                    If DR("Status") = "Good" Then
                        TSGPEGood = TSGPEGood + 1
                    ElseIf DR("Status") = "Due" Then
                        TSGPEDue = TSGPEDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        TSGPEDelay = TSGPEDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = TSGPETotal,
                        .Good = TSGPEGood,
                        .Due = TSGPEDue,
                        .Delay = TSGPEDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_TSG_PMD_Project_All()

        Dim TSGPMDTotal As Integer = 0
        Dim TSGPMDGood As Integer = 0
        Dim TSGPMDDue As Integer = 0
        Dim TSGPMDDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when Status = 'Good' then 'bullet bullet-vertical h-58px bg-info' ")
        Query.Append("        when Status = 'Due' then 'bullet bullet-vertical h-58px bg-warning' ")
        Query.Append("        when Status = 'Delay' then 'bullet bullet-vertical h-58px bg-danger' end) [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  [Group] = 'TSG-PMD' ")
        Query.Append("  and Status not in ('Cancelled', 'Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    TSGPMDTotal = TSGPMDTotal + 1

                    If DR("Status") = "Good" Then
                        TSGPMDGood = TSGPMDGood + 1
                    ElseIf DR("Status") = "Due" Then
                        TSGPMDDue = TSGPMDDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        TSGPMDDelay = TSGPMDDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = TSGPMDTotal,
                        .Good = TSGPMDGood,
                        .Due = TSGPMDDue,
                        .Delay = TSGPMDDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_Complete_Project_All()

        Dim DONETotal As Integer = 0
        Dim DONEGood As Integer = 0
        Dim DONEDue As Integer = 0
        Dim DONEDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'bullet bullet-vertical h-58px bg-success' [Bullet] ")
        Query.Append("  ,'FRM0000-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  Status in ('Done') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
        'get task

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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    DONETotal = DONETotal + 1

                    If DR("Status") = "Good" Then
                        DONEGood = DONEGood + 1
                    ElseIf DR("Status") = "Due" Then
                        DONEDue = DONEDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        DONEDelay = DONEDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = DONETotal,
                        .Good = DONEGood,
                        .Due = DONEDue,
                        .Delay = DONEDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Private Function DSB100000_Get_Cancelled_Project_All()

        Dim CANTotal As Integer = 0
        Dim CANGood As Integer = 0
        Dim CANDue As Integer = 0
        Dim CANDelay As Integer = 0

        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  'bullet bullet-vertical h-58px bg-danger' [Bullet] ")
        Query.Append("  ,'FRM000037-DTL-' + FormNo [Link] ")
        Query.Append("  ,FormNo ")
        Query.Append("  ,Project ")
        Query.Append("  ,dbo.ProperCase(first_name) + ' ' + dbo.ProperCase(last_name) [Assigned] ")
        Query.Append("  ,(case when isnull(CONVERT(VARCHAR(10),[DueDate],101),'') = '' then Status else isnull(CONVERT(VARCHAR(10),[DueDate],101),'') end) [DueDate] ")
        Query.Append("  ,Rpt_DashboardWOC.AssignTo [AssignTo] ")
        Query.Append("  ,Status ")
        Query.Append("from ")
        Query.Append("  Rpt_DashboardWOC ")
        Query.Append("  left join employee on Rpt_DashboardWOC.AssignTO = employee.emp_no ")
        Query.Append("where ")
        Query.Append("  Status in ('Cancelled') ")
        Query.Append("order by ")
        Query.Append("  FormNo ")
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
                    Dim Image As String
                    If File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".png")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".png"
                    ElseIf File.Exists(Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/"), DR("AssignTo") & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & DR("AssignTo") & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If

                    CANTotal = CANTotal + 1

                    If DR("Status") = "Good" Then
                        CANGood = CANGood + 1
                    ElseIf DR("Status") = "Due" Then
                        CANDue = CANDue + 1
                    ElseIf DR("Status") = "Delay" Then
                        CANDelay = CANDelay + 1
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<table class='table table-no-border table-row-dashed table-hover align-middle m-0 p-0'> ")
                    Data.Append("   <tbody> ")
                    Data.Append("       <tr> ")
                    Data.Append("           <td class='h-100'> ")
                    Data.Append("               <div class='h-100'> ")
                    Data.Append("                   <span class='" & DR("Bullet") & "'></span> ")
                    Data.Append("               </div> ")
                    Data.Append("           </td> ")
                    Data.Append("           <td class='w-100'> ")
                    Data.Append("               <a href='" & DR("Link") & "' class='d-flex' onclick='targetDIR(this);'> ")
                    Data.Append("                   <div class='symbol symbol-60px me-3'> ")
                    Data.Append("                       <img src='" & Image & "' alt='blank' /> ")
                    Data.Append("                   </div> ")
                    Data.Append("                   <div class='flex-grow-1'> ")
                    Data.Append("                       <span class='text-gray-800 fw-bolder fs-6'>" & DR("FormNo") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Project") & "</span> ")
                    Data.Append("                       <span class='text-muted fw-bold d-block fs-7'>" & DR("Assigned") & " | " & DR("DueDate") & "</span> ")
                    Data.Append("                   </div> ")
                    Data.Append("               </a> ")
                    Data.Append("           </td> ")
                    Data.Append("       </tr> ")
                    Data.Append("   </tbody> ")
                    Data.Append("</table> ")
                    FormList.Add(New With {
                        .Data = Data.ToString,
                        .Total = CANTotal,
                        .Good = CANGood,
                        .Due = CANDue,
                        .Delay = CANDelay
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
#End Region

End Class