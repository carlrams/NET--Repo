Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices

Public Class DSB010000
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
        Master.setActiveMenu("DSB", "DSB010000")
        'active account / menu

        'load page
        If IsPostBack = False Then
            bindEvent()
            bindCounter()
        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

    Function RenderDatatable()
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        'If gvFRM_Summary.Rows.Count > 0 Then
        '    'Adds THEAD and TBODY Section.
        '    gvFRM_Summary.HeaderRow.TableSection = TableRowSection.TableHeader
        '    'Adds THEAD and TBODY Section.

        '    'Adds TH element in Header Row.  
        '    gvFRM_Summary.UseAccessibleHeader = True
        '    'Adds TH element in Header Row.  

        '    'Adds TFOOT section. 
        '    gvFRM_Summary.FooterRow.TableSection = TableRowSection.TableFooter
        '    'Adds TFOOT section. 
        'End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        'If gvWO_Summary.Rows.Count > 0 Then
        'Adds THEAD and TBODY Section.
        'gvWO_Summary.HeaderRow.TableSection = TableRowSection.TableHeader
        'Adds THEAD and TBODY Section.

        'Adds TH element in Header Row.  
        'gvWO_Summary.UseAccessibleHeader = True
        'Adds TH element in Header Row.  

        'Adds TFOOT section. 
        'gvWO_Summary.FooterRow.TableSection = TableRowSection.TableFooter
        'Adds TFOOT section. 
        'End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

#End Region

