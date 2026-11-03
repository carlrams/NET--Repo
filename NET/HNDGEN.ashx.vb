Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities
Imports Microsoft.AspNet.SignalR

Public Class HNDGEN
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

#Region "Form"

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim pType = context.Request("pType")
            'general parameter

            If pType = "If Exist" Then

                Dim pTblName = context.Request("pTblName")
                Dim pClmName = context.Request("pClmName")
                Dim pTblCode = context.Request("pTblCode")

                Dim json As String = Me.IfExist(pTblName, pClmName, pTblCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Restriction" Then

                Dim pUserId = CIIS_EmpCode
                Dim pFormCode = context.Request("pFormCode")
                Dim pRes = context.Request("pRes")
                Dim json As String = Me.Conf_Restriction(pUserId, pFormCode, pRes)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Validate - Record" Then

                Dim pTblName = context.Request("pTblName")
                Dim pTblCode = context.Request("pTblCode")
                Dim pTblVal = context.Request("pTblVal")
                Dim pAction = context.Request("pAction")

                Dim json As String = Me.Conf_Record(pTblName, pTblCode, pTblVal, pAction)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Validate - Password" Then

                Dim pEmpCode = CIIS_EmpCode
                Dim pPassword = context.Request("pPassword")

                Dim json As String = Me.Conf_Password(pEmpCode, pPassword)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Delete" Then

                Dim pFormCode = context.Request("pFormCode")
                Dim pTblName = context.Request("pTblName")
                Dim pTblCode = context.Request("pTblCode")
                Dim pRemovedBy = CIIS_EmpCode

                Dim json As String = Me.Del_Record(pFormCode, pTblName, pTblCode, pRemovedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Lock" Then

                Dim pTblName = context.Request("pTblName")
                Dim pTblCode = context.Request("pTblCode")
                Dim pLockBy = CIIS_EmpCode
                Dim pLock = 1

                Dim json As String = Me.Lock_Record(pTblName, pTblCode, pLockBy, pLock)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Unlock" Then

                Dim pTblName = context.Request("pTblName")
                Dim pTblCode = context.Request("pTblCode")
                Dim pLockBy = CIIS_EmpCode
                Dim pLock = 0

                Dim json As String = Me.Lock_Record(pTblName, pTblCode, pLockBy, pLock)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Upload" Then

                context.Response.ContentType = "text/plain"
                Dim pFormCode = context.Request("pFormCode")
                Dim pID = context.Request("pID")
                Dim pCreatedBy = CIIS_EmpCode

                Upload_Add(pFormCode, pID, pCreatedBy, context)

            ElseIf pType = "Upload - Get Record" Then

                Dim pFormCode = context.Request("pFormCode")
                Dim pID = context.Request("pID")

                Dim json As String = Me.Upload_Get_Record(pFormCode, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Upload - Download" Then

                Dim pFormCode = context.Request("pFormCode")
                Dim pID = context.Request("pID")
                Dim pFileName = context.Request("pFileName")
                Dim pDownloadedBy = CIIS_EmpCode

                Dim json As String = Me.Upload_Download(pFormCode, pID, pFileName, pDownloadedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Upload - Delete" Then

                Dim pFormCode = context.Request("pFormCode")
                Dim pID = context.Request("pID")
                Dim pFileName = context.Request("pFileName")
                Dim pRemovedBy = CIIS_EmpCode

                Dim json As String = Me.Upload_Delete(pFormCode, pID, pFileName, pRemovedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Notes - Get Record" Then

                Dim pFormCode = context.Request("pFormCode")
                Dim pID = context.Request("pID")

                Dim json As String = Me.Note_Get_Record(pFormCode, pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Notes - Add" Then

                Dim pFormCode = context.Request("pFormCode")
                Dim pID = context.Request("pID")
                Dim pNotes = context.Request("pNotes")
                Dim pMention = context.Request("pMention")

                Dim json As String = Me.Note_Add(pFormCode, pID, pNotes, pMention)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Mode" Then

                Dim pEmpCode = CIIS_EmpCode

                Dim json As String = Me.Upd_Mode(pEmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pType = "Bind Mode" Then

                Dim pEmpCode = CIIS_EmpCode

                Dim json As String = Me.Bind_Mode(pEmpCode)
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

#Region "Restriction"

    Function Conf_Restriction(pUserId, pFormCode, pRes)

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
        SqlCmd.CommandText = "Conf_Restriction"
        SqlCmd.Parameters.AddWithValue("@pUserId", pUserId)
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pRes", pRes)
        Dim oConf As New SqlClient.SqlParameter("@oConf", SqlDbType.NVarChar, 1000)
        oConf.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oConf)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = oConf.Value.ToString})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

#End Region

#Region "Validate - Record"

    Function Conf_Record(pTblName, pTblCode, pTblVal, pAction)

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
        SqlCmd.CommandText = "Conf_Record"
        SqlCmd.Parameters.AddWithValue("@pTblName", pTblName)
        SqlCmd.Parameters.AddWithValue("@pTblCode", pTblCode)
        SqlCmd.Parameters.AddWithValue("@pTblVal", pTblVal)
        SqlCmd.Parameters.AddWithValue("@pType", pAction)
        Dim oAns As New SqlClient.SqlParameter("@oAns", SqlDbType.NVarChar, 1000)
        oAns.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oAns)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = oAns.Value.ToString})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

#End Region

#Region "Validate - Password"

    Function Conf_Password(pEmpCode, pPassword)

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
        SqlCmd.CommandText = "Conf_Password"
        SqlCmd.Parameters.AddWithValue("@pEmpCode", pEmpCode)
        SqlCmd.Parameters.AddWithValue("@pPassword", pPassword)
        Dim oMsg As New SqlClient.SqlParameter("@oMsg", SqlDbType.NVarChar, 1000)
        oMsg.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oMsg)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = oMsg.Value.ToString})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

