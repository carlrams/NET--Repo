Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.InteropServices
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports System.Net.PeerToPeer.Collaboration
Public Class DSB140000HND
    Implements System.Web.IHttpHandler


    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
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
            Dim pFormCode = context.Request("pFormCode")
            Dim pFunction = context.Request("pFunction")
            'general parameter
            Dim pType = context.Request("pType")
            'general parameter

            If pFunction = "Get-DeptCode" Then


                Dim json As String = Me.Get_DeptCode()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Access-01" Then


                Dim json As String = Me.Access_01()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Get-Record-01" Then

                Dim pDeptCode = context.Request("pDeptCode")

                Dim json As String = Me.Get_Record_01(pDeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Get-Record-02" Then

                Dim pDeptCode = context.Request("pDeptCode")

                Dim json As String = Me.Get_Record_02(pDeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Get-Record-03" Then


                Dim json As String = Me.Get_Record_03()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            ElseIf pFunction = "Get-Record-04" Then

                Dim pYear As String = context.Request("pYear")
                Dim pDeptCode = context.Request("pDeptCode")

                Dim json As String = Me.Get_Record_04(pYear, pDeptCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Record-01-List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_01_List(pTblName, pPlaceHolder, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Get-Type-01" Then

                Dim pList = context.Request("pList")
                Dim pDeptCode = context.Request("pDeptCode")

                Dim json As String = Me.Get_Type_01(pList, pDeptCode)
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

    Function Get_Record_01_List(pTblName, pPlaceHolder, pID)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Department" Then
            Query.Append(" Select '' [ID], ")
            Query.Append(" '" & pPlaceHolder & "' [Name]  ")
            Query.Append(" ,1 [Order01]  ")
            Query.Append(",'' [Order02]  ")
            Query.Append(" union select  ")
            Query.Append(" cast(dept_code As nvarchar(13)) [ID],   ")
            Query.Append(" Description [Name]  ")
            Query.Append(" ,2 [Order01]  ")
            Query.Append(" ,Description [Order02]  ")
            Query.Append(" From ")
            Query.Append(" department ")
            Query.Append(" Where ")
            Query.Append(" dept_code = '" & pID & "'  ")
            Query.Append(" union Select ")
            Query.Append(" cast(dept_code As nvarchar(13)) [ID]   ")
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
        ElseIf pTblName = "Department01" Then
            Query.Append(" Select 'ALL' [ID], ")
            Query.Append(" '" & pPlaceHolder & "' [Name] ")
            Query.Append(" ,1 [Order01]  ")
            Query.Append(",'' [Order02]  ")
            Query.Append(" union select  ")
            Query.Append(" cast(dept_code As nvarchar(13)) [ID],   ")
            Query.Append(" Description [Name]  ")
            Query.Append(" ,2 [Order01]  ")
            Query.Append(" ,Description [Order02]  ")
            Query.Append(" From ")
            Query.Append(" department ")
            Query.Append(" Where ")
            Query.Append(" dept_code = '" & pID & "'  ")
            Query.Append(" union Select ")
            Query.Append(" cast(dept_code As nvarchar(13)) [ID]   ")
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
            Query.Append(" select '' [ID],  ")
            Query.Append(" '" & pPlaceHolder & "' [Name]  ")
            Query.Append(" ,1 [Order01] ")
            Query.Append(" ,'' [Order02] ")
            Query.Append(" union  ")
            Query.Append(" select cast(emp_no as nvarchar(13)) [ID],   ")
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

        ElseIf pTblName = "PreparedBy" Then
            Query.Append("    select '' [ID],  ")
            Query.Append("    '" & pPlaceHolder & "' [Name]    ")
            Query.Append("    ,1 [Order01]   ")
            Query.Append(",'' [Order02]   ")
            Query.Append("    union    ")
            Query.Append("    select cast(emp_no as nvarchar(13)) [ID],     ")
            Query.Append("    fullname [Name]    ")
            Query.Append("    ,3 [Order01]   ")
            Query.Append("    ,fullname [Order02]   ")
            Query.Append("    from   ")
            Query.Append("    employee    ")
            Query.Append("    WHERE (emp_no = '" & pID & "' OR Superior = 'MN2023050002') ")
            Query.Append("      And emp_status IN ('Contractual','Probationary','Regular') ")
            Query.Append("    UNION ")
            Query.Append("    Select 'MN2023050002' AS [ID], ")
            Query.Append("    'BANTANG, VIVIAN V.' AS [Name], ")
            Query.Append("    2 AS [Order01], ")
            Query.Append("    'BANTANG, VIVIAN V.' AS [Order02] ")
            Query.Append("    order by    ")
            Query.Append("    [Order01]  ")
            Query.Append("    ,[Order02]   ")



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

    Function Get_DeptCode()
        ' Build query
        Dim Query As New StringBuilder()
        Query.Append("SELECT distinct dept_code FROM department WHERE lock = '1' ")


        Dim RecordList As New List(Of Object)()
        ' Open connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .DeptCode = DR("dept_code")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using



        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function
    Function Access_01()
        ' Build query
        Dim Query As New StringBuilder()
        Query.Append("SELECT fullname FROM employee WHERE emp_no = @EmpCode")


        Dim RecordList As New List(Of Object)()
        ' Open connection
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.Parameters.AddWithValue("@EmpCode", CIIS_EmpCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()

                    RecordList.Add(New With {
                        .Empno = DR("fullname")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using



        'Creates an instance of your JavaScriptSerializer And Setting the MaxJsonLength
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        'display 
        Return (serializer.Serialize(RecordList))
        'display

    End Function



    Function Get_Record_01(pDeptCode)

        'query
        Dim Query As New StringBuilder
        Query.Append(" SELECT ")
        Query.Append(" A.F_Code, ")
        Query.Append(" B.RefNo, ")
        Query.Append(" D.DateStart AS DateReceive, ")
        Query.Append(" B.DocumentNo, ")
        Query.Append(" B.DocumentTitle, ")
        Query.Append(" B.DocumentType, ")
        Query.Append(" B.RevisionNo, ")
        Query.Append(" C.description, ")
        Query.Append(" B.DescriptionChange, ")
        Query.Append(" B.TargetDate, ")
        Query.Append(" DA.DateStart AS DateCompletionStart, ")
        Query.Append(" DA.DateEnd   AS DateCompletionEnd, ")
        Query.Append("	CASE ")
        Query.Append("	WHEN D.DateStart IS NULL THEN NULL ")
        Query.Append("	ELSE  ")
        Query.Append("	DATEDIFF(DAY, D.DateStart, ISNULL(DA.DateEnd, GETDATE()))  ")
        Query.Append("	- (DATEDIFF(WEEK, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) * 2) ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, D.DateStart) = 'Sunday' THEN 1 ELSE 0 END ")
        Query.Append("	- CASE WHEN DATENAME(WEEKDAY, ISNULL(DA.DateEnd, GETDATE())) = 'Saturday' THEN 1 ELSE 0 END ")
        Query.Append("	END AS TAT,")
        Query.Append(" CASE ")
        Query.Append(" WHEN A.status IN ('Cancelled', 'For Cancellation') THEN 'CANCELLED' ")
        Query.Append(" WHEN D.DateStart IS NULL THEN 'NO DATE' ")
        Query.Append(" WHEN A.status = 'Approved' or A.status ='New' ")
        Query.Append(" AND ( ")
        Query.Append(" DATEDIFF(DAY, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) ")
        Query.Append(" - (DATEDIFF(WEEK, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) * 2) ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, D.DateStart) = 'Sunday' THEN 1 ELSE 0 END ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, ISNULL(DA.DateEnd, GETDATE())) = 'Saturday' THEN 1 ELSE 0 END ")
        Query.Append(" ) <= 15 Then 'ONGOING' ")
        Query.Append(" WHEN ( ")
        Query.Append(" DATEDIFF(DAY, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) ")
        Query.Append(" - (DATEDIFF(WEEK, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) * 2) ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, D.DateStart) = 'Sunday' THEN 1 ELSE 0 END ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, ISNULL(DA.DateEnd, GETDATE())) = 'Saturday' THEN 1 ELSE 0 END ")
        Query.Append(") > 15 Then 'DELAYED' ")
        Query.Append(" Else 'ONTIME' ")
        Query.Append(" END AS Status ")
        Query.Append(" FROM oop_form_hdr A ")
        Query.Append(" LEFT JOIN Form_QMSDoc B ON A.tbl_code = B.QMSCode ")
        Query.Append(" LEFT JOIN department C ON B.OrigDepartment = C.dept_code ")
        Query.Append(" LEFT JOIN ( ")
        Query.Append("   SELECT f_code, MIN(DateStart) AS DateStart ")
        Query.Append("   FROM oop_form_dtl_appr ")
        Query.Append("   GROUP BY f_code ")
        Query.Append(" ) D ON A.f_code = D.f_code ")
        Query.Append(" LEFT JOIN oop_form_dtl_appr DA ")
        Query.Append("   On DA.f_code = A.f_code ")
        Query.Append("  And DA.Seq_no = ( ")
        Query.Append("     Select MAX(Seq_no) ")
        Query.Append("     FROM oop_form_dtl_appr ")
        Query.Append("     WHERE f_code = A.f_code ")
        Query.Append(" ) ")
        Query.Append(" WHERE tbl_from = 'Form_QMSdOC' and  b.OrigDepartment IN ( SELECT Data FROM split_string(@Dept_Code, ',')) ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.Parameters.AddWithValue("@Dept_Code", pDeptCode)
                Cmd.CommandType = CommandType.Text
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()


                    Dim statusValue = If(IsDBNull(DR("Status")), "", DR("Status").ToString())

                    Dim statusClass = If(statusValue = "DELAYED", "badge badge-lg badge-danger",
                        If(statusValue = "ONTIME", "badge badge-lg badge-success",
                        If(statusValue = "CANCELLED", "badge badge-lg badge-warning", "badge badge-lg badge-secondary")))


                    Dim Status As New StringBuilder
                    Status.Append("<div class='d-flex align-items-center'>")
                    Status.Append("<div class='d-flex flex-column'>")
                    Status.Append($"<span class='{statusClass}'>{statusValue}</span>")
                    Status.Append("</div></div>")

                    RecordList.Add(New With {
                        .rowId = DR("F_Code"),
                        .RefNo = If(IsDBNull(DR("RefNo")), Nothing, "<span title='" & DR("RefNo") & "'>" & DR("RefNo") & "</span>"),
                        .DateReceive = If(IsDBNull(DR("DateReceive")), Nothing, Convert.ToDateTime(DR("DateReceive")).ToString("MM/dd/yyyy")),
                        .DocumentNo = If(IsDBNull(DR("DocumentNo")), Nothing, "<span title='" & DR("DocumentNo") & "'>" & DR("DocumentNo") & "</span>"),
                        .DocumentTitle = If(IsDBNull(DR("DocumentTitle")), Nothing, "<span title='" & DR("DocumentTitle") & "'>" & DR("DocumentTitle") & "</span>"),
                        .DocumentType = If(IsDBNull(DR("DocumentType")), Nothing, "<span title='" & DR("DocumentType") & "'>" & DR("DocumentType") & "</span>"),
                        .RevisionNo = If(IsDBNull(DR("RevisionNo")), Nothing, "<span title='" & DR("RevisionNo") & "'>" & DR("RevisionNo") & "</span>"),
                        .Dept = If(IsDBNull(DR("description")), Nothing, "<span title='" & DR("description") & "'>" & DR("description") & "</span>"),
                        .DescriptionChange = If(IsDBNull(DR("DescriptionChange")), Nothing, "<span title='" & DR("DescriptionChange") & "'>" & DR("DescriptionChange") & "</span>"),
                        .TargetDate = If(IsDBNull(DR("TargetDate")), Nothing, Convert.ToDateTime(DR("TargetDate")).ToString("MM/dd/yyyy")),
                        .DateCompletionEnd = If(IsDBNull(DR("DateCompletionEnd")), Nothing, Convert.ToDateTime(DR("DateCompletionEnd")).ToString("MM/dd/yyyy")),
                        .Tat = If(IsDBNull(DR("TAT")), Nothing, "<span title='" & DR("TAT") & "'>" & DR("TAT") & "</span>"),
                        .Status = Status.ToString
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

    Function Get_Record_02(DeptCode)

        'query
        Dim Query As New StringBuilder
        Query.Append("  SELECT ")
        Query.Append("  COUNT(*) AS Total, ")
        Query.Append("  SUM(CASE WHEN TypeRequest = 'Document Creation' THEN 1 ELSE 0 END) AS Creation, ")
        Query.Append("  SUM(CASE WHEN TypeRequest = 'Document Revision' THEN 1 ELSE 0 END) AS Revision, ")
        Query.Append("  SUM(CASE WHEN TypeRequest = 'Document Obsoletion/Discontinuance' THEN 1 ELSE 0 END) AS Obsoletion, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Policy' AND TypeRequest = 'Document Creation' THEN 1 ELSE 0 END) AS CreationPolicy, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Policy' AND TypeRequest = 'Document Revision' THEN 1 ELSE 0 END) AS RevisionPolicy, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Policy' AND TypeRequest = 'Document Obsoletion/Discontinuance' THEN 1 ELSE 0 END) AS ObsoletionPolicy, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Guideline' AND TypeRequest = 'Document Creation' THEN 1 ELSE 0 END) AS CreationGuideline, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Guideline' AND TypeRequest = 'Document Revision' THEN 1 ELSE 0 END) AS RevisionGuideline, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Guideline' AND TypeRequest = 'Document Obsoletion/Discontinuance' THEN 1 ELSE 0 END) AS ObsoletionGuideline,  ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Procedure' AND TypeRequest = 'Document Creation' THEN 1 ELSE 0 END) AS CreationProcedure, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Procedure' AND TypeRequest = 'Document Revision' THEN 1 ELSE 0 END) AS RevisionProcedure, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Procedure' AND TypeRequest = 'Document Obsoletion/Discontinuance' THEN 1 ELSE 0 END) AS ObsoletionProcedure, ")
        Query.Append("      SUM(CASE WHEN DocumentType = 'Work Instruction' AND TypeRequest = 'Document Creation' THEN 1 ELSE 0 END) AS CreationWorkInstruction, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Work Instruction' AND TypeRequest = 'Document Revision' THEN 1 ELSE 0 END) AS RevisionWorkInstruction, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Work Instruction' AND TypeRequest = 'Document Obsoletion/Discontinuance' THEN 1 ELSE 0 END) AS ObsoletionWorkInstruction, ")
        Query.Append("      SUM(CASE WHEN DocumentType = 'Form' AND TypeRequest = 'Document Creation' THEN 1 ELSE 0 END) AS CreationForm, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Form' AND TypeRequest = 'Document Revision' THEN 1 ELSE 0 END) AS RevisionForm, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Form' AND TypeRequest = 'Document Obsoletion/Discontinuance' THEN 1 ELSE 0 END) AS ObsoletionForm, ")
        Query.Append("      SUM(CASE WHEN DocumentType = 'Manual' AND TypeRequest = 'Document Creation' THEN 1 ELSE 0 END) AS CreationManual, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Manual' AND TypeRequest = 'Document Revision' THEN 1 ELSE 0 END) AS RevisionManual, ")
        Query.Append("  SUM(CASE WHEN DocumentType = 'Manual' AND TypeRequest = 'Document Obsoletion/Discontinuance' THEN 1 ELSE 0 END) AS ObsoletionManual ")
        Query.Append("          From Form_QMSDoc ")
        Query.Append("  WHERE OrigDepartment IN (SELECT Data FROM split_string(@Dept_Code, ',')); ")


        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Dept_Code", DeptCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()


                    RecordList.Add(New With {
                     .Total = If(IsDBNull(DR("Total")), 0, Convert.ToInt32(DR("Total"))),
                     .Creation = If(IsDBNull(DR("Creation")), 0, Convert.ToInt32(DR("Creation"))),
                     .Revision = If(IsDBNull(DR("Revision")), 0, Convert.ToInt32(DR("Revision"))),
                     .Obsoletion = If(IsDBNull(DR("Obsoletion")), 0, Convert.ToInt32(DR("Obsoletion"))),
                    .CreationPolicy = If(IsDBNull(DR("CreationPolicy")), 0, Convert.ToInt32(DR("CreationPolicy"))),
                    .RevisionPolicy = If(IsDBNull(DR("RevisionPolicy")), 0, Convert.ToInt32(DR("RevisionPolicy"))),
                    .ObsoletionPolicy = If(IsDBNull(DR("ObsoletionPolicy")), 0, Convert.ToInt32(DR("ObsoletionPolicy"))),
                    .CreationGuideline = If(IsDBNull(DR("CreationGuideline")), 0, Convert.ToInt32(DR("CreationGuideline"))),
                    .RevisionGuideline = If(IsDBNull(DR("RevisionGuideline")), 0, Convert.ToInt32(DR("RevisionGuideline"))),
                    .ObsoletionGuideline = If(IsDBNull(DR("ObsoletionGuideline")), 0, Convert.ToInt32(DR("ObsoletionGuideline"))),
                    .CreationProcedure = If(IsDBNull(DR("CreationProcedure")), 0, Convert.ToInt32(DR("CreationProcedure"))),
                    .RevisionProcedure = If(IsDBNull(DR("RevisionProcedure")), 0, Convert.ToInt32(DR("RevisionProcedure"))),
                    .ObsoletionProcedure = If(IsDBNull(DR("ObsoletionProcedure")), 0, Convert.ToInt32(DR("ObsoletionProcedure"))),
                    .CreationWorkInstruction = If(IsDBNull(DR("CreationWorkInstruction")), 0, Convert.ToInt32(DR("CreationWorkInstruction"))),
                    .RevisionWorkInstruction = If(IsDBNull(DR("RevisionWorkInstruction")), 0, Convert.ToInt32(DR("RevisionWorkInstruction"))),
                    .ObsoletionWorkInstruction = If(IsDBNull(DR("ObsoletionWorkInstruction")), 0, Convert.ToInt32(DR("ObsoletionWorkInstruction"))),
                    .CreationForm = If(IsDBNull(DR("CreationForm")), 0, Convert.ToInt32(DR("CreationForm"))),
                    .RevisionForm = If(IsDBNull(DR("RevisionForm")), 0, Convert.ToInt32(DR("RevisionForm"))),
                    .ObsoletionForm = If(IsDBNull(DR("ObsoletionForm")), 0, Convert.ToInt32(DR("ObsoletionForm"))),
                    .CreationManual = If(IsDBNull(DR("CreationManual")), 0, Convert.ToInt32(DR("CreationManual"))),
                    .RevisionManual = If(IsDBNull(DR("RevisionManual")), 0, Convert.ToInt32(DR("RevisionManual"))),
                    .ObsoletionManual = If(IsDBNull(DR("ObsoletionManual")), 0, Convert.ToInt32(DR("ObsoletionManual")))
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

    Function Get_Record_03()

        'query
        Dim Query As New StringBuilder
        Query.Append(" SELECT ")
        Query.Append(" B.abbr, ")
        Query.Append(" COUNT(*) AS TotalCount ")
        Query.Append(" FROM  ")
        Query.Append(" Form_QMSDoc A ")
        Query.Append(" INNER JOIN  ")
        Query.Append(" department B  ")
        Query.Append(" ON A.OrigDepartment = B.dept_code ")
        Query.Append(" GROUP BY  ")
        Query.Append(" B.abbr ")
        Query.Append(" ORDER BY  ")
        Query.Append(" B.abbr ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()


                    RecordList.Add(New With {
                        .TotalCount = If(IsDBNull(DR("TotalCount")), 0, Convert.ToInt32(DR("TotalCount"))),
                        .description = If(IsDBNull(DR("abbr")), Nothing, DR("abbr"))
                    })


                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer()
        serializer.MaxJsonLength = 2146233079

        Return serializer.Serialize(RecordList)

    End Function
    Public Class StatusCount
        Public Property Accepted As Integer
        Public Property Approved As Integer
        Public Property Cancelled As Integer
        Public Property NewStat As Integer
    End Class
    Public Function Get_Record_04(pYear As String, pDeptCode As String)

        ' Prepare dictionary for months 1-12
        Dim months As New Dictionary(Of Integer, StatusCount)
        For i As Integer = 1 To 12
            months.Add(i, New StatusCount())
        Next

        Dim Query As New StringBuilder()
        Query.Append("
        SELECT
                h.status,
                h.created_date
            FROM oop_form_hdr h
            INNER JOIN Form_QMSDoc d
                ON h.tbl_code = d.QMSCode  
            WHERE h.tbl_from = 'Form_QMSdOC'
              AND YEAR(h.created_date) = @pYear
              AND d.OrigDepartment IN (
                    SELECT Data
                    FROM split_string(@Dept_Code, ',')
         );  ")

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.Parameters.AddWithValue("@pYear", pYear)
                Cmd.Parameters.AddWithValue("@Dept_Code", pDeptCode)
                ConStr.Open()

                Dim DR As SqlDataReader = Cmd.ExecuteReader()

                While DR.Read()

                    Dim st As String = DR("status").ToString().Trim()
                    Dim dt As DateTime = Convert.ToDateTime(DR("created_date"))
                    Dim m As Integer = dt.Month

                    Dim group = months(m)

                    Select Case st
                        Case "Accepted", "Pending"
                            group.Accepted += 1
                        Case "Approved", "Done"
                            group.Approved += 1
                        Case "Cancelled"
                            group.Cancelled += 1
                        Case "New"
                            group.NewStat += 1
                    End Select

                End While

                DR.Close()
                ConStr.Close()
            End Using
        End Using

        ' Build JSON result
        Dim result = New With {
        .Months = New String() {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"},
        .Accepted = months.Values.Select(Function(x) x.Accepted).ToArray(),
        .Approved = months.Values.Select(Function(x) x.Approved).ToArray(),
        .Cancelled = months.Values.Select(Function(x) x.Cancelled).ToArray(),
        .NewStat = months.Values.Select(Function(x) x.NewStat).ToArray()
    }

        Dim serializer As New JavaScriptSerializer()
        Return serializer.Serialize(result)

    End Function

    Function Get_Type_01(pLIST, pDeptCode)

        'query
        Dim Query As New StringBuilder
        Query.Append(" SELECT ")
        Query.Append(" A.F_Code, ")
        Query.Append(" B.RefNo, ")
        Query.Append(" D.DateStart AS DateReceive, ")
        Query.Append(" B.DocumentNo, ")
        Query.Append(" B.DocumentTitle, ")
        Query.Append(" B.DocumentType, ")
        Query.Append(" B.RevisionNo, ")
        Query.Append(" C.description, ")
        Query.Append(" B.DescriptionChange, ")
        Query.Append(" B.TargetDate, ")
        Query.Append(" DA.DateStart AS DateCompletionStart, ")
        Query.Append(" DA.DateEnd   AS DateCompletionEnd, ")
        Query.Append("	CASE ")
        Query.Append("	WHEN D.DateStart IS NULL THEN NULL ")
        Query.Append("	ELSE  ")
        Query.Append("	DATEDIFF(DAY, D.DateStart, ISNULL(DA.DateEnd, GETDATE()))  ")
        Query.Append("	- (DATEDIFF(WEEK, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) * 2) ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, D.DateStart) = 'Sunday' THEN 1 ELSE 0 END ")
        Query.Append("	- CASE WHEN DATENAME(WEEKDAY, ISNULL(DA.DateEnd, GETDATE())) = 'Saturday' THEN 1 ELSE 0 END ")
        Query.Append("	END AS TAT,")
        Query.Append(" CASE ")
        Query.Append(" WHEN A.status IN ('Cancelled', 'For Cancellation') THEN 'CANCELLED' ")
        Query.Append(" WHEN D.DateStart IS NULL THEN 'NO DATE' ")
        Query.Append(" WHEN A.status = 'Approved' or A.status ='New' ")
        Query.Append(" AND ( ")
        Query.Append(" DATEDIFF(DAY, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) ")
        Query.Append(" - (DATEDIFF(WEEK, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) * 2) ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, D.DateStart) = 'Sunday' THEN 1 ELSE 0 END ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, ISNULL(DA.DateEnd, GETDATE())) = 'Saturday' THEN 1 ELSE 0 END ")
        Query.Append(" ) <= 15 Then 'ONGOING' ")
        Query.Append(" WHEN ( ")
        Query.Append(" DATEDIFF(DAY, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) ")
        Query.Append(" - (DATEDIFF(WEEK, D.DateStart, ISNULL(DA.DateEnd, GETDATE())) * 2) ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, D.DateStart) = 'Sunday' THEN 1 ELSE 0 END ")
        Query.Append(" - CASE WHEN DATENAME(WEEKDAY, ISNULL(DA.DateEnd, GETDATE())) = 'Saturday' THEN 1 ELSE 0 END ")
        Query.Append(") > 15 Then 'DELAYED' ")
        Query.Append(" Else 'ONTIME' ")
        Query.Append(" END AS Status ")
        Query.Append(" FROM oop_form_hdr A ")
        Query.Append(" LEFT JOIN Form_QMSDoc B ON A.tbl_code = B.QMSCode ")
        Query.Append(" LEFT JOIN department C ON B.OrigDepartment = C.dept_code ")
        Query.Append(" LEFT JOIN ( ")
        Query.Append("   SELECT f_code, MIN(DateStart) AS DateStart ")
        Query.Append("   FROM oop_form_dtl_appr ")
        Query.Append("   GROUP BY f_code ")
        Query.Append(" ) D ON A.f_code = D.f_code ")
        Query.Append(" LEFT JOIN oop_form_dtl_appr DA ")
        Query.Append("   On DA.f_code = A.f_code ")
        Query.Append("  And DA.Seq_no = ( ")
        Query.Append("     Select MAX(Seq_no) ")
        Query.Append("     FROM oop_form_dtl_appr ")
        Query.Append("     WHERE f_code = A.f_code ")
        Query.Append(" ) ")
        Query.Append(" WHERE tbl_from = 'Form_QMSdOC' and b.TypeRequest LIKE '%' + @pLIST + '%'  ")
        Query.Append(" and  b.OrigDepartment IN ( SELECT Data FROM split_string(@Dept_Code, ',')) ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.Parameters.AddWithValue("@pLIST", pLIST)
                Cmd.Parameters.AddWithValue("@Dept_Code", pDeptCode)
                Cmd.CommandType = CommandType.Text
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()


                    Dim statusValue = If(IsDBNull(DR("Status")), "", DR("Status").ToString())

                    Dim statusClass = If(statusValue = "DELAYED", "badge badge-lg badge-danger",
                        If(statusValue = "ONTIME", "badge badge-lg badge-success",
                        If(statusValue = "CANCELLED", "badge badge-lg badge-warning", "badge badge-lg badge-secondary")))


                    Dim Status As New StringBuilder
                    Status.Append("<div class='d-flex align-items-center'>")
                    Status.Append("<div class='d-flex flex-column'>")
                    Status.Append($"<span class='{statusClass}'>{statusValue}</span>")
                    Status.Append("</div></div>")

                    RecordList.Add(New With {
                        .rowId = DR("F_Code"),
                        .RefNo = If(IsDBNull(DR("RefNo")), Nothing, "<span title='" & DR("RefNo") & "'>" & DR("RefNo") & "</span>"),
                        .DateReceive = If(IsDBNull(DR("DateReceive")), Nothing, Convert.ToDateTime(DR("DateReceive")).ToString("MM/dd/yyyy")),
                        .DocumentNo = If(IsDBNull(DR("DocumentNo")), Nothing, "<span title='" & DR("DocumentNo") & "'>" & DR("DocumentNo") & "</span>"),
                        .DocumentTitle = If(IsDBNull(DR("DocumentTitle")), Nothing, "<span title='" & DR("DocumentTitle") & "'>" & DR("DocumentTitle") & "</span>"),
                        .DocumentType = If(IsDBNull(DR("DocumentType")), Nothing, "<span title='" & DR("DocumentType") & "'>" & DR("DocumentType") & "</span>"),
                        .RevisionNo = If(IsDBNull(DR("RevisionNo")), Nothing, "<span title='" & DR("RevisionNo") & "'>" & DR("RevisionNo") & "</span>"),
                        .Dept = If(IsDBNull(DR("description")), Nothing, "<span title='" & DR("description") & "'>" & DR("description") & "</span>"),
                        .DescriptionChange = If(IsDBNull(DR("DescriptionChange")), Nothing, "<span title='" & DR("DescriptionChange") & "'>" & DR("DescriptionChange") & "</span>"),
                        .TargetDate = If(IsDBNull(DR("TargetDate")), Nothing, Convert.ToDateTime(DR("TargetDate")).ToString("MM/dd/yyyy")),
                        .DateCompletionEnd = If(IsDBNull(DR("DateCompletionEnd")), Nothing, Convert.ToDateTime(DR("DateCompletionEnd")).ToString("MM/dd/yyyy")),
                        .Tat = If(IsDBNull(DR("TAT")), Nothing, "<span title='" & DR("TAT") & "'>" & DR("TAT") & "</span>"),
                        .Status = Status.ToString
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