#Region "Overview"

    Function bindCounter()

        'query
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	 isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Endorsed By') and status not in ('Accepted','Declined','Cancelled')),0) [Endorse] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Approved By') and status not in ('Accepted','Declined','Cancelled')),0) [Approve] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Implementer') and status not in ('Accepted','Declined','Cancelled')),0) [Implement] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Clarification') and status not in ('Accepted','Declined','Cancelled')),0) [Clarify] ")
        Query.Append("	 ,isnull((select count(1) from oop_form_hdr where approver = '" & CIIS_EmpCode & "' And approver_type in ('Creator') and status not in ('Accepted','Declined','Cancelled')),0) [ForCancel] ")

        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Assigned')),0) [WOAssigned] ")
        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Accepted')),0) [WOAccepted] ")
        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Completed')),0) [WOCompleted] ")
        Query.Append("	 ,isnull((select count(1) from oop_wo_hdr where assigned_to = '" & CIIS_EmpCode & "' And status in ('Clarify')),0) [WOClarify] ")

        'PDD
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'PDD010101') then isnull((select count(1) from Form_HWTask where TaskCode = '001' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [PDD010101] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'PDD010201') then isnull((select count(1) from Form_HWTask where TaskCode = '012' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [PDD010201] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'PDD010301') then isnull((select count(1) from Form_HWTask where TaskCode = '007' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [PDD010301] ")
        'PDD

        'ENG
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG010101') then isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category = 'Land Development New' and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going','On-Hold','Complete','Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) else 0 end) [ENG010101] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG010201') then isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category = 'Land Development Repair' and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going','On-Hold','Complete','Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) else 0 end) [ENG010201] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG010301') then isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category = 'Amenities New' and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going','On-Hold','Complete','Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) else 0 end) [ENG010301] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG010401') then isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category = 'Amenities Repair' and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going','On-Hold','Complete','Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) else 0 end) [ENG010401] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG010501') then isnull((select count(1) from Form_HWTask where TaskCode = '006' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG010501] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG010601') then isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category = 'House Repair' and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going','On-Hold','Complete','Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) else 0 end) [ENG010601] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG010601') then isnull((select count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code where [A].Category not in ('Land Development New','Land Development Repair','Amenities New','Amenities Repair','House Construction','House Repair') and [A].POCAssignTo = '" & CIIS_EmpCode & "' and [A].POCStatus in ('','Assign','On-Going','On-Hold','Complete','Clarify') and [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined')),0) else 0 end) [ENG010701] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG020101') then isnull((select count(1) from Form_HWTask where TaskCode = '002' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG020101] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG020201') then isnull((select count(1) from Form_HWTask where TaskCode = '014' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG020201] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG030101') then isnull((select count(1) from Form_HWTask where TaskCode = '003' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG030101] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG040101') then isnull((select count(1) from Form_HWTask where TaskCode = '008' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG040101] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG040201') then isnull((select count(1) from Form_HWTask where TaskCode = '009' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG040201] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG040301') then isnull((select count(1) from Form_HWTask where TaskCode = '010' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG040301] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG050101') then isnull((select count(1) from Form_HWTask where TaskCode = '011' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG050101] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'ENG050201') then isnull((select count(1) from Form_HWTask where TaskCode = '013' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [ENG050201] ")
        'ENG

        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'SLS020000') then isnull((select count(1) from slp_user_register where acct_status = 'For Approval'),0) else 0 end) [SLS020000] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'SLS030000') then isnull((select count(1) from slp_frm_rsv where status = 'Reserved'),0) else 0 end) [SLS030000] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'AAD010000') then isnull((select count(1) from bp_inquiry where Status = 'Pending'),0) + isnull((select count(1) from bp_requirements where Status = 'Pending'),0) + isnull((select count(1) from bp_pdc where Status = 'Pending'),0) + isnull((select count(1) from bp_remittance where Status = 'Pending'),0) else 0 end) [AAD010000] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = '810000') then isnull((select Count(1) from Form_HWTask [A] left join Form_HWHdr [B] on [A].HWCode = [B].HWCode where [A].TaskCode = '006' and [B].ConStatus = 'Awarded' and [B].ConPrice > isnull([B].BillAmt,0) and [A].AssignTo = '" & CIIS_EmpCode & "'),0) else 0 end) [FIN010100] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'FIN010000') then isnull((select Count(1) from Form_CRT [A] left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_Code where [B].tbl_from = 'Form_CRT' and [B].status not in ('Cancelled','Declined') and [A].ContractStatus = 'Awarded' and [A].ContractPrice > isnull([A].BillAmt,0) and [B].approver = '" & CIIS_EmpCode & "'),0) else 0 end) [FIN010200] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'FIN020000') then isnull((select count(1) from (select  isnull((select top 1 [E].approver from oop_form_dtl_appr [E] where [E].f_code = [B].f_code and [E].type = 'Implementer'), '') [Custodian] from Form_PCHdr [A] left join oop_form_hdr [B] on [A].PCCode = [B].tbl_code where [A].PCType = 'Cash Payment and Cash Liquidation' and [A].APVNo = '' and [B].tbl_from = 'Form_PCHdr' and [B].status = 'Accepted') [A] where [Custodian] = '" & CIIS_EmpCode & "'), 0) else 0 end) [FIN020000] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'FIN030101') then isnull((select count(1) from Form_HWTask where TaskCode = '004' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [FIN030101] ")

        'SCM
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'SCM010000') then isnull((select count(1) from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].tbl_from = 'Form_CRT' and [A].approver = '" & CIIS_EmpCode & "' and [A].status not in ('Accepted','Declined','Cancelled') and [B].ContractStatus not in ('Awarded', 'Cancelled')),0) + isnull((select count(1) from Form_HWTask [A] left join Form_HWHdr [B] on [A].HWCode = [B].HWCode where [A].TaskCode = '005' and [A].AssignTo = '" & CIIS_EmpCode & "' and [B].ConStatus not in ('Awarded', 'Cancelled')),0) else 0 end) [SCM010000] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'SCM020000') then isnull((select count(1) from SCM_Contractor where status = 0 and acct_progress in ('For Verification', 'For Approval')),0) else 0 end) [SCM020000] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'SCM030101') then isnull((select count(1) from Form_HWTask where TaskCode = '005' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Complete','Clarify')),0) else 0 end) [SCM030101] ")
        Query.Append("   ,(case when '" & CIIS_EmpCode & "' in (select EmpCode from Mstr_UserRestriction where FormCode = 'SCM040100' and Post_ = 1) then isnull((select count(1) from ogm_po_hdr where lock = 1 and post = 0 and Status = 'for Posting'),0) else 0 end) [SCM040100] ")
        'SCM

        'query

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblCntFRM.Text = DR("Endorse") + DR("Approve") + DR("Implement") + DR("Clarify")
                    lblCnt_FRM_Endorsement.Text = DR("Endorse")
                    lblCnt_FRM_Approval.Text = DR("Approve")
                    lblCnt_FRM_Implementation.Text = DR("Implement")
                    lblCnt_FRM_Clarification.Text = DR("Clarify")
                    lblCnt_FRM_ForCancellation.Text = DR("ForCancel")

                    lblCntWO.Text = DR("WOAssigned") + DR("WOAccepted") + DR("WOCompleted") + DR("WOClarify")
                    lblCnt_WO_Assigned.Text = DR("WOAssigned")
                    lblCnt_WO_Accepted.Text = DR("WOAccepted")
                    lblCnt_WO_Completed.Text = DR("WOCompleted")
                    lblCnt_WO_Clarify.Text = DR("WOClarify")

                    'PDD
                    lblCntPDD.Text = DR("PDD010301") + DR("PDD010201") + DR("PDD010101")
                    lblCntPDD_PDD010100.Text = DR("PDD010101")
                    lblCntPDD_PDD010200.Text = DR("PDD010201")
                    lblCntPDD_PDD010300.Text = DR("PDD010301")
                    'PDD

                    'ENG
                    lblCntENG.Text = DR("ENG020201") + DR("ENG050201") + DR("ENG040301") + DR("ENG050101") + DR("ENG040201") + DR("ENG040101") + DR("ENG030101") + DR("ENG020101") + DR("ENG010101") + DR("ENG010201") + DR("ENG010301") + DR("ENG010401") + DR("ENG010501") + DR("ENG010601") + DR("ENG010701")
                    lblCntENG_ENG010000.Text = DR("ENG010101") + DR("ENG010201") + DR("ENG010301") + DR("ENG010401") + DR("ENG010501") + DR("ENG010601") + DR("ENG010701")
                    lblCntENG_ENG010100.Text = DR("ENG010101")
                    lblCntENG_ENG010200.Text = DR("ENG010201")
                    lblCntENG_ENG010300.Text = DR("ENG010301")
                    lblCntENG_ENG010400.Text = DR("ENG010401")
                    lblCntENG_ENG010500.Text = DR("ENG010501")
                    lblCntENG_ENG010600.Text = DR("ENG010601")
                    lblCntENG_ENG010700.Text = DR("ENG010701")
                    lblCntENG_ENG020000.Text = DR("ENG020101") + DR("ENG020201")
                    lblCntENG_ENG020100.Text = DR("ENG020101")
                    lblCntENG_ENG020200.Text = DR("ENG020201")
                    lblCntENG_ENG030000.Text = DR("ENG030101")
                    lblCntENG_ENG030100.Text = DR("ENG030101")
                    lblCntENG_ENG040000.Text = DR("ENG040301") + DR("ENG040201") + DR("ENG040101")
                    lblCntENG_ENG040100.Text = DR("ENG040101")
                    lblCntENG_ENG040200.Text = DR("ENG040201")
                    lblCntENG_ENG040300.Text = DR("ENG040301")
                    lblCntENG_ENG050000.Text = DR("ENG050101") + DR("ENG050201")
                    lblCntENG_ENG050100.Text = DR("ENG050101")
                    lblCntENG_ENG050200.Text = DR("ENG050201")
                    'ENG

                    'SLS
                    lblCntSLS.Text = DR("SLS020000") + DR("SLS030000")
                    lblCntSLS_SLS020000.Text = DR("SLS020000")
                    lblCntSLS_SLS030000.Text = DR("SLS030000")
                    'SLS

                    'AAD
                    lblCntAAD.Text = DR("AAD010000")
                    lblCntAAD_AAD010000.Text = DR("AAD010000")
                    'AAD

                    'FIN
                    lblCntFIN.Text = DR("FIN030101") + DR("FIN010100") + DR("FIN010200") + +DR("FIN020000")
                    lblCntFIN_FIN010000.Text = DR("FIN010100") + DR("FIN010200")
                    lblCntFIN_FIN020000.Text = DR("FIN020000")
                    lblCntFIN_FIN030000.Text = DR("FIN030101")
                    lblCntFIN_FIN030100.Text = DR("FIN030101")
                    'FIN

                    'SCM
                    lblCntSCM.Text = DR("SCM030101") + DR("SCM010000") + DR("SCM020000")
                    lblCntSCM_SCM010000.Text = DR("SCM010000")
                    lblCntSCM_SCM020000.Text = DR("SCM020000")
                    lblCntSCM_SCM030000.Text = DR("SCM030101")
                    lblCntSCM_SCM030100.Text = DR("SCM030101")
                    'SCM

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'PDD
        If lblCntPDD.Text = "0" Then lblCntPDD.Visible = False
        If lblCntPDD_PDD010000.Text = "0" Then lblCntPDD_PDD010000.Visible = False
        If lblCntPDD_PDD010100.Text = "0" Then lblCntPDD_PDD010100.Visible = False
        If lblCntPDD_PDD010200.Text = "0" Then lblCntPDD_PDD010200.Visible = False
        If lblCntPDD_PDD010300.Text = "0" Then lblCntPDD_PDD010300.Visible = False
        If lblCntPDD_PDD010001.Text = "0" Then lblCntPDD_PDD010001.Visible = False
        If lblCntPDD_PDD030000.Text = "0" Then lblCntPDD_PDD030000.Visible = False
        If lblCntPDD_PDD040000.Text = "0" Then lblCntPDD_PDD040000.Visible = False
        If lblCntPDD_PDD050000.Text = "0" Then lblCntPDD_PDD050000.Visible = False
        'PDD

        'ENG
        If lblCntENG.Text = "0" Then lblCntENG.Visible = False
        If lblCntENG_ENG010000.Text = "0" Then lblCntENG_ENG010000.Visible = False
        If lblCntENG_ENG010100.Text = "0" Then lblCntENG_ENG010100.Visible = False
        If lblCntENG_ENG010200.Text = "0" Then lblCntENG_ENG010200.Visible = False
        If lblCntENG_ENG010300.Text = "0" Then lblCntENG_ENG010300.Visible = False
        If lblCntENG_ENG010400.Text = "0" Then lblCntENG_ENG010400.Visible = False
        If lblCntENG_ENG010500.Text = "0" Then lblCntENG_ENG010500.Visible = False
        If lblCntENG_ENG010600.Text = "0" Then lblCntENG_ENG010600.Visible = False
        If lblCntENG_ENG010700.Text = "0" Then lblCntENG_ENG010700.Visible = False
        If lblCntENG_ENG020000.Text = "0" Then lblCntENG_ENG020000.Visible = False
        If lblCntENG_ENG020100.Text = "0" Then lblCntENG_ENG020100.Visible = False
        If lblCntENG_ENG020200.Text = "0" Then lblCntENG_ENG020200.Visible = False
        If lblCntENG_ENG030000.Text = "0" Then lblCntENG_ENG030000.Visible = False
        If lblCntENG_ENG030100.Text = "0" Then lblCntENG_ENG030100.Visible = False
        If lblCntENG_ENG040000.Text = "0" Then lblCntENG_ENG040000.Visible = False
        If lblCntENG_ENG040100.Text = "0" Then lblCntENG_ENG040100.Visible = False
        If lblCntENG_ENG040200.Text = "0" Then lblCntENG_ENG040200.Visible = False
        If lblCntENG_ENG040300.Text = "0" Then lblCntENG_ENG040300.Visible = False
        If lblCntENG_ENG050000.Text = "0" Then lblCntENG_ENG050000.Visible = False
        If lblCntENG_ENG050100.Text = "0" Then lblCntENG_ENG050100.Visible = False
        If lblCntENG_ENG050200.Text = "0" Then lblCntENG_ENG050200.Visible = False
        'ENG

        'SLS
        If lblCntSLS.Text = "0" Then lblCntSLS.Visible = False
        If lblCntSLS_SLS010000.Text = "0" Then lblCntSLS_SLS010000.Visible = False
        If lblCntSLS_SLS020000.Text = "0" Then lblCntSLS_SLS020000.Visible = False
        If lblCntSLS_SLS030000.Text = "0" Then lblCntSLS_SLS030000.Visible = False
        If lblCntSLS_SLS040000.Text = "0" Then lblCntSLS_SLS040000.Visible = False
        If lblCntSLS_SLS050000.Text = "0" Then lblCntSLS_SLS050000.Visible = False
        If lblCntSLS_SLS060000.Text = "0" Then lblCntSLS_SLS060000.Visible = False
        'SLS

        'AAD
        If lblCntAAD.Text = "0" Then lblCntAAD.Visible = False
        If lblCntAAD_AAD010000.Text = "0" Then lblCntAAD_AAD010000.Visible = False
        If lblCntAAD_AAD040000.Text = "0" Then lblCntAAD_AAD040000.Visible = False
        If lblCntAAD_AAD050000.Text = "0" Then lblCntAAD_AAD050000.Visible = False
        If lblCntAAD_AAD060000.Text = "0" Then lblCntAAD_AAD060000.Visible = False
        'AAD

        If lblCntFIN.Text = "0" Then lblCntFIN.Visible = False
        If lblCntFIN_FIN010000.Text = "0" Then lblCntFIN_FIN010000.Visible = False
        If lblCntFIN_FIN020000.Text = "0" Then lblCntFIN_FIN020000.Visible = False
        If lblCntFIN_FIN030000.Text = "0" Then lblCntFIN_FIN030000.Visible = False
        If lblCntFIN_FIN030100.Text = "0" Then lblCntFIN_FIN030100.Visible = False
        If lblCntFIN_FIN040000.Text = "0" Then lblCntFIN_FIN040000.Visible = False
        If lblCntFIN_FIN050000.Text = "0" Then lblCntFIN_FIN050000.Visible = False
        If lblCntFIN_FIN060000.Text = "0" Then lblCntFIN_FIN060000.Visible = False
        If lblCntFIN_FIN080000.Text = "0" Then lblCntFIN_FIN080000.Visible = False
        If lblCntFIN_FIN110000.Text = "0" Then lblCntFIN_FIN110000.Visible = False
        If lblCntFIN_FIN120000.Text = "0" Then lblCntFIN_FIN120000.Visible = False
        If lblCntFIN_FIN140000.Text = "0" Then lblCntFIN_FIN140000.Visible = False
        If lblCntFIN_FIN150000.Text = "0" Then lblCntFIN_FIN150000.Visible = False
        If lblCntFIN_FIN160000.Text = "0" Then lblCntFIN_FIN160000.Visible = False

        'SCM
        If lblCntSCM.Text = "0" Then lblCntSCM.Visible = False
        If lblCntSCM_SCM010000.Text = "0" Then lblCntSCM_SCM010000.Visible = False
        If lblCntSCM_SCM020000.Text = "0" Then lblCntSCM_SCM020000.Visible = False
        If lblCntSCM_SCM030000.Text = "0" Then lblCntSCM_SCM030000.Visible = False
        If lblCntSCM_SCM030100.Text = "0" Then lblCntSCM_SCM030100.Visible = False
        'SCM

        If lblCntHRA.Text = "0" Then lblCntHRA.Visible = False

        If lblCntCSD.Text = "0" Then lblCntCSD.Visible = False

        If lblCntAUD.Text = "0" Then lblCntAUD.Visible = False

    End Function

    Function bindEvent()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 Code ")
        Query.Append("	 ,Title ")
        Query.Append("	 ,Description ")
        Query.Append("	 ,Location ")
        Query.Append("	 ,IsAllDay ")
        Query.Append("	 ,(case when IsAllDay = 1 then FORMAT(DateStart,'yyyy-MM-dd') else FORMAT(DateStart,'yyyy-MM-ddTHH:mm:ss') end) [DateStart] ")
        Query.Append("	 ,(case when IsAllDay = 1 then FORMAT(dateadd(day,1,DateEnd),'yyyy-MM-dd') else FORMAT(DateEnd,'yyyy-MM-ddTHH:mm:ss') end) [DateEnd] ")
        Query.Append("	 ,'#009ef7' [EventColor] ")
        Query.Append("from ")
        Query.Append("   Mstr_Event ")
        Query.Append("where ")
        Query.Append("   CreatedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("union  ")
        Query.Append("select  ")
        Query.Append("	 Code ")
        Query.Append("	 ,Title ")
        Query.Append("	 ,Description ")
        Query.Append("	 ,Location ")
        Query.Append("	 ,IsAllDay ")
        Query.Append("	 ,(case when IsAllDay = 1 then FORMAT(DateStart,'yyyy-MM-dd') else FORMAT(DateStart,'yyyy-MM-ddTHH:mm:ss') end) [DateStart] ")
        Query.Append("	 ,(case when IsAllDay = 1 then FORMAT(dateadd(day,1,DateEnd),'yyyy-MM-dd') else FORMAT(DateEnd,'yyyy-MM-ddTHH:mm:ss') end) [DateEnd] ")
        Query.Append("	 ,(case when [CreatedBy] = '" & CIIS_EmpCode & "' then '#009ef7' ") 'Creator
        Query.Append("	        when [IsAllDay] = 1 and cast(getdate() as date) < cast([DateStart] as date) then '#ffc700' ") 'upcomming
        Query.Append("	        when [IsAllDay] = 1 and cast(getdate() as date) between cast([DateStart] as date)  and cast([DateEnd] as date)  then '#50cd89' ") 'within
        Query.Append("	        when [IsAllDay] = 1 and cast(getdate() as date) > cast([DateEnd] as date) then '#f1416c' ") 'after
        Query.Append("	        when [IsAllDay] = 0 and getdate() < [DateStart] then '#ffc700' ") 'upcomming
        Query.Append("	        when [IsAllDay] = 0 and getdate() between [DateStart] and [DateEnd] then '#50cd89' ") 'within
        Query.Append("	        when [IsAllDay] = 0 and getdate() > [DateEnd] then '#f1416c' end) [EventColor] ") 'after
        Query.Append("from ")
        Query.Append("   Mstr_Event ")
        Query.Append("where ")
        Query.Append("   Members like '%" & CIIS_EmpCode & "%' ")
        Query.Append("union  ")
        Query.Append("select  ")
        Query.Append("	 Code ")
        Query.Append("	 ,Title ")
        Query.Append("	 ,Description ")
        Query.Append("	 ,Location ")
        Query.Append("	 ,IsAllDay ")
        Query.Append("	 ,(case when IsAllDay = 1 then FORMAT(DateStart,'yyyy-MM-dd') else FORMAT(DateStart,'yyyy-MM-ddTHH:mm:ss') end) [DateStart] ")
        Query.Append("	 ,(case when IsAllDay = 1 then FORMAT(dateadd(day,1,DateEnd),'yyyy-MM-dd') else FORMAT(DateEnd,'yyyy-MM-ddTHH:mm:ss') end) [DateEnd] ")
        Query.Append("	 ,(case when [CreatedBy] = '" & CIIS_EmpCode & "' then '#009ef7' ") 'Creator
        Query.Append("	        when [IsAllDay] = 1 and cast(getdate() as date) < cast([DateStart] as date) then '#ffc700' ") 'upcomming
        Query.Append("	        when [IsAllDay] = 1 and cast(getdate() as date) between cast([DateStart] as date)  and cast([DateEnd] as date)  then '#50cd89' ") 'within
        Query.Append("	        when [IsAllDay] = 1 and cast(getdate() as date) > cast([DateEnd] as date) then '#f1416c' ") 'after
        Query.Append("	        when [IsAllDay] = 0 and getdate() < [DateStart] then '#ffc700' ") 'upcomming
        Query.Append("	        when [IsAllDay] = 0 and getdate() between [DateStart] and [DateEnd] then '#50cd89' ") 'within
        Query.Append("	        when [IsAllDay] = 0 and getdate() > [DateEnd] then '#f1416c' end) [EventColor] ") 'after
        Query.Append("from ")
        Query.Append("   Mstr_Event ")
        Query.Append("where ")
        Query.Append("   Members like '%Everyone%' ")
        'get approver 

        Dim FCEvent As New StringBuilder

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password )
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()

                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'event
                    If FCEvent.ToString = "" Then
                        FCEvent.Append("{'id' : '" & DR("Code") & "' , 'title' : '" & DR("Title") & "' , 'start' : '" & DR("DateStart") & "' , 'end' : '" & DR("DateEnd") & "' , 'description' : '" & DR("Description") & "' , 'color' : '" & DR("EventColor") & "'} ")
                    Else
                        FCEvent.Append(", {'id' : '" & DR("Code") & "' , 'title' : '" & DR("Title") & "' , 'start' : '" & DR("DateStart") & "' , 'end' : '" & DR("DateEnd") & "' , 'description' : '" & DR("Description") & "' , 'color' : '" & DR("EventColor") & "'} ")
                    End If
                    'event

                End While
                DR.Close()
                ConStr.Close()
                hfEvent.Value = "[" & Replace(FCEvent.ToString, "'", ControlChars.Quote) & "]"
                upnlHidden.Update()
            End Using
        End Using
        'read record

    End Function

#End Region

End Class