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
Imports System.Drawing.Printing
Imports Microsoft.AspNet.SignalR.Infrastructure

Public Class FRM000047HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim catalogdb As String = "calmardbLive"
    Dim UserID As String = "ciis"
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
            If pFunction = "Get-Access" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Access(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'GetName


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

            ElseIf pFunction = "Save-New-Record-0201" Then

                Dim pDateRequired = context.Request("pDateRequired")
                Dim pDepartment = context.Request("pDepartment")
                Dim pPersonInCharge = context.Request("pPersonInCharge")
                Dim pPurpose = context.Request("pPurpose")
                Dim pDescription = context.Request("pDescription")

                Dim json As String = Me.Save_New_Record_0201(pDateRequired, pDepartment, pPersonInCharge, pPurpose, pDescription)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-New-Record-0201" Then

                Dim pFrmCode = context.Request("pFrmCode")
                Dim pID = context.Request("pID")


                Dim pDateRequired = context.Request("pDateRequired")
                Dim pDepartment = context.Request("pDepartment")
                Dim pPersonInCharge = context.Request("pPersonInCharge")
                Dim pPurpose = context.Request("pPurpose")
                Dim pDescription = context.Request("pDescription")

                Dim json As String = Me.Update_New_Record_0201(pFrmCode, pID, pDateRequired, pDepartment, pPersonInCharge, pPurpose, pDescription)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Details

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

            'Buyers
            If pFunction = "Search-Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Select-Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Search-Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Select-Project" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.Get_Project_Info(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Buyers

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
                Dim pPersonInCharge = context.Request("pPersonInCharge")

                Dim json As String = Me.Save_New_Approval_path(pID, pFrmCode, pTypeApr, pApprover, pNoDays, pTemplate, pAddForm, pPersonInCharge)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Approval Path

            'Update Approver
            If pFunction = "Save-UpdApprover" Then

                Dim pID = context.Request("pID")
                Dim pFrmCode = context.Request("pFrmCode")
                Dim pSeqNo = context.Request("pSeqNo")
                Dim pUpdApprover = context.Request("pUpdApprover")

                Dim json As String = Me.Save_UpdApprover(pID, pFrmCode, pSeqNo, pUpdApprover)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Get-Record-04-List" Then

                Dim json As String = Me.Get_Record_04_List()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Get-NextAprrover" Then
                Dim pID = context.Request("pID")
                Dim json As String = Me.Get_NextAprrover(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If
            'Update Approver

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

            ElseIf pFunction = "Send-SMS" Then

                Dim pID = context.Request("pID")
                Dim pSMSType = context.Request("pSMSType")
                Dim pAcctName = context.Request("pAcctName")
                Dim pContactNo = context.Request("pContactNo")
                Dim pStatus = context.Request("pStatus")
                Dim pNote = context.Request("pNote")


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

#Region "Ciis_Access"
    Function Get_Access(pID)

        'query
        Dim Query As New StringBuilder()
        Query.Append(" SELECT ")
        Query.Append(" CASE  ")
        Query.Append(" WHEN h.status = 'New' and h.approver = @EmpCode THEN 1 ")
        Query.Append(" WHEN EXISTS ( ")
        Query.Append(" Select 1 ")
        Query.Append(" FROM oop_form_dtl_appr d ")
        Query.Append(" WHERE d.f_code = h.f_code ")
        Query.Append(" AND d.approver = @EmpCode ")
        Query.Append(" ) THEN 1 ")
        Query.Append(" ELSE 0 ")
        Query.Append(" End As hasAccess ")
        Query.Append(" FROM oop_form_hdr h ")
        Query.Append(" WHERE h.f_code = @pID ")



        Dim RecordList As New List(Of Object)()

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.Parameters.AddWithValue("@pID", pID)
                Cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)

                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()

                While DR.Read()
                    RecordList.Add(New With {
                    .oReturn = DR("HasAccess")
                })
                End While

                DR.Close()
                ConStr.Close()
            End Using
        End Using

        Return New JavaScriptSerializer().Serialize(RecordList)

    End Function
#End Region

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

#Region "Details"

    Function Get_Info_0101(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("    [A].f_code [ID] ")
        Query.Append("   ,[A].created_date [DateRequested] ")
        Query.Append("   ,[A].date_required [DateRequired] ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [RequestedBy] ")
        Query.Append("   ,dbo.ProperCase([D].first_name) + ' ' + dbo.ProperCase([D].last_name) [AssignedTo] ")
        Query.Append("   ,(case when isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') = '' then '-' else isnull(dbo.ProperCase([E].first_name) + ' ' + dbo.ProperCase([E].last_name),'') end) [EndorsedTo]  ")
        Query.Append("   ,[A].status [Status] ")
        Query.Append("   ,[A].FormTitle [Title] ")
        Query.Append("   ,[B].Purpose ")
        Query.Append("   ,[B].DescriptionReference  ")
        Query.Append("   ,[B].Department  ")
        Query.Append("   ,[B].PersonInCharge  ")
        Query.Append("   ,(SELECT Description FROM Department WHERE dept_code = [B].Department) AS [dept]  ")
        Query.Append("   ,(SELECT  fullname FROM employee WHERE emp_no = [B].PersonInCharge) AS [PIC]  ")
        Query.Append("  from ")
        Query.Append("   oop_form_hdr [A] ")
        Query.Append("   left join Form_QMSAuditRef [B] On [A].tbl_code = [B].QMSCode ")
        Query.Append("   left join employee [C] on [A].created_by = [C].emp_no ")
        Query.Append("   left join employee [D] on [A].approver = [D].emp_no ")
        Query.Append("   left join employee [E] on [A].EndorsedTo = [E].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].f_code = '" & pID & "' ")
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
                    .ID = If(IsDBNull(DR("ID")), "", DR("ID")),
                    .FormType = "Audit Document Request",
                    .DateRequested = If(IsDBNull(DR("DateRequested")), "", Convert.ToDateTime(DR("DateRequested")).ToString("MM/dd/yyyy")),
                    .DateRequired = If(IsDBNull(DR("DateRequired")), "", Convert.ToDateTime(DR("DateRequired")).ToString("MM/dd/yyyy")),
                    .RequestedBy = If(IsDBNull(DR("RequestedBy")), "", DR("RequestedBy")),
                    .AssignedTo = If(IsDBNull(DR("AssignedTo")), "", DR("AssignedTo")),
                    .EndorsedTo = If(IsDBNull(DR("EndorsedTo")), "", DR("EndorsedTo")),
                    .Status = If(IsDBNull(DR("Status")), "", DR("Status")),
                    .Title = If(IsDBNull(DR("Title")), "", DR("Title")),
                    .Dept = If(IsDBNull(DR("Dept")), "", DR("Dept")),
                    .Department = If(IsDBNull(DR("Department")), "", DR("Department")),
                    .PersonInCharge = If(IsDBNull(DR("PersonInCharge")), "", DR("PersonInCharge")),
                    .PIC = If(IsDBNull(DR("PIC")), "", DR("PIC")),
                    .Purpose = If(IsDBNull(DR("Purpose")), "", DR("Purpose")),
                    .Description = If(IsDBNull(DR("DescriptionReference")), "", DR("DescriptionReference"))
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
    Function Save_New_Record_0201(pDateRequired, pDepartment, pPersonInCharge, pPurpose, pDescription)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("New_FRM_FRM000047", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pDateRequired", pDateRequired)
                    SqlCmd.Parameters.AddWithValue("@pDepartment", pDepartment)
                    SqlCmd.Parameters.AddWithValue("@pPersonInCharge", pPersonInCharge)
                    SqlCmd.Parameters.AddWithValue("@pPurpose", pPurpose)
                    SqlCmd.Parameters.AddWithValue("@pDescription", pDescription)
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
    Function Update_New_Record_0201(pFrmCode, pID, pDateRequired, pDepartment, pPersonInCharge, pPurpose, pDescription)
        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("UPD_FRM_FRM000047", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pDateRequired", pDateRequired)
                    SqlCmd.Parameters.AddWithValue("@pDepartment", pDepartment)
                    SqlCmd.Parameters.AddWithValue("@pPersonInCharge", pPersonInCharge)
                    SqlCmd.Parameters.AddWithValue("@pPurpose", pPurpose)
                    SqlCmd.Parameters.AddWithValue("@pDescription", pDescription)
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
        End If

        If pTblName = "Status" Then
            Query.Append("if (select top 1 created_by from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & pID & "' and status = '') in ('Endorsed By','Approved By','Implementer') ")
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
            Query.Append("      'Clarify' [Code] ")
            Query.Append("      ,'Clarify' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Cancelled' [Code] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append("else if (select top 1 created_by from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') and (select top 1 approver from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') and (select top 1 type from oop_form_dtl_appr where f_code = '" & pID & "' and status = '') in ('Clarification') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Reply' [Code] ")
            Query.Append("      ,'Reply' [Name] ")
            Query.Append("end ")
            Query.Append(" else if (select top 1 created_by from oop_form_hdr where f_code = '" & pID & "') in ('" & CIIS_EmpCode & "') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Cancelled' [Code] ")
            Query.Append("      ,'Cancel' [Name] ")
            Query.Append("end ")
            Query.Append(" else if (select top 1 type from oop_form_dtl_appr where f_code = '" & pID & "' and status = '') in ('Endorsed By','Approved By','Implementer') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union ")
            Query.Append("   select ")
            Query.Append("      'Approved' [Code] ")
            Query.Append("      ,'Approve' [Name] ")
            Query.Append("end ")
            Query.Append(" else if (select top 1 type from oop_form_dtl_appr where f_code = '" & pID & "' and status = '') in ('Clarification') ")
            Query.Append("begin ")
            Query.Append("   select ")
            Query.Append("      '' [Code] ")
            Query.Append("      ,'Select a status' [Name] ")
            Query.Append("   union")
            Query.Append("   select")
            Query.Append("      'Reply' [Code] ")
            Query.Append("      ,'Reply' [Name] ")
            Query.Append("end ")
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

        If pTblName = "Department" Then
            Query.Append(" Select '' [Code], ")
            Query.Append(" '" & pPlaceHolder & "' [Name]  ")
            Query.Append(" ,1 [Order01]  ")
            Query.Append(",'' [Order02]  ")
            Query.Append(" union select  ")
            Query.Append(" cast(dept_code As nvarchar(13)) [Code],   ")
            Query.Append(" Description [Name]  ")
            Query.Append(" ,2 [Order01]  ")
            Query.Append(" ,Description [Order02]  ")
            Query.Append(" From ")
            Query.Append(" department ")
            Query.Append(" Where ")
            Query.Append(" dept_code = '" & pID & "'  ")
            Query.Append(" union Select ")
            Query.Append(" cast(dept_code As nvarchar(13)) [Code]   ")
            Query.Append(" ,Description [Name]  ")
            Query.Append(" ,2 [Order01]  ")
            Query.Append(" ,Description [Order02]  ")
            Query.Append(" From ")
            Query.Append(" department ")
            Query.Append(" Where ")
            Query.Append(" Lock = '1'  ")
            Query.Append(" order by  ")
            Query.Append(" [Order01] ")
            Query.Append(" ,[Order02]  ")


        ElseIf pTblName = "PIC" Then
            Query.Append(" select '' [Code],  ")
            Query.Append(" '" & pPlaceHolder & "' [Name]  ")
            Query.Append(" ,1 [Order01] ")
            Query.Append(" ,'' [Order02] ")
            Query.Append(" union  ")
            Query.Append(" select cast(emp_no as nvarchar(13)) [Code],   ")
            Query.Append(" fullname [Name]  ")
            Query.Append(" ,2 [Order01] ")
            Query.Append(" ,fullname [Order02] ")
            Query.Append(" from ")
            Query.Append(" employee  ")
            Query.Append(" where dept_code = '" & pID & "' ")
            Query.Append(" and emp_status in ('Contractual','Probationary','Regular')  ")
            Query.Append(" order by  ")
            Query.Append(" [Order01]")
            Query.Append(" ,[Order02] ")
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
            ' Define paths
            Dim reportFolderPath = context.Server.MapPath("~/Assets/Report/" & pID & "/")
            Dim pdfFolderPath = context.Server.MapPath("~/Assets/PDF/" & pID & "/")

            ' Create report folder if it doesn't exist
            If Not Directory.Exists(reportFolderPath) Then
                Directory.CreateDirectory(reportFolderPath)
            End If

            ' Delete existing files in the report folder
            Dim reportDir As New DirectoryInfo(reportFolderPath)
            For Each file In reportDir.GetFiles()
                file.Delete()
            Next

            ' Create PDF folder if it doesn't exist
            If Not Directory.Exists(pdfFolderPath) Then
                Directory.CreateDirectory(pdfFolderPath)
            End If

            ' Delete existing files in the PDF folder
            Dim pdfDir As New DirectoryInfo(pdfFolderPath)
            For Each file In pdfDir.GetFiles()
                file.Delete()
            Next

            ' Copy template report
            File.Copy(context.Server.MapPath("~/Assets/Report/RPT000009.rpt"), Path.Combine(reportFolderPath, "RPT000009.rpt"), True)

            ' Load and configure report
            Dim RptDoc As New ReportDocument()
            RptDoc.Load(Path.Combine(reportFolderPath, "RPT000009.rpt"))

            Dim logoninfo As TableLogOnInfo
            For Each tbcurrent As Table In RptDoc.Database.Tables
                logoninfo = tbcurrent.LogOnInfo()
                logoninfo.ConnectionInfo.ServerName = DataSource
                logoninfo.ConnectionInfo.DatabaseName = catalog
                logoninfo.ConnectionInfo.UserID = UserID
                logoninfo.ConnectionInfo.Password = Password
                tbcurrent.ApplyLogOnInfo(logoninfo)
            Next

            RptDoc.SetDatabaseLogon(UserID, Password, DataSource, catalog)
            RptDoc.SetParameterValue("@f_code", pID)

            ' Export to PDF
            Dim stream As Stream = RptDoc.ExportToStream(ExportFormatType.PortableDocFormat)
            Dim buf(CInt(stream.Length - 1)) As Byte
            stream.Read(buf, 0, buf.Length)
            File.WriteAllBytes(Path.Combine(pdfFolderPath, "RPT000009.pdf"), buf)

            ' Cleanup
            RptDoc.Close()
            RptDoc.Dispose()

            ' Encrypt path and return response
            Dim encryptedPath As String = EncryptionHelper.EncryptString("~/Assets/PDF/" & pID & "/RPT000009.pdf")
            result("status") = "success"
            result("viewUrl") = "MNU020200?View=" & encryptedPath

        Catch ex As Exception
            result("status") = "error"
            result("message") = ex.Message
        End Try

        Return New JavaScriptSerializer().Serialize(result)
    End Function
#End Region

#Region "Buyers"
    Private Function Get_Buyer_List(Value)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 [A].Active = 1 ")
        Query.Append("	 and [A].Posted = 1 ")
        Query.Append("	 and ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
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

                    Dim Bullet As New StringBuilder
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectBuyer('" & DR("AcctNo") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("AcctName") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("AcctNo") & " " & DR("Project") & "</span>")
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
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordList)
        'display

    End Function
    Private Function Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].LotCode ")
        Query.Append("   ,[A].Subd ")
        Query.Append("   ,[A].Phase ")
        Query.Append("   ,[A].Block ")
        Query.Append("   ,[A].Lot ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Account [A] ")
        Query.Append("where ")
        Query.Append("	 [A].AcctNo = '" & AcctNo & "' ")
        'get total task

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName"),
                        .Project = DR("Project"),
                        .LotCode = DR("LotCode"),
                        .Subd = DR("Subd"),
                        .Phase = DR("Phase"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordInfo))
        'display 

    End Function
    Private Function Get_Project_List(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].LotCode [Code] ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [C].ModelName + ')' [Description] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("	 left join calmardblive.dbo.mstr_HouseModels [C] on [A].Model = [C].ModelCode ")
        Query.Append("where ")
        Query.Append("	 [A].LotCode like '%" & Find & "%' ")
        Query.Append("	    or [B].ProjInit like '%" & Find & "%' ")
        Query.Append("	    or [A].PhaseNo like '%" & Find & "%' ")
        Query.Append("	    or [A].Block like '%" & Find & "%' ")
        Query.Append("	    or [A].Lot like '%" & Find & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [C].ModelName + ')' like '%" & Find & "%' ")
        Query.Append("order by ")
        Query.Append("   [Description] ")
        'subdivision

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
                    Bullet.Append("")

                    Dim Data As New StringBuilder
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectProject('" & DR("Code") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Description") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("Code") & "</span>")
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
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordList)
        'display 

    End Function
    Private Function Get_Project_Info(LotCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].LotCode ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot + ' (' + [C].ModelName + ')' [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("	 left join calmardblive.dbo.mstr_HouseModels [C] on [A].Model = [C].ModelCode ")
        Query.Append("where ")
        Query.Append("	 [A].LotCode = '" & LotCode & "' ")
        'get total task

        'variable
        Dim RecordInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    RecordInfo.Add(New With {
                        .LotCode = DR("LotCode"),
                        .Project = DR("Project")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordInfo))
        'display 

    End Function
#End Region


#Region "Update Approver"

    Function Get_NextAprrover(pID)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select top 1 ")
        Query.Append("    approver [Approver] ")
        Query.Append("from oop_form_dtl_appr ")
        Query.Append("where f_code = '" & pID & "' ")
        Query.Append("  and seq_no = (select min(seq_no) + 1 from oop_form_dtl_appr where f_code = '" & pID & "' and status = '' and DateStart is not null) ")
        'get approver 

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
                      .NextApprover = DR("Approver")
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
    Function Get_Record_04_List()

        'query
        Dim Query As New StringBuilder
        Query.Append("select * from ( ")
        Query.Append("    select  '' as [ID], 'Select an approver' as [Name] ")
        Query.Append("    union ")
        Query.Append("    select emp_no as [ID], fullname as [Name] ")
        Query.Append("    from employee ")
        Query.Append("    where lock = '1' ")
        Query.Append(") t ")
        Query.Append("order by ")
        Query.Append("    case when t.ID = '' then 1 ")
        Query.Append("         else 2 end, ")
        Query.Append("    t.[Name] ")
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
    Function Save_UpdApprover(pID As String, pFrmCode As String, pSeqNo As String, pUpdApprover As String)

        Dim result As New Dictionary(Of String, String)
        Try
            Using SqlConn As New SqlClient.SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                SqlConn.Open()
                Using SqlCmd As New SqlClient.SqlCommand("Upd_FRM_Approver", SqlConn)
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                    SqlCmd.Parameters.AddWithValue("@pID", pID)
                    SqlCmd.Parameters.AddWithValue("@pSeqNo", pSeqNo)
                    SqlCmd.Parameters.AddWithValue("@pApprover", pUpdApprover)
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



#Region "Validate"
    Private Function Validate(pID As String, Group_ As String, Type As String, Value As String)

        'get total task
        Dim Query As New StringBuilder

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
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & Value & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
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
                Query.Append("else if (select status from oop_form_dtl_appr where f_code = '" & pID & "' and seq_no = " & Value & ") in ('Approved','Clarification','Clarify','Reply','Cancelled','Declined') ")
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
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
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
        Query.Append("      [A].tbl_from = 'Form_QMSAuditRef' ")
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
        Query.Append("      [A].tbl_from = 'Form_QMSAuditRef' ")
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
        Query.Append("      [A].tbl_from = 'Form_QMSAuditRef' ")
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
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [ApprName] ")
        Query.Append("	,isnull(dbo.ProperCase([B].JobDesc),'-') [ApprJob] ")
        Query.Append("	,(case when [A].status = '' then '-' else [A].status end) [ApprStatus] ")
        Query.Append("	,(case when [A].status = '' then '-' else format([A].updated_date,'MM/dd/yy') end) [ApprDate] ")
        Query.Append("	,(case when [A].status = '' and [A].approver = [C].approver then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') when [A].status not in ('') then format([A].DateStart,'MM/dd/yy') + '-' + format([A].DateEnd,'MM/dd/yy') else '-' end ) [Coverage] ")
        Query.Append("	,format([A].NoDays,'N1') [Duration] ")
        Query.Append("	,(case when [A].Reason = '' then '-' else isnull([A].Reason,'-') end) [Reason] ")
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

                    Dim isEditable As Boolean = Convert.ToString(DR("IsEditable")) = "1"

                    Dim User As New StringBuilder
                    User.Append("<div class='d-flex align-items-center w-100'>")
                    User.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3' >")
                    User.Append("       <div class='symbol symbol-30px overflow-hidden' >")
                    User.Append("           <img alt='' class='w-100' src='" & Icon & "' />")
                    User.Append("        </div> ")
                    User.Append("   </div> ")
                    User.Append("   <div class='d-flex flex-column' >")
                    User.Append("      <span class='fw-bold text-dark'>" & DR("ApprName") & "</span>")
                    User.Append("      <span class='text-muted' >" & DR("ApprJob") & "</span>")
                    User.Append("   </div>")
                    User.Append("</div>")

                    If isEditable Then
                        User.Append("   <div class='d-flex flex-column ms-auto'>")
                        User.Append("      <button class='btn btn-sm btn-icon btn-active-success' title='Update Approver' ")
                        User.Append("              onclick=""fn989UpdApprover('" & DR("SeqNo") & "');return false;"">")
                        User.Append("          <i class='las la-pencil-alt fs-3'></i>")
                        User.Append("      </button>")
                        User.Append("   </div>")
                    End If
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

                    RecordList.Add(New With {
                        .Bullet = Bullet.ToString,
                        .Action = Action.ToString,
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .User = User.ToString,
                        .Status = Status.ToString,
                        .TAT = TAT.ToString,
                        .RFD = "<span title='" & DR("Reason") & "'>" & DR("Reason") & "</span>"
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
    Function Save_New_Approval_path(pID, pFrmCode, pTypeApr, pApprover, pNoDays, pTemplate, pAddForm, pPersonInCharge)

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
                    Using SqlCmd As New SqlClient.SqlCommand("New_FRM_ApproverTemplate_47", SqlConn)
                        SqlCmd.CommandTimeout = 1500
                        SqlCmd.CommandType = CommandType.StoredProcedure
                        SqlCmd.CommandText = "New_FRM_ApproverTemplate_47"
                        SqlCmd.Parameters.AddWithValue("@pFormCode", pFrmCode)
                        SqlCmd.Parameters.AddWithValue("@pID", pID)
                        SqlCmd.Parameters.AddWithValue("@pTemplate", pTemplate)
                        SqlCmd.Parameters.AddWithValue("@pPersonInCharge", pPersonInCharge)
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
                    Data.Append("       <div class='symbol symbol-30px overflow-hidden' >")
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
