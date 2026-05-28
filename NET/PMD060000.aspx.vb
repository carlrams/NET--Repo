Imports System.Data.SqlClient
Imports System.IO
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Threading.Tasks
Imports System.Web.Script.Serialization
Imports System.Web.Script.Services
Imports System.Web.Services
Imports AjaxControlToolkit
Imports AjaxControlToolkit.HtmlEditor.ToolbarButtons
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Ajax.Utilities
Imports Microsoft.VisualBasic.Logging

Public Class PMD060000
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Public __o As String

    Dim DataSource As String = "10.10.30.10"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciis"
    Dim Password As String = "Cii5s"
    Dim FormCode As String = "PMD060000"

    Private Shared DataSource1 As String = "10.10.30.10"
    Private Shared catalog1 As String = "cldc_live_acc"
    Private Shared UserID1 As String = "ciis"
    Private Shared Password1 As String = "Cii5s"

    Dim AssignToDT As New DataTable
    Protected Property FormDataSet As DataSet

#Region "Page"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'user info
        CIIS_UserInfo = Request.Cookies("CIIS_UserInfo")
        Try
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
        Catch ex As Exception
            Response.Redirect("MNU010100")
        End Try
        'user info

        'active account / menu
        Master.setActiveMenu("APP", "PMD060000")
        'active account / menu

        'create variable
        Dim Msg As String = Access(CIIS_EmpCode, FormCode, "View")
        'create variable

        'validate access
        If Msg <> "1" Then
            Response.Redirect("MNU000022")
        End If
        'validate access

        'load page
        If IsPostBack = False Then

            'load
            bindTask()
            ClientScript.RegisterClientScriptBlock(Me.GetType, "IsPostBack", "var isPostBack = false;", True)
            'load

        End If
        'load page

    End Sub


    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Shared Function UpdateRFOMonitor(updatedData As List(Of Object)) As Object
        Dim result As New Dictionary(Of String, String)()
        Dim rowsAffected As Integer = 0

        Try
            Using conn As New SqlConnection("Data Source=" & DataSource1 & "; Initial Catalog=" & catalog1 & "; User ID=" & UserID1 & "; Password=" & Password1)
                conn.Open()

                Using transaction = conn.BeginTransaction()
                    Try
                        For Each item As Dictionary(Of String, Object) In updatedData
                            Using cmd As New SqlCommand("
                            UPDATE calmardblive.dbo.mstr_LotsInventory 
                            SET TOtoPMD = @TOtoPMD, 
                                TurnOverDate = @TurnOverDate, 
                                Keys = @Keys, 
                                PMDStatus = @PMDStatus 
                            WHERE LotCode = @LotCode", conn, transaction)

                                cmd.Parameters.AddWithValue("@LotCode", item("LotCode"))
                                cmd.Parameters.AddWithValue("@TOtoPMD", item("TOtoPMD"))
                                cmd.Parameters.AddWithValue("@TurnOverDate", If(IsDate(item("TurnOverDate")), item("TurnOverDate"), DBNull.Value))
                                cmd.Parameters.AddWithValue("@Keys", item("Keys"))
                                cmd.Parameters.AddWithValue("@PMDStatus", item("PMDStatus"))

                                rowsAffected += cmd.ExecuteNonQuery()
                            End Using
                        Next

                        transaction.Commit()
                        result("status") = "success"
                        result("rowsAffected") = rowsAffected.ToString()
                    Catch ex As Exception
                        transaction.Rollback()
                        result("status") = "error"
                        result("message") = ex.Message
                    End Try
                End Using
            End Using
        Catch ex As Exception
            result("error") = ex.Message
        End Try

        Return result
    End Function

#End Region

#Region "Button"
    Protected Sub lbtn01Refresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lbtn01Refresh.Click
        bindTask()
        Debug.WriteLine("refressh")
    End Sub




    Function bindTask()

        ' Define the SQL query
        Dim Query As New StringBuilder
        Query.Append("	select ")
        Query.Append("		* ")
        Query.Append("	from ")
        Query.Append("		(select ")
        Query.Append("			[LOT].LotCode [Code] ")
        Query.Append("			,[PRJ].ProjInit [Subd] ")
        Query.Append("			,[LOT].PhaseNo [Phase] ")
        Query.Append("			,[LOT].Block [Block] ")
        Query.Append("			,[LOT].Lot [Lot] ")
        Query.Append("			,[LOT].LotArea [Area] ")
        Query.Append("			,(Case	when [LOT].Status = 1 then 'Open' ")
        Query.Append("					when [LOT].Status = 2 then 'On-Hold' ")
        Query.Append("					when [LOT].Status = 3 then 'Sold' ")
        Query.Append("					when [LOT].Status = 4 then 'Not for Sale' end) [Status] ")
        Query.Append("			,[LOT].DOE [DOE] ")
        Query.Append("			,[HSE].ModelName [ModelName] ")
        Query.Append("			,[LOT].BatchNo	[BatchNo] ")
        Query.Append("			,[LOT].HCCompDate [HCCompDate] ")
        Query.Append("			,[LOT].[TOtoPMD] ")
        Query.Append("			,[LOT].TurnOverDate [TODate] ")
        Query.Append("			,[LOT].AcctNo [AcctNo] ")
        Query.Append("			,[LOT].AcctName [AcctName]")
        Query.Append("			,[LOT].[Keys] ")
        Query.Append("			,[LOT].[PMDStatus] ")
        Query.Append("		from ")
        Query.Append("			calmardblive.dbo.mstr_LotsInventory [LOT] ")
        Query.Append("			left join calmardblive.dbo.mstr_Projects [PRJ] on [LOT].ProjCode = [PRJ].ProjCode ")
        Query.Append("			left join calmardblive.dbo.mstr_HouseModels [HSE] on [LOT].Model = [HSE].ModelCode ")
        Query.Append("		where ")
        Query.Append("			[LOT].HCRate = 100 ")
        Query.Append("			and isnull([LOT].IsPackage,0) = 0 ")
        Query.Append("		union ")
        Query.Append("		Select ")
        Query.Append("			[LOT].LotCode [Code] ")
        Query.Append("			,[PRJ].ProjInit [Subd] ")
        Query.Append("			,[LOT].PhaseNo [Phase] ")
        Query.Append("			,[LOT].Block [Block] ")
        Query.Append("			,calmardblive.dbo.Get_LotPackageDesc([LOT].LotCode) [Lot] ")
        Query.Append("			,calmardblive.dbo.Get_LotPackageArea([LOT].LotCode) [Area] ")
        Query.Append("			,(Case	When [LOT].Status = 1 Then 'Open' ")
        Query.Append("					when [LOT].Status = 2 then 'On-Hold' ")
        Query.Append("					when [LOT].Status = 3 then 'Sold' ")
        Query.Append("					when [LOT].Status = 4 then 'Not for Sale' end) [Status] ")
        Query.Append("			,[LOT].DOE [DOE] ")
        Query.Append("			,[HSE].ModelName [ModelName] ")
        Query.Append("			,[LOT].BatchNo	[BatchNo] ")
        Query.Append("			,[LOT].HCCompDate [HCCompDate]	 ")
        Query.Append("			,[LOT].[TOtoPMD] ")
        Query.Append("			,[LOT].TurnOverDate [TODate] ")
        Query.Append("			,[LOT].AcctNo [AcctNo]")
        Query.Append("			,[LOT].AcctName[AcctName] ")
        Query.Append("			,[LOT].[Keys] ")
        Query.Append("			,[LOT].[PMDStatus] ")
        Query.Append("		from ")
        Query.Append("			calmardblive.dbo.mstr_LotsInventory [LOT] ")
        Query.Append("			left join calmardblive.dbo.mstr_Projects [PRJ] on [LOT].ProjCode = [PRJ].ProjCode ")
        Query.Append("			left join calmardblive.dbo.mstr_HouseModels [HSE] on [LOT].Model = [HSE].ModelCode ")
        Query.Append("		where ")
        Query.Append("			[LOT].HCRate = 100 ")
        Query.Append("			and [LOT].IsPackage = 1) [Tbl] ")
        Query.Append("	ORDER BY  ")
        Query.Append("		[Subd] ")
        Query.Append("		,(CASE	WHEN isnumeric([Phase]) = 1 THEN CONVERT(int, [Phase])  ")
        Query.Append("				ELSE (CASE	WHEN isnumeric(substring([Phase], 1, 1)) = 1 THEN CONVERT(int, replace([Phase], substring([Phase], patindex('%[^0-9]%', [Phase]), 20), ''))  ")
        Query.Append("							ELSE 0 END) END) ")
        Query.Append("		,[Phase] ")
        Query.Append("		,(CASE	WHEN isnumeric(block) = 1 THEN CONVERT(int, block)  ")
        Query.Append("				ELSE (CASE	WHEN isnumeric(substring(block, 1, 1)) = 1 THEN CONVERT(int, replace(block, substring(block, patindex('%[^0-9]%', block), 20), ''))  ")
        Query.Append("							ELSE 0 END) END) ")
        Query.Append("		,Block ")
        Query.Append("		,(CASE WHEN isnumeric(replace(Lot,',','.')) = 1 THEN CONVERT(decimal, replace(Lot,',','.'))  ")
        Query.Append("				ELSE (CASE	WHEN isnumeric(substring(replace(Lot,',','.'), 1, 1)) = 1 THEN CONVERT(decimal, replace(replace(Lot,',','.'), substring(replace(Lot,',','.'), patindex('%[^0-9]%', replace(Lot,',','.')), 20), ''))  ")
        Query.Append("				ELSE 0 END) END) ")
        Query.Append("		,replace(Lot,',','.') ")




        ' Create a DataTable to store the results
        Dim FormDataTable As New DataTable()
        FormDataTable.Columns.Add(New DataColumn("Code"))
        FormDataTable.Columns.Add(New DataColumn("Subd"))
        FormDataTable.Columns.Add(New DataColumn("Phase"))
        FormDataTable.Columns.Add(New DataColumn("Block"))
        FormDataTable.Columns.Add(New DataColumn("Lot"))
        FormDataTable.Columns.Add(New DataColumn("Area"))
        FormDataTable.Columns.Add(New DataColumn("Status"))
        FormDataTable.Columns.Add(New DataColumn("DOE"))
        FormDataTable.Columns.Add(New DataColumn("ModelName"))
        FormDataTable.Columns.Add(New DataColumn("BatchNo"))
        FormDataTable.Columns.Add(New DataColumn("HCCompDate"))
        FormDataTable.Columns.Add(New DataColumn("TOtoPMD"))
        FormDataTable.Columns.Add(New DataColumn("TODate"))
        FormDataTable.Columns.Add(New DataColumn("AcctName"))
        FormDataTable.Columns.Add(New DataColumn("Keys"))
        FormDataTable.Columns.Add(New DataColumn("PMDStatus"))



        ' Execute the query and fill the DataTable
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    Dim DOE As String = If(IsDBNull(DR("DOE")), "", Convert.ToDateTime(DR("DOE")).ToString("MM/dd/yyyy"))
                    Dim TODate As String = If(IsDBNull(DR("TODate")), "", Convert.ToDateTime(DR("TODate")).ToString("MM/dd/yyyy"))
                    Dim HCCompDate As String = If(IsDBNull(DR("HCCompDate")), "", Convert.ToDateTime(DR("HCCompDate")).ToString("MM/dd/yyyy"))
                    Dim TOtoPMD As String = ""
                    If Not IsDBNull(DR("TOtoPMD")) AndAlso Not String.IsNullOrWhiteSpace(DR("TOtoPMD").ToString()) Then
                        Dim tempDate As DateTime
                        If DateTime.TryParse(DR("TOtoPMD").ToString(), tempDate) Then
                            TOtoPMD = tempDate.ToString("MM/dd/yyyy")
                        End If
                    End If
                    Dim AcctName As String = "<div style='white-space: nowrap; overflow: hidden; text-overflow: ellipsis; max-width:200px;' title='" & DR("AcctName").ToString() & "'>" & DR("AcctName").ToString() & "</div>"
                    Dim ModelName As String = "<div style='white-space: nowrap; overflow: hidden; text-overflow: ellipsis; max-width:200px;' title='" & DR("ModelName").ToString() & "'>" & DR("ModelName").ToString() & "</div>"
                    Dim Phase As String = "<div style='white-space: nowrap; overflow: hidden; text-overflow: ellipsis; max-width:200px;' title='" & DR("Phase").ToString() & "'>" & DR("Phase").ToString() & "</div>"
                    ' Add the row to the DataTable
                    FormDataTable.Rows.Add(DR("Code"), DR("Subd"), Phase, DR("Block"), DR("Lot"), DR("Area"), DR("Status"), DOE, ModelName, DR("BatchNo"), HCCompDate, TOtoPMD, TODate, AcctName, DR("Keys"), DR("PMDStatus"))

                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record

        FormDataSet = New DataSet()
        FormDataSet.Tables.Add(FormDataTable)
    End Function



#End Region

#Region "Function"

    Function Alert(ByVal Alert_ As String, ByVal Message_ As String, AdditionalScript As String)
        Dim class_ As String = IIf(Alert_ = "success", "btn btn-primary", "btn btn-danger")
        ScriptManager.RegisterClientScriptBlock(Me, Page.GetType(), "none", "<script>" & AdditionalScript & "Swal.fire({text: '" & Message_ & "',icon: '" & Alert_ & "',buttonsStyling: false,confirmButtonText: 'Ok, got it!',customClass: {confirmButton: '" & class_ & "'}});</script>", False)
    End Function




    Function Access(EmpCode, FormCode, Action)

        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Restriction"
        sqlCmd.Parameters.AddWithValue("@pUserId", EmpCode)
        sqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
        sqlCmd.Parameters.AddWithValue("@pRes", Action)
        Dim oConf As New SqlClient.SqlParameter("@oConf", SqlDbType.NVarChar, 1000)
        oConf.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oConf)

        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()

        Return oConf.Value.ToString
    End Function

    Function Validate(TblName, TblCode, Type)
        Dim sqlConn As New SqlClient.SqlConnection
        Dim sqlCmd As New SqlCommand
        sqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password
        sqlCmd.CommandTimeout = 1500
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "Conf_Record"
        sqlCmd.Parameters.AddWithValue("@pTblName", "Trxn_CEHdr")
        sqlCmd.Parameters.AddWithValue("@pTblCode", hfID.Value)
        sqlCmd.Parameters.AddWithValue("@pTblVal", "")
        sqlCmd.Parameters.AddWithValue("@pType", Type)
        Dim oAns As New SqlClient.SqlParameter("@oAns", SqlDbType.NVarChar, 1000)
        oAns.Direction = ParameterDirection.Output
        sqlCmd.Parameters.Add(oAns)
        sqlConn.Open()
        sqlCmd.ExecuteNonQuery()
        sqlConn.Close()
        Return oAns.Value.ToString
    End Function


#End Region

End Class