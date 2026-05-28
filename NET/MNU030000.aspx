<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="MNU030000.aspx.vb" Inherits="NET.MNU030000" MaintainScrollPositionOnPostback = "true"%>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
    <!--begin::Post-->
	<div class="content flex-row-fluid" id="kt_content">
		
		<!--begin::breadcrumb bar-->
		<asp:UpdatePanel ID="upnlBreadcrumbbar" runat="server" UpdateMode="Conditional" class="toolbar py-5">
		<ContentTemplate>
			<!--begin::Container-->
			<div class="container-xxl d-flex flex-stack flex-wrap p-0">
				<!--begin::Page title-->
				<div class="page-title d-flex flex-column me-3">
					<!--begin::Title-->
					<h1 class="d-flex text-white fw-bolder my-1 fs-3">What's New</h1>
					<!--end::Title-->
					<!--begin::Breadcrumb-->
					<ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
						<!--begin::Item-->
						<li class="breadcrumb-item text-white">Bug fixes and new feature in the system</li>
						<!--end::Item-->
					</ul>
					<!--end::Breadcrumb-->
				</div>
				<!--end::Page title-->
			</div>
			<!--begin::Container-->
		</ContentTemplate>
		</asp:UpdatePanel>
		<!--begin::breadcrumb bar-->

		<div class="card card-flush">
			
			<!--begin::Body-->
			<div class="card-body" >
				<div class="d-flex flex-column">
					<div class="d-flex flex-row">
						<div class="d-flex flex-column me-5">
							<div class="symbol symbol-25px">
								<img src="Assets/media/svg/apps/MNU030000_Date.svg" alt="" />
							</div>
						</div>
						<div class="d-flex flex-column ">
							<span class="fs-3 fw-bolder">7th February 2025 - Release Notes</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_New.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">What's New</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> Stock Issuance  (For Site Warehouseman)
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Bug.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Fixed Bugs & Errors</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Change status button not responding on House Task Detail</span>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Unable to edit departments designated fields/remarks for Occupancy Clearance</span>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Total Expense not equal to the actual cash liquidation under replenishment</span>
						</div>
					</div>
				</div>
			</div>
			<!--end::Body-->
				
			<!--begin::Body-->
			<div class="card-body" >
				<div class="d-flex flex-column">
					<div class="d-flex flex-row">
						<div class="d-flex flex-column me-5">
							<div class="symbol symbol-25px">
								<img src="Assets/media/svg/apps/MNU030000_Date.svg" alt="" />
							</div>
						</div>
						<div class="d-flex flex-column ">
							<span class="fs-3 fw-bolder">5th February 2025 - Release Notes</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Upgrade.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Modification</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Remove restriction on creating contract billing for easy access</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Bug.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Fixed Bugs & Errors</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Posted BOM not displaying when requesting materials for construction</span>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Adding material from BOM not responding</span>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Project description not displaying in SRA form</span>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Unable to edit departments designated fields/remarks for Contruction Clearance</span>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Unable to edit departments designated fields/remarks for TCT Clearance</span>
						</div>
					</div>
				</div>
			</div>
			<!--end::Body-->
				
			<!--begin::Body-->
			<div class="card-body" >
				<div class="d-flex flex-column">
					<div class="d-flex flex-row">
						<div class="d-flex flex-column me-5">
							<div class="symbol symbol-25px">
								<img src="Assets/media/svg/apps/MNU030000_Date.svg" alt="" />
							</div>
						</div>
						<div class="d-flex flex-column ">
							<span class="fs-3 fw-bolder">4th February 2025 - Release Notes</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Upgrade.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Modification</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Additional type for AAA 'Updating Buyers Profile'</span>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Change the UI of Work Order main page same with Form main page</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Bug.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Fixed Bugs & Errors</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Cannot change status of work order</span>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Cannot save work order under EWT Payment</span>
						</div>
					</div>
				</div>
			</div>
			<!--end::Body-->
								
			<!--begin::Body-->
			<div class="card-body" >
				<div class="d-flex flex-column">
					<div class="d-flex flex-row">
						<div class="d-flex flex-column me-5">
							<div class="symbol symbol-25px">
								<img src="Assets/media/svg/apps/MNU030000_Date.svg" alt="" />
							</div>
						</div>
						<div class="d-flex flex-column ">
							<span class="fs-3 fw-bolder">28th January 2025 - Release Notes</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_New.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">What's New</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0001" class="fs-5"> Warehouse Transfer (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0002" class="fs-5"> Warehouse Cancelled (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0003" class="fs-5"> Cycle (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0004" class="fs-5"> PR Under OSM (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0005" class="fs-5"> For Deliver (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0006" class="fs-5"> PO Notes (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0007" class="fs-5"> COF Approval Monitoring (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0008" class="fs-5"> Warehouse Inventory (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0010" class="fs-5"> Procurement (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0011" class="fs-5"> Warehouse Issuance (SCM Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="SCMRT0012" class="fs-5"> Warehouse Receiving (SCM Report)</a>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Bug.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Fixed Bugs & Errors</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Department signatories not display when printing RS Form</span>
						</div>
					</div>
				</div>
			</div>
			<!--end::Body-->

			<!--begin::Body-->
			<div class="card-body" >
				<div class="d-flex flex-column">
					<div class="d-flex flex-row">
						<div class="d-flex flex-column me-5">
							<div class="symbol symbol-25px">
								<img src="Assets/media/svg/apps/MNU030000_Date.svg" alt="" />
							</div>
						</div>
						<div class="d-flex flex-column ">
							<span class="fs-3 fw-bolder">27th January 2025 - Release Notes</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_New.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">What's New</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="ENGRTView?FormCode=ENGRT0001" class="fs-5"> OSM Material Monitoring (CON Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="ENGRT0002" class="fs-5"> Batch Monitoring (CON Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="ENGRT0003" class="fs-5"> COD Form Monitoring (CON Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="ENGRT0004" class="fs-5"> Billing Monitoring (CON Report)</a>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Upgrade.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Modification</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Added column Contract No. in Contract Billing Form Module</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Bug.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Fixed Bugs & Errors</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Exclude Amount of Revolving Fund in Breakdown of Fund total</span>
						</div>
					</div>
				</div>
			</div>
			<!--end::Body-->
			
			<!--begin::Body-->
			<div class="card-body" >
				<div class="d-flex flex-column">
					<div class="d-flex flex-row">
						<div class="d-flex flex-column me-5">
							<div class="symbol symbol-25px">
								<img src="Assets/media/svg/apps/MNU030000_Date.svg" alt="" />
							</div>
						</div>
						<div class="d-flex flex-column ">
							<span class="fs-3 fw-bolder">24th January 2025 - Release Notes</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Upgrade.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Modification</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Remove access restriction for House Contruction > Task for easy access</span>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Remove access restriction for Contract Billing for easy access</span>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Auto compute VAT and EWT on Contract Awarding</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Bug.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Fixed Bugs & Errors</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Employee name not displaying in notification panel when viewing at safari browser</span>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Form title not displaying in form home page when viewing at safari browser</span>
						</div>
					</div>
				</div>
			</div>
			<!--end::Body-->

			<!--begin::Body-->
			<div class="card-body" >
				<div class="d-flex flex-column">
					<div class="d-flex flex-row">
						<div class="d-flex flex-column me-5">
							<div class="symbol symbol-25px">
								<img src="Assets/media/svg/apps/MNU030000_Date.svg" alt="" />
							</div>
						</div>
						<div class="d-flex flex-column ">
							<span class="fs-3 fw-bolder">23rd January 2025 - Release Notes</span>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_New.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">What's New</span>
							</div>
						</div>
						
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Release notes allows employee to see the changes in the system</span>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0001" class="fs-5"> Land Inventory (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRTView?FormCode=PDDRT0002" class="fs-5"> Overall Inventory Status (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRTView?FormCode=PDDRT0003" class="fs-5"> Hold Units Breakdown (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRTView?FormCode=PDDRT0004" class="fs-5"> Overall Open (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0005" class="fs-5"> Actual Sale Report (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0006" class="fs-5"> Total Gross Sale (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0007" class="fs-5"> Gross Sale Report (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0008" class="fs-5"> H&L Gross Sale Breakdown (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0009" class="fs-5"> LO Gross Sale Breakdown (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0010" class="fs-5"> Gross sale (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0011" class="fs-5"> PDD Promos (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0012" class="fs-5"> Price List (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0013" class="fs-5"> Price List (per Unit) (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0014" class="fs-5"> Reserved Sale (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0015" class="fs-5"> Cancellation (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0016" class="fs-5"> Summary of Promo Discount (PDD Report)</a>
						</div>
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <a href="PDDRT0017" class="fs-5"> Tracking of Cancelled Units (PDD Report)</a>
						</div>
					</div>
					<div class="d-flex align-items-center px-10 mt-5">
						<div class="d-flex flex-row mb-4">
							<div class="d-flex flex-column me-5">
								<div class="symbol symbol-20px">
									<img src="Assets/media/svg/apps/MNU030000_Upgrade.svg" alt="" />
								</div>
							</div>
							<div class="d-flex flex-column ">
								<span class="fs-5 fw-bolder">Modification</span>
							</div>
						</div>
					</div>
					<div class="d-flex flex-column">
						<div class="d-flex align-items-center px-20">
							<span class="bullet bg-dark me-5"></span> <span class="fs-5"> Account Activity Advice additional fields (Model House, Lot Area, Sending Notice Date, Declaration Date and Last Feedback Date)</span>
						</div>
					</div>
				</div>
			</div>
			<!--end::Body-->
		</div>
			
	</div>
	<!--end::Post-->
	
</asp:Content>
