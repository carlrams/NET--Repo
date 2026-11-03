Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Public Class SLS030000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "iis"
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SLS030000")
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

            'display record
            'checkUserAccess()
            bindNewReservations()
            bindApproved()
            bindRejected()
            bindExpired()
            bindCounter()
            CheckExpiry()
            bindGroupSalesBarChart()
            bindAcctStatPieChart()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Public Function CheckIfRemoteFileExists(ByVal url As String) As Boolean
        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "HEAD"
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                If response.StatusCode = HttpStatusCode.OK Then
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As WebException
            If ex.Status = WebExceptionStatus.ProtocolError Then
                Dim httpResponse As HttpWebResponse = CType(ex.Response, HttpWebResponse)
                If httpResponse.StatusCode = HttpStatusCode.NotFound Then
                    Return False
                End If
            End If
            Return False
        End Try
    End Function

    Function bindNewReservations()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].slf_code ")
        Query.Append("   ,(dbo.ProperCase([A].acct_name)) [AcctName] ")
        Query.Append("   ,(case when [A].created_date is null then '-' else CONVERT (varchar, [A].created_date, 107) end) [CreatedDate] ")
        Query.Append("   ,[A].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[B].ModelName ")
        Query.Append("   ,[A].house_status ")
        Query.Append("   ,[A].LotArea ")
        Query.Append("   ,[A].FloorArea ")
        Query.Append("   ,[A].TCP ")
        Query.Append("   ,(dbo.ProperCase([C].first_name)) + ' ' + (dbo.ProperCase([C].last_name)) [Seller] ")
        Query.Append("   ,(case when [A].created_date is null then '-' else RIGHT(CONVERT(varchar, [A].created_date, 100), 7) end) [CreatedTime] ")
        Query.Append("   ,(case when [A].rsv_expdate is null then '-' else CONVERT (varchar, [A].rsv_expdate, 107) end) [ExpiryDate] ")
        Query.Append("   ,(case when [A].rsv_expdate is null then '-' else RIGHT(CONVERT(varchar, [A].rsv_expdate, 100), 7) end) [ExpireTime] ")
        Query.Append("   ,[C].agent_code [AgentCode] ")
        Query.Append("from ")
        Query.Append("   slp_frm_rsv [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [B] on [B].ModelCode = [A].model_code ")
        Query.Append("   left join agent [C] on [C].agent_code = [A].created_by ")
        Query.Append("where ")
        Query.Append("   [A].status = 'Reserved' ")
        Query.Append("order by ")
        Query.Append("   [A].created_date desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("Buyer"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("TCP"))
        dtable.Columns.Add(New DataColumn("ReservationDate"))
        dtable.Columns.Add(New DataColumn("ExpiryDate"))
        dtable.Columns.Add(New DataColumn("Link"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim SlrImg As String
                    If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".PNG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPE") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPEG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If

                    Dim ReservationDate As String = DR.GetString(2) & " | " & DR.GetString(10)
                    Dim ExpirationDate As String = DR.GetString(11) & " | " & DR.GetString(12)
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(8), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(9), DR.GetString(1), DR.GetString(3), DR.GetString(4), DR.GetString(5), TCP, ReservationDate, ExpirationDate, DR.GetString(0)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvNewReservations.DataSource = dtable
        gvNewReservations.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvNewReservations.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvNewReservations.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvNewReservations.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvNewReservations.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindApproved()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("   [A].slf_code ")
        Query.Append("   ,(dbo.ProperCase([C].first_name)) + ' ' + (dbo.ProperCase([C].last_name)) [Seller] ")
        Query.Append("   ,(dbo.ProperCase([A].acct_name)) [AcctName] ")
        Query.Append("   ,[A].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[B].ModelName ")
        Query.Append("   ,[A].house_status ")
        Query.Append("   ,[A].LotArea ")
        Query.Append("   ,[A].FloorArea ")
        Query.Append("   ,[A].TCP ")
        Query.Append("   ,(dbo.ProperCase([D].first_name)) + ' ' + (dbo.ProperCase([D].last_name)) [Approver] ")
        Query.Append("   ,(case when [A].approved_date is null then '-' else CONVERT (varchar, [A].approved_date, 107) end) [ApprovedDate] ")
        Query.Append("   ,(case when [A].approved_date is null then '-' else RIGHT(CONVERT(varchar, [A].approved_date, 100), 7) end) [ApprovedTime] ")
        Query.Append("   ,[C].agent_code [AgentCode] ")
        Query.Append("from ")
        Query.Append("   slp_frm_rsv [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [B] on [B].ModelCode = [A].model_code ")
        Query.Append("   left join agent [C] on [C].agent_code = [A].created_by ")
        Query.Append("   left join employee [D] on [D].emp_no = [A].approved_by ")
        Query.Append("where ")
        Query.Append("   [A].status = 'Approved' ")
        Query.Append("order by ")
        Query.Append("   [A].approved_date desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("Buyer"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("TCP"))
        dtable.Columns.Add(New DataColumn("Approver"))
        dtable.Columns.Add(New DataColumn("ApprovedDate"))
        dtable.Columns.Add(New DataColumn("Link"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim SlrImg As String
                    If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".PNG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPE") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPEG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If
                    Dim ApprovedDate As String = DR.GetString(10) & " | " & DR.GetString(11)
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(8), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), TCP, DR.GetString(9), ApprovedDate, DR.GetString(0)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvApproved.DataSource = dtable
        gvApproved.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvApproved.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvApproved.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvApproved.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvApproved.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindRejected()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].slf_code ")
        Query.Append("   ,(dbo.ProperCase([C].first_name)) + ' ' + (dbo.ProperCase([C].last_name)) [Seller] ")
        Query.Append("   ,(dbo.ProperCase([A].acct_name)) [AcctName] ")
        Query.Append("   ,[A].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[B].ModelName ")
        Query.Append("   ,[A].house_status ")
        Query.Append("   ,[A].LotArea ")
        Query.Append("   ,[A].FloorArea ")
        Query.Append("   ,[A].TCP ")
        Query.Append("   ,(dbo.ProperCase([D].first_name)) + ' ' + (dbo.ProperCase([D].last_name)) [RejectedBy] ")
        Query.Append("   ,(case when [A].rejected_date is null then '-' else CONVERT (varchar, [A].rejected_date, 107) end) [RejectedDate] ")
        Query.Append("   ,(case when [A].rejected_date is null then '-' else RIGHT(CONVERT(varchar, [A].rejected_date, 100), 7) end) [RejectedTime] ")
        Query.Append("   ,[C].agent_code [AgentCode] ")
        Query.Append("from ")
        Query.Append("   slp_frm_rsv [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [B] on [B].ModelCode = [A].model_code ")
        Query.Append("   left join agent [C] on [C].agent_code = [A].created_by ")
        Query.Append("   left join employee [D] on [D].emp_no = [A].rejected_by ")
        Query.Append("where ")
        Query.Append("   [A].status = 'Rejected' ")
        Query.Append("order by ")
        Query.Append("   [A].rejected_date desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("Buyer"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("TCP"))
        dtable.Columns.Add(New DataColumn("RejectedBy"))
        dtable.Columns.Add(New DataColumn("RejectedDate"))
        dtable.Columns.Add(New DataColumn("Link"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim SlrImg As String
                    If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".PNG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPE") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPEG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If

                    Dim RejectedDate As String = DR.GetString(10) & " | " & DR.GetString(11)
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(8), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), DR.GetString(5), TCP, DR.GetString(9), RejectedDate, DR.GetString(0)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvRejected.DataSource = dtable
        gvRejected.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvRejected.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvRejected.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvRejected.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvRejected.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindExpired()

        'get sellers for approval
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].slf_code ")
        Query.Append("   ,(dbo.ProperCase([A].acct_name)) [AcctName] ")
        Query.Append("   ,[A].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[B].ModelName ")
        Query.Append("   ,[A].house_status ")
        Query.Append("   ,[A].LotArea ")
        Query.Append("   ,[A].FloorArea ")
        Query.Append("   ,[A].TCP ")
        Query.Append("   ,(case when [A].rsv_expdate is null then '-' else CONVERT (varchar, [A].rsv_expdate, 107) end) [ExpiredDate] ")
        Query.Append("   ,(case when [A].rsv_expdate is null then '-' else RIGHT(CONVERT(varchar, [A].rsv_expdate, 100), 7) end) [ExpireTime] ")
        Query.Append("   ,(dbo.ProperCase([C].fullname)) [AgentName] ")
        Query.Append("   ,[C].agent_code [AgentCode] ")
        Query.Append("from ")
        Query.Append("   slp_frm_rsv [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [B] on [B].ModelCode = [A].model_code ")
        Query.Append("   left join agent [C] on [C].agent_code = [A].created_by ")
        Query.Append("where ")
        Query.Append("   [A].status = 'Expired' ")
        Query.Append("order by ")
        Query.Append("   [A].rsv_expdate desc ")
        'get sellers for approval

        'Create datatable and columns
        Dim dtable As New DataTable
        dtable.Columns.Add(New DataColumn("SlrImg"))
        dtable.Columns.Add(New DataColumn("Seller"))
        dtable.Columns.Add(New DataColumn("Buyer"))
        dtable.Columns.Add(New DataColumn("Project"))
        dtable.Columns.Add(New DataColumn("Unit"))
        dtable.Columns.Add(New DataColumn("HouseStatus"))
        dtable.Columns.Add(New DataColumn("TCP"))
        dtable.Columns.Add(New DataColumn("ExpiryDate"))
        dtable.Columns.Add(New DataColumn("Link"))
        'Create datatable and columns

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim SlrImg As String
                    If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".PNG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".png"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpg"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPE") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpe"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".JPEG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("AgentCode") & "/Profile/" & DR("AgentCode") & ".jpeg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If

                    Dim ExpirationDate As String = DR.GetString(8) & " | " & DR.GetString(9)
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(7), "N2")

                    Dim NewRowValues As Object() = {SlrImg, DR.GetString(10), DR.GetString(1), DR.GetString(2), DR.GetString(3), DR.GetString(4), TCP, ExpirationDate, DR.GetString(0)}
                    Dim NewRow As DataRow
                    NewRow = dtable.Rows.Add(NewRowValues)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'bind datatable 
        gvExpired.DataSource = dtable
        gvExpired.DataBind()
        'bind datatable 

        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes
        If gvExpired.Rows.Count > 0 Then
            'Adds THEAD and TBODY Section.
            gvExpired.HeaderRow.TableSection = TableRowSection.TableHeader
            'Adds THEAD and TBODY Section.

            'Adds TH element in Header Row.  
            gvExpired.UseAccessibleHeader = True
            'Adds TH element in Header Row.  

            'Adds TFOOT section. 
            gvExpired.FooterRow.TableSection = TableRowSection.TableFooter
            'Adds TFOOT section. 
        End If
        'tagged gridview with THEAD / TBODY / TFOOT for datatable javacript purposes

    End Function

    Function bindCounter()

        'get the count of sellers
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  count(case when [A].status = 'Reserved' then 1 end) [Reserved] ")
        Query.Append("  ,count(case when [A].status = 'Approved' then 1 end) [Approved] ")
        Query.Append("  ,count(case when [A].status = 'Rejected' then 1 end) [Rejected] ")
        Query.Append("  ,count(case when [A].status = 'Expired' then 1 end) [Expired] ")
        Query.Append("from ")
        Query.Append("  slp_frm_rsv [A] ")
        'get the count of sellers

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblNewReservationsCount.Text = DR.GetInt32(0)
                    lblApprovedCount.Text = DR.GetInt32(1)
                    lblRejectedCount.Text = DR.GetInt32(2)
                    lblExpiredCount.Text = DR.GetInt32(3)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        mdlSellerDtl.Update()
        upnlNavBar.Update()
        'display data

    End Function

    Function CheckExpiry()

        Dim today As DateTime = Date.Today

        'get the count of sellers
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].LotCode [LotCode] ")
        Query.Append("   ,(case when [A].rsv_expdate is null then '' else CONVERT (varchar, [A].rsv_expdate, 107) end) [ExpiryDate] ")
        Query.Append("   ,(case when [A].slf_date is null then '' else CONVERT (varchar, [A].slf_date, 107) end) [ReservationDate] ")
        Query.Append("   ,[A].status ")
        Query.Append("   ,[A].rsv_expdate ")
        Query.Append("from ")
        Query.Append("  slp_frm_rsv [A] ")
        'get the count of sellers

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim LotCode As String = DR.GetString(0)
                    Dim expirationDate As String = DR.GetString(1)
                    Dim status As String = DR.GetString(3)
                    Dim CurrentDate = DateTime.Now
                    If Not DR.IsDBNull(4) Then
                        Dim ExpiryDate = DR.GetDateTime(4)
                        Dim CheckExpDate = ExpiryDate.TimeOfDay
                        Dim CheckCurrentDate = CurrentDate.TimeOfDay

                        'Check for expiration and update status if necessary
                        If CheckCurrentDate >= CheckExpDate And status <> "Expired" Then
                            UpdateExpiredReservation(LotCode)
                        End If
                    End If

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        mdlSellerDtl.Update()
        upnlNavBar.Update()
        bindCounter()
        'display data

    End Function

    Private Sub UpdateExpiredReservation(LotCode As String)
        'update reservation table
        Dim Query As New StringBuilder()
        Query.AppendLine("update slp_frm_rsv ")
        Query.AppendLine("  set status = 'Expired' ")
        Query.AppendLine("where ")
        Query.AppendLine("  LotCode = @LotCode ")
        Query.AppendLine("  and status <> 'Expired' ")

        'update lotinventory
        Query.AppendLine("update calmardbLive.dbo.mstr_LotsInventory ")
        Query.AppendLine("  set IsReserve = 2 ")
        Query.AppendLine("where ")
        Query.AppendLine("  LotCode = @LotCode ")
        Query.AppendLine("  and IsReserve <> 2 ")

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@LotCode", LotCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

        'counter and refresh
        mdlSellerDtl.Update()
        upnlNavBar.Update()
        bindCounter()
        ClientScript.RegisterStartupScript(Me.GetType(), "reload", "window.location.reload();", True)
        'counter and refresh

    End Sub

    Function bindGroupSalesBarChart()

        'get sold units per seller
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [D].SellerRank [Rank] ")
        Query.Append("  ,[D].SellerTypeDesc [Type] ")
        Query.Append("  ,COUNT(G.ModelCode) [ReservedUnits]  ")
        Query.Append("from  ")
        Query.Append("  calmardbLive.dbo.ICR_Sellers [A]  ")
        Query.Append("  left join calmardbLive.dbo.mstr_Sellers [B] on [B].SellerCode =  [A].SellerCode ")
        Query.Append("  left join agent [C] on [C].agent_code = [B].AgentCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_SellerTypes [D] on [D].SellerTypeCode = [A].TypeCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [A].GroupCode ")
        Query.Append("  left join calmardbLive.dbo.ICR_Buyers [F] on [F].AcctNo = [A].AcctNo ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [G] on [G].ModelCode = [F].ModelCode ")
        Query.Append("  left join calmardbLive.dbo.ICR_Reservations [H] on [H].AcctNo = [A].AcctNo ")
        Query.Append("where ")
        Query.Append("  [F].Posted = 1 ")
        Query.Append("  and [F].Active = 1 ")
        Query.Append("  and YEAR([H].RFDate) = YEAR(GETDATE()) ")
        Query.Append("group by ")
        Query.Append("  [D].SellerRank  ")
        Query.Append("  ,[D].SellerTypeDesc  ")
        Query.Append("order by ")
        Query.Append("  [D].SellerRank ")
        'get sold units per seller 

        ltrlBarGroupSalesData.Text = ""
        ltrlBarGroupSalesName.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGroupSalesName.Text = "" Then
                        ltrlBarGroupSalesName.Text = DR.GetString(1)
                    Else
                        ltrlBarGroupSalesName.Text = ltrlBarGroupSalesName.Text & "," & DR.GetString(1)
                    End If

                    If ltrlBarGroupSalesData.Text = "" Then
                        ltrlBarGroupSalesData.Text = DR.GetInt32(2)
                    Else
                        ltrlBarGroupSalesData.Text = ltrlBarGroupSalesData.Text & "," & DR.GetInt32(2)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        mdlSellerDtl.Update()
        'diplay record

    End Function

    Function bindAcctStatPieChart()

        'get details - per project
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  count(case when [A].status = 'New' then 1 end) [Pending] ")
        Query.Append("  ,count(case when [A].status = 'Reserved' then 1 end) [Reserved] ")
        Query.Append("  ,count(case when [A].status = 'Approved' then 1 end) [Approved] ")
        Query.Append("  ,count(case when [A].status = 'Rejected' then 1 end) [Rejected] ")
        Query.Append("from ")
        Query.Append("  slp_frm_rsv [A] ")
        'get details - per project

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    lblPiePending.Text = DR.GetInt32(0)
                    ltrlPiePending.Text = DR.GetInt32(0)

                    lblPieReserved.Text = DR.GetInt32(1)
                    ltrlPieReserved.Text = DR.GetInt32(1)

                    lblPieApproved.Text = DR.GetInt32(2)
                    ltrlPieApproved.Text = DR.GetInt32(2)

                    lblPieRejected.Text = DR.GetInt32(3)
                    ltrlPieRejected.Text = DR.GetInt32(3)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        mdlSellerDtl.Update()
        'diplay record

    End Function

