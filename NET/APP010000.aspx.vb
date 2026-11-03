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
Imports Microsoft.Extensions.Configuration
Imports System.Web.Services
Imports Newtonsoft.Json.Linq
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports System.Web.Services.Description
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Diagnosti
Imports CrystalDecisions.[Shared]

Public Class APP010000
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
        Master.setActiveMenu("APP", "FRM010000")
        'active account / menu

        If IsPostBack = False Then
            bindCounter()
            'bindTemplate()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)

            'approver
            bind01Approver()
            bind01Project()

            'update approver
            bind02Approver()
            bind02Project()

            'add approval path
            bind03Type()
        ElseIf IsPostBack = True Then
            'nothing
        End If
    End Sub

#End Region

#Region "Button"

#Region "Add Approver"
    Protected Sub btn02ConfirmAddApprover_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Count As String = hfCount.Value
        Dim Project As String = hfProject.Value

        'set value
        tbx01Project.Text = Count
        'set value

        'validation
        Dim Msg As String = Validate("01Restriction", "APP", "Add")
        'validation

        If Msg = 0 Then
            Alert("error", "Access denied!")
        Else

            If ddl01Approver.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf ddl01Approver.SelectedValue = "" Then
                Alert("error", "Some fields are missing!")
            ElseIf tbx01Days.Text = "" Or tbx01Days.Text = 0.00 Then
                Alert("error", "Some fields are missing!")
            Else

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "New_FRM_APP010000"
                SqlCmd.Parameters.AddWithValue("@pCode", hfCode.Value)
                SqlCmd.Parameters.AddWithValue("@pType", ddl01Type.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pApprover", ddl01Approver.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pNoDays", tbx01Days.Text)
                SqlCmd.Parameters.AddWithValue("@pProject", IIf(Project = "", "", Project))
                SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
                'execute procedure

                'reset
                ddl01Type.SelectedValue = ""
                ddl01Approver.SelectedValue = ""
                tbx01Days.Text = "1.00"
                tbx01Project.Text = ""
                hfCount.Value = ""
                Project = ""
                hfProject.Value = ""
                'reset

                'modal
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>triggerReset(); Swal.fire({text: 'Record successfully added.',icon: 'success',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: 'btn btn-primary'}}).then((result) => { viewApprover('" & hfCode.Value & "', '" & hfFormTitle.Value & "'); });</script>", False)
                'modal

                'display record
                Bind01Sequence(hfCode.Value)
                'display record

                mdl02EMP.Update()
            End If

        End If

    End Sub
#End Region

