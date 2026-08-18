Imports System.Web.SessionState
Imports System.Web.Routing

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub

    Private Shared Sub RegisterRoutes(ByVal routes As RouteCollection)

        'Menu
        routes.MapPageRoute("Caller", "Caller", "~/Caller.aspx")
        routes.MapPageRoute("Form Approval Path", "APP010000", "~/APP010000.aspx")
        routes.MapPageRoute("Updater", "Updater", "~/Updater.aspx")
        routes.MapPageRoute("Sign In", "MNU010100", "~/MNU010100.aspx")
        routes.MapPageRoute("Sign Up", "MNU010200", "~/MNU010200.aspx")
        routes.MapPageRoute("Change Password", "MNU010300", "~/MNU010300.aspx")
        routes.MapPageRoute("Reset Password", "MNU010400", "~/MNU010400.aspx")
        routes.MapPageRoute("Notification", "MNU020100", "~/MNU020100.aspx")
        routes.MapPageRoute("Preview / Download File", "MNU020200", "~/MNU020200.aspx")
        routes.MapPageRoute("Purchase Order - Preview / Download File", "MNU020300", "~/MNU020300.aspx")
        routes.MapPageRoute("Patch Note", "MNU030000", "~/MNU030000.aspx")
        routes.MapPageRoute("Account - Personal Settings - Profile", "ACC010100", "~/ACC010100.aspx")
        routes.MapPageRoute("Account - Personal Settings - Change Password", "ACC010200", "~/ACC010200.aspx")
        routes.MapPageRoute("Account - Personal Settings - Notification", "ACC010300", "~/ACC010300.aspx")
        routes.MapPageRoute("Account - HRMS and Payroll - Daily Time Record", "ACC020100", "~/ACC020100.aspx")
        routes.MapPageRoute("Account - HRMS and Payroll - Leave Balance", "ACC020200", "~/ACC020200.aspx")
        routes.MapPageRoute("Account - HRMS and Payroll - Payslip", "ACC020300", "~/ACC020300.aspx")
        routes.MapPageRoute("Account - Monitoring - Liquidation", "ACC030100", "~/ACC030100.aspx")
        routes.MapPageRoute("Account - Monitoring - Cost Control", "ACC030200", "~/ACC030200.aspx")
        routes.MapPageRoute("Fixed Asset Type", "AMD010000", "~/AMD010000.aspx")
        routes.MapPageRoute("Fixed Asset - HDR", "AMD020000", "~/AMD020000.aspx")
        routes.MapPageRoute("Fixed Asset - DTL", "AMD020100-{Mode}-{ID}", "~/AMD020100.aspx")
        routes.MapPageRoute("Fixed Asset Issuance", "AMD030000", "~/AMD030000.aspx")
        routes.MapPageRoute("Fixed Asset Issuance - DTL", "AMD030100-{Mode}-{ID}", "~/AMD030100.aspx")
        routes.MapPageRoute("Access Denied", "MNU000022", "~/MNU000022.aspx")
        routes.MapPageRoute("Liquidation", "MNU000023", "~/MNU000023.aspx")
        routes.MapPageRoute("Replenishment", "MNU000024", "~/MNU000024.aspx")
        'Menu

        'HRA
        routes.MapPageRoute("HRA - Work Shift", "HRA010000", "~/HRA010000.aspx")
        'HRA

        'PDD
        routes.MapPageRoute("PDD - Permit : Building Permit - HDR", "PDD010100", "~/PDD010100.aspx")
        routes.MapPageRoute("PDD - Permit : Building Permit - DTL", "PDD010101-{ID}", "~/PDD010101.aspx")
        routes.MapPageRoute("PDD - Permit : Inspection - HDR", "PDD010200", "~/PDD010200.aspx")
        routes.MapPageRoute("PDD - Permit : Inspection - DTL", "PDD010201-{ID}", "~/PDD010201.aspx")
        routes.MapPageRoute("PDD - Permit : COO / CEI - HDR", "PDD010300", "~/PDD010300.aspx")
        routes.MapPageRoute("PDD - Permit : COO / CEI - DTL", "PDD010301-{ID}", "~/PDD010301.aspx")
        routes.MapPageRoute("PDD - RPT - Land Inventory", "PDDRT0001", "~/PDDRT0001.aspx")
        routes.MapPageRoute("PDD - RPT - Actual Sale Report", "PDDRT0005", "~/PDDRT0005.aspx")
        routes.MapPageRoute("PDD - RPT - Total Gross Sale", "PDDRT0006", "~/PDDRT0006.aspx")
        routes.MapPageRoute("PDD - RPT - Gross Sale Report", "PDDRT0007", "~/PDDRT0007.aspx")
        routes.MapPageRoute("PDD - RPT - H&L Gross Sale Breakdown", "PDDRT0008", "~/PDDRT0008.aspx")
        routes.MapPageRoute("PDD - RPT - LO Gross Sale Breakdown", "PDDRT0009", "~/PDDRT0009.aspx")
        routes.MapPageRoute("PDD - RPT - Gross sale", "PDDRT0010", "~/PDDRT0010.aspx")
        routes.MapPageRoute("PDD - RPT - PDD Promos", "PDDRT0011", "~/PDDRT0011.aspx")
        routes.MapPageRoute("PDD - RPT - Price List", "PDDRT0012", "~/PDDRT0012.aspx")
        routes.MapPageRoute("PDD - RPT - Price List (per Unit)", "PDDRT0013", "~/PDDRT0013.aspx")
        routes.MapPageRoute("PDD - RPT - Reserved Sale", "PDDRT0014", "~/PDDRT0014.aspx")
        routes.MapPageRoute("PDD - RPT - Cancellation", "PDDRT0015", "~/PDDRT0015.aspx")
        routes.MapPageRoute("PDD - RPT - Summary of Promo Discount", "PDDRT0016", "~/PDDRT0016.aspx")
        routes.MapPageRoute("PDD - RPT - Tracking of Cancelled Units", "PDDRT0017", "~/PDDRT0017.aspx")
        routes.MapPageRoute("PDD - RPT - View", "PDDRTView", "~/PDDRTView.aspx")
        'PDD

        'PDD - Merge Lots
        routes.MapPageRoute("PDD - Masterlist : Merge Lots - HDR", "PDD090000", "~/PDD090000.aspx")
        routes.MapPageRoute("PDD - Masterlist : Merge Lots - DTL", "PDD090100-{Mode}-{ID}", "~/PDD090100.aspx")
        'PDD - Merge Lots

        'Engineering
        routes.MapPageRoute("ENG - Planning and Design : Construction Drawings - HDR", "ENG020100", "~/ENG020100.aspx")
        routes.MapPageRoute("ENG - Planning and Design : Construction Drawings - DTL", "ENG020101-{ID}", "~/ENG020101.aspx")
        routes.MapPageRoute("ENG - Planning and Design : Permit Plan - HDR", "ENG020200", "~/ENG020200.aspx")
        routes.MapPageRoute("ENG - Planning and Design : Permit Plan - DTL", "ENG020201-{ID}", "~/ENG020201.aspx")
        routes.MapPageRoute("ENG - Cost Estimate : House - HDR", "ENG030100", "~/ENG030100.aspx")
        routes.MapPageRoute("ENG - Cost Estimate : House - DTL", "ENG030101-{ID}", "~/ENG030101.aspx")
        routes.MapPageRoute("ENG - Construction : Land Development (New) - HDR", "ENG010100", "~/ENG010100.aspx")
        routes.MapPageRoute("ENG - Construction : Development (New) - DTL", "ENG010101-{ID}", "~/ENG010101.aspx")
        routes.MapPageRoute("ENG - Construction : Land Development (Repair) - HDR", "ENG010200", "~/ENG010200.aspx")
        routes.MapPageRoute("ENG - Construction : Land Development (Repair) - DTL", "ENG010201-{ID}", "~/ENG010201.aspx")
        routes.MapPageRoute("ENG - Construction : Amenities (New) - HDR", "ENG010300", "~/ENG010300.aspx")
        routes.MapPageRoute("ENG - Construction : Amenities (New) - DTL", "ENG010301-{ID}", "~/ENG010301.aspx")
        routes.MapPageRoute("ENG - Construction : Amenities (Repair) - HDR", "ENG010400", "~/ENG010400.aspx")
        routes.MapPageRoute("ENG - Construction : Amenities (Repair) - DTL", "ENG010401-{ID}", "~/ENG010401.aspx")
        routes.MapPageRoute("ENG - Construction : House (New) - HDR", "ENG010500", "~/ENG010500.aspx")
        routes.MapPageRoute("ENG - Construction : House (New) - DTL", "ENG010501-{ID}", "~/ENG010501.aspx")
        routes.MapPageRoute("ENG - Construction : House (Repair) - HDR", "ENG010600", "~/ENG010600.aspx")
        routes.MapPageRoute("ENG - Construction : House (Repair) - DTL", "ENG010601-{ID}", "~/ENG010601.aspx")
        routes.MapPageRoute("ENG - Construction : Other Project - HDR", "ENG010700", "~/ENG010700.aspx")
        routes.MapPageRoute("ENG - Construction : Other Project - DTL", "ENG010701-{ID}", "~/ENG010701.aspx")
        routes.MapPageRoute("ENG - Property Management : Temporary Facility - HDR", "ENG040100", "~/ENG040100.aspx")
        routes.MapPageRoute("ENG - Property Management : Temporary Facility - DTL", "ENG040101-{ID}", "~/ENG040101.aspx")
        routes.MapPageRoute("ENG - Property Management : Extension of Facilities - HDR", "ENG040200", "~/ENG040200.aspx")
        routes.MapPageRoute("ENG - Property Management : Extension of Facilities - DTL", "ENG040201-{ID}", "~/ENG040201.aspx")
        routes.MapPageRoute("ENG - Property Management : Punchlist / Turn-Over - HDR", "ENG040300", "~/ENG040300.aspx")
        routes.MapPageRoute("ENG - Property Management : Punchlist / Turn-Over - DTL", "ENG040301-{ID}", "~/ENG040301.aspx")
        routes.MapPageRoute("ENG - Survey : TOPO - HDR1", "TOPOTEST", "~/TOPOTEST.aspx")
        routes.MapPageRoute("ENG - Survey : TOPO - HDR", "ENG050100", "~/ENG050100.aspx")
        routes.MapPageRoute("ENG - Survey : TOPO - DTL", "ENG050101-{ID}", "~/ENG050101.aspx")
        routes.MapPageRoute("ENG - Survey : Relocation - HDR", "ENG050200", "~/ENG050200.aspx")
        routes.MapPageRoute("ENG - Survey : Relocation - DTL", "ENG050201-{ID}", "~/ENG050201.aspx")
        routes.MapPageRoute("ENG - Survey : POC Upload", "ENG060000", "~/ENG060000.aspx")
        routes.MapPageRoute("ENG - Report - Batch Monitoring", "ENGRT0002", "~/ENGRT0002.aspx")
        routes.MapPageRoute("ENG - Report - COD Form Monitoring", "ENGRT0003", "~/ENGRT0003.aspx")
        routes.MapPageRoute("ENG - Report - Billing Monitoring", "ENGRT0004", "~/ENGRT0004.aspx")
        routes.MapPageRoute("ENG - Report - BOQ Monitoring", "ENGRT0010", "~/ENGRT0010.aspx")
        routes.MapPageRoute("ENG - RPT - View", "ENGRTView", "~/ENGRTView.aspx")
        'Engineering

        'Seller's Admin
        routes.MapPageRoute("Seller Masterlist", "SLS010000", "~/SLS010000.aspx")
        routes.MapPageRoute("Seller Registration", "SLS020000", "~/SLS020000.aspx")
        routes.MapPageRoute("Reservation Monitoring", "SLS030000", "~/SLS030000.aspx")
        routes.MapPageRoute("Lot Inventory", "SLS040000", "~/SLS040000.aspx")
        routes.MapPageRoute("Sales Monitoring", "SLS050000", "~/SLS050000.aspx")
        routes.MapPageRoute("Seller Ranking", "SLS060000", "~/SLS060000.aspx")
        routes.MapPageRoute("Error", "SEP000001", "~/SEP000001.aspx")
        'Seller's Admin

        'AAD
        routes.MapPageRoute("AAD - Account Transaction", "AAD010000", "~/AAD010000.aspx")
        routes.MapPageRoute("AAD - Account Transaction : Request and Inquiry", "AAD010300", "~/AAD010300.aspx")
        routes.MapPageRoute("AAD - Account Transaction : Submitted PDC", "AAD010400", "~/AAD010400.aspx")
        routes.MapPageRoute("AAD - Account Transaction : Submitted Remittance", "AAD010500", "~/AAD010500.aspx")
        routes.MapPageRoute("AAD - Account Transaction : Pending Requirements", "AAD010600", "~/AAD010600.aspx")
        routes.MapPageRoute("AAD - Account Transaction : Documentary", "AAD010100", "~/AAD010100.aspx")
        routes.MapPageRoute("AAD - Account Transaction : Downloadables", "AAD010200", "~/AAD010200.aspx")
        routes.MapPageRoute("AAD - Account Transaction : PDC For Verification", "AAD010700", "~/AAD010700.aspx")
        routes.MapPageRoute("AAD - Account Transaction : PDC Verified", "AAD010800", "~/AAD010800.aspx")
        'AAD
        routes.MapPageRoute("AAD - Account Inquiry", "AAD002000", "~/AAD002000.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - Info", "AAD002001", "~/AAD002001.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - Non ICR Schedule", "AAD002002", "~/AAD002002.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - Account Diary", "AAD002013", "~/AAD002013.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - Seller", "AAD002014", "~/AAD002014.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - Buyers Folder - Documents", "AAD002016", "~/AAD002016.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - Buyers Folder - Others", "AAD002017", "~/AAD002017.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - Update Buyers Information", "AAD002031", "~/AAD002031.aspx")
        routes.MapPageRoute("AAD - Account Inquiry - House Turnover Schedule", "AAD002034", "~/AAD002034.aspx")

        'Finance
        routes.MapPageRoute("FIN - Billing", "FIN010000", "~/FIN010000.aspx")
        routes.MapPageRoute("FIN - Replenishment", "FIN020000", "~/FIN020000.aspx")
        routes.MapPageRoute("FIN - Budget Approval : House - HDR", "FIN030100", "~/FIN030100.aspx")
        routes.MapPageRoute("FIN - Budget Approval : House - DTL", "FIN030101-{ID}", "~/FIN030101.aspx")
        routes.MapPageRoute("FIN - RPT - GL Balance", "FINRT0001", "~/FINRT0001.aspx")
        routes.MapPageRoute("FIN - RPT - GL Detail", "FINRT0021", "~/FINRT0021.aspx")
        routes.MapPageRoute("FIN - RPT - SL Balance", "FINRT0010", "~/FINRT0010.aspx")
        routes.MapPageRoute("FIN - RPT - SL Detail", "FINRT0019", "~/FINRT0019.aspx")
        routes.MapPageRoute("FIN - RPT - Trial Balance", "FINRT0006", "~/FINRT0006.aspx")
        routes.MapPageRoute("FIN - RPT - GL Financial Report - HDR", "FINRT0023", "~/FINRT0023.aspx")
        routes.MapPageRoute("FIN - RPT - Schedule of Released Checks", "FINRT0018", "~/FINRT0018.aspx")
        routes.MapPageRoute("FIN - RPT - A/P Aging Report", "FINRT0016", "~/FINRT0016.aspx")
        routes.MapPageRoute("FIN - RPT - Schedule Of Creditable Input Tax", "FINRT0004", "~/FINRT0004.aspx")
        routes.MapPageRoute("FIN - RPT - Schedule of Withholding Tax - Expanded", "FINRT0005", "~/FINRT0005.aspx")
        routes.MapPageRoute("FIN - RPT - Cash Advance Aging", "FINRT0015", "~/FINRT0015.aspx")
        routes.MapPageRoute("FIN - RPT - Income Recognition", "FINRT0013", "~/FINRT0013.aspx")
        routes.MapPageRoute("FIN - RPT - Land Inventory", "FINRT0014", "~/FINRT0014.aspx")
        routes.MapPageRoute("FIN - RPT - Capital Expenditure Request", "FINRT0009", "~/FINRT0009.aspx")
        routes.MapPageRoute("FIN - RPT - View", "FINRTView", "~/FINRTView.aspx")
        routes.MapPageRoute("FIN - Cashiering - HDR", "FIN090000", "~/FIN090000.aspx")
        routes.MapPageRoute("FIN - Cashiering - DTL", "FIN090100-{Mode}-{ID}-{Date}-{AcctNo}", "~/FIN090100.aspx")
        'Finance

        'SCM
        routes.MapPageRoute("SCM - Contract Mangement : Projects", "SCM010100", "~/SCM010100.aspx")
        routes.MapPageRoute("SCM - Contract Mangement : OnGoing", "SCM010200", "~/SCM010200.aspx")
        routes.MapPageRoute("SCM - Contract Mangement : Completed", "SCM010300", "~/SCM010300.aspx")
        routes.MapPageRoute("SCM - Contract Mangement : Cancelled", "SCM010400", "~/SCM010400.aspx")
        routes.MapPageRoute("SCM - Contractor Registration", "SCM020000", "~/SCM020000.aspx")
        routes.MapPageRoute("SCM - Contractor Registration - For Approval", "SCM020100-{Mode}-{ID}", "~/SCM020100.aspx")
        routes.MapPageRoute("SCM - Contractor Registration - For Resubmission", "SCM020200-{Mode}-{ID}", "~/SCM020200.aspx")
        routes.MapPageRoute("SCM - Contractor Registration - Approved", "SCM020300-{Mode}-{ID}", "~/SCM020300.aspx")
        routes.MapPageRoute("SCM - Contractor Registration - Declined", "SCM020400-{Mode}-{ID}", "~/SCM020400.aspx")
        routes.MapPageRoute("SCM - Contract Management : Project Details", "SCM000006-{ID}", "~/SCM000006.aspx")
        routes.MapPageRoute("SCM - Contract Management : Construction Details", "SCM000007-{ID}", "~/SCM000007.aspx")
        routes.MapPageRoute("SCM - Preview", "SCM020200", "~/SCM020200.aspx")
        routes.MapPageRoute("SCM - Contract Awarding : House - HDR", "SCM030100", "~/SCM030100.aspx")
        routes.MapPageRoute("SCM - Contract Awarding : House - DTL", "SCM030101-{ID}", "~/SCM030101.aspx")
        routes.MapPageRoute("SCM - Contract Mangement : Projects - Detail", "SCM010101-{Mode}-{ID}", "~/SCM010101.aspx")
        routes.MapPageRoute("SCM - Contract Mangement : Batch - Detail", "SCM010102-{Mode}-{ID}", "~/SCM010102.aspx")
        routes.MapPageRoute("SCM - Item Receiving (For Site Warehouseman)", "SCM040000", "~/SCM040000.aspx")
        routes.MapPageRoute("SCM - Stock Issuance (For Site Warehouseman)", "SCM050000", "~/SCM050000.aspx")
        routes.MapPageRoute("SCM - RPT - Warehouse Transfer", "SCMRT0001", "~/SCMRT0001.aspx")
        routes.MapPageRoute("SCM - RPT - Warehouse Cancelled", "SCMRT0002", "~/SCMRT0002.aspx")
        routes.MapPageRoute("SCM - RPT - Cycle Report", "SCMRT0003", "~/SCMRT0003.aspx")
        routes.MapPageRoute("SCM - RPT - PR Under OSM", "SCMRT0004", "~/SCMRT0004.aspx")
        routes.MapPageRoute("SCM - RPT - For Deliver", "SCMRT0005", "~/SCMRT0005.aspx")
        routes.MapPageRoute("SCM - RPT - PO Notes", "SCMRT0006", "~/SCMRT0006.aspx")
        routes.MapPageRoute("SCM - RPT - COF Approval Monitoring", "SCMRT0007", "~/SCMRT0007.aspx")
        routes.MapPageRoute("SCM - RPT - Warehouse Inventory", "SCMRT0008", "~/SCMRT0008.aspx")
        routes.MapPageRoute("SCM - RPT - Procurement Report", "SCMRT0010", "~/SCMRT0010.aspx")
        routes.MapPageRoute("SCM - RPT - Warehouse Issuance", "SCMRT0011", "~/SCMRT0011.aspx")
        routes.MapPageRoute("SCM - RPT - Warehouse Receiving", "SCMRT0012", "~/SCMRT0012.aspx")
        routes.MapPageRoute("SCM - RPT - View", "SCMRTView", "~/SCMRTView.aspx")
        routes.MapPageRoute("SCM - PR Monitoring", "ACC040000", "~/ACC040000.aspx")
        routes.MapPageRoute("SCM - PR Status", "ACC050000", "~/ACC050000.aspx")
        routes.MapPageRoute("ACC - Warehouse Monitoring", "ACC060000", "~/ACC060000.aspx")
        routes.MapPageRoute("SCM - Crystal Report Viewer", "SCMRPTViewer", "~/SCMRPTViewer.aspx")
        'SCM

        'Form Detail
        routes.MapPageRoute("Apps - Form", "FRM010000", "~/FRM010000.aspx")
        routes.MapPageRoute("Apps - Form - Work Order", "FRM000001-{Mode}-{ID}", "~/FRM000001.aspx")
        routes.MapPageRoute("Apps - Form - Business Tech. Support", "FRM000002-{Mode}-{ID}", "~/FRM000002.aspx")
        routes.MapPageRoute("Apps - Form - Change Off", "FRM000003-{Mode}-{ID}", "~/FRM000003.aspx")
        routes.MapPageRoute("Apps - Form - Change Shift", "FRM000004-{Mode}-{ID}", "~/FRM000004.aspx")
        routes.MapPageRoute("Apps - Form - Leave of Absence", "FRM000005-{Mode}-{ID}", "~/FRM000005.aspx")
        routes.MapPageRoute("Apps - Form - Out of Office Work", "FRM000006-{Mode}-{ID}", "~/FRM000006.aspx")
        routes.MapPageRoute("Apps - Form - Undertine", "FRM000007-{Mode}-{ID}", "~/FRM000007.aspx")
        routes.MapPageRoute("Apps - Form - Training Request", "FRM000008-{Mode}-{ID}", "~/FRM000008.aspx")
        routes.MapPageRoute("Apps - Form - Contract Order", "FRM000009-{Mode}-{ID}", "~/FRM000009.aspx")
        routes.MapPageRoute("Apps - Form - Purchase Request", "FRM000010-{Mode}-{ID}", "~/FRM000010.aspx")
        routes.MapPageRoute("Apps - Form - Customer Request", "FRM000011-{Mode}-{ID}", "~/FRM000011.aspx")
        routes.MapPageRoute("Apps - Form - Service Request", "FRM000012-{Mode}-{ID}", "~/FRM000012.aspx")
        routes.MapPageRoute("Apps - Form - Occupancy Clearance", "FRM000013-{Mode}-{ID}", "~/FRM000013.aspx")
        routes.MapPageRoute("Apps - Form - Transaction Log", "FRM000014-{Mode}-{ID}", "~/FRM000014.aspx")
        routes.MapPageRoute("Apps - Form - Cash Advance", "FRM000015-{Mode}-{ID}", "~/FRM000015.aspx")
        routes.MapPageRoute("Apps - Form - Petty Cash", "FRM000016-{Mode}-{ID}", "~/FRM000016.aspx")
        routes.MapPageRoute("Apps - Form - Payment Request", "FRM000017-{Mode}-{ID}", "~/FRM000017.aspx")
        routes.MapPageRoute("Apps - Form - Capital Expenditure Request", "FRM000018-{Mode}-{ID}", "~/FRM000018.aspx")
        routes.MapPageRoute("Apps - Form - Request for Approval", "FRM000019-{Mode}-{ID}", "~/FRM000019.aspx")
        routes.MapPageRoute("Apps - Form - Request for Information", "FRM000020-{Mode}-{ID}", "~/FRM000020.aspx")
        routes.MapPageRoute("Apps - Form - Site Instruction", "FRM000021-{Mode}-{ID}", "~/FRM000021.aspx")
        routes.MapPageRoute("Apps - Form - Construction Clearance", "FRM000022-{Mode}-{ID}", "~/FRM000022.aspx")
        routes.MapPageRoute("Apps - Form - Electric Connection Service", "FRM000023-{Mode}-{ID}", "~/FRM000023.aspx")
        routes.MapPageRoute("Apps - Form - Request for RFO Keys", "FRM000024-{Mode}-{ID}", "~/FRM000024.aspx")
        routes.MapPageRoute("Apps - Form - Water Connection Service", "FRM000025-{Mode}-{ID}", "~/FRM000025.aspx")
        routes.MapPageRoute("Apps - Form - Rawland Documents Turn-over", "FRM000026-{Mode}-{ID}", "~/FRM000026.aspx")
        routes.MapPageRoute("Apps - Form - TCT Clearance", "FRM000027-{Mode}-{ID}", "~/FRM000027.aspx")
        routes.MapPageRoute("Apps - Form - Lot Clearance", "FRM000028-{Mode}-{ID}", "~/FRM000028.aspx")
        routes.MapPageRoute("Apps - Form - Sales Request Advice", "FRM000029-{Mode}-{ID}", "~/FRM000029.aspx")
        routes.MapPageRoute("Apps - Form - Account Activity Advice", "FRM000030-{Mode}-{ID}", "~/FRM000030.aspx")
        routes.MapPageRoute("Apps - Form - Cash Remittance Verification Slip", "FRM000031-{Mode}-{ID}", "~/FRM000031.aspx")
        routes.MapPageRoute("Apps - Form - Transfer of Title Routing Slip", "FRM000032-{Mode}-{ID}", "~/FRM000032.aspx")
        routes.MapPageRoute("Apps - Form - Contract Bill", "FRM000033-{Mode}-{ID}", "~/FRM000033.aspx")
        routes.MapPageRoute("Apps - Form - Job Order", "FRM000034-{Mode}-{ID}", "~/FRM000034.aspx")
        routes.MapPageRoute("Apps - Form - Conference Room Reservation", "FRM000035-{Mode}-{ID}", "~/FRM000035.aspx")
        routes.MapPageRoute("Apps - Form - Survey Request", "FRM000036-{Mode}-{ID}", "~/FRM000036.aspx")
        routes.MapPageRoute("Apps - Form - Work Order (Contracts)", "FRM000037-{Mode}-{ID}", "~/FRM000037.aspx")
        routes.MapPageRoute("Apps - Form - Notice of Delay", "FRM000038-{Mode}-{ID}", "~/FRM000038.aspx")
        routes.MapPageRoute("Apps - Form - Non Conformance Report", "FRM000039-{Mode}-{ID}", "~/FRM000039.aspx")
        routes.MapPageRoute("Apps - Form - Personnel Requesition", "FRM000040-{Mode}-{ID}", "~/FRM000040.aspx")
        routes.MapPageRoute("Apps - Form - Holding Request Form", "FRM000043-{Mode}-{ID}", "~/FRM000043.aspx")
        routes.MapPageRoute("Apps - Form - Audit Document Request", "FRM000047-{Mode}-{ID}", "~/FRM000047.aspx")
        routes.MapPageRoute("Apps - Form - Supplier Performance Evaluation", "FRM000053-{Mode}-{ID}", "~/FRM000053.aspx")
        routes.MapPageRoute("Apps - Form - Price Inquiry", "FRM000054-{Mode}-{ID}", "~/FRM000054.aspx")
        routes.MapPageRoute("Apps - Form - Purchase Request (Updated)", "FRM0000100-{Mode}-{ID}", "~/FRM0000100.aspx")
        'Form Detail

        'Purchase Order
        routes.MapPageRoute("Apps - Data Entry - Purchase Order (HDR)", "SCM060000", "~/SCM060000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Purchase Order (DTL)", "SCM060100-{Mode}-{ID}", "~/SCM060100.aspx")
        'Purchase Order

        'Item Receiving
        routes.MapPageRoute("Apps - Data Entry - Item Receiving (HDR)", "SCM070000", "~/SCM070000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Item Receiving (DTL)", "SCM070100-{Mode}-{ID}", "~/SCM070100.aspx")
        'Item Receiving

        'Stock Issuance
        routes.MapPageRoute("Apps - Data Entry - Stock Issuance (HDR)", "SCM080000", "~/SCM080000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Stock Issuance (DTL)", "SCM080100-{Mode}-{ID}", "~/SCM080100.aspx")
        'Stock Issuance

        'Warehouse Transfer
        routes.MapPageRoute("Apps - Data Entry - Warehouse Transfer (HDR)", "SCM090000", "~/SCM090000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Warehouse Transfer (DTL)", "SCM090100-{Mode}-{ID}", "~/SCM090100.aspx")
        'Warehouse Transfer

        'Item Convertion
        routes.MapPageRoute("Apps - Data Entry - Item Convertion (HDR)", "SCM100000", "~/SCM100000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Item Convertion (DTL)", "SCM100100-{Mode}-{ID}", "~/SCM100100.aspx")
        'Item Convertion

        'Awarding
        routes.MapPageRoute("Apps - Data Entry - Awarding", "SCM110000", "~/SCM110000.aspx")
        'Awarding

        'Cancellation
        routes.MapPageRoute("Apps - Data Entry - Cancellation", "SCM120000", "~/SCM120000.aspx")
        'Cancellation

        'Item Masterlist
        routes.MapPageRoute("Apps - Data Entry - Item Masterlist (HDR)", "SCM130000", "~/SCM130000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Item Masterlist (DTL)", "SCM130100-{Mode}-{ID}", "~/SCM130100.aspx")
        'Item Masterlist

        'Vendor Masterlist
        routes.MapPageRoute("Apps - Data Entry - Vendor Masterlist (HDR)", "SCM140000", "~/SCM140000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Vendor Masterlist (DTL)", "SCM140100-{Mode}-{ID}", "~/SCM140100.aspx")
        'Vendor Masterlist

        'Credit Terms Masterlist
        routes.MapPageRoute("Apps - Data Entry - Credit Terms Masterlist (HDR)", "SCM150000", "~/SCM150000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Credit Terms Masterlist (DTL)", "SCM150100-{Mode}-{ID}", "~/SCM150100.aspx")
        'Credit Terms Masterlist

        'Cost Estimate
        routes.MapPageRoute("Apps - Data Entry - Cost Estimate (HDR)", "FIN170000", "~/FIN170000.aspx")
        routes.MapPageRoute("Apps - Data Entry - Cost Estimate (DTL)", "FIN170100-{Mode}-{ID}", "~/FIN170100.aspx")
        'Cost Estimate

        'Work Order
        routes.MapPageRoute("Apps - Work Order", "WRK010000", "~/WRK010000.aspx")
        routes.MapPageRoute("Apps - Work Order - Detail", "WRK010100-{Mode}-{ID}", "~/WRK010100.aspx")
        'Work Order

        'Dashboard
        routes.MapPageRoute("Dashboard - Home", "DSB010000", "~/DSB010000.aspx")
        routes.MapPageRoute("Dashboard - Personal", "DSB020000", "~/DSB020000.aspx")
        routes.MapPageRoute("Dashboard - Form", "DSB030000", "~/DSB030000.aspx")
        routes.MapPageRoute("Dashboard - House Repair : SRF", "DSB040000", "~/DSB040000.aspx")
        routes.MapPageRoute("Dashboard - House Repair : COF", "DSB040100", "~/DSB040100.aspx")
        routes.MapPageRoute("Dashboard - House Repair : WOC", "DSB040200", "~/DSB040200.aspx")
        routes.MapPageRoute("Dashboard - Purchase Request : PR - OSM Project", "DSB040300", "~/DSB040300.aspx")
        routes.MapPageRoute("Dashboard - Purchase Request : PR - Non OSM Project", "DSB040400", "~/DSB040400.aspx")
        routes.MapPageRoute("Dashboard - House Turn-Over", "DSB050000", "~/DSB050000.aspx")
        routes.MapPageRoute("Dashboard - Land Development", "DSB060000", "~/DSB060000.aspx")
        routes.MapPageRoute("Dashboard - Business Tech. Support - Overview", "DSB070100", "~/DSB070100.aspx")
        routes.MapPageRoute("Dashboard - Business Tech. Support - Status", "DSB070200", "~/DSB070200.aspx")

        routes.MapPageRoute("Dashboard - House Construction", "DSB100000", "~/DSB100000.aspx")

        routes.MapPageRoute("Dashboard - House Construction1", "DSB080000", "~/DSB080000.aspx")
        routes.MapPageRoute("Dashboard - House Construction2", "DSB090000", "~/DSB090000.aspx")
        routes.MapPageRoute("Dashboard - Supply Chain Management - Warehouse Monitoring", "DSB100000", "~/DSB100000.aspx")
        routes.MapPageRoute("Dashboard - Supply Chain Management - Purchasing Monitoring", "DSB100100", "~/DSB100100.aspx")

        routes.MapPageRoute("Property Management", "DSB000002", "~/DSB000002.aspx")
        routes.MapPageRoute("House Construction", "DSB000007", "~/DSB000007.aspx")
        routes.MapPageRoute("House Construction - Overview", "DSB000008", "~/DSB000008.aspx")
        routes.MapPageRoute("House Construction - Territory", "DSB000009", "~/DSB000009.aspx")
        routes.MapPageRoute("House Construction - Project", "DSB000010", "~/DSB000010.aspx")
        routes.MapPageRoute("House Construction - Per Project - Overview", "DSB000011-{ID}", "~/DSB000011.aspx")
        routes.MapPageRoute("House Construction - Per Project - Map", "DSB000012-{ID}", "~/DSB000012.aspx")
        routes.MapPageRoute("House Construction - Per Batch", "DSB000013", "~/DSB000013.aspx")
        routes.MapPageRoute("House Construction - Per Batch - Details", "DSB000014-{YEAR}-{NO}", "~/DSB000014.aspx")
        routes.MapPageRoute("House Construction - Report", "DSB000015", "~/DSB000015.aspx")
        'Dashboard

        'Dashboard - Warehouse
        routes.MapPageRoute("Dashboard - SCM : Warehouse", "DSB240000", "~/DSB240000.aspx")
        routes.MapPageRoute("Dashboard - SCM : Contracts", "DSB250000", "~/DSB250000.aspx")
        routes.MapPageRoute("Dashboard - SCM : Purchasing", "DSB280000", "~/DSB280000.aspx")
        routes.MapPageRoute("Dashboard - FIN : Cost Control", "DSB290000", "~/DSB290000.aspx")
        'Dashboard - Warehouse

    End Sub

End Class

