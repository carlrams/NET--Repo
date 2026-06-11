Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.IO
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization
Imports OfficeOpenXml

Public Class HNDPDD
    Implements System.Web.IHttpHandler

    'cookies
    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String
    Dim ID As String
    'cookies

    'connection
    Dim DataSource As String = "10.10.30.20"
    Dim catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")

            Dim pFormCode = context.Request("pFormCode")
            Dim pType = context.Request("pType")
            'general parameter

            If FormCode = "FRM000043" And Type = "Search Project" Then

                Dim Find = context.Request("Find")

                Dim json As String = Me.FRM000043_Get_Project_List(Find)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "FRM000043" And Type = "Select Project" Then

                Dim LotCode = context.Request("LotCode")

                Dim json As String = Me.FRM000043_Get_Project_Info(LotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "PDD010000" And pType = "Get Record" Then

                Dim json As String = Me.PDD010000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD010000" And pType = "Get Record - List" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Get_Record_List(pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD010000" And pType = "Redraw" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD010000_Redraw(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD010000" And pType = "Get Info" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD010000_Get_Info(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD010000" And pType = "Add Record" Then

                Dim pProjName = context.Request("pProjName")
                Dim pProjInit = context.Request("pProjInit")
                Dim pBarangay = context.Request("pBarangay")
                Dim pMunicipality = context.Request("pMunicipality")
                Dim pProvince = context.Request("pProvince")
                Dim pOfficeAddress = context.Request("pOfficeAddress")
                Dim pDivision = context.Request("pDivision")
                Dim pDivCode = context.Request("pDivCode")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD010000_Add_Record(pProjName, pProjInit, pBarangay, pMunicipality, pProvince, pOfficeAddress, pDivision, pDivCode, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD010000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pProjName = context.Request("pProjName")
                Dim pProjInit = context.Request("pProjInit")
                Dim pBarangay = context.Request("pBarangay")
                Dim pMunicipality = context.Request("pMunicipality")
                Dim pProvince = context.Request("pProvince")
                Dim pOfficeAddress = context.Request("pOfficeAddress")
                Dim pDivision = context.Request("pDivision")
                Dim pDivCode = context.Request("pDivCode")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD010000_Edit_Record(pID, pProjName, pProjInit, pBarangay, pMunicipality, pProvince, pOfficeAddress, pDivision, pDivCode, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD010000" And pType = "Get Info - Last" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD010000_Get_Info_Last(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "PDD030000" And pType = "Get Record" Then

                Dim json As String = Me.PDD030000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD030000" And pType = "Get GLHouse" Then

                Dim pTblName = context.Request("pTblName")
                Dim pPlaceHolder = context.Request("pPlaceHolder")

                Dim json As String = Me.Get_House_List(pTblName, pPlaceHolder)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD030000" And pType = "Redraw" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD030000_Redraw(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD030000" And pType = "Get Info" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD030000_Get_Info(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD030000" And pType = "Add Record" Then

                Dim pName = context.Request("pName")
                Dim pInternal = context.Request("pInternal")
                Dim pMarketing = context.Request("pMarketing")
                Dim pFinish = context.Request("pFinish")
                Dim pMinLotArea = context.Request("pMinLotArea")
                Dim pLotDimension = context.Request("pLotDimension")
                Dim pMType = context.Request("pMType")
                Dim pStorey = context.Request("pStorey")
                Dim pGrossFloorArea = context.Request("pGrossFloorArea")
                Dim pNetFloorArea = context.Request("pNetFloorArea")
                Dim pGLHouse = context.Request("pGLHouse")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD030000_Add_Record(pName, pInternal, pMarketing, pFinish, pMinLotArea, pLotDimension, pMType, pStorey, pGrossFloorArea, pNetFloorArea, pGLHouse, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD030000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pName = context.Request("pName")
                Dim pInternal = context.Request("pInternal")
                Dim pMarketing = context.Request("pMarketing")
                Dim pFinish = context.Request("pFinish")
                Dim pMinLotArea = context.Request("pMinLotArea")
                Dim pLotDimension = context.Request("pLotDimension")
                Dim pMType = context.Request("pMType")
                Dim pStorey = context.Request("pStorey")
                Dim pGrossFloorArea = context.Request("pGrossFloorArea")
                Dim pNetFloorArea = context.Request("pNetFloorArea")
                Dim pGLHouse = context.Request("pGLHouse")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD030000_Edit_Record(pID, pName, pInternal, pMarketing, pFinish, pMinLotArea, pLotDimension, pMType, pStorey, pGrossFloorArea, pNetFloorArea, pGLHouse, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD030000" And pType = "Get Info - Last" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD030000_Get_Info_Last(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "PDD040000" And pType = "Get Record" Then

                Dim json As String = Me.PDD040000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD040000" And pType = "Get Info" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD040000_Get_Info(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD040000" And pType = "Add Record" Then

                Dim pSubject = context.Request("pSubject")
                Dim pReference = context.Request("pReference")
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")
                Dim pRemarks = context.Request("pRemarks")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD040000_Add_Record(pSubject, pReference, pDateFrom, pDateTo, pRemarks, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD040000" And pType = "Redraw" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD040000_Redraw(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD040000" And pType = "Edit Record" Then

                Dim pID = context.Request("pID")
                Dim pSubject = context.Request("pSubject")
                Dim pReference = context.Request("pReference")
                Dim pDateFrom = context.Request("pDateFrom")
                Dim pDateTo = context.Request("pDateTo")
                Dim pRemarks = context.Request("pRemarks")
                Dim pUpdatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD040000_Edit_Record(pID, pSubject, pReference, pDateFrom, pDateTo, pRemarks, pUpdatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "PDD050000" And pType = "Get Record" Then '//

                Dim json As String = Me.PDD050000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Get Info - Dtl" Then '//

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD050000_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Get Data" Then '//

                Dim pProjCode = context.Request("pProjCode")

                Dim json As String = Me.PDD050000_Get_Data(pProjCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Get House Model" Then '//

                Dim pProjCode = context.Request("pProjCode")

                Dim json As String = Me.PDD050000_Get_House_Model(pProjCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Add House Model" Then '//

                Dim pProjCode = context.Request("pProjCode")
                Dim pModelCodeSrs = context.Request("pModelCodeSrs")
                Dim pEmpCode = CIIS_EmpCode

                Dim json As String = Me.PDD050000_Add_House_Model(pProjCode, pModelCodeSrs, pEmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Redraw" Then '//

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD050000_Redraw(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Get Info" Then '//

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD050000_Get_Info(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Get Info - Last" Then '//

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD050000_Get_Info_Last(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Get ModelCode" Then '//

                Dim Project = context.Request("Project")
                Dim Model = context.Request("Model")

                Dim json As String = Me.PDD050000_Get_ModelCode(Project, Model)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD050000" And pType = "Edit-Record" Then '//

                Dim pProjCode = context.Request("pProjCode")
                Dim pLotSrs = context.Request("pLotSrs")
                Dim pEmpCode = CIIS_EmpCode

                Dim json As String = Me.PDD050000_Update_CB(pProjCode, pLotSrs, pEmpCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pType = "Upload-HLA" Then '//

                Dim json As String = Me.PDD050000_UploadHLA(context)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "PDD060000" And pType = "Get Record - HDR" Then

                Dim pTblFrom = context.Request("pTblFrom")

                Dim json As String = Me.PDD060000_Get_Record_Hdr(pTblFrom)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD060000" And pType = "Get Info - DTL" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD060000_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD060000" And pType = "Get Record - DTL - Lot Price" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD060000_Get_Record_Dtl_LotPrice(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD060000" And pType = "Get Record - DTL - House Price" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD060000_Get_Record_Dtl_HousePrice(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD070000" And pType = "GetBatchNo" Then
                context.Response.Write(GetBatchNo())
            ElseIf pFormCode = "PDD070000" And pType = "GetModelCode" Then

                Dim tableJson As String = context.Request("UploadExcel")
                Dim serializer As New JavaScriptSerializer()
                Dim rows As List(Of Dictionary(Of String, Object)) = serializer.Deserialize(Of List(Of Dictionary(Of String, Object)))(tableJson)

                Dim enrichedRows As List(Of Dictionary(Of String, Object)) = Me.PDD070000_Get_ModelInternal(rows)

                context.Response.ContentType = "application/json"
                context.Response.Write(serializer.Serialize(enrichedRows))
            ElseIf pFormCode = "PDD070000" And pType = "SaveBatchUpload" Then

                Dim DDLBatchNo = context.Request("DDLBatchNo")
                Dim DateStart = context.Request("DateStart")
                Dim tableJson As String = context.Request("UploadExcel")

                Dim serializer As New JavaScriptSerializer()
                Dim rows As List(Of Dictionary(Of String, Object)) = serializer.Deserialize(Of List(Of Dictionary(Of String, Object)))(tableJson)

                Dim json As String = Me.PDD070000_SaveBatchUpload(DDLBatchNo, DateStart, rows)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD080000" And pType = "Get Record - HDR" Then

                Dim json As String = Me.PDD080000_Get_Record_Hdr()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD080100" And pType = "Get Record - DTL" Then
                Dim ProjCode = context.Request("ProjCode")
                Dim json As String = Me.PDD080100_Get_Record_Dtl(ProjCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD080100" And pType = "GetProjName" Then
                Dim ProjCode = context.Request("ProjCode")
                Dim json As String = Me.PDD080100_GetProjName(ProjCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD080100" And pType = "ValidateLotsInventory" Then

                'Dim ProjCode = context.Request("ProjCode")
                'Dim json As String = Me.PDD080100_ValidateInventory(ProjCode)
                'context.Response.ContentType = "text/json"
                'context.Response.Write(json)

            End If

            If pFormCode = "PDD090000" And pType = "Get Record" Then

                Dim json As String = Me.PDD090000_Get_Record()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If

            If pFormCode = "PDD090100" And pType = "Get Info - Dtl" Then

                Dim pID = context.Request("pID")

                Dim json As String = Me.PDD090100_Get_Info_Dtl(pID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Redraw" Then

                Dim pID = context.Request("pID")
                Dim pLotCode = context.Request("pLotCode")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")

                Dim json As String = Me.PDD090100_Redraw(pID, pLotCode, pPhase, pBlock, pLot)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Redraw - Dtl" Then

                Dim pID = context.Request("pID")
                Dim pLotCode = context.Request("pLotCode")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")

                Dim json As String = Me.PDD090100_Redraw_Dtl(pID, pLotCode, pPhase, pBlock, pLot)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Get Data - Add" Then

                Dim pProjCode = context.Request("pProjCode")

                Dim json As String = Me.PDD090100_Get_Data_Add(pProjCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Get Data - Add (Dtl)" Then

                Dim pProjCode = context.Request("pProjCode")

                Dim json As String = Me.PDD090100_Get_Data_Add_Dtl(pProjCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Add Record" Then

                Dim pID = context.Request("pID")
                Dim pLotCode = context.Request("pLotCode")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD090100_Add_Record(pID, pLotCode, pPhase, pBlock, pLot, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Add Record (Dtl)" Then

                Dim pID = context.Request("pID")
                Dim pCode = context.Request("pCode")
                Dim pMtr_Phase = context.Request("pMtr_Phase")
                Dim pMtr_Block = context.Request("pMtr_Block")
                Dim pMtr_Lot = context.Request("pMtr_Lot")
                Dim pLotCode = context.Request("pLotCode")
                Dim pPhase = context.Request("pPhase")
                Dim pBlock = context.Request("pBlock")
                Dim pLot = context.Request("pLot")
                Dim pCreatedBy = CIIS_EmpCode

                Dim json As String = Me.PDD090100_Add_Record_Dtl(pID, pCode, pMtr_Phase, pMtr_Block, pMtr_Lot, pLotCode, pPhase, pBlock, pLot, pCreatedBy)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Get Data" Then

                Dim pProjCode = context.Request("pProjCode")

                Dim json As String = Me.PDD090100_Get_Data(pProjCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Get Data - Edit" Then

                Dim pLotCode = context.Request("pLotCode")

                Dim json As String = Me.PDD090100_Edit_Record(pLotCode)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf pFormCode = "PDD090100" And pType = "Edit Record" Then


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

#Region "FRM000043"

    Private Function FRM000043_Get_Project_List(Find)

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
        Query.Append("	    [A].LotCode in (select [E].LotCode from calmardblive.dbo.mstr_LotsInventory [E] where [E].Status = 1) ")
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

    Private Function FRM000043_Get_Project_Info(LotCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [A].ProjInit + ' ' + [A].PhaseNo + ' B' + [A].Block + ' L' + [A].Lot [Project] ")
        Query.Append("   ,[A].LotCode ")
        Query.Append("from ")
        Query.Append("	 calmardblive.dbo.Lot [A] ")
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
                        .Project = DR("Project"),
                        .LotCode = DR("LotCode")
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

#Region "PDD010000"

    Function Get_Record_List(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "division" Then
            Query.Append("select ")
            Query.Append("	'' [ID] ")
            Query.Append("	,'" & pPlaceHolder & "' [Name] ")
            Query.Append("	,0 [Order1] ")
            Query.Append("	,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("	[A].div_code [ID] ")
            Query.Append("	,[A].description [Name] ")
            Query.Append("	,2 [Order1] ")
            Query.Append("	,[A].description [Order2] ")
            Query.Append("from ")
            Query.Append("	division [A] ")
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

    Function PDD010000_Get_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ProjCode [ID] ")
        Query.Append("	,ProjName [Project] ")
        Query.Append("	,ProjInit [Initial] ")
        Query.Append("	,Address ")
        Query.Append("	,AuditUser ")
        Query.Append("	,AuditDate ")
        Query.Append("	,LockedBy ")
        Query.Append("	,LockedDate ")
        Query.Append("	,isnull(Lock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_Projects ")
        Query.Append("order by  ")
        Query.Append("	ProjName ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ProjName = "<span title='" & DR("Project") & "'>" & DR("Project") & "</span>",
                        .ProjInit = "<span title='" & DR("Initial") & "'>" & DR("Initial") & "</span>",
                        .Address = "<span title='" & DR("Address") & "'>" & DR("Address") & "</span>"
                    })

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

    Function PDD010000_Redraw(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ProjCode [ID] ")
        Query.Append("	,ProjName [Project] ")
        Query.Append("	,ProjInit [Initial] ")
        Query.Append("	,Address ")
        Query.Append("	,AuditUser ")
        Query.Append("	,AuditDate ")
        Query.Append("	,LockedBy ")
        Query.Append("	,LockedDate ")
        Query.Append("	,isnull(Lock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("   ProjCode = '" & pID & "' ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ProjName = "<span title='" & DR("Project") & "'>" & DR("Project") & "</span>",
                        .ProjInit = "<span title='" & DR("Initial") & "'>" & DR("Initial") & "</span>",
                        .Address = "<span title='" & DR("Address") & "'>" & DR("Address") & "</span>"
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

    Function PDD010000_Get_Info(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ProjCode [ID] ")
        Query.Append("	,[A].ProjName [Project] ")
        Query.Append("	,[A].ProjInit [Initial] ")
        Query.Append("	,(case when [A].Address IS NULL or ltrim(rtrim([A].Address)) in ('', ' ') then '-' else [A].Address end) [Address] ")
        Query.Append("	,[A].OfficeAddress ")
        Query.Append("	,[A].Division ")
        Query.Append("	,[B].fullname [UpdatedByName] ")
        Query.Append("	,format([A].UpdatedDate,'MM/dd/yy hh:mm tt') [UpdatedDate] ")
        Query.Append("	,(case when isnull([A].lock,0) = 1 then [B].fullname else '' end) [LockedByName] ")
        Query.Append("	,format([A].LockedDate,'MM/dd/yy hh:mm tt') [LockedDate] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [Status] ")
        Query.Append("from  ")
        Query.Append("	calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("	left join employee [B] on [B].emp_no = [A].UpdatedBy ")
        Query.Append("	left join employee [C] on [C].emp_no = [A].LockedBy ")
        Query.Append("where ")
        Query.Append("   ProjCode = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("	ProjName ")
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
                        .Title = DR("Project"),
                        .ID = DR("ID"),
                        .Status = DR("Status"),
                        .Lock = DR("Lock"),
                        .ProjName = DR("Project"),
                        .Initial = DR("Initial"),
                        .Address = DR("Address"),
                        .OfficeAddress = DR("OfficeAddress"),
                        .Division = DR("Division"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

    Function PDD010000_Add_Record(pProjName, pProjInit, pBarangay, pMunicipality, pProvince, pOfficeAddress, pDivision, pDivCode, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @ID nvarchar(13) ")
        Query.Append("exec New_Code 'mstr_Projects','',@ID output ")
        Query.Append("INSERT INTO calmardblive.dbo.mstr_Projects ")
        Query.Append("   ([ProjCode] ")
        Query.Append("   ,[ProjName] ")
        Query.Append("   ,[ProjInit] ")
        Query.Append("   ,[Address] ")
        Query.Append("   ,[BarangayName] ")
        Query.Append("   ,[Municipality] ")
        Query.Append("   ,[ProvinceName] ")
        Query.Append("   ,[OfficeAddress] ")
        Query.Append("   ,[Division] ")
        Query.Append("   ,[DivCode] ")
        Query.Append("   ,[AuditUser] ")
        Query.Append("   ,[AuditDate] ")
        Query.Append("   ,[UpdatedBy] ")
        Query.Append("   ,[UpdatedDate] ")
        Query.Append("   ,[LockedBy] ")
        Query.Append("   ,[LockedDate] ")
        Query.Append("   ,[lock]) ")
        Query.Append("VALUES ")
        Query.Append("   (@ID ")
        Query.Append("   ,'" & pProjName & "' ")
        Query.Append("   ,'" & pProjInit & "' ")
        Query.Append("   ,'Brgy. ' + '" & pBarangay & "' + ', ' + '" & pMunicipality & "' + ', ' + '" & pProvince & "' ")
        Query.Append("   ,'" & pBarangay & "' ")
        Query.Append("   ,'" & pMunicipality & "' ")
        Query.Append("   ,'" & pProvince & "' ")
        Query.Append("   ,'" & pOfficeAddress & "' ")
        Query.Append("   ,'" & pDivision & "' ")
        Query.Append("   ,'" & pDivCode & "' ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0) ")
        Query.Append("select @ID [oID] ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function PDD010000_Edit_Record(pID, pProjName, pProjInit, pBarangay, pMunicipality, pProvince, pOfficeAddress, pDivision, pDivCode, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("update calmardblive.dbo.mstr_Projects set ")
        Query.Append("   ProjName = '" & pProjName & "' ")
        Query.Append("   ,ProjInit = '" & pProjInit & "' ")
        Query.Append("   ,Address = 'Brgy. ' + '" & pBarangay & "' + ', ' + '" & pMunicipality & "' + ', ' + '" & pProvince & "' ")
        Query.Append("   ,BarangayName = '" & pBarangay & "' ")
        Query.Append("   ,Municipality = '" & pMunicipality & "' ")
        Query.Append("   ,ProvinceName = '" & pProvince & "' ")
        Query.Append("   ,OfficeAddress = '" & pOfficeAddress & "' ")
        Query.Append("   ,Division = '" & pDivision & "' ")
        Query.Append("   ,DivCode = '" & pDivCode & "' ")
        Query.Append("   ,UpdatedBy = '" & pCreatedBy & "' ")
        Query.Append("   ,UpdatedDate = getdate() ")
        Query.Append("where ")
        Query.Append("   ProjCode = '" & pID & "' ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function PDD010000_Get_Info_Last(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ProjCode [ID] ")
        Query.Append("	,[A].ProjName [Project] ")
        Query.Append("	,[A].ProjInit [Initial] ")
        Query.Append("	,(case when [A].BarangayName IS NULL or ltrim(rtrim([A].BarangayName)) in ('', ' ') then '-' else [A].BarangayName end) [BarangayName] ")
        Query.Append("	,(case when [A].Municipality IS NULL or ltrim(rtrim([A].Municipality)) in ('', ' ') then '-' else [A].Municipality end) [Municipality] ")
        Query.Append("	,(case when [A].ProvinceName IS NULL or ltrim(rtrim([A].ProvinceName)) in ('', ' ') then '-' else [A].ProvinceName end) [ProvinceName] ")
        Query.Append("	,[A].OfficeAddress ")
        Query.Append("	,[A].DivCode ")
        Query.Append("	,[B].fullname [UpdatedByName] ")
        Query.Append("	,format([A].UpdatedDate,'MM/dd/yy hh:mm tt') [UpdatedDate] ")
        Query.Append("	,(case when isnull([A].lock,0) = 1 then [B].fullname else '' end) [LockedByName] ")
        Query.Append("	,format([A].LockedDate,'MM/dd/yy hh:mm tt') [LockedDate] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [Status] ")
        Query.Append("from  ")
        Query.Append("	calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("	left join employee [B] on [B].emp_no = [A].UpdatedBy ")
        Query.Append("	left join employee [C] on [C].emp_no = [A].LockedBy ")
        Query.Append("where ")
        Query.Append("   ProjCode = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("	ProjName ")
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
                        .Title = DR("Project"),
                        .ID = DR("ID"),
                        .Status = DR("Status"),
                        .Lock = DR("Lock"),
                        .ProjName = DR("Project"),
                        .Initial = DR("Initial"),
                        .Barangay = DR("BarangayName"),
                        .Municipality = DR("Municipality"),
                        .Province = DR("ProvinceName"),
                        .OfficeAddress = DR("OfficeAddress"),
                        .Division = DR("DivCode"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

#Region "PDD030000"

    Function PDD030000_Get_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ModelCode [ID] ")
        Query.Append("	,ModelName [Name]  ")
        Query.Append("	,ModelInternal [Internal] ")
        Query.Append("	,ModelMarketing [Marketing] ")
        Query.Append("	,ModelFinish [Finish] ")
        Query.Append("	,MinLotArea ")
        Query.Append("	,LotDimension ")
        Query.Append("	,Type ")
        Query.Append("	,Storey ")
        Query.Append("	,GrossFloorArea ")
        Query.Append("	,NetFloorArea ")
        Query.Append("	,isnull(Active, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_HouseModels ")
        Query.Append("order by ")
        Query.Append("	ModelName ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Name = "<span title='" & DR("Name") & "'>" & DR("Name") & "</span>",
                        .Internal = "<span title='" & DR("Internal") & "'>" & DR("Internal") & "</span>",
                        .Marketing = "<span title='" & DR("Marketing") & "'>" & DR("Marketing") & "</span>",
                        .Finish = "<span title='" & DR("Finish") & "'>" & DR("Finish") & "</span>",
                        .MinLotArea = "<span title='" & DR("MinLotArea") & "'>" & DR("MinLotArea") & "</span>",
                        .LotDimension = "<span title='" & DR("LotDimension") & "'>" & DR("LotDimension") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .Storey = "<span title='" & DR("Storey") & "'>" & DR("Storey") & "</span>",
                        .GrossFloorArea = "<span title='" & DR("GrossFloorArea") & "'>" & DR("GrossFloorArea") & "</span>",
                        .NetFloorArea = "<span title='" & DR("NetFloorArea") & "'>" & DR("NetFloorArea") & "</span>"
                    })

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

    Function Get_House_List(pTblName, pPlaceHolder)

        'query
        Dim Query As New StringBuilder
        If pTblName = "glhouse" Then
            Query.Append("select ")
            Query.Append("	'' [ID] ")
            Query.Append("	,'" & pPlaceHolder & "' [Name] ")
            Query.Append("	,0 [Order1] ")
            Query.Append("	,'" & pPlaceHolder & "' [Order2] ")
            Query.Append("union ")
            Query.Append("select ")
            Query.Append("	isnull([B].h_code, '') [ID] ")
            Query.Append("	,isnull([B].house, '') [Name] ")
            Query.Append("	,2 [Order1] ")
            Query.Append("	,isnull([B].house, '') [Order2] ")
            Query.Append("from ")
            Query.Append("	calmardbLive.dbo.mstr_HouseModels [A] ")
            Query.Append("	left join eng_house [B] on [B].h_code = [A].HCode ")
            Query.Append("where ")
            Query.Append("	isnull([B].h_code, '') <> '' ")
            Query.Append("order by ")
            Query.Append("	[Order1] ")
            Query.Append("	,[Order2] ")
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

    Function PDD030000_Redraw(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ModelCode [ID] ")
        Query.Append("	,ModelName [Name]  ")
        Query.Append("	,ModelInternal [Internal] ")
        Query.Append("	,ModelMarketing [Marketing] ")
        Query.Append("	,ModelFinish [Finish] ")
        Query.Append("	,MinLotArea ")
        Query.Append("	,LotDimension ")
        Query.Append("	,Type ")
        Query.Append("	,Storey ")
        Query.Append("	,GrossFloorArea ")
        Query.Append("	,NetFloorArea ")
        Query.Append("	,isnull(Active, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_HouseModels ")
        Query.Append("where ")
        Query.Append("  ModelCode = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("	ModelName ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Name = "<span title='" & DR("Name") & "'>" & DR("Name") & "</span>",
                        .Internal = "<span title='" & DR("Internal") & "'>" & DR("Internal") & "</span>",
                        .Marketing = "<span title='" & DR("Marketing") & "'>" & DR("Marketing") & "</span>",
                        .Finish = "<span title='" & DR("Finish") & "'>" & DR("Finish") & "</span>",
                        .MinLotArea = "<span title='" & DR("MinLotArea") & "'>" & DR("MinLotArea") & "</span>",
                        .LotDimension = "<span title='" & DR("LotDimension") & "'>" & DR("LotDimension") & "</span>",
                        .Type = "<span title='" & DR("Type") & "'>" & DR("Type") & "</span>",
                        .Storey = "<span title='" & DR("Storey") & "'>" & DR("Storey") & "</span>",
                        .GrossFloorArea = "<span title='" & DR("GrossFloorArea") & "'>" & DR("GrossFloorArea") & "</span>",
                        .NetFloorArea = "<span title='" & DR("NetFloorArea") & "'>" & DR("NetFloorArea") & "</span>"
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

    Function PDD030000_Get_Info(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ModelCode [ID] ")
        Query.Append("	,[A].ModelName [Name] ")
        Query.Append("	,[A].ModelInternal [Internal] ")
        Query.Append("	,[A].ModelMarketing [Marketing] ")
        Query.Append("	,[A].ModelFinish [Finish] ")
        Query.Append("	,[A].MinLotArea ")
        Query.Append("	,[A].LotDimension ")
        Query.Append("	,[A].Type ")
        Query.Append("	,[A].Storey ")
        Query.Append("	,[A].GrossFloorArea ")
        Query.Append("	,[A].NetFloorArea ")
        Query.Append("	,isnull([F].house, '') [GLHouse] ")
        Query.Append("	,isnull([A].Active,0) [Lock] ")
        Query.Append("	,(case when [A].Active = 0 then 'New' when [A].Active = 1 then 'Locked' when [A].Active is null then 'Unlocked' end) [Status] ")
        Query.Append("	,isnull([D].fullname, '') [UpdatedByName] ")
        Query.Append("	,isnull(format([A].UpdatedDate,'MM/dd/yy hh:mm tt'), '') [UpdatedDate] ")
        Query.Append("	,(case when isnull([A].Active, 0) = 1 then isnull([C].fullname, (select top 1 [Y].fullname from calmardbLive.dbo.mstr_Users [X] left join employee [Y] on [X].EmpCode = [Y].emp_no where [X].LogName = [A].AuditUser)) else '' end) [LockedByName] ")
        Query.Append("	,isnull(format([A].LockedDate,'MM/dd/yy hh:mm tt'), '') [LockedDate] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_HouseModels [A] ")
        Query.Append("	left join calmardbLive.dbo.mstr_Users [B] on [B].LogName = [A].AuditUser ")
        Query.Append("	left join employee [C] on [C].emp_no = [B].EmpCode ")
        Query.Append("	left join employee [D] on [D].emp_no = [A].UpdatedBy ")
        Query.Append("	left join employee [E] on [E].emp_no = [A].LockedBy ")
        Query.Append("	left join eng_house [F] on [F].h_code = [A].HCode ")
        Query.Append("where ")
        Query.Append("  ModelCode = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("	ModelName ")
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
                        .Title = DR("Name"),
                        .ID = DR("ID"),
                        .Status = DR("Status"),
                        .Lock = DR("Lock"),
                        .Name = DR("Name"),
                        .Internal = DR("Internal"),
                        .Marketing = DR("Marketing"),
                        .Finish = DR("Finish"),
                        .MinLotArea = DR("MinLotArea"),
                        .LotDimension = DR("LotDimension"),
                        .Type = DR("Type"),
                        .Storey = DR("Storey"),
                        .GrossFloorArea = DR("GrossFloorArea"),
                        .NetFloorArea = DR("NetFloorArea"),
                        .GLHouse = DR("GLHouse"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

    Function PDD030000_Add_Record(pName, pInternal, pMarketing, pFinish, pMinLotArea, pLotDimension, pMType, pStorey, pGrossFloorArea, pNetFloorArea, pGLHouse, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @ID nvarchar(13) ")
        Query.Append("exec New_Code 'mstr_HouseModels','',@ID output ")
        Query.Append("INSERT INTO calmardblive.dbo.mstr_HouseModels ")
        Query.Append("   ([ModelCode] ")
        Query.Append("   ,[ModelName] ")
        Query.Append("   ,[ModelInternal] ")
        Query.Append("   ,[ModelMarketing] ")
        Query.Append("   ,[ModelFinish] ")
        Query.Append("   ,[MinLotArea] ")
        Query.Append("   ,[LotDimension] ")
        Query.Append("   ,[Type] ")
        Query.Append("   ,[Storey] ")
        Query.Append("   ,[GrossFloorArea] ")
        Query.Append("   ,[NetFloorArea] ")
        Query.Append("   ,[HCode] ")
        Query.Append("   ,[ProjCode] ")
        Query.Append("   ,[AuditUser] ")
        Query.Append("   ,[AuditDate] ")
        Query.Append("   ,[UpdatedBy] ")
        Query.Append("   ,[UpdatedDate] ")
        Query.Append("   ,[LockedBy] ")
        Query.Append("   ,[LockedDate] ")
        Query.Append("   ,[Active]) ")
        Query.Append("VALUES ")
        Query.Append("   (@ID ")
        Query.Append("   ,'" & pName & "' ")
        Query.Append("   ,'" & pInternal & "' ")
        Query.Append("   ,'" & pMarketing & "' ")
        Query.Append("   ,'" & pFinish & "' ")
        Query.Append("   ," & CDbl(pMinLotArea) & " ")
        Query.Append("   ,'" & pLotDimension & "' ")
        Query.Append("   ,'" & pMType & "' ")
        Query.Append("   ,'" & pStorey & "' ")
        Query.Append("   ," & CDbl(pGrossFloorArea) & " ")
        Query.Append("   ," & CDbl(pNetFloorArea) & " ")
        Query.Append("   ,'" & pGLHouse & "' ")
        Query.Append("   ,0 ")
        Query.Append("   ,(select LogName from calmardbLive.dbo.mstr_users where EmpCode = '" & pCreatedBy & "') ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0) ")
        Query.Append("select @ID [oID] ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function PDD030000_Edit_Record(pID, pName, pInternal, pMarketing, pFinish, pMinLotArea, pLotDimension, pMType, pStorey, pGrossFloorArea, pNetFloorArea, pGLHouse, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("update calmardblive.dbo.mstr_HouseModels set ")
        Query.Append("   ModelName = '" & pName & "' ")
        Query.Append("   ,ModelInternal = '" & pInternal & "' ")
        Query.Append("   ,ModelMarketing = '" & pMarketing & "' ")
        Query.Append("   ,ModelFinish = '" & pFinish & "' ")
        Query.Append("   ,MinLotArea = " & CDbl(pMinLotArea) & " ")
        Query.Append("   ,LotDimension = '" & pLotDimension & "' ")
        Query.Append("   ,Type = '" & pMType & "' ")
        Query.Append("   ,Storey = '" & pStorey & "' ")
        Query.Append("   ,GrossFloorArea = " & CDbl(pGrossFloorArea) & " ")
        Query.Append("   ,NetFloorArea = " & CDbl(pNetFloorArea) & " ")
        Query.Append("   ,HCode = '" & pGLHouse & "' ")
        Query.Append("   ,UpdatedBy = '" & pCreatedBy & "' ")
        Query.Append("   ,UpdatedDate = getdate() ")
        Query.Append("where ")
        Query.Append("   ModelCode = '" & pID & "' ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function PDD030000_Get_Info_Last(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ModelCode [ID] ")
        Query.Append("	,[A].ModelName [Name] ")
        Query.Append("	,[A].ModelInternal [Internal] ")
        Query.Append("	,[A].ModelMarketing [Marketing] ")
        Query.Append("	,[A].ModelFinish [Finish] ")
        Query.Append("	,[A].MinLotArea ")
        Query.Append("	,[A].LotDimension ")
        Query.Append("	,[A].Type ")
        Query.Append("	,[A].Storey ")
        Query.Append("	,[A].GrossFloorArea ")
        Query.Append("	,[A].NetFloorArea ")
        Query.Append("	,isnull([A].Active,0) [Lock] ")
        Query.Append("	,(case when [A].Active = 0 then 'New' when [A].Active = 1 then 'Locked' when [A].Active is null then 'Unlocked' end) [Status] ")
        Query.Append("	,isnull([F].h_code,'') [GLHouse] ")
        Query.Append("	,[D].fullname [UpdatedByName] ")
        Query.Append("	,format([A].UpdatedDate,'MM/dd/yy hh:mm tt') [UpdatedDate] ")
        Query.Append("	,(case when isnull([A].Active, 0) = 1 then isnull([C].fullname, (select top 1 [Y].fullname from calmardbLive.dbo.mstr_Users [X] left join employee [Y] on [X].EmpCode = [Y].emp_no where [X].LogName = [A].AuditUser)) else '' end) [LockedByName] ")
        Query.Append("	,format([A].LockedDate,'MM/dd/yy hh:mm tt') [LockedDate] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_HouseModels [A] ")
        Query.Append("	left join calmardbLive.dbo.mstr_Users [B] on [B].LogName = [A].AuditUser ")
        Query.Append("	left join employee [C] on [C].emp_no = [B].EmpCode ")
        Query.Append("	left join employee [D] on [D].emp_no = [A].UpdatedBy ")
        Query.Append("	left join employee [E] on [E].emp_no = [A].LockedBy ")
        Query.Append("	left join eng_house [F] on [F].h_code = [A].HCode ")
        Query.Append("where ")
        Query.Append("  ModelCode = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("	ModelName ")
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
                        .Title = DR("Name"),
                        .ID = DR("ID"),
                        .Status = DR("Status"),
                        .Lock = DR("Lock"),
                        .Name = DR("Name"),
                        .Internal = DR("Internal"),
                        .Marketing = DR("Marketing"),
                        .Finish = DR("Finish"),
                        .MinLotArea = DR("MinLotArea"),
                        .LotDimension = DR("LotDimension"),
                        .Type = DR("Type"),
                        .Storey = DR("Storey"),
                        .GrossFloorArea = DR("GrossFloorArea"),
                        .NetFloorArea = DR("NetFloorArea"),
                        .GLHouse = DR("GLHouse"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

#Region "PDD040000"

    Function PDD040000_Get_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("	SELECT        PDCode [ID], PDName, RefNo, DateFrom, DateTo, Remarks, AuditUser, AuditDate, UpdatedBy, UpdatedDate, LockedBy, LockedDate, isnull(Lock,0) [Lock] ")
        Query.Append("	FROM            calmardblive.dbo.mstr_PromoDiscount ")
        Query.Append("	ORDER BY PDName ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .ID = DR("ID"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .PDName = DR("PDName"),
                        .RefNo = DR("RefNo"),
                        .DateFrom = If(IsDBNull(DR("DateFrom")), "", Convert.ToDateTime(DR("DateFrom")).ToShortDateString()),
                        .DateTo = If(IsDBNull(DR("DateTo")), "", Convert.ToDateTime(DR("DateTo")).ToShortDateString()),
                        .Remarks = DR("Remarks")
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

    Function PDD040000_Get_Info(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("   select ")
        Query.Append("   [A].PDCode [ID] ")
        Query.Append("   ,[A].PDName ")
        Query.Append("   ,[A].RefNo  ")
        Query.Append("   ,[A].DateFrom  ")
        Query.Append("   ,[A].DateTo  ")
        Query.Append("   ,[A].Remarks  ")
        Query.Append("   ,[B].fullname [UpdatedByName] ")
        Query.Append("   ,format([A].UpdatedDate,'MM/dd/yyyy hh:mm tt') [UpdatedDate] ")
        Query.Append("   ,(case when isnull([A].lock,0) = 1 then [C].fullname else '' end) [LockedByName] ")
        Query.Append("   ,(case when isnull([A].lock,0) = 1 then format([A].LockedDate,'MM/dd/yyyy hh:mm tt') else '' end) AS LockedDate ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("   ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [RecordStatus] ")
        Query.Append("   from ")
        Query.Append("   calmardblive.dbo.mstr_PromoDiscount [A] ")
        Query.Append("   LEFT JOIN employee [B] ON [A].UpdatedBy = [B].emp_no ")
        Query.Append("   LEFT JOIN employee [C] ON [A].LockedBy = [C].emp_no ")
        Query.Append("   where ")
        Query.Append("   [A].PDCode = '" & pID & "' ")
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
                        .PDName = DR("PDName"),
                        .RefNo = DR("RefNo"),
                        .DateFrom = If(IsDBNull(DR("DateFrom")), "", Convert.ToDateTime(DR("DateFrom")).ToShortDateString()),
                        .DateTo = If(IsDBNull(DR("DateTo")), "", Convert.ToDateTime(DR("DateTo")).ToShortDateString()),
                        .Remarks = DR("Remarks"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate"),
                        .Lock = DR("Lock"),
                        .RecordStatus = DR("RecordStatus")
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

  Function PDD040000_Add_Record(pSubject, pReference, pDateFrom, pDateTo, pRemarks, pCreatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("declare @ID nvarchar(13) ")
        Query.Append("exec calmardblive.dbo.JCF_NewCode 'Mstr_PromoDiscount',@ID output ")
        Query.Append("INSERT INTO calmardblive.dbo.Mstr_PromoDiscount ")
        Query.Append("   ([PDCode] ")
        Query.Append("   ,[PDName] ")
        Query.Append("   ,[RefNo] ")
        Query.Append("   ,[DateFrom] ")
        Query.Append("   ,[DateTo] ")
        Query.Append("   ,[Remarks] ")
        Query.Append("   ,[AuditUser] ")
        Query.Append("   ,[AuditDate] ")
        Query.Append("   ,[UpdatedBy] ")
        Query.Append("   ,[UpdatedDate] ")
        Query.Append("   ,[LockedBy] ")
        Query.Append("   ,[LockedDate] ")
        Query.Append("   ,[Lock]) ")
        Query.Append("VALUES ")
        Query.Append("   (@ID ")
        Query.Append("   ,'" & pSubject & "' ")
        Query.Append("   ,'" & pReference & "' ")
        Query.Append("   ,'" & pDateFrom & "' ")
        Query.Append("   ,'" & pDateTo & "' ")
        Query.Append("   ,'" & pRemarks & "' ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,'" & pCreatedBy & "' ")
        Query.Append("   ,getdate() ")
        Query.Append("   ,null ")
        Query.Append("   ,null ")
        Query.Append("   ,0) ")
        Query.Append("select @ID [oID] ")

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

                    RecordList.Add(New With {.oID = DR("oID")})

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

    Function PDD040000_Redraw(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].PDCode [ID] ")
        Query.Append("   ,[A].PDName ")
        Query.Append("   ,[A].RefNo ")
        Query.Append("   ,[A].DateFrom ")
        Query.Append("   ,[A].DateTo ")
        Query.Append("   ,[A].Remarks ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.mstr_PromoDiscount [A] ")
        Query.Append("where ")
        Query.Append("   [A].PDCode = '" & pID & "' ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');$('#mdl01View').modal('show');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn01Delete('DTL','" & DR("ID") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn01Edit('DTL','" & DR("ID") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn01Lock('DTL','" & DR("ID") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn01Unlock('DTL','" & DR("ID") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .PDCode = "<span title='" & DR("ID") & "'>" & DR("ID") & "</span>",
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .PDName = "<span title='" & DR("PDName") & "'>" & DR("PDName") & "</span>",
                        .RefNo = "<span title='" & DR("RefNo") & "'>" & DR("RefNo") & "</span>",
                        .DateFrom = "<span title='" & DR("DateFrom") & "'>" & DR("DateFrom") & "</span>",
                        .DateTo = "<span title='" & DR("DateTo") & "'>" & DR("DateTo") & "</span>",
                        .Remarks = "<span title='" & DR("Remarks") & "'>" & DR("Remarks") & "</span>"
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

    Function PDD040000_Edit_Record(pID, pSubject, pReference, pDateFrom, pDateTo, pRemarks, pUpdatedBy)

        'create variable
        Dim Query As New StringBuilder
        Query.Append("update calmardblive.dbo.mstr_PromoDiscount set ")
        Query.Append("   PDName = '" & pSubject & "' ")
        Query.Append("   ,RefNo = '" & pReference & "' ")
        Query.Append("   ,DateFrom = '" & pDateFrom & "' ")
        Query.Append("   ,DateTo = '" & pDateTo & "' ")
        Query.Append("   ,Remarks = '" & pRemarks & "' ")
        Query.Append("   ,UpdatedBy = '" & pUpdatedBy & "' ")
        Query.Append("   ,UpdatedDate = getdate() ")
        Query.Append("where ")
        Query.Append("   PDCode = '" & pID & "' ")

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

                    RecordList.Add(New With {.oID = pID})

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

#Region "PDD050000"
    Function PDD050000_Get_Data(pProjCode)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardbLive.dbo.JCF_GetHLAList", ConStr)
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pProjCode", pProjCode)
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim row As New Dictionary(Of String, Object)()
                    'row("LotCode") = DR("cbxID")
                    For i As Integer = 0 To DR.FieldCount - 1
                        row(DR.GetName(i)) = DR.GetValue(i)
                    Next
                    RecordList.Add(row)



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

    Function PDD050000_Get_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ProjCode [ID] ")
        Query.Append("	,ProjName [Project] ")
        Query.Append("	,ProjInit [Initial] ")
        Query.Append("	,Address ")
        Query.Append("	,AuditUser ")
        Query.Append("	,AuditDate ")
        Query.Append("	,LockedBy ")
        Query.Append("	,LockedDate ")
        Query.Append("	,isnull(Lock, 0) [Lock] ")
        Query.Append("	,isnull(HLALock, 0) [HLALock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_Projects ")
        Query.Append("order by  ")
        Query.Append("	ProjName ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .HLALock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("HLALock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ProjName = "<span title='" & DR("Project") & "'>" & DR("Project") & "</span>",
                        .ProjInit = "<span title='" & DR("Initial") & "'>" & DR("Initial") & "</span>",
                        .Address = "<span title='" & DR("Address") & "'>" & DR("Address") & "</span>"
                    })

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

    Function PDD050000_Redraw(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ProjCode [ID] ")
        Query.Append("	,ProjName [Project] ")
        Query.Append("	,ProjInit [Initial] ")
        Query.Append("	,Address ")
        Query.Append("	,AuditUser ")
        Query.Append("	,AuditDate ")
        Query.Append("	,LockedBy ")
        Query.Append("	,LockedDate ")
        Query.Append("	,isnull(Lock, 0) [Lock] ")
        Query.Append("	,isnull(HLALock, 0) [HLALock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_Projects ")
        Query.Append("where ")
        Query.Append("   ProjCode = '" & pID & "' ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .HLALock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("HLALock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ProjName = "<span title='" & DR("Project") & "'>" & DR("Project") & "</span>",
                        .ProjInit = "<span title='" & DR("Initial") & "'>" & DR("Initial") & "</span>",
                        .Address = "<span title='" & DR("Address") & "'>" & DR("Address") & "</span>"
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

    Function PDD050000_Get_Info(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ProjCode [ID] ")
        Query.Append("	,[A].ProjName [Project] ")
        Query.Append("	,[A].ProjInit [Initial] ")
        Query.Append("	,(case when [A].Address IS NULL or ltrim(rtrim([A].Address)) in ('', ' ') then '-' else [A].Address end) [Address] ")
        Query.Append("	,[A].OfficeAddress ")
        Query.Append("	,[A].Division ")
        Query.Append("	,[B].fullname [UpdatedByName] ")
        Query.Append("	,format([A].UpdatedDate,'MM/dd/yy hh:mm tt') [UpdatedDate] ")
        Query.Append("	,(case when isnull([A].lock,0) = 1 then [B].fullname else '' end) [LockedByName] ")
        Query.Append("	,format([A].LockedDate,'MM/dd/yy hh:mm tt') [LockedDate] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [Status] ")
        Query.Append("from  ")
        Query.Append("	calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("	left join employee [B] on [B].emp_no = [A].UpdatedBy ")
        Query.Append("	left join employee [C] on [C].emp_no = [A].LockedBy ")
        Query.Append("where ")
        Query.Append("   ProjCode = '" & pID & "' ")
        Query.Append("order by ")
        Query.Append("	ProjName ")
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
                        .Title = DR("Project"),
                        .ID = DR("ID"),
                        .Status = DR("Status"),
                        .Lock = DR("Lock"),
                        .ProjName = DR("Project"),
                        .Initial = DR("Initial"),
                        .Address = DR("Address"),
                        .OfficeAddress = DR("OfficeAddress"),
                        .Division = DR("Division"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

    Function PDD050000_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ProjCode [ID] ")
        Query.Append("	,[A].ProjName [Project] ")
        Query.Append("	,[A].ProjInit [Initial] ")
        Query.Append("	,(case when [A].HLALock = 0 then 'New' when [A].HLALock = 1 then 'Locked' when [A].HLALock is null then 'Unlocked' end) [RecordStatus] ")
        Query.Append("	,isnull([D].fullname, '') [UpdatedByName] ")
        Query.Append("	,format([A].UpdatedDate,'MM/dd/yy hh:mm tt') [UpdatedDate] ")
        Query.Append("	,(case when isnull([A].HLALock, 0) = 1 then isnull([C].fullname, (select top 1 [Y].fullname from calmardbLive.dbo.mstr_Users [X] left join employee [Y] on [X].EmpCode = [Y].emp_no where [X].LogName = [A].HLALockedBy)) else '' end) [LockedByName] ")
        Query.Append("	,isnull(format([A].HLALockedDate,'MM/dd/yy hh:mm tt'), '') [LockedDate] ")
        Query.Append("	,isnull([A].HLALock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("	left join calmardbLive.dbo.mstr_Users [B] on [B].LogName = [A].HLALockedBy ")
        Query.Append("	left join employee [C] on [C].emp_no = [B].EmpCode ")
        Query.Append("	left join employee [D] on [D].emp_no = [A].UpdatedBy ")
        Query.Append("where ")
        Query.Append("	ProjCode = '" & pID & "' ")
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
                        .Title = DR("Project"),
                        .Status = DR("RecordStatus"),
                        .Lock = DR("Lock"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

    Function PDD050000_Get_Info_Last(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ProjCode [ID] ")
        Query.Append("	,[A].ProjName [Project] ")
        Query.Append("	,[A].ProjInit [Initial] ")
        Query.Append("	,(case when [A].BarangayName IS NULL or ltrim(rtrim([A].BarangayName)) in ('', ' ') then '-' else [A].BarangayName end) [BarangayName] ")
        Query.Append("	,(case when [A].Municipality IS NULL or ltrim(rtrim([A].Municipality)) in ('', ' ') then '-' else [A].Municipality end) [Municipality] ")
        Query.Append("	,(case when [A].ProvinceName IS NULL or ltrim(rtrim([A].ProvinceName)) in ('', ' ') then '-' else [A].ProvinceName end) [ProvinceName] ")
        Query.Append("	,[A].OfficeAddress ")
        Query.Append("	,[A].DivCode ")
        Query.Append("	,[B].fullname [UpdatedByName] ")
        Query.Append("	,format([A].UpdatedDate,'MM/dd/yy hh:mm tt') [UpdatedDate] ")
        Query.Append("	,(case when isnull([A].lock,0) = 1 then [B].fullname else '' end) [LockedByName] ")
        Query.Append("	,format([A].LockedDate,'MM/dd/yy hh:mm tt') [LockedDate] ")
        Query.Append("   ,isnull([A].Lock,0) [Lock] ")
        Query.Append("  ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [Status] ")
        Query.Append("from  ")
        Query.Append("	calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("	left join employee [B] on [B].emp_no = [A].UpdatedBy ")
        Query.Append("	left join employee [C] on [C].emp_no = [A].LockedBy ")
        Query.Append("where ")
        Query.Append("   ProjCode = '" & pID & "' ")
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
                        .Title = DR("Project"),
                        .ID = DR("ID"),
                        .Status = DR("Status"),
                        .Lock = DR("Lock"),
                        .ProjName = DR("Project"),
                        .Initial = DR("Initial"),
                        .Barangay = DR("BarangayName"),
                        .Municipality = DR("Municipality"),
                        .Province = DR("ProvinceName"),
                        .OfficeAddress = DR("OfficeAddress"),
                        .Division = DR("DivCode"),
                        .UpdatedByName = DR("UpdatedByName"),
                        .UpdatedDate = DR("UpdatedDate"),
                        .LockedByName = DR("LockedByName"),
                        .LockedDate = DR("LockedDate")
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

    Function PDD050000_Get_House_Model(pProjCode)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	isnull((select Active from calmardblive.dbo.mstr_ProjectAssignedHouse where calmardblive.dbo.mstr_ProjectAssignedHouse.ProjCode = '" & pProjCode & "' and calmardblive.dbo.mstr_ProjectAssignedHouse.ModelCode = [A].ModelCode),0) [Checked] ")
        Query.Append("	,[A].ModelCode ")
        Query.Append("	,isnull((select SeqNo from calmardblive.dbo.mstr_ProjectAssignedHouse where calmardblive.dbo.mstr_ProjectAssignedHouse.ProjCode = '" & pProjCode & "' and calmardblive.dbo.mstr_ProjectAssignedHouse.ModelCode = [A].ModelCode),0) [SeqNo] ")
        Query.Append("	,[A].ModelInternal [ModelName] ")
        Query.Append("	,[A].ModelFinish ")
        Query.Append("	,[A].GrossFloorArea [Area] ")
        Query.Append("	,[A].GrossFloorArea ")
        Query.Append("from ")
        Query.Append("	calmardblive.dbo.mstr_HouseModels [A] ")
        Query.Append("where ")
        Query.Append("	[A].ModelInternal != '' ")
        Query.Append("order by ")
        Query.Append("	[A].ModelName ")
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
                        .Action = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center '><input class='form-check-input cbxAddHA0102' type='checkbox' data-modelcode='" & DR("ModelCode") & "' value='' " & IIf(DR("Checked") = 1, " checked='checked'", "") & "/></div>",
                        .Sort = DR("SeqNo"),
                        .Code = DR("ModelCode"),
                        .ModelName = DR("ModelName"),
                        .ModelFinish = DR("ModelFinish"),
                        .Area = DR("Area")
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

    Function PDD050000_Get_ModelCode(Project, Model)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ModelCode ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_HouseModels [A] ")
        Query.Append("	left join calmardbLive.dbo.mstr_ProjectAssignedHouse [B] on [B].ModelCode = [A].ModelCode ")
        Query.Append("where ")
        Query.Append("	[B].ProjCode = '" & Project & "' ")
        Query.Append("	and ModelInternal = '" & Model & "' ")
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
                        .ModelCode = DR("ModelCode")
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

    Function PDD050000_Add_House_Model(pProjCode, pModelCodeSrs, pEmpCode)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "calmardblive.dbo.JCF_NewPAH"
        SqlCmd.Parameters.AddWithValue("@pProjCode", pProjCode)
        SqlCmd.Parameters.AddWithValue("@pModelCodeSRS", pModelCodeSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pEmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        'RecordList.Add(New With {.oReturn = oAns.Value.ToString})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Function PDD050000_Update_CB(pProjCode, pLotSrs, pEmpCode)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "calmardblive.dbo.JCF_NewHLA"
        SqlCmd.Parameters.AddWithValue("@pProjCode", pProjCode)
        SqlCmd.Parameters.AddWithValue("@pLotSrs", pLotSrs)
        SqlCmd.Parameters.AddWithValue("@pCreatedBy", pEmpCode)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        'RecordList.Add(New With {.oReturn = oAns.Value.ToString})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

    Function PDD050000_UploadHLA(context As HttpContext)

        'create new folder
        If Directory.Exists(HttpContext.Current.Server.MapPath("~/Assets/Upload/UploadHLA/" & CIIS_EmpCode & "/")) = False Then
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Assets/Upload/UploadHLA/" & CIIS_EmpCode & "/"))
        End If
        'create new folder

        Dim FilesPath As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/UploadHLA/" & CIIS_EmpCode & "/")
        Dim Files As String()
        For Each s As String In context.Request.Files
            Dim FileContext As HttpPostedFile = context.Request.Files(s)
            Dim FileSizeInBytes As Integer = FileContext.ContentLength
            Dim FileName As String = FileContext.FileName
            Dim FileCode As String = GenerateNewFileName(FileName)
            Dim FileExtension As String = FileContext.ContentType
            If Not String.IsNullOrEmpty(FileCode) Then
                FileExtension = System.IO.Path.GetExtension(FileCode)
                Files = System.IO.Directory.GetFiles(FilesPath)

                FileCode = Replace(FileCode, "@", "")
                FileCode = Replace(FileCode, "[", "")
                FileCode = Replace(FileCode, "^", "")
                FileCode = Replace(FileCode, "`", "")
                FileCode = Replace(FileCode, "|", "")
                FileCode = Replace(FileCode, "~", "")
                FileCode = Replace(FileCode, "\", "")
                FileCode = Replace(FileCode, "/", "")
                FileCode = Replace(FileCode, "!", "")
                FileCode = Replace(FileCode, "#", "")
                FileCode = Replace(FileCode, "$", "")
                FileCode = Replace(FileCode, "%", "")
                FileCode = Replace(FileCode, "&", "")
                FileCode = Replace(FileCode, "*", "")
                FileCode = Replace(FileCode, "(", "")
                FileCode = Replace(FileCode, ")", "")
                FileCode = Replace(FileCode, "+", "")
                FileCode = Replace(FileCode, "=", "")
                FileCode = Replace(FileCode, "[", "")
                FileCode = Replace(FileCode, "]", "")
                FileCode = Replace(FileCode, "{", "")
                FileCode = Replace(FileCode, "}", "")
                FileCode = Replace(FileCode, "'", "")
                FileCode = Replace(FileCode, "<", "")
                FileCode = Replace(FileCode, ">", "")
                FileCode = Replace(FileCode, ",", "")
                FileCode = Replace(FileCode, ",", "")
                FileCode = Replace(FileCode, "?", "")
                FileCode = Replace(FileCode, ":", "")
                FileCode = Replace(FileCode, ";", "")
                FileCode = Replace(FileCode, ";", "")
                FileCode = Replace(FileCode, "ñ", "n")
                FileCode = Replace(FileCode, "Ñ", "N")

                Dim Path As String = HttpContext.Current.Server.MapPath("~/Assets/Upload/UploadHLA/" & CIIS_EmpCode & "/" & FileCode)

                'save
                FileContext.SaveAs(Path)

                Try
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                    Using package As New ExcelPackage(New FileInfo(Path))
                        Dim sheetCount As Integer = package.Workbook.Worksheets.Count
                        Dim xlWorksheet = package.Workbook.Worksheets.FirstOrDefault
                        If xlWorksheet Is Nothing Then Throw New Exception("Worksheet is missing.")
                        Dim row As Integer = 1

                        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
                            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_UploadHLA", ConStr)
                                Cmd.CommandType = CommandType.StoredProcedure
                                Cmd.CommandTimeout = 1500
                                ConStr.Open()

                                For row = 2 To xlWorksheet.Dimension.End.Row
                                    Dim pProjInit = xlWorksheet.Cells(row, 1).Text.Trim()
                                    Dim pPhase = xlWorksheet.Cells(row, 2).Text.Trim()
                                    Dim pBlock = xlWorksheet.Cells(row, 3).Text.Trim()
                                    Dim pLot = xlWorksheet.Cells(row, 4).Text.Trim()
                                    Dim pCode = xlWorksheet.Cells(row, 5).Text.Trim()

                                    If String.IsNullOrEmpty(pProjInit) OrElse String.IsNullOrEmpty(pPhase) OrElse
                       String.IsNullOrEmpty(pBlock) OrElse String.IsNullOrEmpty(pLot) OrElse
                       String.IsNullOrEmpty(pCode) Then
                                        Continue For
                                    End If

                                    Cmd.Parameters.Clear()
                                    Cmd.Parameters.AddWithValue("@pProjInit", pProjInit)
                                    Cmd.Parameters.AddWithValue("@pPhase", pPhase)
                                    Cmd.Parameters.AddWithValue("@pBlock", pBlock)
                                    Cmd.Parameters.AddWithValue("@pLot", pLot)
                                    Cmd.Parameters.AddWithValue("@pCode", pCode)
                                    Cmd.ExecuteNonQuery()
                                Next

                            End Using
                        End Using

                        'deletion
                        If File.Exists(FilesPath) Then
                            File.Delete(FilesPath)
                        End If

                    End Using
                Catch ex As Exception
                    context.Response.Write("ERROR: " & ex.Message)
                End Try

            End If
        Next


    End Function

    Private Function GenerateNewFileName(ByVal originalFileName As String) As String
        ' Generate a unique file name or rename as needed
        Dim fileExtension As String = Path.GetExtension(originalFileName)
        Dim newFileName As String = CIIS_EmpCode & fileExtension
        Return newFileName
    End Function

#End Region

#Region "PDD060000"
    Function PDD060000_Get_Record_Hdr(pTblFrom)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardbLive.dbo.JCF_GetRcrdList")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pTblFrom", pTblFrom)
                Cmd.Parameters.AddWithValue("@pCode1", "")
                Cmd.Parameters.AddWithValue("@pCode2", "")
                Cmd.Parameters.AddWithValue("@pCode3", "")
                Cmd.Parameters.AddWithValue("@pCode4", "")
                Cmd.Parameters.AddWithValue("@pCode5", "")



                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('PDD060100-DTL-" & DR("Code") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn03Delete('" & DR("Code") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn04Edit('" & DR("Code") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Lock' onclick=""fn05Lock('" & DR("Code") & "');return false;""><i class='las la-lock fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-lock' title='Unlock' onclick=""fn06Unlock('" & DR("Code") & "');return false;""><i class='las la-unlock fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("Code"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Code = "<span title='" & DR("Code") & "'>" & DR("Code") & "</span>",
                        .Description = "<span title='" & DR("Description") & "'>" & DR("Description") & "</span>"
                    })

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

    Function PDD060000_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append(" SELECT        Code, PriceListNo, MemoNo, EffectiveDate, DateReleased, Remarks, AuditUser, AuditDate, LockedBy, LockedDate, Lock ")
        Query.Append(" FROM            calmardbLive.dbo.JCF_PriceMemo ")
        Query.Append(" WHERE        Code = '" & pID & "'  ")
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
                        .Code = DR("Code"),
                        .PriceListNo = DR("PriceListNo"),
                        .MemoNo = DR("MemoNo"),
                        .EffectiveDate = If(IsDBNull(DR("EffectiveDate")), "", Convert.ToDateTime(DR("EffectiveDate")).ToShortDateString()),
                        .DateReleased = If(IsDBNull(DR("DateReleased")), "", Convert.ToDateTime(DR("DateReleased")).ToShortDateString()),
                        .Remarks = DR("Remarks"),
                        .Lock = DR("Lock")
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

    Function PDD060000_Get_Record_Dtl_LotPrice(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT        LP.Code, LP.ProjCode, PR.ProjInit, LP.Phase, LP.Tier, LP.HL_ILRESDL, LP.HL_CLRESDL, LP.HL_ILPRIME, LP.HL_CLPRIME, LP.LO_ILRESDL, LP.LO_CLRESDL, ")
        Query.Append("                         LP.LO_ILPRIME, LP.LO_CLPRIME, LP.AuditUser, LP.AuditDate, LP.SeqNo ")
        Query.Append("FROM            calmardbLive.dbo.JCF_LotPrice AS LP LEFT OUTER JOIN ")
        Query.Append("                         calmardbLive.dbo.mstr_Projects AS PR ON LP.ProjCode = PR.ProjCode ")
        Query.Append("WHERE        (LP.Code = '" & pID & "') ")
        Query.Append("ORDER BY PR.ProjInit, (CASE WHEN isnumeric([LP].Phase) = 1 THEN CONVERT(int, [LP].Phase) ELSE (CASE WHEN isnumeric(substring([LP].Phase, 1, 1)) ")
        Query.Append("                         = 1 THEN CONVERT(int, replace([LP].Phase, substring([LP].Phase, patindex('%[^0-9]%', [LP].Phase), 20), '')) ELSE 0 END) END), LP.Phase, LP.Tier ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-light btn-active-light action-button' onclick=""window.open('AMD030100-DTL-" & DR("Code") & "');return false;"" title='View'>")
                    Action.Append("   <i class='las la-search fs-3'></i>")
                    Action.Append("</button>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("Code"),
                        .Action = Action.ToString,
                        .ProjCode = DR("ProjCode"),
                        .ProjInit = DR("ProjInit"),
                        .Phase = DR("Phase"),
                        .Tier = DR("Tier"),
                        .HL_ILRESDL = DR("HL_ILRESDL"),
                        .HL_CLRESDL = DR("HL_CLRESDL"),
                        .HL_ILPRIME = DR("HL_ILPRIME"),
                        .HL_CLPRIME = DR("HL_CLPRIME"),
                        .LO_ILRESDL = DR("LO_ILRESDL"),
                        .LO_CLRESDL = DR("LO_CLRESDL"),
                        .LO_ILPRIME = DR("LO_ILPRIME"),
                        .LO_CLPRIME = DR("LO_CLPRIME")
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

    Function PDD060000_Get_Record_Dtl_HousePrice(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("SELECT        HP.Code, HP.ModelCode, HM.ModelInternal, HM.ModelMarketing, HM.ModelFinish, HP.Price, HP.AuditUser, HP.AuditDate ")
        Query.Append("FROM            calmardbLive.dbo.JCF_HousePrice AS HP LEFT OUTER JOIN ")
        Query.Append("                         calmardbLive.dbo.mstr_HouseModels AS HM ON HP.ModelCode = HM.ModelCode ")
        Query.Append("WHERE        (HP.Code = '" & pID & "') ")
        Query.Append("ORDER BY HM.ModelName ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<button class='btn btn-sm btn-icon btn-light btn-active-light action-button' onclick=""window.open('AMD030100-DTL-" & DR("Code") & "');return false;"" title='View'>")
                    Action.Append("   <i class='las la-search fs-3'></i>")
                    Action.Append("</button>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("Code"),
                        .Action = Action.ToString,
                        .ModelCode = DR("ModelCode"),
                        .ModelInternal = DR("ModelInternal"),
                        .ModelMarketing = DR("ModelMarketing"),
                        .ModelFinish = DR("ModelFinish"),
                        .Price = DR("Price")
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

#Region "PDD070000"
    Function GetBatchNo()

        Dim Query As New StringBuilder
        Query.Append(" select ")
        Query.Append(" '' [Code] ")
        Query.Append(" ,'Select Batch No.' [Description] ")
        Query.Append(" ,'' [Order] ")
        Query.Append(" ,1 [Lock] ")
        Query.Append(" union ")
        Query.Append(" select ")
        Query.Append(" BatchNo [Code] ")
        Query.Append(" ,'Batch ' + BatchNo [Description] ")
        Query.Append(" ,'Batch ' + BatchNo [Order] ")
        Query.Append(" ,1 [Lock] ")
        Query.Append(" from  ")
        Query.Append(" calmardblive.dbo.mstr_BatchNo ")
        Query.Append(" order by ")
        Query.Append(" [Order] ")

        Dim ConStr As String = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        Dim SqlCon As New SqlConnection(ConStr)
        Dim SDA As New SqlDataAdapter(Query.ToString, SqlCon)
        Dim DT As New DataTable()
        SDA.Fill(DT)
        'execute query

        ' Convert DataTable to List(Of Dictionary(Of String, String))
        Dim result As New List(Of Dictionary(Of String, String))()
        For Each row As DataRow In DT.Rows
            Dim dict As New Dictionary(Of String, String)()
            dict("Code") = row("Code").ToString()
            dict("Description") = row("Description").ToString()
            result.Add(dict)
        Next

        ' Serialize the list to JSON
        Return New JavaScriptSerializer().Serialize(result)

    End Function
    Function PDD070000_Get_ModelInternal(rows As List(Of Dictionary(Of String, Object))) As List(Of Dictionary(Of String, Object))

        Dim enriched As New List(Of Dictionary(Of String, Object))()

        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            ConStr.Open()

            For Each row As Dictionary(Of String, Object) In rows
                Dim modelCode As String = row("Model_Code").ToString()
                Dim modelName As String = ""

                Using Cmd As New SqlCommand("SELECT TOP 1 ModelInternal FROM calmardblive.dbo.mstr_HouseModels WHERE ModelCode = @ModelCode", ConStr)
                    Cmd.Parameters.AddWithValue("@ModelCode", modelCode)
                    Dim result = Cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        modelName = result.ToString()
                    End If
                End Using

                ' Add Model_Name into the row
                row("Model_Name") = modelName

                enriched.Add(row)
            Next

            ConStr.Close()
        End Using

        Return enriched
    End Function



    Function PDD070000_SaveBatchUpload(DDLBatchNo As String, DateStart As String, rows As List(Of Dictionary(Of String, Object))) As String
        Dim RecordList As New List(Of Object)()

        Using SqlConn As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            SqlConn.Open()

            For Each row As Dictionary(Of String, Object) In rows
                Using SqlCmd As New SqlCommand("calmardblive.dbo.New_Form_HWCon", SqlConn)
                    SqlCmd.CommandType = CommandType.StoredProcedure
                    SqlCmd.CommandTimeout = 1500
                    SqlCmd.Parameters.AddWithValue("@pLotCode", row("Lot_Code").ToString())
                    SqlCmd.Parameters.AddWithValue("@pModelCode", row("Model_Code").ToString())
                    SqlCmd.Parameters.AddWithValue("@pBatchNo", DDLBatchNo)
                    SqlCmd.Parameters.AddWithValue("@pDate", DateStart)
                    SqlCmd.Parameters.AddWithValue("@pCreatedBy", CIIS_EmpCode)

                    SqlCmd.ExecuteNonQuery()
                End Using
            Next

            SqlConn.Close()
        End Using

        RecordList.Add(New With {.oReturn = "Success"})
        Return (New JavaScriptSerializer().Serialize(RecordList))
    End Function


#End Region

#Region "PDD080000"
    Function PDD080000_Get_Record_Hdr()
        'get total task
        Dim Query As New StringBuilder
        Query.Append(" 		select ")
        Query.Append(" 	ProjCode, ")
        Query.Append(" 	ProjName, ")
        Query.Append(" 	Lock ")
        Query.Append(" 	from   ")
        Query.Append(" 	calmardblive.dbo.mstr_Projects   ")
        Query.Append(" 	where lock = '1'   ")
        'get total task

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
                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""window.open('PDD080100-DTL-" & DR("ProjCode") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordInfo.Add(New With {
                        .Action = Action.ToString,
                        .Code = DR("projCode"),
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .Description = DR("projName")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'Display
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordInfo)
        'Display


    End Function

#End Region

#Region "PDD080100"

    Function PDD080100_Get_Record_Dtl(ProjCode)
        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand("calmardblive.dbo.JCF_GetINVList")
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pProjCode", ProjCode)
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader

                While DR.Read()
                    ' Build Action HTML
                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn0102Delete('" & DR("LotCode") & "', '" & DR("TCTNo") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn0102Edit('" & DR("LotCode") & "' ,'" & DR("TCTNo") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    ' Create row dictionary
                    Dim row As New Dictionary(Of String, Object)()

                    ' ✅ Add the Action column FIRST
                    row("Action") = Action.ToString()

                    ' Add all DB fields
                    For i As Integer = 0 To DR.FieldCount - 1
                        row(DR.GetName(i)) = If(IsDBNull(DR(i)), "", DR(i))
                    Next

                    ' Add row to RecordList
                    RecordList.Add(row)
                End While

                DR.Close()
                ConStr.Close()
            End Using
        End Using
        'read record


        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordList)

    End Function


    Function PDD080100_GetProjName(ProjCode)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("   	select  ")
        Query.Append(" ProjName, ")
        Query.Append(" (case when Lock = 1 then 'Locked' when Lock = 0 then 'New' when Lock = 1 then 'Locked' when Lock is null then 'Unlocked' end) [RecordStatus]")
        Query.Append(" from   ")
        Query.Append(" calmardblive.dbo.mstr_Projects   ")
        Query.Append(" where ProjCode =  '" & ProjCode & "'")
        'get total task

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
                        .ProjName = If(IsDBNull(DR("ProjName")), Nothing, DR("ProjName")),
                        .RecordStatus = DR("RecordStatus")
                    })
                End While
                DR.Close()
                ConStr.Close()
            End Using
        End Using

        'Display
        Dim serializer As New JavaScriptSerializer()
        serializer.MaxJsonLength = Integer.MaxValue
        Return serializer.Serialize(RecordInfo)
        'Display


    End Function

    Function PDD080100_ValidateInventory(pTblName, pTblCode, pTblVal, pAction)

        'variable
        Dim RecordList As New List(Of Object)()
        'variable

        'create connection
        Dim SqlConn As New SqlClient.SqlConnection
        Dim SqlCmd As New SqlCommand
        SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
        SqlCmd.CommandTimeout = 1500
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "Conf_Record"
        SqlCmd.Parameters.AddWithValue("@pTblName", pTblName)
        SqlCmd.Parameters.AddWithValue("@pType", pTblCode)
        SqlCmd.Parameters.AddWithValue("@pProjCode", pTblVal)
        SqlCmd.Parameters.AddWithValue("@pNewPhaseNo", pAction)
        SqlCmd.Parameters.AddWithValue("@pNewBlock", pAction)
        SqlCmd.Parameters.AddWithValue("@pNewLot", pAction)
        SqlCmd.Parameters.AddWithValue("@pNewLot", pAction)
        Dim oAns As New SqlClient.SqlParameter("@oAns", SqlDbType.NVarChar, 1000)
        oAns.Direction = ParameterDirection.Output
        SqlCmd.Parameters.Add(oAns)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oReturn = oAns.Value.ToString})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

#End Region

#Region "PDD090000"

    Function PDD090000_Get_Record()

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	ProjCode [ID] ")
        Query.Append("	,ProjName [Project] ")
        Query.Append("	,ProjInit [Initial] ")
        Query.Append("	,Address ")
        Query.Append("	,AuditUser ")
        Query.Append("	,AuditDate ")
        Query.Append("	,LockedBy ")
        Query.Append("	,LockedDate ")
        Query.Append("	,isnull(Lock, 0) [Lock] ")
        Query.Append("from ")
        Query.Append("	calmardbLive.dbo.mstr_Projects ")
        Query.Append("order by  ")
        Query.Append("	ProjName ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-view' title='View' onclick=""fn01View('DTL','" & DR("ID") & "');return false;""><i class='las la-search fs-3'></i></button>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID01" & DR("ID"),
                        .Action = Action.ToString,
                        .Lock = "<div class='form-check form-check-custom form-check-solid form-check-success w-100 flex-center'><input class='form-check-input' type='checkbox' value='' " & IIf(DR("Lock") = 1, " checked='checked'", "") & " onclick='return false'/></div>",
                        .ProjName = "<span title='" & DR("Project") & "'>" & DR("Project") & "</span>",
                        .ProjInit = "<span title='" & DR("Initial") & "'>" & DR("Initial") & "</span>",
                        .Address = "<span title='" & DR("Address") & "'>" & DR("Address") & "</span>"
                    })

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

#End Region

#Region "PDD090100"
    Function PDD090100_Get_Info_Dtl(pID)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("	[A].ProjCode [ID] ")
        Query.Append("	,[A].ProjName [Project] ")
        Query.Append("	,[A].ProjInit [Initial] ")
        Query.Append("  ,(case when [A].Lock = 0 then 'New' when [A].Lock = 1 then 'Locked' when [A].Lock is null then 'Unlocked' end) [Status] ")
        Query.Append("from  ")
        Query.Append("	calmardbLive.dbo.mstr_Projects [A] ")
        Query.Append("where ")
        Query.Append("   [A].ProjCode = '" & pID & "' ")
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
                        .Title = DR("Project"),
                        .ID = DR("ID"),
                        .Status = DR("Status"),
                        .ProjName = DR("Project"),
                        .Initial = DR("Initial")
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
    Function PDD090100_Get_Data_Add(pProjCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  LotCode [Code] ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,PhaseNo ")
        Query.Append("  ,Block ")
        Query.Append("  ,Lot ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_LotsInventory [Lot] ")
        Query.Append("where ")
        Query.Append("  [Lot].ProjCode = '" & pProjCode & "' ")
        Query.Append("  and [Lot].Saleable = 1 ")
        Query.Append("  and [Lot].LotCode not in (select [PL].LotCode from calmardbLive.dbo.mstr_PackagedLots [PL] where [PL].ProjCode = '" & pProjCode & "') ")
        Query.Append("order by ")
        Query.Append("  (case		when isnumeric(PhaseNo) = 1 then convert(int, PhaseNo) ")
        Query.Append("      else (case	when isnumeric(substring(PhaseNo, 1, 1)) = 1 then convert(int, replace(PhaseNo, substring(PhaseNo, patindex('%[^0-9]%', PhaseNo), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,PhaseNo ")
        Query.Append("  ,(case		when isnumeric(Block) = 1 then convert(int, Block) ")
        Query.Append("      else (case	when isnumeric(substring(Block, 1, 1)) = 1 then convert(int, replace(Block, substring(Block, patindex('%[^0-9]%', Block), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Block ")
        Query.Append("  ,(case		when isnumeric(Lot) = 1 then convert(int, Lot) ")
        Query.Append("      else (case	when isnumeric(substring(Lot, 1, 1)) = 1 then convert(int, replace(Lot, substring(Lot, patindex('%[^0-9]%', Lot), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Lot ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-info' title='Add' onclick=""fn010201Add('" & DR("Code") & "', '" & DR("PhaseNo") & "', '" & DR("Block") & "', '" & DR("Lot") & "');return false;""><i class='las la-check fs-3'></i></button>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("Code") & DR("PhaseNo") & DR("Block") & DR("Lot"),
                        .Action = Action.ToString,
                        .Phase = DR("PhaseNo"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .Blank = ""
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
    Function PDD090100_Get_Data_Add_Dtl(pProjCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  LotCode [Code] ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,PhaseNo ")
        Query.Append("  ,Block ")
        Query.Append("  ,Lot ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_LotsInventory [Lot] ")
        Query.Append("where ")
        Query.Append("  [Lot].ProjCode = '" & pProjCode & "' ")
        Query.Append("  and [Lot].Saleable = 1 ")
        Query.Append("  and [Lot].LotCode not in (select [PL].LotCode from calmardbLive.dbo.mstr_PackagedLots [PL] where [PL].ProjCode = '" & pProjCode & "') ")
        Query.Append("order by ")
        Query.Append("  (case		when isnumeric(PhaseNo) = 1 then convert(int, PhaseNo) ")
        Query.Append("      else (case	when isnumeric(substring(PhaseNo, 1, 1)) = 1 then convert(int, replace(PhaseNo, substring(PhaseNo, patindex('%[^0-9]%', PhaseNo), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,PhaseNo ")
        Query.Append("  ,(case		when isnumeric(Block) = 1 then convert(int, Block) ")
        Query.Append("      else (case	when isnumeric(substring(Block, 1, 1)) = 1 then convert(int, replace(Block, substring(Block, patindex('%[^0-9]%', Block), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Block ")
        Query.Append("  ,(case		when isnumeric(Lot) = 1 then convert(int, Lot) ")
        Query.Append("      else (case	when isnumeric(substring(Lot, 1, 1)) = 1 then convert(int, replace(Lot, substring(Lot, patindex('%[^0-9]%', Lot), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Lot ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-info' title='Add' onclick=""fn010401Add('" & DR("Code") & "', '" & DR("PhaseNo") & "', '" & DR("Block") & "', '" & DR("Lot") & "');return false;""><i class='las la-check fs-3'></i></button>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0104" & DR("Code") & DR("PhaseNo") & DR("Block") & DR("Lot"),
                        .Action = Action.ToString,
                        .Phase = DR("PhaseNo"),
                        .Block = DR("Block"),
                        .Lot = DR("Lot"),
                        .Blank = ""
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
    Function PDD090100_Add_Record(pID, pLotCode, pPhase, pBlock, pLot, pCreatedBy)

        'insert
        Dim Query As New StringBuilder
        Query.Append("INSERT INTO calmardbLive.dbo.mstr_PackagedLots ")
        Query.Append("  (Mtr_LotCode ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,Mtr_Phase ")
        Query.Append("  ,Mtr_Block ")
        Query.Append("  ,Mtr_Lot ")
        Query.Append("  ,Mtr_SurveyNo ")
        Query.Append("  ,LotCode ")
        Query.Append("  ,Phase ")
        Query.Append("  ,Block ")
        Query.Append("  ,Lot ")
        Query.Append("  ,SurveyNo ")
        Query.Append("  ,AuditUser ")
        Query.Append("  ,AuditDate) ")
        Query.Append("  VALUES ")
        Query.Append("  ('" & pLotCode & "' ")
        Query.Append("  ,'" & pID & "' ")
        Query.Append("  ,'" & pPhase & "' ")
        Query.Append("  ,'" & pBlock & "' ")
        Query.Append("  ,'" & pLot & "' ")
        Query.Append("  ,'-' ")
        Query.Append("  ,'" & pLotCode & "' ")
        Query.Append("  ,'" & pPhase & "' ")
        Query.Append("  ,'" & pBlock & "' ")
        Query.Append("  ,'" & pLot & "' ")
        Query.Append("  ,'-' ")
        Query.Append("  ,'" & pCreatedBy & "' ")
        Query.Append("  ,GETDATE()) ")
        'insert

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

                    RecordList.Add(New With {.oAction = "DTL"})

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
    Function PDD090100_Add_Record_Dtl(pID, pCode, pMtr_Phase, pMtr_Block, pMtr_Lot, pLotCode, pPhase, pBlock, pLot, pCreatedBy)

        'insert
        Dim Query As New StringBuilder
        Query.Append("INSERT INTO calmardbLive.dbo.mstr_PackagedLots ")
        Query.Append("  (Mtr_LotCode ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,Mtr_Phase ")
        Query.Append("  ,Mtr_Block ")
        Query.Append("  ,Mtr_Lot ")
        Query.Append("  ,Mtr_SurveyNo ")
        Query.Append("  ,LotCode ")
        Query.Append("  ,Phase ")
        Query.Append("  ,Block ")
        Query.Append("  ,Lot ")
        Query.Append("  ,SurveyNo ")
        Query.Append("  ,AuditUser ")
        Query.Append("  ,AuditDate) ")
        Query.Append("  VALUES ")
        Query.Append("  ('" & pCode & "' ")
        Query.Append("  ,'" & pID & "' ")
        Query.Append("  ,'" & pMtr_Phase & "' ")
        Query.Append("  ,'" & pMtr_Block & "' ")
        Query.Append("  ,'" & pMtr_Lot & "' ")
        Query.Append("  ,'-' ")
        Query.Append("  ,'" & pLotCode & "' ")
        Query.Append("  ,'" & pPhase & "' ")
        Query.Append("  ,'" & pBlock & "' ")
        Query.Append("  ,'" & pLot & "' ")
        Query.Append("  ,'-' ")
        Query.Append("  ,'" & pCreatedBy & "' ")
        Query.Append("  ,GETDATE()) ")
        'insert

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

                    RecordList.Add(New With {.oAction = "DTL"})

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
    Function PDD090100_Get_Data(pProjCode)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  Mtr_LotCode [Code] ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,Mtr_Phase ")
        Query.Append("  ,Mtr_Block ")
        Query.Append("  ,Mtr_Lot ")
        Query.Append("  ,AcctNo ")
        Query.Append("  ,AcctName ")
        Query.Append("  ,Lots ")
        Query.Append("from ")
        Query.Append("  (select distinct ")
        Query.Append("      [Hdr].Mtr_LotCode ")
        Query.Append("      ,[Hdr].ProjCode ")
        Query.Append("      ,[Hdr].Mtr_Phase ")
        Query.Append("      ,[Hdr].Mtr_Block ")
        Query.Append("      ,[Hdr].Mtr_Lot ")
        Query.Append("      ,(case when [Lot].Status = 3 then isnull((select [Byr].AcctNo from calmardbLive.dbo.ICR_Buyers [Byr] where [Byr].ProjCode = [Hdr].ProjCode and [Byr].Phase = [Hdr].Mtr_Phase and [Byr].Block = [Hdr].Mtr_Block and [Byr].Lot = [Hdr].Mtr_lot and [Byr].Active = 1),'') else '' end) [AcctNo] ")
        Query.Append("      ,(case when [Lot].Status = 3 then isnull((select [Byr].AcctName from calmardbLive.dbo.ICR_Buyers [Byr] where [Byr].ProjCode = [Hdr].ProjCode and [Byr].Phase = [Hdr].Mtr_Phase and [Byr].Block = [Hdr].Mtr_Block and [Byr].Lot = [Hdr].Mtr_lot and [Byr].Active = 1),'') else '' end) [AcctName] ")
        Query.Append("      ,(select count(*) from calmardbLive.dbo.mstr_PackagedLots [Dtl] where [Dtl].ProjCode = [Hdr].ProjCode and [Dtl].Mtr_Phase = [Hdr].Mtr_Phase and [Dtl].Mtr_Block = [Hdr].Mtr_Block and [Dtl].Mtr_Lot = [Hdr].Mtr_Lot) [Lots] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.mstr_PackagedLots [Hdr] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [Lot] on [Hdr].Mtr_LotCode = [Lot].LotCode ")
        Query.Append("  where ")
        Query.Append("      [Hdr].ProjCode = '" & pProjCode & "') [Tbl] ")
        Query.Append("order by ")
        Query.Append("  (case		when isnumeric(Mtr_Phase) = 1 then convert(int, Mtr_Phase) ")
        Query.Append("      else (case	when isnumeric(substring(Mtr_Phase, 1, 1)) = 1 then convert(int, replace(Mtr_Phase, substring(Mtr_Phase, patindex('%[^0-9]%', Mtr_Phase), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Mtr_Phase ")
        Query.Append("  ,(case		when isnumeric(Mtr_Block) = 1 then convert(int, Mtr_Block) ")
        Query.Append("      else (case	when isnumeric(substring(Mtr_Block, 1, 1)) = 1 then convert(int, replace(Mtr_Block, substring(Mtr_Block, patindex('%[^0-9]%', Mtr_Block), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Mtr_Block ")
        Query.Append("  ,(case		when isnumeric(Mtr_Lot) = 1 then convert(int, Mtr_Lot) ")
        Query.Append("      else (case	when isnumeric(substring(Mtr_Lot, 1, 1)) = 1 then convert(int, replace(Mtr_Lot, substring(Mtr_Lot, patindex('%[^0-9]%', Mtr_Lot), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Mtr_Lot ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn010201Delete('" & DR("Code") & "', '" & DR("ProjCode") & "', '" & DR("Mtr_Phase") & "', '" & DR("Mtr_Block") & "', '" & DR("Mtr_Lot") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn010201Edit('" & DR("Code") & "', '" & DR("ProjCode") & "', '" & DR("Mtr_Phase") & "', '" & DR("Mtr_Block") & "', '" & DR("Mtr_Lot") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("Code") & DR("ProjCode") & DR("Mtr_Phase") & DR("Mtr_Block") & DR("Mtr_Lot"),
                        .Action = Action.ToString,
                        .Phase = DR("Mtr_Phase"),
                        .Block = DR("Mtr_Block"),
                        .Lot = DR("Mtr_Lot"),
                        .Lots = DR("Lots"),
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName")
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
    Function PDD090100_Redraw(pID, pLotCode, pPhase, pBlock, pLot)

        'get query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  Mtr_LotCode [Code] ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,Mtr_Phase ")
        Query.Append("  ,Mtr_Block ")
        Query.Append("  ,Mtr_Lot ")
        Query.Append("  ,AcctNo ")
        Query.Append("  ,AcctName ")
        Query.Append("  ,Lots ")
        Query.Append("  ,(CASE WHEN (select fullname from employee where emp_no = AuditHdr) IS NULL THEN (select UPPER(LastName) + ', ' + UPPER(FirstName) + ' ' + UPPER(MiddleName) + '.' From calmardbLive.dbo.mstr_Users where calmardbLive.dbo.mstr_Users.LogName = AuditHdr) ELSE (select fullname from employee where emp_no = AuditHdr) END) [AuditUser]  ")
        Query.Append("  ,AuditDate ")
        Query.Append("from ")
        Query.Append("  (select distinct ")
        Query.Append("      [Hdr].Mtr_LotCode ")
        Query.Append("      ,[Hdr].ProjCode ")
        Query.Append("      ,[Hdr].Mtr_Phase ")
        Query.Append("      ,[Hdr].Mtr_Block ")
        Query.Append("      ,[Hdr].Mtr_Lot ")
        Query.Append("      ,[Hdr].AuditUser [AuditHdr] ")
        Query.Append("      ,FORMAT([Hdr].AuditDate, 'MM/dd/yyyy') [AuditDate] ")
        Query.Append("      ,(case when [Lot].Status = 3 then isnull((select [Byr].AcctNo from calmardbLive.dbo.ICR_Buyers [Byr] where [Byr].ProjCode = [Hdr].ProjCode and [Byr].Phase = [Hdr].Mtr_Phase and [Byr].Block = [Hdr].Mtr_Block and [Byr].Lot = [Hdr].Mtr_lot and [Byr].Active = 1),'') else '' end) [AcctNo] ")
        Query.Append("      ,(case when [Lot].Status = 3 then isnull((select [Byr].AcctName from calmardbLive.dbo.ICR_Buyers [Byr] where [Byr].ProjCode = [Hdr].ProjCode and [Byr].Phase = [Hdr].Mtr_Phase and [Byr].Block = [Hdr].Mtr_Block and [Byr].Lot = [Hdr].Mtr_lot and [Byr].Active = 1),'') else '' end) [AcctName] ")
        Query.Append("      ,(select count(*) from calmardbLive.dbo.mstr_PackagedLots [Dtl] where [Dtl].ProjCode = [Hdr].ProjCode and [Dtl].Mtr_Phase = [Hdr].Mtr_Phase and [Dtl].Mtr_Block = [Hdr].Mtr_Block and [Dtl].Mtr_Lot = [Hdr].Mtr_Lot) [Lots] ")
        Query.Append("  from ")
        Query.Append("      calmardbLive.dbo.mstr_PackagedLots [Hdr] ")
        Query.Append("      left join calmardbLive.dbo.mstr_LotsInventory [Lot] on [Hdr].Mtr_LotCode = [Lot].LotCode ")
        Query.Append("  where ")
        Query.Append("      [Hdr].ProjCode = '" & pID & "' ")
        Query.Append("      and [Hdr].Mtr_LotCode = '" & pLotCode & "' ")
        Query.Append("      and [Hdr].Mtr_Phase = '" & pPhase & "' ")
        Query.Append("      and [Hdr].Mtr_Block = '" & pBlock & "' ")
        Query.Append("      and [Hdr].Mtr_Lot = '" & pLot & "') [Tbl] ")
        'get query

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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("   <button class='btn btn-sm btn-icon btn-light btn-active-light action-button' title='Action' onclick='fn01Toggle(this);return false;'><i class='las la-bars fs-3'></i></button>")
                    Action.Append("   <div class='toggle-menu d-none btn-group action-button-toggle'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn010201Delete('" & DR("Code") & "', '" & DR("ProjCode") & "', '" & DR("Mtr_Phase") & "', '" & DR("Mtr_Block") & "', '" & DR("Mtr_Lot") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-edit' title='Edit' onclick=""fn010201Edit('" & DR("Code") & "', '" & DR("ProjCode") & "', '" & DR("Mtr_Phase") & "', '" & DR("Mtr_Block") & "', '" & DR("Mtr_Lot") & "');return false;""><i class='las la-pencil-alt fs-3'></i></button>")
                    Action.Append("   </div>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0102" & DR("Code") & DR("ProjCode") & DR("Mtr_Phase") & DR("Mtr_Block") & DR("Mtr_Lot"),
                        .Action = Action.ToString,
                        .Phase = DR("Mtr_Phase"),
                        .Block = DR("Mtr_Block"),
                        .Lot = DR("Mtr_Lot"),
                        .Lots = DR("Lots"),
                        .AcctNo = DR("AcctNo"),
                        .AcctName = DR("AcctName"),
                        .AuditBy = DR("AuditUser"),
                        .AuditDate = DR("AuditDate")
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
    Function PDD090100_Redraw_Dtl(pID, pLotCode, pPhase, pBlock, pLot)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  Mtr_LotCode ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,Mtr_Phase ")
        Query.Append("  ,Mtr_Block ")
        Query.Append("  ,Mtr_Lot ")
        Query.Append("  ,LotCode [Code] ")
        Query.Append("  ,Phase ")
        Query.Append("  ,Block ")
        Query.Append("  ,Lot ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_PackagedLots ")
        Query.Append("where ")
        Query.Append("  LotCode = '" & pLotCode & "' ")
        Query.Append("  and Phase = '" & pPhase & "' ")
        Query.Append("  and Block = '" & pBlock & "' ")
        Query.Append("  and Lot = '" & pLot & "' ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn010301Delete('" & DR("Code") & "', '" & DR("ProjCode") & "', '" & DR("Phase") & "', '" & DR("Block") & "', '" & DR("Lot") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0104" & DR("Code") & DR("Phase") & DR("Block") & DR("Lot"),
                        .Action = Action.ToString,
                        .PhaseNo = DR("Mtr_Phase"),
                        .BlockNo = DR("Mtr_Block"),
                        .LotNo = DR("Mtr_Lot"),
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
    Function PDD090100_Edit_Record(pLotCode)

        'query
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("  Mtr_LotCode ")
        Query.Append("  ,ProjCode ")
        Query.Append("  ,Mtr_Phase ")
        Query.Append("  ,Mtr_Block ")
        Query.Append("  ,Mtr_Lot ")
        Query.Append("  ,LotCode [Code] ")
        Query.Append("  ,Phase ")
        Query.Append("  ,Block ")
        Query.Append("  ,Lot ")
        Query.Append("from ")
        Query.Append("  calmardbLive.dbo.mstr_PackagedLots ")
        Query.Append("where ")
        Query.Append("  Mtr_LotCode = '" & pLotCode & "' ")
        Query.Append("order by ")
        Query.Append("  (case		when isnumeric(Phase) = 1 then convert(int, Phase) ")
        Query.Append("      else (case	when isnumeric(substring(Phase, 1, 1)) = 1 then convert(int, replace(Phase, substring(Phase, patindex('%[^0-9]%', Phase), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Phase ")
        Query.Append("  ,(case		when isnumeric(Block) = 1 then convert(int, Block) ")
        Query.Append("      else (case	when isnumeric(substring(Block, 1, 1)) = 1 then convert(int, replace(Block, substring(Block, patindex('%[^0-9]%', Block), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Block ")
        Query.Append("  ,(case		when isnumeric(Lot) = 1 then convert(int, Lot) ")
        Query.Append("      else (case	when isnumeric(substring(Lot, 1, 1)) = 1 then convert(int, replace(Lot, substring(Lot, patindex('%[^0-9]%', Lot), 20), '')) ")
        Query.Append("          else 0 end) end) ")
        Query.Append("  ,Lot ")
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

                    Dim Action As New StringBuilder
                    Action.Append("<div class='action-toggle-wrapper' style='position: relative; display: inline-block;'>")
                    Action.Append("      <button class='btn btn-sm btn-icon btn-delete' title='Delete' onclick=""fn010301Delete('" & DR("Code") & "', '" & DR("ProjCode") & "', '" & DR("Phase") & "', '" & DR("Block") & "', '" & DR("Lot") & "');return false;""><i class='las la-trash fs-3'></i></button>")
                    Action.Append("</div>")

                    RecordList.Add(New With {
                        .rowId = "rowID0103" & DR("Code") & DR("ProjCode") & DR("Mtr_Phase") & DR("Mtr_Block") & DR("Mtr_Lot"),
                        .Action = Action.ToString,
                        .PhaseNo = DR("Mtr_Phase"),
                        .BlockNo = DR("Mtr_Block"),
                        .LotNo = DR("Mtr_Lot"),
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
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display

    End Function
#End Region

End Class