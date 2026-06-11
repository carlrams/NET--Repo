Imports System.Data.SqlClient
Imports System.Diagnostics.Contracts
Imports System.IO
Imports Microsoft.Ajax.Utilities
Imports Microsoft.VisualBasic.Logging

Public Class DSB000012
    Inherits System.Web.UI.Page

    Dim CIIS_UserInfo As HttpCookie
    Dim CIIS_EmpCode As String

    Dim DataSource As String = "10.10.30.20"
    Dim Catalog As String = "cldc_live_acc"
    Dim UserID As String = "ciisv2"
    Dim Password As String = "Cii5s"

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
        Master.setActiveMenu("DSB", "001002")
        'active account / menu

        'load page
        If IsPostBack = False Then

            'Record
            ltrlID.Text = Me.Page.RouteData.Values("ID").ToString().Replace("No", "#")
            'Record

            'display record
            bindNavBar()
            bindMap()
            bindLegend()
            'display record

        End If
        'load page

    End Sub

#End Region

#Region "General"

    Function bindNavBar()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   [A].ProjInit  ")
        Query.Append("   ,[A].ProjName  ")
        Query.Append("   ,[A].Address  ")
        Query.Append("   ,[A].DateOpen  ")
        Query.Append("   ,(select count(1) from Form_HWHdr [B] where [B].ConStatus = 'Awarded' and isnull([B].POCRate,0) < 100 and [B].Subd = [A].ProjCode) [Total] ")
        Query.Append("from ")
        Query.Append("   calmardblive.dbo.mstr_Projects [A] ")
        Query.Append("where ")
        Query.Append("   [A].ProjCode = " & ltrlID.Text & " ")

        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()
                    imgProject.Src = "Assets/media/svg/project/" & DR.GetString(0) & ".svg"
                    lblProjName.Text = DR.GetString(1)
                    lblAddress.Text = DR.GetString(2)
                    lblLaunchDate.Text = Format(DR.GetDateTime(3), "dd MMM, yyyy")
                    divTotal.Attributes.Add("data-kt-countup-value", DR.GetInt32(4))
                    divPE.InnerHtml = bindPEList(ltrlID.Text)
                    aOverview.Attributes.Add("href", "DSB000011-" & ltrlID.Text)
                    aMap.Attributes.Add("href", "DSB000012-" & ltrlID.Text)
                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        upnlNavBar.Update()
        'display

    End Function

    Function bindPEList(ProjCode As String)

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   [A].AssignTo  ")
        Query.Append("   ,dbo.ProperCase([C].first_name) + ' ' + dbo.ProperCase([C].last_name) ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join employee [C] on [A].AssignTo = [C].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [A].POCRate < 100 ")
        Query.Append("   and [A].Status not in ('Complete','Close') ")
        Query.Append("   and [B].Subd = " & ProjCode & " ")
        'get approver 

        'Create innerhtml
        Dim InnerHtml As New StringBuilder
        'Create innerhtml

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim imgUser As String = ""
                    If File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(0) & ".png")) = True Then
                        imgUser = "Assets/media/avatars/" & DR.GetString(0) & ".png"
                    ElseIf File.Exists(Server.MapPath("~/Assets/media/avatars/" & DR.GetString(0) & ".jpg")) = True Then
                        imgUser = "Assets/media/avatars/" & DR.GetString(0) & ".jpg"
                    Else
                        imgUser = "Assets/media/avatars/blank.png"
                    End If

                    InnerHtml.Append("   <div Class='symbol symbol-35px symbol-circle' data-bs-toggle='tooltip' title='" & DR.GetString(1) & "'> ")
                    InnerHtml.Append("      <img alt ='Pic' src='" & imgUser & "' /> ")
                    InnerHtml.Append("   </div> ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        'display
        Return InnerHtml.ToString
        'display

    End Function

    Function bindMap()
        Dim Script As New StringBuilder
        Script.Append("<script src='Assets/js/custom/Map/" & ltrlID.Text & ".js'></script> ")
        Script.Append("<script type='text/javascript'> ")
        Script.Append("   $(function () { ")
        Script.Append("      $('.mapcontainer').mapael({ ")
        Script.Append("         map: { ")
        Script.Append("            name: 'Map' ")
        Script.Append("               ,zoom: { enabled: true , minLevel: 1, maxLevel: 10} ")
        Script.Append("               ,defaultArea: { attrs: { fill: '#acacac' , stroke: '#555555' , 'stroke-width':0.25 } , attrsHover: { fill: '#acacac', stroke: '#555555' , animDuration: 0 } } ")
        Script.Append("         } ")
        Script.Append("         ,legend: { ")
        Script.Append("            area: { ")
        Script.Append("               slices: [ ")
        Script.Append("                  { min: 1 , max: 1 , attrs: { fill: '#555555' , stroke: '#555555' , 'stroke-width': 0 } , attrsHover: { fill: '#555555' , stroke: '#555555' , 'stroke-width': 0 } } ") 'LotNo
        Script.Append("                  ,{ min: 2 , max: 2 , attrs: { fill: '#ffffff' , stroke: '#ffffff' , 'stroke-width': 0 } , attrsHover: { fill: '#ffffff' , stroke: '#ffffff' , 'stroke-width': 0 } } ") 'BlockNo
        Script.Append("                  ,{ min: 3 , max: 3 , attrs: { fill: '#555555' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#555555' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'PhaseNo
        Script.Append("                  ,{ min: 4 , max: 4 , attrs: { fill: '#efeeec' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#efeeec' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'PhaseBox
        Script.Append("                  ,{ min: 5 , max: 5 , attrs: { fill: 'none' , stroke: '#555555' , 'stroke-width': 1 , 'fill-opacity': 0 } , attrsHover: { fill: 'none' , stroke: '#555555' , 'stroke-width': 1 , 'fill-opacity': 0 } } ") 'PhaseBorder
        Script.Append("                  ,{ min: 6 , max: 6 , attrs: { fill: '#83E2E9' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'Newly Awarded
        Script.Append("                  ,{ min: 7 , max: 7 , attrs: { fill: '#619FFC' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'For Costing
        Script.Append("                  ,{ min: 8 , max: 8 , attrs: { fill: '#A777C9' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'For Budget
        Script.Append("                  ,{ min: 9 , max: 9 , attrs: { fill: '#ED7DB1' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'For Award
        Script.Append("                  ,{ min: 10 , max: 10 , attrs: { fill: '#6991A7' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'Awarded
        Script.Append("                  ,{ min: 11 , max: 11 , attrs: { fill: '#F8C22D' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'On-Going
        Script.Append("                  ,{ min: 12 , max: 12 , attrs: { fill: '#43BF57' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'Completed
        Script.Append("                  ,{ min: 13 , max: 13 , attrs: { fill: '#ADD43C' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'On-Hold
        Script.Append("                  ,{ min: 14 , max: 14 , attrs: { fill: '#F2451C' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#ffffff' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'Cancelled
        Script.Append("                  ,{ min: 15 , max: 15 , attrs: { fill: '#555555' , stroke: '#ffffff' , 'stroke-width': 1 } , attrsHover: { fill: '#555555' , stroke: '#ffffff' , 'stroke-width': 1 } } ") 'Road Lot
        Script.Append("                  ,{ min: 16 , max: 16 , attrs: { fill: '#d91e00' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#d91e00' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'Reserved Area
        Script.Append("                  ,{ min: 17 , max: 17 , attrs: { fill: '#157201' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#157201' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'Open Space
        Script.Append("                  ,{ min: 18 , max: 18 , attrs: { fill: '#00bff3' , stroke: '#00bff3' , 'stroke-width': 0.25 } , attrsHover: { fill: '#00bff3' , stroke: '#00bff3' , 'stroke-width': 0.25 } } ") 'Legal Easement
        Script.Append("                  ,{ min: 19 , max: 19 , attrs: { fill: '#5ad8f4' , stroke: '#5ad8f4' , 'stroke-width': 0.25 } , attrsHover: { fill: '#5ad8f4' , stroke: '#5ad8f4' , 'stroke-width': 0.25 } } ") 'Creek
        Script.Append("                  ,{ min: 20 , max: 20 , attrs: { fill: '#5f473f' , stroke: '#555555' , 'stroke-width': 0.25 } , attrsHover: { fill: '#5f473f' , stroke: '#555555' , 'stroke-width': 0.25 } } ") 'Excluded Area
        Script.Append("                  ,{ min: 21 , max: 21 , attrs: { fill: '#555555' , stroke: '#ffffff' , 'stroke-width': 1 } , attrsHover: { fill: '#555555' , stroke: '#ffffff' , 'stroke-width': 1 } } ") 'National Roan
        Script.Append("               ] ")
        Script.Append("            } ")
        Script.Append("         } ")
        Script.Append("         ,areas: {")
        Script.Append("            'LotNo': { value : 1 } ")
        Script.Append("            ,'BlockNo': { value : 2 } ")
        Script.Append("            ,'PhaseNo': { value : 3 } ")
        Script.Append("            ,'PhaseBox': { value : 4 } ")
        Script.Append("            ,'PhaseBorder1': { value : 5 } ")
        Script.Append("            ,'PhaseBorder2': { value : 5 } ")

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select distinct ")
        Query.Append("   replace([A].Phase,' ','') + '-' + replace([A].Block,' ','') + '-' + replace([A].Lot,' ','') [ID] ")
        Query.Append("   ,(case [A].Status when 'Newly Endorsed' then 6 when 'for Costing' then 7 when 'for Budget' then 8 when 'for Award' then 9 when 'Awarded' then 10 when 'On-Going' then 11 when 'Completed' then 12 when 'On-Hold' then 13 when 'Cancelled' then 14 end) [Value] ")
        Query.Append("   ,[A].SubdInit [Subd] ")
        Query.Append("   ,[A].Phase ")
        Query.Append("   ,[A].Block ")
        Query.Append("   ,[A].Lot ")
        Query.Append("   ,[A].House ")
        Query.Append("   ,isnull([A].Contractor,'-') [Contractor] ")
        Query.Append("   ,isnull([A].POCRate,0) [POCRate] ")
        Query.Append("   ,[A].POCStatus ")
        Query.Append("   ,dbo.ProperCase([B].first_name) [POCPE] ")
        Query.Append("from ")
        Query.Append("   view_ContructionStatus [A] ")
        Query.Append("   left join employee [B] on [A].POCPE = [B].emp_no ")
        Query.Append("where ")
        Query.Append("   [A].Subd = " & ltrlID.Text & " ")
        Query.Append("   and [A].Status in ('Newly Endorsed','for Costing','for Budget','for Award','Awarded','On-Going','Completed','On-Hold','Cancelled') ")
        'get approver 

        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    Dim ID As String = DR.GetString(0)
                    Dim Value As String = DR.GetInt32(1)
                    Dim Subd As String = DR.GetString(2)
                    Dim Phase As String = DR.GetString(3)
                    Dim Block As String = DR.GetString(4)
                    Dim Lot As String = DR.GetString(5)
                    Dim Unit As String = DR.GetString(6)
                    Dim Contractor As String = DR.GetString(7)
                    Dim POCRate As String = Format(DR.GetDecimal(8), "N2") & "%"
                    Dim POCStatus As String = DR.GetString(9)
                    Dim PE As String = DR.GetString(10)

                    Script.Append("            ,'" & ID & "': { ")
                    Script.Append("               value : " & Value & " ")
                    Script.Append("               ,eventHandlers: { ")
                    Script.Append("                  click: function () {")
                    Script.Append("                     var spnProject = document.getElementById('spnProject'); ")
                    Script.Append("                     var spnUnit = document.getElementById('spnUnit'); ")
                    Script.Append("                     var spnContractor = document.getElementById('spnContractor'); ")
                    Script.Append("                     var spnProgress = document.getElementById('spnProgress'); ")
                    Script.Append("                     var spnStatus = document.getElementById('spnStatus'); ")
                    Script.Append("                     var spnPE = document.getElementById('spnPE'); ")
                    Script.Append("                     spnProject.innerText = '" & Subd & " " & Phase & " B" & Block & " L" & Lot & "'; ")
                    Script.Append("                     spnUnit.innerText = '" & Unit & "'; ")
                    Script.Append("                     spnContractor.innerText = '" & Contractor & "'; ")
                    Script.Append("                     spnProgress.innerText = '" & POCRate & "'; ")
                    Script.Append("                     spnStatus.innerText = '" & POCStatus & "'; ")
                    Script.Append("                     spnPE.innerText = '" & PE & "'; ")
                    Script.Append("                  }")
                    Script.Append("               } ")
                    Script.Append("            } ")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

        Script.Append("            ,'RL': { value : 15 , tooltip: { content: 'Road Lot' } }")
        Script.Append("            ,'RA': { value : 16 , tooltip: { content: 'Reserved Area' } }")
        Script.Append("            ,'OS': { value : 17 , tooltip: { content: 'Open Space' } }")
        Script.Append("            ,'CF': { value : 17 , tooltip: { content: 'CF' } }")
        Script.Append("            ,'MRF': { value : 17 , tooltip: { content: 'MRF' } }")
        Script.Append("            ,'FD': { value : 17 , tooltip: { content: 'FD' } }")
        Script.Append("            ,'NC': { value : 17 , tooltip: { content: 'NC' } }")
        Script.Append("            ,'NA': { value : 17 , tooltip: { content: 'NA' } }")
        Script.Append("            ,'LE': { value : 18 , tooltip: { content: 'Legal Easement' } }")
        Script.Append("            ,'CREEK': { value : 19 , tooltip: { content: 'Creek' }  }")
        Script.Append("            ,'EA': { value : 20 , tooltip: { content: 'Exclueded Area' } }")
        Script.Append("            ,'BR': { value : 21 , tooltip: { content: 'Brgy. Road' } }")
        Script.Append("         }")
        Script.Append("      });")
        Script.Append("   });")
        Script.Append("</script>")

        ScriptManager.RegisterStartupScript(Me, Page.GetType(), "none", Script.ToString, False)

    End Function

    Function bindLegend()

        'get approver
        Dim Query As New StringBuilder
        Query.Append("select ")
        Query.Append("   (select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'Newly Endorsed') [NewlyEndorsed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'for Costing') [forCosting] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'for Budget') [forBudget] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'for Award') [forAward] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'Awarded') [Awarded] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'On-Going') [OnGoing] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'Completed') [Completed] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'On-Hold') [OnHold] ")
        Query.Append("   ,(select count(1) from view_ContructionStatus where Subd = " & ltrlID.Text & " and Status = 'Cancelled') [Cancelled] ")
        'get approver 


        'read record
        Using ConStr As New SqlConnection("Data Source=" & DataSource & "; Initial Catalog=" & Catalog & "; User ID=" & UserID & "; Password=" & Password)
            Using Cmd As New SqlCommand(Query.ToString)
                Cmd.CommandType = CommandType.Text
                Cmd.Connection = ConStr
                ConStr.Open()
                Dim DR As SqlDataReader = Cmd.ExecuteReader
                While DR.Read()

                    lblStsNewlyEndorsed.Text = DR("NewlyEndorsed")
                    lblStsForCosting.Text = DR("forCosting")
                    lblStsForBudget.Text = DR("forBudget")
                    lblStsForAward.Text = DR("forAward")
                    lblStsAwarded.Text = DR("Awarded")
                    lblStsOnGoing.Text = DR("OnGoing")
                    lblStsCompleted.Text = DR("Completed")
                    lblStsOnHold.Text = DR("OnHold")
                    lblStsCancelled.Text = DR("Cancelled")

                End While
                DR.Close()
                ConStr.Close()

            End Using
        End Using
        'read record

    End Function

#End Region

End Class
