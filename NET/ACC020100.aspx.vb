Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.NetworkInformation

Public Class ACC020100
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
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
            CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "ACC020100")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'Record
            tbxDateFrom.Text = Format(DateAdd(DateInterval.Day, -6, Date.Now), "MM/dd/yyyy")
            tbxDateTo.Text = Format(Date.Now, "MM/dd/yyyy")
            'Record

            'display record
            UpdDTR(tbxDateFrom.Text, tbxDateTo.Text)
            bindDTR(tbxDateFrom.Text, tbxDateTo.Text)
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Protected Sub btnFilter_Click(ByVal sender As Object, e As EventArgs)
        If tbxDateFrom.Text = "" Or tbxDateTo.Text = "" Then
            Alert("error", "Some field(s) are missing!")
            Exit Sub
        End If

        'processing time
        System.Threading.Thread.Sleep(10000)
        'processing time

        UpdDTR(tbxDateFrom.Text, tbxDateTo.Text)
        bindDTR(tbxDateFrom.Text, tbxDateTo.Text)
    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function RenderDatatable()
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvDTR.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvDTR.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvDTR.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvDTR.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function UpdDTR(DateFrom As String, DateTo As String)
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Upd_DTR"
        sqlCmd.Parameters.AddWithValue("@pEmpCode", CIIS_EmpCode)
        sqlCmd.Parameters.AddWithValue("@pDateFrom", DateFrom)
        sqlCmd.Parameters.AddWithValue("@pDateTo", DateTo)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
    End Function

    Function bindDTR(DateFrom As Date, DateTo As Date)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   Format([A].Date,'MM/dd/yyyy') [Date] ")
        Query.Append("   ,[A].Day ")
        Query.Append("   ,[A].Status ")
        Query.Append("   ,Format([A].AMIn,'hh:mm tt') [AMIn] ")
        Query.Append("   ,Format([A].AMOut,'hh:mm tt') [AMOut] ")
        Query.Append("   ,Format([A].PMIn,'hh:mm tt') [PMIn] ")
        Query.Append("   ,Format([A].PMOut,'hh:mm tt') [PMOut] ")
        Query.Append("   ,Format([A].OTAMIn,'hh:mm tt') [OTIn] ")
        Query.Append("   ,Format([A].OTPMout,'hh:mm tt') [OTOut] ")
        Query.Append("   ,(case when [A].CSTick = 1 then 'Approved' else isnull((select top 1 (case when [B].status in ('Declined','Cancelled') then 'w/ File' else '' end) from oop_form_hdr [B] left join hr_form_cs [C] on [B].tbl_code = [C].cs_code where [B].tbl_from = 'hr_form_cs' and [B].created_by = '" & CIIS_EmpCode & "' and [C].cs_date = [A].Date),'') end) [CSTick] ")
        Query.Append("   ,(case when [A].COTick = 1 then 'Approved' else isnull((select top 1 (case when [B].status in ('Declined','Cancelled') then 'w/ File' else '' end) from oop_form_hdr [B] left join hr_form_co [C] on [B].tbl_code = [C].co_code where [B].tbl_from = 'hr_form_co' and [B].created_by = '" & CIIS_EmpCode & "' and ([C].co_from = [A].Date or [C].co_to = [A].Date)),'') end) [COTick] ")
        Query.Append("   ,(case when [A].LVTick = 1 then 'Approved' else isnull((select top 1 (case when [B].status in ('Declined','Cancelled') then 'w/ File' else '' end) from  oop_form_hdr [B] left join hr_form_leave [C] on [B].tbl_code = [C].l_code where [B].tbl_from = 'hr_form_leave' and [B].created_by = '" & CIIS_EmpCode & "' and [A].Date between [C].date_from and [C].date_to),'') end) [LVTick] ")
        Query.Append("   ,(case when [A].OOWTick = 1 then 'Approved' else isnull((select top 1 (case when [B].status in ('Declined','Cancelled') then 'w/ File' else '' end) from oop_form_hdr [B] left join Form_OOWHdr [C] on [B].tbl_code = [C].OOWCode where [B].tbl_from = 'Form_OOWHdr' and [B].created_by = '" & CIIS_EmpCode & "' and [A].Date between cast([C].Departure as date) and cast([C].Arrival as date) and [C].LocType in ('Home','Manual DTR')),'') end) [OOWTick] ")
        Query.Append("   ,(case when [A].TATick = 1 then 'Approved' else isnull((select top 1 (case when [B].status in ('Declined','Cancelled') then 'w/ File' else '' end) from oop_form_hdr [B] left join Form_OOWHdr [C] on [B].tbl_code = [C].OOWCode where [B].tbl_from = 'Form_OOWHdr' and [B].created_by = '" & CIIS_EmpCode & "' and [A].Date between cast([C].Departure as date) and cast([C].Arrival as date) and [C].LocType = 'Other Office'),'') end) [TATick] ")
        Query.Append("   ,(case when [A].OBTick = 1 then 'Approved' else isnull((select top 1 (case when [B].status in ('Declined','Cancelled') then 'w/ File' else '' end) from oop_form_hdr [B] left join Form_OOWHdr [C] on [B].tbl_code = [C].OOWCode where [B].tbl_from = 'Form_OOWHdr' and [B].created_by = '" & CIIS_EmpCode & "' and [A].Date between cast([C].Departure as date) and cast([C].Arrival as date) and [C].LocType = 'Site'),'') end) [OBTick] ")
        Query.Append("   ,(case when [A].OTTick = 1 then 'Approved' else isnull((select top 1 (case when [B].status in ('Declined','Cancelled') then 'w/ File' else '' end) from oop_form_hdr [B] left join Form_OOWHdr [C] on [B].tbl_code = [C].OOWCode where [B].tbl_from = 'Form_OOWHdr' and [B].created_by = '" & CIIS_EmpCode & "' and [A].Date between cast([C].Departure as date) and cast([C].Arrival as date) and [C].LocType = 'Overtime'),'') end) [OTTick] ")
        Query.Append("   ,(case when [A].WOPTick = 1 then 'WOP' else '' end) [WOPTick] ")
        Query.Append("   ,(case when [A].LateTick = 1 then 'LT/UT' else '' end) [LateTick] ")
        Query.Append("   ,(case when [A].FTLTick = 1 then 'FTL' else '' end) [FTLTick] ")
        Query.Append("from ")
        Query.Append("   Trxn_AttendanceDtl [A] ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Date between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("order by ")
        Query.Append("   [A].Date ")
        'get approver 

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("Date"))
        dtable.Columns.Add(New DataColumn("Day"))
        dtable.Columns.Add(New DataColumn("Status"))
        dtable.Columns.Add(New DataColumn("AMIn"))
        dtable.Columns.Add(New DataColumn("AMOut"))
        dtable.Columns.Add(New DataColumn("PMIn"))
        dtable.Columns.Add(New DataColumn("PMOut"))
        dtable.Columns.Add(New DataColumn("OTIn"))
        dtable.Columns.Add(New DataColumn("OTOut"))
        dtable.Columns.Add(New DataColumn("CSTick"))
        dtable.Columns.Add(New DataColumn("COTick"))
        dtable.Columns.Add(New DataColumn("LVTick"))
        dtable.Columns.Add(New DataColumn("OOWTick"))
        dtable.Columns.Add(New DataColumn("TATick"))
        dtable.Columns.Add(New DataColumn("OBTick"))
        dtable.Columns.Add(New DataColumn("OTTick"))
        dtable.Columns.Add(New DataColumn("WOPTick"))
        dtable.Columns.Add(New DataColumn("LateTick"))
        dtable.Columns.Add(New DataColumn("FTLTick"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                Cmd.CommandTimeout = 120 'Command TimeOut
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'add new row
                    Dim NewRowValues As Object() = {DR("Date"), DR("Day"), DR("Status"), DR("AMIn"), DR("AMOut"), DR("PMIn"), DR("PMOut"), DR("OTIn"), DR("OTOut"), DR("CSTick"), DR("COTick"), DR("LVTick"), DR("OOWTick"), DR("TATick"), DR("OBTick"), DR("OTTick"), DR("WOPTick"), DR("LateTick"), DR("FTLTick")}
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
        gvDTR.DataSource = dtable
        gvDTR.DataBind()
        RenderDatatable()
        'bind datatable 

        'display
        upnlDTR.Update()
        'display

    End Function

#End Region

End Class