#Region "Update Approver"
    Protected Sub btn04UpdApprover_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'variable
        Dim ID As String = hfUpdApprover.Value
        Dim Code As String = hfUpdCode.Value
        Dim SeqNo As String = hfUpdSeqNo.Value
        Dim Type As String = hfUpdType.Value
        'variable

        If ID <> "" And Code <> "" And SeqNo <> "" And Type <> "" Then

            'validation
            Dim Msg As String = Validate("01Restriction", "APP", "Save")
            'validation

            If Msg = 0 Then
                Alert("error", "Access denied!")
            Else

                'get query
                Dim Query As New StringBuilder
                Query.Append("select ")
                Query.Append("  Type ")
                Query.Append("  ,SeqNo ")
                Query.Append("  ,Approver ")
                Query.Append("  ,NoDays ")
                Query.Append("  ,Project ")
                Query.Append("  ,(case when Project = '' or Project is null then 0 else LEN(Project) - LEN(REPLACE(Project, ',', '')) + 1 end) [Count] ")
                Query.Append("from ")
                Query.Append("  Mstr_AppPathTempDtl ")
                Query.Append("where ")
                Query.Append("  Code = '" & Code & "' ")
                Query.Append("  and Approver = '" & ID & "' ")
                Query.Append("  and Type = '" & Type & "' ")
                Query.Append("  and SeqNo = '" & SeqNo & "' ")
                'get query

                'read record
                Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
                    Using Cmd As New SqlCommand(Query.ToString)
                        Cmd.CommandType = CommandType.Text
                        Cmd.Connection = ConStr
                        ConStr.Open()
                        Dim DR As SqlDataReader = Cmd.ExecuteReader
                        While DR.Read()
                            ddl02Type.SelectedValue = DR("Type")
                            ddl02Approver.SelectedValue = DR("Approver")
                            tbx02SeqNo.Text = DR("SeqNo")
                            tbx02Days.Text = Format(DR("NoDays"), "N2")
                            tbx02Project.Text = DR("Count")
                        End While
                        DR.Close()
                        ConStr.Close()
                    End Using
                End Using
                'read record

                'modal
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01APP').modal('hide'); $('#ContentPlaceHolder1_mdl04UPD').modal('show');</script>", False)
                'modal

                'update
                mdl04UPD.Update()
                'update

            End If

        End If

    End Sub
    Protected Sub btn04ConfirmUpdApprover_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'variable
        Dim Seq As String = hfUpdSeqNo.Value
        Dim Project As String = hfUpdProject.Value
        'variable

        'validation
        Dim Msg As String = Validate("01Restriction", "APP", "Save")
        'validation

        If Msg = 0 Then
            Alert("error", "Access denied!")
        Else

            If ddl02Type.SelectedValue = "" Then
                Alert("Error", "Some fields are missing!")
            ElseIf ddl02Approver.SelectedValue = "" Then
                Alert("Error", "Some fields are missing!")
            ElseIf tbx02Days.Text = "" Or tbx02Days.Text = 0.00 Then
                Alert("Error", "Some fields are missing!")
            Else

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "Upd_FRM_APP010000"
                SqlCmd.Parameters.AddWithValue("@pCode", hfUpdCode.Value)
                SqlCmd.Parameters.AddWithValue("@pSeqNo", Seq)
                SqlCmd.Parameters.AddWithValue("@pType", ddl02Type.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pApprover", ddl02Approver.SelectedValue)
                SqlCmd.Parameters.AddWithValue("@pNoDays", tbx02Days.Text)
                SqlCmd.Parameters.AddWithValue("@pProject", IIf(Project = "", "", Project))
                SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
                'execute procedure

                'reset
                ddl02Type.SelectedValue = ""
                ddl02Approver.SelectedValue = ""
                tbx02Days.Text = "1.00"
                tbx02SeqNo.Text = Seq + 1
                tbx02Project.Text = ""

                Project = ""
                hfUpdCount.Value = ""
                hfUpdProject.Value = ""
                'reset

                'modal
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl04UPD').modal('hide'); triggerResetUpd(); Swal.fire({text: 'Record successfully updated.',icon: 'success',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: 'btn btn-primary'}});</script>", False)
                'modal

            End If
        End If

    End Sub

#End Region

#Region "Delete Approver"
    Protected Sub btn04DelApprover_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'variable
        Dim ID As String = hfUpdApprover.Value
        Dim Code As String = hfUpdCode.Value
        Dim SeqNo As String = hfUpdSeqNo.Value
        Dim Type As String = hfUpdType.Value
        'variable

        If ID <> "" And Code <> "" And SeqNo <> "" And Type <> "" Then

            'validation
            Dim Msg As String = Validate("01Restriction", "APP", "Delete")
            'validation

            If Msg = 0 Then
                Alert("error", "Access denied!")
            Else

                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "Del_FRM_APP010000"
                SqlCmd.Parameters.AddWithValue("@pCode", Code)
                SqlCmd.Parameters.AddWithValue("@pSeqNo", SeqNo)
                SqlCmd.Parameters.AddWithValue("@pType", Type)
                SqlCmd.Parameters.AddWithValue("@pApprover", ID)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
                'execute procedure

                'modal
                ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl01APP').modal('hide'); Swal.fire({text: 'Record successfully removed.',icon: 'success',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: 'btn btn-primary'}});</script>", False)
                'modal

                'update
                mdl01APP.Update()
                'update

            End If

        End If

    End Sub
#End Region

#Region "Add Approval Path"

    Protected Sub lbtn03SaveHdr_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'bindTemplate()
    End Sub

#End Region

#End Region

#Region "Function"
    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "01Restriction" Then
            If Type = "APP" Then
                Query.Append("declare @oConf nvarchar(60) ")
                Query.Append("declare @pUserId nvarchar(13) = (select user_id from duser where emp_no = '" & CIIS_EmpCode & "') ")
                Query.Append(" exec calmardbLive.dbo.JCF_ConfRestriction @pUserId, 'mtFA', '" & Value & "', @oConf output ")
                Query.Append(" select @oConf ")
            End If
        End If

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
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
    Function RenderDataTable()

        'tagged gridview with THEAD / TBODY / TFOOT for datatabe javacript purposes
        If gvProjects.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvProjects.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvProjects.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvProjects.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatabe javacript purposes
        If gvUpdProjects.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvUpdProjects.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvUpdProjects.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvUpdProjects.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindCounter()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull((select count(1) from Mstr_AppPathTempHdr), 0) [Total] ")
        'get query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    spn01Total.InnerText = DR("Total") & " template(s)"
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    'Function bindTemplate()

    '    'get query 
    '    Dim Query As New StringBuilder
    '    Query.Append("select ")
    '    Query.Append("  [A].Code ")
    '    Query.Append("  ,[A].FormCode ")
    '    Query.Append("  ,[A].Title ")
    '    Query.Append("  ,dbo.ProperCase([B].Fullname) [CreatedBy] ")
    '    Query.Append("  ,[A].CreatedBy [EmpNo] ")
    '    Query.Append("  ,Format([A].CreatedDate, 'MM/dd/yyyy') [CreatedDate] ")
    '    Query.Append("  ,(select distinct top 1 dbo.Get_Icon(tbl_from) from oop_form_hdr where dbo.Get_Link(tbl_from) = [A].FormCode) [Icon] ")
    '    Query.Append("from ")
    '    Query.Append("  Mstr_AppPathTempHdr [A] ")
    '    Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
    '    'get query 

    '    'variable
    '    Dim InnerHtml As New StringBuilder
    '    'variable

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()

    '                InnerHtml.Append("<tr id='tr01" & DR("Code") & "'>")
    '                InnerHtml.Append("   <td><a onclick=""viewApprover('" & DR("Code") & "', '" & DR("Title") & "');"" class='text-primary pointer' >" & DR("Code") & "</a></td>")
    '                InnerHtml.Append("   <td>" & DR("FormCode") & "</td>")
    '                InnerHtml.Append("   <td><div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div></td>")
    '                InnerHtml.Append("   <td>" & DR("CreatedDate") & "</td>")
    '                InnerHtml.Append("   <td><div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("EmpNo") & ".png)'></div></div>&nbsp" & DR("CreatedBy") & "</div></td>")
    '                InnerHtml.Append("</tr>")

    '            End While
    '            DR.Close()
    '            ConStr.Close()
    '        End Using
    '    End Using
    '    'read record

    '    'update
    '    tbody01Form.InnerHtml = InnerHtml.ToString
    '    upnl01Form.Update()
    '    'update

    'End Function

    Function Bind01Sequence(Code As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select top 1 SeqNo + 1 [SeqNo] ")
        Query.Append("   from ")
        Query.Append("      Mstr_AppPathTempDtl ")
        Query.Append("   where ")
        Query.Append("      Code = '" & Code & "' ")
        Query.Append("   order by ")
        Query.Append("      SeqNo DESC) [TBL] ")
        Query.Append("  union ")
        Query.Append("  select 1 [SeqNo] ")
        Query.Append("  where not exists ")
        Query.Append("      (select 1 from Mstr_AppPathTempDtl where Code = '" & Code & "') ")
        'get query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    tbx01SeqNo.Text = DR("SeqNo")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        mdl02EMP.Update()
        'display data

    End Function

    Function bind01Approver()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a approver' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Creator' [Code] ")
        Query.Append("      ,'Creator' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Manager' [Code] ")
        Query.Append("      ,'Manager' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Director' [Code] ")
        Query.Append("      ,'Director' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      emp_no ")
        Query.Append("      ,fullname [Description] ")
        Query.Append("      ,lock ")
        Query.Append("   from ")
        Query.Append("      cldc_live_acc.dbo.employee) [TBL] ")
        Query.Append("order by ")
        Query.Append("  (case when [Code] = '' then 1 when [Code] = 'Creator' then 2 when [Code] = 'Manager' then 3 when [Code] = 'Director' then 4 else 5 end) ")
        Query.Append("  ,[Description] ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl01Approver.DataSource = DT
        ddl01Approver.DataValueField = "Code"
        ddl01Approver.DataTextField = "Description"
        ddl01Approver.DataBind()
        'fill data

    End Function

    Function bind02Approver()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      '' [Code] ")
        Query.Append("      ,'Select a approver' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Creator' [Code] ")
        Query.Append("      ,'Creator' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Manager' [Code] ")
        Query.Append("      ,'Manager' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      'Director' [Code] ")
        Query.Append("      ,'Director' [Description] ")
        Query.Append("      ,1 [Lock] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      emp_no ")
        Query.Append("      ,fullname [Description] ")
        Query.Append("      ,lock ")
        Query.Append("   from ")
        Query.Append("      cldc_live_acc.dbo.employee) [TBL] ")
        Query.Append("order by ")
        Query.Append("  (case when [Code] = '' then 1 when [Code] = 'Creator' then 2 when [Code] = 'Manager' then 3 when [Code] = 'Director' then 4 else 5 end) ")
        Query.Append("  ,[Description] ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl02Approver.DataSource = DT
        ddl02Approver.DataValueField = "Code"
        ddl02Approver.DataTextField = "Description"
        ddl02Approver.DataBind()
        'fill data

    End Function

    Function bind01Project()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when [Code] = '' then 'display: none;' else '' end) [Project] ")
        Query.Append("  ,(case when [Code] = '' then 'text-align: center;' else '' end) [Align] ")
        Query.Append("  ,[Code] ")
        Query.Append("  ,[Description] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Quezon' [Description] ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  cast(ProjCode as nvarchar(13)) [Code] ")
        Query.Append("  ,ProjName [Description] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("  Territory = 'QUE' ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Batangas' [Description] ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  cast(ProjCode as nvarchar(13)) [Code] ")
        Query.Append("  ,ProjName [Description] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("  Territory = 'BAT' ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Laguna' [Description] ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  cast(ProjCode as nvarchar(13)) [Code] ")
        Query.Append("  ,ProjName [Description] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("  Territory = 'LAG') [TBL] ")
        'get query

        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Align"))
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("Description"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'add new row
                    Dim NewRowValues As Object() = {DR("Project"), DR("Align"), DR("Code"), DR("Description")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable
        gvProjects.DataSource = dtable
        gvProjects.DataBind()
        RenderDataTable()
        'bind datatable

        'display
        mdl03PRJ.Update()
        'display
    End Function

    Function bind02Project()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (case when [Code] = '' then 'display: none;' else '' end) [Project] ")
        Query.Append("  ,(case when [Code] = '' then 'text-align: center;' else '' end) [Align] ")
        Query.Append("  ,[Code] ")
        Query.Append("  ,[Description] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Quezon' [Description] ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  cast(ProjCode as nvarchar(13)) [Code] ")
        Query.Append("  ,ProjName [Description] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("  Territory = 'QUE' ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Batangas' [Description] ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  cast(ProjCode as nvarchar(13)) [Code] ")
        Query.Append("  ,ProjName [Description] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("  Territory = 'BAT' ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Laguna' [Description] ")
        Query.Append("union all ")
        Query.Append("select ")
        Query.Append("  cast(ProjCode as nvarchar(13)) [Code] ")
        Query.Append("  ,ProjName [Description] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("  Territory = 'LAG') [TBL] ")
        'get query

        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Align"))
        dtable.Columns.Add(New DataColumn("Code"))
        dtable.Columns.Add(New DataColumn("Description"))

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'add new row
                    Dim NewRowValues As Object() = {DR("Project"), DR("Align"), DR("Code"), DR("Description")}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                    'add new row

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'bind datatable
        gvUpdProjects.DataSource = dtable
        gvUpdProjects.DataBind()
        RenderDataTable()
        'bind datatable

        'display
        mdl05UPJ.Update()
        'display
    End Function

    Function bind03Type()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  '' [Code] ")
        Query.Append("  ,'Form Type' [Name] ")
        Query.Append("  ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  [A].FormCode [Code] ")
        Query.Append("  ,[A].description [Name] ")
        Query.Append("  ,[A].description [Order] ")
        Query.Append("from ")
        Query.Append("  oop_form_type [A] ")
        Query.Append("where ")
        Query.Append("  Active = 1 ")
        Query.Append("  and FormCode is not null ")
        Query.Append("order by ")
        Query.Append("  [Order] ")
        'get query

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl03FormType.DataSource = DT
        ddl03FormType.DataValueField = "Code"
        ddl03FormType.DataTextField = "Name"
        ddl03FormType.DataBind()
        'fill data

    End Function
#End Region

#Region "Alert"
    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>   </script>", False)
    End Function

#End Region

End Class