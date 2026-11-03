Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection.Emit
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Web.Services.Description
Imports System.Web.WebSockets
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices

Public Class HNDAPP
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
            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")
            'general parameter

            If FormCode = "APP010000" And Type = "Access" Then

                Dim Action = context.Request("Action")

                Dim json As String = Me.APP010000_Acess(Action)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "APP010000" And Type = "Approval Template - HDR" Then

                Dim FormType = context.Request("FormType")
                Dim Title = context.Request("Title")

                Dim json As String = Me.APP010000_Add_FormTitle(FormType, Title)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "APP010000" And Type = "Approval Template - Bind" Then

                Dim json As String = Me.APP010000_Bind_FormTitle()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "APP010000" And Type = "View Approver (Detail)" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.APP010000_View_Approver(Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)
            End If

            If FormCode = "APP010000" And Type = "Get Sequence" Then

                Dim Code = context.Request("Code")

                Dim json As String = Me.APP010000_Get_Sequence(Code)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If FormCode = "APP010000" And Type = "View Detail (Update)" Then

                Dim Code = context.Request("Code")
                Dim AppType = context.Request("AppType")
                Dim Emp = context.Request("Emp")
                Dim SeqNo = context.Request("SeqNo")

                Dim json As String = Me.APP010000_View_Detail(Code, AppType, Emp, SeqNo)
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

