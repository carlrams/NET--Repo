Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports OfficeOpenXml.ConditionalFormatting.Contracts

Public Class AAD002031HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
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

            ElseIf pFunction = "Get-Info-0201" Then

                Dim pID = context.Request("pID")
                Dim pType = context.Request("pType")
                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Get_Info_0201(pID, pType, pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Info-0202" Then

                Dim pType = context.Request("pType")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Get_Info_0202(pType, pPhase, pBlock, pLot, pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Info-0301" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_0301(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-Record-03" Then

                Dim pAcctNo = context.Request("pAcctno")
                Dim pModelCode = context.Request("pModelCode")
                Dim pHouseSpec = context.Request("pHouseSpec")
                Dim pContractType = context.Request("pContractType")
                Dim pAcctName = context.Request("pAcctName")
                Dim pLastName = context.Request("pLastName")
                Dim pFirstName = context.Request("pFirstName")
                Dim pMiddleName = context.Request("pMiddleName")
                Dim pSuffix = context.Request("pSuffix")
                Dim pHomeAddress = context.Request("pHomeAddress")
                Dim pHomeCountryCode = context.Request("pHomeCountryCode")
                Dim pHomeCityCode = context.Request("pHomeCityCode")
                Dim pHomeTownPlace = context.Request("pHomeTownPlace")
                Dim pHomeTownCode = context.Request("pHomeTownCode")
                Dim pYearsofStay = context.Request("pYearsofStay")
                Dim pOwnership = context.Request("pOwnership")
                Dim pEmailAddress = context.Request("pEmailAddress")
                Dim pMobileNo = context.Request("pMobileNo")
                Dim pBirthDate = context.Request("pBirthDate")
                Dim pGender = context.Request("pGender")
                Dim pCitizenship = context.Request("pCitizenship")
                Dim pCivilStatus = context.Request("pCivilStatus")
                Dim pTIN = context.Request("pTIN")
                Dim pSSS = context.Request("pSSS")
                Dim pUMID = context.Request("pUMID")
                Dim pEmployer = context.Request("pEmployer")
                Dim pEmployerAddress = context.Request("pEmployerAddress")
                Dim pEmpCountryCode = context.Request("pEmpCountryCode")
                Dim pEmpCityCode = context.Request("pEmpCityCode")
                Dim pEmpTownPlace = context.Request("pEmpTownPlace")
                Dim pEmpTownCode = context.Request("pEmpTownCode")
                Dim pWorkYears = context.Request("pWorkYears")
                Dim pPosition = context.Request("pPosition")
                Dim pEmploymentType = context.Request("pEmploymentType")
                Dim pMailingAddress = context.Request("pMailingAddress")
                Dim pMailingCountryCode = context.Request("pMailingCountryCode")
                Dim pMailingCityCode = context.Request("pMailingCityCode")
                Dim pMailingTownPlace = context.Request("pMailingTownPlace")
                Dim pMailingTownCode = context.Request("pMailingTownCode")
                Dim pAuditUser = CIIS_EmpCode

                Dim json As String = Me.Upd_Rec_03(pAcctNo, pModelCode, pHouseSpec, pContractType, pAcctName, pLastName, pFirstName, pMiddleName, pSuffix, pHomeAddress, pHomeCountryCode, pHomeCityCode, pHomeTownPlace, pHomeTownCode, pYearsofStay, pOwnership, pEmailAddress, pMobileNo, pBirthDate, pGender, pCitizenship, pCivilStatus, pTIN, pSSS, pUMID, pEmployer, pEmployerAddress, pEmpCountryCode, pEmpCityCode, pEmpTownPlace, pEmpTownCode, pWorkYears, pPosition, pEmploymentType, pMailingAddress, pMailingCountryCode, pMailingCityCode, pMailingTownPlace, pMailingTownCode, pAuditUser)
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
        Query.Append("   ,[B].ProjInit ")
        Query.Append("   ,[A].Phase ")
        Query.Append("   ,[A].Block ")
        Query.Append("   ,[A].Lot ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + calmardblive.dbo.Get_LotPackageDesc([A].LotCode) + ' / ' + format(calmardblive.dbo.Get_LotPackageArea([A].LotCode),'N2') + ' sqm' [Project] ")
        Query.Append("   ,[C].ModelName + ' / ' + (case when [A].HouseSpec is null then '' when [A].HouseSpec = '' then '' else [A].HouseSpec + ' / ' end) + format([D].HCRate,'N2') + '%' [ModelName] ")
        Query.Append("   ,[A].ModelCode ")
        Query.Append("   ,[A].HouseSpec ")
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
                        .ProjInit = DR("ProjInit"),
                        .Phase = DR("Phase"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .ModelCode = DR("ModelCode"),
                        .HouseSpec = DR("HouseSpec"),
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

    Function Get_Info_0201(pID, pType, pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Mstr_ContractTypes" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   cast([A].ContractTypeCode as nvarchar(13)) [ID] ")
            Query.Append("   ,[A].ContractTypeName [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].ContractTypeName [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.Mstr_ContractTypes [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Citizenship" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   CAST([A].Code as nvarchar) [ID] ")
            Query.Append("   ,[A].Description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Description [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.Mstr_Citizenship [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Countries" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   cast(CountryCode as nvarchar(13)) [ID] ")
            Query.Append("   ,[A].CountryName [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].CountryName [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.Mstr_Countries [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Cities" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   cast(CityCode as nvarchar(13)) [ID] ")
            Query.Append("   ,[A].CityName [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].CityName [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.Mstr_Cities [A] ")
            Query.Append("where ")
            Query.Append("  [A].CountryCode = '" & pID & "' ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_ZipCodes" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   cast(ZipCode as nvarchar(13)) [ID] ")
            Query.Append("   ,[A].Place [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Place [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.Mstr_ZipCodes [A] ")
            Query.Append("where ")
            Query.Append("  [A].CountryCode = '" & pType & "' ")
            Query.Append("  and [A].CityCode = '" & pID & "' ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_HomeOwnership" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   CAST([A].Code AS NVARCHAR) [ID] ")
            Query.Append("   ,[A].Description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Description [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.Mstr_HomeOwnership [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_EmploymentType" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   cast(Code as nvarchar(13)) [ID] ")
            Query.Append("   ,[A].Description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Description [Order2] ")
            Query.Append("from ")
            Query.Append("   calmardbLive.dbo.Mstr_EmploymentType [A] ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        End If
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
                        .ID = DR("ID"),
                        .Name = DR("Name")
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
    Function Get_Info_0202(pType, pPhase, pBlock, pLot, pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "mstr_HouseModels(LotFit)" Then
            If pType = "TML" Or pType = "CG" Or pType = "COH" Or pType = "TV" Or pType = "LCR" Or pType = "SOR" Or pType = "CBH" Or pType = "IL" Or pType = "PROP" Or pType = "NEV" Or pType = "PRIS" Or pType = "PS" Or pType = "BW" Or pType = "LRT" Or pType = "SBW" Then
                Query.Append("select ")
                Query.Append("   '' [ID] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
                Query.Append("   ,0 [Order1] ")
                Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("   CAST([A].ModelCode AS NVARCHAR) [ID] ")
                Query.Append("   ,[C].ModelName [Name] ")
                Query.Append("   ,2 [Order1] ")
                Query.Append("   ,[C].ModelName [Order2] ")
                Query.Append("from ")
                Query.Append("   calmardbLive.dbo.mstr_housefit [A] ")
                Query.Append("   left join calmardbLive.dbo.mstr_projects [B] on [A].ProjCode = [B].ProjCode ")
                Query.Append("   left join calmardbLive.dbo.mstr_housemodels [C] on [A].ModelCode = [C].ModelCode ")
                Query.Append("where ")
                Query.Append("  [B].ProjInit = '" & pType & "' ")
                Query.Append("  And [A].Phase = '" & pPhase & "' ")
                Query.Append("  And [A].Block = '" & pBlock & "' ")
                Query.Append("  And [A].Lot = '" & pLot & "' ")
                Query.Append("  And [A].Active = 1 ")
                Query.Append("order by ")
                Query.Append("   [Order1] ")
                Query.Append("   ,[Order2] ")
            End If
        End If
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
                        .ID = DR("ID"),
                        .Name = DR("Name")
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
        Query.Append("   ,[A].ContractType ")
        Query.Append("   ,[A].DateEntered ")
        Query.Append("   ,[A].AcctName [FullName] ")
        Query.Append("   ,[A].LastName ")
        Query.Append("   ,[A].FirstName ")
        Query.Append("   ,[A].MiddleName ")
        Query.Append("   ,[A].Suffix ")
        Query.Append("   ,[A].HomeAddress ")
        Query.Append("   ,[H].CountryName [HomeCountryName] ")
        Query.Append("   ,[A].HomeCountryCode ")
        Query.Append("   ,[A].HomeCountryCode ")
        Query.Append("   ,[I].CityName [HomeCityName] ")
        Query.Append("   ,[A].HomeCityCode ")
        Query.Append("   ,[A].HomeTownPlace ")
        Query.Append("   ,[A].HomeTownCode ")
        Query.Append("   ,[A].YearsofStay ")
        Query.Append("   ,[J].Description [OwnershipName] ")
        Query.Append("   ,[A].Ownership ")
        Query.Append("   ,[A].Emailaddress ")
        Query.Append("   ,[A].MobileNo ")
        Query.Append("   ,format([A].BirthDate,'MM/dd/yyyy') [BirthDate] ")
        Query.Append("   ,(case [A].Gender when 'M' then 'Male' when 'F' then 'Female' else '' end) [GenderName] ")
        Query.Append("   ,[A].Gender ")
        Query.Append("   ,[K].Description [CitizenshipName] ")
        Query.Append("   ,[A].Citizenship [CitizenshipCode] ")
        Query.Append("   ,(case [A].CivilStatus when 'S' then 'Single' when 'M' then 'Married' when 'W' then 'Widowed' when 'L' then 'Legally Separated' when 'D' then 'Divorced' when 'A' then 'Anulled' else '' end) [CivilStatusName] ")
        Query.Append("   ,[A].CivilStatus ")
        Query.Append("   ,[A].TIN ")
        Query.Append("   ,[A].SSS ")
        Query.Append("   ,[A].UMID ")
        Query.Append("   ,[A].Employer ")
        Query.Append("   ,[A].EmployerAddress ")
        Query.Append("   ,[L].CountryName [EmpCountryName] ")
        Query.Append("   ,[A].EmpCountryCode ")
        Query.Append("   ,[M].CityName [EmpCityName] ")
        Query.Append("   ,[A].EmpCityCode ")
        Query.Append("   ,[A].EmpTownPlace ")
        Query.Append("   ,[A].EmpTownCode ")
        Query.Append("   ,[A].WorkYears ")
        Query.Append("   ,[A].Position ")
        Query.Append("   ,[N].Description [EmploymentTypeName] ")
        Query.Append("   ,[A].EmploymentType ")
        Query.Append("   ,[A].MailingAddress ")
        Query.Append("   ,[O].CountryName [MailingCountryCodeName] ")
        Query.Append("   ,[A].MailingCountryCode ")
        Query.Append("   ,[P].CityName [MailingCityName] ")
        Query.Append("   ,[A].MailingCityCode ")
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
                        .ContractType = DR("ContractType"),
                        .DateEntered = DR("DateEntered"),
                        .FullName = DR("FullName"),
                        .LastName = DR("LastName"),
                        .FirstName = DR("FirstName"),
                        .MiddleName = DR("MiddleName"),
                        .Suffix = DR("Suffix"),
                        .HomeAddress = DR("HomeAddress"),
                        .HomeCountryName = DR("HomeCountryName"),
                        .HomeCountryCode = DR("HomeCountryCode"),
                        .HomeCityName = DR("HomeCityName"),
                        .HomeCityCode = DR("HomeCityCode"),
                        .HomeTownPlace = DR("HomeTownPlace"),
                        .HomeTownCode = DR("HomeTownCode"),
                        .YearsofStay = DR("YearsofStay"),
                        .OwnershipName = DR("OwnershipName"),
                        .Ownership = DR("Ownership"),
                        .Emailaddress = DR("Emailaddress"),
                        .MobileNo = DR("MobileNo"),
                        .BirthDate = DR("BirthDate"),
                        .GenderName = DR("GenderName"),
                        .Gender = DR("Gender"),
                        .CitizenshipName = DR("CitizenshipName"),
                        .CitizenshipCode = DR("CitizenshipCode"),
                        .CivilStatusName = DR("CivilStatusName"),
                        .CivilStatus = DR("CivilStatus"),
                        .TIN = DR("TIN"),
                        .SSS = DR("SSS"),
                        .UMID = DR("UMID"),
                        .Employer = DR("Employer"),
                        .EmployerAddress = DR("EmployerAddress"),
                        .EmpCountryName = DR("EmpCountryName"),
                        .EmpCountryCode = DR("EmpCountryCode"),
                        .EmpCityName = DR("EmpCityName"),
                        .EmpCityCode = DR("EmpCityCode"),
                        .EmpTownPlace = DR("EmpTownPlace"),
                        .EmpTownCode = DR("EmpTownCode"),
                        .WorkYears = DR("WorkYears"),
                        .Position = DR("Position"),
                        .EmploymentTypeName = DR("EmploymentTypeName"),
                        .EmploymentType = DR("EmploymentType"),
                        .MailingAddress = DR("MailingAddress"),
                        .MailingCountryCodeName = DR("MailingCountryCodeName"),
                        .MailingCountryCode = DR("MailingCountryCode"),
                        .MailingCityName = DR("MailingCityName"),
                        .MailingCityCode = DR("MailingCityCode"),
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
    Function Upd_Rec_03(pAcctNo, pModelCode, pHouseSpec, pContractType, pAcctName, pLastName, pFirstName, pMiddleName, pSuffix, pHomeAddress, pHomeCountryCode, pHomeCityCode, pHomeTownPlace, pHomeTownCode, pYearsofStay, pOwnership, pEmailAddress, pMobileNo, pBirthDate, pGender, pCitizenship, pCivilStatus, pTIN, pSSS, pUMID, pEmployer, pEmployerAddress, pEmpCountryCode, pEmpCityCode, pEmpTownPlace, pEmpTownCode, pWorkYears, pPosition, pEmploymentType, pMailingAddress, pMailingCountryCode, pMailingCityCode, pMailingTownPlace, pMailingTownCode, pAuditUser)

        'update
        Dim Query As New StringBuilder
        Query.Append("UPDATE calmardbLive.dbo.ICR_Buyers SET ")
        Query.Append("  ModelCode = @pModelCode ")
        Query.Append("  ,HouseSpec = @pHouseSpec ")
        Query.Append("  ,ContractType = @pContractType ")
        Query.Append("  ,AcctName = @pAcctName ")
        Query.Append("  ,LastName = @pLastName ")
        Query.Append("  ,FirstName = @pFirstName ")
        Query.Append("  ,MiddleName = @pMiddleName ")
        Query.Append("  ,Suffix = @pSuffix ")
        Query.Append("  ,HomeAddress = @pHomeAddress ")
        Query.Append("  ,HomeCountryCode = @pHomeCountryCode ")
        Query.Append("  ,HomeCityCode = @pHomeCityCode ")
        Query.Append("  ,HomeTownPlace = @pHomeTownPlace ")
        Query.Append("  ,HomeTownCode = @pHomeTownCode ")
        Query.Append("  ,YearsOfStay = @pYearsofStay ")
        Query.Append("  ,Ownership = @pOwnership ")
        Query.Append("  ,Emailaddress = @pEmailAddress ")
        Query.Append("  ,MobileNo = @pMobileNo ")
        If pBirthDate <> "" Then
            Query.Append("  ,BirthDate = '" & pBirthDate & "' ")
        Else
            Query.Append("  ,BirthDate = NULL ")
        End If
        Query.Append("  ,Gender = @pGender ")
        Query.Append("  ,Citizenship = @pCitizenship ")
        Query.Append("  ,CivilStatus = @pCivilStatus ")
        Query.Append("  ,TIN = @pTIN ")
        Query.Append("  ,SSS = @pSSS ")
        Query.Append("  ,UMID = @pUMID ")
        Query.Append("  ,Employer = @pEmployer ")
        Query.Append("  ,EmployerAddress = @pEmployerAddress ")
        Query.Append("  ,EmpCountryCode = @pEmpCountryCode ")
        Query.Append("  ,EmpCityCode = @pEmpCityCode ")
        Query.Append("  ,EmpTownPlace = @pEmpTownPlace ")
        Query.Append("  ,EmpTownCode = @pEmpTownCode ")
        Query.Append("  ,WorkYears = @pWorkYears ")
        Query.Append("  ,Position = @pPosition ")
        Query.Append("  ,EmploymentType = @pEmploymentType ")
        Query.Append("  ,MailingAddress = @pMailingAddress ")
        Query.Append("  ,MailingCountryCode = @pMailingCountryCode ")
        Query.Append("  ,MailingCityCode = @pMailingCityCode ")
        Query.Append("  ,MailingTownPlace = @pMailingTownPlace ")
        Query.Append("  ,MailingTownCode = @pMailingTownCode ")
        Query.Append("  ,AuditUser = @pAuditUser ")
        Query.Append("  ,AuditDate = GETDATE() ")
        Query.Append("WHERE ")
        Query.Append("  AcctNo = '" & pAcctNo & "' ")
        'update

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@pModelCode", pModelCode)
                Cmd.Parameters.AddWithValue("@pHouseSpec", pHouseSpec)
                Cmd.Parameters.AddWithValue("@pContractType", pContractType)
                Cmd.Parameters.AddWithValue("@pAcctName", pAcctName)
                Cmd.Parameters.AddWithValue("@pLastName", pLastName)
                Cmd.Parameters.AddWithValue("@pFirstName", pFirstName)
                Cmd.Parameters.AddWithValue("@pMiddleName", pMiddleName)
                Cmd.Parameters.AddWithValue("@pSuffix", pSuffix)
                Cmd.Parameters.AddWithValue("@pHomeAddress", pHomeAddress)
                Cmd.Parameters.AddWithValue("@pHomeCountryCode", pHomeCountryCode)
                Cmd.Parameters.AddWithValue("@pHomeCityCode", pHomeCityCode)
                Cmd.Parameters.AddWithValue("@pHomeTownPlace", pHomeTownPlace)
                Cmd.Parameters.AddWithValue("@pHomeTownCode", pHomeTownCode)
                Cmd.Parameters.AddWithValue("@pYearsOfStay", pYearsofStay)
                Cmd.Parameters.AddWithValue("@pOwnership", pOwnership)
                Cmd.Parameters.AddWithValue("@pEmailAddress", pEmailAddress)
                Cmd.Parameters.AddWithValue("@pMobileNo", pMobileNo)
                Cmd.Parameters.AddWithValue("@pGender", pGender)
                Cmd.Parameters.AddWithValue("@pCitizenship", pCitizenship)
                Cmd.Parameters.AddWithValue("@pCivilStatus", pCivilStatus)
                Cmd.Parameters.AddWithValue("@pTIN", pTIN)
                Cmd.Parameters.AddWithValue("@pSSS", pSSS)
                Cmd.Parameters.AddWithValue("@pUMID", pUMID)
                Cmd.Parameters.AddWithValue("@pEmployer", pEmployer)
                Cmd.Parameters.AddWithValue("@pEmployerAddress", pEmployerAddress)
                Cmd.Parameters.AddWithValue("@pEmpCountryCode", pEmpCountryCode)
                Cmd.Parameters.AddWithValue("@pEmpCityCode", pEmpCityCode)
                Cmd.Parameters.AddWithValue("@pEmpTownPlace", pEmpTownPlace)
                Cmd.Parameters.AddWithValue("@pEmpTownCode", pEmpTownCode)
                Cmd.Parameters.AddWithValue("@pWorkYears", pWorkYears)
                Cmd.Parameters.AddWithValue("@pPosition", pPosition)
                Cmd.Parameters.AddWithValue("@pEmploymentType", pEmploymentType)
                Cmd.Parameters.AddWithValue("@pMailingAddress", pMailingAddress)
                Cmd.Parameters.AddWithValue("@pMailingCountryCode", pMailingCountryCode)
                Cmd.Parameters.AddWithValue("@pMailingCityCode", pMailingCityCode)
                Cmd.Parameters.AddWithValue("@pMailingTownPlace", pMailingTownPlace)
                Cmd.Parameters.AddWithValue("@pMailingTownCode", pMailingTownCode)
                Cmd.Parameters.AddWithValue("@pAuditUser", pAuditUser)
                Cmd.Parameters.AddWithValue("@pAcctNo", pAcctNo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordList.Add(New With {.oReturn = "Success"})
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