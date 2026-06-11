Imports System.Data.SqlClient

Public Class DSB090000
    Inherits System.Web.UI.Page

#Region "Page"

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_Deparment As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

    Protected Property dsUnit As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_Deparment = CIIS_UserInfo("CIIS_Department")

        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("DSB", "DSB080000")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'load
            bindBatch()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
            'load

        End If
        'load page
    End Sub

#End Region

#Region "Function"

    Function bindBatch()

        'get Assigned To
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   '' [Code] ")
        Query.Append("   ,'Select batch' [Name] ")
        Query.Append("   ,0 [Active] ")
        Query.Append("   ,0 [Order01] ")
        Query.Append("   ,'' [Order02] ")
        Query.Append("union ")
        Query.Append("select")
        Query.Append("   'All' [Code] ")
        Query.Append("   ,'All' [Name] ")
        Query.Append("   ,0 [Active] ")
        Query.Append("   ,1 [Order01] ")
        Query.Append("   ,'All' [Order02] ")
        Query.Append("union ")
        Query.Append("select ")
        Query.Append("   [A].BatchNo [Code] ")
        Query.Append("   ,[A].BatchNo [Name] ")
        Query.Append("   ,[A].Active ")
        Query.Append("   ,2 [Order01] ")
        Query.Append("   ,[A].BatchNo [Order02] ")
        Query.Append("from ")
        Query.Append("   calmardbLive.dbo.mstr_BatchNo [A] ")
        Query.Append("order by ")
        Query.Append("   [Order01] ")
        Query.Append("   ,[Order02] ")
        'get Assigned To

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlBatch.DataSource = DT
        ddlBatch.DataValueField = "Code"
        ddlBatch.DataTextField = "Name"
        ddlBatch.DataBind()
        'fill data

        'select last item
        Dim lastItem As ListItem = ddlBatch.Items(ddlBatch.Items.Count - 1)
        ddlBatch.SelectedValue = lastItem.Value
        'select last item

        'display
        upnlBreadcrumbbar.Update()
        'display

        bindUnit(lastItem.Value)

    End Function

    Function bindUnit(Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("   [A].HWCode [No] ")
        Query.Append("   ,[A].BatchNo [Batch] ")
        Query.Append("   ,[B].ProjInit [Subd] ")
        Query.Append("   ,[A].Phase ")
        Query.Append("   ,[A].Block ")
        Query.Append("   ,[A].Lot ")
        Query.Append("   ,[D].ModelName [House] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '011'),'-') [Target011] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '011'),'-') [Status011] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '011'),'-') [DateSecured011] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '002'),'-') [Target002] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '002'),'-') [Status002] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '002'),'-') [DateSecured002] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '014'),'-') [Target014] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '014'),'-') [Status014] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '014'),'-') [DateSecured014] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '008'),'-') [Target008] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '008'),'-') [Status008] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '008'),'-') [DateSecured008] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '012'),'-') [Target012] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '012'),'-') [Status012] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '012'),'-') [DateSecured012] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '001'),'-') [Target001] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '001'),'-') [Status001] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '001'),'-') [DateSecured001] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '003'),'-') [Target003] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '003'),'-') [Status003] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '003'),'-') [DateSecured003] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '013'),'-') [Target013] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '013'),'-') [Status013] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '013'),'-') [DateSecured013] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '005'),'-') [Target005] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '005'),'-') [Status005] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '005'),'-') [DateSecured005] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '009'),'-') [Target009] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '009'),'-') [Status009] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '009'),'-') [DateSecured009] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '006'),'-') [Target006] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '006'),'-') [Status006] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '006'),'-') [DateSecured006] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '007'),'-') [Target007] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '007'),'-') [Status007] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '007'),'-') [DateSecured007] ")
        Query.Append("   ,isnull((select top 1 format([F].DateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '010'),'-') [Target010] ")
        Query.Append("   ,isnull((select top 1 [F].Status from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '010'),'-') [Status010] ")
        Query.Append("   ,isnull((select top 1 format([F].ActDateEnd,'MM/dd/yy') from Form_HWTask [F] where [F].HWCode = [A].HWCode and [F].TaskCode = '010'),'-') [DateSecured010] ")
        Query.Append("from ")
        Query.Append("   Form_HWHdr [A] ")
        Query.Append("   left join calmardbLive.dbo.mstr_Projects [B] on [A].Subd = [B].ProjCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_BatchNo [C] on [A].BatchNo = [C].BatchNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_HouseModels [D] on [A].House = [D].ModelCode ")
        Query.Append("where ")
        If Batch = "All" Then Query.Append("   [A].BatchNo in (select [E].BatchNo from Form_HWHdr [E] ) ")
        If Batch <> "All" Then Query.Append("   [A].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [C].DateReleased ")
        Query.Append("   ,[B].ProjInit + ' ' + [A].Phase + ' B' + [A].Block + ' L' + [A].Lot ")
        'get query 

        'variable
        Dim dtUnit As DataTable = New DataTable()
        dtUnit.Columns.Add(New DataColumn("No"))
        dtUnit.Columns.Add(New DataColumn("Batch"))
        dtUnit.Columns.Add(New DataColumn("Subd"))
        dtUnit.Columns.Add(New DataColumn("Phase"))
        dtUnit.Columns.Add(New DataColumn("Block"))
        dtUnit.Columns.Add(New DataColumn("Lot"))
        dtUnit.Columns.Add(New DataColumn("House"))
        dtUnit.Columns.Add(New DataColumn("Target011"))
        dtUnit.Columns.Add(New DataColumn("Status011"))
        dtUnit.Columns.Add(New DataColumn("DateSecured011"))
        dtUnit.Columns.Add(New DataColumn("Target002"))
        dtUnit.Columns.Add(New DataColumn("Status002"))
        dtUnit.Columns.Add(New DataColumn("DateSecured002"))
        dtUnit.Columns.Add(New DataColumn("Target014"))
        dtUnit.Columns.Add(New DataColumn("Status014"))
        dtUnit.Columns.Add(New DataColumn("DateSecured014"))
        dtUnit.Columns.Add(New DataColumn("Target008"))
        dtUnit.Columns.Add(New DataColumn("Status008"))
        dtUnit.Columns.Add(New DataColumn("DateSecured008"))
        dtUnit.Columns.Add(New DataColumn("Target012"))
        dtUnit.Columns.Add(New DataColumn("Status012"))
        dtUnit.Columns.Add(New DataColumn("DateSecured012"))
        dtUnit.Columns.Add(New DataColumn("Target001"))
        dtUnit.Columns.Add(New DataColumn("Status001"))
        dtUnit.Columns.Add(New DataColumn("DateSecured001"))
        dtUnit.Columns.Add(New DataColumn("Target003"))
        dtUnit.Columns.Add(New DataColumn("Status003"))
        dtUnit.Columns.Add(New DataColumn("DateSecured003"))
        dtUnit.Columns.Add(New DataColumn("Target013"))
        dtUnit.Columns.Add(New DataColumn("Status013"))
        dtUnit.Columns.Add(New DataColumn("DateSecured013"))
        dtUnit.Columns.Add(New DataColumn("Target005"))
        dtUnit.Columns.Add(New DataColumn("Status005"))
        dtUnit.Columns.Add(New DataColumn("DateSecured005"))
        dtUnit.Columns.Add(New DataColumn("Target009"))
        dtUnit.Columns.Add(New DataColumn("Status009"))
        dtUnit.Columns.Add(New DataColumn("DateSecured009"))
        dtUnit.Columns.Add(New DataColumn("Target006"))
        dtUnit.Columns.Add(New DataColumn("Status006"))
        dtUnit.Columns.Add(New DataColumn("DateSecured006"))
        dtUnit.Columns.Add(New DataColumn("Target007"))
        dtUnit.Columns.Add(New DataColumn("Status007"))
        dtUnit.Columns.Add(New DataColumn("DateSecured007"))
        dtUnit.Columns.Add(New DataColumn("Target010"))
        dtUnit.Columns.Add(New DataColumn("Status010"))
        dtUnit.Columns.Add(New DataColumn("DateSecured010"))
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    'Dim ID As String = "<a href='" & DR("Link") & "'>" & DR("ID") & "</a>"
                    ''Dim Title As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px me-3'><img alt='' class='w-100' src='" & DR("Icon") & "' /></div>" & DR("Title") & "</div>"
                    'Dim Title As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(" & DR("Icon") & ")'></div></div>&nbsp" & DR("Title") & "</div>"
                    'Dim RequestedBy As String = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("RequestedByCode") & ".png)'></div></div>&nbsp" & DR("RequestedByName") & "</div>"

                    dtUnit.Rows.Add(DR("No"), DR("Batch"), DR("Subd"), DR("Phase"), DR("Block"), DR("Lot"), DR("House"), DR("Target011"), DR("Status011"), DR("DateSecured011"), DR("Target002"), DR("Status002"), DR("DateSecured002"), DR("Target014"), DR("Status014"), DR("DateSecured014"), DR("Target008"), DR("Status008"), DR("DateSecured008"), DR("Target012"), DR("Status012"), DR("DateSecured012"), DR("Target001"), DR("Status001"), DR("DateSecured001"), DR("Target003"), DR("Status003"), DR("DateSecured003"), DR("Target013"), DR("Status013"), DR("DateSecured013"), DR("Target005"), DR("Status005"), DR("DateSecured005"), DR("Target009"), DR("Status009"), DR("DateSecured009"), DR("Target006"), DR("Status006"), DR("DateSecured006"), DR("Target007"), DR("Status007"), DR("DateSecured007"), DR("Target010"), DR("Status010"), DR("DateSecured010"))

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        dsUnit = New DataSet()
        dsUnit.Tables.Add(dtUnit)

    End Function

#End Region

End Class