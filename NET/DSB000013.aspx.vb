Imports System.Data.SqlClient
Imports System.IO

Public Class DSB000013
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

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
            bindBatchBarChart()
            bindBatchList()
        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindBatchBarChart()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   * ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      [A].BatchNo  ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and [B].POCEnd >= [B].POCDate and [B].BatchNo = [A].BatchNo) [CompleteOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and [B].POCEnd < [B].POCDate and [B].BatchNo = [A].BatchNo) [CompleteDelayed] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'On-Going' and [B].POCEnd >= [B].POCDate and [B].BatchNo = [A].BatchNo) [OngoingOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'On-Going' and [B].POCEnd < [B].POCDate and [B].BatchNo = [A].BatchNo) [OngoingDelayed] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [B].POCStart >= cast(getdate() as date) and [B].BatchNo = [A].BatchNo) [ForConstructionOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [B].POCEnd < cast(getdate() as date) and [B].BatchNo = [A].BatchNo) [ForConstructionDelayed] ")
        Query.Append("   from ")
        Query.Append("      view_ContructionStatus [A]) [A] ")
        Query.Append("where ")
        Query.Append("   [A].[CompleteOntime] + [CompleteDelayed] + [OngoingOntime] + [OngoingDelayed] + [ForConstructionOntime] + [ForConstructionDelayed] > 0 ")
        Query.Append("order by ")
        Query.Append("   [A].BatchNo ")
        'get approver 

        ltrlProjectBarCategory.Text = ""
        ltrlProjectBarCompletedOntimeData.Text = ""
        ltrlProjectBarCompletedDelayedData.Text = ""
        ltrlProjectBarOngoingOntimeData.Text = ""
        ltrlProjectBarOngoingDelayedData.Text = ""
        ltrlProjectBarForConstructionOntimeData.Text = ""
        ltrlProjectBarForConstructionDelayedData.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlProjectBarCategory.Text = "" Then
                        ltrlProjectBarCategory.Text = DR.GetString(0)
                        ltrlProjectBarCompletedOntimeData.Text = DR.GetInt32(1)
                        ltrlProjectBarCompletedDelayedData.Text = DR.GetInt32(2)
                        ltrlProjectBarOngoingOntimeData.Text = DR.GetInt32(3)
                        ltrlProjectBarOngoingDelayedData.Text = DR.GetInt32(4)
                        ltrlProjectBarForConstructionOntimeData.Text = DR.GetInt32(5)
                        ltrlProjectBarForConstructionDelayedData.Text = DR.GetInt32(6)
                    Else
                        ltrlProjectBarCategory.Text = ltrlProjectBarCategory.Text & "," & DR.GetString(0)
                        ltrlProjectBarCompletedOntimeData.Text = ltrlProjectBarCompletedOntimeData.Text & "," & DR.GetInt32(1)
                        ltrlProjectBarCompletedDelayedData.Text = ltrlProjectBarCompletedDelayedData.Text & "," & DR.GetInt32(2)
                        ltrlProjectBarOngoingOntimeData.Text = ltrlProjectBarOngoingOntimeData.Text & "," & DR.GetInt32(3)
                        ltrlProjectBarOngoingDelayedData.Text = ltrlProjectBarOngoingDelayedData.Text & "," & DR.GetInt32(4)
                        ltrlProjectBarForConstructionOntimeData.Text = ltrlProjectBarForConstructionOntimeData.Text & "," & DR.GetInt32(5)
                        ltrlProjectBarForConstructionDelayedData.Text = ltrlProjectBarForConstructionDelayedData.Text & "," & DR.GetInt32(6)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindBatchList()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].BatchNo  ")
        Query.Append("   ,[A].DateReleased  ")
        Query.Append("   ,[A].No  ")
        Query.Append("   ,'DSB000014-' + [A].BatchNo [Link]  ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].POCEnd >= [B].POCDate and [B].BatchNo = [A].BatchNo) [Ontime] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].POCRate = 0 and [B].BatchNo = [A].BatchNo) [NotYetStarted] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Awarded','On-Going') and [B].POCEnd < [B].POCDate and [B].BatchNo = [A].BatchNo) [Delayed] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.mstr_BatchNo [A] ")
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

                    InnerHtml.Append("<div Class='col-md-6 col-xl-4'> ")
                    InnerHtml.Append("   <div Class='card border-hover-primary'> ")
                    InnerHtml.Append("      <div Class='card-header border-0 pt-9'> ")
                    InnerHtml.Append("         <div Class='card-title m-0'> ")
                    InnerHtml.Append("            <div Class='symbol symbol-50px me-5'> ")
                    InnerHtml.Append("               <div class='symbol-label bg-success text-inverse-info fs-2 fw-bold'>" & DR.GetString(2) & "</div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div Class='symbol symbol-35px'> ")
                    InnerHtml.Append("               <a class='symbol-label bg-info text-white fs-5 fw-bold pointer' onclick=""ViewWARStatusProject('On-going','" & DR.GetString(0) & "')"">" & DR.GetInt32(4) + DR.GetInt32(5) + DR.GetInt32(6) & "</a> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("         <div Class='card-toolbar'> ")
                    InnerHtml.Append("            <a href ='" & DR.GetString(3) & "' class='btn btn-primary btn-sm me-3'>View Details</a> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("      <div Class='card-body p-9'> ")
                    InnerHtml.Append("         <div Class='fs-3 fw-bolder text-dark'>Batch " & DR.GetString(0) & "</div> ")
                    InnerHtml.Append("         <p Class='text-gray-400 fw-bold fs-5 mt-1 mb-7'>Date Released " & Format(DR.GetDateTime(1), "MMM dd, yyyy") & "</p> ")
                    InnerHtml.Append("         <a class='fs-6 d-flex justify-content-between mb-4 pointer text-dark' onclick=""ViewWARStatusProject('On-time','" & DR.GetString(0) & "')""> ")
                    InnerHtml.Append("               <div class='fw-bold'>On-time</div> ")
                    InnerHtml.Append("               <div class='d-flex fw-bolder'>" & DR.GetInt32(4) & "</div> ")
                    InnerHtml.Append("         </a> ")
                    InnerHtml.Append("         <div class='separator separator-dashed mb-4'  ></div> ")
                    InnerHtml.Append("         <a class='fs-6 d-flex justify-content-between mb-4 pointer text-dark' onclick=""ViewWARStatusProject('Delayed','" & DR.GetString(0) & "')""> ")
                    InnerHtml.Append("               <div class='fw-bold'>Delayed</div> ")
                    InnerHtml.Append("               <div class='d-flex fw-bolder'>" & DR.GetInt32(6) & "</div> ")
                    InnerHtml.Append("         </a> ")
                    InnerHtml.Append("         <div class='separator separator-dashed mb-4'  ></div> ")
                    InnerHtml.Append("         <a class='fs-6 d-flex justify-content-between mb-4 pointer text-dark' onclick=""ViewWARStatusProject('Not yet started','" & DR.GetString(0) & "')""> ")
                    InnerHtml.Append("               <div class='fw-bold'>Not yet started</div> ")
                    InnerHtml.Append("               <div class='d-flex fw-bolder'>" & DR.GetInt32(5) & "</div> ")
                    InnerHtml.Append("         </a> ")
                    InnerHtml.Append("         <div Class='symbol-group symbol-hover'> ")
                    InnerHtml.Append(bindPEList(DR.GetString(0)))
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        divBatch.InnerHtml = InnerHtml.ToString
        'display

    End Function

    Function bindPEList(BatchNo As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].POCPE  ")
        Query.Append("   ,dbo.ProperCase([B].first_name) ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join employee [B] on [A].POCPE = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Awarded','On-Going') ")
        Query.Append("   and [A].BatchNo = '" & BatchNo & "' ")

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

                    InnerHtml.Append("            <a class='symbol symbol-35px symbol-circle pointer' data-bs-toggle='tooltip' title='" & DR.GetString(1) & "' onclick=""ViewWARPE('" & BatchNo & "' ,'" & DR.GetString(1) & "')""> ")
                    InnerHtml.Append("               <img alt ='Pic' src='" & imgUser & "' /> ")
                    InnerHtml.Append("            </a> ")

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

#End Region

End Class