Imports System.Data.SqlClient
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.EnterpriseServices
Imports System.IO
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net.PeerToPeer.Collaboration
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Cryptography
Imports System.Security.Principal
Imports System.Web
Imports System.Web.DynamicData
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.WebSockets
Imports System.Windows.Automation
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.[Shared].Json
Imports Microsoft.Ajax.Utilities
Imports Microsoft.Identity.Client.AuthScheme
Imports Microsoft.Identity.Client.Cache
Imports Microsoft.IdentityModel.Protocols.OpenIdConnect
Imports Microsoft.Reporting.Map.WebForms.VirtualEarth
Imports Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports OfficeOpenXml.ConditionalFormatting.Contracts

Public Class HND000003
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
            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")
            'general parameter

            If FormCode = "DSB020000" And Type = "Form" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Form(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Form)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_Form_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Details)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_Form_Details_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Form Days)" Then

                Dim Status = context.Request("Status")
                Dim Days = context.Request("Days")

                Dim json As String = Me.DSB020000_Get_Form_Days_All(Status, Days)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Work Order)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_WorkOrder_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Work Order Details)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_WorkOrder_Details_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Work Order Department)" Then

                Dim Status = context.Request("Status")
                Dim Department = context.Request("Department")

                Dim json As String = Me.DSB020000_Get_WorkOrder_Department_All(Status, Department)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Construction Task)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_Task_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Construction Task Details)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_Task_Details_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Construction Task Name)" Then

                Dim Status = context.Request("Status")
                Dim TaskName = context.Request("TaskName")

                Dim json As String = Me.DSB020000_Get_Task_Name_All(Status, TaskName)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Request)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_Request_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Request Details)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_Request_Details_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Request FormInit)" Then

                Dim Status = context.Request("Status")
                Dim FormInit = context.Request("FormInit")

                Dim json As String = Me.DSB020000_Get_Request_FormInit_All(Status, FormInit)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Request Work Order)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_RequestWO_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Request Work Order Details)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB020000_Get_RequestWO_Details_All(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB020000" And Type = "My Dashboard (Request Work Order Department)" Then

                Dim Status = context.Request("Status")
                Dim Department = context.Request("Department")

                Dim json As String = Me.DSB020000_Get_RequestWO_Department_All(Status, Department)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB030000" And Type = "Overview Count Per Forms" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB030000_Get_Total_Per_Form(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Overview Count Per Month" Then

                Dim Month = context.Request("Month")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB030000_Get_Total_Per_Month(Month, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Department" Then

                Dim DeptCode = context.Request("DeptCode")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Dept(DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Employee" Then

                Dim DeptCode = context.Request("DeptCode")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Emp(DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Details" Then

                Dim EmpCode = context.Request("EmpCode")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Details(EmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Year" Then

                Dim Year = context.Request("Year")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Year(Year)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Year Details" Then

                Dim Year = context.Request("Year")
                Dim DeptCode = context.Request("DeptCode")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Year_Details(Year, DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Year Emp Details" Then

                Dim EmpCode = context.Request("EmpCode")
                Dim Year = context.Request("Year")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Year_Emp_Details(EmpCode, Year)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Year Chart" Then

                Dim Year = context.Request("Year")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Year_Chart(Year)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Aging" Then

                Dim Aging = context.Request("Aging")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Aging(Aging)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Aging Details" Then

                Dim Aging = context.Request("Aging")
                Dim DeptCode = context.Request("DeptCode")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Aging_Details(Aging, DeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Aging Form Per Emp Aging Details" Then

                Dim Aging = context.Request("Aging")
                Dim EmpCode = context.Request("EmpCode")

                Dim json As String = Me.DSB030000_Get_Aging_Per_Emp_Aging_Details(Aging, EmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB030000" And Type = "Accomplishment Details" Then

                Dim Code = context.Request("Code")
                Dim DateFrom = context.Request("DateFrom")
                Dim DateTo = context.Request("DateTo")

                Dim json As String = Me.DSB030000_Get_Accomplishment_Details(Code, DateFrom, DateTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "ENG050101" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG050101_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020101" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG020101_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020201" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG020201_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040101" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG040101_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010201" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.PDD010201_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010101" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.PDD010101_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "FIN030101" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.FIN030101_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG030101" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG030101_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050201" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG050201_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "SCM030101" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.SCM030101_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040201" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG040201_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010501" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG010501_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010501" And Type = "Update Progress" Then

                Dim UPID = context.Request("UPID")
                Dim UPSUBID = context.Request("UPSUBID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010501_UpdateProgress(FormCode, UPID, UPSUBID, UPRate, UPDate)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010301" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.PDD010301_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040301" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSSUBID = context.Request("CSSUBID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG040301_ChangeStatus(FormCode, CSID, CSSUBID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010100" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG010100_ChangeStatus(CSID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010100" And Type = "Update Progress" Then

                Dim UPID = context.Request("UPID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010100_UpdateProgress(UPID, UPRate, UPDate)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010200" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG010200_ChangeStatus(CSID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010200" And Type = "Update Progress" Then

                Dim UPID = context.Request("UPID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010200_UpdateProgress(UPID, UPRate, UPDate)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010300" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG010300_ChangeStatus(CSID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010300" And Type = "Update Progress" Then

                Dim UPID = context.Request("UPID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010300_UpdateProgress(UPID, UPRate, UPDate)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010400" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG010400_ChangeStatus(CSID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010400" And Type = "Update Progress" Then

                Dim UPID = context.Request("UPID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010400_UpdateProgress(UPID, UPRate, UPDate)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010600" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG010600_ChangeStatus(CSID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010600" And Type = "Update Progress" Then

                Dim UPID = context.Request("UPID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010600_UpdateProgress(UPID, UPRate, UPDate)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010700" And Type = "Change Status" Then

                Dim CSID = context.Request("CSID")
                Dim CSStatus = context.Request("CSStatus")
                Dim CSAssignTo = context.Request("CSAssignTo")

                Dim json As String = Me.ENG010700_ChangeStatus(CSID, CSStatus, CSAssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010700" And Type = "Update Progress" Then

                Dim UPID = context.Request("UPID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010700_UpdateProgress(UPID, UPRate, UPDate)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            End If

            If FormCode = "FIN010000" And Type = "Create Billing" Then

                Dim CBID = context.Request("CBID")
                Dim CBType = context.Request("CBType")
                Dim CBAmt = CDbl(context.Request("CBAmt"))

                Dim json As String = Me.FIN010000_CreateBilling(CBID, CBType, CBAmt)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            End If

            If FormCode = "MNU020100" And Type = "Mark All Read" Then

                Me.MNU020100_MarkAllRead()

                Dim json As String = Me.MNU020100_GetAllUnread()
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "MNU020100" And Type = "Mark As Read" Then

                Dim ID = Replace(context.Request("ID"), "ReadA", "")

                Me.MNU020100_MarkAsRead(ID)

                Dim json As String = Me.MNU020100_GetUnread(ID)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "MNU020100" And Type = "Mark As Unread" Then

                Dim ID = Replace(context.Request("ID"), "UnreadA", "")

                Me.MNU020100_MarkAsUnread(ID)

                Dim json As String = Me.MNU020100_GetRead(ID)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            End If

            If FormCode = "MNU000000" And Type = "Mark All Read" Then

                Me.MNU000000_MarkAllRead()

                Dim json As String = Me.MNU000000_GetAllUnread()
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "MNU000000" And Type = "Mark As Read" Then

                Dim ID = Replace(context.Request("ID"), "ReadA", "")

                Me.MNU000000_MarkAsRead(ID)

                Dim json As String = Me.MNU000000_GetUnread(ID)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "MNU000000" And Type = "Mark As Unread" Then

                Dim ID = Replace(context.Request("ID"), "UnreadA", "")

                Me.MNU000000_MarkAsUnread(ID)

                Dim json As String = Me.MNU000000_GetRead(ID)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            End If

            If FormCode = "MNU000017" And Type = "View Unit" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.MNU000017_View_Unit(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "MNU000017" And Type = "View Review" Then

                Dim CodeSrs = context.Request("CodeSrs")

                Dim json As String = Me.MNU000017_View_Review(CodeSrs)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "MNU000017" And Type = "Submit" Then

                Dim BatchNo = context.Request("BatchNo")
                Dim LotCodeSrs = context.Request("LotCodeSrs")

                Dim json As String = Me.MNU000017_Submit(BatchNo, LotCodeSrs)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB000008" And Type = "View WAR (All)" Then

                Dim json As String = Me.DSB000008_Get_WAR_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Completed)" Then

                Dim json As String = Me.DSB000008_Get_WAR_Completed()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Completed - Month)" Then

                Dim Month = context.Request("Month")

                Dim json As String = Me.DSB000008_Get_WAR_Completed_Month(Month)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Completed - Status)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Completed_Status(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Completed - Batch)" Then

                Dim BatchNo = context.Request("BatchNo")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Completed_Batch(BatchNo, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (On-Going)" Then

                Dim json As String = Me.DSB000008_Get_WAR_OnGoing()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (On-Going - Status)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Ongoing_Status(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (On-Going - Batch)" Then

                Dim BatchNo = context.Request("BatchNo")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Ongoing_Batch(BatchNo, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (For Construction)" Then

                Dim json As String = Me.DSB000008_Get_WAR_ForConstruction()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (For Construction - Status)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_ForConstruction_Status(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (For Construction - Batch)" Then

                Dim BatchNo = context.Request("BatchNo")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_ForConstruction_Batch(BatchNo, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Year)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Year(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Year - Status)" Then

                Dim Year = context.Request("Year")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Year_Status(Year, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View Year" Then

                Dim Year = context.Request("Year")

                Dim json As String = Me.DSB000008_Get_Year_Bar_Chart(Year)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Month)" Then

                Dim Year = context.Request("Year")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Month(Year, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000008" And Type = "View WAR (Month - Status)" Then

                Dim Year = context.Request("Year")
                Dim Month = context.Request("Month")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000008_Get_WAR_Month_Status(Year, Month, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB000009" And Type = "View WAR (All)" Then

                Dim json As String = Me.DSB000009_Get_WAR_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000009" And Type = "View WAR (All - Status)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000009_Get_WAR_All_Status(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000009" And Type = "View WAR (Division)" Then

                Dim Division = context.Request("Division")

                Dim json As String = Me.DSB000009_Get_WAR_Division(Division)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000009" And Type = "View WAR (Division - Status)" Then

                Dim Division = context.Request("Division")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB000009_Get_WAR_Division_Status(Division, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB000010" And Type = "View Project (All)" Then

                Dim json As String = Me.DSB000010_Get_Project_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000010" And Type = "View WAR (Status)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB00010_Get_WAR_Status(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000010" And Type = "View WAR (Status - Project)" Then

                Dim Status = context.Request("Status")
                Dim Project = context.Request("Project")

                Dim json As String = Me.DSB00010_Get_WAR_Status_Project(Status, Project)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000010" And Type = "View WAR (PE)" Then

                Dim Project = context.Request("Project")
                Dim PE = context.Request("PE")

                Dim json As String = Me.DSB00010_Get_WAR_PE(Project, PE)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB000011" And Type = "View WAR (Status)" Then

                Dim Project = context.Request("Project")
                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB00011_Get_WAR_Status(Project, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000011" And Type = "View WAR (Status - PE)" Then

                Dim Project = context.Request("Project")
                Dim Status = context.Request("Status")
                Dim PE = context.Request("PE")

                Dim json As String = Me.DSB00011_Get_WAR_Status_PE(Project, Status, PE)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB000013" And Type = "View Batch (All)" Then

                Dim json As String = Me.DSB00013_Get_Batch_All()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000013" And Type = "View WAR (Status)" Then

                Dim Status = context.Request("Status")

                Dim json As String = Me.DSB00013_Get_WAR_Status(Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000013" And Type = "View WAR (Status - Batch)" Then

                Dim Status = context.Request("Status")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.DSB00013_Get_WAR_Status_Batch(Status, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000013" And Type = "View WAR (PE)" Then

                Dim Batch = context.Request("Batch")
                Dim PE = context.Request("PE")

                Dim json As String = Me.DSB00013_Get_WAR_PE(Batch, PE)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB000013" And Type = "View Year" Then

                Dim Year = context.Request("Year")

                Dim json As String = Me.bindBatchList(Year)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000013" And Type = "View WAR (Batch)" Then

                Dim Batch = context.Request("Batch")
                Dim Status = context.Request("Status")

                Dim json As String = Me.bindWARBatch(Batch, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000013" And Type = "View WAR (PE)" Then

                Dim Batch = context.Request("Batch")
                Dim PE = context.Request("PE")
                Dim Status = context.Request("Status")

                Dim json As String = Me.bindWARPE(FormCode, Batch, PE, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "DSB000011" And Type = "View WAR (Project)" Then

                Dim Project = context.Request("Project")
                Dim Status = context.Request("Status")

                Dim json As String = Me.bindWARProject(Project, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "DSB000011" And Type = "View WAR (PE)" Then

                Dim Project = context.Request("Project")
                Dim PE = context.Request("PE")
                Dim Status = context.Request("Status")

                Dim json As String = Me.bindWARPE(FormCode, Project, PE, Status)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000001" And Type = "Get Project" Then

                Dim Category = context.Request("Category")

                Dim json As String = Me.FRM000001_Get_Project_List(Category)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000001" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000001_Get_Project(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000001" And Type = "Select Project" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.FRM000001_Get_Project_Info(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000001" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000001_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000001" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000001_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000001" And Type = "Search Project (Contract)" Then

                Dim Category = context.Request("Category")
                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000001_Get_Contract_Project_List(Category, Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000001" And Type = "Select Project (Contract)" Then

                Dim Category = context.Request("Category")
                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000001_Get_Contract_Project_Info(Category, Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000009" And Type = "Search Project" Then

                Dim Category = context.Request("Category")
                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000009_Get_Project_List(Category, Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000009" And Type = "Select Project" Then

                Dim Category = context.Request("Category")
                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000009_Get_Project_Info(Category, Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000010" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000010_Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Select Project" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000010_Get_Project_Info(Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Select Vehicle" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000010_Get_Vehicle_Info(Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Charge Code" Then

                Dim pTblFrom = context.Request("pTblFrom")
                Dim pCode1 = context.Request("pCode1")
                Dim pCode2 = context.Request("pCode2")
                Dim pCode3 = context.Request("pCode3")
                Dim pCode4 = context.Request("pCode4")
                Dim pCode5 = context.Request("pCode5")

                Dim json As String = Me.FRM000010_Get_Charge_To(pTblFrom, pCode1, pCode2, pCode3, pCode4, pCode5)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Sub-Phase" Then

                Dim json As String = Me.FRM000010_Get_Sub_Phase()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Sub-Miscellaneous" Then

                Dim pAcctCode = context.Request("pAcctCode")

                Dim json As String = Me.FRM000010_Get_Sub_Miscellaneous(pAcctCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Sub-Others" Then

                Dim pAcctCode = context.Request("pAcctCode")

                Dim json As String = Me.FRM000010_Get_Sub_Other(pAcctCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Sub-Department" Then

                Dim pAcctCode = context.Request("pAcctCode")

                Dim json As String = Me.FRM000010_Get_Sub_Department(pAcctCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Cost-Estimate-Construction" Then

                Dim pCategory = context.Request("pCategory")
                Dim pSubd = context.Request("pSubd")

                Dim json As String = Me.FRM000010_Get_Cost_Estimate_Cons(pCategory, pSubd)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Cost-Estimate" Then

                Dim pProjectType = context.Request("pProjectType")
                Dim pSubd = context.Request("pSubd")
                Dim pCategory = context.Request("pCategory")

                Dim json As String = Me.FRM000010_Get_Cost_Estimate(pProjectType, pSubd, pCategory)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "PR-Tagging" Then

                Dim pID = context.Request("pID")
                Dim pWBSNo = context.Request("pWBSNo")
                Dim pProjectCat = context.Request("pProjectCat")

                Dim json As String = Me.FRM000010_Get_PR_Tagging(pID, pWBSNo, pProjectCat)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Save-PR-Tagging" Then

                Dim pID = context.Request("pID")
                Dim pResultData = context.Request("pResultData")

                Dim json As String = Me.FRM000010_Add_PR_Tagging(pID, pResultData)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000010" And Type = "Return-PR-Tagging" Then

                Dim pItemNo = context.Request("pItemNo")
                Dim pParticular = context.Request("pParticular")
                Dim pQty = context.Request("pQty")
                Dim pID = context.Request("pID")
                Dim pLotCode = context.Request("pLotCode")

                Dim json As String = Me.FRM000010_Return_PR_Tagging(pItemNo, pParticular, pQty, pID, pLotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000011" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000011_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000011" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000011_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000012" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000012_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000012" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000012_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000013" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000013_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000013" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000013_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000014" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000014_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000014" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000014_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000016" And Type = "Get Fund" Then

                Dim Fund = context.Request("Fund")

                Dim json As String = Me.FRM000016_Get_Fund(Fund)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000016" And Type = "Get Subsidiary" Then

                Dim Expense = context.Request("Expense")

                Dim json As String = Me.FRM000016_Get_Subsidiary(Expense)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000016" And Type = "Get Description" Then

                Dim Expense = context.Request("Expense")

                Dim json As String = Me.FRM000016_Get_Description(Expense)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000016" And Type = "Get Payee" Then

                Dim Payee = context.Request("Payee")

                Dim json As String = Me.FRM000016_Get_Payee(Payee)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000017" And Type = "Get Payee" Then

                Dim Payee = context.Request("Payee")

                Dim json As String = Me.FRM000017_Get_Payee(Payee)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000022" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000022_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000022" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000022_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000022" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000022_Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000022" And Type = "Select Project" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000022_Get_Project_Info(Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000023" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000023_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000023" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000023_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000023" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000023_Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000023" And Type = "Select Project" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.FRM000023_Get_Project_Info(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000024" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000024_Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000024" And Type = "Select Project" Then

                Dim ID = context.Request("ID")

                Dim json As String = Me.FRM000024_Get_Project_Info(ID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000025" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000025_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000025" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000025_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000025" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000025_Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000025" And Type = "Select Project" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.FRM000025_Get_Project_Info(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000027" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000027_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000027" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000027_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000028" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000028_Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000028" And Type = "Select Project" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.FRM000028_Get_Project_Info(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000029" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000029_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000029" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000029_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000029" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000029_Get_Porject_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000029" And Type = "Select Project" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.FRM000029_Get_Project_Info(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000031" And Type = "Search Buyer" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000031_Get_Buyer_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000031" And Type = "Select Buyer" Then

                Dim AcctNo = context.Request("AcctNo")

                Dim json As String = Me.FRM000031_Get_Buyer_Info(AcctNo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000033" And Type = "Search Contract" Then

                Dim json As String = Me.FRM000033_Get_Contract_List()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000033" And Type = "Select Contract" Then

                Dim ID = context.Request("ID")

                Dim json As String = Me.FRM000033_Get_Contract_Info(ID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000036" And Type = "Get Phase" Then

                Dim ProjInit = context.Request("ProjInit")

                Dim json As String = Me.FRM000036_Get_Phase_Info(ProjInit)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000036" And Type = "Get Block" Then

                Dim ProjInit = context.Request("ProjInit")

                Dim json As String = Me.FRM000036_Get_Block_Info(ProjInit)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000036" And Type = "Get Lot" Then

                Dim ProjInit = context.Request("ProjInit")

                Dim json As String = Me.FRM000036_Get_Lot_Info(ProjInit)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000037" And Type = "Select Project" Then

                Dim Category = context.Request("Category")
                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000037_Get_Project_Info(Category, Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000037" And Type = "Search Project" Then

                Dim Category = context.Request("Category")
                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000037_Get_Project_List(Category, Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000038" And Type = "Search Project" Then

                Dim Search = context.Request("Search")

                Dim json As String = Me.FRM000038_Get_Project_List(Search)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000038" And Type = "Select Project" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000038_Get_Project_Info(Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "FRM000039" And Type = "Search Project" Then

                Dim json As String = Me.FRM000039_Get_Project_List()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000039" And Type = "Select Project" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.FRM000039_Get_Project_Info(Code)
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

#Region "DSB020000"

    Function DSB020000_Form(Status)

        'get form
        Dim Query As New StringBuilder
        If Status = "All" Then
            Query.Append("Select  ")
            Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
            Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
            Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
            Query.Append("   ,[Link] ")
            Query.Append("   ,[Icon] ")
            Query.Append("   ,[Title] ")
            Query.Append("   ,[ID] ")
            Query.Append("   ,[Name] ")
            Query.Append("   ,[Date] ")
            Query.Append("   ,[DateRequired] ")
            Query.Append("   ,[DateEnd] ")
            Query.Append("from ")
            Query.Append("   (select  ")
            Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
            Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
            Query.Append("      ,[A].FormTitle [Title] ")
            Query.Append("      ,[A].f_code [ID] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("      ,[A].created_date [Date] ")
            Query.Append("      ,[A].date_required [DateRequired] ")
            Query.Append("   from ")
            Query.Append("	    oop_form_hdr [A] ")
            Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
            Query.Append("   where ")
            Query.Append("      [A].approver = '" & CIIS_EmpCode & "' ")
            Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
            Query.Append("order by ")
            Query.Append("   [DateEnd] desc ")
        End If
        If Status = "Good" Then
            Query.Append("Select  ")
            Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
            Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
            Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
            Query.Append("   ,[Link] ")
            Query.Append("   ,[Icon] ")
            Query.Append("   ,[Title] ")
            Query.Append("   ,[ID] ")
            Query.Append("   ,[Name] ")
            Query.Append("   ,[Date] ")
            Query.Append("   ,[DateRequired] ")
            Query.Append("   ,[DateEnd] ")
            Query.Append("from ")
            Query.Append("   (select  ")
            Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
            Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
            Query.Append("      ,[A].FormTitle [Title] ")
            Query.Append("      ,[A].f_code [ID] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("      ,[A].created_date [Date] ")
            Query.Append("      ,[A].date_required [DateRequired] ")
            Query.Append("   from ")
            Query.Append("	    oop_form_hdr [A] ")
            Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
            Query.Append("   where ")
            Query.Append("      [A].approver = '" & CIIS_EmpCode & "' ")
            Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
            Query.Append("where ")
            Query.Append("   [DateEnd] > cast(getdate() As Date) ")
            Query.Append("order by ")
            Query.Append("   [DateEnd] desc ")
        End If
        If Status = "Due" Then
            Query.Append("Select  ")
            Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
            Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
            Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
            Query.Append("   ,[Link] ")
            Query.Append("   ,[Icon] ")
            Query.Append("   ,[Title] ")
            Query.Append("   ,[ID] ")
            Query.Append("   ,[Name] ")
            Query.Append("   ,[Date] ")
            Query.Append("   ,[DateRequired] ")
            Query.Append("   ,[DateEnd] ")
            Query.Append("from ")
            Query.Append("   (select  ")
            Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
            Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
            Query.Append("      ,[A].FormTitle [Title] ")
            Query.Append("      ,[A].f_code [ID] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("      ,[A].created_date [Date] ")
            Query.Append("      ,[A].date_required [DateRequired] ")
            Query.Append("   from ")
            Query.Append("	    oop_form_hdr [A] ")
            Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
            Query.Append("   where ")
            Query.Append("      [A].approver = '" & CIIS_EmpCode & "' ")
            Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
            Query.Append("where ")
            Query.Append("   [DateEnd] = cast(getdate() As Date) ")
            Query.Append("order by ")
            Query.Append("   [DateEnd] desc ")
        End If
        If Status = "Delay" Then
            Query.Append("Select  ")
            Query.Append("	 (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger'  ")
            Query.Append("	       when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning'  ")
            Query.Append("	       when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet]  ")
            Query.Append("   ,[Link] ")
            Query.Append("   ,[Icon] ")
            Query.Append("   ,[Title] ")
            Query.Append("   ,[ID] ")
            Query.Append("   ,[Name] ")
            Query.Append("   ,[Date] ")
            Query.Append("   ,[DateRequired] ")
            Query.Append("   ,[DateEnd] ")
            Query.Append("from ")
            Query.Append("   (select  ")
            Query.Append("      isnull((select top 1 [C].DateEnd from oop_form_dtl_appr [C] where [C].f_code = [A].f_code and [C].approver = [A].approver and [C].status = '' order by [C].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("      ,dbo.Get_Link([A].tbl_from) + '-DTL-' + replace([A].f_code,'#','No') [Link] ")
            Query.Append("      ,dbo.Get_Icon([A].tbl_from) [Icon] ")
            Query.Append("      ,[A].FormTitle [Title] ")
            Query.Append("      ,[A].f_code [ID] ")
            Query.Append("      ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Name] ")
            Query.Append("      ,[A].created_date [Date] ")
            Query.Append("      ,[A].date_required [DateRequired] ")
            Query.Append("   from ")
            Query.Append("	    oop_form_hdr [A] ")
            Query.Append("	    left join employee [B] on [A].created_by = [B].emp_no ")
            Query.Append("	    left join oop_form_type [C] on [A].form_type = [C].t_code ")
            Query.Append("   where ")
            Query.Append("      [A].approver = '" & CIIS_EmpCode & "' ")
            Query.Append("      and [A].status not in ('Accepted','Declined','Cancelled')) [A] ")
            Query.Append("where ")
            Query.Append("   [DateEnd] < cast(getdate() As Date) ")
            Query.Append("order by ")
            Query.Append("   [DateEnd] desc ")
        End If
        'get form

        'variable
        Dim FormList As New List(Of Object)()
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
                    Data.Append("<a href ='" & DR("Link") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("      <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("         <img alt ='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("      </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Title") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("ID") & " " & DR("Name") & " " & DR("Date") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'>")
                    Data.Append("      <span class='text-dark fw-bolder fs-6'>" & DR("DateRequired") & "</span>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Date Required</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'>")
                    Data.Append("      <span class='text-dark fw-bolder fs-6'>" & DR("DateEnd") & "</span>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Expected Approval</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

#Region "Form Assigned"

    Function DSB020000_Get_Form_All(Status)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""' + dbo.Get_Link(tbl_from) + '-DTL-' + form_no +'"">' + form_no + '</a>' [Link] ")
        Query.Append("      ,form_desc [FormDesc] ")
        Query.Append("      ,requested_by [RequestedBy] ")
        Query.Append("      ,(select top 1 [A].DateEnd from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [DateEnd] ")
        Query.Append("      ,(select top 1 (case when [A].DateEnd > cast(getdate() as date) then 'Good' when [A].DateEnd = cast(getdate() as date) then 'Due' when [A].DateEnd < cast(getdate() as date) then 'Delay' end) from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [Status] ")
        Query.Append("   from ")
        Query.Append("      form_hdr [H] ")
        Query.Append("   where ")
        Query.Append("       approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and status not in ('Accepted', 'Declined', 'Cancelled')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB020000_Get_Form_Details_All(Status)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  SUM([Less5Count]) [Less5Total] ")
        Query.Append("  ,SUM([Less10Count]) [Less10Total] ")
        Query.Append("  ,SUM([Less30Count]) [Less30Total] ")
        Query.Append("  ,SUM([Less60Count]) [Less60Total] ")
        Query.Append("  ,SUM([Less90Count]) [Less90Total] ")
        Query.Append("  ,SUM([Less180Count]) [Less180Total] ")
        Query.Append("  ,SUM([Less360Count]) [Less360Total] ")
        Query.Append("  ,SUM([Above360Count]) [Above360Total] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      SUM(CASE WHEN [Less5] <> '' THEN 1 ELSE 0 END) [Less5Count] ")
        Query.Append("      ,SUM(CASE WHEN [Less10] <> '' THEN 1 ELSE 0 END) [Less10Count] ")
        Query.Append("      ,SUM(CASE WHEN [Less30] <> '' THEN 1 ELSE 0 END) [Less30Count] ")
        Query.Append("      ,SUM(CASE WHEN [Less60] <> '' THEN 1 ELSE 0 END) [Less60Count] ")
        Query.Append("      ,SUM(CASE WHEN [Less90] <> '' THEN 1 ELSE 0 END) [Less90Count] ")
        Query.Append("      ,SUM(CASE WHEN [Less180] <> '' THEN 1 ELSE 0 END) [Less180Count] ")
        Query.Append("      ,SUM(CASE WHEN [Less360] <> '' THEN 1 ELSE 0 END) [Less360Count] ")
        Query.Append("      ,SUM(CASE WHEN [Above360] <> '' THEN 1 ELSE 0 END) [Above360Count] ")
        Query.Append("   from ")
        Query.Append("      (select ")
        Query.Append("          (CASE WHEN [Days] <= 5 THEN LTRIM(STR([Days])) ELSE '' END) AS [Less5] ")
        Query.Append("          ,(CASE WHEN [Days] BETWEEN 6 AND 10 THEN LTRIM(STR([Days])) ELSE '' END) [Less10] ")
        Query.Append("          ,(CASE WHEN [Days] BETWEEN 11 AND 30 THEN LTRIM(STR([Days])) ELSE '' END) [Less30] ")
        Query.Append("          ,(CASE WHEN [Days] BETWEEN 31 AND 60 THEN LTRIM(STR([Days])) ELSE '' END) [Less60] ")
        Query.Append("          ,(CASE WHEN [Days] BETWEEN 61 AND 90 THEN LTRIM(STR([Days])) ELSE '' END) [Less90] ")
        Query.Append("          ,(CASE WHEN [Days] BETWEEN 91 AND 180 THEN LTRIM(STR([Days])) ELSE '' END) [Less180] ")
        Query.Append("          ,(CASE WHEN [Days] BETWEEN 181 AND 360 THEN LTRIM(STR([Days])) ELSE '' END) [Less360] ")
        Query.Append("          ,(CASE WHEN [Days] >= 360 THEN LTRIM(STR([Days])) ELSE '' END) AS [Above360] ")
        Query.Append("      from ")
        Query.Append("          (select ")
        Query.Append("              (SELECT DATEDIFF(DAY, [A].DateEnd, GETDATE()) FROM Form_AssignedApprover [A] WHERE [A].f_code = [H].form_no AND [A].approver = [H].approver AND [A].type = [H].approver_type and [A].DateStart IS NOT NULL and [A].DateEnd IS NOT NULL ) [Days] ")
        Query.Append("              ,(SELECT TOP 1 CASE WHEN [A].DateEnd > CAST(GETDATE() AS DATE) THEN 'Good' WHEN [A].DateEnd = CAST(GETDATE() AS DATE) THEN 'Due' WHEN [A].DateEnd < CAST(GETDATE() AS DATE) THEN 'Delay' END FROM Form_AssignedApprover [A] WHERE [A].f_code = [H].form_no AND [A].approver = [H].approver AND [A].type = [H].approver_type) [Status] ")
        Query.Append("            from ")
        Query.Append("              form_hdr [H] ")
        Query.Append("            where ")
        Query.Append("            approver = '" & CIIS_EmpCode & "' ")
        Query.Append("            AND status NOT IN ('Accepted', 'Declined', 'Cancelled')) [tbl] ")
        Query.Append("              where ")
        Query.Append("                  [Status] = '" & Status & "') [tbl] ) [tbl] ")
        'get form

        'variable
        Dim FormDetailList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormDetailList.Add(New With {
                    .Less5 = DR("Less5Total"),
                    .Less10 = DR("Less10Total"),
                    .Less30 = DR("Less30Total"),
                    .Less60 = DR("Less60Total"),
                    .Less90 = DR("Less90Total"),
                    .Less180 = DR("Less180Total"),
                    .Less360 = DR("Less360Total"),
                    .Above360 = DR("Above360Total")
                })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormDetailList))
        'display 

    End Function

    Function DSB020000_Get_Form_Days_All(Status, Days)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""' + dbo.Get_Link(tbl_from) + '-DTL-' + form_no +'"">' + form_no + '</a>' [Link] ")
        Query.Append("      ,form_desc [FormDesc] ")
        Query.Append("      ,requested_by [RequestedBy] ")
        Query.Append("      ,(SELECT DATEDIFF(DAY, [A].DateEnd, GETDATE()) FROM Form_AssignedApprover [A] WHERE [A].f_code = [H].form_no AND [A].approver = [H].approver AND [A].type = [H].approver_type and [A].DateStart IS NOT NULL and [A].DateEnd IS NOT NULL) [Days] ")
        Query.Append("      ,(select top 1 [A].DateEnd from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [DateEnd] ")
        Query.Append("      ,(select top 1 (case when [A].DateEnd > cast(getdate() as date) then 'Good' when [A].DateEnd = cast(getdate() as date) then 'Due' when [A].DateEnd < cast(getdate() as date) then 'Delay' end) from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [Status] ")
        Query.Append("   from ")
        Query.Append("      form_hdr [H] ")
        Query.Append("   where ")
        Query.Append("      approver = '" & CIIS_EmpCode & "' ")
        Query.Append("      and status not in ('Accepted', 'Declined', 'Cancelled')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        Query.Append("          and [Days] " & Days & "  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

#End Region

#Region "Work Order"

    Function DSB020000_Get_WorkOrder_All(Status)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""FRM000001-DTL-' + wo_no +'"">' + wo_no + '</a>' [Link] ")
        Query.Append("      ,summary [FormDesc] ")
        Query.Append("      ,reported_by [RequestedBy] ")
        Query.Append("      ,date_end [DateEnd] ")
        Query.Append("      ,(case when date_end > cast(getdate() as date) then 'Good' when date_end = cast(getdate() as date) then 'Due' when date_end < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("   from ")
        Query.Append("      wo_hdr ")
        Query.Append("   where ")
        Query.Append("      AssignedTo = '" & CIIS_EmpCode & "' ")
        Query.Append("      and status not in ('Closed')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB020000_Get_WorkOrder_Details_All(Status)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append(" [Department]  ")
        Query.Append(" ,[Dept]  ")
        Query.Append(" ,count(*) [Count]  ")
        Query.Append("   from ")
        Query.Append("      (select ")
        Query.Append("          [H].date_end [DateEnd] ")
        Query.Append("          ,(case when date_end > cast(getdate() as date) then 'Good' when date_end = cast(getdate() as date) then 'Due' when date_end < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("          ,(select SUBSTRING(category, 1, 3) from oop_wo_hdr where wo_code = [H].wo_no) [Department] ")
        Query.Append("          ,[H].department [Dept] ")
        Query.Append("       from ")
        Query.Append("          wo_hdr [H] ")
        Query.Append("       where ")
        Query.Append("          AssignedTo = '" & CIIS_EmpCode & "' ")
        Query.Append("          and status not in ('Closed')) [tbl] ")
        Query.Append("         where ")
        Query.Append("          [Status] = '" & Status & "' ")
        Query.Append("          group by [Department], [Dept] ")
        'get form

        'variable
        Dim FormDetailList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormDetailList.Add(New With {
                        .Department = DR("Department"),
                        .Count = DR("Count"),
                        .Dept = DR("Dept")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormDetailList))
        'display 

    End Function

    Function DSB020000_Get_WorkOrder_Department_All(Status, Department)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""FRM000001-DTL-' + wo_no +'"">' + wo_no + '</a>' [Link] ")
        Query.Append("      ,summary [FormDesc] ")
        Query.Append("      ,reported_by [RequestedBy] ")
        Query.Append("      ,date_end [DateEnd] ")
        Query.Append("      ,(case when date_end > cast(getdate() as date) then 'Good' when date_end = cast(getdate() as date) then 'Due' when date_end < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("   from ")
        Query.Append("      wo_hdr ")
        Query.Append("   where ")
        Query.Append("      AssignedTo = '" & CIIS_EmpCode & "' ")
        Query.Append("      and status not in ('Closed') ")
        Query.Append("      and department = '" & Department & "' ) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
#End Region

#Region "Construction Task"

    Function DSB020000_Get_Task_All(Status)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      Form_HWTask.HWCode [Link] ")
        Query.Append("      ,mstr_Projects.ProjInit + ' ' +  Form_HWHdr.Phase + ' ' + Form_HWHdr.Block + ' ' + Form_HWHdr.Lot [FormDesc] ")
        Query.Append("      ,dbo.ProperCase(employee.fullname) [RequestedBy] ")
        Query.Append("      ,Form_HWTask.DateEnd [DateEnd] ")
        Query.Append("      ,(case when Form_HWTask.DateEnd > cast(getdate() as date) then 'Good' when Form_HWTask.DateEnd = cast(getdate() as date) then 'Due' when Form_HWTask.DateEnd < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("   from ")
        Query.Append("      Form_HWTask ")
        Query.Append("      left join Form_HWHdr on Form_HWTask.HWCode = Form_HWHdr.HWCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_Projects on Form_HWHdr.Subd = mstr_Projects.ProjCode ")
        Query.Append("      left join employee on Form_HWTask.CreatedBy = employee.emp_no ")
        Query.Append("   where ")
        Query.Append("      Form_HWTask.AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("      and Form_HWTask.Status not in ('Complete')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB020000_Get_Task_Details_All(Status)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [TaskName] ")
        Query.Append("  ,count(*) [Count] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      (case when Form_HWTask.DateEnd > cast(getdate() as date) then 'Good' when Form_HWTask.DateEnd = cast(getdate() as date) then 'Due' when Form_HWTask.DateEnd < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("      ,Form_HWTask.TaskName [TaskName] ")
        Query.Append("   from ")
        Query.Append("      Form_HWTask ")
        Query.Append("   where ")
        Query.Append("      Form_HWTask.AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("      and Form_HWTask.Status not in ('Complete')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        Query.Append("          group by [TaskName]  ")
        'get form

        'variable
        Dim FormDetailList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormDetailList.Add(New With {
                        .TaskName = DR("TaskName"),
                        .Count = DR("Count")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormDetailList))
        'display 

    End Function

    Function DSB020000_Get_Task_Name_All(Status, TaskName)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      Form_HWTask.HWCode [Link] ")
        Query.Append("      ,mstr_Projects.ProjInit + ' ' +  Form_HWHdr.Phase + ' ' + Form_HWHdr.Block + ' ' + Form_HWHdr.Lot [FormDesc] ")
        Query.Append("      ,dbo.ProperCase(employee.fullname) [RequestedBy] ")
        Query.Append("      ,Form_HWTask.DateEnd [DateEnd] ")
        Query.Append("      ,(case when Form_HWTask.DateEnd > cast(getdate() as date) then 'Good' when Form_HWTask.DateEnd = cast(getdate() as date) then 'Due' when Form_HWTask.DateEnd < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("   from ")
        Query.Append("      Form_HWTask ")
        Query.Append("      left join Form_HWHdr on Form_HWTask.HWCode = Form_HWHdr.HWCode ")
        Query.Append("      left join calmardbLive.dbo.mstr_Projects on Form_HWHdr.Subd = mstr_Projects.ProjCode ")
        Query.Append("      left join employee on Form_HWTask.CreatedBy = employee.emp_no ")
        Query.Append("   where ")
        Query.Append("      Form_HWTask.AssignTo = '" & CIIS_EmpCode & "' ")
        Query.Append("      and Form_HWTask.Status not in ('Complete') ")
        Query.Append("      and Form_HWTask.TaskName = '" & TaskName & "') [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
#End Region

#Region "My Request"

    Function DSB020000_Get_Request_All(Status)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""' + dbo.Get_Link(tbl_from) + '-DTL-' + form_no +'"">' + form_no + '</a>' [Link] ")
        Query.Append("      ,form_desc [FormDesc] ")
        Query.Append("      ,requested_by [RequestedBy] ")
        Query.Append("      ,(select top 1 [A].DateEnd from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [DateEnd] ")
        Query.Append("      ,(select top 1 (case when [A].DateEnd > cast(getdate() as date) then 'Good' when [A].DateEnd = cast(getdate() as date) then 'Due' when [A].DateEnd < cast(getdate() as date) then 'Delay' end) from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [Status] ")
        Query.Append("   from ")
        Query.Append("      form_hdr [H] ")
        Query.Append("   where ")
        Query.Append("      created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("      and status not in ('Accepted', 'Declined', 'Cancelled')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Function DSB020000_Get_Request_Details_All(Status)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Department] ")
        Query.Append("  ,count(*) [Count] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("  (select top 1 (case when [A].DateEnd > cast(getdate() as date) then 'Good' when [A].DateEnd = cast(getdate() as date) then 'Due' when [A].DateEnd < cast(getdate() as date) then 'Delay' end) from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [Status] ")
        Query.Append("  ,(select FormInit from oop_form_type where t_code = [H].form_code) [Department] ")
        Query.Append("  from ")
        Query.Append("      form_hdr [H] ")
        Query.Append("  where ")
        Query.Append("      created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("      and status not in ('Accepted', 'Declined', 'Cancelled')) [tbl]  ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "' ")
        Query.Append("      group by ")
        Query.Append("          [Department] ")
        'get form

        'variable
        Dim FormDetailList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader

                While DR.Read()

                    FormDetailList.Add(New With {
                        .Department = DR("Department"),
                        .Count = DR("Count")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormDetailList))
        'display 

    End Function
    Function DSB020000_Get_Request_FormInit_All(Status, FormInit)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""' + dbo.Get_Link(tbl_from) + '-DTL-' + form_no +'"">' + form_no + '</a>' [Link] ")
        Query.Append("      ,form_desc [FormDesc] ")
        Query.Append("      ,requested_by [RequestedBy] ")
        Query.Append("      ,(select top 1 [A].DateEnd from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [DateEnd] ")
        Query.Append("      ,(select top 1 (case when [A].DateEnd > cast(getdate() as date) then 'Good' when [A].DateEnd = cast(getdate() as date) then 'Due' when [A].DateEnd < cast(getdate() as date) then 'Delay' end) from Form_AssignedApprover [A] where [A].f_code = [H].form_no and [A].approver = [H].approver and [A].type = [H].approver_type) [Status] ")
        Query.Append("   from ")
        Query.Append("      form_hdr [H] ")
        Query.Append("      left join oop_form_type [I] on [H].form_code = [I].t_code ")
        Query.Append("   where ")
        Query.Append("      created_by = '" & CIIS_EmpCode & "' ")
        Query.Append("      and status not in ('Accepted', 'Declined', 'Cancelled') ")
        Query.Append("      and [I].FormInit = '" & FormInit & "' ")
        Query.Append("      and [I].FormInit IS NOT NULL) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
#End Region

#Region "My Request Work Order"

    Function DSB020000_Get_RequestWO_All(Status)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""FRM000001-DTL-' + wo_no +'"">' + wo_no + '</a>' [Link] ")
        Query.Append("      ,summary [FormDesc] ")
        Query.Append("      ,reported_by [RequestedBy] ")
        Query.Append("      ,date_end [DateEnd] ")
        Query.Append("      ,(case when date_end > cast(getdate() as date) then 'Good' when date_end = cast(getdate() as date) then 'Due' when date_end < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("   from ")
        Query.Append("      wo_hdr ")
        Query.Append("   where ")
        Query.Append("      CreatedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("	    and AssignedTo not in ('') ")
        Query.Append("      and status not in ('Closed')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
    Function DSB020000_Get_RequestWO_Details_All(Status)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [Department] ")
        Query.Append("  ,[Dept] ")
        Query.Append("  ,count(*) [Count] ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("      (case when date_end > cast(getdate() as date) then 'Good' when date_end = cast(getdate() as date) then 'Due' when date_end < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("     ,(select SUBSTRING(category, 1, 3) from oop_wo_hdr where wo_code = wo_hdr.wo_no) [Department] ")
        Query.Append("     ,department [Dept] ")
        Query.Append("  from ")
        Query.Append("      wo_hdr ")
        Query.Append("  where ")
        Query.Append("      CreatedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("      and AssignedTo not in ('') ")
        Query.Append("      and status not in ('Closed')) [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "' ")
        Query.Append("      group by ")
        Query.Append("          [Department], [Dept] ")
        'get form

        'variable
        Dim FormDetailList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    FormDetailList.Add(New With {
                        .Department = DR("Department"),
                        .Dept = DR("Dept"),
                        .Count = DR("Count")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormDetailList))
        'display 

    End Function
    Function DSB020000_Get_RequestWO_Department_All(Status, Department)

        'get form 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  * ")
        Query.Append("from ")
        Query.Append("  (select ")
        Query.Append("   '<a class=""pointer"" href=""FRM000001-DTL-' + wo_no +'"">' + wo_no + '</a>' [Link] ")
        Query.Append("      ,summary [FormDesc] ")
        Query.Append("      ,reported_by [RequestedBy] ")
        Query.Append("      ,date_end [DateEnd] ")
        Query.Append("      ,(case when date_end > cast(getdate() as date) then 'Good' when date_end = cast(getdate() as date) then 'Due' when date_end < cast(getdate() as date) then 'Delay' end) [Status] ")
        Query.Append("   from ")
        Query.Append("      wo_hdr ")
        Query.Append("   where ")
        Query.Append("      CreatedBy = '" & CIIS_EmpCode & "' ")
        Query.Append("	    and AssignedTo not in ('') ")
        Query.Append("      and status not in ('Closed') ")
        Query.Append("      and department = '" & Department & "') [tbl] ")
        Query.Append("      where ")
        Query.Append("          [Status] = '" & Status & "'  ")
        'get form

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""

                    If Status = "Good" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-info'></span>"
                    ElseIf Status = "Due" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-warning'></span>"
                    ElseIf Status = "Delay" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-danger'></span>"
                    End If

                    FormList.Add(New With {
                        .Bullet = Bullet,
                        .Link = DR("Link"),
                        .FormDesc = DR("FormDesc"),
                        .RequestedBy = DR("RequestedBy"),
                        .DateEnd = Format(DR("DateEnd"), "MM/dd/yyyy"),
                        .Status = DR("Status")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function
#End Region

#End Region

#Region "DSB030000"

    Function DSB030000_Get_Total_Per_Form(Status)

        'get count
        Dim Query As New StringBuilder
        If Status = "Open" Then
            Query.Append("select ")
            Query.Append("  * ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  count(*) [Count] ")
            Query.Append("  ,'Open Form' [Category] ")
            Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("  ,[A].form_type [Type] ")
            Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("from ")
            Query.Append("  form_hdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and year([A].date_start) <= year(getdate()) ")
            Query.Append("group by ")
            Query.Append("  [A].form_type ")
            Query.Append("  ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("  [Form] is not null ")
            Query.Append("order by ")
            Query.Append("  [Count] DESC ")
        End If
        If Status = "Closed" Then
            Query.Append("select ")
            Query.Append("  * ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  count(*) [Count] ")
            Query.Append("  ,'Closed Form' [Category] ")
            Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("  ,[A].form_type [Type] ")
            Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("from ")
            Query.Append("  form_hdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].status in ('Accepted') ")
            Query.Append("  and year([A].date_start) = year(getdate()) ")
            Query.Append("group by ")
            Query.Append("  [A].form_type ")
            Query.Append("  ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("  [Form] is not null ")
            Query.Append("order by ")
            Query.Append("  [Count] DESC ")
        End If
        If Status = "Total" Then
            Query.Append("select ")
            Query.Append("  * ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  count(*) [Count] ")
            Query.Append("  ,'Open Form' [Category] ")
            Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("  ,[A].form_type [Type] ")
            Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("from ")
            Query.Append("  form_hdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and year([A].date_start) <= year(getdate()) ")
            Query.Append("group by ")
            Query.Append("  [A].form_type ")
            Query.Append("  ,[A].tbl_from) [Tbl] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("  * ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  count(*) [Count] ")
            Query.Append("  ,'Closed Form' [Category] ")
            Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("  ,[A].form_type [Type] ")
            Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("from ")
            Query.Append("  form_hdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].status in ('Accepted') ")
            Query.Append("  and year([A].date_start) = year(getdate()) ")
            Query.Append("group by ")
            Query.Append("  [A].form_type ")
            Query.Append("  ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("  [Form] is not null ")
            Query.Append("order by ")
            Query.Append("  [Count] DESC ")
        End If
        'get count

        'variable
        Dim FormList As New List(Of Object)()
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
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")

                    Dim Badge As String
                    If DR("Category") = "Open Form" Then
                        Badge = "<span class='badge badge-success badge-square p-2'>Open Form</span>"
                    ElseIf DR("Category") = "Closed Form" Then
                        Badge = "<span class='badge badge-info badge-square p-2'>Closed Form</span>"
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<div id='" & DR("Type") & "' data-category='" & DR("Category") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("      <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("         <img alt ='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("      </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Form") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>" & Badge & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total Form</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Count"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Total_Per_Month(Month, Status)

        'get query
        Dim Query As New StringBuilder
        If Status = "Open" Then
            If Month = Date.Today.Year Then
                Query.Append("select ")
                Query.Append("  * ")
                Query.Append("from ")
                Query.Append("(select ")
                Query.Append("  count(*) [Count] ")
                Query.Append("  ,'Open Form' [Category] ")
                Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
                Query.Append("  ,[A].form_type [Type] ")
                Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
                Query.Append("from ")
                Query.Append("  form_hdr [A] ")
                Query.Append("where ")
                Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
                Query.Append("  and year([A].date_start) < year(getdate()) ")
                Query.Append("group by ")
                Query.Append("  [A].form_type ")
                Query.Append("  ,[A].tbl_from) [Tbl] ")
                Query.Append("where ")
                Query.Append("  [Form] is not null ")
                Query.Append("order by ")
                Query.Append("  [Count] DESC ")
            Else
                Query.Append("select ")
                Query.Append("  * ")
                Query.Append("from ")
                Query.Append("(select ")
                Query.Append("  count(*) [Count] ")
                Query.Append("  ,'Open Form' [Category] ")
                Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
                Query.Append("  ,[A].form_type [Type] ")
                Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
                Query.Append("from ")
                Query.Append("  form_hdr [A] ")
                Query.Append("where ")
                Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
                Query.Append("  and year([A].date_start) <= year(getdate()) ")
                Query.Append("  and month([A].date_start) = '" & Month & "' ")
                Query.Append("group by ")
                Query.Append("  [A].form_type ")
                Query.Append("  ,[A].tbl_from) [Tbl] ")
                Query.Append("where ")
                Query.Append("  [Form] is not null ")
                Query.Append("order by ")
                Query.Append("  [Count] DESC ")
            End If
        End If
        If Status = "Closed" Then
            If Month = Date.Today.Year Then
                Query.Append("select '' ")
            Else
                Query.Append("select ")
                Query.Append("  * ")
                Query.Append("from ")
                Query.Append("(select ")
                Query.Append("  count(*) [Count] ")
                Query.Append("  ,'Closed Form' [Category] ")
                Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
                Query.Append("  ,[A].form_type [Type] ")
                Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
                Query.Append("from ")
                Query.Append("  form_hdr [A] ")
                Query.Append("where ")
                Query.Append("  [A].status in ('Accepted') ")
                Query.Append("  and year([A].date_start) = year(getdate()) ")
                Query.Append("  and month([A].date_start) = '" & Month & "' ")
                Query.Append("group by ")
                Query.Append("  [A].form_type ")
                Query.Append("  ,[A].tbl_from) [Tbl] ")
                Query.Append("where ")
                Query.Append("  [Form] is not null ")
                Query.Append("order by ")
                Query.Append("  [Count] DESC ")
            End If
        End If
        If Status = "Total" Then
            If Month = Date.Today.Year Then
                Query.Append("select ")
                Query.Append("  * ")
                Query.Append("from ")
                Query.Append("(select ")
                Query.Append("  count(*) [Count] ")
                Query.Append("  ,'Open Form' [Category] ")
                Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
                Query.Append("  ,[A].form_type [Type] ")
                Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
                Query.Append("from ")
                Query.Append("  form_hdr [A] ")
                Query.Append("where ")
                Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
                Query.Append("  and year([A].date_start) < year(getdate()) ")
                Query.Append("group by ")
                Query.Append("  [A].form_type ")
                Query.Append("  ,[A].tbl_from) [Tbl] ")
                Query.Append("where ")
                Query.Append("  [Form] is not null ")
                Query.Append("order by ")
                Query.Append("  [Count] DESC ")
            Else
                Query.Append("select ")
                Query.Append("  * ")
                Query.Append("from ")
                Query.Append("(select ")
                Query.Append("  count(*) [Count] ")
                Query.Append("  ,'Open Form' [Category] ")
                Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
                Query.Append("  ,[A].form_type [Type] ")
                Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
                Query.Append("from ")
                Query.Append("  form_hdr [A] ")
                Query.Append("where ")
                Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
                Query.Append("  and year([A].date_start) <= year(getdate()) ")
                Query.Append("  and month([A].date_start) <= '" & Month & "' ")
                Query.Append("group by ")
                Query.Append("  [A].form_type ")
                Query.Append("  ,[A].tbl_from) [Tbl] ")
                Query.Append("union ")
                Query.Append("select ")
                Query.Append("  * ")
                Query.Append("from ")
                Query.Append("(select ")
                Query.Append("  count(*) [Count] ")
                Query.Append("  ,'Closed Form' [Category] ")
                Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
                Query.Append("  ,[A].form_type [Type] ")
                Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
                Query.Append("from ")
                Query.Append("  form_hdr [A] ")
                Query.Append("where ")
                Query.Append("  [A].status in ('Accepted') ")
                Query.Append("  and year([A].date_start) = year(getdate()) ")
                Query.Append("  and month([A].date_start) = '" & Month & "' ")
                Query.Append("group by ")
                Query.Append("  [A].form_type ")
                Query.Append("  ,[A].tbl_from) [Tbl] ")
                Query.Append("where ")
                Query.Append("  [Form] is not null ")
                Query.Append("order by ")
                Query.Append("  [Count] DESC ")
            End If
        End If
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")

                    Dim Badge As String
                    If DR("Category") = "Open Form" Then
                        Badge = "<span class='badge badge-success badge-square p-2'>Open Form</span>"
                    ElseIf DR("Category") = "Closed Form" Then
                        Badge = "<span class='badge badge-info badge-square p-2'>Closed Form</span>"
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<div id='" & DR("Type") & "' data-category='" & DR("Category") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("      <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("         <img alt ='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("      </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Form") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>" & Badge & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total Form</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Count"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Dept(DeptCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  DepCode ")
        Query.Append("  ,DepName ")
        Query.Append("  ,Total ")
        Query.Append("  ,Age1 ")
        Query.Append("  ,Age2 ")
        Query.Append("  ,Age3 ")
        Query.Append("  ,Age4 ")
        Query.Append("  ,Age5 ")
        Query.Append("  ,Age6 ")
        Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [Department] ")
        Query.Append("from ")
        Query.Append("  Rpt_AgingFormDep ")
        Query.Append("where ")
        Query.Append("  DepCode = '" & DeptCode & "' ")
        Query.Append("order by ")
        Query.Append("  SeqNo ")
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")

                    Dim Data As New StringBuilder
                    Data.Append("<div id='" & DR("DepCode") & "' data-name='" & DR("DepName") & "' class='d-flex align-items-center w-100' onclick='ViewAgingDetails(this, this.id);'>")
                    Data.Append("   <div class='d-flex flex-column min-w-250px w-100 pointer'>")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Department") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>" & DR("DepName") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Total"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age1"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age2"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age3"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age4"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age5"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'> > 30</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age6"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Emp(DeptCode)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("  '' [EmpCode] ")
        Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
        Query.Append("  ,'' [Total] ")
        Query.Append("  ,'' [Age1] ")
        Query.Append("  ,'' [Age2] ")
        Query.Append("  ,'' [Age3] ")
        Query.Append("  ,'' [Age4] ")
        Query.Append("  ,'' [Age5] ")
        Query.Append("  ,'' [Age6] ")
        Query.Append("  ,SecName ")
        Query.Append("  ,1 [SeqNo] ")
        Query.Append("from ")
        Query.Append("  Rpt_AgingFormEmp ")
        Query.Append("Where ")
        Query.Append("  DepCode = '" & DeptCode & "' ")
        Query.Append("  and SecName != '' ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("  EmpCode ")
        Query.Append("  ,EmpName ")
        Query.Append("  ,ltrim(str(Total)) [Total] ")
        Query.Append("  ,ltrim(str(Age1)) [Age1] ")
        Query.Append("  ,ltrim(str(Age2)) [Age2] ")
        Query.Append("  ,ltrim(str(Age3)) [Age3] ")
        Query.Append("  ,ltrim(str(Age4)) [Age4] ")
        Query.Append("  ,ltrim(str(Age5)) [Age5] ")
        Query.Append("  ,ltrim(str(Age6)) [Age6] ")
        Query.Append("  ,SecName ")
        Query.Append("  ,2 [SeqNo] ")
        Query.Append("from ")
        Query.Append("  Rpt_AgingFormEmp ")
        Query.Append("Where ")
        Query.Append("  DepCode = '" & DeptCode & "' ")
        Query.Append("order by ")
        Query.Append("  SecName ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,EmpName ")
        'get query 

        'variable
        Dim FormList As New List(Of Object)()
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

                    Dim Data As New StringBuilder
                    If DR("EmpCode") = "" Then
                        Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-dark'></span></div>")
                        Data.Append("<div class='d-flex align-items-center w-100'>")
                        Data.Append("   <div class='d-flex flex-column min-w-250px w-100' >")
                        Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto pb-2'>" & DR("EmpName") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("</div>")
                    Else
                        Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")
                        Data.Append("<div id='" & DR("EmpCode") & "' class='d-flex align-items-center pointer w-100' onclick='ViewEmpDetails(this.id);'>")
                        Data.Append("   <div class='d-flex flex-column min-w-250px w-100' >")
                        Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("EmpName") & "</span>")
                        Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>Employee</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Total") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age1") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age2") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age3") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age4") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age5") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'> > 30</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age6") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("</div>")
                    End If
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Details(EmpCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
        Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
        Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
        Query.Append("  ,[Link] ")
        Query.Append("  ,[Icon] ")
        Query.Append("  ,[Title] ")
        Query.Append("  ,[ID] ")
        Query.Append("  ,[Name] ")
        Query.Append("  ,[Date] ")
        Query.Append("  ,[DateRequired] ")
        Query.Append("  ,[DateEnd] ")
        Query.Append("  ,[Total] ")
        Query.Append("  ,[Age1] ")
        Query.Append("  ,[Age2] ")
        Query.Append("  ,[Age3] ")
        Query.Append("  ,[Age4] ")
        Query.Append("  ,[Age5] ")
        Query.Append("  ,[Age6] ")
        Query.Append("from ")
        Query.Append("      (select ")
        Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
        Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
        Query.Append("          ,[A].FormSummary [Title] ")
        Query.Append("          ,[A].FormNo [ID] ")
        Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("          ,[B].created_date [Date] ")
        Query.Append("          ,[B].date_required [DateRequired] ")
        Query.Append("          ,[A].Total [Total] ")
        Query.Append("          ,[A].Age1 [Age1] ")
        Query.Append("          ,[A].Age2 [Age2] ")
        Query.Append("          ,[A].Age3 [Age3] ")
        Query.Append("          ,[A].Age4 [Age4] ")
        Query.Append("          ,[A].Age5 [Age5] ")
        Query.Append("          ,[A].Age6 [Age6] ")
        Query.Append("      from ")
        Query.Append("          Rpt_AgingFormDtl [A] ")
        Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
        Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
        Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
        Query.Append("      where ")
        Query.Append("          [A].EmpCode = '" & EmpCode & "') [A] ")
        Query.Append("order by ")
        Query.Append("  [DateEnd] DESC ")
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Data.Append("<a href ='" & DR("Link") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("      <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("         <img alt ='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("      </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-300px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 flex-nowrap'>" & DR("Title") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Total") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age1") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age2") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age3") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age4") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age5") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>> 30</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age6") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Year(Year)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].DepName ")
        Query.Append("  ,[A].DepCode ")
        Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = [A].DepCode) [Department] ")
        Query.Append("  ,count(*) [Total] ")
        Query.Append("  ,(select count(*) from form_hdr [D] left join employee [E] on [D].approver = [E].emp_no where [D].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = '" & Year & "' and [E].dept_code = [A].DepCode and datediff(day,getdate(),[D].date_end) >= 0) [Age1] ")
        Query.Append("  ,(select count(*) from form_hdr [D] left join employee [E] on [D].approver = [E].emp_no where [D].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = '" & Year & "' and [E].dept_code = [A].DepCode and datediff(day,getdate(),[D].date_end) between -7 and -1) [Age2] ")
        Query.Append("  ,(select count(*) from form_hdr [D] left join employee [E] on [D].approver = [E].emp_no where [D].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = '" & Year & "' and [E].dept_code = [A].DepCode and datediff(day,getdate(),[D].date_end) between -15 and -8) [Age3] ")
        Query.Append("  ,(select count(*) from form_hdr [D] left join employee [E] on [D].approver = [E].emp_no where [D].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = '" & Year & "' and [E].dept_code = [A].DepCode and datediff(day,getdate(),[D].date_end) between -22 and -16) [Age4] ")
        Query.Append("  ,(select count(*) from form_hdr [D] left join employee [E] on [D].approver = [E].emp_no where [D].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = '" & Year & "' and [E].dept_code = [A].DepCode and datediff(day,getdate(),[D].date_end) between -30 and -23) [Age5] ")
        Query.Append("  ,(select count(*) from form_hdr [D] left join employee [E] on [D].approver = [E].emp_no where [D].status not in ('Accepted', 'Cancelled', 'Declined') and year(date_start) = '" & Year & "' and [E].dept_code = [A].DepCode and datediff(day,getdate(),[D].date_end) < -30) [Age6] ")
        Query.Append("from ")
        Query.Append("  Rpt_AgingFormDep [A] ")
        Query.Append("  left join Rpt_AgingFormEmp [B] on [A].DepCode = [B].DepCode ")
        Query.Append("  left join form_hdr [C] on [B].EmpCode = [C].approver ")
        Query.Append("where ")
        Query.Append("  [C].status not in ('Accepted', 'Cancelled', 'Declined') ")
        Query.Append("  and year([C].date_start) = '" & Year & "' ")
        Query.Append("group by ")
        Query.Append("  [A].DepName ")
        Query.Append("  ,[A].DepCode ")
        Query.Append("order by ")
        Query.Append("  [A].DepName ")
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")

                    Dim Data As New StringBuilder
                    Data.Append("<div id='" & DR("DepCode") & "' data-year='" & Year & "' class='d-flex align-items-center w-100' onclick='ViewAgingYrDetails(this, this.id);'>")
                    Data.Append("   <div class='d-flex flex-column min-w-250px w-100 pointer'>")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Department") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>" & DR("DepName") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Total"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age1"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age2"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age3"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age4"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age5"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'> > 30</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age6"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Year_Details(Year, DeptCode)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("  '' [EmpCode] ")
        Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
        Query.Append("  ,'' [Total] ")
        Query.Append("  ,'' [Age1] ")
        Query.Append("  ,'' [Age2] ")
        Query.Append("  ,'' [Age3] ")
        Query.Append("  ,'' [Age4] ")
        Query.Append("  ,'' [Age5] ")
        Query.Append("  ,'' [Age6] ")
        Query.Append("  ,SecName ")
        Query.Append("  ,1 [SeqNo] ")
        Query.Append("from ")
        Query.Append("  Rpt_AgingFormEmp [A] ")
        Query.Append("  left join form_hdr [B] on [A].EmpCode = [B].approver ")
        Query.Append("Where ")
        Query.Append("  DepCode = '" & DeptCode & "' ")
        Query.Append("  and SecName != '' ")
        Query.Append("  and [B].status not in ('Accepted', 'Cancelled', 'Declined') ")
        Query.Append("  and year([B].date_start) = '" & Year & "' ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("  EmpCode ")
        Query.Append("  ,EmpName ")
        Query.Append("  ,(select count(*) from form_hdr [D] where [D].status not in ('Accepted', 'Cancelled', 'Declined') and [D].approver = [A].EmpCode and year([D].date_start) = '" & Year & "') [Total] ")
        Query.Append("  ,(select count(*) from form_hdr [D] where [D].status not in ('Accepted', 'Cancelled', 'Declined') and [D].approver = [A].EmpCode and year(date_start) = '" & Year & "' and datediff(day,getdate(),[D].date_end) >= 0) [Age1] ")
        Query.Append("  ,(select count(*) from form_hdr [D] where [D].status not in ('Accepted', 'Cancelled', 'Declined') and [D].approver = [A].EmpCode and year(date_start) = '" & Year & "' and datediff(day,getdate(),[D].date_end) between -7 and -1) [Age2] ")
        Query.Append("  ,(select count(*) from form_hdr [D] where [D].status not in ('Accepted', 'Cancelled', 'Declined') and [D].approver = [A].EmpCode and year(date_start) = '" & Year & "' and datediff(day,getdate(),[D].date_end) between -15 and -8) [Age3] ")
        Query.Append("  ,(select count(*) from form_hdr [D] where [D].status not in ('Accepted', 'Cancelled', 'Declined') and [D].approver = [A].EmpCode and year(date_start) = '" & Year & "' and datediff(day,getdate(),[D].date_end) between -22 and -16) [Age4] ")
        Query.Append("  ,(select count(*) from form_hdr [D] where [D].status not in ('Accepted', 'Cancelled', 'Declined') and [D].approver = [A].EmpCode and year(date_start) = '" & Year & "' and datediff(day,getdate(),[D].date_end) between -30 and -23) [Age5] ")
        Query.Append("  ,(select count(*) from form_hdr [D] where [D].status not in ('Accepted', 'Cancelled', 'Declined') and [D].approver = [A].EmpCode and year(date_start) = '" & Year & "' and datediff(day,getdate(),[D].date_end) < -30) [Age6] ")
        Query.Append("  ,SecName ")
        Query.Append("  ,2 [SeqNo] ")
        Query.Append("from ")
        Query.Append("  Rpt_AgingFormEmp [A] ")
        Query.Append("  left join form_hdr [B] on [A].EmpCode = [B].approver ")
        Query.Append("Where ")
        Query.Append("  DepCode = '" & DeptCode & "' ")
        Query.Append("  and [B].status not in ('Accepted', 'Cancelled', 'Declined') ")
        Query.Append("  and year([B].date_start) = '" & Year & "' ")
        Query.Append("order by ")
        Query.Append("  SecName ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,EmpName ")
        'get query 

        'variable
        Dim FormList As New List(Of Object)()
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

                    Dim Data As New StringBuilder
                    If DR("EmpCode") = "" Then
                        Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-dark'></span></div>")
                        Data.Append("<div class='d-flex align-items-center w-100'>")
                        Data.Append("   <div class='d-flex flex-column min-w-250px w-100' >")
                        Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto pb-2'>" & DR("EmpName") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("</div>")
                    Else
                        Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")
                        Data.Append("<div id='" & DR("EmpCode") & "' data-year='" & Year & "' class='d-flex align-items-center pointer w-100' onclick='ViewEmpYrDetails(this, this.id);'>")
                        Data.Append("   <div class='d-flex flex-column min-w-250px w-100' >")
                        Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("EmpName") & "</span>")
                        Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>Employee</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Total") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age1") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age2") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age3") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age4") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age5") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'> > 30</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age6") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("</div>")
                    End If
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Year_Emp_Details(Code, Year)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
        Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
        Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
        Query.Append("  ,[Link] ")
        Query.Append("  ,[Icon] ")
        Query.Append("  ,[Title] ")
        Query.Append("  ,[ID] ")
        Query.Append("  ,[Name] ")
        Query.Append("  ,[Date] ")
        Query.Append("  ,[DateRequired] ")
        Query.Append("  ,[DateEnd] ")
        Query.Append("  ,[Total] ")
        Query.Append("  ,[Age1] ")
        Query.Append("  ,[Age2] ")
        Query.Append("  ,[Age3] ")
        Query.Append("  ,[Age4] ")
        Query.Append("  ,[Age5] ")
        Query.Append("  ,[Age6] ")
        Query.Append("from ")
        Query.Append("      (select ")
        Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
        Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
        Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
        Query.Append("          ,[A].FormSummary [Title] ")
        Query.Append("          ,[A].FormNo [ID] ")
        Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
        Query.Append("          ,[B].created_date [Date] ")
        Query.Append("          ,[B].date_required [DateRequired] ")
        Query.Append("          ,[A].Total [Total] ")
        Query.Append("          ,[A].Age1 [Age1] ")
        Query.Append("          ,[A].Age2 [Age2] ")
        Query.Append("          ,[A].Age3 [Age3] ")
        Query.Append("          ,[A].Age4 [Age4] ")
        Query.Append("          ,[A].Age5 [Age5] ")
        Query.Append("          ,[A].Age6 [Age6] ")
        Query.Append("      from ")
        Query.Append("          Rpt_AgingFormDtl [A] ")
        Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
        Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
        Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
        Query.Append("          left join form_hdr [E] on [B].f_code = [E].form_no ")
        Query.Append("      where ")
        Query.Append("          [A].EmpCode = '" & Code & "' ")
        Query.Append("          and [E].status not in ('Accepted', 'Cancelled', 'Declined') ")
        Query.Append("          and year([E].date_start) = '" & Year & "') [A] ")
        Query.Append("order by ")
        Query.Append("  [DateEnd] DESC ")
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Data.Append("<a href ='" & DR("Link") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("      <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("         <img alt ='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("      </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-300px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 flex-nowrap'>" & DR("Title") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Total") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age1") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age2") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age3") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age4") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age5") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>> 30</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age6") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Year_Chart(Year)

        'get query
        Dim Query As New StringBuilder
        If Year = "Previous" Then
            Query.Append("select ")
            Query.Append("  * ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  count(*) [Count] ")
            Query.Append("  ,'Open Form' [Category] ")
            Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("  ,[A].form_type [Type] ")
            Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("from ")
            Query.Append("  form_hdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and year([A].date_start) < year(getdate()) ")
            Query.Append("group by ")
            Query.Append("  [A].form_type ")
            Query.Append("  ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("  [Form] is not null ")
            Query.Append("order by ")
            Query.Append("  [Count] DESC ")
        End If
        If Year <> "Previous" Then
            Query.Append("select ")
            Query.Append("  * ")
            Query.Append("from ")
            Query.Append("(select ")
            Query.Append("  count(*) [Count] ")
            Query.Append("  ,'Open Form' [Category] ")
            Query.Append("  ,(select [B].description from oop_form_type [B] where t_code = [A].form_type) [Form] ")
            Query.Append("  ,[A].form_type [Type] ")
            Query.Append("  ,(case when dbo.Get_Icon([A].tbl_from) is null or dbo.Get_Icon([A].tbl_from) = '' then 'assets/media/svg/apps/FRM000009.svg' else dbo.Get_Icon([A].tbl_from) end) [Icon] ")
            Query.Append("from ")
            Query.Append("  form_hdr [A] ")
            Query.Append("where ")
            Query.Append("  [A].status not in ('Accepted', 'Cancelled', 'Declined') ")
            Query.Append("  and year([A].date_start) = '" & Year & "' ")
            Query.Append("group by ")
            Query.Append("  [A].form_type ")
            Query.Append("  ,[A].tbl_from) [Tbl] ")
            Query.Append("where ")
            Query.Append("  [Form] is not null ")
            Query.Append("order by ")
            Query.Append("  [Count] DESC ")
        End If
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")

                    Dim Badge As String
                    If DR("Category") = "Open Form" Then
                        Badge = "<span class='badge badge-success badge-square p-2'>Open Form</span>"
                    ElseIf DR("Category") = "Closed Form" Then
                        Badge = "<span class='badge badge-info badge-square p-2'>Closed Form</span>"
                    End If

                    Dim Data As New StringBuilder
                    Data.Append("<div id='" & DR("Type") & "' data-category='" & DR("Category") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("      <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("         <img alt ='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("      </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Form") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>" & Badge & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total Form</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Count"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Aging(Aging)

        'get query
        Dim Query As New StringBuilder
        If Aging = "Within" Then
            Query.Append("select ")
            Query.Append("  DepCode ")
            Query.Append("  ,DepName ")
            Query.Append("  ,Total ")
            Query.Append("  ,Age1 ")
            Query.Append("  ,Age2 ")
            Query.Append("  ,Age3 ")
            Query.Append("  ,Age4 ")
            Query.Append("  ,Age5 ")
            Query.Append("  ,Age6 ")
            Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [Department] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormDep ")
            Query.Append("where ")
            Query.Append("  Age1 != 0 ")
            Query.Append("order by ")
            Query.Append("  SeqNo ")
        End If
        If Aging = "1 to 7 days" Then
            Query.Append("select ")
            Query.Append("  DepCode ")
            Query.Append("  ,DepName ")
            Query.Append("  ,Total ")
            Query.Append("  ,Age1 ")
            Query.Append("  ,Age2 ")
            Query.Append("  ,Age3 ")
            Query.Append("  ,Age4 ")
            Query.Append("  ,Age5 ")
            Query.Append("  ,Age6 ")
            Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [Department] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormDep ")
            Query.Append("where ")
            Query.Append("  Age2 != 0 ")
            Query.Append("order by ")
            Query.Append("  SeqNo ")
        End If
        If Aging = "8 to 15 days" Then
            Query.Append("select ")
            Query.Append("  DepCode ")
            Query.Append("  ,DepName ")
            Query.Append("  ,Total ")
            Query.Append("  ,Age1 ")
            Query.Append("  ,Age2 ")
            Query.Append("  ,Age3 ")
            Query.Append("  ,Age4 ")
            Query.Append("  ,Age5 ")
            Query.Append("  ,Age6 ")
            Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [Department] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormDep ")
            Query.Append("where ")
            Query.Append("  Age3 != 0 ")
            Query.Append("order by ")
            Query.Append("  SeqNo ")
        End If
        If Aging = "16 to 22 days" Then
            Query.Append("select ")
            Query.Append("  DepCode ")
            Query.Append("  ,DepName ")
            Query.Append("  ,Total ")
            Query.Append("  ,Age1 ")
            Query.Append("  ,Age2 ")
            Query.Append("  ,Age3 ")
            Query.Append("  ,Age4 ")
            Query.Append("  ,Age5 ")
            Query.Append("  ,Age6 ")
            Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [Department] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormDep ")
            Query.Append("where ")
            Query.Append("  Age4 != 0 ")
            Query.Append("order by ")
            Query.Append("  SeqNo ")
        End If
        If Aging = "23 to 30 days" Then
            Query.Append("select ")
            Query.Append("  DepCode ")
            Query.Append("  ,DepName ")
            Query.Append("  ,Total ")
            Query.Append("  ,Age1 ")
            Query.Append("  ,Age2 ")
            Query.Append("  ,Age3 ")
            Query.Append("  ,Age4 ")
            Query.Append("  ,Age5 ")
            Query.Append("  ,Age6 ")
            Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [Department] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormDep ")
            Query.Append("where ")
            Query.Append("  Age5 != 0 ")
            Query.Append("order by ")
            Query.Append("  SeqNo ")
        End If
        If Aging = "Above 30 days" Then
            Query.Append("select ")
            Query.Append("  DepCode ")
            Query.Append("  ,DepName ")
            Query.Append("  ,Total ")
            Query.Append("  ,Age1 ")
            Query.Append("  ,Age2 ")
            Query.Append("  ,Age3 ")
            Query.Append("  ,Age4 ")
            Query.Append("  ,Age5 ")
            Query.Append("  ,Age6 ")
            Query.Append("  ,(select dbo.ProperCase(description) from department where dept_code = Rpt_AgingFormDep.DepCode) [Department] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormDep ")
            Query.Append("where ")
            Query.Append("  Age6 != 0 ")
            Query.Append("order by ")
            Query.Append("  SeqNo ")
        End If
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")

                    Dim Data As New StringBuilder
                    Data.Append("<div id='" & DR("DepCode") & "' data-aging='" & Aging & "' class='d-flex align-items-center w-100' onclick='ViewOpenAgingDetails(this, this.id);'>")
                    Data.Append("   <div class='d-flex flex-column min-w-250px w-100 pointer'>")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Department") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>" & DR("DepName") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Total"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age1"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age2"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age3"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age4"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age5"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'> > 30</span>")
                    Data.Append("       <span class='text-dark fw-bolder fs-6'>" & Format(DR("Age6"), "N0") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</div>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Aging_Details(Aging, DeptCode)

        'get query
        Dim Query As New StringBuilder
        If Aging = "Within" Then
            Query.Append("select ")
            Query.Append("  '' [EmpCode] ")
            Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
            Query.Append("  ,'' [Total] ")
            Query.Append("  ,'' [Age1] ")
            Query.Append("  ,'' [Age2] ")
            Query.Append("  ,'' [Age3] ")
            Query.Append("  ,'' [Age4] ")
            Query.Append("  ,'' [Age5] ")
            Query.Append("  ,'' [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,1 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and SecName != '' ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("  EmpCode ")
            Query.Append("  ,EmpName ")
            Query.Append("  ,ltrim(str(Total)) [Total] ")
            Query.Append("  ,ltrim(str(Age1)) [Age1] ")
            Query.Append("  ,ltrim(str(Age2)) [Age2] ")
            Query.Append("  ,ltrim(str(Age3)) [Age3] ")
            Query.Append("  ,ltrim(str(Age4)) [Age4] ")
            Query.Append("  ,ltrim(str(Age5)) [Age5] ")
            Query.Append("  ,ltrim(str(Age6)) [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,2 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and Age1 != 0 ")
            Query.Append("order by ")
            Query.Append("  SecName ")
            Query.Append("  ,SeqNo ")
            Query.Append("  ,EmpName ")
        End If
        If Aging = "1 to 7 days" Then
            Query.Append("select")
            Query.Append("  '' [EmpCode] ")
            Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
            Query.Append("  ,'' [Total] ")
            Query.Append("  ,'' [Age1] ")
            Query.Append("  ,'' [Age2] ")
            Query.Append("  ,'' [Age3] ")
            Query.Append("  ,'' [Age4] ")
            Query.Append("  ,'' [Age5] ")
            Query.Append("  ,'' [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,1 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and SecName != '' ")
            Query.Append("union ")
            Query.Append("select")
            Query.Append("  EmpCode ")
            Query.Append("  ,EmpName ")
            Query.Append("  ,ltrim(str(Total)) [Total] ")
            Query.Append("  ,ltrim(str(Age1)) [Age1] ")
            Query.Append("  ,ltrim(str(Age2)) [Age2] ")
            Query.Append("  ,ltrim(str(Age3)) [Age3] ")
            Query.Append("  ,ltrim(str(Age4)) [Age4] ")
            Query.Append("  ,ltrim(str(Age5)) [Age5] ")
            Query.Append("  ,ltrim(str(Age6)) [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,2 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and Age2 != 0 ")
            Query.Append("order by ")
            Query.Append("  SecName ")
            Query.Append("  ,SeqNo ")
            Query.Append("  ,EmpName ")
        End If
        If Aging = "8 to 15 days" Then
            Query.Append("select")
            Query.Append("  '' [EmpCode] ")
            Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
            Query.Append("  ,'' [Total] ")
            Query.Append("  ,'' [Age1] ")
            Query.Append("  ,'' [Age2] ")
            Query.Append("  ,'' [Age3] ")
            Query.Append("  ,'' [Age4] ")
            Query.Append("  ,'' [Age5] ")
            Query.Append("  ,'' [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,1 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and SecName != '' ")
            Query.Append("union ")
            Query.Append("select")
            Query.Append("  EmpCode ")
            Query.Append("  ,EmpName ")
            Query.Append("  ,ltrim(str(Total)) [Total] ")
            Query.Append("  ,ltrim(str(Age1)) [Age1] ")
            Query.Append("  ,ltrim(str(Age2)) [Age2] ")
            Query.Append("  ,ltrim(str(Age3)) [Age3] ")
            Query.Append("  ,ltrim(str(Age4)) [Age4] ")
            Query.Append("  ,ltrim(str(Age5)) [Age5] ")
            Query.Append("  ,ltrim(str(Age6)) [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,2 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and Age3 != 0 ")
            Query.Append("order by ")
            Query.Append("  SecName ")
            Query.Append("  ,SeqNo ")
            Query.Append("  ,EmpName ")
        End If
        If Aging = "16 to 22 days" Then
            Query.Append("select")
            Query.Append("  '' [EmpCode] ")
            Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
            Query.Append("  ,'' [Total] ")
            Query.Append("  ,'' [Age1] ")
            Query.Append("  ,'' [Age2] ")
            Query.Append("  ,'' [Age3] ")
            Query.Append("  ,'' [Age4] ")
            Query.Append("  ,'' [Age5] ")
            Query.Append("  ,'' [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,1 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and SecName != '' ")
            Query.Append("union ")
            Query.Append("select")
            Query.Append("  EmpCode ")
            Query.Append("  ,EmpName ")
            Query.Append("  ,ltrim(str(Total)) [Total] ")
            Query.Append("  ,ltrim(str(Age1)) [Age1] ")
            Query.Append("  ,ltrim(str(Age2)) [Age2] ")
            Query.Append("  ,ltrim(str(Age3)) [Age3] ")
            Query.Append("  ,ltrim(str(Age4)) [Age4] ")
            Query.Append("  ,ltrim(str(Age5)) [Age5] ")
            Query.Append("  ,ltrim(str(Age6)) [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,2 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and Age4 != 0 ")
            Query.Append("order by ")
            Query.Append("  SecName ")
            Query.Append("  ,SeqNo ")
            Query.Append("  ,EmpName ")
        End If
        If Aging = "23 to 30 days" Then
            Query.Append("select")
            Query.Append("  '' [EmpCode] ")
            Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
            Query.Append("  ,'' [Total] ")
            Query.Append("  ,'' [Age1] ")
            Query.Append("  ,'' [Age2] ")
            Query.Append("  ,'' [Age3] ")
            Query.Append("  ,'' [Age4] ")
            Query.Append("  ,'' [Age5] ")
            Query.Append("  ,'' [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,1 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and SecName != '' ")
            Query.Append("union ")
            Query.Append("select")
            Query.Append("  EmpCode ")
            Query.Append("  ,EmpName ")
            Query.Append("  ,ltrim(str(Total)) [Total] ")
            Query.Append("  ,ltrim(str(Age1)) [Age1] ")
            Query.Append("  ,ltrim(str(Age2)) [Age2] ")
            Query.Append("  ,ltrim(str(Age3)) [Age3] ")
            Query.Append("  ,ltrim(str(Age4)) [Age4] ")
            Query.Append("  ,ltrim(str(Age5)) [Age5] ")
            Query.Append("  ,ltrim(str(Age6)) [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,2 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and Age5 != 0 ")
            Query.Append("order by ")
            Query.Append("  SecName ")
            Query.Append("  ,SeqNo ")
            Query.Append("  ,EmpName ")
        End If
        If Aging = "Above 30 days" Then
            Query.Append("select")
            Query.Append("  '' [EmpCode] ")
            Query.Append("  ,'<b>' + SecName + '</b>' [EmpName] ")
            Query.Append("  ,'' [Total] ")
            Query.Append("  ,'' [Age1] ")
            Query.Append("  ,'' [Age2] ")
            Query.Append("  ,'' [Age3] ")
            Query.Append("  ,'' [Age4] ")
            Query.Append("  ,'' [Age5] ")
            Query.Append("  ,'' [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,1 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and SecName != '' ")
            Query.Append("union ")
            Query.Append("select")
            Query.Append("  EmpCode ")
            Query.Append("  ,EmpName ")
            Query.Append("  ,ltrim(str(Total)) [Total] ")
            Query.Append("  ,ltrim(str(Age1)) [Age1] ")
            Query.Append("  ,ltrim(str(Age2)) [Age2] ")
            Query.Append("  ,ltrim(str(Age3)) [Age3] ")
            Query.Append("  ,ltrim(str(Age4)) [Age4] ")
            Query.Append("  ,ltrim(str(Age5)) [Age5] ")
            Query.Append("  ,ltrim(str(Age6)) [Age6] ")
            Query.Append("  ,SecName ")
            Query.Append("  ,2 [SeqNo] ")
            Query.Append("from ")
            Query.Append("  Rpt_AgingFormEmp ")
            Query.Append("Where ")
            Query.Append("  DepCode = '" & DeptCode & "' ")
            Query.Append("  and Age6 != 0 ")
            Query.Append("order by ")
            Query.Append("  SecName ")
            Query.Append("  ,SeqNo ")
            Query.Append("  ,EmpName ")
        End If
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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

                    Dim Data As New StringBuilder
                    If DR("EmpCode") = "" Then
                        Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-dark'></span></div>")
                        Data.Append("<div class='d-flex align-items-center w-100'>")
                        Data.Append("   <div class='d-flex flex-column min-w-250px w-100' >")
                        Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto pb-2'>" & DR("EmpName") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'></span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'></span>")
                        Data.Append("   </div>")
                        Data.Append("</div>")
                    Else
                        Bullet.Append("<div class='h-100'><span class='bullet bullet-vertical bullet-margin h-58px bg-secondary'></span></div>")
                        Data.Append("<div id='" & DR("EmpCode") & "' data-aging='" & Aging & "' class='d-flex align-items-center pointer w-100' onclick='ViewPerAgingDetails(this ,this.id);'>")
                        Data.Append("   <div class='d-flex flex-column min-w-250px w-100' >")
                        Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("EmpName") & "</span>")
                        Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto'>Employee</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Total") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age1") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age2") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age3") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age4") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age5") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                        Data.Append("	    <span class='text-muted fw-bold text-muted d-block fs-7'> > 30</span>")
                        Data.Append("       <span class='text-dark fw-bolder fs-6'>" & DR("Age6") & "</span>")
                        Data.Append("   </div>")
                        Data.Append("</div>")
                    End If
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Aging_Per_Emp_Aging_Details(Aging, EmpCode)

        'get query
        Dim Query As New StringBuilder
        If Aging = "Within" Then
            Query.Append("select ")
            Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
            Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
            Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
            Query.Append("  ,[Link] ")
            Query.Append("  ,[Icon] ")
            Query.Append("  ,[Title] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[Name] ")
            Query.Append("  ,[Date] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[DateEnd] ")
            Query.Append("  ,[Total] ")
            Query.Append("  ,[Age1] ")
            Query.Append("  ,[Age2] ")
            Query.Append("  ,[Age3] ")
            Query.Append("  ,[Age4] ")
            Query.Append("  ,[Age5] ")
            Query.Append("  ,[Age6] ")
            Query.Append("from ")
            Query.Append("      (select ")
            Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("          ,[A].FormSummary [Title] ")
            Query.Append("          ,[A].FormNo [ID] ")
            Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("          ,[B].created_date [Date] ")
            Query.Append("          ,[B].date_required [DateRequired] ")
            Query.Append("          ,[A].Total [Total] ")
            Query.Append("          ,[A].Age1 [Age1] ")
            Query.Append("          ,[A].Age2 [Age2] ")
            Query.Append("          ,[A].Age3 [Age3] ")
            Query.Append("          ,[A].Age4 [Age4] ")
            Query.Append("          ,[A].Age5 [Age5] ")
            Query.Append("          ,[A].Age6 [Age6] ")
            Query.Append("      from ")
            Query.Append("          Rpt_AgingFormDtl [A] ")
            Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("      where ")
            Query.Append("          [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("          and [A].Age1 != 0) [A] ")
            Query.Append("order by ")
            Query.Append("  [DateEnd] DESC ")
        End If
        If Aging = "1 to 7 days" Then
            Query.Append("select ")
            Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
            Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
            Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
            Query.Append("  ,[Link] ")
            Query.Append("  ,[Icon] ")
            Query.Append("  ,[Title] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[Name] ")
            Query.Append("  ,[Date] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[DateEnd] ")
            Query.Append("  ,[Total] ")
            Query.Append("  ,[Age1] ")
            Query.Append("  ,[Age2] ")
            Query.Append("  ,[Age3] ")
            Query.Append("  ,[Age4] ")
            Query.Append("  ,[Age5] ")
            Query.Append("  ,[Age6] ")
            Query.Append("from ")
            Query.Append("      (select ")
            Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("          ,[A].FormSummary [Title] ")
            Query.Append("          ,[A].FormNo [ID] ")
            Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("          ,[B].created_date [Date] ")
            Query.Append("          ,[B].date_required [DateRequired] ")
            Query.Append("          ,[A].Total [Total] ")
            Query.Append("          ,[A].Age1 [Age1] ")
            Query.Append("          ,[A].Age2 [Age2] ")
            Query.Append("          ,[A].Age3 [Age3] ")
            Query.Append("          ,[A].Age4 [Age4] ")
            Query.Append("          ,[A].Age5 [Age5] ")
            Query.Append("          ,[A].Age6 [Age6] ")
            Query.Append("      from ")
            Query.Append("          Rpt_AgingFormDtl [A] ")
            Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("      where ")
            Query.Append("          [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("          and [A].Age2 != 0) [A] ")
            Query.Append("order by ")
            Query.Append("  [DateEnd] DESC ")
        End If
        If Aging = "8 to 15 days" Then
            Query.Append("select ")
            Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
            Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
            Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
            Query.Append("  ,[Link] ")
            Query.Append("  ,[Icon] ")
            Query.Append("  ,[Title] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[Name] ")
            Query.Append("  ,[Date] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[DateEnd] ")
            Query.Append("  ,[Total] ")
            Query.Append("  ,[Age1] ")
            Query.Append("  ,[Age2] ")
            Query.Append("  ,[Age3] ")
            Query.Append("  ,[Age4] ")
            Query.Append("  ,[Age5] ")
            Query.Append("  ,[Age6] ")
            Query.Append("from ")
            Query.Append("      (select ")
            Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("          ,[A].FormSummary [Title] ")
            Query.Append("          ,[A].FormNo [ID] ")
            Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("          ,[B].created_date [Date] ")
            Query.Append("          ,[B].date_required [DateRequired] ")
            Query.Append("          ,[A].Total [Total] ")
            Query.Append("          ,[A].Age1 [Age1] ")
            Query.Append("          ,[A].Age2 [Age2] ")
            Query.Append("          ,[A].Age3 [Age3] ")
            Query.Append("          ,[A].Age4 [Age4] ")
            Query.Append("          ,[A].Age5 [Age5] ")
            Query.Append("          ,[A].Age6 [Age6] ")
            Query.Append("      from ")
            Query.Append("          Rpt_AgingFormDtl [A] ")
            Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("      where ")
            Query.Append("          [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("          and [A].Age3 != 0) [A] ")
            Query.Append("order by ")
            Query.Append("  [DateEnd] DESC ")
        End If
        If Aging = "16 to 22 days" Then
            Query.Append("select ")
            Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
            Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
            Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
            Query.Append("  ,[Link] ")
            Query.Append("  ,[Icon] ")
            Query.Append("  ,[Title] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[Name] ")
            Query.Append("  ,[Date] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[DateEnd] ")
            Query.Append("  ,[Total] ")
            Query.Append("  ,[Age1] ")
            Query.Append("  ,[Age2] ")
            Query.Append("  ,[Age3] ")
            Query.Append("  ,[Age4] ")
            Query.Append("  ,[Age5] ")
            Query.Append("  ,[Age6] ")
            Query.Append("from ")
            Query.Append("      (select ")
            Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("          ,[A].FormSummary [Title] ")
            Query.Append("          ,[A].FormNo [ID] ")
            Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("          ,[B].created_date [Date] ")
            Query.Append("          ,[B].date_required [DateRequired] ")
            Query.Append("          ,[A].Total [Total] ")
            Query.Append("          ,[A].Age1 [Age1] ")
            Query.Append("          ,[A].Age2 [Age2] ")
            Query.Append("          ,[A].Age3 [Age3] ")
            Query.Append("          ,[A].Age4 [Age4] ")
            Query.Append("          ,[A].Age5 [Age5] ")
            Query.Append("          ,[A].Age6 [Age6] ")
            Query.Append("      from ")
            Query.Append("          Rpt_AgingFormDtl [A] ")
            Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("      where ")
            Query.Append("          [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("          and [A].Age4 != 0) [A] ")
            Query.Append("order by ")
            Query.Append("  [DateEnd] DESC ")
        End If
        If Aging = "23 to 30 days" Then
            Query.Append("select ")
            Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
            Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
            Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
            Query.Append("  ,[Link] ")
            Query.Append("  ,[Icon] ")
            Query.Append("  ,[Title] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[Name] ")
            Query.Append("  ,[Date] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[DateEnd] ")
            Query.Append("  ,[Total] ")
            Query.Append("  ,[Age1] ")
            Query.Append("  ,[Age2] ")
            Query.Append("  ,[Age3] ")
            Query.Append("  ,[Age4] ")
            Query.Append("  ,[Age5] ")
            Query.Append("  ,[Age6] ")
            Query.Append("from ")
            Query.Append("      (select ")
            Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("          ,[A].FormSummary [Title] ")
            Query.Append("          ,[A].FormNo [ID] ")
            Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("          ,[B].created_date [Date] ")
            Query.Append("          ,[B].date_required [DateRequired] ")
            Query.Append("          ,[A].Total [Total] ")
            Query.Append("          ,[A].Age1 [Age1] ")
            Query.Append("          ,[A].Age2 [Age2] ")
            Query.Append("          ,[A].Age3 [Age3] ")
            Query.Append("          ,[A].Age4 [Age4] ")
            Query.Append("          ,[A].Age5 [Age5] ")
            Query.Append("          ,[A].Age6 [Age6] ")
            Query.Append("      from ")
            Query.Append("          Rpt_AgingFormDtl [A] ")
            Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("      where ")
            Query.Append("          [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("          and [A].Age5 != 0) [A] ")
            Query.Append("order by ")
            Query.Append("  [DateEnd] DESC ")
        End If
        If Aging = "Above 30 days" Then
            Query.Append("select ")
            Query.Append("  (Case When [DateEnd] < cast(getdate() As Date) Then 'bullet bullet-vertical bullet-margin h-58px bg-danger' ")
            Query.Append("        when [DateEnd] = cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-warning' ")
            Query.Append("        when [DateEnd] > cast(getdate() as date) then 'bullet bullet-vertical bullet-margin h-58px bg-success' end) [Bullet] ")
            Query.Append("  ,[Link] ")
            Query.Append("  ,[Icon] ")
            Query.Append("  ,[Title] ")
            Query.Append("  ,[ID] ")
            Query.Append("  ,[Name] ")
            Query.Append("  ,[Date] ")
            Query.Append("  ,[DateRequired] ")
            Query.Append("  ,[DateEnd] ")
            Query.Append("  ,[Total] ")
            Query.Append("  ,[Age1] ")
            Query.Append("  ,[Age2] ")
            Query.Append("  ,[Age3] ")
            Query.Append("  ,[Age4] ")
            Query.Append("  ,[Age5] ")
            Query.Append("  ,[Age6] ")
            Query.Append("from ")
            Query.Append("      (select ")
            Query.Append("          isnull((select top 1 [E].DateEnd from oop_form_dtl_appr [E] where [E].f_code = [A].FormNo and [E].approver = [A].EmpCode and [E].status = '' order by [E].seq_no),cast(getdate() as date)) [DateEnd] ")
            Query.Append("          ,dbo.Get_Link([B].tbl_from) + '-DTL-' + replace([A].FormNo,'#','No') [Link] ")
            Query.Append("          ,dbo.Get_Icon([B].tbl_from) [Icon] ")
            Query.Append("          ,[A].FormSummary [Title] ")
            Query.Append("          ,[A].FormNo [ID] ")
            Query.Append("          ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) [Name] ")
            Query.Append("          ,[B].created_date [Date] ")
            Query.Append("          ,[B].date_required [DateRequired] ")
            Query.Append("          ,[A].Total [Total] ")
            Query.Append("          ,[A].Age1 [Age1] ")
            Query.Append("          ,[A].Age2 [Age2] ")
            Query.Append("          ,[A].Age3 [Age3] ")
            Query.Append("          ,[A].Age4 [Age4] ")
            Query.Append("          ,[A].Age5 [Age5] ")
            Query.Append("          ,[A].Age6 [Age6] ")
            Query.Append("      from ")
            Query.Append("          Rpt_AgingFormDtl [A] ")
            Query.Append("          left join oop_form_hdr [B] on [A].FormNo = [B].f_code ")
            Query.Append("          left join employee [C] on [A].EmpCode = [C].emp_no ")
            Query.Append("          left join oop_form_type [D] on [B].form_type = [D].t_code ")
            Query.Append("      where ")
            Query.Append("          [A].EmpCode = '" & EmpCode & "' ")
            Query.Append("          and [A].Age6 != 0) [A] ")
            Query.Append("order by ")
            Query.Append("  [DateEnd] DESC ")
        End If
        'get query

        'variable
        Dim FormList As New List(Of Object)()
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
                    Data.Append("<a href ='" & DR("Link") & "' class='d-flex align-items-center w-100'>")
                    Data.Append("   <div class='d-flex flex-column min-w-30px mw-30px me-3'>")
                    Data.Append("      <div class='symbol symbol-30px overflow-hidden'>")
                    Data.Append("         <img alt ='' class='w-100' src='" & DR("Icon") & "' />")
                    Data.Append("      </div>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-300px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 flex-nowrap'>" & DR("Title") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Total</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Total") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>Within</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age1") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>1 - 7</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age2") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>8 - 15</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age3") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>16 - 22</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age4") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>23 - 30</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age5") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-80px'>")
                    Data.Append("	     <span class='text-muted fw-bold text-muted d-block fs-7'>> 30</span>")
                    Data.Append("        <span class='text-dark fw-bolder fs-6'>" & DR("Age6") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("</a>")
                    FormList.Add(New With {
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
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

    Function DSB030000_Get_Accomplishment_Details(Code, DateFrom, DateTo)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [EmpName] ")
        Query.Append("  ,[IN] ")
        Query.Append("  ,[OUT] ")
        Query.Append("  ,[Good] ")
        Query.Append("  ,[Due] ")
        Query.Append("  ,[Delay] ")
        Query.Append("  ,'width:' + (case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Good] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) + '%' [GoodStyle] ")
        Query.Append("  ,'width:' + (case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Due] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) + '%' [DueStyle] ")
        Query.Append("  ,'width:' + (case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Delay] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) + '%' [DelayStyle] ")
        Query.Append("  ,(case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Good] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) [GoodValue] ")
        Query.Append("  ,(case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Due] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) [DueValue] ")
        Query.Append("  ,(case when [Good] + [Due] + [Delay] = 0 then '0.00' else FORMAT((cast([Delay] as decimal(21,2)) / cast([Good] + [Due] + [Delay] as decimal(21,2))) * 100.00,'N2') end) [DelayValue] ")
        Query.Append("from ")
        Query.Append("(Select distinct ")
        Query.Append("  '<b>' + [SEC].Description + '</b>' [EmpName] ")
        Query.Append("  ,'' [IN] ")
        Query.Append("  ,'' [OUT] ")
        Query.Append("  ,'' [Good] ")
        Query.Append("  ,'' [Due] ")
        Query.Append("  ,'' [Delay] ")
        Query.Append("  ,[SEC].Description [SecName] ")
        Query.Append("  ,1 [SeqNo] ")
        Query.Append("from ")
        Query.Append("  employee [EMP]  ")
        Query.Append("  Left Join Mstr_Section [SEC] on [EMP].Section = [SEC].SecCode ")
        Query.Append("where ")
        Query.Append("  [EMP].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("  And [EMP].dept_code = '" & Code & "' ")
        Query.Append("  And [EMP].Section Not in ('') ")
        Query.Append("union ")
        Query.Append("Select  ")
        Query.Append("  fullname [EmpName] ")
        Query.Append("  ,ltrim(str((select count(1) from view_FormApprover [A] where [A].approver = [EMP].emp_no And [A].DateStart between '" & DateFrom & "' And '" & DateTo & "'))) [IN] ")
        Query.Append("  ,ltrim(str((select count(1) from view_FormApprover [A] where [A].approver = [EMP].emp_no And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved'))) [OUT] ")
        Query.Append("  ,(select count(1) from view_FormApprover [A] where [A].approver = [EMP].emp_no And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved' and [A].DateEnd > [A].UpdatedDate) [Good] ")
        Query.Append("	,(select count(1) from view_FormApprover [A] where [A].approver = [EMP].emp_no And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved' and [A].DateEnd = [A].UpdatedDate) [Due] ")
        Query.Append("  ,(select count(1) from view_FormApprover [A] where [A].approver = [EMP].emp_no And [A].UpdatedDate between '" & DateFrom & "' And '" & DateTo & "' And [A].status = 'Approved' and [A].DateEnd < [A].UpdatedDate) [Delay] ")
        Query.Append("	,[SEC].Description [SecName] ")
        Query.Append("	,2 [SeqNo] ")
        Query.Append("from ")
        Query.Append("  employee [EMP]  ")
        Query.Append("  Left Join Mstr_Section [SEC] on [EMP].Section = [SEC].SecCode ")
        Query.Append("where ")
        Query.Append("  [EMP].emp_status in ('Contractual','Probationary','Regular') ")
        Query.Append("  And [EMP].dept_code = '" & Code & "') [TBL] ")
        Query.Append("where ")
        Query.Append("  [IN] != '0' ")
        Query.Append("  and [OUT] != '0' ")
        Query.Append("order by ")
        Query.Append("  [SecName] ")
        Query.Append("  ,[SeqNo] ")
        Query.Append("  ,[EmpName] ")
        'get query

        'variable
        Dim FormList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Data As New StringBuilder
                    If DR.GetString(1) = "" And DR.GetString(2) = "" Then
                        Data.Append("<div class='d-flex align-items-center pl-3'> ")
                        Data.Append("   <div class='d-flex flex-column min-w-250px'> ")
                        Data.Append("       <span class='text-dark fw-bolder fs-7 nowrap-auto'>" & DR("EmpName") & "</span> ")
                        Data.Append("   </div> ")
                        Data.Append("   <div class='d-flex flex-column min-w-50px me-3'> ")
                        Data.Append("       <span class='text-dark fw-bold fs-6 nowrap-auto'></span><span class='text-muted fs-8 fw-bold'></span> ")
                        Data.Append("   </div> ")
                        Data.Append("   <div class='d-flex flex-column min-w-50px me-3'> ")
                        Data.Append("       <span class='text-dark fw-bold fs-6 nowrap-auto'></span><span class='text-muted fs-8 fw-bold'></span> ")
                        Data.Append("   </div> ")
                        Data.Append("   <div class='d-flex flex-column min-w-250 w-100 me-3'> ")
                        Data.Append("       <div class='progress h-20px'> ")
                        Data.Append("           <div class='progress-bar bg-info' role='progressbar' style='width: 0;' aria-valuenow='0' aria-valuemin=0' aria-valuemax='100'><span class='text-white'></span></div> ")
                        Data.Append("           <div class='progress-bar bg-warning' role='progressbar' style='width: 0;' aria-valuenow='0' aria-valuemin=0' aria-valuemax='100'><span class='text-white'></span></div> ")
                        Data.Append("           <div class='progress-bar bg-danger' role='progressbar' style='width: 0;' aria-valuenow='0' aria-valuemin=0' aria-valuemax='100'><span class='text-white'></span></div> ")
                        Data.Append("       </div> ")
                        Data.Append("   </div> ")
                        Data.Append("</div> ")
                    ElseIf DR.GetString(1) <> "0" And DR.GetString(2) <> "0" Then
                        Data.Append("<div class='d-flex align-items-center pl-3'> ")
                        Data.Append("   <div class='d-flex flex-column min-w-250px'> ")
                        Data.Append("       <span class='text-dark fw-bolder fs-7 nowrap-auto'>" & DR("EmpName") & "</span> ")
                        Data.Append("   </div> ")
                        Data.Append("   <div class='d-flex flex-column min-w-50px me-3'> ")
                        Data.Append("       <span class='text-dark fw-bold fs-6 nowrap-auto'>" & DR("IN") & "</span><span class='text-muted fs-8 fw-bold'>In</span> ")
                        Data.Append("   </div> ")
                        Data.Append("   <div class='d-flex flex-column min-w-50px me-3'> ")
                        Data.Append("       <span class='text-dark fw-bold fs-6 nowrap-auto'>" & DR("OUT") & "</span><span class='text-muted fs-8 fw-bold'>Out</span> ")
                        Data.Append("   </div> ")
                        Data.Append("   <div class='d-flex flex-column min-w-250 w-100 me-3'> ")
                        Data.Append("       <div class='progress h-20px'> ")
                        Data.Append("           <div class='progress-bar bg-info' role='progressbar' style='" & DR("GoodStyle") & "' aria-valuenow='" & DR("GoodValue") & "' aria-valuemin=0' aria-valuemax='100'><span class='text-white'>" & DR("Good") & "</span></div> ") '
                        Data.Append("           <div class='progress-bar bg-warning' role='progressbar' style='" & DR("DueStyle") & "' aria-valuenow='" & DR("DueValue") & "' aria-valuemin=0' aria-valuemax='100'><span class='text-white'>" & DR("Due") & "</span></div> ") '
                        Data.Append("           <div class='progress-bar bg-danger' role='progressbar' style='" & DR("DelayStyle") & "' aria-valuenow='" & DR("DelayValue") & "' aria-valuemin=0' aria-valuemax='100'><span class='text-white'>" & DR("Delay") & "</span></div> ")
                        Data.Append("       </div> ")
                        Data.Append("   </div> ")
                        Data.Append("</div> ")
                    End If
                    FormList.Add(New With {
                        .Data = Data.ToString
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(FormList))
        'display 

    End Function

#End Region

#Region "ENG050101"

    Private Function ENG050101_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG020101"

    Private Function ENG020101_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG020201"

    Private Function ENG020201_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG040101"

    Private Function ENG040101_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "FIN030101"

    Private Function FIN030101_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG030101"

    Private Function ENG030101_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG050201"

    Private Function ENG050201_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "SCM030101"

    Private Function SCM030101_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG040201"

    Private Function ENG040201_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "PDD010201"

    Private Function PDD010201_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "PDD010101"

    Private Function PDD010101_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010501"

    Private Function ENG010501_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

    Private Function ENG010501_UpdateProgress(FormCode As String, UPID As String, UPSUBID As String, UPRate As String, UPDate As String)
        If CDbl(UPRate) <= 0 And UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pSubID", UPSUBID)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "PDD010301"

    Private Function PDD010301_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG040301"

    Private Function ENG040301_ChangeStatus(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010100"

    Private Function ENG010100_ChangeStatus(CSID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010101_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG01010")
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

    Private Function ENG010100_UpdateProgress(UPID As String, UPRate As String, UPDate As String)
        If CDbl(UPRate) <= 0 And UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010101_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010101")
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010200"

    Private Function ENG010200_ChangeStatus(CSID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010201_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010201")
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

    Private Function ENG010200_UpdateProgress(UPID As String, UPRate As String, UPDate As String)
        If CDbl(UPRate) <= 0 And UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010201_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010201")
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010300"

    Private Function ENG010300_ChangeStatus(CSID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010301_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010301")
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

    Private Function ENG010300_UpdateProgress(UPID As String, UPRate As String, UPDate As String)
        If CDbl(UPRate) <= 0 And UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010301_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010301")
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010400"

    Private Function ENG010400_ChangeStatus(CSID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010401_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010401")
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

    Private Function ENG010400_UpdateProgress(UPID As String, UPRate As String, UPDate As String)
        If CDbl(UPRate) <= 0 And UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010401_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010401")
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010600"

    Private Function ENG010600_ChangeStatus(CSID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010601_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010601")
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

    Private Function ENG010600_UpdateProgress(UPID As String, UPRate As String, UPDate As String)
        If CDbl(UPRate) <= 0 And UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010601_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010601")
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010700"

    Private Function ENG010700_ChangeStatus(CSID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010701_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010701")
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

    Private Function ENG010700_UpdateProgress(UPID As String, UPRate As String, UPDate As String)
        If CDbl(UPRate) <= 0 And UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_ENG010701_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", "ENG010701")
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "FIN010000"

    Function FIN010000_Validate(ID As String, Type As String, Amt As Double)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Type = "Downpayment" And Amt > 0 Then
            Query.Append("if '" & ID & "' in (select f_code from oop_form_hdr where f_code = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select [B].DPBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select [B].DPBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
            Query.Append("else if '" & ID & "' in (select HWCode from Form_HWHdr where HWCode = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select DPBal from Form_HWHdr where HWCode = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select DPBal from Form_HWHdr where HWCode = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
        ElseIf Type = "Progress Bill" And Amt > 0 Then
            Query.Append("if '" & ID & "' in (select f_code from oop_form_hdr where f_code = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select [B].TCPBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select [B].TCPBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
            Query.Append("else if '" & ID & "' in (select HWCode from Form_HWHdr where HWCode = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select TCPBal from Form_HWHdr where HWCode = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select TCPBal from Form_HWHdr where HWCode = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
        ElseIf Type = "Final Billing" And Amt > 0 Then
            Query.Append("if '" & ID & "' in (select f_code from oop_form_hdr where f_code = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select [B].TCPBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select [B].TCPBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
            Query.Append("else if '" & ID & "' in (select HWCode from Form_HWHdr where HWCode = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select TCPBal from Form_HWHdr where HWCode = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select TCPBal from Form_HWHdr where HWCode = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
        ElseIf Type = "Retention Fee" And Amt > 0 Then
            Query.Append("if '" & ID & "' in (select f_code from oop_form_hdr where f_code = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select [B].RFBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select [B].RFBal from oop_form_hdr [A] left join Form_CRT [B] on [A].tbl_code = [B].CRTCode where [A].f_code = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
            Query.Append("else if '" & ID & "' in (select HWCode from Form_HWHdr where HWCode = '" & ID & "') ")
            Query.Append("begin ")
            Query.Append("   if (select RFBal from Form_HWHdr where HWCode = '" & ID & "') <= 0 ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("   else if (select RFBal from Form_HWHdr where HWCode = '" & ID & "') < " & CDbl(Amt) & " ")
            Query.Append("   begin ")
            Query.Append("      select 'Error!' ")
            Query.Append("   end ")
            Query.Append("end ")
        ElseIf Type = "" Or Amt <= 0 Then
            Query.Append("select 'Error!' ")
        End If

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
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

    Private Function FIN010000_CreateBilling(CBID As String, CBType As String, CBAmt As Double)

        'validate
        Dim Msg As String = Me.FIN010000_Validate(CBID, CBType, CBAmt)
        'validate

        If Msg = "" Then
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "New_ContractBilling"
            SqlCmd.Parameters.AddWithValue("@pCRTCode", CBID)
            SqlCmd.Parameters.AddWithValue("@pCBType", CBType)
            SqlCmd.Parameters.AddWithValue("@pCBAmt", CBAmt)
            SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
            Dim oAPVNo As New SqlClient.SqlParameter("@oAPVNo", SqlDbType.NVarChar, 1000)
            oAPVNo.Direction = ParameterDirection.Output
            SqlCmd.Parameters.Add(oAPVNo)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp" & oAPVNo.Value.ToString
        Else
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbspError"
        End If

    End Function

#End Region

#Region "MNU020100"

    Private Function MNU020100_MarkAllRead()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = getdate() ")
        Query.Append("   ,Seen = 1 ")
        Query.Append("where ")
        Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Seen = 0 ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Private Function MNU020100_GetAllUnread()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'UnreadDiv' + ltrim(str([A].SeqNo)) [UnreadDiv] ")
        Query.Append("   ,'UnreadA' + ltrim(str([A].SeqNo)) [UnreadA] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 1 ")
        Query.Append("order by ")
        Query.Append("   [A].SeenDate desc ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim UnreadDiv As String = DR("UnreadDiv")
                    Dim UnreadA As String = DR("UnreadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & UnreadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <img alt='' class='w-100' src='" & Image & "' /> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6'>" & Title & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fw-bold text-muted d-block fs-7'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & UnreadA & "' onclick='MNU020100_MarkAsUnread(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' data-bs-toggle='tooltip' data-bs-placement='top' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'return value
        Return InnerHtml.ToString
        'return value

    End Function

    Private Function MNU020100_MarkAsRead(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = getdate() ")
        Query.Append("   ,Seen = 1 ")
        Query.Append("where ")
        Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and SeqNo = " & ID & " ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Private Function MNU020100_GetUnread(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'UnreadDiv' + ltrim(str([A].SeqNo)) [UnreadDiv] ")
        Query.Append("   ,'UnreadA' + ltrim(str([A].SeqNo)) [UnreadA] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].SeqNo = " & ID & " ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim UnreadDiv As String = DR("UnreadDiv")
                    Dim UnreadA As String = DR("UnreadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & UnreadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <img alt='' class='w-100' src='" & Image & "' /> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6'>" & Title & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fw-bold text-muted d-block fs-7'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & UnreadA & "' onclick='MNU020100_MarkAsUnread(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'return value
        Return InnerHtml.ToString
        'return value

    End Function

    Private Function MNU020100_MarkAsUnread(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = NULL ")
        Query.Append("   ,Seen = 0 ")
        Query.Append("where ")
        Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and SeqNo = " & ID & " ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Private Function MNU020100_GetRead(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'ReadDiv' + ltrim(str([A].SeqNo)) [ReadDiv] ")
        Query.Append("   ,'ReadA' + ltrim(str([A].SeqNo)) [ReadA] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].SeqNo = " & ID & " ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim ReadDiv As String = DR("ReadDiv")
                    Dim ReadA As String = DR("ReadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & ReadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <img alt='' class='w-100' src='" & Image & "' /> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6'>" & Title & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fw-bold text-muted d-block fs-7'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & ReadA & "' onclick='MNU020100_MarkAsRead(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'return value
        Return InnerHtml.ToString
        'return value

    End Function

#End Region

#Region "MNU000000"

    Private Function MNU000000_MarkAllRead()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = getdate() ")
        Query.Append("   ,Seen = 1 ")
        Query.Append("where ")
        Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Seen = 0 ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Private Function MNU000000_GetAllUnread()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select top 15 ")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'UnreadDiv' + ltrim(str([A].SeqNo)) [UnreadDiv] ")
        Query.Append("   ,'UnreadA' + ltrim(str([A].SeqNo)) [UnreadA] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].Seen = 1 ")
        Query.Append("order by ")
        Query.Append("   [A].SeenDate desc ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim UnreadDiv As String = DR("UnreadDiv")
                    Dim UnreadA As String = DR("UnreadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & UnreadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <div Class='symbol-label' style='background-image:url(" & Image & ")'></div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6 nowrap-280px'>" & Title & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-280px'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & UnreadA & "' onclick='MarkAsUnread(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' data-bs-toggle='tooltip' data-bs-placement='top' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'return value
        Return InnerHtml.ToString
        'return value

    End Function

    Private Function MNU000000_MarkAsRead(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = getdate() ")
        Query.Append("   ,Seen = 1 ")
        Query.Append("where ")
        Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and SeqNo = " & ID & " ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Private Function MNU000000_GetUnread(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'UnreadDiv' + ltrim(str([A].SeqNo)) [UnreadDiv] ")
        Query.Append("   ,'UnreadA' + ltrim(str([A].SeqNo)) [UnreadA] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].SeqNo = " & ID & " ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim UnreadDiv As String = DR("UnreadDiv")
                    Dim UnreadA As String = DR("UnreadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & UnreadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <div Class='symbol-label' style='background-image:url(" & Image & ")'></div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6 nowrap-280px'>" & Title & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-280px'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & UnreadA & "' onclick='MarkAsUnread(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'return value
        Return InnerHtml.ToString
        'return value

    End Function

    Private Function MNU000000_MarkAsUnread(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Mstr_Notification set ")
        Query.Append("   SeenDate = NULL ")
        Query.Append("   ,Seen = 0 ")
        Query.Append("where ")
        Query.Append("   Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and SeqNo = " & ID & " ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Cmd.ExecuteNonQuery()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Private Function MNU000000_GetRead(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   replace([A].Link,'#','No') [Link] ")
        Query.Append("   ,[A].CreatedBy [Image] ")
        Query.Append("   ,[A].Type + ' ' + [A].Description [Title] ")
        Query.Append("   ,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [Detail] ")
        Query.Append("   ,[A].CreatedDate [Date] ")
        Query.Append("   ,'ReadDiv' + ltrim(str([A].SeqNo)) [ReadDiv] ")
        Query.Append("   ,'ReadA' + ltrim(str([A].SeqNo)) [ReadA] ")
        Query.Append("from ")
        Query.Append("   Mstr_Notification [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Notify = '" & CIIS_EmpCode & "' ")
        Query.Append("   and [A].SeqNo = " & ID & " ")
        'get total task

        'variable
        Dim InnerHtml As New StringBuilder
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'set value
                    Dim Link As String = DR("Link")
                    Dim Image As String = DR("Image")
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".png")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & Image & ".jpg")) = True Then
                        Image = "Assets/media/avatars/" & Image & ".jpg"
                    Else
                        Image = "Assets/media/avatars/blank.png"
                    End If
                    Dim Title As String = DR("Title")
                    Dim Detail As String = DR("Detail") & " " & IIf(Year(DR("Date")) < Year(Date.Now), Format(DR("Date"), "MMM d, yyyy"), IIf(Day(DR("Date")) < Day(Date.Now), Format(DR("Date"), "MMM d"), IIf(Day(DR("Date")) = Day(Date.Now), "Today", "On " & Format(DR("Date"), "MMM d"))))
                    Dim ReadDiv As String = DR("ReadDiv")
                    Dim ReadA As String = DR("ReadA")
                    'set value

                    'set notification ui
                    InnerHtml.Append("<div id='" & ReadDiv & "' class='overlay overflow-hidden mb-4'> ")
                    InnerHtml.Append("   <div class='overlay-wrapper'> ")
                    InnerHtml.Append("      <a href='" & Link & "' class='d-flex align-items-center'> ")
                    InnerHtml.Append("         <div class='d-flex flex-column-fluid'> ")
                    InnerHtml.Append("            <div class='symbol symbol-45px overflow-hidden me-3'> ")
                    InnerHtml.Append("               <div Class='symbol-label' style='background-image:url(" & Image & ")'></div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='d-flex flex-column'> ")
                    InnerHtml.Append("               <span class='text-dark fw-bolder fs-6 nowrap-280px'>" & Title & "</span> ")
                    InnerHtml.Append("               <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-280px'>" & Detail & "</span> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </a> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("   <div class='overlay-layer bg-white ml-100 bg-opacity-0 justify-content-end'> ")
                    InnerHtml.Append("      <div class='d-flex justify-content-end flex-shrink-0'> ")
                    InnerHtml.Append("         <a id='" & ReadA & "' onclick='MarkAsRead(this.id)' class='position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto bg-white' title='Mark as read'> ")
                    InnerHtml.Append("            <span class='text-dark fw-bolder fs-6'><i class='las la-times'></i></span> ")
                    InnerHtml.Append("         </a>")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")
                    'set notification ui

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'return value
        Return InnerHtml.ToString
        'return value

    End Function

#End Region

#Region "MNU000017"

    Private Function MNU000017_View_Unit(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   isnull([A].Model,0) [Bullet] ")
        Query.Append("   ,[A].LotCode [Code] ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[C].ModelName [Unit] ")
        Query.Append("   ,isnull([A].BatchNo,'-') [Batch] ")
        Query.Append("   ,isnull([A].Model,0) [Status] ")
        Query.Append("   ,isnull([A].Model,0) [Button] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [C] on [A].Model = [C].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].Saleable = 1 ")
        Query.Append("	 and ([A].LotCode like '%" & Find & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot like '%" & Find & "%') ")
        'get total task

        'variable
        Dim ANUList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Bullet As String = ""
                    If DR("Bullet") = "0" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-58px bg-danger'></span>"
                    Else
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-58px bg-success'></span>"
                    End If
                    Dim Status As String = ""
                    If DR("Status") = "0" Then
                        Status = "<span class='badge badge-light-danger'>Invalid</span>"
                    Else
                        Status = "<span class='badge badge-light-success'>Valid</span>"
                    End If
                    Dim Button As String = ""
                    If DR("Button") = "0" Then
                        Button = "<button type = 'button' class='btn btn btn-sm btn-primary btn-active-light-primary' disabled>Add</button>"
                    Else
                        Button = "<button type = 'button' class='btn btn btn-sm btn-primary btn-active-light-primary' code='" & DR("Code") & "' onclick='btnAddCode(this);'><span class='indicator-label'>Add</span><span class='indicator-progress'>Adding... <span class='spinner-border spinner-border-sm align-middle ms-2'></span></span></button>"
                    End If

                    ANUList.Add(New With {
                        .Bullet = Bullet,
                        .Code = DR("Code"),
                        .Project = DR("Project"),
                        .Unit = DR("Unit"),
                        .Batch = DR("Batch"),
                        .Status = Status,
                        .Button = Button
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ANUList))
        'display 

    End Function

    Private Function MNU000017_View_Review(CodeSrs)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   isnull([A].Model,0) [Bullet] ")
        Query.Append("   ,[A].LotCode [Code] ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[C].ModelName [Unit] ")
        Query.Append("   ,isnull([A].BatchNo,'-') [Batch] ")
        Query.Append("   ,isnull([A].Model,0) [Status] ")
        Query.Append("   ,isnull([A].Model,0) [Button] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [C] on [A].Model = [C].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].LotCode in (select * from SplitString('" & CodeSrs & "',',')) ")
        'get total task

        'variable
        Dim ReviewList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Bullet As String = ""
                    If DR("Bullet") = "0" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-58px bg-danger'></span>"
                    Else
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-58px bg-success'></span>"
                    End If
                    Dim Status As String = ""
                    If DR("Status") = "0" Then
                        Status = "<span class='badge badge-light-danger'>Invalid</span>"
                    Else
                        Status = "<span class='badge badge-light-success'>Valid</span>"
                    End If
                    Dim Button As String = ""
                    Button = "<button type = 'button' class='btn btn btn-sm btn-danger btn-active-light-danger' code='" & DR("Code") & "' onclick='btnRemoveCode(this);'><span class='indicator-label'>Remove</span><span class='indicator-progress'>Removing... <span class='spinner-border spinner-border-sm align-middle ms-2'></span></span></button>"
                    ReviewList.Add(New With {
                        .Bullet = Bullet,
                        .Code = DR("Code"),
                        .Project = DR("Project"),
                        .Unit = DR("Unit"),
                        .Batch = DR("Batch"),
                        .Status = Status,
                        .Button = Button
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ReviewList))
        'display 

    End Function

    Private Function MNU000017_Submit(BatchNo, CodeSrs)
        Dim Codes As String() = CodeSrs.Split(New Char() {","c})
        For Each LotCode As String In Codes
            If LotCode = "" Then
                'nothing
            Else
                'create connection
                Dim SqlConn As New SqlClient.SqlConnection
                Dim SqlCmd As New SqlCommand
                SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=calmardblive; User ID=" & UserID & "; Password=" & Password
                SqlCmd.CommandTimeout = 1500
                SqlCmd.Connection = SqlConn
                SqlCmd.CommandType = CommandType.StoredProcedure
                SqlCmd.CommandText = "New_Form_HWCon"
                SqlCmd.Parameters.AddWithValue("@pLotCode", LotCode)
                SqlCmd.Parameters.AddWithValue("@pBatchNo", BatchNo)
                SqlCmd.Parameters.AddWithValue("@pDate", Date.Now)
                SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                'create connection

                'execute procedure
                SqlConn.Open()
                SqlCmd.ExecuteNonQuery()
                SqlConn.Close()
                'execute procedure
            End If
        Next

    End Function

#End Region

#Region "DSB000008"

    Private Function DSB000008_Get_WAR_All()

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded')")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'On-Going' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Completed' ")
        Query.Append("   and year([A].POCDate) = year(getdate()) ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Completed()

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Completed' ")
        Query.Append("   and [A].POCRate = 100 ")
        Query.Append("   and year([A].POCDate) = year(getdate()) ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Completed_Month(Month)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Completed' ")
        Query.Append("   and year([A].POCDate) = year(getdate()) ")
        Query.Append("   and ltrim(str(month([A].POCDate))) = '" & Month & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Completed_Status(Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Completed' ")
        Query.Append("   and year([A].POCDate) = year(getdate()) ")
        Query.Append("   and (case when '" & Status & "' = 'On-time' and [A].POCEnd > [A].POCDate then 'On-time' else 'Delayed' end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Completed_Batch(BatchNo, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'Completed' ")
        Query.Append("   and year([A].POCDate) = year(getdate()) ")
        Query.Append("   and [A].batchNo = '" & BatchNo & "' ")
        Query.Append("   and (case when '" & Status & "' = 'On-time' and [A].POCEnd > [A].POCDate then 'On-time' else 'Delayed' end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_OnGoing()

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'On-Going' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Ongoing_Status(Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'On-Going' ")
        Query.Append("   and (case when '" & Status & "' = 'On-time' and [A].POCEnd <= [A].POCDate then 'On-time' when [A].POCEnd > [A].POCDate then 'Delayed' end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Ongoing_Batch(BatchNo, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = 'On-Going' ")
        Query.Append("   and [A].BatchNo = '" & BatchNo & "' ")
        Query.Append("   and (case when '" & Status & "' = 'On-time' and [A].POCEnd <= [A].POCDate then 'On-time' when [A].POCEnd > [A].POCDate then 'Delayed' end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_ForConstruction()

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_ForConstruction_Status(Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_ForConstruction_Batch(BatchNo, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [B].BatchNo = '" & BatchNo & "' ")
        Query.Append("   and [A].Status = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Year(Status)

        'get approver 
        Dim Query As New StringBuilder
        If Status = "COC" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].Status = 'Completed' ")
        End If
        If Status = "PMD" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].Status = 'Completed' ")
            Query.Append("   and [A].TOStatus in ('Complete','Close') ")
        End If
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Year_Status(Year, Status)

        'get approver 
        Dim Query As New StringBuilder
        If Status = "COC" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].Status = 'Completed' ")
            Query.Append("   and year([A].POCDate) = " & Year & " ")
        End If
        If Status = "PMD" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].Status = 'Completed' ")
            Query.Append("   and [A].TOStatus in ('Complete','Close') ")
            Query.Append("   and year([A].TODate) = " & Year & " ")
        End If
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_Year_Bar_Chart(Year)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   (select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 1 and [A].POCRate = 100) [Act01] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 1) [Tar01] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 2 and [A].POCRate = 100) [Act02] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 2) [Tar02] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 3 and [A].POCRate = 100) [Act03] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 3) [Tar03] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 4 and [A].POCRate = 100) [Act04] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 4) [Tar04] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 5 and [A].POCRate = 100) [Act05] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 5) [Tar05] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 6 and [A].POCRate = 100) [Act06] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 6) [Tar06] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 7 and [A].POCRate = 100) [Act07] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 7) [Tar07] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 8 and [A].POCRate = 100) [Act08] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 8) [Tar08] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 9 and [A].POCRate = 100) [Act09] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 9) [Tar09] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 10 and [A].POCRate = 100) [Act10] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 10) [Tar10] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 11 and [A].POCRate = 100) [Act11] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 11) [Tar11] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 12 and [A].POCRate = 100) [Act12] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus [A] where year([A].POCEnd) = " & Year & " and month([A].POCEnd) = 12) [Tar12] ")
        'get approver 

        'variable
        Dim YearInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    YearInfo.Add(New With {
                        .Actual = DR("Act01") & "," & DR("Act02") & "," & DR("Act03") & "," & DR("Act04") & "," & DR("Act05") & "," & DR("Act06") & "," & DR("Act07") & "," & DR("Act08") & "," & DR("Act09") & "," & DR("Act10") & "," & DR("Act11") & "," & DR("Act12"),
                        .Target = DR("Tar01") & "," & DR("Tar02") & "," & DR("Tar03") & "," & DR("Tar04") & "," & DR("Tar05") & "," & DR("Tar06") & "," & DR("Tar07") & "," & DR("Tar08") & "," & DR("Tar09") & "," & DR("Tar10") & "," & DR("Tar11") & "," & DR("Tar12")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(YearInfo))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Month(Year, Status)

        'get approver 
        Dim Query As New StringBuilder
        If Status = "Target" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   year([A].POCEnd) = " & Year & " ")
        End If
        If Status = "Actual" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].Status = 'Completed' ")
            Query.Append("   and year([A].POCEnd) = " & Year & " ")
        End If
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function DSB000008_Get_WAR_Month_Status(Year, Month_, Status)

        'get approver 
        Dim Query As New StringBuilder
        If Status = "Target" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   year([A].POCEnd) = " & Year & " ")
            Query.Append("   and month([A].POCEnd) = " & Month(CDate(Month_ & " 1, " & Year)) & " ")
        End If
        If Status = "Actual" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   view_ContructionStatus [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
            Query.Append("where ")
            Query.Append("   [A].Status = 'Completed' ")
            Query.Append("   and year([A].POCEnd) = " & Year & " ")
            Query.Append("   and month([A].POCEnd) = " & Month(CDate(Month_ & " 1, " & Year)) & " ")
        End If
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

#End Region

#Region "DSB000009"

    Function DSB000009_Get_WAR_All()

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Awarded','On-Going') ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB000009_Get_WAR_All_Status(Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Awarded','On-Going') ")
        Query.Append("   and (case when '" & Status & "' = 'On-going' and isnull([A].POCRate,0) between 0.01 and 99.99 then 'On-going' when '" & Status & "' = 'On-time' and isnull([A].POCRate,0) between 0.01 and 99.99 and [A].POCEnd >= [A].POCDate then 'On-time' when '" & Status & "' = 'Delayed' and isnull([A].POCRate,0) between 0.01 and 99.99 and [A].POCEnd < [A].POCDate then 'Delayed' when '" & Status & "' = 'Not yet started' and isnull([A].POCRate,0) = 0 then 'Not yet started' end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB000009_Get_WAR_Division(Division)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Awarded','On-Going') ")
        Query.Append("   and [A].Division = '" & Division & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB000009_Get_WAR_Division_Status(Division, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Awarded','On-Going') ")
        Query.Append("   and [C].Division = '" & Division & "' ")
        Query.Append("   and (case when '" & Status & "' = 'On-going' and isnull([A].POCRate,0) between 0.01 and 99.99 then 'On-going' when '" & Status & "' = 'On-time' and isnull([A].POCRate,0) between 0.01 and 99.99 and [A].POCEnd >= [A].POCDate then 'On-time' when '" & Status & "' = 'Delayed' and isnull([A].POCRate,0) between 0.01 and 99.99 and [A].POCEnd < [A].POCDate then 'Delayed' when '" & Status & "' = 'Not yet started' and isnull([A].POCRate,0) = 0 then 'Not yet started' end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

#End Region

#Region "DSB000010"

    Function DSB000010_Get_Project_All()

        'get approver 
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("   '<a class=""pointer"" href=""DSB000011-' + ltrim(str([A].ProjCode)) + '"">' + [A].ProjInit + '</a>' [ProjInit] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusProject(''All'',''' + [A].ProjInit + ''')"">' + ltrim(str([A].Total)) + '</a>' [Total] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusProject(''Completed - On-time'',''' + [A].ProjInit + ''')"">' + ltrim(str([A].CompletedOntime)) + '</a>' [CompletedOntime] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusProject(''Completed - Delayed'',''' + [A].ProjInit + ''')"">' + ltrim(str([A].CompletedDelayed)) + '</a>' [CompletedDelayed] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusProject(''On-going - On-time'',''' + [A].ProjInit + ''')"">' + ltrim(str([A].OngoingOntime)) + '</a>' [OngoingOntime] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusProject(''On-going - Delayed'',''' + [A].ProjInit + ''')"">' + ltrim(str([A].OngoingDelayed)) + '</a>' [OngoingDelayed] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusProject(''For Construction - On-time'',''' + [A].ProjInit + ''')"">' + ltrim(str([A].ForConstructionOntime)) + '</a>' [ForConstructionOntime] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusProject(''For Construction - Delayed'',''' + [A].ProjInit + ''')"">' + ltrim(str([A].ForConstructionDelayed)) + '</a>' [ForConstructionDelayed] ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      [A].ProjCode  ")
        Query.Append("      ,[A].ProjInit  ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Subd = [A].ProjCode) [Total] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and [B].POCEnd >= [B].POCDate and [B].Subd = [A].ProjCode) [CompletedOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and [B].POCEnd < [B].POCDate and [B].Subd = [A].ProjCode) [CompletedDelayed] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'On-Going' and [B].POCEnd >= [B].POCDate and [B].Subd = [A].ProjCode) [OngoingOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'On-Going' and [B].POCEnd < [B].POCDate and [B].Subd = [A].ProjCode) [OngoingDelayed] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [B].POCStart >= cast(getdate() as date) and [B].Subd = [A].ProjCode) [ForConstructionOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [B].POCStart < cast(getdate() as date) and [B].Subd = [A].ProjCode) [ForConstructionDelayed] ")
        Query.Append("   from ")
        Query.Append("      calmardblive.dbo.mstr_Projects [A]) [A] ")
        Query.Append("where ")
        Query.Append("   [A].[CompletedOntime] + [CompletedDelayed] + [OngoingOntime] + [OngoingDelayed] + [ForConstructionOntime] + [ForConstructionDelayed] > 0 ")
        Query.Append("order by ")
        Query.Append("   [A].ProjInit ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Bullet As String = "<span class='bullet bullet-vertical bullet-margin h-40px bg-secondary'></span>"
                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .ProjInit = DR("ProjInit"),
                        .Total = DR("Total"),
                        .CompletedOntime = DR("CompletedOntime"),
                        .CompletedDelayed = DR("CompletedDelayed"),
                        .OngoingOntime = DR("OngoingOntime"),
                        .OngoingDelayed = DR("OngoingDelayed"),
                        .ForConstructionOntime = DR("ForConstructionOntime"),
                        .ForConstructionDelayed = DR("ForConstructionDelayed")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB00010_Get_WAR_Status(Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   (case when '" & Status & "' = 'Completed - On-time' and [A].Status = 'Completed' and [A].POCEnd >= [A].POCDate then 'Completed - On-time' ")
        Query.Append("         when '" & Status & "' = 'Completed - Delayed' and [A].Status = 'Completed' and [A].POCEnd < [A].POCDate then 'Completed - Delayed' ")
        Query.Append("         when '" & Status & "' = 'On-going - On-time' and [A].Status = 'On-Going' and [A].POCEnd >= [A].POCDate then 'On-going - On-time' ")
        Query.Append("         when '" & Status & "' = 'On-going - Delayed' and [A].Status = 'On-Going' and [A].POCEnd < [A].POCDate then 'On-going - Delayed' ")
        Query.Append("         when '" & Status & "' = 'For Construction - On-time' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart >= cast(getdate() as date) then 'For Construction - On-time' ")
        Query.Append("         when '" & Status & "' = 'For Construction - Delayed' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart < cast(getdate() as date) then 'For Construction - Delayed' ")
        Query.Append("         end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB00010_Get_WAR_Status_Project(Status, Project)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   (case when '" & Status & "' = 'All' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going','Completed') then 'All' ")
        Query.Append("         when '" & Status & "' = 'Completed - On-time' and [A].Status = 'Completed' and [A].POCEnd >= [A].POCDate then 'Completed - On-time' ")
        Query.Append("         when '" & Status & "' = 'Completed - Delayed' and [A].Status = 'Completed' and [A].POCEnd < [A].POCDate then 'Completed - Delayed' ")
        Query.Append("         when '" & Status & "' = 'On-going - On-time' and [A].Status = 'On-Going' and [A].POCEnd >= [A].POCDate then 'On-going - On-time' ")
        Query.Append("         when '" & Status & "' = 'On-going - Delayed' and [A].Status = 'On-Going' and [A].POCEnd < [A].POCDate then 'On-going - Delayed' ")
        Query.Append("         when '" & Status & "' = 'For Construction - On-time' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart >= cast(getdate() as date) then 'For Construction - On-time' ")
        Query.Append("         when '" & Status & "' = 'For Construction - Delayed' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart < cast(getdate() as date) then 'For Construction - Delayed' ")
        Query.Append("         when '" & Status & "' = 'On-going' and [A].Status in ('Awarded','On-Going') then 'On-going' ")
        Query.Append("         when '" & Status & "' = 'On-time' and [A].Status in ('Awarded','On-Going') and [A].POCEnd >= [A].POCDate then 'On-time' ")
        Query.Append("         when '" & Status & "' = 'Delayed' and [A].Status in ('Awarded','On-Going') and [A].POCEnd < [A].POCDate then 'Delayed' ")
        Query.Append("         when '" & Status & "' = 'Not yet started' and [A].Status in ('Awarded','On-Going') and [A].POCRate = 0 then 'Not yet started' ")
        Query.Append("         end) = '" & Status & "' ")
        Query.Append("   and [A].SubdInit = '" & Project & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB00010_Get_WAR_PE(Project, PE)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Awarded','On-Going') ")
        Query.Append("   and [A].Subd = '" & Project & "' ")
        Query.Append("   and dbo.ProperCase([F].first_name) = '" & PE & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

#End Region

#Region "DSB000011"

    Function DSB00011_Get_WAR_Status(Project, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Subd = " & Project & " ")
        Query.Append("   and (case when '" & Status & "' = 'All' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going') then 'All' ")
        Query.Append("             when '" & Status & "' = 'On-time' and [A].Status = 'On-Going' and [A].POCEnd >= [A].POCDate then 'On-time' ")
        Query.Append("             when '" & Status & "' = 'Delayed' and [A].Status = 'On-Going' and [A].POCEnd < [A].POCDate then 'Delayed' ")
        Query.Append("             when '" & Status & "' = 'Not yet started' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') then 'Not yet started' ")
        Query.Append("             end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB00011_Get_WAR_Status_PE(Project, Status, PE)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Subd = " & Project & " ")
        Query.Append("   and (case when '" & Status & "' = 'All' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going') then 'All' ")
        Query.Append("             when '" & Status & "' = 'Total' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going') then 'Total' ")
        Query.Append("             when '" & Status & "' = 'On-time' and [A].Status = 'On-Going' and [A].POCEnd >= [A].POCDate then 'On-time' ")
        Query.Append("             when '" & Status & "' = 'Delayed' and [A].Status = 'On-Going' and [A].POCEnd < [A].POCDate then 'Delayed' ")
        Query.Append("             when '" & Status & "' = 'Not yet started' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') then 'Not yet started' ")
        Query.Append("             end) = '" & Status & "' ")
        Query.Append("   and dbo.ProperCase([F].first_name) = '" & PE & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

#End Region

#Region "DSB000013"

    Function DSB00013_Get_Batch_All()

        'get approver 
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("   '<a class=""pointer"" href=""DSB000014-' + [A].BatchNo + '"">' + [A].BatchNo + '</a>' [BatchNo] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusBatch(''All'',''' + [A].BatchNo + ''')"">' + ltrim(str([A].Total)) + '</a>' [Total] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusBatch(''Completed - On-time'',''' + [A].BatchNo + ''')"">' + ltrim(str([A].CompletedOntime)) + '</a>' [CompletedOntime] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusBatch(''Completed - Delayed'',''' + [A].BatchNo + ''')"">' + ltrim(str([A].CompletedDelayed)) + '</a>' [CompletedDelayed] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusBatch(''On-going - On-time'',''' + [A].BatchNo + ''')"">' + ltrim(str([A].OngoingOntime)) + '</a>' [OngoingOntime] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusBatch(''On-going - Delayed'',''' + [A].BatchNo + ''')"">' + ltrim(str([A].OngoingDelayed)) + '</a>' [OngoingDelayed] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusBatch(''For Construction - On-time'',''' + [A].BatchNo + ''')"">' + ltrim(str([A].ForConstructionOntime)) + '</a>' [ForConstructionOntime] ")
        Query.Append("   ,'<a class=""pointer"" onclick=""ViewWARStatusBatch(''For Construction - Delayed'',''' + [A].BatchNo + ''')"">' + ltrim(str([A].ForConstructionDelayed)) + '</a>' [ForConstructionDelayed] ")
        Query.Append("from ")
        Query.Append("   (select distinct ")
        Query.Append("      [A].BatchNo  ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].BatchNo = [A].BatchNo) [Total] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and [B].POCEnd >= [B].POCDate and [B].BatchNo = [A].BatchNo) [CompletedOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'Completed' and [B].POCEnd < [B].POCDate and [B].BatchNo = [A].BatchNo) [CompletedDelayed] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'On-Going' and [B].POCEnd >= [B].POCDate and [B].BatchNo = [A].BatchNo) [OngoingOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status = 'On-Going' and [B].POCEnd < [B].POCDate and [B].BatchNo = [A].BatchNo) [OngoingDelayed] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [B].POCStart >= cast(getdate() as date) and [B].BatchNo = [A].BatchNo) [ForConstructionOntime] ")
        Query.Append("      ,(select count(1) from view_ContructionStatus [B] where [B].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [B].POCEnd < cast(getdate() as date) and [B].BatchNo = [A].BatchNo) [ForConstructionDelayed] ")
        Query.Append("   from ")
        Query.Append("      view_ContructionStatus [A]) [A] ")
        Query.Append("where ")
        Query.Append("   [A].[CompletedOntime] + [CompletedDelayed] + [OngoingOntime] + [OngoingDelayed] + [ForConstructionOntime] + [ForConstructionDelayed] > 0 ")
        Query.Append("order by ")
        Query.Append("   [A].BatchNo ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Bullet As String = "<span class='bullet bullet-vertical bullet-margin h-40px bg-secondary'></span>"
                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .BatchNo = DR("BatchNo"),
                        .Total = DR("Total"),
                        .CompletedOntime = DR("CompletedOntime"),
                        .CompletedDelayed = DR("CompletedDelayed"),
                        .OngoingOntime = DR("OngoingOntime"),
                        .OngoingDelayed = DR("OngoingDelayed"),
                        .ForConstructionOntime = DR("ForConstructionOntime"),
                        .ForConstructionDelayed = DR("ForConstructionDelayed")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB00013_Get_WAR_Status(Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   (case when '" & Status & "' = 'Completed - On-time' and [A].Status = 'Completed' and [A].POCEnd >= [A].POCDate then 'Completed - On-time' ")
        Query.Append("         when '" & Status & "' = 'Completed - Delayed' and [A].Status = 'Completed' and [A].POCEnd < [A].POCDate then 'Completed - Delayed' ")
        Query.Append("         when '" & Status & "' = 'On-going - On-time' and [A].Status = 'On-Going' and [A].POCEnd >= [A].POCDate then 'On-going - On-time' ")
        Query.Append("         when '" & Status & "' = 'On-going - Delayed' and [A].Status = 'On-Going' and [A].POCEnd < [A].POCDate then 'On-going - Delayed' ")
        Query.Append("         when '" & Status & "' = 'For Construction - On-time' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart >= cast(getdate() as date) then 'For Construction - On-time' ")
        Query.Append("         when '" & Status & "' = 'For Construction - Delayed' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart < cast(getdate() as date) then 'For Construction - Delayed' ")
        Query.Append("         end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB00013_Get_WAR_Status_Batch(Status, Batch)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   (case when '" & Status & "' = 'All' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going','Completed') then 'All' ")
        Query.Append("         when '" & Status & "' = 'Completed - On-time' and [A].Status = 'Completed' and [A].POCEnd >= [A].POCDate then 'Completed - On-time' ")
        Query.Append("         when '" & Status & "' = 'Completed - Delayed' and [A].Status = 'Completed' and [A].POCEnd < [A].POCDate then 'Completed - Delayed' ")
        Query.Append("         when '" & Status & "' = 'On-going - On-time' and [A].Status = 'On-Going' and [A].POCEnd >= [A].POCDate then 'On-going - On-time' ")
        Query.Append("         when '" & Status & "' = 'On-going - Delayed' and [A].Status = 'On-Going' and [A].POCEnd < [A].POCDate then 'On-going - Delayed' ")
        Query.Append("         when '" & Status & "' = 'For Construction - On-time' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart >= cast(getdate() as date) then 'For Construction - On-time' ")
        Query.Append("         when '" & Status & "' = 'For Construction - Delayed' and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') and [A].POCStart < cast(getdate() as date) then 'For Construction - Delayed' ")
        Query.Append("         when '" & Status & "' = 'On-going' and [A].Status in ('Awarded','On-Going') then 'On-going' ")
        Query.Append("         when '" & Status & "' = 'On-time' and [A].Status in ('Awarded','On-Going') and [A].POCEnd >= [A].POCDate then 'On-time' ")
        Query.Append("         when '" & Status & "' = 'Delayed' and [A].Status in ('Awarded','On-Going') and [A].POCEnd < [A].POCDate then 'Delayed' ")
        Query.Append("         when '" & Status & "' = 'Not yet started' and [A].Status in ('Awarded','On-Going') and [A].POCRate = 0 then 'Not yet started' ")
        Query.Append("         end) = '" & Status & "' ")
        Query.Append("   and [A].BatchNo = '" & Batch & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function DSB00013_Get_WAR_PE(Batch, PE)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].POCPE = [F].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Status in ('Awarded','On-Going') ")
        Query.Append("   and [A].BatchNo = '" & Batch & "' ")
        Query.Append("   and dbo.ProperCase([F].first_name) = '" & PE & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

#End Region

#Region "FRM000001"

    Private Function FRM000001_Get_Project_List(Category)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'select a project' [Text] ")
        Query.Append("   ,'' [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].p_code [Value] ")
        Query.Append("   ,[A].description [Text] ")
        Query.Append("   ,[A].description [Order] ")
        Query.Append("from ")
        Query.Append("   oop_project [A] ")
        Query.Append("where ")
        Query.Append("   [A].c_code = '" & Category & "' ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
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
                    RecordList.Add(New With {
                        .Value = DR("Value"),
                        .Text = DR("Text")
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

    Private Function FRM000001_Get_Project(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].LotCode ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 [A].LotCode like '%" & Find & "%' ")
        Query.Append("	    or [B].ProjInit like '%" & Find & "%' ")
        Query.Append("	    or [A].PhaseNo like '%" & Find & "%' ")
        Query.Append("	    or [A].Block like '%" & Find & "%' ")
        Query.Append("	    or [A].Lot like '%" & Find & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot like '%" & Find & "%' ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get total task

        'variable
        Dim ProjectList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    ProjectList.Add(New With {
                        .Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-secondary'></span>",
                        .LotCode = "<a id='" & DR("LotCode") & "' class='pointer' onclick='SelectProject(this.id)'>" & DR("LotCode") & "</a>",
                        .Project = "<span class='nowrap-200px'>" & DR("Project") & "</span>"
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ProjectList))
        'display 

    End Function

    Private Function FRM000001_Get_Project_Info(LotCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].LotCode ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Lot [A] ")
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
                        .Project = DR("Project"),
                        .LotCode = DR("LotCode")
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

    Private Function FRM000001_Get_Buyer_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000001_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,isnull([A].eMail,'-') [eMail] ")
        Query.Append("   ,isnull((select top 1 [B].ContactNo from calmardblive.dbo.mstr_ContactNos [B] where [B].AcctNo = [A].AcctNo and [B].NoCode = 1),'-') [MobileNo] ")
        Query.Append("   ,format([A].TCPNet,'N2') [TCP] ")
        Query.Append("   ,[A].FinancingScheme ")
        Query.Append("   ,[A].House ")
        Query.Append("   ,[A].TCTNo ")
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
                        .eMail = DR("eMail"),
                        .MobileNo = DR("MobileNo"),
                        .TCP = DR("TCP"),
                        .FinancingScheme = DR("FinancingScheme"),
                        .House = DR("House"),
                        .TCTNo = DR("TCTNo")
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

    Private Function FRM000001_Get_Contract_Project_List(Category, Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = '" & Category & "'  ")

        'subd phase
        Query.Append("if @Category in ('Structural Consultant - Amenities','Service Entrance','Land Scape Project Restoration','Land Scape Project New','Land Development Repair','Land Development New','DOLE Application - Land Development','Amenities Repair','Amenities New') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].code [Code] ")
        Query.Append("      ,[B].abbr + ' ' + [A].description [Description] ")
        Query.Append("   from ")
        Query.Append("	    phase [A] ")
        Query.Append("	    left join subdivision [B] on [A].scode = [B].code ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subd phase

        'subd phase block lot
        Query.Append("else if @Category in ('Shell to Premium','Shell to Complete','classic to Premium','Shell to classic','Shell to Basic','Structural Consultant - House Unit','NWRB Application','Land Scape Unit','Interior Designer','House Repair','House Construction','Electrical Consultant','DOLE Application - Model House','Basic to Complete') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].l_code [Code] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("	    and ([D].description like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr like '%" & Find & "%' ")
        Query.Append("	       or [C].description like '%" & Find & "%' ")
        Query.Append("	       or 'B' + [B].block like '%" & Find & "%' ")
        Query.Append("	       or 'L' + [A].lot like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot like '%" & Find & "%') ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subd phase block lot

        'branch
        Query.Append("else if @Category in ('CLDC Office') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].buss_code [Code] ")
        Query.Append("      ,dbo.ProperCase([A].description) [Description] ")
        Query.Append("   from ")
        Query.Append("      business [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'branch

        'subdivision
        Query.Append("else if @Category in ('Waste Hauling Services','Utilities Repair','Testing and Investigation','Temporary Facilities Construction','Security Services','Container Van','Clearing / Grass Cutting') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].code [Code] ")
        Query.Append("      ,dbo.ProperCase([A].description) [Description] ")
        Query.Append("   from ")
        Query.Append("      subdivision [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
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
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectContractProject('" & DR("Code") & "')"">")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000001_Get_Contract_Project_Info(Category, Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = '" & Category & "'  ")

        'subd phase
        Query.Append("if @Category in ('Structural Consultant - Amenities','Service Entrance','Land Scape Project Restoration','Land Scape Project New','Land Development Repair','Land Development New','DOLE Application - Land Development','Amenities Repair','Amenities New') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [B].abbr + ' ' + [A].description [Project] ")
        Query.Append("      ,[A].scode [Subdivision] ")
        Query.Append("      ,[A].code [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("	    phase [A] ")
        Query.Append("	    left join subdivision [B] on [A].scode = [B].code ")
        Query.Append("   where ")
        Query.Append("	    [A].code = '" & Code & "' ")
        Query.Append("end  ")
        'subd phase

        'subd phase block lot
        Query.Append("else if @Category in ('Shell to Premium','Shell to Complete','classic to Premium','Shell to classic','Shell to Basic','Structural Consultant - House Unit','NWRB Application','Land Scape Unit','Interior Designer','House Repair','House Construction','Electrical Consultant','DOLE Application - Model House','Basic to Complete') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Project] ")
        Query.Append("      ,[A].s_code [Subdivision] ")
        Query.Append("      ,[A].p_code [Phase] ")
        Query.Append("      ,[A].b_code [Block] ")
        Query.Append("      ,[A].l_code [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].l_code = '" & Code & "' ")
        Query.Append("end  ")
        'subd phase block lot

        'branch
        Query.Append("else if @Category in ('CLDC Office') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      dbo.ProperCase([A].description) [Project] ")
        Query.Append("      ,'' [Subdivision] ")
        Query.Append("      ,'' [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,[A].buss_code [Branch] ")
        Query.Append("   from ")
        Query.Append("      business [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("	    and [A].buss_code = '" & Code & "' ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'branch

        'subdivision
        Query.Append("else if @Category in ('Waste Hauling Services','Utilities Repair','Testing and Investigation','Temporary Facilities Construction','Security Services','Container Van','Clearing / Grass Cutting') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      dbo.ProperCase([A].description) [Project] ")
        Query.Append("      ,[A].code [Subdivision] ")
        Query.Append("      ,'' [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("      subdivision [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("	    and [A].code = '" & Code & "' ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subdivision

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
                        .Project = DR("Project"),
                        .Subdivision = DR("Subdivision"),
                        .Phase = DR("Phase"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .Branch = DR("Branch")
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

#Region "FRM000009"

    Private Function FRM000009_Get_Project_List(Category, Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = '" & Category & "'  ")

        'subd phase
        Query.Append("if @Category in ('Structural Consultant - Amenities','Service Entrance','Land Scape Project Restoration','Land Scape Project New','Land Development Repair','Land Development New', 'Land Development','DOLE Application - Land Development','Amenities Repair','Amenities New', 'Amenities', 'Perimeter Fence', 'Perimeter Fence New') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].code [Code] ")
        Query.Append("      ,[B].abbr + ' ' + [A].description [Description] ")
        Query.Append("   from ")
        Query.Append("	    phase [A] ")
        Query.Append("	    left join subdivision [B] on [A].scode = [B].code ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subd phase

        'subd phase block lot
        Query.Append("else if @Category in ('Shell to Premium','Shell to Complete','classic to Premium','Shell to classic','Shell to Basic','Structural Consultant - House Unit','NWRB Application','Land Scape Unit','Interior Designer','House Repair', 'House Modification','Initial Inspection','House Construction', 'Take-Over Unit','Electrical Consultant','DOLE Application - Model House','Basic to Complete') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].l_code [Code] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("	    and ([D].description like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr like '%" & Find & "%' ")
        Query.Append("	       or [C].description like '%" & Find & "%' ")
        Query.Append("	       or 'B' + [B].block like '%" & Find & "%' ")
        Query.Append("	       or 'L' + [A].lot like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot like '%" & Find & "%') ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subd phase block lot

        'branch
        Query.Append("else if @Category in ('CLDC Office') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].buss_code [Code] ")
        Query.Append("      ,dbo.ProperCase([A].description) [Description] ")
        Query.Append("   from ")
        Query.Append("      business [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'branch

        'subdivision
        Query.Append("else if @Category in ('Waste Hauling Services','Utilities Repair','Testing and Investigation','Temporary Facilities Construction','Security Services','Container Van','Clearing / Grass Cutting') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].code [Code] ")
        Query.Append("      ,dbo.ProperCase([A].description) [Description] ")
        Query.Append("   from ")
        Query.Append("      subdivision [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000009_Get_Project_Info(Category, Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = '" & Category & "'  ")

        'subd phase
        Query.Append("if @Category in ('Structural Consultant - Amenities','Service Entrance','Land Scape Project Restoration','Land Scape Project New','Land Development Repair','Land Development New', 'Land Development','DOLE Application - Land Development','Amenities Repair','Amenities New', 'Amenities', 'Perimeter Fence', 'Perimeter Fence New') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [B].abbr + ' ' + [A].description [Project] ")
        Query.Append("      ,[A].scode [Subdivision] ")
        Query.Append("      ,[A].code [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("	    phase [A] ")
        Query.Append("	    left join subdivision [B] on [A].scode = [B].code ")
        Query.Append("   where ")
        Query.Append("	    [A].code = '" & Code & "' ")
        Query.Append("end  ")
        'subd phase

        'subd phase block lot
        Query.Append("else if @Category in ('Shell to Premium','Shell to Complete','classic to Premium','Shell to classic','Shell to Basic','Structural Consultant - House Unit','NWRB Application','Land Scape Unit','Interior Designer','House Repair', 'House Modification','Initial Inspection','House Construction', 'Take-Over Unit','Electrical Consultant','DOLE Application - Model House','Basic to Complete') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Project] ")
        Query.Append("      ,[A].s_code [Subdivision] ")
        Query.Append("      ,[A].p_code [Phase] ")
        Query.Append("      ,[A].b_code [Block] ")
        Query.Append("      ,[A].l_code [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].l_code = '" & Code & "' ")
        Query.Append("end  ")
        'subd phase block lot

        'branch
        Query.Append("else if @Category in ('CLDC Office') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      dbo.ProperCase([A].description) [Project] ")
        Query.Append("      ,'' [Subdivision] ")
        Query.Append("      ,'' [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,[A].buss_code [Branch] ")
        Query.Append("   from ")
        Query.Append("      business [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("	    and [A].buss_code = '" & Code & "' ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'branch

        'subdivision
        Query.Append("else if @Category in ('Waste Hauling Services','Utilities Repair','Testing and Investigation','Temporary Facilities Construction','Security Services','Container Van','Clearing / Grass Cutting') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      dbo.ProperCase([A].description) [Project] ")
        Query.Append("      ,[A].code [Subdivision] ")
        Query.Append("      ,'' [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("      subdivision [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("	    and [A].code = '" & Code & "' ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subdivision

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
                        .Project = DR("Project"),
                        .Subdivision = DR("Subdivision"),
                        .Phase = DR("Phase"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .Branch = DR("Branch")
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

#Region "FRM000010"

    Private Function FRM000010_Get_Project_List(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      [A].LotCode [Code] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("	    and ([D].description like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr like '%" & Find & "%' ")
        Query.Append("	       or [C].description like '%" & Find & "%' ")
        Query.Append("	       or 'B' + [B].block like '%" & Find & "%' ")
        Query.Append("	       or 'L' + [A].lot like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot like '%" & Find & "%') ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000010_Get_Project_Info(Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Project] ")
        Query.Append("      ,[A].s_code [Subdivision] ")
        Query.Append("      ,[A].p_code [Phase] ")
        Query.Append("      ,[A].b_code [Block] ")
        Query.Append("      ,[A].l_code [Lot] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode = '" & Code & "' ")
        'subdivision

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
                        .Project = DR("Project"),
                        .Subdivision = DR("Subdivision"),
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

    Private Function FRM000010_Get_Vehicle_Info(Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      CarModel ")
        Query.Append("      ,PlateNo")
        Query.Append("   from ")
        Query.Append("      Mstr_Vehicle ")
        Query.Append("   where ")
        Query.Append("	    PlateNo = '" & Code & "' ")
        'subdivision

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
                        .Vehicle = DR("CarModel"),
                        .PlateNo = DR("PlateNo")
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
    Private Function FRM000010_Get_Charge_To(pTblFrom, pCode1, pCode2, pCode3, pCode4, pCode5)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("Get_RcrdList_PRChargeTo")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pTblFrom", pTblFrom)
                Cmd.Parameters.AddWithValue("@pCode1", pCode1)
                Cmd.Parameters.AddWithValue("@pCode2", pCode2)
                Cmd.Parameters.AddWithValue("@pCode3", pCode3)
                Cmd.Parameters.AddWithValue("@pCode4", pCode4)
                Cmd.Parameters.AddWithValue("@pCode5", pCode5)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select' onclick=""fn01AddChargeTo('" & DR("Code") & "', '" & DR("Description") & "','" & DR("Lock") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("code"),
                        .Action = Action.ToString,
                        .Code = DR("code"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = DR("description")
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
    Private Function FRM000010_Get_Sub_Phase()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  code ")
        Query.Append("  ,description ")
        Query.Append("  ,isnull(lock, 0) [Lock] ")
        Query.Append("  ,scode ")
        Query.Append("from ")
        Query.Append("  sub_phase ")
        'get query

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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select' onclick=""fn01AddPhase('" & DR("code") & "', '" & DR("description") & "','" & DR("Lock") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("code"),
                        .Action = Action.ToString,
                        .Code = DR("code"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Phase = DR("description"),
                        .SCode = DR("scode")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function
    Private Function FRM000010_Get_Sub_Miscellaneous(pAcctCode)

        Dim pSplit As String() = pAcctCode.ToString.Split("/"c)
        Dim pAcctFrom As String = pSplit(0)
        Dim pAcctTo As String = pSplit(1)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  code ")
        Query.Append("  ,description ")
        Query.Append("  ,account ")
        Query.Append("  ,isnull(lock, 0) [Lock] ")
        Query.Append("  ,subsidiary ")
        Query.Append("from ")
        Query.Append("  sub_misc ")
        Query.Append("where ")
        Query.Append("  account between '" & pAcctFrom & "' and '" & pAcctTo & "' ")
        'get query

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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select' onclick=""fn01AddMisc('" & DR("account") & "', '" & DR("code") & "', '" & DR("description") & "','" & DR("Lock") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID02" & DR("code"),
                        .Action = Action.ToString,
                        .Code = DR("code"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Misc = DR("description"),
                        .AcctCode = DR("account")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function
    Private Function FRM000010_Get_Sub_Other(pAcctCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  code ")
        Query.Append("  ,description ")
        Query.Append("  ,account ")
        Query.Append("  ,isnull(lock, 0) [Lock] ")
        Query.Append("  ,subsidiary ")
        Query.Append("from ")
        Query.Append("  sub_misc ")
        Query.Append("where ")
        Query.Append("  account = '" & pAcctCode & "' ")
        'get query

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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select' onclick=""fn01AddOther('" & DR("code") & "', '" & DR("description") & "','" & DR("Lock") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .rowId = "rowID03" & DR("code"),
                        .Action = Action.ToString,
                        .Code = DR("code"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Misc = DR("description"),
                        .AcctCode = DR("account")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function
    Function FRM000010_Get_Sub_Department(pAcctCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  acct_type ")
        Query.Append("from ")
        Query.Append("  fin_chart ")
        Query.Append("where ")
        Query.Append("  acct_code = '" & pAcctCode & "' ")
        'get query

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
                        .AcctType = DR("acct_type")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function
    Private Function FRM000010_Get_Cost_Estimate_Cons(pCategory, pSubd)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("  (CASE WHEN [A].Batch IS NULL OR [A].Batch = '' OR [A].Batch = '-' THEN [A].CECode ELSE [A].Batch END) [Batch] ")
        Query.Append("  ,[A].Title [Project] ")
        Query.Append("  ,[A].CECode ")
        Query.Append("  ,ISNULL([A].DivCode, '') [DivCode] ")
        Query.Append("  ,ISNULL((select description from division where div_code = [A].DivCode), '') [DivName] ")
        Query.Append("from ")
        Query.Append("  Trxn_CEHdr [A] ")
        Query.Append("  left join eng_lot [B] on [A].Subdivision = [B].l_code ")
        Query.Append("  left join subdivision [C] on (CASE WHEN [B].s_code IS NULL THEN [A].SubdCode ELSE [B].s_code END) = [C].Code ")
        Query.Append("where ")
        Query.Append("  [A].Post = 1 ")
        Query.Append("  and [A].Rvrs = 0 ")
        Query.Append("  and [A].Category = '" & pCategory & "' ")
        If pSubd <> "" Then
            Query.Append("  and ([A].Subdivision = '" & pSubd & "' OR [A].SubdCode = '" & pSubd & "') ")
        End If
        'get query

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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select' onclick=""fn01AddEstimate('" & DR("CECode") & "', '" & DR("Project") & "', '" & DR("DivCode") & "', '" & DR("DivName") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Batch = DR("Batch"),
                        .Project = DR("Project"),
                        .DivCode = DR("DivCode"),
                        .DivName = DR("DivName")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function
    Private Function FRM000010_Get_Cost_Estimate(pProjectType, pSubd, pCategory)

        'get query
        Dim Query As New StringBuilder
        If pProjectType = "OSM Project (Advance PO)" Or pProjectType = "CCI Project (Advance PO)" Then
            Query.Append("select distinct ")
            Query.Append("  (CASE WHEN [A].BatchNo IS NULL OR [A].BatchNo = '' OR [A].BatchNo = '-' THEN [A].CECode ELSE [A].BatchNo END) [Batch] ")
            Query.Append("  ,(CASE WHEN [A].BatchNo IS NULL OR [A].BatchNo = '' OR [A].BatchNo = '-' THEN [A].BatchNo ELSE [A].BatchNo + ' - ' + (select top 1 subdivision.description from subdivision where subdivision.code = '" & pSubd & "') END) [Project]  ")
            Query.Append("  ,isnull([B].division, '') [DivCode] ")
            Query.Append("  ,ISNULL((select description from division where div_code = [B].division), '') [DivName] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEDtl_PO [A] ")
            Query.Append("  left join subdivision [B] on [A].Project = [B].Code ")
            Query.Append("where ")
            Query.Append("  [A].Project = '" & pSubd & "' ")
            Query.Append("  and [A].Category = 'House Construction' ")
        Else
            Query.Append("select distinct ")
            Query.Append("  (CASE WHEN [A].Batch IS NULL OR [A].Batch = '' OR [A].Batch = '-' THEN [A].CECode ELSE [A].Batch END) [Batch] ")
            Query.Append("  ,(CASE WHEN [A].Batch IS NULL OR [A].Batch = '' OR [A].Batch = '-' THEN [A].Title ELSE [A].Batch + ' - ' + (select top 1 subdivision.description from subdivision where subdivision.code = '" & pSubd & "' or subdivision.code = '" & pSubd & "') END) [Project] ")
            Query.Append("  ,isnull([A].DivCode, '') [DivCode] ")
            Query.Append("  ,ISNULL((select description from division where div_code = [A].DivCode), '') [DivName] ")
            Query.Append("from ")
            Query.Append("  Trxn_CEHdr [A] ")
            Query.Append("  left join eng_lot [B] on [A].Subdivision = [B].l_code ")
            Query.Append("  left join subdivision [C] on (CASE WHEN [B].s_code IS NULL THEN [A].SubdCode ELSE [B].s_code END) = [C].Code ")
            Query.Append("where ")
            Query.Append("  [A].Post = 1 ")
            Query.Append("  and [A].Rvrs = 0 ")
            Query.Append("  and ([A].Subdivision = '" & pSubd & "' OR [A].SubdCode = '" & pSubd & "') ")
            Query.Append("  and [A].Category = '" & pCategory & "' ")
        End If
        'get query

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
                    Action.Append("<button class='btn btn-sm btn-icon btn-view' title='Select' onclick=""fn01AddEstimate('" & DR("Batch") & "', '" & DR("Project") & "', '" & DR("DivCode") & "', '" & DR("DivName") & "');return false;""><i class='las la-check-circle fs-3'></i></button>")

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Batch = DR("Batch"),
                        .Project = DR("Project"),
                        .DivCode = DR("DivCode"),
                        .DivName = DR("DivName")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'set to max
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display 

    End Function

    Private Function FRM000010_Get_PR_Tagging(pID, pWBSNo, pProjectCat)

        'query
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = ISNULL((select Category from ogm_pr_hdr where form_no = '" & pID & "'), '') ")
        Query.Append("declare @BatchNo nvarchar(20) = IIF(@Category = 'House Construction' OR @Category = 'House Construction - CCI', ISNULL((select CECode from ogm_pr_hdr where form_no = '" & pID & "'), ''), '') ")
        Query.Append("declare @Subd nvarchar(13) = ISNULL((select Subdivision from ogm_pr_hdr where form_no = '" & pID & "'), '') ")
        Query.Append("declare @PRCode nvarchar(13) = ISNULL((select pr_code from ogm_pr_hdr where form_no = '" & pID & "'), '') ")
        Query.Append("declare @Particular nvarchar(max) = ISNULL((select item from ogm_pr_dtl where WBSNo = '" & pWBSNo & "' and pr_code = @PRCode), '') ")
        Query.Append("select ")
        Query.Append("  [a].ItemNo ")
        Query.Append("  ,ISNULL([a].[Project], [a].[Title]) [Project] ")
        Query.Append("  ,[a].[Unit] ")
        Query.Append("  ,[a].[Qty1] ")
        Query.Append("  ,[a].[Qty2] ")
        Query.Append("  ,[a].[Qty1] - [a].[Qty2] [Qty3] ")
        Query.Append("  ,[a].[LotCode] ")
        Query.Append("  ,isnull([a].[AcctCode], '') [AcctCode] ")
        Query.Append("  ,isnull([a].[DivCode], '') [DivCode] ")
        Query.Append("  ,isnull([a].[DeptCode], '') [DeptCode] ")
        Query.Append("  ,isnull([a].[Subsidiary], '') [Subsidiary] ")
        Query.Append("  ,isnull([a].[Code], '') [Code] ")
        Query.Append("  ,@Particular [Particular] ")
        Query.Append("from ")
        Query.Append("(select ")
        Query.Append("  [a].ItemNo ")
        Query.Append("  ,[f].abbr + ' ' + [e].description + ' B' + [d].block + ' L' + [c].lot [Project] ")
        Query.Append("  ,[c].LotCode ")
        Query.Append("  ,[g].abbr [Unit] ")
        Query.Append("  ,([a].Qty + [a].QtyRev) - [a].QtyReq [Qty1] ")
        If pProjectCat = "House Construction" Then
            Query.Append("  ,ISNULL((select sum([h].qty) from Trxn_PRDtl_HouseCon [h] left join oop_form_hdr [i] on [h].PRCode = [i].tbl_code where [h].WBSNo = '" & pWBSNo & "' and [h].ItemNo = [a].ItemNo and [i].tbl_from = 'ogm_pr_hdr' and [i].status not in ('Accepted','Declined','Cancelled')),0) [Qty2]  ")
        ElseIf pProjectCat = "House Construction - CCI" Then
            Query.Append("  ,ISNULL((select sum([h].qty) from Trxn_PRDtl_HouseCon_CCI [h] left join oop_form_hdr [i] on [h].PRCode = [i].tbl_code where [h].WBSNo = '" & pWBSNo & "' and [h].ItemNo = [a].ItemNo and [i].tbl_from = 'ogm_pr_hdr' and [i].status not in ('Accepted','Declined','Cancelled')),0) [Qty2]  ")
        End If
        Query.Append("  ,[a].AcctCode ")
        Query.Append("  ,[a].DivCode ")
        Query.Append("  ,[a].DeptCode ")
        Query.Append("  ,[a].Subsidiary ")
        Query.Append("  ,[a].Code ")
        Query.Append("  ,[b].Title ")
        Query.Append("from ")
        Query.Append("  Trxn_CEDtl [a] ")
        Query.Append("  left join Trxn_CEHdr [b] on [a].CECode = [b].CECode ")
        Query.Append("  left join eng_lot [c] on [b].Subdivision = [c].l_code ")
        Query.Append("  left join eng_block [d] on [c].b_code = [d].b_code ")
        Query.Append("  left join phase [e] on [c].p_code = [e].code ")
        Query.Append("  left join subdivision [f] on (CASE WHEN [c].s_code IS null then [b].SubdCode else [c].s_code end) = [f].code ")
        Query.Append("  left join sys_um [g] on [a].UMCode = [g].u_code ")
        Query.Append("where ")
        Query.Append("  [A].WBSNo = '" & pWBSNo & "' ")
        Query.Append("  and ISNULL([a].IsOSM, 0) = 1 ")
        Query.Append("  and ISNULL([b].Post, 0) = 1 ")
        Query.Append("  and ISNULL([b].Rvrs, 0) = 0 ")
        Query.Append("  AND (@BatchNo = '' OR [b].Batch = @BatchNo) ")
        Query.Append("  and [B].SubdCode = @Subd ")
        Query.Append("  and [a].Particular = @Particular) [a] ")
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
                        .ItemNo = DR("ItemNo"),
                        .Project = DR("Project"),
                        .LotCode = DR("LotCode"),
                        .Unit = DR("Unit"),
                        .Qty1 = DR("Qty1"),
                        .Select = "<div class='form-check form-check-custom form-check-solid w-100 flex-center'><input class='form-check-input cbx06Return' parm_return06='" & DR("ItemNo") & "' onchange='cbx06Return_onchange(this);' type='checkbox'/></div>",
                        .Qty2 = DR("Qty2"),
                        .Return = "<div class='form-check form-check-custom form-check-solid w-100 flex-center'><input class='form-check-input cbx06Add' parm+ parm_select06='" & DR("ItemNo") & "' onchange='cbx06Add_onchange(this);' type='checkbox'/></div>",
                        .Qty3 = DR("Qty3"),
                        .Available = "",
                        .AcctCode = DR("AcctCode"),
                        .DivCode = DR("DivCode"),
                        .DeptCode = DR("DeptCode"),
                        .Subsidiary = DR("Subsidiary"),
                        .Code = DR("Code"),
                        .Particular = DR("Particular")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return JsonConvert.SerializeObject(RecordList, Formatting.None)
        'display

    End Function

    Private Function FRM000010_Add_PR_Tagging(pID, pResultData)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_FRM000010_Tagging_OSM"
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pResultData", pResultData)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Private Function FRM000010_Return_PR_Tagging(pItemNo, pParticular, pQty, pID, pLotCode)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_FRM000010_Return_OSM"
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pItemNo", pItemNo)
        SqlCmd.Parameters.AddWithValue("@pParticular", pParticular)
        SqlCmd.Parameters.AddWithValue("@pLotCode", pLotCode)
        SqlCmd.Parameters.AddWithValue("@pQty", CDbl(pQty))
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000010_Get_Type_List(Purpose)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select type' [Text] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   Purpose [Value] ")
        Query.Append("   ,Purpose [Text] ")
        Query.Append("from ")
        Query.Append("   Mstr_PurposeType ")
        Query.Append("where ")
        Query.Append("   Type = '" & Purpose & "' ")
        Query.Append("order by ")
        Query.Append("   [Value] ")
        'branch

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
                        .Value = DR("Value"),
                        .Text = DR("Text")
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

    Private Function FRM000010_Get_Type_Category(Type)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select type' [Text] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   Purpose [Value] ")
        Query.Append("   ,Purpose [Text] ")
        Query.Append("from ")
        Query.Append("   Mstr_PurposeType ")
        Query.Append("where ")
        Query.Append("   Type = '" & Type & "' ")
        Query.Append("order by ")
        Query.Append("   [Value] ")
        'branch

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
                        .Value = DR("Value"),
                        .Text = DR("Text")
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

#Region "FRM000011"

    Private Function FRM000011_Get_Buyer_List(Account)

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
        Query.Append("	 ([A].AcctNo like '%" & Account & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Account & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Account & "%') ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000011_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].House ")
        Query.Append("   ,isnull(FORMAT([A].DOE,'MM/dd/yyyy'),'') [DOE] ")
        Query.Append("   ,isnull([A].FinancingScheme, '-') [FinancingScheme] ")
        Query.Append("   ,(select top 1 case [B].TRCode when 'Loan' then 'Full DP' when 'MA' then 'MA Stage' when 'DP' then 'DP Stage' when 'RF' then 'RF Stage' else 'Fully Paid' end from calmardblive.dbo.ICR_Ledger [B] ) [PaymentStatus] ")
        Query.Append("   ,isnull([C].Remarks, '-') [BankInstitution] ")
        Query.Append("   ,isnull(FORMAT(([D].DateAcquired), 'MM/dd/yyyy'),'') [DateFilled] ")
        Query.Append("   ,isnull(FORMAT(([E].DateAcquired), 'MM/dd/yyyy'),'') [ApprovalDate] ")
        Query.Append("   ,isnull([F].Remarks, '-') [ApprovedAmount] ")
        Query.Append("   ,isnull([G].Remarks, '-') [LoanStatus] ")
        Query.Append("   ,isnull([H].Remarks, '-') [Remarks] ")
        Query.Append("   ,isnull((select top 1 [I].ContactNo from calmardbLive.dbo.mstr_ContactNos [I] where [I].AcctNo = [A].AcctNo and [I].NoCode = 1), '-') [MobileNo] ")
        Query.Append("   ,isnull([A].eMail, '-') [Email] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Account [A] ")
        Query.Append("   left join calmardblive.dbo.ICR_Ledger [B] on [A].AcctNo = [B].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.ICR_Status [C] on [C].AcctNo = [A].AcctNo and [C].StatusCode = '65' and [C].Active = '1'  ")
        Query.Append("   left join calmardbLive.dbo.ICR_Status [D] on [D].AcctNo = [A].AcctNo and [D].StatusCode = '66' and [D].Active = '1'  ")
        Query.Append("   left join calmardbLive.dbo.ICR_Status [E] on [E].AcctNo = [A].AcctNo and [E].StatusCode = '104' and [E].Active = '1'  ")
        Query.Append("   left join calmardbLive.dbo.ICR_Status [F] on [F].AcctNo = [A].AcctNo and [F].StatusCode = '218' and [F].Active = '1'  ")
        Query.Append("   left join calmardbLive.dbo.ICR_Status [G] on [G].AcctNo = [A].AcctNo and [G].StatusCode = '106' and [G].Active = '1'  ")
        Query.Append("   left join calmardbLive.dbo.ICR_Status [H] on [H].AcctNo = [A].AcctNo and [H].StatusCode = '107' and [H].Active = '1'  ")
        Query.Append("where ")
        Query.Append("	 [A].AcctNo = '" & AcctNo & "' ")
        'get total task

        'variable
        Dim BuyerInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    BuyerInfo.Add(New With {
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName"),
                        .Project = DR("Project"),
                        .House = DR("House"),
                        .DOE = DR("DOE"),
                        .FinancingScheme = DR("FinancingScheme"),
                        .PaymentStatus = DR("PaymentStatus"),
                        .BankInstitution = DR("BankInstitution"),
                        .DateFilled = DR("DateFilled"),
                        .ApprovalDate = DR("ApprovalDate"),
                        .ApprovedAmount = DR("ApprovedAmount"),
                        .LoanStatus = DR("LoanStatus"),
                        .Remarks = DR("Remarks"),
                        .MobileNo = DR("MobileNo"),
                        .Email = DR("Email")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(BuyerInfo))
        'display 

    End Function

#End Region

#Region "FRM000012"

    Private Function FRM000012_Get_Buyer_List(Value)

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000012_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].House ")
        Query.Append("   ,isnull(FORMAT([A].DOE,'MM/dd/yyyy'),'') [DOE] ")
        Query.Append("   ,isnull([A].TCPNet,0) [TCPNet] ")
        Query.Append("   ,[A].FinancingScheme ")
        Query.Append("   ,isnull(FORMAT([A].HCCompDate,'MM/dd/yyyy'),'') [HCCompDate] ")
        Query.Append("   ,isnull(FORMAT([A].TurnOverDate,'MM/dd/yyyy'),'') [TurnOverDate] ")
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
                        .House = DR("House"),
                        .DOE = DR("DOE"),
                        .TCPNet = Format(DR("TCPNet"), "N2"),
                        .FinancingScheme = DR("FinancingScheme"),
                        .HCCompDate = DR("HCCompDate"),
                        .TurnOverDate = DR("TurnOverDate")
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

#Region "FRM000013"

    Private Function FRM000013_Get_Buyer_List(Value)

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000013_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].House ")
        Query.Append("   ,FORMAT([A].TCP,'N2') [TCP] ")
        Query.Append("   ,[A].FinancingScheme [Financing] ")
        Query.Append("   ,'-' [Bank] ")
        Query.Append("   ,FORMAT([A].DPAmt,'N2') [DPAmt] ")
        Query.Append("   ,isnull((select top 1 [B].ContactNo from calmardblive.dbo.mstr_ContactNos [B] where [B].AcctNo = [A].AcctNo and [B].NoCode = 1),'-') [MobileNo] ")
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
                        .House = DR("House"),
                        .TCP = DR("TCP"),
                        .Financing = DR("Financing"),
                        .Bank = DR("Bank"),
                        .DPAmt = DR("DPAmt"),
                        .MobileNo = DR("MobileNo")
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

#Region "FRM000014"

    Private Function FRM000014_Get_Buyer_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000014_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,isnull([A].eMail,'-') [eMail] ")
        Query.Append("   ,isnull((select top 1 [B].ContactNo from calmardblive.dbo.mstr_ContactNos [B] where [B].AcctNo = [A].AcctNo and [B].NoCode = 1),'-') [MobileNo] ")
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
                        .eMail = DR("eMail"),
                        .MobileNo = DR("MobileNo")
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

#Region "FRM000016"

    Private Function FRM000016_Get_Payee(Value)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("if '" & Value & "' = 'Employee' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_employee ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if '" & Value & "'  = 'Vendor' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_vendor ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
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
                        .Value = DR("Value"),
                        .Text = DR("Text")
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
    Private Function FRM000016_Get_Fund(Value)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select fund' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("    Fund [Value] ")
        Query.Append("    ,Fund [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("   Parm_PettyCash_Fund ")
        Query.Append("where ")
        Query.Append("   BrnchCode = '" & Value & "' ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
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
                        .Value = DR("Value"),
                        .Text = DR("Text")
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

    Private Function FRM000016_Get_Subsidiary(Value)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   subsidiary ")
        Query.Append("from ")
        Query.Append("   fin_chart ")
        Query.Append("where ")
        Query.Append("   acct_code = '" & Value & "' ")
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
                        .Subsidiary = DR("Subsidiary")
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

    Private Function FRM000016_Get_Description(Value)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("declare @Subsidiary nvarchar(20) = (select subsidiary from fin_chart where acct_code = '" & Value & "') ")
        Query.Append("if @Subsidiary = 'LOT' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_lot ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'MISCELLANEOUS' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_misc ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("      and account = '" & Value & "' ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'MODEL HOUSE' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_house ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'NO SUBSIDIARY' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("      '-' [Value] ")
        Query.Append("      ,'No Subsidiary' [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'PHASE' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_phase ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if @Subsidiary = 'SUBDIVISION' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_subdivision ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
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
                        .Value = DR("Value"),
                        .Text = DR("Text")
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

#Region "FRM000017"

    Private Function FRM000017_Get_Payee(Value)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("if '" & Value & "' = 'Employee' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_employee ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else if '" & Value & "'  = 'Vendor' ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   union ")
        Query.Append("   select ")
        Query.Append("       code [Value] ")
        Query.Append("       ,description [Text] ")
        Query.Append("	    ,1 [Order] ")
        Query.Append("   from ")
        Query.Append("      sub_vendor ")
        Query.Append("   where ")
        Query.Append("      lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select ")
        Query.Append("      '' [Value] ")
        Query.Append("      ,'Select description' [Text] ")
        Query.Append("	    ,0 [Order] ")
        Query.Append("   order by ")
        Query.Append("      [Order] ")
        Query.Append("      ,[Text] ")
        Query.Append("end ")
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
                        .Value = DR("Value"),
                        .Text = DR("Text")
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

#Region "FRM000022"

    Private Function FRM000022_Get_Buyer_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000022_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].LotCode ")
        Query.Append("   ,isnull((select top 1 [B].ContactNo from calmardblive.dbo.mstr_ContactNos [B] where [B].AcctNo = [A].AcctNo and [B].NoCode = 1),'-') [MobileNo] ")
        Query.Append("   ,isnull([A].eMail,'-') [Email] ")
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
                        .MobileNo = DR("MobileNo"),
                        .Email = DR("Email")
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

    Private Function FRM000022_Get_Project_List(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      [A].LotCode [Code] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("	    and ([D].description like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr like '%" & Find & "%' ")
        Query.Append("	       or [C].description like '%" & Find & "%' ")
        Query.Append("	       or 'B' + [B].block like '%" & Find & "%' ")
        Query.Append("	       or 'L' + [A].lot like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot like '%" & Find & "%') ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000022_Get_Project_Info(Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Project] ")
        Query.Append("      ,[A].LotCode ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode = '" & Code & "' ")
        'subdivision

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
                        .Project = DR("Project"),
                        .LotCode = DR("LotCode")
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

#Region "FRM000023"

    Private Function FRM000023_Get_Buyer_List(Value)

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000023_Get_Buyer_Info(AcctNo)

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

    Private Function FRM000023_Get_Project_List(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      [A].LotCode [Code] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("	    and ([D].description like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr like '%" & Find & "%' ")
        Query.Append("	       or [C].description like '%" & Find & "%' ")
        Query.Append("	       or 'B' + [B].block like '%" & Find & "%' ")
        Query.Append("	       or 'L' + [A].lot like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot like '%" & Find & "%') ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000023_Get_Project_Info(LotCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].LotCode ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[B].ProjInit ")
        Query.Append("   ,[A].PhaseNo ")
        Query.Append("   ,[A].Block ")
        Query.Append("   ,[A].Lot ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
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
                        .Project = DR("Project"),
                        .ProjInit = DR("ProjInit"),
                        .PhaseNo = DR("PhaseNo"),
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

#End Region

#Region "FRM000024"

    Private Function FRM000024_Get_Project_List(Find)

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000024_Get_Project_Info(LotCode)

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

#Region "FRM000025"

    Private Function FRM000025_Get_Buyer_List(Value)

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000025_Get_Buyer_Info(AcctNo)

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

    Private Function FRM000025_Get_Project_List(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("      [A].LotCode [Code] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("	    and ([D].description like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr like '%" & Find & "%' ")
        Query.Append("	       or [C].description like '%" & Find & "%' ")
        Query.Append("	       or 'B' + [B].block like '%" & Find & "%' ")
        Query.Append("	       or 'L' + [A].lot like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot like '%" & Find & "%') ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000025_Get_Project_Info(LotCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [B].ProjInit ")
        Query.Append("   ,[A].PhaseNo ")
        Query.Append("   ,[A].Block ")
        Query.Append("   ,[A].Lot ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
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
                        .ProjInit = DR("ProjInit"),
                        .PhaseNo = DR("PhaseNo"),
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

#End Region

#Region "FRM000027"

    Private Function FRM000027_Get_Buyer_List(Value)

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Private Function FRM000027_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].LotCode ")
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
                        .LotCode = DR("LotCode")
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

#Region "FRM000028"

    Private Function FRM000028_Get_Project_List(Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].LotCode ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.mstr_LotsInventory [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 [A].LotCode like '%" & Find & "%' ")
        Query.Append("	    or [B].ProjInit like '%" & Find & "%' ")
        Query.Append("	    or [A].PhaseNo like '%" & Find & "%' ")
        Query.Append("	    or [A].Block like '%" & Find & "%' ")
        Query.Append("	    or [A].Lot like '%" & Find & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot like '%" & Find & "%' ")
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
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectProject('" & DR("LotCode") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Project") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("LotCode") & "</span>")
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

    Private Function FRM000028_Get_Project_Info(LotCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].LotCode ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Lot [A] ")
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
                        .Project = DR("Project"),
                        .LotCode = DR("LotCode")
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

#Region "FRM000029"

    Private Function FRM000029_Get_Buyer_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000029_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
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
                        .AcctName = DR("AcctName")
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

    Private Function FRM000029_Get_Porject_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   LotCode ")
        Query.Append("   ,ProjInit + ' ' + PhaseNo + ' B' + Block + ' L' + Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Lot ")
        Query.Append("where ")
        Query.Append("	 (LotCode like '%" & Value & "%' ")
        Query.Append("	    or ProjInit + ' ' + PhaseNo + ' B' + Block + ' L' + Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectProject('" & DR("LotCode") & "')"">")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100' >")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Project") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("LotCode") & "</span>")
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

    Private Function FRM000029_Get_Project_Info(LotCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   LotCode ")
        Query.Append("   ,ProjInit + ' ' + PhaseNo + ' B' + Block + ' L' + Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Lot ")
        Query.Append("where ")
        Query.Append("	 LotCode = '" & LotCode & "' ")
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

#Region "FRM000031"

    Private Function FRM000031_Get_Buyer_List(Value)

        'get form
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.ICR_Buyers [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].ProjCode = [B].ProjCode ")
        Query.Append("where ")
        Query.Append("	 ([A].AcctNo like '%" & Value & "%' ")
        Query.Append("	    or [A].AcctName like '%" & Value & "%' ")
        Query.Append("	    or [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot like '%" & Value & "%') ")
        Query.Append("order by ")
        Query.Append("   [Project] ")
        'get form

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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000031_Get_Buyer_Info(AcctNo)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("Select  ")
        Query.Append("   [A].AcctNo ")
        Query.Append("   ,[A].AcctName ")
        Query.Append("   ,[A].Subd + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
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

#Region "FRM000033"

    Private Function FRM000033_Get_Contract_List()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].HWCode [ID] ")
        Query.Append("   ,'House Construction' [Category] ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("	 ,[C].vendor [Contractor] ")
        Query.Append("	 ,[A].ConNo ")
        Query.Append("	 ,FORMAT([A].ConPrice,'N2') [Price] ")
        Query.Append("	 ,FORMAT([A].BillAmt,'N2') [Billed] ")
        Query.Append("	 ,FORMAT([A].TCPBal,'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("	 Form_HWHdr [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("	 left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("	 [A].ConStatus = 'Awarded' ")
        Query.Append("	 and [A].ConPrice > isnull([A].BillAmt,0) ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("	 [B].f_code [ID] ")
        Query.Append("	 ,[A].Category ")
        Query.Append("	 ,[A].Project ")
        Query.Append("	 ,[C].vendor [Contractor] ")
        Query.Append("	 ,[A].ContractNo [ConNo] ")
        Query.Append("	 ,FORMAT([A].ContractPrice,'N2') [Price] ")
        Query.Append("	 ,FORMAT([A].BillAmt,'N2') [Billed] ")
        Query.Append("	 ,FORMAT([A].TCPBal,'N2') [Balance] ")
        Query.Append("from ")
        Query.Append("	 Form_CRT [A] ")
        Query.Append("	 left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_Code ")
        Query.Append("	 left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("	 [B].tbl_from = 'Form_CRT' ")
        Query.Append("	 and [B].status not in ('Cancelled','Declined') ")
        Query.Append("	 and [A].ContractStatus = 'Awarded' ")
        Query.Append("	 and [A].ContractPrice > isnull([A].BillAmt,0) ")
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
                    Data.Append("<a href ='#' class='d-flex align-items-center w-100' onclick=""SelectContract('" & DR("ID") & "')""> ")
                    Data.Append("   <div class='d-flex flex-column min-w-400px w-100'>")
                    Data.Append("      <span class='text-dark fw-bolder fs-6 nowrap-auto'>" & DR("Category") & " / " & DR("Project") & "</span>")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7 nowrap-auto' >" & DR("ID") & " " & DR("Contractor") & "</span>")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'> ")
                    Data.Append("      <span class='text-dark fw-bolder fs-6'>" & DR("Price") & "</span> ")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7'>Price</span> ")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'> ")
                    Data.Append("      <span class='text-dark fw-bolder fs-6'>" & DR("Billed") & "</span> ")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7'>Billed</span> ")
                    Data.Append("   </div>")
                    Data.Append("   <div class='d-flex flex-column min-w-150px'>")
                    Data.Append("      <span class='text-dark fw-bolder fs-6'>" & DR("Balance") & "</span> ")
                    Data.Append("      <span class='text-muted fw-bold text-muted d-block fs-7'>Balnce</span> ")
                    Data.Append("   </div> ")
                    Data.Append("</a> ")

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

    Private Function FRM000033_Get_Contract_Info(ID)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].HWCode [ID] ")
        Query.Append("   ,'House Construction' [Category] ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[C].vendor [Contractor] ")
        Query.Append("   ,[A].ConNo ")
        Query.Append("from ")
        Query.Append("	 Form_HWHdr [A] ")
        Query.Append("	 left join calmardblive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("	 left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("	 [A].HWCode = '" & ID & "' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("	 [B].f_code [ID] ")
        Query.Append("	 ,[A].Category ")
        Query.Append("	 ,[A].Project ")
        Query.Append("	 ,[C].vendor [Contractor] ")
        Query.Append("	 ,[A].ContractNo [ConNo] ")
        Query.Append("from ")
        Query.Append("	 Form_CRT [A] ")
        Query.Append("	 left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_Code ")
        Query.Append("	 left join ogm_vendor [C] on [A].Contractor = [C].v_code ")
        Query.Append("where ")
        Query.Append("	 [B].f_code = '" & ID & "' ")
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
                        .ID = DR("ID"),
                        .Category = DR("Category"),
                        .Project = DR("Project"),
                        .Contractor = DR("Contractor"),
                        .ConNo = DR("ConNo")
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

#Region "FRM000036"
    Function FRM000036_Get_Phase_Info(Code)

        'get phase
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  '' [Value] ")
        Query.Append("  ,'Select phase' [Text] ")
        Query.Append("	,0 [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  Phase [Value] ")
        Query.Append("  ,Phase [Text] ")
        Query.Append("  ,1 [Order] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.Lot ")
        Query.Append("where ")
        Query.Append("  Subd = '" & Code & "' ")
        Query.Append("order by ")
        Query.Append("  [Order] ")
        Query.Append("  ,[Text] ")
        'get phase

        'variable
        Dim PhaseList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    PhaseList.Add(New With {
                        .Value = DR("Value"),
                        .Text = DR("Text")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(PhaseList))
        'display 

    End Function

    Function FRM000036_Get_Block_Info(Code)

        'get block
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  '' [Value] ")
        Query.Append("  ,'Select block' [Text] ")
        Query.Append("	,0 [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  Block [Value] ")
        Query.Append("  ,Block [Text] ")
        Query.Append("  ,(case when isnumeric(Block) = 1 then convert(int, Block) else (case when isnumeric(substring(Block, 1, 1)) = 1 then convert(int, replace(Block, substring(Block, patindex('%[^0-9]%', Block), 20), '')) else 0 end) end) [Order] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.Lot ")
        Query.Append("where ")
        Query.Append("  Subd + ' ' + Phase = '" & Code & "' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  'Others' [Value] ")
        Query.Append("  ,'Others' [Text] ")
        Query.Append("  ,999 [Order] ")
        Query.Append("order by ")
        Query.Append("  [Order] ")
        'get block

        'variable
        Dim BlockList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    BlockList.Add(New With {
                        .Value = DR("Value"),
                        .Text = DR("Text")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(BlockList))
        'display 

    End Function

    Function FRM000036_Get_Lot_Info(Code)

        'get block
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  '' [Value] ")
        Query.Append("  ,'Select lot' [Text] ")
        Query.Append("	,0 [Order] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  Lot [Value] ")
        Query.Append("  ,Lot + ' (sq.m. ' + LTRIM(STR(LotArea)) + ')' [Text] ")
        Query.Append("  ,(case when isnumeric(Lot) = 1 then convert(int, Lot) else (case when isnumeric(substring(Lot, 1, 1)) = 1 then convert(int, replace(Lot, substring(Lot, patindex('%[^0-9]%', lot), 20), '')) else 0 end) end) [Order] ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.Lot ")
        Query.Append("where ")
        Query.Append("  Subd + ' ' + Phase + ' ' + Block = '" & Code & "' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  'Others' [Value] ")
        Query.Append("  ,'Others' [Text] ")
        Query.Append("  ,999 [Order] ")
        Query.Append("order by ")
        Query.Append("  [Order] ")
        'get block

        'variable
        Dim LotList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    LotList.Add(New With {
                        .Value = DR("Value"),
                        .Text = DR("Text")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(LotList))
        'display 

    End Function

#End Region

#Region "FRM000037"

    Private Function FRM000037_Get_Project_Info(Category, Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = '" & Category & "'  ")

        'subd phase
        Query.Append("if @Category in ('Structural Consultant - Amenities','Service Entrance','Land Scape Project Restoration','Land Scape Project New','Land Development Repair','Land Development New','DOLE Application - Land Development','Amenities Repair','Amenities New') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [B].abbr + ' ' + [A].description [Project] ")
        Query.Append("      ,[A].scode [Subdivision] ")
        Query.Append("      ,[A].code [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("	    phase [A] ")
        Query.Append("	    left join subdivision [B] on [A].scode = [B].code ")
        Query.Append("   where ")
        Query.Append("	    [A].code = '" & Code & "' ")
        Query.Append("end  ")
        'subd phase

        'subd phase block lot
        Query.Append("else if @Category in ('Structural Consultant - House Unit','NWRB Application','Land Scape Unit','Interior Designer','House Repair','House Construction','Electrical Consultant','DOLE Application - Model House','Basic to Complete') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Project] ")
        Query.Append("      ,[A].s_code [Subdivision] ")
        Query.Append("      ,[A].p_code [Phase] ")
        Query.Append("      ,[A].b_code [Block] ")
        Query.Append("      ,[A].l_code [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].l_code = '" & Code & "' ")
        Query.Append("end  ")
        'subd phase block lot

        'branch
        Query.Append("else if @Category in ('CLDC Office') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      dbo.ProperCase([A].description) [Project] ")
        Query.Append("      ,'' [Subdivision] ")
        Query.Append("      ,'' [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,[A].buss_code [Branch] ")
        Query.Append("   from ")
        Query.Append("      business [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'branch

        'subdivision
        Query.Append("else if @Category in ('Waste Hauling Services','Utilities Repair','Testing and Investigation','Temporary Facilities Construction','Security Services','Container Van','Clearing / Grass Cutting') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      dbo.ProperCase([A].description) [Project] ")
        Query.Append("      ,[A].code [Subdivision] ")
        Query.Append("      ,'' [Phase] ")
        Query.Append("      ,'' [Block] ")
        Query.Append("      ,'' [Lot] ")
        Query.Append("      ,'' [Branch] ")
        Query.Append("   from ")
        Query.Append("      subdivision [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subdivision

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
                        .Project = DR("Project"),
                        .Subdivision = DR("Subdivision"),
                        .Phase = DR("Phase"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .Branch = DR("Branch")
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

    Private Function FRM000037_Get_Project_List(Category, Find)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("declare @Category nvarchar(60) = '" & Category & "'  ")

        'subd phase
        Query.Append("if @Category in ('Structural Consultant - Amenities','Service Entrance','Land Scape Project Restoration','Land Scape Project New','Land Development Repair','Land Development New','DOLE Application - Land Development','Amenities Repair','Amenities New') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].code [Code] ")
        Query.Append("      ,[B].abbr + ' ' + [A].description [Description] ")
        Query.Append("   from ")
        Query.Append("	    phase [A] ")
        Query.Append("	    left join subdivision [B] on [A].scode = [B].code ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subd phase

        'subd phase block lot
        Query.Append("else if @Category in ('Structural Consultant - House Unit','NWRB Application','Land Scape Unit','Interior Designer','House Repair','House Construction','Electrical Consultant','DOLE Application - Model House','Basic to Complete') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].l_code [Code] ")
        Query.Append("      ,[D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot [Description] ")
        Query.Append("   from ")
        Query.Append("      eng_lot [A] ")
        Query.Append("      left join eng_block [B] on [A].b_code = [B].b_code ")
        Query.Append("      left join phase [C] on [A].p_code = [C].code ")
        Query.Append("      left join subdivision [D] on [A].s_code = [D].code ")
        Query.Append("   where ")
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E]) ")
        Query.Append("	    and ([D].description like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr like '%" & Find & "%' ")
        Query.Append("	       or [C].description like '%" & Find & "%' ")
        Query.Append("	       or 'B' + [B].block like '%" & Find & "%' ")
        Query.Append("	       or 'L' + [A].lot like '%" & Find & "%' ")
        Query.Append("	       or [D].abbr + ' ' + [C].description + ' B' + [B].block + ' L' + [A].lot like '%" & Find & "%') ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'subd phase block lot

        'branch
        Query.Append("else if @Category in ('CLDC Office') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].buss_code [Code] ")
        Query.Append("      ,dbo.ProperCase([A].description) [Description] ")
        Query.Append("   from ")
        Query.Append("      business [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
        'branch

        'subdivision
        Query.Append("else if @Category in ('Waste Hauling Services','Utilities Repair','Testing and Investigation','Temporary Facilities Construction','Security Services','Container Van','Clearing / Grass Cutting') ")
        Query.Append("begin  ")
        Query.Append("   select ")
        Query.Append("      [A].code [Code] ")
        Query.Append("      ,dbo.ProperCase([A].description) [Description] ")
        Query.Append("   from ")
        Query.Append("      subdivision [A] ")
        Query.Append("   where ")
        Query.Append("	    [A].lock = 1 ")
        Query.Append("   order by ")
        Query.Append("      [Description] ")
        Query.Append("end  ")
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
                    RecordList.Add(New With {
                        .Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-secondary'></span>",
                        .Code = "<a id='" & DR("Code") & "' class='pointer' onclick='SelectProject(this.id)'>" & DR("Code") & "</a>",
                        .Description = "<span class='nowrap-400px'>" & DR("Description") & "</span>"
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

#Region "FRM000038"

    Private Function FRM000038_Get_Project_List(Search)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [Code] ")
        Query.Append("   ,[A].BatchNo + ' / ' + [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' / ' + [C].ModelName [Description] ")
        Query.Append("from ")
        Query.Append("   Form_HWHdr [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [C] on [A].House = [C].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].ConStatus = 'Awarded' ")
        Query.Append("	 and ([A].HWCode like '%" & Search & "%' ")
        Query.Append("	 or [A].BatchNo + ' / ' + [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' / ' + [C].ModelName like '%" & Search & "%') ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [B].f_code [Code] ")
        Query.Append("   ,[A].Project + ' / ' + [A].Remarks [Description] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("where ")
        Query.Append("   [A].ContractStatus = 'Awarded' ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
        Query.Append("	 and ([B].f_code like '%" & Search & "%' ")
        Query.Append("	 or [A].Project + ' / ' + [A].Remarks like '%" & Search & "%') ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000038_Get_Project_Info(Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [Code] ")
        Query.Append("   ,[A].BatchNo + ' / ' + [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' / ' + [C].ModelName [Description] ")
        Query.Append("   ,[A].Contractor [ConCode] ")
        Query.Append("   ,[D].vendor [ConName] ")
        Query.Append("from ")
        Query.Append("   Form_HWHdr [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [C] on [A].House = [C].ModelCode ")
        Query.Append("   left join ogm_vendor [D] on [A].Contractor = [D].v_code ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & Code & "' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [B].f_code [Code] ")
        Query.Append("   ,[A].Project + ' / ' + [A].Remarks [Description] ")
        Query.Append("   ,[A].Contractor [ConCode] ")
        Query.Append("   ,[D].vendor [ConName] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [D] on [A].Contractor = [D].v_code ")
        Query.Append("where ")
        Query.Append("   [B].f_code = '" & Code & "' ")
        Query.Append("order by ")
        Query.Append("   [Description] ")
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
                        .Code = DR("Code"),
                        .Description = DR("Description"),
                        .ConCode = DR("ConCode"),
                        .ConName = DR("ConName")
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

#Region "FRM000039"

    Private Function FRM000039_Get_Project_List()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [Code] ")
        Query.Append("   ,[A].BatchNo + ' / ' + [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' / ' + [C].ModelName [Description] ")
        Query.Append("from ")
        Query.Append("   Form_HWHdr [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [C] on [A].House = [C].ModelCode ")
        Query.Append("where ")
        Query.Append("   [A].ConStatus = 'Awarded' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [B].f_code [Code] ")
        Query.Append("   ,[A].Project + ' / ' + [A].Remarks [Description] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("where ")
        Query.Append("   [A].ContractStatus = 'Awarded' ")
        Query.Append("   and [B].tbl_from = 'Form_CRT' ")
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Private Function FRM000039_Get_Project_Info(Code)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].HWCode [Code] ")
        Query.Append("   ,[A].BatchNo + ' / ' + [B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot + ' / ' + [C].ModelName [Description] ")
        Query.Append("   ,[A].Contractor [ConCode] ")
        Query.Append("   ,[D].vendor [ConName] ")
        Query.Append("from ")
        Query.Append("   Form_HWHdr [A] ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [C] on [A].House = [C].ModelCode ")
        Query.Append("   left join ogm_vendor [D] on [A].Contractor = [D].v_code ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & Code & "' ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [B].f_code [Code] ")
        Query.Append("   ,[A].Project + ' / ' + [A].Remarks [Description] ")
        Query.Append("   ,[A].Contractor [ConCode] ")
        Query.Append("   ,[D].vendor [ConName] ")
        Query.Append("from ")
        Query.Append("   Form_CRT [A] ")
        Query.Append("   left join oop_form_hdr [B] on [A].CRTCode = [B].tbl_code ")
        Query.Append("   left join ogm_vendor [D] on [A].Contractor = [D].v_code ")
        Query.Append("where ")
        Query.Append("   [B].f_code = '" & Code & "' ")
        Query.Append("order by ")
        Query.Append("   [Description] ")
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
                        .Code = DR("Code"),
                        .Description = DR("Description"),
                        .ConCode = DR("ConCode"),
                        .ConName = DR("ConName")
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

    Function bindWARStatus(Status, SubStatus)

        'get approver 
        Dim Query As New StringBuilder
        If Status = "All" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded')")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [A].Status = 'On-Going' ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [B].ConStatus = 'Awarded' ")
            Query.Append("   and [B].POCRate = 100 ")
            Query.Append("   and year([B].POCDate) = year(getdate()) ")
        End If
        If Status = "Completed" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [B].ConStatus = 'Awarded' ")
            Query.Append("   and [B].POCRate = 100 ")
            Query.Append("   and year([B].POCDate) = year(getdate()) ")
            Query.Append("   and (case when '" & SubStatus & "' = 'All' then 'All' else ltrim(str(month([B].POCDate))) end) = '" & SubStatus & "' ")
        End If
        If Status = "On-Going" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [A].Status = 'On-Going' ")
        End If
        If Status = "For Construction" And SubStatus = "All" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded') ")
        ElseIf Status = "For Construction" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [A].Status = '" & SubStatus & "' ")
        End If
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function bindWARPE(FormCode, Project, PE, Status)

        'get approver 
        Dim Query As New StringBuilder
        If FormCode = "DSB000013" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [B].ConStatus = 'Awarded' ")
            Query.Append("   and [B].BatchNo = '" & Project & "' ")
            Query.Append("   and dbo.ProperCase([F].first_name) = '" & PE & "' ")
            Query.Append("   and (case when '" & Status & "' = 'Assigned' and isnull([B].POCRate,0) <= 99.99 then 'Assigned' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd >= [A].POCDate then 'On-time' when isnull([B].POCRate,0) = 0 then 'Not yet started' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd < [A].POCDate then 'Delayed' end) = '" & Status & "' ")
        ElseIf FormCode = "DSB000011" Or FormCode = "DSB000010" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and [B].ConStatus = 'Awarded' ")
            Query.Append("   and [B].Subd = '" & Project & "' ")
            Query.Append("   and dbo.ProperCase([F].first_name) = '" & PE & "' ")
            Query.Append("   and (case when '" & Status & "' = 'Assigned' and isnull([B].POCRate,0) <= 99.99 then 'Assigned' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd >= [A].POCDate then 'On-time' when isnull([B].POCRate,0) = 0 then 'Not yet started' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd < [A].POCDate then 'Delayed' end) = '" & Status & "' ")
        End If
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function bindWARBatch(Batch, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [B].ConStatus = 'Awarded' ")
        Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("   and (case when '" & Status & "' = 'All' and isnull([B].POCRate,0) between 0.00 and 99.99 then 'All' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd >= [A].POCDate then 'On-time' when isnull([B].POCRate,0) = 0 then 'Not yet started' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd < [A].POCDate then 'Delayed' end) = '" & Status & "' ")

        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function bindWARProject(Project, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [B].ConStatus = 'Awarded' ")
        Query.Append("   and [B].Subd = '" & Project & "' ")
        Query.Append("   and (case when '" & Status & "' = 'All' and isnull([B].POCRate,0) between 0.00 and 99.99 then 'All' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd >= [A].POCDate then 'On-time' when isnull([B].POCRate,0) = 0 then 'Not yet started' when isnull([B].POCRate,0) between 0.01 and 99.99 and [A].DateEnd < [A].POCDate then 'Delayed' end) = '" & Status & "' ")

        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function bindWARDivision(Division, Status)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [B].ConStatus = 'Awarded' ")
        Query.Append("   and (case when '" & Division & "' = 'All' then 'All' else [C].Division end) = '" & Division & "' ")
        Query.Append("   and (case when '" & Status & "' = 'All' and isnull([B].POCRate,0) between 0.00 and 99.99 then 'All' when isnull([B].POCRate,0) between 0.01 and 99.99 then 'On-going' when isnull([B].POCRate,0) = 0 then 'Not yet started' end) = '" & Status & "' ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function bindWARYear(Year)

        'get approver 
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [B].HWCode ")
        Query.Append("   ,[C].Territory ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
        Query.Append("   ,[D].ModelName ")
        Query.Append("   ,isnull([A].Status,'') [Status] ")
        Query.Append("   ,isnull([E].vendor,'') [vendor] ")
        Query.Append("   ,[B].BatchNo ")
        Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
        Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
        Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and isnull([B].POCRate,0) = 100.00 ")
        Query.Append("   and year(isnull([B].POCDate,getdate())) = " & Year & " ")
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Function bindWARMonth(Year, Mon, Category)

        'get approver 
        Dim Query As New StringBuilder
        If Category = "Actual" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and year([A].DateEnd) = " & Year & " ")
            Query.Append("   and month([A].DateEnd) = " & Month(CDate(Mon & " 1, " & Year)) & " ")
            Query.Append("   and isnull([B].POCRate,0) = 100.00 ")
        End If
        If Category = "Target" Then
            Query.Append("select ")
            Query.Append("   [B].HWCode ")
            Query.Append("   ,[C].Territory ")
            Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot [Project] ")
            Query.Append("   ,[D].ModelName ")
            Query.Append("   ,isnull([A].Status,'') [Status] ")
            Query.Append("   ,isnull([E].vendor,'') [vendor] ")
            Query.Append("   ,[B].BatchNo ")
            Query.Append("   ,isnull([B].POCRate,0) [POCRate] ")
            Query.Append("   ,isnull([B].POCDate,getdate()) [POCDate] ")
            Query.Append("   ,isnull((select top 1 [H].Remarks from Form_HWNotes [H] where [H].HWCode = [B].HWCode and [H].TaskCode = '006' order by [H].SeqNo desc),'') [Remarks] ")
            Query.Append("   ,dbo.ProperCase([F].first_name) [PE] ")
            Query.Append("from ")
            Query.Append("   Form_HWTask [A] ")
            Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
            Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode ")
            Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
            Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
            Query.Append("   left join view_ContructionStatus [G] on [A].HWCode = [G].HWCode ")
            Query.Append("where ")
            Query.Append("   [A].TaskCode = '006' ")
            Query.Append("   and year([A].DateEnd) = " & Year & " ")
            Query.Append("   and month([A].DateEnd) = " & Month(CDate(Mon & " 1, " & Year)) & " ")
        End If
        'get approver 

        'variable
        Dim WARList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Bullet As String = ""
                    If DR("Status") = "Newly Endorsed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-NewlyEndorsed'></span>"
                    ElseIf DR("Status") = "for Costing" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForCosting'></span>"
                    ElseIf DR("Status") = "for Budget" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForBudget'></span>"

                    ElseIf DR("Status") = "for Award" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-ForAward'></span>"
                    ElseIf DR("Status") = "Awarded" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Awarded'></span>"
                    ElseIf DR("Status") = "On-Going" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnGoing'></span>"

                    ElseIf DR("Status") = "Completed" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Completed'></span>"
                    ElseIf DR("Status") = "On-hold" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-OnHold'></span>"
                    ElseIf DR("Status") = "Cancelled" Then
                        Bullet = "<span class='bullet bullet-vertical bullet-margin h-40px bg-Cancelled'></span>"

                    End If

                    WARList.Add(New With {
                        .Bullet = Bullet,
                        .HWCode = DR("HWCode"),
                        .Territory = DR("Territory"),
                        .Project = DR("Project"),
                        .ModelName = DR("ModelName"),
                        .Status = DR("Status"),
                        .vendor = "<span class='nowrap-250px'>" & DR("vendor") & "</span>",
                        .BatchNo = DR("BatchNo"),
                        .POCRate = DR("POCRate") & "%",
                        .POCDate = Format(DR("POCDate"), "MM/dd/yyyy"),
                        .Remarks = "<span class='nowrap-250px'>" & DR("Remarks") & "</span>",
                        .PE = DR("PE")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(WARList))
        'display 

    End Function

    Private Function bindBarChart(Year_ As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   (select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 1 and [A].POCRate = 100) [Act01] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 1) [Tar01] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 2 and [A].POCRate = 100) [Act02] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 2) [Tar02] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 3 and [A].POCRate = 100) [Act03] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 3) [Tar03] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 4 and [A].POCRate = 100) [Act04] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 4) [Tar04] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 5 and [A].POCRate = 100) [Act05] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 5) [Tar05] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 6 and [A].POCRate = 100) [Act06] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 6) [Tar06] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 7 and [A].POCRate = 100) [Act07] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 7) [Tar07] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 8 and [A].POCRate = 100) [Act08] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 8) [Tar08] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 9 and [A].POCRate = 100) [Act09] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 9) [Tar09] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 10 and [A].POCRate = 100) [Act10] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 10) [Tar10] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 11 and [A].POCRate = 100) [Act11] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 11) [Tar11] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 12 and [A].POCRate = 100) [Act12] ")
        Query.Append("   ,(select count(1) from Form_HWTask [A] where [A].TaskCode = '006' and year([A].DateEnd) = " & Year_ & " and month([A].DateEnd) = 12) [Tar12] ")
        'get approver 

        'variable
        Dim YearInfo As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    YearInfo.Add(New With {
                        .Actual = DR("Act01") & "," & DR("Act02") & "," & DR("Act03") & "," & DR("Act04") & "," & DR("Act05") & "," & DR("Act06") & "," & DR("Act07") & "," & DR("Act08") & "," & DR("Act09") & "," & DR("Act10") & "," & DR("Act11") & "," & DR("Act12"),
                        .Target = DR("Tar01") & "," & DR("Tar02") & "," & DR("Tar03") & "," & DR("Tar04") & "," & DR("Tar05") & "," & DR("Tar06") & "," & DR("Tar07") & "," & DR("Tar08") & "," & DR("Tar09") & "," & DR("Tar10") & "," & DR("Tar11") & "," & DR("Tar12")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(YearInfo))
        'display 

    End Function

    Private Function bindBatchList(Year As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   * ")
        Query.Append("from ")
        Query.Append("   (select ")
        Query.Append("      [A].No ")
        Query.Append("	    ,'DSB000014-' + [A].BatchNo [Link]  ")
        Query.Append("      ,[A].BatchNo ")
        Query.Append("      ,(select count(1) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [B].TaskCode = '006' and [C].ConStatus = 'Awarded' and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].DateEnd >= [B].POCDate and [C].BatchNo = [A].BatchNo) [Ontime] ")
        Query.Append("      ,(select count(1) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [B].TaskCode = '006' and [C].ConStatus = 'Awarded' and isnull([B].POCRate,0) = 0 and [C].BatchNo = [A].BatchNo) [NotYetStarted] ")
        Query.Append("      ,(select count(1) from Form_HWTask [B] left join Form_HWHdr [C] on [B].HWCode = [C].HWCode where [B].TaskCode = '006' and [C].ConStatus = 'Awarded' and isnull([B].POCRate,0) between 0.01 and 99.99 and [B].DateEnd < [B].POCDate and [C].BatchNo = [A].BatchNo) [Delayed] ")
        Query.Append("      ,[A].DateReleased ")
        Query.Append("   from ")
        Query.Append("      calmardblive.dbo.mstr_BatchNo [A] ")
        Query.Append("   where ")
        Query.Append("     [A].Year = " & Year & ") [A] ")
        Query.Append("where ")
        Query.Append("   [A].[Ontime] + [NotYetStarted] + [Delayed] > 0 ")
        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    InnerHtml.Append("<div class='col-md-6 col-xl-4'> ")
                    InnerHtml.Append("   <div class='card border-hover-primary'> ")
                    InnerHtml.Append("      <div class='card-header border-0 pt-9'> ")
                    InnerHtml.Append("         <div class='card-title m-0'> ")
                    InnerHtml.Append("            <div class='symbol symbol-50px me-5'> ")
                    InnerHtml.Append("               <div class='symbol-label bg-info text-inverse-info fs-2 fw-bold'>" & DR.GetString(0) & "</div> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("            <div class='symbol symbol-30px'> ")
                    InnerHtml.Append("               <a class='symbol-label fs-5 fw-bold pointer' onclick=""ViewWARBatch('" & DR.GetString(2) & "','All')"">" & DR.GetInt32(3) + DR.GetInt32(4) + DR.GetInt32(5) & "</a> ")
                    InnerHtml.Append("            </div> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("         <div class='card-toolbar'> ")
                    InnerHtml.Append("            <a href ='" & DR.GetString(1) & "' class='btn btn-primary btn-sm me-3'>View Details</a> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("      <div class='card-body p-9'> ")
                    InnerHtml.Append("         <div class='fs-3 fw-bolder text-dark'>Batch " & DR.GetString(2) & "</div> ")
                    InnerHtml.Append("         <p class='text-gray-400 fw-bold fs-5 mt-1 mb-7'>" & Format(DR.GetDateTime(6), "dd MMM, yyyy") & "</p> ")
                    InnerHtml.Append("         <div class='d-flex flex-wrap mb-5'> ")
                    InnerHtml.Append("            <a class='border border-gray-300 border-dashed rounded min-w-100px py-3 px-4 me-3 mb-3 pointer' onclick=""ViewWARBatch('" & DR.GetString(2) & "','On-time')""> ")
                    InnerHtml.Append("               <div class='fs-5 text-gray-800 fw-bolder'>" & DR.GetInt32(3) & "</div> ")
                    InnerHtml.Append("               <div class='fw-bold text-gray-400'>On-time</div> ")
                    InnerHtml.Append("            </a> ")
                    InnerHtml.Append("            <a class='border border-gray-300 border-dashed rounded min-w-100px py-3 px-4 me-3 mb-3 pointer' onclick=""ViewWARBatch('" & DR.GetString(2) & "','Not yet started')""> ")
                    InnerHtml.Append("               <div class='fs-5 text-gray-800 fw-bolder'>" & DR.GetInt32(4) & "</div> ")
                    InnerHtml.Append("               <div class='fw-bold fs-7 text-gray-400'>Not yet started</div> ")
                    InnerHtml.Append("            </a> ")
                    InnerHtml.Append("            <a class='border border-gray-300 border-dashed rounded min-w-100px py-3 px-4 mb-3 pointer' onclick=""ViewWARBatch('" & DR.GetString(2) & "','Delayed')""> ")
                    InnerHtml.Append("               <div class='fs-5 text-gray-800 fw-bolder'>" & DR.GetInt32(5) & "</div> ")
                    InnerHtml.Append("               <div class='fw-bold text-gray-400'>Delayed</div> ")
                    InnerHtml.Append("            </a> ")
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("         <div class='symbol-group symbol-hover'> ")
                    InnerHtml.Append(Me.bindPEList(DR.GetString(2)))
                    InnerHtml.Append("         </div> ")
                    InnerHtml.Append("      </div> ")
                    InnerHtml.Append("   </div> ")
                    InnerHtml.Append("</div> ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        Return InnerHtml.ToString
        'display

    End Function

    Private Function bindPEList(BatchNo As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].AssignTo  ")
        Query.Append("   ,dbo.ProperCase([C].first_name) ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join employee [C] on [A].AssignTo = [C].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and isnull([A].POCRate,0) < 100 ")
        Query.Append("   and [B].BatchNo = '" & BatchNo & "' ")
        Query.Append("   and [B].ConStatus = 'Awarded'")
        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim imgUser As String = ""
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR.GetString(0) & ".png")) = True Then
                        imgUser = "Assets/media/avatars/" & DR.GetString(0) & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR.GetString(0) & ".jpg")) = True Then
                        imgUser = "Assets/media/avatars/" & DR.GetString(0) & ".jpg"
                    Else
                        imgUser = "Assets/media/avatars/blank.png"
                    End If

                    InnerHtml.Append("            <a class='symbol symbol-35px symbol-circle pointer' data-bs-toggle='tooltip' title='" & DR.GetString(1) & "' onclick=""ViewWARPE('" & BatchNo & "' ,'" & DR.GetString(1) & "' ,'Assigned')""> ")
                    InnerHtml.Append("               <img alt ='Pic' src='" & imgUser & "' /> ")
                    InnerHtml.Append("            </a> ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        Return InnerHtml.ToString
        'display

    End Function

End Class