#End Region

#Region "Delete"

    Function Del_Record(pFormCode, pTblName, pTblCode, pRemovedBy)

        'remove notifications
        Del_Notifications(pFormCode, pTblCode)
        'remove notifications

        'remove notes
        Del_Notes(pFormCode, pTblCode)
        'remove notes

        'remove file within the folder
        Dim UploadFile As DirectoryInfo = New DirectoryInfo(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & pFormCode & "/" & pTblCode & "/"))
        Try
            Dim File As FileInfo
            For Each File In UploadFile.GetFiles()
                Upload_Delete(pFormCode, pTblCode, File.Name, pRemovedBy)
            Next
        Catch ex As Exception
            'do nothing
        End Try
        'remove file within the folder

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
        SqlCmd.CommandText = "Del_Record"
        SqlCmd.Parameters.AddWithValue("@pTblName", pTblName)
        SqlCmd.Parameters.AddWithValue("@pTblCode", pTblCode)
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

    Function Del_Notes(pFormCode, pID)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.Text
        SqlCmd.CommandText = "delete from Mstr_Remarks where FormCode = '" & pFormCode & "' and ID = '" & pID & "' "
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

    End Function

    Function Del_Notifications(pFormCode, pID)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.Text
        SqlCmd.CommandText = "delete from Mstr_Notification where TblName = '" & pFormCode & "' and TblCode = '" & pID & "' "
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

    End Function

#End Region

#Region "Lock"

    Function Lock_Record(pTblName, pTblCode, pLockBy, pLock)

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
        SqlCmd.CommandText = "Lock_Record"
        SqlCmd.Parameters.AddWithValue("@pTblName", pTblName)
        SqlCmd.Parameters.AddWithValue("@pTblCode", pTblCode)
        SqlCmd.Parameters.AddWithValue("@pLockBy", pLockBy)
        SqlCmd.Parameters.AddWithValue("@pLock", pLock)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = "Success"})
        'add value

        'trigger
        Dim hub = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)()
        hub.Clients.All.updatePurchaseOrder()
        'trigger

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

