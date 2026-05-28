Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.Ajax.Utilities
Imports Microsoft.Owin
Imports Microsoft.ReportingServices.Rendering.ExcelRenderer
Imports Microsoft.VisualBasic.Devices

Public Class HNDENG
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

#Region "Form"

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            'user info
            CIIS_UserInfo = HttpContext.Current.Request.Cookies("CIIS_UserInfo")
            CIIS_EmpCode = CIIS_UserInfo("CIIS_EmpCode")
            'user info

            'general parameter
            Dim FormCode = context.Request("FormCode")
            Dim Type = context.Request("Type")
            'general parameter

            'Building Permit
            If FormCode = "PDD010101" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010101" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.PDD010101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010101" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010101" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.PDD010101_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010101" And Type = "Close" Then

                Dim json As String = Me.PDD010101_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Building Permit

            'Construction Drawings
            If FormCode = "ENG020101" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020101" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG020101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020101" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020101" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG020101_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020101" And Type = "Close" Then

                Dim json As String = Me.ENG020101_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Construction Drawings

            'Cost Estimate
            If FormCode = "ENG030101" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG030101" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG030101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG030101" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG030101" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG030101_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG030101" And Type = "Close" Then

                Dim json As String = Me.ENG030101_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG030101" And Type = "Tag" Then

                Dim LotCodeSrs = context.Request("LotCodeSrs")

                Dim json As String = Me.ENG030101_Tag(LotCodeSrs)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Cost Estimate

            'Contract Awarding
            If FormCode = "SCM030101" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM030101" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.SCM030101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM030101" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "SCM030101" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.SCM030101_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM030101" And Type = "Close" Then

                Dim json As String = Me.SCM030101_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "SCM030101" And Type = "Update Contract" Then

                Dim UCID = context.Request("UCID")
                Dim UCBOQ = context.Request("UCBOQ")
                Dim UCContractor = context.Request("UCContractor")
                Dim UCCategory = context.Request("UCCategory")
                Dim UCType = context.Request("UCType")
                Dim UCNo = context.Request("UCNo")
                Dim UCPrice = context.Request("UCPrice")
                Dim UCVAT = context.Request("UCVAT")
                Dim UCEWT = context.Request("UCEWT")
                Dim UCDP = context.Request("UCDP")
                Dim UCRF = context.Request("UCRF")
                Dim UCPriorStart = context.Request("UCPriorStart")
                Dim UCStatus = context.Request("UCStatus")
                Dim UCDate = context.Request("UCDate")
                Dim UCStart = context.Request("UCStart")
                Dim UCEnd = context.Request("UCEnd")

                Dim json As String = Me.SCM030101_UpdateContract(FormCode, UCID, UCBOQ, UCContractor, UCCategory, UCType, UCNo, UCPrice, UCVAT, UCEWT, UCDP, UCRF, UCPriorStart, UCStatus, UCDate, UCStart, UCEnd)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Contract Awarding

            'Construction
            If FormCode = "ENG010501" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010501" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")
                Dim Contractor = context.Request("Contractor")

                Dim json As String = Me.ENG010501_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch, Contractor)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010501" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010501" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG010501_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010501" And Type = "Close" Then

                Dim json As String = Me.ENG010501_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG010501" And Type = "Update Contract" Then

                Dim UPID = context.Request("UPID")
                Dim UPRate = context.Request("UPRate")
                Dim UPDate = context.Request("UPDate")

                Dim json As String = Me.ENG010501_UpdateContract(FormCode, UPID, UPRate, UPDate)

                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Construction

            'COO / CEI
            If FormCode = "PDD010301" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010301" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.PDD010301_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010301" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010301" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.PDD010301_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010301" And Type = "Close" Then

                Dim json As String = Me.PDD010301_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'COO / CEI

            'Temporary Facility
            If FormCode = "ENG040101" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040101" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG040101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040101" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040101" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG040101_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040101" And Type = "Close" Then

                Dim json As String = Me.ENG040101_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Temporary Facility

            'Extension of Facilities
            If FormCode = "ENG040201" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040201" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG040201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040201" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040201" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG040101_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040201" And Type = "Close" Then

                Dim json As String = Me.ENG040201_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Extension of Facilities

            'Punchlist / COC
            If FormCode = "ENG040301" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040301" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG040301_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040301" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040301" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG040301_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG040301" And Type = "Close" Then

                Dim json As String = Me.ENG040301_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Punchlist / COC

            'TOPO
            If FormCode = "ENG050101" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050101" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG050101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050101" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050101" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG050101_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050101" And Type = "Close" Then

                Dim json As String = Me.ENG050101_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'TOPO

            'Inspection
            If FormCode = "PDD010201" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010201" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.PDD010201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010201" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010201" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.PDD010201_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "PDD010201" And Type = "Close" Then

                Dim json As String = Me.PDD010201_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Inspection

            'Relocation
            If FormCode = "ENG050201" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050201" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG050201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050201" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050201" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG050201_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG050201" And Type = "Close" Then

                Dim json As String = Me.ENG050201_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Relocation

            'Permit Plans
            If FormCode = "ENG020201" And Type = "Counter" Then

                Dim SubID = context.Request("SubID")

                Dim json As String = Me.ENGTASK_Counter(SubID)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020201" And Type = "Filter" Then

                Dim SubID = context.Request("SubID")
                Dim AssignTo = context.Request("AssignTo")
                Dim Subd = context.Request("Subd")
                Dim Phase = context.Request("Phase")
                Dim Block = context.Request("Block")
                Dim Lot = context.Request("Lot")
                Dim Batch = context.Request("Batch")

                Dim json As String = Me.ENG020201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020201" And Type = "Update" Then

                Dim ID = context.Request("ID")
                Dim SUBID = context.Request("SUBID")
                Dim Status = context.Request("Status")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENGTASK_Update(FormCode, ID, SUBID, Status, AssignTo)
                context.Response.ContentType = "text/html"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020201" And Type = "Redraw" Then

                Dim ID = context.Request("ID")
                Dim AssignTo = context.Request("AssignTo")

                Dim json As String = Me.ENG020201_Redraw(ID, AssignTo)
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            ElseIf FormCode = "ENG020201" And Type = "Close" Then

                Dim json As String = Me.ENG020201_Close()
                context.Response.ContentType = "text/json"
                context.Response.Write(json)

            End If
            'Permit Plans

        Catch ex As Exception

        End Try
    End Sub

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

