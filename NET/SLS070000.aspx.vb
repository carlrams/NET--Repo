Imports System.Data.SqlClient
Imports System.IO

Public Class SLS070000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "iis"
    Dim catalog As String = ""
    Dim UserID As String = ""
    Dim Password As String = ""

#Region "Page"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "SLS070000")
        'active account / menu

        'create variable
        Dim Msg As String = Validate("Access", "View", "")
        'create variable

        'validate access
        If Msg <> "" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        'load page
        If IsPostBack = False Then

            'display record
            bindGSRsvChart()
            bindGSBkChart()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

#End Region

#Region "Charts"

    Function bindGSRsvChart()

        'get sold units per seller
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull([E].SellerGrpDesc, '-') [Group]  ")
        Query.Append("  ,SUM([B].Sellingprice) [TotalSales]  ")
        Query.Append("from  ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("  YEAR([B].RFDate) = YEAR(GETDATE())  ")
        Query.Append("  and [A].Active = 1 ")
        Query.Append("  and [A].Posted = 1 ")
        Query.Append("  and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("  [E].SellerGrpDesc ")
        Query.Append("order by ")
        Query.Append("  [TotalSales] desc ")
        'get sold units per seller 

        ltrlBarGroupSalesDataRsv.Text = ""
        ltrlBarGroupSalesNameRsv.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGroupSalesNameRsv.Text = "" Then
                        ltrlBarGroupSalesNameRsv.Text = DR.GetString(0)
                    Else
                        ltrlBarGroupSalesNameRsv.Text = ltrlBarGroupSalesNameRsv.Text & "," & DR.GetString(0)
                    End If

                    If ltrlBarGroupSalesDataRsv.Text = "" Then
                        ltrlBarGroupSalesDataRsv.Text = DR.GetDecimal(1)
                    Else
                        ltrlBarGroupSalesDataRsv.Text = ltrlBarGroupSalesDataRsv.Text & "," & DR.GetDecimal(1)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        upnlDashboard.Update()
        'diplay record

    End Function

    Function bindGSBkChart()

        'get sold units per seller
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  isnull([E].SellerGrpDesc, '-') [Group]  ")
        Query.Append("  ,SUM([B].Sellingprice) [TotalSales]  ")
        Query.Append("from  ")
        Query.Append("   calmardbLive.dbo.ICR_Buyers [A] ")
        Query.Append("   left join calmardbLive.dbo.ICR_Reservations [B] on [B].AcctNo = [A].AcctNo ")
        Query.Append("   left join calmardbLive.dbo.mstr_Sellers [D] on [D].SellerCode = [A].SellerCode ")
        Query.Append("   left join calmardbLive.dbo.mstr_SellerGroups [E] on [E].SellerGrpCode = [D].SellerGrpCode ")
        Query.Append("where ")
        Query.Append("  YEAR([B].RFDate) = YEAR(GETDATE())  ")
        Query.Append("  and [A].Active = 1 ")
        Query.Append("  and [A].Posted = 1 ")
        Query.Append("  and [B].Posted = 1 ")
        Query.Append("  and [E].SellerGrpDesc IS NOT NULL ")
        Query.Append("group by ")
        Query.Append("  [E].SellerGrpDesc ")
        Query.Append("order by ")
        Query.Append("  [TotalSales] desc ")
        'get sold units per seller 

        ltrlBarGroupSalesDataBk.Text = ""
        ltrlBarGroupSalesNameBk.Text = ""

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    If ltrlBarGroupSalesNameBk.Text = "" Then
                        ltrlBarGroupSalesNameBk.Text = DR.GetString(0)
                    Else
                        ltrlBarGroupSalesNameBk.Text = ltrlBarGroupSalesNameBk.Text & "," & DR.GetString(0)
                    End If

                    If ltrlBarGroupSalesDataBk.Text = "" Then
                        ltrlBarGroupSalesDataBk.Text = DR.GetDecimal(1)
                    Else
                        ltrlBarGroupSalesDataBk.Text = ltrlBarGroupSalesDataBk.Text & "," & DR.GetDecimal(1)
                    End If

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display record
        upnlDashboard.Update()
        'diplay record

    End Function

#End Region

#Region "Add ON"

    Function Validate(ByVal Group_ As String, Type As String, Value As String)

        'create variable
        Dim Query As New StringBuilder
        Dim Msg As String = ""
        'create variable

        If Group_ = "Access" Then

            'get total task
            If Type = "View" Then
                Query.Append("if 'SLS070000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS070000') ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Add" Then
                Query.Append("if 'SLS070000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS070000' and Add_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            If Type = "Save" Then
                Query.Append("if 'SLS070000' not in (select FormCode from Mstr_UserRestriction where EmpCode = '" & CIIS_EmpCode & "' and FormCode = 'SLS070000' and Save_ = 1) ")
                Query.Append("begin ")
                Query.Append("   select 'Access denied!' ")
                Query.Append("end ")
                Query.Append("else ")
                Query.Append("begin ")
                Query.Append("   select '' ")
                Query.Append("end ")
            End If
            'get total task

        End If

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Msg = DR.GetString(0)
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        'display data
        Return Msg
        'display data

    End Function

#End Region

End Class