Imports System.Data.SqlClient
Imports System.IO

Public Class DSB000011
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
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

        'active account / menu
        Master.setActiveMenu("DSB", "001002")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString().Replace("No", "#")
            'Record

            'display record
            bindNavBar()
            bindPieChart()
            bindBarChart()
            bindWAR()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindNavBar()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].ProjInit  ")
        Query.Append("   ,[A].ProjName  ")
        Query.Append("   ,[A].Address  ")
        Query.Append("   ,[A].DateOpen  ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Subd = [A].ProjCode and [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going')) [Total] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.mstr_Projects [A] ")
        Query.Append("where ")
        Query.Append("   [A].ProjCode = " & ltrlID.Text & " ")

        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    imgProject.Src = "Assets/media/svg/project/" & DR.GetString(0) & ".svg"
                    lblProjName.Text = DR.GetString(1)
                    lblAddress.Text = DR.GetString(2)
                    lblLaunchDate.Text = Format(DR.GetDateTime(3), "dd MMM, yyyy")
                    divTotal.Attributes.Add("data-kt-countup-value", DR.GetInt32(4))
                    divPE.InnerHtml = bindPEList(ltrlID.Text)
                    aOverview.Attributes.Add("href", "DSB000011-" & ltrlID.Text)
                    aMap.Attributes.Add("href", "DSB000012-" & ltrlID.Text)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        upnlNavBar.Update()
        'display

    End Function

    Function bindPEList(ProjCode As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].AssignTo  ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join employee [C] on [A].AssignTo = [C].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [A].POCRate < 100 ")
        Query.Append("   and [B].Subd = " & ProjCode & " ")
        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim imgUser As String = ""
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(0) & ".png")) = True Then
                        imgUser = "Assets/media/avatars/" & DR.GetString(0) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(0) & ".jpg")) = True Then
                        imgUser = "Assets/media/avatars/" & DR.GetString(0) & ".jpg"
                    Else
                        imgUser = "Assets/media/avatars/blank.png"
                    End If

                    InnerHtml.Append("   <div Class='symbol symbol-35px symbol-circle' data-bs-toggle='tooltip' title='" & DR.GetString(1) & "'> ")
                    InnerHtml.Append("      <img alt ='Pic' src='" & imgUser & "' /> ")
                    InnerHtml.Append("   </div> ")

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

    Function bindPieChart()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   (select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going')) [Total] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].Status in ('On-Going') and [B].POCEnd >= [B].POCDate) [OnTime] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].Status in ('On-Going') and [B].POCEnd < [B].POCDate) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded')) [YetToStart] ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblActiveTask.Text = DR("Total") & " Units"

                    lblPieOntime.Text = DR("OnTime")
                    ltrlPieOntime.Text = DR("OnTime")
                    lblPieDelayed.Text = DR("Delayed")
                    ltrlPieDelayed.Text = DR("Delayed")
                    lblPieNotYetStarted.Text = DR("YetToStart")
                    ltrlPieNotYetStarted.Text = DR("YetToStart")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindBarChart()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct")
        Query.Append("   (select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].POCPE = [A].POCPE and [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going')) [Total] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].POCPE = [A].POCPE and [B].Status in ('On-Going') and [B].POCEnd >= [B].POCDate) [OnTime] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].POCPE = [A].POCPE and [B].Status in ('On-Going') and [B].POCEnd < [B].POCDate) [Delayed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Subd = " & ltrlID.Text & " and [B].POCPE = [A].POCPE and [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded')) [YetToStart] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join employee [B] on [A].POCPE = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Subd = " & ltrlID.Text & " ")
        'get approver 

        ltrlBarOngoing.Text = ""
        ltrlBarNotYetStarted.Text = ""
        ltrlBarDelayed.Text = ""
        ltrlBarAssigned.Text = ""
        ltrlBarCategories.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    If ltrlBarAssigned.Text = "" Then
                        ltrlBarAssigned.Text = DR("Total")
                    Else
                        ltrlBarAssigned.Text = ltrlBarAssigned.Text & "," & DR("Total")
                    End If
                    If ltrlBarOngoing.Text = "" Then
                        ltrlBarOngoing.Text = DR("OnTime")
                    Else
                        ltrlBarOngoing.Text = ltrlBarOngoing.Text & "," & DR("OnTime")
                    End If
                    If ltrlBarDelayed.Text = "" Then
                        ltrlBarDelayed.Text = DR("Delayed")
                    Else
                        ltrlBarDelayed.Text = ltrlBarDelayed.Text & "," & DR("Delayed")
                    End If
                    If ltrlBarNotYetStarted.Text = "" Then
                        ltrlBarNotYetStarted.Text = DR("YetToStart")
                    Else
                        ltrlBarNotYetStarted.Text = ltrlBarNotYetStarted.Text & "," & DR("YetToStart")
                    End If
                    If ltrlBarCategories.Text = "" Then
                        ltrlBarCategories.Text = DR("PE")
                    Else
                        ltrlBarCategories.Text = ltrlBarCategories.Text & "," & DR("PE")
                    End If
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindWAR()

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Subd = " & ltrlID.Text & " ")
        Query.Append("   and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going') ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Bullet"))
        dtable.Columns.Add(New DataColumn("HWCode"))
        dtable.Columns.Add(New DataColumn("Territory"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("ModelName"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("vendor"))
        dtable.Columns.Add(New DataColumn("BatchNo"))
        dtable.Columns.Add(New DataColumn("POCRate"))
        dtable.Columns.Add(New DataColumn("POCDate"))
        dtable.Columns.Add(New DataColumn("Remarks"))
        dtable.Columns.Add(New DataColumn("PE"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Bullet As String = ""
                    If DR.GetString(4) = "On-time" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf DR.GetString(4) = "Not yet started" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-secondary'></span>"
                    ElseIf DR.GetString(4) = "Delayed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If
                    'add new row
                    Dim NewRowValues As Object() = {Bullet, DR.GetString(0), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), DR.GetString(6), Format(DR.GetDecimal(7), "N2") & "%", Format(DR.GetDateTime(8), "MM/dd/yyyy"), DR.GetString(9), DR.GetString(10)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable 
        gvWAR01.DataSource = dtable
        gvWAR01.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvWAR01.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvWAR01.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvWAR01.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvWAR01.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

End Class