#End Region

#Region "ENG"

    Function ENGTASK_Counter(SUBID As String)

        'get total task
        Dim Query As New StringBuilder
        Query.Append("select")
        Query.Append("	isnull((select count(1) from Form_HWTask where TaskCode = '" & SUBID & "' and AssignTo = '" & CIIS_EmpCode & "' and status in ('','Assign','On-Going','On-Hold','Clarify')),0) [InProgress] ")
        Query.Append("	,isnull((select count(1) from Form_HWTask where TaskCode = '" & SUBID & "' and AssignTo = '" & CIIS_EmpCode & "' and status in ('Close','Complete')),0) [Close] ")
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
                    RecordList.Add(New With {
                        .InProgress = DR("InProgress"),
                        .Close = DR("Close")
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

    Function ENGTASK_Update(FormCode As String, CSID As String, CSSUBID As String, CSStatus As String, CSAssignTo As String)
        If CSStatus = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else
            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Status"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", CSID)
            SqlCmd.Parameters.AddWithValue("@pSubID", CSSUBID)
            SqlCmd.Parameters.AddWithValue("@pStatus", CSStatus)
            SqlCmd.Parameters.AddWithValue("@pActDateEnd", Format(Date.Today, "MM/dd/yyyy"))
            SqlCmd.Parameters.AddWithValue("@pAssignTo", IIf(CSAssignTo = "", CIIS_EmpCode, CSAssignTo))
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "PDD010101"

    Function PDD010101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")

        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function PDD010101_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '001' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function PDD010101_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '001' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG020101"

    Function ENG020101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG020101_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '002' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG020101_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '002' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG030101"

    Function ENG030101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG030101_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '003' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG030101_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '003' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG030101_Tag(LotCodeSrs)

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
        SqlCmd.CommandText = "Upd_Form_HWHdr_Type"
        SqlCmd.Parameters.AddWithValue("@pLotCodeSrs", LotCodeSrs)
        'create connection

        'execute procedure
        SqlConn.Open()
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        'execute procedure

        'add value
        RecordList.Add(New With {.oAction = "Success"})
        'add value

        'display 
        Return (New JavaScriptSerializer().Serialize(RecordList))
        'display 

    End Function

#End Region

#Region "SCM030101"

    Function SCM030101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,[E].vendor [Contractor] ")
        Query.Append("   ,[E].v_code [ContractorCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .Contractor = If(IsDBNull(DR("Contractor")), "-", DR("Contractor")),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function SCM030101_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,[E].vendor [Contractor] ")
        Query.Append("   ,[E].v_code [ContractorCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '005' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .Contractor = If(IsDBNull(DR("Contractor")), "-", DR("Contractor")),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function SCM030101_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,[E].vendor [Contractor] ")
        Query.Append("   ,[E].v_code [ContractorCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '005' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .Contractor = If(IsDBNull(DR("Contractor")), "-", DR("Contractor")),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function SCM030101_UpdateContract(FormCode As String, UCID As String, UCBOQ As String, UCContractor As String, UCCategory As String, UCType As String, UCNo As String, UCPrice As String, UCVAT As String, UCEWT As String, UCDP As String, UCRF As String, UCPriorStart As String, UCStatus As String, UCDate As String, UCStart As String, UCEnd As String)
        If UCContractor = "" Or UCCategory = "" Or UCType = "" Or UCNo = "" Or UCStatus = "" Or UCDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Contract"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", UCID)
            SqlCmd.Parameters.AddWithValue("@pSubID", "005")
            SqlCmd.Parameters.AddWithValue("@pBOQ", UCBOQ)
            SqlCmd.Parameters.AddWithValue("@pContractor", UCContractor)
            SqlCmd.Parameters.AddWithValue("@pContractCategory", UCCategory)
            SqlCmd.Parameters.AddWithValue("@pContractType", UCType)
            SqlCmd.Parameters.AddWithValue("@pContractNo", UCNo)
            SqlCmd.Parameters.AddWithValue("@pContractPrice", CDbl(UCPrice))
            SqlCmd.Parameters.AddWithValue("@pContractVAT", CDbl(UCVAT))
            SqlCmd.Parameters.AddWithValue("@pContractEWT", CDbl(UCEWT))
            SqlCmd.Parameters.AddWithValue("@pContractDP", CDbl(UCDP))
            SqlCmd.Parameters.AddWithValue("@pContractRF", CDbl(UCRF))
            SqlCmd.Parameters.AddWithValue("@pContractPriorStart", CDbl(UCPriorStart))
            SqlCmd.Parameters.AddWithValue("@pContractStatus", UCStatus)
            SqlCmd.Parameters.AddWithValue("@pDateAwarded", UCDate)
            SqlCmd.Parameters.AddWithValue("@pConStart", UCStart)
            SqlCmd.Parameters.AddWithValue("@pConEnd", UCEnd)
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "ENG010501"

    Function ENG010501_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch, Contractor)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when isnull([A].POCRate,0) between 0.00 and 33.00 then '<span class=""badge badge-danger"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' ")
        Query.Append("          when isnull([A].POCRate,0) between 33.01 and 66.00 then '<span class=""badge badge-warning"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' ")
        Query.Append("          when isnull([A].POCRate,0) between 66.01 and 100.00 then '<span class=""badge badge-success"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' end) [POCRate]")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        If Contractor <> "" Then Query.Append("   and [B].Contractor = '" & Contractor & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title") + " - " + DR("Name"),
                        .POCRate = DR("POCRate"),
                        .POCDate = DR("POCDate"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG010501_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when isnull([A].POCRate,0) between 0.00 and 33.00 then '<span class=""badge badge-danger"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' ")
        Query.Append("          when isnull([A].POCRate,0) between 33.01 and 66.00 then '<span class=""badge badge-warning"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' ")
        Query.Append("          when isnull([A].POCRate,0) between 66.01 and 100.00 then '<span class=""badge badge-success"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' end) [POCRate]")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '006' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title") + " - " + DR("Name"),
                        .POCRate = DR("POCRate"),
                        .POCDate = DR("POCDate"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG010501_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when isnull([A].POCRate,0) between 0.00 and 33.00 then '<span class=""badge badge-danger"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' ")
        Query.Append("          when isnull([A].POCRate,0) between 33.01 and 66.00 then '<span class=""badge badge-warning"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' ")
        Query.Append("          when isnull([A].POCRate,0) between 66.01 and 100.00 then '<span class=""badge badge-success"">' + FORMAT(isnull([A].POCRate,0),'N2') + '%' + '</span>' end) [POCRate]")
        Query.Append("   ,FORMAT([A].POCDate,'MM/dd/yyyy') [POCDate] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '006' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title") + " - " + DR("Name"),
                        .POCRate = DR("POCRate"),
                        .POCDate = DR("POCDate"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG010501_UpdateContract(FormCode As String, UPID As String, UPRate As String, UPDate As String)
        If UPRate = "" Or UPDate = "" Then
            Return "<i class='las la-exclamation-circle text-danger fs-2'></i>&nbsp Error"
        Else

            'create connection
            Dim SqlConn As New SqlClient.SqlConnection
            Dim SqlCmd As New SqlCommand
            SqlConn.ConnectionString = "Data Source=" & DataSource & "; Initial Catalog=" & catalog & "; User ID=" & UserID & "; Password=" & Password
            SqlCmd.CommandTimeout = 1500
            SqlCmd.Connection = SqlConn
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.CommandText = "Upd_CON_Progress"
            SqlCmd.Parameters.AddWithValue("@pFormCode", FormCode)
            SqlCmd.Parameters.AddWithValue("@pID", UPID)
            SqlCmd.Parameters.AddWithValue("@pSubID", "006")
            SqlCmd.Parameters.AddWithValue("@pPOCRate", CDbl(UPRate))
            SqlCmd.Parameters.AddWithValue("@pPOCDate", UPDate)
            SqlCmd.Parameters.AddWithValue("@pRemarks", "")
            SqlCmd.Parameters.AddWithValue("@pMention", "")
            SqlCmd.Parameters.AddWithValue("@pUpdatedBy", CIIS_EmpCode)
            'create connection

            'execute procedure
            SqlConn.Open()
            SqlCmd.ExecuteNonQuery()
            SqlConn.Close()
            'execute procedure

            Return "<i class='las la-check-circle text-success fs-2'></i>&nbsp Success"
        End If
    End Function

#End Region

#Region "PDD010301"

    Function PDD010301_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function PDD010301_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '007' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function PDD010301_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '007' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG040101"

    Function ENG040101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG040101_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '008' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG040101_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '008' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG040201"

    Function ENG040201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG040201_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '009' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG040201_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '009' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG040301"

    Function ENG040301_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG040301_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '010' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG040301_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '010' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG050101"

    Function ENG050101_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG050101_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '011' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG050101_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '011' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "PDD010201"

    Function PDD010201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function PDD010201_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '012' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function PDD010201_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '012' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG050201"
    Function ENG050201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG050201_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '013' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG050201_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '013' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

#Region "ENG020201"

    Function ENG020201_Filter(SubID, AssignTo, Subd, Phase, Block, Lot, Batch)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '" & SubID & "' ")
        Query.Append("   and [A].Status in ('','Assign', 'Not Started', 'On-Going','Clarify','On-Hold') ")
        If AssignTo <> "" Then Query.Append("   and [A].AssignTo = '" & AssignTo & "' ")
        If Subd <> "" Then Query.Append("   and [C].ProjInit like '%" & Subd & "%' ")
        If Phase <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase like '%" & Subd & " " & Phase & "%' ")
        If Block <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block like '%" & Subd & " " & Phase & " " & Block & "%' ")
        If Lot <> "" Then Query.Append("   and [C].ProjInit + ' ' + [B].Phase + ' ' + [B].Block + ' ' + [B].Lot like '%" & Subd & " " & Phase & " " & Block & " " & Lot & "%' ")
        If Batch <> "" Then Query.Append("   and [B].BatchNo = '" & Batch & "' ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid justify-content-center'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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

    Function ENG020201_Redraw(ID, AssignTo)

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("   ,(case when [A].status in ('Close') then 'Remove' when [A].AssignTo not in ('" & AssignTo & "') then 'Remove' else 'Update' end) [Action] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].HWCode = '" & ID & "' ")
        Query.Append("   and [A].TaskCode = '014' ")
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

                    RecordList.Add(New With {
                        .ID = "tr01" & DR("ID"),
                        .CheckBox = "<div class='form-check form-check-sm form-check-custom form-check-solid me-2 pl-4'><input class='form-check-input row-checkbox' type='checkbox' id='select1' data-id='" & DR("ID") & "' style='width: 18px; height: 18px;'/></div>",
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>",
                        .Action = DR("Action")
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

    Function ENG020201_Close()

        'get query 
        Dim Query As New StringBuilder
        Query.Append("select  ")
        Query.Append("   [G].FormCode + '-' + [A].HWCode [Link] ")
        Query.Append("   ,[B].BatchNo + ' / ' + [C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot + ' / ' + [D].ModelName [Title] ")
        Query.Append("   ,[A].HWCode [ID] ")
        Query.Append("   ,isnull([E].vendor,'-') [Name] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateStart, GETDATE()), 'MM/dd/yyyy') AS [DateStart] ")
        Query.Append("   ,FORMAT(ISNULL([A].DateEnd, GETDATE()), 'MM/dd/yyyy') AS [DateEnd] ")
        Query.Append("   ,dbo.ProperCase([F].first_name) [AssignToName] ")
        Query.Append("   ,[A].AssignTo [AssignToCode] ")
        Query.Append("   ,dbo.Get_Icon([A].AssignTo) [Icon] ")
        Query.Append("	 ,(case when [A].Status = '' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Not Started' then '<span class=""badge badge-hc-new"">Not Started</span>' ")
        Query.Append("          when [A].Status = 'Assign' then '<span class=""badge badge-hc-new"">Assign</span>' ")
        Query.Append("          when [A].Status = 'On-Going' then '<span class=""badge badge-hc-ongoing"">On-Going</span>' ")
        Query.Append("          when [A].Status = 'On-Hold' then '<span class=""badge badge-hc-onhold"">On-Hold</span>' ")
        Query.Append("          when [A].Status = 'Clarify' then '<span class=""badge badge-hc-clarify"">Clarify</span>' ")
        Query.Append("          when [A].Status = 'Complete' then '<span class=""badge badge-hc-complete"">Complete</span>' ")
        Query.Append("          when [A].Status = 'Close' then '<span class=""badge badge-hc-complete"">Close</span>' end) [Status] ")
        Query.Append("from ")
        Query.Append("   Form_HWTask [A] ")
        Query.Append("   left join Form_HWHdr [B] on [A].HWCode = [B].HWCode ")
        Query.Append("   left join calmardblive.dbo.mstr_Projects [C] on [B].Subd = [C].ProjCode ")
        Query.Append("   left join calmardblive.dbo.mstr_HouseModels [D] on [B].House = [D].ModelCode")
        Query.Append("   left join ogm_vendor [E] on [B].Contractor = [E].v_code ")
        Query.Append("   left join employee [F] on [A].AssignTo = [F].emp_no ")
        Query.Append("   left join Mstr_TaskTemplate [G] on [A].TaskCode = [G].TaskCode ")
        Query.Append("where ")
        Query.Append("   [A].TaskCode = '014' ")
        Query.Append("   and [A].Status in ('Complete','Close') ")
        Query.Append("order by ")
        Query.Append("   [B].BatchNo ")
        Query.Append("   ,[C].ProjInit + ' ' + [B].Phase + ' B' + [B].Block + ' L' + [B].Lot ")
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

                    RecordList.Add(New With {
                        .ID = "tr04" & DR("ID"),
                        .Link = "<a href='#' onclick=""window.open('" & DR("Link") & "');"" >" & DR("ID") & "</a>",
                        .Title = DR("Title"),
                        .DateStart = DR("DateStart"),
                        .DateEnd = DR("DateEnd"),
                        .Status = DR("Status"),
                        .AssignTo = "<div class='d-flex align-items-center'><div Class='symbol symbol-20px symbol-circle'><div Class='symbol-label' style='background-image:url(Assets/media/avatars/" & DR("AssignToCode") & ".png)'></div></div>&nbsp" & DR("AssignToName") & "</div>"
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