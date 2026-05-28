Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports System.Web.Services

Public Class HND0000041
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
        'user info
        CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        Try
            context.Response.ContentType = "text/plain"
            Dim FormCode = context.Request("FormCode")
            Dim IDSrs = Replace(context.Request("IDSrs"), "No", "#")

            If FormCode = "WRK010100" Then

                Dim IDs As String() = IDSrs.Split(New Char() {";"c})

                For Each ID As String In IDs
                    'create new folder
                    If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")) = False Then
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/"))
                    End If
                    'create new folder

                    Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")
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

                            Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/") & FileName
                            File.SaveAs(Path)
                        End If
                    Next
                Next

            End If

            If FormCode = "WRK010100" Then

                Dim IDs As String() = IDSrs.Split(New Char() {";"c})

                For Each ID As String In IDs

                    Dim FormCode01 As String = ID.Substring(0, 9)
                    Dim ID01 As String = ID.Substring(10, 13)

                    Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode01 & "/" & ID01 & "/")
                    Dim Files As String()
                    For Each s As String In context.Request.Files
                        Dim File As HttpPostedFile = context.Request.Files(s)
                        Dim FileSizeInBytes As Integer = File.ContentLength
                        Dim FileName As String = File.FileName
                        Dim FileExtension As String = System.IO.Path.GetExtension(FileName)
                        Files = System.IO.Directory.GetFiles(FilesPath)

                        FileName = Replace(FileName, FileExtension, "")
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

                        Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode01 & "/" & ID01 & "/") & FileName
                        File.SaveAs(Path)
                    Next
                Next

            End If

            If FormCode = "ENG010501" Then

                Dim IDs As String() = IDSrs.Split(New Char() {";"c})

                For Each ID As String In IDs
                    'create new folder
                    If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")) = False Then
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/"))
                    End If
                    'create new folder

                    Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/")
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

                            Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode & "/" & ID & "/") & FileName
                            File.SaveAs(Path)
                        End If
                    Next
                Next

            End If

            If FormCode = "FRM010000" Then

                Dim IDs As String() = IDSrs.Split(New Char() {";"c})

                For Each ID As String In IDs

                    Dim FormCode01 As String = ID.Substring(0, 9)
                    Dim ID01 As String = ID.Substring(10, 13)

                    'create new folder
                    If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode01 & "/" & ID01 & "/")) = False Then
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode01 & "/" & ID01 & "/"))
                    End If
                    'create new folder

                    'copy work order files
                    If FormCode01 = "FRM000001" And Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/WRK010100/" & ID01 & "/")) = False Then
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/WRK010100/" & ID01 & "/"))
                    End If
                    'copy work order files

                    Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode01 & "/" & ID01 & "/")
                    Dim Files As String()
                    For Each s As String In context.Request.Files
                        Dim File As HttpPostedFile = context.Request.Files(s)
                        Dim FileSizeInBytes As Integer = File.ContentLength
                        Dim FileName As String = File.FileName
                        Dim FileExtension As String = System.IO.Path.GetExtension(FileName)
                        Files = System.IO.Directory.GetFiles(FilesPath)

                        FileName = Replace(FileName, FileExtension, "")
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

                        Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/" & FormCode01 & "/" & ID01 & "/") & FileName
                        File.SaveAs(Path)

                        'create connection
                        Dim SqlConn As New SqlClient.SqlConnection
                        Dim SqlCmd As New SqlCommand
                        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
                        SqlCmd.CommandTimeout = 1500
                        SqlCmd.Connection = SqlConn
                        SqlCmd.CommandType = CommandType.StoredProcedure
                        SqlCmd.CommandText = "New_File"
                        SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode01)
                        SqlCmd.Parameters.AddWithValue("@pID", ID01)
                        SqlCmd.Parameters.AddWithValue("@pType", "Uploaded a file:")
                        SqlCmd.Parameters.AddWithValue("@pDescription", FileName)
                        SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)
                        'create connection

                        'execute procedure
                        SqlConn.Open()
                        SqlCmd.ExecuteNonQuery()
                        SqlConn.Close()
                        'execute procedure

                    Next
                Next

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

End Class