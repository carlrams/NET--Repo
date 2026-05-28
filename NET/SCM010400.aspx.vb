Imports System.Data.SqlClient
Imports System.IO
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Imports CrystalDecisions.Web
Imports Microsoft.Ajax.Utilities
Imports System.Security.Policy
Imports System.ComponentModel
Imports Microsoft.AspNet.SignalR.Hubs

Public Class SCM010400
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SCM010400")
        'active account / menu

        'create variable
        Dim Msg As String = Validate("Access", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        If IsPostBack = False Then
            bindCount()
            bindBatch()
            bindProject()

            'deadline
            bindDeadline()
        End If

    End Sub
#End Region

#Region "Function"

    Function bindCount()

        'get count
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (select count(1) from ogm_vendor where lock = 1) [RegisteredContractor] ")
        Query.Append("  ,(select count(distinct [FormNo]) from(select [A].status [Status], [A].f_code [FormNo] from oop_form_hdr [A] left join SCM_TagContractors [B] on [A].f_code = [B].tag_code left join Form_CRT [C] on [A].tbl_code = [C].CRTCode where [A].status not in ('Accepted', 'Cancelled', 'Declined') and [A].tbl_from = 'Form_CRT' and ([C].ContractStatus not in ('For Award' ,'Awarded', 'Cancelled'))) [A]) [Projects] ")
        Query.Append("  ,(select count(1) from Form_HWHdr [A] left join SCM_TagContractors [B] on [A].HWCode = [B].tag_code where ([B].acct_status not in ('Awarded', 'Cancelled') or [A].ConStatus not in ('For Award', 'Awarded', 'Cancelled'))) [Construction] ")
        Query.Append("  ,(select count(distinct [FormNo]) from(select [A].status [Status], [A].f_code [FormNo] from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].tbl_from = 'Form_CRT' and [B].ContractStatus in ('Awarded')) [A]) [AwardedProjects] ")
        Query.Append("  ,(select count(1) from Form_HWHdr [A] where [A].ConStatus in ('Awarded') )  [AwardedConstruction] ")
        Query.Append("  ,(select count(distinct [FormNo]) from(select [A].status [Status], [A].f_code [FormNo] from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].tbl_from = 'Form_CRT' and [B].ContractStatus in ('Awarded') and [B].POCRate >= 95.00) [A]) [WithBalanceProj] ")
        Query.Append("  ,(select count(1) from Form_HWHdr where ConStatus in ('Awarded') and POCRate >= 95.00) [WithBalanceCon] ")
        Query.Append("  ,(select count(distinct [FormNo]) from(select [A].status [Status], [A].f_code [FormNo] from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].tbl_from = 'Form_CRT' and [B].ContractStatus in ('Cancelled')) [A]) [CancelledProjects] ")
        'get count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'for award projects
                    Dim ForAward As String = DR("Projects") + DR("Construction")
                    divForAward.InnerHtml = ForAward
                    'for award projects

                    'awarded projects
                    Dim AwardedProjects As String = DR("AwardedProjects") + DR("AwardedConstruction")
                    divAwardedProj.InnerHtml = AwardedProjects
                    'awarded projects

                    'awarded projects with balance
                    Dim WithBalance As String = DR("WithBalanceProj") + DR("WithBalanceCon")
                    divWithBalance.InnerHtml = WithBalance
                    'awarded projects with balance

                    'cancelled projects
                    Dim CancelledProjects As String = DR("CancelledProjects")
                    divCancelledProj.InnerHtml = CancelledProjects
                    'cancelled projects

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record
    End Function

    Function bindProject()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  dbo.ProperCase([C].description) [Subdivision] ")
        Query.Append("  ,dbo.ProperCase([C].address) [Address] ")
        Query.Append("  ,[D].ProvinceName [ProvName] ")
        Query.Append("  ,(select count(1) from Form_CRT where subdivision = [B].Subdivision and ContractStatus not in ('For Award', 'Awarded', 'Declined')) [ForAward] ")
        Query.Append("  ,(select count(1) from Form_CRT where subdivision = [B].Subdivision and ContractStatus = 'Awarded') [Awarded] ")
        Query.Append("  ,[C].abbr ")
        Query.Append("  ,[B].Subdivision [SubdCode] ")
        Query.Append("  ,(select count(1) from Form_CRT where subdivision = [B].Subdivision and ContractStatus = 'Cancelled') [Count] ")
        Query.Append("from ")
        Query.Append("  oop_form_hdr [A] ")
        Query.Append("  left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("  left join subdivision [C] on [B].Subdivision = [C].code ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [D] on [C].division = [D].DivCode ")
        Query.Append("where ")
        Query.Append("  [A].tbl_from = 'Form_CRT' ")
        Query.Append("  and [B].ContractStatus = 'Cancelled' ")
        Query.Append("  and [B].Subdivision is not null ")
        Query.Append("  and [B].Subdivision != '' ")
        Query.Append("  and [B].Subdivision != 'Rawland' ")
        Query.Append("  and [D].ProvinceName is not null ")
        Query.Append("  and [D].ProvinceName != '' ")
        Query.Append("group by ")
        Query.Append("  [C].description ")
        Query.Append("  ,[C].address ")
        Query.Append("  ,[D].ProvinceName ")
        Query.Append("  ,[B].Subdivision")
        Query.Append("  ,[C].abbr ")
        Query.Append("order by ")
        Query.Append("  [Awarded] DESC ")
        'get query

        'Create innerhtml
        Dim ProjectHTML As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    ProjectHTML.Append("<div Class='col-md-6 col-xl-4'> ")
                    ProjectHTML.Append("  <div class='card ribbon ribbon-top'> ")
                    ProjectHTML.Append("      <div class='ribbon-label bg-primary'>" & DR("ProvName") & "</div> ")
                    ProjectHTML.Append("      <div class='card-body d-flex flex-center flex-column p-9'> ")
                    ProjectHTML.Append("      <div class='symbol symbol-65px mb-5'> ")
                    ProjectHTML.Append("          <img src='Assets/media/svg/project/" & DR("abbr") & ".svg' alt='" & DR("abbr") & "' /> ")
                    ProjectHTML.Append("      </div> ")
                    ProjectHTML.Append("      <div class='fs-4 text-gray-800 fw-bolder mb-0'>" & DR("Subdivision") & "</div> ")
                    ProjectHTML.Append("      <div class='fw-bold text-gray-400 mb-6'>" & IIf(DR("Address") = "", "-", DR("Address")) & "</div> ")
                    ProjectHTML.Append("      <div class='d-flex flex-center flex-wrap'> ")
                    ProjectHTML.Append("          <div class='border border-dashed rounded min-w-125px py-3 px-4 mx-3 mb-3' style='text-align: center;'> ")
                    ProjectHTML.Append("              <div class='fs-6 fw-bolder text-gray-700'>" & DR("Awarded") & "</div> ")
                    ProjectHTML.Append("              <div class='fw-bold text-gray-400'>Awarded Project</div> ")
                    ProjectHTML.Append("          </div> ")
                    ProjectHTML.Append("      </div> ")
                    ProjectHTML.Append("      <div class='d-flex flex-center flex-wrap mb-5'> ")
                    ProjectHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-danger fs-7 me-3' data-bs-toggle='tooltip' title='Cancelled Projects'>" & DR("Count") & "</span> ")
                    ProjectHTML.Append("      </div> ")
                    ProjectHTML.Append("      <div class='btn btn-sm btn-primary pointer' onclick=""SortedProject('" & DR("SubdCode") & "')""> ")
                    ProjectHTML.Append("          <span class='svg-icon svg-icon-3'> ")
                    ProjectHTML.Append("              <svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    ProjectHTML.Append("                  <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'> ")
                    ProjectHTML.Append("                      <rect x='0' y='0' width='24' height='24'/> ")
                    ProjectHTML.Append("                      <path d='M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z' fill='currentColor' fill-rule='nonzero' opacity='0.3'/> ")
                    ProjectHTML.Append("                      <path d='M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z' fill='currentColor' fill-rule='nonzero'/> ")
                    ProjectHTML.Append("                  </g> ")
                    ProjectHTML.Append("              </svg> ")
                    ProjectHTML.Append("          </span>View Details</div> ")
                    ProjectHTML.Append("      </div> ")
                    ProjectHTML.Append("  </div> ")
                    ProjectHTML.Append("</div> ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'condition
        If ProjectHTML.ToString() = "" Then
            projectEmpty.Style("display") = ""
            ProjectContainer.Visible = False
        Else
            projectEmpty.Style("display") = "none"
            ProjectContainer.Visible = True
        End If

        ProjectContainer.InnerHtml = ProjectHTML.ToString()
    End Function

    Function bindBatch()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [B].ProjName [Subdivision] ")
        Query.Append("  ,[B].Address [Address] ")
        Query.Append("  ,[B].ProvinceName [ProvName] ")
        Query.Append("  ,(select count(1) from Form_HWHdr where Subd = [A].Subd and ConStatus = 'Awarded') [Awarded] ")
        Query.Append("  ,[A].Subd ")
        Query.Append("  ,[B].ProjInit ")
        Query.Append("  ,(select count(1) from Form_HWHdr where Subd = [A].Subd and ConStatus = 'Cancelled') [Count] ")
        Query.Append("from ")
        Query.Append("  Form_HWHdr [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("  [A].ConStatus = 'Cancelled' ")
        Query.Append("group by ")
        Query.Append("  [A].Subd ")
        Query.Append("  ,[B].ProjName ")
        Query.Append("  ,[B].Address ")
        Query.Append("  ,[B].ProvinceName ")
        Query.Append("  ,[B].ProjInit ")
        Query.Append("order by ")
        Query.Append("  [Awarded] DESC ")
        'get query

        'Create innerhtml
        Dim BatchHTML As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    BatchHTML.Append("<div Class='col-md-6 col-xl-4'> ")
                    BatchHTML.Append("  <div class='card ribbon ribbon-top'> ")
                    BatchHTML.Append("      <div class='ribbon-label bg-primary'>" & DR("ProvName") & "</div> ")
                    BatchHTML.Append("      <div class='card-body d-flex flex-center flex-column p-9'> ")
                    BatchHTML.Append("      <div class='symbol symbol-65px mb-5'> ")
                    BatchHTML.Append("          <img src='Assets/media/svg/project/" & DR("ProjInit") & ".svg' alt='" & DR("ProjInit") & "' /> ")
                    BatchHTML.Append("      </div> ")
                    BatchHTML.Append("      <div class='fs-4 text-gray-800 fw-bolder mb-0'>" & DR("Subdivision") & "</div> ")
                    BatchHTML.Append("      <div class='fw-bold text-gray-400 mb-6'>" & IIf(DR("Address") = "", "-", DR("Address")) & "</div> ")
                    BatchHTML.Append("      <div class='d-flex flex-center flex-wrap mb-5'> ")
                    BatchHTML.Append("          <div class='border border-dashed rounded min-w-125px py-3 px-4 mx-3 mb-3' style='text-align: center;'> ")
                    BatchHTML.Append("              <div class='fs-6 fw-bolder text-gray-700'>" & DR("Awarded") & "</div> ")
                    BatchHTML.Append("              <div class='fw-bold text-gray-400'>Awarded Project</div> ")
                    BatchHTML.Append("          </div> ")
                    BatchHTML.Append("      </div> ")
                    BatchHTML.Append("      <div class='d-flex flex-center flex-wrap mb-5'> ")
                    BatchHTML.Append("          <span class='d-flex justify-content-center w-60px badge badge-danger fs-7 me-3' data-bs-toggle='tooltip' title='Cancelled Projects'>" & DR("Count") & "</span> ")
                    BatchHTML.Append("      </div> ")
                    BatchHTML.Append("      <div class='btn btn-sm btn-primary pointer' onclick=""SortedBatch('" & DR("Subd") & "')""> ")
                    BatchHTML.Append("          <span class='svg-icon svg-icon-3'> ")
                    BatchHTML.Append("              <svg xmlns='http://www.w3.org/2000/svg' width='24' height='24' viewBox='0 0 24 24' fill='none'> ")
                    BatchHTML.Append("                  <g stroke='none' stroke-width='1' fill='none' fill-rule='evenodd'> ")
                    BatchHTML.Append("                      <rect x='0' y='0' width='24' height='24'/> ")
                    BatchHTML.Append("                      <path d='M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z' fill='currentColor' fill-rule='nonzero' opacity='0.3'/> ")
                    BatchHTML.Append("                      <path d='M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z' fill='currentColor' fill-rule='nonzero'/> ")
                    BatchHTML.Append("                  </g> ")
                    BatchHTML.Append("              </svg> ")
                    BatchHTML.Append("          </span>View Details</div> ")
                    BatchHTML.Append("      </div> ")
                    BatchHTML.Append("  </div> ")
                    BatchHTML.Append("</div> ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'condition
        If BatchHTML.ToString() = "" Then
            batchEmpty.Style("display") = ""
            BatchContainer.Visible = False
        Else
            batchEmpty.Style("display") = "none"
            BatchContainer.Visible = True
        End If

        BatchContainer.InnerHtml = BatchHTML.ToString()
    End Function

#End Region

#Region "Add ON"
    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Access" Then

            'get total task
            If Type = "View" Then
                Query.Append("if 'SCM010000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SCM010000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SCM010000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SCM010000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SCM010000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SCM010000' and Save_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Msg = DR.GetString(0)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        Return Msg
        'display data

    End Function

#End Region

#Region "Update Deadline"
    Function bindDeadline()

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "SCM_Upd_Deadline"
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

    End Function
#End Region

End Class