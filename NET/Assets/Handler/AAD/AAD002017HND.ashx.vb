Imports System.Net
Imports System.Security.Cryptography
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes
Imports Microsoft.Ajax.Utilities
Imports System.Net.Mail
Imports OfficeOpenXml.Drawing.Slicer.Style
Imports Newtonsoft.Json

Public Class AAD002017HND
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.10"
    Dim catalog As String = "calmardblive"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    'connection

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            CIIS_UserInfo = context.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            Dim pFunction = context.Request("pFunction")

            If pFunction = "Get-Record-02" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.Get_Record_02(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Update-Record-02" Then

                Dim pAcctNo = context.Request("pAcctNo")
                Dim pDocumentList = context.Request("pDocumentList")

                Dim json As String = Me.Update_Record_02(pAcctNo, pDocumentList)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFunction = "Delete-Record-02" Then

                Dim pCode = context.Request("pCode")

                Dim json As String = Me.Delete_Record_02(pCode)
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

    Function Get_Record_02(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT       ")
        Query.Append("	AcctNo ")
        Query.Append("	,Code ")
        Query.Append("	,Rcvd   ")
        Query.Append("	,Type ")
        Query.Append("	,ReqDesc ")
        Query.Append("	,DocNo ")
        Query.Append("	,DocDate ")
        Query.Append("	,ExpDate ")
        Query.Append("	,ReceivedBy ")
        Query.Append("	,ReceivedDate ")
        Query.Append("	,Remarks ")
        Query.Append("	,UpdatedBy ")
        Query.Append("	,UpdatedDate ")
        Query.Append("FROM             ")
        Query.Append("	calmardbLive.dbo.JCF_AcctOthReq ")
        Query.Append("WHERE         ")
        Query.Append("	AcctNo = @AcctNo ")
        Query.Append("ORDER BY  ")
        Query.Append("	Type ")
        Query.Append("	,Code ")
        'query

        'variable
        Dim RecordList As New List(Of Object)()
        Dim rowIndex As Integer = 0
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString, ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@AcctNo", pID)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader()
                While DR.Read()


                    Dim no_chk As String = "<div class='form-check form-check-sm form-check-custom form-check-solid' " &
                       " style='display: flex; justify-content: center; align-items: center; padding-right: 3px; margin-right: 3px;'>" &
                       "<input type='checkbox' class='form-check-input checkBoxAllClass chkSelect row-checkbox' style='pointer-events: none' " &
                       " data-row='" & rowIndex & "'" &
                       If(DR("Rcvd").ToString().Trim() = "1", " checked", "") & " />" &
                       "</div>"

                    RecordList.Add(New With {
                        .Rcvd = no_chk,
                        .rowId = "rowID02" & DR("AcctNo"),
                        .AcctNo = "<span title='" & DR("AcctNo") & "'>" & DR("AcctNo") & "</span>",
                        .Code = "<span title='" & DR("Code") & "'>" & DR("Code") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .ReqDesc = "<span title='" & DR("ReqDesc") & "'>" & DR("ReqDesc") & "</span>",
                        .DocNo = "<span title='" & DR("DocNo") & "'>" & DR("DocNo") & "</span>",
                        .DocDate = If(IsDBNull(DR("DocDate")), "", "<span title='" & Convert.ToDateTime(DR("DocDate")).ToString("MM/dd/yyyy") & "'>" & Convert.ToDateTime(DR("DocDate")).ToString("MM/dd/yyyy") & "</span>"),
                        .ExpDate = If(IsDBNull(DR("ExpDate")), "", "<span title='" & Convert.ToDateTime(DR("ExpDate")).ToString("MM/dd/yyyy") & "'>" & Convert.ToDateTime(DR("ExpDate")).ToString("MM/dd/yyyy") & "</span>"),
                        .Remarks = "<span title='" & DR("Remarks") & "'>" & DR("Remarks") & "</span>",
                        .ReceivedBy = "<span title='" & DR("ReceivedBy") & "'>" & DR("ReceivedBy") & "</span>",
                        .ReceivedDate = "<span title='" & DR("ReceivedDate") & "'>" & DR("ReceivedDate") & "</span>",
                        .UpdatedBy = "<span title='" & DR("UpdatedBy") & "'>" & DR("UpdatedBy") & "</span>",
                        .UpdatedDate = "<span title='" & DR("UpdatedDate") & "'>" & DR("UpdatedDate") & "</span>"
                    })
                    rowIndex += 1
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
    Public Function Update_Record_02(pAcctNo As String, pDocumentList As String) As String
        Dim DocuList As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(pDocumentList)

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            ConStr.Open()
            Try
                For Each Item In DocuList
                    If Item.ContainsKey("isNew") AndAlso Convert.ToBoolean(Item("isNew")) Then
                        ' 🔹 INSERT for new rows
                        Dim Query As New StringBuilder()
                        Query.Append("DECLARE @Code nvarchar(13); ")
                        Query.Append("EXEC calmardblive.dbo.JCF_NewCode 'JCF_AcctOthReq', @Code OUTPUT; ")
                        Query.Append("INSERT INTO calmardblive.dbo.JCF_AcctOthReq ")
                        Query.Append("	(AcctNo, Code, Rcvd, Type,  ")
                        Query.Append("	ReqDesc, DocNo, DocDate,  ")
                        Query.Append("	ExpDate, ReceivedBy, ReceivedDate,  ")
                        Query.Append("	Remarks, UpdatedBy, UpdatedDate) ")
                        Query.Append("VALUES         ")
                        Query.Append("	(@AcctNo,@Code,@Rcvd,@Type, ")
                        Query.Append("	@ReqDesc,@DocNo,@DocDate, ")
                        Query.Append("	@ExpDate,@ReceivedBy,@ReceivedDate, ")
                        Query.Append("	@Remarks,@UpdatedBy,GETDATE()) ")

                        Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                            Cmd.Parameters.AddWithValue("@AcctNo", pAcctNo)
                            Cmd.Parameters.AddWithValue("@Rcvd", Item("checked"))
                            Cmd.Parameters.AddWithValue("@Type", Item("col1"))
                            Cmd.Parameters.AddWithValue("@ReqDesc", Item("col2"))
                            Cmd.Parameters.AddWithValue("@DocNo", Item("col3"))
                            If String.IsNullOrWhiteSpace(Convert.ToString(Item("col4"))) Then
                                Cmd.Parameters.AddWithValue("@DocDate", DBNull.Value)
                            Else
                                Cmd.Parameters.AddWithValue("@DocDate", Item("col4"))
                            End If
                            If String.IsNullOrWhiteSpace(Convert.ToString(Item("col5"))) Then
                                Cmd.Parameters.AddWithValue("@ExpDate", DBNull.Value)
                            Else
                                Cmd.Parameters.AddWithValue("@ExpDate", Item("col5"))
                            End If
                            Cmd.Parameters.AddWithValue("@ReceivedBy", Item("col6"))
                            If String.IsNullOrWhiteSpace(Convert.ToString(Item("col7"))) Then
                                Cmd.Parameters.AddWithValue("@ReceivedDate", DBNull.Value)
                            Else
                                Cmd.Parameters.AddWithValue("@ReceivedDate", Item("col7"))
                            End If
                            Cmd.Parameters.AddWithValue("@Remarks", Item("col8"))
                            Cmd.Parameters.AddWithValue("@UpdatedBy", CIIS_EmpCode)
                            Cmd.ExecuteNonQuery()
                        End Using

                    Else
                        Dim Query As New StringBuilder()
                        Query.Append("UPDATE       ")
                        Query.Append("	calmardblive.dbo.JCF_AcctOthReq ")
                        Query.Append("SET              ")
                        Query.Append("	Rcvd = @Rcvd,  ")
                        Query.Append("	Type = @Type,  ")
                        Query.Append("	ReqDesc = @ReqDesc,  ")
                        Query.Append("	DocNo = @DocNo,  ")
                        Query.Append("	DocDate = @DocDate,  ")
                        Query.Append("	ExpDate = @ExpDate,  ")
                        Query.Append("	ReceivedBy = @ReceivedBy,  ")
                        Query.Append("	ReceivedDate = @ReceivedDate,  ")
                        Query.Append("	Remarks = @Remarks,  ")
                        Query.Append("	UpdatedBy = @UpdatedBy,  ")
                        Query.Append("	UpdatedDate = GETDATE() ")
                        Query.Append("WHERE         ")
                        Query.Append("	(Code = @Original_Code) ")

                        Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                            Cmd.Parameters.AddWithValue("@Rcvd", Item("checked"))
                            Cmd.Parameters.AddWithValue("@Type", Item("col1"))
                            Cmd.Parameters.AddWithValue("@ReqDesc", Item("col2"))
                            Cmd.Parameters.AddWithValue("@DocNo", Item("col3"))
                            If String.IsNullOrWhiteSpace(Convert.ToString(Item("col4"))) Then
                                Cmd.Parameters.AddWithValue("@DocDate", DBNull.Value)
                            Else
                                Cmd.Parameters.AddWithValue("@DocDate", Item("col4"))
                            End If
                            If String.IsNullOrWhiteSpace(Convert.ToString(Item("col5"))) Then
                                Cmd.Parameters.AddWithValue("@ExpDate", DBNull.Value)
                            Else
                                Cmd.Parameters.AddWithValue("@ExpDate", Item("col5"))
                            End If
                            Cmd.Parameters.AddWithValue("@ReceivedBy", Item("col6"))
                            If String.IsNullOrWhiteSpace(Convert.ToString(Item("col7"))) Then
                                Cmd.Parameters.AddWithValue("@ReceivedDate", DBNull.Value)
                            Else
                                Cmd.Parameters.AddWithValue("@ReceivedDate", Item("col7"))
                            End If
                            Cmd.Parameters.AddWithValue("@Remarks", Item("col8"))
                            Cmd.Parameters.AddWithValue("@Original_Code", Item("code")) ' <- make sure JS sends "code"
                            Cmd.Parameters.AddWithValue("@UpdatedBy", CIIS_EmpCode)
                            Cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next

                Return JsonConvert.SerializeObject(New With {.status = "Success"})

            Catch ex As Exception
                Return "Failed: " & ex.Message
            End Try
        End Using
    End Function

    Function Delete_Record_02(pCode)
        'query
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Dim Query As New StringBuilder()
            Query.Append("DELETE FROM calmardblive.dbo.JCF_AcctOthReq WHERE Code = @Code")

            Using Cmd As New SqlCommand(Query.ToString(), ConStr)
                Cmd.CommandType = CommandType.Text
                Cmd.Parameters.AddWithValue("@Code", pCode)

                ConStr.Open()
                Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()
                ConStr.Close()

                If rowsAffected > 0 Then
                    Return JsonConvert.SerializeObject(New With {.status = "Success"})
                Else
                    Return JsonConvert.SerializeObject(New With {.status = "NotFound"})
                End If
            End Using
        End Using
    End Function

End Class