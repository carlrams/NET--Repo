Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.Web
Imports Microsoft.ReportingServices.ReportProcessing.ReportObjectModel
Imports Microsoft.VisualBasic.ApplicationServices
Imports WebGrease.Activities

Public Class MNU020300
    Inherits System.Web.UI.Page

    'cookiesl
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    Dim No As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        Try
            CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            ID = HttpUtility.UrlDecode(Request.QueryString("ID"))
            No = HttpUtility.UrlDecode(Request.QueryString("No"))
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'load page
        If IsPostBack = False Then

            'get file
            Dim Query As New StringBuilder
            Query.Append("select ")
            Query.Append("  [A].POCode ")
            Query.Append("  ,[A].SeqNo ")
            Query.Append("  ,[A].FileName ")
            Query.Append("  ,[A].Attachment ")
            Query.Append("from ")
            Query.Append("  Trxn_PODtl_Attachment [A] ")
            Query.Append("where ")
            Query.Append("  [A].POCode = '" & ID & "' ")
            Query.Append("  and [A].SeqNo = " & No & " ")
            'get file

            'read record
            Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                Using Cmd As New SqlCommand(Query.ToString)
                    Cmd.CommandType = CommandType.Text
                    Cmd.Connection = ConStr
                    ConStr.Open()
                    Dim DR As SqlDataReader = Cmd.ExecuteReader
                    While DR.Read()
                        Dim SqlBytes As System.Data.SqlTypes.SqlBytes = DR.GetSqlBytes(DR.GetOrdinal("Attachment"))
                        Dim FileBytes() As Byte = SqlBytes.Value
                        Dim FileName As String = DR("FileName").ToString()
                        Dim Extension As String = DR("FileName").ToString().ToLower()

                        If Extension.EndsWith(".png") Or Extension.EndsWith(".jpg") Or Extension.EndsWith(".jpeg") Or Extension.EndsWith(".jfif") Then
                            Dim base64 As String = Convert.ToBase64String(FileBytes)
                            Dim mime As String = If(Extension.EndsWith(".png"), "image/png", "image/jpeg")
                            ltEmbed.Text = $"<img src='data:{mime};base64,{base64}' style='max-width:100%; max-height:100%; height:auto;' />"
                        ElseIf Extension.EndsWith(".pdf") Then
                            Dim base64 As String = Convert.ToBase64String(FileBytes)
                            ltEmbed.Text = $"<object data='data:application/pdf;base64,{base64}' type='application/pdf' width='100%' height='800px'>Your browser does not support PDF preview.</object>"
                        Else
                            Response.Clear()
                            Response.ContentType = "application/octet-stream"
                            Response.AddHeader("Content-Disposition", "attachment; filename=" & FileName)
                            Response.BinaryWrite(FileBytes)
                            Response.End()
                        End If

                    End While
                    DR.Close()
                    ConStr.Close()
                End Using
            End Using
            'read record

        End If
        'load page
    End Sub

End Class