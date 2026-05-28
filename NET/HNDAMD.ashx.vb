Imports System.Web
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports System.Security.Cryptography
Imports WebGrease.Css
Imports Microsoft.Reporting.Map.WebForms.VirtualEarth
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports Microsoft.Identity.Client.AuthScheme

Public Class HNDAMD
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

#Region "Form"

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim pFormCode = context.Request("pFormCode")
            Dim pType = context.Request("pType")
            'general parameter

            If pType = "Get Record - List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Get_Reocrd_List(pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "AMD010000" And pType = "Redraw" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD010000_Redraw(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD010000" And pType = "Get Record" Then

                Dim json As String = Me.AMD010000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD010000" And pType = "Get Info" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD010000_Get_Info(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD010000" And pType = "Add Record" Then

                Dim pDescription = context.Request("pDescription")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.AMD010000_Add_Record(pDescription, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD010000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pDescription = context.Request("pDescription")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.AMD010000_Edit_Record(pID, pDescription, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "AMD020000" And pType = "Redraw - Hdr" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD020000_Redraw_Hdr(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD020000" And pType = "Get Record - HDR" Then

                Dim pLock = context.Request("pLock")
                Dim pDescription = context.Request("pDescription")
                Dim pFAType = context.Request("pFAType")
                Dim pStatus = context.Request("pStatus")
                Dim pBranch = context.Request("pBranch")
                Dim pIssuedTo = context.Request("pIssuedTo")

                Dim json As String = Me.AMD020000_Get_Record_Hdr(pLock, pDescription, pFAType, pStatus, pBranch, pIssuedTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD020000" And pType = "Get Info - DTL" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD020000_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD020000" And pType = "Get Record - DTL - Movement" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD020000_Get_Record_Dtl_Movement(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD020000" And pType = "Add Record" Then

                Dim pTblFrom = "Manual"
                Dim pTblCode = ""
                Dim pDescription = context.Request("pDescription")
                Dim pFAType = context.Request("pFAType")
                Dim pStatus = context.Request("pStatus")
                Dim pDivision = context.Request("pDivision")
                Dim pBranch = context.Request("pBranch")
                Dim pDepartment = context.Request("pDepartment")
                Dim pTagNo = context.Request("pTagNo")
                Dim pQty = context.Request("pQty")
                Dim pUnit = context.Request("pUnit")
                Dim pLocation = context.Request("pLocation")
                Dim pManufacturer = context.Request("pManufacturer")
                Dim pModelNo = context.Request("pModelNo")
                Dim pSerialNo = context.Request("pSerialNo")
                Dim pDateAquired = context.Request("pDateAquired")
                Dim pDisposalDate = context.Request("pDisposalDate")
                Dim pDisposalAmt = context.Request("pDisposalAmt")
                Dim pIssuedTo = context.Request("pIssuedTo")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.AMD020000_Add_Record(pTblFrom, pTblCode, pDescription, pFAType, pStatus, pDivision, pBranch, pDepartment, pTagNo, IIf(pQty = "", 0, pQty), pUnit, pLocation, pManufacturer, pModelNo, pSerialNo, pDateAquired, pDisposalDate, IIf(pDisposalAmt = "", 0, pDisposalAmt), pIssuedTo, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD020000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pDescription = context.Request("pDescription")
                Dim pFAType = context.Request("pFAType")
                Dim pStatus = context.Request("pStatus")
                Dim pDivision = context.Request("pDivision")
                Dim pBranch = context.Request("pBranch")
                Dim pDepartment = context.Request("pDepartment")
                Dim pTagNo = context.Request("pTagNo")
                Dim pQty = context.Request("pQty")
                Dim pUnit = context.Request("pUnit")
                Dim pLocation = context.Request("pLocation")
                Dim pManufacturer = context.Request("pManufacturer")
                Dim pModelNo = context.Request("pModelNo")
                Dim pSerialNo = context.Request("pSerialNo")
                Dim pDateAquired = context.Request("pDateAquired")
                Dim pDisposalDate = context.Request("pDisposalDate")
                Dim pDisposalAmt = context.Request("pDisposalAmt")
                Dim pIssuedTo = context.Request("pIssuedTo")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.AMD020000_Edit_Record(pID, pDescription, pFAType, pStatus, pDivision, pBranch, pDepartment, pTagNo, IIf(pQty = "", 0, pQty), pUnit, pLocation, pManufacturer, pModelNo, pSerialNo, pDateAquired, pDisposalDate, IIf(pDisposalAmt = "", 0, pDisposalAmt), pIssuedTo, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "AMD030000" And pType = "Redraw - Hdr" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD030000_Redraw_Hdr(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Get Record - HDR" Then

                Dim pLock = context.Request("pLock")
                Dim pIssuedTo = context.Request("pIssuedTo")
                Dim pStatus = context.Request("pStatus")

                Dim json As String = Me.AMD030000_Get_Record_Hdr(IIf(pLock = True, 1, 0), pIssuedTo, pStatus)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Get Info - DTL" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD030000_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Add Record" Then

                Dim pIssuedType = context.Request("pIssuedType")
                Dim pIssuedTo = context.Request("pIssuedTo")
                Dim pLocation = context.Request("pLocation")
                Dim pIssuedBy = context.Request("pIssuedBy")
                Dim pGP = context.Request("pGP")
                Dim DeliverTo = context.Request("DeliverTo")
                Dim AuthorizedBy = context.Request("AuthorizedBy")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.AMD030000_Add_Record(pIssuedType, pIssuedTo, pLocation, pIssuedBy, IIf(pGP = True, 1, 0), DeliverTo, AuthorizedBy, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pIssuedType = context.Request("pIssuedType")
                Dim pIssuedTo = context.Request("pIssuedTo")
                Dim pLocation = context.Request("pLocation")
                Dim pIssuedBy = context.Request("pIssuedBy")
                Dim pGP = context.Request("pGP")
                Dim DeliverTo = context.Request("DeliverTo")
                Dim AuthorizedBy = context.Request("AuthorizedBy")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.AMD030000_Edit_Record(pID, pIssuedType, pIssuedTo, pLocation, pIssuedBy, IIf(pGP = True, 1, 0), DeliverTo, AuthorizedBy, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Redraw - DTL - Asset" Then

                Dim pIssueCode = context.Request("pIssueCode")
                Dim pFACode = context.Request("pFACode")

                Dim json As String = Me.AMD030000_Redraw_Dtl_Asset(pIssueCode, pFACode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Get Record - DTL - Asset - HDR" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.AMD030000_Get_Record_Dtl_Asset_Hdr(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Get Record - DTL - Asset - DTL" Then

                Dim pIssueCode = context.Request("pIssueCode")
                Dim pIssuedType = context.Request("pIssuedType")

                Dim json As String = Me.AMD030000_Get_Record_Dtl_Asset_Dtl(pIssueCode, pIssuedType)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "AMD030000" And pType = "Add Record - DTL - Asset" Then

                Dim pIssueCode = context.Request("pIssueCode")
                Dim pFACode = context.Request("pFACode")
                Dim pDisposalAmt = context.Request("pDisposalAmt")
                Dim pRemarks = context.Request("pRemarks")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.AMD030000_Add_Record_Dtl_Asset(pIssueCode, pFACode, pDisposalAmt, pRemarks, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

        Catch ex As Exception

        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#End Region

#Region "Get Record - List"

    Function Get_Reocrd_List(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Mstr_Employee" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].emp_no [ID] ")
            Query.Append("   ,[A].fullname [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].fullname [Order2] ")
            Query.Append("from ")
            Query.Append("   employee [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_UOM" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].u_code [ID] ")
            Query.Append("   ,[A].abbr [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].abbr [Order2] ")
            Query.Append("from ")
            Query.Append("   sys_um [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Department" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].dept_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   department [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Branch" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].buss_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   business [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_FAType" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].FATCode [ID] ")
            Query.Append("   ,[A].Description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].Description [Order2] ")
            Query.Append("from ")
            Query.Append("   Mstr_FAType [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order1] ")
            Query.Append("   ,[Order2] ")
        ElseIf pTblName = "Mstr_Division" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].div_code [ID] ")
            Query.Append("   ,[A].description [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("   division [A] ")
            Query.Append("where ")
            Query.Append("   [A].Lock = 1 ")
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

#End Region

#Region "AMD010000"

    Function AMD010000_Redraw(pID)

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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

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

    Function AMD010000_Get_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].FATCode [ID] ")
        Query.Append("   ,[A].Description [Description] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("from ")
        Query.Append("   Mstr_FAType [A] ")
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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

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

        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function

    Function AMD010000_Get_Info(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].FATCode [ID] ")
        Query.Append("   ,[A].Description [Description] ")
        Query.Append("   ,[B].fullname [UpdatedByName] ")
        Query.Append("   ,format([A].UpdatedDate,'MM/dd/yyyy hh:mm tt') [UpdatedDate] ")
        Query.Append("   ,(case when isnull([A].lock,0) = 1 then [C].fullname else '' end) [LockedByName] ")
        Query.Append("   ,(case when isnull([A].lock,0) = 1 then format([A].LockedDate,'MM/dd/yyyy hh:mm tt') else '' end) AS LockedDate ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("   ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [RecordStatus] ")
        Query.Append("from ")
        Query.Append("   Mstr_FAType [A] ")
        Query.Append("   LEFT JOIN employee [B] ON [A].UpdatedBy = [B].emp_no ")
        Query.Append("   LEFT JOIN employee [C] ON [A].LockedBy = [C].emp_no ")
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

                    RecordList.Add(New With {
                        .ID = DR("ID"),
                        .Description = DR("Description"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate"),
                        .Lock = DR("Lock"),
                        .RecordStatus = DR("RecordStatus")
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

    Function AMD010000_Add_Record(pDescription, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @ID nvarchar(13) ")
        Query.Append("exec New_Code 'Mstr_FAType','MN',@ID output ")
        Query.Append("INSERT INTO Mstr_FAType ")
        Query.Append("   ([FATCode] ")
        Query.Append("   ,[Description] ")
        Query.Append("   ,[CreatedBy] ")
        Query.Append("   ,[CreatedDate] ")
        Query.Append("   ,[UpdatedBy] ")
        Query.Append("   ,[UpdatedDate] ")
        Query.Append("   ,[LockedBy] ")
        Query.Append("   ,[LockedDate] ")
        Query.Append("   ,[Lock]) ")
        Query.Append("VALUES ")
        Query.Append("   (@ID ")
        Query.Append("   ,'" & pDescription & "' ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0) ")
        Query.Append("select @ID [oID] ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function AMD010000_Edit_Record(pID, pDescription, pUpdatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("update Mstr_FAType set ")
        Query.Append("   Description = '" & pDescription & "' ")
        Query.Append("   ,UpdatedBy = '" & pUpdatedBy & "' ")
        Query.Append("   ,UpdatedDate = getdate() ")
        Query.Append("where ")
        Query.Append("   FATCode = '" & pID & "' ")

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

                    RecordList.Add(New With {.oID = pID})

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

#End Region

#Region "AMD020000"

    Function AMD020000_Redraw_Hdr(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("   isnull([A].FACode,'') [ID] ")
        Query.Append("   ,isnull([A].Description,'') [Description] ")
        Query.Append("   ,isnull([B].Description,'') [Type] ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([C].description,'') [Branch] ")
        Query.Append("   ,isnull([D].fullname,'') [IssuedTo] ")
        Query.Append("   ,isnull([A].TagNo,'') [TagNo] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("FROM ")
        Query.Append("   Trxn_FixedAsset [A] ")
        Query.Append("   left join Mstr_FAType [B] on [A].Type = [B].FATCode ")
        Query.Append("   left join business [C] on [A].Branch = [C].buss_code ")
        Query.Append("   left join employee [D] on [A].IssuedTo = [D].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].FACode = '" & pID & "' ")
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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AMD020100-DTL-" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .Status = "<span title='" & DR("Status") & "'>" & DR("Status") & "</span>",
                        .Branch = "<span title='" & DR("Branch") & "'>" & DR("Branch") & "</span>",
                        .IssuedTo = "<span title='" & DR("IssuedTo") & "'>" & DR("IssuedTo") & "</span>",
                        .TagNo = "<span title='" & DR("TagNo") & "'>" & DR("TagNo") & "</span>"
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

    Function AMD020000_Get_Record_Hdr(pLock, pDescription, pFAType, pStatus, pBranch, pIssuedTo)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("Get_FAHdrList")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pLock", IIf(pLock = True, 1, 0))
                Cmd.Parameters.AddWithValue("@pDescription", pDescription)
                Cmd.Parameters.AddWithValue("@pType", pFAType)
                Cmd.Parameters.AddWithValue("@pStatus", pBranch)
                Cmd.Parameters.AddWithValue("@pBranch", pBranch)
                Cmd.Parameters.AddWithValue("@pIssuedTo", pIssuedTo)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AMD020100-DTL-" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .Status = "<span title='" & DR("Status") & "'>" & DR("Status") & "</span>",
                        .Branch = "<span title='" & DR("Branch") & "'>" & DR("Branch") & "</span>",
                        .IssuedTo = "<span title='" & DR("IssuedTo") & "'>" & DR("IssuedTo") & "</span>",
                    .TagNo = "<span title='" & DR("TagNo") & "'>" & DR("TagNo") & "</span>"
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

    Function AMD020000_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("   [A].FACode ")
        Query.Append("   ,[A].Description ")
        Query.Append("   ,[A].Type ")
        Query.Append("   ,[B].Description [TypeName] ")
        Query.Append("   ,[A].Status ")
        Query.Append("   ,[A].Division ")
        Query.Append("   ,[C].description [DivisionName] ")
        Query.Append("   ,[A].Branch ")
        Query.Append("   ,[D].description [BranchName] ")
        Query.Append("   ,[A].Department ")
        Query.Append("   ,[E].description [DepartmentName] ")
        Query.Append("   ,[A].TagNo ")
        Query.Append("   ,Format([A].Qty,'N2') [Qty] ")
        Query.Append("   ,[A].Unit ")
        Query.Append("   ,[F].abbr [UnItName] ")
        Query.Append("   ,[A].Location ")
        Query.Append("   ,[A].Manufacturer ")
        Query.Append("   ,[A].ModelNo ")
        Query.Append("   ,[A].SerialNo ")
        Query.Append("   ,format([A].DateAquired,'MM/dd/yyyy') [DateAquired] ")
        Query.Append("   ,[A].IssuedTo ")
        Query.Append("   ,[G].fullname [IssuedToName] ")
        Query.Append("   ,format([A].DisposalDate,'MM/dd/yyyy') [DisposalDate] ")
        Query.Append("   ,format([A].DisposalAmt,'N2') [DisposalAmt] ")
        Query.Append("   ,[A].UpdatedBy ")
        Query.Append("   ,[H].fullname [UpdatedByName] ")
        Query.Append("   ,format([A].UpdatedDate,'MM/dd/yyyy hh:mm tt') [UpdatedDate] ")
        Query.Append("   ,[A].LockedBy ")
        Query.Append("   ,(case when isnull([A].Lock,0) = 1 then [H].fullname else '' end) [LockedByName] ")
        Query.Append("   ,(case when isnull([A].Lock,0) = 1 then format([A].LockedDate,'MM/dd/yyyy hh:mm tt') else '' end) [LockedDate] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("   ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [RecordStatus] ")
        Query.Append("FROM ")
        Query.Append("   Trxn_FixedAsset [A] ")
        Query.Append("   left join Mstr_FAType [B] on [A].Type = [B].FATCode ")
        Query.Append("   left join division [C] on [A].Division = [C].div_code ")
        Query.Append("   left join business [D] on [A].Branch = [D].buss_code ")
        Query.Append("   left join department [E] on [A].Department = [E].dept_code ")
        Query.Append("   left join sys_um [F] on [A].Unit = [F].u_code ")
        Query.Append("   left join employee [G] on [A].IssuedTo = [G].emp_no ")
        Query.Append("   left join employee [H] on [A].CreatedBy = [H].emp_no ")
        Query.Append("   left join employee [I] on [A].UpdatedBy = [I].emp_no ")
        Query.Append("   left join employee [J] on [A].LockedBy = [J].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].FACode = '" & pID & "' ")
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
                        .FACode = DR("FACode"),
                        .Description = DR("Description"),
                        .Type = DR("Type"),
                        .TypeName = DR("TypeName"),
                        .Status = DR("Status"),
                        .Division = DR("Division"),
                        .DivisionName = DR("DivisionName"),
                        .Branch = DR("Branch"),
                        .BranchName = DR("BranchName"),
                        .Department = DR("Department"),
                        .DepartmentName = DR("DepartmentName"),
                        .TagNo = DR("TagNo"),
                        .Qty = DR("Qty"),
                        .Unit = DR("Unit"),
                        .UnitName = DR("UnitName"),
                        .Location = DR("Location"),
                        .Manufacturer = DR("Manufacturer"),
                        .ModelNo = DR("ModelNo"),
                        .SerialNo = DR("SerialNo"),
                        .DateAquired = DR("DateAquired"),
                        .IssuedTo = DR("IssuedTo"),
                        .IssuedToName = DR("IssuedToName"),
                        .DisposalDate = DR("DisposalDate"),
                        .DisposalAmt = DR("DisposalAmt"),
                        .UpdatedBy = DR("UpdatedBy"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .UpdatedLockedByBy = DR("LockedBy"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate"),
                        .Lock = DR("Lock"),
                        .RecordStatus = DR("RecordStatus")
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

    Function AMD020000_Get_Record_Dtl_Movement(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].IssueCode ")
        Query.Append("   ,[B].Type ")
        Query.Append("   ,format([B].IssueDate,'MM/dd/yyyy') [IssueDate] ")
        Query.Append("   ,(case when [B].Type in ('Return','Disposal') then '' else [C].fullname end) [IssueTo] ")
        Query.Append("   ,[A].Remarks ")
        Query.Append("from ")
        Query.Append("   Trxn_FAIDtl [A] ")
        Query.Append("   left join Trxn_FAIHdr [B] on [A].IssueCode = [B].IssueCode ")
        Query.Append("   left join employee [C] on [B].IssuedTo = [C].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].FACode = '" & pID & "' ")
        Query.Append("   and [B].Accept = 1 ")
        Query.Append("order by ")
        Query.Append("   [B].IssueDate ")
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
                    Action.Append("<button class='btn btn-sm btn-icon btn-light btn-active-light action-button' onclick=""window.open('AMD030100-DTL-" & DR("IssueCode") & "');return false;"" title='View'>")
                    Action.Append("   <i class='las la-search fs-3'></i>")
                    Action.Append("</button>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("IssueCode"),
                        .Action = Action.ToString,
                        .Type = DR("Type"),
                        .IssueDate = DR("IssueDate"),
                        .IssueTo = DR("IssueTo"),
                        .Remarks = DR("Remarks")
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

    Function AMD020000_Add_Record(pTblFrom, pTblCode, pDescription, pFAType, pStatus, pDivision, pBranch, pDepartment, pTagNo, pQty, pUnit, pLocation, pManufacturer, pModelNo, pSerialNo, pDateAquired, pDisposalDate, pDisposalAmt, pIssuedTo, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @ID nvarchar(13) ")
        Query.Append("exec New_Code 'Trxn_FixedAsset','MN',@ID output ")
        Query.Append("INSERT INTO Trxn_FixedAsset ")
        Query.Append("   (FACode ")
        Query.Append("   ,TblFrom ")
        Query.Append("   ,TblCode ")
        Query.Append("   ,Description ")
        Query.Append("   ,Type ")
        Query.Append("   ,Status ")
        Query.Append("   ,Division ")
        Query.Append("   ,Branch ")
        Query.Append("   ,Department ")
        Query.Append("   ,TagNo ")
        Query.Append("   ,Qty ")
        Query.Append("   ,Unit ")
        Query.Append("   ,Location ")
        Query.Append("   ,Manufacturer ")
        Query.Append("   ,ModelNo ")
        Query.Append("   ,SerialNo ")
        Query.Append("   ,DateAquired ")
        Query.Append("   ,DisposalDate ")
        Query.Append("   ,DisposalAmt ")
        Query.Append("   ,IssuedTo ")
        Query.Append("   ,CreatedBy ")
        Query.Append("   ,CreatedDate ")
        Query.Append("   ,UpdatedBy ")
        Query.Append("   ,UpdatedDate ")
        Query.Append("   ,LockedBy ")
        Query.Append("   ,LockedDate ")
        Query.Append("   ,Lock) ")
        Query.Append("VALUES ")
        Query.Append("   (@ID ")
        Query.Append("   ,'" & pTblFrom & "' ")
        Query.Append("   ,'" & pTblCode & "' ")
        Query.Append("   ,'" & pDescription & "' ")
        Query.Append("   ,'" & pFAType & "' ")
        Query.Append("   ,'" & pStatus & "' ")
        Query.Append("   ,'" & pDivision & "' ")
        Query.Append("   ,'" & pBranch & "' ")
        Query.Append("   ,'" & pDepartment & "' ")
        Query.Append("   ,'" & pTagNo & "' ")
        Query.Append("   ," & CDbl(pQty) & " ")
        Query.Append("   ,'" & pUnit & "' ")
        Query.Append("   ,'" & pLocation & "' ")
        Query.Append("   ,'" & pManufacturer & "' ")
        Query.Append("   ,'" & pModelNo & "' ")
        Query.Append("   ,'" & pSerialNo & "' ")
        Query.Append("   ," & IIf(pDateAquired = "", "NULL", "'" & pDateAquired & "'") & " ")
        Query.Append("   ," & IIf(pDisposalDate = "", "NULL", "'" & pDisposalDate & "'") & " ")
        Query.Append("   ," & CDbl(pDisposalAmt) & " ")
        Query.Append("   ,'" & pIssuedTo & "' ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,NULL ")
        Query.Append("   ,NULL ")
        Query.Append("   ,0) ")
        Query.Append("select @ID [oID] ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function AMD020000_Edit_Record(pID, pDescription, pFAType, pStatus, pDivision, pBranch, pDepartment, pTagNo, pQty, pUnit, pLocation, pManufacturer, pModelNo, pSerialNo, pDateAquired, pDisposalDate, pDisposalAmt, pIssuedTo, pUpdatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE Trxn_FixedAsset SET ")
        Query.Append("   Description = '" & pDescription & "' ")
        Query.Append("   ,Type = '" & pFAType & "' ")
        Query.Append("   ,Status = '" & pStatus & "' ")
        Query.Append("   ,Division = '" & pDivision & "' ")
        Query.Append("   ,Branch = '" & pBranch & "' ")
        Query.Append("   ,Department = '" & pDepartment & "' ")
        Query.Append("   ,TagNo = '" & pTagNo & "' ")
        Query.Append("   ,Qty = " & CDbl(pQty) & " ")
        Query.Append("   ,Unit = '" & pUnit & "' ")
        Query.Append("   ,Location = '" & pLocation & "' ")
        Query.Append("   ,Manufacturer = '" & pManufacturer & "' ")
        Query.Append("   ,ModelNo = '" & pModelNo & "' ")
        Query.Append("   ,SerialNo = '" & pSerialNo & "' ")
        Query.Append("   ,DateAquired = " & IIf(pDateAquired = "", "NULL", "'" & pDateAquired & "'") & " ")
        Query.Append("   ,DisposalDate = " & IIf(pDisposalDate = "", "NULL", "'" & pDisposalDate & "'") & " ")
        Query.Append("   ,DisposalAmt = " & CDbl(pDisposalAmt) & " ")
        Query.Append("   ,IssuedTo = '" & pIssuedTo & "' ")
        Query.Append("   ,UpdatedBy = '" & pUpdatedBy & "' ")
        Query.Append("   ,UpdatedDate = getdate() ")
        Query.Append("where ")
        Query.Append("   FACode = '" & pID & "' ")

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

                    RecordList.Add(New With {.oID = pID})

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

#End Region

#Region "AMD030000"

    Function AMD030000_Redraw_Hdr(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].IssueCode ")
        Query.Append("   ,[A].Lock ")
        Query.Append("   ,[A].IssueNo ")
        Query.Append("   ,format([A].IssueDate,'MM/dd/yyyy') [IssueDate] ")
        Query.Append("   ,[A].GPNo ")
        Query.Append("   ,[A].Status ")
        Query.Append("   ,[A].Type ")
        Query.Append("   ,[B].fullname [IssuedToName] ")
        Query.Append("   ,[A].Location ")
        Query.Append("from ")
        Query.Append("   Trxn_FAIHdr [A] ")
        Query.Append("   left join employee [B] on [A].IssuedTo = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].IssueCode = '" & pID & "' ")
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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AMD030100-DTL-" & DR("IssueCode") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("IssueCode") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("IssueCode") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("IssueCode") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("IssueCode"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .IssueNo = "<span title='" & DR("IssueNo") & "'>" & DR("IssueNo") & "</span>",
                        .IssueDate = "<span title='" & DR("IssueDate") & "'>" & DR("IssueDate") & "</span>",
                        .Status = "<span title='" & DR("Status") & "'>" & DR("Status") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .IssuedToName = "<span title='" & DR("IssuedToName") & "'>" & DR("IssuedToName") & "</span>",
                        .Location = "<span title='" & DR("Location") & "'>" & DR("Location") & "</span>"
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

    Function AMD030000_Get_Record_Hdr(pLock, pIssuedTo, pStatus)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("Get_FAIHdrList")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pLock", pLock)
                Cmd.Parameters.AddWithValue("@pIssuedTo", pIssuedTo)
                Cmd.Parameters.AddWithValue("@pStatus", pStatus)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('AMD030100-DTL-" & DR("IssueCode") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("IssueCode") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("IssueCode") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("IssueCode") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("IssueCode"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .IssueNo = "<span title='" & DR("IssueNo") & "'>" & DR("IssueNo") & "</span>",
                        .IssueDate = "<span title='" & DR("IssueDate") & "'>" & DR("IssueDate") & "</span>",
                        .Status = "<span title='" & DR("Status") & "'>" & DR("Status") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .IssuedToName = "<span title='" & DR("IssuedToName") & "'>" & DR("IssuedToName") & "</span>",
                        .Location = "<span title='" & DR("Location") & "'>" & DR("Location") & "</span>"
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

    Function AMD030000_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].IssueCode ")
        Query.Append("   ,[A].IssueNo ")
        Query.Append("   ,format([A].IssueDate,'MM/dd/yyyy') [IssueDate] ")
        Query.Append("   ,[A].Status ")
        Query.Append("   ,[A].Type ")
        Query.Append("   ,[A].IssuedTo ")
        Query.Append("   ,[D].fullname [IssuedToName] ")
        Query.Append("   ,[A].Location ")
        Query.Append("   ,[A].IssuedBy ")
        Query.Append("   ,[B].fullname [IssuedByName] ")
        Query.Append("   ,[A].GP ")
        Query.Append("   ,[A].GPNo ")
        Query.Append("   ,[A].AuthorizedBy ")
        Query.Append("   ,[C].fullname [AuthorizedByName] ")
        Query.Append("   ,[A].DeliverTo ")
        Query.Append("   ,[A].UpdatedBy ")
        Query.Append("   ,[F].fullname [UpdatedByName] ")
        Query.Append("   ,format([A].UpdatedDate,'MM/dd/yyyy hh:mm tt') [UpdatedDate] ")
        Query.Append("   ,[A].LockedBy ")
        Query.Append("   ,(case when isnull([A].Lock,0) = 1 then [G].fullname else '' end) [LockedByName] ")
        Query.Append("   ,(case when isnull([A].Lock,0) = 1 then format([A].LockedDate,'MM/dd/yyyy hh:mm tt') else '' end) [LockedDate] ")
        Query.Append("   ,[A].Lock ")
        Query.Append("   ,(case when [A].Accept = 1 then [A].Status when [A].Lock = 1 then 'Locked' when [A].Lock = 0 then 'New' end) [RecordStatus] ")
        Query.Append("from ")
        Query.Append("   Trxn_FAIHdr [A] ")
        Query.Append("   left join employee [B] on [A].IssuedBy = [B].emp_no ")
        Query.Append("   left join employee [C] on [A].AuthorizedBy = [C].emp_no ")
        Query.Append("   left join employee [D] on [A].IssuedTo = [D].emp_no ")
        Query.Append("   left join employee [E] on [A].CreatedBy = [E].emp_no ")
        Query.Append("   left join employee [F] on [A].UpdatedBy = [F].emp_no ")
        Query.Append("   left join employee [G] on [A].LockedBy = [G].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].IssueCode = '" & pID & "' ")
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
                        .IssueCode = DR("IssueCode"),
                        .IssueNo = DR("IssueNo"),
                        .IssueDate = DR("IssueDate"),
                        .Status = DR("Status"),
                        .Type = DR("Type"),
                        .IssuedTo = DR("IssuedTo"),
                        .IssuedToName = DR("IssuedToName"),
                        .Location = DR("Location"),
                        .IssuedBy = DR("IssuedBy"),
                        .IssuedByName = DR("IssuedByName"),
                        .GP = DR("GP"),
                        .GPNo = DR("GPNo"),
                        .AuthorizedBy = DR("AuthorizedBy"),
                        .AuthorizedByName = DR("AuthorizedByName"),
                        .DeliverTo = DR("DeliverTo"),
                        .UpdatedBy = DR("UpdatedBy"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .UpdatedLockedByBy = DR("LockedBy"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate"),
                        .Lock = DR("Lock"),
                        .RecordStatus = DR("RecordStatus")
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

    Function AMD030000_Add_Record(pIssuedType, pIssuedTo, pLocation, pIssuedBy, pGP, DeliverTo, AuthorizedBy, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @ID nvarchar(13) ")
        Query.Append("exec New_Code 'Trxn_FAIHdr(Code)','MN',@ID output ")
        Query.Append("INSERT INTO Trxn_FAIHdr ")
        Query.Append("   (IssueCode ")
        Query.Append("   ,IssueNo ")
        Query.Append("   ,IssueDate ")
        Query.Append("   ,Status ")
        Query.Append("   ,Type ")
        Query.Append("   ,IssuedTo ")
        Query.Append("   ,Location ")
        Query.Append("   ,IssuedBy ")
        Query.Append("   ,GP ")
        Query.Append("   ,GPNo ")
        Query.Append("   ,DeliverTo ")
        Query.Append("   ,AuthorizedBy ")
        Query.Append("   ,CreatedBy ")
        Query.Append("   ,CreatedDate ")
        Query.Append("   ,UpdatedBy ")
        Query.Append("   ,UpdatedDate ")
        Query.Append("   ,LockedBy ")
        Query.Append("   ,LockedDate ")
        Query.Append("   ,Lock ")
        Query.Append("   ,AcceptedBy ")
        Query.Append("   ,AcceptedDate ")
        Query.Append("   ,Accept) ")
        Query.Append("VALUES ")
        Query.Append("   (@ID ")
        Query.Append("   ,'' ")
        Query.Append("   ,NULL ")
        Query.Append("   ,'' ")
        Query.Append("   ,'" & pIssuedType & "' ")
        Query.Append("   ,'" & pIssuedTo & "' ")
        Query.Append("   ,'" & pLocation & "' ")
        Query.Append("   ,'" & pIssuedBy & "' ")
        Query.Append("   ," & pGP & " ")
        Query.Append("   ,'' ")
        Query.Append("   ,'" & DeliverTo & "' ")
        Query.Append("   ,'" & AuthorizedBy & "' ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'' ")
        Query.Append("   ,NULL ")
        Query.Append("   ,0 ")
        Query.Append("   ,'' ")
        Query.Append("   ,NULL ")
        Query.Append("   ,0) ")
        Query.Append("select @ID [oID] ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function AMD030000_Edit_Record(pID, pIssuedType, pIssuedTo, pLocation, pIssuedBy, pGP, DeliverTo, AuthorizedBy, pUpdatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("UPDATE Trxn_FAIHdr SET ")
        Query.Append("   Type = '" & pIssuedType & "' ")
        Query.Append("   ,IssuedTo = '" & pIssuedTo & "' ")
        Query.Append("   ,Location = '" & pLocation & "' ")
        Query.Append("   ,IssuedBy = '" & pIssuedBy & "' ")
        Query.Append("   ,GP = " & pGP & " ")
        Query.Append("   ,DeliverTo = '" & DeliverTo & "' ")
        Query.Append("   ,AuthorizedBy = '" & AuthorizedBy & "' ")
        Query.Append("   ,UpdatedBy = '" & pUpdatedBy & "' ")
        Query.Append("   ,UpdatedDate = getdate() ")
        Query.Append("where ")
        Query.Append("   IssueCode = '" & pID & "' ")

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

                    RecordList.Add(New With {.oID = pID})

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

    Function AMD030000_Redraw_Dtl_Asset(pIssueCode, pFACode)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].IssueCode ")
        Query.Append("   ,[A].SeqNo ")
        Query.Append("   ,[A].FACode ")
        Query.Append("   ,[B].Description ")
        Query.Append("   ,[B].TagNo ")
        Query.Append("   ,[B].Qty ")
        Query.Append("   ,[C].abbr [Unit] ")
        Query.Append("   ,format([A].DisposalAmt,'N2') [DisposalAmt] ")
        Query.Append("   ,[A].Remarks ")
        Query.Append("from ")
        Query.Append("   Trxn_FAIDtl [A] ")
        Query.Append("   left join Trxn_FixedAsset [B] on [A].FACode = [B].FACode ")
        Query.Append("   left join sys_um [C] on [B].Unit = [C].u_code ")
        Query.Append("where ")
        Query.Append("   [A].IssueCode = '" & pIssueCode & "' ")
        Query.Append("   and [A].FACode = '" & pFACode & "' ")
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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & DR("IssueCode") & "','" & DR("FACode") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("FACode"),
                        .Action = Action.ToString,
                        .FACode = "<span title='" & DR("FACode") & "'>" & DR("FACode") & "</span>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>",
                        .Qty = "<span title='" & DR("Qty") & "'>" & DR("Qty") & "</span>",
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .TagNo = "<span title='" & DR("TagNo") & "'>" & DR("TagNo") & "</span>",
                        .DisposalAmt = "<span title='" & DR("DisposalAmt") & "'>" & DR("DisposalAmt") & "</span>",
                        .Remarks = "<span title='" & DR("Remarks") & "'>" & DR("Remarks") & "</span>"
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

    Function AMD030000_Get_Record_Dtl_Asset_Hdr(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].IssueCode ")
        Query.Append("   ,[A].SeqNo ")
        Query.Append("   ,[A].FACode ")
        Query.Append("   ,[B].Description ")
        Query.Append("   ,[B].TagNo ")
        Query.Append("   ,format([B].Qty,'N2') [Qty] ")
        Query.Append("   ,[C].abbr [Unit] ")
        Query.Append("   ,format([A].DisposalAmt,'N2') [DisposalAmt] ")
        Query.Append("   ,[A].Remarks ")
        Query.Append("from ")
        Query.Append("   Trxn_FAIDtl [A] ")
        Query.Append("   left join Trxn_FixedAsset [B] on [A].FACode = [B].FACode ")
        Query.Append("   left join sys_um [C] on [B].Unit = [C].u_code ")
        Query.Append("where ")
        Query.Append("   [A].IssueCode = '" & pID & "' ")
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
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & DR("IssueCode") & "','" & DR("FACode") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("FACode"),
                        .Action = Action.ToString,
                        .FACode = "<span title='" & DR("FACode") & "'>" & DR("FACode") & "</span>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>",
                        .Qty = "<span title='" & DR("Qty") & "'>" & DR("Qty") & "</span>",
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .TagNo = "<span title='" & DR("TagNo") & "'>" & DR("TagNo") & "</span>",
                        .DisposalAmt = "<span title='" & DR("DisposalAmt") & "'>" & DR("DisposalAmt") & "</span>",
                        .Remarks = "<span title='" & DR("Remarks") & "'>" & DR("Remarks") & "</span>"
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

    Function AMD030000_Get_Record_Dtl_Asset_Dtl(pIssueCode, pIssuedType)

        'query
        Dim Query01 As New StringBuilder
        Query01.Append("select ")
        Query01.Append("   '" & pIssueCode & "' [IssueCode] ")
        Query01.Append("   ,[A].[FACode] ")
        Query01.Append("   ,[A].Description ")
        Query01.Append("   ,format([A].Qty,'N2') [Qty] ")
        Query01.Append("   ,[B].abbr [Unit] ")
        Query01.Append("   ,[A].TagNo ")
        Query01.Append("   ,0.00 [DisposalAmt] ")
        Query01.Append("   ,'' [Remarks] ")
        Query01.Append("from ")
        Query01.Append("   Trxn_FixedAsset [A] ")
        Query01.Append("   left join sys_um [B] on [A].Unit = [B].u_code ")
        Query01.Append("where ")
        Query01.Append("   [A].Lock = 1 ")
        Query01.Append("   and isnull([A].IssuedTo,'') = '' ")
        Query01.Append("   and [A].FACode not in (select [C].FACode from Trxn_FAIDtl [C] left join Trxn_FAIHdr [D] on [C].IssueCode = [D].IssueCode and [D].Lock = 0) ")
        Dim Query02 As New StringBuilder
        Query02.Append("select ")
        Query02.Append("   [A].IssueCode ")
        Query02.Append("   ,[A].FACode ")
        Query02.Append("   ,[B].Description ")
        Query02.Append("   ,format([B].Qty,'N2') [Qty] ")
        Query02.Append("   ,[C].abbr [Unit] ")
        Query02.Append("   ,[B].TagNo ")
        Query02.Append("   ,format([A].DisposalAmt,'N2') [DisposalAmt] ")
        Query02.Append("   ,[A].Remarks ")
        Query02.Append("from ")
        Query02.Append("   Trxn_FAIDtl [A] ")
        Query02.Append("   left join Trxn_FixedAsset [B] on [A].FACode = [B].FACode ")
        Query02.Append("   left join sys_um [C] on [B].Unit = [C].u_code ")
        Query02.Append("where ")
        Query02.Append("   [A].IssueCode = '" & pIssueCode & "' ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query01.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .FACode = "<span title='" & DR("FACode") & "'>" & DR("FACode") & "</span>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>",
                        .Qty = "<span title='" & DR("Qty") & "'>" & DR("Qty") & "</span>",
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .TagNo = "<span title='" & DR("TagNo") & "'>" & DR("TagNo") & "</span>",
                        .DisposalAmt = "<input type='text' class='w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300' prm010201disposalamt='" & DR("FACode") & "' onkeypress='return fnEnterKey(event,this)' onblur='fnFormatNumeric(this)' " & IIf(pIssuedType = "Disposal", "", "readonly") & " maxlength='21' value='0.00'/>",
                        .Remarks = "<input type='text' class='w-100 outline-none text-start border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300' prm010201remarks='" & DR("FACode") & "' maxlength='1000' value=''/>",
                        .Action = "<div class='d-flex justify-content-center flex-shrink-0'><button id='" & DR("FACode") & "' class='btn btn-sm btn-add w-100 receive' onclick="" fn010201Add_Ok('" & DR("IssueCode") & "','" & DR("FACode") & "',this);return false""><span id='spn010201Add" & DR("FACode") & "' class='indicator-label'>Add</span><span class='indicator-progress'>Saving</span></button></div>"
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query02.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    RecordList.Add(New With {
                        .FACode = "<span title='" & DR("FACode") & "'>" & DR("FACode") & "</span>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>",
                        .Qty = "<span title='" & DR("Qty") & "'>" & DR("Qty") & "</span>",
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .TagNo = "<span title='" & DR("TagNo") & "'>" & DR("TagNo") & "</span>",
                        .DisposalAmt = "<input type='text' class='w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300' prm010201disposalamt='" & DR("FACode") & "' onkeypress='return fnEnterKey(event,this)' onblur='fnFormatNumeric(this)' " & IIf(pIssuedType = "Disposal", "", "readonly") & " maxlength='21' value='0.00'/>",
                        .Remarks = "<input type='text' class='w-100 outline-none text-start border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300' prm010201remarks='" & DR("FACode") & "' maxlength='1000' value=''/>",
                        .Action = "<div class='d-flex justify-content-center flex-shrink-0'><button id='" & DR("FACode") & "' class='btn btn-sm btn-add w-100 receive' onclick="" fn010201Add_Ok('" & DR("IssueCode") & "','" & DR("FACode") & "',this);return false""><span id='spn010201Add" & DR("FACode") & "' class='indicator-label'>Update</span><span class='indicator-progress'>Saving</span></button></div>"
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

    Function AMD030000_Add_Record_Dtl_Asset(pIssueCode, pFACode, pDisposalAmt, pRemarks, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @SeqNo int = isnull((select max(SeqNo) from Trxn_FAIDtl where IssueCode = '" & pIssueCode & "'),0) + 1 ")

        Query.Append("if '" & pFACode & "' not in (select FACode from Trxn_FAIDtl where IssueCode = '" & pIssueCode & "') ")
        Query.Append("begin ")
        Query.Append("   INSERT INTO Trxn_FAIDtl ")
        Query.Append("      (IssueCode ")
        Query.Append("      ,SeqNo ")
        Query.Append("      ,FACode ")
        Query.Append("      ,DisposalAmt ")
        Query.Append("      ,Remarks ")
        Query.Append("      ,CreatedBy ")
        Query.Append("      ,CreatedDate ")
        Query.Append("      ,UpdatedBy ")
        Query.Append("      ,UpdatedDate) ")
        Query.Append("   VALUES ")
        Query.Append("      ('" & pIssueCode & "'")
        Query.Append("      ,@SeqNo ")
        Query.Append("      ,'" & pFACode & "' ")
        Query.Append("      ," & CDbl(pDisposalAmt) & " ")
        Query.Append("      ,'" & pRemarks & "' ")
        Query.Append("      ,'" & pCreatedBy & "' ")
        Query.Append("      ,getdate() ")
        Query.Append("      ,'" & pCreatedBy & "' ")
        Query.Append("      ,getdate()) ")
        Query.Append("   select 'Add' [oAction] ")
        Query.Append("end ")
        Query.Append("begin ")
        Query.Append("   update Trxn_FAIDtl set ")
        Query.Append("      DisposalAmt = " & CDbl(pDisposalAmt) & " ")
        Query.Append("      ,Remarks = '" & pRemarks & "' ")
        Query.Append("      ,UpdatedBy = '" & pCreatedBy & "' ")
        Query.Append("      ,UpdatedDate = getdate() ")
        Query.Append("   where ")
        Query.Append("      IssueCode = '" & pIssueCode & "'")
        Query.Append("      and FACode = '" & pFACode & "' ")
        Query.Append("   select 'Edit' [oAction] ")
        Query.Append("end ")

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

                    RecordList.Add(New With {.oAction = DR("oAction")})

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

#End Region

End Class