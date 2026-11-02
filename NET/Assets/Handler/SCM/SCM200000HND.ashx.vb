Imports System.ComponentModel.Design
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Pipes
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Net.PeerToPeer.Collaboration
Imports System.Reflection.Emit
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes
Imports System.Runtime.Remoting.Contexts
Imports System.Security.AccessControl
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Principal
Imports System.Web
Imports System.Web.ApplicationServices
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Windows.Forms
Imports System.Windows.Forms.LinkLabel
Imports System.Windows.Forms.VisualStyles
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft
Imports Microsoft.Ajax.Utilities
Imports Microsoft.AspNet.SignalR.Infrastructure
Imports Microsoft.Identity.Client
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports OfficeOpenXml.ConditionalFormatting.Contracts

Public Class SCM200000HND
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
            Dim pFunction = context.Request("pFunction")
            Dim pFormCode = context.Request("pFormCode")
            Dim pType = context.Request("pType")
            Dim json As String
            'general parameter

            If pFormCode = "SCM200000" And pType = "Get - Dropdown" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")
                json = Me.Get_Dropdown(pTblName, pPlaceHolder)

            End If

            If pFunction = "Upload - Attachment" Then

                Dim pCode = context.Request("pCode")

                If context.Request.Files.Count = 0 Then
                    context.Response.Write(New JavaScriptSerializer().Serialize(New With {
                    .status = "error",
                    .message = "No file uploaded"
                }))
                    Return
                End If

                Dim file As HttpPostedFile = context.Request.Files(0)
                Dim extension As String = Path.GetExtension(file.FileName).ToLower()
                Dim allowedExtensions As String() = {".pdf", ".jpg", ".jpeg", ".png"}

                If Not allowedExtensions.Contains(extension) Then
                    context.Response.Write(New JavaScriptSerializer().Serialize(New With {
                    .status = "error",
                    .message = "Invalid file type. Only PDF and images are allowed."
                }))
                    Return
                End If

                Dim uniqueFileName As String = Guid.NewGuid().ToString("N") & "_" & Path.GetFileName(file.FileName)

                Dim adminUploadDir As String = context.Server.MapPath("~/Assets/Upload/Chat/" & pCode & "/")
                If Not Directory.Exists(adminUploadDir) Then
                    Directory.CreateDirectory(adminUploadDir)
                End If
                Dim adminPhysicalPath As String = Path.Combine(adminUploadDir, uniqueFileName)

                'Dim contractorUploadDir As String = "C:\inetpub\ciis.net\Assets\Upload\Chat\" & pCode & "\"
                Dim contractorUploadDir As String = "C:\inetpub\testsite\Assets\Upload\Chat\" & pCode & "\"
                'Dim contractorUploadDir As String = "C:\Users\User\Desktop\.NET\Contractor Portal\NET v2.6\NET\NET\Assets\Upload\Chat\" & pCode & "\"
                If Not Directory.Exists(contractorUploadDir) Then
                    Directory.CreateDirectory(contractorUploadDir)
                End If
                Dim contractorPhysicalPath As String = Path.Combine(contractorUploadDir, uniqueFileName)

                file.SaveAs(adminPhysicalPath)
                System.IO.File.Copy(adminPhysicalPath, contractorPhysicalPath, True)

                Dim relativePath As String = "Assets/Upload/Chat/" & pCode & "/" & uniqueFileName

                context.Response.Write(New JavaScriptSerializer().Serialize(New With {
                .status = "success",
                .filePath = relativePath,
                .fileName = file.FileName,
                .fileType = If(extension = ".pdf", "pdf", "image")
            }))

            End If

            'general - context
            context.Response.ContentType = "application/json"
            context.Response.Write(json)
            'general - context

        Catch ex As Exception
            context.Response.Write("ERROR: " & ex.Message)
        End Try

    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#Region "Dropdown"
    Function Get_Dropdown(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "Get_Contractor" Then
            Query.Append("select ")
            Query.Append("   '' [ID] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Name] ")
            Query.Append("   ,0 [Order1] ")
            Query.Append("   ,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select distinct ")
            Query.Append("   [A].v_code [ID] ")
            Query.Append("   ,[A].vendor [Name] ")
            Query.Append("   ,2 [Order1] ")
            Query.Append("   ,[A].vendor [Order2] ")
            Query.Append("from ")
            Query.Append("   cldc_live_acc.dbo.ogm_vendor [A] ")
            Query.Append("where ")
            Query.Append("  ISNULL([A].lock, 0) = 1 ")
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
End Class