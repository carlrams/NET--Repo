Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic.ApplicationServices

Public Class HNDPMD
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

        'general parameter
        Dim FormCode = context.Request("FormCode")
        Dim Type = context.Request("Type")
        'general parameter


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


    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property


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


End Class