Imports System.Net
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes
Imports Microsoft.Ajax.Utilities
Imports System.Net.Mail
Imports OfficeOpenXml.Drawing.Slicer.Style
Imports Newtonsoft.Json

Public Class AAD002014HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "calmardblive"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            CIIS_UserInfo = context.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            Dim pFunction = context.Request("pFunction")

            If pFunction = "Get-Record-02" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_02(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Info-03" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_03(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)


            ElseIf pFunction = "Get-Info-04" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_04(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-03-List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Get_Record_03_List(pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)


            ElseIf pFunction = "Add-Record-03" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pRealty = context.Request("pRealty")
                Dim pGroup = context.Request("pGroup")
                Dim pSellerType = context.Request("pSellerType")
                Dim pSeller = context.Request("pSeller")
                Dim pLOComm = context.Request("pLOComm")
                Dim pHLComm = context.Request("pHLComm")
                Dim pSMO = context.Request("pSMO")

                Dim json As String = Me.Add_Record_03(pAcctNo, pRealty, pGroup, pSellerType, pSeller, pLOComm, pHLComm, pSMO)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-Record-03" Then

                Dim pID = context.Request("pID")
                Dim pRealty = context.Request("pRealty")
                Dim pGroup = context.Request("pGroup")
                Dim pSellerType = context.Request("pSellerType")
                Dim pSeller = context.Request("pSeller")
                Dim pLOComm = context.Request("pLOComm")
                Dim pHLComm = context.Request("pHLComm")
                Dim pSMO = context.Request("pSMO")

                Dim json As String = Me.Update_Record_03(pID, pRealty, pGroup, pSellerType, pSeller, pLOComm, pHLComm, pSMO)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Update-Record-04" Then

                Dim pID = context.Request("pID")
                Dim pPayload = context.Request("pPayload")

                Dim json As String = Me.Update_Setup_Seller(pID, pPayload)
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

    Function Get_Record_02(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ICR_Sellers.AcctNo  ")
        Query.Append("	,ICR_Sellers.SellerCode ")
        Query.Append("	,mstr_Realty.NameOfRealty [Realty] ")
        Query.Append("	,mstr_SellerGroups.SellerGrpDesc [Group] ")
        Query.Append("	,mstr_SellerTypes.SellerTypeDesc [Type]  ")
        Query.Append("	,mstr_Sellers.SellerName [Seller] ")
        Query.Append("	,ICR_Sellers.CommRate  ")
        Query.Append("	,ICR_Sellers.HLCommRate ")
        Query.Append("	,mstr_Entities.CompoundName [SMO] ")
        Query.Append("	,ICR_Sellers.AuditUser  ")
        Query.Append("	,ICR_Sellers.AuditDate  ")
        Query.Append("	,ICR_Sellers.UpdatedBy  ")
        Query.Append("	,ICR_Sellers.UpdatedDate ")
        Query.Append("	,ICR_Sellers.[Level] ")
        Query.Append("   ,mstr_Sellers.EWTRate [WithholdingTax] ")
        Query.Append("	,mstr_Sellers.EmailAddress ")
        Query.Append("	,mstr_Sellers.Cellphone ")
        Query.Append("from ")
        Query.Append("	calmardblive.dbo.ICR_Sellers ")
        Query.Append("	left join calmardblive.dbo.mstr_Realty on ICR_Sellers.RealtyCode = mstr_Realty.RealtyCode ")
        Query.Append("	left join calmardblive.dbo.mstr_SellerGroups on ICR_Sellers.GroupCode = mstr_SellerGroups.SellerGrpCode ")
        Query.Append("	left join calmardblive.dbo.mstr_SellerTypes on ICR_Sellers.TypeCode = mstr_SellerTypes.SellerTypeCode ")
        Query.Append("	left join calmardblive.dbo.mstr_Sellers on ICR_Sellers.SellerCode = mstr_Sellers.SellerCode ")
        Query.Append("	left join calmardblive.dbo.mstr_Entities  on ICR_Sellers.SMO = mstr_Entities.EntityCode ")
        Query.Append("where ")
        Query.Append("	ICR_Sellers.AcctNo = @AcctNo ")
        Query.Append("order by ")
        Query.Append("	[Level] desc ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    Dim Action As New StringBuilder

                    RecordList.Add(New With {
                        .rowId = "rowID02" & DR("AcctNo"),
                        .Realty = "<span title='" & DR("Realty") & "'>" & DR("Realty") & "</span>",
                        .Group = "<span title='" & DR("Group") & "'>" & DR("Group") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .Seller = "<span title='" & DR("Seller") & "'>" & DR("Seller") & "</span>",
                        .LOComm = "<span title='" & DR("CommRate") & "'>" & DR("CommRate") & "</span>",
                        .HLComm = "<span title='" & DR("HLCommRate") & "'>" & DR("HLCommRate") & "</span>",
                        .WT = "<span title='" & DR("WithholdingTax") & "'>" & DR("WithholdingTax") & "</span>"
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function Get_Info_03(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT  ")
        Query.Append("    [A].SellerRank, ")
        Query.Append("    [A].SellerTypeCode, ")
        Query.Append("    [A].SellerTypeDesc AS [Type], ")
        Query.Append("	[B].RealtyCode AS [RealtyCode], ")
        Query.Append("    [B].GroupCode AS [GroupCode], ")
        Query.Append("    [B].SellerCode AS [SellerCode], ")
        Query.Append("    [B].TypeCode as [TypeCode], ")
        Query.Append("    ISNULL([C].SellerName, '') AS [SellerName], ")
        Query.Append("    ISNULL([B].CommRate, 0) AS [CommRate], ")
        Query.Append("    ISNULL([B].HLCommRate, 0) AS [HLCommRate] ")
        Query.Append("FROM mstr_SellerTypes [A] ")
        Query.Append("LEFT JOIN ICR_Sellers [B] ON [B].TypeCode = [A].SellerTypeCode AND [B].AcctNo = @AcctNo ")
        Query.Append("LEFT JOIN mstr_Sellers [C] ON [B].SellerCode = [C].SellerCode ")
        Query.Append("LEFT JOIN mstr_Realty [D] ON [B].RealtyCode = [D].RealtyCode ")
        Query.Append("LEFT JOIN mstr_SellerGroups [E] ON [B].GroupCode = [E].SellerGrpCode ")
        Query.Append("WHERE [A].SellerTypeCode IN (1,2,3,4,6,7) ")
        Query.Append("ORDER BY  ")
        Query.Append("    [A].SellerRank ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .RealtyCode = DR("RealtyCode"),
                        .GroupCode = DR("GroupCode"),
                        .Type = DR("Type"),
                        .TypeCode = DR("TypeCode"),
                        .SellerName = DR("SellerName"),
                        .SellerCode = DR("SellerCode"),
                        .LOComm = Convert.ToDecimal(DR("CommRate")).ToString("N2"),
                        .HLComm = Convert.ToDecimal(DR("HLCommRate")).ToString("N2")
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
    Function Get_Info_04(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[B].SellerName  ")
        Query.Append("from  ")
        Query.Append("	ICR_Buyers [A]  ")
        Query.Append("	left join calmardblive.dbo.mstr_Sellers [B] on [A].SellerCode = [B].SellerCode ")
        Query.Append("where  ")
        Query.Append("	AcctNo = @AcctNo ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .SellerName = DR("SellerName")
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

    'Realty
    Function Get_Record_03_List(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder()
        If pTblName = "mstr_Realty" Then
            Query.Append("select ")
            Query.Append("	'' [ID] ")
            Query.Append("	,'" & pPlaceHolder & "' [Name] ")
            Query.Append("    ,1 [Lock] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("	ltrim(str(RealtyCode)) [ID] ")
            Query.Append("	,NameOfRealty [Name] ")
            Query.Append("    ,isnull(Lock,0) [Lock] ")
            Query.Append("from  ")
            Query.Append("	calmardbLive.dbo.mstr_Realty ")
            Query.Append("order by ")
            Query.Append("	[ID] ")
        ElseIf pTblName = "mstr_SellerGroup" Then
            Query.Append("select ")
            Query.Append("	'' [ID] ")
            Query.Append("	,'" & pPlaceHolder & "' [Name] ")
            Query.Append("    ,1 [Lock] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("	ltrim(str(SellerGrpCode)) [ID] ")
            Query.Append("	,SellerGrpDesc [Name] ")
            Query.Append("    ,isnull(Lock,0) [Lock] ")
            Query.Append("from  ")
            Query.Append("	calmardbLive.dbo.mstr_SellerGroups	 ")
            Query.Append("order by ")
            Query.Append("	[ID] ")
        ElseIf pTblName = "mstr_SellerType" Then
            Query.Append("select ")
            Query.Append("	'' [ID] ")
            Query.Append("	,'" & pPlaceHolder & "' [Name] ")
            Query.Append("    ,1 [Lock] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("	ltrim(str(SellerTypeCode)) [ID] ")
            Query.Append("	,SellerTypeDesc [Name] ")
            Query.Append("    ,isnull(Lock,0) [Lock] ")
            Query.Append("from  ")
            Query.Append("	calmardbLive.dbo.mstr_SellerTypes ")
            Query.Append("order by ")
            Query.Append("	[ID] ")
        ElseIf pTblName = "mstr_Sellers" Then
            Query.Append("select ")
            Query.Append("	'' [ID] ")
            Query.Append("	,'" & pPlaceHolder & "' [Name] ")
            Query.Append("    ,1 [Lock] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("	SellerCode [ID] ")
            Query.Append("	,SellerName [Name] ")
            Query.Append("    ,isnull(Lock ,0)[Lock] ")
            Query.Append("from  ")
            Query.Append("	calmardbLive.dbo.Mstr_Sellers ")
            Query.Append("order by ")
            Query.Append("	[ID] ")
        ElseIf pTblName = "mstr_Entities" Then
            Query.Append("select ")
            Query.Append("	'' [ID] ")
            Query.Append("	,'" & pPlaceHolder & "' [Name] ")
            Query.Append("    ,1 [Lock] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("	mstr_EntityInstances.EntityCode [ID] ")
            Query.Append("	,mstr_Entities.CompoundName [Name] ")
            Query.Append("    ,1 [Lock] ")
            Query.Append("from  ")
            Query.Append("	calmardbLive.dbo.mstr_EntityInstances ")
            Query.Append("	left join calmardbLive.dbo.mstr_Entities on mstr_EntityInstances.EntityCode = mstr_Entities.EntityCode ")
            Query.Append("where ")
            Query.Append("	mstr_EntityInstances.ClassCode = '6' ")
            Query.Append("order by ")
            Query.Append("	[ID] ")
        End If

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

    Function Add_Record_03(pAcctNo, pRealty, pGroup, pSellerType, pSeller, pLOComm, pHLComm, pSMO)
        'create variable
        Dim Query As New StringBuilder
        Query.Append("DECLARE @Level nvarchar(13); ")
        Query.Append("EXEC calmardblive.dbo.JCF_NewSeqNo 'ICR_Sellers', @AcctNo, @Level OUTPUT; ")
        Query.Append("INSERT INTO calmardbLive.dbo.ICR_Sellers ")
        Query.Append("	(AcctNo, [Level], RealtyCode,  ")
        Query.Append("	GroupCode, TypeCode, SellerCode,  ")
        Query.Append("	CommRate, HLCommRate, SMO,  ")
        Query.Append("	AuditUser, AuditDate, UpdatedBy, UpdatedDate) ")
        Query.Append("VALUES         ")
        Query.Append("	(@AcctNo,@Level,@RealtyCode, ")
        Query.Append("	@GroupCode,@TypeCode,@SellerCode, ")
        Query.Append("	@CommRate,@HLCommRate,@SMO, ")
        Query.Append("	@AuditUser,FORMAT(GETDATE(), 'MM/dd/yy HH:mm:ss.fff'), ")
        Query.Append("	@UpdatedBy, FORMAT(GETDATE(), 'MM/dd/yy HH:mm:ss.fff')) ")
        Query.Append("SELECT @AcctNo + @Level AS oID; ")

        'variable
        Dim RecordList As New List(Of Object)()

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text

                ' Parameters
                Cmd.Parameters.AddWithValue("@AcctNo", pAcctNo)
                Cmd.Parameters.AddWithValue("@RealtyCode", pRealty)
                Cmd.Parameters.AddWithValue("@GroupCode", pGroup)
                Cmd.Parameters.AddWithValue("@TypeCode", pSellerType)
                Cmd.Parameters.AddWithValue("@SellerCode", pSeller)
                Cmd.Parameters.AddWithValue("@CommRate", pLOComm)
                Cmd.Parameters.AddWithValue("@HLCommRate", pHLComm)
                Cmd.Parameters.AddWithValue("@SMO", pSMO)
                Cmd.Parameters.AddWithValue("@AuditUser", CIIS_EmpCode)
                Cmd.Parameters.AddWithValue("@UpdatedBy", CIIS_EmpCode)

                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    While DR.Read()
                        RecordList.Add(New With {.oID = DR("oID")})
                    End While
                    DR.Close()
                End Using
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
    End Function

    Function Update_Record_03(pID, pRealty, pGroup, pSellerType, pSeller, pLOComm, pHLComm, pSMO)
        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE       ")
        Query.Append("	calmardbLive.dbo.ICR_Sellers ")
        Query.Append("SET                 ")
        Query.Append("	RealtyCode = @RealtyCode,  ")
        Query.Append("	GroupCode = @GroupCode,  ")
        Query.Append("	TypeCode = @TypeCode,  ")
        Query.Append("	SellerCode = @SellerCode,  ")
        Query.Append("	CommRate = @CommRate,  ")
        Query.Append("	HLCommRate = @HLCommRate,  ")
        Query.Append("	SMO = @SMO,  ")
        Query.Append("	UpdatedBy = @UpdatedBy,  ")
        Query.Append("	UpdatedDate = FORMAT(GETDATE(), 'MM/dd/yy HH:mm:ss.fff') ")
        Query.Append("WHERE         ")
        Query.Append("	CAST(ICR_Sellers.AcctNo AS VARCHAR(50)) + CAST(ICR_Sellers.[Level] AS VARCHAR(50)) = @AcctNo ")

        'variable
        Dim RecordList As New List(Of Object)()

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text

                ' Parameters
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                Cmd.Parameters.AddWithValue("@RealtyCode", pRealty)
                Cmd.Parameters.AddWithValue("@GroupCode", pGroup)
                Cmd.Parameters.AddWithValue("@TypeCode", pSellerType)
                Cmd.Parameters.AddWithValue("@SellerCode", pSeller)
                Cmd.Parameters.AddWithValue("@CommRate", pLOComm)
                Cmd.Parameters.AddWithValue("@HLCommRate", pHLComm)
                Cmd.Parameters.AddWithValue("@SMO", pSMO)
                Cmd.Parameters.AddWithValue("@UpdatedBy", CIIS_EmpCode)

                ConStr.Open()
                Using DR As SqlDataReader = Cmd.ExecuteReader()
                    While DR.Read()
                        RecordList.Add(New With {.oID = pID})
                    End While
                    DR.Close()
                End Using
            End Using
        End Using

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
    End Function


    Public Function Update_Setup_Seller(pAcctNo As String, pPayload As String) As String
        Dim sellers As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(pPayload)

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            ConStr.Open()
            Dim trans As SqlTransaction = ConStr.BeginTransaction()

            Try
                ' 🔹 First delete all existing records for this AcctNo
                Using delCmd As New SqlCommand("DELETE FROM ICR_Sellers WHERE AcctNo = @AcctNo", ConStr, trans)
                    delCmd.Parameters.AddWithValue("@AcctNo", pAcctNo)
                    delCmd.ExecuteNonQuery()
                End Using

                ' 🔹 Insert new records from payload
                For Each Item In sellers
                    Dim Query As New StringBuilder()
                    Query.Append("DECLARE @Level nvarchar(13); ")
                    Query.Append("EXEC calmardblive.dbo.JCF_NewSeqNo 'ICR_Sellers', @AcctNo, @Level OUTPUT; ")
                    Query.Append("INSERT INTO calmardbLive.dbo.ICR_Sellers ")
                    Query.Append(" (AcctNo, [Level], RealtyCode, GroupCode, TypeCode, SellerCode, CommRate, HLCommRate, SMO, AuditUser, AuditDate, UpdatedBy, UpdatedDate) ")
                    Query.Append("VALUES ")
                    Query.Append(" (@AcctNo,@Level,@RealtyCode,@GroupCode,@TypeCode,@SellerCode,@CommRate,@HLCommRate,@SMO, ")
                    Query.Append("  @AuditUser,GETDATE(),@UpdatedBy,GETDATE()) ")

                    Using Cmd As New SqlCommand(Query.ToString(), ConStr, trans)
                        Cmd.CommandType = CommandType.Text

                        ' Parameters
                        Cmd.Parameters.AddWithValue("@AcctNo", pAcctNo)
                        Cmd.Parameters.AddWithValue("@RealtyCode", Item("RealtyCode"))
                        Cmd.Parameters.AddWithValue("@GroupCode", Item("GroupCode"))
                        Cmd.Parameters.AddWithValue("@TypeCode", Item("TypeCode"))
                        Cmd.Parameters.AddWithValue("@SellerCode", Item("SellerCode"))
                        Cmd.Parameters.AddWithValue("@CommRate", Item("CommRate"))
                        Cmd.Parameters.AddWithValue("@HLCommRate", Item("HLCommRate"))
                        Cmd.Parameters.AddWithValue("@SMO", DBNull.Value) ' 🔹 placeholder if not in payload
                        Cmd.Parameters.AddWithValue("@AuditUser", CIIS_EmpCode)
                        Cmd.Parameters.AddWithValue("@UpdatedBy", CIIS_EmpCode)

                        Cmd.ExecuteNonQuery()
                    End Using
                Next

                ' 🔹 Commit only if all succeeded
                trans.Commit()
                Return JsonConvert.SerializeObject(New With {.status = "Success"})

            Catch ex As Exception
                ' 🔹 Rollback if any failure
                trans.Rollback()
                Return "Failed: " & ex.Message
            End Try
        End Using
    End Function

End Class