Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Web.Script.Serialization
Imports System.Threading.Tasks

Public Class SCM030100
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    Dim SubID As String = "005"
    Dim dtAssignTo_Dtl As New DataTable
    Dim dtContractor_Dtl As New DataTable
    Dim dtBOQ_Dtl As New DataTable

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("SCM030100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SCM030100")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'filter
            bind02AssignTo()
            bind02Batch()
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

#End Region

#Region "Change Status"

    Private Sub bind03AssignTo_Hdr()

        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select User (All)' [Name] ")
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

        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)

        ddl03AssignTo_Hdr.DataSource = DT
        ddl03AssignTo_Hdr.DataValueField = "Code"
        ddl03AssignTo_Hdr.DataTextField = "Name"
        ddl03AssignTo_Hdr.DataBind()
    End Sub

    Function bind03AssignTo_Dtl()
        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select User' [Name] ")
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
        SDA.Fill(dtAssignTo_Dtl)
        'execute query

    End Function

    Protected Sub btn01Status_Click(ByVal sender As Object, ByVal e As EventArgs)

        'Populate the dropdown
        bind03AssignTo_Hdr()
        bind03AssignTo_Dtl()
        bind05Contractor_Hdr()
        bind05Contractor_Dtl()
        'Populate the dropdown

        'default
        ddl03Status_Hdr.SelectedValue = ""
        'default

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
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].HWCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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
        mdl03Status.Update()
        rptr03Status.DataSource = dtable
        rptr03Status.DataBind()

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl03Status').modal('show');</script>", False)
        'modal
    End Sub

    Protected Sub rptr03Status_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles rptr03Status.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ' Find the DropDownList
            Dim ddl03AssignTo_Dtl As DropDownList = DirectCast(e.Item.FindControl("ddl03AssignTo_Dtl"), DropDownList)
            ddl03AssignTo_Dtl.DataSource = dtAssignTo_Dtl
            ddl03AssignTo_Dtl.DataValueField = "Code"
            ddl03AssignTo_Dtl.DataTextField = "Name"
            ddl03AssignTo_Dtl.DataBind()
            ' Get the ID from the bound data and assign it as an attribute
            Dim rowID As String = DataBinder.Eval(e.Item.DataItem, "ID").ToString()
            ddl03AssignTo_Dtl.Attributes.Add("prm03assign", rowID)
        End If
    End Sub

#End Region

