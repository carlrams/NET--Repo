Imports System.Data.SqlClient

Public Class ACC020200
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
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
            CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
            CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "ACC010100")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'display record
            bindInfo()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "Button"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

#End Region

#Region "Function"

    Function bindInfo()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   DateFrom ")
        Query.Append("   ,DateTo ")
        Query.Append("   ,FORMAT(VL,'N1') [VLCredit] ")
        Query.Append("   ,FORMAT(VLUsed,'N1') [VLUsed] ")
        Query.Append("   ,FORMAT(VL - VLUsed,'N1') [VLBalance] ")
        Query.Append("   ,FORMAT(SL,'N1') [SLCredit] ")
        Query.Append("   ,FORMAT(SLUsed,'N1') [SLUsed] ")
        Query.Append("   ,FORMAT(SL - SLUsed,'N1') [SLBalance] ")
        Query.Append("   ,FORMAT(PML,'N1') [PMLCredit] ")
        Query.Append("   ,FORMAT(PMLUsed,'N1') [PMLUsed] ")
        Query.Append("   ,FORMAT(PML - PMLUsed,'N1') [PMLBalance] ")
        Query.Append("   ,FORMAT(SPL,'N1') [SPLCredit] ")
        Query.Append("   ,FORMAT(SPLUsed,'N1') [SPLUsed] ")
        Query.Append("   ,FORMAT(SPL - SPLUsed,'N1') [SPLBalance] ")
        Query.Append("   ,FORMAT(BL,'N1') [BLCredit] ")
        Query.Append("   ,FORMAT(BLUsed,'N1') [BLUsed] ")
        Query.Append("   ,FORMAT(BL - BLUsed,'N1') [BLBalance] ")
        Query.Append("from ")
        Query.Append("   Mstr_LeaveCredit ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and '" & Date.Now.ToShortDateString & "' between DateFrom and DateTo ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblVLCredit.Text = DR("VLCredit")
                    lblVLUsed.Text = DR("VLUsed")
                    lblVLBalance.Text = DR("VLBalance")
                    If CDbl(DR("VLUsed")) > 0 Then bindVLInfo(DR("DateFrom"), DR("DateTo"))

                    lblSLCredit.Text = DR("SLCredit")
                    lblSLUsed.Text = DR("SLUsed")
                    lblSLBalance.Text = DR("SLBalance")
                    If CDbl(DR("SLUsed")) > 0 Then bindSLInfo(DR("DateFrom"), DR("DateTo"))

                    lblPMLCredit.Text = DR("PMLCredit")
                    lblPMLUsed.Text = DR("PMLUsed")
                    lblPMLBalance.Text = DR("PMLBalance")
                    If CDbl(DR("PMLUsed")) > 0 Then bindPMLInfo(DR("DateFrom"), DR("DateTo"))

                    lblSPLCredit.Text = DR("SPLCredit")
                    lblSPLUsed.Text = DR("SPLUsed")
                    lblSPLBalance.Text = DR("SPLBalance")
                    If CDbl(DR("SPLUsed")) > 0 Then bindSPLInfo(DR("DateFrom"), DR("DateTo"))

                    lblBLCredit.Text = DR("BLCredit")
                    lblBLUsed.Text = DR("BLUsed")
                    lblBLBalance.Text = DR("BLBalance")
                    If CDbl(DR("BLUsed")) > 0 Then bindBLInfo(DR("DateFrom"), DR("DateTo"))

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Function bindVLInfo(DateFrom As String, DateTo As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   FORMAT(Date,'MM/dd/yyyy') [Date] ")
        Query.Append("   ,(select top 1 [B].description from hr_form_leave [B] where [B].created_by = [A].EmpCode and [B].leave_type = 'Vacation Leave' and [A].Date between [B].date_from and [B].date_to order by [B].created_date desc) [Description] ")
        Query.Append("   ,VL ")
        Query.Append("from ")
        Query.Append("   Trxn_AttendanceDtl [A] ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Date between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("   and [A].VL > 0 ")
        'get total task

        'inner html
        Dim InnerHtml As New StringBuilder
        'inner html

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    InnerHtml.Append("<div class='d-flex flex-row'> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("Date") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto text-nowrap' style='width:calc(100% - 400px);'> ")
                    InnerHtml.Append("      " & DR("Description") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("VL") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display record
        divDtlVL.InnerHtml = InnerHtml.ToString
        'display record

    End Function

    Function bindSLInfo(DateFrom As String, DateTo As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   FORMAT(Date,'MM/dd/yyyy') [Date] ")
        Query.Append("   ,(select top 1 [B].description from hr_form_leave [B] where [B].created_by = [A].EmpCode and [B].leave_type = 'Sick Leave' and [A].Date between [B].date_from and [B].date_to order by [B].created_date desc) [Description] ")
        Query.Append("   ,SL ")
        Query.Append("from ")
        Query.Append("   Trxn_AttendanceDtl [A] ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Date between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("   and [A].SL > 0 ")
        'get total task

        'inner html
        Dim InnerHtml As New StringBuilder
        'inner html

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    InnerHtml.Append("<div class='d-flex flex-row'> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("Date") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto text-nowrap' style='width:calc(100% - 400px);'> ")
                    InnerHtml.Append("      " & DR("Description") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("SL") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display record
        divDtlSL.InnerHtml = InnerHtml.ToString
        'display record

    End Function

    Function bindPMLInfo(DateFrom As String, DateTo As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   FORMAT(Date,'MM/dd/yyyy') [Date] ")
        Query.Append("   ,(select top 1 [B].description from hr_form_leave [B] where [B].created_by = [A].EmpCode and [B].leave_type in ('Paternity Leave','Maternity Leave') and [A].Date between [B].date_from and [B].date_to order by [B].created_date desc) [Description] ")
        Query.Append("   ,ML ")
        Query.Append("from ")
        Query.Append("   Trxn_AttendanceDtl [A] ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Date between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("   and [A].ML > 0 ")
        'get total task

        'inner html
        Dim InnerHtml As New StringBuilder
        'inner html

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    InnerHtml.Append("<div class='d-flex flex-row'> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("Date") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto text-nowrap' style='width:calc(100% - 400px);'> ")
                    InnerHtml.Append("      " & DR("Description") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("ML") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display record
        divDtlPML.InnerHtml = InnerHtml.ToString
        'display record

    End Function

    Function bindSPLInfo(DateFrom As String, DateTo As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   FORMAT(Date,'MM/dd/yyyy') [Date] ")
        Query.Append("   ,(select top 1 [B].description from hr_form_leave [B] where [B].created_by = [A].EmpCode and [B].leave_type = 'Solo Parent Leave' and [A].Date between [B].date_from and [B].date_to order by [B].created_date desc) [Description] ")
        Query.Append("   ,PL ")
        Query.Append("from ")
        Query.Append("   Trxn_AttendanceDtl [A] ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Date between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("   and [A].PL > 0 ")
        'get total task

        'inner html
        Dim InnerHtml As New StringBuilder
        'inner html

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    InnerHtml.Append("<div class='d-flex flex-row'> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("Date") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto text-nowrap' style='width:calc(100% - 400px);'> ")
                    InnerHtml.Append("      " & DR("Description") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("PL") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display record
        divDtlSPL.InnerHtml = InnerHtml.ToString
        'display record

    End Function

    Function bindBLInfo(DateFrom As String, DateTo As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   FORMAT(Date,'MM/dd/yyyy') [Date] ")
        Query.Append("   ,(select top 1 [B].description from hr_form_leave [B] where [B].created_by = [A].EmpCode and [B].leave_type = 'Bereavement Leave' and [A].Date between [B].date_from and [B].date_to order by [B].created_date desc) [Description] ")
        Query.Append("   ,BL ")
        Query.Append("from ")
        Query.Append("   Trxn_AttendanceDtl [A] ")
        Query.Append("where ")
        Query.Append("   [A].EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Date between '" & DateFrom & "' and '" & DateTo & "' ")
        Query.Append("   and [A].BL > 0 ")
        'get total task

        'inner html
        Dim InnerHtml As New StringBuilder
        'inner html

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    InnerHtml.Append("<div class='d-flex flex-row'> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("Date") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto text-nowrap' style='width:calc(100% - 400px);'> ")
                    InnerHtml.Append("      " & DR("Description") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("      " & DR("BL") & " ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='d-flex flex-column flex-row-auto min-w-100px'> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display record
        divDtlBL.InnerHtml = InnerHtml.ToString
        'display record

    End Function

#End Region

End Class