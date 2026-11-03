Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient

Public Class AAD002000HND
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

            If pFunction = "Redraw-02" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Redraw_02(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-02" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pAcctName = context.Request("pAcctName")
                Dim pSubd = context.Request("pSubd")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pDOEFrom = context.Request("pDOEFrom")
                Dim pDOETo = context.Request("pDOETo")
                Dim pPaid = context.Request("pPaid")

                Dim pCancelled = context.Request("pCancelled")
                Dim pTransferred = context.Request("pTransferred")

                Dim json As String = Me.Get_Record_02(pAcctNo, pAcctName, pSubd, pPhase, pBlock, pLot, pDOEFrom, pDOETo, pPaid, pCancelled, pTransferred)
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

    Function Redraw_02(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].FATCode [ID] ")
        Query.Append("   ,[A].Description [Description] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("from ")
        Query.Append("   Mstr_FAType [A] ")
        Query.Append("where ")
        Query.Append("   [A].FATCode = '" & pID & "' ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<a class='btn btn-sm btn-icon btn-view' title='View' href=""AAD002001?pID=" & DR("ID") & """><i class='las la-search fs-3'></i></a>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>"
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

    Function Get_Record_02(pAcctNo, pAcctName, pSubd, pPhase, pBlock, pLot, pDOEFrom, pDOETo, pPaid, pCancelled, pTransferred)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo [ID] ")
        Query.Append("   ,[A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,format([C].RFDate,'MM/dd/yyyy') [DOE] ")
        Query.Append("   ,(case when [C].Sellingprice + ISNULL([C].VATAmount, 0) - ISNULL([C].TCPDiscount, 0) - ISNULL([C].VATDiscAmt, 0) - ISNULL([C].PromoDPDiscount, 0) <= (select sum([E].AmtPd2Prin) from calmardbLive.dbo.ICR_Ledger [E] where [E].AcctNo = [A].AcctNo) then 1 else 0 end) [Paid] ")
        Query.Append("   ,(case when [A].Active = 0 then 1 else 0 end) [Cancelled] ")
        Query.Append("   ,isnull([D].TOL,0) [Transferred] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.ICR_Reservations [C] on [A].AcctNo = [C].AcctNo ")
        Query.Append("   left join calmardblive.dbo.ICR_Cancellation [D] on [A].AcctNo = [D].AcctNo ")
        Query.Append("where ")
        Query.Append("   [C].Posted = 1 ")
        If pAcctNo = "" And pAcctName = "" And pSubd = "" And pPhase = "" And pBlock = "" And pLot = "" And pDOEFrom = "" And pDOETo = "" And pPaid = False And pCancelled = False And pTransferred = False Then Query.Append("   and [A].AcctNo = '' ")
        If pAcctNo <> "" Then Query.Append("   and ([A].AcctNo = '" & pAcctNo & "' or [A].AcctNo like '%" & pAcctNo & "%') ")
        If pAcctName <> "" Then Query.Append("   and ([A].AcctName = '" & pAcctName & "' or [A].AcctName like '%" & pAcctName & "%') ")
        If pSubd <> "" Then Query.Append("   and [B].ProjInit = '" & pSubd & "' ")
        If pPhase <> "" Then Query.Append("   and [A].Phase = '" & pPhase & "' ")
        If pBlock <> "" Then Query.Append("   and [A].Block = '" & pBlock & "' ")
        If pLot <> "" Then Query.Append("   and [A].Lot = '" & pLot & "' ")
        If pDOEFrom <> "" And pDOETo = "" Then Query.Append("   and cast([C].RFDate as date) = '" & Format(CDate(pDOEFrom), "yyyy-MM-dd") & "' ")
        If pDOEFrom = "" And pDOETo <> "" Then Query.Append("   and cast([C].RFDate as date) = '" & Format(CDate(pDOETo), "yyyy-MM-dd") & "' ")
        If pDOEFrom <> "" And pDOETo <> "" Then Query.Append("   and cast([C].RFDate as date) between '" & Format(CDate(pDOEFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(pDOETo), "yyyy-MM-dd") & "' ")
        If pPaid = True Then Query.Append("   and (case when [C].Sellingprice + ISNULL([C].VATAmount, 0) - ISNULL([C].TCPDiscount, 0) - ISNULL([C].VATDiscAmt, 0) - ISNULL([C].PromoDPDiscount, 0) <= (select sum([E].AmtPd2Prin) from calmardbLive.dbo.ICR_Ledger [E] where [E].AcctNo = [A].AcctNo) then 1 else 0 end) = 1 ")
        If pCancelled = True Then Query.Append("   and (case when [A].Active = 0 then 1 else 0 end) = 1 ")
        If pTransferred = True Then Query.Append("   and isnull([D].TOL,0) = 1 ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<a class='btn btn-sm btn-icon btn-view' title='View' href=""AAD002001?pID=" & DR("ID") & """><i class='las la-search fs-3'></i></a>")

                    RecordList.Add(New With {
                        .rowId = "rowID02" & DR("ID"),
                        .Action = Action.ToString,
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName"),
                        .Project = DR("Project"),
                        .DOE = DR("DOE"),
                        .Paid = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Paid") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Cancelled = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Cancelled") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Transferred = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Transferred") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Blank = ""
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

End Class