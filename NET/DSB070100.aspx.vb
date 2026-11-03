Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports Microsoft.Ajax.Utilities

Public Class DSB070100
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_Deparment As String

    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_Deparment = CIIS_UserInfo("CIIS_Department")

        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("DSB", "DSB070100")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'load
            bindSummary()
            bindEmployee()
            'load

        End If
        'load page
    End Sub

#End Region

#Region "Button"

    Protected Sub btnAdd_Click(ByVal sender As Object, e As EventArgs)

        'bind
        bindCategory()
        ddlAdd_Category.SelectedValue = ""
        bindTask("")
        ddlAdd_Task.SelectedValue = ""
        tbxAdd_Priority.Text = ""
        tbxAdd_Summary.Text = ""
        tbxAdd_Remarks.Text = ""
        bindRequestor()
        ddlAdd_CreatedBy.SelectedValue = ""
        'bind

        'update
        mdlAdd.Update()
        'update

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlAdd').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnAdd_Ok_Click(ByVal sender As Object, e As EventArgs)

        If ddlAdd_Category.SelectedValue = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf ddlAdd_Task.SelectedValue = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf tbxAdd_Priority.Text = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf tbxAdd_Summary.Text = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf tbxAdd_Remarks.Text = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf ddlAdd_CreatedBy.SelectedValue = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        End If

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_FRM000002"
        SqlCmd.Parameters.AddWithValue("@pDateRequired", Date.Now)
        SqlCmd.Parameters.AddWithValue("@pCategory", ddlAdd_Category.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pTask", ddlAdd_Task.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pPriority", tbxAdd_Priority.Text)
        SqlCmd.Parameters.AddWithValue("@pSummary", tbxAdd_Summary.Text)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxAdd_Remarks.Text)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", ddlAdd_CreatedBy.SelectedValue)
        Dim oFCode As New SqlClient.SqlParameter("@oFCode", SqlDbType.NVarChar, 1000)
        oFCode.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oFCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'fill record
        bindSummary()
        'fill record

        'clear record
        ddlAdd_Category.SelectedValue = ""
        bindTask("")
        ddlAdd_Task.SelectedValue = ""
        tbxAdd_Priority.Text = ""
        tbxAdd_Summary.Text = ""
        tbxAdd_Remarks.Text = ""
        ddlAdd_CreatedBy.SelectedValue = ""
        'clear record

        'update modal
        mdlAdd.Update()
        'update modal

        'alert success
        Alert("success", "Record successfully added.", "")
        'alert success

    End Sub

    Protected Sub btnList_Click(ByVal sender As Object, e As EventArgs)

        'bind
        bindList(hfView.Value, hfEmpCode.Value)
        'bind

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlList').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnList_Close_Click(ByVal sender As Object, e As EventArgs)

        'display record
        bindSummary()
        bindEmployee()
        'display record

    End Sub

    Protected Sub btnDetail_Click(ByVal sender As Object, e As EventArgs)

        'bind
        bindDetail(hfView.Value, hfID.Value)
        'bind

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlDetail').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnAccept_Click(ByVal sender As Object, e As EventArgs)

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlAccept').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnAccept_Ok_Click(ByVal sender As Object, e As EventArgs)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Upd_FRM_FRM000002_AcceptTicket"
        SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'display record
        bindList(hfView.Value, "")
        'display record

        'success alert
        Alert("success", "Ticket Accepted.", "$('#ContentPlaceHolder1_mdlAccept').modal('hide');")
        'success alert

    End Sub

    Protected Sub btnChangeStatus_Click(ByVal sender As Object, e As EventArgs)

        'set value
        bindChangeStatus(hfID.Value)
        'set value

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlChangeStatus').modal('show');</script>", False)
        'display modal

    End Sub

    Protected Sub btnChangeStatus_Ok_Click(ByVal sender As Object, e As EventArgs)

        If ddlChangeStatus_AssignTo.SelectedValue = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf ddlChangeStatus_Status.SelectedValue = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        ElseIf ddlChangeStatus_Stage.SelectedValue = "" Then
            Alert("error", "Some fields are missing!", "")
            Exit Sub
        End If

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Upd_FRM_FRM000002_ChangeStatus"
        SqlCmd.Parameters.AddWithValue("@pFormCode", "FRM000002")
        SqlCmd.Parameters.AddWithValue("@pID", hfID.Value)
        SqlCmd.Parameters.AddWithValue("@pAssignTo", ddlChangeStatus_AssignTo.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pStatus", ddlChangeStatus_Status.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pStage", ddlChangeStatus_Stage.SelectedValue)
        SqlCmd.Parameters.AddWithValue("@pRemarks", tbxChangeStatus_Note.Text)
        SqlCmd.Parameters.AddWithValue("@pMention", hfMention.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'display record
        bindDetail(hfView.Value, hfID.Value)
        bindList(hfView.Value, hfEmpCode.Value)

        'display record

        'success alert
        Alert("success", "Ticket successfully updated.", "")
        'success alert

    End Sub

    Protected Sub btnReport_MyRequest_Click(ByVal sender As Object, e As EventArgs)

        'set value
        bindReport_MyRequest()
        'set value

        'display modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdlReport_MyRequest').modal('show');</script>", False)
        'display modal

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String, AdditionalScript As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & AdditionalScript & "Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function bindSummary()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'New') [New] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'Not Started') [Notstarted] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'On-Going') [Ongoing] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'On-Hold') [Onhold] ")
        Query.Append("   ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].Status = 'Complete') [Complete] ")

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

                    lblNotstarted.Text = DR("Notstarted")
                    lblNew.Text = DR("New")
                    lblOngoing.Text = DR("Ongoing")
                    lblOnhold.Text = DR("Onhold")
                    lblComplete.Text = DR("Complete")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'update
        upnlSummary.Update()
        'update

    End Function

    Function bindEmployee()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [Code] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Rank] ")
        Query.Append("   ,[Position] ")
        Query.Append("   ,[Total] ")
        Query.Append("   ,[Ongoing] ")
        Query.Append("   ,(case when [Total] > 0 then Format(cast([Ongoing] as decimal(21,2)) / cast([Total] as decimal(21,2)) * 100.00,'N2') else '0.00' end) [OngoingRate] ")
        Query.Append("   ,[Onhold] ")
        Query.Append("   ,(case when [Total] > 0 then Format(cast([Onhold] as decimal(21,2)) / cast([Total] as decimal(21,2)) * 100.00,'N2') else '0.00' end) [OnholdRate] ")
        Query.Append("   ,[Notstarted] ")
        Query.Append("   ,(case when [Total] > 0 then Format(cast([Notstarted] as decimal(21,2)) / cast([Total] as decimal(21,2)) * 100.00,'N2') else '0.00' end) [NotstartedRate] ")
        Query.Append("   ,[Complete] ")
        Query.Append("   ,(case when [Total] > 0 then Format(cast([Complete] as decimal(21,2)) / cast([Total] as decimal(21,2)) * 100.00,'N2') else '0.00' end) [CompleteRate] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      [A].emp_no [Code] ")
        Query.Append("      ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
        Query.Append("      ,[A].JobCategory [Rank] ")
        Query.Append("      ,[A].JobDesc [Position] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no) [Total] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'On-Going') [Ongoing] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'On-Hold') [Onhold] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'Complete') [Complete] ")
        Query.Append("      ,(select count(1) from oop_form_hdr [B] left join Form_BTS [C] on [B].tbl_code = [C].BTSCode where [B].tbl_from = 'Form_BTS' and [B].status not in ('Accepted','Declined','Cancelled') and [C].AssignTo = [A].emp_no and [C].Status = 'Not Started') [Notstarted] ")
        Query.Append("      ,[A].DateHired ")
        Query.Append("   from ")
        Query.Append("      employee [A] ")
        Query.Append("   where ")
        Query.Append("      [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("      and [A].dept_code = '2023000009' ")
        Query.Append("      and [A].lock = 1) [A] ")
        Query.Append("order by ")
        Query.Append("   [A].DateHired ")
        Query.Append("   ,[A].Name ")
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

                    Dim imgUser As String = "Assets/media/avatars/" & DR("Code") & ".png"
                    'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("Code") & ".png")) = True Then
                    '    imgUser = "Assets/media/avatars/" & DR("Code") & ".png"
                    'ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("Code") & ".jpg")) = True Then
                    '    imgUser = "Assets/media/avatars/" & DR("Code") & ".jpg"
                    'Else
                    '    imgUser = "Assets/media/avatars/blank.png"
                    'End If

                    Dim OngoingRate = DR("OngoingRate") & "%"
                    Dim OnholdRate = DR("OnholdRate") & "%"
                    Dim NotstartedRate = DR("NotstartedRate") & "%"
                    Dim CompleteRate = DR("CompleteRate") & "%"

                    If DR("Rank") = "Supervisor" Then
                        InnerHtml.Append("<div class='col-md-6 col-xl-6'> ")
                    Else
                        InnerHtml.Append("<div class='col-md-6 col-xl-4'> ")
                    End If
                    InnerHtml.Append("   <div class='card card-flush'> ")
                    InnerHtml.Append("      <div class='card-header border-0 pt-9'> ")
                    InnerHtml.Append("         <div class='card-title m-0'> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                    InnerHtml.Append("               <div class='symbol symbol-40px me-2'> ")
                    InnerHtml.Append("                  <img src ='" & imgUser & "' alt='image' /> ")
                    InnerHtml.Append("               </div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='fs-6 fw-bold text-dark'>" & DR("Name") & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fs-7'>" & DR("Position") & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("         <div Class='card-toolbar'> ")
                    InnerHtml.Append("		      <div class='symbol symbol-30px'> ")
                    InnerHtml.Append("			     <span class='symbol-label bg-success fw-bolder text-white fs-6'>" & DR("Total") & "</span> ")
                    InnerHtml.Append("		      </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("      <div class='card-body p-9'> ")
                    InnerHtml.Append("         <a class='d-flex flex-stack pointer' onclick=""List('On-Going','" & DR("Code") & "')""> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center me-2'> ")
                    InnerHtml.Append("		         <div class='symbol symbol-30px me-2'> ")
                    InnerHtml.Append("			        <span class='symbol-label bg-info fw-bolder text-white'>G</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("		         <div class='me-2'> ")
                    InnerHtml.Append("			        <span class='text-gray-800 fw-bolder fs-7'>On-going</span> ")
                    InnerHtml.Append("			        <span class='text-muted fw-bolder fs-8 d-block text-start ps-0'>Ticket</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                    InnerHtml.Append("		         <span class='text-gray-800 fw-bolder fs-7 me-3'>" & DR("Ongoing") & "</span> ")
                    InnerHtml.Append("		         <span class='d-flex text-start w-60px badge badge-info fs-7'>" & OngoingRate & "</span> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("         </a> ")
                    InnerHtml.Append("         <div class='separator separator-dashed my-3'></div> ")
                    InnerHtml.Append("         <a class='d-flex flex-stack pointer' onclick=""List('On-Hold','" & DR("Code") & "')""> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center me-2'> ")
                    InnerHtml.Append("		         <div class='symbol symbol-30px me-2'> ")
                    InnerHtml.Append("			        <span class='symbol-label bg-warning fw-bolder text-white'>H</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("		         <div class='me-2'> ")
                    InnerHtml.Append("			        <span class='text-gray-800 fw-bolder fs-7'>On-Hold</span> ")
                    InnerHtml.Append("			        <span class='text-muted fw-bolder fs-8 d-block text-start ps-0'>Ticket</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                    InnerHtml.Append("		         <span class='text-gray-800 fw-bolder fs-7 me-3'>" & DR("Onhold") & "</span> ")
                    InnerHtml.Append("		         <span class='d-flex text-start w-60px badge badge-warning fs-7'>" & OnholdRate & "</span> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("         </a> ")
                    InnerHtml.Append("         <div class='separator separator-dashed my-3'></div> ")
                    InnerHtml.Append("         <a class='d-flex flex-stack pointer' onclick=""List('Not Started','" & DR("Code") & "')""> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center me-2'> ")
                    InnerHtml.Append("		         <div class='symbol symbol-30px me-2'> ")
                    InnerHtml.Append("			        <span class='symbol-label bg-danger fw-bolder text-white'>N</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("		         <div class='me-2'> ")
                    InnerHtml.Append("			        <span class='text-gray-800 fw-bolder fs-7'>Not started</span> ")
                    InnerHtml.Append("			        <span class='text-muted fw-bolder fs-8 d-block text-start ps-0'>Ticket</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                    InnerHtml.Append("		         <span class='text-gray-800 fw-bolder fs-7 me-3'>" & DR("Notstarted") & "</span> ")
                    InnerHtml.Append("		         <span class='d-flex text-start w-60px badge badge-danger fs-7'>" & NotstartedRate & "</span> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("         </a> ")
                    InnerHtml.Append("         <div class='separator separator-dashed my-3'></div> ")
                    InnerHtml.Append("         <a class='d-flex flex-stack pointer' onclick=""List('Complete','" & DR("Code") & "')""> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center me-2'> ")
                    InnerHtml.Append("		         <div class='symbol symbol-30px me-2'> ")
                    InnerHtml.Append("			        <span class='symbol-label bg-success fw-bolder text-white'>C</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("		         <div class='me-2'> ")
                    InnerHtml.Append("			        <span class='text-gray-800 fw-bolder fs-7'>Complete</span> ")
                    InnerHtml.Append("			        <span class='text-muted fw-bolder fs-8 d-block text-start ps-0'>Ticket</span> ")
                    InnerHtml.Append("		         </div> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                    InnerHtml.Append("		         <span class='text-gray-800 fw-bolder fs-7 me-3'>" & DR("Complete") & "</span> ")
                    InnerHtml.Append("		         <span class='d-flex text-start w-60px badge badge-success fs-7'>" & CompleteRate & "</span> ")
                    InnerHtml.Append("	          </div> ")
                    InnerHtml.Append("         </a> ")
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
        divEmployee.InnerHtml = InnerHtml.ToString
        'display

        'update
        upnlEmployee.Update()
        'update

    End Function

    Function bindList(View, EmpCode)

        lblList_Title.Text = View & " Ticket"

        'summary
        If EmpCode = "" Then

            'get approver
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].created_by [ImgRequestor] ")
            Query.Append("   ,[B].AssignTo [ImgAssignTo] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("   ,[B].CreatedDate [Date] ")
            Query.Append("   ,[A].f_code [ID] ")
            Query.Append("   ,[B].Priority ")
            Query.Append("   ,[B].Type ")
            Query.Append("   ,isnull([B].Summary,[B].Remarks) [Summary] ")
            Query.Append("   ,(case when [B].AssignTo = '' then 'None' else dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) end) [AssignTo] ")
            Query.Append("   ,isnull([B].Status,'') [Status] ")
            Query.Append("   ,isnull([B].Stage,'') [Stage] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [B].AssignTo = [D].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].tbl_from = 'Form_BTS' ")
            Query.Append("   and [A].status not in ('Accepted','Declined','Cancelled') ")
            Query.Append("   and [B].Status = '" & View & "' ")
            Query.Append("order by ")
            Query.Append("   [B].CreatedDate ")
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

                        Dim ImgRequestor As String = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                        'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgRequestor") & ".png")) = True Then
                        '    ImgRequestor = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                        'Else
                        '    ImgRequestor = "Assets/media/avatars/blank.png"
                        'End If

                        Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(DR("Date") < Date.Now, Format(DR("Date"), "MMM d"), "Today"))

                        Dim Priority As String = ""
                        If DR("Priority") = "Critical" Then
                            Priority = "<span class='badge badge-light-critical fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "High" Then
                            Priority = "<span class='badge badge-light-high fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "Medium" Then
                            Priority = "<span class='badge badge-light-medium fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "Low" Then
                            Priority = "<span class='badge badge-light-low fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "Lowest" Then
                            Priority = "<span class='badge badge-light-lowest fs-7'>" & DR("Priority") & "</span>"
                        End If

                        Dim ImgAssignTo As String = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                        'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgAssignTo") & ".png")) = True Then
                        '    ImgAssignTo = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                        'Else
                        '    ImgAssignTo = "Assets/media/avatars/blank.png"
                        'End If
                        ImgAssignTo = "<span class='symbol symbol-20px symbol-circle'><img alt ='Pic' src='" & ImgAssignTo & "' /></span>"

                        Dim Status As String = ""
                        If DR("Status") = "New" Then
                            Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "On-Going" Then
                            Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "On-Hold" Then
                            Status = "<span class='text-warning fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "Not Started" Then
                            Status = "<span class='text-danger fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "Complete" Then
                            Status = "<span class='text-success fw-boldest '>" & DR("Status") & "</span>"
                        End If

                        Dim Stage As String = DR("Stage")
                        If DR("Stage") = "Complete" Then
                            Stage = "<span class='text-success fw-boldest '>" & DR("Stage") & "</span>"
                        ElseIf DR("Stage") = "Not Started" Then
                            Stage = "<span class='text-danger fw-boldest '>" & DR("Stage") & "</span>"
                        Else
                            Stage = "<span class='text-info fw-boldest '>" & DR("Stage") & "</span>"
                        End If

                        InnerHtml.Append("<div Class='col-md-4 col-xl-3'> ")
                        InnerHtml.Append("   <div class='card card-flush'> ")
                        InnerHtml.Append("      <div class='card-header'> ")
                        InnerHtml.Append("         <div class='card-title'> ")
                        InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                        InnerHtml.Append("               <div class='symbol symbol-40px me-2'> ")
                        InnerHtml.Append("                  <img src ='" & ImgRequestor & "' alt='image' /> ")
                        InnerHtml.Append("               </div> ")
                        InnerHtml.Append("            </div> ")
                        InnerHtml.Append("            <div class='d-flex flex-column'>  ")
                        InnerHtml.Append("               <span class='fs-6 fw-bold text-dark'>" & DR("Name") & "</span> ")
                        InnerHtml.Append("               <span class='text-muted fs-7'>" & Date_ & "</span> ")
                        InnerHtml.Append("            </div> ")
                        InnerHtml.Append("         </div> ")
                        InnerHtml.Append("      </div> ")
                        InnerHtml.Append("      <a class='card-body pt-0 pb-0 pointer' onclick=""Detail('" & View & "','" & DR("ID") & "')""> ")
                        InnerHtml.Append("         <p class='fs-5 text-dark fw-boldest'>" & DR("ID") & " " & Priority & "</p> ")
                        InnerHtml.Append("         <p class='fs-6 text-dark nowrap-auto'> ")
                        InnerHtml.Append("            <span class='fw-bolder'>" & DR("Type") & "</span></br> ")
                        InnerHtml.Append("            <span>" & DR("Summary") & "</span> ")
                        InnerHtml.Append("         </p> ")
                        InnerHtml.Append("         <p class='fs-7 text-dark'><span class='fw-bold'>Assign to </span>" & ImgAssignTo & " <span class='fw-boldest'> " & DR("AssignTo") & "</span></p> ")
                        InnerHtml.Append("         <p class='fs-7 text-dark'> ")
                        InnerHtml.Append("            <span class='fw-bold'>Status</span> " & Status & "</span></br> ")
                        InnerHtml.Append("            <span class='fw-bold'>Stage</span> <span class='text-info fw-boldest '>" & Stage & "</span> ")
                        InnerHtml.Append("         </p> ")
                        InnerHtml.Append("      </a> ")
                        InnerHtml.Append("      <div class='card-footer pt-0'> ")
                        If View = "New" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""Accept('" & DR("ID") & "')"">Accept</a> ")
                        If View = "On-Going" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                        If View = "On-Hold" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                        If View = "Not Started" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                        If View = "Complete" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
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
            divList.InnerHtml = InnerHtml.ToString
            'display

            'update
            mdlList.Update()
            'update

        End If
        'summary

        'employee
        If EmpCode <> "" Then

            'get approver
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("   [A].created_by [ImgRequestor] ")
            Query.Append("   ,[B].AssignTo [ImgAssignTo] ")
            Query.Append("   ,ROW_NUMBER() OVER(ORDER BY [B].CreatedDate ASC) [SeqNo] ")
            Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("   ,[B].CreatedDate [Date] ")
            Query.Append("   ,[A].f_code [ID] ")
            Query.Append("   ,[B].Priority ")
            Query.Append("   ,[B].Type ")
            Query.Append("   ,isnull([B].Summary,[B].Remarks) [Summary] ")
            Query.Append("   ,(case when [B].AssignTo = '' then 'None' else dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) end) [AssignTo] ")
            Query.Append("   ,isnull([B].Status,'') [Status] ")
            Query.Append("   ,isnull([B].Stage,'') [Stage] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
            Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
            Query.Append("   left join employee [D] on [B].AssignTo = [D].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].tbl_from = 'Form_BTS' ")
            Query.Append("   and [A].status not in ('Accepted','Declined','Cancelled') ")
            Query.Append("   and [B].Status = '" & View & "' ")
            Query.Append("   and [B].AssignTo = '" & EmpCode & "' ")
            Query.Append("order by ")
            Query.Append("   [B].CreatedDate ")
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

                        Dim ImgRequestor As String = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                        'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgRequestor") & ".png")) = True Then
                        '    ImgRequestor = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                        'Else
                        '    ImgRequestor = "Assets/media/avatars/blank.png"
                        'End If

                        Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(DR("Date") < Date.Now, Format(DR("Date"), "MMM d"), "Today"))

                        Dim Priority As String = ""
                        If DR("Priority") = "Critical" Then
                            Priority = "<span class='badge badge-light-critical fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "High" Then
                            Priority = "<span class='badge badge-light-high fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "Medium" Then
                            Priority = "<span class='badge badge-light-medium fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "Low" Then
                            Priority = "<span class='badge badge-light-low fs-7'>" & DR("Priority") & "</span>"
                        ElseIf DR("Priority") = "Lowest" Then
                            Priority = "<span class='badge badge-light-lowest fs-7'>" & DR("Priority") & "</span>"
                        End If

                        Dim ImgAssignTo As String = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                        'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgAssignTo") & ".png")) = True Then
                        '    ImgAssignTo = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                        'Else
                        '    ImgAssignTo = "Assets/media/avatars/blank.png"
                        'End If
                        ImgAssignTo = "<span class='symbol symbol-20px symbol-circle'><img alt ='Pic' src='" & ImgAssignTo & "' /></span>"

                        Dim Status As String = ""
                        If DR("Status") = "New" Then
                            Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "On-Going" Then
                            Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "On-Hold" Then
                            Status = "<span class='text-warning fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "Not Started" Then
                            Status = "<span class='text-danger fw-boldest '>" & DR("Status") & "</span>"
                        ElseIf DR("Status") = "Complete" Then
                            Status = "<span class='text-success fw-boldest '>" & DR("Status") & "</span>"
                        End If

                        Dim Stage As String = DR("Stage")
                        If DR("Stage") = "Complete" Then
                            Stage = "<span class='text-success fw-boldest '>" & DR("Stage") & "</span>"
                        ElseIf DR("Stage") = "Not Started" Then
                            Stage = "<span class='text-danger fw-boldest '>" & DR("Stage") & "</span>"
                        Else
                            Stage = "<span class='text-info fw-boldest '>" & DR("Stage") & "</span>"
                        End If

                        InnerHtml.Append("<div Class='col-md-4 col-xl-3'> ")
                        InnerHtml.Append("   <div class='card card-flush'> ")
                        InnerHtml.Append("      <div class='card-header'> ")
                        InnerHtml.Append("         <div class='card-title'> ")
                        InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                        InnerHtml.Append("               <div class='symbol symbol-40px me-2'> ")
                        InnerHtml.Append("                  <img src ='" & ImgRequestor & "' alt='image' /> ")
                        InnerHtml.Append("               </div> ")
                        InnerHtml.Append("            </div> ")
                        InnerHtml.Append("            <div class='d-flex flex-column'>  ")
                        InnerHtml.Append("               <span class='fs-6 fw-bold text-dark'>" & DR("Name") & "</span> ")
                        InnerHtml.Append("               <span class='text-muted fs-7'>" & Date_ & "</span> ")
                        InnerHtml.Append("            </div> ")
                        InnerHtml.Append("         </div> ")

                        'queu #
                        If View = "Not Started" Then
                            InnerHtml.Append("         <div Class='card-toolbar'> ")
                            InnerHtml.Append("		      <div class='symbol symbol-30px'> ")
                            InnerHtml.Append("			     <span class='symbol-label bg-secondary fw-bolder fs-6'>" & DR("SeqNo") & "</span> ")
                            InnerHtml.Append("		      </div> ")
                            InnerHtml.Append("		   </div> ")
                        End If
                        'queu #

                        InnerHtml.Append("      </div> ")
                        InnerHtml.Append("      <a class='card-body pt-0 pb-0 pointer' onclick=""Detail('" & View & "','" & DR("ID") & "')""> ")
                        InnerHtml.Append("         <p class='fs-5 text-dark fw-boldest'>" & DR("ID") & " " & Priority & "</p> ")
                        InnerHtml.Append("         <p class='fs-6 text-dark nowrap-auto'> ")
                        InnerHtml.Append("            <span class='fw-bolder'>" & DR("Type") & "</span></br> ")
                        InnerHtml.Append("            <span>" & DR("Summary") & "</span> ")
                        InnerHtml.Append("         </p> ")
                        InnerHtml.Append("         <p class='fs-7 text-dark'><span class='fw-bold'>Assign to </span>" & ImgAssignTo & " <span class='fw-boldest'> " & DR("AssignTo") & "</span></p> ")
                        InnerHtml.Append("         <p class='fs-7 text-dark'> ")
                        InnerHtml.Append("            <span class='fw-bold'>Status</span> " & Status & "</span></br> ")
                        InnerHtml.Append("            <span class='fw-bold'>Stage</span> <span class='text-info fw-boldest '>" & Stage & "</span> ")
                        InnerHtml.Append("         </p> ")
                        InnerHtml.Append("      </a> ")
                        InnerHtml.Append("      <div class='card-footer pt-0'> ")
                        If View = "New" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""Accept('" & DR("ID") & "')"">Accept</a> ")
                        If View = "On-Going" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                        If View = "On-Hold" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                        If View = "Not Started" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                        If View = "Complete" Then InnerHtml.Append("         <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
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
            divList.InnerHtml = InnerHtml.ToString
            'display

            'update
            mdlList.Update()
            'update

        End If
        'employee

    End Function

    Function bindDetail(View, ID)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].created_by [ImgRequestor] ")
        Query.Append("   ,[B].AssignTo [ImgAssignTo] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("   ,[B].CreatedDate [Date] ")
        Query.Append("   ,[A].f_code [ID] ")
        Query.Append("   ,[B].Priority ")
        Query.Append("   ,[B].Type ")
        Query.Append("   ,isnull([B].Summary,[B].Remarks) [Summary] ")
        Query.Append("   ,[B].Remarks ")
        Query.Append("   ,(case when [B].AssignTo = '' then 'None' else dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) end) [AssignTo] ")
        Query.Append("   ,isnull([B].Status,'') [Status] ")
        Query.Append("   ,isnull([B].Stage,'') [Stage] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
        Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("   left join employee [D] on [B].AssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ID & "' ")
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

                    Dim ImgRequestor As String = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                    'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgRequestor") & ".png")) = True Then
                    '    ImgRequestor = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                    'ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgRequestor") & ".jpg")) = True Then
                    '    ImgRequestor = "Assets/media/avatars/" & DR("ImgRequestor") & ".jpg"
                    'Else
                    '    ImgRequestor = "Assets/media/avatars/blank.png"
                    'End If

                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(DR("Date") < Date.Now, Format(DR("Date"), "MMM d"), "Today"))

                    Dim Priority As String = ""
                    If DR("Priority") = "Critical" Then
                        Priority = "<span class='badge badge-light-critical fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "High" Then
                        Priority = "<span class='badge badge-light-high fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "Medium" Then
                        Priority = "<span class='badge badge-light-medium fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "Low" Then
                        Priority = "<span class='badge badge-light-low fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "Lowest" Then
                        Priority = "<span class='badge badge-light-lowest fs-7'>" & DR("Priority") & "</span>"
                    End If

                    Dim ImgAssignTo As String = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                    'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgAssignTo") & ".png")) = True Then
                    '    ImgAssignTo = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                    'ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgAssignTo") & ".jpg")) = True Then
                    '    ImgAssignTo = "Assets/media/avatars/" & DR("ImgAssignTo") & ".jpg"
                    'Else
                    '    ImgAssignTo = "Assets/media/avatars/blank.png"
                    'End If
                    ImgAssignTo = "<span class='symbol symbol-20px symbol-circle'><img alt ='Pic' src='" & ImgAssignTo & "' /></span>"

                    Dim Status As String = ""
                    If DR("Status") = "New" Then
                        Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "On-Hold" Then
                        Status = "<span class='text-warning fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "Not Started" Then
                        Status = "<span class='text-danger fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "Complete" Then
                        Status = "<span class='text-success fw-boldest '>" & DR("Status") & "</span>"
                    End If

                    Dim Stage As String = DR("Stage")
                    If DR("Stage") = "Complete" Then
                        Stage = "<span class='text-success fw-boldest '>" & DR("Stage") & "</span>"
                    ElseIf DR("Stage") = "Not Started" Then
                        Stage = "<span class='text-danger fw-boldest '>" & DR("Stage") & "</span>"
                    Else
                        Stage = "<span class='text-info fw-boldest '>" & DR("Stage") & "</span>"
                    End If

                    InnerHtml.Append("<div class='card card-flush'> ")
                    InnerHtml.Append("   <div class='card-header'> ")
                    InnerHtml.Append("      <div class='card-title'> ")
                    InnerHtml.Append("         <div class='d-flex align-items-center'> ")
                    InnerHtml.Append("            <div class='symbol symbol-40px me-2'> ")
                    InnerHtml.Append("               <img src ='" & ImgRequestor & "' alt='image' /> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("         <div class='d-flex flex-column'>  ")
                    InnerHtml.Append("            <span class='fs-6 fw-bold text-dark'>" & DR("Name") & "</span> ")
                    InnerHtml.Append("            <span class='text-muted fs-7'>" & Date_ & "</span> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <a href='FRM000002-DTL-" & DR("ID") & "' class='card-body pt-0 pb-0 pointer'> ")
                    InnerHtml.Append("      <p class='fs-5 text-dark fw-boldest'>" & DR("ID") & " " & Priority & "</p> ")
                    InnerHtml.Append("      <p class='fs-6 text-dark'> ")
                    InnerHtml.Append("         <span class='fw-bolder'>" & DR("Type") & "</span></br> ")
                    InnerHtml.Append("         <span>" & DR("Summary") & "</span> ")
                    InnerHtml.Append("      </p> ")
                    InnerHtml.Append("      <p class='fs-6 text-dark'> ")
                    InnerHtml.Append("         <span>" & DR("Remarks") & "</span> ")
                    InnerHtml.Append("      </p> ")
                    InnerHtml.Append("      </br> ")
                    InnerHtml.Append("      <p class='fs-7 text-dark'><span class='fw-bold'>Assign to </span>" & ImgAssignTo & " <span class='fw-boldest'> " & DR("AssignTo") & "</span></p> ")
                    InnerHtml.Append("      <p class='fs-7 text-dark'> ")
                    InnerHtml.Append("         <span class='fw-bold'>Status</span> " & Status & "</span></br> ")
                    InnerHtml.Append("         <span class='fw-bold'>Stage</span> <span class='text-info fw-boldest '>" & Stage & "</span> ")
                    InnerHtml.Append("      </p> ")
                    InnerHtml.Append("   </a> ")
                    InnerHtml.Append("   <div class='card-footer pt-0'> ")
                    If View = "New" Then InnerHtml.Append("      <a class='btn btn-sm btn-primary pointer' onclick=""Accept('" & DR("ID") & "')"">Accept</a> ")
                    If View = "On-Going" Then InnerHtml.Append("      <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                    If View = "On-Hold" Then InnerHtml.Append("      <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                    If View = "Not Started" Then InnerHtml.Append("      <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                    If View = "Complete" Then InnerHtml.Append("      <a class='btn btn-sm btn-primary pointer' onclick=""ChangeStatus('" & DR("ID") & "')"">Change Status</a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        divDetail.InnerHtml = InnerHtml.ToString
        'display

        'update 
        mdlDetail.Update()
        'update

    End Function

    Function bindChangeStatus(ID)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].AssignTo ")
        Query.Append("   ,[B].Status ")
        Query.Append("   ,[B].Stage ")
        Query.Append("   ,[B].Category ")
        Query.Append("   ,[B].Type ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & ID & "' ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    bindAssignTo()
                    ddlChangeStatus_AssignTo.SelectedValue = DR("AssignTo")
                    ddlChangeStatus_Status.SelectedValue = DR("Status")
                    bindStage(DR("Category"), DR("Type"))
                    ddlChangeStatus_Stage.SelectedValue = DR("Stage")
                    tbxChangeStatus_Note.Text = ""
                    'set value

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'update 
        mdlChangeStatus.Update()
        'update

    End Function

    Function bindCategory()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a category' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].HdrCode [Code] ")
        Query.Append("   ,[A].Description [Name] ")
        Query.Append("   ,[A].Description [Order] ")
        Query.Append("from ")
        Query.Append("   Parm_BTSCategory [A]")
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
        ddlAdd_Category.DataSource = DT
        ddlAdd_Category.DataValueField = "Code"
        ddlAdd_Category.DataTextField = "Name"
        ddlAdd_Category.DataBind()
        'fill data

    End Function

    Function bindTask(Category As String)

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a task' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].DtlCode [Code] ")
        Query.Append("   ,[A].Description [Name] ")
        Query.Append("   ,[A].Description [Order] ")
        Query.Append("from ")
        Query.Append("   Parm_BTSType [A] ")
        Query.Append("where ")
        Query.Append("   [A].HdrCode = '" & Category & "' ")
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
        ddlAdd_Task.DataSource = DT
        ddlAdd_Task.DataValueField = "Code"
        ddlAdd_Task.DataTextField = "Name"
        ddlAdd_Task.DataBind()
        'fill data

        'display record
        mdlAdd.Update()
        'display record

    End Function

    Function bindRequestor()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a user' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee [A] ")
        Query.Append("where ")
        Query.Append("   [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("   and [A].lock = 1 ")
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
        ddlAdd_CreatedBy.DataSource = DT
        ddlAdd_CreatedBy.DataValueField = "Code"
        ddlAdd_CreatedBy.DataTextField = "Name"
        ddlAdd_CreatedBy.DataBind()
        'fill data

    End Function

    Private Sub ddlAdd_Category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAdd_Category.SelectedIndexChanged
        bindTask(ddlAdd_Category.SelectedValue)
    End Sub

    Private Sub ddlAdd_Task_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAdd_Task.SelectedIndexChanged

        'get priority
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   Priority ")
        Query.Append("from ")
        Query.Append("   Parm_BTSType ")
        Query.Append("where ")
        Query.Append("   DtlCode = '" & ddlAdd_Task.SelectedValue & "' ")
        'get priority

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    tbxAdd_Priority.Text = DR("Priority")
                    'set value

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display record
        mdlAdd.Update()
        'display record

    End Sub

    Function bindAssignTo()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select a user' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].emp_no [Code] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
        Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
        Query.Append("from ")
        Query.Append("   employee [A] ")
        Query.Append("where ")
        Query.Append("   [A].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("   and [A].dept_code = '2023000009' ")
        Query.Append("   and [A].lock = 1 ")
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
        ddlChangeStatus_AssignTo.DataSource = DT
        ddlChangeStatus_AssignTo.DataValueField = "Code"
        ddlChangeStatus_AssignTo.DataTextField = "Name"
        ddlChangeStatus_AssignTo.DataBind()
        'fill data

    End Function

    Function bindStage(Category, Type)

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select stage' [Name] ")
        Query.Append("   ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].Description [Code] ")
        Query.Append("   ,[A].Description [Name] ")
        Query.Append("   ,[A].SeqNo [Order] ")
        Query.Append("from ")
        Query.Append("   Parm_BTSStage [A] ")
        Query.Append("   left join Parm_BTSCategory [B] on [A].HdrCode = [B].HdrCode ")
        Query.Append("   left join Parm_BTSType [C] on [A].DtlCode = [C].DtlCode ")
        Query.Append("where ")
        Query.Append("   [B].Description = '" & Category & "' ")
        Query.Append("   and [C].Description = '" & Type & "' ")
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
        ddlChangeStatus_Stage.DataSource = DT
        ddlChangeStatus_Stage.DataValueField = "Code"
        ddlChangeStatus_Stage.DataTextField = "Name"
        ddlChangeStatus_Stage.DataBind()
        'fill data

    End Function

    Function bindReport_MyRequest()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   1 [Order] ")
        Query.Append("   ,[A].created_by [ImgRequestor] ")
        Query.Append("   ,[B].AssignTo [ImgAssignTo] ")
        Query.Append("   ,ROW_NUMBER() OVER(ORDER BY [B].CreatedDate ASC) [SeqNo] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("   ,[B].CreatedDate [Date] ")
        Query.Append("   ,[A].f_code [ID] ")
        Query.Append("   ,[B].Priority ")
        Query.Append("   ,[B].Type ")
        Query.Append("   ,isnull([B].Summary,[B].Remarks) [Summary] ")
        Query.Append("   ,(case when [B].AssignTo = '' then 'None' else dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) end) [AssignTo] ")
        Query.Append("   ,isnull([B].Status,'') [Status] ")
        Query.Append("   ,isnull([B].Stage,'') [Stage] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
        Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("   left join employee [D] on [B].AssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].tbl_from = 'Form_BTS' ")
        Query.Append("   and [A].status not in ('Accepted','Declined','Cancelled') ")
        Query.Append("   and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [B].Status = 'New' ")

        Query.Append("union ")

        Query.Append("select ")
        Query.Append("   2 [Order] ")
        Query.Append("   ,[A].created_by [ImgRequestor] ")
        Query.Append("   ,[B].AssignTo [ImgAssignTo] ")
        Query.Append("   ,ROW_NUMBER() OVER(ORDER BY [B].CreatedDate ASC) [SeqNo] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("   ,[B].CreatedDate [Date] ")
        Query.Append("   ,[A].f_code [ID] ")
        Query.Append("   ,[B].Priority ")
        Query.Append("   ,[B].Type ")
        Query.Append("   ,isnull([B].Summary,[B].Remarks) [Summary] ")
        Query.Append("   ,(case when [B].AssignTo = '' then 'None' else dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) end) [AssignTo] ")
        Query.Append("   ,isnull([B].Status,'') [Status] ")
        Query.Append("   ,isnull([B].Stage,'') [Stage] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
        Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("   left join employee [D] on [B].AssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].tbl_from = 'Form_BTS' ")
        Query.Append("   and [A].status not in ('Accepted','Declined','Cancelled') ")
        Query.Append("   and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [B].Status = 'On-Going' ")

        Query.Append("union ")

        Query.Append("select ")
        Query.Append("   3 [Order] ")
        Query.Append("   ,[A].created_by [ImgRequestor] ")
        Query.Append("   ,[B].AssignTo [ImgAssignTo] ")
        Query.Append("   ,ROW_NUMBER() OVER(ORDER BY [B].CreatedDate ASC) [SeqNo] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("   ,[B].CreatedDate [Date] ")
        Query.Append("   ,[A].f_code [ID] ")
        Query.Append("   ,[B].Priority ")
        Query.Append("   ,[B].Type ")
        Query.Append("   ,isnull([B].Summary,[B].Remarks) [Summary] ")
        Query.Append("   ,(case when [B].AssignTo = '' then 'None' else dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) end) [AssignTo] ")
        Query.Append("   ,isnull([B].Status,'') [Status] ")
        Query.Append("   ,isnull([B].Stage,'') [Stage] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
        Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("   left join employee [D] on [B].AssignTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].tbl_from = 'Form_BTS' ")
        Query.Append("   and [A].status not in ('Accepted','Declined','Cancelled') ")
        Query.Append("   and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [B].Status = 'On-Hold' ")

        Query.Append("union ")


        Query.Append("select ")
        Query.Append("   [Order] ")
        Query.Append("   ,[ImgRequestor] ")
        Query.Append("   ,[ImgAssignTo] ")
        Query.Append("   ,[SeqNo] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Priority] ")
        Query.Append("   ,[Type] ")
        Query.Append("   ,[Summary] ")
        Query.Append("   ,[AssignTo] ")
        Query.Append("   ,[Status] ")
        Query.Append("   ,[Stage] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      4 [Order] ")
        Query.Append("      ,[A].created_by [ImgRequestor] ")
        Query.Append("      ,[B].AssignTo [ImgAssignTo] ")
        Query.Append("      ,ROW_NUMBER() OVER(PARTITION BY [B].AssignTo ORDER BY [B].CreatedDate ASC) [SeqNo] ")
        Query.Append("      ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("      ,[B].CreatedDate [Date] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,[B].Priority ")
        Query.Append("      ,[B].Type ")
        Query.Append("      ,isnull([B].Summary,[B].Remarks) [Summary] ")
        Query.Append("      ,(case when [B].AssignTo = '' then 'None' else dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) end) [AssignTo] ")
        Query.Append("      ,isnull([B].Status,'') [Status] ")
        Query.Append("      ,isnull([B].Stage,'') [Stage] ")
        Query.Append("      ,[A].created_by [CreatedBy] ")
        Query.Append("   from ")
        Query.Append("      oop_form_hdr [A] ")
        Query.Append("      left join Form_BTS [B] on [A].tbl_code = [B].BTSCode ")
        Query.Append("      left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("      left join employee [D] on [B].AssignTo = [D].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_BTS' ")
        Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled') ")
        Query.Append("      and [B].Status = 'Not Started') [A] ")
        Query.Append("where ")
        Query.Append("   [CreatedBy] = '" & CIIS_EmpCode & "' ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[ImgAssignTo] ")
        Query.Append("   ,[Date] ")
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

                    Dim ImgRequestor As String = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                    'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgRequestor") & ".png")) = True Then
                    '    ImgRequestor = "Assets/media/avatars/" & DR("ImgRequestor") & ".png"
                    'Else
                    '    ImgRequestor = "Assets/media/avatars/blank.png"
                    'End If

                    Dim Date_ As String = IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(DR("Date") < Date.Now, Format(DR("Date"), "MMM d"), "Today"))

                    Dim Priority As String = ""
                    If DR("Priority") = "Critical" Then
                        Priority = "<span class='badge badge-light-critical fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "High" Then
                        Priority = "<span class='badge badge-light-high fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "Medium" Then
                        Priority = "<span class='badge badge-light-medium fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "Low" Then
                        Priority = "<span class='badge badge-light-low fs-7'>" & DR("Priority") & "</span>"
                    ElseIf DR("Priority") = "Lowest" Then
                        Priority = "<span class='badge badge-light-lowest fs-7'>" & DR("Priority") & "</span>"
                    End If

                    Dim ImgAssignTo As String = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                    'If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR("ImgAssignTo") & ".png")) = True Then
                    '    ImgAssignTo = "Assets/media/avatars/" & DR("ImgAssignTo") & ".png"
                    'Else
                    '    ImgAssignTo = "Assets/media/avatars/blank.png"
                    'End If
                    ImgAssignTo = "<span class='symbol symbol-20px symbol-circle'><img alt ='Pic' src='" & ImgAssignTo & "' /></span>"

                    Dim Status As String = ""
                    If DR("Status") = "New" Then
                        Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Status = "<span class='text-info fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "On-Hold" Then
                        Status = "<span class='text-warning fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "Not Started" Then
                        Status = "<span class='text-danger fw-boldest '>" & DR("Status") & "</span>"
                    ElseIf DR("Status") = "Complete" Then
                        Status = "<span class='text-success fw-boldest '>" & DR("Status") & "</span>"
                    End If

                    Dim Stage As String = DR("Stage")
                    If DR("Stage") = "Complete" Then
                        Stage = "<span class='text-success fw-boldest '>" & DR("Stage") & "</span>"
                    ElseIf DR("Stage") = "Not Started" Then
                        Stage = "<span class='text-danger fw-boldest '>" & DR("Stage") & "</span>"
                    Else
                        Stage = "<span class='text-info fw-boldest '>" & DR("Stage") & "</span>"
                    End If

                    InnerHtml.Append("<div Class='col-md-4 col-xl-3'> ")
                    InnerHtml.Append("   <div class='card card-flush'> ")
                    InnerHtml.Append("      <div class='card-header'> ")
                    InnerHtml.Append("         <div class='card-title'> ")
                    InnerHtml.Append("            <div class='d-flex align-items-center'> ")
                    InnerHtml.Append("               <div class='symbol symbol-40px me-2'> ")
                    InnerHtml.Append("                  <img src ='" & ImgRequestor & "' alt='image' /> ")
                    InnerHtml.Append("               </div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'>  ")
                    InnerHtml.Append("               <span class='fs-6 fw-bold text-dark'>" & DR("Name") & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fs-7'>" & Date_ & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")

                    'queu #
                    If DR("Status") = "Not Started" Then
                        InnerHtml.Append("         <div Class='card-toolbar'> ")
                        InnerHtml.Append("		      <div class='symbol symbol-30px'> ")
                        InnerHtml.Append("			     <span class='symbol-label bg-secondary fw-bolder fs-6'>" & DR("SeqNo") & "</span> ")
                        InnerHtml.Append("		      </div> ")
                        InnerHtml.Append("		   </div> ")
                    End If
                    'queu #

                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("      <a href='FRM000002-DTL-" & DR("ID") & "' class='card-body pt-0 pb-0 pointer'> ")
                    InnerHtml.Append("         <p class='fs-5 text-dark fw-boldest'>" & DR("ID") & " " & Priority & "</p> ")
                    InnerHtml.Append("         <p class='fs-6 text-dark nowrap-auto'> ")
                    InnerHtml.Append("            <span class='fw-bolder'>" & DR("Type") & "</span></br> ")
                    InnerHtml.Append("            <span>" & DR("Summary") & "</span> ")
                    InnerHtml.Append("         </p> ")
                    InnerHtml.Append("         <p class='fs-7 text-dark'><span class='fw-bold'>Assign to </span>" & ImgAssignTo & " <span class='fw-boldest'> " & DR("AssignTo") & "</span></p> ")
                    InnerHtml.Append("         <p class='fs-7 text-dark'> ")
                    InnerHtml.Append("            <span class='fw-bold'>Status</span> " & Status & "</span></br> ")
                    InnerHtml.Append("            <span class='fw-bold'>Stage</span> <span class='text-info fw-boldest '>" & Stage & "</span> ")
                    InnerHtml.Append("         </p> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("      <div class='card-footer pt-0'> ")
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
        divReport_MyRequest.InnerHtml = InnerHtml.ToString
        'display

        'update
        mdlReport_MyRequest.Update()
        'update

    End Function

#End Region

End Class