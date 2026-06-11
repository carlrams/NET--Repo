Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.AspNet.SignalR.Hosting

Public Class SLM000011
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "IISV2"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
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

                Dim json As String = Me.bindReservationDetail(SLFCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

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
        Query.Append("   ,isnull([C].SellerGrpDesc, '-') [AgentGroup] ")
        Query.Append("   ,isnull([D].SellerTypeDesc, '-') [AgentType] ")
        Query.Append("   ,(dbo.ProperCase(isnull([A].addr1, '-'))) [AgentAddress] ")
        Query.Append("   ,isnull([A].tin, '-') [AgentTIN] ")
        Query.Append("   ,(dbo.ProperCase(isnull([A].remarks, '-'))) [AgentRemarks] ")
        Query.Append("from ")
        Query.Append("   agent [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [B] on [B].AgentCode = [A].agent_code ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [C] on [C].SellerGrpCode = [B].SellerGrpCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerTypes [D] on [D].SellerTypeCode = [B].SellerType ")
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
                        .AgentGroup = DR("AgentGroup"),
                        .AgentType = DR("AgentType"),
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

#End Region

#Region "SLS020000"

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

                    SellerDetails.Add(New With {
                        .AgentCode = DR("AgentCode"),
                        .FirstName = DR("FirstName"),
                        .MiddleName = DR("MiddleName"),
                        .LastName = DR("LastName"),
                        .Email = DR("Email"),
                        .Type = DR("Type"),
                        .Group = DR("Group"),
                        .Status = DR("Status"),
                        .DateCreated = DR("DateCreated")
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
        Query.Append("from ")
        Query.Append("   slp_user_register [A] ")
        Query.Append("where ")
        Query.Append("   [A].acct_status = 'Approved' ")
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

                    SellerDetails.Add(New With {
                        .RvtAgentCode = DR("RvtAgentCode"),
                        .RvtFirstName = DR("RvtFirstName"),
                        .RvtMiddleName = DR("RvtMiddleName"),
                        .RvtLastName = DR("RvtLastName"),
                        .RvtEmail = DR("RvtEmail"),
                        .RvtType = DR("RvtType"),
                        .RvtGroup = DR("RvtGroup"),
                        .RvtStatus = DR("RvtStatus"),
                        .RvtDateApproved = DR("RvtDateApproved")
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
        Query.Append("  ,(dbo.ProperCase([C].first_name)) + ' ' + (dbo.ProperCase([C].last_name)) [RequestedBy] ")
        Query.Append("  ,[F].SellerTypeDesc [Type] ")
        Query.Append("  ,[E].SellerGrpDesc [Group] ")
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
        Query.Append("  ,[A].downpaymentBPercent [downpaymentBPercent] ")
        Query.Append("  ,[A].downpaymentB [DownpaymentB] ")
        Query.Append("  ,[A].payablewithinB [PayableWithinB] ")
        Query.Append("  ,[A].monthly_equityB [MonthlyEquityB] ")
        Query.Append("  ,[A].loanable_amtPercent [LoanableAmtPercent] ")
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

                    Dim spotDPDiscPercent As Decimal = DR("spotDPDiscPercent") / 100
                    Dim VATPercent As Decimal = DR("VATPercent") / 100
                    Dim downpaymentAPercent As Decimal = DR("downpaymentAPercent") / 100
                    Dim downpaymentBPercent As Decimal = DR("downpaymentBPercent") / 100
                    Dim LoanableAmtPercent As Decimal = DR("LoanableAmtPercent") / 100

                    ReservationDetails.Add(New With {
                        .LotCode = DR("LotCode"),
                        .RequestedBy = DR("RequestedBy"),
                        .Type = DR("Type"),
                        .Group = DR("Group"),
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
                        .DownPaymentBPercent = String.Format("{0:P2}", downpaymentBPercent),
                        .DownPaymentB = String.Format("₱ {0:N2}", DR("DownPaymentB")),
                        .PayableWithinB = DR("PayableWithinB"),
                        .MonthlyEquityB = String.Format("₱ {0:N2}", DR("MonthlyEquityB")),
                        .LoanableAmtPercent = String.Format("{0:P2}", LoanableAmtPercent),
                        .LoanableAmt = String.Format("₱ {0:N2}", DR("LoanableAmt")),
                        .InterestRate = String.Format("{0}%", DR("InterestRate")),
                        .Term = DR("Term"),
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

#End Region


End Class