#End Region

#Region "Upload"

    Function Upload_Get_Record(pFormCode, pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT ")
        Query.Append("   [A].FileName ")
        Query.Append("   ,dbo.ProperCase([B].first_name) [UploadedBy] ")
        Query.Append("   ,format([A].UploadedDate,'MM/dd/yyyy hh:mm tt') [UploadedDate] ")
        Query.Append("FROM ")
        Query.Append("   Mstr_Attachment [A] ")
        Query.Append("   left join employee [B] on [A].UploadedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].FormCode = '" & pFormCode & "' ")
        Query.Append("   and [A].ID = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("   [A].UploadedDate ")
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

                    'create variable
                    Dim Icon As String
                    'create variable

                    'set icon for specific file
                    If DR("FileName").Contains(".png") Or DR("FileName").Contains(".PNG") Then
                        Icon = "<i class='las la-file-image text-purple fs-1' title='Image'></i>"
                    ElseIf DR("FileName").Contains(".jpg") Or DR("FileName").Contains(".jpeg") Or DR("FileName").Contains(".jpe") Or DR("FileName").Contains(".jfif") Or DR("FileName").Contains(".JPG") Or DR("FileName").Contains(".JPEG") Or DR("FileName").Contains(".JPE") Or DR("FileName").Contains(".JFIF") Then
                        Icon = "<i class='las la-file-image text-purple fs-1' title='Image'></i>"
                    ElseIf DR("FileName").Contains(".txt") Or DR("FileName").Contains(".TXT") Then
                        Icon = "<i class='las la-file-alt text-muted fs-1' title='Text'></i>"
                    ElseIf DR("FileName").Contains(".xlsx") Or DR("FileName").Contains(".xls") Or DR("FileName").Contains(".XLSX") Or DR("FileName").Contains(".XLS") Then
                        Icon = "<i class='las la-file-excel text-primary fs-1' title='Excel'></i>"
                    ElseIf DR("FileName").Contains(".docx") Or DR("FileName").Contains(".doc") Or DR("FileName").Contains(".DOCX") Or DR("FileName").Contains(".DOC") Then
                        Icon = "<i class='las la-file-word text-info fs-1' title='Word'></i>"
                    ElseIf DR("FileName").Contains(".pptx") Or DR("FileName").Contains(".ppt") Or DR("FileName").Contains(".PPTX") Or DR("FileName").Contains(".PPT") Then
                        Icon = "<i class='las la-file-powerpoint text-warning fs-1' title='Powerpoint'></i>"
                    ElseIf DR("FileName").Contains(".pdf") Or DR("FileName").Contains(".PDF") Then
                        Icon = "<i class='las la-file-pdf text-danger fs-1' title='PDF'></i>"
                    End If
                    'set icon for specific file


                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='Download' onclick=""fn0201Download('" & pFormCode & "','" & pID & "','" & DR("FileName") & "');return false;""><i class='las la-download fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0201Delete('" & pFormCode & "','" & pID & "','" & DR("FileName") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .Action = Action.ToString,
                        .Type = Icon,
                        .Attachment = DR("FileName"),
                        .UploadedBy = DR("UploadedBy"),
                        .UploadedDate = DR("UploadedDate")
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

    Function Upload_Add(ByVal pFormCode As String, ByVal pID As String, ByVal pCreatedBy As String, ByVal context As HttpContext)
        'create new folder
        If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & pFormCode & "/" & pID & "/")) = False Then
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & pFormCode & "/" & pID & "/"))
        End If
        'create new folder

        Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & pFormCode & "/" & pID & "/")
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
                FileName = Replace(FileName, "&", "")

                Dim counter As Integer = 0
                Dim newFileName As String = FileName & FileExtension
                newFileName = Replace(newFileName, ".png.png", ".png")
                newFileName = Replace(newFileName, ".jpg.jpg", ".jpg")
                newFileName = Replace(newFileName, ".jpeg.jpeg", ".jpeg")
                newFileName = Replace(newFileName, ".jpe.jpe", ".jpe")
                newFileName = Replace(newFileName, ".xlsx.xlsx", ".xlsx")
                newFileName = Replace(newFileName, ".docx.docx", ".docx")
                newFileName = Replace(newFileName, ".pdf.pdf", ".pdf")
                newFileName = Replace(newFileName, ".PNG.PNG", ".PNG")
                newFileName = Replace(newFileName, ".JPG.JPG", ".JPG")
                newFileName = Replace(newFileName, ".JPE.JPE", ".JPE")
                newFileName = Replace(newFileName, ".XLSX.XLSX", ".XLSX")
                newFileName = Replace(newFileName, ".XLS.XLS", ".XLS")
                newFileName = Replace(newFileName, ".DOCX.DOCX", ".DOCX")
                newFileName = Replace(newFileName, ".DOC.DOC", ".DOC")
                newFileName = Replace(newFileName, ".PDF.DOC", ".PDF")
                While System.IO.File.Exists(FilesPath & newFileName)
                    counter = counter + 1
                    newFileName = FileName & "(" & counter.ToString & ")" & FileExtension
                End While
                newFileName = Replace(newFileName, ".png.png", ".png")
                newFileName = Replace(newFileName, ".jpg.jpg", ".jpg")
                newFileName = Replace(newFileName, ".jpeg.jpeg", ".jpeg")
                newFileName = Replace(newFileName, ".jpe.jpe", ".jpe")
                newFileName = Replace(newFileName, ".xlsx.xlsx", ".xlsx")
                newFileName = Replace(newFileName, ".docx.docx", ".docx")
                newFileName = Replace(newFileName, ".pdf.pdf", ".pdf")
                newFileName = Replace(newFileName, ".PNG.PNG", ".PNG")
                newFileName = Replace(newFileName, ".JPG.JPG", ".JPG")
                newFileName = Replace(newFileName, ".JPE.JPE", ".JPE")
                newFileName = Replace(newFileName, ".XLSX.XLSX", ".XLSX")
                newFileName = Replace(newFileName, ".XLS.XLS", ".XLS")
                newFileName = Replace(newFileName, ".DOCX.DOCX", ".DOCX")
                newFileName = Replace(newFileName, ".DOC.DOC", ".DOC")
                newFileName = Replace(newFileName, ".PDF.DOC", ".PDF")
                FileName = newFileName
                Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & pFormCode & "/" & pID & "/") & FileName
                File.SaveAs(Path)

                'create connection
                Dim SqlConn01 As New SqlClient.SqlConnection
                Dim SqlCmd01 As New SqlCommand
                SqlConn01.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                SqlCmd01.CommandTimeout = 1500
                SqlCmd01.Connection = SqlConn01
                SqlCmd01.CommandType = CommandType.StoredProcedure
                SqlCmd01.CommandText = "New_File"
                SqlCmd01.Parameters.AddWithValue("@pFormCode", pFormCode)
                SqlCmd01.Parameters.AddWithValue("@pID", pID)
                SqlCmd01.Parameters.AddWithValue("@pType", "Uploaded a file:")
                SqlCmd01.Parameters.AddWithValue("@pDescription", FileName)
                SqlCmd01.Parameters.AddWithValue("@pCreatedBy", pCreatedBy)
                'create connection

                'execute procedure
                SqlConn01.Open()
                SqlCmd01.ExecuteNonQuery()
                SqlConn01.Close()
                'execute procedure

            End If
        Next

    End Function

    Function Upload_Download(pFormCode, pID, pFileName, pDownloadedBy)

        'create new folder
        If Not Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/View/" & pDownloadedBy & "/")) Then
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/View/" & pDownloadedBy & "/"))
        End If
        'create new folder

        'remove file
        Dim DirectoryPath As DirectoryInfo = New DirectoryInfo(HttpContext.Current.Server.MapPath("~/Assets/View/" & CIIS_EmpCode & "/"))
        Dim Files As FileInfo
        For Each Files In DirectoryPath.GetFiles()
            Files.Delete()
        Next
        'remove file

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Download_File"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pType", "Downloaded a file:")
        SqlCmd.Parameters.AddWithValue("@pDescription", pFileName)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pDownloadedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'transfer file
        File.Copy(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & pFormCode & "/" & pID & "/") & pFileName, HttpContext.Current.Server.MapPath("~/Assets/View/" & pDownloadedBy & "/") & pFileName, True)
        'transfer file

        'view/download
        Dim View As String = EncryptionHelper.EncryptString("~/Assets/View/" & CIIS_EmpCode & "/" & pFileName)
        'view/download

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        RecordList.Add(New With {
            .View = View
        })

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

    Function Upload_Delete(pFormCode, pID, pFileName, pRemovedBy)

        'remove file
        Dim FilePath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & pFormCode & "/" & pID & "/") & pFileName
        File.Delete(FilePath)
        'remove file

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Del_File"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pType", "Removed a file:")
        SqlCmd.Parameters.AddWithValue("@pDescription", pFileName)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pRemovedBy)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        RecordList.Add(New With {
            .oReturn = "Attachment successfully remove."
        })

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