#Region "APP010000"
    Private Function APP010000_Acess(Action As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("declare @oConf nvarchar(60) ")
        Query.Append("declare @pUserId nvarchar(13) = (select user_id from duser where emp_no = '" & CIIS_EmpCode & "') ")
        Query.Append(" exec calmardbLive.dbo.JCF_ConfRestriction @pUserId, 'mtFA', '" & Action & "', @oConf output ")
        Query.Append(" select @oConf ")
        'get query

        'variable
        Dim Access As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Access.Add(New With {
                        .Status = DR.GetString(0)
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(Access))
        'display 

    End Function

    Private Function APP010000_Add_FormTitle(FormType As String, Title As String)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_FRM_ApproverPath"
        SqlCmd.Parameters.AddWithValue("@pFormCode", FormType)
        SqlCmd.Parameters.AddWithValue("@pTitle", Title)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'variable
        Dim Status As String = "Success"
        'variable

        'display 
        Return Status
        'display 

    End Function
    Private Function APP010000_Bind_FormTitle()

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Code ")
        Query.Append("  ,[A].FormCode ")
        Query.Append("  ,[A].Title ")
        Query.Append("  ,dbo.ProperCase([B].Fullname) [CreatedBy] ")
        Query.Append("  ,[A].CreatedBy [EmpNo] ")
        Query.Append("  ,Format([A].CreatedDate, 'MM/dd/yyyy') [CreatedDate] ")
        Query.Append("  ,(select distinct top 1 dbo.Get_Icon(tbl_from) from oop_form_hdr where dbo.Get_Link(tbl_from) = [A].FormCode) [Icon] ")
        Query.Append("from ")
        Query.Append("  Mstr_AppPathTempHdr [A] ")
        Query.Append("  left join employee [B] on [A].CreatedBy = [B].emp_no ")
        'get query

        'variable
        Dim ApproverList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Link As String = "<a onclick=""viewApprover('" & DR("Code") & "', '" & DR("Title") & "');"" class='text-primary pointer' >" & DR("Code") & "</a>"
                    Dim Title As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>"
                    Dim Icon As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("EmpNo") & ".png)'></div></div>&nbsp" & DR("CreatedBy") & "</div>"
                    ApproverList.Add(New With {
                        .col00 = Link.ToString(),
                        .col01 = DR("FormCode"),
                        .col02 = Title.ToString(),
                        .col03 = DR("CreatedDate"),
                        .col04 = Icon.ToString()
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ApproverList))
        'display 

    End Function
    Private Function APP010000_View_Approver(Code As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  [A].Type ")
        Query.Append("  ,(case when dbo.ProperCase([B].fullname) = '' or dbo.ProperCase([B].fullname) is null then [A].Approver else dbo.ProperCase([B].fullname) end) [Approver] ")
        Query.Append("  ,[A].SeqNo ")
        Query.Append("  ,[A].NoDays ")
        Query.Append("  ,[A].Project [Project] ")
        Query.Append("  ,(case when [A].Project = '' or [A].Project IS NULL then '' else LEN([A].Project) - LEN(replace([A].Project, ',', '')) + 1 end) [Count] ")
        Query.Append("  ,[A].Code ")
        Query.Append("  ,[A].Approver [EmpCode] ")
        Query.Append("from ")
        Query.Append("  Mstr_AppPathTempDtl [A] ")
        Query.Append("  left join employee [B] on [A].Approver = [B].emp_no ")
        Query.Append("where ")
        Query.Append("  [A].Code = '" & Code & "' ")
        Query.Append("  order by ")
        Query.Append("      [SeqNo] ")
        'get query

        'variable
        Dim ApproverList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim Button As String = "<div class='d-flex justify-content-center align-items-center'>
                                                <button class='btn btn-sm btn-icon btn-active-success mr-5' data-bs-toggle='tooltip' title='Remove approver' onclick=""btn01DelApprover('" & DR("EmpCode") & "', '" & DR("Code") & "', '" & DR("SeqNo") & "', '" & DR("Type") & "', '" & DR("Project") & "'); return false;""><i class='las la-trash fs-3'></i></button>
                                                <Button Class='btn btn-sm btn-icon btn-active-success mr-5' data-bs-toggle='tooltip' title='Update approver' onclick=""btn01UpdApprover('" & DR("EmpCode") & "', '" & DR("Code") & "', '" & DR("SeqNo") & "', '" & DR("Type") & "', '" & DR("Project") & "'); return false;""><i class='las la-pencil-alt fs-3'></i></button>
                                            </div>"
                    Dim Icon As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("EmpCode") & ".png)'></div></div>&nbsp" & DR("Approver") & "</div>"
                    ApproverList.Add(New With {
                        .col00 = Button.ToString(),
                        .col01 = DR("Type"),
                        .col02 = Icon.ToString(),
                        .col03 = DR("SeqNo"),
                        .col04 = Format(DR("NoDays"), "N2"),
                        .col05 = DR("Project"),
                        .col06 = DR("Code"),
                        .col07 = DR("EmpCode"),
                        .col08 = DR("Count")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(ApproverList))
        'display 

    End Function
    Private Function APP010000_Get_Sequence(Code As String)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append(" * ")
        Query.Append("from ")
        Query.Append("(select top 1 ")
        Query.Append("  SeqNo + 1 [Seq] ")
        Query.Append("from ")
        Query.Append("  Mstr_AppPathTempDtl ")
        Query.Append("where ")
        Query.Append("  Code = '" & Code & "' ")
        Query.Append("order by ")
        Query.Append("  SeqNo DESC) [TBL] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("  1 [Seq] ")
        Query.Append("where not exists ( ")
        Query.Append("  select 1 from Mstr_AppPathTempDtl where Code = '" & Code & "' ")
        Query.Append(") ")
        'get query

        'variable
        Dim GetSeq As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    GetSeq.Add(New With {
                        .Seq = DR("Seq")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(GetSeq))
        'display 

    End Function
    Private Function APP010000_View_Detail(Code As String, Type As String, Emp As String, SeqNo As Integer)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  Type ")
        Query.Append("  ,SeqNo ")
        Query.Append("  ,Approver ")
        Query.Append("  ,NoDays ")
        Query.Append("  ,Project ")
        Query.Append("  ,(case when Project = '' or Project is null then 0 else LEN(Project) - LEN(REPLACE(Project, ',', '')) + 1 end) [Count] ")
        Query.Append("from ")
        Query.Append("  Mstr_AppPathTempDtl ")
        Query.Append("where ")
        Query.Append("  Code = '" & Code & "' ")
        Query.Append("  and Approver = '" & Emp & "' ")
        Query.Append("  and Type = '" & Type & "' ")
        Query.Append("  and SeqNo = '" & SeqNo & "' ")
        'get query

        'variable
        Dim GetDetail As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    GetDetail.Add(New With {
                        .Type = DR("Type"),
                        .SeqNo = DR("SeqNo"),
                        .Approver = DR("Approver"),
                        .Days = Format(DR("NoDays"), "N2"),
                        .Project = DR("Project"),
                        .Count = DR("Count")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(GetDetail))
        'display 

    End Function
#End Region

End Class