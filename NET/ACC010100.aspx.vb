Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports Microsoft.Ajax.Utilities

Public Class ACC010100
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            CIIS_FirstName = CIIS_UserInfo("CIIS_FirstName")
            CIIS_LastName = CIIS_UserInfo("CIIS_LastName")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "ACC010100")
        'active account / menu

        'Record
        ltrlFormCode.Text = "ACC010100"
        'Record

        'load page
        If IsPostBack = False Then

            'Record
            ltrlID.Text = CIIS_EmpCode
            'Record

            'display record
            bindInfo()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function

#End Region

#Region "Profile"

    Function bindInfo()

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   addr_1 [Address] ")
        Query.Append("   ,prov_code [Province] ")
        Query.Append("   ,town_code [Town] ")
        Query.Append("   ,isnull(email2,'-') [Email] ")
        Query.Append("   ,isnull(tel_no,'-') [TelNo] ")
        Query.Append("   ,isnull(mobile_no,'-') [MobileNo1] ")
        Query.Append("   ,isnull(mobile_no2,'-') [MobileNo2] ")
        Query.Append("   ,isnull(mobile_no3,'-') [MobileNo3] ")
        Query.Append("   ,isnull(cpn,'-') [ConName] ")
        Query.Append("   ,isnull(cpa,'-') [ConAddress] ")
        Query.Append("   ,isnull(cpt,'-') [ConTelNo] ")
        Query.Append("   ,isnull(cpc,'-') [ConMobile] ")
        Query.Append("from ")
        Query.Append("   employee ")
        Query.Append("where ")
        Query.Append("   emp_no = '" & CIIS_EmpCode & "' ")
        'get total task

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim urlAvatar As String
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & CIIS_EmpCode & ".png")) = True Then
                        urlAvatar = "url(assets/media/avatars/" & CIIS_EmpCode & ".png)"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & CIIS_EmpCode & ".jpg")) = True Then
                        urlAvatar = "url(assets/media/avatars/" & CIIS_EmpCode & ".jpg)"
                    Else
                        urlAvatar = "Assets/media/avatars/blank.png"
                    End If
                    divAvatar.Style.Add("background-image", urlAvatar)
                    tbxAddress.Text = DR("Address")
                    bindProvince()
                    ddlProvince.SelectedValue = DR("Province")
                    bindTown(DR("Province"))
                    ddlTown.SelectedValue = DR("Town")
                    tbxEmail.Text = DR("Email")
                    tbxTelNo.Text = DR("TelNo")
                    tbxMobileNo1.Text = DR("MobileNo1")
                    tbxMobileNo2.Text = DR("MobileNo2")
                    tbxMobileNo3.Text = DR("MobileNo3")
                    tbxConName.Text = DR("ConName")
                    tbxConAddress.Text = DR("ConAddress")
                    tbxConTelNo.Text = DR("ConTelNo")
                    tbxConMobileNo.Text = DR("ConMobile")
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

    End Function

    Function bindProvince()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select province' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [prov_code] [Value] ")
        Query.Append("	 ,[mdesc] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 [province] ")
        Query.Append("where ")
        Query.Append("   lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlProvince.DataSource = DT
        ddlProvince.DataValueField = "Value"
        ddlProvince.DataTextField = "Text"
        ddlProvince.DataBind()
        'fill data

    End Function

    Function bindTown(Province As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   '' [Value] ")
        Query.Append("   ,'Select province' [Text] ")
        Query.Append("	 ,0 [Order] ")
        Query.Append("union ")
        Query.Append("select  ")
        Query.Append("   [town_code] [Value] ")
        Query.Append("	 ,[mdesc] [Text] ")
        Query.Append("	 ,1 [Order] ")
        Query.Append("from ")
        Query.Append("	 [town] ")
        Query.Append("where ")
        Query.Append("   prov_code = '" & Province & "' ")
        Query.Append("   and lock = 1 ")
        Query.Append("order by ")
        Query.Append("   [Order] ")
        Query.Append("   ,[Text] ")
        'get approver 

        'execute query
        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        'fill data
        ddlTown.DataSource = DT
        ddlTown.DataValueField = "Value"
        ddlTown.DataTextField = "Text"
        ddlTown.DataBind()
        'fill data

    End Function

    Private Sub ddlProvince_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProvince.SelectedIndexChanged
        bindTown(ddlProvince.SelectedValue)
        upnlProfile.Update()
    End Sub

    Protected Sub lbtnSave_Click(ByVal sender As Object, e As EventArgs)

        If tbxAddress.Text = "" Or ddlProvince.SelectedValue = "" Or ddlTown.SelectedValue = "" Then
            Alert("error", "Some fields are missing!")
            Exit Sub
        End If

        'Save the File.
        If FileUpload1.HasFile Then
            'delete frile
            If File.Exists(Server.MapPath("~/Assets/media/avatars/" & CIIS_EmpCode & ".png")) = True Then
                'delete frile
                Dim ExistingFile As String = Server.MapPath("~/Assets/media/avatars/" & CIIS_EmpCode & ".png")
                File.Delete(ExistingFile)
            End If
            'save file
            Dim FilePath As String = Server.MapPath("~/Assets/media/avatars/") + CIIS_EmpCode & ".png"
            FileUpload1.SaveAs(FilePath)
        End If

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update employee set ")
        Query.Append("   addr_1 = '" & tbxAddress.Text & "' ")
        Query.Append("   ,prov_code = '" & ddlProvince.SelectedValue & "' ")
        Query.Append("   ,town_code = '" & ddlTown.SelectedValue & "' ")
        Query.Append("   ,email2 = '" & tbxEmail.Text & "' ")
        Query.Append("   ,tel_no = '" & tbxTelNo.Text & "' ")
        Query.Append("   ,mobile_no = '" & tbxMobileNo1.Text & "' ")
        Query.Append("   ,mobile_no2 = '" & tbxMobileNo2.Text & "' ")
        Query.Append("   ,mobile_no3 = '" & tbxMobileNo3.Text & "' ")
        Query.Append("   ,cpn = '" & tbxConName.Text & "' ")
        Query.Append("   ,cpa = '" & tbxConAddress.Text & "' ")
        Query.Append("   ,cpt = '" & tbxConTelNo.Text & "' ")
        Query.Append("   ,cpc = '" & tbxConMobileNo.Text & "' ")
        Query.Append("where ")
        Query.Append("   emp_no = '" & CIIS_EmpCode & "' ")
        'get total task

        Dim SqlCon As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
        Dim SqlCmd As New SqlCommand
        SqlCmd.CommandText = Query.ToString
        SqlCmd.CommandType = CommandType.Text
        SqlCmd.Connection = SqlCon

        SqlCon.Open()
        SqlCmd.ExecuteScalar()
        SqlCon.Close()

        Master.bindAccount()

        Alert("success", "Record successfully saved!")

    End Sub

#End Region

End Class