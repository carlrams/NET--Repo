Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports Microsoft.Reporting.WebForms
Imports System.Security.Cryptography
Imports OfficeOpenXml.Drawing.Slicer.Style
Imports System.Drawing.Drawing2D
Imports Newtonsoft.Json
Imports Microsoft.Ajax.Utilities
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Interop
Imports System.Data.SqlTypes
Imports Microsoft.Reporting.Map.WebForms.VirtualEarth
Imports System.Web.Services.Description
Imports System.EnterpriseServices
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class FRM000049HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim catalogdb As String = "calmardbLive"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"
    Private oFCodeValue As String
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

            'GetName
            If pFunction = "Get-CIIS-Name" Then

                Dim json As String = Me.Get_CIIS_Name()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'GetName

            'Details
            If pFunction = "Get-Info-0101" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Info_0101(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Edit-Record-Info-02" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Edit_Record_Info_02(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Save-New-Record-0201" Then

                Dim pDateRequired = context.Request("pDateRequired")
                Dim pGPDate = context.Request("pGPDate")
                Dim pIssuedTo = context.Request("pIssuedTo")
                Dim pDept = context.Request("pDept")
                Dim pSite = context.Request("pSite")
                Dim pLocation = context.Request("pLocation")
                Dim pPurpose = context.Request("pPurpose")
                Dim pNote = context.Request("pNote")

                Dim json As String = Me.Save_New_Record_0201(pDateRequired, pGPDate, pIssuedTo, pDept, pSite, pLocation, pPurpose, pNote)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-New-Record-0201" Then

                Dim pFrmCode = context.Request("pFrmCode")
                Dim pID = context.Request("pID")

                Dim pDateRequired = context.Request("pDateRequired")
                Dim pGPDate = context.Request("pGPDate")
                Dim pIssuedTo = context.Request("pIssuedTo")
                Dim pDept = context.Request("pDept")
                Dim pSite = context.Request("pSite")
                Dim pLocation = context.Request("pLocation")
                Dim pPurpose = context.Request("pPurpose")
                Dim pNote = context.Request("pNote")

                Dim json As String = Me.Update_New_Record_0201(pFrmCode, pID, pDateRequired, pGPDate, pIssuedTo, pDept, pSite, pLocation, pPurpose, pNote)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If
            'Details

            'Particular
            If pFunction = "Get-Particular-11" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Load_Particular_11(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Get-Info-03" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Load_Particular_Dtl_11(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Add-Record-03" Then

                Dim pFrmCode = context.Request("pFrmCode")
                Dim pID = context.Request("pID")
                Dim pPart = context.Request("pPart")
                Dim pQty = context.Request("pQty")
                Dim pUom = context.Request("pUom")
                Dim pTagNo = context.Request("pTagNo")
                Dim pLoc = context.Request("pLoc")
                Dim pReturn = context.Request("pReturn")
                Dim pDateReturn = context.Request("pDateReturn")

                Dim json As String = Me.Save_New_Record_11(pFrmCode, pID, pPart, pQty, pUom, pTagNo, pLoc, pReturn, pDateReturn)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-Record-03" Then

                Dim pFrmCode = context.Request("pFrmCode")
                Dim pID = context.Request("pID")
                Dim pDtlCode = context.Request("pDtlCode")
                Dim pPart = context.Request("pPart")
                Dim pQty = context.Request("pQty")
                Dim pUom = context.Request("pUom")
                Dim pTagNo = context.Request("pTagNo")
                Dim pLoc = context.Request("pLoc")
                Dim pReturn = context.Request("pReturn")
                Dim pDateReturn = context.Request("pDateReturn")

                Dim json As String = Me.Update_New_Record_11(pFrmCode, pID, pDtlCode, pPart, pQty, pUom, pTagNo, pLoc, pReturn, pDateReturn)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Delete-Record-03" Then

                Dim pFrmCode = context.Request("pFrmCode")
                Dim pID = context.Request("pTblName")
                Dim pTblCode = context.Request("pTblCode")

                Dim json As String = Me.Delete_Record_11(pFrmCode, pID, pTblCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If
            'Particular

            'Report and Dropdown
            If pFunction = "Get-Record-03-List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pAprType = context.Request("pAprType")
                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record(pTblName, pPlaceHolder, pFrmCode, pAprType, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Generate-Report-0101" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Generate_Report_1010(pID, context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If
            'Report and Dropdown

            'Validate
            If pFunction = "Validate" Then

                Dim pID = context.Request("pID")
                Dim Group = context.Request("Group")
                Dim Type = context.Request("Type")
                Dim Value = context.Request("Value")

                Dim json As String = Me.Validate(pID, Group, Type, Value)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Validate

            'Find Record
            If pFunction = "Find-Record" Then

                Dim json As String = Me.Find_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Find Record

            'Approval Path
            If pFunction = "Get-Record-989" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Load_Approval_path(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Delete-Record-989" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.Delete_Approval_path(pID, pFrmCode, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Move-Record-989" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pAction = context.Request("pAction")

                Dim json As String = Me.Move_Approval_path(pID, pFrmCode, pSeqNo, pAction)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Save-Record-989" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pReason = context.Request("pReason")

                Dim json As String = Me.Save_Approval_path(pID, pFrmCode, pSeqNo, pReason)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)


            ElseIf pFunction = "Save-New-Record-989" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pTypeApr = context.Request("pTypeApr")
                Dim pApprover = context.Request("pApprover")
                Dim pNoDays = context.Request("pNoDays")
                Dim pTemplate = context.Request("pTemplate")
                Dim pAddForm = context.Request("pAddForm")

                Dim json As String = Me.Save_New_Approval_path(pID, pFrmCode, pTypeApr, pApprover, pNoDays, pTemplate, pAddForm)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Save-New-Open-Record-989" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pTemplate = context.Request("pTemplate")
                Dim pSeqNo = context.Request("pSeqNo")

                Dim json As String = Me.Save_New_Open_Approval_path(pID, pFrmCode, pTemplate, pSeqNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Approval Path

            'Subscriber
            If pFunction = "Get-Record-03010101" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Load_Subscriber(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Save-New-Record-03010101" Then

                Dim pFrmCode = context.Request("pFrmCode")
                Dim pID = context.Request("pID")
                Dim pUser = context.Request("pUser")

                Dim json As String = Me.Save_New_Subscriber(pFrmCode, pID, pUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Delete-Record-03010101" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pUser = context.Request("pUser")

                Dim json As String = Me.Delete_Subscriber(pID, pFrmCode, pUser)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Subscriber

            'History
            If pFunction = "Get-Record-04010101" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")

                Dim json As String = Me.Load_History(pID, pFrmCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'History

            'Status
            If pFunction = "Update-Record-Status-88" Then
                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pStatus = context.Request("pStatus")
                Dim pAssignto = context.Request("pAssignto")
                Dim pRemarks = context.Request("pRemarks")
                Dim pMention = context.Request("pMention")

                Dim json As String = Me.Update_Record_Status(pID, pFrmCode, pStatus, pAssignto, pRemarks, pMention)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Status

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#Region "Ciis_EmpName"
    Function Get_CIIS_Name()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	(case when isnull(dbo.ProperCase([E].first_name) + ' ' +  ")
        Query.Append("	dbo.ProperCase([E].last_name),'') = '' then '-' else  ")
        Query.Append("	isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [Name]  ")
        Query.Append("from  ")
        Query.Append("	employee [E] ")
        Query.Append("where ")
        Query.Append("	emp_no = '" & CIIS_EmpCode & "' ")
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
                    .Name = If(IsDBNull(DR("Name")), "", DR("Name"))
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

#Region "Header"
    Function Get_Info_0101(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("    [A].f_code [ID]  ")
        Query.Append("    ,FORMAT([A].created_date, 'MM/dd/yyyy') [DateCreated]  ")
        Query.Append("    ,FORMAT([A].date_required, 'MM/dd/yyyy') [DateRequired]  ")
        Query.Append("    ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy]  ")
        Query.Append("    ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo]  ")
        Query.Append("    ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo]  ")
        Query.Append("    ,[A].status [Status]  ")
        Query.Append("    ,[B].GPDate ")
        Query.Append("    ,(case when isnull(dbo.ProperCase([F].first_name) + ' ' + dbo.ProperCase([F].last_name),'') = '' then '-' else isnull(dbo.ProperCase([F].first_name) + ' ' + dbo.ProperCase([F].last_name),'') end) [IssuedTo] ")
        Query.Append("    ,[G].description   ")
        Query.Append("    ,[B].Site ")
        Query.Append("	,[B].Location ")
        Query.Append("	,[B].Purpose ")
        Query.Append("	,[B].Notes ")
        Query.Append("    ,[A].formtitle [Title]  ")
        Query.Append("from  ")
        Query.Append("    oop_form_hdr [A]  ")
        Query.Append("    left join form_gatepass_hdr [B] On [A].tbl_code = [B].GPCode  ")
        Query.Append("    left join employee [C] On [A].created_by = [C].emp_no  ")
        Query.Append("    left join employee [D] On [A].approver = [D].emp_no  ")
        Query.Append("    left join employee [E] On [A].EndorsedTo = [E].emp_no  ")
        Query.Append("    left join employee [F] on [B].IssuedTo = [F].emp_no ")
        Query.Append("    left join department [G] on [B].Department = [G].dept_code ")
        Query.Append("where  ")
        Query.Append("    [A].f_code = '" & pID & "' ")
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
                    .ID = If(IsDBNull(DR("ID")), "-", DR("ID")),
                    .FormType = "Gate Pass",
                    .DateCreated = If(IsDBNull(DR("DateCreated")), "-", Convert.ToDateTime(DR("DateCreated")).ToString("MM/dd/yyyy")),
                    .DateRequired = If(IsDBNull(DR("DateRequired")), "-", Convert.ToDateTime(DR("DateRequired")).ToString("MM/dd/yyyy")),
                    .RequestedBy = If(IsDBNull(DR("RequestedBy")), "-", DR("RequestedBy")),
                    .AssignedTo = If(IsDBNull(DR("AssignedTo")), "-", DR("AssignedTo")),
                    .EndorsedTo = If(IsDBNull(DR("EndorsedTo")), "-", DR("EndorsedTo")),
                    .Status = If(IsDBNull(DR("Status")), "-", DR("Status")),
                    .GPDate = If(IsDBNull(DR("GPDate")), "-", Convert.ToDateTime(DR("GPDate")).ToString("MM/dd/yyyy")),
                    .IssuedTo = If(IsDBNull(DR("IssuedTo")), "-", DR("IssuedTo")),
                    .Dept = If(IsDBNull(DR("description")), "-", DR("description")),
                    .Site = If(IsDBNull(DR("Site")), "-", DR("Site")),
                    .Location = If(IsDBNull(DR("Location")), "-", DR("Location")),
                    .Purpose = If(IsDBNull(DR("Purpose")), "-", DR("Purpose")),
                    .Note = If(IsDBNull(DR("Notes")), "-", DR("Notes")),
                    .Title = If(IsDBNull(DR("Title")), "-", DR("Title"))
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
    Function Edit_Record_Info_02(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("    [A].f_code [ID]  ")
        Query.Append("    ,FORMAT([A].created_date, 'MM/dd/yyyy') [DateCreated]  ")
        Query.Append("    ,FORMAT([A].date_required, 'MM/dd/yyyy') [DateRequired]  ")
        Query.Append("    ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy]  ")
        Query.Append("    ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo]  ")
        Query.Append("    ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo]  ")
        Query.Append("    ,[A].status [Status]  ")
        Query.Append("    ,[B].GPDate ")
        Query.Append("    ,[B].IssuedTo [IssuedTo] ")
        Query.Append("    ,[B].Department   ")
        Query.Append("    ,[B].Site ")
        Query.Append("	,[B].Location ")
        Query.Append("	,[B].Purpose ")
        Query.Append("	,[B].Notes ")
        Query.Append("    ,[A].formtitle [Title]  ")
        Query.Append("from  ")
        Query.Append("    oop_form_hdr [A]  ")
        Query.Append("    left join form_gatepass_hdr [B] On [A].tbl_code = [B].GPCode  ")
        Query.Append("    left join employee [C] On [A].created_by = [C].emp_no  ")
        Query.Append("    left join employee [D] On [A].approver = [D].emp_no  ")
        Query.Append("    left join employee [E] On [A].EndorsedTo = [E].emp_no  ")
        Query.Append("    left join employee [F] on [B].IssuedTo = [F].emp_no ")
        Query.Append("    left join department [G] on [B].Department = [G].dept_code ")
        Query.Append("where  ")
        Query.Append("    [A].f_code = '" & pID & "' ")
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
                    .ID = If(IsDBNull(DR("ID")), "-", DR("ID")),
                    .FormType = "Gate Pass",
                    .DateCreated = If(IsDBNull(DR("DateCreated")), "-", Convert.ToDateTime(DR("DateCreated")).ToString("MM/dd/yyyy")),
                    .DateRequired = If(IsDBNull(DR("DateRequired")), "-", Convert.ToDateTime(DR("DateRequired")).ToString("MM/dd/yyyy")),
                    .RequestedBy = If(IsDBNull(DR("RequestedBy")), "-", DR("RequestedBy")),
                    .AssignedTo = If(IsDBNull(DR("AssignedTo")), "-", DR("AssignedTo")),
                    .EndorsedTo = If(IsDBNull(DR("EndorsedTo")), "-", DR("EndorsedTo")),
                    .Status = If(IsDBNull(DR("Status")), "-", DR("Status")),
                    .GPDate = If(IsDBNull(DR("GPDate")), "-", Convert.ToDateTime(DR("GPDate")).ToString("MM/dd/yyyy")),
                    .IssuedTo = If(IsDBNull(DR("IssuedTo")), "-", DR("IssuedTo")),
                    .Dept = If(IsDBNull(DR("Department")), "-", DR("Department")),
                    .Site = If(IsDBNull(DR("Site")), "-", DR("Site")),
                    .Location = If(IsDBNull(DR("Location")), "-", DR("Location")),
                    .Purpose = If(IsDBNull(DR("Purpose")), "-", DR("Purpose")),
                    .Note = If(IsDBNull(DR("Notes")), "-", DR("Notes")),
                    .Title = If(IsDBNull(DR("Title")), "-", DR("Title"))
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
    Private Function ToSafeInt(val As Object) As Integer
        If val Is Nothing OrElse val Is DBNull.Value Then Return 0

        Dim dec As Decimal
        If Decimal.TryParse(val.ToString(), dec) Then
            Return Convert.ToInt32(dec)
        Else
            Return 0
        End If
    End Function
    Function Save_New_Record_0201(pDateRequired, pGPDate, pIssuedTo, pDept, pSite, pLocation, pPurpose, pNote)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("New_FRM_FRM000049", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pDateRequired", pDateRequired)

                    SqlCmd.Parameters.AddWithValue("@pGPDate", pGPDate)
                    SqlCmd.Parameters.AddWithValue("@pIssuedTo", pIssuedTo)
                    SqlCmd.Parameters.AddWithValue("@pDept", pDept)
                    SqlCmd.Parameters.AddWithValue("@pSite", pSite)
                    SqlCmd.Parameters.AddWithValue("@pLocation", pLocation)
                    SqlCmd.Parameters.AddWithValue("@pPurpose", pPurpose)
                    SqlCmd.Parameters.AddWithValue("@pNote", pNote)

                    SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)

                    Dim oFCode As New SqlClient.SqlParameter("@oFCode", SqlDbType.NVarChar, 1000)
                    oFCode.Direction = ParameterDirection.Output
                    SqlCmd.Parameters.Add(oFCode)

                    SqlCmd.ExecuteNonQuery()

                    oFCodeValue = oFCode.Value.ToString()
                End Using
            End Using

            result("oReturn") = oFCodeValue
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
    Function Update_New_Record_0201(pFrmCode, pID, pDateRequired, pGPDate, pIssuedTo, pDept, pSite, pLocation, pPurpose, pNote)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Upd_FRM_FRM000049", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)

                    SqlCmd.Parameters.AddWithValue("@pDateRequired", pDateRequired)
                    SqlCmd.Parameters.AddWithValue("@pGPDate", pGPDate)
                    SqlCmd.Parameters.AddWithValue("@pIssuedTo", pIssuedTo)

                    SqlCmd.Parameters.AddWithValue("@pDept", pDept)
                    SqlCmd.Parameters.AddWithValue("@pSite", pSite)
                    SqlCmd.Parameters.AddWithValue("@pLocation", pLocation)
                    SqlCmd.Parameters.AddWithValue("@pPurpose", pPurpose)
                    SqlCmd.Parameters.AddWithValue("@pNote", pNote)

                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)

                    SqlCmd.ExecuteNonQuery()

                End Using
            End Using

            result("oReturn") = oFCodeValue
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

#End Region

#Region "Particular"
    Function Load_Particular_11(pID As String)

        'query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("    [A].GPCode  ")
        Query.Append("    ,[A].DtlCode  ")
        Query.Append("    ,[A].Particular  ")
        Query.Append("    ,[A].Qty  ")
        Query.Append("    ,[C].abbr [Unit] ")
        Query.Append("    ,[A].TagNumber  ")
        Query.Append("    ,[A].Location [Loc]  ")
        Query.Append("    ,[A].IsReturnable  ")
        Query.Append("    ,[A].DateReturn  ")
        Query.Append("From   ")
        Query.Append("    Form_Gatepass_Dtl [A]  ")
        Query.Append("	  left join oop_form_hdr [B] on [A].GPCode = [B].tbl_code ")
        Query.Append("	  left join sys_um [C] on [A].Unit = [C].u_code ")
        Query.Append("Where  ")
        Query.Append("    [B].f_code = '" & pID & "'  ")
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

                    Dim Action As New StringBuilder()
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn11View('DTL','" & DR("DtlCode") & "');$('#mdl03View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn11Delete('DTL','" & DR("DtlCode") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn11Edit('UPD','" & DR("DtlCode") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    Dim isReturnableValue As String = If(DR("IsReturnable").ToString() = "1", "Yes", "No")

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .GPCode = DR("GPCode"),
                        .DtlCode = DR("DtlCode"),
                        .Particular = "<span title='" & DR("Particular") & "'>" & DR("Particular") & "</span>",
                        .Qty = If(IsDBNull(DR("Qty")), "0.00", Convert.ToDecimal(DR("Qty")).ToString("N2")),
                        .Unit = "<span title='" & DR("Unit") & "'>" & DR("Unit") & "</span>",
                        .TagNumber = "<span title='" & DR("TagNumber") & "'>" & DR("TagNumber") & "</span>",
                        .Loc = "<span title='" & DR("Loc") & "'>" & DR("Loc") & "</span>",
                        .IsReturnable = "<span title='" & isReturnableValue & "'>" & isReturnableValue & "</span>",
                        .DateReturn = If(IsDBNull(DR("DateReturn")), "-", Convert.ToDateTime(DR("DateReturn")).ToString("MM/dd/yyyy"))
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
    Function Load_Particular_Dtl_11(pID As String)

        'query
        Dim Query As New StringBuilder
        Query.Append("Select ")
        Query.Append("    [A].GPCode  ")
        Query.Append("    ,[A].DtlCode  ")
        Query.Append("    ,[A].Particular  ")
        Query.Append("    ,[A].Qty  ")
        Query.Append("    ,[C].abbr [Unit] ")
        Query.Append("    ,[A].Unit [UnitCode] ")
        Query.Append("    ,[A].TagNumber  ")
        Query.Append("    ,[A].Location [Loc]  ")
        Query.Append("    ,[A].IsReturnable  ")
        Query.Append("    ,[A].DateReturn  ")
        Query.Append("From   ")
        Query.Append("    Form_Gatepass_Dtl [A]  ")
        Query.Append("	  left join oop_form_hdr [B] on [A].GPCode = [B].tbl_code ")
        Query.Append("	  left join sys_um [C] on [A].Unit = [C].u_code ")
        Query.Append("Where  ")
        Query.Append("    [A].DtlCode = '" & pID & "'  ")
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


                    Dim isReturnableValue As String = If(DR("IsReturnable").ToString() = "1", "Yes", "No")

                    RecordList.Add(New With {
                        .GPCode = DR("GPCode"),
                        .DtlCode = DR("DtlCode"),
                        .Particular = DR("Particular"),
                        .Qty = If(IsDBNull(DR("Qty")), "0.00", Convert.ToDecimal(DR("Qty")).ToString("N2")),
                        .Unit = DR("Unit"),
                        .UnitCode = DR("UnitCode"),
                        .TagNumber = DR("TagNumber"),
                        .Loc = DR("Loc"),
                        .IsReturnable = isReturnableValue,
                        .DateReturn = If(IsDBNull(DR("DateReturn")), "-", Convert.ToDateTime(DR("DateReturn")).ToString("MM/dd/yyyy"))
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
    Function Save_New_Record_11(pFrmCode, pID, pPart, pQty, pUom, pTagNo, pLoc, pReturn, pDateReturn)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("New_FRM_FRM000049_GPDtl", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)

                    SqlCmd.Parameters.AddWithValue("@pPart", pPart)
                    SqlCmd.Parameters.AddWithValue("@pQty", pQty)
                    SqlCmd.Parameters.AddWithValue("@pUom", pUom)
                    SqlCmd.Parameters.AddWithValue("@pTagNo", pTagNo)
                    SqlCmd.Parameters.AddWithValue("@pLoc", pLoc)
                    SqlCmd.Parameters.AddWithValue("@pReturn", pReturn)
                    SqlCmd.Parameters.AddWithValue("@pDateReturn", pDateReturn)

                    SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)

                    Dim oFCode As New SqlClient.SqlParameter("@oFCode", SqlDbType.NVarChar, 1000)
                    oFCode.Direction = ParameterDirection.Output
                    SqlCmd.Parameters.Add(oFCode)

                    SqlCmd.ExecuteNonQuery()

                    oFCodeValue = oFCode.Value.ToString()
                End Using
            End Using

            result("oReturn") = oFCodeValue
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
    Function Update_New_Record_11(pFrmCode, pID, pDtlCode, pPart, pQty, pUom, pTagNo, pLoc, pReturn, pDateReturn)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Upd_FRM_FRM000049_GPDtl", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)

                    SqlCmd.Parameters.AddWithValue("@DtlCode", pDtlCode)
                    SqlCmd.Parameters.AddWithValue("@pPart", pPart)
                    SqlCmd.Parameters.AddWithValue("@pQty", pQty)
                    SqlCmd.Parameters.AddWithValue("@pUom", pUom)
                    SqlCmd.Parameters.AddWithValue("@pTagNo", pTagNo)
                    SqlCmd.Parameters.AddWithValue("@pLoc", pLoc)
                    SqlCmd.Parameters.AddWithValue("@pReturn", pReturn)
                    SqlCmd.Parameters.AddWithValue("@pDateReturn", pDateReturn)

                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)

                    SqlCmd.ExecuteNonQuery()

                End Using
            End Using

            result("oReturn") = oFCodeValue
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
    Function Delete_Record_11(pFrmCode, pID, pTblCode)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Del_FRM_FRM000049_GPDtl", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pSeqNo", pTblCode)
                    SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)

                    SqlCmd.ExecuteNonQuery()

                End Using
            End Using

            result("oReturn") = "Success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

#End Region

#Region "Report and Dropdown"
    Function Get_Record(pTblName, pPlaceHolder, pFrmCode, pAprType, pID)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Approver" Then
            Query.Append("if '" & pFrmCode & "' not in (select oop_form_type.FormCode from oop_form_appr left join oop_form_type on oop_form_appr.form_type = oop_form_type.t_code where oop_form_type.FormCode = '" & pFrmCode & "' and oop_form_appr.type = '" & pAprType & "') ")
            Query.Append("begin ")
            Query.Append("   select")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("      ,'' [Order] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      [A].emp_no [Code] ")
            Query.Append("      ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
            Query.Append("      ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
            Query.Append("   from ")
            Query.Append("      employee [A] ")
            Query.Append("   where ")
            Query.Append("      [A].emp_status in ('Contractual','Probationary','Regular') ")
            Query.Append("      and [A].lock = 1 ")
            Query.Append("   order by ")
            Query.Append("      [Order] ")
            Query.Append("end ")
            Query.Append("else ")
            Query.Append("begin ")
            Query.Append("   select")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'" & pPlaceHolder & "'[Name] ")
            Query.Append("      ,'' [Order] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      [A].approver [Code] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
            Query.Append("   from ")
            Query.Append("      oop_form_appr [A] ")
            Query.Append("      left join employee [B] on [A].approver = [B].emp_no ")
            Query.Append("      left join oop_form_type [C] on [A].form_type = [C].t_code ")
            Query.Append("   where ")
            Query.Append("      [C].FormCode = '" & pFrmCode & "' ")
            Query.Append("      and [A].type = '" & pAprType & "' ")
            Query.Append("      and [B].emp_status in ('Contractual','Probationary','Regular') ")
            Query.Append("      and [B].lock = 1 ")
            Query.Append("   order by ")
            Query.Append("      [Order] ")
            Query.Append("end")
        ElseIf pTblName = "Template" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].Code [Code] ")
            Query.Append("   ,[A].Title [Name] ")
            Query.Append("   ,[A].Title [Order] ")
            Query.Append("from ")
            Query.Append("   Mstr_AppPathTempHdr [A] ")
            Query.Append("where ")
            Query.Append("   [A].FormCode = '" & pFrmCode & "' ")
            Query.Append("order by ")
            Query.Append("   [Order] ")
        ElseIf pTblName = "User" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].emp_no [Code] ")
            Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Name] ")
            Query.Append("   ,dbo.ProperCase([A].first_name) + ' ' + dbo.ProperCase([A].last_name) [Order] ")
            Query.Append("from ")
            Query.Append("   employee [A] ")
            Query.Append("where ")
            Query.Append("   [A].emp_status in ('Contractual','Probationary','Regular') ")
            Query.Append("   and [A].lock = 1 ")
            Query.Append("order by ")
            Query.Append("   [Order] ")
        ElseIf pTblName = "Department" Then
            Query.Append("select ")
            Query.Append("    '' [Code]  ")
            Query.Append("    ,'" & pPlaceHolder & "' [Name]  ")
            Query.Append("    ,'' [Order]  ")
            Query.Append("union  ")
            Query.Append("select  ")
            Query.Append("    [A].dept_code [Code]  ")
            Query.Append("    ,[A].description [Name]  ")
            Query.Append("    ,[A].description [Order]  ")
            Query.Append("from  ")
            Query.Append("    department [A]  ")
            Query.Append("order by  ")
            Query.Append("    [Order]  ")
        ElseIf pTblName = "Mstr_Uom" Then
            Query.Append("select ")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].u_code [Code] ")
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
        ElseIf pTblName = "EmployeeApprover" Then
            Query.Append("select * from ( ")
            Query.Append("    select  '' as [Code], 'Select an approver' as [Name]  ")
            Query.Append("    union  ")
            Query.Append("    select emp_no as [Code], fullname as [Name]  ")
            Query.Append("    from employee  ")
            Query.Append("    where lock = '1'  ")
            Query.Append("	) t ")
            Query.Append("order by  ")
            Query.Append("    case when t.Code = '' then 1  ")
            Query.Append("    else 2 end, t.[Name]  ")
        ElseIf pTblName = "Status" Then
            Query.Append("if (select top 1 created_by from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & pID & "' and status = '') in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & pID & "') not in ('For Cancellation')")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Approved' [Code] ")
            Query.Append("      ,'Approve' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Cancelled' [Code] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Cancelled' [Code] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 type from oop_form_dtl_appr where f_code = '" & pID & "' and status = '') in ('Endorsed By','Approved By','Implementer') and (select top 1 status from oop_form_hdr where f_code = '" & pID & "') not in ('For Cancellation') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Approved' [Code] ")
            Query.Append("      ,'Approve' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Declined' [Code] ")
            Query.Append("      ,'Decline' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 status from oop_form_hdr where f_code = '" & pID & "') in ('For Cancellation') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Cancelled' [Code] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("end ")
        ElseIf pTblName = "Clarify" Then
            Query.Append("select")
            Query.Append("   '' [Code] ")
            Query.Append("   ,'Select a user' [Name] ")
            Query.Append("   ,'' [Order] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].created_by [Code] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
            Query.Append("from ")
            Query.Append("   oop_form_hdr [A] ")
            Query.Append("   left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & pID & "' ")
            Query.Append("   and [A].created_by not in ('" & CIIS_EmpCode & "') ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [A].approver [Code] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Order] ")
            Query.Append("from ")
            Query.Append("   oop_form_dtl_appr [A] ")
            Query.Append("   left join employee [B] on [A].approver = [B].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].f_code = '" & pID & "' ")
            Query.Append("   and [A].approver not in ('" & CIIS_EmpCode & "') ")
            Query.Append("order by ")
            Query.Append("   [Order] ")
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
                        .ID = DR("Code"),
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


    Function Generate_Report_1010(pID As String, context As HttpContext) As String
        Dim result As New Dictionary(Of String, String)

        Try
            ' Paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pID & "/")

            ' Ensure folders exist
            If Not Directory.Exists(reportFolderPath) Then Directory.CreateDirectory(reportFolderPath)
            If Not Directory.Exists(pdfFolderPath) Then Directory.CreateDirectory(pdfFolderPath)

            ' Clean old files
            For Each f In New DirectoryInfo(reportFolderPath).GetFiles() : f.Delete() : Next
            For Each f In New DirectoryInfo(pdfFolderPath).GetFiles() : f.Delete() : Next

            ' Copy template
            File.Copy(context.Server.MapPath("~/Assets/Report/AMD03RPT01.rpt"), Path.Combine(reportFolderPath, "AMD03RPT01.rpt"), True)

            ' Load report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "AMD03RPT01.rpt"))

            ' Set DB logon
            For Each tbcurrent As Table In RptDoc.Database.Tables
                Dim logoninfo As TableLogOnInfo = tbcurrent.LogOnInfo
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, catalog)
            RptDoc.SetParameterValue("@pAcctNo", pID)
            RptDoc.SetParameterValue("@pAcctNo", pID, "AMD03RPT03.rpt")

            ' Export original PDF to memory
            Dim origStream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim origPdfBytes(CInt(origStream.Length - 1)) As Byte
            origStream.Read(origPdfBytes, 0, origPdfBytes.Length)
            origStream.Close()

            Dim outputPdfPath = Path.Combine(pdfFolderPath, "AMD03RPT01_Duplicated.pdf")

            'Using ms As New MemoryStream(origPdfBytes)
            '    Dim reader As New PdfReader(ms)

            '    Dim longPage As New iTextSharp.text.Rectangle(612, 936) ' 8.5 x 13
            '    Dim doc As New Document(longPage)
            '    Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(outputPdfPath, FileMode.Create))
            '    doc.Open()

            '    Dim cb As PdfContentByte = writer.DirectContent
            '    Dim importedPage As PdfImportedPage = writer.GetImportedPage(reader, 1)

            '    Dim srcHeight As Single = reader.GetPageSize(1).Height
            '    Dim longHeight As Single = longPage.Height
            '    Dim halfHeight As Single = longHeight / 2

            '    If srcHeight <= halfHeight Then
            '        cb.AddTemplate(importedPage, 0, longHeight - srcHeight)
            '        cb.AddTemplate(importedPage, 0, halfHeight - srcHeight)

            '    Else
            '        cb.AddTemplate(importedPage, 0, longHeight - srcHeight)
            '        doc.NewPage()
            '        cb.AddTemplate(importedPage, 0, longHeight - srcHeight)
            '    End If

            '    doc.Close()
            'End Using
            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & pID & "/AMD03RPT01_Duplicated.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)
    End Function

#End Region

#Region "Validate"
    Private Function Validate(pID As String, Group_ As String, Type As String, Value As String)

        'get total task
        Dim Query As New StringBuilder
        If Group_ = "06DTL" Then

            'get total task
            If Type = "Status" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Closed' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_hdr where f_code = '" & pID & "') not in ('New','Requested','Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'On-Going' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_hdr where f_code = '" & pID & "') in ('New','Requested') ")
                Query.Append("begin ")
                Query.Append("   select 'New' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Clarification') ")
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

        If Group_ = "04ApprovalPath" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Clarification') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & CIIS_EmpCode & "' not in (select created_by from oop_form_hdr where f_code = '" & pID & "') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (Select top 1 GPCode from Form_Gatepass_Dtl where GPCode = (select tbl_code from oop_form_hdr where f_code = '" & pID & "')) is NULL ")
                Query.Append("begin   ")
                Query.Append("    select 'Please add particular first!'   ")
                Query.Append("end  ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & Value & ") in ('Approved') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save(ReasonForDelay)" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & CIIS_EmpCode & "' not in (select approver from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & Value & ") ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Up" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & Value & ") in ('Approved','Clarification','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Down" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & Value & ") in ('Approved','Clarification','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If

            If Type = "Save(Approver)" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined','For Cancellation') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & Value & ") in ('Approved','Clarification','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & CIIS_EmpCode & "' not in (select approver from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & (Value - 1) & ") ")
                Query.Append("and '" & CIIS_EmpCode & "' not in (select created_by from oop_form_hdr where f_code = '" & pID & "') ")
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

        If Group_ = "03Subscribers" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
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

        If Group_ = "02Files" Then

            'get total task
            If Type = "Add" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
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

        If Group_ = "01Overview" Then

            'get total task
            If Type = "Delete" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') not in ('New','Requested') ")
                Query.Append("begin ")
                Query.Append("   select 'Record cannot be deleted!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Record cannot be deleted!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') not in ('New','Requested') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Status" Then
                Query.Append("if (select status from oop_form_hdr where f_code = '" & pID & "') in ('Accepted','Cancelled','Declined') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if (select (case when '" + CIIS_EmpCode + "' not in (created_by,approver) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & Value & "' in ('Approved','Clarify') and (select (case when '" + CIIS_EmpCode + "' not in (approver) then 1 end) from oop_form_hdr where f_code = '" & pID & "') = 1 ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else if '" & Value & "' in ('Approved') and (select top 1 approver [Approver] from oop_form_dtl_appr where f_code = '" & pID & "'  and seq_no = (select min(seq_no) + 1 from oop_form_dtl_appr where f_code = '" & pID & "' and status = '' and DateStart is not null))  in ('Open')  ")
                Query.Append("begin ")
                Query.Append("   select 'Please specify the next approver to proceed.' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "PrintStatus" Then
                Query.Append("if (Select GPCode from Form_Gatepass_Dtl where GPCode = (select tbl_code from oop_form_hdr where f_code = '" & pID & "')) is NULL ")
                Query.Append("begin   ")
                Query.Append("    select 'Please add particular first!'   ")
                Query.Append("end  ")
                Query.Append("else if (Select top 1 f_code from oop_form_dtl_appr where f_code = '" & pID & "') is NULL ")
                Query.Append("begin   ")
                Query.Append("    select 'Please add an approval path!'   ")
                Query.Append("end  ")
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = 4) not in ('Approved')   ")
                Query.Append("begin   ")
                Query.Append("    select 'Form is not yet approved!'   ")
                Query.Append("end    ")
                Query.Append("else   ")
                Query.Append("begin   ")
                Query.Append("    select ''   ")
                Query.Append("end ")
            End If
            'get total task

        End If
        'get total task

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
                        .oReturn = DR.GetString(0)
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

#Region "Find"
    Function Find_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
        Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
        Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
        Query.Append("   ,[Link] ")
        Query.Append("   ,[Icon] ")
        Query.Append("   ,[Title] ")
        Query.Append("   ,[ID] ")
        Query.Append("   ,[Name] ")
        Query.Append("   ,[Date] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_Gatepass_Hdr' ")
        Query.Append("      and [A].created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_hdr [A] ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_Gatepass_Hdr' ")
        Query.Append("      and [A].approver = '" & CIIS_EmpCode & "' ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
        Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
        Query.Append("      ,[A].FormTitle [Title] ")
        Query.Append("      ,[A].f_code [ID] ")
        Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("      ,[A].created_date [Date] ")
        Query.Append("   from ")
        Query.Append("	    oop_form_dtl_monitor [M] ")
        Query.Append("	    left join oop_form_hdr [A] on [M].f_code = [A].f_code ")
        Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
        Query.Append("   where ")
        Query.Append("      [A].tbl_from = 'Form_Gatepass_Hdr' ")
        Query.Append("      and [M].monitored_by = '" & CIIS_EmpCode & "') [A] ")
        Query.Append("order by ")
        Query.Append("   [ID] ")
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

                    Dim Bullet As New StringBuilder
                    Bullet.Append("<div class='h-100'><span class='" & DR("Bullet") & "'></span></div>")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='" & DR("Link") & "' class='d-flex align-items-center w-100' target='_blank'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3' >")
                    Data.Append("       <div class='symbol symbol-30px overflow-hidden' >")
                    Data.Append("           <img alt='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("        </div> ")
                    Data.Append("   </div> ")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Title") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("ID") & " " & DR("Name") & " " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")

                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Data = Data.ToString
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

#Region "Approval Path"
    Function Load_Approval_path(pID As String)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	(case when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) < cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger'  ")
        Query.Append("	       when [A].status in ('') and [A].approver = [C].approver and cast([A].DateEnd as date) >= cast(getdate() as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success'  ")
        Query.Append("	       when [A].status in ('') then 'bullet bullet-margin bullet-vertical h-58px bg-secondary' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) < cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-danger' ")
        Query.Append("	       when [A].status not in ('') and cast([A].DateEnd as date) >= cast([A].updated_date as date) then 'bullet bullet-margin bullet-vertical h-58px bg-success' end) [Bullet] ")
        Query.Append("	,[A].seq_no [SeqNo] ")
        Query.Append("	,[A].type [Type] ")
        Query.Append("	,[A].approver [Icon] ")
        Query.Append("  ,ISNULL(NULLIF(LTRIM(RTRIM(COALESCE(dbo.ProperCase([B].first_name),'') + ' ' + COALESCE(dbo.ProperCase([B].last_name),''))),''),'Open') AS [ApprName]")
        Query.Append("	,ISNULL(NULLIF(dbo.ProperCase([B].JobDesc),''), [A].JobDesc) AS [ApprJob] ")
        Query.Append("	,(case when [A].status = '' then '-' else [A].status end) [ApprStatus] ")
        Query.Append("	,(case when [A].status = '' then '-' else format([A].updated_date,'MM/dd/yy') end) [ApprDate] ")
        Query.Append("	,(case when [A].status = '' and [A].approver = [C].approver then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') when [A].status not in ('') then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') else '-' end ) [Coverage] ")
        Query.Append("	,format([A].NoDays,'N1') [Duration] ")
        Query.Append("	,(case when [A].Reason = '' then '-' else isnull([A].Reason,'-') end) [Reason] ")
        Query.Append("  ,(case when [A].status = '' and [A].approver = [C].approver then [A].seq_no else null end) [CurrentSeqNo] ")
        Query.Append("  ,[A].IsEditable [IsEditable] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_appr [A] ")
        Query.Append("   left join employee [B] on [A].approver = [B].emp_no ")
        Query.Append("   left join oop_form_hdr [C] on [A].f_code = [C].f_code ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("  [A].seq_no ")
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

                    Dim Icon As String = ""
                    Dim iconName As String = If(IsDBNull(DR("Icon")), "", DR("Icon").ToString().Trim())

                    Dim avatarPath As String = HttpContext.Current.Server.MapPath("~/Assets/media/avatars/")

                    If Not String.IsNullOrEmpty(iconName) Then
                        Dim pngPath As String = Path.Combine(avatarPath, iconName & ".png")
                        Dim jpgPath As String = Path.Combine(avatarPath, iconName & ".jpg")

                        If File.Exists(pngPath) Then
                            Icon = "Assets/media/avatars/" & iconName & ".png"
                        ElseIf File.Exists(jpgPath) Then
                            Icon = "Assets/media/avatars/" & iconName & ".jpg"
                        Else
                            Icon = "Assets/media/avatars/blank.png"
                        End If
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    Dim Bullet As New StringBuilder
                    Bullet.Append("<div class='h-100'><span class='" & DR("Bullet") & "'></span></div>")

                    Dim Action As New StringBuilder()
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Remove User' onclick=""fn989Delete('" & DR("SeqNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Update reason for delay' onclick=""fn989Update('" & DR("SeqNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-add' title='Move user up' onclick=""fn989Up('" & DR("SeqNo") & "');return false;""><i class='las la-angle-up'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-add' title='Move user down' onclick=""fn989Down('" & DR("SeqNo") & "');return false;""><i class='las la-angle-down'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")


                    Dim User As New StringBuilder
                    User.Append("<div class='d-flex align-items-center w-100'>")
                    User.Append("   <div class='symbol symbol-30px overflow-hidden me-3'>")
                    User.Append("       <div class='symbol-label'>")
                    User.Append("           <img alt='' class='w-100' src='" & Icon & "' />")
                    User.Append("       </div>")
                    User.Append("   </div>")
                    User.Append("   <div class='d-flex flex-column'>")
                    User.Append("      <span class='fw-bold text-dark'>" & DR("ApprName") & "</span>")
                    User.Append("      <span class='text-muted'>" & DR("ApprJob") & "</span>")
                    User.Append("   </div>")
                    Dim isEditable As Boolean =
                            DR("IsEditable").ToString() = "1" AndAlso
                            (String.IsNullOrEmpty(Convert.ToString(DR("ApprStatus"))) OrElse
                             Convert.ToString(DR("ApprStatus")) = "-")

                    If isEditable Then
                        User.Append("   <button class='btn btn-sm btn-icon btn-active-success ms-auto' title='Update Approver' onclick=""fn989AddOpenApprover('" & DR("SeqNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    End If
                    User.Append("</div>")


                    Dim Status As New StringBuilder
                    Status.Append("<div class='d-flex align-items-center'>")
                    Status.Append("     <div class='d-flex flex-column'>")
                    Status.Append("         <span class='fw-bold text-dark' >" & DR("ApprStatus") & "</span>")
                    Status.Append("         <span class='text-muted' >" & DR("ApprDate") & "</span>")
                    Status.Append("     </div>")
                    Status.Append("</div>")

                    Dim TAT As New StringBuilder
                    TAT.Append("<div class='d-flex align-items-center'>")
                    TAT.Append("     <div class='d-flex flex-column'>")
                    TAT.Append("         <span class='fw-bold text-dark' >" & DR("Coverage") & "</span>")
                    TAT.Append("         <span class='text-muted' >" & DR("Duration") & "</span>")
                    TAT.Append("     </div>")
                    TAT.Append("</div>")

                    Dim RFD As New StringBuilder
                    RFD.Append("<div class='d-flex align-items-center w-100''>")
                    RFD.Append("         <span class='fw-bold text-dark' >" & DR("Reason") & "</span>")
                    RFD.Append("   <button class='btn btn-sm btn-icon btn-active-success ms-auto' title='Update reason for delay' onclick=""fn989Update('" & DR("SeqNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    RFD.Append("</div>")

                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Action = Action.ToString,
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .User = User.ToString,
                        .Status = Status.ToString,
                        .TAT = TAT.ToString,
                        .RFD = RFD.ToString
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
    Function Move_Approval_path(pID As String, pFrmCode As String, pSeqNo As String, pAction As String)

        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Upd_FRM_MoveApprover", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
                    SqlCmd.Parameters.AddWithValue("@pMove", pAction)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using

            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
    Function Delete_Approval_path(pID As String, pFrmCode As String, pSeqNo As String)

        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Del_FRM_Approver", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
                    SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using

            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
    Function Save_Approval_path(pID As String, pFrmCode As String, pSeqNo As String, pReason As String)

        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Upd_FRM_ReasonForDelay", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
                    SqlCmd.Parameters.AddWithValue("@pReason", pReason)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using

            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
    Function Save_New_Approval_path(pID, pFrmCode, pTypeApr, pApprover, pNoDays, pTemplate, pAddForm)

        If pAddForm = "Manual" Then
            Dim result As New Dictionary(Of String, String)
            Try
                Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                    SqlConn.Open()
                    Using SqlCmd As New SqlClient.SqlCommand("New_FRM_Approver", SqlConn)
                        SqlCmd.CommandTimeout = 1500
                        SqlCmd.CommandType = CommandType.StoredProcedure
                        SqlCmd.CommandText = "New_FRM_Approver"
                        SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                        SqlCmd.Parameters.AddWithValue("@pID", pID)
                        SqlCmd.Parameters.AddWithValue("@pType", pTypeApr)
                        SqlCmd.Parameters.AddWithValue("@pApprover", pApprover)
                        SqlCmd.Parameters.AddWithValue("@pNoDays", pNoDays.Replace(",", ""))
                        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                        SqlCmd.ExecuteNonQuery()
                    End Using
                End Using

                result("success") = "success"
            Catch ex As Exception
                result("success") = "error"
                result("message") = ex.Message
            End Try

            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Return serializer.Serialize(result)
        Else
            Dim result As New Dictionary(Of String, String)
            Try
                Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                    SqlConn.Open()
                    Using SqlCmd As New SqlClient.SqlCommand("New_FRM_ApproverTemplate", SqlConn)
                        SqlCmd.CommandTimeout = 1500
                        SqlCmd.CommandType = CommandType.StoredProcedure
                        SqlCmd.CommandText = "New_FRM_ApproverTemplate"
                        SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                        SqlCmd.Parameters.AddWithValue("@pID", pID)
                        SqlCmd.Parameters.AddWithValue("@pTemplate", pTemplate)
                        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                        SqlCmd.ExecuteNonQuery()
                    End Using
                End Using

                result("success") = "success"
            Catch ex As Exception
                result("success") = "error"
                result("message") = ex.Message
            End Try

            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Return serializer.Serialize(result)
        End If
    End Function
    Function Save_New_Open_Approval_path(pID, pFrmCode, pTemplate, pSeqNo)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Upd_FRM_Approver", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandText = "Upd_FRM_Approver"
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
                    SqlCmd.Parameters.AddWithValue("@pApprover", pTemplate)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using

            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

#End Region

#Region "Subscriber"
    Function Load_Subscriber(pID As String)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	 [A].monitored_by [Code] ")
        Query.Append("	 ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	 ,isnull(dbo.ProperCase([B].JobDesc),'-') [JobDesc] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_monitor [A] ")
        Query.Append("   left join employee [B] on [A].monitored_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("   [A].seq_no ")
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

                    Dim Icon As String = ""
                    Dim iconName As String = If(IsDBNull(DR("Code")), "", DR("Code").ToString().Trim())

                    Dim avatarPath As String = HttpContext.Current.Server.MapPath("~/Assets/media/avatars/")

                    If Not String.IsNullOrEmpty(iconName) Then
                        Dim pngPath As String = Path.Combine(avatarPath, iconName & ".png")
                        Dim jpgPath As String = Path.Combine(avatarPath, iconName & ".jpg")

                        If File.Exists(pngPath) Then
                            Icon = "Assets/media/avatars/" & iconName & ".png"
                        ElseIf File.Exists(jpgPath) Then
                            Icon = "Assets/media/avatars/" & iconName & ".jpg"
                        Else
                            Icon = "Assets/media/avatars/blank.png"
                        End If
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    Dim Bullet As New StringBuilder
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-margin bullet-vertical h-58px bg-secondary'></span></div>")

                    Dim Action As New StringBuilder()
                    Action.Append("<div class='d-flex'>")
                    Action.Append("     <button id='lbtn04Delete' class='btn btn-sm btn-icon btn-active-success mr-5' title='Remove User' onclick=""fn03010101Delete('" & DR("Code") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("</div>")


                    Dim User As New StringBuilder
                    User.Append("<div class='d-flex align-items-center w-100'>")
                    User.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3' >")
                    User.Append("       <div class='symbol symbol-30px overflow-hidden' >")
                    User.Append("           <img alt='' class='w-100' src='" & Icon & "' />")
                    User.Append("        </div> ")
                    User.Append("   </div> ")
                    User.Append("   <div class='d-flex flex-column' >")
                    User.Append("      <span class='fw-bold text-dark'>" & DR("Name") & "</span>")
                    User.Append("      <span class='text-muted' >" & DR("JobDesc") & "</span>")
                    User.Append("   </div>")
                    User.Append("</div>")

                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Action = Action.ToString,
                        .User = User.ToString
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
    Function Save_New_Subscriber(pFrmCode, pID, pUser)

        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("New_FRM_Monitor", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pMonitorBy", pUser)
                    SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using

            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
    Function Delete_Subscriber(pID As String, pFrmCode As String, pUser As String)

        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Del_FRM_Monitor", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pMonitoredBy", pUser)
                    SqlCmd.Parameters.AddWithValue("@pDeletedBy", CIIS_EmpCode)
                    SqlCmd.ExecuteNonQuery()
                End Using
            End Using

            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function
#End Region

#Region "History"

    Function Load_History(pID As String, pFrmCode As String)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	[A].CreatedDate [SeqNo01] ")
        Query.Append("	,0 [SeqNo02] ")
        Query.Append("	,[A].CreatedBy [Icon01] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	,Format([A].CreatedDate,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,'V2' [Version] ")
        Query.Append("	,[A].Type [Icon02] ")
        Query.Append("	,[A].Type ")
        Query.Append("	,[A].Description ")
        Query.Append("from ")
        Query.Append("	 Mstr_History [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TblName = '" & pFrmCode & "' ")
        Query.Append("   and [A].TblCode = '" & pID & "' ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("	[A].updated_Date [SeqNo01] ")
        Query.Append("	,[A].seq_no [SeqNo02] ")
        Query.Append("	,[A].updated_by [Icon] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
        Query.Append("	,Format([A].updated_Date,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,'V1' [Version] ")
        Query.Append("	,[A].field [Icon02] ")
        Query.Append("	,[A].field [Type] ")
        Query.Append("	,[A].change [Description] ")
        Query.Append("from ")
        Query.Append("	 oop_form_dtl_history [A] ")
        Query.Append("   left join employee [B] on [A].updated_by = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("  [SeqNo01] ")
        Query.Append("  ,[SeqNo02] ")
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

                    Dim Icon01 As String
                    Dim iconPath As String = HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR("Icon01") & ".png")

                    If File.Exists(iconPath) Then
                        Icon01 = "Assets/media/avatars/" & DR("Icon01") & ".png"
                    Else
                        Icon01 = "Assets/media/avatars/blank.png"
                    End If

                    Dim Class02 As String
                    Dim Icon02 As String

                    If DR("Version") = "V1" And DR("Icon02") = "New Form" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-file-alt"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Assigned To" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Endorsed To" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Relation" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-sitemap"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Upload") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Download") Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Attached File" And DR("Description").ToString.Contains("Delete") Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white la-paperclip"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Form Monitor" And DR("Description").ToString.Contains("Start Monitored") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V1" And (DR("Icon02") = "Form Monitor" And DR("Description").ToString.Contains("End Monitored")) Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Add Approver") Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Remove Approver:") Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Approver" And DR("Description").ToString.Contains("Move Approver") Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Note Added" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-comment"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Approved") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Clarify") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Declined") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" And DR("Icon02") = "Status" And DR("Description").ToString.Contains("Reply") Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V1" Then
                        Class02 = "symbol-label bg-warning"
                        Icon02 = "fs-1 text-white las la-pencil-alt"
                    End If

                    If DR("Version") = "V2" And DR("Icon02") = "Form Created:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-file-alt"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Assigned to:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-user"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Uploaded a file:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Downloaded a file:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed a file:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white la-paperclip"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added a subscriber:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed a subscriber:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-user-friends"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added an approver:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Removed an approver:" Then
                        Class02 = "symbol-label bg-danger"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Moved an approver up:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Moved an approver down:" Then
                        Class02 = "symbol-label bg-info"
                        Icon02 = "fs-1 text-white las la-users"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Added a note:" Then
                        Class02 = "symbol-label bg-success"
                        Icon02 = "fs-1 text-white las la-comment"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Approved:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Clarify:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Declined:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" And DR("Icon02") = "Reply:" Then
                        Class02 = "symbol-label bg-secondary"
                        Icon02 = "fs-1 text-dark las la-flag"
                    ElseIf DR("Version") = "V2" Then
                        Class02 = "symbol-label bg-warning"
                        Icon02 = "fs-1 text-white las la-pencil-alt"
                    End If


                    Dim Data As New StringBuilder
                    Data.Append("<div class='d-flex align-items-center'>")
                    Data.Append("       <div class='symbol symbol-30px overflow-hidden me-3' >")
                    Data.Append("           <div class='symbol-label' >")
                    Data.Append("               <img alt='' class='w-100' src='" & Icon01 & "' />")
                    Data.Append("           </div> ")
                    Data.Append("        </div> ")
                    Data.Append("   <div class='d-flex flex-column min-w-200px me-3' >")
                    Data.Append("      <span class='fw-bold text-dark nowrap-200px'>" & DR("Name") & "</span>")
                    Data.Append("      <span class='text-muted nowrap-200px' >" & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='symbol symbol-30px overflow-hidden me-3' >")
                    Data.Append("       <div class='" & Class02 & "' >")
                    Data.Append("             <i class='" & Icon02 & "'></i>")
                    Data.Append("       </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-200px me-3' >")
                    Data.Append("      <span class='fw-bold text-dark'>" & DR("Type") & "</span>")
                    Data.Append("      <span class='text-muted' >" & DR("Description") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")

                    RecordList.Add(New With {
                        .Data = Data.ToString
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

#Region "Status"

    Function Update_Record_Status(pID, pFrmCode, pStatus, pAssignto, pRemarks, pMention)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)

                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Upd_FRM_Status", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pStatus", pStatus)
                    SqlCmd.Parameters.AddWithValue("@pAssignTo", pAssignto)
                    SqlCmd.Parameters.AddWithValue("@pRemarks", pRemarks)
                    SqlCmd.Parameters.AddWithValue("@pMention", pMention)
                    SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)

                    SqlCmd.ExecuteNonQuery()

                End Using
            End Using

            result("success") = "success"
        Catch ex As Exception
            result("success") = "error"
            result("message") = ex.Message
        End Try

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Return serializer.Serialize(result)
    End Function

#End Region

End Class
