Imports System.Data.SqlClient

Public Class AAD010000
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    Dim CIIS_Department As String
    'cookies

    Dim DataSource As String = "iis"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
        CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        CIIS_Department = CIIS_UserInfo("CIIS_Department")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "AAD010000")
        'active account / menu

        'create variable
        Dim Msg As String = Validate("Access", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        'load page
        If IsPostBack = False Then

            'bindREQVerified()
            'bindREQForVerification()
            bindPDCVerified()
            bindPDCForVerification()
            bind06INQDeclinedTotal()
            bind06INQApprovedTotal()
            bind06INQPendingTotal()
            bind06INQ()
            bind05REQDeclinedTotal()
            bind05REQApprovedTotal()
            bind05REQPendingTotal()
            bind05REQ()
            bind04PDCDeclinedTotal()
            bind04PDCApprovedTotal()
            bind04PDCPendingTotal()
            bind04PDC()
            bind03RSDeclinedTotal()
            bind03RSApprovedTotal()
            bind03RSPendingTotal()
            bind03RS()
            bind02TotalUserChart()
            bind01TotalUsers()

        End If
        'load page

    End Sub

#End Region

#Region "Request Summary"

    Protected Sub RSViewDetails_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RSViewDetails.Click

        'create variable
        Dim Msg As String = Validate("RemittanceAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010500")
        End If
        'validate access

    End Sub

    Protected Sub lbtnPDCVerified_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCVerified.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010800")
        End If
        'validate access

    End Sub

    Protected Sub lbtnPDCForVerification_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCForVerification.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010700")
        End If
        'validate access

    End Sub

    'Protected Sub lbtnREQVerified_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQVerified.Click

    '    'create variable
    '    Dim Msg As String = Validate("RequirementsAccess", "View", "")
    '    'create variable

    '    'validate access
    '    If Msg <> "" Then
    '        Alert("error", Msg)
    '    Else
    '        Response.Redirect("AAD010900")
    '    End If
    '    'validate access

    'End Sub

    'Protected Sub lbtnREQForVerification_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQForVerification.Click

    '    'create variable
    '    Dim Msg As String = Validate("RequirementsAccess", "View", "")
    '    'create variable

    '    'validate access
    '    If Msg <> "" Then
    '        Alert("error", Msg)
    '    Else
    '        Response.Redirect("AAD011000")
    '    End If
    '    'validate access

    'End Sub

    'Protected Sub lbtnPDCViewDetails_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnPDCViewDetails.Click

    '    'create variable
    '    Dim Msg As String = Validate("PDCAccess", "View", "")
    '    'create variable

    '    'validate access
    '    If Msg <> "" Then
    '        Alert("error", Msg)
    '    Else
    '        Response.Redirect("AAD010400")
    '    End If
    '    'validate access

    'End Sub

    Protected Sub lbtnREQViewDetails_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnREQViewDetails.Click

        'create variable
        Dim Msg As String = Validate("RequirementsAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010600")
        End If
        'validate access

    End Sub

    Protected Sub lbtnINQViewDetails_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnINQViewDetails.Click

        'create variable
        Dim Msg As String = Validate("RequestInquiryAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010300")
        End If
        'validate access

    End Sub

#End Region

#Region "Menu"

    Protected Sub lbtnAAD010600_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAAD010600.Click

        'create variable
        Dim Msg As String = Validate("RequirementsAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010600")
        End If
        'validate access

    End Sub
    Protected Sub lbtnAAD010500_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAAD010500.Click

        'create variable
        Dim Msg As String = Validate("RemittanceAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010500")
        End If
        'validate access

    End Sub
    Protected Sub lbtnAAD010400_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAAD010400.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            CallJS("$('#mdlPDCMenu').modal('show');")
        End If
        'validate access

    End Sub

    Protected Sub lbtnMenuPDCForVerification_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnMenuPDCForVerification.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010700")
        End If
        'validate access

    End Sub

    Protected Sub lbtnMenuPDCForApproval_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnMenuPDCForApproval.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010800")
        End If
        'validate access

    End Sub

    Protected Sub lbtnMenuPDCMonitoring_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnMenuPDCMonitoring.Click

        'create variable
        Dim Msg As String = Validate("PDCAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010400")
        End If
        'validate access

    End Sub

    Protected Sub lbtnAAD010300_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAAD010300.Click

        'create variable
        Dim Msg As String = Validate("RequestInquiryAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010300")
        End If
        'validate access

    End Sub
    Protected Sub lbtnAAD010200_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAAD010200.Click

        'create variable
        Dim Msg As String = Validate("DownloadablesAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010200")
        End If
        'validate access

    End Sub

    Protected Sub lbtnAAD010100_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtnAAD010100.Click

        'create variable
        Dim Msg As String = Validate("DocumentaryAccess", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Alert("error", Msg)
        Else
            Response.Redirect("AAD010100")
        End If
        'validate access

    End Sub

#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)

        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterStartupScript(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)

    End Function

    Function CallJS(ByVal Script As String)

        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & Script & "</script>", False)

    End Function

    Function bindPDCForVerification()

        'get history count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and CSVerified is not null ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPDCForApprovalTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))
                    lblMenuPDCForApprovalTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                    IIf(DR.GetInt32(0) > 0, spanMenuPDCIsNotEmpty.Visible = True, spanMenuPDCIsNotEmpty.Visible = False)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindPDCVerified()

        'get history count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and CSVerified is null ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblPDCForVerificationTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))
                    lblMenuPDCForVerificationTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                    IIf(DR.GetInt32(0) > 0, spanMenuPDCIsNotEmpty.Visible = True, spanMenuPDCIsNotEmpty.Visible = False)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindREQForVerification()

        'get history count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and CSVerified is not null ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'lblREQVerifiedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bindREQVerified()

        'get history count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and CSVerified is null ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'lblREQForVerificationTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind06INQDeclinedTotal()

        'get history count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(INQCode) ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry ")
        Query.Append("where ")
        Query.Append("   Status = 'Declined' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl04INQDeclinedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind06INQApprovedTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(INQCode) ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry ")
        Query.Append("where ")
        Query.Append("   Status = 'Approved' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl04INQApprovedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind06INQPendingTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(INQCode) ")
        Query.Append("from ")
        Query.Append("	 bp_inquiry ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and month(CreatedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl04INQPendingTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind06INQ()

        'get 
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("     [TotalRemaining].[Remaining] ")
        Query.Append("    ,[TotalSubmitted].[Submitted] ")
        Query.Append("    ,[TotalDeclined].[Declined] ")
        Query.Append("from ")
        Query.Append("	 (select ")
        Query.Append("	    count(INQCode) [Remaining] ")
        Query.Append("	  from ")
        Query.Append("	     bp_inquiry ")
        Query.Append("	  where ")
        Query.Append("	       Status = 'Pending' ")
        Query.Append("	       and month(CreatedDate) = (select datepart(m, getdate()))) [TotalRemaining], ")
        Query.Append("	 (select ")
        Query.Append("	    count(INQCode) [Submitted] ")
        Query.Append("	  from ")
        Query.Append("	     bp_inquiry ")
        Query.Append("	  where ")
        Query.Append("	     Status = 'Approved' ")
        Query.Append("	     and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalSubmitted], ")
        Query.Append("	 (select ")
        Query.Append("	    count(INQCode) [Declined] ")
        Query.Append("	  from ")
        Query.Append("	     bp_inquiry ")
        Query.Append("	  where ")
        Query.Append("	    Status = 'Declined' ")
        Query.Append("	    and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalDeclined] ")
        'get

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl04INQDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")

                    Dim TotalPending As Integer = DR.GetInt32(0)
                    Dim TotalApproved As Integer = DR.GetInt32(1)
                    Dim TotalDeclined As Integer = DR.GetInt32(2)

                    Dim TotalPendingValue As Double
                    Dim TotalApprovedValue As Double
                    Dim TotalDeclinedValue As Double
                    TotalPendingValue = (TotalPending / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalApprovedValue = (TotalApproved / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalDeclinedValue = (TotalDeclined / (TotalPending + TotalApproved + TotalDeclined) * 100)

                    div04INQPendingProgress.Attributes("style") = "width: " & TotalPendingValue & "%;"
                    lbl04INQPendingPercentage.Text = IIf(TotalPendingValue.ToString("N0") = "NaN", "0%", TotalPendingValue.ToString("N0") & "%")

                    div04INQApprovedProgress.Attributes("style") = "width: " & TotalApprovedValue & "%;"
                    lbl04INQApprovedPercentage.Text = IIf(TotalApprovedValue.ToString("N0") = "NaN", "0%", TotalApprovedValue.ToString("N0") & "%")

                    div04INQDeclinedProgress.Attributes("style") = "width:" & TotalDeclinedValue & "%;"
                    lbl04INQDeclinedPercentage.Text = IIf(TotalDeclinedValue.ToString("N0") = "NaN", "0%", TotalDeclinedValue.ToString("N0") & "%")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind05REQDeclinedTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(REQCode) ")
        Query.Append("from ")
        Query.Append("	 bp_requirements ")
        Query.Append("where ")
        Query.Append("   Status = 'Declined' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl03REQDeclinedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind05REQApprovedTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(REQCode) ")
        Query.Append("from ")
        Query.Append("	 bp_requirements ")
        Query.Append("where ")
        Query.Append("   Status = 'Approved' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl03REQApprovedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind05REQPendingTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(REQCode) ")
        Query.Append("from ")
        Query.Append("	 bp_requirements ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and month(CreatedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl03REQPendingTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind05REQ()

        'get 
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("     [TotalRemaining].[Remaining] ")
        Query.Append("    ,[TotalSubmitted].[Submitted] ")
        Query.Append("    ,[TotalDeclined].[Declined] ")
        Query.Append("from ")
        Query.Append("	 (select ")
        Query.Append("	    count(REQCode) [Remaining] ")
        Query.Append("	  from ")
        Query.Append("	     bp_requirements ")
        Query.Append("	  where ")
        Query.Append("	       Status = 'Pending' ")
        Query.Append("	       and month(CreatedDate) = (select datepart(m, getdate()))) [TotalRemaining], ")
        Query.Append("	 (select ")
        Query.Append("	    count(REQCode) [Submitted] ")
        Query.Append("	  from ")
        Query.Append("	     bp_requirements ")
        Query.Append("	  where ")
        Query.Append("	     Status = 'Approved' ")
        Query.Append("	     and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalSubmitted], ")
        Query.Append("	 (select ")
        Query.Append("	    count(REQCode) [Declined] ")
        Query.Append("	  from ")
        Query.Append("	     bp_requirements ")
        Query.Append("	  where ")
        Query.Append("	     Status = 'Declined' ")
        Query.Append("	     and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalDeclined] ")
        'get

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl03REQDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")

                    Dim TotalPending As Integer = DR.GetInt32(0)
                    Dim TotalApproved As Integer = DR.GetInt32(1)
                    Dim TotalDeclined As Integer = DR.GetInt32(2)
                    Dim TotalPendingValue As Double
                    Dim TotalApprovedValue As Double
                    Dim TotalDeclinedValue As Double

                    TotalPendingValue = (TotalPending / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalApprovedValue = (TotalApproved / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalDeclinedValue = (TotalDeclined / (TotalPending + TotalApproved + TotalDeclined) * 100)

                    div03REQPendingProgress.Attributes("style") = "width: " & TotalPendingValue & "%;"
                    lbl03REQPendingPercentage.Text = IIf(TotalPendingValue.ToString("N0") = "NaN", "0%", TotalPendingValue.ToString("N0") & "%")

                    div03REQApprovedProgress.Attributes("style") = "width: " & TotalApprovedValue & "%;"
                    lbl03REQApprovedPercentage.Text = IIf(TotalApprovedValue.ToString("N0") = "NaN", "0%", TotalApprovedValue.ToString("N0") & "%")

                    div03REQDeclinedProgress.Attributes("style") = "width:" & TotalDeclinedValue & "%;"
                    lbl03REQDeclinedPercentage.Text = IIf(TotalApprovedValue.ToString("N0") = "NaN", "0%", TotalApprovedValue.ToString("N0") & "%")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind04PDCDeclinedTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Declined' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl02PDCDeclinedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind04PDCApprovedTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Approved' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl02PDCApprovedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind04PDCPendingTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(PDCCode) ")
        Query.Append("from ")
        Query.Append("	 bp_pdc ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and month(CreatedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl02PDCPendingTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind04PDC()

        'get 
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("     [TotalRemaining].[Remaining] ")
        Query.Append("    ,[TotalSubmitted].[Submitted] ")
        Query.Append("    ,[TotalDeclined].[Declined] ")
        Query.Append("from ")
        Query.Append("	 (select ")
        Query.Append("	    count(PDCCode) [Remaining] ")
        Query.Append("	  from ")
        Query.Append("	     bp_pdc ")
        Query.Append("	  where ")
        Query.Append("	       Status = 'Pending' ")
        Query.Append("	       and month(CreatedDate) = (select datepart(m, getdate()))) [TotalRemaining], ")
        Query.Append("	 (select ")
        Query.Append("	    count(PDCCode) [Submitted] ")
        Query.Append("	  from ")
        Query.Append("	     bp_pdc ")
        Query.Append("	  where ")
        Query.Append("	     Status = 'Approved' ")
        Query.Append("	     and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalSubmitted], ")
        Query.Append("	 (select ")
        Query.Append("	    count(PDCCode) [Declined] ")
        Query.Append("	  from ")
        Query.Append("	     bp_pdc ")
        Query.Append("	  where ")
        Query.Append("	     Status = 'Declined' ")
        Query.Append("	     and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalDeclined] ")
        'get

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl02PDCDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")

                    Dim TotalPending As Integer = DR.GetInt32(0)
                    Dim TotalApproved As Integer = DR.GetInt32(1)
                    Dim TotalDeclined As Integer = DR.GetInt32(2)
                    Dim TotalPendingValue As Double
                    Dim TotalApprovedValue As Double
                    Dim TotalDeclinedValue As Double

                    TotalPendingValue = (TotalPending / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalApprovedValue = (TotalApproved / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalDeclinedValue = (TotalDeclined / (TotalPending + TotalApproved + TotalDeclined) * 100)

                    div02PDCPendingProgress.Attributes("style") = "width: " & TotalPendingValue & "%;"
                    lbl02PDCPendingPercentage.Text = IIf(TotalPendingValue.ToString("N0") = "NaN", "0%", TotalPendingValue.ToString("N0") & "%")

                    div02PDCApprovedProgress.Attributes("style") = "width: " & TotalApprovedValue & "%;"
                    lbl02PDCApprovedPercentage.Text = IIf(TotalApprovedValue.ToString("N0") = "NaN", "0%", TotalApprovedValue.ToString("N0") & "%")

                    div02PDCDeclinedProgress.Attributes("style") = "width:" & TotalDeclinedValue & "%;"
                    lbl02PDCDeclinedPercentage.Text = IIf(TotalDeclinedValue.ToString("N0") = "NaN", "0%", TotalDeclinedValue.ToString("N0") & "%")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind03RSDeclinedTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(RSCode) ")
        Query.Append("from ")
        Query.Append("	 bp_remittance ")
        Query.Append("where ")
        Query.Append("   Status = 'Declined' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01RSDeclinedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind03RSApprovedTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(RSCode) ")
        Query.Append("from ")
        Query.Append("	 bp_remittance ")
        Query.Append("where ")
        Query.Append("   Status = 'Approved' ")
        Query.Append("   and month(ApprovedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01RSApprovedTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind03RSPendingTotal()

        'get hisory count
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("    count(RSCode) ")
        Query.Append("from ")
        Query.Append("	 bp_remittance ")
        Query.Append("where ")
        Query.Append("   Status = 'Pending' ")
        Query.Append("   and month(CreatedDate) = (select datepart(m, getdate())) ")
        'get history count

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01RSPendingTotal.Text = IIf(DR.GetInt32(0) > 99, "99+", DR.GetInt32(0))

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind03RS()

        'get 
        Dim Query As New StringBuilder

        Query.Append("select  ")
        Query.Append("     [TotalRemaining].[Remaining] ")
        Query.Append("    ,[TotalSubmitted].[Submitted] ")
        Query.Append("    ,[TotalDeclined].[Declined] ")
        Query.Append("from ")
        Query.Append("	 (select ")
        Query.Append("	    count(RSCode) [Remaining] ")
        Query.Append("	  from ")
        Query.Append("	     bp_remittance ")
        Query.Append("	  where ")
        Query.Append("	       Status = 'Pending' ")
        Query.Append("	       and month(CreatedDate) = (select datepart(m, getdate()))) [TotalRemaining], ")
        Query.Append("	 (select ")
        Query.Append("	    count(RSCode) [Submitted] ")
        Query.Append("	  from ")
        Query.Append("	     bp_remittance ")
        Query.Append("	  where ")
        Query.Append("	     Status = 'Approved' ")
        Query.Append("	     and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalSubmitted], ")
        Query.Append("	 (select ")
        Query.Append("	    count(RSCode) [Declined] ")
        Query.Append("	  from ")
        Query.Append("	     bp_remittance ")
        Query.Append("	  where ")
        Query.Append("	     Status = 'Declined' ")
        Query.Append("	     and month(ApprovedDate) = (select datepart(m, getdate()))) [TotalDeclined] ")
        'get

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01RSDate.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")

                    Dim TotalPending As Integer = DR.GetInt32(0)
                    Dim TotalApproved As Integer = DR.GetInt32(1)
                    Dim TotalDeclined As Integer = DR.GetInt32(2)
                    Dim TotalPendingValue As Double
                    Dim TotalApprovedValue As Double
                    Dim TotalDeclinedValue As Double
                    Dim TotalTask As Double

                    TotalPendingValue = (TotalPending / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalApprovedValue = (TotalApproved / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalDeclinedValue = (TotalDeclined / (TotalPending + TotalApproved + TotalDeclined) * 100)
                    TotalTask = (TotalPending / (TotalPending + TotalApproved + TotalDeclined) * 100)

                    div01RSPendingProgress.Attributes("style") = "width: " & TotalPendingValue & "%;"
                    lbl01RSPendingPercentage.Text = IIf(TotalPendingValue.ToString("N0") = "NaN", "0%", TotalPendingValue.ToString("N0") & "%")

                    div01RSApprovedProgress.Attributes("style") = "width: " & TotalApprovedValue & "%;"
                    lbl01RSApprovedPercentage.Text = IIf(TotalApprovedValue.ToString("N0") = "NaN", "0%", TotalApprovedValue.ToString("N0") & "%")

                    div01RSDeclinedProgress.Attributes("style") = "width:" & TotalDeclinedValue & "%;"
                    lbl01RSDeclinedPercentage.Text = IIf(TotalDeclinedValue.ToString("N0") = "NaN", "0%", TotalDeclinedValue.ToString("N0") & "%")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind02TotalUserChart()

        'get
        Dim Query As New StringBuilder

        Query.Append("select distinct ")
        Query.Append("   [BW] ")
        Query.Append("  ,[CBH] ")
        Query.Append("  ,[CH] ")
        Query.Append("  ,[CHD] ")
        Query.Append("  ,[CHN] ")
        Query.Append("  ,[CASA] ")
        Query.Append("  ,[CG] ")
        Query.Append("  ,[CM] ")
        Query.Append("  ,[COH] ")
        Query.Append("  ,[IL] ")
        Query.Append("  ,[LCR] ")
        Query.Append("  ,[LRT] ")
        Query.Append("  ,[LM]  ")
        Query.Append("  ,[NCE] ")
        Query.Append("  ,[NEV]  ")
        Query.Append("  ,[PS] ")
        Query.Append("  ,[PV] ")
        Query.Append("  ,[PREA] ")
        Query.Append("  ,[PRIS]  ")
        Query.Append("  ,[PROP] ")
        Query.Append("  ,[SLH] ")
        Query.Append("  ,[SON] ")
        Query.Append("  ,[SOR] ")
        Query.Append("  ,[SBW] ")
        Query.Append("  ,[TML] ")
        Query.Append("  ,[TV] ")
        Query.Append("from ")
        Query.Append(" (select ")
        Query.Append("       (select count(Project) from bp_user where Project = 'BW') [BW] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'CBH') [CBH] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'CH') [CH] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'CHD') [CHD] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'CHN') [CHN] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'CASA') [CASA] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'CG') [CG] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'CM') [CM] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'COH') [COH] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'IL') [IL] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'LCR') [LCR] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'LRT') [LRT] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'LM') [LM] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'NCE') [NCE] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'NEV') [NEV] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'PS') [PS] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'PV') [PV] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'PREA') [PREA] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'PRIS') [PRIS] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'PROP') [PROP] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'SLH') [SLH] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'SON') [SON] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'SOR') [SOR] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'SBW') [SBW] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'TML') [TML] ")
        Query.Append("      ,(select count(Project) from bp_user where Project = 'TV') [TV] ")
        Query.Append(" from ")
        Query.Append("   bp_user ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects on bp_user.project = calmardbLive.dbo.mstr_Projects.ProjCode) [UserPerProject] ")
        'get

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lbl01Date.Text = "as of " & Date.Today.ToString("MMMM dd, yyyy")

                    ltrlTotalUsers.Text = DR.GetInt32(0) & "," & DR.GetInt32(1) & "," & DR.GetInt32(2) & "," & DR.GetInt32(3) & "," & DR.GetInt32(4) & "," & DR.GetInt32(5) & "," & DR.GetInt32(6) & "," & DR.GetInt32(7) & "," & DR.GetInt32(8) & "," & DR.GetInt32(9) & "," & DR.GetInt32(10) & "," & DR.GetInt32(11) & "," & DR.GetInt32(12) & "," & DR.GetInt32(13) & "," & DR.GetInt32(14) & "," & DR.GetInt32(15) & "," & DR.GetInt32(16) & "," & DR.GetInt32(17) & "," & DR.GetInt32(18) & "," & DR.GetInt32(19) & "," & DR.GetInt32(20) & "," & DR.GetInt32(21) & "," & DR.GetInt32(22) & "," & DR.GetInt32(23) & "," & DR.GetInt32(24) & "," & DR.GetInt32(25)

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

    Function bind01TotalUsers()

        'get 
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("     [NewUsers].[New] ")
        Query.Append("    ,[TotalUsers].[Total] ")
        Query.Append("from ")
        Query.Append("	 (select ")
        Query.Append("	    count(AcctNo) [New] ")
        Query.Append("	  from ")
        Query.Append("	     bp_user ")
        Query.Append("	  where ")
        Query.Append("	       DateDiff(Day, CreatedDate, getdate()) < 31) [NewUsers], ")
        Query.Append("	 (select ")
        Query.Append("	    count(AcctNo) [Total] ")
        Query.Append("	  from ")
        Query.Append("	     bp_user) [TotalUsers] ")
        'get

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim NewUser As Integer = DR.GetInt32(0)
                    Dim TotalUser As Integer = DR.GetInt32(1)
                    span01NewUsers.Attributes("data-kt-countup-value") = NewUser
                    span01TotalUsers.Attributes("data-kt-countup-value") = TotalUser

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

#End Region

#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        'requirements access
        If Group_ = "RequirementsAccess" Then
            If Type = "View" Then
                Query.Append("if 'AAD010600' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010600') ")
                Query.Append("begin ")
                Query.Append("   select 'Access Denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'requirements access

        'remittance access
        If Group_ = "RemittanceAccess" Then
            If Type = "View" Then
                Query.Append("if 'AAD010500' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010500') ")
                Query.Append("begin ")
                Query.Append("   select 'Access Denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'remittance access

        'PDC access
        If Group_ = "PDCAccess" Then
            If Type = "View" Then
                Query.Append("if 'AAD010400' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010400') ")
                Query.Append("begin ")
                Query.Append("   select 'Access Denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'PDC access

        'request/inquiry access
        If Group_ = "RequestInquiryAccess" Then
            If Type = "View" Then
                Query.Append("if 'AAD010300' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010300') ")
                Query.Append("begin ")
                Query.Append("   select 'Access Denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'request/inquiry access

        'downloadables access
        If Group_ = "DownloadablesAccess" Then
            If Type = "View" Then
                Query.Append("if 'AAD010200' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010200') ")
                Query.Append("begin ")
                Query.Append("   select 'Access Denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'downloadables access

        'documentary access
        If Group_ = "DocumentaryAccess" Then
            If Type = "View" Then
                Query.Append("if 'AAD010100' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010100') ")
                Query.Append("begin ")
                Query.Append("   select 'Access Denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'documentary access

        'account transaction access
        If Group_ = "Access" Then
            If Type = "View" Then
                Query.Append("if 'AAD010000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'AAD010000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access Denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
        End If
        'account transaction access

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

#End Region

End Class