Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Web.Script.Serialization
Imports System.Web.Services.Protocols
Imports Microsoft.AspNet.SignalR.Hosting
Imports Microsoft.SqlServer

Public Class HND000006
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "iis"
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")
            'general parameter

            If FormCode = "SLS010000" And Type = "View Agent Detail (AgentCode)" Then

                Dim AgentCode = context.Request("AgentCode")

                Dim json As String = Me.bindAgentDetail(AgentCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS010000" And Type = "Edit Agent Detail (AgentCode)" Then

                Dim AgentCode = context.Request("AgentCode")

                Dim json As String = Me.bindEditSellerDetail(AgentCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS020000" And Type = "View Users (SellerType)" Then

                Dim SellerType = context.Request("SellerType")

                Dim json As String = Me.bindUserDetail(SellerType)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS020000" And Type = "View Detail (SellerCode)" Then

                Dim SellerCode = context.Request("SellerCode")

                Dim json As String = Me.bindSellerDetail(SellerCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS020000" And Type = "View Detail Revert (SellerCode)" Then

                Dim SellerCode = context.Request("SellerCode")

                Dim json As String = Me.bindRvtSellerDetail(SellerCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS030000" And Type = "View Reservation Detail (SLFCode)" Then

                Dim SLFCode = context.Request("SLFCode")

                Dim textbox As String = Me.bindReservationDetail(SLFCode)
                Dim datatable As String = Me.bindDatatable(SLFCode)

                Dim jsonResponse As String = $"{{""textBoxData"": {textbox}, ""dataTableData"": {datatable}}}"
                context.Response.ContentType = "text/json"
                context.Response.Write(jsonResponse)

            ElseIf FormCode = "SLS040000" And Type = "View Masterlist (Project)" Then

                Dim Project = context.Request("Project")

                Dim json As String = Me.bindMasterlistProj(Project)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS040000" And Type = "View Sellers Inventory (Project)" Then

                Dim Project = context.Request("Project")

                Dim json As String = Me.bindInventoryProj(Project)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS040000" And Type = "View History (LotCode)" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.bindLotHistory(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS050000" And Type = "View Reservation Detail (Project)" Then

                Dim Project = context.Request("Project")

                Dim json As String = Me.bindRvtDetail(Project)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS050000" And Type = "View Booked Detail (Project)" Then

                Dim Project = context.Request("Project")

                Dim json As String = Me.bindBkDetail(Project)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS060000" And Type = "View Group Sales (RsvGrp)" Then

                Dim RsvGrp = context.Request("RsvGrp")

                Dim json As String = Me.bindGrpSlsRsv(RsvGrp)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS060000" And Type = "View Group Sales (BkGrp)" Then

                Dim BkGrp = context.Request("BkGrp")

                Dim json As String = Me.bindGrpSlsBk(BkGrp)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SLS060000" And Type = "View Group Sales Chart (Month)" Then

                Dim selectedMonth = context.Request("selectedMonth")

                Dim json As String = Me.bindGrpSlsChart(selectedMonth)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

                'ElseIf FormCode = "SLS060000" And Type = "View Seller Ranking (Type)" Then

                '    Dim SLType = context.Request("SLType")

                '    Dim json As String = Me.bindSLTypeRank(SLType)
                '    context.Response.ContentType = "text/json"
                '    context.Response.Write(json)

            End If

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
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

#Region "SLS010000"

    Function bindAgentDetail(AgentCode)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [AgentCodeDtl] ")
        Query.Append("   ,(dbo.ProperCase([A].first_name)) [AgentFName] ")
        Query.Append("   ,(dbo.ProperCase([A].middle_name)) [AgentMName] ")
        Query.Append("   ,(dbo.ProperCase([A].last_name)) [AgentLName] ")
        Query.Append("   ,isnull([A].email, '-') [AgentEmail] ")
        'Query.Append("   ,isnull([C].SellerGrpDesc, '-') [AgentGroup] ")
        'Query.Append("   ,isnull([D].SellerTypeDesc, '-') [AgentType] ")
        Query.Append("   ,(dbo.ProperCase(isnull([A].addr1, '-'))) [AgentAddress] ")
        Query.Append("   ,isnull([A].tin, '-') [AgentTIN] ")
        Query.Append("   ,(dbo.ProperCase(isnull([A].remarks, '-'))) [AgentRemarks] ")
        Query.Append("from ")
        Query.Append("   agent [A] ")
        'Query.Append("   left join calmardbLive.dbo.mstr_Sellers [B] on [B].AgentCode = [A].agent_code ")
        'Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [C] on [C].SellerGrpCode = [B].SellerGrpCode ")
        'Query.Append("   left join calmardbLive.dbo.mstr_SellerTypes [D] on [D].SellerTypeCode = [B].SellerType ")
        Query.Append("where ")
        Query.Append("   [A].agent_code = '" & AgentCode & "' ")
        Query.Append("   and [A].last_name <> 'Direct' ")
        'get seller details onclick

        'variable
        Dim AgentDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    AgentDetails.Add(New With {
                        .AgentCodeDtl = DR("AgentCodeDtl"),
                        .AgentFName = DR("AgentFName"),
                        .AgentMName = DR("AgentMName"),
                        .AgentLName = DR("AgentLName"),
                        .AgentEmail = DR("AgentEmail"),
                        .AgentAddress = DR("AgentAddress"),
                        .AgentTIN = DR("AgentTIN"),
                        .AgentRemarks = DR("AgentRemarks")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(AgentDetails))
        'display 

    End Function

    Function bindEditSellerDetail(AgentCode)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [AgentCodeDtl1] ")
        Query.Append("   ,[A].first_name [AgentFName1] ")
        Query.Append("   ,[A].middle_name [AgentMName1] ")
        Query.Append("   ,[A].last_name [AgentLName1] ")
        Query.Append("   ,isnull([A].email, '-') [AgentEmail1] ")
        Query.Append("   ,(dbo.ProperCase(isnull([A].addr1, '-'))) [AgentAddress1] ")
        Query.Append("   ,isnull([A].tin, '-') [AgentTIN1] ")
        Query.Append("   ,(dbo.ProperCase(isnull([A].remarks, '-'))) [AgentRemarks1] ")
        Query.Append("from ")
        Query.Append("   agent [A] ")
        Query.Append("where ")
        Query.Append("   [A].agent_code = '" & AgentCode & "' ")
        Query.Append("   and [A].last_name <> 'Direct' ")
        'get seller details onclick

        'variable
        Dim AgentDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    AgentDetails.Add(New With {
                        .AgentCodeDtl1 = DR("AgentCodeDtl1"),
                        .AgentFName1 = DR("AgentFName1"),
                        .AgentMName1 = DR("AgentMName1"),
                        .AgentLName1 = DR("AgentLName1"),
                        .AgentEmail1 = DR("AgentEmail1"),
                        .AgentAddress1 = DR("AgentAddress1"),
                        .AgentTIN1 = DR("AgentTIN1"),
                        .AgentRemarks1 = DR("AgentRemarks1")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(AgentDetails))
        'display 

    End Function

#End Region

#Region "SLS020000"

    Function bindUserDetail(SellerType)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [AgentCode]  ")
        Query.Append("   ,dbo.ProperCase([A].fullname) [Seller]  ")
        Query.Append("   ,[A].sl_type [Type] ")
        Query.Append("   ,[A].sl_group [Group] ")
        Query.Append("   ,[A].sl_username [Email] ")
        Query.Append("   ,[A].acct_status [Status] ")
        Query.Append("from ")
        Query.Append("   slp_user_register [A] ")
        Query.Append("where ")
        Query.Append("   [A].active = 1 ")
        Query.Append("   and [A].sl_type = '" & SellerType & "' ")
        'get seller details onclick

        'variable
        Dim UserDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Status = DR.GetString(5)
                    Dim FormattedStatus As String
                    If Status = "For Approval" Then
                        FormattedStatus = "<span class='fw-bolder text-info fs-6'> " & Status & " </span>"
                    ElseIf Status = "Approved" Then
                        FormattedStatus = "<span class='fw-bolder text-primary fs-6'> " & Status & " </span>"
                    ElseIf Status = "Rejected" Then
                        FormattedStatus = "<span class='fw-bolder text-danger fs-6'> " & Status & " </span>"
                    End If

                    UserDetails.Add(New With {
                        .Seller = DR("Seller"),
                        .Type = DR("Type"),
                        .Group = DR("Group"),
                        .Email = DR("Email"),
                        .Status = FormattedStatus
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(UserDetails))
        'display 

    End Function

    Function bindSellerDetail(SellerCode)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [AgentCode]  ")
        Query.Append("   ,(dbo.ProperCase([A].first_name)) [FirstName]  ")
        Query.Append("   ,(dbo.ProperCase([A].middle_name)) [MiddleName]  ")
        Query.Append("   ,(dbo.ProperCase([A].last_name)) [LastName]  ")
        Query.Append("   ,[A].sl_username [Email] ")
        Query.Append("   ,[A].sl_type [Type] ")
        Query.Append("   ,[A].sl_group [Group] ")
        Query.Append("   ,[A].acct_status [Status] ")
        Query.Append("   ,(case when [A].created_date is null then '-' else CONVERT (varchar, [A].created_date, 107) end) [DateCreated] ")
        Query.Append("from ")
        Query.Append("   slp_user_register [A] ")
        Query.Append("where ")
        Query.Append("   [A].acct_status = 'For Approval' ")
        Query.Append("   and [A].agent_code = '" & SellerCode & "' ")
        'get seller details onclick

        'variable
        Dim SellerDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
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

                    SellerDetails.Add(New With {
                        .AgentCode = DR("AgentCode"),
                        .FirstName = DR("FirstName"),
                        .MiddleName = DR("MiddleName"),
                        .LastName = DR("LastName"),
                        .Email = DR("Email"),
                        .Type = DR("Type"),
                        .Group = DR("Group"),
                        .Status = DR("Status"),
                        .DateCreated = DR("DateCreated"),
                        .SlrImg = SlrImg
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(SellerDetails))
        'display 

    End Function

    Function bindRvtSellerDetail(SellerCode)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].agent_code [RvtAgentCode]  ")
        Query.Append("   ,(dbo.ProperCase([A].first_name)) [RvtFirstName]  ")
        Query.Append("   ,(dbo.ProperCase([A].middle_name)) [RvtMiddleName]  ")
        Query.Append("   ,(dbo.ProperCase([A].last_name)) [RvtLastName]  ")
        Query.Append("   ,[A].sl_username [RvtEmail] ")
        Query.Append("   ,[A].sl_type [RvtType] ")
        Query.Append("   ,[A].sl_group [RvtGroup] ")
        Query.Append("   ,[A].acct_status [RvtStatus] ")
        Query.Append("   ,(case when [A].created_date is null then '-' else CONVERT (varchar, [A].created_date, 107) end) [RvtDateApproved] ")
        Query.Append("   ,(case when [A].rejected_date is null then '-' else CONVERT (varchar, [A].rejected_date, 107) end) [RvtDateDenied] ")
        Query.Append("from ")
        Query.Append("   slp_user_register [A] ")
        Query.Append("where ")
        Query.Append("   [A].agent_code = '" & SellerCode & "' ")
        'get seller details onclick

        'variable
        Dim SellerDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Status As String = DR("RvtStatus")
                    Dim NewDate As String
                    If Status = "Approved" Then
                        NewDate = DR("RvtDateApproved")
                    ElseIf Status = "Rejected" Then
                        NewDate = DR("RvtDateDenied")
                    End If
                    Dim SlrImg As String
                    If CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".png") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".PNG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".png"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".jpg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".JPG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".jpg"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".jpe") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".JPE") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".jpe"
                    ElseIf CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".jpeg") Or CheckIfRemoteFileExists("http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".JPEG") Then
                        SlrImg = "http://sellersportal.calmarland.com:809/Assets/Upload/sellers/" & DR("RvtAgentCode") & "/Profile/" & DR("RvtAgentCode") & ".jpeg"
                    Else
                        SlrImg = "Assets/media/avatars/blank.png"
                    End If

                    SellerDetails.Add(New With {
                        .RvtAgentCode = DR("RvtAgentCode"),
                        .RvtFirstName = DR("RvtFirstName"),
                        .RvtMiddleName = DR("RvtMiddleName"),
                        .RvtLastName = DR("RvtLastName"),
                        .RvtEmail = DR("RvtEmail"),
                        .RvtType = DR("RvtType"),
                        .RvtGroup = DR("RvtGroup"),
                        .RvtStatus = DR("RvtStatus"),
                        .RvtDateApproved = NewDate,
                        .SlrImg = SlrImg
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(SellerDetails))
        'display 

    End Function

#End Region

#Region "SLS030000"

    Function bindReservationDetail(SLFCode)

        'get reservation details onclick
        Dim Query As New StringBuilder
        Query.Append("select top 1")
        Query.Append("  [A].LotCode ")
        Query.Append("  ,[A].slf_code [ID] ")
        Query.Append("  ,[A].status [FormStatus] ")
        Query.Append("  ,(dbo.ProperCase([C].first_name)) + ' ' + (dbo.ProperCase([C].last_name)) [RequestedBy] ")
        Query.Append("  ,isnull([F].SellerTypeDesc, '-') [Type] ")
        Query.Append("  ,isnull([E].SellerGrpDesc, '-') [Group] ")
        Query.Append("  ,[G].Description [FormType] ")
        Query.Append("  ,(case when [A].created_date is null then '-' else CONVERT (varchar, [A].created_date, 107) end) [ReservationDate] ")
        Query.Append("  ,(dbo.ProperCase([A].acct_name)) [AcctName] ")
        Query.Append("  ,[A].ProjInit [ProjInit] ")
        Query.Append("  ,[A].phase [Phase] ")
        Query.Append("  ,[A].Block [Block] ")
        Query.Append("  ,[A].Lot [Lot] ")
        Query.Append("  ,[B].ModelName [HouseModel] ")
        Query.Append("  ,[A].lot_type [LotType] ")
        Query.Append("  ,[A].house_status [HouseStatus] ")
        Query.Append("  ,[A].LotArea [LotArea] ")
        Query.Append("  ,[A].FloorArea [FloorArea] ")
        Query.Append("  ,[A].financing [Financing] ")
        Query.Append("  ,[A].TCP [TCP] ")
        Query.Append("  ,[A].fixeddisc [FixedDisc] ")
        Query.Append("  ,[A].loyaltydiscPercent [LoyaltyDiscPercent] ")
        Query.Append("  ,[A].loyaltydisc [LoyaltyDisc] ")
        Query.Append("  ,[A].netpromodisc [NetPromoDisc] ")
        Query.Append("  ,[A].spotDPdiscPercent [SpotDPDiscPercent] ")
        Query.Append("  ,[A].spotDPdisc [SpotDPDisc] ")
        Query.Append("  ,[A].netTCP [NetTCP] ")
        Query.Append("  ,[A].VATPercent [VATPercent] ")
        Query.Append("  ,[A].VAT [VAT] ")
        Query.Append("  ,[A].netContractPrice [NetContractPrice] ")
        Query.Append("  ,[A].downpaymentAPercent [downpaymentAPercent] ")
        Query.Append("  ,[A].downpaymentA [DownPaymentA] ")
        Query.Append("  ,[A].payments_made [PaymentsMade] ")
        Query.Append("  ,[A].PRNo [PRNo] ")
        Query.Append("  ,(case when [A].PRDate is null then '-' else CONVERT (varchar, [A].PRDate, 107) end) [PRDate] ")
        Query.Append("  ,[A].dpbalance [DPBalance] ")
        Query.Append("  ,[A].payablewithinA [PayableWithinA] ")
        Query.Append("  ,[A].monthly_equityA [MonthlyEquityA] ")
        Query.Append("  ,[H].Description [LoanableAmtOpt] ")
        Query.Append("  ,[A].loanable_amt [LoanableAmt] ")
        Query.Append("  ,[A].interest_rate [InterestRate] ")
        Query.Append("  ,[A].term_years [Term] ")
        Query.Append("  ,[A].est_monthly_amort [EstMonthlyAmort] ")
        Query.Append("  ,[A].finalnetTCP [FinalNetTCP] ")
        Query.Append("  ,[A].bankcharges [BankCharges] ")
        Query.Append("  ,[A].movein_charges [MoveInCharges] ")
        Query.Append("  ,[A].waterconnfee [WaterConnFee] ")
        Query.Append("  ,[A].elecconnfee [ElecConnFee] ")
        Query.Append("  ,[A].fireinsurance [FireInsurance] ")
        Query.Append("  ,[A].mri [MortInsurance] ")
        Query.Append("  ,[A].vmd_prom [Promesa] ")
        Query.Append("  ,[A].vmd_cbhiltv [CbhIlTv] ")
        Query.Append("  ,[A].totalothercharges [TotalOtherCharges] ")
        Query.Append("from ")
        Query.Append("  slp_frm_rsv [A] ")
        Query.Append("  left join calmardbLive.dbo.mstr_HouseModels [B] on [B].ModelCode = [A].model_code ")
        Query.Append("  left join agent [C] on [C].agent_code = [A].created_by ")
        Query.Append("  left join calmardbLive.dbo.mstr_Sellers [D] on [D].AgentCode = [C].agent_code ")
        Query.Append("  left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("  left join calmardbLive.dbo.mstr_SellerTypes [F] on [F].SellerTypeCode = [D].SellerType ")
        Query.Append("  left join calmardbLive.dbo.Parm_CSHdr [G] on [G].Code = [A].FormType ")
        Query.Append("  left join calmardbLive.dbo.Parm_CSLoan [H] on [H].LCode = [A].LoanableAmtOpt ")
        Query.Append("where ")
        Query.Append("  [A].slf_code = '" & SLFCode & "' ")
        'get reservation details onclick

        'variable
        Dim ReservationDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim FloorArea As String
                    If DR("FloorArea") <> 0 Then
                        FloorArea = String.Format("{0:N2}sqm", DR("FloorArea"))
                    Else
                        FloorArea = "-"
                    End If

                    Dim loyaltyDiscPercent As Decimal = DR("loyaltyDiscPercent") / 100
                    Dim spotDPDiscPercent As Decimal = DR("spotDPDiscPercent") / 100
                    Dim VATPercent As Decimal = DR("VATPercent") / 100
                    Dim downpaymentAPercent As Decimal = DR("downpaymentAPercent") / 100

                    ReservationDetails.Add(New With {
                        .LotCode = DR("LotCode"),
                        .ID = DR("ID"),
                        .FormStatus = DR("FormStatus"),
                        .RequestedBy = DR("RequestedBy"),
                        .Type = DR("Type"),
                        .Group = DR("Group"),
                        .FormType = DR("FormType"),
                        .ReservationDate = DR("ReservationDate"),
                        .AcctName = DR("AcctName"),
                        .ProjInit = DR("ProjInit"),
                        .Phase = DR("Phase"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .HouseModel = DR("HouseModel"),
                        .LotType = DR("LotType"),
                        .HouseStatus = DR("HouseStatus"),
                        .LotArea = String.Format("{0}sqm", DR("LotArea")),
                        .FloorArea = FloorArea,
                        .Financing = DR("Financing"),
                        .TCP = String.Format("₱ {0:N2}", DR("TCP")),
                        .FixedDisc = String.Format("₱ {0:N2}", DR("FixedDisc")),
                        .LoyaltyDiscPercent = String.Format("{0:P2}", loyaltyDiscPercent),
                        .LoyaltyDisc = String.Format("₱ {0:N2}", DR("LoyaltyDisc")),
                        .NetPromoDisc = String.Format("₱ {0:N2}", DR("NetPromoDisc")),
                        .SpotDPDiscPercent = String.Format("{0:P2}", spotDPDiscPercent),
                        .SpotDPDisc = String.Format("₱ {0:N2}", DR("SpotDPDisc")),
                        .NetTCP = String.Format("₱ {0:N2}", DR("NetTCP")),
                        .VATPercent = String.Format("{0:P2}", VATPercent),
                        .VAT = String.Format("₱ {0:N2}", DR("VAT")),
                        .NetContractPrice = String.Format("₱ {0:N2}", DR("NetContractPrice")),
                        .DownPaymentAPercent = String.Format("{0:P2}", downpaymentAPercent),
                        .DownPaymentA = String.Format("₱ {0:N2}", DR("DownPaymentA")),
                        .PaymentsMade = String.Format("₱ {0:N2}", DR("PaymentsMade")),
                        .PRNo = DR("PRNo"),
                        .PRDate = DR("PRDate"),
                        .DPBalance = String.Format("₱ {0:N2}", DR("DPBalance")),
                        .PayableWithinA = DR("PayableWithinA"),
                        .MonthlyEquityA = String.Format("₱ {0:N2}", DR("MonthlyEquityA")),
                        .LoanableAmtOpt = DR("LoanableAmtOpt"),
                        .LoanableAmt = String.Format("₱ {0:N2}", DR("LoanableAmt")),
                        .InterestRate = String.Format("{0}%", DR("InterestRate")),
                        .Term = DR("Term") & " Months",
                        .EstMonthlyAmort = String.Format("₱ {0:N2}", DR("EstMonthlyAmort")),
                        .FinalNetTCP = String.Format("₱ {0:N2}", DR("FinalNetTCP")),
                        .BankCharges = String.Format("₱ {0:N2}", DR("BankCharges")),
                        .MoveInCharges = String.Format("₱ {0:N2}", DR("MoveInCharges")),
                        .WaterConnFee = String.Format("₱ {0:N2}", DR("WaterConnFee")),
                        .ElecConnFee = String.Format("₱ {0:N2}", DR("ElecConnFee")),
                        .FireInsurance = String.Format("₱ {0:N2}", DR("FireInsurance")),
                        .MortInsurance = String.Format("₱ {0:N2}", DR("MortInsurance")),
                        .Promesa = String.Format("₱ {0:N2}", DR("Promesa")),
                        .CbhIlTv = String.Format("₱ {0:N2}", DR("CbhIlTv")),
                        .TotalOtherCharges = String.Format("₱ {0:N2}", DR("TotalOtherCharges"))
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ReservationDetails))
        'display 

    End Function

    Private Function bindDatatable(ByVal SLFCode As String) As String

        'get reservation details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Description [Description]")
        Query.Append("  ,(case when [A].DueDate is null then '-' else CONVERT (varchar, [A].DueDate, 107) end) [DueDate] ")
        Query.Append("  ,[A].DPAmount [DPAmount] ")
        Query.Append("  ,[A].BankCharges [BankCharges] ")
        Query.Append("  ,[A].MoveInCharges [MoveInCharges] ")
        Query.Append("  ,[A].TotalAmountDue [TotalAmountDue] ")
        Query.Append("from ")
        Query.Append("  slp_payment_schedule [A] ")
        Query.Append("where ")
        Query.Append("  [A].SLFCode = '" & SLFCode & "' ")
        Query.Append("order by ")
        Query.Append("  [A].sequence ")
        'get reservation details onclick

        'variable
        Dim ReservationDetails As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim BankCharges As Decimal = Convert.ToDecimal(DR("BankCharges"))
                    Dim FormattedBankCharges As String
                    If BankCharges <> 0 Then
                        FormattedBankCharges = String.Format("₱ {0:N2}", BankCharges)
                    Else
                        FormattedBankCharges = "-"
                    End If

                    Dim MoveInCharges As Decimal = Convert.ToDecimal(DR("MoveInCharges"))
                    Dim FormattedMoveInCharges As String
                    If MoveInCharges <> 0 Then
                        FormattedMoveInCharges = String.Format("₱ {0:N2}", MoveInCharges)
                    Else
                        FormattedMoveInCharges = "-"
                    End If

                    Dim DPAmount As Decimal = Convert.ToDecimal(DR("DPAmount"))
                    Dim FormattedDPAmount As String
                    If DPAmount <> 0 Then
                        FormattedDPAmount = String.Format("₱ {0:N2}", DPAmount)
                    Else
                        FormattedDPAmount = "-"
                    End If

                    Dim TotalAmountDue As Decimal = Convert.ToDecimal(DR("TotalAmountDue"))
                    Dim FormattedTotalAmountDue As String
                    If TotalAmountDue <> 0 Then
                        FormattedTotalAmountDue = String.Format("₱ {0:N2}", TotalAmountDue)
                    Else
                        FormattedTotalAmountDue = "-"
                    End If

                    ReservationDetails.Add(New With {
                        .Description = DR("Description"),
                        .DueDate = DR("DueDate"),
                        .DPAmount = FormattedDPAmount,
                        .BankCharges = FormattedBankCharges,
                        .MoveInCharges = FormattedMoveInCharges,
                        .TotalAmountDue = FormattedTotalAmountDue
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ReservationDetails))
        'display 

    End Function

#End Region

#Region "SLS040000"

    Function bindMasterlistProj(Project)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status <> 1  ")
        If Project = "[A].ProjInit" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @Project  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("   ,[P].InventoryStatus ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get seller details onclick

        'variable
        Dim MstrListDtl As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If Project <> "[A].ProjInit" Then
                    Cmd.Parameters.AddWithValue("@Project", Project)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    MstrListDtl.Add(New With {
                        .ProjInit = DR("ProjInit"),
                        .Project = DR("Project"),
                        .HouseStatus = DR("HouseStatus"),
                        .LotType = DR("LotType"),
                        .Category = DR("Category"),
                        .Status = DR("Status"),
                        .LotCode = DR("LotCode"),
                        .InventoryStatus = DR("InventoryStatus")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(MstrListDtl))
        'display 

    End Function

    Function bindInventoryProj(Project)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("with ProjList AS ( ")
        Query.Append("   select ")
        Query.Append("      [A].ProjInit ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("      ,[B].inventory_status [InventoryStatus] ")
        Query.Append("      ,[A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project]  ")
        Query.Append("      ,[C].ModelCode [ModelCode]  ")
        Query.Append("      ,[D].ModelName [Unit]  ")
        Query.Append("      ,(case when [A].Territory = 'Que' then 'Quezon' when [A].Territory = 'Bat' then 'Batangas' when [A].Territory = 'Lag' then 'Laguna' else '-' end) [Territory] ")
        Query.Append("      ,[A].LotArea ")
        Query.Append("      ,[A].FloorArea ")
        Query.Append("      ,[A].LotType ")
        Query.Append("      ,[A].DevAllocation [Category] ")
        Query.Append("      ,(case when [A].HCRate = 100 then 'RFO' else 'Non-RFO' end) [HouseStatus] ")
        Query.Append("      ,(case when [B].IsReserve = 1 then 'Reserved' when [B].IsReserve = 2 then 'Open Lot' when [B].IsReserve = 0 then 'Pending' end) [Status] ")
        Query.Append("      ,[A].HCRate [Rate] ")
        Query.Append("      ,ROW_NUMBER() OVER (PARTITION BY [A].LotCode ORDER BY [A].LotCode) [DescRow] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.Lot [A] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [B] on [B].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseFit [C] on [C].LotCode = [A].LotCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_HouseModels [D] on [D].ModelCode = [C].ModelCode ")
        Query.Append("  where ")
        Query.Append("      [B].inventory_status = 1  ")
        If Project = "[A].ProjInit" Then
            Query.Append("      and [A].ProjInit = [A].ProjInit ")
        Else
            Query.Append("      and [A].ProjInit = @Project  ")
        End If
        Query.Append("      and [A].Saleable = 1  ")
        Query.Append("      and [A].PropertyStatus = 'Open' ")
        Query.Append("      and [B].IsReserve <> 3 ")
        Query.Append("      and ([C].TCP <> 0 OR [C].SellingPrice <> 0)) ")
        Query.Append("select  ")
        Query.Append("   [P].ProjInit ")
        Query.Append("   ,[P].Project ")
        Query.Append("   ,[P].HouseStatus ")
        Query.Append("   ,[P].LotType ")
        Query.Append("   ,[P].Category ")
        Query.Append("   ,[P].Status ")
        Query.Append("   ,[P].LotCode ")
        Query.Append("   ,[P].InventoryStatus ")
        Query.Append("from ")
        Query.Append("   ProjList [P] ")
        Query.Append("where ")
        Query.Append("   ([P].Rate = 100 and [P].Status = 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate = 100 and [P].Status <> 'Reserved' and [P].DescRow = 1) ")
        Query.Append("   or ([P].Rate <> 100 and [P].ModelCode = 0) ")
        Query.Append("order by ")
        Query.Append("   [P].Project ")
        'get seller details onclick

        'variable
        Dim InvListDtl As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                If Project <> "[A].ProjInit" Then
                    Cmd.Parameters.AddWithValue("@Project", Project)
                End If
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    InvListDtl.Add(New With {
                        .ProjInit = DR("ProjInit"),
                        .Project = DR("Project"),
                        .HouseStatus = DR("HouseStatus"),
                        .LotType = DR("LotType"),
                        .Category = DR("Category"),
                        .Status = DR("Status"),
                        .LotCode = DR("LotCode"),
                        .InventoryStatus = DR("InventoryStatus")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(InvListDtl))
        'display 

    End Function

    Function bindLotHistory(LotCode) 'retyrn

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].LotCode [LotCode] ")
        Query.Append("   ,dbo.ProperCase([B].first_name + ' ' + [B].last_name) [Employee] ")
        Query.Append("   ,[A].description [Desc] ")
        Query.Append("   ,(case when [A].remarks is null or [A].remarks = '' then '-' else [A].remarks end) [Remarks] ")
        Query.Append("   ,(case when [A].updated_date is null then '-' else CONVERT (varchar, [A].updated_date, 107) end) [Date] ")
        Query.Append("   ,(case when [A].updated_date is null then '-' else RIGHT(CONVERT(varchar, [A].updated_date, 100), 7) end) [Time] ")
        Query.Append("   ,[C].ProjCode [ProjImage] ")
        Query.Append("from ")
        Query.Append("   lot_inventory_history [A] ")
        Query.Append("   left join employee [B] on [B].emp_no = [A].updated_by ")
        Query.Append("   left join calmardbLive.dbo.mstr_LotsInventory [C] on [C].LotCode = [A].LotCode ")
        Query.Append("where ")
        Query.Append("   [A].LotCode = '" & LotCode & "' ")
        Query.Append("order by ")
        Query.Append("   [A].updated_date desc ")
        'get seller details onclick

        'variable
        Dim LotHistoryDtl As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim DateTime As String = DR("Date") & " | " & DR("Time")

                    LotHistoryDtl.Add(New With {
                        .Desc = DR("Desc"),
                        .Employee = DR("Employee"),
                        .Remarks = DR("Remarks"),
                        .DateTime = DateTime
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(LotHistoryDtl))
        'display 

    End Function

#End Region

#Region "SLS050000"

    Function bindRvtDetail(Project)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,dbo.ProperCase([A].AcctName) [Buyer] ")
        Query.Append("   ,[D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[E].ModelName [Unit] ")
        Query.Append("   ,[B].Sellingprice [TCP] ")
        Query.Append("   ,isnull([C].AgentCode, '') [AgentCode] ")
        Query.Append("   ,case when [C].SellerName IS NOT NULL then dbo.ProperCase([C].SellerName) when [C].SellerName <> '' then dbo.ProperCase([C].SellerName) else '-' end [Seller] ")
        Query.Append("   ,(case when [B].RFDate is null then '-' else CONVERT (varchar, [B].RFDate, 107) end) [RsvDate] ")
        Query.Append("   ,(case when [B].RFDate is null then '-' else RIGHT(CONVERT(varchar, [B].RFDate, 100), 7) end) [RsvTime] ")
        Query.Append("   ,[F].SchemeDesc [FinancingScheme] ")
        Query.Append("   ,[B].PmtTerm ")
        Query.Append("   ,'Reserved' [Status] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [C] on [C].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [D] on [D].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [E] on [E].ModelCode = [A].ModelCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_FinancingScheme [F] on [F].SchemeCode = [B].FinancingScheme ")
        Query.Append("where ")
        Query.Append("   [D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot = '" & Project & "' ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and YEAR([B].RFDate) = YEAR(GETDATE()) ")
        'get seller details onclick

        'variable
        Dim RsvDetail As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(4), "N2")
                    Dim ReservationDate As String = DR.GetString(7) & " | " & DR.GetString(8)

                    RsvDetail.Add(New With {
                        .Seller = DR("Seller"),
                        .Buyer = DR("Buyer"),
                        .Project = DR("Project"),
                        .Unit = DR("Unit"),
                        .TCP = TCP,
                        .RsvDate = ReservationDate,
                        .FinancingScheme = DR("FinancingScheme"),
                        .Status = DR("Status"),
                        .PmtTerm = DR("PmtTerm")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RsvDetail))
        'display 

    End Function

    Function bindBkDetail(Project)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,dbo.ProperCase([A].AcctName) [Buyer] ")
        Query.Append("   ,[D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[E].ModelName [Unit] ")
        Query.Append("   ,[B].Sellingprice [TCP] ")
        Query.Append("   ,isnull([C].AgentCode, '') [AgentCode] ")
        Query.Append("   ,case when [C].SellerName IS NOT NULL then dbo.ProperCase([C].SellerName) when [C].SellerName <> '' then dbo.ProperCase([C].SellerName) else '-' end [Seller] ")
        Query.Append("   ,(case when [B].DatePosted is null then '-' else CONVERT (varchar, [B].DatePosted, 107) end) [BkDate] ")
        Query.Append("   ,(case when [B].DatePosted is null then '-' else RIGHT(CONVERT(varchar, [B].DatePosted, 100), 7) end) [BkTime] ")
        Query.Append("   ,[F].SchemeDesc [FinancingScheme] ")
        Query.Append("   ,[B].PmtTerm ")
        Query.Append("   ,'Booked' [Status] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [C] on [C].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [D] on [D].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [E] on [E].ModelCode = [A].ModelCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_FinancingScheme [F] on [F].SchemeCode = [B].FinancingScheme ")
        Query.Append("where ")
        Query.Append("   [D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot = '" & Project & "' ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [B].Posted = 1 ")
        Query.Append("   and YEAR([B].RFDate) = YEAR(GETDATE()) ")
        'get seller details onclick

        'variable
        Dim BkDetail As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(4), "N2")
                    Dim BookedDate As String = DR.GetString(7) & " | " & DR.GetString(8)

                    BkDetail.Add(New With {
                        .Seller1 = DR("Seller"),
                        .Buyer1 = DR("Buyer"),
                        .Project1 = DR("Project"),
                        .Unit1 = DR("Unit"),
                        .TCP1 = TCP,
                        .BkDate = BookedDate,
                        .FinancingScheme1 = DR("FinancingScheme"),
                        .Status1 = DR("Status"),
                        .PmtTerm1 = DR("PmtTerm")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(BkDetail))
        'display 

    End Function

#End Region

#Region "SLS060000"

    Function bindGrpSlsRsv(RsvGrp)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,dbo.ProperCase([A].AcctName) [Buyer] ")
        Query.Append("   ,[D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[E].ModelName [Unit] ")
        Query.Append("   ,[B].Sellingprice [TCP] ")
        Query.Append("   ,isnull([C].AgentCode, '') [AgentCode] ")
        Query.Append("   ,case when [C].SellerName IS NOT NULL then dbo.ProperCase([C].SellerName) when [C].SellerName <> '' then dbo.ProperCase([C].SellerName) else '-' end [Seller] ")
        Query.Append("   ,[F].SellerGrpDesc [Group] ")
        Query.Append("   ,'Reserved' [Status] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [C] on [C].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [D] on [D].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [E] on [E].ModelCode = [A].ModelCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [F] on [F].SellerGrpCode = [C].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("   [F].SellerGrpDesc = '" & RsvGrp & "' ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("   and [C].AgentCode IS NOT NULL ")
        Query.Append("order by ")
        Query.Append("   [B].Sellingprice desc  ")
        'get seller details onclick

        'variable
        Dim GrpSlsRsv As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(4), "N2")

                    GrpSlsRsv.Add(New With {
                        .Seller = DR("Seller"),
                        .Group = DR("Group"),
                        .Buyer = DR("Buyer"),
                        .Project = DR("Project"),
                        .Unit = DR("Unit"),
                        .TCP = TCP,
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(GrpSlsRsv))
        'display 

    End Function

    Function bindGrpSlsBk(BkGrp)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,dbo.ProperCase([A].AcctName) [Buyer] ")
        Query.Append("   ,[D].ProjInit + ' ' + [A].phase + ' ' + [A].Block + ' ' + [A].Lot [Project] ")
        Query.Append("   ,[E].ModelName [Unit] ")
        Query.Append("   ,[B].Sellingprice [TCP] ")
        Query.Append("   ,isnull([C].AgentCode, '') [AgentCode] ")
        Query.Append("   ,case when [C].SellerName IS NOT NULL then dbo.ProperCase([C].SellerName) when [C].SellerName <> '' then dbo.ProperCase([C].SellerName) else '-' end [Seller] ")
        Query.Append("   ,[F].SellerGrpDesc [Group] ")
        Query.Append("   ,'Reserved' [Status] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [C] on [C].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [D] on [D].ProjCode = [A].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [E] on [E].ModelCode = [A].ModelCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [F] on [F].SellerGrpCode = [C].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("   [F].SellerGrpDesc = '" & BkGrp & "' ")
        Query.Append("   and [A].Active = 1 ")
        Query.Append("   and [A].Posted = 1 ")
        Query.Append("   and [B].Posted = 1 ")
        Query.Append("   and YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("   and [C].AgentCode IS NOT NULL ")
        Query.Append("order by ")
        Query.Append("   [B].Sellingprice desc  ")
        'get seller details onclick

        'variable
        Dim GrpSlsBk As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim TCP As String = "₱ " & Format(DR.GetDecimal(4), "N2")

                    GrpSlsBk.Add(New With {
                        .Seller = DR("Seller"),
                        .Group = DR("Group"),
                        .Buyer = DR("Buyer"),
                        .Project = DR("Project"),
                        .Unit = DR("Unit"),
                        .TCP = TCP,
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(GrpSlsBk))
        'display 

    End Function

    Function bindGrpSlsChart(selectedMonth)

        'get seller details onclick
        Dim Query As New StringBuilder
        Query.Append("WITH Month AS ( ")
        Query.Append("  SELECT 1 AS MonthNumber, 'Jan' AS MonthName UNION ALL ")
        Query.Append("  SELECT 2, 'Feb' UNION ALL  ")
        Query.Append("  SELECT 3, 'Mar' UNION ALL ")
        Query.Append("  SELECT 4, 'Apr' UNION ALL  ")
        Query.Append("  SELECT 5, 'May' UNION ALL  ")
        Query.Append("  SELECT 6, 'Jun' UNION ALL ")
        Query.Append("  SELECT 7, 'Jul' UNION ALL  ")
        Query.Append("  SELECT 8, 'Aug' UNION ALL ")
        Query.Append("  SELECT 9, 'Sep' UNION ALL  ")
        Query.Append("  SELECT 10, 'Oct' UNION ALL  ")
        Query.Append("  SELECT 11, 'Nov' UNION ALL ")
        Query.Append("  SELECT 12, 'Dec' )  ")
        Query.Append("select  ")
        Query.Append("  [M].MonthNumber  ")
        Query.Append("  ,[M].MonthName ")
        Query.Append("  ,isnull(sum([ReservedAmount]), 0) [ReservationSales] ")
        Query.Append("  ,[Group] ")
        Query.Append("from  ")
        Query.Append("  Month [M]  ")
        Query.Append("left join ")
        Query.Append("   (select ")
        Query.Append("      MONTH([B].RFDate) [ReservedMonth] ")
        Query.Append("      ,[B].SellingPrice [ReservedAmount] ")
        Query.Append("      ,[E].SellerGrpDesc [Group] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.ICR_Buyers [A]  ")
        Query.Append("      left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo  ")
        Query.Append("      left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [A].SellerCode  ")
        Query.Append("      left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode  ")
        Query.Append("  where ")
        Query.Append("      YEAR([B].RFDate) = YEAR(GETDATE()) ")
        Query.Append("      and [A].Active = 1   ")
        Query.Append("      and [A].Posted = 1 ")
        Query.Append("      and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("  group by ")
        Query.Append("      [B].RFDate ")
        Query.Append("      ,[B].AcctNo ")
        Query.Append("      ,[B].Sellingprice ")
        Query.Append("      ,[E].SellerGrpDesc) [Reserved] ON [Reserved].[ReservedMonth] = [M].MonthNumber ")
        Query.Append("where ")
        Query.Append("  [M].MonthNumber = '" & selectedMonth & "' ")
        Query.Append("group by ")
        Query.Append("  [M].MonthNumber ")
        Query.Append("  ,[M].MonthName  ")
        Query.Append("  ,[Group] ")
        Query.Append("order by ")
        Query.Append("  [ReservationSales] desc ")
        'get seller details onclick

        'variable
        Dim GrpSlsChart As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Group As String
                    Dim Rsrv
                    If Group = "" Then
                        Rsrv = DR("ReservationSales")
                        Group = DR("Group")
                    Else
                        Rsrv = Rsrv & "," & DR("ReservationSales")
                        Group = Group & "," & DR("Group")
                    End If
                    GrpSlsChart.Add(New With {
                        .Group = Group,
                        .ReservationSales = Rsrv
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(GrpSlsChart))
        'display 

    End Function

    'Function bindSLTypeRank(SLType)

    '    'get seller details onclick
    '    Dim Query As New StringBuilder
    '    Query.Append("select")
    '    Query.Append("   isnull([D].AgentCode, '-') [AgentCode]  ")
    '    Query.Append("   ,dbo.ProperCase([F].fullname) [Agent] ")
    '    Query.Append("   ,SUM([B].Sellingprice) [TotalSales] ")
    '    Query.Append("   ,ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) [Rank] ")
    '    Query.Append("   ,[E].SellerGrpDesc [Group] ")
    '    Query.Append("from ")
    '    Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
    '    Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
    '    Query.Append("   left join calmardbLive.dbo.ICR_Sellers [C] on [C].AcctNo = [A].AcctNo ")
    '    Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [C].SellerCode ")
    '    Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
    '    Query.Append("   left join agent [F] on [F].agent_code = [D].AgentCode ")
    '    Query.Append("   left join calmardbLive.dbo.mstr_SellerTypes [G] on [G].SellerTypeCode = [D].SellerType ")
    '    Query.Append("where ")
    '    Query.Append("   YEAR([B].RFDate) = YEAR(GETDATE()) ")
    '    Query.Append("   and [A].Active = 1 ")
    '    Query.Append("   and [A].Posted = 1 ")
    '    Query.Append("   and [D].AgentCode IS NOT NULL ")
    '    Query.Append("   and [G].SellerTypeCode = '" & SLType & "' ")
    '    Query.Append("group by ")
    '    Query.Append("   [D].AgentCode ")
    '    Query.Append("   ,[F].fullname ")
    '    Query.Append("   ,[E].SellerGrpDesc ")
    '    Query.Append("order by ")
    '    Query.Append("   [TotalSales] desc ")
    '    'get seller details onclick

    '    'variable
    '    Dim SLTypeRankList As New List(Of Object)()
    '    'variable

    '    'read record
    '    Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
    '        Using Cmd As New SqlCommand(Query.ToString)
    '            Cmd.CommandType = CommandType.Text
    '            Cmd.Connection = ConStr
    '            ConStr.Open()
    '            Dim DR As SqlDataReader = Cmd.ExecuteReader
    '            While DR.Read()
    '                Dim SlrImg As String
    '                If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png")) = True Then
    '                    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".png"
    '                ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg")) = True Then
    '                    SlrImg = "Assets/Upload/sellers/" & DR.GetString(0) & "/Profile/" & DR.GetString(0) & ".jpg"
    '                Else
    '                    SlrImg = "Assets/media/avatars/blank.png"
    '                End If
    '                Dim TCP As String = "₱ " & Format(DR.GetDecimal(2), "N2")

    '                SLTypeRankList.Add(New With {
    '                    .SlrImg = SlrImg,
    '                    .Seller = DR("Agent"),
    '                    .TotalSales = TCP,
    '                    .Link = DR("AgentCode"),
    '                    .Rank = DR("Rank"),
    '                    .Group = DR("Group")
    '                })
    '            End While
    '            DR.Close()
    '            ConStr.Close()
    '        End Using
    '    End Using
    '    'read record

    '    'display 
    '    Return (New JavaScriptSerializer().Serialize(SLTypeRankList))
    '    'display 

    'End Function

#End Region


End Class