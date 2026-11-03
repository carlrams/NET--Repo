Imports System.Data.SqlClient

Public Class ACC010300
    Inherits System.Web.UI.Page

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim CIIS_FirstName As String
    Dim CIIS_LastName As String
    'cookies

    'connection
    Dim DataSource As String = ""
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

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
        Master.setActiveMenu("APP", "ACC010300")
        'active account / menu

        'load page
        If IsPostBack = False Then

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
        Query.Append("   (select Value from Parm_Account where EmpCode = '" & CIIS_EmpCode & "' and Type = '001001') [001001] ")
        Query.Append("   ,(select Value from Parm_Account where EmpCode = '" & CIIS_EmpCode & "' and Type = '002001') [002001] ")
        Query.Append("   ,(select Value from Parm_Account where EmpCode = '" & CIIS_EmpCode & "' and Type = '002002') [002002] ")
        Query.Append("   ,(select Value from Parm_Account where EmpCode = '" & CIIS_EmpCode & "' and Type = '002003') [002003] ")
        Query.Append("   ,(select Value from Parm_Account where EmpCode = '" & CIIS_EmpCode & "' and Type = '003001') [003001] ")
        Query.Append("   ,(select Value from Parm_Account where EmpCode = '" & CIIS_EmpCode & "' and Type = '003002') [003002] ")
        Query.Append("   ,(select Value from Parm_Account where EmpCode = '" & CIIS_EmpCode & "' and Type = '004001') [004001] ")
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
                    cbxChangeStatus.Checked = IIf(DR("001001") = "1", True, False)
                    cbxAddRecord.Checked = IIf(DR("002001") = "1", True, False)
                    cbxDeleteRecord.Checked = IIf(DR("002002") = "1", True, False)
                    cbxEditRecord.Checked = IIf(DR("002003") = "1", True, False)
                    cbxAddFile.Checked = IIf(DR("003001") = "1", True, False)
                    cbxDeleteFile.Checked = IIf(DR("003002") = "1", True, False)
                    cbxAddNote.Checked = IIf(DR("004001") = "1", True, False)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display
        upnlNotification.Update()
        'display

    End Function

    Protected Sub lbtnSave_Click(ByVal sender As Object, e As EventArgs)

        Dim _001001 As String = IIf(cbxChangeStatus.Checked = True, 1, 0)
        Dim _002001 As String = IIf(cbxAddRecord.Checked = True, 1, 0)
        Dim _002002 As String = IIf(cbxDeleteRecord.Checked = True, 1, 0)
        Dim _002003 As String = IIf(cbxEditRecord.Checked = True, 1, 0)
        Dim _003001 As String = IIf(cbxAddFile.Checked = True, 1, 0)
        Dim _003002 As String = IIf(cbxDeleteFile.Checked = True, 1, 0)
        Dim _004001 As String = IIf(cbxAddNote.Checked = True, 1, 0)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("update Parm_Account set ")
        Query.Append("   Value = '" & _001001 & "' ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Type = '001001' ")
        Query.Append("update Parm_Account set ")
        Query.Append("   Value = '" & _002001 & "' ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Type = '002001' ")
        Query.Append("update Parm_Account set ")
        Query.Append("   Value = '" & _002002 & "' ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Type = '002002' ")
        Query.Append("update Parm_Account set ")
        Query.Append("   Value = '" & _002003 & "' ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Type = '002003' ")
        Query.Append("update Parm_Account set ")
        Query.Append("   Value = '" & _003001 & "' ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Type = '003001' ")
        Query.Append("update Parm_Account set ")
        Query.Append("   Value = '" & _003002 & "' ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Type = '003002' ")
        Query.Append("update Parm_Account set ")
        Query.Append("   Value = '" & _004001 & "' ")
        Query.Append("where ")
        Query.Append("   EmpCode = '" & CIIS_EmpCode & "' ")
        Query.Append("   and Type = '004001' ")
        'get total task

        Dim SqlCon As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
        Dim SqlCmd As New SqlCommand
        SqlCmd.CommandText = Query.ToString
        SqlCmd.CommandType = CommandType.Text
        SqlCmd.Connection = SqlCon

        SqlCon.Open()
        SqlCmd.ExecuteScalar()
        SqlCon.Close()

        Alert("success", "Record successfully saved!")

    End Sub

#End Region

End Class