#Region "Update Contract"

    Function bind05BOQ_Hdr()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select BOQ' [Name] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [CECode] [Code] ")
        Query.Append("	 ,[Title] [Name] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 Trxn_CEHdr [A] ")
        Query.Append("where ")
        Query.Append("   [A].Lock = 1 ")
        Query.Append("   and [A].Post = 1 ")
        Query.Append("   and [A].Rvrs = 0 ")
        Query.Append("   and [A].Category = 'House Construction' ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Name] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl05BOQ_Hdr.DataSource = DT
        ddl05BOQ_Hdr.DataValueField = "Code"
        ddl05BOQ_Hdr.DataTextField = "Name"
        ddl05BOQ_Hdr.DataBind()
        'fill data

    End Function

    Function bind05BOQ_Dtl()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select BOQ' [Name] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [CECode] [Code] ")
        Query.Append("	 ,[Title] [Name] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 Trxn_CEHdr [A] ")
        Query.Append("where ")
        Query.Append("   [A].Lock = 1 ")
        Query.Append("   and [A].Post = 1 ")
        Query.Append("   and [A].Rvrs = 0 ")
        Query.Append("   and [A].Category = 'House Construction' ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Name] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        SDA.Fill(dtBOQ_Dtl)
        'execute query

    End Function

    Function bind05Contractor_Hdr()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Contractor (All)' [Name] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [v_code] [Code] ")
        Query.Append("	 ,[vendor] [Name] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 ogm_vendor ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Name] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddl05Contractor_Hdr.DataSource = DT
        ddl05Contractor_Hdr.DataValueField = "Code"
        ddl05Contractor_Hdr.DataTextField = "Name"
        ddl05Contractor_Hdr.DataBind()
        'fill data

    End Function

    Function bind05Contractor_Dtl()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select Contractor' [Name] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [v_code] [Code] ")
        Query.Append("	 ,[vendor] [Name] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 ogm_vendor ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Name] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        SDA.Fill(dtContractor_Dtl)
        'execute query

    End Function

    Protected Sub btn01Contract_Click(ByVal sender As Object, ByVal e As EventArgs)

        'Populate the dropdown
        bind05Contractor_Hdr()
        bind05Contractor_Dtl()
        'Populate the dropdown

        'default
        ddl05Contractor_Hdr.SelectedValue = ""
        ddl05Category_Hdr.SelectedValue = ""
        ddl05Type_Hdr.SelectedValue = ""
        tbx05No_Hdr.Text = ""
        tbx05Price_Hdr.Value = "0.00"
        tbx05VAT_Hdr.Value = "0.00"
        tbx05EWT_Hdr.Value = "0.00"
        tbx05DP_Hdr.Value = "0.00"
        tbx05RF_Hdr.Value = "0.00"
        tbx05PriorStart_Hdr.Value = "0.00"
        ddl05Status_Hdr.SelectedValue = ""
        tbx05Date_Hdr.Value = ""
        'default

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
        Query.Append("   [B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,isnull([B].Contractor,'') [Contractor] ")
        Query.Append("   ,[B].ConCategory [Category] ")
        Query.Append("   ,[B].ConType [Type] ")
        Query.Append("   ,[B].ConNo [No] ")
        Query.Append("   ,FORMAT([B].ConPrice,'N2') [Price] ")
        Query.Append("   ,FORMAT([B].VAT,'N2') [VAT] ")
        Query.Append("   ,FORMAT([B].EWT,'N2') [EWT] ")
        Query.Append("   ,FORMAT([B].DP,'N2') [DP] ")
        Query.Append("   ,FORMAT([B].RF,'N2') [RF] ")
        Query.Append("   ,FORMAT([B].ConPriorStart,'N2') [PriorStart] ")
        Query.Append("   ,[B].ConStatus [Status] ")
        Query.Append("   ,isnull(FORMAT([B].ConDate,'MM/dd/yyyy'),'') [Date] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status not in ('Close','Complete') ")
        Query.Append("   and [A].HWCode in (select * from SplitString('" & IDSrs & "',',')) ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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
        mdl05Contract.Update()
        rptr05Contractor.DataSource = dtable
        rptr05Contractor.DataBind()

        'modal
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>$('#ContentPlaceHolder1_mdl05Contract').modal('show');</script>", False)
        'modal

    End Sub

    Protected Sub rptr05Contractor_ItemDataBound(ByVal sender As Object, ByVal e As RepeaterItemEventArgs) Handles rptr05Contractor.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            'Find the DropDownList
            Dim ddl05BOQ_Dtl As DropDownList = DirectCast(e.Item.FindControl("ddl05BOQ_Dtl"), DropDownList)
            ddl05BOQ_Dtl.DataSource = dtBOQ_Dtl
            ddl05BOQ_Dtl.DataValueField = "Code"
            ddl05BOQ_Dtl.DataTextField = "Name"
            ddl05BOQ_Dtl.DataBind()
            'Find the DropDownList
            Dim ddl05Contractor_Dtl As DropDownList = DirectCast(e.Item.FindControl("ddl05Contractor_Dtl"), DropDownList)
            ddl05Contractor_Dtl.DataSource = dtContractor_Dtl
            ddl05Contractor_Dtl.DataValueField = "Code"
            ddl05Contractor_Dtl.DataTextField = "Name"
            ddl05Contractor_Dtl.DataBind()
            'Get the ID from the bound data And assign it as an attribute
            Dim rowID As String = DataBinder.Eval(e.Item.DataItem, "ID").ToString()
            ddl05BOQ_Dtl.Attributes.Add("prm05boq", rowID)
            ddl05Contractor_Dtl.Attributes.Add("prm05contractor", rowID)
        End If
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
                    " & IIf(Alert_ = "success", "$('#ContentPlaceHolder1_mdl03Status').modal('hide'); lbtn01Update();", "console.log('Error');") & "
              }
           });
        }, 200);
    </script>", False)
    End Function

#End Region

End Class