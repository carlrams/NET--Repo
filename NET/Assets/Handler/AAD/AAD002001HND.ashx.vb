Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class AAD002001HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = ""
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
            Dim pFormCode = context.Request("pFormCode")
            Dim pFunction = context.Request("pFunction")
            'general parameter

            If pFunction = "Get-Info-02" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_02(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Info-0301" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_0301(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Info-0302" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_0302(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-0303" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_0303(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-0304" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_0304(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-0305" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_0305(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-0306" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_0306(pID)
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

    Function Get_Info_02(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctName [Title] ")
        Query.Append("   ,calmardblive.dbo.Get_AcctStatus([A].AcctNo) [RecordStatus] ")
        Query.Append("   ,[A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + calmardblive.dbo.Get_LotPackageDesc([A].LotCode) + ' / ' + format(calmardblive.dbo.Get_LotPackageArea([A].LotCode),'N2') + ' sqm' [Project] ")
        Query.Append("   ,[C].ModelName + ' / ' + (case when [A].HouseSpec is null then '' when [A].HouseSpec = '' then '' else [A].HouseSpec + ' / ' end) + format([D].HCRate,'N2') + '%' [ModelName] ")
        Query.Append("   ,calmardblive.dbo.Get_AcctStatus([A].AcctNo) [Status] ")
        Query.Append("   ,format(calmardblive.dbo.Get_ICR_Balance([A].AcctNo),'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [C] on [A].ModelCode = [C].ModelCode ")
        Query.Append("   left join calmardblive.dbo.mstr_LotsInventory [D] on [A].LotCode = [D].LotCode  ")
        Query.Append("where ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Title = DR("Title"),
                        .RecordStatus = DR("RecordStatus"),
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .Balance = DR("Balance")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Get_Info_0301(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [E].ContractTypeName ")
        Query.Append("   ,[A].DateEntered ")
        Query.Append("   ,[A].AcctName [FullName] ")
        Query.Append("   ,[A].LastName ")
        Query.Append("   ,[A].FirstName ")
        Query.Append("   ,[A].MiddleName ")
        Query.Append("   ,[A].Suffix ")
        Query.Append("   ,[A].HomeAddress ")
        Query.Append("   ,[H].CountryName [HomeCountryName] ")
        Query.Append("   ,[I].CityName [HomeCityName] ")
        Query.Append("   ,[A].HomeTownPlace ")
        Query.Append("   ,[A].HomeTownCode ")
        Query.Append("   ,[A].YearsofStay ")
        Query.Append("   ,[J].Description [OwnershipName] ")
        Query.Append("   ,[A].Emailaddress ")
        Query.Append("   ,[A].MobileNo ")
        Query.Append("   ,format([A].BirthDate,'MM/dd/yyyy') [BirthDate] ")
        Query.Append("   ,(case [A].Gender when 'M' then 'Male' when 'F' then 'Female' else '' end) [GenderName] ")
        Query.Append("   ,[K].Description [CitizenshipName] ")
        Query.Append("   ,(case [A].CivilStatus when 'S' then 'Single' when 'M' then 'Married' when 'W' then 'Widowed' when 'L' then 'Legally Separated' when 'D' then 'Divorced' when 'A' then 'Anulled' else '' end) [CivilStatusName] ")
        Query.Append("   ,[A].TIN ")
        Query.Append("   ,[A].SSS ")
        Query.Append("   ,[A].UMID ")
        Query.Append("   ,[A].Employer ")
        Query.Append("   ,[A].EmployerAddress ")
        Query.Append("   ,[L].CountryName [EmpCountryName] ")
        Query.Append("   ,[M].CityName [EmpCityName] ")
        Query.Append("   ,[A].EmpTownPlace ")
        Query.Append("   ,[A].EmpTownCode ")
        Query.Append("   ,[A].WorkYears ")
        Query.Append("   ,[A].Position ")
        Query.Append("   ,[N].Description [EmploymentTypeName] ")
        Query.Append("   ,[A].MailingAddress ")
        Query.Append("   ,[O].CountryName [MailingCountryCodeName] ")
        Query.Append("   ,[P].CityName [MailingCityName] ")
        Query.Append("   ,[A].MailingTownPlace ")
        Query.Append("   ,[A].MailingTownCode ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_ContractTypes [E] on [A].ContractType = [E].ContractTypeCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Countries [H] on [A].HomeCountryCode = [H].CountryCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Cities [I] on [A].HomeCountryCode = [I].CountryCode and [A].HomeCityCode = [I].CityCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HomeOwnerShip [J] on [A].Ownership = [J].Code ")
        Query.Append("   left join calmardblive.dbo.mstr_Citizenship [K] on [A].Citizenship = [K].Code ")
        Query.Append("   left join calmardblive.dbo.mstr_Countries [L] on [A].EmpCountryCode = [L].CountryCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Cities [M] on [A].EmpCountryCode = [M].CountryCode and [A].EmpCityCode = [M].CityCode ")
        Query.Append("   left join calmardblive.dbo.mstr_EmploymentType [N] on [A].EmploymentType = [N].Code ")
        Query.Append("   left join calmardblive.dbo.mstr_Countries [O] on [A].MailingCountryCode = [O].CountryCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Cities [P] on [A].MailingCountryCode = [P].CountryCode and [A].MailingCityCode = [P].CityCode ")
        Query.Append("where ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .ContractTypeName = DR("ContractTypeName"),
                        .DateEntered = DR("DateEntered"),
                        .FullName = DR("FullName"),
                        .LastName = DR("LastName"),
                        .FirstName = DR("FirstName"),
                        .MiddleName = DR("MiddleName"),
                        .Suffix = DR("Suffix"),
                        .HomeAddress = DR("HomeAddress"),
                        .HomeCountryName = DR("HomeCountryName"),
                        .HomeCityName = DR("HomeCityName"),
                        .HomeTownPlace = DR("HomeTownPlace"),
                        .HomeTownCode = DR("HomeTownCode"),
                        .YearsofStay = DR("YearsofStay"),
                        .OwnershipName = DR("OwnershipName"),
                        .Emailaddress = DR("Emailaddress"),
                        .MobileNo = DR("MobileNo"),
                        .BirthDate = DR("BirthDate"),
                        .GenderName = DR("GenderName"),
                        .CitizenshipName = DR("CitizenshipName"),
                        .CivilStatusName = DR("CivilStatusName"),
                        .TIN = DR("TIN"),
                        .SSS = DR("SSS"),
                        .UMID = DR("UMID"),
                        .Employer = DR("Employer"),
                        .EmployerAddress = DR("EmployerAddress"),
                        .EmpCountryName = DR("EmpCountryName"),
                        .EmpCityName = DR("EmpCityName"),
                        .EmpTownPlace = DR("EmpTownPlace"),
                        .EmpTownCode = DR("EmpTownCode"),
                        .WorkYears = DR("WorkYears"),
                        .Position = DR("Position"),
                        .EmploymentTypeName = DR("EmploymentTypeName"),
                        .MailingAddress = DR("MailingAddress"),
                        .MailingCountryCodeName = DR("MailingCountryCodeName"),
                        .MailingCityName = DR("MailingCityName"),
                        .MailingTownPlace = DR("MailingTownPlace"),
                        .MailingTownCode = DR("MailingTownCode")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Get_Info_0302(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   'ICR' + [A].AcctCode [AcctCode] ")
        Query.Append("   ,[Q].SellerName [SellerCodeName] ")
        Query.Append("   ,format([R].RFDate,'MM/dd/yyyy') [RFDate] ")
        Query.Append("   ,[S].SchemeDesc [FinancingSchemeName] ")
        Query.Append("   ,[R].PmtTerm ")
        Query.Append("   ,format([R].Sellingprice,'N2') [Sellingprice] ")
        Query.Append("   ,format([R].TCPDiscount,'N2') [TCPDiscount] ")
        Query.Append("   ,format([R].VATDiscAmt,'N2') [VATDiscAmt] ")
        Query.Append("   ,format([R].Sellingprice - ([R].TCPDiscount + isnull([R].VATDiscAmt,0)),'N2') [TCP] ")
        Query.Append("   ,format([R].VATAmount,'N2') [VATAmount] ")
        Query.Append("   ,format(([R].Sellingprice - [R].TCPDiscount) + ([R].VATAmount - ISNULL([R].VATDiscAmt,0)),'N2') [TCPNet] ")
        Query.Append("   ,format([R].DPAmount,'N2') [DPAmount] ")
        Query.Append("   ,format([R].PromoDPDiscount,'N2') [PromoDPDiscount] ")
        Query.Append("   ,format([R].RFAmount,'N2') [RFAmount] ")
        Query.Append("   ,[R].DPTerms ")
        Query.Append("   ,format(cast((case when [R].DPTerms = 0 then 0 else ([R].DPAmount - [R].RFAmount - [R].PromoDPDiscount) / [R].DPTerms end) as decimal(21,2)),'N2') [MoDP] ")
        Query.Append("   ,format([R].FirstDPDue,'MM/dd/yyyy') [FirstDPDue] ")
        Query.Append("   ,format([R].ExternalLoan,'N2') [ExternalLoan] ")
        Query.Append("   ,format((case when [R].FinancingScheme in (10,3) then 0.00 else [R].InterestRate end),'N2') [InterestRate] ")
        Query.Append("   ,(case when [R].FinancingScheme in (10,3) then 1 else [R].MATerms end) [MATerms] ")
        Query.Append("   ,format((case when [R].FinancingScheme in (10,3) then [R].ExternalLoan else [R].MAAmt end),'N2') [MAAmt] ")
        Query.Append("   ,format((case when [R].FinancingScheme in (10,3) then dateadd(month,[R].DPTerms + 2,[R].FirstDPDue) else [R].FirstMADue end),'MM/dd/yyyy') [FirstMADue] ")
        Query.Append("   ,[R].Remarks ")
        Query.Append("   ,Format([R].SalesProductionValueDate,'MMMM yyyy') [SalesProductionValueDate] ")
        Query.Append("   ,Format(isnull([R].Cost,0),'N2') [Cost] ")
        Query.Append("   ,Format([R].CommTCDiscAmt,'N2') [CommTCDiscAmt] ")
        Query.Append("   ,Format([R].CommTCVarDiscAmt,'N2') [CommTCVarDiscAmt] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Sellers [Q] on [A].SellerCode = [Q].SellerCode ")
        Query.Append("   left join calmardblive.dbo.ICR_Reservations [R] on [A].AcctNo = [R].AcctNo ")
        Query.Append("   left join calmardblive.dbo.mstr_FinancingScheme [S] on [R].FinancingScheme = [S].SchemeCode ")
        Query.Append("where ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .AcctCode = DR("AcctCode"),
                        .SellerCodeName = DR("SellerCodeName"),
                        .RFDate = DR("RFDate"),
                        .FinancingSchemeName = DR("FinancingSchemeName"),
                        .PmtTerm = DR("PmtTerm"),
                        .Sellingprice = DR("Sellingprice"),
                        .TCPDiscount = DR("TCPDiscount"),
                        .VATDiscAmt = DR("VATDiscAmt"),
                        .TCP = DR("TCP"),
                        .VATAmount = DR("VATAmount"),
                        .TCPNet = DR("TCPNet"),
                        .DPAmount = DR("DPAmount"),
                        .PromoDPDiscount = DR("PromoDPDiscount"),
                        .RFAmount = DR("RFAmount"),
                        .DPTerms = DR("DPTerms"),
                        .MoDP = DR("MoDP"),
                        .FirstDPDue = DR("FirstDPDue"),
                        .ExternalLoan = DR("ExternalLoan"),
                        .InterestRate = DR("InterestRate"),
                        .MATerms = DR("MATerms"),
                        .MAAmt = DR("MAAmt"),
                        .FirstMADue = DR("FirstMADue"),
                        .Remarks = DR("Remarks"),
                        .SalesProductionValueDate = DR("SalesProductionValueDate"),
                        .Cost = DR("Cost"),
                        .CommTCDiscAmt = DR("CommTCDiscAmt"),
                        .CommTCVarDiscAmt = DR("CommTCVarDiscAmt")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Get_Record_0303(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (case when [A].StatusCode in (select [B].StatusCode from calmardblive.dbo.ICR_Status [B] where [B].AcctNo = '" & pID & "' and [B].StatusCode = [A].StatusCode and [B].Active = 1) then 1 else 0 end) [Check] ")
        Query.Append("   ,(case [A].MotherCode when 332 then 'Overdue' when 219 then 'Reservation' when 289 then 'Credit Investigation' when 191 then 'Booking' when 290 then 'Legal Documents' when 223 then 'Modification' when 181 then 'Billing Section' when 63 then 'Loan Section' when 312 then 'Compliance and Loan Filing' when 310 then 'Approvals & Loan Take-Out' when 354 then 'Loan Section - Commission Related Tagging' when 358 then 'Documentation & Compliance' else '' end) [Group] ")
        Query.Append("   ,[A].StatusDescription [Status] ")
        Query.Append("   ,(select top 1 format([B].DateAcquired,'MM/dd/yy hh:mm tt') from calmardblive.dbo.ICR_Status [B] where [B].AcctNo = '" & pID & "' and [B].StatusCode = [A].StatusCode and [B].Active = 1) [Date] ")
        Query.Append("   ,(select top 1 [B].Remarks from calmardblive.dbo.ICR_Status [B] where [B].AcctNo = '" & pID & "' and [B].StatusCode = [A].StatusCode and [B].Active = 1) [Remarks] ")
        Query.Append("   ,(select top 1 [B].AuditUser from calmardblive.dbo.ICR_Status [B] where [B].AcctNo = '" & pID & "' and [B].StatusCode = [A].StatusCode and [B].Active = 1) [UpdatedByName] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.mstr_StatusCodes [A] ")
        Query.Append("where ")
        Query.Append("   [A].MotherCode IN (332,219, 289, 191, 290, 223, 181, 63,312,310,354,358) ")
        Query.Append("ORDER BY ")
        Query.Append("   (CASE [A].MotherCode WHEN 332 THEN 0 WHEN 219 THEN 1 WHEN 289 THEN 2 WHEN 191 THEN 3 WHEN 290 THEN 4 WHEN  358 THEN 5 WHEN 223 THEN 6 WHEN 181 THEN 7 WHEN 63 THEN 8 WHEN 354 THEN 9 WHEN 312 THEN 10 WHEN 310 THEN 11 END) ")
        Query.Append("   ,[A].SeqNo ")
        Query.Append("   ,[A].StatusDescription ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Check = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Check") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Group = "<span title='" & DR("Group") & "'>" & DR("Group") & "</span>",
                        .Status = "<span title='" & DR("Status") & "'>" & DR("Status") & "</span>",
                        .Date = DR("Date"),
                        .Remarks = "<span title='" & DR("Remarks") & "'>" & DR("Remarks") & "</span>",
                        .UpdatedByName = "<span title='" & DR("UpdatedByName") & "'>" & DR("UpdatedByName") & "</span>",
                        .Blank = ""
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Get_Record_0304(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("   Rcvd ")
        Query.Append("   ,Type ")
        Query.Append("   ,ReqDesc ")
        Query.Append("   ,DocNo ")
        Query.Append("   ,format(DocDate,'MM/dd/yyyy') [DocDate] ")
        Query.Append("   ,format(ExpDate,'MM/dd/yyyy') [ExpDate] ")
        Query.Append("   ,Remarks ")
        Query.Append("   ,ReceivedBy ")
        Query.Append("   ,format(ReceivedDate,'MM/dd/yy hh:mm tt') [ReceivedDate] ")
        Query.Append("FROM ")
        Query.Append("   calmardblive.dbo.JCF_AcctRequirements ")
        Query.Append("WHERE ")
        Query.Append("   AcctNo = '" & pID & "' ")
        Query.Append("ORDER BY ")
        Query.Append("   Code ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Rcvd = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Rcvd") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Type = DR("Type"),
                        .ReqDesc = DR("ReqDesc"),
                        .DocNo = DR("DocNo"),
                        .DocDate = DR("DocDate"),
                        .ExpDate = DR("ExpDate"),
                        .Remarks = DR("Remarks"),
                        .ReceivedBy = DR("ReceivedBy"),
                        .ReceivedDate = DR("ReceivedDate"),
                        .Blank = ""
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Get_Record_0305(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("   (case when [A].AmtPD2Prin >= [A].Principal then 1 else 0 end) [Paid] ")
        Query.Append("   ,ROW_NUMBER() OVER(PARTITION BY [A].TRCode ORDER BY [A].DueDate) [No] ")
        Query.Append("   ,format([A].DueDate,'MM/dd/yyyy') [DueDate] ")
        Query.Append("   ,(case [A].TRCode when 'RF' then 'Reservation Fee' when 'DP' then 'DP - ' + format([A].DueDate,'MMM yyyy') when 'MA' then 'MA - ' + format([A].DueDate,'MMM yyyy') else (case when [A].TRCode = 'LOAN' and isnull([A].IsLoanDiff,0) = 0 then 'Loan' else 'LD - ' + format([A].DueDate,'MMM yyyy') end) end) [Description] ")
        Query.Append("   ,format([A].Principal + [A].Interest,'N2') [Total] ")
        Query.Append("   ,format([A].Interest,'N2') [Interest] ")
        Query.Append("   ,format([A].Principal,'N2') [Principal]  ")
        Query.Append("   ,format((select sum([B].Principal) from calmardblive.dbo.ICR_Ledger [B] where [B].AcctNo = [A].AcctNo) - SUM([A].Principal) OVER(ORDER BY cast([A].link as int),[A].DueDate  ROWS BETWEEN UNBOUNDED PRECEDING And CURRENT ROW),'N2') [Balance] ")
        Query.Append("   ,format([A].AmtPD2Pen,'N2') [AmtPD2Pen]  ")
        Query.Append("   ,format([A].AmtPD2Int,'N2') [AmtPD2Int]  ")
        Query.Append("   ,format([A].AmtPD2Prin,'N2') [AmtPD2Prin]  ")
        Query.Append("   ,format([A].Principal - [A].AmtPD2Prin,'N2') [AmtPD2Bal]  ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Ledger [A] ")
        Query.Append("where ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("   cast([A].link as int) ")
        Query.Append("   ,[A].DueDate ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .Paid = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Paid") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .No = DR("No"),
                        .DueDate = DR("DueDate"),
                        .Description = DR("Description"),
                        .Total = DR("Total"),
                        .Interest = DR("Interest"),
                        .Principal = DR("Principal"),
                        .Balance = DR("Balance"),
                        .AmtPD2Pen = DR("AmtPD2Pen"),
                        .AmtPD2Int = DR("AmtPD2Int"),
                        .AmtPD2Prin = DR("AmtPD2Prin"),
                        .AmtPD2Bal = DR("AmtPD2Bal"),
                        .Blank = ""
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Get_Record_0306(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT distinct ")
        Query.Append("   1 [Group] ")
        Query.Append("   ,1 [No] ")
        Query.Append("   ,'' [DocNo] ")
        Query.Append("   ,format([A].RFDate,'MM/dd/yyyy') [DocDate] ")
        Query.Append("   ,'Beginning Balance' [DocDesc] ")
        Query.Append("   ,'0.00' [Total] ")
        Query.Append("   ,'0.00' [Penalty] ")
        Query.Append("   ,'0.00' [Interest] ")
        Query.Append("   ,'0.00' [Principal] ")
        Query.Append("   ,format(([A].Sellingprice + [A].VATAmount) - ([A].TCPDiscount + [A].VATDiscAmt),'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Reservations [A] ")
        Query.Append("WHERE ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        Query.Append("union SELECT ")
        Query.Append("   2 [Group] ")
        Query.Append("   ,1 [No] ")
        Query.Append("   ,'' [DocNo] ")
        Query.Append("   ,format([A].RFDate,'MM/dd/yyyy') [DocDate] ")
        Query.Append("   ,'Discount on DP' [DocDesc] ")
        Query.Append("   ,'0.00' [Total] ")
        Query.Append("   ,'0.00' [Penalty] ")
        Query.Append("   ,'0.00' [Interest] ")
        Query.Append("   ,format([A].PromoDPDiscount,'N2') [Principal] ")
        Query.Append("   ,'0.00' [Balance] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Reservations [A] ")
        Query.Append("WHERE ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        Query.Append("   and [A].PromoDPDiscount > 0 ")
        Query.Append("union SELECT ")
        Query.Append("   3 [Group] ")
        Query.Append("   ,ROW_NUMBER() OVER(PARTITION BY [A].TRCode ORDER BY isnull([B].DocDate,[A].DatePaid)) [No] ")
        Query.Append("   ,isnull([B].DocNo,'') [DocNo] ")
        Query.Append("   ,format(isnull([B].DocDate,[A].DatePaid),'MM/dd/yyyy') [DocDate] ")
        Query.Append("   ,(case [A].TRCode when 'RF' then 'Reservation Fee' when 'DP' then 'DP - ' + format([A].DueDate,'MMM yyyy') when 'MA' then 'MA - ' + format([A].DueDate,'MMM yyyy') else (case when [A].TRCode = 'LOAN' and isnull([A].IsLoanDiff,0) = 0 then 'Loan' else 'LD - ' + format([A].DueDate,'MMM yyyy') end) end) [DocDesc] ")
        Query.Append("   ,format(isnull([B].Penalty + [B].Interest + [B].Principal,[A].AmtPD2Pen + [A].AmtPD2Int + [A].AmtPD2Prin),'N2') [Total] ")
        Query.Append("   ,format(isnull([B].Penalty,[A].AmtPD2Pen),'N2') [Penalty] ")
        Query.Append("   ,format(isnull([B].Interest,[A].AmtPD2Int),'N2') [Interest] ")
        Query.Append("   ,format(isnull([B].Principal,[A].AmtPD2Prin),'N2') [Principal] ")
        Query.Append("   ,'0.00' [Balance] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Ledger [A] ")
        Query.Append("   left join calmardblive.dbo.ICR_PaymentDetails [B] on [A].AcctNo = [B].AcctNo and [A].TRCode = [B].TRCode and [A].Link = [B].Link ")
        Query.Append("WHERE ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        Query.Append("   and ([A].AmtPD2Pen + [A].AmtPD2Int + [A].AmtPD2Prin != 0 or [B].Penalty + [B].Interest + [B].Principal != 0) ")
        Query.Append("union SELECT ")
        Query.Append("   3 [Group] ")
        Query.Append("   ,ROW_NUMBER() OVER(PARTITION BY [A].TRCode ORDER BY [A].DueDate) [No] ")
        Query.Append("   ,'No Data' [DocNo] ")
        Query.Append("   ,format([A].DatePaid,'MM/dd/yyyy') [DocDate] ")
        Query.Append("   ,(case [A].TRCode when 'RF' then 'Reservation Fee' when 'DP' then 'DP - ' + format([A].DueDate,'MMM yyyy') when 'MA' then 'MA - ' + format([A].DueDate,'MMM yyyy') else (case when [A].TRCode = 'LOAN' and isnull([A].IsLoanDiff,0) = 0 then 'Loan' else 'LD - ' + format([A].DueDate,'MMM yyyy') end) end) [DocDesc] ")
        Query.Append("   ,format([A].AmtPd2Pen + [A].AmtPd2Int + [A].AmtPd2Prin - (select SUM([B].Penalty + [B].Interest + [B].Principal) from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = '" & pID & "' and [B].TRCode = [A].TRCode and [B].Link = [A].Link),'N2') [Total] ")
        Query.Append("   ,format([A].AmtPd2Pen - (select SUM([B].Penalty) from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = '" & pID & "' and [B].TRCode = [A].TRCode and [B].Link = [A].Link),'N2') [Penalty] ")
        Query.Append("   ,format([A].AmtPd2Int - (select SUM([B].Interest) from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = '" & pID & "' and [B].TRCode = [A].TRCode and [B].Link = [A].Link),'N2') [Interest] ")
        Query.Append("   ,format([A].AmtPd2Prin - (select SUM([B].Principal) from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = '" & pID & "' and [B].TRCode = [A].TRCode and [B].Link = [A].Link),'N2') [Principal] ")
        Query.Append("   ,'0.00' [Balance] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Ledger [A] ")
        Query.Append("WHERE ")
        Query.Append("   [A].AcctNo = '" & pID & "' ")
        Query.Append("   and [A].AmtPd2Prin > (select SUM([B].Principal) from calmardblive.dbo.ICR_PaymentDetails [B] where [B].AcctNo = '" & pID & "' and [B].TRCode = [A].TRCode and [B].Link = [A].Link) ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .No = DR("No"),
                        .DocNo = DR("DocNo"),
                        .DocDate = DR("DocDate"),
                        .DocDesc = DR("DocDesc"),
                        .Total = DR("Total"),
                        .Penalty = DR("Penalty"),
                        .Interest = DR("Interest"),
                        .Principal = DR("Principal"),
                        .Balance = DR("Balance"),
                        .Blank = ""
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

End Class