Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization

Public Class HND000005
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "iis"
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        'user info
        CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        Try
            context.Response.ContentType = "text/plain"

            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")

            If FormCode = "AAD010200" And Type = "Downloadables Upload" Then

                'create new folder
                If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\") = False Then
                    Directory.CreateDirectory("C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\")
                End If
                'create new folder

                Dim FilesPath As String = "C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\"
                Dim Files As String()
                For Each s As String In context.Request.Files
                    Dim File As HttpPostedFile = context.Request.Files(s)
                    Dim FileSizeInBytes As Integer = File.ContentLength
                    Dim FileName As String = File.FileName
                    Dim FileExtension As String = File.ContentType
                    If Not String.IsNullOrEmpty(FileName) Then
                        FileExtension = System.IO.Path.GetExtension(FileName)
                        Files = System.IO.Directory.GetFiles(FilesPath)

                        FileName = Replace(FileName, "@", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "^", "")
                        FileName = Replace(FileName, "`", "")
                        FileName = Replace(FileName, "|", "")
                        FileName = Replace(FileName, "~", "")
                        FileName = Replace(FileName, "\", "")
                        FileName = Replace(FileName, "/", "")
                        FileName = Replace(FileName, "!", "")
                        FileName = Replace(FileName, "#", "")
                        FileName = Replace(FileName, "$", "")
                        FileName = Replace(FileName, "%", "")
                        FileName = Replace(FileName, "&", "")
                        FileName = Replace(FileName, "*", "")
                        FileName = Replace(FileName, "(", "")
                        FileName = Replace(FileName, ")", "")
                        FileName = Replace(FileName, "+", "")
                        FileName = Replace(FileName, "=", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "]", "")
                        FileName = Replace(FileName, "{", "")
                        FileName = Replace(FileName, "}", "")
                        FileName = Replace(FileName, "'", "")
                        FileName = Replace(FileName, "<", "")
                        FileName = Replace(FileName, ">", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, "?", "")
                        FileName = Replace(FileName, ":", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, "ñ", "n")
                        FileName = Replace(FileName, "Ñ", "N")

                        Dim Path As String = "C:\inetpub\ciis.net\Assets\Upload\Buyers\Downloadables\" & FileName
                        File.SaveAs(Path)

                    End If
                Next

            ElseIf FormCode = "AAD010100" And Type = "Documentary Upload" Then

                'get input value
                Dim InputValueAcctNo As String = context.Request("InputValueAcctNo")
                'get input value

                'create new folder
                If Directory.Exists("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & InputValueAcctNo & "\Documentary\") = False Then
                    Directory.CreateDirectory("C:\inetpub\ciis.net\Assets\Upload\Buyers\" & InputValueAcctNo & "\Documentary\")
                End If
                'create new folder

                Dim FilesPath As String = "C:\inetpub\ciis.net\Assets\Upload\Buyers\" & InputValueAcctNo & "\Documentary\"
                Dim Files As String()
                For Each s As String In context.Request.Files
                    Dim File As HttpPostedFile = context.Request.Files(s)
                    Dim FileSizeInBytes As Integer = File.ContentLength
                    Dim FileName As String = File.FileName
                    Dim FileExtension As String = File.ContentType
                    If Not String.IsNullOrEmpty(FileName) Then
                        FileExtension = System.IO.Path.GetExtension(FileName)
                        Files = System.IO.Directory.GetFiles(FilesPath)

                        FileName = Replace(FileName, "@", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "^", "")
                        FileName = Replace(FileName, "`", "")
                        FileName = Replace(FileName, "|", "")
                        FileName = Replace(FileName, "~", "")
                        FileName = Replace(FileName, "\", "")
                        FileName = Replace(FileName, "/", "")
                        FileName = Replace(FileName, "!", "")
                        FileName = Replace(FileName, "#", "")
                        FileName = Replace(FileName, "$", "")
                        FileName = Replace(FileName, "%", "")
                        FileName = Replace(FileName, "&", "")
                        FileName = Replace(FileName, "*", "")
                        FileName = Replace(FileName, "(", "")
                        FileName = Replace(FileName, ")", "")
                        FileName = Replace(FileName, "+", "")
                        FileName = Replace(FileName, "=", "")
                        FileName = Replace(FileName, "[", "")
                        FileName = Replace(FileName, "]", "")
                        FileName = Replace(FileName, "{", "")
                        FileName = Replace(FileName, "}", "")
                        FileName = Replace(FileName, "'", "")
                        FileName = Replace(FileName, "<", "")
                        FileName = Replace(FileName, ">", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, ",", "")
                        FileName = Replace(FileName, "?", "")
                        FileName = Replace(FileName, ":", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, ";", "")
                        FileName = Replace(FileName, "ñ", "n")
                        FileName = Replace(FileName, "Ñ", "N")

                        Dim Path As String = "C:\inetpub\ciis.net\Assets\Upload\Buyers\" & InputValueAcctNo & "\Documentary\" & FileName
                        File.SaveAs(Path)

                    End If
                Next

            ElseIf FormCode = "AAD010000" And Type = "UserPerProject" Then

                Dim Project = context.Request("Project")

                Dim json As String = Me.Get_User_Per_Project(Project)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "AAD010300" And Type = "GetCategory" Then

                Dim Category = context.Request("Category")

                Dim json As String = Me.Get_Category(Category)
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

#Region "Function"

    Function Get_User_Per_Project(Project)

        'get
        Dim Query As New StringBuilder

        Query.Append("select ")
        Query.Append("    [A].AcctNo ")
        Query.Append("   ,[A].Fullname ")
        Query.Append("   ,[B].ProjName ")
        Query.Append("   ,[A].CreatedDate ")
        Query.Append("from ")
        Query.Append("   bp_user [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [B] on [A].project = [B].ProjInit ")
        Query.Append("where ")
        Query.Append("   [A].Project in ('" & Project & "') ")
        Query.Append("order by ")
        Query.Append("   [A].CreatedDate Desc ")
        'get

        'variable
        Dim UserList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    UserList.Add(New With {
                        .Acct = DR("AcctNo"),
                        .Name = DR("Fullname"),
                        .Project = DR("ProjName"),
                        .Date = Format(DR("CreatedDate"), "MM/dd/yyyy")
                    })

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display 
        Return (New JavaScriptSerializer().Serialize(UserList))
        'display 

    End Function

    Private Function Get_Category(Value)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select category' [Text] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("    Category [Value] ")
        Query.Append("    ,Category [Text] ")
        Query.Append("from ")
        Query.Append("   Mstr_InqTrx_Category ")
        Query.Append("where ")
        Query.Append("   Type = '" & Value & "' ")
        Query.Append("order by ")
        Query.Append("   [Value] ")
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

End Class