#End Region

#Region "Button"

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApprove.Click

        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Rsv_Frm_Approved"
        SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'display record
        bindNewReservations()
        bindApproved()
        bindRejected()
        bindCounter()
        mdlSellerDtl.Update()
        'diplay record
        Exit Sub

    End Sub

    Protected Sub btnReject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReject.Click

        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Rsv_Frm_Reject"
        SqlCmd.Parameters.AddWithValue("@pLotCode", hfLotCode.Value)
        SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'display record
        bindNewReservations()
        bindApproved()
        bindRejected()
        bindCounter()
        mdlSellerDtl.Update()
        'diplay record
        Exit Sub

    End Sub

#End Region

#Region "Validation"

    'Private Sub checkUserAccess()

    '    'retrieve user information from the cookie
    '    Dim Validator As String = CIIS_UserInfo.Values("CIIS_EmpCode")

    '    'validate user credentials
    '    If validateUserAccess(Validator) = False Then
    '        Response.Redirect("DSB000001")
    '    End If

    'End Sub

    'Private Function validateUserAccess(Validator As String) As Boolean

    '    'get agent details
    '    Dim Query As New StringBuilder
    '    Query.Append("if (select [A].emp_no from employee [A] where [A].emp_no = '" & Validator & "') in ('2010000024', 'MN2021080000', 'MN2024030004', 'MN2023100001') ")
    '    Query.Append("begin ")
    '    Query.Append("  select 'Approved' ")
    '    Query.Append("end ")
    '    Query.Append("else ")
    '    Query.Append("begin ")
    '    Query.Append("  select 'Denied' ")
    '    Query.Append("end ")
    '    'get agent details

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()
    '                Dim Access As String = DR.GetString(0)

    '                If Access = "Approved" Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            End While
    '            DR.Close()
    '            ConStr.Close()
    '        End Using
    '    End Using
    '    'read record

    'End Function

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
                Query.Append("if 'SLS030000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS030000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SLS030000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS030000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SLS030000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS030000' and Save_ = 1) ")
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