Imports System.Data.SqlClient

Public Class FIN010000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
    Dim SubID As String = "006"
    Dim dtAssignTo_Dtl As New DataTable

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
        Master.setActiveMenu("APP", "FIN010000")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'filter
            bind02AssignTo()
            bind02Batch()
            bind02Contractor()
            'filter

            'content
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
            'content

        End If
        'load page

    End Sub

#End Region

#Region "Filter"

    Function bind02AssignTo()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Assign to' [Name] ")
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
        ddl02AssignTo.DataSource = DT
        ddl02AssignTo.DataValueField = "Code"
        ddl02AssignTo.DataTextField = "Name"
        ddl02AssignTo.DataBind()
        'fill data

        'default value
        ddl02AssignTo.SelectedValue = CIIS_EmpCode
        'default value

    End Function

    Function bind02Batch()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Batch' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].BatchNo [Code] ")
        Query.Append("   ,[A].BatchNo [Name] ")
        Query.Append("   ,[A].DateReleased [Order] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_BatchNo [A] ")
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
        ddl02Batch.DataSource = DT
        ddl02Batch.DataValueField = "Code"
        ddl02Batch.DataTextField = "Name"
        ddl02Batch.DataBind()
        'fill data

    End Function

    Function bind02Contractor()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Contractor' [Name] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].v_code [Code] ")
        Query.Append("   ,[A].vendor [Name] ")
        Query.Append("   ,[A].vendor [Order] ")
        Query.Append("from ")
        Query.Append("   ogm_vendor [A] ")
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
        ddl02Contractor.DataSource = DT
        ddl02Contractor.DataValueField = "Code"
        ddl02Contractor.DataTextField = "Name"
        ddl02Contractor.DataBind()
        'fill data

    End Function

#End Region

#Region "Billing"

    Protected Sub btn01BillingAmount_Click(ByVal sender As Object, ByVal e As EventArgs)

        'Validate if any record is selected
        Dim IDSrs = Request.Form("selectedIDs")
        'Validate if any record is selected

        'validate
        If IDSrs = "" Then
            Alert("error", "No record selected.")
            Exit Sub
        End If
        'validate

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [ID] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[E].vendor [Contractor] ")
        Query.Append("   ,[B].ConNo [No] ")
        Query.Append("   ,FORMAT([B].ConPrice,'N2') [Price] ")
        Query.Append("   ,FORMAT([B].BillAmt,'N2') [Billed] ")
        Query.Append("   ,FORMAT([B].TCPBal,'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [B].ConStatus = 'Awarded'")
        Query.Append("   and [B].ConPrice > isnull([B].BillAmt,0) ")
        Query.Append("   and [A].HWCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("union  ")
        Query.Append("select  ")
        Query.Append("   [A].f_code [ID] ")
        Query.Append("   ,[A].FormTitle [Title] ")
        Query.Append("   ,[C].vendor [Contractor] ")
        Query.Append("   ,[B].ContractNo [No] ")
        Query.Append("   ,FORMAT([B].ContractPrice,'N2') [Price] ")
        Query.Append("   ,FORMAT([B].BillAmt,'N2') [Billed] ")
        Query.Append("   ,FORMAT([B].TCPBal,'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("   left join ogm_vendor [C] on [B].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("   [A].status Not in ('Cancelled','Declined')")
        Query.Append("   and [A].tbl_from = 'Form_CRT' ")
        Query.Append("   and [B].ContractStatus = 'Awarded'")
        Query.Append("   and [B].ContractPrice > isnull([B].BillAmt,0) ")
        Query.Append("   and [A].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        'get item

        'Create DataTable
        Dim dtable As New DataTable()
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                dtable.Load(DR)
                ConStr.Close()
            End Using
        End Using
        'Create DataTable

        'Bind data to Repeater
        mdl03Billing.Update()
        rptr03Billing.DataSource = dtable
        rptr03Billing.DataBind()

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl03Billing').modal('show');</script>", False)
        'modal
    End Sub

    Protected Sub btn01BillingRate_Click(ByVal sender As Object, ByVal e As EventArgs)

        'Validate if any record is selected
        Dim IDSrs = Request.Form("selectedIDs")
        'Validate if any record is selected

        'validate
        If IDSrs = "" Then
            Alert("error", "No record selected.")
            Exit Sub
        End If
        'validate

        'get item
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [ID] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[E].vendor [Contractor] ")
        Query.Append("   ,[B].ConNo [No] ")
        Query.Append("   ,FORMAT([B].ConPrice,'N2') [Price] ")
        Query.Append("   ,FORMAT([B].BillAmt,'N2') [Billed] ")
        Query.Append("   ,FORMAT([B].TCPBal,'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [B].ConStatus = 'Awarded'")
        Query.Append("   and [B].ConPrice > isnull([B].BillAmt,0) ")
        Query.Append("   and [A].HWCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("union  ")
        Query.Append("select  ")
        Query.Append("   [A].f_code [ID] ")
        Query.Append("   ,[A].FormTitle [Title] ")
        Query.Append("   ,[C].vendor [Contractor] ")
        Query.Append("   ,[B].ContractNo [No] ")
        Query.Append("   ,FORMAT([B].ContractPrice,'N2') [Price] ")
        Query.Append("   ,FORMAT([B].BillAmt,'N2') [Billed] ")
        Query.Append("   ,FORMAT([B].TCPBal,'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_CRT [B] on [A].tbl_code = [B].CRTCode ")
        Query.Append("   left join ogm_vendor [C] on [B].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("   [A].status Not in ('Cancelled','Declined')")
        Query.Append("   and [A].tbl_from = 'Form_CRT' ")
        Query.Append("   and [B].ContractStatus = 'Awarded'")
        Query.Append("   and [B].ContractPrice > isnull([B].BillAmt,0) ")
        Query.Append("   and [A].f_code in (select * from SplitString('" & IDSrs & "',',')) ")
        'get item

        'Create DataTable
        Dim dtable As New DataTable()
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                dtable.Load(DR)
                ConStr.Close()
            End Using
        End Using
        'Create DataTable

        'Bind data to Repeater
        mdl05Billing.Update()
        rptr05Billing.DataSource = dtable
        rptr05Billing.DataBind()

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl05Billing').modal('show');</script>", False)
        'modal
    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none",
        "<script>
           setTimeout(function() {
              Swal.fire({
                 text: '" & Message_ & "',
                 icon: '" & Alert_ & "',
                 buttonsStyling: false,
                 confirmButtonText: 'Ok, got it!',
                 customClass: {
                    confirmButton: '" & class_ & "'
                 }
              }).then((result) => {
                 if (result.isConfirmed) {
                    " & IIf(Alert_ = "success", "$('#ContentPlaceHolder1_mdl03Billing').modal('hide'); lbtn01Update();", "console.log('Error');") & "
              }
           });
        }, 200);
    </script>", False)
    End Function

#End Region

End Class