#End Region

#Region "Notes"

    Function Note_Get_Record(pFormCode, pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("	[A].CreatedBy [Avatar] ")
        Query.Append("	,dbo.ProperCase([B].first_name) + ' ' + dbo.ProperCase([B].last_name) [By] ")
        Query.Append("	,Format([A].CreatedDate,'MM/dd/yyyy hh:mm tt') [Date] ")
        Query.Append("	,[A].Remarks ")
        Query.Append("from ")
        Query.Append("	 Mstr_Remarks [A] ")
        Query.Append("   left join employee [B] on [A].CreatedBy = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].FormCode = '" & pFormCode & "' ")
        Query.Append("   and [A].ID = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("  [A].SeqNo ")
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

                    Dim Icon As String
                    If File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR("Avatar") & ".png")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Avatar") & ".png"
                    ElseIf File.Exists(HttpContext.Current.Server.MapPath("~/Assets/media/avatars/" & DR("Avatar") & ".jpg")) = True Then
                        Icon = "Assets/media/avatars/" & DR("Avatar") & ".jpg"
                    Else
                        Icon = "Assets/media/avatars/blank.png"
                    End If

                    Dim Notes As New StringBuilder
                    Notes.Append("<div class='d-flex align-items-center mb-5'> ")
                    Notes.Append("   <div class='symbol symbol-30px overflow-hidden me-3'> ")
                    Notes.Append("      <div class='symbol-label'> ")
                    Notes.Append("         <img alt='' class='w-100' src='" & Icon & "' /> ")
                    Notes.Append("      </div> ")
                    Notes.Append("   </div> ")
                    Notes.Append("   <div class='d-flex flex-column'> ")
                    Notes.Append("      <span class='fw-bold text-dark'>" & DR("By") & "</span> ")
                    Notes.Append("      <span class='text-muted'>" & DR("Date") & "</span> ")
                    Notes.Append("   </div> ")
                    Notes.Append("</div> ")
                    Notes.Append("<p class='text-dark'>" & DR("Remarks") & "</p> ")

                    RecordList.Add(New With {
                        .Notes = Notes.ToString
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

    Function Note_Add(pFormCode, pID, pNotes, pMention)

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "New_Remarks"
        SqlCmd.Parameters.AddWithValue("@pFormCode", pFormCode)
        SqlCmd.Parameters.AddWithValue("@pID", pID)
        SqlCmd.Parameters.AddWithValue("@pSubID", "")
        SqlCmd.Parameters.AddWithValue("@pRemarks", pNotes)
        SqlCmd.Parameters.AddWithValue("@pMention", pMention)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        RecordList.Add(New With {
            .oReturn = "Note successfully saved."
        })

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function

#End Region

#Region "IfExist"

    Function IfExist(pTblName, pClmName, pTblCode)

        'query
        Dim Query As New StringBuilder
        Query.Append("if '" & pTblCode & "' in (select " & pClmName & " from " & pTblName & " where " & pClmName & " = '" & pTblCode & "') ")
        Query.Append("begin")
        Query.Append("   select '1' [Message] ")
        Query.Append("end ")
        Query.Append("else ")
        Query.Append("begin ")
        Query.Append("   select '0' [Message] ")
        Query.Append("end ")
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
                        .oReturn = DR("Message")
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

#Region "Mode"
    Function Upd_Mode(pEmpCode)

        'update
        Dim Query As New StringBuilder
        Query.Append("if not exists (select 1 from Mstr_UserSettings where EmpCode = '" & pEmpCode & "') ")
        Query.Append("begin ")
        Query.Append("  INSERT INTO Mstr_UserSettings ")
        Query.Append("      (EmpCode ")
        Query.Append("      ,Category ")
        Query.Append("      ,Mode ")
        Query.Append("      ,CreatedBy ")
        Query.Append("      ,CreatedDate) ")
        Query.Append("  VALUES ")
        Query.Append("      ('" & pEmpCode & "' ")
        Query.Append("      ,'Screen Size' ")
        Query.Append("      ,'container-fluid' ")
        Query.Append("      ,'" & pEmpCode & "' ")
        Query.Append("      ,GETDATE()) ")
        Query.Append("end ")
        Query.Append("else if exists (select 1 from Mstr_UserSettings where EmpCode = '" & pEmpCode & "') and (select Mode from Mstr_UserSettings where EmpCode = '" & pEmpCode & "') = 'container-fluid' ")
        Query.Append("begin ")
        Query.Append("  UPDATE Mstr_UserSettings SET ")
        Query.Append("      Mode = 'container-xxl' ")
        Query.Append("      ,UpdatedBy = '" & pEmpCode & "' ")
        Query.Append("      ,UpdatedDate = GETDATE() ")
        Query.Append("  WHERE ")
        Query.Append("      EmpCode = '" & pEmpCode & "' ")
        Query.Append("end ")
        Query.Append("else if exists (select 1 from Mstr_UserSettings where EmpCode = '" & pEmpCode & "') and (select Mode from Mstr_UserSettings where EmpCode = '" & pEmpCode & "') = 'container-xxl' ")
        Query.Append("begin ")
        Query.Append("  UPDATE Mstr_UserSettings SET ")
        Query.Append("      Mode = 'container-fluid' ")
        Query.Append("      ,UpdatedBy = '" & pEmpCode & "' ")
        Query.Append("      ,UpdatedDate = GETDATE() ")
        Query.Append("  WHERE ")
        Query.Append("      EmpCode = '" & pEmpCode & "' ")
        Query.Append("end ")
        Query.Append("select isnull(Mode, '') [Mode] from Mstr_UserSettings where EmpCode = '" & pEmpCode & "' ")
        'update

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
                        .Mode = DR("Mode")
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
    Function Bind_Mode(pEmpCode)

        Dim Query As New StringBuilder()
        Query.AppendLine("SELECT ISNULL(Mode, '') AS [Mode] ")
        Query.AppendLine("FROM Mstr_UserSettings ")
        Query.AppendLine("WHERE EmpCode = '" & pEmpCode & "'")

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
                        .Mode = DR("Mode")
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